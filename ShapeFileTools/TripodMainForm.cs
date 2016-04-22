using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
using WeifenLuo.WinFormsUI.Docking;
using Tripodmaps.Customization;
using NpgsqlTypes;
using Tripodmaps.Reader;
using System.Xml;

namespace Tripodmaps
{
    public partial class TripodMainForm : Form
    {

        private bool m_bSaveLayout = true;
        private DeserializeDockContent m_deserializeDockContent;
        private DummySolutionExplorer m_solutionExplorer = new DummySolutionExplorer();
        private DummyPropertyWindow m_propertyWindow = new DummyPropertyWindow();
        private DummyToolbox m_toolbox = new DummyToolbox();
        //private DummyOutputWindow m_outputWindow = new DummyOutputWindow();
        private frmSearch m_outputWindow = new frmSearch();
        private SearchResultList m_taskList = new SearchResultList();

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
        


        #region FormInterfaceMethods


        public TripodMainForm(string strLoadDefaultProjectPath)
        {
            try
            {
                InitializeComponent();

                //showRightToLeft.Checked = (RightToLeft == RightToLeft.Yes);
                //RightToLeftLayout = showRightToLeft.Checked;
                m_solutionExplorer = new DummySolutionExplorer();
                m_solutionExplorer.RightToLeftLayout = RightToLeftLayout;
                m_deserializeDockContent = new DeserializeDockContent(GetContentFromPersistString);

                Tripodmaps.Reader.ShapeFile.UseMercatorProjection = false;
                Tripodmaps.Reader.ShapeFile.UseMercatorProjection = true;
                Tripodmaps.Reader.ShapeFile.MapFilesInMemory = true;

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

        public void CloseBuildingForm()
        {
            BuildingForm = null;
        }

        public void CloseFindForm()
        {
            FindDetails = null;
        }

        public void CloseDocumentsForm()
        {
            DocumentsForm = null;
        }


        #endregion



        #region "GISInterface"

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

        private void tsBtnZoomIn_Click(object sender, EventArgs e)
        {
            ZoomIn();
        }

        private void tsBtnZoomOut_Click(object sender, EventArgs e)
        {
            ZoomOut();
        }

        #endregion



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

        private void sfMap1_Load(object sender, EventArgs e)
        {

        }

        private void sfMap1_ClientSizeChanged(object sender, EventArgs e)
        {
            UpdateVisibleAreaLabel();
        }

        private void sfMap1_ZoomLevelChanged(object sender, EventArgs args)
        {
            //this.tsLabelCurrentZoom.Text = sfMap1.ZoomLevel.ToString("0.00000");
            UpdateVisibleAreaLabel();
        }

        private void sfMap1_MouseClick(object sender, MouseEventArgs e)
        {
            //txtBuilingAddressPOICoordinates.Text = sfMap1.PixelCoordToGisPoint(e.Location).X.ToString() +
            //    "," + sfMap1.PixelCoordToGisPoint(e.Location).Y.ToString();
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



        #region Methods



        private IDockContent FindDocument(string text)
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                foreach (Form form in MdiChildren)
                    if (form.Text == text)
                        return form as IDockContent;

                return null;
            }
            else
            {
                foreach (IDockContent content in dockPanel.Documents)
                    if (content.DockHandler.TabText == text)
                        return content;

                return null;
            }
        }

        private DummyDoc CreateNewDocument()
        {
            DummyDoc dummyDoc = new DummyDoc();

            int count = 1;
            //string text = "C:\\MADFDKAJ\\ADAKFJASD\\ADFKDSAKFJASD\\ASDFKASDFJASDF\\ASDFIJADSFJ\\ASDFKDFDA" + count.ToString();
            string text = "Document" + count.ToString();
            while (FindDocument(text) != null)
            {
                count++;
                //text = "C:\\MADFDKAJ\\ADAKFJASD\\ADFKDSAKFJASD\\ASDFKASDFJASDF\\ASDFIJADSFJ\\ASDFKDFDA" + count.ToString();
                text = "Document" + count.ToString();
            }
            dummyDoc.Text = text;
            return dummyDoc;
        }

        private DummyDoc CreateNewDocument(string text)
        {
            DummyDoc dummyDoc = new DummyDoc();
            dummyDoc.Text = text;
            return dummyDoc;
        }

        private void CloseAllDocuments()
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                foreach (Form form in MdiChildren)
                    form.Close();
            }
            else
            {
                for (int index = dockPanel.Contents.Count - 1; index >= 0; index--)
                {
                    if (dockPanel.Contents[index] is IDockContent)
                    {
                        IDockContent content = (IDockContent)dockPanel.Contents[index];
                        content.DockHandler.Close();
                    }
                }
            }
        }

