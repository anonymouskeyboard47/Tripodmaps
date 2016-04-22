using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Tripodmaps.Reader;
using System.IO;

namespace Tripodmaps
{
    public partial class frmCustomers : Form
    {
        private long lCurrentCustomerNumber = 0;
        private long lCurrentBuildingNumber = 0;
        private long lCurrentPlotNumber = 0;
        private long lCurrentAddressID = 0;
        private long lCurrentMapID = 0;

        private TabPage tabPrivateCustomerTab;
        private TabPage tabOrganizationCustomerTab;
        private TabPage tabCustomerIDTab;
        private TabPage tabCitizenshipTab;
        private bool bActionNewCustomer;

        Tripodmaps.Reader.ShapeFile[] shapefiles;
        Tripodmaps.Reader.ShapeFile buildingshapefile;
        private Tripodmaps.Reader.PointD currentMarkerPosition = new Tripodmaps.Reader.PointD(0, 0);

        private const int MarkerWidth = 10;
        private string errCust = "";

        enum ProjectState { NewProject, UnsavedNewProject, OpenProject, UnsavedOpenProject };

        private ProjectState projectStatus = ProjectState.NewProject;
        private string strProjectPath = null;
        private string currentProjectPath = null;
        private string errMessage;

        public frmCustomers(string strArgProjectPath)
        {
            InitializeComponent();
            strProjectPath = strArgProjectPath;

            tabPrivateCustomerTab = tabCustomers.TabPages[1];
            tabOrganizationCustomerTab = tabCustomers.TabPages[2];
            tabCustomerIDTab = tabCustomers.TabPages[3];
            tabCitizenshipTab = tabCustomers.TabPages[4];

            AddRemovePrivateCustomerTab(2);
            AddRemoveOrganizationCustomerTab(2);
            AddRemoveCustomerIDTab(2);
            AddRemoveCitizenshipTab(2);
        }

        #region "interfaces"

        private void cmbAssetType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPrivateCustomer_Click(object sender, EventArgs e)
        {

        }

        private void cmbIDType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtTimEndDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void grpPhysicalAddressOrgCustomers_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmCustomers_Load(object sender, EventArgs e)
        {
            SetDateFormats();
            LoadForm();
        }

        private void tabOrganizationCustomer_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabCustomers.SelectedTab = tabCustomers.TabPages[0];
        }

