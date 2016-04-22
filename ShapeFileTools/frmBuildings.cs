using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using Tripodmaps.Reader;
using System.Xml;


namespace Tripodmaps
{
    public partial class frmBuildings : Form
    {

        private long lCurrentBuildingNumber = 0;
        private string errMessage = "";
        Tripodmaps.Reader.ShapeFile[] shapefiles;
        Tripodmaps.Reader.ShapeFile buildingshapefile;
        private Tripodmaps.Reader.PointD currentMarkerPosition = new Tripodmaps.Reader.PointD(0, 0);
        private const int MarkerWidth = 10;
        private string strProjectPath = null;

        private string currentProjectPath = null;
        enum ProjectState { NewProject, UnsavedNewProject, OpenProject, UnsavedOpenProject };
        private ProjectState projectStatus = ProjectState.NewProject;
        

        #region "FormOperations"

        
        public frmBuildings(string strArgProjectPath)
        {
            InitializeComponent();
            strProjectPath = strArgProjectPath;

        }

        private bool CheckIfStringValueIsNumeric(string strArgValue)
        {
            bool IsNumber = false;

            try
            {

                for (int i = 0; i < strArgValue.Length; i++)
                {
                    if (char.IsNumber(strArgValue[i]))
                    {
                        IsNumber = true;
                    }
                }

                return IsNumber;
            }

            catch (Exception ex)
            {
                errMessage = ex.Message;
                return IsNumber;
                
            }


        }

        private void tlstrpbtnSave_Click(object sender, EventArgs e)
        {
            SaveBuildingMaster();
        }

        private void cmbPhysicalAddressCustomerEstate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbBuildingBuilding_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void tlstrpbtnFirst_Click_1(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //scaleByTrackBar1();
        }

        private void scaleByTrackBar1()
        {
            if (picBuildingPhoto.Image != null)
            {

                //pictureBox1.Dock = DockStyle.None;
                lblZoomPercentage.Text = trackBar1.Value.ToString() + "%";
                Image scaledbmp = ScaleByPercent(picBuildingPhoto.Image, trackBar1.Value);
                picBuildingPhoto.Width = scaledbmp.Width;
                picBuildingPhoto.Height = scaledbmp.Height;
                picBuildingPhoto.Image = scaledbmp;

            }
        }

        static Image ScaleByPercent(Image imgPhoto, int Percent)
        {
            try
            {
                float nPercent = ((float)Percent / 100);

                int sourceWidth = imgPhoto.Width;
                int sourceHeight = imgPhoto.Height;
                int destWidth = (int)(sourceWidth * nPercent);
                int destHeight = (int)(sourceHeight * nPercent);

                Bitmap bmPhoto = new Bitmap(destWidth, destHeight, PixelFormat.Format24bppRgb);
                bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

                Graphics grPhoto = Graphics.FromImage(bmPhoto);
                grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

                grPhoto.DrawImage(imgPhoto,
                    new Rectangle(0, 0, destWidth, destHeight),
                    new Rectangle(0, 0, sourceWidth, sourceHeight),
                    GraphicsUnit.Pixel);

                grPhoto.Dispose();
                return bmPhoto;
            }
            
            catch (Exception ex)
            {
                //errMessage = ex.Message;
                return null;
            }

            finally
            {

            }
        }

        private void cmdBuildingPhotoAdd_Click(object sender, EventArgs e)
        {
            LoadBuildingImage();
        }

        private void LoadBuildingImage()
        {
            
            try
            {
                string strFilePath = "";

                opnfldlgBuildings = new OpenFileDialog();
                opnfldlgBuildings.ShowDialog(this);
                strFilePath = opnfldlgBuildings.FileName;

                if (File.Exists(strFilePath))
                {
                    picBuildingPhoto.Image = Image.FromFile(strFilePath);
                }               

            }

            catch (Exception ex)
            {

            }

            finally
            {
                opnfldlgBuildings = null;
            }

        }

        private void frmBuildings_Load(object sender, EventArgs e)
        {
            LoadPhysicalAddressMap();
            LoadForm();
        }
         
        private void cmdBuildingColour_Click(object sender, EventArgs e)
        {
            LoadColours();
        }

        private void LoadColours()
        {            
            cldlgBuildingColor.ShowDialog(this);
            txtBuildingColour.Text = cldlgBuildingColor.Color.R.ToString() + "." + cldlgBuildingColor.Color.G.ToString()
                + "." + cldlgBuildingColor.Color.B.ToString();
        }

        private void LoadForm()
        {
            LoadFirstBuildingMaster();
        }

