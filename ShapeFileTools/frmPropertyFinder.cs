using System ;
using System.Drawing ;
using System.Drawing.Imaging ;
using System.Collections ;
using System.ComponentModel ;
using System.Windows.Forms ;
using System.Data ;
using UIComponents ;

namespace Tripodmaps {
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
    public class frmPropertyFinder : System.Windows.Forms.Form
    {
        private UIComponents.XPPanelGroup xpPanelGroup1;
		private UIComponents.XPPanel xpNewLandProperties ;
        private UIComponents.XPPanel xpNewBuildingProperties;
		private UIComponents.ImageSet MediaItemImageSet ;
        private UIComponents.ImageSet purpleGlyphsImageSet;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
		private UIComponents.TextStyle HeaderStyle ;
		private UIComponents.TextStyle TypeStyle ;
        private UIComponents.TextStyle SectionHeaderStyle;
        private DataGridView dtgrdBuildingProperties;
        private DataGridView dtgrdLandProperties;
        private Label label2;
        private NumericUpDown numericUpDown2;
        private Button button3;
        private Button button4;
        private Label label1;
        private NumericUpDown numericUpDown1;
        private Button button1;
        private Button button2;
		private System.ComponentModel.IContainer components ;
        private XPPanel xppnlMyMessages;
        private Label label11;
        private NumericUpDown numNumberToDisplay;
        private Button cmdNextTen;
        private Button cmdPrevious;
        private DataGridView dtgrdMyMessages;
        private XPPanel xppnlFind;
        private XPPanel xpMyProperties;
        private Label label3;
        private NumericUpDown numericUpDown3;
        private Button button5;
        private Button button6;
        private DataGridView dtgrdMyProperties;
        private string errMessage = "";