        private IDockContent GetContentFromPersistString(string persistString)
        {
            if (persistString == typeof(DummySolutionExplorer).ToString())
                return m_solutionExplorer;
            else if (persistString == typeof(DummyPropertyWindow).ToString())
                return m_propertyWindow;
            else if (persistString == typeof(DummyToolbox).ToString())
                return m_toolbox;
            else if (persistString == typeof(DummyOutputWindow).ToString())
                return m_outputWindow;
            else if (persistString == typeof(SearchResultList).ToString())
                return m_taskList;
            else
            {
                // DummyDoc overrides GetPersistString to add extra information into persistString.
                // Any DockContent may override this value to add any needed information for deserialization.

                string[] parsedStrings = persistString.Split(new char[] { ',' });
                if (parsedStrings.Length != 3)
                    return null;

                if (parsedStrings[0] != typeof(DummyDoc).ToString())
                    return null;

                DummyDoc dummyDoc = new DummyDoc();
                if (parsedStrings[1] != string.Empty)
                    dummyDoc.FileName = parsedStrings[1];
                if (parsedStrings[2] != string.Empty)
                    dummyDoc.Text = parsedStrings[2];

                return dummyDoc;
            }
        }

        private void CloseAllContents()
        {
            // we don't want to create another instance of tool window, set DockPanel to null
            m_solutionExplorer.DockPanel = null;
            m_propertyWindow.DockPanel = null;
            m_toolbox.DockPanel = null;
            m_outputWindow.DockPanel = null;
            m_taskList.DockPanel = null;

            // Close all other document windows
            CloseAllDocuments();
        }

        private void SetSchema(object sender, System.EventArgs e)
        {
            CloseAllContents();

            //if (sender == menuItemSchemaVS2005)
            //    Extender.SetSchema(dockPanel, Extender.Schema.VS2005);
            //else if (sender == menuItemSchemaVS2003)
            //    Extender.SetSchema(dockPanel, Extender.Schema.VS2003);

            //menuItemSchemaVS2005.Checked = (sender == menuItemSchemaVS2005);
            //menuItemSchemaVS2003.Checked = (sender == menuItemSchemaVS2003);
        }

        private void SetDocumentStyle(object sender, System.EventArgs e)
        {
            //DocumentStyle oldStyle = dockPanel.DocumentStyle;
            //DocumentStyle newStyle;
            //if (sender == menuItemDockingMdi)
            //    newStyle = DocumentStyle.DockingMdi;
            //else if (sender == menuItemDockingWindow)
            //    newStyle = DocumentStyle.DockingWindow;
            //else if (sender == menuItemDockingSdi)
            //    newStyle = DocumentStyle.DockingSdi;
            //else
            //    newStyle = DocumentStyle.SystemMdi;

            //if (oldStyle == newStyle)
            //    return;

            //if (oldStyle == DocumentStyle.SystemMdi || newStyle == DocumentStyle.SystemMdi)
            //    CloseAllDocuments();

            //dockPanel.DocumentStyle = newStyle;
            //menuItemDockingMdi.Checked = (newStyle == DocumentStyle.DockingMdi);
            //menuItemDockingWindow.Checked = (newStyle == DocumentStyle.DockingWindow);
            //menuItemDockingSdi.Checked = (newStyle == DocumentStyle.DockingSdi);
            //menuItemSystemMdi.Checked = (newStyle == DocumentStyle.SystemMdi);
            //menuItemLayoutByCode.Enabled = (newStyle != DocumentStyle.SystemMdi);
            //menuItemLayoutByXml.Enabled = (newStyle != DocumentStyle.SystemMdi);
            //toolBarButtonLayoutByCode.Enabled = (newStyle != DocumentStyle.SystemMdi);
            //toolBarButtonLayoutByXml.Enabled = (newStyle != DocumentStyle.SystemMdi);
        }

