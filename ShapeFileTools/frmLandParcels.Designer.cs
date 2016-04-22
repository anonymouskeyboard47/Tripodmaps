namespace Tripodmaps
{
    partial class frmLandParcels
    {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLandParcels));
            this.spltcontLandParcels = new System.Windows.Forms.SplitContainer();
            this.spltcontLandDetails = new System.Windows.Forms.SplitContainer();
            this.trvLandDetails = new System.Windows.Forms.TreeView();
            this.tlstrpLandParcels = new System.Windows.Forms.ToolStrip();
            this.tlstrpbtnNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tlstrpbtnSave = new System.Windows.Forms.ToolStripButton();
            this.tlstrpbtnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tlstrpbtnReports = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tlstrpbtnFirst = new System.Windows.Forms.ToolStripButton();
            this.tlstrpbtnPrevious = new System.Windows.Forms.ToolStripButton();
            this.tlstrpbtnNext = new System.Windows.Forms.ToolStripButton();
            this.tlstrpbtnLast = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tlstrpbtnTools = new System.Windows.Forms.ToolStripButton();
            this.tlstrpbtnHelp = new System.Windows.Forms.ToolStripButton();
            this.grpCustomers = new System.Windows.Forms.GroupBox();
            this.txtCustomerAccount = new System.Windows.Forms.TextBox();
            this.dtpckCustomerDateRegistered = new System.Windows.Forms.DateTimePicker();
            this.cmbCustomerDefaultCurrency = new System.Windows.Forms.ComboBox();
            this.lblDefaultCountryCurrency = new System.Windows.Forms.Label();
            this.cmbCustomerCountryOfBirth = new System.Windows.Forms.ComboBox();
            this.lblCustomerCountryOfBirth = new System.Windows.Forms.Label();
            this.txtCustomerPINNumber = new System.Windows.Forms.TextBox();
            this.lblCustomerPINNumber = new System.Windows.Forms.Label();
            this.cmdFindCustomerByIDNumber = new System.Windows.Forms.Button();
            this.txtCustomerEmailAddress = new System.Windows.Forms.TextBox();
            this.lblEmailAddress = new System.Windows.Forms.Label();
            this.cmbCustomerPriority = new System.Windows.Forms.ComboBox();
            this.lblCustomerPriority = new System.Windows.Forms.Label();
            this.lblCustomerDateOfBirth = new System.Windows.Forms.Label();
            this.dtCustomerDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.lblDateCreated = new System.Windows.Forms.Label();
            this.dtpckCustomerDateCreated = new System.Windows.Forms.DateTimePicker();
            this.lblCustomerDescription = new System.Windows.Forms.Label();
            this.txtCustomerDescription = new System.Windows.Forms.TextBox();
            this.lblDateDeRegistered = new System.Windows.Forms.Label();
            this.dtpckCustomerDateDeleted = new System.Windows.Forms.DateTimePicker();
            this.statLandParcels = new System.Windows.Forms.StatusStrip();
            this.spltcontLandParcels.Panel2.SuspendLayout();
            this.spltcontLandParcels.SuspendLayout();
            this.spltcontLandDetails.Panel1.SuspendLayout();
            this.spltcontLandDetails.Panel2.SuspendLayout();
            this.spltcontLandDetails.SuspendLayout();
            this.tlstrpLandParcels.SuspendLayout();
            this.grpCustomers.SuspendLayout();
            this.SuspendLayout();
            // 
            // spltcontLandParcels
            // 
            this.spltcontLandParcels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltcontLandParcels.Location = new System.Drawing.Point(0, 0);
            this.spltcontLandParcels.Name = "spltcontLandParcels";
            this.spltcontLandParcels.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.spltcontLandParcels.Panel1Collapsed = true;
            // 
            // spltcontLandParcels.Panel2
            // 
            this.spltcontLandParcels.Panel2.Controls.Add(this.spltcontLandDetails);
            this.spltcontLandParcels.Size = new System.Drawing.Size(910, 540);
            this.spltcontLandParcels.SplitterDistance = 141;
            this.spltcontLandParcels.TabIndex = 0;
            // 
            // spltcontLandDetails
            // 
            this.spltcontLandDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltcontLandDetails.Location = new System.Drawing.Point(0, 0);
            this.spltcontLandDetails.Name = "spltcontLandDetails";
            // 
            // spltcontLandDetails.Panel1
            // 
            this.spltcontLandDetails.Panel1.Controls.Add(this.trvLandDetails);
            // 
            // spltcontLandDetails.Panel2
            // 
            this.spltcontLandDetails.Panel2.Controls.Add(this.tlstrpLandParcels);
            this.spltcontLandDetails.Panel2.Controls.Add(this.grpCustomers);
            this.spltcontLandDetails.Size = new System.Drawing.Size(910, 540);
            this.spltcontLandDetails.SplitterDistance = 303;
            this.spltcontLandDetails.TabIndex = 0;
            // 
            // trvLandDetails
            // 
            this.trvLandDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvLandDetails.Location = new System.Drawing.Point(0, 0);
            this.trvLandDetails.Name = "trvLandDetails";
            this.trvLandDetails.Size = new System.Drawing.Size(303, 540);
            this.trvLandDetails.TabIndex = 0;
            // 
            // tlstrpLandParcels
            // 
            this.tlstrpLandParcels.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlstrpLandParcels.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlstrpLandParcels.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlstrpbtnNew,
            this.toolStripSeparator2,
            this.tlstrpbtnSave,
            this.tlstrpbtnDelete,
            this.toolStripSeparator3,
            this.tlstrpbtnReports,
            this.toolStripButton5,
            this.toolStripSeparator4,
            this.tlstrpbtnFirst,
            this.tlstrpbtnPrevious,
            this.tlstrpbtnNext,
            this.tlstrpbtnLast,
            this.toolStripSeparator6,
            this.tlstrpbtnTools,
            this.tlstrpbtnHelp});
            this.tlstrpLandParcels.Location = new System.Drawing.Point(0, 0);
            this.tlstrpLandParcels.Name = "tlstrpLandParcels";
            this.tlstrpLandParcels.Size = new System.Drawing.Size(603, 25);
            this.tlstrpLandParcels.TabIndex = 202;
            this.tlstrpLandParcels.Text = "Customer Main Menu";
            // 
            // tlstrpbtnNew
            // 
            this.tlstrpbtnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpbtnNew.Image = global::Tripodmaps.Properties.Resources.icon_new;
            this.tlstrpbtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpbtnNew.Name = "tlstrpbtnNew";
            this.tlstrpbtnNew.Size = new System.Drawing.Size(23, 22);
            this.tlstrpbtnNew.Text = "toolStripButton1";
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
            this.tlstrpbtnSave.Text = "toolStripButton2";
            // 
            // tlstrpbtnDelete
            // 
            this.tlstrpbtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpbtnDelete.Image = global::Tripodmaps.Properties.Resources.b_drop;
            this.tlstrpbtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpbtnDelete.Name = "tlstrpbtnDelete";
            this.tlstrpbtnDelete.Size = new System.Drawing.Size(23, 22);
            this.tlstrpbtnDelete.Text = "toolStripButton3";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tlstrpbtnReports
            // 
            this.tlstrpbtnReports.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpbtnReports.Image = global::Tripodmaps.Properties.Resources.PIE_DIAGRAM;
            this.tlstrpbtnReports.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpbtnReports.Name = "tlstrpbtnReports";
            this.tlstrpbtnReports.Size = new System.Drawing.Size(23, 22);
            this.tlstrpbtnReports.Text = "toolStripButton4";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = global::Tripodmaps.Properties.Resources.b_print;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.Text = "toolStripButton5";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tlstrpbtnFirst
            // 
            this.tlstrpbtnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpbtnFirst.Image = global::Tripodmaps.Properties.Resources.b_firstpage;
            this.tlstrpbtnFirst.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tlstrpbtnFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpbtnFirst.Name = "tlstrpbtnFirst";
            this.tlstrpbtnFirst.Size = new System.Drawing.Size(23, 22);
            this.tlstrpbtnFirst.Text = "toolStripButton6";
            // 
            // tlstrpbtnPrevious
            // 
            this.tlstrpbtnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpbtnPrevious.Image = global::Tripodmaps.Properties.Resources.b_prevpage;
            this.tlstrpbtnPrevious.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tlstrpbtnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpbtnPrevious.Name = "tlstrpbtnPrevious";
            this.tlstrpbtnPrevious.Size = new System.Drawing.Size(23, 22);
            this.tlstrpbtnPrevious.Text = "toolStripButton7";
            // 
            // tlstrpbtnNext
            // 
            this.tlstrpbtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpbtnNext.Image = global::Tripodmaps.Properties.Resources.b_nextpage;
            this.tlstrpbtnNext.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tlstrpbtnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpbtnNext.Name = "tlstrpbtnNext";
            this.tlstrpbtnNext.Size = new System.Drawing.Size(23, 22);
            this.tlstrpbtnNext.Text = "toolStripButton8";
            // 
            // tlstrpbtnLast
            // 
            this.tlstrpbtnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpbtnLast.Image = global::Tripodmaps.Properties.Resources.b_lastpage;
            this.tlstrpbtnLast.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tlstrpbtnLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpbtnLast.Name = "tlstrpbtnLast";
            this.tlstrpbtnLast.Size = new System.Drawing.Size(23, 22);
            this.tlstrpbtnLast.Text = "toolStripButton9";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // tlstrpbtnTools
            // 
            this.tlstrpbtnTools.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpbtnTools.Image = global::Tripodmaps.Properties.Resources.Tools;
            this.tlstrpbtnTools.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpbtnTools.Name = "tlstrpbtnTools";
            this.tlstrpbtnTools.Size = new System.Drawing.Size(23, 22);
            this.tlstrpbtnTools.Text = "toolStripButton10";
            // 
            // tlstrpbtnHelp
            // 
            this.tlstrpbtnHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpbtnHelp.Image = global::Tripodmaps.Properties.Resources.Help_icon1616;
            this.tlstrpbtnHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpbtnHelp.Name = "tlstrpbtnHelp";
            this.tlstrpbtnHelp.Size = new System.Drawing.Size(23, 22);
            this.tlstrpbtnHelp.Text = "toolStripButton11";
            // 
            // grpCustomers
            // 
            this.grpCustomers.Controls.Add(this.txtCustomerAccount);
            this.grpCustomers.Controls.Add(this.dtpckCustomerDateRegistered);
            this.grpCustomers.Controls.Add(this.cmbCustomerDefaultCurrency);
            this.grpCustomers.Controls.Add(this.lblDefaultCountryCurrency);
            this.grpCustomers.Controls.Add(this.cmbCustomerCountryOfBirth);
            this.grpCustomers.Controls.Add(this.lblCustomerCountryOfBirth);
            this.grpCustomers.Controls.Add(this.txtCustomerPINNumber);
            this.grpCustomers.Controls.Add(this.lblCustomerPINNumber);
            this.grpCustomers.Controls.Add(this.cmdFindCustomerByIDNumber);
            this.grpCustomers.Controls.Add(this.txtCustomerEmailAddress);
            this.grpCustomers.Controls.Add(this.lblEmailAddress);
            this.grpCustomers.Controls.Add(this.cmbCustomerPriority);
            this.grpCustomers.Controls.Add(this.lblCustomerPriority);
            this.grpCustomers.Controls.Add(this.lblCustomerDateOfBirth);
            this.grpCustomers.Controls.Add(this.dtCustomerDateOfBirth);
            this.grpCustomers.Controls.Add(this.lblDateCreated);
            this.grpCustomers.Controls.Add(this.dtpckCustomerDateCreated);
            this.grpCustomers.Controls.Add(this.lblCustomerDescription);
            this.grpCustomers.Controls.Add(this.txtCustomerDescription);
            this.grpCustomers.Controls.Add(this.lblDateDeRegistered);
            this.grpCustomers.Controls.Add(this.dtpckCustomerDateDeleted);
            this.grpCustomers.Location = new System.Drawing.Point(8, 35);
            this.grpCustomers.Name = "grpCustomers";
            this.grpCustomers.Size = new System.Drawing.Size(592, 480);
            this.grpCustomers.TabIndex = 201;
            this.grpCustomers.TabStop = false;
            this.grpCustomers.Text = "Customer Main Details";
            // 
            // txtCustomerAccount
            // 
            this.txtCustomerAccount.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtCustomerAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerAccount.Location = new System.Drawing.Point(100, 19);
            this.txtCustomerAccount.Name = "txtCustomerAccount";
            this.txtCustomerAccount.Size = new System.Drawing.Size(321, 20);
            this.txtCustomerAccount.TabIndex = 230;
            // 
            // dtpckCustomerDateRegistered
            // 
            this.dtpckCustomerDateRegistered.Location = new System.Drawing.Point(101, 337);
            this.dtpckCustomerDateRegistered.Name = "dtpckCustomerDateRegistered";
            this.dtpckCustomerDateRegistered.Size = new System.Drawing.Size(200, 20);
            this.dtpckCustomerDateRegistered.TabIndex = 228;
            // 
            // cmbCustomerDefaultCurrency
            // 
            this.cmbCustomerDefaultCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomerDefaultCurrency.FormattingEnabled = true;
            this.cmbCustomerDefaultCurrency.Location = new System.Drawing.Point(100, 211);
            this.cmbCustomerDefaultCurrency.MaxDropDownItems = 10;
            this.cmbCustomerDefaultCurrency.Name = "cmbCustomerDefaultCurrency";
            this.cmbCustomerDefaultCurrency.Size = new System.Drawing.Size(321, 21);
            this.cmbCustomerDefaultCurrency.TabIndex = 9;
            // 
            // lblDefaultCountryCurrency
            // 
            this.lblDefaultCountryCurrency.AutoSize = true;
            this.lblDefaultCountryCurrency.Location = new System.Drawing.Point(50, 211);
            this.lblDefaultCountryCurrency.Name = "lblDefaultCountryCurrency";
            this.lblDefaultCountryCurrency.Size = new System.Drawing.Size(49, 13);
            this.lblDefaultCountryCurrency.TabIndex = 227;
            this.lblDefaultCountryCurrency.Text = "Currency";
            // 
            // cmbCustomerCountryOfBirth
            // 
            this.cmbCustomerCountryOfBirth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomerCountryOfBirth.FormattingEnabled = true;
            this.cmbCustomerCountryOfBirth.Location = new System.Drawing.Point(102, 182);
            this.cmbCustomerCountryOfBirth.MaxDropDownItems = 10;
            this.cmbCustomerCountryOfBirth.Name = "cmbCustomerCountryOfBirth";
            this.cmbCustomerCountryOfBirth.Size = new System.Drawing.Size(321, 21);
            this.cmbCustomerCountryOfBirth.TabIndex = 8;
            // 
            // lblCustomerCountryOfBirth
            // 
            this.lblCustomerCountryOfBirth.AutoSize = true;
            this.lblCustomerCountryOfBirth.Location = new System.Drawing.Point(20, 182);
            this.lblCustomerCountryOfBirth.Name = "lblCustomerCountryOfBirth";
            this.lblCustomerCountryOfBirth.Size = new System.Drawing.Size(79, 13);
            this.lblCustomerCountryOfBirth.TabIndex = 224;
            this.lblCustomerCountryOfBirth.Text = "Country of Birth";
            // 
            // txtCustomerPINNumber
            // 
            this.txtCustomerPINNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerPINNumber.Location = new System.Drawing.Point(102, 304);
            this.txtCustomerPINNumber.Name = "txtCustomerPINNumber";
            this.txtCustomerPINNumber.Size = new System.Drawing.Size(200, 20);
            this.txtCustomerPINNumber.TabIndex = 12;
            // 
            // lblCustomerPINNumber
            // 
            this.lblCustomerPINNumber.AutoSize = true;
            this.lblCustomerPINNumber.Location = new System.Drawing.Point(13, 304);
            this.lblCustomerPINNumber.Name = "lblCustomerPINNumber";
            this.lblCustomerPINNumber.Size = new System.Drawing.Size(86, 13);
            this.lblCustomerPINNumber.TabIndex = 218;
            this.lblCustomerPINNumber.Text = "PIN-TIN Number";
            // 
            // cmdFindCustomerByIDNumber
            // 
            this.cmdFindCustomerByIDNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdFindCustomerByIDNumber.Image = global::Tripodmaps.Properties.Resources.Find_icon3232;
            this.cmdFindCustomerByIDNumber.Location = new System.Drawing.Point(442, 50);
            this.cmdFindCustomerByIDNumber.Name = "cmdFindCustomerByIDNumber";
            this.cmdFindCustomerByIDNumber.Size = new System.Drawing.Size(48, 28);
            this.cmdFindCustomerByIDNumber.TabIndex = 6;
            this.cmdFindCustomerByIDNumber.UseVisualStyleBackColor = true;
            // 
            // txtCustomerEmailAddress
            // 
            this.txtCustomerEmailAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerEmailAddress.Location = new System.Drawing.Point(100, 51);
            this.txtCustomerEmailAddress.Name = "txtCustomerEmailAddress";
            this.txtCustomerEmailAddress.Size = new System.Drawing.Size(321, 20);
            this.txtCustomerEmailAddress.TabIndex = 5;
            // 
            // lblEmailAddress
            // 
            this.lblEmailAddress.AutoSize = true;
            this.lblEmailAddress.Location = new System.Drawing.Point(26, 51);
            this.lblEmailAddress.Name = "lblEmailAddress";
            this.lblEmailAddress.Size = new System.Drawing.Size(73, 13);
            this.lblEmailAddress.TabIndex = 216;
            this.lblEmailAddress.Text = "Email Address";
            // 
            // cmbCustomerPriority
            // 
            this.cmbCustomerPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomerPriority.FormattingEnabled = true;
            this.cmbCustomerPriority.Location = new System.Drawing.Point(102, 273);
            this.cmbCustomerPriority.MaxDropDownItems = 10;
            this.cmbCustomerPriority.Name = "cmbCustomerPriority";
            this.cmbCustomerPriority.Size = new System.Drawing.Size(200, 21);
            this.cmbCustomerPriority.TabIndex = 11;
            // 
            // lblCustomerPriority
            // 
            this.lblCustomerPriority.AutoSize = true;
            this.lblCustomerPriority.Location = new System.Drawing.Point(61, 273);
            this.lblCustomerPriority.Name = "lblCustomerPriority";
            this.lblCustomerPriority.Size = new System.Drawing.Size(38, 13);
            this.lblCustomerPriority.TabIndex = 215;
            this.lblCustomerPriority.Text = "Priority";
            // 
            // lblCustomerDateOfBirth
            // 
            this.lblCustomerDateOfBirth.AutoSize = true;
            this.lblCustomerDateOfBirth.Location = new System.Drawing.Point(31, 242);
            this.lblCustomerDateOfBirth.Name = "lblCustomerDateOfBirth";
            this.lblCustomerDateOfBirth.Size = new System.Drawing.Size(68, 13);
            this.lblCustomerDateOfBirth.TabIndex = 214;
            this.lblCustomerDateOfBirth.Text = "Date Of Birth";
            // 
            // dtCustomerDateOfBirth
            // 
            this.dtCustomerDateOfBirth.Location = new System.Drawing.Point(102, 242);
            this.dtCustomerDateOfBirth.Name = "dtCustomerDateOfBirth";
            this.dtCustomerDateOfBirth.Size = new System.Drawing.Size(200, 20);
            this.dtCustomerDateOfBirth.TabIndex = 10;
            // 
            // lblDateCreated
            // 
            this.lblDateCreated.AutoSize = true;
            this.lblDateCreated.Location = new System.Drawing.Point(29, 367);
            this.lblDateCreated.Name = "lblDateCreated";
            this.lblDateCreated.Size = new System.Drawing.Size(70, 13);
            this.lblDateCreated.TabIndex = 212;
            this.lblDateCreated.Text = "Date Created";
            this.lblDateCreated.Visible = false;
            // 
            // dtpckCustomerDateCreated
            // 
            this.dtpckCustomerDateCreated.Location = new System.Drawing.Point(101, 367);
            this.dtpckCustomerDateCreated.Name = "dtpckCustomerDateCreated";
            this.dtpckCustomerDateCreated.Size = new System.Drawing.Size(200, 20);
            this.dtpckCustomerDateCreated.TabIndex = 206;
            this.dtpckCustomerDateCreated.Visible = false;
            // 
            // lblCustomerDescription
            // 
            this.lblCustomerDescription.AutoSize = true;
            this.lblCustomerDescription.Location = new System.Drawing.Point(39, 89);
            this.lblCustomerDescription.Name = "lblCustomerDescription";
            this.lblCustomerDescription.Size = new System.Drawing.Size(60, 13);
            this.lblCustomerDescription.TabIndex = 211;
            this.lblCustomerDescription.Text = "Description";
            // 
            // txtCustomerDescription
            // 
            this.txtCustomerDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerDescription.Location = new System.Drawing.Point(100, 86);
            this.txtCustomerDescription.Multiline = true;
            this.txtCustomerDescription.Name = "txtCustomerDescription";
            this.txtCustomerDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCustomerDescription.Size = new System.Drawing.Size(321, 86);
            this.txtCustomerDescription.TabIndex = 7;
            // 
            // lblDateDeRegistered
            // 
            this.lblDateDeRegistered.AutoSize = true;
            this.lblDateDeRegistered.Location = new System.Drawing.Point(29, 399);
            this.lblDateDeRegistered.Name = "lblDateDeRegistered";
            this.lblDateDeRegistered.Size = new System.Drawing.Size(70, 13);
            this.lblDateDeRegistered.TabIndex = 210;
            this.lblDateDeRegistered.Text = "Date Deleted";
            this.lblDateDeRegistered.Visible = false;
            // 
            // dtpckCustomerDateDeleted
            // 
            this.dtpckCustomerDateDeleted.Location = new System.Drawing.Point(100, 399);
            this.dtpckCustomerDateDeleted.Name = "dtpckCustomerDateDeleted";
            this.dtpckCustomerDateDeleted.Size = new System.Drawing.Size(200, 20);
            this.dtpckCustomerDateDeleted.TabIndex = 207;
            this.dtpckCustomerDateDeleted.Visible = false;
            // 
            // statLandParcels
            // 
            this.statLandParcels.Location = new System.Drawing.Point(0, 518);
            this.statLandParcels.Name = "statLandParcels";
            this.statLandParcels.Size = new System.Drawing.Size(910, 22);
            this.statLandParcels.TabIndex = 1;
            this.statLandParcels.Text = "statusStrip1";
            // 
            // frmLandParcels
            // 
            this.ClientSize = new System.Drawing.Size(910, 540);
            this.Controls.Add(this.statLandParcels);
            this.Controls.Add(this.spltcontLandParcels);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLandParcels";
            this.Text = "Land Parcels (Plots)";
            this.Load += new System.EventHandler(this.frmLandParcels_Load);
            this.spltcontLandParcels.Panel2.ResumeLayout(false);
            this.spltcontLandParcels.ResumeLayout(false);
            this.spltcontLandDetails.Panel1.ResumeLayout(false);
            this.spltcontLandDetails.Panel2.ResumeLayout(false);
            this.spltcontLandDetails.Panel2.PerformLayout();
            this.spltcontLandDetails.ResumeLayout(false);
            this.tlstrpLandParcels.ResumeLayout(false);
            this.tlstrpLandParcels.PerformLayout();
            this.grpCustomers.ResumeLayout(false);
            this.grpCustomers.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAssetRegCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDateRegistered;
        private System.Windows.Forms.DateTimePicker dtTimEndDate;
        private System.Windows.Forms.ComboBox cmbAssetType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbAssetName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLandParcelArea;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLandParcelCentroid;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TreeView trvwAssetHistory;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.CheckBox chkLandParcelAssetOnlyFilter;
        private System.Windows.Forms.SplitContainer spltcontLandParcels;
        private System.Windows.Forms.StatusStrip statLandParcels;
        private System.Windows.Forms.SplitContainer spltcontLandDetails;
        private System.Windows.Forms.TreeView trvLandDetails;
        private System.Windows.Forms.GroupBox grpCustomers;
        private System.Windows.Forms.TextBox txtCustomerAccount;
        private System.Windows.Forms.DateTimePicker dtpckCustomerDateRegistered;
        private System.Windows.Forms.ComboBox cmbCustomerDefaultCurrency;
        private System.Windows.Forms.Label lblDefaultCountryCurrency;
        private System.Windows.Forms.ComboBox cmbCustomerCountryOfBirth;
        private System.Windows.Forms.Label lblCustomerCountryOfBirth;
        private System.Windows.Forms.TextBox txtCustomerPINNumber;
        private System.Windows.Forms.Label lblCustomerPINNumber;
        private System.Windows.Forms.Button cmdFindCustomerByIDNumber;
        private System.Windows.Forms.TextBox txtCustomerEmailAddress;
        private System.Windows.Forms.Label lblEmailAddress;
        private System.Windows.Forms.ComboBox cmbCustomerPriority;
        private System.Windows.Forms.Label lblCustomerPriority;
        private System.Windows.Forms.Label lblCustomerDateOfBirth;
        private System.Windows.Forms.DateTimePicker dtCustomerDateOfBirth;
        private System.Windows.Forms.Label lblDateCreated;
        private System.Windows.Forms.DateTimePicker dtpckCustomerDateCreated;
        private System.Windows.Forms.Label lblCustomerDescription;
        private System.Windows.Forms.TextBox txtCustomerDescription;
        private System.Windows.Forms.Label lblDateDeRegistered;
        private System.Windows.Forms.DateTimePicker dtpckCustomerDateDeleted;
        private System.Windows.Forms.ToolStrip tlstrpLandParcels;
        private System.Windows.Forms.ToolStripButton tlstrpbtnNew;
        private System.Windows.Forms.ToolStripButton tlstrpbtnSave;
        private System.Windows.Forms.ToolStripButton tlstrpbtnDelete;
        private System.Windows.Forms.ToolStripButton tlstrpbtnReports;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton tlstrpbtnFirst;
        private System.Windows.Forms.ToolStripButton tlstrpbtnPrevious;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tlstrpbtnNext;
        private System.Windows.Forms.ToolStripButton tlstrpbtnLast;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tlstrpbtnTools;
        private System.Windows.Forms.ToolStripButton tlstrpbtnHelp;

    }
}