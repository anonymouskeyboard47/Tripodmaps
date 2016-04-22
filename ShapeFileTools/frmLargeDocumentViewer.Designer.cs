namespace Tripodmaps
{
    partial class frmLargeDocumentViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLargeDocumentViewer));
            this.opnfldlgBuildings = new System.Windows.Forms.OpenFileDialog();
            this.tlstrpBuildingTypes = new System.Windows.Forms.ToolStrip();
            this.tlstrpbtnNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.picDocument = new System.Windows.Forms.PictureBox();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.pdfViewer = new PDFView.PDFViewer();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlstrpcmdFitImage = new System.Windows.Forms.ToolStripButton();
            this.tlstrpcmdActualImageSize = new System.Windows.Forms.ToolStripButton();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tlstrpBuildingTypes.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // tlstrpBuildingTypes
            // 
            this.tlstrpBuildingTypes.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlstrpBuildingTypes.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlstrpBuildingTypes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlstrpbtnNew,
            this.toolStripSeparator5,
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
            this.tlstrpbtnHelp,
            this.toolStripSeparator1,
            this.tlstrpcmdFitImage,
            this.tlstrpcmdActualImageSize});
            this.tlstrpBuildingTypes.Location = new System.Drawing.Point(0, 0);
            this.tlstrpBuildingTypes.Name = "tlstrpBuildingTypes";
            this.tlstrpBuildingTypes.Size = new System.Drawing.Size(911, 25);
            this.tlstrpBuildingTypes.TabIndex = 363;
            this.tlstrpBuildingTypes.Text = "Customer Main Menu";
            // 
            // tlstrpbtnNew
            // 
            this.tlstrpbtnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpbtnNew.Image = global::Tripodmaps.Properties.Resources.icon_new;
            this.tlstrpbtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpbtnNew.Name = "tlstrpbtnNew";
            this.tlstrpbtnNew.Size = new System.Drawing.Size(23, 22);
            this.tlstrpbtnNew.ToolTipText = "New Document Volume";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tlstrpbtnSave
            // 
            this.tlstrpbtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpbtnSave.Image = global::Tripodmaps.Properties.Resources.b_save;
            this.tlstrpbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpbtnSave.Name = "tlstrpbtnSave";
            this.tlstrpbtnSave.Size = new System.Drawing.Size(23, 22);
            this.tlstrpbtnSave.ToolTipText = "Save Document Volume";
            // 
            // tlstrpbtnDelete
            // 
            this.tlstrpbtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpbtnDelete.Image = global::Tripodmaps.Properties.Resources.b_drop;
            this.tlstrpbtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpbtnDelete.Name = "tlstrpbtnDelete";
            this.tlstrpbtnDelete.Size = new System.Drawing.Size(23, 22);
            this.tlstrpbtnDelete.ToolTipText = "Delete Document Volume";
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
            this.tlstrpbtnReports.ToolTipText = "Document Volume Reports";
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
            this.tlstrpbtnFirst.ToolTipText = "First Document Volume";
            // 
            // tlstrpbtnPrevious
            // 
            this.tlstrpbtnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpbtnPrevious.Image = global::Tripodmaps.Properties.Resources.b_prevpage;
            this.tlstrpbtnPrevious.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tlstrpbtnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpbtnPrevious.Name = "tlstrpbtnPrevious";
            this.tlstrpbtnPrevious.Size = new System.Drawing.Size(23, 22);
            this.tlstrpbtnPrevious.ToolTipText = "Previous Document Volume";
            // 
            // tlstrpbtnNext
            // 
            this.tlstrpbtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpbtnNext.Image = global::Tripodmaps.Properties.Resources.b_nextpage;
            this.tlstrpbtnNext.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tlstrpbtnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpbtnNext.Name = "tlstrpbtnNext";
            this.tlstrpbtnNext.Size = new System.Drawing.Size(23, 22);
            this.tlstrpbtnNext.ToolTipText = "Next Document Volume";
            // 
            // tlstrpbtnLast
            // 
            this.tlstrpbtnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpbtnLast.Image = global::Tripodmaps.Properties.Resources.b_lastpage;
            this.tlstrpbtnLast.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tlstrpbtnLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpbtnLast.Name = "tlstrpbtnLast";
            this.tlstrpbtnLast.Size = new System.Drawing.Size(23, 22);
            this.tlstrpbtnLast.ToolTipText = "Last Document Volume";
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
            // 
            // tlstrpbtnHelp
            // 
            this.tlstrpbtnHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpbtnHelp.Image = global::Tripodmaps.Properties.Resources.Help_icon1616;
            this.tlstrpbtnHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpbtnHelp.Name = "tlstrpbtnHelp";
            this.tlstrpbtnHelp.Size = new System.Drawing.Size(23, 22);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.hScrollBar1);
            this.panel1.Controls.Add(this.vScrollBar1);
            this.panel1.Controls.Add(this.picDocument);
            this.panel1.Location = new System.Drawing.Point(0, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(911, 442);
            this.panel1.TabIndex = 365;
            // 
            // picDocument
            // 
            this.picDocument.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picDocument.Location = new System.Drawing.Point(0, 0);
            this.picDocument.Name = "picDocument";
            this.picDocument.Size = new System.Drawing.Size(894, 422);
            this.picDocument.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picDocument.TabIndex = 3;
            this.picDocument.TabStop = false;
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hScrollBar1.Location = new System.Drawing.Point(0, 425);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(894, 17);
            this.hScrollBar1.TabIndex = 2;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll_2);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar1.Location = new System.Drawing.Point(894, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 442);
            this.vScrollBar1.TabIndex = 1;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll_2);
            // 
            // pdfViewer
            // 
            this.pdfViewer.AllowBookmarks = true;
            this.pdfViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewer.FileName = null;
            this.pdfViewer.Location = new System.Drawing.Point(0, 25);
            this.pdfViewer.Name = "pdfViewer";
            this.pdfViewer.Size = new System.Drawing.Size(911, 469);
            this.pdfViewer.TabIndex = 364;
            this.pdfViewer.UseXPDF = true;
            this.pdfViewer.Visible = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tlstrpcmdFitImage
            // 
            this.tlstrpcmdFitImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpcmdFitImage.Image = global::Tripodmaps.Properties.Resources.ZoomToExtents2;
            this.tlstrpcmdFitImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpcmdFitImage.Name = "tlstrpcmdFitImage";
            this.tlstrpcmdFitImage.Size = new System.Drawing.Size(23, 22);
            this.tlstrpcmdFitImage.Text = "Zoom Image to Extents";
            this.tlstrpcmdFitImage.Click += new System.EventHandler(this.tlstrpcmd_Click);
            // 
            // tlstrpcmdActualImageSize
            // 
            this.tlstrpcmdActualImageSize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpcmdActualImageSize.Image = global::Tripodmaps.Properties.Resources.ZoomIn;
            this.tlstrpcmdActualImageSize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpcmdActualImageSize.Name = "tlstrpcmdActualImageSize";
            this.tlstrpcmdActualImageSize.Size = new System.Drawing.Size(23, 22);
            this.tlstrpcmdActualImageSize.Text = "Actual Document Size";
            this.tlstrpcmdActualImageSize.Click += new System.EventHandler(this.tlstrpcmdActualImageSize_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown1.Location = new System.Drawing.Point(846, 28);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(48, 20);
            this.numericUpDown1.TabIndex = 366;
            this.numericUpDown1.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(748, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 367;
            this.label1.Text = "Zoom Percentage";
            // 
            // frmLargeDocumentViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 494);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pdfViewer);
            this.Controls.Add(this.tlstrpBuildingTypes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(919, 528);
            this.Name = "frmLargeDocumentViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tripodmaps - Enlarged Document - Folio Series";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLargeDocumentViewer_Load);
            this.tlstrpBuildingTypes.ResumeLayout(false);
            this.tlstrpBuildingTypes.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog opnfldlgBuildings;
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private PDFView.PDFViewer pdfViewer;
        private System.Windows.Forms.PictureBox picDocument;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tlstrpcmdFitImage;
        private System.Windows.Forms.ToolStripButton tlstrpcmdActualImageSize;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
    }
}