        private void dtDateOfBirth_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtCustomerDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmdNext_Click(object sender, EventArgs e)
        {

            CustomerNextClick();

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            SavePrivateCustomer();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabCustomers.SelectedTab = tabCustomers.TabPages["tabOrganizationCustomer"];
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void lblIDType_Click(object sender, EventArgs e)
        {

        }

        private void lblIDNumber_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblCustomerPassword_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        #endregion

        #region "logic"

        private void SetDateFormats()
        {
            dtCustomerDateOfBirth.Format = DateTimePickerFormat.Long;
            dtCustomerIDExpiryDate.Format = DateTimePickerFormat.Long;
            dtCustomerIDRegistrationDate.Format = DateTimePickerFormat.Long;
            dtpckCustomerDateDeleted.Format = DateTimePickerFormat.Long;
            dtpckCustomerDateCreated.Format = DateTimePickerFormat.Long;
        }

        private void AddRemovePrivateCustomerTab(int iAction)
        {
            if (iAction == 2)
            {
                tabCustomers.TabPages.Remove(tabPrivateCustomerTab);
            }
            else
            {

                tabCustomers.TabPages.Add(tabPrivateCustomerTab);
                //this.Controls.Add(tabPrivateCustomerTab);
            }
        }

        private void AddRemoveOrganizationCustomerTab(int iAction)
        {
            if (iAction == 2)
            {
                tabCustomers.TabPages.Remove(tabOrganizationCustomerTab);
            }
            else
            {
                tabCustomers.TabPages.Add(tabOrganizationCustomerTab);
            }
        }

        private void AddRemoveCustomerIDTab(int iAction)
        {
            if (iAction == 2)
            {
                tabCustomers.TabPages.Remove(tabCustomerIDTab);
            }
            else
            {
                tabCustomers.TabPages.Add(tabCustomerIDTab);

            }
        }

        private void AddRemoveCitizenshipTab(int iAction)
        {
            if (iAction == 2)
            {
                tabCustomers.TabPages.Remove(tabCitizenshipTab);
            }
            else
            {
                tabCustomers.TabPages.Add(tabCitizenshipTab);

            }
        }

        private void SavePrivateCustomer()
        {
            TRIP_API.IMPrivateCustomer imPrivCust = null;

            try
            {
                imPrivCust = new TRIP_API.IMPrivateCustomer();

                imPrivCust.CustomerNo = lCurrentCustomerNumber;
                imPrivCust.EmailAddress = txtCustomerEmailAddress.Text.Trim();
                

                if (cmbCustomerCountryOfBirth.SelectedValue != null)
                {
                    imPrivCust.CountryOfBirthID = Convert.ToInt64(cmbCustomerCountryOfBirth.SelectedValue);
                }

                //imPrivCust.CustomerSerialNumber = txtCustomerAccount.Text.Trim();                     
                imPrivCust.CustomerPINNumber = txtCustomerPINNumber.Text.Trim();

                if (dtCustomerDateOfBirth.MinDate > imPrivCust.DateOfBirth.Date)
                {
                    imPrivCust.DateOfBirth = dtCustomerDateOfBirth.Value;
                }

                if (dtpckCustomerDateCreated.MinDate > imPrivCust.DateCreated.Date)
                {
                    imPrivCust.DateCreated = dtpckCustomerDateCreated.Value;
                }

                if (dtpckCustomerDateRegistered.MinDate > imPrivCust.DateRegistered.Date)
                {
                    imPrivCust.DateRegistered = dtpckCustomerDateRegistered.Value;
                }

                if (dtpckCustomerDateDeleted.MinDate > imPrivCust.DateDeRegistered.Date)
                {
                    imPrivCust.DateDeRegistered = dtpckCustomerDateDeleted.Value;
                }

                imPrivCust.FirstName = txtPrivateCustomerFirstName.Text.Trim();
                imPrivCust.MiddleName = txtPrivateCustomerMiddleName.Text.Trim();
                imPrivCust.Surname = txtPrivateCustomerSurname.Text.Trim();
                imPrivCust.OtherName = txtPrivateCustomerOtherName.Text.Trim();

                if (cmbPrivateCustomerSex.SelectedValue != null)
                {
                    imPrivCust.Sex = Convert.ToInt64(cmbPrivateCustomerSex.SelectedValue);
                }

                imPrivCust.Title = cmbPrivateCustomerTitle.Text.Trim();

                imPrivCust.UserName = txtUserLoginName.Text.Trim();
                imPrivCust.UserPassword = txtUserLoginPassword.Text;
                imPrivCust.ConfirmPassword = txtUserLoginConfirmPassword.Text;


                //contact details
                imPrivCust.AddressDetailsTelephone1 = txtContactDetailsLandLineNumber1.Text.Trim();
                imPrivCust.AddressDetailsTelephone2 = txtContactDetailsLandLineNumber2.Text.Trim();

                imPrivCust.AddressDetailsMobilePhone1 = txtContactDetailsMobileNumber1.Text.Trim();
                imPrivCust.AddressDetailsMobilePhone2 = txtContactDetailsMobileNumber2.Text.Trim();

                imPrivCust.AddressDetailsCompanyEmail = txtContactDetailsMainEmailAddress.Text.Trim();
                imPrivCust.AddressDetailsSalesEmail = txtContactDetailsSalesEmailAddress.Text.Trim();

                imPrivCust.AddressDetailsFax1 = txtContactDetailsFax1.Text.Trim();
                imPrivCust.AddressDetailsFax2 = txtContactDetailsFax2.Text.Trim();
                imPrivCust.AddressDetailsPostalAddress = txtContactDetailsPostalAddress.Text.Trim();
                imPrivCust.AddressDetailsBuildingID = lCurrentBuildingNumber;
                imPrivCust.AddressDetailsID = lCurrentAddressID;
                imPrivCust.AddressDetailsOwnerTypeID = 2;

                if (cmbContactDetailsPostalCode.SelectedValue != null)
                {
                    imPrivCust.AddressDetailsPostalCode = cmbContactDetailsPostalCode.SelectedValue.ToString();
                }

                //physical address
                if (cmbPhysicalAddressCustomerCountry.SelectedValue != null)
                {
                    imPrivCust.AddressDetailsCountryID = Convert.ToInt64(cmbPhysicalAddressCustomerCountry.SelectedValue);
                }

                if (cmbPhysicalAddressCustomerCity.SelectedValue != null)
                {
                    imPrivCust.AddressDetailsCityID = Convert.ToInt64(cmbPhysicalAddressCustomerCity.SelectedValue);
                }

                if (cmbPhysicalAddressCustomerProvince.SelectedValue != null)
                {
                    imPrivCust.AddressDetailsProvinceID = Convert.ToInt64(cmbPhysicalAddressCustomerProvince.SelectedValue);
                }

                if (cmbPhysicalAddressCustomerDistrict.SelectedValue != null)
                {
                    imPrivCust.AddressDetailsDistrictID = Convert.ToInt64(cmbPhysicalAddressCustomerDistrict.SelectedValue);
                }

                if (cmbPhysicalAddressCustomerDivision.SelectedValue != null)
                {
                    imPrivCust.AddressDetailsDivisionID = Convert.ToInt64(cmbPhysicalAddressCustomerDivision.SelectedValue);
                }

                if (cmbPhysicalAddressCustomerLocation.SelectedValue != null)
                {
                    imPrivCust.AddressDetailsLocationID = Convert.ToInt64(cmbPhysicalAddressCustomerLocation.SelectedValue);
                }

                if (cmbPhysicalAddressCustomerSubLocation.SelectedValue != null)
                {
                    imPrivCust.AddressDetailsSublocationID = Convert.ToInt64(cmbPhysicalAddressCustomerSubLocation.SelectedValue);
                }

                if (txtPhysicalAddressCustomerPOI.Text.Trim() != "")
                {
                    string[] arPointArray = txtPhysicalAddressCustomerPOI.Text.Split(new char[] { ',' });

                    if (arPointArray.GetLength(0) == 2)
                    {
                        if (!string.IsNullOrEmpty(arPointArray[0]) || !string.IsNullOrEmpty(arPointArray[0]))
                        {
                            NpgsqlTypes.NpgsqlPoint pntAddress = new
                                NpgsqlTypes.NpgsqlPoint(float.Parse(arPointArray[0]), float.Parse(arPointArray[1]));
                            imPrivCust.PhysicalAddressCoordinate = pntAddress;
                        }
                    }
                }

                if (imPrivCust.RegisterPrivateCustomer() == true)
                {
                    MessageBox.Show("Private customer successfuly saved.", "Tripodmaps - Data Saved", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Data not saved.", "Tripodmaps - Data Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            catch (Exception ex)
            {
                errCust = ex.Message + " " + ex.Source;
            }

            finally
            {
                imPrivCust = null;
            }


        }

        private void SaveOrganizationCustomer()
        {
            frmAjaxLoading frmLoadForm = new frmAjaxLoading();
            TRIP_API.IMOrganizationCustomer imorgcustTripodmaps = new TRIP_API.IMOrganizationCustomer();

            try
            {
                frmLoadForm.ShowDialog(this);

                imorgcustTripodmaps.PINNo = txtCustomerPINNumber.Text.Trim();
                imorgcustTripodmaps.EmailAddress = txtCustomerEmailAddress.Text.Trim();
                imorgcustTripodmaps.CountryOfBirthID = Convert.ToInt32(cmbCustomerCountryOfBirth.SelectedValue);
                imorgcustTripodmaps.DateOfBirth = dtCustomerDateOfBirth.Value;
                imorgcustTripodmaps.CustomerPriorityID = cmbCustomerPriority.SelectedValue.ToString();
                imorgcustTripodmaps.CustomerSerialNumber = txtOrganizationVerificationCodes.Text.Trim();
                imorgcustTripodmaps.CustomerTypeID = 2;
                imorgcustTripodmaps.DefaultCurrencyID = Convert.ToInt32(cmbCustomerDefaultCurrency.SelectedValue);
                imorgcustTripodmaps.OrganizationName = txtOrganizationName.Text.Trim();

                if (txtOrganizationVATNo.Text.Trim() != "")
                {
                    imorgcustTripodmaps.VATRegistered = true;
                }



                //organization customer details
                imorgcustTripodmaps.CompanyTypeID = Convert.ToInt32(cmbCustomerType.SelectedValue);
                imorgcustTripodmaps.CompanyRegistrationDate = dtCustomerDateOfBirth.Value;


                imorgcustTripodmaps.UserName = txtUserLoginName.Text.Trim();
                imorgcustTripodmaps.UserPassword = txtUserLoginPassword.Text;
                imorgcustTripodmaps.ConfirmPassword = txtUserLoginConfirmPassword.Text;

            }

            catch (Exception ex)
            {
                errCust = ex.Message;
                frmLoadForm.Close();
                frmLoadForm = null;
                imorgcustTripodmaps = null;
            }

            finally
            {
                frmLoadForm.Close();
                frmLoadForm = null;
                imorgcustTripodmaps = null;

            }

        }

        private void SaveAddressAndContactDetails(long lArgCustomerNo)
        {
            TRIP_API.IMCustomer custAddresses = new TRIP_API.IMCustomer();


            try
            {
                if (lArgCustomerNo > 0)
                {

                    custAddresses.CustomerNo = lArgCustomerNo;

                    //contact details
                    custAddresses.AddressDetailsTelephone1 = txtContactDetailsLandLineNumber1.Text.Trim();
                    custAddresses.AddressDetailsTelephone2 = txtContactDetailsLandLineNumber2.Text.Trim();

                    custAddresses.AddressDetailsMobilePhone1 = txtContactDetailsMobileNumber1.Text.Trim();
                    custAddresses.AddressDetailsMobilePhone2 = txtContactDetailsMobileNumber2.Text.Trim();

                }


            }

            catch (Exception ex)
            {
                errCust = ex.Message;

            }


            finally
            {
                custAddresses = null;
            }
        }

        private void CustomerNextClick()
        {
            frmAjaxLoading frmLoadForm = new frmAjaxLoading();
            frmLoadForm.ShowDialog(this);
            cmbCustomerType.Enabled = false;

            if (cmbCustomerType.SelectedIndex == 0)
            {
                //organization customers
                AddRemovePrivateCustomerTab(1);
                tabCustomers.SelectedTab = tabCustomers.TabPages["tabPrivateCustomer"];

                tabCustomers.TabPages[2].Focus();
            }

            else
            {
                //private customers
                tabCustomers.SelectedTab = tabCustomers.TabPages[1];
                tabCustomers.TabPages[1].Focus();
            }

        }

        private void CustomerNavigationFirstClick()
        {
            frmAjaxLoading frmLoadForm = new frmAjaxLoading();
            frmLoadForm.ShowDialog(this);
            cmbCustomerType.Enabled = false;

            try
            {
                TRIP_API.IMCustomer imCustomer = new TRIP_API.IMCustomer();
                //imCustomer.

                if (cmbCustomerType.SelectedIndex == 0)
                {
                    //organization customers
                    AddRemovePrivateCustomerTab(1);
                    tabCustomers.SelectedTab = tabCustomers.TabPages["tabPrivateCustomer"];

                    tabCustomers.TabPages[2].Focus();
                }

                else
                {
                    //private customers
                    tabCustomers.SelectedTab = tabCustomers.TabPages[1];
                    tabCustomers.TabPages[1].Focus();
                }

            }

            catch (Exception ex)
            {
                errCust = ex.Message;
            }

            finally
            {

            }



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
            //DialogResult rs = MessageBox.Show("Do you want to change the customer location?", "Change Location?", MessageBoxButtons.YesNo);

            //if (rs == DialogResult.Yes)
            //{
            txtPhysicalAddressCustomerPOI.Text = sfMap1.PixelCoordToGisPoint(e.Location).X.ToString() +
                "," + sfMap1.PixelCoordToGisPoint(e.Location).Y.ToString();

            currentMarkerPosition.X = sfMap1.PixelCoordToGisPoint(e.Location).X;
            currentMarkerPosition.Y = sfMap1.PixelCoordToGisPoint(e.Location).Y;

            sfMap1.Refresh();
            //}
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

        private void tlstrpbtnNew_Click(object sender, EventArgs e)
        {
            try
            {
                bActionNewCustomer = true;
            }

            finally
            {

            }
        }

        private void NewRecordForm()
        {
            if (bActionNewCustomer == true)
            {
                DialogResult result;

                result = MessageBox.Show("You are currently adding a new record. " + Environment.NewLine +
                    "Do you want to cancel the current new record procedure?", "Cancel new record procedure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    LoadForm();
                }

            }
            else
            {


            }
        }

        private void LoadForm()
        {
            frmAjaxLoading ajLoader = null;

            try
            {
                
                PointD pxPoint = new PointD();
                Point mousePos = new Point();

                pxPoint.X = MousePosition.X;
                pxPoint.Y = mousePos.Y;

                mousePos.X = MousePosition.X;
                mousePos.Y = mousePos.Y;

                ajLoader = new frmAjaxLoading();
                ajLoader.Show();
                ajLoader.Update();

                LoadCountries(0);
                LoadCurrencies(0);
                LoadFirstCustomer();
                LoadPhysicalAddressMap();

                sfMap1.LocateShape(pxPoint, mousePos);

            }

            finally
            {
                ajLoader.Close();
                ajLoader = null;

            }


        }

        private void LoadPhysicalAddressMap()
        {
            if (!string.IsNullOrEmpty(strProjectPath))
            {
                OpenProject(strProjectPath);
                FindShapeFile("rtk.shp");
            }


        }

        private void CleanCustomerForm()
        {
            //clear the status bar
            statstrpCustomer.Items[0].Text = "";
            statstrpCustomer.Items[1].Text = "";
            statstrpCustomer.Items[2].Text = "";

            LoadCountries(0); //0 = no Country selected
            LoadCurrencies(0);

            //clear customer login details
            txtUserLoginConfirmPassword.Text = "";
            txtUserLoginPassword.Text = "";

            //clear main customer details
            txtCustomerDescription.Text = "";
            txtCustomerPINNumber.Text = "";
            txtCustomerAddedBy.Text = "";
            txtCustomerEmailAddress.Text = "";
            txtCustomerName.Text = "";
            txtCustomerAccount.Text = "";



            //clear private customer details
            txtPrivateCustomerFirstName.Text = "";
            txtPrivateCustomerMiddleName.Text = "";
            txtPhysicalAddressCustomerPOI.Text = "";
            txtPrivateCustomerSurname.Text = "";
            txtPhysicalAddressUniversalAddress.Text = "";
            txtPrivateCustomerVerificationCodes.Text = "";

            //clear organization customer details
            txtOrganizationName.Text = "";
            txtOrganizationRegistrationNo.Text = "";
            txtOrganizationVATNo.Text = "";
            txtOrganizationVerificationCodes.Text = "";
            cmbOrganizationBranchOf.Items.Clear();
            cmbOrganizationType.Items.Clear();

            //clear contact details
            //contact details
            txtContactDetailsLandLineNumber1.Text = "";
            txtContactDetailsLandLineNumber2.Text = "";
            txtContactDetailsMobileNumber1.Text = "";
            txtContactDetailsMobileNumber2.Text = "";
            txtContactDetailsMainEmailAddress.Text = "";
            txtContactDetailsSalesEmailAddress.Text = "";
            txtContactDetailsSupportEmailAddress.Text = "";
            txtContactDetailsFax1.Text = "";
            txtContactDetailsFax2.Text = "";

            //physical address

        }

        private void CleanPrivateCustomerForm()
        {

        }

        private void CleanOrganizationCustomerForm()
        {

        }

        private void LoadFirstCustomer()
        {
            currentMarkerPosition = new PointD(0, 0);
            lCurrentAddressID = 0;
            lCurrentBuildingNumber = 0;
            lCurrentCustomerNumber = 0;
            lCurrentMapID = 0;
            lCurrentPlotNumber = 0;

            AddRemovePrivateCustomerTab(2);
            AddRemoveOrganizationCustomerTab(2);
            AddRemoveCustomerIDTab(2);
            AddRemoveCitizenshipTab(2);
            CleanCustomerForm();

            TRIP_API.IMCustomer imCust = new TRIP_API.IMCustomer();

            try
            {
                long lCustomerNumber = 0;
                long lCustomerType = 0;

                //get the first customer number
                imCust.ReturnFirstCustomerNo();

                if (imCust.CustomerNo > 0)
                {
                    lCustomerNumber = imCust.CustomerNo;
                    imCust.CheckCustomerType();
                    lCustomerType = imCust.CustomerTypeID;
                    lCurrentCustomerNumber = lCustomerNumber;

                    //private customer                    
                    if (lCustomerType == 1)
                    {

                        LoadPrivateCustomer(lCustomerNumber);

                    }

                    //organization customer
                    else if (lCustomerType == 2)
                    {
                        LoadOrganizationCustomer(lCustomerNumber);
                    }

                }

                else
                {
                    statstrpCustomer.Items[0].Text = "There are no customer records";
                }



            }

            catch (Exception ex)
            {
                string Err = ex.Message + " ;Source = " + ex.Source;
                imCust = null;
            }

            finally
            {
                imCust = null;

            }

        }

        private void LoadPreviousCustomer()
        {
            currentMarkerPosition = new PointD(0, 0);
            lCurrentAddressID = 0;
            lCurrentBuildingNumber = 0;
            lCurrentCustomerNumber = 0;
            lCurrentMapID = 0;
            lCurrentPlotNumber = 0;

            AddRemovePrivateCustomerTab(2);
            AddRemoveOrganizationCustomerTab(2);
            AddRemoveCustomerIDTab(2);
            AddRemoveCitizenshipTab(2);
            CleanCustomerForm();

            TRIP_API.IMCustomer imCust = new TRIP_API.IMCustomer();

            try
            {
                long lCustomerNumber = 0;
                long lCustomerType = 0;

                imCust.CustomerNo = lCurrentCustomerNumber;

                //get the first customer number
                imCust.ReturnPreviousCustomerNo();

                if (imCust.CustomerNo > 0)
                {
                    lCustomerNumber = imCust.CustomerNo;
                    imCust.CheckCustomerType();
                    lCustomerType = imCust.CustomerTypeID;
                    lCurrentCustomerNumber = lCustomerNumber;



                    //private customer                    
                    if (lCustomerType == 1)
                    {

                        LoadPrivateCustomer(lCustomerNumber);

                    }

                    //organization customer
                    else if (lCustomerType == 2)
                    {
                        LoadOrganizationCustomer(lCustomerNumber);
                    }
                }

                else
                {
                    statstrpCustomer.Items[0].Text = "You have reached the First Customer";
                }

            }

            catch (Exception ex)
            {
                string Err = ex.Message + " ;Source = " + ex.Source;
                imCust = null;
            }

            finally
            {
                imCust = null;

            }

        }

        private void LoadNextCustomer()
        {
            currentMarkerPosition = new PointD(0, 0);
            lCurrentAddressID = 0;
            lCurrentBuildingNumber = 0;
            lCurrentCustomerNumber = 0;
            lCurrentMapID = 0;
            lCurrentPlotNumber = 0;

            AddRemovePrivateCustomerTab(2);
            AddRemoveOrganizationCustomerTab(2);
            AddRemoveCustomerIDTab(2);
            AddRemoveCitizenshipTab(2);
            CleanCustomerForm();

            TRIP_API.IMCustomer imCust = new TRIP_API.IMCustomer();

            try
            {
                long lCustomerNumber = 0;
                long lCustomerType = 0;

                imCust.CustomerNo = lCurrentCustomerNumber;

                //get the first customer number
                imCust.ReturnNextCustomerNo();

                if (imCust.CustomerNo > 0)
                {
                    lCustomerNumber = imCust.CustomerNo;
                    imCust.CheckCustomerType();
                    lCustomerType = imCust.CustomerTypeID;
                    lCurrentCustomerNumber = lCustomerNumber;




                    //private customer                    
                    if (lCustomerType == 1)
                    {
                        LoadPrivateCustomer(lCustomerNumber);
                    }

                    //organization customer
                    else if (lCustomerType == 2)
                    {
                        LoadOrganizationCustomer(lCustomerNumber);
                    }
                }

                else
                {
                    statstrpCustomer.Items[0].Text = "You have reached the last customer";
                }

            }

            catch (Exception ex)
            {
                string Err = ex.Message + " ;Source = " + ex.Source;
                imCust = null;
            }

            finally
            {
                imCust = null;

            }

        }

        private void LoadLastCustomer()
        {
            currentMarkerPosition = new PointD(0, 0);
            lCurrentAddressID = 0;
            lCurrentBuildingNumber = 0;
            lCurrentCustomerNumber = 0;
            lCurrentMapID = 0;
            lCurrentPlotNumber = 0;

            AddRemovePrivateCustomerTab(2);
            AddRemoveOrganizationCustomerTab(2);
            AddRemoveCustomerIDTab(2);
            AddRemoveCitizenshipTab(2);
            CleanCustomerForm();

            TRIP_API.IMCustomer imCust = new TRIP_API.IMCustomer();

            try
            {
                long lCustomerNumber = 0;
                long lCustomerType = 0;

                //get the first customer number
                imCust.ReturnLastCustomerNo();

                if (imCust.CustomerNo > 0)
                {
                    lCustomerNumber = imCust.CustomerNo;
                    imCust.CheckCustomerType();
                    lCustomerType = imCust.CustomerTypeID;
                    lCurrentCustomerNumber = lCustomerNumber;



                    //private customer                    
                    if (lCustomerType == 1)
                    {

                        LoadPrivateCustomer(lCustomerNumber);

                    }

                    //organization customer
                    else if (lCustomerType == 2)
                    {
                        LoadOrganizationCustomer(lCustomerNumber);
                    }

                }

                else
                {
                    statstrpCustomer.Items[0].Text = "There are no customer records";
                }

            }

            catch (Exception ex)
            {
                string Err = ex.Message + " ;Source = " + ex.Source;
                imCust = null;
            }

            finally
            {
                imCust = null;

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
                        lCurrentBuildingNumber = imBuildingMaster.BuildingID;

                        if (imBuildingMaster.BuildingID > 0)
                        {

                            if (imBuildingMaster.BuildingName != null)
                            {
                                txtBuildingName.Text = imBuildingMaster.BuildingName.ToString();
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

        private void LoadPrivateCustomer(long lArgCustomerNo)
        {

            TRIP_API.IMPrivateCustomer imPrivCust = new TRIP_API.IMPrivateCustomer();
            TRIP_API.IMBuildingMaster imBuildingMaster;

            if (sfMap1.ShapeFileCount > 0)
            {
                //check if buildinghshapefile is present
                if (FindShapeFile("rtk.shp") == true)
                {
                    buildingshapefile.ClearSelectedRecords();
                }

                sfMap1.Refresh(true);

            }
            

            AddRemovePrivateCustomerTab(1);

            try
            {
                imPrivCust.CustomerNo = lArgCustomerNo;
                imPrivCust.ReturnPrivateCustomerMasterByCustomerNumber(1, 0, 0, true);

                if (imPrivCust.CustomerNo > 0)
                {
                    lCurrentCustomerNumber = lArgCustomerNo;
                    lCurrentAddressID = imPrivCust.AddressDetailsID;
                    lCurrentBuildingNumber = imPrivCust.AddressDetailsBuildingID;
                    lCurrentMapID = imPrivCust.AddressDetailsMapID;
                    txtCustomerEmailAddress.Text = imPrivCust.EmailAddress.ToUpper();

                    if (imPrivCust.CountryOfBirthID > 0)
                    {
                        cmbCustomerCountryOfBirth.SelectedValue = Convert.ToString(imPrivCust.CountryOfBirthID);
                    }

                    txtCustomerAccount.Text = imPrivCust.CustomerSerialNumber.ToUpper();

                    txtCustomerPINNumber.Text = imPrivCust.CustomerPINNumber.ToUpper();

                    if (imPrivCust.DateOfBirth.Date > dtCustomerDateOfBirth.MinDate)
                    {
                        dtCustomerDateOfBirth.Value = imPrivCust.DateOfBirth;
                    }

                    if (imPrivCust.DateCreated.Date > dtpckCustomerDateCreated.MinDate)
                    {
                        dtpckCustomerDateCreated.Value = imPrivCust.DateCreated;
                    }

                    if (imPrivCust.DateRegistered.Date > dtpckCustomerDateRegistered.MinDate)
                    {
                        dtpckCustomerDateRegistered.Value = imPrivCust.DateRegistered;
                    }

                    if (imPrivCust.DateDeRegistered.Date > dtpckCustomerDateDeleted.MinDate)
                    {
                        dtpckCustomerDateDeleted.Value = imPrivCust.DateDeRegistered;
                    }

                    txtPrivateCustomerFirstName.Text = imPrivCust.FirstName.ToUpper();
                    txtPrivateCustomerMiddleName.Text = imPrivCust.MiddleName.ToUpper();
                    txtPrivateCustomerSurname.Text = imPrivCust.Surname.ToUpper();
                    txtPrivateCustomerOtherName.Text = imPrivCust.OtherName.ToUpper();

                    txtCustomerName.Text =
                        imPrivCust.FirstName.ToUpper() + " " +
                        imPrivCust.MiddleName.ToUpper() + " " +
                        imPrivCust.Surname.ToUpper() + " " +
                        imPrivCust.OtherName.ToUpper();

                    statstrpCustomer.Items[2].Text =
                        imPrivCust.FirstName.ToUpper() + " " +
                        imPrivCust.MiddleName.ToUpper() + " " +
                        imPrivCust.Surname.ToUpper() + " " +
                        imPrivCust.OtherName.ToUpper();


                    if (imPrivCust.Sex > 0)
                    {
                        cmbPrivateCustomerSex.SelectedValue = Convert.ToString(imPrivCust.Sex);
                    }

                    cmbPrivateCustomerTitle.Text = imPrivCust.Title;

                    //contact details
                    txtContactDetailsLandLineNumber1.Text = imPrivCust.AddressDetailsTelephone1;
                    txtContactDetailsLandLineNumber2.Text = imPrivCust.AddressDetailsTelephone2;

                    txtContactDetailsMobileNumber1.Text = imPrivCust.AddressDetailsMobilePhone1;
                    txtContactDetailsMobileNumber2.Text = imPrivCust.AddressDetailsMobilePhone2;

                    txtContactDetailsMainEmailAddress.Text = imPrivCust.AddressDetailsCompanyEmail;
                    txtContactDetailsSalesEmailAddress.Text = imPrivCust.AddressDetailsSalesEmail;

                    txtContactDetailsFax1.Text = imPrivCust.AddressDetailsFax1;
                    txtContactDetailsFax2.Text = imPrivCust.AddressDetailsFax2;
                    txtContactDetailsPostalAddress.Text = imPrivCust.AddressDetailsPostalAddress;
                    cmbContactDetailsPostalCode.SelectedValue = imPrivCust.AddressDetailsPostalCode;


                    //physical address
                    cmbPhysicalAddressCustomerCountry.SelectedValue = imPrivCust.AddressDetailsCountryID;
                    cmbPhysicalAddressCustomerCity.SelectedValue = imPrivCust.AddressDetailsCityID;
                    cmbPhysicalAddressCustomerProvince.SelectedValue = imPrivCust.AddressDetailsProvinceID;
                    cmbPhysicalAddressCustomerDistrict.SelectedValue = imPrivCust.AddressDetailsDistrictID;
                    cmbPhysicalAddressCustomerDivision.SelectedValue = imPrivCust.AddressDetailsDivisionID;
                    cmbPhysicalAddressCustomerLocation.SelectedValue = imPrivCust.AddressDetailsLocationID;
                    cmbPhysicalAddressCustomerSubLocation.SelectedValue = imPrivCust.AddressDetailsSublocationID;
                    imPrivCust.AddressDetailsOwnerTypeID = 2;

                    if (imPrivCust.AddressDetailsBuildingID > 0)
                    {
                        imBuildingMaster = new TRIP_API.IMBuildingMaster();
                        imBuildingMaster.BuildingID = imPrivCust.AddressDetailsBuildingID;
                        imBuildingMaster.ReturnBuildingIDAndUsageNameByBuildingID(0, 0);

                        if (imBuildingMaster.BuildingName != "")
                        {
                            txtBuildingName.Text = imBuildingMaster.BuildingName.Trim();
                        }

                        imBuildingMaster.BuildingID = imPrivCust.AddressDetailsBuildingID;
                        imBuildingMaster.ReturnMapIDByBuildingID();

                        if (imBuildingMaster.MapID > 0)
                        {
                            ZoomToBuilding(imBuildingMaster.MapID);
                        }

                    }


                    //login details
                    txtUserLoginName.Text = imPrivCust.UserName;

                    txtPhysicalAddressUniversalAddress.Text = imPrivCust.AddressDetailsUniversalAddress;

                    if (imPrivCust.PhysicalAddressCoordinate != null)
                    {
                        if (imPrivCust.PhysicalAddressCoordinate.X != 0.0f &&
                            imPrivCust.PhysicalAddressCoordinate.Y != 0.0f)
                        {
                            txtPhysicalAddressCustomerPOI.Text = imPrivCust.PhysicalAddressCoordinate.X +
                                "," + imPrivCust.PhysicalAddressCoordinate.Y;

                            currentMarkerPosition = new Tripodmaps.Reader.PointD(
                                Convert.ToDouble(imPrivCust.PhysicalAddressCoordinate.X),
                                Convert.ToDouble(imPrivCust.PhysicalAddressCoordinate.Y));

                            sfMap1.CentrePoint2D = currentMarkerPosition;
                        }
                    }
                    
                    //sfMap1.Refresh();

                }

                else
                {
                    statstrpCustomer.Items[0].Text = "There are no customer records";
                }
            }

            catch (Exception ex)
            {
                string Err = ex.Message + " ;Source = " + ex.Source;
            }

            finally
            {
                imPrivCust = null;
                imBuildingMaster = null;
                imPrivCust = null;
            }

        }

        private void LoadOrganizationCustomer(long lArgCustomerNo)
        {
            AddRemoveOrganizationCustomerTab(1);
            TRIP_API.IMOrganizationCustomer imOrgCust = new TRIP_API.IMOrganizationCustomer();

            try
            {
                imOrgCust.CustomerNo = lArgCustomerNo;
                imOrgCust.ReturnOrganizationCustomerMasterByCustomerNumber(0, 0, 0, true);

                if (imOrgCust.CustomerNo > 0)
                {
                    lCurrentCustomerNumber = imOrgCust.CustomerNo;
                    txtCustomerAccount.Text = imOrgCust.CustomerSerialNumber.ToUpper();
                    txtCustomerEmailAddress.Text = imOrgCust.EmailAddress.ToUpper();
                    txtCustomerName.Text = imOrgCust.OrganizationName;

                    if (imOrgCust.CountryOfBirthID > 0)
                    {
                        cmbCustomerCountryOfBirth.SelectedValue = Convert.ToString(imOrgCust.CountryOfBirthID);
                    }

                    txtCustomerPINNumber.Text = imOrgCust.CustomerPINNumber.ToUpper();

                    if (imOrgCust.DateOfBirth.Date > dtCustomerDateOfBirth.MinDate)
                    {
                        dtCustomerDateOfBirth.Value = imOrgCust.DateOfBirth;
                    }

                    if (imOrgCust.DateCreated.Date > dtpckCustomerDateCreated.MinDate)
                    {
                        dtpckCustomerDateCreated.Value = imOrgCust.DateCreated;
                    }

                    if (imOrgCust.DateRegistered.Date > dtpckCustomerDateRegistered.MinDate)
                    {
                        dtpckCustomerDateRegistered.Value = imOrgCust.DateRegistered;
                    }

                    if (imOrgCust.DateDeRegistered.Date > dtpckCustomerDateDeleted.MinDate)
                    {
                        dtpckCustomerDateDeleted.Value = imOrgCust.DateDeRegistered;
                    }

                    txtOrganizationName.Text = imOrgCust.OrganizationName.ToUpper();
                    txtOrganizationRegistrationNo.Text = imOrgCust.CompanyRegistrationNo.ToUpper();
                    txtOrganizationVATNo.Text = imOrgCust.VATNumber.ToUpper();

                    statstrpCustomer.Items[2].Text = imOrgCust.OrganizationName.ToUpper();

                    if (imOrgCust.CompanyTypeID > 0)
                    {
                        cmbOrganizationType.SelectedValue = Convert.ToString(imOrgCust.CompanyTypeID);
                    }

                    //contact details
                    txtContactDetailsLandLineNumber1.Text = imOrgCust.AddressDetailsTelephone1;
                    txtContactDetailsLandLineNumber2.Text = imOrgCust.AddressDetailsTelephone2;

                    txtContactDetailsMobileNumber1.Text = imOrgCust.AddressDetailsMobilePhone1;
                    txtContactDetailsMobileNumber2.Text = imOrgCust.AddressDetailsMobilePhone2;

                    txtContactDetailsMainEmailAddress.Text = imOrgCust.AddressDetailsCompanyEmail;
                    txtContactDetailsSalesEmailAddress.Text = imOrgCust.AddressDetailsSalesEmail;

                    txtContactDetailsFax1.Text = imOrgCust.AddressDetailsFax1;
                    txtContactDetailsFax2.Text = imOrgCust.AddressDetailsFax2;
                    txtContactDetailsPostalAddress.Text = imOrgCust.AddressDetailsPostalAddress;
                    cmbContactDetailsPostalCode.SelectedValue = imOrgCust.AddressDetailsPostalCode;


                    //physical address
                    cmbPhysicalAddressCustomerCountry.SelectedValue = imOrgCust.AddressDetailsCountryID;
                    cmbPhysicalAddressCustomerCity.SelectedValue = imOrgCust.AddressDetailsCityID;
                    cmbPhysicalAddressCustomerProvince.SelectedValue = imOrgCust.AddressDetailsProvinceID;
                    cmbPhysicalAddressCustomerDistrict.SelectedValue = imOrgCust.AddressDetailsDistrictID;
                    cmbPhysicalAddressCustomerDivision.SelectedValue = imOrgCust.AddressDetailsDivisionID;
                    cmbPhysicalAddressCustomerLocation.SelectedValue = imOrgCust.AddressDetailsLocationID;
                    cmbPhysicalAddressCustomerSubLocation.SelectedValue = imOrgCust.AddressDetailsSublocationID;
                    txtPhysicalAddressCustomerPOI.Text = "X= " + imOrgCust.PhysicalAddressCoordinate.X +
                        ": Y= " + imOrgCust.PhysicalAddressCoordinate.Y;
                    txtPhysicalAddressUniversalAddress.Text = imOrgCust.AddressDetailsUniversalAddress;



                }
                else
                {
                    statstrpCustomer.Items[0].Text = "There are no customer records";
                }


            }
            catch (Exception ex)
            {
                string Err = ex.Message + " ;Source = " + ex.Source;
                imOrgCust = null;
            }

            finally
            {
                imOrgCust = null;

            }

        }

        private void LoadBasemapPOI()
        {

        }

        private void LoadCurrencies(long lArgDefaultCountryID)
        {
            try
            {
                TRIP_API.IMCountries imCountries = new TRIP_API.IMCountries();

                imCountries.RetrieveCurrencyNameCodeCountryNameCountryIDList();
                cmbCustomerDefaultCurrency.Items.Clear();


                if (imCountries.CountryDataset != null)
                {

                    cmbCustomerDefaultCurrency.DataSource = imCountries.CountryDataset.Tables[0];
                    cmbCustomerDefaultCurrency.DisplayMember = "CURRENCYLIST";
                    cmbCustomerDefaultCurrency.ValueMember = "COUNTRYID";

                }

                if (lArgDefaultCountryID > 0)
                {
                    cmbCustomerDefaultCurrency.SelectedValue = lArgDefaultCountryID;
                }

                imCountries = null;

            }

            catch (Exception ex)
            {
                string err = ex.Message + " Source=" + ex.Source;
            }

            finally
            {

            }
        }

        private void LoadPlaceNames()
        {

        }

        private class Item
        {
            public string Name;
            public int Value;
            public Item(string name, int value)
            {
                Name = name; Value = value;
            }
            public override string ToString()
            {
                // Generates the text shown in the combo box
                return Name;
            }
        }

        private void LoadCountries(long lArgDefaultCountryID)
        {
            TRIP_API.IMCountries imCountries = new TRIP_API.IMCountries();

            try
            {

                imCountries.RetrieveCountryIDAndNameByCountryName(0, 0, 0);
                cmbCustomerCountryOfCitizenship.Items.Clear();
                cmbCustomerCountryOfBirth.Items.Clear();
                cmbPhysicalAddressCustomerCountry.Items.Clear();


                if (imCountries.CountryDataset != null)
                {

                    cmbCustomerCountryOfCitizenship.DataSource = imCountries.CountryDataset.Tables[0];
                    cmbCustomerCountryOfCitizenship.DisplayMember = "COUNTRYNAME";
                    cmbCustomerCountryOfCitizenship.ValueMember = "COUNTRYID";

                    cmbCustomerCountryOfBirth.DataSource = imCountries.CountryDataset.Tables[0];
                    cmbCustomerCountryOfBirth.DisplayMember = "COUNTRYNAME";
                    cmbCustomerCountryOfBirth.ValueMember = "COUNTRYID";

                    cmbPhysicalAddressCustomerCountry.DataSource = imCountries.CountryDataset.Tables[0];
                    cmbPhysicalAddressCustomerCountry.DisplayMember = "COUNTRYNAME";
                    cmbPhysicalAddressCustomerCountry.ValueMember = "COUNTRYID";

                }

                if (lArgDefaultCountryID > 0)
                {
                    cmbCustomerCountryOfCitizenship.SelectedValue = lArgDefaultCountryID;
                    cmbCustomerCountryOfBirth.SelectedValue = lArgDefaultCountryID;
                    cmbPhysicalAddressCustomerCountry.SelectedValue = lArgDefaultCountryID;
                }



            }

            catch (Exception ex)
            {
                string err = ex.Message + " Source=" + ex.Source;
            }

            finally
            {

                imCountries = null;
            }



        }

        private void LoadCities(long lArgCountryID, long lArgDefaultCityID)
        {

        }

        private void LoadProvinces(long lArgCountryID, long lArgDefaultProvinceID)
        {

        }

        private void LoadDistricts(long lArgCountryID, long lArgProvinceID, long lArgDefaultDistrictID)
        {

        }

        private void LoadDivisions(long lArgCountryID, long lArgProvinceID, long lArgDistrictID, long lArgDefaultDivisionID)
        {

        }

        private void LoadLocations(long lArgCountryID, long lArgProvinceID, long lArgDistrictID,
            long lArgDivisionID, long lArgDefaultLocationID)
        {

        }

        private void LoadSubLocations(long lArgCountryID, long lArgProvinceID, long lArgDistrictID,
            long lArgDivisionID, long lArgLocationID, long lArgDefaultSubLocationID)
        {

        }

        private void LoadCounties(long lArgCountryID, long lArgDefaultCountryID)
        {

        }

        private void cmbCustomerPriority_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tlstrpbtnFirst_Click(object sender, EventArgs e)
        {
            frmAjaxLoading ajLoader = null;            
            

            try
            {
                ajLoader = new frmAjaxLoading();
                ajLoader.Show();
                ajLoader.Update();

                LoadFirstCustomer();
            }

            finally
            {
                ajLoader.Close();
                ajLoader = null;
            }
        }

        private void tlstrpbtnPrevious_Click(object sender, EventArgs e)
        {
            frmAjaxLoading ajLoader = null;


            try
            {
                ajLoader = new frmAjaxLoading();
                ajLoader.Show();
                ajLoader.Update();

                LoadPreviousCustomer();
            }

            finally
            {
                ajLoader.Close();
                ajLoader = null;
            }
        }

        private void tlstrpbtnNext_Click(object sender, EventArgs e)
        {

            frmAjaxLoading ajLoader = null;

            try
            {
                
                ajLoader = new frmAjaxLoading();
                ajLoader.Show();
                ajLoader.Update();

                LoadNextCustomer();
            }

            finally
            {
                ajLoader.Close();
                ajLoader = null;
            }
        }

        private void tlstrpbtnLast_Click(object sender, EventArgs e)
        {
            frmAjaxLoading ajLoader = null;

            try
            {
                ajLoader = new frmAjaxLoading();
                ajLoader.Show();
                ajLoader.Update();

                LoadLastCustomer();
            }

            finally
            {
                ajLoader.Close();
                ajLoader = null;
            }
        }

        private void cmbTitle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtMobileNumber2_TextChanged(object sender, EventArgs e)
        {

        }

        private void grpCustomerContactDetails_Enter(object sender, EventArgs e)
        {

        }

        private void cmdPrivateCustomerSave_Click(object sender, EventArgs e)
        {
            frmAjaxLoading ajaxLoader = null;

            try
            {
                ajaxLoader = new frmAjaxLoading();
                ajaxLoader.Show();

                SavePrivateCustomer();

            }

            finally
            {
                ajaxLoader.Close();
                ajaxLoader = null;

            }

        }

        private void tlstrpbtnSave_Click(object sender, EventArgs e)
        {
            if (tabPrivateCustomerTab != null)
            {
                SavePrivateCustomer();
            }
            else if (tabOrganizationCustomer != null)
            {
                SaveOrganizationCustomer();
            }

        }

        private void sfMap1_Load(object sender, EventArgs e)
        {

        }

        private void cmdPhysicalAddressSave_Click(object sender, EventArgs e)
        {

        }


        private void frmCustomer_FormClosing(Object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms.Count > 1)
            {
                MainForm frmMain = (MainForm)Application.OpenForms["MainForm"];
                frmMain.CloseCustForm();
            }
        }

    }
}