        public frmPropertyFinder()
        {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent() ;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPropertyFinder));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.HeaderStyle = new UIComponents.TextStyle();
            this.TypeStyle = new UIComponents.TextStyle();
            this.SectionHeaderStyle = new UIComponents.TextStyle();
            this.xpPanelGroup1 = new UIComponents.XPPanelGroup();
            this.xpMyProperties = new UIComponents.XPPanel(234);
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.dtgrdMyProperties = new System.Windows.Forms.DataGridView();
            this.MediaItemImageSet = new UIComponents.ImageSet();
            this.xppnlMyMessages = new UIComponents.XPPanel(208);
            this.purpleGlyphsImageSet = new UIComponents.ImageSet();
            this.label11 = new System.Windows.Forms.Label();
            this.numNumberToDisplay = new System.Windows.Forms.NumericUpDown();
            this.cmdNextTen = new System.Windows.Forms.Button();
            this.cmdPrevious = new System.Windows.Forms.Button();
            this.dtgrdMyMessages = new System.Windows.Forms.DataGridView();
            this.xppnlFind = new UIComponents.XPPanel(418);
            this.xpNewBuildingProperties = new UIComponents.XPPanel(222);
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dtgrdBuildingProperties = new System.Windows.Forms.DataGridView();
            this.xpNewLandProperties = new UIComponents.XPPanel(223);
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dtgrdLandProperties = new System.Windows.Forms.DataGridView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.xpPanelGroup1)).BeginInit();
            this.xpPanelGroup1.SuspendLayout();
            this.xpMyProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdMyProperties)).BeginInit();
            this.xppnlMyMessages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberToDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdMyMessages)).BeginInit();
            this.xpNewBuildingProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdBuildingProperties)).BeginInit();
            this.xpNewLandProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdLandProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // HeaderStyle
            // 
            this.HeaderStyle.BackColor = System.Drawing.Color.Transparent;
            this.HeaderStyle.Description = "";
            this.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderStyle.HorzAlign = System.Drawing.StringAlignment.Near;
            this.HeaderStyle.ImageSet = null;
            this.HeaderStyle.Indent = 0;
            this.HeaderStyle.SpacingAdjustment = new System.Drawing.Size(0, 0);
            this.HeaderStyle.TextColor = System.Drawing.Color.Empty;
            this.HeaderStyle.VertAlign = System.Drawing.StringAlignment.Center;
            // 
            // TypeStyle
            // 
            this.TypeStyle.BackColor = System.Drawing.Color.Transparent;
            this.TypeStyle.Description = "";
            this.TypeStyle.Font = null;
            this.TypeStyle.HorzAlign = System.Drawing.StringAlignment.Near;
            this.TypeStyle.ImageSet = null;
            this.TypeStyle.Indent = 0;
            this.TypeStyle.SpacingAdjustment = new System.Drawing.Size(-4, 0);
            this.TypeStyle.TextColor = System.Drawing.Color.Empty;
            this.TypeStyle.VertAlign = System.Drawing.StringAlignment.Center;
            // 
            // SectionHeaderStyle
            // 
            this.SectionHeaderStyle.BackColor = System.Drawing.Color.Transparent;
            this.SectionHeaderStyle.Description = "";
            this.SectionHeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SectionHeaderStyle.HorzAlign = System.Drawing.StringAlignment.Near;
            this.SectionHeaderStyle.ImageSet = null;
            this.SectionHeaderStyle.Indent = 0;
            this.SectionHeaderStyle.SpacingAdjustment = new System.Drawing.Size(2, 0);
            this.SectionHeaderStyle.TextColor = System.Drawing.Color.White;
            this.SectionHeaderStyle.VertAlign = System.Drawing.StringAlignment.Center;
            // 
            // xpPanelGroup1
            // 
            this.xpPanelGroup1.AutoScroll = true;
            this.xpPanelGroup1.BackColor = System.Drawing.Color.Transparent;
            this.xpPanelGroup1.Controls.Add(this.xpMyProperties);
            this.xpPanelGroup1.Controls.Add(this.xppnlMyMessages);
            this.xpPanelGroup1.Controls.Add(this.xppnlFind);
            this.xpPanelGroup1.Controls.Add(this.xpNewBuildingProperties);
            this.xpPanelGroup1.Controls.Add(this.xpNewLandProperties);
            this.xpPanelGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xpPanelGroup1.Location = new System.Drawing.Point(0, 0);
            this.xpPanelGroup1.Name = "xpPanelGroup1";
            this.xpPanelGroup1.PanelGradient = ((UIComponents.GradientColor)(resources.GetObject("xpPanelGroup1.PanelGradient")));
            this.xpPanelGroup1.Size = new System.Drawing.Size(357, 570);
            this.xpPanelGroup1.TabIndex = 4;
            // 
            // xpMyProperties
            // 
            this.xpMyProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpMyProperties.BackColor = System.Drawing.Color.Transparent;
            this.xpMyProperties.Caption = "My Properties";
            this.xpMyProperties.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xpMyProperties.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.xpMyProperties.CaptionGradient.Start = System.Drawing.Color.White;
            this.xpMyProperties.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpMyProperties.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xpMyProperties.CollapsedGlyphs.ImageSet = null;
            this.xpMyProperties.Controls.Add(this.label3);
            this.xpMyProperties.Controls.Add(this.numericUpDown3);
            this.xpMyProperties.Controls.Add(this.button5);
            this.xpMyProperties.Controls.Add(this.button6);
            this.xpMyProperties.Controls.Add(this.dtgrdMyProperties);
            this.xpMyProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.xpMyProperties.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xpMyProperties.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xpMyProperties.ImageItems.Highlight = 0;
            this.xpMyProperties.ImageItems.ImageSet = this.MediaItemImageSet;
            this.xpMyProperties.ImageItems.Normal = 0;
            this.xpMyProperties.ImageItems.Pressed = 0;
            this.xpMyProperties.Location = new System.Drawing.Point(8, 248);
            this.xpMyProperties.Name = "xpMyProperties";
            this.xpMyProperties.PanelGradient.End = System.Drawing.Color.LightGray;
            this.xpMyProperties.PanelGradient.Start = System.Drawing.Color.LightGray;
            this.xpMyProperties.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpMyProperties.PanelState = UIComponents.XPPanelState.Collapsed;
            this.xpMyProperties.Size = new System.Drawing.Size(341, 52);
            this.xpMyProperties.TabIndex = 7;
            this.xpMyProperties.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.xpMyProperties.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.xpMyProperties.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xpMyProperties.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(193, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 64;
            this.label3.Text = "List Amount";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(266, 63);
            this.numericUpDown3.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown3.TabIndex = 63;
            this.numericUpDown3.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(97, 60);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 62;
            this.button5.Text = "Next >>";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(17, 60);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 61;
            this.button6.Text = "<< Prev";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // dtgrdMyProperties
            // 
            this.dtgrdMyProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgrdMyProperties.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgrdMyProperties.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgrdMyProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgrdMyProperties.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgrdMyProperties.Location = new System.Drawing.Point(1, 89);
            this.dtgrdMyProperties.Name = "dtgrdMyProperties";
            this.dtgrdMyProperties.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgrdMyProperties.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgrdMyProperties.Size = new System.Drawing.Size(588, 38);
            this.dtgrdMyProperties.TabIndex = 2;
            // 
            // MediaItemImageSet
            // 
            this.MediaItemImageSet.Images.AddRange(new System.Drawing.Image[] {
            ((System.Drawing.Image)(resources.GetObject("MediaItemImageSet.Images"))),
            ((System.Drawing.Image)(resources.GetObject("MediaItemImageSet.Images1"))),
            ((System.Drawing.Image)(resources.GetObject("MediaItemImageSet.Images2"))),
            ((System.Drawing.Image)(resources.GetObject("MediaItemImageSet.Images3"))),
            ((System.Drawing.Image)(resources.GetObject("MediaItemImageSet.Images4")))});
            this.MediaItemImageSet.Size = new System.Drawing.Size(48, 48);
            this.MediaItemImageSet.TransparentColor = System.Drawing.Color.Empty;
            // 
            // xppnlMyMessages
            // 
            this.xppnlMyMessages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xppnlMyMessages.BackColor = System.Drawing.Color.Transparent;
            this.xppnlMyMessages.Caption = "My Messages";
            this.xppnlMyMessages.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xppnlMyMessages.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.xppnlMyMessages.CaptionGradient.Start = System.Drawing.Color.White;
            this.xppnlMyMessages.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xppnlMyMessages.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xppnlMyMessages.CollapsedGlyphs.Highlight = 1;
            this.xppnlMyMessages.CollapsedGlyphs.ImageSet = this.purpleGlyphsImageSet;
            this.xppnlMyMessages.CollapsedGlyphs.Normal = 0;
            this.xppnlMyMessages.CollapsedGlyphs.Pressed = 1;
            this.xppnlMyMessages.Controls.Add(this.label11);
            this.xppnlMyMessages.Controls.Add(this.numNumberToDisplay);
            this.xppnlMyMessages.Controls.Add(this.cmdNextTen);
            this.xppnlMyMessages.Controls.Add(this.cmdPrevious);
            this.xppnlMyMessages.Controls.Add(this.dtgrdMyMessages);
            this.xppnlMyMessages.ExpandedGlyphs.Highlight = 3;
            this.xppnlMyMessages.ExpandedGlyphs.ImageSet = this.purpleGlyphsImageSet;
            this.xppnlMyMessages.ExpandedGlyphs.Normal = 2;
            this.xppnlMyMessages.ExpandedGlyphs.Pressed = 3;
            this.xppnlMyMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.xppnlMyMessages.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xppnlMyMessages.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xppnlMyMessages.ImageItems.Highlight = 3;
            this.xppnlMyMessages.ImageItems.ImageSet = this.MediaItemImageSet;
            this.xppnlMyMessages.ImageItems.Normal = 4;
            this.xppnlMyMessages.ImageItems.Pressed = 3;
            this.xppnlMyMessages.Location = new System.Drawing.Point(8, 188);
            this.xppnlMyMessages.Name = "xppnlMyMessages";
            this.xppnlMyMessages.PanelGradient.End = System.Drawing.Color.LightGray;
            this.xppnlMyMessages.PanelGradient.Start = System.Drawing.Color.LightGray;
            this.xppnlMyMessages.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xppnlMyMessages.PanelState = UIComponents.XPPanelState.Collapsed;
            this.xppnlMyMessages.Size = new System.Drawing.Size(341, 52);
            this.xppnlMyMessages.TabIndex = 6;
            this.xppnlMyMessages.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.xppnlMyMessages.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.xppnlMyMessages.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xppnlMyMessages.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // purpleGlyphsImageSet
            // 
            this.purpleGlyphsImageSet.Images.AddRange(new System.Drawing.Image[] {
            ((System.Drawing.Image)(resources.GetObject("purpleGlyphsImageSet.Images"))),
            ((System.Drawing.Image)(resources.GetObject("purpleGlyphsImageSet.Images1"))),
            ((System.Drawing.Image)(resources.GetObject("purpleGlyphsImageSet.Images2"))),
            ((System.Drawing.Image)(resources.GetObject("purpleGlyphsImageSet.Images3")))});
            this.purpleGlyphsImageSet.Size = new System.Drawing.Size(21, 21);
            this.purpleGlyphsImageSet.TransparentColor = System.Drawing.Color.Empty;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(193, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 13);
            this.label11.TabIndex = 64;
            this.label11.Text = "List Amount";
            // 
            // numNumberToDisplay
            // 
            this.numNumberToDisplay.Location = new System.Drawing.Point(266, 62);
            this.numNumberToDisplay.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numNumberToDisplay.Name = "numNumberToDisplay";
            this.numNumberToDisplay.Size = new System.Drawing.Size(50, 20);
            this.numNumberToDisplay.TabIndex = 63;
            this.numNumberToDisplay.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // cmdNextTen
            // 
            this.cmdNextTen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdNextTen.Location = new System.Drawing.Point(97, 59);
            this.cmdNextTen.Name = "cmdNextTen";
            this.cmdNextTen.Size = new System.Drawing.Size(75, 23);
            this.cmdNextTen.TabIndex = 62;
            this.cmdNextTen.Text = "Next >>";
            this.cmdNextTen.UseVisualStyleBackColor = true;
            // 
            // cmdPrevious
            // 
            this.cmdPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPrevious.Location = new System.Drawing.Point(17, 59);
            this.cmdPrevious.Name = "cmdPrevious";
            this.cmdPrevious.Size = new System.Drawing.Size(75, 23);
            this.cmdPrevious.TabIndex = 61;
            this.cmdPrevious.Text = "<< Prev";
            this.cmdPrevious.UseVisualStyleBackColor = true;
            // 
            // dtgrdMyMessages
            // 
            this.dtgrdMyMessages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgrdMyMessages.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgrdMyMessages.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgrdMyMessages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgrdMyMessages.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtgrdMyMessages.Location = new System.Drawing.Point(0, 88);
            this.dtgrdMyMessages.Name = "dtgrdMyMessages";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgrdMyMessages.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dtgrdMyMessages.Size = new System.Drawing.Size(606, 120);
            this.dtgrdMyMessages.TabIndex = 0;
            // 
            // xppnlFind
            // 
            this.xppnlFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xppnlFind.BackColor = System.Drawing.Color.Transparent;
            this.xppnlFind.Caption = "Find";
            this.xppnlFind.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xppnlFind.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.xppnlFind.CaptionGradient.Start = System.Drawing.Color.White;
            this.xppnlFind.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xppnlFind.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xppnlFind.CollapsedGlyphs.ImageSet = null;
            this.xppnlFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.xppnlFind.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xppnlFind.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xppnlFind.ImageItems.Highlight = 0;
            this.xppnlFind.ImageItems.ImageSet = this.MediaItemImageSet;
            this.xppnlFind.ImageItems.Normal = 0;
            this.xppnlFind.ImageItems.Pressed = 0;
            this.xppnlFind.Location = new System.Drawing.Point(8, 128);
            this.xppnlFind.Name = "xppnlFind";
            this.xppnlFind.PanelGradient.End = System.Drawing.Color.LightGray;
            this.xppnlFind.PanelGradient.Start = System.Drawing.Color.LightGray;
            this.xppnlFind.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xppnlFind.PanelState = UIComponents.XPPanelState.Collapsed;
            this.xppnlFind.Size = new System.Drawing.Size(341, 52);
            this.xppnlFind.TabIndex = 5;
            this.xppnlFind.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.xppnlFind.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.xppnlFind.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xppnlFind.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // xpNewBuildingProperties
            // 
            this.xpNewBuildingProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpNewBuildingProperties.BackColor = System.Drawing.Color.Transparent;
            this.xpNewBuildingProperties.Caption = "New Building Properties";
            this.xpNewBuildingProperties.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xpNewBuildingProperties.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.xpNewBuildingProperties.CaptionGradient.Start = System.Drawing.Color.White;
            this.xpNewBuildingProperties.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpNewBuildingProperties.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xpNewBuildingProperties.CollapsedGlyphs.ImageSet = null;
            this.xpNewBuildingProperties.Controls.Add(this.label2);
            this.xpNewBuildingProperties.Controls.Add(this.numericUpDown2);
            this.xpNewBuildingProperties.Controls.Add(this.button3);
            this.xpNewBuildingProperties.Controls.Add(this.button4);
            this.xpNewBuildingProperties.Controls.Add(this.dtgrdBuildingProperties);
            this.xpNewBuildingProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.xpNewBuildingProperties.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xpNewBuildingProperties.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xpNewBuildingProperties.ImageItems.Highlight = 0;
            this.xpNewBuildingProperties.ImageItems.ImageSet = this.MediaItemImageSet;
            this.xpNewBuildingProperties.ImageItems.Normal = 0;
            this.xpNewBuildingProperties.ImageItems.Pressed = 0;
            this.xpNewBuildingProperties.Location = new System.Drawing.Point(8, 68);
            this.xpNewBuildingProperties.Name = "xpNewBuildingProperties";
            this.xpNewBuildingProperties.PanelGradient.End = System.Drawing.Color.LightGray;
            this.xpNewBuildingProperties.PanelGradient.Start = System.Drawing.Color.LightGray;
            this.xpNewBuildingProperties.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpNewBuildingProperties.PanelState = UIComponents.XPPanelState.Collapsed;
            this.xpNewBuildingProperties.Size = new System.Drawing.Size(341, 52);
            this.xpNewBuildingProperties.TabIndex = 2;
            this.xpNewBuildingProperties.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.xpNewBuildingProperties.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.xpNewBuildingProperties.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xpNewBuildingProperties.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 64;
            this.label2.Text = "List Amount";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(266, 63);
            this.numericUpDown2.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown2.TabIndex = 63;
            this.numericUpDown2.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(97, 60);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 62;
            this.button3.Text = "Next >>";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(17, 60);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 61;
            this.button4.Text = "<< Prev";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // dtgrdBuildingProperties
            // 
            this.dtgrdBuildingProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgrdBuildingProperties.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgrdBuildingProperties.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dtgrdBuildingProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgrdBuildingProperties.DefaultCellStyle = dataGridViewCellStyle8;
            this.dtgrdBuildingProperties.Location = new System.Drawing.Point(0, 89);
            this.dtgrdBuildingProperties.Name = "dtgrdBuildingProperties";
            this.dtgrdBuildingProperties.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgrdBuildingProperties.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dtgrdBuildingProperties.Size = new System.Drawing.Size(465, 133);
            this.dtgrdBuildingProperties.TabIndex = 1;
            // 
            // xpNewLandProperties
            // 
            this.xpNewLandProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpNewLandProperties.BackColor = System.Drawing.Color.Transparent;
            this.xpNewLandProperties.Caption = "Today\'s New Land Properties";
            this.xpNewLandProperties.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xpNewLandProperties.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.xpNewLandProperties.CaptionGradient.Start = System.Drawing.Color.White;
            this.xpNewLandProperties.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpNewLandProperties.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xpNewLandProperties.CollapsedGlyphs.Disabled = 9;
            this.xpNewLandProperties.CollapsedGlyphs.Highlight = 10;
            this.xpNewLandProperties.CollapsedGlyphs.ImageSet = null;
            this.xpNewLandProperties.CollapsedGlyphs.Normal = 8;
            this.xpNewLandProperties.CollapsedGlyphs.Pressed = 10;
            this.xpNewLandProperties.Controls.Add(this.label1);
            this.xpNewLandProperties.Controls.Add(this.numericUpDown1);
            this.xpNewLandProperties.Controls.Add(this.button1);
            this.xpNewLandProperties.Controls.Add(this.button2);
            this.xpNewLandProperties.Controls.Add(this.dtgrdLandProperties);
            this.xpNewLandProperties.CurveRadius = 12;
            this.xpNewLandProperties.ExpandedGlyphs.Highlight = 5;
            this.xpNewLandProperties.ExpandedGlyphs.ImageSet = null;
            this.xpNewLandProperties.ExpandedGlyphs.Normal = 4;
            this.xpNewLandProperties.ExpandedGlyphs.Pressed = 6;
            this.xpNewLandProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.xpNewLandProperties.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xpNewLandProperties.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xpNewLandProperties.ImageItems.Highlight = 1;
            this.xpNewLandProperties.ImageItems.ImageSet = this.MediaItemImageSet;
            this.xpNewLandProperties.ImageItems.Normal = 2;
            this.xpNewLandProperties.ImageItems.Pressed = 1;
            this.xpNewLandProperties.Location = new System.Drawing.Point(8, 8);
            this.xpNewLandProperties.Name = "xpNewLandProperties";
            this.xpNewLandProperties.PanelGradient.End = System.Drawing.Color.LightGray;
            this.xpNewLandProperties.PanelGradient.Start = System.Drawing.Color.LightGray;
            this.xpNewLandProperties.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpNewLandProperties.PanelState = UIComponents.XPPanelState.Collapsed;
            this.xpNewLandProperties.Size = new System.Drawing.Size(341, 52);
            this.xpNewLandProperties.TabIndex = 1;
            this.xpNewLandProperties.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.xpNewLandProperties.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.xpNewLandProperties.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xpNewLandProperties.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(193, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 64;
            this.label1.Text = "List Amount";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(266, 64);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown1.TabIndex = 63;
            this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(97, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 62;
            this.button1.Text = "Next >>";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(17, 61);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 61;
            this.button2.Text = "<< Prev";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // dtgrdLandProperties
            // 
            this.dtgrdLandProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgrdLandProperties.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgrdLandProperties.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dtgrdLandProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgrdLandProperties.DefaultCellStyle = dataGridViewCellStyle11;
            this.dtgrdLandProperties.Location = new System.Drawing.Point(0, 90);
            this.dtgrdLandProperties.Name = "dtgrdLandProperties";
            this.dtgrdLandProperties.ReadOnly = true;
            this.dtgrdLandProperties.Size = new System.Drawing.Size(470, 133);
            this.dtgrdLandProperties.TabIndex = 1;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList2.Images.SetKeyName(0, "");
            this.imageList2.Images.SetKeyName(1, "");
            // 
            // frmPropertyFinder
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(122)))), ((int)(((byte)(215)))));
            this.ClientSize = new System.Drawing.Size(357, 570);
            this.Controls.Add(this.xpPanelGroup1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPropertyFinder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Today\'s New Properties";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmPropertyFinder_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPropertyFinder_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.xpPanelGroup1)).EndInit();
            this.xpPanelGroup1.ResumeLayout(false);
            this.xpMyProperties.ResumeLayout(false);
            this.xpMyProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdMyProperties)).EndInit();
            this.xppnlMyMessages.ResumeLayout(false);
            this.xppnlMyMessages.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberToDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdMyMessages)).EndInit();
            this.xpNewBuildingProperties.ResumeLayout(false);
            this.xpNewBuildingProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdBuildingProperties)).EndInit();
            this.xpNewLandProperties.ResumeLayout(false);
            this.xpNewLandProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdLandProperties)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			Application.Run(new frmPropertyFinder()) ;
		}

        private void frmPropertyFinder_Load(object sender, EventArgs e)
        {
            LoadMyMessages();
            LoadNewLandColumns();
            LoadNewBuildingColumns();
            LoadNewMyPropertiesColumns();
           
            xpMyProperties.PanelState = XPPanelState.Expanded;
            xppnlMyMessages.PanelState = XPPanelState.Expanded;
            xpNewBuildingProperties.PanelState = XPPanelState.Collapsed;
            xpNewLandProperties.PanelState = XPPanelState.Collapsed;

            xpMyProperties.PanelState = XPPanelState.Collapsed;
            xppnlMyMessages.PanelState = XPPanelState.Collapsed;
            xpNewBuildingProperties.PanelState = XPPanelState.Expanded;
            xpNewLandProperties.PanelState = XPPanelState.Expanded;


        }

        private void LoadMyMessages()
        {
            try
            {
                dtgrdMyMessages.Columns.Add("CUSTOMERID", "CUSTOMERID");
                dtgrdMyMessages.Columns.Add("CUSTOMERSNO", "CUSTOMERSNO");
                dtgrdMyMessages.Columns.Add("CUSTOMERNAME", "NAME");
                dtgrdMyMessages.Columns.Add("MESSAGE", "MESSAGE");
                dtgrdMyMessages.Columns.Add("DATESENT", "DATE SENT");
                dtgrdMyMessages.Columns.Add("TIMESENT", "TIME SENT");
                dtgrdMyMessages.Columns.Add("MESSAGESOURCE", "MESSAGE SOURCE");
                dtgrdMyMessages.Columns["MESSAGESOURCE"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                dtgrdMyMessages.ReadOnly = true;
                dtgrdMyMessages.Columns["CUSTOMERID"].Visible = false;
               
            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {


            }

        }
		
        private void LoadNewLandColumns()
        {
            try
            {
                dtgrdLandProperties.Columns.Add("PLOTID", "PLOTID");
                dtgrdLandProperties.Columns.Add("PRICE", "PRICE");
                dtgrdLandProperties.Columns.Add("SALEORRENT", "SALE OR RENT");
                dtgrdLandProperties.Columns.Add("LOCALITY", "LOCALITY");
                dtgrdLandProperties.Columns.Add("COUNTY", "COUNTY");
                dtgrdLandProperties.Columns.Add("DETAILS", "DETAILS");
                dtgrdLandProperties.Columns.Add("PLOTNO", "PLOTNO");
                dtgrdLandProperties.Columns.Add("PLOTAREA", "PLOTAREA");
                dtgrdLandProperties.ReadOnly = true;
                dtgrdLandProperties.Columns["PLOTID"].Visible = false;               

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {


            }

        }

        private void LoadNewBuildingColumns()
        {
            try
            {
                dtgrdBuildingProperties.Columns.Add("BUILDINGID", "BUILDING ID");
                dtgrdBuildingProperties.Columns.Add("PRICE", "PRICE");
                dtgrdBuildingProperties.Columns.Add("HOUSENUMBER", "HOUSENUMBER");
                dtgrdBuildingProperties.Columns.Add("SALEORRENT", "SALE OR RENT");
                dtgrdBuildingProperties.Columns.Add("LOCALITY", "LOCALITY");
                dtgrdBuildingProperties.Columns.Add("COUNTY", "COUNTY");
                dtgrdBuildingProperties.Columns.Add("DETAILS", "DETAILS");
                dtgrdBuildingProperties.Columns.Add("NOOFROOMS", "NOOFROOMS");
                dtgrdBuildingProperties.Columns.Add("LIVINGAREA", "LIVINGAREA");
                dtgrdBuildingProperties.ReadOnly = true;
                dtgrdBuildingProperties.Columns["BUILDINGID"].Visible = false;
            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {


            }

        }

        private void LoadNewMyPropertiesColumns()
        {
            try
            {
                dtgrdMyProperties.Columns.Add("ASSETID", "ASSETID");

                dtgrdMyProperties.Columns.Add("PROPERTYTYPE", "PROPERTY TYPE");
                dtgrdMyProperties.Columns["PROPERTYTYPE"].ReadOnly = true;
                dtgrdMyProperties.Columns.Add("SALEORRENT", "SALE OR LEASE");
                dtgrdMyProperties.Columns["SALEORRENT"].ReadOnly = true;
                dtgrdMyProperties.Columns.Add("PRICE", "PRICE");
                dtgrdMyProperties.Columns["PRICE"].ReadOnly = true;
                dtgrdMyProperties.Columns.Add("LOCALITY", "LOCALITY");
                dtgrdMyProperties.Columns["LOCALITY"].ReadOnly = true;
                dtgrdMyProperties.Columns.Add("COUNTY", "COUNTY");
                dtgrdMyProperties.Columns["COUNTY"].ReadOnly = true;
                dtgrdMyProperties.Columns.Add("DETAILS", "DETAILS");
                dtgrdMyProperties.Columns["DETAILS"].ReadOnly = false;
                dtgrdMyProperties.Columns.Add("NOOFROOMS", "NOOFROOMS");
                dtgrdMyProperties.Columns["NOOFROOMS"].ReadOnly = true;
                dtgrdMyProperties.Columns.Add("LIVINGAREA", "LIVINGAREA");
                dtgrdMyProperties.Columns["LIVINGAREA"].ReadOnly = false;

                dtgrdMyProperties.Columns["ASSETID"].Visible = false;

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {


            }

        }

        private void frmPropertyFinder_FormClosing(Object sender, FormClosingEventArgs e)
        {
            MainForm frmMain = (MainForm)Application.OpenForms["MainForm"];
            frmMain.ClosePropertyFinderForm();
        }

	}
}