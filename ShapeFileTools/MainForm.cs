
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
using NpgsqlTypes;
using System.Diagnostics;
using UIComponents;


namespace Tripodmaps
{
    public partial class MainForm : Form
    {
        enum ProjectState { NewProject, UnsavedNewProject, OpenProject, UnsavedOpenProject };

        private ProjectState projectStatus = ProjectState.NewProject;
        private string currentProjectPath = null;
        private string errMessage = "";
        private long lDirection = 0;
        private long lOffset = 0;

        Tripodmaps.Reader.ShapeFile[] shapefiles;
        Tripodmaps.Reader.ShapeFile buildingshapefile;
        Tripodmaps.Reader.ShapeFile landparcelshapefile;
        Tripodmaps.Reader.ShapeFile pointshapefile;
        private Tripodmaps.Reader.PointD currentMarkerPosition = new Tripodmaps.Reader.PointD(0, 0);
        private const int MarkerWidth = 10;

        private RecordAttributesForm recordAttributesForm;
        private frmCustomers CustForm;
        private frmAssetTypes AssetTypesForm;
        private frmUsageMaster UsagesForm;
        private frmBuildings BuildingForm;
        private frmPointTypesMaster PointTypesMasterForm;
        private frmRoomTypeMaster RoomTypeMasterForm;
        private frmRoomAmenityTypes RoomAmenityTypesForm;
        private frmBuildingTypes BuildingTypesForm;
        private frmDocumentTypes DocumentTypesForm;
        private frmDocuments DocumentsForm;
        private frmAddressDetails AddressDetails;
        private frmFind FindDetails;
        private frmPropertyFinder frmPropertyFinder;

        private Bitmap blank;
        private Bitmap x;
        private Bitmap o;
        private int bitmapPadding = 6;



        public void CloseCustForm()
        {
            CustForm = null;
        }

        public void CloseBuildingForm()
        {
            BuildingForm = null;
        }

        public void CloseFindForm()
        {
            FindDetails = null;
        }

        public void ClosePropertyFinderForm()
        {
            frmPropertyFinder = null;
        }

        public void CloseAddressDetailsForm()
        {
            AddressDetails = null;
        }

        public void CloseDocumentsForm()
        {
            DocumentsForm = null;
        }

        public MainForm(string strLoadDefaultProjectPath)
        {
            try
            {

                InitializeComponent();

                Tripodmaps.Reader.ShapeFile.UseMercatorProjection = false;
                this.miMercatorProjection.Checked = Tripodmaps.Reader.ShapeFile.UseMercatorProjection;
                this.useNativeFileMappingToolStripMenuItem.Checked = Tripodmaps.Reader.ShapeFile.MapFilesInMemory;

                //recordAttributesForm = new RecordAttributesForm();
                //recordAttributesForm.Show(this);
                //recordAttributesForm.Owner = this;
                //recordAttributesForm.VisibleChanged += new EventHandler(recordAttributesForm_VisibleChanged);S

                if (!string.IsNullOrEmpty(strLoadDefaultProjectPath))
                {
                    OpenProject(strLoadDefaultProjectPath);
                }

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                FindParcelShapeFile("Plots.shp");
                FindBuildingShapeFile("rtk.shp");
                FindPointsShapeFile("pointsofinterest.shp");
                //LoadPropertyFinderForm();
            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;

            }

            finally
            {

            }

        }

        private void CheckLicence()
        {
            if (!Tripodmaps.Properties.Settings.Default.LicenceAccepted)
            {
                Licence laf = new Licence();
                try
                {
                    if (laf.ShowDialog() == DialogResult.Yes)
                    {
                        Tripodmaps.Properties.Settings.Default.LicenceAccepted = true;
                        Tripodmaps.Properties.Settings.Default.Save();
                    }
                    else
                    {
                        Close();
                    }
                }
                finally
                {
                    laf.Dispose();
                }
            }
        }


        #region "GIS"

        private void miOpenShapeFile_Click(object sender, EventArgs e)
        {
            this.OpenShapeFile();
        }