        private void ClearFormBuildingTab()
        {
            txtBuildingName.Text = "";
            txtBuildingDescription.Text = "";
            txtBuildingColour.Text = "";
            txtBuildingCurrentHouseNumber.Text = "";
            txtBuildingEstate.Text = "";
            txtBuildingNoOfFloors.Text = "";
            txtBuildingSerialNumber.Text = "";
            txtBuildingPhysicalAddress.Text = "";

            if (picBuildingPhoto.Image != null)
            {
                picBuildingPhoto.Image.Dispose();
                picBuildingPhoto.Image = null;
            }
            
            dtDateCreated.Value = dtDateCreated.MinDate;
            dtDateRegistered.Value = dtDateRegistered.MinDate;
            dtDateDeregistered.Value = dtDateDeregistered.MinDate;
            dtDateConstructed.Value = dtDateConstructed.MinDate;
            LoadUsages(0);
            LoadBuildingTypes(0);
            cmbBuildingUsage.SelectedValue = "6";
            cmbBuildingType.SelectedValue = "7";

        }

        private void ClearFormBuildingAppartmentsTab()
        {
            txtAppartmentDescription.Text = "";
            txtAppartmentFootPrintArea.Text = "";
            txtAppartmentNumber.Text = "";
        }

        private void ClearFormBuildingAppartmentRoomsTab()
        {
            txtAppartmentRoomName.Text = "";
            txtAppartmentRoomNumber.Text = "";
            if (picAppartmentRooms.Image != null)
            {
                picAppartmentRooms.Image.Dispose();
                picAppartmentRooms.Image = null;
            }
        }

        private void ClearFormBuildingAddressTab()
        {
            txtBuilingAddressUniversalAddress.Text = "";
            txtBuilingAddressPOICoordinates.Text = "";
            txtBuilingAddressDescription.Text = "";

        }


        #endregion       

        #region "GIS"

