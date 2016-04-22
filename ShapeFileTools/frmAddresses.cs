using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using Tripodmaps.Reader;

namespace Tripodmaps
{
    public partial class frmAddressDetails : Form
    {
        private long lCurrentAddressNumber = 0;
        private long lCurrentAddressBuildingID = 0;
        private long lCurrentAddressRoadID = 0;
        private long lCurrentAddressOwnerID = 0;
        private long lCurrentAddressOwnerTypeID = 0;
        private long lCurrentAddressAppartmentID = 0;
        private long lCurrentAddressRootID = 0;
        private long lCurrentAddressMapID = 0;

        private string errMessage;
        Tripodmaps.Reader.ShapeFile[] shapefiles;
        Tripodmaps.Reader.ShapeFile buildingshapefile;
        private Tripodmaps.Reader.PointD currentMarkerPosition = new Tripodmaps.Reader.PointD(0, 0);
        private const int MarkerWidth = 10;
        private string strProjectPath = null;

        private string currentProjectPath = null;
        enum ProjectState { NewProject, UnsavedNewProject, OpenProject, UnsavedOpenProject };
        private ProjectState projectStatus = ProjectState.NewProject;

        #region "FormOperations"

        public frmAddressDetails(string strArgProjectPath)
        {
            strProjectPath = strArgProjectPath;
            InitializeComponent();
        }

        private void frmPointOfInterest_Load(object sender, EventArgs e)
        {
            LoadPhysicalAddressMap();
            LoadForm();
        }

        private void LoadForm()
        {
            LoadFirstAddressDetails();
        }

        #endregion


        #region "GIS"

        private void LoadPhysicalAddressMap()
        {
            if (!string.IsNullOrEmpty(strProjectPath))
            {
                OpenProject(strProjectPath);
                FindShapeFile("pointsofinterest.shp");
            }
        }

        public void OpenProject(string projectPath)
        {
            frmAjaxLoading ajLoader = null;

            try
            {
                this.Show();
                ajLoader = new frmAjaxLoading();
                ajLoader.Show();
                ajLoader.Update();


                PointD cntPoint = new PointD(36.8131780839425D, -1.29527436108661D);

                ReadProject(projectPath);
                this.projectStatus = ProjectState.OpenProject;
                this.currentProjectPath = projectPath;
                //AddToRecentProjects(currentProjectPath);
                this.Text = "Tripodmaps - Tripodsystems";

                sfMap1.CentrePoint2D = cntPoint;
                sfMap1.ZoomLevel = 346370.32554;
                sfMap1.Refresh();
            }


            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error reading project :" + ex.ToString());
                MessageBox.Show(this, "Error opening project\n" + ex.Message, "Error opening project",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                ajLoader.Close();
                ajLoader = null;
            }

        }

        private void ReadProject(string path)
        {
            TRIP_API.IMLogin prjFile;

            try
            {
                MemoryStream prjStream;
                XmlDocument doc = new XmlDocument();

                prjFile = new TRIP_API.IMLogin();

                prjFile.CurrentPassword = "jackson1";
                prjStream = prjFile.RudishaFiliKwaMafikira(path);

                doc.Load(prjStream);

                this.Cursor = Cursors.WaitCursor;
                XmlElement prjElement = (XmlElement)doc.GetElementsByTagName("sfproject").Item(0);
                string version = prjElement.GetAttribute("version");
                mainProgressBar.Visible = true;

                this.sfMap1.ReadXml(prjElement, new Tripodmaps.Viewer.ProgressLoadStatusHandler(this.ProjectLoadStatus));
            }

            catch (Exception ex)
            {
                errMessage = ex.Message;
            }

            finally
            {
                mainProgressBar.Visible = false;
                this.Cursor = Cursors.Default;
            }
        }

        private bool IsMapFitForMercator()
        {
            RectangleF ext = sfMap1.Extent;
            return (ext.Top <= 90 && ext.Bottom >= -90);
        }

        private void UpdateVisibleAreaLabel()
        {
            RectangleF r = this.sfMap1.VisibleExtent;
            double w, h;
            if (IsMapFitForMercator())
            {
                //assume using latitude longitude
                w = Tripodmaps.Reader.ConversionFunctions.DistanceBetweenLatLongPoints(Tripodmaps.Reader.ConversionFunctions.RefEllipse,
                    r.Bottom, r.Left, r.Bottom, r.Right);
                h = Tripodmaps.Reader.ConversionFunctions.DistanceBetweenLatLongPoints(Tripodmaps.Reader.ConversionFunctions.RefEllipse,
                    r.Bottom, r.Left, r.Top, r.Left);
            }
            else
            {
                //assume coord in meters
                w = r.Width;
                h = r.Height;
            }
            tsLabelVisibleArea.Text = w.ToString("0000000.0m") + " x " + h.ToString("0000000.0m");
        }

        private void sfMap1_ZoomLevelChanged(object sender, EventArgs args)
        {
            //this.tsLabelCurrentZoom.Text = sfMap1.ZoomLevel.ToString("0.00000");
            UpdateVisibleAreaLabel();
        }

        private void sfMap1_ClientSizeChanged(object sender, EventArgs e)
        {
            UpdateVisibleAreaLabel();

        }

        private void sfMap1_MouseMove(object sender, MouseEventArgs e)
        {
            PointD pt = sfMap1.PixelCoordToGisPoint(new Point(e.X, e.Y));

            string msg = string.Format("[{0},{1}]", new object[] { pt.X, pt.Y });
            tsLblMapMousePos.Text = msg;
        }

        private void sfMap1_MouseUp(object sender, MouseEventArgs e)
        {
            int intMouseRecord = -1;
            if (sfMap1.ShapeFileCount > 0)
            {
                //PointD pt =MousePosToGisPoint(e.X, e.Y);
                PointD pt = sfMap1.PixelCoordToGisPoint(e.X, e.Y);

                intMouseRecord = sfMap1.LocateShapeIndexOnMouseUp(pt, new Point(e.X, e.Y), "rtk.shp");

                if (intMouseRecord >= 0)
                {
                    ZoomToBuildingImpartialIndex(intMouseRecord);

                }
            }
        }

        //Get shapefile with this name
        private bool FindShapeFile(string strArgShapeFileName)
        {

            try
            {
                if (sfMap1 == null)
                {
                    return false;
                }

                shapefiles = new Tripodmaps.Reader.ShapeFile[sfMap1.ShapeFileCount];



                for (int n = 0; n < shapefiles.Length; n++)
                {
                    shapefiles[n] = sfMap1[n];
                    shapefiles[n].ClearSelectedRecords();
                }

                if (shapefiles.GetLength(0) > 0)
                {
                    foreach (Tripodmaps.Reader.ShapeFile shpSearch in shapefiles)
                    {
                        if (shpSearch != null)
                        {
                            if (shpSearch.Name == strArgShapeFileName)
                            {
                                buildingshapefile = shpSearch;
                                return true;
                            }
                        }
                    }

                    return false;


                }
                else
                {
                    return false;
                }

            }

            catch (Exception ex)
            {
                errMessage = ex.Message;
                return false;
            }

            finally
            {

            }

        }

