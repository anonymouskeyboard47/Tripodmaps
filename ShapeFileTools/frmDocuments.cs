using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Globalization;

namespace Tripodmaps
{

    public partial class frmDocuments : Form
    {

        private string strCurrentOpenFile = "";
        private string errMessage = "";

        string strPath = @"E:\Pictures\Pictures\Cribwall\OasisVillas2";
        string substringDirectory = null;


        private TreeNode RootNode = new System.Windows.Forms.TreeNode("C:\\", 1, 0);
        private TreeNode OriginalNode = new System.Windows.Forms.TreeNode("C:\\", 1, 0);
        private TreeNode StartNode = null;
        private TreeNode EndNode = null;
        private TreeNode OldNode = null;

        private enum States { Idle, Move, Copy };
        private States CurrentState = States.Idle;


        public frmDocuments()
        {
            InitializeComponent();
        }

        private void frmDocuments_Load(object sender, EventArgs e)
        {

            ClearFolioForm();
            ClearVolumeForm();
            ClearDocumentFolderForm();

            LoadDocumentTypes(0);

            LoadDocumentFolders();

        }

        private void cmdDocumentFolderDeleteVolume_Click(object sender, EventArgs e)
        {

        }

        public void ArchiveVolume()
        {
            tabDocumentVolumes.Focus();
        }

        public void DocumentRegistration()
        {
            tabDocumentFolios.Focus();
        }

        private void frmDocuments_FormClosing(Object sender, FormClosingEventArgs e)
        {
            MainForm frmMain = (MainForm)Application.OpenForms["MainForm"];
            frmMain.CloseDocumentsForm();
        }

        private void cmdAddDocumentFolio_Click(object sender, EventArgs e)
        {
            ClearFolioForm();
        }

        private void cmdAddDocumentFolioImage_Click(object sender, EventArgs e)
        {
            LoadDocument();
        }

        private void pdfViewer_Load(object sender, EventArgs e)
        {

        }

        private void pdfViewer_DoubleClick(object sender, MouseEventArgs e)
        {
            EnlargeViewer();
        }

        private void cmdDocumentEnlargeViewer_Click(object sender, EventArgs e)
        {
            EnlargeViewer();
        }

        private void EnlargeViewer()
        {
            frmLargeDocumentViewer frmEnLargeDocument;

            try
            {
                if (!string.IsNullOrEmpty(strCurrentOpenFile))
                {
                    frmEnLargeDocument = new frmLargeDocumentViewer();
                    frmEnLargeDocument.LoadDocument(strCurrentOpenFile);
                    frmEnLargeDocument.ShowDialog(this);
                    
                }

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }
        }

        private void tlstrpEnlargeDocuments_Click(object sender, EventArgs e)
        {
            EnlargeViewer();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtDocumentDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtCustomerDateOfBirth_ValueChanged(object sender, EventArgs e)
        {

        }

        private void trvDocuments_MouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            cntxtmnuArchiveTree.Visible = false;

            if (e.Button == MouseButtons.Right)
            {
                if (trvDocuments.SelectedNode.Tag.ToString() == "1A")
                {
                    LoadArchiveContext();
                    cntxtmnuArchiveTree.Visible = true;
                }

                if (trvDocuments.SelectedNode.Tag.ToString() == "2A")
                {
                    cntxtmnuArchiveTree.Visible = false;
                }

                if (trvDocuments.SelectedNode.Tag.ToString() == "3A")
                {
                    cntxtmnuArchiveTree.Visible = false;
                }

                if (trvDocuments.SelectedNode.Tag.ToString() == "4A")
                {
                    //Manage Folders
                    cntxtmnuArchiveTree.Visible = true;
                }

                if (trvDocuments.SelectedNode.Tag.ToString() == "5A")
                {
                    //Manage Folders
                    cntxtmnuArchiveTree.Visible = true;
                }

                if (trvDocuments.SelectedNode.Tag.ToString() == "6A")
                {
                    cntxtmnuArchiveTree.Visible = false;

                }
            }
        }

        private void trvDocuments_AfterSelect(object sender, TreeViewEventArgs e)
        {
            

        }

        private void cmdDocumentVolumesAddVolumes_Click(object sender, EventArgs e)
        {
            ClearVolumeForm();
        }

        private void dtDocumentVolumeDateProduced_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtDocumentFolioNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmdDocumentFolderAddFolder_Click(object sender, EventArgs e)
        {
            ClearDocumentFolderForm();
        }