        private void SetDockPanelSkinOptions(bool isChecked)
        {
            if (isChecked)
            {
                // All of these options may be set in the designer.
                // This is not a complete list of possible options available in the skin.

                AutoHideStripSkin autoHideSkin = new AutoHideStripSkin();
                autoHideSkin.DockStripGradient.StartColor = Color.AliceBlue;
                autoHideSkin.DockStripGradient.EndColor = Color.Blue;
                autoHideSkin.DockStripGradient.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
                autoHideSkin.TabGradient.StartColor = SystemColors.Control;
                autoHideSkin.TabGradient.EndColor = SystemColors.ControlDark;
                autoHideSkin.TabGradient.TextColor = SystemColors.ControlText;
                autoHideSkin.TextFont = new Font("Showcard Gothic", 10);

                dockPanel.Skin.AutoHideStripSkin = autoHideSkin;

                DockPaneStripSkin dockPaneSkin = new DockPaneStripSkin();
                dockPaneSkin.DocumentGradient.DockStripGradient.StartColor = Color.Red;
                dockPaneSkin.DocumentGradient.DockStripGradient.EndColor = Color.Pink;

                dockPaneSkin.DocumentGradient.ActiveTabGradient.StartColor = Color.Green;
                dockPaneSkin.DocumentGradient.ActiveTabGradient.EndColor = Color.Green;
                dockPaneSkin.DocumentGradient.ActiveTabGradient.TextColor = Color.White;

                dockPaneSkin.DocumentGradient.InactiveTabGradient.StartColor = Color.Gray;
                dockPaneSkin.DocumentGradient.InactiveTabGradient.EndColor = Color.Gray;
                dockPaneSkin.DocumentGradient.InactiveTabGradient.TextColor = Color.Black;

                dockPaneSkin.TextFont = new Font("SketchFlow Print", 10);

                dockPanel.Skin.DockPaneStripSkin = dockPaneSkin;
            }
            else
            {
                dockPanel.Skin = new DockPanelSkin();
            }

            menuItemLayoutByXml_Click(menuItemLayoutByXml, EventArgs.Empty);
        }



        #endregion



        #region Event Handlers



        private void menuItemExit_Click(object sender, System.EventArgs e)
        {
            if (Application.OpenForms.Count > 1)
            {
                DialogResult rs = MessageBox.Show("Do you want to Exit Tripodmaps?", "Exit Tripodmaps?", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                Close();

            }
            
            
        }

        private void menuItemSolutionExplorer_Click(object sender, System.EventArgs e)
        {
            m_solutionExplorer.Show(dockPanel);
        }

        private void menuItemPropertyWindow_Click(object sender, System.EventArgs e)
        {
            m_propertyWindow.Show(dockPanel);
        }

        private void menuItemToolbox_Click(object sender, System.EventArgs e)
        {
            m_toolbox.Show(dockPanel);
        }

        private void menuItemOutputWindow_Click(object sender, System.EventArgs e)
        {
            m_outputWindow.Show(dockPanel);
        }

        private void menuItemTaskList_Click(object sender, System.EventArgs e)
        {
            m_taskList.Show(dockPanel);
        }

        private void menuItemAbout_Click(object sender, System.EventArgs e)
        {
            AboutDialog aboutDialog = new AboutDialog();
            aboutDialog.ShowDialog(this);
        }

        private void menuItemNew_Click(object sender, System.EventArgs e)
        {
            DummyDoc dummyDoc = CreateNewDocument();
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                dummyDoc.MdiParent = this;
                dummyDoc.Show();
            }
            else
                dummyDoc.Show(dockPanel);
        }

        private void menuItemOpen_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            openFile.InitialDirectory = Application.ExecutablePath;
            openFile.Filter = "rtf files (*.rtf)|*.rtf|txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFile.FilterIndex = 1;
            openFile.RestoreDirectory = true;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string fullName = openFile.FileName;
                string fileName = Path.GetFileName(fullName);

                if (FindDocument(fileName) != null)
                {
                    MessageBox.Show("The document: " + fileName + " has already opened!");
                    return;
                }