        private void OpenShapeFile()
        {
            if (ofdShapeFile.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    //OpenShapeFile(ofdShapeFile.FileName);
                    foreach (string file in ofdShapeFile.FileNames)
                    {
                        OpenShapeFile(file);
                    }
                    /*
                    int tzl = TileUtil.ScaleToZoomLevel(sfMap1.ZoomLevel);
                    if (tzl >= 0)
                    {
                        sfMap1.ZoomLevel = TileUtil.ZoomLevelToScale(tzl);
                    }
                    else
                    {
                        //not using lat long 
                    }
                     **/
                }
                catch (Exception ex)
                {
                    Log(ex.ToString());
                    MessageBox.Show(this, "Unable to open or access the data files.\nPlease check if they meet access requirements" + ex.Message, "Error opening data files", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Log(string msg)
        {
            //this.rtbStatus.AppendText(DateTime.Now.ToString() + ": " + msg + "\n");
            System.Diagnostics.Debug.WriteLine(DateTime.Now.ToString() + ": " + msg + "\n");
        }

        /// <summary>
        /// Opens the specified shapefile
        /// </summary>
        /// <param name="path">path to the shapefile to be opened</param>
        public void OpenShapeFile(string path)
        {
            string name = path.Substring(path.LastIndexOf("\\") + 1);
            Tripodmaps.Reader.ShapeFile sf = sfMap1.AddShapeFile(path, name, "NAME");
            //RectangleF r = sfMap1.Extent;
            //sf.RenderSettings.MinRenderLabelZoom = 25.0f * 512f / r.Width;
            //this.shapeFileRenderPropertyGrid.SelectedObject = sf.RenderSettings;
        }

        #region "Pan and Zoom methods"


        private void PanLeft()
        {
            RectangleF r = sfMap1.Extent;
            PointD pt = sfMap1.CentrePoint2D;
            pt.X -= (sfMap1.ClientSize.Width >> 2) / sfMap1.ZoomLevel; ;// (0.0025f * r.Width);
            sfMap1.CentrePoint2D = pt;
        }

        private void PanRight()
        {
            RectangleF r = sfMap1.Extent;
            PointD pt = sfMap1.CentrePoint2D;
            pt.X += (sfMap1.ClientSize.Width >> 2) / sfMap1.ZoomLevel;// (0.0025f * r.Width);
            sfMap1.CentrePoint2D = pt;
        }

        private void PanUp()
        {
            RectangleF r = sfMap1.Extent;
            PointD pt = sfMap1.CentrePoint2D;
            pt.Y += (sfMap1.ClientSize.Height >> 2) / sfMap1.ZoomLevel; //(0.0025f * r.Height);
            sfMap1.CentrePoint2D = pt;
        }

        private void PanDown()
        {
            RectangleF r = sfMap1.Extent;
            PointD pt = sfMap1.CentrePoint2D;
            pt.Y -= (sfMap1.ClientSize.Height >> 2) / sfMap1.ZoomLevel;
            sfMap1.CentrePoint2D = pt;
        }

        private void ZoomIn()
        {
            double z = sfMap1.ZoomLevel;
            sfMap1.ZoomLevel = z * 2d;
        }

        private void ZoomOut()
        {
            double z = sfMap1.ZoomLevel;
            sfMap1.ZoomLevel = z / 2d;
        }

        private void ZoomFull()
        {
            sfMap1.ZoomToFullExtent();

        }


        #endregion

        private void shapeFileListControl1_SelectedShapeFileChanged(object sender, EventArgs args)
        {
            //shapeFileRenderPropertyGrid.SelectedObject = shapeFileListControl1.SelectedShapeFile.RenderSettings;
            //LoadFindTextAutoCompleteData(shapeFileListControl1.SelectedShapeFile);
        }

        private void LoadFindTextAutoCompleteData(Tripodmaps.Reader.ShapeFile shapeFile)
        {
            LoadFindTextAutoCompleteData(shapeFile, true);
        }

        private void LoadFindTextAutoCompleteData(Tripodmaps.Reader.ShapeFile shapeFile, bool clearExisting)
        {
            if (clearExisting) this.txtFindValue.AutoCompleteCustomSource.Clear();
            if (shapeFile == null || shapeFile.RenderSettings == null) return;
            if (shapeFile.RenderSettings.FieldIndex >= 0 && shapeFile.RenderSettings.IsSelectable)
            {
                string[] records = shapeFile.GetRecords(shapeFile.RenderSettings.FieldIndex);
                this.txtFindValue.AutoCompleteCustomSource.AddRange(records);
            }
        }

        private void LoadFindTextAutoCompleteDataFromAllLayers()
        {
            this.txtFindValue.AutoCompleteCustomSource.Clear();
            for (int n = this.sfMap1.ShapeFileCount - 1; n >= 0; n--)
            {
                LoadFindTextAutoCompleteData(sfMap1[n], false);
            }
        }

        private void shapeFileRenderPropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            this.sfMap1.Refresh(true);
            ProjectChanged();
        }


        #region "Project Open/Save methods"


        private void GeuzaFili()
        {
            TRIP_API.IMLogin tripGeuza;

            try
            {
                tripGeuza = new TRIP_API.IMLogin();
                string strFili = "";

                opnfldlgBuildings = new OpenFileDialog();
                opnfldlgBuildings.ShowDialog(this);
                strFili = opnfldlgBuildings.FileName;

                if (File.Exists(strFili))
                {
                    if (Path.GetExtension(strFili) == ".shp")
                    {
                        tripGeuza.CurrentPassword = "KroaprO1";
                        tripGeuza.GeuzaFili(strFili, Application.StartupPath + "\\" + strFili);
                    }
                    else
                    {
                        tripGeuza.CurrentPassword = "jackson1";
                        tripGeuza.GeuzaFili(strFili, Application.StartupPath + "\\" + "Main.trip");
                    }
                }

            }

            catch (Exception ex)
            {
                errMessage = ex.Message;
            }

            finally
            {
                tripGeuza = null;
            }

        }

        private void NewProject()
        {
            DialogResult dr = MessageBox.Show(this, "The current project will be closed.\nDo you wish to save your changes before creating a new project?", "Save Project?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.Cancel) return;
            if (dr == DialogResult.Yes)
            {
                if (projectStatus == ProjectState.UnsavedNewProject || projectStatus == ProjectState.UnsavedOpenProject)
                {
                    this.SaveProject(this.currentProjectPath);
                }
            }
            sfMap1.ClearShapeFiles();
            this.currentProjectPath = null;
            this.projectStatus = ProjectState.NewProject;
            this.Text = "Easy GIS .NET Desktop Edition";
            System.GC.Collect();

        }

        private void WriteProject(string path)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;

            XmlWriter writer = XmlWriter.Create(path, settings);
            try
            {
                // Write the project element.
                writer.WriteStartElement("sfproject");
                writer.WriteAttributeString("version", "1.0");
                sfMap1.WriteXml(writer);
                // Write the close tag for the root element.
                writer.WriteEndElement();
            }
            finally
            {
                // Write the XML and close the writer.
                writer.Close();
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

                sfMap1.ZoomLevel = 346370.32554;

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

        private void OpenProject()
        {
            if (projectStatus == ProjectState.UnsavedNewProject || projectStatus == ProjectState.UnsavedOpenProject)
            {
                DialogResult dr = MessageBox.Show(this, "The current project will be closed.\nDo you wish to save your changes before opening a new project?", "Save Project?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Cancel) return;
                if (dr == DialogResult.Yes)
                {
                    this.SaveProject(this.currentProjectPath);
                }
            }

            if (this.ofdProject.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    ReadProject(ofdProject.FileName);
                    this.projectStatus = ProjectState.OpenProject;
                    this.currentProjectPath = ofdProject.FileName;
                    AddToRecentProjects(currentProjectPath);
                    this.Text = "Tripodmaps - Tripodsystems";


                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error reading project :" + ex.ToString());
                    MessageBox.Show(this, "Error opening project\n" + ex.Message, "Error opening project",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private ShapeFile FindShapeFile(string strArgShapeFileName)
        {

            try
            {
                if (sfMap1 == null)
                {
                    return null;
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
                                ShapeFile shpToReturn;
                                shpToReturn = shpSearch;
                                return shpToReturn;
                            }
                        }
                    }

                    return null;


                }
                else
                {
                    return null;
                }

            }

            catch (Exception ex)
            {
                errMessage = ex.Message;
                return null;
            }

            finally
            {

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

                ReadProject(projectPath);
                this.projectStatus = ProjectState.OpenProject;
                this.currentProjectPath = projectPath;
                //AddToRecentProjects(currentProjectPath);
                this.Text = "Tripodmaps - Tripodsystems";

                //sfMap1.Refresh();
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

        private void ProjectChanged()
        {
            if (this.projectStatus == ProjectState.OpenProject)
            {
                this.projectStatus = ProjectState.UnsavedOpenProject;
            }
            else if (projectStatus == ProjectState.NewProject)
            {
                this.projectStatus = ProjectState.UnsavedNewProject;
            }
        }

        private void SaveProject()
        {
            SaveProject(this.currentProjectPath);
        }

        private void SaveProject(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                try
                {
                    WriteProject(path);
                    projectStatus = ProjectState.OpenProject;
                    currentProjectPath = path;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error writing project :" + ex.ToString());
                    MessageBox.Show(this, "Error saving project\n" + ex.Message, "Error saving project", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (this.sfdProject.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        WriteProject(sfdProject.FileName);
                        projectStatus = ProjectState.OpenProject;
                        currentProjectPath = sfdProject.FileName;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("Error writing project :" + ex.ToString());
                        MessageBox.Show(this, "Error saving project\n" + ex.Message, "Error saving project", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void ExportProject()
        {

            if (projectStatus == ProjectState.UnsavedNewProject || projectStatus == ProjectState.UnsavedOpenProject)
            {
                DialogResult dr = MessageBox.Show(this, "Do you wish to save your changes before exporting the project?", "Save Project?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Cancel) return;
                if (dr == DialogResult.Yes)
                {
                    this.SaveProject(this.currentProjectPath);
                }
            }
            if (currentProjectPath == null) return;

            if (this.sfdProject.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    string subDir = System.IO.Path.GetFileNameWithoutExtension(sfdProject.FileName) + "_files";
                    string absSubDir = System.IO.Path.GetDirectoryName(sfdProject.FileName) + "\\" + subDir;
                    if (!System.IO.Directory.Exists(absSubDir))
                    {
                        System.IO.Directory.CreateDirectory(absSubDir);
                    }
                    XmlDocument projDoc = new XmlDocument();
                    projDoc.Load(this.currentProjectPath);
                    XmlNodeList shapeNodes = projDoc.GetElementsByTagName("shapefile");
                    if (shapeNodes != null && shapeNodes.Count > 0)
                    {

                        for (int n = 0; n < shapeNodes.Count; n++)
                        {
                            XmlElement shapeElement = shapeNodes[n] as XmlElement;
                            string shapePath = shapeElement.GetElementsByTagName("path")[0].InnerText;
                            string shapeFilename = System.IO.Path.GetFileName(shapePath);
                            if (!System.IO.Path.IsPathRooted(shapePath))
                            {
                                shapePath = System.IO.Path.GetDirectoryName(this.currentProjectPath) + "/" + shapePath;
                            }

                            //copy the .shpx and dbf files, then update the path in the shapeElement
                            //if (!System.IO.File.Exists(absSubDir + "\\" + shapeFilename + ".shpx"))
                            //{
                            //    System.IO.File.Copy(shapePath + ".shpx", absSubDir + "\\" + shapeFilename + ".shpx");
                            //}
                            if (!System.IO.File.Exists(absSubDir + "\\" + shapeFilename + ".shp"))
                            {
                                System.IO.File.Copy(shapePath + ".shp", absSubDir + "\\" + shapeFilename + ".shp");
                            }
                            if (!System.IO.File.Exists(absSubDir + "\\" + shapeFilename + ".shx"))
                            {
                                System.IO.File.Copy(shapePath + ".shx", absSubDir + "\\" + shapeFilename + ".shx");
                            }
                            if (!System.IO.File.Exists(absSubDir + "\\" + shapeFilename + ".dbf"))
                            {
                                System.IO.File.Copy(shapePath + ".dbf", absSubDir + "\\" + shapeFilename + ".dbf", false);
                            }
                            shapeElement.GetElementsByTagName("path")[0].InnerText = subDir + "/" + shapeFilename;
                        }
                    }

                    XmlNodeList imageNodes = projDoc.GetElementsByTagName("PointImageSymbol");
                    if (imageNodes != null && imageNodes.Count > 0)
                    {

                        for (int n = 0; n < imageNodes.Count; n++)
                        {
                            XmlElement imgElement = imageNodes[n] as XmlElement;
                            string imagePath = imgElement.InnerText;
                            string imageFilename = System.IO.Path.GetFileName(imagePath);
                            if (!System.IO.Path.IsPathRooted(imagePath))
                            {
                                imagePath = System.IO.Path.GetDirectoryName(this.currentProjectPath) + "/" + imagePath;
                            }

                            //copy the .image file and then update the path in the image Element
                            if (!System.IO.File.Exists(absSubDir + "\\" + imageFilename))
                            {
                                System.IO.File.Copy(imagePath, absSubDir + "\\" + imageFilename);
                            }

                            imgElement.InnerText = subDir + "/" + imageFilename;
                        }
                    }

                    projDoc.Save(sfdProject.FileName);
                    MessageBox.Show(this, "Project Exported Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error exporting project :" + ex.ToString());
                    MessageBox.Show(this, "Error exporting project\n" + ex.Message, "Error exporting project", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }

        private void ProjectLoadStatus(int totalLayers, int layersLoaded)
        {
            if (mainProgressBar.Maximum != totalLayers) this.mainProgressBar.Maximum = totalLayers;
            this.mainProgressBar.Value = layersLoaded;
            this.mainProgressBar.Visible = (totalLayers != layersLoaded);
        }

        private const int MaxRecentProjects = 5;

        private void LoadRecentProjects()
        {
            if (Properties.Settings.Default.RecentProjects == null)
            {
                Properties.Settings.Default.RecentProjects = new System.Collections.Specialized.StringCollection();
                Properties.Settings.Default.Save();
                return;
            }
            recentProjectsMenuItem.DropDownItems.Clear();
            foreach (string s in Properties.Settings.Default.RecentProjects)
            {
                ToolStripMenuItem i = new ToolStripMenuItem(s);
                i.Click += new EventHandler(i_Click);
                recentProjectsMenuItem.DropDownItems.Add(i);
            }
        }

        void i_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null)
            {
                if (projectStatus == ProjectState.UnsavedNewProject || projectStatus == ProjectState.UnsavedOpenProject)
                {
                    DialogResult dr = MessageBox.Show(this, "The current project will be closed.\nDo you wish to save your changes before opening a new project?", "Save Project?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.Cancel) return;
                    if (dr == DialogResult.Yes)
                    {
                        this.SaveProject(this.currentProjectPath);
                    }
                }
                try
                {
                    ReadProject(item.Text);
                    this.projectStatus = ProjectState.OpenProject;
                    this.currentProjectPath = item.Text;
                    AddToRecentProjects(currentProjectPath);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error reading project :" + ex.ToString());
                    MessageBox.Show(this, "Error opening project " + item.Text + "\n" + ex.Message, "Error opening project", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddToRecentProjects(string path)
        {
            if (string.IsNullOrEmpty(path) || !System.IO.File.Exists(path)) return;

            try
            {
                int foundIndex = -1;
                for (int n = Properties.Settings.Default.RecentProjects.Count - 1; foundIndex <= 0 && n >= 0; n--)
                {
                    if (string.Compare(Properties.Settings.Default.RecentProjects[n], path, true) == 0)
                    {
                        foundIndex = n;
                    }
                }
                if (foundIndex >= 0)
                {
                    //adjust the project
                    Properties.Settings.Default.RecentProjects.RemoveAt(foundIndex);
                    Properties.Settings.Default.RecentProjects.Insert(0, path);
                }
                else
                {
                    Properties.Settings.Default.RecentProjects.Insert(0, path);
                    while (Properties.Settings.Default.RecentProjects.Count > MaxRecentProjects)
                    {
                        Properties.Settings.Default.RecentProjects.RemoveAt(Properties.Settings.Default.RecentProjects.Count - 1);
                    }
                }


            }
            finally
            {
                Properties.Settings.Default.Save();
                LoadRecentProjects();
            }


        }


        #endregion


        #region "DataCapture"

        private void CaptureBuildings()
        {
            DbfReader r = null;
            TRIP_API.IMBuildingMaster buildingAdd;

            try
            {

                string strFili = "";

                opnfldlgBuildings = new OpenFileDialog();
                opnfldlgBuildings.ShowDialog(this);
                strFili = opnfldlgBuildings.FileName;

                if (File.Exists(strFili))
                {
                    //get mapid (mapoid) and building name (name) from shapefile with building polygons
                    r = new DbfReader(System.IO.Path.ChangeExtension(strFili, ".dbf"));
                    string[] ray = r.GetFieldNames();

                    int intMapOIDIndex = Array.IndexOf(ray, "MAPOID");
                    int intNameIndex = Array.IndexOf(ray, "NAME");
                    {
                        string[,] strarrbldMapOID = r.GetRecordsTwoFields(intMapOIDIndex, intNameIndex);

                        if (strarrbldMapOID != null)
                        {
                            buildingAdd = new TRIP_API.IMBuildingMaster();


                            if (!(buildingAdd.MapID > 0))
                            {
                                for (int n = 0; n < strarrbldMapOID.GetLength(0); n++)
                                {
                                    if (strarrbldMapOID[n, 0] != null)
                                    {
                                        buildingAdd.BuildingName = "";
                                        buildingAdd.MapID = 0;

                                        buildingAdd.MapID = Convert.ToInt64(strarrbldMapOID[n, 0]);

                                        if (buildingAdd.MapID > 0)
                                        {
                                            if (buildingAdd.CheckIfMapIDExistsInDatabase() == false)
                                            {
                                                if (strarrbldMapOID[n, 1] != null)
                                                {
                                                    buildingAdd.BuildingName = strarrbldMapOID[n, 1].ToString();
                                                }

                                                buildingAdd.BuildingTypeID = 7;
                                                buildingAdd.BuildingUsage = 6;
                                                buildingAdd.DateConstructed = DateTime.Now;

                                                buildingAdd.SaveBuildingMasterMapOID();
                                            }

                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {
                if (r != null) r.Close();

            }

        }

        private void CapturePointsOfInterest()
        {
            DbfReader r = null;
            TRIP_API.IMAddress imAddressAdd = null; ;

            try
            {

                string strFili = "";

                opnfldlgBuildings = new OpenFileDialog();
                opnfldlgBuildings.ShowDialog(this);
                strFili = opnfldlgBuildings.FileName;

                if (File.Exists(strFili))
                {
                    //get mapid (mapoid) and pointofinterest name (name) from shapefile with building polygons
                    r = new DbfReader(System.IO.Path.ChangeExtension(strFili, ".dbf"));
                    string[] ray = r.GetFieldNames();

                    int intMapOIDIndex = Array.IndexOf(ray, "MAPOID");
                    int intNameIndex = Array.IndexOf(ray, "NAME");
                    int intXIndex = Array.IndexOf(ray, "X");
                    int intYIndex = Array.IndexOf(ray, "Y");
                    {
                        string[,] strarrPOIMapOID = r.GetRecordsFourFields(intMapOIDIndex, intNameIndex, intXIndex, intYIndex);

                        if (strarrPOIMapOID != null)
                        {
                            imAddressAdd = new TRIP_API.IMAddress();

                            for (int n = 0; n < strarrPOIMapOID.GetLength(0); n++)
                            {
                                if (strarrPOIMapOID[n, 0] != null)
                                {
                                    imAddressAdd.AddressDetailsPointName = "";
                                    imAddressAdd.AddressDetailsMapID = 0;

                                    imAddressAdd.AddressDetailsMapID = Convert.ToInt64(strarrPOIMapOID[n, 0]);

                                    if (imAddressAdd.AddressDetailsMapID > 0)
                                    {
                                        if (imAddressAdd.CheckIfMapIDExistsInDatabase() == false)
                                        {
                                            if (strarrPOIMapOID[n, 1] != null)
                                            {
                                                imAddressAdd.AddressDetailsPointName = strarrPOIMapOID[n, 1].ToString();
                                            }

                                            if (strarrPOIMapOID[n, 2] != null)
                                            {

                                                //Get the coordinates
                                                if (strarrPOIMapOID[n, 3] != null)
                                                {
                                                    NpgsqlPoint pnCoordinate = new NpgsqlPoint(
                                                        float.Parse(strarrPOIMapOID[n, 2]),
                                                        float.Parse(strarrPOIMapOID[n, 3]));

                                                    imAddressAdd.PhysicalAddressCoordinate = pnCoordinate;

                                                    PointD pt = new PointD(double.Parse(strarrPOIMapOID[n, 2]),
                                                        double.Parse(strarrPOIMapOID[n, 3]));

                                                    //Get the building id if the point encompasses a building id
                                                    imAddressAdd.AddressDetailsBuildingID = sfMap_ReturnBuildingIDAtPoint(pt);
                                                }
                                            }

                                            imAddressAdd.SaveAddressDetails();
                                        }
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
                if (r != null) r.Close();
                if (imAddressAdd != null)
                {
                    imAddressAdd = null;
                }
            }

        }

        #endregion


        private void miOpenProject_Click(object sender, EventArgs e)
        {
            OpenProject();
        }

        private void miSaveProject_Click(object sender, EventArgs e)
        {
            SaveProject();
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

        private long sfMap_ReturnParcelIDAtPoint(PointD pt)
        {
            try
            {
                int intMouseRecord = -1;

                if (sfMap1.ShapeFileCount > 0)
                {
                    intMouseRecord = sfMap1.LocateShapeIndexAtPoint(pt, "Plots.shp");

                    if (intMouseRecord >= 0)
                    {
                        long lBuildingID = ZoomToLandParcelImpartialIndex(intMouseRecord);
                        return lBuildingID;
                    }
                }

                return 0;

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " :Source = " + ex.Source;
                return 0;
            }

            finally
            {

            }


        }

        public long ZoomToLandParcelImpartialIndex(int lIndex)
        {
            TRIP_API.IMPlotMaster imPlotMaster = null;

            try
            {
                //if sfmap is not empty
                if (sfMap1.ShapeFileCount > 0)
                {
                    RectangleF bounds = landparcelshapefile.GetShapeBounds(lIndex);
                    if (bounds != RectangleF.Empty)
                    {
                        //shapeFileListControl1.SelectedShapeFile.SelectedRecordIndex = index;
                        landparcelshapefile.ClearSelectedRecords();
                        landparcelshapefile.SelectRecord(lIndex, true);
                        sfMap1.CentrePoint2D = new PointD((bounds.Left + bounds.Right) / 2,
                            (bounds.Top + bounds.Bottom) / 2);

                        string[] ar = landparcelshapefile.GetAttributeFieldNames();

                        if (ar != null)
                        {
                            int intMapOIDIndex = Array.IndexOf(ar, "MAPOID");

                            if (intMapOIDIndex >= 0)
                            {
                                string strSelectedMapIDValue = sfMap1.GetFieldValueOfSelectedIndex(landparcelshapefile,
                                    lIndex, intMapOIDIndex);

                                if (!string.IsNullOrEmpty(strSelectedMapIDValue))
                                {
                                    imPlotMaster = new TRIP_API.IMPlotMaster();
                                    imPlotMaster.MapID = Convert.ToInt64(strSelectedMapIDValue);

                                    if (imPlotMaster.ReturnPlotIDParcelNoByMapID(0, 0) == true)
                                    {
                                        return imPlotMaster.PlotID;
                                    }
                                }

                            }
                        }
                    }
                }

                return 0;
            }


            catch (Exception ex)
            {
                errMessage = ex.Message + " :Source = " + ex.Source;
                return 0;
            }

            finally
            {
                if (imPlotMaster != null)
                {
                    imPlotMaster = null;
                }
            }

        }

        private bool FindParcelShapeFile(string strArgShapeFileName)
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
                                landparcelshapefile = shpSearch;
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

        private bool FindPointsShapeFile(string strArgShapeFileName)
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
                                pointshapefile = shpSearch;
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

        public void ZoomToLandParcel(long lArgParcelMapID)
        {
            try
            {
                //if sfmap is not empty
                if (sfMap1.ShapeFileCount > 0)
                {
                    //check if buildinghshapefile is present
                    if (FindParcelShapeFile("Plots.shp") == true)
                    {
                        string[] ar = landparcelshapefile.GetAttributeFieldNames();

                        if (ar != null)
                        {
                            int intMapOIDIndex = Array.IndexOf(ar, "MAPOID");

                            if (intMapOIDIndex >= 0)
                            {
                                int index = landparcelshapefile.RenderSettings.DbfReader.IndexOf(lArgParcelMapID.ToString(),
                                    intMapOIDIndex, true);

                                if (index >= 0)
                                {
                                    RectangleF bounds = landparcelshapefile.GetShapeBounds(index);
                                    if (bounds != RectangleF.Empty)
                                    {
                                        //shapeFileListControl1.SelectedShapeFile.SelectedRecordIndex = index;
                                        landparcelshapefile.ClearSelectedRecords();
                                        landparcelshapefile.SelectRecord(index, true);
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

        private long sfMap_ReturnBuildingIDAtPoint(PointD pt)
        {
            try
            {
                int intMouseRecord = -1;

                if (sfMap1.ShapeFileCount > 0)
                {
                    intMouseRecord = sfMap1.LocateShapeIndexAtPoint(pt, "rtk.shp");

                    if (intMouseRecord >= 0)
                    {
                        long lBuildingID = ZoomToBuildingImpartialIndex(intMouseRecord);
                        return lBuildingID;
                    }
                }

                return 0;

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " :Source = " + ex.Source;
                return 0;
            }

            finally
            {

            }


        }

        private long ZoomToBuildingImpartialIndex(int lIndex)
        {
            TRIP_API.IMBuildingMaster imBuilding = null;

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
                                    imBuilding = new TRIP_API.IMBuildingMaster();
                                    imBuilding.MapID = Convert.ToInt64(strSelectedMapIDValue);

                                    if (imBuilding.ReturnBuildingIDNameMapIDMapID(0, 0) == true)
                                    {
                                        return imBuilding.BuildingID;
                                    }
                                }

                            }
                        }
                    }
                }

                return 0;
            }


            catch (Exception ex)
            {
                errMessage = ex.Message + " :Source = " + ex.Source;
                return 0;
            }

            finally
            {
                if (imBuilding != null)
                {
                    imBuilding = null;
                }
            }

        }

        private bool FindBuildingShapeFile(string strArgShapeFileName)
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


                    if (FindBuildingShapeFile("rtk.shp") == true)
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



        private void sfMap1_Load(object sender, EventArgs e)
        {

        }

        private void sfMap1_ClientSizeChanged(object sender, EventArgs e)
        {
            UpdateVisibleAreaLabel();

        }

        private void miMapBackgroundColor_Click(object sender, EventArgs e)
        {
            mapColorDialog.Color = sfMap1.BackColor;
            if (this.mapColorDialog.ShowDialog(this) == DialogResult.OK)
            {
                sfMap1.MapBackColor = mapColorDialog.Color;
                ProjectChanged();

            }
        }

        private void FindData(string recordValue)
        {
            try
            {

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }
        }

        private void LoadInputFilterShapefile(string path)
        {

            DbfReader r = null;
            try
            {
                r = new DbfReader(System.IO.Path.ChangeExtension(path, ".dbf"));
                string[] ray = r.GetFieldNames();
            }
            finally
            {
                if (r != null) r.Close();
            }

        }

        private bool IsMapFitForMercator()
        {
            RectangleF ext = sfMap1.Extent;
            return (ext.Top <= 90 && ext.Bottom >= -90);
        }


        #endregion

        #region "XPPanel"

        public void LoadXPPanel()
        {
            
            Point pt = new Point(392,33);

            xpMyProperties.Size = new Size(pt);
            xpNewBuildingProperties.Size = new Size(pt);
            xpNewLandProperties.Size = new Size(pt);
            xppnlMyMessages.Size = new Size(pt);
            xppnlFind.Size = new Size(pt);
               
            xpMyProperties.PanelState = XPPanelState.Expanded;
            xppnlMyMessages.PanelState = XPPanelState.Expanded;
            xpNewBuildingProperties.PanelState = XPPanelState.Expanded;
            xpNewLandProperties.PanelState = XPPanelState.Expanded;
            xppnlFind.PanelState = XPPanelState.Expanded;

            xpMyProperties.PanelState = XPPanelState.Collapsed;
            xpNewBuildingProperties.PanelState = XPPanelState.Collapsed;
            xppnlFind.PanelState = XPPanelState.Collapsed;
            xpNewLandProperties.PanelState = XPPanelState.Collapsed;

        }


        #endregion

        private void tsTxtFind_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void tsTxtFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FindData(txtFindValue.Text);
            }
        }        

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            NewProject();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveProject();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenShapeFile();
        }

        private void openToolStripButton1_Click(object sender, EventArgs e)
        {
            OpenProject();
        }

        private void DisplayAbout()
        {
            frmAbout f = new frmAbout();
            try
            {
                f.ShowDialog(this);
            }
            finally
            {
                f.Dispose();
            }
        }

        private void tsBtnZoomIn_Click(object sender, EventArgs e)
        {
            ZoomIn();
        }

        private void tsBtnZoomOut_Click(object sender, EventArgs e)
        {
            ZoomOut();
        }

        private void tsBtnPanLeft_Click(object sender, EventArgs e)
        {
            PanLeft();
        }

        private void tsBtnPanRight_Click(object sender, EventArgs e)
        {
            PanRight();
        }

        private void tsBtnPanUp_Click(object sender, EventArgs e)
        {
            PanUp();
        }

        private void tsBtnPanDown_Click(object sender, EventArgs e)
        {
            PanDown();
        }

        private void tsBtnZoomFull_Click(object sender, EventArgs e)
        {
            ZoomFull();
        }

        private void shapeFileListControl1_AddLayerClicked(object sender, EventArgs e)
        {
            OpenShapeFile();
        }

        private void sfMap1_MouseMove(object sender, MouseEventArgs e)
        {
            PointD pt = sfMap1.PixelCoordToGisPoint(new Point(e.X, e.Y));

            string msg = string.Format("[{0},{1}]", new object[] { pt.X, pt.Y });
            tsLblMapMousePos.Text = msg;

        }

        private void sfMap1_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Arrow;
        }

        private void sfMap1_MouseUp(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            DisplayAbout();
        }

        private void miMercatorProjection_Click(object sender, EventArgs e)
        {
            bool useProjection = !sfMap1.UseMercatorProjection;
            bool ok = true;
            if (useProjection)
            {
                if (!IsMapFitForMercator())
                {
                    ok = (DialogResult.Yes == MessageBox.Show(this, "Warning: The current project does not appear to be using" +
                        "Lat Long Coords.\nIf you use the Mercator Projection all parts of the map may not be visibe.\nAre you" +
                        "sure you wish to use the Mercator Projection?",
                        "Confirm Mercator Projection", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning));
                }
            }
            if (ok)
            {
                sfMap1.UseMercatorProjection = useProjection;
                miMercatorProjection.Checked = useProjection;
            }
        }

        private void highToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lowToolStripMenuItem.Checked = false;
            highToolStripMenuItem.Checked = true;
            autoToolStripMenuItem.Checked = false;
            this.sfMap1.RenderQuality = Tripodmaps.Reader.RenderQuality.High;

        }

        private void lowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lowToolStripMenuItem.Checked = true;
            highToolStripMenuItem.Checked = false;
            autoToolStripMenuItem.Checked = false;
            this.sfMap1.RenderQuality = Tripodmaps.Reader.RenderQuality.Low;
        }

        private void autoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lowToolStripMenuItem.Checked = false;
            highToolStripMenuItem.Checked = false;
            autoToolStripMenuItem.Checked = true;
            this.sfMap1.RenderQuality = Tripodmaps.Reader.RenderQuality.Auto;

        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewProject();

        }

        private void saveProjectAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveProject(null);
        }

        private void sfMap1_ShapeFilesChanged(object sender, EventArgs args)
        {
            ProjectChanged();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.recordAttributesForm.AllowClose = !e.Cancel;

            if (frmPropertyFinder != null)
            {
                frmPropertyFinder = null;
            }

            if (BuildingForm != null)
            {
                BuildingForm = null;
            }

            if (CustForm != null)
            {
                CustForm = null;
            }

            if (DocumentsForm != null)
            {
                DocumentsForm = null;
            }

            if (recordAttributesForm != null)
            {
                recordAttributesForm = null;
            }

            if (AssetTypesForm != null)
            {
                AssetTypesForm = null;
            }

            if (UsagesForm != null)
            {
                UsagesForm = null;
            }

            if (PointTypesMasterForm != null)
            {
                PointTypesMasterForm = null;
            }

            if (RoomTypeMasterForm != null)
            {
                RoomTypeMasterForm = null;
            }

            if (RoomAmenityTypesForm != null)
            {
                RoomAmenityTypesForm = null;
            }

            if (BuildingTypesForm != null)
            {
                BuildingTypesForm = null;
            }

            if (DocumentTypesForm != null)
            {
                DocumentTypesForm = null;
            }

            if (AddressDetails != null)
            {
                AddressDetails = null;
            }

            if (FindDetails != null)
            {
                FindDetails = null;
            }

            
            Application.Exit();
        }

        private void exportProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportProject();
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (string.Compare(System.IO.Path.GetExtension(files[0]), ".shp", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Assign the file names to a string array, in 
                // case the user has selected multiple files.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                try
                {
                    this.mainProgressBar.Maximum = files.Length;
                    this.mainProgressBar.Value = 0;
                    this.mainProgressBar.Visible = true;
                    for (int n = 0; n < files.Length; n++)
                    {
                        if (string.Compare(System.IO.Path.GetExtension(files[n]), ".shp", StringComparison.OrdinalIgnoreCase) == 0)
                            this.OpenShapeFile(files[n]);
                        this.mainProgressBar.Increment(1);
                        Refresh();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    this.mainProgressBar.Visible = false;
                }
            }
        }

        private void saveMapImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfdMapImage.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    SaveMapBitmap(sfdMapImage.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void SaveMapBitmap(string path)
        {
            Bitmap bm = sfMap1.GetBitmap();
            try
            {
                bm.Save(path);
            }
            finally
            {
                bm.Dispose();
            }
        }

        private void sfMap1_TooltipDisplayed(object sender, Tripodmaps.Viewer.MapViewer.TooltipEventArgs e)
        {
            if (e.ShapeFileIndex >= 0 && e.RecordIndex >= 0)
            {
                if (recordAttributesForm.Visible)
                {
                    string[] names = sfMap1[e.ShapeFileIndex].GetAttributeFieldNames();
                    string[] values = sfMap1[e.ShapeFileIndex].GetAttributeFieldValues(e.RecordIndex);
                    recordAttributesForm.SetRecordData(e.ShapeFileIndex, sfMap1[e.ShapeFileIndex].Name, e.RecordIndex, names, values);
                }
                //PointD ptd = sfMap1.PixelCoordToGisPoint(e.MousePosition);
                //int recIndex = sfMap1[e.ShapeFileIndex].GetShapeIndexContainingPoint(new PointF((float)ptd.X, (float)ptd.Y), 0.00001F);
                //Console.Out.WriteLine("rec: " + recIndex);
            }
            else
            {
                recordAttributesForm.SetRecordData(-1, "", -1, null, null);
            }
        }

        private void displayShapeAttributesWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.displayShapeAttributesWindowToolStripMenuItem.Checked = !displayShapeAttributesWindowToolStripMenuItem.Checked;
            this.recordAttributesForm.Visible = displayShapeAttributesWindowToolStripMenuItem.Checked;
        }

        void recordAttributesForm_VisibleChanged(object sender, EventArgs e)
        {
            this.displayShapeAttributesWindowToolStripMenuItem.Checked = recordAttributesForm.Visible;
        }

        private void useNativeFileMappingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.useNativeFileMappingToolStripMenuItem.Checked = !this.useNativeFileMappingToolStripMenuItem.Checked;
            Tripodmaps.Reader.ShapeFile.MapFilesInMemory = useNativeFileMappingToolStripMenuItem.Checked;
        }

        private void tsTxtFind_Click(object sender, EventArgs e)
        {

        }

        private void registerCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //if (CustForm.IsDisposed == true)
            //{
            //    CustForm = new frmCustomers(this.currentProjectPath);
            //}

            {
                CustForm = new frmCustomers(this.currentProjectPath);
            }

            CustForm.Show();
        }

        private void mnuUsageTypes_Click(object sender, EventArgs e)
        {
            if (UsagesForm == null)
            {
                UsagesForm = new frmUsageMaster();
            }

            UsagesForm.ShowDialog(this);
        }

        public static Form IsFormAlreadyOpen(Type FormType)
        {
            foreach (Form OpenForm in Application.OpenForms)
            {
                if (OpenForm.GetType() == FormType)
                    return OpenForm;
            }
            return null;
        }

        private void mnuGISControllerBuildings_Click(object sender, EventArgs e)
        {
            try
            {

                if (BuildingForm == null)
                {
                    BuildingForm = new frmBuildings(this.currentProjectPath);
                }

                if (BuildingForm.Visible != true)
                {
                    BuildingForm.ShowDialog(this);
                }

            }

            finally
            {

            }

        }


        //    if (FormOpen== true)
        //{
        //MessageBox.Show(“Form already open.”);
        //}
        //else
        //{
        //Form MyForm= new MyForm();
        //OnSite.Show();

        //}


        private void pointTyprdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PointTypesMasterForm == null)
            {
                PointTypesMasterForm = new frmPointTypesMaster();
            }

            PointTypesMasterForm.ShowDialog(this);
        }

        private void roomTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (RoomTypeMasterForm == null)
            {
                RoomTypeMasterForm = new frmRoomTypeMaster();
            }

            RoomTypeMasterForm.ShowDialog(this);
        }

        private void mnuToolsLookupsRoomAmenityTypes_Click(object sender, EventArgs e)
        {
            if (RoomAmenityTypesForm == null)
            {
                RoomAmenityTypesForm = new frmRoomAmenityTypes();
            }

            RoomAmenityTypesForm.ShowDialog(this);

        }

        private void buildingTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BuildingTypesForm == null)
            {
                BuildingTypesForm = new frmBuildingTypes();
            }

            BuildingTypesForm.ShowDialog(this);
        }

        private void addDocumentTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mnuToolsLookupsDocumentTypes_Click(object sender, EventArgs e)
        {
            if (DocumentTypesForm == null)
            {
                DocumentTypesForm = new frmDocumentTypes();
            }

            DocumentTypesForm.ShowDialog(this);
        }

        private void mnuToolsEncryptionEncryptFile_Click(object sender, EventArgs e)
        {
            GeuzaFili();
        }

        private void mnuToolsDataCaptureImportBuildings_Click(object sender, EventArgs e)
        {
            CaptureBuildings();
        }

        private void mnuGISControllerAddresses_Click(object sender, EventArgs e)
        {
            try
            {

                if (AddressDetails == null)
                {
                    AddressDetails = new frmAddressDetails(this.currentProjectPath);
                }

                if (AddressDetails.Visible != true)
                {
                    AddressDetails.ShowDialog(this);
                }

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }

        }

        private void mainToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void mnuToolsDataCaptureImportPointsOfInterest_Click(object sender, EventArgs e)
        {
            CapturePointsOfInterest();
        }

        private void tscbSearchLayers_Click(object sender, EventArgs e)
        {

        }

        private void propertyFinderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadPropertyFinderForm();

            if (mnuGISControllerPropertyFinder.Checked == true)
            {
                Properties.Settings.Default.LoadPropertyFormAtStartup = true;
                Properties.Settings.Default.Save();
                mnuGISControllerPropertyFinder.Checked = true;
                return;
            }
            else
            {
                Properties.Settings.Default.LoadPropertyFormAtStartup = false;
                Properties.Settings.Default.Save();
                mnuGISControllerPropertyFinder.Checked = false;
                return;
            }
        }

        private void LoadPropertyFinderForm()
        {
            try
            {
                if (frmPropertyFinder == null)
                {
                    frmPropertyFinder = new frmPropertyFinder();
                }

                if (frmPropertyFinder.Visible == false)
                {
                    frmPropertyFinder.Show(this);
                }


                frmPropertyFinder.WindowState = FormWindowState.Normal;
                frmPropertyFinder.Focus();
            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;

            }




        }

        private void LoadPropertyPropertyFormBySettings()
        {
            if (Properties.Settings.Default.LoadPropertyFormAtStartup == true)
            {
                mnuGISControllerPropertyFinder.Checked = true;
                LoadPropertyFinderForm();
                return;
            }
            else
            {
                mnuGISControllerPropertyFinder.Checked = false;
                return;
            }
        }

        private void DisplayParcelsInBounds()
        {
            try
            {
                int XBound = 0;
                int YBound = 0;
                int HeightBound = 0;
                int WidthBound = 0;
                int TopBound = 0;
                int BottomBound = 0;

                XBound = sfMap1.Bounds.X;
                YBound = sfMap1.Bounds.Y;

                HeightBound = sfMap1.Bounds.Height;
                WidthBound = sfMap1.Bounds.Width;

                TopBound = sfMap1.Bounds.Top;
                BottomBound = sfMap1.Bounds.Bottom;
            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }

        }

        private void mnuFindPlotParcelNo_Click(object sender, EventArgs e)
        {
            FindParcelsForSaleOrLease();
        }

        private void cmdFind_Click(object sender, EventArgs e)
        {
            ChangeBySelection();
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void FindParcelsForSaleOrLease()
        {
            try
            {
                if (FindDetails == null)
                {
                    FindDetails = new frmFind();
                }

                if (FindDetails.Visible == false)
                {
                    FindDetails.Show(this);
                }

                FindDetails.FindParcelsForSaleOrLease();
                FindDetails.WindowState = FormWindowState.Normal;
                FindDetails.Focus();

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }

        }

        private void FindByPointsOfInterest()
        {
            try
            {
                if (FindDetails == null)
                {
                    FindDetails = new frmFind();
                }

                if (FindDetails.Visible == false)
                {
                    FindDetails.Show(this);
                }

                FindDetails.FindByPointsOfInterest();
                FindDetails.WindowState = FormWindowState.Normal;
                FindDetails.Focus();

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }

        }

        private void FindByPlotNumber()
        {
            try
            {
                if (FindDetails == null)
                {
                    FindDetails = new frmFind();
                }

                if (FindDetails.Visible == false)
                {
                    FindDetails.Show(this);
                }

                FindDetails.FindByPlotNumber();
                FindDetails.WindowState = FormWindowState.Normal;
                FindDetails.Focus();
            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }

        }

        private void FindByPlotNumber(string strPlotNumber)
        {
            try
            {
                if (FindDetails == null)
                {
                    FindDetails = new frmFind();
                }

                if (FindDetails.Visible == false)
                {
                    FindDetails.Show(this);
                }

                FindDetails.LoadByPlotNumber(strPlotNumber);
                FindDetails.WindowState = FormWindowState.Normal;
                FindDetails.Focus();

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }

        }

        private void FindByBuildingName()
        {
            try
            {
                if (FindDetails == null)
                {
                    FindDetails = new frmFind();
                }

                if (FindDetails.Visible == false)
                {
                    FindDetails.Show(this);
                }

                FindDetails.FindByBuildingName();
                FindDetails.WindowState = FormWindowState.Normal;
                FindDetails.Focus();

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }

        }

        private void FindByRoadNames()
        {
            try
            {
                if (FindDetails == null)
                {
                    FindDetails = new frmFind();
                }

                if (FindDetails.Visible == false)
                {
                    FindDetails.Show(this);
                }

                FindDetails.FindByRoadNames();
                FindDetails.WindowState = FormWindowState.Normal;
                FindDetails.Focus();


            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }

        }

        private void FindByCustomerNumber()
        {
            try
            {
                if (FindDetails == null)
                {
                    FindDetails = new frmFind();
                }

                if (FindDetails.Visible == false)
                {
                    FindDetails.Show(this);
                }

                FindDetails.FindByCustomerNumber();
                FindDetails.WindowState = FormWindowState.Normal;
                FindDetails.Focus();

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }

        }

        private void FindByCustomerName()
        {
            try
            {
                if (FindDetails == null)
                {
                    FindDetails = new frmFind();
                }

                if (FindDetails.Visible == false)
                {
                    FindDetails.Show(this);
                }

                FindDetails.FindByCustomerName();
                FindDetails.WindowState = FormWindowState.Normal;
                FindDetails.Focus();
            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }

        }

        private void FindByPrivateCustomerSurnameName()
        {
            try
            {
                if (FindDetails == null)
                {
                    FindDetails = new frmFind();
                }

                if (FindDetails.Visible == false)
                {
                    FindDetails.Show(this);
                }

                FindDetails.FindByPrivateCustomerSurnameName();
                FindDetails.WindowState = FormWindowState.Normal;
                FindDetails.Focus();
            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }

        }

        private void FindByCompanyCustomerCompanyName()
        {
            try
            {
                if (FindDetails == null)
                {
                    FindDetails = new frmFind();
                }

                if (FindDetails.Visible == false)
                {
                    FindDetails.Show(this);
                }

                FindDetails.FindByCompanyCustomerCompanyName();
                FindDetails.WindowState = FormWindowState.Normal;
                FindDetails.Focus();

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }

        }

        private void FindByCustomerPINCode()
        {
            try
            {
                if (FindDetails == null)
                {
                    FindDetails = new frmFind();
                }

                if (FindDetails.Visible == false)
                {
                    FindDetails.Show(this);
                }

                FindDetails.FindByCustomerPINCode();
                FindDetails.WindowState = FormWindowState.Normal;
                FindDetails.Focus();
            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }

        }

        private void FindFormEmpty()
        {
            try
            {
                if (FindDetails == null)
                {
                    FindDetails = new frmFind();
                }

                if (FindDetails.Visible == false)
                {
                    FindDetails.Show(this);
                }

                FindDetails.WindowState = FormWindowState.Normal;
                FindDetails.BringToFront();
                FindDetails.Focus();
            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }

        }

        private void ChangeBySelection()
        {
            int cmCriteria;

            cmCriteria = -1;

            if (cmbCriteria.Text.Trim() != "")
            {
                cmCriteria = cmbCriteria.SelectedIndex;
            }

            switch (cmCriteria)
            {
                case -1:
                    FindFormEmpty();
                    break;

                case 0:
                    if (txtFindValue.Text.Trim() == "")
                    {
                        FindByPlotNumber();
                    }
                    else
                    {
                        FindByPlotNumber(txtFindValue.Text.Trim());
                    }

                    break;

                case 1:
                    FindByPointsOfInterest();
                    break;

                case 2:
                    FindParcelsForSaleOrLease();
                    break;

                case 3:
                    FindByBuildingName();
                    break;

                case 4:
                    FindByRoadNames();
                    break;

                case 5:
                    FindByCustomerNumber();
                    break;

                case 6:
                    FindByCustomerName();
                    break;

                case 7:
                    FindByPrivateCustomerSurnameName();
                    break;

                case 8:
                    FindByCompanyCustomerCompanyName();
                    break;

                case 9:
                    FindByCustomerPINCode();
                    break;

            }
        }

        private void mnuGISControllerLandParcels_Click(object sender, EventArgs e)
        {

        }

        private void txtFindValue_Click(object sender, EventArgs e)
        {

        }

        private void txtFindValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ChangeBySelection();
            }
        }

        private void mnuDocumentControllerManagerRegisterDocument_Click(object sender, EventArgs e)
        {
            try
            {
                LoadDocumentsForm();
                DocumentsForm.DocumentRegistration();
            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }

        }

        private bool LoadDocumentsForm()
        {
            try
            {
                if (DocumentsForm == null)
                {
                    DocumentsForm = new frmDocuments();
                }

                if (DocumentsForm.Visible == false)
                {
                    DocumentsForm.Show(this);
                }

                DocumentsForm.WindowState = FormWindowState.Normal;
                DocumentsForm.Focus();
                return true;

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
                return false;
            }

            finally
            {

            }

        }

        private void mnuDocumentControllerManagerArchiveRegisterVolume_Click(object sender, EventArgs e)
        {
            try
            {
                LoadDocumentsForm();
                DocumentsForm.ArchiveVolume();
            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }
        }

        private void ShowFindPanel()
        {
            if (panel2.Visible == false)
            {
                panel2.Visible = true;
                panel2.Focus();
                LoadXPPanel();
            }
        }

        private void HideFindPanel()
        {
            if (panel2.Visible == true)
            {
                panel2.Visible = false;
                sfMap1.Focus();
            }
        }

        private void mnuViewFindPanel_Click(object sender, EventArgs e)
        {
            ShowFindPanel();
        }

        private void xpPanelGroup1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tlstrpbtnCloseTripodMainPanel_Click(object sender, EventArgs e)
        {
            HideFindPanel();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void tlstrpbtnTripodMainPanel_Click(object sender, EventArgs e)
        {
            HideFindPanel();
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeByCriteria();
        }

        private void ChangeByCriteria()
        {
            int cmbCriteria;

            cmbCriteria = -1;
            cmbFindSubCriteria.Items.Clear();
            cmbCriteria = cmbFindCriteria.SelectedIndex;

            switch (cmbCriteria)
            {
                case 0:
                    //Plot
                    cmbFindSubCriteria.Items.Add("Plot Number");
                    cmbFindSubCriteria.Items.Add("Plots for Sale");
                    cmbFindSubCriteria.Items.Add("Plot for Lease");
                    cmbFindSubCriteria.Items.Add("Size of Plot in Acres with sale details");
                    cmbFindSubCriteria.Items.Add("Size of Plot in Acres with lease details");
                    cmbFindSubCriteria.Items.Add("Size of Plot in Acres with any details");
                    cmbFindSubCriteria.Items.Add("Plots near map centre");
                    break;

                case 1:
                    //Points of interest
                    cmbFindSubCriteria.Items.Add("Point Name");
                    cmbFindSubCriteria.Items.Add("Point Category e.g. Hospital, School, Hotel");
                    cmbFindSubCriteria.Items.Add("Point Sub Category e.g. Clinic, 3 Star Hotel");
                    break;

                case 2:
                    //Buildings
                    cmbFindSubCriteria.Items.Add("Building Name");
                    cmbFindSubCriteria.Items.Add("Building with Rental Space");
                    cmbFindSubCriteria.Items.Add("Building with Rental Space and X number of rooms");
                    cmbFindSubCriteria.Items.Add("Building with Appartments with Certain Amenities and X Rooms");
                    cmbFindSubCriteria.Items.Add("Buildings with certain point categories");
                    cmbFindSubCriteria.Items.Add("Buildings with Usage e.g Residential, Commercial");
                    cmbFindSubCriteria.Items.Add("Buildings Type - Permanent, Semi-Permanent");
                    break;

                case 3:
                    //Roads
                    cmbFindSubCriteria.Items.Add("Road Name");
                    cmbFindSubCriteria.Items.Add("Road Class");
                    cmbFindSubCriteria.Items.Add("Road Surface Type - e.g. Murram, Tarmac");
                    break;

                case 4:
                    //Property Agents
                    cmbFindSubCriteria.Items.Add("Property Agent Name");
                    cmbFindSubCriteria.Items.Add("Property Agent in Geographical Area");
                    cmbFindSubCriteria.Items.Add("Property Agent with X number of TripodStars");
                    break;


            }
        }

        private void cmdFind2_Click(object sender, EventArgs e)
        {
            dtgrdvwFind.Columns.Clear();
            LoadBySelection();
        }

        private void LoadBySelection()
        {
            

            int cmbCriteria;

            cmbCriteria = -1;

            cmbCriteria = cmbFindSubCriteria.SelectedIndex;

            if (cmbFindCriteria.SelectedIndex == 0)
            {
                switch (cmbCriteria)
                {
                    case 0:
                        LoadByPlotNumber();
                        break;

                    case 1:

                        break;

                    case 2:
                        LoadParcelsForSaleOrLease();
                        break;

                    case 3:
                        break;

                    case 4:
                        break;

                    case 5:
                        break;

                    case 6:
                        break;

                    case 7:
                        break;

                    case 8:
                        break;

                    case 9:
                        break;

                }
            }

            if (cmbFindCriteria.SelectedIndex == 1)
            {
                switch (cmbCriteria)
                {
                    case 0:
                        //Point Name
                        LoadByPointOfInterest();
                        break;

                    case 1:
                        break;

                    case 2:
                        break;


                }
            }



            lDirection = 0;

            if (dtgrdvwFind.Rows.Count > 0)
            {
                int cntRecords = 0;

                cntRecords = dtgrdvwFind.Rows.Count - 1;
            }

        }

        public void LoadParcelsForSaleOrLease()
        {

        }

        public void LoadByPlotNumber()
        {
            TRIP_API.IMPlotMaster imPlotMaster = null;
            FindByPlotNumberPanel();
            
            try
            {
                imPlotMaster = new TRIP_API.IMPlotMaster();
                imPlotMaster.ParcelNo = txtFindValue2.Text.Trim();

                imPlotMaster.ReturnAllPlotMasterByParcelNo(0, Convert.ToInt64(numNumberToDisplay.Value), lOffset);

                if (imPlotMaster.PlotMasterDataSet != null)
                {
                    if (imPlotMaster.PlotMasterDataSet.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow myDataRowsPlot in imPlotMaster.PlotMasterDataSet.Tables[0].Rows)
                        {
                            dtgrdvwFind.AutoGenerateColumns = false;
                            dtgrdvwFind.DataSource = imPlotMaster.PlotMasterDataSet.Tables[0];

                            dtgrdvwFind.Columns["PLOTID"].DataPropertyName = "PLOTID";
                            dtgrdvwFind.Columns["PARCELNO"].DataPropertyName = "PARCELNO";
                            dtgrdvwFind.Columns["REGISTRYSHEETNO"].DataPropertyName = "REGISTRYMAPSHEETNO";
                            dtgrdvwFind.Columns["TITLEDEEDNUMBER"].DataPropertyName = "TITLEDEEDNUMBER";
                            dtgrdvwFind.Columns["PLOTAREA"].DataPropertyName = "PLOTAREA";

                        }
                    }
                }

                dtgrdvwFind.Focus();

                if (lDirection == 1)
                {
                    lOffset = lOffset + Convert.ToInt64(numNumberToDisplay.Value);
                }
                else if (lDirection == 2)
                {
                    lOffset = lOffset - Convert.ToInt64(numNumberToDisplay.Value);

                    if (lOffset < 0)
                    {
                        lOffset = 0;
                    }
                }

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {
                if (imPlotMaster != null)
                {
                    imPlotMaster = null;
                }
            }

        }

        public void LoadByPointOfInterest()
        {
            TRIP_API.IMAddress imAddress = null;
            FindByPointsOfInterest();

            try
            {
                imAddress = new TRIP_API.IMAddress();
                imAddress.AddressDetailsPointName = txtFindValue.Text.Trim();

                if (chkExactValue.Checked == true)
                {
                    imAddress.ExactMatch = 1;
                }
                else
                {
                    imAddress.ExactMatch = 0;
                }

                imAddress.ReturnAllAddressDetailsByPointName(Convert.ToInt64(numNumberToDisplay.Value), lOffset);

                if (imAddress.AddressDetailsDataSet != null)
                {
                    if (imAddress.AddressDetailsDataSet.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow myDataRowsPlot in imAddress.AddressDetailsDataSet.Tables[0].Rows)
                        {
                            dtgrdvwFind.AutoGenerateColumns = false;
                            dtgrdvwFind.DataSource = imAddress.AddressDetailsDataSet.Tables[0];

                            dtgrdvwFind.Columns["ADDRESSID"].DataPropertyName = "ADDRESSDETAILSID";
                            dtgrdvwFind.Columns["NAME"].DataPropertyName = "POINTNAME";
                        }
                    }
                }

                dtgrdvwFind.Focus();

                if (lDirection == 1)
                {
                    lOffset = lOffset + Convert.ToInt64(numNumberToDisplay.Value);
                }
                else if (lDirection == 2)
                {
                    lOffset = lOffset - Convert.ToInt64(numNumberToDisplay.Value);

                    if (lOffset < 0)
                    {
                        lOffset = 0;
                    }
                }

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {
                if (imAddress != null)
                {
                    imAddress = null;
                }
            }

        }

        private void txtFindValue2_TextChanged(object sender, EventArgs e)
        {
            lOffset = 0;
            lDirection = 1;
        }

        private void cmdPrevious_Click(object sender, EventArgs e)
        {
            lDirection = 2;
            dtgrdvwFind.Columns.Clear();
            LoadBySelection();
        }

        private void cmdNextTen_Click(object sender, EventArgs e)
        {
            lDirection = 1;
            dtgrdvwFind.Columns.Clear();
            LoadBySelection();
        }

        private void numNumberToDisplay_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                lOffset = 0;
                dtgrdvwFind.Columns.Clear();
                LoadBySelection();
            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;

            }

            finally
            {


            }
        }

        private void cmbFindSubCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {
            FindBySelectionPanel();
        }

        private void FindBySelectionPanel()
        {
            int cmbSubCriteria;

            cmbSubCriteria = -1;

            //Plots
            if (cmbFindCriteria.SelectedIndex == 0)
            {
                cmbSubCriteria = cmbFindSubCriteria.SelectedIndex;

                switch (cmbSubCriteria)
                {
                    case 0:
                        FindByPlotNumberPanel();
                        break;

                    case 1:
                        FindByPlotsForSalePanel();
                        break;

                    case 2:
                        FindByPlotsForLeasePanel();
                        break;

                    case 3:
                        FindByBuildingNamePanel();
                        break;

                    case 4:
                        FindByRoadNamesPanel();
                        break;

                    case 5:
                        FindByCustomerNumberPanel();
                        break;

                    case 6:
                        FindByCustomerNamePanel();
                        break;

                    case 7:
                        FindByPrivateCustomerSurnameNamePanel();
                        break;

                    case 8:
                        FindByCompanyCustomerCompanyNamePanel();
                        break;

                    case 9:
                        FindByCustomerPINCodePanel();
                        break;
                }
            }

            //Points of interest
            if (cmbFindCriteria.SelectedIndex == 1)
            {
                cmbSubCriteria = cmbFindSubCriteria.SelectedIndex;

                switch (cmbSubCriteria)
                {
                    case 0:


                        FindByPointsOfInterestPanel();
                        break;

                    case 1:
                        FindByPointsOfInterestPanel();
                        break;

                    case 2:
                        FindParcelsForSaleOrLeasePanel();
                        break;


                }
            }

            //Buildings
            if (cmbFindCriteria.SelectedIndex == 2)
            {
                cmbSubCriteria = cmbFindSubCriteria.SelectedIndex;

                switch (cmbSubCriteria)
                {
                    case 0:
                        //FindByBuildingName
                        break;

                    case 1:
                        //Building with Rental Space
                        break;


                    case 2:
                        //Building with Rental Space and X number of rooms
                        break;

                    case 3:
                        //Building with Appartments with Certain Amenities and X Rooms
                        break;

                    case 4:
                        //Buildings with certain point categories
                        break;

                    case 5:
                        //Buildings with Usage e.g Residential, Commercial
                        break;

                    case 6:
                        //Buildings Type - Permanent, Semi-Permanent
                        break;

                }
            }


            //Buildings
            if (cmbFindCriteria.SelectedIndex == 2)
            {
                cmbSubCriteria = cmbFindSubCriteria.SelectedIndex;

                switch (cmbSubCriteria)
                {
                    case 0:
                        //RoadName
                        break;

                    case 1:
                        //Road Class
                        break;


                    case 2:
                        //Road Surface Type - e.g. Murram, Tarmac
                        break;

                    case 3:
                        //Building with Appartments with Certain Amenities and X Rooms
                        break;

                    case 4:
                        //Buildings with certain point categories
                        break;

                    case 5:
                        //Buildings with Usage e.g Residential, Commercial
                        break;

                    case 6:
                        //Buildings Type - Permanent, Semi-Permanent
                        break;

                }
            }


        }

        public void FindByPlotsForSalePanel()
        {
            try
            {
                DataGridViewImageColumn imageColumn;

                Bitmap unMarked = blank;
                imageColumn = new DataGridViewImageColumn();

                //Add twice the padding for the left and 
                //right sides of the cell.
                imageColumn.Width = x.Width + 2 * bitmapPadding + 1;

                imageColumn.Image = unMarked;


                dtgrdvwFind.DataMember = "";
                dtgrdvwFind.Columns.Clear();

                dtgrdvwFind.Columns.Add("PLOTID", "PLOT ID");

                dtgrdvwFind.Columns.Add(imageColumn);


                dtgrdvwFind.Columns.Add("PARCELNO", "PARCEL NUMBER");
                dtgrdvwFind.Columns["PARCELNO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgrdvwFind.Columns.Add("SALEPRICE", "SALE PRICE");
                dtgrdvwFind.Columns.Add("PLOTAREA", "PLOT AREA");
                dtgrdvwFind.Columns.Add("LOCALITY", "LOCALITY");
                dtgrdvwFind.Columns.Add("DEEDPLANNUMBER", "DEED PLAN NUMBER");
                dtgrdvwFind.Columns.Add("REGISTRYSHEETNO", "REGISTRY SHEET NUMBER");
                dtgrdvwFind.Columns.Add("TITLEDEEDNUMBER", "TITLE DEED NUMBER");
                dtgrdvwFind.Columns.Add("PHYSICALADDRESS", "PHYSICAL ADDRESS");
                dtgrdvwFind.Columns.Add("UNIVERSALADDRESS", "UNIVERSALADDRESS");
                dtgrdvwFind.Columns.Add("PROVINCE", "PROVINCE");
                dtgrdvwFind.Columns.Add("DISTRICT", "DISTRICT");
                dtgrdvwFind.Columns.Add("DIVISION", "DIVISION");
                dtgrdvwFind.Columns.Add("LOCATION", "LOCATION");
                dtgrdvwFind.Columns.Add("SUBLOCATION", "SUB-LOCATION");
                dtgrdvwFind.Columns.Add("COORDINATES", "COORDINATES");

                dtgrdvwFind.ColumnHeadersVisible = true;
                dtgrdvwFind.AutoSize = true;
                dtgrdvwFind.Columns["PLOTID"].Visible = false;

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }

        }

        public void FindByPlotsForLeasePanel()
        {
            try
            {
                DataGridViewImageColumn imageColumn;

                Bitmap unMarked = blank;
                imageColumn = new DataGridViewImageColumn();

                //Add twice the padding for the left and 
                //right sides of the cell.
                imageColumn.Width = x.Width + 2 * bitmapPadding + 1;

                imageColumn.Image = unMarked;


                dtgrdvwFind.DataMember = "";
                dtgrdvwFind.Columns.Clear();

                dtgrdvwFind.Columns.Add("PLOTID", "PLOT ID");

                dtgrdvwFind.Columns.Add(imageColumn);

                dtgrdvwFind.Columns.Add("PLOTID", "PLOT ID");
                dtgrdvwFind.Columns.Add("PARCELNO", "PARCEL NUMBER");
                dtgrdvwFind.Columns["PARCELNO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgrdvwFind.Columns.Add("LEASEPRICE", "LEASE PRICE");
                dtgrdvwFind.Columns.Add("PLOTAREA", "PLOT AREA");
                dtgrdvwFind.Columns.Add("LOCALITY", "LOCALITY");
                dtgrdvwFind.Columns.Add("DEEDPLANNUMBER", "DEED PLAN NUMBER");
                dtgrdvwFind.Columns.Add("REGISTRYSHEETNO", "REGISTRY SHEET NUMBER");
                dtgrdvwFind.Columns.Add("TITLEDEEDNUMBER", "TITLE DEED NUMBER");
                dtgrdvwFind.Columns.Add("PHYSICALADDRESS", "PHYSICAL ADDRESS");
                dtgrdvwFind.Columns.Add("UNIVERSALADDRESS", "UNIVERSALADDRESS");
                dtgrdvwFind.Columns.Add("PROVINCE", "PROVINCE");
                dtgrdvwFind.Columns.Add("DISTRICT", "DISTRICT");
                dtgrdvwFind.Columns.Add("DIVISION", "DIVISION");
                dtgrdvwFind.Columns.Add("LOCATION", "LOCATION");
                dtgrdvwFind.Columns.Add("SUBLOCATION", "SUB-LOCATION");
                dtgrdvwFind.Columns.Add("COORDINATES", "COORDINATES");

                dtgrdvwFind.ColumnHeadersVisible = true;
                dtgrdvwFind.AutoSize = true;
                dtgrdvwFind.Columns["PLOTID"].Visible = false;

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }

        }

        public void FindParcelsForSaleOrLeasePanel()
        {
            try
            {
                dtgrdvwFind.DataMember = "";
                dtgrdvwFind.Columns.Clear();
                dtgrdvwFind.Columns.Add("PLOTID", "PLOT ID");
                dtgrdvwFind.Columns.Add("PARCELNO", "PARCEL NUMBER");
                dtgrdvwFind.Columns["PARCELNO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgrdvwFind.Columns.Add("SALEPRICE", "SALE PRICE");
                dtgrdvwFind.Columns.Add("PLOTAREA", "PLOT AREA");
                dtgrdvwFind.Columns.Add("LOCALITY", "LOCALITY");
                dtgrdvwFind.Columns.Add("DEEDPLANNUMBER", "DEED PLAN NUMBER");
                dtgrdvwFind.Columns.Add("REGISTRYSHEETNO", "REGISTRY SHEET NUMBER");
                dtgrdvwFind.Columns.Add("TITLEDEEDNUMBER", "TITLE DEED NUMBER");
                dtgrdvwFind.Columns.Add("PHYSICALADDRESS", "PHYSICAL ADDRESS");
                dtgrdvwFind.Columns.Add("UNIVERSALADDRESS", "UNIVERSALADDRESS");
                dtgrdvwFind.Columns.Add("PROVINCE", "PROVINCE");
                dtgrdvwFind.Columns.Add("DISTRICT", "DISTRICT");
                dtgrdvwFind.Columns.Add("DIVISION", "DIVISION");
                dtgrdvwFind.Columns.Add("LOCATION", "LOCATION");
                dtgrdvwFind.Columns.Add("SUBLOCATION", "SUB-LOCATION");
                dtgrdvwFind.Columns.Add("COORDINATES", "COORDINATES");

                dtgrdvwFind.ColumnHeadersVisible = true;
                dtgrdvwFind.AutoSize = true;
                dtgrdvwFind.Columns["PLOTID"].Visible = false;

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }

        }

        public void FindByPointsOfInterestPanel()
        {
            try
            {
                DataGridViewImageColumn imageColumn;

                Bitmap unMarked = blank;
                imageColumn = new DataGridViewImageColumn();

                //Add twice the padding for the left and 
                //right sides of the cell.
                imageColumn.Width = x.Width + 2 * bitmapPadding + 1;

                imageColumn.Image = unMarked;


                dtgrdvwFind.DataMember = "";
                dtgrdvwFind.Columns.Clear();

                dtgrdvwFind.Columns.Add("ADDRESSID", "ADDRESSID");

                dtgrdvwFind.Columns.Add(imageColumn);

                dtgrdvwFind.Columns.Add("ADDRESSID", "ADDRESSID");
                dtgrdvwFind.Columns.Add("NAME", "NAME");
                dtgrdvwFind.Columns.Add("COORDINATES", "COORDINATES");
                dtgrdvwFind.Columns.Add("PHYSICALADDRESS", "PHYSICAL ADDRESS");
                dtgrdvwFind.Columns.Add("UNIVERSALADDRESS", "UNIVERSALADDRESS");
                dtgrdvwFind.Columns.Add("PROVINCE", "PROVINCE");
                dtgrdvwFind.Columns.Add("DISTRICT", "DISTRICT");
                dtgrdvwFind.Columns.Add("DIVISION", "DIVISION");
                dtgrdvwFind.Columns.Add("LOCATION", "LOCATION");
                dtgrdvwFind.Columns.Add("SUBLOCATION", "SUB-LOCATION");
                dtgrdvwFind.Columns.Add("COORDINATES", "COORDINATES");

                dtgrdvwFind.ColumnHeadersVisible = true;
                dtgrdvwFind.AutoSize = true;
                dtgrdvwFind.Columns["ADDRESSID"].Visible = false;

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }

        }

        public void FindByPlotNumberPanel()
        {

            try
            {
                cmbFindCriteria.SelectedIndex = 0;
                cmbFindSubCriteria.SelectedIndex = 0;

                DataGridViewImageColumn imageColumn;

                Bitmap unMarked = blank;
                imageColumn = new DataGridViewImageColumn();

                //Add twice the padding for the left and 
                //right sides of the cell.
                //imageColumn.Width = x.Width + 2 * bitmapPadding + 1;

                imageColumn.Name = "IMAGE";
                imageColumn.Image = unMarked;


                dtgrdvwFind.DataMember = "";
                dtgrdvwFind.Columns.Clear();

                dtgrdvwFind.Columns.Add("PLOTID", "PLOT ID");

                dtgrdvwFind.Columns.Add(imageColumn);

                dtgrdvwFind.Columns.Add("PARCELNO", "PARCEL NUMBER");
                dtgrdvwFind.Columns["PARCELNO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgrdvwFind.Columns["PARCELNO"].ToolTipText =
                    "Similar to L.R (Land Reference), Mazrui Number (IMN), Government Land (G.L)";
                dtgrdvwFind.Columns.Add("PLOTAREA", "PLOT AREA");
                dtgrdvwFind.Columns.Add("LOCALITY", "LOCALITY");
                dtgrdvwFind.Columns.Add("DEEDPLANNUMBER", "DEED PLAN NUMBER");
                dtgrdvwFind.Columns.Add("REGISTRYSHEETNO", "REGISTRY SHEET NUMBER");
                dtgrdvwFind.Columns.Add("TITLEDEEDNUMBER", "TITLE DEED NUMBER");
                dtgrdvwFind.Columns.Add("PHYSICALADDRESS", "PHYSICAL ADDRESS");
                dtgrdvwFind.Columns.Add("UNIVERSALADDRESS", "UNIVERSALADDRESS");
                dtgrdvwFind.Columns.Add("PROVINCE", "PROVINCE");
                dtgrdvwFind.Columns.Add("DISTRICT", "DISTRICT");
                dtgrdvwFind.Columns.Add("DIVISION", "DIVISION");
                dtgrdvwFind.Columns.Add("LOCATION", "LOCATION");
                dtgrdvwFind.Columns.Add("SUBLOCATION", "SUB-LOCATION");
                dtgrdvwFind.Columns.Add("COORDINATES", "COORDINATES");

                dtgrdvwFind.ColumnHeadersVisible = true;
                dtgrdvwFind.AutoSize = true;
                dtgrdvwFind.Columns["PLOTID"].Visible = false;

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }


        }

        public void FindByBuildingNamePanel()
        {
            try
            {
                DataGridViewImageColumn imageColumn;

                Bitmap unMarked = blank;
                imageColumn = new DataGridViewImageColumn();

                //Add twice the padding for the left and 
                //right sides of the cell.
                imageColumn.Width = x.Width + 2 * bitmapPadding + 1;

                imageColumn.Image = unMarked;


                dtgrdvwFind.DataMember = "";
                dtgrdvwFind.Columns.Clear();

                dtgrdvwFind.Columns.Add("BUILDINGID", "BUILDING ID");

                dtgrdvwFind.Columns.Add(imageColumn);

                dtgrdvwFind.Columns.Add("BUILDINGNAME", "BUILDING NAME");
                dtgrdvwFind.Columns.Add("BUILDINGTYPE", "BUILDING TYPE");
                dtgrdvwFind.Columns.Add("CURRENTHOUSENUMBER", "CURRENT HOUSE NUMBER");
                dtgrdvwFind.Columns.Add("BUILDINGHOUSENUMBER", "HOUSE NUMBER");
                dtgrdvwFind.Columns.Add("BUILDINGHOUSENUMBER", "HOUSE TYPE");
                dtgrdvwFind.Columns.Add("NOOFFLOORS", "NO OF FLOORS");
                dtgrdvwFind.Columns.Add("PHYSICALADDRESS", "PHYSICAL ADDRESS");
                dtgrdvwFind.Columns.Add("UNIVERSALADDRESS", "UNIVERSALADDRESS");
                dtgrdvwFind.Columns.Add("PROVINCE", "PROVINCE");
                dtgrdvwFind.Columns.Add("DISTRICT", "DISTRICT");
                dtgrdvwFind.Columns.Add("DIVISION", "DIVISION");
                dtgrdvwFind.Columns.Add("LOCATION", "LOCATION");
                dtgrdvwFind.Columns.Add("SUBLOCATION", "SUB-LOCATION");
                dtgrdvwFind.Columns.Add("COORDINATES", "COORDINATES");

                dtgrdvwFind.ColumnHeadersVisible = true;
                dtgrdvwFind.AutoSize = true;

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }

        }

        public void FindByRoadNamesPanel()
        {
            try
            {
                DataGridViewImageColumn imageColumn;

                Bitmap unMarked = blank;
                imageColumn = new DataGridViewImageColumn();

                //Add twice the padding for the left and 
                //right sides of the cell.
                imageColumn.Width = x.Width + 2 * bitmapPadding + 1;

                imageColumn.Image = unMarked;


                dtgrdvwFind.DataMember = "";
                dtgrdvwFind.Columns.Clear();

                dtgrdvwFind.Columns.Add("ROADID", "ROAD ID");

                dtgrdvwFind.Columns.Add(imageColumn);

                dtgrdvwFind.Columns.Add("ROADNAME", "ROAD NAME");
                dtgrdvwFind.Columns.Add("ROADCLASS", "ROAD CLASS");
                dtgrdvwFind.Columns.Add("PROVINCE", "PROVINCE");
                dtgrdvwFind.Columns.Add("DISTRICT", "DISTRICT");
                dtgrdvwFind.Columns.Add("DIVISION", "DIVISION");
                dtgrdvwFind.Columns.Add("LOCATION", "LOCATION");
                dtgrdvwFind.Columns.Add("SUBLOCATION", "SUB-LOCATION");

                dtgrdvwFind.ColumnHeadersVisible = true;
                dtgrdvwFind.AutoSize = true;

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }

        }

        public void FindByCustomerNumberPanel()
        {
            try
            {
                DataGridViewImageColumn imageColumn;

                Bitmap unMarked = blank;
                imageColumn = new DataGridViewImageColumn();

                //Add twice the padding for the left and 
                //right sides of the cell.
                imageColumn.Width = x.Width + 2 * bitmapPadding + 1;

                imageColumn.Image = unMarked;


                dtgrdvwFind.DataMember = "";
                dtgrdvwFind.Columns.Clear();

                dtgrdvwFind.Columns.Add("CUSTOMERNUMBER", "CUSTOMER ACCOUNT NUMBER");

                dtgrdvwFind.Columns.Add(imageColumn);


                dtgrdvwFind.Columns.Add("FIRSTNAME", "FIRSTNAME");
                dtgrdvwFind.Columns.Add("MIDDLENAME", "MIDDLENAME");
                dtgrdvwFind.Columns.Add("SURNAME", "SURNAME");
                dtgrdvwFind.Columns.Add("PINNUMBER", "PIN NUMBER");
                dtgrdvwFind.Columns.Add("PHYSICALADDRESS", "PHYSICAL ADDRESS");
                dtgrdvwFind.Columns.Add("UNIVERSALADDRESS", "UNIVERSALADDRESS");
                dtgrdvwFind.Columns.Add("PROVINCE", "PROVINCE");
                dtgrdvwFind.Columns.Add("DISTRICT", "DISTRICT");
                dtgrdvwFind.Columns.Add("DIVISION", "DIVISION");
                dtgrdvwFind.Columns.Add("LOCATION", "LOCATION");
                dtgrdvwFind.Columns.Add("SUBLOCATION", "SUB-LOCATION");
                dtgrdvwFind.Columns.Add("COORDINATES", "COORDINATES");

                dtgrdvwFind.ColumnHeadersVisible = true;
                dtgrdvwFind.AutoSize = true;

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }
        }

        public void FindByCustomerNamePanel()
        {
            try
            {
                DataGridViewImageColumn imageColumn;

                Bitmap unMarked = blank;
                imageColumn = new DataGridViewImageColumn();

                //Add twice the padding for the left and 
                //right sides of the cell.
                imageColumn.Width = x.Width + 2 * bitmapPadding + 1;

                imageColumn.Image = unMarked;


                dtgrdvwFind.DataMember = "";
                dtgrdvwFind.Columns.Clear();

                dtgrdvwFind.Columns.Add("CUSTOMERNUMBER", "CUSTOMER ACCOUNT NUMBER");

                dtgrdvwFind.Columns.Add(imageColumn);

                dtgrdvwFind.Columns.Add("FIRSTNAME", "FIRSTNAME");
                dtgrdvwFind.Columns.Add("MIDDLENAME", "MIDDLENAME");
                dtgrdvwFind.Columns.Add("SURNAME", "SURNAME");
                dtgrdvwFind.Columns.Add("PINNUMBER", "PIN NUMBER");
                dtgrdvwFind.Columns.Add("PHYSICALADDRESS", "PHYSICAL ADDRESS");
                dtgrdvwFind.Columns.Add("UNIVERSALADDRESS", "UNIVERSALADDRESS");
                dtgrdvwFind.Columns.Add("PROVINCE", "PROVINCE");
                dtgrdvwFind.Columns.Add("DISTRICT", "DISTRICT");
                dtgrdvwFind.Columns.Add("DIVISION", "DIVISION");
                dtgrdvwFind.Columns.Add("LOCATION", "LOCATION");
                dtgrdvwFind.Columns.Add("SUBLOCATION", "SUB-LOCATION");
                dtgrdvwFind.Columns.Add("COORDINATES", "COORDINATES");
                dtgrdvwFind.ColumnHeadersVisible = true;
                dtgrdvwFind.AutoSize = true;

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }

        }

        public void FindByPrivateCustomerSurnameNamePanel()
        {
            try
            {
                DataGridViewImageColumn imageColumn;

                Bitmap unMarked = blank;
                imageColumn = new DataGridViewImageColumn();

                //Add twice the padding for the left and 
                //right sides of the cell.
                imageColumn.Width = x.Width + 2 * bitmapPadding + 1;

                imageColumn.Image = unMarked;


                dtgrdvwFind.DataMember = "";
                dtgrdvwFind.Columns.Clear();

                dtgrdvwFind.Columns.Add("CUSTOMERNUMBER", "CUSTOMER ACCOUNT NUMBER");

                dtgrdvwFind.Columns.Add(imageColumn);

                dtgrdvwFind.Columns.Add("FIRSTNAME", "FIRSTNAME");
                dtgrdvwFind.Columns.Add("MIDDLENAME", "MIDDLENAME");
                dtgrdvwFind.Columns.Add("SURNAME", "SURNAME");
                dtgrdvwFind.Columns.Add("PINNUMBER", "PIN NUMBER");
                dtgrdvwFind.Columns.Add("PHYSICALADDRESS", "PHYSICAL ADDRESS");
                dtgrdvwFind.Columns.Add("UNIVERSALADDRESS", "UNIVERSALADDRESS");
                dtgrdvwFind.Columns.Add("PROVINCE", "PROVINCE");
                dtgrdvwFind.Columns.Add("DISTRICT", "DISTRICT");
                dtgrdvwFind.Columns.Add("DIVISION", "DIVISION");
                dtgrdvwFind.Columns.Add("LOCATION", "LOCATION");
                dtgrdvwFind.Columns.Add("SUBLOCATION", "SUB-LOCATION");
                dtgrdvwFind.Columns.Add("COORDINATES", "COORDINATES");

                dtgrdvwFind.ColumnHeadersVisible = true;
                dtgrdvwFind.AutoSize = true;

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }

        }

        public void FindByCompanyCustomerCompanyNamePanel()
        {
            try
            {
                DataGridViewImageColumn imageColumn;

                Bitmap unMarked = blank;
                imageColumn = new DataGridViewImageColumn();

                //Add twice the padding for the left and 
                //right sides of the cell.
                imageColumn.Width = x.Width + 2 * bitmapPadding + 1;

                imageColumn.Image = unMarked;


                dtgrdvwFind.DataMember = "";
                dtgrdvwFind.Columns.Clear();

                dtgrdvwFind.Columns.Add("CUSTOMERNUMBER", "CUSTOMER ACCOUNT NUMBER");

                dtgrdvwFind.Columns.Add(imageColumn);

                dtgrdvwFind.Columns.Add("COMPANYNAME", "COMPANY NAME");
                dtgrdvwFind.Columns.Add("VATNUMBER", "VAT NUMBER");
                dtgrdvwFind.Columns.Add("PINNUMBER", "PIN NUMBER");
                dtgrdvwFind.Columns.Add("PHYSICALADDRESS", "PHYSICAL ADDRESS");
                dtgrdvwFind.Columns.Add("UNIVERSALADDRESS", "UNIVERSALADDRESS");
                dtgrdvwFind.Columns.Add("PROVINCE", "PROVINCE");
                dtgrdvwFind.Columns.Add("DISTRICT", "DISTRICT");
                dtgrdvwFind.Columns.Add("DIVISION", "DIVISION");
                dtgrdvwFind.Columns.Add("LOCATION", "LOCATION");
                dtgrdvwFind.Columns.Add("SUBLOCATION", "SUB-LOCATION");
                dtgrdvwFind.Columns.Add("COORDINATES", "COORDINATES");



                dtgrdvwFind.ColumnHeadersVisible = true;
                dtgrdvwFind.AutoSize = true;

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }

        }

        public void FindByCustomerPINCodePanel()
        {
            try
            {
                DataGridViewImageColumn imageColumn;

                Bitmap unMarked = blank;
                imageColumn = new DataGridViewImageColumn();

                //Add twice the padding for the left and 
                //right sides of the cell.
                imageColumn.Width = x.Width + 2 * bitmapPadding + 1;

                imageColumn.Image = unMarked;


                dtgrdvwFind.DataMember = "";
                dtgrdvwFind.Columns.Clear();

                dtgrdvwFind.Columns.Add("CUSTOMERNUMBER", "CUSTOMER ACCOUNT NUMBER");

                dtgrdvwFind.Columns.Add(imageColumn);

                dtgrdvwFind.Columns.Add("CUSTOMERNAME", "CUSTOMER NAME");
                dtgrdvwFind.Columns.Add("VATNUMBER", "VAT NUMBER");
                dtgrdvwFind.Columns.Add("PINNUMBER", "PIN NUMBER");
                dtgrdvwFind.Columns.Add("PHYSICALADDRESS", "PHYSICAL ADDRESS");
                dtgrdvwFind.Columns.Add("UNIVERSALADDRESS", "UNIVERSALADDRESS");
                dtgrdvwFind.Columns.Add("PROVINCE", "PROVINCE");
                dtgrdvwFind.Columns.Add("DISTRICT", "DISTRICT");
                dtgrdvwFind.Columns.Add("DIVISION", "DIVISION");
                dtgrdvwFind.Columns.Add("LOCATION", "LOCATION");
                dtgrdvwFind.Columns.Add("SUBLOCATION", "SUB-LOCATION");
                dtgrdvwFind.Columns.Add("COORDINATES", "COORDINATES");


                dtgrdvwFind.ColumnHeadersVisible = true;
                dtgrdvwFind.AutoSize = true;

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }

        }

      

    }

}