        #region "DocumentViewers"

        private void LoadDocument()
        {
            try
            {
                string strFilePath = "";
                strCurrentOpenFile = "";
                CultureInfo ci;

                ci = new CultureInfo("en-US");

                string strFilter = "Image Files (*.jpg,*.jpeg,*.png,*.bmp)|*.jpg;*.jpeg;*.png;*.bmp" +
                    "|Movie Files (*.avi, *.mpeg,*.mpg)|*.avi;*.mpeg;*.mpg |PDF|*.pdf";

                opnfldlgBuildings = new OpenFileDialog();

                opnfldlgBuildings.Filter = strFilter;

                opnfldlgBuildings.ShowDialog(this);
                strFilePath = opnfldlgBuildings.FileName;

                if (File.Exists(strFilePath))
                {
                    if (strFilePath.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
                    {
                        pdfViewer.Visible = true;
                        panel1.Visible = false;
                        picDocument.Visible = false;
                        pdfViewer.FileName = strFilePath;
                    }

                    if (strFilePath.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase))
                    {
                        pdfViewer.Visible = false;
                        panel1.Visible = true;
                        picDocument.Visible = true;
                        picDocument.Image = Image.FromFile(strFilePath);
                        picDocument.Size = picDocument.Image.Size;
                    }

                    if (strFilePath.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase))
                    {
                        pdfViewer.Visible = false;
                        panel1.Visible = true;
                        picDocument.Visible = true;
                        picDocument.Image = Image.FromFile(strFilePath);
                        picDocument.Size = picDocument.Image.Size;

                    }

                    if (strFilePath.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase))
                    {
                        pdfViewer.Visible = false;
                        panel1.Visible = true;
                        picDocument.Visible = true;
                        picDocument.Image = Image.FromFile(strFilePath);
                        picDocument.Size = picDocument.Image.Size;

                    }

                    if (strFilePath.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                    {
                        pdfViewer.Visible = false;
                        panel1.Visible = true;
                        picDocument.Visible = true;
                        picDocument.Image = Image.FromFile(strFilePath);
                        picDocument.Size = picDocument.Image.Size;

                    }

                    strCurrentOpenFile = strFilePath;
                }

            }

            catch (Exception ex)
            {

                errMessage = ex.Message + " : Source = " + ex.Source;

            }

            finally
            {
                opnfldlgBuildings = null;
            }
        }

        #endregion


        #region "FormManagement"