        private void ZoomToBuilding(long lArgBuildingMapID)
        {
            try
            {
                //if sfmap is not empty
                if (sfMap1.ShapeFileCount > 0)
                {
                    //check if buildinghshapefile is present
                    if (FindShapeFile("rtk.shp") == true)
                    {
                        string[] ar = buildingshapefile.GetAttributeFieldNames();

                        if (ar != null)
                        {
                            int intMapOIDIndex = Array.IndexOf(ar, "MAPOID");

                            if (intMapOIDIndex >= 0)
                            {
                                int index = buildingshapefile.RenderSettings.DbfReader.IndexOf(lArgBuildingMapID.ToString(),
                                    intMapOIDIndex, true);

                                if (index >= 0)
                                {
                                    RectangleF bounds = buildingshapefile.GetShapeBounds(index);
                                    if (bounds != RectangleF.Empty)
                                    {
                                        //shapeFileListControl1.SelectedShapeFile.SelectedRecordIndex = index;
                                        buildingshapefile.ClearSelectedRecords();
                                        buildingshapefile.SelectRecord(index, true);
                                        sfMap1.CentrePoint2D = new PointD((bounds.Left + bounds.Right) / 2,
                                            (bounds.Top + bounds.Bottom) / 2);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                errMessage = ex.Message;

            }

            finally
            {

            }

        }

        private void ZoomToBuildingImpartialIndex(int lIndex)
        {
            try
            {
                //if sfmap is not empty
                if (sfMap1.ShapeFileCount > 0)
                {
                    RectangleF bounds = buildingshapefile.GetShapeBounds(lIndex);
                    if (bounds != RectangleF.Empty)
                    {
                        //shapeFileListControl1.SelectedShapeFile.SelectedRecordIndex = index;
                        buildingshapefile.ClearSelectedRecords();
                        buildingshapefile.SelectRecord(lIndex, true);
                        sfMap1.CentrePoint2D = new PointD((bounds.Left + bounds.Right) / 2,
                            (bounds.Top + bounds.Bottom) / 2);

                        string[] ar = buildingshapefile.GetAttributeFieldNames();

                        if (ar != null)
                        {
                            int intMapOIDIndex = Array.IndexOf(ar, "MAPOID");

                            if (intMapOIDIndex >= 0)
                            {
                                string strSelectedMapIDValue = sfMap1.GetFieldValueOfSelectedIndex(buildingshapefile,
                                    lIndex, intMapOIDIndex);

                                if (!string.IsNullOrEmpty(strSelectedMapIDValue))
                                {
                                    LoadBuildingIDNameByMapID(Convert.ToInt64(strSelectedMapIDValue.Trim()));
                                }

                            }
                        }
                    }
                }
            }


            catch (Exception ex)
            {
                errMessage = ex.Message;
            }

            finally
            {

            }

        }

        private void ProjectLoadStatus(int totalLayers, int layersLoaded)
        {

            if (mainProgressBar.Maximum != totalLayers) this.mainProgressBar.Maximum = totalLayers;
            this.mainProgressBar.Value = layersLoaded;
            this.mainProgressBar.Visible = (totalLayers != layersLoaded);
        }

        private void sfMap1_Click(object sender, EventArgs e)
        {

        }

        private void sfMap1_MouseClick(object sender, MouseEventArgs e)
        {
            txtPhysicalAddressCustomerPOI.Text = sfMap1.PixelCoordToGisPoint(e.Location).X.ToString() +
                "," + sfMap1.PixelCoordToGisPoint(e.Location).Y.ToString();

            txtPOICoordinate.Text = sfMap1.PixelCoordToGisPoint(e.Location).X.ToString() +
               "," + sfMap1.PixelCoordToGisPoint(e.Location).Y.ToString();

            currentMarkerPosition.X = sfMap1.PixelCoordToGisPoint(e.Location).X;
            currentMarkerPosition.Y = sfMap1.PixelCoordToGisPoint(e.Location).Y;
            sfMap1.Refresh();


        }

        private void sfMap1_Paint(object sender, PaintEventArgs e)
        {
            Boolean bNotZeroCoordinate = false;

            if (currentMarkerPosition.X != 0.0f)
            {
                bNotZeroCoordinate = true;
            }

            if (currentMarkerPosition.Y != 0.0f)
            {
                bNotZeroCoordinate = true;
            }

            if (bNotZeroCoordinate == true)
            {
                DrawMarker(e.Graphics, currentMarkerPosition.X, currentMarkerPosition.Y);
            }
        }

        //draws a marker at gis location locX,locY
        private void DrawMarker(Graphics g, double locX, double locY)
        {
            //convert the gis location to pixel coordinates
            Point pt = sfMap1.GisPointToPixelCoord(locX, locY);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //draw a marker centered at the gis location
            //alternative is to draw an image/icon
            g.DrawLine(Pens.DarkRed, pt.X, pt.Y - MarkerWidth, pt.X, pt.Y + MarkerWidth);
            g.DrawLine(Pens.DarkRed, pt.X - MarkerWidth, pt.Y, pt.X + MarkerWidth, pt.Y);
            pt.Offset(-MarkerWidth / 2, -MarkerWidth / 2);
            g.FillEllipse(Brushes.Blue, pt.X, pt.Y, MarkerWidth, MarkerWidth);
            g.DrawEllipse(Pens.ForestGreen, pt.X, pt.Y, MarkerWidth, MarkerWidth);
        }


        #endregion


        #region "DatabaseOperations"


        private void LoadFirstAddressDetails()
        {
            TRIP_API.IMAddress imAddress= new TRIP_API.IMAddress();

            try
            {
                imAddress.ReturnFirstAddressDetails();

                lCurrentAddressNumber = imAddress.AddressDetailsID;

                if (imAddress.AddressDetailsID > 0)
                {
                    if (imAddress.AddressDetailsOwnerID > 0)
                    {
                        lCurrentAddressOwnerID = imAddress.AddressDetailsOwnerID;
                    }

                    if (imAddress.AddressDetailsOwnerTypeID > 0)
                    {
                        lCurrentAddressOwnerTypeID = imAddress.AddressDetailsOwnerTypeID;
                    }

                    if (imAddress.AddressDetailsPostalCode != null)
                    {
                        txtPhysicalAddressPostCode.Text = imAddress.AddressDetailsPostalCode.ToString();
                    }

                    if (imAddress.AddressDetailsPostalAddress != null)
                    {
                        txtPhysicalAddressPostalAddress.Text = imAddress.AddressDetailsPostalAddress.ToString();
                    }

                    if (imAddress.AddressDetailsPhysicalAddress != null)
                    {
                        txtPhysicalAddress.Text = imAddress.AddressDetailsPhysicalAddress.ToString();
                    }
                    
                    if (imAddress.AddressDetailsCountryID >= 0)
                    {
                        cmbPhysicalAddressCustomerCountry.SelectedValue = imAddress.AddressDetailsCountryID;
                    }

                    if (imAddress.AddressDetailsCityID >= 0)
                    {
                        cmbPhysicalAddressCustomerCity.SelectedValue = imAddress.AddressDetailsCityID;
                    }

                    if (imAddress.AddressDetailsCountyID >= 0)
                    {
                        cmbPhysicalAddressCustomerCounty.SelectedValue = imAddress.AddressDetailsCountyID;
                    }

                    if (imAddress.AddressDetailsConstituencyID >= 0)
                    {
                        cmbPhysicalAddressCustomerConstituency.SelectedValue = imAddress.AddressDetailsCountryID;
                    }

                    if (imAddress.AddressDetailsProvinceID > 0)
                    {
                        cmbPhysicalAddressCustomerProvince.SelectedValue = imAddress.AddressDetailsProvinceID;
                    }

                    if (imAddress.AddressDetailsDistrictID >= 0)
                    {
                        cmbPhysicalAddressCustomerDistrict.SelectedValue = imAddress.AddressDetailsDistrictID;
                    }

                    if (imAddress.AddressDetailsDivisionID >= 0)
                    {
                        cmbPhysicalAddressCustomerDivision.SelectedValue = imAddress.AddressDetailsDivisionID;
                    }

                    if (imAddress.AddressDetailsLocationID >= 0)
                    {
                        cmbPhysicalAddressCustomerLocation.SelectedValue = imAddress.AddressDetailsLocationID;
                    }

                    if (imAddress.AddressDetailsSublocationID >= 0)
                    {
                        cmbPhysicalAddressCustomerSubLocation.SelectedValue = imAddress.AddressDetailsSublocationID;
                    }

                    if (imAddress.AddressDetailsEstateID >= 0)
                    {
                        txtPhysicalAddressEstate.Text = imAddress.AddressDetailsEstateID.ToString();
                    }

                    if (imAddress.AddressDetailsHouseNumber != null)
                    {
                        txtPhysicalAddress.Text = imAddress.AddressDetailsHouseNumber;
                    }

                    if (imAddress.PhysicalAddressCoordinate != null)
                    {
                        if (imAddress.IsCoordinateZeroCoordinate() != true)
                        {
                            txtPOICoordinate.Text = imAddress.PhysicalAddressCoordinate.X + "," + 
                                imAddress.PhysicalAddressCoordinate.Y;
                            txtPhysicalAddressCustomerPOI.Text = imAddress.PhysicalAddressCoordinate.X + "," +
                                imAddress.PhysicalAddressCoordinate.Y;
                        }
                    }

                    if (imAddress.AddressDetailsTelephone1 != null)
                    {
                        txtPhysicalAddressTelephone1.Text = imAddress.AddressDetailsTelephone1.ToString();
                    }

                    if (imAddress.AddressDetailsTelephone2 != null)
                    {
                        txtPhysicalAddressTelephone2.Text = imAddress.AddressDetailsTelephone2.ToString();
                    }

                    if (imAddress.AddressDetailsMobilePhone1 != null)
                    {
                        txtPhysicalAddressMobilePhone1.Text = imAddress.AddressDetailsMobilePhone1.ToString();
                    }

                    if (imAddress.AddressDetailsMobilePhone2 != null)
                    {
                        txtPhysicalAddressMobilePhone2.Text = imAddress.AddressDetailsMobilePhone2.ToString();
                    }

                    if (imAddress.AddressDetailsFax1 != null)
                    {
                        txtPhysicalAddressFax2.Text = imAddress.AddressDetailsFax1.ToString();
                    }

                    if (imAddress.AddressDetailsFax1 != null)
                    {
                        txtPhysicalAddressFax2.Text = imAddress.AddressDetailsFax2.ToString();
                    }

                    if (imAddress.AddressDetailsCompanyEmail != null)
                    {
                        txtPhysicalAddressCompanyEmail.Text = imAddress.AddressDetailsCompanyEmail.ToString();
                    }

                    if (imAddress.AddressDetailsSalesEmail != null)
                    {
                        txtPhysicalAddressSalesEmail.Text = imAddress.AddressDetailsSalesEmail.ToString();
                    }

                    if (imAddress.AddressDetailsSupportEmail != null)
                    {
                        txtPhysicalAddressSupportEmail.Text = imAddress.AddressDetailsSupportEmail.ToString();
                    }

                    if (imAddress.AddressDetailsUniversalAddress != null)
                    {
                        txtPhysicalAddressUniversalAddress.Text = imAddress.AddressDetailsUniversalAddress.ToString();
                    }

                    if (imAddress.AddressDetailsRoadID > 0)
                    {
                        txtRoadName.Text = imAddress.AddressDetailsRoadID.ToString(); 
                        txtPhysicalAddressRoadName.Text = imAddress.AddressDetailsRoadID.ToString();
                        lCurrentAddressRoadID = imAddress.AddressDetailsRoadID;
                    }

                    if (imAddress.AddressDetailsProjection != null)
                    {
                        cmbPhysicalAddressProjection.Text = imAddress.AddressDetailsProjection.ToString();
                    }

                    if (imAddress.AddressDetailsPointName != null)
                    {
                        txtPointOfInterestName.Text = imAddress.AddressDetailsPointName.ToString();
                    }

                    if (imAddress.AddressDetailsBuildingID > 0)
                    {
                        lCurrentAddressBuildingID = imAddress.AddressDetailsBuildingID;
                        txtPhysicalAddressBuildingName.Text = imAddress.AddressDetailsBuildingID.ToString();
                    }

                    if (imAddress.AddressDetailsRootID  > 0)
                    {
                        lCurrentAddressRootID = imAddress.AddressDetailsRootID;
                    }

                    if (imAddress.AddressDetailsAppartmentID > 0)
                    {
                        lCurrentAddressAppartmentID = imAddress.AddressDetailsAppartmentID;
                    }

                    if (imAddress.AddressDetailsMapID > 0)
                    {
                        lCurrentAddressMapID = imAddress.AddressDetailsMapID;
                    }

                    txtPhysicalAddressUniversalAddress.Focus();
                }

            }

            catch (Exception ex)
            {
                string err = ex.Message + " Source=" + ex.Source;
            }

            finally
            {
                imAddress = null;
            }
            
        }

        private void LoadNextBuildingMaster()
        {            
            TRIP_API.IMAddress imAddress = new TRIP_API.IMAddress();

            try
            {
                imAddress.AddressDetailsID = lCurrentAddressNumber;

                if (imAddress.ReturnNextAddressDetails() == true)
                {
                   
                    lCurrentAddressNumber = imAddress.AddressDetailsID;

                    if (imAddress.AddressDetailsID > 0)
                    {

                        if (imAddress.AddressDetailsOwnerID > 0)
                        {
                            lCurrentAddressOwnerID = imAddress.AddressDetailsOwnerID;
                        }

                        if (imAddress.AddressDetailsOwnerTypeID > 0)
                        {
                            lCurrentAddressOwnerTypeID = imAddress.AddressDetailsOwnerTypeID;
                        }

                        if (imAddress.AddressDetailsPostalCode != null)
                        {
                            txtPhysicalAddressPostCode.Text = imAddress.AddressDetailsPostalCode.ToString();
                        }

                        if (imAddress.AddressDetailsPostalAddress != null)
                        {
                            txtPhysicalAddressPostalAddress.Text = imAddress.AddressDetailsPostalAddress.ToString();
                        }

                        if (imAddress.AddressDetailsPhysicalAddress != null)
                        {
                            txtPhysicalAddress.Text = imAddress.AddressDetailsPhysicalAddress.ToString();
                        }

                        if (imAddress.AddressDetailsCountryID >= 0)
                        {
                            cmbPhysicalAddressCustomerCountry.SelectedValue = imAddress.AddressDetailsCountryID;
                        }

                        if (imAddress.AddressDetailsCityID >= 0)
                        {
                            cmbPhysicalAddressCustomerCity.SelectedValue = imAddress.AddressDetailsCityID;
                        }

                        if (imAddress.AddressDetailsCountyID >= 0)
                        {
                            cmbPhysicalAddressCustomerCounty.SelectedValue = imAddress.AddressDetailsCountyID;
                        }

                        if (imAddress.AddressDetailsConstituencyID >= 0)
                        {
                            cmbPhysicalAddressCustomerConstituency.SelectedValue = imAddress.AddressDetailsCountryID;
                        }

                        if (imAddress.AddressDetailsProvinceID > 0)
                        {
                            cmbPhysicalAddressCustomerProvince.SelectedValue = imAddress.AddressDetailsProvinceID;
                        }

                        if (imAddress.AddressDetailsDistrictID >= 0)
                        {
                            cmbPhysicalAddressCustomerDistrict.SelectedValue = imAddress.AddressDetailsDistrictID;
                        }

                        if (imAddress.AddressDetailsDivisionID >= 0)
                        {
                            cmbPhysicalAddressCustomerDivision.SelectedValue = imAddress.AddressDetailsDivisionID;
                        }

                        if (imAddress.AddressDetailsLocationID >= 0)
                        {
                            cmbPhysicalAddressCustomerLocation.SelectedValue = imAddress.AddressDetailsLocationID;
                        }

                        if (imAddress.AddressDetailsSublocationID >= 0)
                        {
                            cmbPhysicalAddressCustomerSubLocation.SelectedValue = imAddress.AddressDetailsSublocationID;
                        }

                        if (imAddress.AddressDetailsEstateID >= 0)
                        {
                            txtPhysicalAddressEstate.Text = imAddress.AddressDetailsEstateID.ToString();
                        }

                        if (imAddress.AddressDetailsHouseNumber != null)
                        {
                            txtPhysicalAddress.Text = imAddress.AddressDetailsHouseNumber;
                        }

                        if (imAddress.PhysicalAddressCoordinate != null)
                        {
                            if (imAddress.IsCoordinateZeroCoordinate() != true)
                            {
                                txtPOICoordinate.Text = imAddress.PhysicalAddressCoordinate.X + "," +
                                    imAddress.PhysicalAddressCoordinate.Y;
                                txtPhysicalAddressCustomerPOI.Text = imAddress.PhysicalAddressCoordinate.X + "," +
                                    imAddress.PhysicalAddressCoordinate.Y;
                            }
                        }

                        if (imAddress.AddressDetailsTelephone1 != null)
                        {
                            txtPhysicalAddressTelephone1.Text = imAddress.AddressDetailsTelephone1.ToString();
                        }

                        if (imAddress.AddressDetailsTelephone2 != null)
                        {
                            txtPhysicalAddressTelephone2.Text = imAddress.AddressDetailsTelephone2.ToString();
                        }

                        if (imAddress.AddressDetailsMobilePhone1 != null)
                        {
                            txtPhysicalAddressMobilePhone1.Text = imAddress.AddressDetailsMobilePhone1.ToString();
                        }

                        if (imAddress.AddressDetailsMobilePhone2 != null)
                        {
                            txtPhysicalAddressMobilePhone2.Text = imAddress.AddressDetailsMobilePhone2.ToString();
                        }

                        if (imAddress.AddressDetailsFax1 != null)
                        {
                            txtPhysicalAddressFax2.Text = imAddress.AddressDetailsFax1.ToString();
                        }

                        if (imAddress.AddressDetailsFax1 != null)
                        {
                            txtPhysicalAddressFax2.Text = imAddress.AddressDetailsFax2.ToString();
                        }

                        if (imAddress.AddressDetailsCompanyEmail != null)
                        {
                            txtPhysicalAddressCompanyEmail.Text = imAddress.AddressDetailsCompanyEmail.ToString();
                        }

                        if (imAddress.AddressDetailsSalesEmail != null)
                        {
                            txtPhysicalAddressSalesEmail.Text = imAddress.AddressDetailsSalesEmail.ToString();
                        }

                        if (imAddress.AddressDetailsSupportEmail != null)
                        {
                            txtPhysicalAddressSupportEmail.Text = imAddress.AddressDetailsSupportEmail.ToString();
                        }

                        if (imAddress.AddressDetailsUniversalAddress != null)
                        {
                            txtPhysicalAddressUniversalAddress.Text = imAddress.AddressDetailsUniversalAddress.ToString();
                        }

                        if (imAddress.AddressDetailsRoadID > 0)
                        {
                            txtRoadName.Text = imAddress.AddressDetailsRoadID.ToString();
                            txtPhysicalAddressRoadName.Text = imAddress.AddressDetailsRoadID.ToString();
                            lCurrentAddressRoadID = imAddress.AddressDetailsRoadID;
                        }

                        if (imAddress.AddressDetailsProjection != null)
                        {
                            cmbPhysicalAddressProjection.Text = imAddress.AddressDetailsProjection.ToString();
                        }

                        if (imAddress.AddressDetailsPointName != null)
                        {
                            txtPointOfInterestName.Text = imAddress.AddressDetailsPointName.ToString();
                        }

                        if (imAddress.AddressDetailsBuildingID > 0)
                        {
                            lCurrentAddressBuildingID = imAddress.AddressDetailsBuildingID;
                            txtPhysicalAddressBuildingName.Text = imAddress.AddressDetailsBuildingID.ToString();
                        }

                        if (imAddress.AddressDetailsRootID > 0)
                        {
                            lCurrentAddressRootID = imAddress.AddressDetailsRootID;
                        }

                        if (imAddress.AddressDetailsAppartmentID > 0)
                        {
                            lCurrentAddressAppartmentID = imAddress.AddressDetailsAppartmentID;
                        }

                        if (imAddress.AddressDetailsMapID > 0)
                        {
                            lCurrentAddressMapID = imAddress.AddressDetailsMapID;
                        }

                        txtPhysicalAddressBuildingName.Focus();

                    }
                }

            }

            catch (Exception ex)
            {
                string err = ex.Message + " Source=" + ex.Source;
            }

            finally
            {

                imAddress = null;
            }



        }

        private void LoadPreviousBuildingMaster()
        {
            TRIP_API.IMAddress imAddress = new TRIP_API.IMAddress();

            try
            {
                imAddress.AddressDetailsID = lCurrentAddressNumber;

                if (imAddress.ReturnPreviousAddressDetails() == true)
                {                    

                    lCurrentAddressNumber = imAddress.AddressDetailsID;

                    if (imAddress.AddressDetailsID > 0)
                    {
                        if (imAddress.AddressDetailsOwnerID > 0)
                        {
                            lCurrentAddressOwnerID = imAddress.AddressDetailsOwnerID;
                        }

                        if (imAddress.AddressDetailsOwnerTypeID > 0)
                        {
                            lCurrentAddressOwnerTypeID = imAddress.AddressDetailsOwnerTypeID;
                        }

                        if (imAddress.AddressDetailsPostalCode != null)
                        {
                            txtPhysicalAddressPostCode.Text = imAddress.AddressDetailsPostalCode.ToString();
                        }

                        if (imAddress.AddressDetailsPostalAddress != null)
                        {
                            txtPhysicalAddressPostalAddress.Text = imAddress.AddressDetailsPostalAddress.ToString();
                        }

                        if (imAddress.AddressDetailsPhysicalAddress != null)
                        {
                            txtPhysicalAddress.Text = imAddress.AddressDetailsPhysicalAddress.ToString();
                        }

                        if (imAddress.AddressDetailsCountryID >= 0)
                        {
                            cmbPhysicalAddressCustomerCountry.SelectedValue = imAddress.AddressDetailsCountryID;
                        }

                        if (imAddress.AddressDetailsCityID >= 0)
                        {
                            cmbPhysicalAddressCustomerCity.SelectedValue = imAddress.AddressDetailsCityID;
                        }

                        if (imAddress.AddressDetailsCountyID >= 0)
                        {
                            cmbPhysicalAddressCustomerCounty.SelectedValue = imAddress.AddressDetailsCountyID;
                        }

                        if (imAddress.AddressDetailsConstituencyID >= 0)
                        {
                            cmbPhysicalAddressCustomerConstituency.SelectedValue = imAddress.AddressDetailsCountryID;
                        }

                        if (imAddress.AddressDetailsProvinceID > 0)
                        {
                            cmbPhysicalAddressCustomerProvince.SelectedValue = imAddress.AddressDetailsProvinceID;
                        }

                        if (imAddress.AddressDetailsDistrictID >= 0)
                        {
                            cmbPhysicalAddressCustomerDistrict.SelectedValue = imAddress.AddressDetailsDistrictID;
                        }

                        if (imAddress.AddressDetailsDivisionID >= 0)
                        {
                            cmbPhysicalAddressCustomerDivision.SelectedValue = imAddress.AddressDetailsDivisionID;
                        }

                        if (imAddress.AddressDetailsLocationID >= 0)
                        {
                            cmbPhysicalAddressCustomerLocation.SelectedValue = imAddress.AddressDetailsLocationID;
                        }

                        if (imAddress.AddressDetailsSublocationID >= 0)
                        {
                            cmbPhysicalAddressCustomerSubLocation.SelectedValue = imAddress.AddressDetailsSublocationID;
                        }

                        if (imAddress.AddressDetailsEstateID >= 0)
                        {
                            txtPhysicalAddressEstate.Text = imAddress.AddressDetailsEstateID.ToString();
                        }

                        if (imAddress.AddressDetailsHouseNumber != null)
                        {
                            txtPhysicalAddress.Text = imAddress.AddressDetailsHouseNumber;
                        }

                        if (imAddress.PhysicalAddressCoordinate != null)
                        {
                            if (imAddress.IsCoordinateZeroCoordinate() != true)
                            {
                                txtPOICoordinate.Text = imAddress.PhysicalAddressCoordinate.X + "," +
                                    imAddress.PhysicalAddressCoordinate.Y;
                                txtPhysicalAddressCustomerPOI.Text = imAddress.PhysicalAddressCoordinate.X + "," +
                                    imAddress.PhysicalAddressCoordinate.Y;
                            }
                        }

                        if (imAddress.AddressDetailsTelephone1 != null)
                        {
                            txtPhysicalAddressTelephone1.Text = imAddress.AddressDetailsTelephone1.ToString();
                        }

                        if (imAddress.AddressDetailsTelephone2 != null)
                        {
                            txtPhysicalAddressTelephone2.Text = imAddress.AddressDetailsTelephone2.ToString();
                        }

                        if (imAddress.AddressDetailsMobilePhone1 != null)
                        {
                            txtPhysicalAddressMobilePhone1.Text = imAddress.AddressDetailsMobilePhone1.ToString();
                        }

                        if (imAddress.AddressDetailsMobilePhone2 != null)
                        {
                            txtPhysicalAddressMobilePhone2.Text = imAddress.AddressDetailsMobilePhone2.ToString();
                        }

                        if (imAddress.AddressDetailsFax1 != null)
                        {
                            txtPhysicalAddressFax2.Text = imAddress.AddressDetailsFax1.ToString();
                        }

                        if (imAddress.AddressDetailsFax1 != null)
                        {
                            txtPhysicalAddressFax2.Text = imAddress.AddressDetailsFax2.ToString();
                        }

                        if (imAddress.AddressDetailsCompanyEmail != null)
                        {
                            txtPhysicalAddressCompanyEmail.Text = imAddress.AddressDetailsCompanyEmail.ToString();
                        }

                        if (imAddress.AddressDetailsSalesEmail != null)
                        {
                            txtPhysicalAddressSalesEmail.Text = imAddress.AddressDetailsSalesEmail.ToString();
                        }

                        if (imAddress.AddressDetailsSupportEmail != null)
                        {
                            txtPhysicalAddressSupportEmail.Text = imAddress.AddressDetailsSupportEmail.ToString();
                        }

                        if (imAddress.AddressDetailsUniversalAddress != null)
                        {
                            txtPhysicalAddressUniversalAddress.Text = imAddress.AddressDetailsUniversalAddress.ToString();
                        }

                        if (imAddress.AddressDetailsRoadID > 0)
                        {
                            txtRoadName.Text = imAddress.AddressDetailsRoadID.ToString();
                            txtPhysicalAddressRoadName.Text = imAddress.AddressDetailsRoadID.ToString();
                            lCurrentAddressRoadID = imAddress.AddressDetailsRoadID;
                        }

                        if (imAddress.AddressDetailsProjection != null)
                        {
                            cmbPhysicalAddressProjection.Text = imAddress.AddressDetailsProjection.ToString();
                        }

                        if (imAddress.AddressDetailsPointName != null)
                        {
                            txtPointOfInterestName.Text = imAddress.AddressDetailsPointName.ToString();
                        }

                        if (imAddress.AddressDetailsBuildingID > 0)
                        {
                            lCurrentAddressBuildingID = imAddress.AddressDetailsBuildingID;
                            txtPhysicalAddressBuildingName.Text = imAddress.AddressDetailsBuildingID.ToString();
                        }

                        if (imAddress.AddressDetailsRootID > 0)
                        {
                            lCurrentAddressRootID = imAddress.AddressDetailsRootID;
                        }

                        if (imAddress.AddressDetailsAppartmentID > 0)
                        {
                            lCurrentAddressAppartmentID = imAddress.AddressDetailsAppartmentID;
                        }

                        if (imAddress.AddressDetailsMapID > 0)
                        {
                            lCurrentAddressMapID = imAddress.AddressDetailsMapID;
                        }

                        txtPhysicalAddressBuildingName.Focus();

                    }
                }
                else
                {


                }

            }

            catch (Exception ex)
            {
                string err = ex.Message + " Source=" + ex.Source;
            }

            finally
            {

                imAddress = null;
            }

        }

        private void LoadLastBuildingMaster()
        {
            TRIP_API.IMAddress imAddress = new TRIP_API.IMAddress();

            try
            {
                imAddress.ReturnLastAddressDetails();

                lCurrentAddressNumber = imAddress.AddressDetailsID;

                if (imAddress.AddressDetailsID > 0)
                {

                    if (imAddress.AddressDetailsOwnerID > 0)
                    {
                        lCurrentAddressOwnerID = imAddress.AddressDetailsOwnerID;
                    }

                    if (imAddress.AddressDetailsOwnerTypeID > 0)
                    {
                        lCurrentAddressOwnerTypeID = imAddress.AddressDetailsOwnerTypeID;
                    }

                    if (imAddress.AddressDetailsPostalCode != null)
                    {
                        txtPhysicalAddressPostCode.Text = imAddress.AddressDetailsPostalCode.ToString();
                    }

                    if (imAddress.AddressDetailsPostalAddress != null)
                    {
                        txtPhysicalAddressPostalAddress.Text = imAddress.AddressDetailsPostalAddress.ToString();
                    }

                    if (imAddress.AddressDetailsPhysicalAddress != null)
                    {
                        txtPhysicalAddress.Text = imAddress.AddressDetailsPhysicalAddress.ToString();
                    }

                    if (imAddress.AddressDetailsCountryID >= 0)
                    {
                        cmbPhysicalAddressCustomerCountry.SelectedValue = imAddress.AddressDetailsCountryID;
                    }

                    if (imAddress.AddressDetailsCityID >= 0)
                    {
                        cmbPhysicalAddressCustomerCity.SelectedValue = imAddress.AddressDetailsCityID;
                    }

                    if (imAddress.AddressDetailsCountyID >= 0)
                    {
                        cmbPhysicalAddressCustomerCounty.SelectedValue = imAddress.AddressDetailsCountyID;
                    }

                    if (imAddress.AddressDetailsConstituencyID >= 0)
                    {
                        cmbPhysicalAddressCustomerConstituency.SelectedValue = imAddress.AddressDetailsCountryID;
                    }

                    if (imAddress.AddressDetailsProvinceID > 0)
                    {
                        cmbPhysicalAddressCustomerProvince.SelectedValue = imAddress.AddressDetailsProvinceID;
                    }

                    if (imAddress.AddressDetailsDistrictID >= 0)
                    {
                        cmbPhysicalAddressCustomerDistrict.SelectedValue = imAddress.AddressDetailsDistrictID;
                    }

                    if (imAddress.AddressDetailsDivisionID >= 0)
                    {
                        cmbPhysicalAddressCustomerDivision.SelectedValue = imAddress.AddressDetailsDivisionID;
                    }

                    if (imAddress.AddressDetailsLocationID >= 0)
                    {
                        cmbPhysicalAddressCustomerLocation.SelectedValue = imAddress.AddressDetailsLocationID;
                    }

                    if (imAddress.AddressDetailsSublocationID >= 0)
                    {
                        cmbPhysicalAddressCustomerSubLocation.SelectedValue = imAddress.AddressDetailsSublocationID;
                    }

                    if (imAddress.AddressDetailsEstateID >= 0)
                    {
                        txtPhysicalAddressEstate.Text = imAddress.AddressDetailsEstateID.ToString();
                    }

                    if (imAddress.AddressDetailsHouseNumber != null)
                    {
                        txtPhysicalAddress.Text = imAddress.AddressDetailsHouseNumber;
                    }

                    if (imAddress.PhysicalAddressCoordinate != null)
                    {
                        if (imAddress.IsCoordinateZeroCoordinate() != true)
                        {
                            txtPOICoordinate.Text = imAddress.PhysicalAddressCoordinate.X + "," +
                                imAddress.PhysicalAddressCoordinate.Y;
                            txtPhysicalAddressCustomerPOI.Text = imAddress.PhysicalAddressCoordinate.X + "," +
                                imAddress.PhysicalAddressCoordinate.Y;
                        }
                    }

                    if (imAddress.AddressDetailsTelephone1 != null)
                    {
                        txtPhysicalAddressTelephone1.Text = imAddress.AddressDetailsTelephone1.ToString();
                    }

                    if (imAddress.AddressDetailsTelephone2 != null)
                    {
                        txtPhysicalAddressTelephone2.Text = imAddress.AddressDetailsTelephone2.ToString();
                    }

                    if (imAddress.AddressDetailsMobilePhone1 != null)
                    {
                        txtPhysicalAddressMobilePhone1.Text = imAddress.AddressDetailsMobilePhone1.ToString();
                    }

                    if (imAddress.AddressDetailsMobilePhone2 != null)
                    {
                        txtPhysicalAddressMobilePhone2.Text = imAddress.AddressDetailsMobilePhone2.ToString();
                    }

                    if (imAddress.AddressDetailsFax1 != null)
                    {
                        txtPhysicalAddressFax2.Text = imAddress.AddressDetailsFax1.ToString();
                    }

                    if (imAddress.AddressDetailsFax1 != null)
                    {
                        txtPhysicalAddressFax2.Text = imAddress.AddressDetailsFax2.ToString();
                    }

                    if (imAddress.AddressDetailsCompanyEmail != null)
                    {
                        txtPhysicalAddressCompanyEmail.Text = imAddress.AddressDetailsCompanyEmail.ToString();
                    }

                    if (imAddress.AddressDetailsSalesEmail != null)
                    {
                        txtPhysicalAddressSalesEmail.Text = imAddress.AddressDetailsSalesEmail.ToString();
                    }

                    if (imAddress.AddressDetailsSupportEmail != null)
                    {
                        txtPhysicalAddressSupportEmail.Text = imAddress.AddressDetailsSupportEmail.ToString();
                    }

                    if (imAddress.AddressDetailsUniversalAddress != null)
                    {
                        txtPhysicalAddressUniversalAddress.Text = imAddress.AddressDetailsUniversalAddress.ToString();
                    }

                    if (imAddress.AddressDetailsRoadID > 0)
                    {
                        txtRoadName.Text = imAddress.AddressDetailsRoadID.ToString();
                        txtPhysicalAddressRoadName.Text = imAddress.AddressDetailsRoadID.ToString();
                        lCurrentAddressRoadID = imAddress.AddressDetailsRoadID;
                    }

                    if (imAddress.AddressDetailsProjection != null)
                    {
                        cmbPhysicalAddressProjection.Text = imAddress.AddressDetailsProjection.ToString();
                    }

                    if (imAddress.AddressDetailsPointName != null)
                    {
                        txtPointOfInterestName.Text = imAddress.AddressDetailsPointName.ToString();
                    }

                    if (imAddress.AddressDetailsBuildingID > 0)
                    {
                        lCurrentAddressBuildingID = imAddress.AddressDetailsBuildingID;
                        txtPhysicalAddressBuildingName.Text = imAddress.AddressDetailsBuildingID.ToString();
                    }

                    if (imAddress.AddressDetailsRootID > 0)
                    {
                        lCurrentAddressRootID = imAddress.AddressDetailsRootID;
                    }

                    if (imAddress.AddressDetailsAppartmentID > 0)
                    {
                        lCurrentAddressAppartmentID = imAddress.AddressDetailsAppartmentID;
                    }

                    if (imAddress.AddressDetailsMapID > 0)
                    {
                        lCurrentAddressMapID = imAddress.AddressDetailsMapID;
                    }

                    txtPhysicalAddressBuildingName.Focus();

                }

            }

            catch (Exception ex)
            {
                string err = ex.Message + " Source=" + ex.Source;
            }

            finally
            {
                imAddress = null;
            }



        }

        public void LoadBuildingMasterByBuildingID(long lArgAddressDetailsID)
        {
            TRIP_API.IMAddress imAddress = new TRIP_API.IMAddress();

            try
            {

                if (lArgAddressDetailsID > 0)
                {
                    imAddress.AddressDetailsID = lArgAddressDetailsID;
                    if (imAddress.ReturnAddressDetailsByAddressDetailsID(0, 0) == true)
                    {
                        lCurrentAddressNumber = imAddress.AddressDetailsID;

                        if (imAddress.AddressDetailsID > 0)
                        {

                            if (imAddress.AddressDetailsOwnerID > 0)
                            {
                                lCurrentAddressOwnerID = imAddress.AddressDetailsOwnerID;
                            }

                            if (imAddress.AddressDetailsOwnerTypeID > 0)
                            {
                                lCurrentAddressOwnerTypeID = imAddress.AddressDetailsOwnerTypeID;
                            }

                            if (imAddress.AddressDetailsPostalCode != null)
                            {
                                txtPhysicalAddressPostCode.Text = imAddress.AddressDetailsPostalCode.ToString();
                            }

                            if (imAddress.AddressDetailsPostalAddress != null)
                            {
                                txtPhysicalAddressPostalAddress.Text = imAddress.AddressDetailsPostalAddress.ToString();
                            }

                            if (imAddress.AddressDetailsPhysicalAddress != null)
                            {
                                txtPhysicalAddress.Text = imAddress.AddressDetailsPhysicalAddress.ToString();
                            }

                            if (imAddress.AddressDetailsCountryID >= 0)
                            {
                                cmbPhysicalAddressCustomerCountry.SelectedValue = imAddress.AddressDetailsCountryID;
                            }

                            if (imAddress.AddressDetailsCityID >= 0)
                            {
                                cmbPhysicalAddressCustomerCity.SelectedValue = imAddress.AddressDetailsCityID;
                            }

                            if (imAddress.AddressDetailsCountyID >= 0)
                            {
                                cmbPhysicalAddressCustomerCounty.SelectedValue = imAddress.AddressDetailsCountyID;
                            }

                            if (imAddress.AddressDetailsConstituencyID >= 0)
                            {
                                cmbPhysicalAddressCustomerConstituency.SelectedValue = imAddress.AddressDetailsCountryID;
                            }

                            if (imAddress.AddressDetailsProvinceID > 0)
                            {
                                cmbPhysicalAddressCustomerProvince.SelectedValue = imAddress.AddressDetailsProvinceID;
                            }

                            if (imAddress.AddressDetailsDistrictID >= 0)
                            {
                                cmbPhysicalAddressCustomerDistrict.SelectedValue = imAddress.AddressDetailsDistrictID;
                            }

                            if (imAddress.AddressDetailsDivisionID >= 0)
                            {
                                cmbPhysicalAddressCustomerDivision.SelectedValue = imAddress.AddressDetailsDivisionID;
                            }

                            if (imAddress.AddressDetailsLocationID >= 0)
                            {
                                cmbPhysicalAddressCustomerLocation.SelectedValue = imAddress.AddressDetailsLocationID;
                            }

                            if (imAddress.AddressDetailsSublocationID >= 0)
                            {
                                cmbPhysicalAddressCustomerSubLocation.SelectedValue = imAddress.AddressDetailsSublocationID;
                            }

                            if (imAddress.AddressDetailsEstateID >= 0)
                            {
                                txtPhysicalAddressEstate.Text = imAddress.AddressDetailsEstateID.ToString();
                            }

                            if (imAddress.AddressDetailsHouseNumber != null)
                            {
                                txtPhysicalAddress.Text = imAddress.AddressDetailsHouseNumber;
                            }

                            if (imAddress.PhysicalAddressCoordinate != null)
                            {
                                if (imAddress.IsCoordinateZeroCoordinate() != true)
                                {
                                    txtPOICoordinate.Text = imAddress.PhysicalAddressCoordinate.X + "," +
                                        imAddress.PhysicalAddressCoordinate.Y;
                                    txtPhysicalAddressCustomerPOI.Text = imAddress.PhysicalAddressCoordinate.X + "," +
                                        imAddress.PhysicalAddressCoordinate.Y;
                                }
                            }

                            if (imAddress.AddressDetailsTelephone1 != null)
                            {
                                txtPhysicalAddressTelephone1.Text = imAddress.AddressDetailsTelephone1.ToString();
                            }

                            if (imAddress.AddressDetailsTelephone2 != null)
                            {
                                txtPhysicalAddressTelephone2.Text = imAddress.AddressDetailsTelephone2.ToString();
                            }

                            if (imAddress.AddressDetailsMobilePhone1 != null)
                            {
                                txtPhysicalAddressMobilePhone1.Text = imAddress.AddressDetailsMobilePhone1.ToString();
                            }

                            if (imAddress.AddressDetailsMobilePhone2 != null)
                            {
                                txtPhysicalAddressMobilePhone2.Text = imAddress.AddressDetailsMobilePhone2.ToString();
                            }

                            if (imAddress.AddressDetailsFax1 != null)
                            {
                                txtPhysicalAddressFax2.Text = imAddress.AddressDetailsFax1.ToString();
                            }

                            if (imAddress.AddressDetailsFax1 != null)
                            {
                                txtPhysicalAddressFax2.Text = imAddress.AddressDetailsFax2.ToString();
                            }

                            if (imAddress.AddressDetailsCompanyEmail != null)
                            {
                                txtPhysicalAddressCompanyEmail.Text = imAddress.AddressDetailsCompanyEmail.ToString();
                            }

                            if (imAddress.AddressDetailsSalesEmail != null)
                            {
                                txtPhysicalAddressSalesEmail.Text = imAddress.AddressDetailsSalesEmail.ToString();
                            }

                            if (imAddress.AddressDetailsSupportEmail != null)
                            {
                                txtPhysicalAddressSupportEmail.Text = imAddress.AddressDetailsSupportEmail.ToString();
                            }

                            if (imAddress.AddressDetailsUniversalAddress != null)
                            {
                                txtPhysicalAddressUniversalAddress.Text = imAddress.AddressDetailsUniversalAddress.ToString();
                            }

                            if (imAddress.AddressDetailsRoadID > 0)
                            {
                                txtRoadName.Text = imAddress.AddressDetailsRoadID.ToString();
                                txtPhysicalAddressRoadName.Text = imAddress.AddressDetailsRoadID.ToString();
                                lCurrentAddressRoadID = imAddress.AddressDetailsRoadID;
                            }

                            if (imAddress.AddressDetailsProjection != null)
                            {
                                cmbPhysicalAddressProjection.Text = imAddress.AddressDetailsProjection.ToString();
                            }

                            if (imAddress.AddressDetailsPointName != null)
                            {
                                txtPointOfInterestName.Text = imAddress.AddressDetailsPointName.ToString();
                            }

                            if (imAddress.AddressDetailsBuildingID > 0)
                            {
                                lCurrentAddressBuildingID = imAddress.AddressDetailsBuildingID;
                                txtPhysicalAddressBuildingName.Text = imAddress.AddressDetailsBuildingID.ToString();
                            }

                            if (imAddress.AddressDetailsRootID > 0)
                            {
                                lCurrentAddressRootID = imAddress.AddressDetailsRootID;
                            }

                            if (imAddress.AddressDetailsAppartmentID > 0)
                            {
                                lCurrentAddressAppartmentID = imAddress.AddressDetailsAppartmentID;
                            }

                            if (imAddress.AddressDetailsMapID > 0)
                            {
                                lCurrentAddressMapID = imAddress.AddressDetailsMapID;
                            }

                            txtPhysicalAddressBuildingName.Focus();

                        }

                    }

                }

            }

            catch (Exception ex)
            {
                string err = ex.Message + " Source=" + ex.Source;
            }

            finally
            {
                imAddress = null;
            }



        }

        public void LoadBuildingMasterByMapID(long lArgMapID)
        {
            TRIP_API.IMAddress imAddress = new TRIP_API.IMAddress();

            try
            {
                if (lArgMapID > 0)
                {
                    imAddress.AddressDetailsMapID = lArgMapID;
                    if (imAddress.ReturnAddressDetailsByMapID(0, 0) == true)
                    {
                        lCurrentAddressNumber = imAddress.AddressDetailsID;

                        if (imAddress.AddressDetailsID > 0)
                        {
                            if (imAddress.AddressDetailsOwnerID > 0)
                            {
                                lCurrentAddressOwnerID = imAddress.AddressDetailsOwnerID;
                            }

                            if (imAddress.AddressDetailsOwnerTypeID > 0)
                            {
                                lCurrentAddressOwnerTypeID = imAddress.AddressDetailsOwnerTypeID;
                            }

                            if (imAddress.AddressDetailsPostalCode != null)
                            {
                                txtPhysicalAddressPostCode.Text = imAddress.AddressDetailsPostalCode.ToString();
                            }

                            if (imAddress.AddressDetailsPostalAddress != null)
                            {
                                txtPhysicalAddressPostalAddress.Text = imAddress.AddressDetailsPostalAddress.ToString();
                            }

                            if (imAddress.AddressDetailsPhysicalAddress != null)
                            {
                                txtPhysicalAddress.Text = imAddress.AddressDetailsPhysicalAddress.ToString();
                            }

                            if (imAddress.AddressDetailsCountryID >= 0)
                            {
                                cmbPhysicalAddressCustomerCountry.SelectedValue = imAddress.AddressDetailsCountryID;
                            }

                            if (imAddress.AddressDetailsCityID >= 0)
                            {
                                cmbPhysicalAddressCustomerCity.SelectedValue = imAddress.AddressDetailsCityID;
                            }

                            if (imAddress.AddressDetailsCountyID >= 0)
                            {
                                cmbPhysicalAddressCustomerCounty.SelectedValue = imAddress.AddressDetailsCountyID;
                            }

                            if (imAddress.AddressDetailsConstituencyID >= 0)
                            {
                                cmbPhysicalAddressCustomerConstituency.SelectedValue = imAddress.AddressDetailsCountryID;
                            }

                            if (imAddress.AddressDetailsProvinceID > 0)
                            {
                                cmbPhysicalAddressCustomerProvince.SelectedValue = imAddress.AddressDetailsProvinceID;
                            }

                            if (imAddress.AddressDetailsDistrictID >= 0)
                            {
                                cmbPhysicalAddressCustomerDistrict.SelectedValue = imAddress.AddressDetailsDistrictID;
                            }

                            if (imAddress.AddressDetailsDivisionID >= 0)
                            {
                                cmbPhysicalAddressCustomerDivision.SelectedValue = imAddress.AddressDetailsDivisionID;
                            }

                            if (imAddress.AddressDetailsLocationID >= 0)
                            {
                                cmbPhysicalAddressCustomerLocation.SelectedValue = imAddress.AddressDetailsLocationID;
                            }

                            if (imAddress.AddressDetailsSublocationID >= 0)
                            {
                                cmbPhysicalAddressCustomerSubLocation.SelectedValue = imAddress.AddressDetailsSublocationID;
                            }

                            if (imAddress.AddressDetailsEstateID >= 0)
                            {
                                txtPhysicalAddressEstate.Text = imAddress.AddressDetailsEstateID.ToString();
                            }

                            if (imAddress.AddressDetailsHouseNumber != null)
                            {
                                txtPhysicalAddress.Text = imAddress.AddressDetailsHouseNumber;
                            }

                            if (imAddress.PhysicalAddressCoordinate != null)
                            {
                                if (imAddress.IsCoordinateZeroCoordinate() != true)
                                {
                                    txtPOICoordinate.Text = imAddress.PhysicalAddressCoordinate.X + "," +
                                        imAddress.PhysicalAddressCoordinate.Y;
                                    txtPhysicalAddressCustomerPOI.Text = imAddress.PhysicalAddressCoordinate.X + "," +
                                        imAddress.PhysicalAddressCoordinate.Y;
                                }
                            }

                            if (imAddress.AddressDetailsTelephone1 != null)
                            {
                                txtPhysicalAddressTelephone1.Text = imAddress.AddressDetailsTelephone1.ToString();
                            }

                            if (imAddress.AddressDetailsTelephone2 != null)
                            {
                                txtPhysicalAddressTelephone2.Text = imAddress.AddressDetailsTelephone2.ToString();
                            }

                            if (imAddress.AddressDetailsMobilePhone1 != null)
                            {
                                txtPhysicalAddressMobilePhone1.Text = imAddress.AddressDetailsMobilePhone1.ToString();
                            }

                            if (imAddress.AddressDetailsMobilePhone2 != null)
                            {
                                txtPhysicalAddressMobilePhone2.Text = imAddress.AddressDetailsMobilePhone2.ToString();
                            }

                            if (imAddress.AddressDetailsFax1 != null)
                            {
                                txtPhysicalAddressFax2.Text = imAddress.AddressDetailsFax1.ToString();
                            }

                            if (imAddress.AddressDetailsFax1 != null)
                            {
                                txtPhysicalAddressFax2.Text = imAddress.AddressDetailsFax2.ToString();
                            }

                            if (imAddress.AddressDetailsCompanyEmail != null)
                            {
                                txtPhysicalAddressCompanyEmail.Text = imAddress.AddressDetailsCompanyEmail.ToString();
                            }

                            if (imAddress.AddressDetailsSalesEmail != null)
                            {
                                txtPhysicalAddressSalesEmail.Text = imAddress.AddressDetailsSalesEmail.ToString();
                            }

                            if (imAddress.AddressDetailsSupportEmail != null)
                            {
                                txtPhysicalAddressSupportEmail.Text = imAddress.AddressDetailsSupportEmail.ToString();
                            }

                            if (imAddress.AddressDetailsUniversalAddress != null)
                            {
                                txtPhysicalAddressUniversalAddress.Text = imAddress.AddressDetailsUniversalAddress.ToString();
                            }

                            if (imAddress.AddressDetailsRoadID > 0)
                            {
                                txtRoadName.Text = imAddress.AddressDetailsRoadID.ToString();
                                txtPhysicalAddressRoadName.Text = imAddress.AddressDetailsRoadID.ToString();
                                lCurrentAddressRoadID = imAddress.AddressDetailsRoadID;
                            }

                            if (imAddress.AddressDetailsProjection != null)
                            {
                                cmbPhysicalAddressProjection.Text = imAddress.AddressDetailsProjection.ToString();
                            }

                            if (imAddress.AddressDetailsPointName != null)
                            {
                                txtPointOfInterestName.Text = imAddress.AddressDetailsPointName.ToString();
                            }

                            if (imAddress.AddressDetailsBuildingID > 0)
                            {
                                lCurrentAddressBuildingID = imAddress.AddressDetailsBuildingID;
                                txtPhysicalAddressBuildingName.Text = imAddress.AddressDetailsBuildingID.ToString();
                            }

                            if (imAddress.AddressDetailsRootID > 0)
                            {
                                lCurrentAddressRootID = imAddress.AddressDetailsRootID;
                            }

                            if (imAddress.AddressDetailsAppartmentID > 0)
                            {
                                lCurrentAddressAppartmentID = imAddress.AddressDetailsAppartmentID;
                            }

                            if (imAddress.AddressDetailsMapID > 0)
                            {
                                lCurrentAddressMapID = imAddress.AddressDetailsMapID;
                            }

                            txtPhysicalAddressBuildingName.Focus();

                        }

                    }

                }

            }

            catch (Exception ex)
            {
                string err = ex.Message + " Source=" + ex.Source;
            }

            finally
            {
                imAddress = null;
            }



        }

        private void LoadPOITypes(long lArgDefaultBuildingTypeID)
        {
            TRIP_API.IMAddress imAddress = new TRIP_API.IMAddress();

            try
            {

            }

            catch (Exception ex)
            {
                string err = ex.Message + " Source=" + ex.Source;
            }

            finally
            {

                imAddress = null;
            }

        }

        public void LoadBuildingIDNameByMapID(long lArgMapID)
        {
            TRIP_API.IMBuildingMaster imBuildingMaster = new TRIP_API.IMBuildingMaster();

            try
            {
                if (lArgMapID > 0)
                {
                    imBuildingMaster.MapID = lArgMapID;
                    if (imBuildingMaster.ReturnBuildingIDNameMapIDMapID(0, 0) == true)
                    {
                        lCurrentAddressBuildingID = imBuildingMaster.BuildingID;

                        if (imBuildingMaster.BuildingID > 0)
                        {
                            if (imBuildingMaster.BuildingName != null)
                            {
                                txtBuildingName.Text = imBuildingMaster.BuildingName.ToString();
                                txtPhysicalAddressBuildingName.Text = imBuildingMaster.BuildingName.ToString();
                            }

                            if (imBuildingMaster.MapID != 0)
                            {
                                ZoomToBuilding(imBuildingMaster.MapID);
                            }

                        }

                    }

                }

            }

            catch (Exception ex)
            {
                string err = ex.Message + " Source=" + ex.Source;
            }

            finally
            {
                imBuildingMaster = null;
            }

        }

        private void SelectAddressPOITypes()
        {
            //POI Types Belonging to each address
            TRIP_API.IMAddress imAddress = new TRIP_API.IMAddress();

            try
            {


            }

            catch (Exception ex)
            {
                string err = ex.Message + " Source=" + ex.Source;
            }

            finally
            {

                imAddress = null;
            }

        }        

        private void SaveAddressDetails()
        {
            TRIP_API.IMAddress imAddress;
            try
            {
                imAddress = new TRIP_API.IMAddress();
                imAddress.AddressDetailsID = lCurrentAddressNumber;
                imAddress.AddressDetailsOwnerID = 1;
                imAddress.AddressDetailsPostalCode = txtPhysicalAddressPostCode.Text;
                imAddress.AddressDetailsPhysicalAddress = txtPhysicalAddress.Text;
                imAddress.AddressDetailsPostalAddress = txtPhysicalAddressPostalAddress.Text;
                imAddress.AddressDetailsCountryID = 
                    Convert.ToInt64(cmbPhysicalAddressCustomerCountry.SelectedValue);
                imAddress.AddressDetailsCityID =
                    Convert.ToInt64(cmbPhysicalAddressCustomerCity.SelectedValue);
                imAddress.AddressDetailsCountyID =
                    Convert.ToInt64(cmbPhysicalAddressCustomerCounty.SelectedValue);
                imAddress.AddressDetailsProvinceID =
                    Convert.ToInt64(cmbPhysicalAddressCustomerProvince.SelectedValue);
                imAddress.AddressDetailsDistrictID =
                    Convert.ToInt64(cmbPhysicalAddressCustomerDistrict.SelectedValue);
                imAddress.AddressDetailsDivisionID =
                    Convert.ToInt64(cmbPhysicalAddressCustomerDivision.SelectedValue);
                imAddress.AddressDetailsLocationID =
                    Convert.ToInt64(cmbPhysicalAddressCustomerLocation.SelectedValue);
                imAddress.AddressDetailsSublocationID =
                    Convert.ToInt64(cmbPhysicalAddressCustomerSubLocation.SelectedValue);
                imAddress.AddressDetailsConstituencyID =
                                    Convert.ToInt64(cmbPhysicalAddressCustomerConstituency.SelectedValue);
                imAddress.AddressDetailsHouseNumber = txtHouseNumber.Text;

                imAddress.AddressDetailsSocialNetworkUserID = txtPhysicalAddressSocialNetworkUserID.Text;
                imAddress.AddressDetailsTelephone1 = txtPhysicalAddressTelephone1.Text;
                imAddress.AddressDetailsTelephone2 = txtPhysicalAddressTelephone2.Text;
                imAddress.AddressDetailsMobilePhone1 = txtPhysicalAddressMobilePhone1.Text;
                imAddress.AddressDetailsMobilePhone2 = txtPhysicalAddressMobilePhone2.Text;
                imAddress.AddressDetailsFax1 = txtPhysicalAddressFax1.Text;
                imAddress.AddressDetailsFax2 = txtPhysicalAddressFax2.Text;
                imAddress.AddressDetailsCompanyEmail = txtPhysicalAddressCompanyEmail.Text;
                imAddress.AddressDetailsSalesEmail = txtPhysicalAddressSalesEmail.Text;
                imAddress.AddressDetailsSupportEmail = txtPhysicalAddressSupportEmail.Text;

                imAddress.AddressDetailsUniversalAddress = txtUniversalAddress.Text;
                imAddress.AddressDetailsRoadID = Convert.ToInt64(txtRoadName.Text);
                imAddress.AddressDetailsProjection = cmbPhysicalAddressProjection.Text;
                imAddress.AddressDetailsPointName = txtPointOfInterestName.Text;
                imAddress.AddressDetailsBuildingID = lCurrentAddressBuildingID;
                imAddress.AddressDetailsRootID = lCurrentAddressRootID;
                imAddress.AddressDetailsAppartmentID = lCurrentAddressAppartmentID;
                imAddress.AddressDetailsMapID = lCurrentAddressMapID;

                if (imAddress.SaveAddressDetails() == true)
                {
                    MessageBox.Show("Address Details Saved", "Tripodmaps - Address",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Address Record Was Not Saved", "Tripodmaps - Address", 
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

                 

            }

            catch (Exception ex)
            {
                errMessage = ex.Message;
            }

            finally
            {
                imAddress = null;
            }

        }

        private void SavePOIImages()
        {

        }


        #endregion

        private void tlstrpbtnSave_Click(object sender, EventArgs e)
        {

        }

        private void frmAddressDetails_FormClosing(Object sender, FormClosingEventArgs e)
        {
            MainForm frmMain = (MainForm)Application.OpenForms["MainForm"];
            frmMain.CloseAddressDetailsForm();
        }

       

    }
}
