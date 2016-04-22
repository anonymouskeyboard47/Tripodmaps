namespace Tripodmaps
{
    partial class frmDocuments
    {
        
        private System.Windows.Forms.DragDropEffects CurrentEffect = System.Windows.Forms.DragDropEffects.Move;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("My Local Archive", 4, 4);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Archive");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("My Shared Folios", 8, 8);
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("My Archive Online", 1, 1, new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("From Other TripodUsers", 9, 9);
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("TripodShare - Online Archive", 6, 6, new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDocuments));
            this.tlstrpBuildingTypes = new System.Windows.Forms.ToolStrip();
            this.tlstrpbtnNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tlstrpbtnFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tlstrpbtnSave = new System.Windows.Forms.ToolStripButton();
            this.tlstrpbtnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tlstrpbtnReports = new System.Windows.Forms.ToolStripButton();
            this.tlstrpbtnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tlstrpbtnFirst = new System.Windows.Forms.ToolStripButton();
            this.tlstrpbtnPrevious = new System.Windows.Forms.ToolStripButton();
            this.tlstrpbtnNext = new System.Windows.Forms.ToolStripButton();
            this.tlstrpbtnLast = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tlstrpbtnTools = new System.Windows.Forms.ToolStripButton();
            this.tlstrpbtnHelp = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.trvDocuments = new System.Windows.Forms.TreeView();
            this.imgListArchiving = new System.Windows.Forms.ImageList(this.components);
            this.tabDocuments = new System.Windows.Forms.TabControl();
            this.tabDocumentFolios = new System.Windows.Forms.TabPage();
            this.cntxtmnuArchiveTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuArchivingViewTripodShare = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArchivingMyTripodAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArchivingSeparatorAccount = new System.Windows.Forms.ToolStripSeparator();
            this.mnuArchivingVolumesAddVolumes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArchivingVolumesManageVolumeSecurity = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArchivingVolumesVolumeSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArchivingVolumesAddNewSubFolders = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArchivingVolumesImportVolumeStructure = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArchivingVolumesDeleteVolume = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArchivingSeparatorVolumeSubFolder = new System.Windows.Forms.ToolStripSeparator();
            this.mnuArchivingSubFoldersAddNewSubFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArchivingSubFoldersManageSecurity = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArchivingSubFoldersImportFolderFolios = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArchivingSubFoldersSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArchivingSubFoldersDeleteSubFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArchivingSeparatorSubFolderFolio = new System.Windows.Forms.ToolStripSeparator();
            this.mnuArchivingSubFoldersAddFolio = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArchivingManageFolioSecurity = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArchivingAddFolioToTripodShare = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArchivingSubFoldersAddFolioSeries = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArchivingAddAnotherFolioVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArchivingFoliosImportFoliosFoliosFromSubSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArchivingFolioSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArchivingSubFoldersDeleteFolio = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuArchivingViewUserReports = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArchivingManageSharedFolioSecurity = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArchivingCreateDailyQuotas = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picDocument = new System.Windows.Forms.PictureBox();
            this.cntxtmnuDocumentViewer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tlstrpEnlargeDocuments = new System.Windows.Forms.ToolStripMenuItem();
            this.txtDocumentFolioName = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.cmdDocumentFolioEnlargeViewer = new System.Windows.Forms.Button();
            this.pdfViewer = new PDFView.PDFViewer();
            this.txtDocumentFolioImageDescription = new System.Windows.Forms.TextBox();
            this.txtDocumentFolioPreviousVersionNumber = new System.Windows.Forms.TextBox();
            this.txtDocumentFolioSourceDescription = new System.Windows.Forms.TextBox();
            this.txtDocumentFolioNumber = new System.Windows.Forms.TextBox();
            this.txtDocumentFolioDescription = new System.Windows.Forms.TextBox();
            this.txtDocumentFolioSerialNumber = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.cmdSaveDocumentFolio = new System.Windows.Forms.Button();
            this.cmdDeleteDocumentFolio = new System.Windows.Forms.Button();
            this.cmdAddDocumentFolio = new System.Windows.Forms.Button();
            this.cmdLastDocumentFolio = new System.Windows.Forms.Button();
            this.cmdNextDocumentFolio = new System.Windows.Forms.Button();
            this.cmdPreviousDocumentFolio = new System.Windows.Forms.Button();
            this.cmdFirstDocumentFolio = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.cmbDocumentFolioProducedBy = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbDocumentFolioDocumentType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtDocumentFolioDateProduced = new System.Windows.Forms.DateTimePicker();
            this.cmdSaveDocumentFolioImage = new System.Windows.Forms.Button();
            this.cmdDeleteDocumentFolioImage = new System.Windows.Forms.Button();
            this.cmdAddDocumentFolioImage = new System.Windows.Forms.Button();
            this.cmdLastDocumentFolioImage = new System.Windows.Forms.Button();
            this.cmdNextDocumentFolioImage = new System.Windows.Forms.Button();
            this.cmdPreviousDocumentFolioImage = new System.Windows.Forms.Button();
            this.cmdFirstDocumentFolioImage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbDocumentFolioMimeType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabMetadata = new System.Windows.Forms.TabPage();
            this.cmdDocumentMetadataSaveMetadata = new System.Windows.Forms.Button();
            this.cmdDocumentMetadataDeleteMetadata = new System.Windows.Forms.Button();
            this.cmdDocumentMetadataAddMetadata = new System.Windows.Forms.Button();
            this.cmdDocumentMetadataLastMetadata = new System.Windows.Forms.Button();
            this.cmdDocumentMetadataNextMetadata = new System.Windows.Forms.Button();
            this.cmbDocumentMetadataProducedBy = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.dtDocumentMetadataDateCreated = new System.Windows.Forms.DateTimePicker();
            this.label24 = new System.Windows.Forms.Label();
            this.cmbDocumentMetadataAddedBy = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.cmbDocumentMetadataType = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDocumentMetadataName = new System.Windows.Forms.TextBox();
            this.txtDocumentMetadataDescription = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.dtDocumentMetadataDateWhenProduced = new System.Windows.Forms.DateTimePicker();
            this.label29 = new System.Windows.Forms.Label();
            this.cmdDocumentMetadataPreviousMetadata = new System.Windows.Forms.Button();
            this.cmdDocumentMetadataFirstMetadata = new System.Windows.Forms.Button();
            this.tabDocumentFolders = new System.Windows.Forms.TabPage();
            this.cmbDocumentFolderProducedBy = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.dtDocumentFolderDateCreated = new System.Windows.Forms.DateTimePicker();
            this.dtDocumentFolderDateProduced = new System.Windows.Forms.DateTimePicker();
            this.label30 = new System.Windows.Forms.Label();
            this.txtDocumentFolderDescription = new System.Windows.Forms.TextBox();
            this.txtDocumentFolderName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDocumentFolderStatus = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDocumentFolderLimitToDocumentType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdDocumentFolderSaveFolder = new System.Windows.Forms.Button();
            this.cmdDocumentFolderDeleteFolder = new System.Windows.Forms.Button();
            this.cmdDocumentFolderAddFolder = new System.Windows.Forms.Button();
            this.cmdDocumentFolderLastFolder = new System.Windows.Forms.Button();
            this.cmdDocumentFolderNextFolder = new System.Windows.Forms.Button();
            this.cmdDocumentFolderPreviousFolder = new System.Windows.Forms.Button();
            this.cmdDocumentFolderFirstFolder = new System.Windows.Forms.Button();
            this.tabDocumentVolumes = new System.Windows.Forms.TabPage();
            this.cmbDocumentVolumeProducedBy = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.dtDocumentVolumeDateCreated = new System.Windows.Forms.DateTimePicker();
            this.dtDocumentVolumeDateProduced = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtDocumentVolumeDescription = new System.Windows.Forms.TextBox();
            this.txtDocumentVolumeName = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.cmdDocumentVolumeFolderStatus = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cmbDocumentVolumeLimitToSpecificType = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cmdDocumentVolumesSaveVolume = new System.Windows.Forms.Button();
            this.cmdDocumentVolumesDeleteVolume = new System.Windows.Forms.Button();
            this.cmdDocumentVolumesAddVolumes = new System.Windows.Forms.Button();
            this.cmdDocumentVolumeLastVolume = new System.Windows.Forms.Button();
            this.cmdDocumentVolumeNextVolume = new System.Windows.Forms.Button();
            this.cmdDocumentVolumePreviousVolume = new System.Windows.Forms.Button();
            this.cmdDocumentVolumeFirstVolume = new System.Windows.Forms.Button();
            this.tabSecurity = new System.Windows.Forms.TabPage();
            this.grpArchiveSecurity = new System.Windows.Forms.GroupBox();
            this.tltpDocuments = new System.Windows.Forms.ToolTip(this.components);
            this.opnfldlgBuildings = new System.Windows.Forms.OpenFileDialog();
            this.imgListUsers = new System.Windows.Forms.ImageList(this.components);
            this.tlstrpBuildingTypes.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabDocuments.SuspendLayout();
            this.tabDocumentFolios.SuspendLayout();
            this.cntxtmnuArchiveTree.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDocument)).BeginInit();
            this.cntxtmnuDocumentViewer.SuspendLayout();
            this.tabMetadata.SuspendLayout();
            this.tabDocumentFolders.SuspendLayout();
            this.tabDocumentVolumes.SuspendLayout();
            this.tabSecurity.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlstrpBuildingTypes
            // 
            this.tlstrpBuildingTypes.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlstrpBuildingTypes.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlstrpBuildingTypes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlstrpbtnNew,
            this.toolStripSeparator5,
            this.tlstrpbtnFind,
            this.toolStripSeparator2,
            this.tlstrpbtnSave,
            this.tlstrpbtnDelete,
            this.toolStripSeparator6,
            this.tlstrpbtnReports,
            this.tlstrpbtnPrint,
            this.toolStripSeparator7,
            this.tlstrpbtnFirst,
            this.tlstrpbtnPrevious,
            this.tlstrpbtnNext,
            this.tlstrpbtnLast,
            this.toolStripSeparator8,
            this.tlstrpbtnTools,
            this.tlstrpbtnHelp});
            this.tlstrpBuildingTypes.Location = new System.Drawing.Point(0, 0);
            this.tlstrpBuildingTypes.Name = "tlstrpBuildingTypes";
            this.tlstrpBuildingTypes.Size = new System.Drawing.Size(991, 25);
            this.tlstrpBuildingTypes.TabIndex = 54;
            this.tlstrpBuildingTypes.Text = "Customer Main Menu";
            // 
            // tlstrpbtnNew
            // 
            this.tlstrpbtnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpbtnNew.Image = global::Tripodmaps.Properties.Resources.icon_new;
            this.tlstrpbtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpbtnNew.Name = "tlstrpbtnNew";
            this.tlstrpbtnNew.Size = new System.Drawing.Size(23, 22);
            this.tlstrpbtnNew.ToolTipText = "New";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tlstrpbtnFind
            // 
            this.tlstrpbtnFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpbtnFind.Image = global::Tripodmaps.Properties.Resources.Find_icon2424;
            this.tlstrpbtnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpbtnFind.Name = "tlstrpbtnFind";
            this.tlstrpbtnFind.Size = new System.Drawing.Size(23, 22);
            this.tlstrpbtnFind.Text = "Find Item In Archive";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tlstrpbtnSave
            // 
            this.tlstrpbtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpbtnSave.Image = global::Tripodmaps.Properties.Resources.b_save;
            this.tlstrpbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpbtnSave.Name = "tlstrpbtnSave";
            this.tlstrpbtnSave.Size = new System.Drawing.Size(23, 22);
            this.tlstrpbtnSave.ToolTipText = "Save";
            // 
            // tlstrpbtnDelete
            // 
            this.tlstrpbtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpbtnDelete.Image = global::Tripodmaps.Properties.Resources.b_drop;
            this.tlstrpbtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpbtnDelete.Name = "tlstrpbtnDelete";
            this.tlstrpbtnDelete.Size = new System.Drawing.Size(23, 22);
            this.tlstrpbtnDelete.ToolTipText = "Delete";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // tlstrpbtnReports
            // 
            this.tlstrpbtnReports.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpbtnReports.Image = global::Tripodmaps.Properties.Resources.PIE_DIAGRAM;
            this.tlstrpbtnReports.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpbtnReports.Name = "tlstrpbtnReports";
            this.tlstrpbtnReports.Size = new System.Drawing.Size(23, 22);
            this.tlstrpbtnReports.ToolTipText = "Archive Reports";
            // 
            // tlstrpbtnPrint
            // 
            this.tlstrpbtnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpbtnPrint.Image = global::Tripodmaps.Properties.Resources.b_print;
            this.tlstrpbtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpbtnPrint.Name = "tlstrpbtnPrint";
            this.tlstrpbtnPrint.Size = new System.Drawing.Size(23, 22);
            this.tlstrpbtnPrint.ToolTipText = "Print Selected Contents in Volume";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // tlstrpbtnFirst
            // 
            this.tlstrpbtnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpbtnFirst.Image = global::Tripodmaps.Properties.Resources.b_firstpage;
            this.tlstrpbtnFirst.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tlstrpbtnFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpbtnFirst.Name = "tlstrpbtnFirst";
            this.tlstrpbtnFirst.Size = new System.Drawing.Size(23, 22);
            this.tlstrpbtnFirst.ToolTipText = "First";
            // 
            // tlstrpbtnPrevious
            // 
            this.tlstrpbtnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpbtnPrevious.Image = global::Tripodmaps.Properties.Resources.b_prevpage;
            this.tlstrpbtnPrevious.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tlstrpbtnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpbtnPrevious.Name = "tlstrpbtnPrevious";
            this.tlstrpbtnPrevious.Size = new System.Drawing.Size(23, 22);
            this.tlstrpbtnPrevious.ToolTipText = "Previous";
            // 
            // tlstrpbtnNext
            // 
            this.tlstrpbtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpbtnNext.Image = global::Tripodmaps.Properties.Resources.b_nextpage;
            this.tlstrpbtnNext.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tlstrpbtnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpbtnNext.Name = "tlstrpbtnNext";
            this.tlstrpbtnNext.Size = new System.Drawing.Size(23, 22);
            this.tlstrpbtnNext.ToolTipText = "Next";
            // 
            // tlstrpbtnLast
            // 
            this.tlstrpbtnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpbtnLast.Image = global::Tripodmaps.Properties.Resources.b_lastpage;
            this.tlstrpbtnLast.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tlstrpbtnLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpbtnLast.Name = "tlstrpbtnLast";
            this.tlstrpbtnLast.Size = new System.Drawing.Size(23, 22);
            this.tlstrpbtnLast.ToolTipText = "Last";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // tlstrpbtnTools
            // 
            this.tlstrpbtnTools.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpbtnTools.Image = global::Tripodmaps.Properties.Resources.Tools;
            this.tlstrpbtnTools.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpbtnTools.Name = "tlstrpbtnTools";
            this.tlstrpbtnTools.Size = new System.Drawing.Size(23, 22);
            this.tlstrpbtnTools.ToolTipText = "Archive Settings";
            // 
            // tlstrpbtnHelp
            // 
            this.tlstrpbtnHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpbtnHelp.Image = global::Tripodmaps.Properties.Resources.Help_icon1616;
            this.tlstrpbtnHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpbtnHelp.Name = "tlstrpbtnHelp";
            this.tlstrpbtnHelp.Size = new System.Drawing.Size(23, 22);
            this.tlstrpbtnHelp.ToolTipText = "Archiving Help";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.trvDocuments);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabDocuments);
            this.splitContainer1.Size = new System.Drawing.Size(991, 543);
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.TabIndex = 55;
            this.splitContainer1.Resize += new System.EventHandler(this.trvDocuments_Resize);
            // 
            // trvDocuments
            // 
            this.trvDocuments.AllowDrop = true;
            this.trvDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvDocuments.ImageIndex = 3;
            this.trvDocuments.ImageList = this.imgListArchiving;
            this.trvDocuments.Location = new System.Drawing.Point(0, 0);
            this.trvDocuments.MinimumSize = new System.Drawing.Size(246, 539);
            this.trvDocuments.Name = "trvDocuments";
            treeNode1.ImageIndex = 4;
            treeNode1.Name = "ndMyArchive";
            treeNode1.NodeFont = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode1.SelectedImageIndex = 4;
            treeNode1.Tag = "1A";
            treeNode1.Text = "My Local Archive";
            treeNode1.ToolTipText = "Located in Local Computer Folder Structure or Network Folders";
            treeNode2.Name = "nd";
            treeNode2.SelectedImageIndex = 1;
            treeNode2.Tag = "4A";
            treeNode2.Text = "Archive";
            treeNode3.ImageIndex = 8;
            treeNode3.Name = "ndMySharedDocuments";
            treeNode3.SelectedImageIndex = 8;
            treeNode3.Tag = "5A";
            treeNode3.Text = "My Shared Folios";
            treeNode4.ImageIndex = 1;
            treeNode4.Name = "ndMyTripodArchive";
            treeNode4.SelectedImageIndex = 1;
            treeNode4.Tag = "3A";
            treeNode4.Text = "My Archive Online";
            treeNode4.ToolTipText = "Whole Archive Set That is Online";
            treeNode5.ImageIndex = 9;
            treeNode5.Name = "ndFromShare";
            treeNode5.SelectedImageIndex = 9;
            treeNode5.Tag = "6A";
            treeNode5.Text = "From Other TripodUsers";
            treeNode5.ToolTipText = "Documents I have received";
            treeNode6.ImageIndex = 6;
            treeNode6.Name = "ndTripodSharedArchive";
            treeNode6.SelectedImageIndex = 6;
            treeNode6.Tag = "2A";
            treeNode6.Text = "TripodShare - Online Archive";
            treeNode6.ToolTipText = "Containing All Documents Received from other TripodUsers";
            this.trvDocuments.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode6});
            this.trvDocuments.SelectedImageIndex = 0;
            this.trvDocuments.ShowNodeToolTips = true;
            this.trvDocuments.Size = new System.Drawing.Size(246, 539);
            this.trvDocuments.TabIndex = 0;
            this.tltpDocuments.SetToolTip(this.trvDocuments, "Volume - Folders - Document Folios");
            this.trvDocuments.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.trvDocuments_GiveFeedback);
            this.trvDocuments.DragLeave += new System.EventHandler(this.trvDocuments_DragLeave);
            this.trvDocuments.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trvDocuments_MouseUp);
            this.trvDocuments.DragDrop += new System.Windows.Forms.DragEventHandler(this.trvDocuments_DragDrop);
            this.trvDocuments.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvDocuments_AfterSelect);
            this.trvDocuments.DragEnter += new System.Windows.Forms.DragEventHandler(this.trvDocuments_DragEnter);
            this.trvDocuments.KeyUp += new System.Windows.Forms.KeyEventHandler(this.trvDocuments_KeyUp);
            this.trvDocuments.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvDocuments_MouseClick);
            this.trvDocuments.KeyDown += new System.Windows.Forms.KeyEventHandler(this.trvDocuments_KeyDown);
            this.trvDocuments.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.trvDocuments_ItemDrag);
            this.trvDocuments.DragOver += new System.Windows.Forms.DragEventHandler(this.trvDocuments_DragOver);
            // 
            // imgListArchiving
            // 
            this.imgListArchiving.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListArchiving.ImageStream")));
            this.imgListArchiving.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListArchiving.Images.SetKeyName(0, "1308812357_Folder.png");
            this.imgListArchiving.Images.SetKeyName(1, "1308812348_web.ico");
            this.imgListArchiving.Images.SetKeyName(2, "1308812337_web.png");
            this.imgListArchiving.Images.SetKeyName(3, "1308812357_Folder.png");
            this.imgListArchiving.Images.SetKeyName(4, "1308812377_Program-Group.png");
            this.imgListArchiving.Images.SetKeyName(5, "1308812407_HP-Video-Folder-Dock-512.png");
            this.imgListArchiving.Images.SetKeyName(6, "1308812460_FolderNetwork.png");
            this.imgListArchiving.Images.SetKeyName(7, "1308812524_My Picture.png");
            this.imgListArchiving.Images.SetKeyName(8, "1308812967_stock_folder-move.png");
            this.imgListArchiving.Images.SetKeyName(9, "1308813107_download_folder.png");
            // 
            // tabDocuments
            // 
            this.tabDocuments.Controls.Add(this.tabDocumentFolios);
            this.tabDocuments.Controls.Add(this.tabMetadata);
            this.tabDocuments.Controls.Add(this.tabDocumentFolders);
            this.tabDocuments.Controls.Add(this.tabDocumentVolumes);
            this.tabDocuments.Controls.Add(this.tabSecurity);
            this.tabDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDocuments.Location = new System.Drawing.Point(0, 0);
            this.tabDocuments.Name = "tabDocuments";
            this.tabDocuments.SelectedIndex = 0;
            this.tabDocuments.Size = new System.Drawing.Size(733, 539);
            this.tabDocuments.TabIndex = 1;
            // 
            // tabDocumentFolios
            // 
            this.tabDocumentFolios.ContextMenuStrip = this.cntxtmnuArchiveTree;
            this.tabDocumentFolios.Controls.Add(this.panel1);
            this.tabDocumentFolios.Controls.Add(this.txtDocumentFolioName);
            this.tabDocumentFolios.Controls.Add(this.label37);
            this.tabDocumentFolios.Controls.Add(this.cmdDocumentFolioEnlargeViewer);
            this.tabDocumentFolios.Controls.Add(this.pdfViewer);
            this.tabDocumentFolios.Controls.Add(this.txtDocumentFolioImageDescription);
            this.tabDocumentFolios.Controls.Add(this.txtDocumentFolioPreviousVersionNumber);
            this.tabDocumentFolios.Controls.Add(this.txtDocumentFolioSourceDescription);
            this.tabDocumentFolios.Controls.Add(this.txtDocumentFolioNumber);
            this.tabDocumentFolios.Controls.Add(this.txtDocumentFolioDescription);
            this.tabDocumentFolios.Controls.Add(this.txtDocumentFolioSerialNumber);
            this.tabDocumentFolios.Controls.Add(this.label33);
            this.tabDocumentFolios.Controls.Add(this.cmdSaveDocumentFolio);
            this.tabDocumentFolios.Controls.Add(this.cmdDeleteDocumentFolio);
            this.tabDocumentFolios.Controls.Add(this.cmdAddDocumentFolio);
            this.tabDocumentFolios.Controls.Add(this.cmdLastDocumentFolio);
            this.tabDocumentFolios.Controls.Add(this.cmdNextDocumentFolio);
            this.tabDocumentFolios.Controls.Add(this.cmdPreviousDocumentFolio);
            this.tabDocumentFolios.Controls.Add(this.cmdFirstDocumentFolio);
            this.tabDocumentFolios.Controls.Add(this.label28);
            this.tabDocumentFolios.Controls.Add(this.cmbDocumentFolioProducedBy);
            this.tabDocumentFolios.Controls.Add(this.label9);
            this.tabDocumentFolios.Controls.Add(this.label12);
            this.tabDocumentFolios.Controls.Add(this.label11);
            this.tabDocumentFolios.Controls.Add(this.cmbDocumentFolioDocumentType);
            this.tabDocumentFolios.Controls.Add(this.label8);
            this.tabDocumentFolios.Controls.Add(this.label10);
            this.tabDocumentFolios.Controls.Add(this.dtDocumentFolioDateProduced);
            this.tabDocumentFolios.Controls.Add(this.cmdSaveDocumentFolioImage);
            this.tabDocumentFolios.Controls.Add(this.cmdDeleteDocumentFolioImage);
            this.tabDocumentFolios.Controls.Add(this.cmdAddDocumentFolioImage);
            this.tabDocumentFolios.Controls.Add(this.cmdLastDocumentFolioImage);
            this.tabDocumentFolios.Controls.Add(this.cmdNextDocumentFolioImage);
            this.tabDocumentFolios.Controls.Add(this.cmdPreviousDocumentFolioImage);
            this.tabDocumentFolios.Controls.Add(this.cmdFirstDocumentFolioImage);
            this.tabDocumentFolios.Controls.Add(this.label1);
            this.tabDocumentFolios.Controls.Add(this.label6);
            this.tabDocumentFolios.Controls.Add(this.cmbDocumentFolioMimeType);
            this.tabDocumentFolios.Controls.Add(this.label7);
            this.tabDocumentFolios.Location = new System.Drawing.Point(4, 22);
            this.tabDocumentFolios.Name = "tabDocumentFolios";
            this.tabDocumentFolios.Size = new System.Drawing.Size(725, 513);
            this.tabDocumentFolios.TabIndex = 3;
            this.tabDocumentFolios.Text = "Document Folios";
            this.tabDocumentFolios.UseVisualStyleBackColor = true;
            // 
            // cntxtmnuArchiveTree
            // 
            this.cntxtmnuArchiveTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuArchivingViewTripodShare,
            this.mnuArchivingMyTripodAccount,
            this.mnuArchivingSeparatorAccount,
            this.mnuArchivingVolumesAddVolumes,
            this.mnuArchivingVolumesManageVolumeSecurity,
            this.mnuArchivingVolumesVolumeSettings,
            this.mnuArchivingVolumesAddNewSubFolders,
            this.mnuArchivingVolumesImportVolumeStructure,
            this.mnuArchivingVolumesDeleteVolume,
            this.mnuArchivingSeparatorVolumeSubFolder,
            this.mnuArchivingSubFoldersAddNewSubFolder,
            this.mnuArchivingSubFoldersManageSecurity,
            this.mnuArchivingSubFoldersImportFolderFolios,
            this.mnuArchivingSubFoldersSettings,
            this.mnuArchivingSubFoldersDeleteSubFolder,
            this.mnuArchivingSeparatorSubFolderFolio,
            this.mnuArchivingSubFoldersAddFolio,
            this.mnuArchivingManageFolioSecurity,
            this.mnuArchivingAddFolioToTripodShare,
            this.mnuArchivingSubFoldersAddFolioSeries,
            this.mnuArchivingAddAnotherFolioVersion,
            this.mnuArchivingFoliosImportFoliosFoliosFromSubSystem,
            this.mnuArchivingFolioSettings,
            this.mnuArchivingSubFoldersDeleteFolio,
            this.toolStripMenuItem1,
            this.mnuArchivingViewUserReports,
            this.mnuArchivingManageSharedFolioSecurity,
            this.mnuArchivingCreateDailyQuotas});
            this.cntxtmnuArchiveTree.Name = "cntxtmnuDocumentViewer";
            this.cntxtmnuArchiveTree.Size = new System.Drawing.Size(223, 556);
            // 
            // mnuArchivingViewTripodShare
            // 
            this.mnuArchivingViewTripodShare.Name = "mnuArchivingViewTripodShare";
            this.mnuArchivingViewTripodShare.Size = new System.Drawing.Size(222, 22);
            this.mnuArchivingViewTripodShare.Text = "My TripodShare View Requests";
            // 
            // mnuArchivingMyTripodAccount
            // 
            this.mnuArchivingMyTripodAccount.Name = "mnuArchivingMyTripodAccount";
            this.mnuArchivingMyTripodAccount.Size = new System.Drawing.Size(222, 22);
            this.mnuArchivingMyTripodAccount.Text = "My TripodAccount";
            // 
            // mnuArchivingSeparatorAccount
            // 
            this.mnuArchivingSeparatorAccount.Name = "mnuArchivingSeparatorAccount";
            this.mnuArchivingSeparatorAccount.Size = new System.Drawing.Size(219, 6);
            // 
            // mnuArchivingVolumesAddVolumes
            // 
            this.mnuArchivingVolumesAddVolumes.Name = "mnuArchivingVolumesAddVolumes";
            this.mnuArchivingVolumesAddVolumes.Size = new System.Drawing.Size(222, 22);
            this.mnuArchivingVolumesAddVolumes.Text = "Add Volumes";
            this.mnuArchivingVolumesAddVolumes.ToolTipText = "Volumes are top level folders. They are not inside sub-folders";
            this.mnuArchivingVolumesAddVolumes.Click += new System.EventHandler(this.mnuArchivingVolumesAddVolumes_Click);
            // 
            // mnuArchivingVolumesManageVolumeSecurity
            // 
            this.mnuArchivingVolumesManageVolumeSecurity.Name = "mnuArchivingVolumesManageVolumeSecurity";
            this.mnuArchivingVolumesManageVolumeSecurity.Size = new System.Drawing.Size(222, 22);
            this.mnuArchivingVolumesManageVolumeSecurity.Text = "Manage Volume Security";
            // 
            // mnuArchivingVolumesVolumeSettings
            // 
            this.mnuArchivingVolumesVolumeSettings.Name = "mnuArchivingVolumesVolumeSettings";
            this.mnuArchivingVolumesVolumeSettings.Size = new System.Drawing.Size(222, 22);
            this.mnuArchivingVolumesVolumeSettings.Text = "Volume Settings";
            // 
            // mnuArchivingVolumesAddNewSubFolders
            // 
            this.mnuArchivingVolumesAddNewSubFolders.Name = "mnuArchivingVolumesAddNewSubFolders";
            this.mnuArchivingVolumesAddNewSubFolders.Size = new System.Drawing.Size(222, 22);
            this.mnuArchivingVolumesAddNewSubFolders.Text = "Add New Sub Folders";
            // 
            // mnuArchivingVolumesImportVolumeStructure
            // 
            this.mnuArchivingVolumesImportVolumeStructure.Name = "mnuArchivingVolumesImportVolumeStructure";
            this.mnuArchivingVolumesImportVolumeStructure.Size = new System.Drawing.Size(222, 22);
            this.mnuArchivingVolumesImportVolumeStructure.Text = "Import Volume Structure";
            // 
            // mnuArchivingVolumesDeleteVolume
            // 
            this.mnuArchivingVolumesDeleteVolume.Name = "mnuArchivingVolumesDeleteVolume";
            this.mnuArchivingVolumesDeleteVolume.Size = new System.Drawing.Size(222, 22);
            this.mnuArchivingVolumesDeleteVolume.Text = "Delete Volume";
            // 
            // mnuArchivingSeparatorVolumeSubFolder
            // 
            this.mnuArchivingSeparatorVolumeSubFolder.Name = "mnuArchivingSeparatorVolumeSubFolder";
            this.mnuArchivingSeparatorVolumeSubFolder.Size = new System.Drawing.Size(219, 6);
            // 
            // mnuArchivingSubFoldersAddNewSubFolder
            // 
            this.mnuArchivingSubFoldersAddNewSubFolder.Name = "mnuArchivingSubFoldersAddNewSubFolder";
            this.mnuArchivingSubFoldersAddNewSubFolder.Size = new System.Drawing.Size(222, 22);
            this.mnuArchivingSubFoldersAddNewSubFolder.Text = "Add New Sub Folder";
            // 
            // mnuArchivingSubFoldersManageSecurity
            // 
            this.mnuArchivingSubFoldersManageSecurity.Name = "mnuArchivingSubFoldersManageSecurity";
            this.mnuArchivingSubFoldersManageSecurity.Size = new System.Drawing.Size(222, 22);
            this.mnuArchivingSubFoldersManageSecurity.Text = "Manage Folder Security";
            // 
            // mnuArchivingSubFoldersImportFolderFolios
            // 
            this.mnuArchivingSubFoldersImportFolderFolios.Name = "mnuArchivingSubFoldersImportFolderFolios";
            this.mnuArchivingSubFoldersImportFolderFolios.Size = new System.Drawing.Size(222, 22);
            this.mnuArchivingSubFoldersImportFolderFolios.Text = "Import Folios to Folder";
            // 
            // mnuArchivingSubFoldersSettings
            // 
            this.mnuArchivingSubFoldersSettings.Name = "mnuArchivingSubFoldersSettings";
            this.mnuArchivingSubFoldersSettings.Size = new System.Drawing.Size(222, 22);
            this.mnuArchivingSubFoldersSettings.Text = "Folder Settings";
            // 
            // mnuArchivingSubFoldersDeleteSubFolder
            // 
            this.mnuArchivingSubFoldersDeleteSubFolder.Name = "mnuArchivingSubFoldersDeleteSubFolder";
            this.mnuArchivingSubFoldersDeleteSubFolder.Size = new System.Drawing.Size(222, 22);
            this.mnuArchivingSubFoldersDeleteSubFolder.Text = "Delete Sub Folder";
            // 
            // mnuArchivingSeparatorSubFolderFolio
            // 
            this.mnuArchivingSeparatorSubFolderFolio.Name = "mnuArchivingSeparatorSubFolderFolio";
            this.mnuArchivingSeparatorSubFolderFolio.Size = new System.Drawing.Size(219, 6);
            // 
            // mnuArchivingSubFoldersAddFolio
            // 
            this.mnuArchivingSubFoldersAddFolio.Name = "mnuArchivingSubFoldersAddFolio";
            this.mnuArchivingSubFoldersAddFolio.Size = new System.Drawing.Size(222, 22);
            this.mnuArchivingSubFoldersAddFolio.Text = "Add Folio";
            this.mnuArchivingSubFoldersAddFolio.ToolTipText = "Add a whole new Folio";
            // 
            // mnuArchivingManageFolioSecurity
            // 
            this.mnuArchivingManageFolioSecurity.Name = "mnuArchivingManageFolioSecurity";
            this.mnuArchivingManageFolioSecurity.Size = new System.Drawing.Size(222, 22);
            this.mnuArchivingManageFolioSecurity.Text = "Manage Folio Security";
            // 
            // mnuArchivingAddFolioToTripodShare
            // 
            this.mnuArchivingAddFolioToTripodShare.Name = "mnuArchivingAddFolioToTripodShare";
            this.mnuArchivingAddFolioToTripodShare.Size = new System.Drawing.Size(222, 22);
            this.mnuArchivingAddFolioToTripodShare.Text = "Add Folio To TripodShare";
            // 
            // mnuArchivingSubFoldersAddFolioSeries
            // 
            this.mnuArchivingSubFoldersAddFolioSeries.Name = "mnuArchivingSubFoldersAddFolioSeries";
            this.mnuArchivingSubFoldersAddFolioSeries.Size = new System.Drawing.Size(222, 22);
            this.mnuArchivingSubFoldersAddFolioSeries.Text = "Add Another Folio Series";
            this.mnuArchivingSubFoldersAddFolioSeries.ToolTipText = "Adds a folio of the same series e.g. Page 2, Back Page";
            // 
            // mnuArchivingAddAnotherFolioVersion
            // 
            this.mnuArchivingAddAnotherFolioVersion.Name = "mnuArchivingAddAnotherFolioVersion";
            this.mnuArchivingAddAnotherFolioVersion.Size = new System.Drawing.Size(222, 22);
            this.mnuArchivingAddAnotherFolioVersion.Text = "Add Another Folio Version";
            this.mnuArchivingAddAnotherFolioVersion.ToolTipText = "Add Previous or Newer versions of the folio";
            // 
            // mnuArchivingFoliosImportFoliosFoliosFromSubSystem
            // 
            this.mnuArchivingFoliosImportFoliosFoliosFromSubSystem.Name = "mnuArchivingFoliosImportFoliosFoliosFromSubSystem";
            this.mnuArchivingFoliosImportFoliosFoliosFromSubSystem.Size = new System.Drawing.Size(222, 22);
            this.mnuArchivingFoliosImportFoliosFoliosFromSubSystem.Text = "Import Folios From System";
            // 
            // mnuArchivingFolioSettings
            // 
            this.mnuArchivingFolioSettings.Name = "mnuArchivingFolioSettings";
            this.mnuArchivingFolioSettings.Size = new System.Drawing.Size(222, 22);
            this.mnuArchivingFolioSettings.Text = "Folio Settings";
            // 
            // mnuArchivingSubFoldersDeleteFolio
            // 
            this.mnuArchivingSubFoldersDeleteFolio.Name = "mnuArchivingSubFoldersDeleteFolio";
            this.mnuArchivingSubFoldersDeleteFolio.Size = new System.Drawing.Size(222, 22);
            this.mnuArchivingSubFoldersDeleteFolio.Text = "Delete Folio Series Selected";
            this.mnuArchivingSubFoldersDeleteFolio.ToolTipText = "Delete the Folio series selected";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(219, 6);
            // 
            // mnuArchivingViewUserReports
            // 
            this.mnuArchivingViewUserReports.Name = "mnuArchivingViewUserReports";
            this.mnuArchivingViewUserReports.Size = new System.Drawing.Size(222, 22);
            this.mnuArchivingViewUserReports.Text = "View User Reports";
            // 
            // mnuArchivingManageSharedFolioSecurity
            // 
            this.mnuArchivingManageSharedFolioSecurity.Name = "mnuArchivingManageSharedFolioSecurity";
            this.mnuArchivingManageSharedFolioSecurity.Size = new System.Drawing.Size(222, 22);
            this.mnuArchivingManageSharedFolioSecurity.Text = "Manage Shared Folio Security";
            // 
            // mnuArchivingCreateDailyQuotas
            // 
            this.mnuArchivingCreateDailyQuotas.Name = "mnuArchivingCreateDailyQuotas";
            this.mnuArchivingCreateDailyQuotas.Size = new System.Drawing.Size(222, 22);
            this.mnuArchivingCreateDailyQuotas.Text = "Define Daily Quota";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.picDocument);
            this.panel1.Location = new System.Drawing.Point(353, 87);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(365, 414);
            this.panel1.TabIndex = 365;
            // 
            // picDocument
            // 
            this.picDocument.ContextMenuStrip = this.cntxtmnuDocumentViewer;
            this.picDocument.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picDocument.Location = new System.Drawing.Point(0, 0);
            this.picDocument.Name = "picDocument";
            this.picDocument.Size = new System.Drawing.Size(365, 414);
            this.picDocument.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picDocument.TabIndex = 0;
            this.picDocument.TabStop = false;
            this.picDocument.Visible = false;
            // 
            // cntxtmnuDocumentViewer
            // 
            this.cntxtmnuDocumentViewer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlstrpEnlargeDocuments});
            this.cntxtmnuDocumentViewer.Name = "cntxtmnuDocumentViewer";
            this.cntxtmnuDocumentViewer.Size = new System.Drawing.Size(167, 26);
            // 
            // tlstrpEnlargeDocuments
            // 
            this.tlstrpEnlargeDocuments.Image = global::Tripodmaps.Properties.Resources.Zoom_In_icon2424;
            this.tlstrpEnlargeDocuments.Name = "tlstrpEnlargeDocuments";
            this.tlstrpEnlargeDocuments.Size = new System.Drawing.Size(166, 22);
            this.tlstrpEnlargeDocuments.Text = "Enlarge Documents";
            this.tlstrpEnlargeDocuments.Click += new System.EventHandler(this.tlstrpEnlargeDocuments_Click);
            // 
            // txtDocumentFolioName
            // 
            this.txtDocumentFolioName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtDocumentFolioName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDocumentFolioName.Location = new System.Drawing.Point(11, 92);
            this.txtDocumentFolioName.Name = "txtDocumentFolioName";
            this.txtDocumentFolioName.Size = new System.Drawing.Size(320, 20);
            this.txtDocumentFolioName.TabIndex = 363;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(14, 79);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(164, 13);
            this.label37.TabIndex = 362;
            this.label37.Text = "Folio\'s unique Name or File Name";
            // 
            // cmdDocumentFolioEnlargeViewer
            // 
            this.cmdDocumentFolioEnlargeViewer.Location = new System.Drawing.Point(604, 49);
            this.cmdDocumentFolioEnlargeViewer.Name = "cmdDocumentFolioEnlargeViewer";
            this.cmdDocumentFolioEnlargeViewer.Size = new System.Drawing.Size(60, 23);
            this.cmdDocumentFolioEnlargeViewer.TabIndex = 361;
            this.cmdDocumentFolioEnlargeViewer.Text = "Enlarge";
            this.cmdDocumentFolioEnlargeViewer.UseVisualStyleBackColor = true;
            this.cmdDocumentFolioEnlargeViewer.Click += new System.EventHandler(this.cmdDocumentEnlargeViewer_Click);
            // 
            // pdfViewer
            // 
            this.pdfViewer.AllowBookmarks = false;
            this.pdfViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pdfViewer.ContextMenuStrip = this.cntxtmnuDocumentViewer;
            this.pdfViewer.FileName = null;
            this.pdfViewer.Location = new System.Drawing.Point(353, 87);
            this.pdfViewer.Name = "pdfViewer";
            this.pdfViewer.Size = new System.Drawing.Size(369, 414);
            this.pdfViewer.TabIndex = 360;
            this.pdfViewer.UseXPDF = true;
            this.pdfViewer.Visible = false;
            this.pdfViewer.Load += new System.EventHandler(this.pdfViewer_Load);
            this.pdfViewer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pdfViewer_DoubleClick);
            // 
            // txtDocumentFolioImageDescription
            // 
            this.txtDocumentFolioImageDescription.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtDocumentFolioImageDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDocumentFolioImageDescription.Location = new System.Drawing.Point(353, 52);
            this.txtDocumentFolioImageDescription.MaxLength = 50;
            this.txtDocumentFolioImageDescription.Name = "txtDocumentFolioImageDescription";
            this.txtDocumentFolioImageDescription.Size = new System.Drawing.Size(245, 20);
            this.txtDocumentFolioImageDescription.TabIndex = 359;
            this.tltpDocuments.SetToolTip(this.txtDocumentFolioImageDescription, "Folio Series Description - Many images may belond to a folio");
            // 
            // txtDocumentFolioPreviousVersionNumber
            // 
            this.txtDocumentFolioPreviousVersionNumber.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtDocumentFolioPreviousVersionNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDocumentFolioPreviousVersionNumber.Location = new System.Drawing.Point(11, 171);
            this.txtDocumentFolioPreviousVersionNumber.Name = "txtDocumentFolioPreviousVersionNumber";
            this.txtDocumentFolioPreviousVersionNumber.Size = new System.Drawing.Size(320, 20);
            this.txtDocumentFolioPreviousVersionNumber.TabIndex = 350;
            // 
            // txtDocumentFolioSourceDescription
            // 
            this.txtDocumentFolioSourceDescription.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtDocumentFolioSourceDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDocumentFolioSourceDescription.Location = new System.Drawing.Point(11, 405);
            this.txtDocumentFolioSourceDescription.Multiline = true;
            this.txtDocumentFolioSourceDescription.Name = "txtDocumentFolioSourceDescription";
            this.txtDocumentFolioSourceDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDocumentFolioSourceDescription.Size = new System.Drawing.Size(320, 52);
            this.txtDocumentFolioSourceDescription.TabIndex = 347;
            this.txtDocumentFolioSourceDescription.Text = "Description Defining the Source of the Folios";
            // 
            // txtDocumentFolioNumber
            // 
            this.txtDocumentFolioNumber.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtDocumentFolioNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDocumentFolioNumber.Location = new System.Drawing.Point(11, 52);
            this.txtDocumentFolioNumber.Name = "txtDocumentFolioNumber";
            this.txtDocumentFolioNumber.Size = new System.Drawing.Size(320, 20);
            this.txtDocumentFolioNumber.TabIndex = 345;
            this.txtDocumentFolioNumber.TextChanged += new System.EventHandler(this.txtDocumentFolioNumber_TextChanged);
            // 
            // txtDocumentFolioDescription
            // 
            this.txtDocumentFolioDescription.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtDocumentFolioDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDocumentFolioDescription.Location = new System.Drawing.Point(12, 332);
            this.txtDocumentFolioDescription.Multiline = true;
            this.txtDocumentFolioDescription.Name = "txtDocumentFolioDescription";
            this.txtDocumentFolioDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDocumentFolioDescription.Size = new System.Drawing.Size(320, 54);
            this.txtDocumentFolioDescription.TabIndex = 343;
            this.txtDocumentFolioDescription.Text = "Description of the Folio";
            this.txtDocumentFolioDescription.TextChanged += new System.EventHandler(this.txtDocumentDescription_TextChanged);
            // 
            // txtDocumentFolioSerialNumber
            // 
            this.txtDocumentFolioSerialNumber.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtDocumentFolioSerialNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDocumentFolioSerialNumber.Location = new System.Drawing.Point(11, 212);
            this.txtDocumentFolioSerialNumber.Name = "txtDocumentFolioSerialNumber";
            this.txtDocumentFolioSerialNumber.Size = new System.Drawing.Size(320, 20);
            this.txtDocumentFolioSerialNumber.TabIndex = 317;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(353, 38);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(137, 13);
            this.label33.TabIndex = 358;
            this.label33.Text = "Folio Document Description";
            this.tltpDocuments.SetToolTip(this.label33, "Folio Series Description");
            // 
            // cmdSaveDocumentFolio
            // 
            this.cmdSaveDocumentFolio.Image = global::Tripodmaps.Properties.Resources.b_save;
            this.cmdSaveDocumentFolio.Location = new System.Drawing.Point(254, 10);
            this.cmdSaveDocumentFolio.Name = "cmdSaveDocumentFolio";
            this.cmdSaveDocumentFolio.Size = new System.Drawing.Size(36, 23);
            this.cmdSaveDocumentFolio.TabIndex = 357;
            this.cmdSaveDocumentFolio.Text = "...";
            this.tltpDocuments.SetToolTip(this.cmdSaveDocumentFolio, "Save Document Folio");
            this.cmdSaveDocumentFolio.UseVisualStyleBackColor = true;
            // 
            // cmdDeleteDocumentFolio
            // 
            this.cmdDeleteDocumentFolio.Image = global::Tripodmaps.Properties.Resources.b_drop;
            this.cmdDeleteDocumentFolio.Location = new System.Drawing.Point(295, 10);
            this.cmdDeleteDocumentFolio.Name = "cmdDeleteDocumentFolio";
            this.cmdDeleteDocumentFolio.Size = new System.Drawing.Size(36, 23);
            this.cmdDeleteDocumentFolio.TabIndex = 356;
            this.tltpDocuments.SetToolTip(this.cmdDeleteDocumentFolio, "Delete Document Folio");
            this.cmdDeleteDocumentFolio.UseVisualStyleBackColor = true;
            // 
            // cmdAddDocumentFolio
            // 
            this.cmdAddDocumentFolio.Image = global::Tripodmaps.Properties.Resources.AddTableHS1;
            this.cmdAddDocumentFolio.Location = new System.Drawing.Point(214, 10);
            this.cmdAddDocumentFolio.Name = "cmdAddDocumentFolio";
            this.cmdAddDocumentFolio.Size = new System.Drawing.Size(36, 23);
            this.cmdAddDocumentFolio.TabIndex = 355;
            this.cmdAddDocumentFolio.Text = "...";
            this.tltpDocuments.SetToolTip(this.cmdAddDocumentFolio, "Add New Document Folio");
            this.cmdAddDocumentFolio.UseVisualStyleBackColor = true;
            this.cmdAddDocumentFolio.Click += new System.EventHandler(this.cmdAddDocumentFolio_Click);
            // 
            // cmdLastDocumentFolio
            // 
            this.cmdLastDocumentFolio.Image = global::Tripodmaps.Properties.Resources.b_lastpage;
            this.cmdLastDocumentFolio.Location = new System.Drawing.Point(128, 10);
            this.cmdLastDocumentFolio.Name = "cmdLastDocumentFolio";
            this.cmdLastDocumentFolio.Size = new System.Drawing.Size(36, 23);
            this.cmdLastDocumentFolio.TabIndex = 354;
            this.tltpDocuments.SetToolTip(this.cmdLastDocumentFolio, "Last Document Folio");
            this.cmdLastDocumentFolio.UseVisualStyleBackColor = true;
            // 
            // cmdNextDocumentFolio
            // 
            this.cmdNextDocumentFolio.Image = global::Tripodmaps.Properties.Resources.b_nextpage;
            this.cmdNextDocumentFolio.Location = new System.Drawing.Point(89, 10);
            this.cmdNextDocumentFolio.Name = "cmdNextDocumentFolio";
            this.cmdNextDocumentFolio.Size = new System.Drawing.Size(36, 23);
            this.cmdNextDocumentFolio.TabIndex = 353;
            this.tltpDocuments.SetToolTip(this.cmdNextDocumentFolio, "Next Document Folio");
            this.cmdNextDocumentFolio.UseVisualStyleBackColor = true;
            // 
            // cmdPreviousDocumentFolio
            // 
            this.cmdPreviousDocumentFolio.Image = global::Tripodmaps.Properties.Resources.b_prevpage;
            this.cmdPreviousDocumentFolio.Location = new System.Drawing.Point(50, 10);
            this.cmdPreviousDocumentFolio.Name = "cmdPreviousDocumentFolio";
            this.cmdPreviousDocumentFolio.Size = new System.Drawing.Size(36, 23);
            this.cmdPreviousDocumentFolio.TabIndex = 352;
            this.tltpDocuments.SetToolTip(this.cmdPreviousDocumentFolio, "Previous Document Folio");
            this.cmdPreviousDocumentFolio.UseVisualStyleBackColor = true;
            // 
            // cmdFirstDocumentFolio
            // 
            this.cmdFirstDocumentFolio.Image = global::Tripodmaps.Properties.Resources.b_firstpage;
            this.cmdFirstDocumentFolio.Location = new System.Drawing.Point(11, 10);
            this.cmdFirstDocumentFolio.Name = "cmdFirstDocumentFolio";
            this.cmdFirstDocumentFolio.Size = new System.Drawing.Size(36, 23);
            this.cmdFirstDocumentFolio.TabIndex = 351;
            this.tltpDocuments.SetToolTip(this.cmdFirstDocumentFolio, "First Document Folio");
            this.cmdFirstDocumentFolio.UseVisualStyleBackColor = true;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(14, 158);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(151, 13);
            this.label28.TabIndex = 349;
            this.label28.Text = "Previous Version Folio Number";
            // 
            // cmbDocumentFolioProducedBy
            // 
            this.cmbDocumentFolioProducedBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocumentFolioProducedBy.FormattingEnabled = true;
            this.cmbDocumentFolioProducedBy.Location = new System.Drawing.Point(11, 293);
            this.cmbDocumentFolioProducedBy.Name = "cmbDocumentFolioProducedBy";
            this.cmbDocumentFolioProducedBy.Size = new System.Drawing.Size(320, 21);
            this.cmbDocumentFolioProducedBy.TabIndex = 348;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 392);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 13);
            this.label9.TabIndex = 346;
            this.label9.Text = "Source Description";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 39);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 13);
            this.label12.TabIndex = 344;
            this.label12.Text = "Folio Number";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 319);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 13);
            this.label11.TabIndex = 342;
            this.label11.Text = "Document Description";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // cmbDocumentFolioDocumentType
            // 
            this.cmbDocumentFolioDocumentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocumentFolioDocumentType.FormattingEnabled = true;
            this.cmbDocumentFolioDocumentType.Location = new System.Drawing.Point(11, 132);
            this.cmbDocumentFolioDocumentType.Name = "cmbDocumentFolioDocumentType";
            this.cmbDocumentFolioDocumentType.Size = new System.Drawing.Size(320, 21);
            this.cmbDocumentFolioDocumentType.TabIndex = 341;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 340;
            this.label8.Text = "Document Type";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 279);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 336;
            this.label10.Text = "Produced By";
            // 
            // dtDocumentFolioDateProduced
            // 
            this.dtDocumentFolioDateProduced.Location = new System.Drawing.Point(11, 251);
            this.dtDocumentFolioDateProduced.Name = "dtDocumentFolioDateProduced";
            this.dtDocumentFolioDateProduced.Size = new System.Drawing.Size(320, 20);
            this.dtDocumentFolioDateProduced.TabIndex = 335;
            this.dtDocumentFolioDateProduced.ValueChanged += new System.EventHandler(this.dtCustomerDateOfBirth_ValueChanged);
            // 
            // cmdSaveDocumentFolioImage
            // 
            this.cmdSaveDocumentFolioImage.Image = global::Tripodmaps.Properties.Resources.b_save;
            this.cmdSaveDocumentFolioImage.Location = new System.Drawing.Point(604, 10);
            this.cmdSaveDocumentFolioImage.Name = "cmdSaveDocumentFolioImage";
            this.cmdSaveDocumentFolioImage.Size = new System.Drawing.Size(36, 23);
            this.cmdSaveDocumentFolioImage.TabIndex = 331;
            this.cmdSaveDocumentFolioImage.Text = "...";
            this.cmdSaveDocumentFolioImage.UseVisualStyleBackColor = true;
            // 
            // cmdDeleteDocumentFolioImage
            // 
            this.cmdDeleteDocumentFolioImage.Image = global::Tripodmaps.Properties.Resources.b_drop;
            this.cmdDeleteDocumentFolioImage.Location = new System.Drawing.Point(645, 10);
            this.cmdDeleteDocumentFolioImage.Name = "cmdDeleteDocumentFolioImage";
            this.cmdDeleteDocumentFolioImage.Size = new System.Drawing.Size(36, 23);
            this.cmdDeleteDocumentFolioImage.TabIndex = 330;
            this.cmdDeleteDocumentFolioImage.UseVisualStyleBackColor = true;
            // 
            // cmdAddDocumentFolioImage
            // 
            this.cmdAddDocumentFolioImage.Image = global::Tripodmaps.Properties.Resources.AddTableHS1;
            this.cmdAddDocumentFolioImage.Location = new System.Drawing.Point(564, 10);
            this.cmdAddDocumentFolioImage.Name = "cmdAddDocumentFolioImage";
            this.cmdAddDocumentFolioImage.Size = new System.Drawing.Size(36, 23);
            this.cmdAddDocumentFolioImage.TabIndex = 329;
            this.cmdAddDocumentFolioImage.Text = "...";
            this.tltpDocuments.SetToolTip(this.cmdAddDocumentFolioImage, "Add Document Image to Folio Series (e.g. Back, Front, etc)");
            this.cmdAddDocumentFolioImage.UseVisualStyleBackColor = true;
            this.cmdAddDocumentFolioImage.Click += new System.EventHandler(this.cmdAddDocumentFolioImage_Click);
            // 
            // cmdLastDocumentFolioImage
            // 
            this.cmdLastDocumentFolioImage.Image = global::Tripodmaps.Properties.Resources.b_lastpage;
            this.cmdLastDocumentFolioImage.Location = new System.Drawing.Point(509, 10);
            this.cmdLastDocumentFolioImage.Name = "cmdLastDocumentFolioImage";
            this.cmdLastDocumentFolioImage.Size = new System.Drawing.Size(36, 23);
            this.cmdLastDocumentFolioImage.TabIndex = 328;
            this.tltpDocuments.SetToolTip(this.cmdLastDocumentFolioImage, "Last Folio Image in Series");
            this.cmdLastDocumentFolioImage.UseVisualStyleBackColor = true;
            // 
            // cmdNextDocumentFolioImage
            // 
            this.cmdNextDocumentFolioImage.Image = global::Tripodmaps.Properties.Resources.b_nextpage;
            this.cmdNextDocumentFolioImage.Location = new System.Drawing.Point(468, 10);
            this.cmdNextDocumentFolioImage.Name = "cmdNextDocumentFolioImage";
            this.cmdNextDocumentFolioImage.Size = new System.Drawing.Size(36, 23);
            this.cmdNextDocumentFolioImage.TabIndex = 327;
            this.tltpDocuments.SetToolTip(this.cmdNextDocumentFolioImage, "Next Folio Image in Series");
            this.cmdNextDocumentFolioImage.UseVisualStyleBackColor = true;
            // 
            // cmdPreviousDocumentFolioImage
            // 
            this.cmdPreviousDocumentFolioImage.Image = global::Tripodmaps.Properties.Resources.b_prevpage;
            this.cmdPreviousDocumentFolioImage.Location = new System.Drawing.Point(428, 10);
            this.cmdPreviousDocumentFolioImage.Name = "cmdPreviousDocumentFolioImage";
            this.cmdPreviousDocumentFolioImage.Size = new System.Drawing.Size(36, 23);
            this.cmdPreviousDocumentFolioImage.TabIndex = 326;
            this.tltpDocuments.SetToolTip(this.cmdPreviousDocumentFolioImage, "Previous Folio Image in Series");
            this.cmdPreviousDocumentFolioImage.UseVisualStyleBackColor = true;
            // 
            // cmdFirstDocumentFolioImage
            // 
            this.cmdFirstDocumentFolioImage.Image = global::Tripodmaps.Properties.Resources.b_firstpage;
            this.cmdFirstDocumentFolioImage.Location = new System.Drawing.Point(388, 10);
            this.cmdFirstDocumentFolioImage.Name = "cmdFirstDocumentFolioImage";
            this.cmdFirstDocumentFolioImage.Size = new System.Drawing.Size(36, 23);
            this.cmdFirstDocumentFolioImage.TabIndex = 325;
            this.tltpDocuments.SetToolTip(this.cmdFirstDocumentFolioImage, "First Folio Image in Series");
            this.cmdFirstDocumentFolioImage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 318;
            this.label1.Text = "Date Produced";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 13);
            this.label6.TabIndex = 316;
            this.label6.Text = "Folio Serial Number or Bar Code";
            // 
            // cmbDocumentFolioMimeType
            // 
            this.cmbDocumentFolioMimeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocumentFolioMimeType.FormattingEnabled = true;
            this.cmbDocumentFolioMimeType.Location = new System.Drawing.Point(11, 476);
            this.cmbDocumentFolioMimeType.Name = "cmbDocumentFolioMimeType";
            this.cmbDocumentFolioMimeType.Size = new System.Drawing.Size(320, 21);
            this.cmbDocumentFolioMimeType.TabIndex = 315;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 462);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 314;
            this.label7.Text = "Mime Type";
            // 
            // tabMetadata
            // 
            this.tabMetadata.ContextMenuStrip = this.cntxtmnuArchiveTree;
            this.tabMetadata.Controls.Add(this.cmdDocumentMetadataSaveMetadata);
            this.tabMetadata.Controls.Add(this.cmdDocumentMetadataDeleteMetadata);
            this.tabMetadata.Controls.Add(this.cmdDocumentMetadataAddMetadata);
            this.tabMetadata.Controls.Add(this.cmdDocumentMetadataLastMetadata);
            this.tabMetadata.Controls.Add(this.cmdDocumentMetadataNextMetadata);
            this.tabMetadata.Controls.Add(this.cmbDocumentMetadataProducedBy);
            this.tabMetadata.Controls.Add(this.label27);
            this.tabMetadata.Controls.Add(this.dtDocumentMetadataDateCreated);
            this.tabMetadata.Controls.Add(this.label24);
            this.tabMetadata.Controls.Add(this.cmbDocumentMetadataAddedBy);
            this.tabMetadata.Controls.Add(this.label26);
            this.tabMetadata.Controls.Add(this.cmbDocumentMetadataType);
            this.tabMetadata.Controls.Add(this.label13);
            this.tabMetadata.Controls.Add(this.txtDocumentMetadataName);
            this.tabMetadata.Controls.Add(this.txtDocumentMetadataDescription);
            this.tabMetadata.Controls.Add(this.label17);
            this.tabMetadata.Controls.Add(this.label25);
            this.tabMetadata.Controls.Add(this.dtDocumentMetadataDateWhenProduced);
            this.tabMetadata.Controls.Add(this.label29);
            this.tabMetadata.Controls.Add(this.cmdDocumentMetadataPreviousMetadata);
            this.tabMetadata.Controls.Add(this.cmdDocumentMetadataFirstMetadata);
            this.tabMetadata.Location = new System.Drawing.Point(4, 22);
            this.tabMetadata.Name = "tabMetadata";
            this.tabMetadata.Size = new System.Drawing.Size(725, 513);
            this.tabMetadata.TabIndex = 4;
            this.tabMetadata.Text = "Folio Metadata";
            this.tabMetadata.UseVisualStyleBackColor = true;
            // 
            // cmdDocumentMetadataSaveMetadata
            // 
            this.cmdDocumentMetadataSaveMetadata.Image = global::Tripodmaps.Properties.Resources.b_save;
            this.cmdDocumentMetadataSaveMetadata.Location = new System.Drawing.Point(268, 17);
            this.cmdDocumentMetadataSaveMetadata.Name = "cmdDocumentMetadataSaveMetadata";
            this.cmdDocumentMetadataSaveMetadata.Size = new System.Drawing.Size(36, 23);
            this.cmdDocumentMetadataSaveMetadata.TabIndex = 397;
            this.cmdDocumentMetadataSaveMetadata.Text = "...";
            this.tltpDocuments.SetToolTip(this.cmdDocumentMetadataSaveMetadata, "Save Document Volume");
            this.cmdDocumentMetadataSaveMetadata.UseVisualStyleBackColor = true;
            // 
            // cmdDocumentMetadataDeleteMetadata
            // 
            this.cmdDocumentMetadataDeleteMetadata.Image = global::Tripodmaps.Properties.Resources.b_drop;
            this.cmdDocumentMetadataDeleteMetadata.Location = new System.Drawing.Point(308, 17);
            this.cmdDocumentMetadataDeleteMetadata.Name = "cmdDocumentMetadataDeleteMetadata";
            this.cmdDocumentMetadataDeleteMetadata.Size = new System.Drawing.Size(36, 23);
            this.cmdDocumentMetadataDeleteMetadata.TabIndex = 396;
            this.tltpDocuments.SetToolTip(this.cmdDocumentMetadataDeleteMetadata, "Delete Document Volume");
            this.cmdDocumentMetadataDeleteMetadata.UseVisualStyleBackColor = true;
            // 
            // cmdDocumentMetadataAddMetadata
            // 
            this.cmdDocumentMetadataAddMetadata.Image = global::Tripodmaps.Properties.Resources.AddTableHS1;
            this.cmdDocumentMetadataAddMetadata.Location = new System.Drawing.Point(228, 17);
            this.cmdDocumentMetadataAddMetadata.Name = "cmdDocumentMetadataAddMetadata";
            this.cmdDocumentMetadataAddMetadata.Size = new System.Drawing.Size(36, 23);
            this.cmdDocumentMetadataAddMetadata.TabIndex = 395;
            this.cmdDocumentMetadataAddMetadata.Text = "...";
            this.tltpDocuments.SetToolTip(this.cmdDocumentMetadataAddMetadata, "Add Document Volume");
            this.cmdDocumentMetadataAddMetadata.UseVisualStyleBackColor = true;
            // 
            // cmdDocumentMetadataLastMetadata
            // 
            this.cmdDocumentMetadataLastMetadata.Image = global::Tripodmaps.Properties.Resources.b_lastpage;
            this.cmdDocumentMetadataLastMetadata.Location = new System.Drawing.Point(144, 17);
            this.cmdDocumentMetadataLastMetadata.Name = "cmdDocumentMetadataLastMetadata";
            this.cmdDocumentMetadataLastMetadata.Size = new System.Drawing.Size(36, 23);
            this.cmdDocumentMetadataLastMetadata.TabIndex = 394;
            this.tltpDocuments.SetToolTip(this.cmdDocumentMetadataLastMetadata, "Last Document Folio");
            this.cmdDocumentMetadataLastMetadata.UseVisualStyleBackColor = true;
            // 
            // cmdDocumentMetadataNextMetadata
            // 
            this.cmdDocumentMetadataNextMetadata.Image = global::Tripodmaps.Properties.Resources.b_nextpage;
            this.cmdDocumentMetadataNextMetadata.Location = new System.Drawing.Point(104, 17);
            this.cmdDocumentMetadataNextMetadata.Name = "cmdDocumentMetadataNextMetadata";
            this.cmdDocumentMetadataNextMetadata.Size = new System.Drawing.Size(36, 23);
            this.cmdDocumentMetadataNextMetadata.TabIndex = 384;
            this.cmdDocumentMetadataNextMetadata.UseVisualStyleBackColor = true;
            // 
            // cmbDocumentMetadataProducedBy
            // 
            this.cmbDocumentMetadataProducedBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocumentMetadataProducedBy.FormattingEnabled = true;
            this.cmbDocumentMetadataProducedBy.Location = new System.Drawing.Point(24, 303);
            this.cmbDocumentMetadataProducedBy.Name = "cmbDocumentMetadataProducedBy";
            this.cmbDocumentMetadataProducedBy.Size = new System.Drawing.Size(320, 21);
            this.cmbDocumentMetadataProducedBy.TabIndex = 383;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(24, 289);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(68, 13);
            this.label27.TabIndex = 382;
            this.label27.Text = "Produced By";
            // 
            // dtDocumentMetadataDateCreated
            // 
            this.dtDocumentMetadataDateCreated.Enabled = false;
            this.dtDocumentMetadataDateCreated.Location = new System.Drawing.Point(24, 437);
            this.dtDocumentMetadataDateCreated.MaxDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtDocumentMetadataDateCreated.Name = "dtDocumentMetadataDateCreated";
            this.dtDocumentMetadataDateCreated.Size = new System.Drawing.Size(320, 20);
            this.dtDocumentMetadataDateCreated.TabIndex = 381;
            this.dtDocumentMetadataDateCreated.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(24, 422);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(70, 13);
            this.label24.TabIndex = 380;
            this.label24.Text = "Date Created";
            // 
            // cmbDocumentMetadataAddedBy
            // 
            this.cmbDocumentMetadataAddedBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocumentMetadataAddedBy.FormattingEnabled = true;
            this.cmbDocumentMetadataAddedBy.Location = new System.Drawing.Point(24, 394);
            this.cmbDocumentMetadataAddedBy.Name = "cmbDocumentMetadataAddedBy";
            this.cmbDocumentMetadataAddedBy.Size = new System.Drawing.Size(320, 21);
            this.cmbDocumentMetadataAddedBy.TabIndex = 377;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(23, 378);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(101, 13);
            this.label26.TabIndex = 376;
            this.label26.Text = "Metadata Added By";
            // 
            // cmbDocumentMetadataType
            // 
            this.cmbDocumentMetadataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocumentMetadataType.FormattingEnabled = true;
            this.cmbDocumentMetadataType.Location = new System.Drawing.Point(24, 114);
            this.cmbDocumentMetadataType.Name = "cmbDocumentMetadataType";
            this.cmbDocumentMetadataType.Size = new System.Drawing.Size(320, 21);
            this.cmbDocumentMetadataType.TabIndex = 375;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(24, 100);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 13);
            this.label13.TabIndex = 374;
            this.label13.Text = "Metadata Type";
            // 
            // txtDocumentMetadataName
            // 
            this.txtDocumentMetadataName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtDocumentMetadataName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDocumentMetadataName.Location = new System.Drawing.Point(24, 72);
            this.txtDocumentMetadataName.Name = "txtDocumentMetadataName";
            this.txtDocumentMetadataName.Size = new System.Drawing.Size(320, 20);
            this.txtDocumentMetadataName.TabIndex = 370;
            // 
            // txtDocumentMetadataDescription
            // 
            this.txtDocumentMetadataDescription.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtDocumentMetadataDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDocumentMetadataDescription.Location = new System.Drawing.Point(24, 159);
            this.txtDocumentMetadataDescription.Multiline = true;
            this.txtDocumentMetadataDescription.Name = "txtDocumentMetadataDescription";
            this.txtDocumentMetadataDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDocumentMetadataDescription.Size = new System.Drawing.Size(320, 122);
            this.txtDocumentMetadataDescription.TabIndex = 368;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(24, 58);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(83, 13);
            this.label17.TabIndex = 369;
            this.label17.Text = "Metadata Name";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(24, 145);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(108, 13);
            this.label25.TabIndex = 367;
            this.label25.Text = "Metadata Description";
            // 
            // dtDocumentMetadataDateWhenProduced
            // 
            this.dtDocumentMetadataDateWhenProduced.Location = new System.Drawing.Point(24, 349);
            this.dtDocumentMetadataDateWhenProduced.MaxDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtDocumentMetadataDateWhenProduced.Name = "dtDocumentMetadataDateWhenProduced";
            this.dtDocumentMetadataDateWhenProduced.Size = new System.Drawing.Size(320, 20);
            this.dtDocumentMetadataDateWhenProduced.TabIndex = 363;
            this.dtDocumentMetadataDateWhenProduced.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(24, 333);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(189, 13);
            this.label29.TabIndex = 355;
            this.label29.Text = "Date Metadata was Produced on Folio";
            // 
            // cmdDocumentMetadataPreviousMetadata
            // 
            this.cmdDocumentMetadataPreviousMetadata.Image = global::Tripodmaps.Properties.Resources.b_prevpage;
            this.cmdDocumentMetadataPreviousMetadata.Location = new System.Drawing.Point(64, 17);
            this.cmdDocumentMetadataPreviousMetadata.Name = "cmdDocumentMetadataPreviousMetadata";
            this.cmdDocumentMetadataPreviousMetadata.Size = new System.Drawing.Size(36, 23);
            this.cmdDocumentMetadataPreviousMetadata.TabIndex = 379;
            this.cmdDocumentMetadataPreviousMetadata.UseVisualStyleBackColor = true;
            // 
            // cmdDocumentMetadataFirstMetadata
            // 
            this.cmdDocumentMetadataFirstMetadata.Image = global::Tripodmaps.Properties.Resources.b_firstpage;
            this.cmdDocumentMetadataFirstMetadata.Location = new System.Drawing.Point(24, 17);
            this.cmdDocumentMetadataFirstMetadata.Name = "cmdDocumentMetadataFirstMetadata";
            this.cmdDocumentMetadataFirstMetadata.Size = new System.Drawing.Size(36, 23);
            this.cmdDocumentMetadataFirstMetadata.TabIndex = 378;
            this.cmdDocumentMetadataFirstMetadata.UseVisualStyleBackColor = true;
            // 
            // tabDocumentFolders
            // 
            this.tabDocumentFolders.ContextMenuStrip = this.cntxtmnuArchiveTree;
            this.tabDocumentFolders.Controls.Add(this.cmbDocumentFolderProducedBy);
            this.tabDocumentFolders.Controls.Add(this.label31);
            this.tabDocumentFolders.Controls.Add(this.label32);
            this.tabDocumentFolders.Controls.Add(this.label23);
            this.tabDocumentFolders.Controls.Add(this.dtDocumentFolderDateCreated);
            this.tabDocumentFolders.Controls.Add(this.dtDocumentFolderDateProduced);
            this.tabDocumentFolders.Controls.Add(this.label30);
            this.tabDocumentFolders.Controls.Add(this.txtDocumentFolderDescription);
            this.tabDocumentFolders.Controls.Add(this.txtDocumentFolderName);
            this.tabDocumentFolders.Controls.Add(this.label2);
            this.tabDocumentFolders.Controls.Add(this.label3);
            this.tabDocumentFolders.Controls.Add(this.cmbDocumentFolderStatus);
            this.tabDocumentFolders.Controls.Add(this.label4);
            this.tabDocumentFolders.Controls.Add(this.cmbDocumentFolderLimitToDocumentType);
            this.tabDocumentFolders.Controls.Add(this.label5);
            this.tabDocumentFolders.Controls.Add(this.cmdDocumentFolderSaveFolder);
            this.tabDocumentFolders.Controls.Add(this.cmdDocumentFolderDeleteFolder);
            this.tabDocumentFolders.Controls.Add(this.cmdDocumentFolderAddFolder);
            this.tabDocumentFolders.Controls.Add(this.cmdDocumentFolderLastFolder);
            this.tabDocumentFolders.Controls.Add(this.cmdDocumentFolderNextFolder);
            this.tabDocumentFolders.Controls.Add(this.cmdDocumentFolderPreviousFolder);
            this.tabDocumentFolders.Controls.Add(this.cmdDocumentFolderFirstFolder);
            this.tabDocumentFolders.Location = new System.Drawing.Point(4, 22);
            this.tabDocumentFolders.Name = "tabDocumentFolders";
            this.tabDocumentFolders.Padding = new System.Windows.Forms.Padding(3);
            this.tabDocumentFolders.Size = new System.Drawing.Size(725, 513);
            this.tabDocumentFolders.TabIndex = 1;
            this.tabDocumentFolders.Text = "Document Folders";
            this.tabDocumentFolders.UseVisualStyleBackColor = true;
            // 
            // cmbDocumentFolderProducedBy
            // 
            this.cmbDocumentFolderProducedBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocumentFolderProducedBy.FormattingEnabled = true;
            this.cmbDocumentFolderProducedBy.Location = new System.Drawing.Point(27, 325);
            this.cmbDocumentFolderProducedBy.Name = "cmbDocumentFolderProducedBy";
            this.cmbDocumentFolderProducedBy.Size = new System.Drawing.Size(325, 21);
            this.cmbDocumentFolderProducedBy.TabIndex = 387;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(27, 311);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(68, 13);
            this.label31.TabIndex = 386;
            this.label31.Text = "Produced By";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(27, 351);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(79, 13);
            this.label32.TabIndex = 384;
            this.label32.Text = "Date Produced";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(482, 59);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(133, 29);
            this.label23.TabIndex = 365;
            this.label23.Text = "FOLDERS";
            // 
            // dtDocumentFolderDateCreated
            // 
            this.dtDocumentFolderDateCreated.Enabled = false;
            this.dtDocumentFolderDateCreated.Location = new System.Drawing.Point(27, 409);
            this.dtDocumentFolderDateCreated.Name = "dtDocumentFolderDateCreated";
            this.dtDocumentFolderDateCreated.Size = new System.Drawing.Size(325, 20);
            this.dtDocumentFolderDateCreated.TabIndex = 337;
            // 
            // dtDocumentFolderDateProduced
            // 
            this.dtDocumentFolderDateProduced.Location = new System.Drawing.Point(27, 366);
            this.dtDocumentFolderDateProduced.Name = "dtDocumentFolderDateProduced";
            this.dtDocumentFolderDateProduced.Size = new System.Drawing.Size(325, 20);
            this.dtDocumentFolderDateProduced.TabIndex = 336;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(27, 394);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(70, 13);
            this.label30.TabIndex = 314;
            this.label30.Text = "Date Created";
            // 
            // txtDocumentFolderDescription
            // 
            this.txtDocumentFolderDescription.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtDocumentFolderDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDocumentFolderDescription.Location = new System.Drawing.Point(27, 115);
            this.txtDocumentFolderDescription.Multiline = true;
            this.txtDocumentFolderDescription.Name = "txtDocumentFolderDescription";
            this.txtDocumentFolderDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDocumentFolderDescription.Size = new System.Drawing.Size(325, 107);
            this.txtDocumentFolderDescription.TabIndex = 295;
            // 
            // txtDocumentFolderName
            // 
            this.txtDocumentFolderName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtDocumentFolderName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDocumentFolderName.Location = new System.Drawing.Point(27, 74);
            this.txtDocumentFolderName.Name = "txtDocumentFolderName";
            this.txtDocumentFolderName.Size = new System.Drawing.Size(325, 20);
            this.txtDocumentFolderName.TabIndex = 292;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 294;
            this.label2.Text = "Folder Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(222, 13);
            this.label3.TabIndex = 291;
            this.label3.Text = "Folder Name ( in Selected Document Volume)";
            // 
            // cmbDocumentFolderStatus
            // 
            this.cmbDocumentFolderStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocumentFolderStatus.FormattingEnabled = true;
            this.cmbDocumentFolderStatus.Location = new System.Drawing.Point(27, 284);
            this.cmbDocumentFolderStatus.Name = "cmbDocumentFolderStatus";
            this.cmbDocumentFolderStatus.Size = new System.Drawing.Size(325, 21);
            this.cmbDocumentFolderStatus.TabIndex = 290;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 289;
            this.label4.Text = "Folder Status";
            // 
            // cmbDocumentFolderLimitToDocumentType
            // 
            this.cmbDocumentFolderLimitToDocumentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocumentFolderLimitToDocumentType.FormattingEnabled = true;
            this.cmbDocumentFolderLimitToDocumentType.Location = new System.Drawing.Point(27, 245);
            this.cmbDocumentFolderLimitToDocumentType.Name = "cmbDocumentFolderLimitToDocumentType";
            this.cmbDocumentFolderLimitToDocumentType.Size = new System.Drawing.Size(325, 21);
            this.cmbDocumentFolderLimitToDocumentType.TabIndex = 288;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 13);
            this.label5.TabIndex = 287;
            this.label5.Text = "Limited to Specific Document Type";
            // 
            // cmdDocumentFolderSaveFolder
            // 
            this.cmdDocumentFolderSaveFolder.Image = global::Tripodmaps.Properties.Resources.b_save;
            this.cmdDocumentFolderSaveFolder.Location = new System.Drawing.Point(275, 17);
            this.cmdDocumentFolderSaveFolder.Name = "cmdDocumentFolderSaveFolder";
            this.cmdDocumentFolderSaveFolder.Size = new System.Drawing.Size(36, 23);
            this.cmdDocumentFolderSaveFolder.TabIndex = 311;
            this.cmdDocumentFolderSaveFolder.Text = "...";
            this.tltpDocuments.SetToolTip(this.cmdDocumentFolderSaveFolder, "Save Folder");
            this.cmdDocumentFolderSaveFolder.UseVisualStyleBackColor = true;
            // 
            // cmdDocumentFolderDeleteFolder
            // 
            this.cmdDocumentFolderDeleteFolder.Image = global::Tripodmaps.Properties.Resources.b_drop;
            this.cmdDocumentFolderDeleteFolder.Location = new System.Drawing.Point(316, 17);
            this.cmdDocumentFolderDeleteFolder.Name = "cmdDocumentFolderDeleteFolder";
            this.cmdDocumentFolderDeleteFolder.Size = new System.Drawing.Size(36, 23);
            this.cmdDocumentFolderDeleteFolder.TabIndex = 310;
            this.tltpDocuments.SetToolTip(this.cmdDocumentFolderDeleteFolder, "Delete Folder");
            this.cmdDocumentFolderDeleteFolder.UseVisualStyleBackColor = true;
            // 
            // cmdDocumentFolderAddFolder
            // 
            this.cmdDocumentFolderAddFolder.Image = global::Tripodmaps.Properties.Resources.AddTableHS1;
            this.cmdDocumentFolderAddFolder.Location = new System.Drawing.Point(235, 17);
            this.cmdDocumentFolderAddFolder.Name = "cmdDocumentFolderAddFolder";
            this.cmdDocumentFolderAddFolder.Size = new System.Drawing.Size(36, 23);
            this.cmdDocumentFolderAddFolder.TabIndex = 309;
            this.cmdDocumentFolderAddFolder.Text = "...";
            this.tltpDocuments.SetToolTip(this.cmdDocumentFolderAddFolder, "Add Folder");
            this.cmdDocumentFolderAddFolder.UseVisualStyleBackColor = true;
            this.cmdDocumentFolderAddFolder.Click += new System.EventHandler(this.cmdDocumentFolderAddFolder_Click);
            // 
            // cmdDocumentFolderLastFolder
            // 
            this.cmdDocumentFolderLastFolder.Image = global::Tripodmaps.Properties.Resources.b_lastpage;
            this.cmdDocumentFolderLastFolder.Location = new System.Drawing.Point(147, 17);
            this.cmdDocumentFolderLastFolder.Name = "cmdDocumentFolderLastFolder";
            this.cmdDocumentFolderLastFolder.Size = new System.Drawing.Size(36, 23);
            this.cmdDocumentFolderLastFolder.TabIndex = 301;
            this.tltpDocuments.SetToolTip(this.cmdDocumentFolderLastFolder, "Last Folder");
            this.cmdDocumentFolderLastFolder.UseVisualStyleBackColor = true;
            // 
            // cmdDocumentFolderNextFolder
            // 
            this.cmdDocumentFolderNextFolder.Image = global::Tripodmaps.Properties.Resources.b_nextpage;
            this.cmdDocumentFolderNextFolder.Location = new System.Drawing.Point(107, 17);
            this.cmdDocumentFolderNextFolder.Name = "cmdDocumentFolderNextFolder";
            this.cmdDocumentFolderNextFolder.Size = new System.Drawing.Size(36, 23);
            this.cmdDocumentFolderNextFolder.TabIndex = 300;
            this.tltpDocuments.SetToolTip(this.cmdDocumentFolderNextFolder, "Next Folder");
            this.cmdDocumentFolderNextFolder.UseVisualStyleBackColor = true;
            // 
            // cmdDocumentFolderPreviousFolder
            // 
            this.cmdDocumentFolderPreviousFolder.Image = global::Tripodmaps.Properties.Resources.b_prevpage;
            this.cmdDocumentFolderPreviousFolder.Location = new System.Drawing.Point(67, 17);
            this.cmdDocumentFolderPreviousFolder.Name = "cmdDocumentFolderPreviousFolder";
            this.cmdDocumentFolderPreviousFolder.Size = new System.Drawing.Size(36, 23);
            this.cmdDocumentFolderPreviousFolder.TabIndex = 299;
            this.tltpDocuments.SetToolTip(this.cmdDocumentFolderPreviousFolder, "Previous Folder");
            this.cmdDocumentFolderPreviousFolder.UseVisualStyleBackColor = true;
            // 
            // cmdDocumentFolderFirstFolder
            // 
            this.cmdDocumentFolderFirstFolder.Image = global::Tripodmaps.Properties.Resources.b_firstpage;
            this.cmdDocumentFolderFirstFolder.Location = new System.Drawing.Point(27, 17);
            this.cmdDocumentFolderFirstFolder.Name = "cmdDocumentFolderFirstFolder";
            this.cmdDocumentFolderFirstFolder.Size = new System.Drawing.Size(36, 23);
            this.cmdDocumentFolderFirstFolder.TabIndex = 298;
            this.tltpDocuments.SetToolTip(this.cmdDocumentFolderFirstFolder, "First Folder");
            this.cmdDocumentFolderFirstFolder.UseVisualStyleBackColor = true;
            // 
            // tabDocumentVolumes
            // 
            this.tabDocumentVolumes.ContextMenuStrip = this.cntxtmnuArchiveTree;
            this.tabDocumentVolumes.Controls.Add(this.cmbDocumentVolumeProducedBy);
            this.tabDocumentVolumes.Controls.Add(this.label14);
            this.tabDocumentVolumes.Controls.Add(this.label22);
            this.tabDocumentVolumes.Controls.Add(this.dtDocumentVolumeDateCreated);
            this.tabDocumentVolumes.Controls.Add(this.dtDocumentVolumeDateProduced);
            this.tabDocumentVolumes.Controls.Add(this.label15);
            this.tabDocumentVolumes.Controls.Add(this.label16);
            this.tabDocumentVolumes.Controls.Add(this.txtDocumentVolumeDescription);
            this.tabDocumentVolumes.Controls.Add(this.txtDocumentVolumeName);
            this.tabDocumentVolumes.Controls.Add(this.label18);
            this.tabDocumentVolumes.Controls.Add(this.label19);
            this.tabDocumentVolumes.Controls.Add(this.cmdDocumentVolumeFolderStatus);
            this.tabDocumentVolumes.Controls.Add(this.label20);
            this.tabDocumentVolumes.Controls.Add(this.cmbDocumentVolumeLimitToSpecificType);
            this.tabDocumentVolumes.Controls.Add(this.label21);
            this.tabDocumentVolumes.Controls.Add(this.cmdDocumentVolumesSaveVolume);
            this.tabDocumentVolumes.Controls.Add(this.cmdDocumentVolumesDeleteVolume);
            this.tabDocumentVolumes.Controls.Add(this.cmdDocumentVolumesAddVolumes);
            this.tabDocumentVolumes.Controls.Add(this.cmdDocumentVolumeLastVolume);
            this.tabDocumentVolumes.Controls.Add(this.cmdDocumentVolumeNextVolume);
            this.tabDocumentVolumes.Controls.Add(this.cmdDocumentVolumePreviousVolume);
            this.tabDocumentVolumes.Controls.Add(this.cmdDocumentVolumeFirstVolume);
            this.tabDocumentVolumes.Location = new System.Drawing.Point(4, 22);
            this.tabDocumentVolumes.Name = "tabDocumentVolumes";
            this.tabDocumentVolumes.Size = new System.Drawing.Size(725, 513);
            this.tabDocumentVolumes.TabIndex = 2;
            this.tabDocumentVolumes.Text = "Document Volumes";
            this.tabDocumentVolumes.UseVisualStyleBackColor = true;
            // 
            // cmbDocumentVolumeProducedBy
            // 
            this.cmbDocumentVolumeProducedBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocumentVolumeProducedBy.FormattingEnabled = true;
            this.cmbDocumentVolumeProducedBy.Location = new System.Drawing.Point(25, 373);
            this.cmbDocumentVolumeProducedBy.Name = "cmbDocumentVolumeProducedBy";
            this.cmbDocumentVolumeProducedBy.Size = new System.Drawing.Size(325, 21);
            this.cmbDocumentVolumeProducedBy.TabIndex = 389;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(25, 359);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 13);
            this.label14.TabIndex = 388;
            this.label14.Text = "Produced By";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(398, 59);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(291, 29);
            this.label22.TabIndex = 364;
            this.label22.Text = "DOCUMENT VOLUMES";
            // 
            // dtDocumentVolumeDateCreated
            // 
            this.dtDocumentVolumeDateCreated.Enabled = false;
            this.dtDocumentVolumeDateCreated.Location = new System.Drawing.Point(25, 418);
            this.dtDocumentVolumeDateCreated.MaxDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtDocumentVolumeDateCreated.Name = "dtDocumentVolumeDateCreated";
            this.dtDocumentVolumeDateCreated.Size = new System.Drawing.Size(325, 20);
            this.dtDocumentVolumeDateCreated.TabIndex = 363;
            this.dtDocumentVolumeDateCreated.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            // 
            // dtDocumentVolumeDateProduced
            // 
            this.dtDocumentVolumeDateProduced.Location = new System.Drawing.Point(25, 329);
            this.dtDocumentVolumeDateProduced.Name = "dtDocumentVolumeDateProduced";
            this.dtDocumentVolumeDateProduced.Size = new System.Drawing.Size(325, 20);
            this.dtDocumentVolumeDateProduced.TabIndex = 362;
            this.dtDocumentVolumeDateProduced.ValueChanged += new System.EventHandler(this.dtDocumentVolumeDateProduced_ValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(25, 405);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 13);
            this.label15.TabIndex = 361;
            this.label15.Text = "Date Created";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(25, 316);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(79, 13);
            this.label16.TabIndex = 360;
            this.label16.Text = "Date Produced";
            // 
            // txtDocumentVolumeDescription
            // 
            this.txtDocumentVolumeDescription.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtDocumentVolumeDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDocumentVolumeDescription.Location = new System.Drawing.Point(25, 115);
            this.txtDocumentVolumeDescription.Multiline = true;
            this.txtDocumentVolumeDescription.Name = "txtDocumentVolumeDescription";
            this.txtDocumentVolumeDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDocumentVolumeDescription.Size = new System.Drawing.Size(325, 108);
            this.txtDocumentVolumeDescription.TabIndex = 352;
            this.tltpDocuments.SetToolTip(this.txtDocumentVolumeDescription, "Description of the folder or contents");
            // 
            // txtDocumentVolumeName
            // 
            this.txtDocumentVolumeName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtDocumentVolumeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDocumentVolumeName.Location = new System.Drawing.Point(25, 73);
            this.txtDocumentVolumeName.Name = "txtDocumentVolumeName";
            this.txtDocumentVolumeName.Size = new System.Drawing.Size(325, 20);
            this.txtDocumentVolumeName.TabIndex = 350;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(25, 101);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(98, 13);
            this.label18.TabIndex = 351;
            this.label18.Text = "Volume Description";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(25, 59);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(228, 13);
            this.label19.TabIndex = 349;
            this.label19.Text = "Volume Name ( in Selected Document Volume)";
            // 
            // cmdDocumentVolumeFolderStatus
            // 
            this.cmdDocumentVolumeFolderStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdDocumentVolumeFolderStatus.FormattingEnabled = true;
            this.cmdDocumentVolumeFolderStatus.Location = new System.Drawing.Point(25, 285);
            this.cmdDocumentVolumeFolderStatus.Name = "cmdDocumentVolumeFolderStatus";
            this.cmdDocumentVolumeFolderStatus.Size = new System.Drawing.Size(325, 21);
            this.cmdDocumentVolumeFolderStatus.TabIndex = 348;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(25, 272);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(69, 13);
            this.label20.TabIndex = 347;
            this.label20.Text = "Folder Status";
            // 
            // cmbDocumentVolumeLimitToSpecificType
            // 
            this.cmbDocumentVolumeLimitToSpecificType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocumentVolumeLimitToSpecificType.FormattingEnabled = true;
            this.cmbDocumentVolumeLimitToSpecificType.Location = new System.Drawing.Point(25, 246);
            this.cmbDocumentVolumeLimitToSpecificType.Name = "cmbDocumentVolumeLimitToSpecificType";
            this.cmbDocumentVolumeLimitToSpecificType.Size = new System.Drawing.Size(325, 21);
            this.cmbDocumentVolumeLimitToSpecificType.TabIndex = 346;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(25, 232);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(172, 13);
            this.label21.TabIndex = 345;
            this.label21.Text = "Limited to Specific Document Type";
            // 
            // cmdDocumentVolumesSaveVolume
            // 
            this.cmdDocumentVolumesSaveVolume.Image = global::Tripodmaps.Properties.Resources.b_save;
            this.cmdDocumentVolumesSaveVolume.Location = new System.Drawing.Point(274, 17);
            this.cmdDocumentVolumesSaveVolume.Name = "cmdDocumentVolumesSaveVolume";
            this.cmdDocumentVolumesSaveVolume.Size = new System.Drawing.Size(36, 23);
            this.cmdDocumentVolumesSaveVolume.TabIndex = 396;
            this.cmdDocumentVolumesSaveVolume.Text = "...";
            this.tltpDocuments.SetToolTip(this.cmdDocumentVolumesSaveVolume, "Save Document Volume");
            this.cmdDocumentVolumesSaveVolume.UseVisualStyleBackColor = true;
            // 
            // cmdDocumentVolumesDeleteVolume
            // 
            this.cmdDocumentVolumesDeleteVolume.Image = global::Tripodmaps.Properties.Resources.b_drop;
            this.cmdDocumentVolumesDeleteVolume.Location = new System.Drawing.Point(314, 17);
            this.cmdDocumentVolumesDeleteVolume.Name = "cmdDocumentVolumesDeleteVolume";
            this.cmdDocumentVolumesDeleteVolume.Size = new System.Drawing.Size(36, 23);
            this.cmdDocumentVolumesDeleteVolume.TabIndex = 395;
            this.tltpDocuments.SetToolTip(this.cmdDocumentVolumesDeleteVolume, "Delete Document Volume");
            this.cmdDocumentVolumesDeleteVolume.UseVisualStyleBackColor = true;
            this.cmdDocumentVolumesDeleteVolume.Click += new System.EventHandler(this.cmdDocumentFolderDeleteVolume_Click);
            // 
            // cmdDocumentVolumesAddVolumes
            // 
            this.cmdDocumentVolumesAddVolumes.Image = global::Tripodmaps.Properties.Resources.AddTableHS1;
            this.cmdDocumentVolumesAddVolumes.Location = new System.Drawing.Point(234, 17);
            this.cmdDocumentVolumesAddVolumes.Name = "cmdDocumentVolumesAddVolumes";
            this.cmdDocumentVolumesAddVolumes.Size = new System.Drawing.Size(36, 23);
            this.cmdDocumentVolumesAddVolumes.TabIndex = 394;
            this.cmdDocumentVolumesAddVolumes.Text = "...";
            this.tltpDocuments.SetToolTip(this.cmdDocumentVolumesAddVolumes, "Add Document Volume");
            this.cmdDocumentVolumesAddVolumes.UseVisualStyleBackColor = true;
            this.cmdDocumentVolumesAddVolumes.Click += new System.EventHandler(this.cmdDocumentVolumesAddVolumes_Click);
            // 
            // cmdDocumentVolumeLastVolume
            // 
            this.cmdDocumentVolumeLastVolume.Image = global::Tripodmaps.Properties.Resources.b_lastpage;
            this.cmdDocumentVolumeLastVolume.Location = new System.Drawing.Point(145, 17);
            this.cmdDocumentVolumeLastVolume.Name = "cmdDocumentVolumeLastVolume";
            this.cmdDocumentVolumeLastVolume.Size = new System.Drawing.Size(36, 23);
            this.cmdDocumentVolumeLastVolume.TabIndex = 393;
            this.tltpDocuments.SetToolTip(this.cmdDocumentVolumeLastVolume, "Last Document Volume");
            this.cmdDocumentVolumeLastVolume.UseVisualStyleBackColor = true;
            // 
            // cmdDocumentVolumeNextVolume
            // 
            this.cmdDocumentVolumeNextVolume.Image = global::Tripodmaps.Properties.Resources.b_nextpage;
            this.cmdDocumentVolumeNextVolume.Location = new System.Drawing.Point(105, 17);
            this.cmdDocumentVolumeNextVolume.Name = "cmdDocumentVolumeNextVolume";
            this.cmdDocumentVolumeNextVolume.Size = new System.Drawing.Size(36, 23);
            this.cmdDocumentVolumeNextVolume.TabIndex = 392;
            this.tltpDocuments.SetToolTip(this.cmdDocumentVolumeNextVolume, "Next Document Volume");
            this.cmdDocumentVolumeNextVolume.UseVisualStyleBackColor = true;
            // 
            // cmdDocumentVolumePreviousVolume
            // 
            this.cmdDocumentVolumePreviousVolume.Image = global::Tripodmaps.Properties.Resources.b_prevpage;
            this.cmdDocumentVolumePreviousVolume.Location = new System.Drawing.Point(65, 17);
            this.cmdDocumentVolumePreviousVolume.Name = "cmdDocumentVolumePreviousVolume";
            this.cmdDocumentVolumePreviousVolume.Size = new System.Drawing.Size(36, 23);
            this.cmdDocumentVolumePreviousVolume.TabIndex = 391;
            this.tltpDocuments.SetToolTip(this.cmdDocumentVolumePreviousVolume, "Previous Document Volume");
            this.cmdDocumentVolumePreviousVolume.UseVisualStyleBackColor = true;
            // 
            // cmdDocumentVolumeFirstVolume
            // 
            this.cmdDocumentVolumeFirstVolume.Image = global::Tripodmaps.Properties.Resources.b_firstpage;
            this.cmdDocumentVolumeFirstVolume.Location = new System.Drawing.Point(25, 17);
            this.cmdDocumentVolumeFirstVolume.Name = "cmdDocumentVolumeFirstVolume";
            this.cmdDocumentVolumeFirstVolume.Size = new System.Drawing.Size(36, 23);
            this.cmdDocumentVolumeFirstVolume.TabIndex = 390;
            this.tltpDocuments.SetToolTip(this.cmdDocumentVolumeFirstVolume, "First Document Volume");
            this.cmdDocumentVolumeFirstVolume.UseVisualStyleBackColor = true;
            // 
            // tabSecurity
            // 
            this.tabSecurity.Controls.Add(this.grpArchiveSecurity);
            this.tabSecurity.Location = new System.Drawing.Point(4, 22);
            this.tabSecurity.Name = "tabSecurity";
            this.tabSecurity.Size = new System.Drawing.Size(725, 513);
            this.tabSecurity.TabIndex = 5;
            this.tabSecurity.Text = "My Archive Security";
            this.tabSecurity.UseVisualStyleBackColor = true;
            // 
            // grpArchiveSecurity
            // 
            this.grpArchiveSecurity.Location = new System.Drawing.Point(8, 6);
            this.grpArchiveSecurity.Name = "grpArchiveSecurity";
            this.grpArchiveSecurity.Size = new System.Drawing.Size(717, 503);
            this.grpArchiveSecurity.TabIndex = 0;
            this.grpArchiveSecurity.TabStop = false;
            this.grpArchiveSecurity.Text = "Define TripodUsers - How they can access your archive, and what the users can acc" +
                "ess";
            // 
            // imgListUsers
            // 
            this.imgListUsers.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListUsers.ImageStream")));
            this.imgListUsers.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListUsers.Images.SetKeyName(0, "");
            this.imgListUsers.Images.SetKeyName(1, "");
            this.imgListUsers.Images.SetKeyName(2, "");
            this.imgListUsers.Images.SetKeyName(3, "");
            // 
            // frmDocuments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 568);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.tlstrpBuildingTypes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(999, 602);
            this.Name = "frmDocuments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tripodmaps Archiving - Volumes, Documents, and Folios";
            this.Load += new System.EventHandler(this.frmDocuments_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDocuments_FormClosing);
            this.Resize += new System.EventHandler(this.trvDocuments_Resize);
            this.tlstrpBuildingTypes.ResumeLayout(false);
            this.tlstrpBuildingTypes.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabDocuments.ResumeLayout(false);
            this.tabDocumentFolios.ResumeLayout(false);
            this.tabDocumentFolios.PerformLayout();
            this.cntxtmnuArchiveTree.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDocument)).EndInit();
            this.cntxtmnuDocumentViewer.ResumeLayout(false);
            this.tabMetadata.ResumeLayout(false);
            this.tabMetadata.PerformLayout();
            this.tabDocumentFolders.ResumeLayout(false);
            this.tabDocumentFolders.PerformLayout();
            this.tabDocumentVolumes.ResumeLayout(false);
            this.tabDocumentVolumes.PerformLayout();
            this.tabSecurity.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tlstrpBuildingTypes;
        private System.Windows.Forms.ToolStripButton tlstrpbtnNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tlstrpbtnSave;
        private System.Windows.Forms.ToolStripButton tlstrpbtnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tlstrpbtnReports;
        private System.Windows.Forms.ToolStripButton tlstrpbtnPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton tlstrpbtnFirst;
        private System.Windows.Forms.ToolStripButton tlstrpbtnPrevious;
        private System.Windows.Forms.ToolStripButton tlstrpbtnNext;
        private System.Windows.Forms.ToolStripButton tlstrpbtnLast;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton tlstrpbtnTools;
        private System.Windows.Forms.ToolStripButton tlstrpbtnHelp;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolTip tltpDocuments;
        private System.Windows.Forms.TreeView trvDocuments;
        private System.Windows.Forms.TabControl tabDocuments;
        private System.Windows.Forms.TabPage tabDocumentFolios;
        private System.Windows.Forms.TextBox txtDocumentFolioImageDescription;
        private System.Windows.Forms.TextBox txtDocumentFolioPreviousVersionNumber;
        private System.Windows.Forms.TextBox txtDocumentFolioSourceDescription;
        private System.Windows.Forms.TextBox txtDocumentFolioNumber;
        private System.Windows.Forms.TextBox txtDocumentFolioDescription;
        private System.Windows.Forms.TextBox txtDocumentFolioSerialNumber;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Button cmdSaveDocumentFolio;
        private System.Windows.Forms.Button cmdDeleteDocumentFolio;
        private System.Windows.Forms.Button cmdAddDocumentFolio;
        private System.Windows.Forms.Button cmdLastDocumentFolio;
        private System.Windows.Forms.Button cmdNextDocumentFolio;
        private System.Windows.Forms.Button cmdPreviousDocumentFolio;
        private System.Windows.Forms.Button cmdFirstDocumentFolio;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox cmbDocumentFolioProducedBy;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbDocumentFolioDocumentType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtDocumentFolioDateProduced;
        private System.Windows.Forms.Button cmdSaveDocumentFolioImage;
        private System.Windows.Forms.Button cmdDeleteDocumentFolioImage;
        private System.Windows.Forms.Button cmdAddDocumentFolioImage;
        private System.Windows.Forms.Button cmdLastDocumentFolioImage;
        private System.Windows.Forms.Button cmdNextDocumentFolioImage;
        private System.Windows.Forms.Button cmdPreviousDocumentFolioImage;
        private System.Windows.Forms.Button cmdFirstDocumentFolioImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbDocumentFolioMimeType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabDocumentFolders;
        private System.Windows.Forms.ComboBox cmbDocumentFolderProducedBy;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DateTimePicker dtDocumentFolderDateCreated;
        private System.Windows.Forms.DateTimePicker dtDocumentFolderDateProduced;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Button cmdDocumentFolderSaveFolder;
        private System.Windows.Forms.Button cmdDocumentFolderDeleteFolder;
        private System.Windows.Forms.Button cmdDocumentFolderAddFolder;
        private System.Windows.Forms.Button cmdDocumentFolderLastFolder;
        private System.Windows.Forms.Button cmdDocumentFolderNextFolder;
        private System.Windows.Forms.Button cmdDocumentFolderPreviousFolder;
        private System.Windows.Forms.TextBox txtDocumentFolderDescription;
        private System.Windows.Forms.TextBox txtDocumentFolderName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbDocumentFolderStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDocumentFolderLimitToDocumentType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmdDocumentFolderFirstFolder;
        private System.Windows.Forms.TabPage tabDocumentVolumes;
        private System.Windows.Forms.Button cmdDocumentVolumesSaveVolume;
        private System.Windows.Forms.Button cmdDocumentVolumesDeleteVolume;
        private System.Windows.Forms.Button cmdDocumentVolumesAddVolumes;
        private System.Windows.Forms.Button cmdDocumentVolumeLastVolume;
        private System.Windows.Forms.Button cmdDocumentVolumeNextVolume;
        private System.Windows.Forms.Button cmdDocumentVolumePreviousVolume;
        private System.Windows.Forms.Button cmdDocumentVolumeFirstVolume;
        private System.Windows.Forms.ComboBox cmbDocumentVolumeProducedBy;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DateTimePicker dtDocumentVolumeDateCreated;
        private System.Windows.Forms.DateTimePicker dtDocumentVolumeDateProduced;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtDocumentVolumeDescription;
        private System.Windows.Forms.TextBox txtDocumentVolumeName;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cmdDocumentVolumeFolderStatus;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cmbDocumentVolumeLimitToSpecificType;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TabPage tabMetadata;
        private System.Windows.Forms.Button cmdDocumentMetadataLastMetadata;
        private System.Windows.Forms.Button cmdDocumentMetadataNextMetadata;
        private System.Windows.Forms.ComboBox cmbDocumentMetadataProducedBy;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.DateTimePicker dtDocumentMetadataDateCreated;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button cmdDocumentMetadataPreviousMetadata;
        private System.Windows.Forms.Button cmdDocumentMetadataFirstMetadata;
        private System.Windows.Forms.ComboBox cmbDocumentMetadataAddedBy;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox cmbDocumentMetadataType;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtDocumentMetadataName;
        private System.Windows.Forms.TextBox txtDocumentMetadataDescription;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.DateTimePicker dtDocumentMetadataDateWhenProduced;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TabPage tabSecurity;
        private System.Windows.Forms.GroupBox grpArchiveSecurity;
        private System.Windows.Forms.Button cmdDocumentMetadataAddMetadata;
        private System.Windows.Forms.Button cmdDocumentMetadataDeleteMetadata;
        private System.Windows.Forms.OpenFileDialog opnfldlgBuildings;
        private PDFView.PDFViewer pdfViewer;
        private System.Windows.Forms.Button cmdDocumentFolioEnlargeViewer;
        private System.Windows.Forms.ContextMenuStrip cntxtmnuDocumentViewer;
        private System.Windows.Forms.ToolStripMenuItem tlstrpEnlargeDocuments;
        private System.Windows.Forms.TextBox txtDocumentFolioName;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picDocument;
        private System.Windows.Forms.ImageList imgListArchiving;
        private System.Windows.Forms.ImageList imgListUsers;
        private System.Windows.Forms.ContextMenuStrip cntxtmnuArchiveTree;
        private System.Windows.Forms.ToolStripMenuItem mnuArchivingVolumesAddVolumes;
        private System.Windows.Forms.ToolStripMenuItem mnuArchivingVolumesManageVolumeSecurity;
        private System.Windows.Forms.ToolStripMenuItem mnuArchivingVolumesAddNewSubFolders;
        private System.Windows.Forms.ToolStripMenuItem mnuArchivingVolumesVolumeSettings;
        private System.Windows.Forms.ToolStripMenuItem mnuArchivingVolumesDeleteVolume;
        private System.Windows.Forms.ToolStripSeparator mnuArchivingSeparatorVolumeSubFolder;
        private System.Windows.Forms.ToolStripMenuItem mnuArchivingSubFoldersAddNewSubFolder;
        private System.Windows.Forms.ToolStripMenuItem mnuArchivingSubFoldersImportFolderFolios;
        private System.Windows.Forms.ToolStripMenuItem mnuArchivingSubFoldersManageSecurity;
        private System.Windows.Forms.ToolStripMenuItem mnuArchivingSubFoldersSettings;
        private System.Windows.Forms.ToolStripMenuItem mnuArchivingSubFoldersDeleteSubFolder;
        private System.Windows.Forms.ToolStripSeparator mnuArchivingSeparatorSubFolderFolio;
        private System.Windows.Forms.ToolStripMenuItem mnuArchivingSubFoldersAddFolioSeries;
        private System.Windows.Forms.ToolStripMenuItem mnuArchivingAddAnotherFolioVersion;
        private System.Windows.Forms.ToolStripMenuItem mnuArchivingFoliosImportFoliosFoliosFromSubSystem;
        private System.Windows.Forms.ToolStripMenuItem mnuArchivingVolumesImportVolumeStructure;
        private System.Windows.Forms.ToolStripMenuItem mnuArchivingSubFoldersDeleteFolio;
        private System.Windows.Forms.ToolStripMenuItem mnuArchivingSubFoldersAddFolio;
        private System.Windows.Forms.ToolStripMenuItem mnuArchivingManageFolioSecurity;
        private System.Windows.Forms.ToolStripMenuItem mnuArchivingAddFolioToTripodShare;
        private System.Windows.Forms.ToolStripMenuItem mnuArchivingFolioSettings;
        private System.Windows.Forms.ToolStripSeparator mnuArchivingSeparatorAccount;
        private System.Windows.Forms.ToolStripMenuItem mnuArchivingViewTripodShare;
        private System.Windows.Forms.ToolStripMenuItem mnuArchivingMyTripodAccount;
        private System.Windows.Forms.Button cmdDocumentMetadataSaveMetadata;
        private System.Windows.Forms.ToolStripButton tlstrpbtnFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuArchivingViewUserReports;
        private System.Windows.Forms.ToolStripMenuItem mnuArchivingManageSharedFolioSecurity;
        private System.Windows.Forms.ToolStripMenuItem mnuArchivingCreateDailyQuotas;
    }
}