namespace DemoWinForm
{
    partial class frmAssetMaintenance
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAssetMaintenance));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tlstrpFleetMaintenance = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.spltAssetMaintenanceEvent = new System.Windows.Forms.SplitContainer();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtTimEndDate = new System.Windows.Forms.DateTimePicker();
            this.cmbMaintenanceTypes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtTimStartDate = new System.Windows.Forms.DateTimePicker();
            this.cmbAssetSerial = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbAssetName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.trvAssetHistory = new System.Windows.Forms.TreeView();
            this.lblAsset = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lstPartsMaintained = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tlstrpNew = new System.Windows.Forms.ToolStripButton();
            this.tlstripSave = new System.Windows.Forms.ToolStripButton();
            this.tlsStrpDelete = new System.Windows.Forms.ToolStripButton();
            this.tlstrpReports = new System.Windows.Forms.ToolStripButton();
            this.tlstrpHelp = new System.Windows.Forms.ToolStripButton();
            this.tlstrpFirst = new System.Windows.Forms.ToolStripButton();
            this.tlstrpPrevious = new System.Windows.Forms.ToolStripButton();
            this.tlstrpNext = new System.Windows.Forms.ToolStripButton();
            this.tlstrpLast = new System.Windows.Forms.ToolStripButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.tlstrpFleetMaintenance.SuspendLayout();
            this.spltAssetMaintenanceEvent.Panel1.SuspendLayout();
            this.spltAssetMaintenanceEvent.Panel2.SuspendLayout();
            this.spltAssetMaintenanceEvent.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tlstrpFleetMaintenance
            // 
            this.tlstrpFleetMaintenance.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlstrpNew,
            this.toolStripSeparator1,
            this.tlstripSave,
            this.tlsStrpDelete,
            this.toolStripSeparator2,
            this.tlstrpReports,
            this.tlstrpHelp,
            this.toolStripSeparator3,
            this.toolStripSeparator4,
            this.tlstrpFirst,
            this.tlstrpPrevious,
            this.tlstrpNext,
            this.tlstrpLast});
            this.tlstrpFleetMaintenance.Location = new System.Drawing.Point(0, 0);
            this.tlstrpFleetMaintenance.Name = "tlstrpFleetMaintenance";
            this.tlstrpFleetMaintenance.Size = new System.Drawing.Size(904, 25);
            this.tlstrpFleetMaintenance.TabIndex = 10;
            this.tlstrpFleetMaintenance.Text = "toolStrip1";
            this.tlstrpFleetMaintenance.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // spltAssetMaintenanceEvent
            // 
            this.spltAssetMaintenanceEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltAssetMaintenanceEvent.Location = new System.Drawing.Point(0, 25);
            this.spltAssetMaintenanceEvent.MinimumSize = new System.Drawing.Size(904, 261);
            this.spltAssetMaintenanceEvent.Name = "spltAssetMaintenanceEvent";
            // 
            // spltAssetMaintenanceEvent.Panel1
            // 
            this.spltAssetMaintenanceEvent.Panel1.Controls.Add(this.label9);
            this.spltAssetMaintenanceEvent.Panel1.Controls.Add(this.comboBox2);
            this.spltAssetMaintenanceEvent.Panel1.Controls.Add(this.label8);
            this.spltAssetMaintenanceEvent.Panel1.Controls.Add(this.textBox2);
            this.spltAssetMaintenanceEvent.Panel1.Controls.Add(this.label7);
            this.spltAssetMaintenanceEvent.Panel1.Controls.Add(this.comboBox1);
            this.spltAssetMaintenanceEvent.Panel1.Controls.Add(this.label6);
            this.spltAssetMaintenanceEvent.Panel1.Controls.Add(this.dateTimePicker1);
            this.spltAssetMaintenanceEvent.Panel1.Controls.Add(this.lstPartsMaintained);
            this.spltAssetMaintenanceEvent.Panel1.Controls.Add(this.label5);
            this.spltAssetMaintenanceEvent.Panel1.Controls.Add(this.label4);
            this.spltAssetMaintenanceEvent.Panel1.Controls.Add(this.textBox1);
            this.spltAssetMaintenanceEvent.Panel1.Controls.Add(this.lblEndDate);
            this.spltAssetMaintenanceEvent.Panel1.Controls.Add(this.dtTimEndDate);
            this.spltAssetMaintenanceEvent.Panel1.Controls.Add(this.cmbMaintenanceTypes);
            this.spltAssetMaintenanceEvent.Panel1.Controls.Add(this.label1);
            this.spltAssetMaintenanceEvent.Panel1.Controls.Add(this.lblStartDate);
            this.spltAssetMaintenanceEvent.Panel1.Controls.Add(this.dtTimStartDate);
            this.spltAssetMaintenanceEvent.Panel1.Controls.Add(this.cmbAssetSerial);
            this.spltAssetMaintenanceEvent.Panel1.Controls.Add(this.label3);
            this.spltAssetMaintenanceEvent.Panel1.Controls.Add(this.cmbAssetName);
            this.spltAssetMaintenanceEvent.Panel1.Controls.Add(this.label2);
            // 
            // spltAssetMaintenanceEvent.Panel2
            // 
            this.spltAssetMaintenanceEvent.Panel2.Controls.Add(this.trvAssetHistory);
            this.spltAssetMaintenanceEvent.Panel2.Controls.Add(this.lblAsset);
            this.spltAssetMaintenanceEvent.Size = new System.Drawing.Size(904, 385);
            this.spltAssetMaintenanceEvent.SplitterDistance = 408;
            this.spltAssetMaintenanceEvent.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(65, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Notes";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(109, 244);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(288, 129);
            this.textBox1.TabIndex = 25;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(48, 199);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(52, 13);
            this.lblEndDate.TabIndex = 24;
            this.lblEndDate.Text = "End Date";
            // 
            // dtTimEndDate
            // 
            this.dtTimEndDate.Location = new System.Drawing.Point(109, 198);
            this.dtTimEndDate.Name = "dtTimEndDate";
            this.dtTimEndDate.Size = new System.Drawing.Size(200, 20);
            this.dtTimEndDate.TabIndex = 23;
            // 
            // cmbMaintenanceTypes
            // 
            this.cmbMaintenanceTypes.FormattingEnabled = true;
            this.cmbMaintenanceTypes.Items.AddRange(new object[] {
            "Breakdown Maintenance",
            "Preventive Maintenance",
            "Corrective Maintenance"});
            this.cmbMaintenanceTypes.Location = new System.Drawing.Point(109, 92);
            this.cmbMaintenanceTypes.Name = "cmbMaintenanceTypes";
            this.cmbMaintenanceTypes.Size = new System.Drawing.Size(200, 21);
            this.cmbMaintenanceTypes.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Maintenance Type";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(48, 162);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(55, 13);
            this.lblStartDate.TabIndex = 20;
            this.lblStartDate.Text = "Start Date";
            // 
            // dtTimStartDate
            // 
            this.dtTimStartDate.Location = new System.Drawing.Point(109, 161);
            this.dtTimStartDate.Name = "dtTimStartDate";
            this.dtTimStartDate.Size = new System.Drawing.Size(200, 20);
            this.dtTimStartDate.TabIndex = 19;
            // 
            // cmbAssetSerial
            // 
            this.cmbAssetSerial.FormattingEnabled = true;
            this.cmbAssetSerial.Location = new System.Drawing.Point(109, 54);
            this.cmbAssetSerial.Name = "cmbAssetSerial";
            this.cmbAssetSerial.Size = new System.Drawing.Size(288, 21);
            this.cmbAssetSerial.TabIndex = 18;
            this.cmbAssetSerial.SelectedIndexChanged += new System.EventHandler(this.cmbAssetSerial_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Asset Serial";
            // 
            // cmbAssetName
            // 
            this.cmbAssetName.FormattingEnabled = true;
            this.cmbAssetName.Location = new System.Drawing.Point(109, 18);
            this.cmbAssetName.Name = "cmbAssetName";
            this.cmbAssetName.Size = new System.Drawing.Size(288, 21);
            this.cmbAssetName.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Asset Name";
            // 
            // trvAssetHistory
            // 
            this.trvAssetHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trvAssetHistory.Location = new System.Drawing.Point(3, 33);
            this.trvAssetHistory.Name = "trvAssetHistory";
            this.trvAssetHistory.ShowNodeToolTips = true;
            this.trvAssetHistory.Size = new System.Drawing.Size(480, 341);
            this.trvAssetHistory.TabIndex = 14;
            // 
            // lblAsset
            // 
            this.lblAsset.AutoSize = true;
            this.lblAsset.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAsset.Location = new System.Drawing.Point(13, 12);
            this.lblAsset.Name = "lblAsset";
            this.lblAsset.Size = new System.Drawing.Size(117, 18);
            this.lblAsset.TabIndex = 13;
            this.lblAsset.Text = "Historic Notes";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(434, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Parts Maintained";
            // 
            // lstPartsMaintained
            // 
            this.lstPartsMaintained.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstPartsMaintained.FormattingEnabled = true;
            this.lstPartsMaintained.Location = new System.Drawing.Point(437, 33);
            this.lstPartsMaintained.Name = "lstPartsMaintained";
            this.lstPartsMaintained.Size = new System.Drawing.Size(281, 132);
            this.lstPartsMaintained.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Event Date";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(109, 128);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 29;
            // 
            // tlstrpNew
            // 
            this.tlstrpNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpNew.Image = ((System.Drawing.Image)(resources.GetObject("tlstrpNew.Image")));
            this.tlstrpNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpNew.Name = "tlstrpNew";
            this.tlstrpNew.Size = new System.Drawing.Size(23, 22);
            this.tlstrpNew.Text = "toolStripButton1";
            // 
            // tlstripSave
            // 
            this.tlstripSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstripSave.Image = ((System.Drawing.Image)(resources.GetObject("tlstripSave.Image")));
            this.tlstripSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstripSave.Name = "tlstripSave";
            this.tlstripSave.Size = new System.Drawing.Size(23, 22);
            this.tlstripSave.Text = "toolStripButton2";
            // 
            // tlsStrpDelete
            // 
            this.tlsStrpDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsStrpDelete.Image = ((System.Drawing.Image)(resources.GetObject("tlsStrpDelete.Image")));
            this.tlsStrpDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsStrpDelete.Name = "tlsStrpDelete";
            this.tlsStrpDelete.Size = new System.Drawing.Size(23, 22);
            this.tlsStrpDelete.Text = "toolStripButton3";
            // 
            // tlstrpReports
            // 
            this.tlstrpReports.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpReports.Image = ((System.Drawing.Image)(resources.GetObject("tlstrpReports.Image")));
            this.tlstrpReports.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpReports.Name = "tlstrpReports";
            this.tlstrpReports.Size = new System.Drawing.Size(23, 22);
            this.tlstrpReports.Text = "toolStripButton4";
            // 
            // tlstrpHelp
            // 
            this.tlstrpHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpHelp.Image = ((System.Drawing.Image)(resources.GetObject("tlstrpHelp.Image")));
            this.tlstrpHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpHelp.Name = "tlstrpHelp";
            this.tlstrpHelp.Size = new System.Drawing.Size(23, 22);
            this.tlstrpHelp.Text = "toolStripButton5";
            // 
            // tlstrpFirst
            // 
            this.tlstrpFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpFirst.Image = ((System.Drawing.Image)(resources.GetObject("tlstrpFirst.Image")));
            this.tlstrpFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpFirst.Name = "tlstrpFirst";
            this.tlstrpFirst.Size = new System.Drawing.Size(23, 22);
            this.tlstrpFirst.Text = "toolStripButton1";
            // 
            // tlstrpPrevious
            // 
            this.tlstrpPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpPrevious.Image = ((System.Drawing.Image)(resources.GetObject("tlstrpPrevious.Image")));
            this.tlstrpPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpPrevious.Name = "tlstrpPrevious";
            this.tlstrpPrevious.Size = new System.Drawing.Size(23, 22);
            this.tlstrpPrevious.Text = "toolStripButton1";
            // 
            // tlstrpNext
            // 
            this.tlstrpNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpNext.Image = ((System.Drawing.Image)(resources.GetObject("tlstrpNext.Image")));
            this.tlstrpNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpNext.Name = "tlstrpNext";
            this.tlstrpNext.Size = new System.Drawing.Size(23, 22);
            this.tlstrpNext.Text = "toolStripButton1";
            // 
            // tlstrpLast
            // 
            this.tlstrpLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpLast.Image = ((System.Drawing.Image)(resources.GetObject("tlstrpLast.Image")));
            this.tlstrpLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpLast.Name = "tlstrpLast";
            this.tlstrpLast.Size = new System.Drawing.Size(23, 22);
            this.tlstrpLast.Text = "toolStripButton1";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Breakdown Maintenance",
            "Preventive Maintenance",
            "Corrective Maintenance"});
            this.comboBox1.Location = new System.Drawing.Point(437, 200);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(281, 21);
            this.comboBox1.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(434, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Asset Parts";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(437, 246);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(153, 20);
            this.textBox2.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(434, 230);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "Event Maintenance Cost";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(434, 277);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "Currency";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Breakdown Maintenance",
            "Preventive Maintenance",
            "Corrective Maintenance"});
            this.comboBox2.Location = new System.Drawing.Point(437, 293);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(281, 21);
            this.comboBox2.TabIndex = 35;
            // 
            // frmAssetMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 410);
            this.Controls.Add(this.spltAssetMaintenanceEvent);
            this.Controls.Add(this.tlstrpFleetMaintenance);
            this.MinimumSize = new System.Drawing.Size(904, 261);
            this.Name = "frmAssetMaintenance";
            this.Text = "Asset Maintenance Event";
            this.Load += new System.EventHandler(this.frmFleetMaintenance_Load);
            this.tlstrpFleetMaintenance.ResumeLayout(false);
            this.tlstrpFleetMaintenance.PerformLayout();
            this.spltAssetMaintenanceEvent.Panel1.ResumeLayout(false);
            this.spltAssetMaintenanceEvent.Panel1.PerformLayout();
            this.spltAssetMaintenanceEvent.Panel2.ResumeLayout(false);
            this.spltAssetMaintenanceEvent.Panel2.PerformLayout();
            this.spltAssetMaintenanceEvent.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStrip tlstrpFleetMaintenance;
        private System.Windows.Forms.ToolStripButton tlstrpNew;
        private System.Windows.Forms.ToolStripButton tlstripSave;
        private System.Windows.Forms.ToolStripButton tlsStrpDelete;
        private System.Windows.Forms.ToolStripButton tlstrpReports;
        private System.Windows.Forms.ToolStripButton tlstrpHelp;
        private System.Windows.Forms.SplitContainer spltAssetMaintenanceEvent;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtTimEndDate;
        private System.Windows.Forms.ComboBox cmbMaintenanceTypes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtTimStartDate;
        private System.Windows.Forms.ComboBox cmbAssetSerial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbAssetName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAsset;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tlstrpFirst;
        private System.Windows.Forms.ToolStripButton tlstrpPrevious;
        private System.Windows.Forms.ToolStripButton tlstrpNext;
        private System.Windows.Forms.ToolStripButton tlstrpLast;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TreeView trvAssetHistory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstPartsMaintained;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}