                DummyDoc dummyDoc = new DummyDoc();
                dummyDoc.Text = fileName;
                if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
                {
                    dummyDoc.MdiParent = this;
                    dummyDoc.Show();
                }
                else
                    dummyDoc.Show(dockPanel);
                try
                {
                    dummyDoc.FileName = fullName;
                }
                catch (Exception exception)
                {
                    dummyDoc.Close();
                    MessageBox.Show(exception.Message);
                }

            }
        }

        private void menuItemFile_Popup(object sender, System.EventArgs e)
        {
            //if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            //{
            //    menuItemClose.Enabled = menuItemCloseAll.Enabled = (ActiveMdiChild != null);
            //}
            //else
            //{
            //    menuItemClose.Enabled = (dockPanel.ActiveDocument != null);
            //    menuItemCloseAll.Enabled = (dockPanel.DocumentsCount > 0);
            //}
        }

        private void menuItemClose_Click(object sender, System.EventArgs e)
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
                ActiveMdiChild.Close();
            else if (dockPanel.ActiveDocument != null)
                dockPanel.ActiveDocument.DockHandler.Close();
        }

        private void menuItemCloseAll_Click(object sender, System.EventArgs e)
        {
            CloseAllDocuments();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            try
            {
                string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");

                if (File.Exists(configFile))
                    dockPanel.LoadFromXml(configFile, m_deserializeDockContent);

                FindParcelShapeFile("Plots.shp");
                FindBuildingShapeFile("rtk.shp");
                FindPointsShapeFile("pointsofinterest.shp");
                sfMap1.Show();
            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }
        }

        private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sfMap1 = null;
            string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");
            if (m_bSaveLayout)
                dockPanel.SaveAsXml(configFile);
            else if (File.Exists(configFile))
                File.Delete(configFile);
        }

        private void menuItemTools_Popup(object sender, System.EventArgs e)
        {
            //menuItemLockLayout.Checked = !this.dockPanel.AllowEndUserDocking;
        }

        private void menuItemLockLayout_Click(object sender, System.EventArgs e)
        {
            dockPanel.AllowEndUserDocking = !dockPanel.AllowEndUserDocking;
        }

        private void menuItemLayoutByCode_Click(object sender, System.EventArgs e)
        {
            dockPanel.SuspendLayout(true);

            CloseAllDocuments();

            m_solutionExplorer = new DummySolutionExplorer();
            m_propertyWindow = new DummyPropertyWindow();
            m_toolbox = new DummyToolbox();
            m_outputWindow = new frmSearch();
            m_outputWindow.Size = new Size(800, 146);
            m_taskList = new SearchResultList();

            m_solutionExplorer.Show(dockPanel, DockState.DockRight);
            m_propertyWindow.Show(m_solutionExplorer.Pane, m_solutionExplorer);
            m_toolbox.Show(dockPanel, new Rectangle(98, 133, 200, 383));
            m_outputWindow.Show(m_solutionExplorer.Pane, DockAlignment.Bottom, 0.35);
            m_taskList.Show(m_toolbox.Pane, DockAlignment.Left, 0.4);

            dockPanel.ResumeLayout(true, true);
        }

        private void LayoutAsCode()
        {
            dockPanel.SuspendLayout(true);

            CloseAllDocuments();

            m_solutionExplorer = new DummySolutionExplorer();
            m_propertyWindow = new DummyPropertyWindow();
            m_toolbox = new DummyToolbox();
            m_outputWindow = new frmSearch();
            m_outputWindow.Size = new Size(800, 146);
            m_taskList = new SearchResultList();

            m_solutionExplorer.Show(dockPanel, DockState.DockRight);
            m_propertyWindow.Show(m_solutionExplorer.Pane, m_solutionExplorer);
            m_toolbox.Show(dockPanel, new Rectangle(98, 133, 200, 383));
            m_outputWindow.Show(m_solutionExplorer.Pane, DockAlignment.Bottom, 0.35);
            m_taskList.Show(m_toolbox.Pane, DockAlignment.Left, 0.4);

            dockPanel.ResumeLayout(true, true);
        }

        private void menuItemLayoutByXml_Click(object sender, System.EventArgs e)
        {
            dockPanel.SuspendLayout(true);

            // In order to load layout from XML, we need to close all the DockContents
            CloseAllContents();

            Assembly assembly = Assembly.GetAssembly(typeof(TripodMainForm));
            Stream xmlStream = assembly.GetManifestResourceStream("DockSample.Resources.DockPanel.xml");
            dockPanel.LoadFromXml(xmlStream, m_deserializeDockContent);
            xmlStream.Close();

            dockPanel.ResumeLayout(true, true);
        }

        private void menuItemCloseAllButThisOne_Click(object sender, System.EventArgs e)
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                Form activeMdi = ActiveMdiChild;
                foreach (Form form in MdiChildren)
                {
                    if (form != activeMdi)
                        form.Close();
                }
            }
            else
            {
                foreach (IDockContent document in dockPanel.DocumentsToArray())
                {
                    if (!document.DockHandler.IsActivated)
                        document.DockHandler.Close();
                }
            }
        }

        private void menuItemShowDocumentIcon_Click(object sender, System.EventArgs e)
        {
            //dockPanel.ShowDocumentIcon = menuItemShowDocumentIcon.Checked = !menuItemShowDocumentIcon.Checked;
        }

        private void showRightToLeft_Click(object sender, EventArgs e)
        {
            
        }

        private void exitWithoutSavingLayout_Click(object sender, EventArgs e)
        {
            m_bSaveLayout = false;
            Close();
            m_bSaveLayout = true;
        }



        #endregion
        


        private void toolBarButtonDockPanelSkinDemo_Click(object sender, EventArgs e)
        {

        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


       


    }
}