        public void OpenProject(string projectPath)
        {
            frmAjaxLoading ajLoader = null;

            try
            {
                this.Show();
                ajLoader = new frmAjaxLoading();
                ajLoader.Show();
                ajLoader.Update();

                ReadProject(projectPath);
                this.projectStatus = ProjectState.OpenProject;
                this.currentProjectPath = projectPath;

                this.Text = "Tripodmaps - Tripodsystems";

                //sfMap1.CentrePoint2D = cntPoint;
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

        private void LoadPhysicalAddressMap()
        {
            if (!string.IsNullOrEmpty(strProjectPath))
            {
                OpenProject(strProjectPath);
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
                w = Tripodmaps.Reader.ConversionFunctions.DistanceBetweenLatLongPoints(
                    Tripodmaps.Reader.ConversionFunctions.RefEllipse, r.Bottom, r.Left, r.Bottom, r.Right);
                h = Tripodmaps.Reader.ConversionFunctions.DistanceBetweenLatLongPoints(
                    Tripodmaps.Reader.ConversionFunctions.RefEllipse, r.Bottom, r.Left, r.Top, r.Left);
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
                PointD pt = sfMap1.PixelCoordToGisPoint(e.X, e.Y);
                
                intMouseRecord = sfMap1.LocateShapeIndexOnMouseUp(pt, new Point(e.X, e.Y), "rtk.shp");

                if (intMouseRecord >= 0)
                {
                    ZoomToBuildingImpartialIndex(intMouseRecord);                    
                }
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
            txtBuilingAddressPOICoordinates.Text = sfMap1.PixelCoordToGisPoint(e.Location).X.ToString() +
                "," + sfMap1.PixelCoordToGisPoint(e.Location).Y.ToString();
        }

        private void sfMap1_Paint(object sender, PaintEventArgs e)
        {
            //DrawMarker(e.Graphics, currentMarkerPosition.X, currentMarkerPosition.Y);
        }

        //draws a marker at gis location locX,locY
        private void DrawMarker(Graphics g, double locX, double locY)
        {
            //convert the gis location to pixel coordinates
            Point pt = sfMap1.GisPointToPixelCoord(locX, locY);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //draw a marker centered at the gis location
            //alternative is to draw an image/icon
            g.DrawLine(Pens.Red, pt.X, pt.Y - MarkerWidth, pt.X, pt.Y + MarkerWidth);
            g.DrawLine(Pens.Red, pt.X - MarkerWidth, pt.Y, pt.X + MarkerWidth, pt.Y);
            pt.Offset(-MarkerWidth / 2, -MarkerWidth / 2);
            g.FillEllipse(Brushes.Yellow, pt.X, pt.Y, MarkerWidth, MarkerWidth);
            g.DrawEllipse(Pens.Red, pt.X, pt.Y, MarkerWidth, MarkerWidth);
        }

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
                                    LoadBuildingMasterByMapID(Convert.ToInt64(strSelectedMapIDValue.Trim()));
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

        private void DisplayCompaniesInBuilding()
        {

        }


        #endregion


        
        #region "DatabaseOperations"


        private void LoadFirstBuildingMaster()
        {
            ClearFormBuildingTab();
            ClearFormBuildingAddressTab();
            ClearFormBuildingAppartmentRoomsTab();
            ClearFormBuildingAppartmentsTab();
            

            TRIP_API.IMBuildingMaster imBuildingMaster = new TRIP_API.IMBuildingMaster();

            try
            {

                imBuildingMaster.ReturnFirstBuildingMaster();

                lCurrentBuildingNumber = imBuildingMaster.BuildingID;

                if (imBuildingMaster.BuildingID > 0)
                {
                    if (imBuildingMaster.BuildingName != null)
                    {
                        txtBuildingName.Text = imBuildingMaster.BuildingName.ToString();
                    }

                    if (imBuildingMaster.CurrentHouseNumber != null)
                    {
                        txtBuildingCurrentHouseNumber.Text = imBuildingMaster.CurrentHouseNumber.ToString();
                    }

                    if (imBuildingMaster.PhysicalAddress != null)
                    {
                        txtBuildingPhysicalAddress.Text = imBuildingMaster.PhysicalAddress.ToString();
                    }

                    if (imBuildingMaster.BuildingSNo != null)
                    {
                        txtBuildingSerialNumber.Text = imBuildingMaster.BuildingSNo.ToString();
                    }

                    if (imBuildingMaster.Street1 != 0)
                    {
                        txtBuildingStreet1.Text = imBuildingMaster.Street1.ToString();
                    }

                    if (imBuildingMaster.Street2 != 0)
                    {
                        txtBuildingStreet2.Text = imBuildingMaster.Street2.ToString();
                    }

                    if (imBuildingMaster.Street3 != 0)
                    {
                        txtBuildingStreet3.Text = imBuildingMaster.Street3.ToString();
                    }

                    if (imBuildingMaster.Street4 != 0)
                    {
                        txtBuildingStreet4.Text = imBuildingMaster.Street4.ToString();
                    }

                    if (imBuildingMaster.BuildingTypeID != 0)
                    {
                        cmbBuildingType.SelectedValue = imBuildingMaster.BuildingTypeID;
                    }

                    if (imBuildingMaster.BuildingUsage != 0)
                    {
                        cmbBuildingUsage.SelectedValue = imBuildingMaster.BuildingUsage;
                    }

                    if (imBuildingMaster.NoOfFloors != 0)
                    {
                        txtBuildingNoOfFloors.Text = imBuildingMaster.NoOfFloors.ToString();
                    }

                    if (imBuildingMaster.BuildingColour != null)
                    {
                        txtBuildingColour.Text = imBuildingMaster.BuildingColour.ToString();
                    }

                    if (imBuildingMaster.BuildingDescription != null)
                    {
                        txtBuildingDescription.Text = imBuildingMaster.BuildingDescription.ToString();
                    }

                    if (imBuildingMaster.DateCreated > dtDateCreated.MinDate)
                    {
                        dtDateCreated.Value = imBuildingMaster.DateCreated;
                    }

                    if (imBuildingMaster.DateRegistered > dtDateRegistered.MinDate)
                    {
                        dtDateRegistered.Value = imBuildingMaster.DateRegistered;
                    }

                    if (imBuildingMaster.DateDeRegistered > dtDateDeregistered.MinDate)
                    {
                        dtDateDeregistered.Value = imBuildingMaster.DateDeRegistered;
                    }

                    if (imBuildingMaster.DateConstructed > dtDateConstructed.MinDate)
                    {
                        dtDateConstructed.Value = imBuildingMaster.DateConstructed;
                    }

                    if (imBuildingMaster.MapID != 0)
                    {
                        ZoomToBuilding(imBuildingMaster.MapID);
                    }

                    txtBuildingName.Focus();

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

        private void LoadNextBuildingMaster()
        {
            

            TRIP_API.IMBuildingMaster imBuildingMaster = new TRIP_API.IMBuildingMaster();

            try
            {

                imBuildingMaster.BuildingID = lCurrentBuildingNumber;

                if (imBuildingMaster.ReturnNextBuildingMaster() == true)
                {
                    ClearFormBuildingAddressTab();
                    ClearFormBuildingAppartmentRoomsTab();
                    ClearFormBuildingAppartmentsTab();
                    ClearFormBuildingTab();

                    lCurrentBuildingNumber = imBuildingMaster.BuildingID;

                    if (imBuildingMaster.BuildingID > 0)
                    {
                        if (imBuildingMaster.BuildingName != null)
                        {
                            txtBuildingName.Text = imBuildingMaster.BuildingName.ToString();
                        }

                        if (imBuildingMaster.CurrentHouseNumber != null)
                        {
                            txtBuildingCurrentHouseNumber.Text = imBuildingMaster.CurrentHouseNumber.ToString();
                        }

                        if (imBuildingMaster.PhysicalAddress != null)
                        {
                            txtBuildingPhysicalAddress.Text = imBuildingMaster.PhysicalAddress.ToString();
                        }

                        if (imBuildingMaster.BuildingSNo != null)
                        {
                            txtBuildingSerialNumber.Text = imBuildingMaster.BuildingSNo.ToString();
                        }

                        if (imBuildingMaster.Street1 != 0)
                        {
                            txtBuildingStreet1.Text = imBuildingMaster.Street1.ToString();
                        }

                        if (imBuildingMaster.Street2 != 0)
                        {
                            txtBuildingStreet2.Text = imBuildingMaster.Street2.ToString();
                        }

                        if (imBuildingMaster.Street3 != 0)
                        {
                            txtBuildingStreet3.Text = imBuildingMaster.Street3.ToString();
                        }

                        if (imBuildingMaster.Street4 != 0)
                        {
                            txtBuildingStreet4.Text = imBuildingMaster.Street4.ToString();
                        }

                        if (imBuildingMaster.BuildingTypeID != 0)
                        {
                            cmbBuildingType.SelectedValue = imBuildingMaster.BuildingTypeID;
                        }

                        if (imBuildingMaster.BuildingUsage != 0)
                        {
                            cmbBuildingUsage.SelectedValue = imBuildingMaster.BuildingUsage;
                        }

                        if (imBuildingMaster.NoOfFloors != 0)
                        {
                            txtBuildingNoOfFloors.Text = imBuildingMaster.NoOfFloors.ToString();
                        }

                        if (imBuildingMaster.BuildingColour != null)
                        {
                            txtBuildingColour.Text = imBuildingMaster.BuildingColour.ToString();
                        }

                        if (imBuildingMaster.BuildingDescription != null)
                        {
                            txtBuildingDescription.Text = imBuildingMaster.BuildingDescription.ToString();
                        }

                        if (imBuildingMaster.DateCreated > dtDateCreated.MinDate)
                        {
                            dtDateCreated.Value = imBuildingMaster.DateCreated;
                        }

                        if (imBuildingMaster.DateRegistered > dtDateRegistered.MinDate)
                        {
                            dtDateRegistered.Value = imBuildingMaster.DateRegistered;
                        }

                        if (imBuildingMaster.DateDeRegistered > dtDateDeregistered.MinDate)
                        {
                            dtDateDeregistered.Value = imBuildingMaster.DateDeRegistered;
                        }

                        if (imBuildingMaster.DateConstructed > dtDateConstructed.MinDate)
                        {
                            dtDateConstructed.Value = imBuildingMaster.DateConstructed;
                        }

                        if (imBuildingMaster.MapID != 0)
                        {
                            ZoomToBuilding(imBuildingMaster.MapID);
                        }

                        txtBuildingName.Focus();

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

        private void LoadPreviousBuildingMaster()
        {
           

            TRIP_API.IMBuildingMaster imBuildingMaster = new TRIP_API.IMBuildingMaster();

            try
            {

                imBuildingMaster.BuildingID = lCurrentBuildingNumber;

                if (imBuildingMaster.ReturnPreviousBuildingMaster() == true)
                {
                    ClearFormBuildingAddressTab();
                    ClearFormBuildingAppartmentRoomsTab();
                    ClearFormBuildingAppartmentsTab();
                    ClearFormBuildingTab();

                    lCurrentBuildingNumber = imBuildingMaster.BuildingID;

                    if (imBuildingMaster.BuildingID > 0)
                    {
                        if (imBuildingMaster.BuildingName != null)
                        {
                            txtBuildingName.Text = imBuildingMaster.BuildingName.ToString();
                        }

                        if (imBuildingMaster.CurrentHouseNumber != null)
                        {
                            txtBuildingCurrentHouseNumber.Text = imBuildingMaster.CurrentHouseNumber.ToString();
                        }

                        if (imBuildingMaster.PhysicalAddress != null)
                        {
                            txtBuildingPhysicalAddress.Text = imBuildingMaster.PhysicalAddress.ToString();
                        }

                        if (imBuildingMaster.BuildingSNo != null)
                        {
                            txtBuildingSerialNumber.Text = imBuildingMaster.BuildingSNo.ToString();
                        }

                        if (imBuildingMaster.Street1 != 0)
                        {
                            txtBuildingStreet1.Text = imBuildingMaster.Street1.ToString();
                        }

                        if (imBuildingMaster.Street2 != 0)
                        {
                            txtBuildingStreet2.Text = imBuildingMaster.Street2.ToString();
                        }

                        if (imBuildingMaster.Street3 != 0)
                        {
                            txtBuildingStreet3.Text = imBuildingMaster.Street3.ToString();
                        }

                        if (imBuildingMaster.Street4 != 0)
                        {
                            txtBuildingStreet4.Text = imBuildingMaster.Street4.ToString();
                        }

                        if (imBuildingMaster.BuildingTypeID != 0)
                        {
                            cmbBuildingType.SelectedValue = imBuildingMaster.BuildingTypeID;
                        }

                        if (imBuildingMaster.BuildingUsage != 0)
                        {
                            cmbBuildingUsage.SelectedValue = imBuildingMaster.BuildingUsage;
                        }

                        if (imBuildingMaster.NoOfFloors != 0)
                        {
                            txtBuildingNoOfFloors.Text = imBuildingMaster.NoOfFloors.ToString();
                        }

                        if (imBuildingMaster.BuildingColour != null)
                        {
                            txtBuildingColour.Text = imBuildingMaster.BuildingColour.ToString();
                        }

                        if (imBuildingMaster.BuildingDescription != null)
                        {
                            txtBuildingDescription.Text = imBuildingMaster.BuildingDescription.ToString();
                        }

                        if (imBuildingMaster.DateCreated > dtDateCreated.MinDate)
                        {
                            dtDateCreated.Value = imBuildingMaster.DateCreated;
                        }

                        if (imBuildingMaster.DateRegistered > dtDateRegistered.MinDate)
                        {
                            dtDateRegistered.Value = imBuildingMaster.DateRegistered;
                        }

                        if (imBuildingMaster.DateDeRegistered > dtDateDeregistered.MinDate)
                        {
                            dtDateDeregistered.Value = imBuildingMaster.DateDeRegistered;
                        }

                        if (imBuildingMaster.DateConstructed > dtDateConstructed.MinDate)
                        {
                            dtDateConstructed.Value = imBuildingMaster.DateConstructed;
                        }

                        if (imBuildingMaster.MapID != 0)
                        {
                            ZoomToBuilding(imBuildingMaster.MapID);
                        }

                        txtBuildingName.Focus();

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

                imBuildingMaster = null;
            }



        }

        private void LoadLastBuildingMaster()
        {

            ClearFormBuildingAddressTab();
            ClearFormBuildingAppartmentRoomsTab();
            ClearFormBuildingAppartmentsTab();
            ClearFormBuildingTab();

            TRIP_API.IMBuildingMaster imBuildingMaster = new TRIP_API.IMBuildingMaster();

            try
            {

                imBuildingMaster.ReturnLastBuildingMaster();

                lCurrentBuildingNumber = imBuildingMaster.BuildingID;

                if (imBuildingMaster.BuildingID > 0)
                {
                    if (imBuildingMaster.BuildingName != null)
                    {
                        txtBuildingName.Text = imBuildingMaster.BuildingName.ToString();
                    }

                    if (imBuildingMaster.CurrentHouseNumber != null)
                    {
                        txtBuildingCurrentHouseNumber.Text = imBuildingMaster.CurrentHouseNumber.ToString();
                    }

                    if (imBuildingMaster.PhysicalAddress != null)
                    {
                        txtBuildingPhysicalAddress.Text = imBuildingMaster.PhysicalAddress.ToString();
                    }

                    if (imBuildingMaster.BuildingSNo != null)
                    {
                        txtBuildingSerialNumber.Text = imBuildingMaster.BuildingSNo.ToString();
                    }

                    if (imBuildingMaster.Street1 != 0)
                    {
                        txtBuildingStreet1.Text = imBuildingMaster.Street1.ToString();
                    }

                    if (imBuildingMaster.Street2 != 0)
                    {
                        txtBuildingStreet2.Text = imBuildingMaster.Street2.ToString();
                    }

                    if (imBuildingMaster.Street3 != 0)
                    {
                        txtBuildingStreet3.Text = imBuildingMaster.Street3.ToString();
                    }

                    if (imBuildingMaster.Street4 != 0)
                    {
                        txtBuildingStreet4.Text = imBuildingMaster.Street4.ToString();
                    }

                    if (imBuildingMaster.BuildingTypeID != 0)
                    {
                        cmbBuildingType.SelectedValue = imBuildingMaster.BuildingTypeID;
                    }

                    if (imBuildingMaster.BuildingUsage != 0)
                    {
                        cmbBuildingUsage.SelectedValue = imBuildingMaster.BuildingUsage;
                    }

                    if (imBuildingMaster.NoOfFloors != 0)
                    {
                        txtBuildingNoOfFloors.Text = imBuildingMaster.NoOfFloors.ToString();
                    }

                    if (imBuildingMaster.BuildingColour != null)
                    {
                        txtBuildingColour.Text = imBuildingMaster.BuildingColour.ToString();
                    }

                    if (imBuildingMaster.BuildingDescription != null)
                    {
                        txtBuildingDescription.Text = imBuildingMaster.BuildingDescription.ToString();
                    }

                    if (imBuildingMaster.DateCreated > dtDateCreated.MinDate)
                    {
                        dtDateCreated.Value = imBuildingMaster.DateCreated;
                    }

                    if (imBuildingMaster.DateRegistered > dtDateRegistered.MinDate)
                    {
                        dtDateRegistered.Value = imBuildingMaster.DateRegistered;
                    }

                    if (imBuildingMaster.DateDeRegistered > dtDateDeregistered.MinDate)
                    {
                        dtDateDeregistered.Value = imBuildingMaster.DateDeRegistered;
                    }

                    if (imBuildingMaster.DateConstructed > dtDateConstructed.MinDate)
                    {
                        dtDateConstructed.Value = imBuildingMaster.DateConstructed;
                    }

                    if (imBuildingMaster.MapID != 0)
                    {
                        ZoomToBuilding(imBuildingMaster.MapID);
                    }

                    txtBuildingName.Focus();


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

        public void LoadBuildingMasterByBuildingID(long lArgBuildingNumber)
        {

            ClearFormBuildingAddressTab();
            ClearFormBuildingAppartmentRoomsTab();
            ClearFormBuildingAppartmentsTab();
            ClearFormBuildingTab();

            TRIP_API.IMBuildingMaster imBuildingMaster = new TRIP_API.IMBuildingMaster();

            try
            {

                if (lArgBuildingNumber > 0)
                {
                    imBuildingMaster.BuildingID = lArgBuildingNumber;
                    if (imBuildingMaster.ReturnBuildingMasterByBuildingID(0, 0) == true)
                    {
                        lCurrentBuildingNumber = imBuildingMaster.BuildingID;

                        if (imBuildingMaster.BuildingID > 0)
                        {

                            if (imBuildingMaster.BuildingName != null)
                            {
                                txtBuildingName.Text = imBuildingMaster.BuildingName.ToString();
                            }

                            if (imBuildingMaster.CurrentHouseNumber != null)
                            {
                                txtBuildingCurrentHouseNumber.Text = imBuildingMaster.CurrentHouseNumber.ToString();
                            }

                            if (imBuildingMaster.PhysicalAddress != null)
                            {
                                txtBuildingPhysicalAddress.Text = imBuildingMaster.PhysicalAddress.ToString();
                            }

                            if (imBuildingMaster.BuildingSNo != null)
                            {
                                txtBuildingSerialNumber.Text = imBuildingMaster.BuildingSNo.ToString();
                            }

                            if (imBuildingMaster.Street1 != 0)
                            {
                                txtBuildingStreet1.Text = imBuildingMaster.Street1.ToString();
                            }

                            if (imBuildingMaster.Street2 != 0)
                            {
                                txtBuildingStreet2.Text = imBuildingMaster.Street2.ToString();
                            }

                            if (imBuildingMaster.Street3 != 0)
                            {
                                txtBuildingStreet3.Text = imBuildingMaster.Street3.ToString();
                            }

                            if (imBuildingMaster.Street4 != 0)
                            {
                                txtBuildingStreet4.Text = imBuildingMaster.Street4.ToString();
                            }

                            if (imBuildingMaster.BuildingTypeID != 0)
                            {
                                cmbBuildingType.SelectedValue = imBuildingMaster.BuildingTypeID;
                            }

                            if (imBuildingMaster.BuildingUsage != 0)
                            {
                                cmbBuildingUsage.SelectedValue = imBuildingMaster.BuildingUsage;
                            }

                            if (imBuildingMaster.NoOfFloors != 0)
                            {
                                txtBuildingNoOfFloors.Text = imBuildingMaster.NoOfFloors.ToString();
                            }

                            if (imBuildingMaster.BuildingColour != null)
                            {
                                txtBuildingColour.Text = imBuildingMaster.BuildingColour.ToString();
                            }

                            if (imBuildingMaster.BuildingDescription != null)
                            {
                                txtBuildingDescription.Text = imBuildingMaster.BuildingDescription.ToString();
                            }

                            if (imBuildingMaster.DateCreated > dtDateCreated.MinDate)
                            {
                                dtDateCreated.Value = imBuildingMaster.DateCreated;
                            }

                            if (imBuildingMaster.DateRegistered > dtDateRegistered.MinDate)
                            {
                                dtDateRegistered.Value = imBuildingMaster.DateRegistered;
                            }

                            if (imBuildingMaster.DateDeRegistered > dtDateDeregistered.MinDate)
                            {
                                dtDateDeregistered.Value = imBuildingMaster.DateDeRegistered;
                            }

                            if (imBuildingMaster.DateConstructed > dtDateConstructed.MinDate)
                            {
                                dtDateConstructed.Value = imBuildingMaster.DateConstructed;
                            }

                            if (imBuildingMaster.MapID != 0)
                            {
                                ZoomToBuilding(imBuildingMaster.MapID);
                            }

                            txtBuildingName.Focus();

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

        public void LoadBuildingMasterByMapID(long lArgMapID)
        {

            ClearFormBuildingAddressTab();
            ClearFormBuildingAppartmentRoomsTab();
            ClearFormBuildingAppartmentsTab();
            ClearFormBuildingTab();

            TRIP_API.IMBuildingMaster imBuildingMaster = new TRIP_API.IMBuildingMaster();

            try
            {

                if (lArgMapID > 0)
                {
                    imBuildingMaster.MapID = lArgMapID;
                    if (imBuildingMaster.ReturnBuildingMasterByMapID(0, 0) == true)
                    {
                        lCurrentBuildingNumber = imBuildingMaster.BuildingID;

                        if (imBuildingMaster.BuildingID > 0)
                        {

                            if (imBuildingMaster.BuildingName != null)
                            {
                                txtBuildingName.Text = imBuildingMaster.BuildingName.ToString();
                            }

                            if (imBuildingMaster.CurrentHouseNumber != null)
                            {
                                txtBuildingCurrentHouseNumber.Text = imBuildingMaster.CurrentHouseNumber.ToString();
                            }

                            if (imBuildingMaster.PhysicalAddress != null)
                            {
                                txtBuildingPhysicalAddress.Text = imBuildingMaster.PhysicalAddress.ToString();
                            }

                            if (imBuildingMaster.BuildingSNo != null)
                            {
                                txtBuildingSerialNumber.Text = imBuildingMaster.BuildingSNo.ToString();
                            }

                            if (imBuildingMaster.Street1 != 0)
                            {
                                txtBuildingStreet1.Text = imBuildingMaster.Street1.ToString();
                            }

                            if (imBuildingMaster.Street2 != 0)
                            {
                                txtBuildingStreet2.Text = imBuildingMaster.Street2.ToString();
                            }

                            if (imBuildingMaster.Street3 != 0)
                            {
                                txtBuildingStreet3.Text = imBuildingMaster.Street3.ToString();
                            }

                            if (imBuildingMaster.Street4 != 0)
                            {
                                txtBuildingStreet4.Text = imBuildingMaster.Street4.ToString();
                            }

                            if (imBuildingMaster.BuildingTypeID != 0)
                            {
                                cmbBuildingType.SelectedValue = imBuildingMaster.BuildingTypeID;
                            }

                            if (imBuildingMaster.BuildingUsage != 0)
                            {
                                cmbBuildingUsage.SelectedValue = imBuildingMaster.BuildingUsage;
                            }

                            if (imBuildingMaster.NoOfFloors != 0)
                            {
                                txtBuildingNoOfFloors.Text = imBuildingMaster.NoOfFloors.ToString();
                            }

                            if (imBuildingMaster.BuildingColour != null)
                            {
                                txtBuildingColour.Text = imBuildingMaster.BuildingColour.ToString();
                            }

                            if (imBuildingMaster.BuildingDescription != null)
                            {
                                txtBuildingDescription.Text = imBuildingMaster.BuildingDescription.ToString();
                            }

                            if (imBuildingMaster.DateCreated > dtDateCreated.MinDate)
                            {
                                dtDateCreated.Value = imBuildingMaster.DateCreated;
                            }

                            if (imBuildingMaster.DateRegistered > dtDateRegistered.MinDate)
                            {
                                dtDateRegistered.Value = imBuildingMaster.DateRegistered;
                            }

                            if (imBuildingMaster.DateDeRegistered > dtDateDeregistered.MinDate)
                            {
                                dtDateDeregistered.Value = imBuildingMaster.DateDeRegistered;
                            }

                            if (imBuildingMaster.DateConstructed > dtDateConstructed.MinDate)
                            {
                                dtDateConstructed.Value = imBuildingMaster.DateConstructed;
                            }

                            if (imBuildingMaster.MapID != 0)
                            {
                                ZoomToBuilding(imBuildingMaster.MapID);
                            }

                            txtBuildingName.Focus();

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

        private void LoadUsages(long lArgDefaultUsageID)
        {
            TRIP_API.IMUsage imUsage = new TRIP_API.IMUsage();

            try
            {

                imUsage.ReturnAllUsageIDAndUsageNameByUsageID(0, 0);
                cmbBuildingUsage.Items.Clear();


                if (imUsage.UsageDataset != null)
                {
                    cmbBuildingUsage.DataSource = imUsage.UsageDataset.Tables[0];
                    cmbBuildingUsage.DisplayMember = "USAGENAME";
                    cmbBuildingUsage.ValueMember = "USAGEID";
                }

                if (lArgDefaultUsageID > 0)
                {
                    cmbBuildingUsage.SelectedValue = lArgDefaultUsageID;
                }

            }

            catch (Exception ex)
            {
                string err = ex.Message + " Source=" + ex.Source;
            }

            finally
            {

                imUsage = null;
            }

        }

        private void LoadBuildingTypes(long lArgDefaultBuildingTypeID)
        {
            TRIP_API.IMBuildingTypes imBuldingTypes = new TRIP_API.IMBuildingTypes();

            try
            {

                imBuldingTypes.ReturnAllBuildingTypeIDAndBuildingTypeNameByBuildingTypeID(0, 0);
                cmbBuildingType.Items.Clear();


                if (imBuldingTypes.BuildingTypesDataSet != null)
                {
                    cmbBuildingType.DataSource = imBuldingTypes.BuildingTypesDataSet.Tables[0];
                    cmbBuildingType.DisplayMember = "BUILDINGTYPENAME";
                    cmbBuildingType.ValueMember = "BUILDINGTYPEID";
                }

                if (lArgDefaultBuildingTypeID > 0)
                {
                    cmbBuildingType.SelectedValue = lArgDefaultBuildingTypeID;
                }



            }

            catch (Exception ex)
            {
                string err = ex.Message + " Source=" + ex.Source;
            }

            finally
            {

                imBuldingTypes = null;
            }

        }

        private void SaveBuildingMaster()
        {
            TRIP_API.IMBuildingMaster imBuildingMaster;
            try
            {
                imBuildingMaster = new TRIP_API.IMBuildingMaster();
                imBuildingMaster.BuildingID = lCurrentBuildingNumber;
                imBuildingMaster.BuildingName = txtBuildingName.Text;
                imBuildingMaster.CurrentHouseNumber = txtBuildingCurrentHouseNumber.Text;

                imBuildingMaster.PhysicalAddress = txtBuildingPhysicalAddress.Text;
                imBuildingMaster.BuildingSNo = txtBuildingSerialNumber.Text;

                if (CheckIfStringValueIsNumeric(txtBuildingStreet1.Text))
                {
                    imBuildingMaster.Street1 = Convert.ToInt64(txtBuildingStreet1.Text);
                }

                if (CheckIfStringValueIsNumeric(txtBuildingStreet2.Text))
                {
                    imBuildingMaster.Street2 = Convert.ToInt64(txtBuildingStreet2.Text);
                }

                if (CheckIfStringValueIsNumeric(txtBuildingStreet3.Text))
                {
                    imBuildingMaster.Street3 = Convert.ToInt64(txtBuildingStreet3.Text);
                }

                if (CheckIfStringValueIsNumeric(txtBuildingStreet4.Text))
                 {
                     imBuildingMaster.Street4 = Convert.ToInt64(txtBuildingStreet4.Text);
                 }

                if (CheckIfStringValueIsNumeric(cmbBuildingType.SelectedValue.ToString()))
                {
                    imBuildingMaster.BuildingTypeID = Convert.ToInt64(cmbBuildingType.SelectedValue);
                }

                if (CheckIfStringValueIsNumeric(cmbBuildingUsage.SelectedValue.ToString()))
                {
                    imBuildingMaster.BuildingUsage = Convert.ToInt64(cmbBuildingUsage.SelectedValue);
                }

                if (CheckIfStringValueIsNumeric(txtBuildingNoOfFloors.Text))
                {
                    imBuildingMaster.NoOfFloors = Convert.ToInt64(txtBuildingNoOfFloors.Text);
                }

                if (dtDateConstructed.Value > dtDateConstructed.MinDate)
                {
                    imBuildingMaster.DateConstructed = dtDateConstructed.MinDate;
                }


                imBuildingMaster.BuildingColour = txtBuildingColour.Text;

                imBuildingMaster.SaveBuildingMaster();

            }

            catch (Exception ex)
            {
                errMessage = ex.Message;
            }

            finally
            {
                imBuildingMaster = null;
            }

        }

        private void SaveBuildingImages()
        {

        }


        #endregion

        #region "Interfaces"


        private void frmBuildingMaster_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void tlstrpbtnFirst_Click(object sender, EventArgs e)
        {
            LoadFirstBuildingMaster();
        }

        private void tlstrpbtnPrevious_Click(object sender, EventArgs e)
        {
            LoadPreviousBuildingMaster();
        }

        private void tlstrpbtnNext_Click(object sender, EventArgs e)
        {
            LoadNextBuildingMaster();
        }

        private void tlstrpbtnLast_Click(object sender, EventArgs e)
        {
            LoadLastBuildingMaster();
        }


        #endregion

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmdBuildingSaveImage_Click(object sender, EventArgs e)
        {

        }

        private void sfMap1_Load(object sender, EventArgs e)
        {

        }

        private void frmBuildings_FormClosing(Object sender, FormClosingEventArgs e)
        {
            MainForm frmMain = (MainForm)Application.OpenForms["MainForm"];
            frmMain.CloseBuildingForm();
        }
       
    }
}