        private void ClearVolumeForm()
        {
            try
            {
                txtDocumentVolumeName.Text = "";
                txtDocumentVolumeDescription.Text = "";
                cmbDocumentVolumeLimitToSpecificType.DataSource = null;
                cmbDocumentVolumeProducedBy.Items.Clear();
                cmdDocumentVolumeFolderStatus.Items.Clear();

                dtDocumentVolumeDateCreated.Value = dtDocumentVolumeDateCreated.MinDate;
                dtDocumentVolumeDateProduced.Value = dtDocumentVolumeDateProduced.MinDate;

                txtDocumentVolumeName.Focus();

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

        }

        private void ClearFolioForm()
        {
            txtDocumentFolioNumber.Text = "";
            txtDocumentFolioName.Text = "";
            txtDocumentFolioPreviousVersionNumber.Text = "";
            txtDocumentFolioSerialNumber.Text = "";
            txtDocumentFolioSourceDescription.Text = "";
            txtDocumentFolioImageDescription.Text = "";
            cmbDocumentFolioDocumentType.DataSource = null;
            cmbDocumentFolioMimeType.DataSource = null;
            cmbDocumentFolioProducedBy.Text = "";

            dtDocumentFolioDateProduced.Value = dtDocumentFolioDateProduced.MinDate;
            picDocument.Image = null;
            pdfViewer.FileName = "";

            txtDocumentFolioSerialNumber.Focus();

        }

        private void ClearDocumentFolderForm()
        {

            try
            {
                txtDocumentFolderName.Text = "";
                txtDocumentFolderDescription.Text = "";
                cmbDocumentFolderLimitToDocumentType.DataSource = null;
                cmbDocumentFolderStatus.Items.Clear();
                cmbDocumentFolderProducedBy.Items.Clear();
                dtDocumentFolderDateProduced.Value = dtDocumentFolderDateProduced.MinDate;
                dtDocumentFolderDateCreated.Value = dtDocumentFolderDateCreated.MinDate;
            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }


        }

        private void LoadVolumeContext()
        {
            //Remove Folio Details
            mnuArchivingAddAnotherFolioVersion.Visible = false;
            mnuArchivingSubFoldersAddFolio.Visible = false;
            mnuArchivingSubFoldersAddFolioSeries.Visible = false;
            mnuArchivingSubFoldersImportFolderFolios.Visible = false;
            mnuArchivingSubFoldersDeleteFolio.Visible = false;
            mnuArchivingFolioSettings.Visible = false;
            mnuArchivingFoliosImportFoliosFoliosFromSubSystem.Visible = false;
            mnuArchivingManageFolioSecurity.Visible = false;
            mnuArchivingAddFolioToTripodShare.Visible = false;


            //SubFolders
            mnuArchivingSubFoldersAddNewSubFolder.Visible = false;
            mnuArchivingSubFoldersDeleteSubFolder.Visible = false;
            mnuArchivingSubFoldersManageSecurity.Visible = false;
            mnuArchivingSubFoldersSettings.Visible = false;



            //Volumes
            mnuArchivingVolumesAddVolumes.Visible = true;
            mnuArchivingVolumesAddNewSubFolders.Visible = true;
            mnuArchivingVolumesDeleteVolume.Visible = true;
            mnuArchivingVolumesImportVolumeStructure.Visible = true;
            mnuArchivingVolumesManageVolumeSecurity.Visible = true;
            mnuArchivingVolumesVolumeSettings.Visible = true;


            //Accounts
            mnuArchivingMyTripodAccount.Visible = true;
            mnuArchivingViewTripodShare.Visible = true;


            //Separators
            mnuArchivingSeparatorAccount.Visible = true;
            mnuArchivingSeparatorSubFolderFolio.Visible = false;
            mnuArchivingSeparatorVolumeSubFolder.Visible = false;


            //Archiving
            mnuArchivingViewUserReports.Visible = false;
            mnuArchivingManageSharedFolioSecurity.Visible = false;
            mnuArchivingCreateDailyQuotas.Visible = false;

            cntxtmnuArchiveTree.Show();


        }

        private void LoadArchiveContext()
        {
            //Remove Folio Details
            mnuArchivingAddAnotherFolioVersion.Visible = false;
            mnuArchivingSubFoldersAddFolio.Visible = false;
            mnuArchivingSubFoldersAddFolioSeries.Visible = false;
            mnuArchivingSubFoldersImportFolderFolios.Visible = false;
            mnuArchivingSubFoldersDeleteFolio.Visible = false;
            mnuArchivingFolioSettings.Visible = false;
            mnuArchivingFoliosImportFoliosFoliosFromSubSystem.Visible = false;
            mnuArchivingManageFolioSecurity.Visible = false;
            mnuArchivingAddFolioToTripodShare.Visible = false;


            //SubFolders
            mnuArchivingSubFoldersAddNewSubFolder.Visible = false;
            mnuArchivingSubFoldersDeleteSubFolder.Visible = false;
            mnuArchivingSubFoldersManageSecurity.Visible = false;
            mnuArchivingSubFoldersSettings.Visible = false;



            //Volumes
            mnuArchivingVolumesAddVolumes.Visible = true;
            mnuArchivingVolumesAddNewSubFolders.Visible = false;
            mnuArchivingVolumesDeleteVolume.Visible = false;
            mnuArchivingVolumesImportVolumeStructure.Visible = true;
            mnuArchivingVolumesManageVolumeSecurity.Visible = true;
            mnuArchivingVolumesVolumeSettings.Visible = true;


            //Accounts
            mnuArchivingMyTripodAccount.Visible = true;
            mnuArchivingViewTripodShare.Visible = true;


            //Separators
            mnuArchivingSeparatorAccount.Visible = true;
            mnuArchivingSeparatorSubFolderFolio.Visible = false;
            mnuArchivingSeparatorVolumeSubFolder.Visible = false;


            //Archiving
            mnuArchivingViewUserReports.Visible = false;
            mnuArchivingManageSharedFolioSecurity.Visible = false;
            mnuArchivingCreateDailyQuotas.Visible = false;

            cntxtmnuArchiveTree.Show();


        }

        private void LoadSubFolderContext()
        {

        }

        private void LoadFolioContextMenu()
        {
            
        }

        

        #region "TreeView"

        //Fills Tree Node with the details of the 
        private void PopulateTreeViewNodeFromPath(string strFolderPath, int trNodeID)
        {
            PopulateTreeView(strFolderPath, trvDocuments.Nodes[trNodeID]);
        }

        public void PopulateTreeView(string directoryValue, TreeNode parentNode)
        {
            string[] directoryArray = Directory.GetDirectories(directoryValue);

            try
            {
                if (directoryArray.Length != 0)
                {
                    foreach (string directory in directoryArray)
                    {
                        substringDirectory = directory.Substring(
                        directory.LastIndexOf('\\') + 1,
                        directory.Length - directory.LastIndexOf('\\') - 1);

                        TreeNode myNode = new TreeNode(substringDirectory);

                        parentNode.Nodes.Add(myNode);

                        PopulateTreeView(directory, myNode);
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                parentNode.Nodes.Add("Access denied");
            } // end catch
        }

        protected void trvDocuments_MouseUp(object sender, MouseEventArgs e)
        {
            CurrentState = States.Idle;
        }

        protected void trvDocuments_KeyUp(object sender, KeyEventArgs e)
        {
            if (CurrentState != States.Idle)
            {
                return; // precondition, can't change effect while moving
            }
            // restore to a move effect
            CurrentEffect = DragDropEffects.Move;
        }

        protected void trvDocuments_KeyDown(object sender, KeyEventArgs e)
        {
            if (CurrentState != States.Idle)
            {
                return; // precondition, can't change effect while moving
            }
            if (e.Control == true)
            {
                CurrentEffect = DragDropEffects.Copy;
            }
            else
            {
                CurrentEffect = DragDropEffects.Move;
            }
        }

        protected void trvDocuments_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            //		  e.UseDefaultCursors = false;
            //		  Bitmap bmp = imageList1.GetBitmap(2);
            //		  Graphics g = Graphics.FromImage(bmp);
            //		  Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            //		  this.Cursor.Draw(g, rect);
        }

        protected void trvDocuments_DragEnter(object sender, DragEventArgs e)
        {
            //				int KeyNum = e.KeyState.ToInt32();
            //			if (KeyNum == 9)
            //				{
            //					CurrentEffect = DragDropEffects.Copy;
            //				}
            //				else
            //				{
            //					CurrentEffect = DragDropEffects.Move;
            //				}
            e.Effect = CurrentEffect;

        }

        protected TreeNode FindTreeNode(int x, int y)
        {
            TreeNode aNode = this.RootNode;

            Point pt = new Point(x, y);
            pt = PointToClient(pt);

            while (aNode != null)
            {
                if (aNode.Bounds.Contains(pt))
                {
                    return aNode;
                }
                aNode = aNode.NextVisibleNode;
            }

            return null;

        }

        protected void trvDocuments_DragOver(object sender, DragEventArgs e)
        {
            //		((TreeView)sender).Cursor = Cursors.Hand;
            e.Effect = CurrentEffect;
            TreeNode aNode = FindTreeNode(e.X, e.Y);
            if (aNode != null)
            {
                if ((aNode.ImageIndex == 1) || (aNode.ImageIndex == 0))
                {
                    aNode.BackColor = Color.DarkBlue;
                    aNode.ForeColor = Color.White;
                    if ((OldNode != null) && (OldNode != aNode))
                    {
                        OldNode.BackColor = OriginalNode.BackColor;
                        OldNode.ForeColor = OriginalNode.ForeColor;
                    }
                    OldNode = aNode;
                }
            }
        }

        protected void trvDocuments_DragLeave(object sender, System.EventArgs e)
        {

        }

        protected void trvDocuments_ItemDrag(object sender, ItemDragEventArgs e)
        {
            TreeNode aNode = (TreeNode)e.Item;
            Bitmap bmp = (Bitmap)imgListArchiving.Images[2];
            if (aNode.ImageIndex == 2)
            {
                StartNode = aNode;
                //		   CurrentEffect = DragDropEffects.Move;
                if (CurrentEffect == DragDropEffects.Move)
                {
                    CurrentState = States.Move;
                }
                else
                {
                    CurrentState = States.Copy;
                }

                this.DoDragDrop(imgListArchiving.Images[aNode.ImageIndex], CurrentEffect);
            }
        }

        private void MoveFile(TreeNode Node1, TreeNode Node2)
        {
            string strdir1 = Node1.Parent.FullPath;
            string strdir2 = Node2.FullPath;
            strdir1 = strdir1 + "\\" + Node1.Text;
            strdir2 = strdir2 + "\\" + Node1.Text;
            Directory.Move(strdir1, strdir2);
            TreeNode aNode = new TreeNode(Node1.Text, 2, 2);
            Node1.Remove();
            Node2.Nodes.Add(aNode);
        }

        private void CopyFile(TreeNode Node1, TreeNode Node2)
        {
            string strdir1 = Node1.Parent.FullPath;
            string strdir2 = Node2.FullPath;
            strdir1 = strdir1 + "\\" + Node1.Text;
            strdir2 = strdir2 + "\\" + Node1.Text;
            File.Copy(strdir1, strdir2);
            TreeNode aNode = new TreeNode(Node1.Text, 2, 2);
            Node2.Nodes.Add(aNode);
        }

        protected void trvDocuments_DragDrop(object sender, DragEventArgs e)
        {
            // called last when mouse released during a drop
            bool movingFile = (CurrentEffect == DragDropEffects.Move);

            TreeNode DropNode = FindTreeNode(e.X, e.Y);
            CurrentState = States.Idle;
            CurrentEffect = DragDropEffects.Move;

            if (DropNode.ImageIndex != 2)
            {
                // it's a folder, drop the file
                if (movingFile)
                {
                    MoveFile(StartNode, DropNode);
                }
                else
                {
                    CopyFile(StartNode, DropNode);
                }
                this.Invalidate(new Region(this.ClientRectangle));
                trvDocuments.SelectedNode = DropNode;
            }

        }

        protected void trvDocuments_Resize(object sender, System.EventArgs e)
        {
            trvDocuments.SetBounds(0, 0, ClientRectangle.Width, ClientRectangle.Height);
        }

        private void LoadDocumentFolders()
        {
            try
            {
                PopulateTreeViewNodeFromPath(strPath,0);
            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }
        }


#endregion


        #endregion


        #region "DatabaseFormLoading"


        private void LoadDocumentTypes(long lArgDocumentTypeID)
        {
            TRIP_API.IMDocumentTypes imDocTypes = null;

            try
            {
                imDocTypes = new TRIP_API.IMDocumentTypes();
                imDocTypes.ReturnAllDocumentTypesIDAndDocumentTypeByDocumentTypeID(0, 0);

                if (imDocTypes.DocumentTypesDataSet != null)
                {
                    cmbDocumentVolumeLimitToSpecificType.DataSource = imDocTypes.DocumentTypesDataSet.Tables[0];
                    cmbDocumentVolumeLimitToSpecificType.DisplayMember = "DOCUMENTTYPE";
                    cmbDocumentFolderLimitToDocumentType.ValueMember = "DOCUMENTTYPEID";

                    cmbDocumentFolderLimitToDocumentType.DataSource = imDocTypes.DocumentTypesDataSet.Tables[0];
                    cmbDocumentFolderLimitToDocumentType.DisplayMember = "DOCUMENTTYPE";
                    cmbDocumentFolderLimitToDocumentType.ValueMember = "DOCUMENTTYPEID";

                    cmbDocumentFolioDocumentType.DataSource = imDocTypes.DocumentTypesDataSet.Tables[0];
                    cmbDocumentFolioDocumentType.DisplayMember = "DOCUMENTTYPE";
                    cmbDocumentFolioDocumentType.ValueMember = "DOCUMENTTYPEID";


                    
                    

                }

                if (lArgDocumentTypeID > -1)
                {
                    cmbDocumentFolderLimitToDocumentType.SelectedValue = lArgDocumentTypeID;
                }

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;

            }

            finally
            {
                if (imDocTypes != null)
                {
                    imDocTypes = null;
                }
            }

        }

        private void LoadDocumentVolumeStatusTypes()
        {

        }



        #endregion


        private void mnuArchivingVolumesAddVolumes_Click(object sender, EventArgs e)
        {
            ClearVolumeForm();
            ClearFolioForm();
            ClearDocumentFolderForm();

            tabDocuments.SelectedTab = tabDocumentVolumes;
            tabDocumentVolumes.Focus();
            txtDocumentVolumeName.Focus();
        }

        private void cmbDocumentVolumeRootFolder_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



    }
}
