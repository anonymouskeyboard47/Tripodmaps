namespace Tripodmaps
{
    partial class frmFind
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFind));
            this.statFind = new System.Windows.Forms.StatusStrip();
            this.statValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.statLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cmbAgentType = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.chkControlledArea = new System.Windows.Forms.CheckBox();
            this.cmbFindSubCriteria = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.chkExactValue = new System.Windows.Forms.CheckBox();
            this.cmdFind = new System.Windows.Forms.Button();
            this.grpGeoFilter = new System.Windows.Forms.GroupBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbFindDistrict = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbFindCounty = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbFindTownCity = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbFindCountry = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaxValue = new System.Windows.Forms.TextBox();
            this.txtMinValue = new System.Windows.Forms.TextBox();
            this.chkFilterByValue = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFindArea = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFindValue = new System.Windows.Forms.TextBox();
            this.cmbFindCriteria = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.numNumberToDisplay = new System.Windows.Forms.NumericUpDown();
            this.cmdNextTen = new System.Windows.Forms.Button();
            this.cmdPrevious = new System.Windows.Forms.Button();
            this.dtgrdvwFind = new System.Windows.Forms.DataGridView();
            this.tltpFindForm = new System.Windows.Forms.ToolTip(this.components);
            this.statFind.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpGeoFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberToDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdvwFind)).BeginInit();
            this.SuspendLayout();
            // 
            // statFind
            // 
            this.statFind.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statValue,
            this.statLabel1});
            this.statFind.Location = new System.Drawing.Point(0, 563);
            this.statFind.Name = "statFind";
            this.statFind.Size = new System.Drawing.Size(611, 22);
            this.statFind.TabIndex = 19;
            this.statFind.Text = "statusStrip1";
            // 
            // statValue
            // 
            this.statValue.Name = "statValue";
            this.statValue.Size = new System.Drawing.Size(0, 17);
            // 
            // statLabel1
            // 
            this.statLabel1.Name = "statLabel1";
            this.statLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(1, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cmbAgentType);
            this.splitContainer1.Panel1.Controls.Add(this.label16);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox1);
            this.splitContainer1.Panel1.Controls.Add(this.chkControlledArea);
            this.splitContainer1.Panel1.Controls.Add(this.cmbFindSubCriteria);
            this.splitContainer1.Panel1.Controls.Add(this.label12);
            this.splitContainer1.Panel1.Controls.Add(this.chkExactValue);
            this.splitContainer1.Panel1.Controls.Add(this.cmdFind);
            this.splitContainer1.Panel1.Controls.Add(this.grpGeoFilter);
            this.splitContainer1.Panel1.Controls.Add(this.txtMaxValue);
            this.splitContainer1.Panel1.Controls.Add(this.txtMinValue);
            this.splitContainer1.Panel1.Controls.Add(this.chkFilterByValue);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.txtFindArea);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.txtFindValue);
            this.splitContainer1.Panel1.Controls.Add(this.cmbFindCriteria);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label11);
            this.splitContainer1.Panel2.Controls.Add(this.numNumberToDisplay);
            this.splitContainer1.Panel2.Controls.Add(this.cmdNextTen);
            this.splitContainer1.Panel2.Controls.Add(this.cmdPrevious);
            this.splitContainer1.Panel2.Controls.Add(this.dtgrdvwFind);
            this.splitContainer1.Size = new System.Drawing.Size(978, 558);
            this.splitContainer1.SplitterDistance = 262;
            this.splitContainer1.SplitterWidth = 10;
            this.splitContainer1.TabIndex = 57;
            // 
            // cmbAgentType
            // 
            this.cmbAgentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAgentType.DropDownWidth = 420;
            this.cmbAgentType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAgentType.FormattingEnabled = true;
            this.cmbAgentType.Items.AddRange(new object[] {
            "All",
            "Registered Valuers, Banks, Mortgage Lenders, Estate and Managing Agents",
            "Registered Valuers",
            "Other Agents"});
            this.cmbAgentType.Location = new System.Drawing.Point(83, 227);
            this.cmbAgentType.Name = "cmbAgentType";
            this.cmbAgentType.Size = new System.Drawing.Size(291, 23);
            this.cmbAgentType.TabIndex = 75;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(14, 228);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(67, 15);
            this.label16.TabIndex = 76;
            this.label16.Text = "Agent Type";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(288, 72);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(86, 17);
            this.checkBox1.TabIndex = 74;
            this.checkBox1.Text = "Strict Control";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // chkControlledArea
            // 
            this.chkControlledArea.AutoSize = true;
            this.chkControlledArea.Location = new System.Drawing.Point(84, 71);
            this.chkControlledArea.Name = "chkControlledArea";
            this.chkControlledArea.Size = new System.Drawing.Size(205, 17);
            this.chkControlledArea.TabIndex = 73;
            this.chkControlledArea.Text = "Filter only in a controlled planned Area";
            this.chkControlledArea.UseVisualStyleBackColor = true;
            // 
            // cmbFindSubCriteria
            // 
            this.cmbFindSubCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFindSubCriteria.DropDownWidth = 350;
            this.cmbFindSubCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFindSubCriteria.FormattingEnabled = true;
            this.cmbFindSubCriteria.Location = new System.Drawing.Point(83, 41);
            this.cmbFindSubCriteria.Name = "cmbFindSubCriteria";
            this.cmbFindSubCriteria.Size = new System.Drawing.Size(289, 23);
            this.cmbFindSubCriteria.TabIndex = 71;
            this.cmbFindSubCriteria.SelectedIndexChanged += new System.EventHandler(this.cmbFindSubCriteria_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(4, 4);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 15);
            this.label12.TabIndex = 72;
            this.label12.Text = "Main Criteria";
            // 
            // chkExactValue
            // 
            this.chkExactValue.AutoSize = true;
            this.chkExactValue.Location = new System.Drawing.Point(379, 96);
            this.chkExactValue.Name = "chkExactValue";
            this.chkExactValue.Size = new System.Drawing.Size(86, 17);
            this.chkExactValue.TabIndex = 70;
            this.chkExactValue.Text = "Exact Match";
            this.chkExactValue.UseVisualStyleBackColor = true;
            // 
            // cmdFind
            // 
            this.cmdFind.Image = global::Tripodmaps.Properties.Resources.Find_icon2424;
            this.cmdFind.Location = new System.Drawing.Point(379, 41);
            this.cmdFind.Name = "cmdFind";
            this.cmdFind.Size = new System.Drawing.Size(46, 23);
            this.cmdFind.TabIndex = 69;
            this.cmdFind.UseVisualStyleBackColor = true;
            this.cmdFind.Click += new System.EventHandler(this.cmdFind_Click);
            // 
            // grpGeoFilter
            // 
            this.grpGeoFilter.Controls.Add(this.comboBox4);
            this.grpGeoFilter.Controls.Add(this.label15);
            this.grpGeoFilter.Controls.Add(this.comboBox3);
            this.grpGeoFilter.Controls.Add(this.label14);
            this.grpGeoFilter.Controls.Add(this.comboBox2);
            this.grpGeoFilter.Controls.Add(this.label13);
            this.grpGeoFilter.Controls.Add(this.comboBox1);
            this.grpGeoFilter.Controls.Add(this.label7);
            this.grpGeoFilter.Controls.Add(this.cmbFindDistrict);
            this.grpGeoFilter.Controls.Add(this.label6);
            this.grpGeoFilter.Controls.Add(this.cmbFindCounty);
            this.grpGeoFilter.Controls.Add(this.label5);
            this.grpGeoFilter.Controls.Add(this.cmbFindTownCity);
            this.grpGeoFilter.Controls.Add(this.label4);
            this.grpGeoFilter.Controls.Add(this.cmbFindCountry);
            this.grpGeoFilter.Controls.Add(this.label3);
            this.grpGeoFilter.Location = new System.Drawing.Point(471, 2);
            this.grpGeoFilter.Name = "grpGeoFilter";
            this.grpGeoFilter.Size = new System.Drawing.Size(384, 251);
            this.grpGeoFilter.TabIndex = 68;
            this.grpGeoFilter.TabStop = false;
            this.grpGeoFilter.Text = "Geo Filters";
            // 
            // comboBox4
            // 
            this.comboBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(95, 222);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(285, 23);
            this.comboBox4.TabIndex = 43;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(4, 225);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(93, 15);
            this.label15.TabIndex = 44;
            this.label15.Text = "Neighbourhood";
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(95, 193);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(285, 23);
            this.comboBox3.TabIndex = 41;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(18, 190);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 15);
            this.label14.TabIndex = 42;
            this.label14.Text = "Sub Location";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(95, 164);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(285, 23);
            this.comboBox2.TabIndex = 39;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(43, 161);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 15);
            this.label13.TabIndex = 40;
            this.label13.Text = "Location";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(95, 132);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(285, 23);
            this.comboBox1.TabIndex = 37;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(47, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 15);
            this.label7.TabIndex = 38;
            this.label7.Text = "Division";
            // 
            // cmbFindDistrict
            // 
            this.cmbFindDistrict.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFindDistrict.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFindDistrict.FormattingEnabled = true;
            this.cmbFindDistrict.Location = new System.Drawing.Point(95, 103);
            this.cmbFindDistrict.Name = "cmbFindDistrict";
            this.cmbFindDistrict.Size = new System.Drawing.Size(285, 23);
            this.cmbFindDistrict.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(53, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 15);
            this.label6.TabIndex = 36;
            this.label6.Text = "District";
            // 
            // cmbFindCounty
            // 
            this.cmbFindCounty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFindCounty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFindCounty.FormattingEnabled = true;
            this.cmbFindCounty.Location = new System.Drawing.Point(95, 73);
            this.cmbFindCounty.Name = "cmbFindCounty";
            this.cmbFindCounty.Size = new System.Drawing.Size(285, 23);
            this.cmbFindCounty.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(53, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 15);
            this.label5.TabIndex = 34;
            this.label5.Text = "County";
            // 
            // cmbFindTownCity
            // 
            this.cmbFindTownCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFindTownCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFindTownCity.FormattingEnabled = true;
            this.cmbFindTownCity.Location = new System.Drawing.Point(95, 44);
            this.cmbFindTownCity.Name = "cmbFindTownCity";
            this.cmbFindTownCity.Size = new System.Drawing.Size(284, 23);
            this.cmbFindTownCity.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 15);
            this.label4.TabIndex = 32;
            this.label4.Text = "Town or City";
            // 
            // cmbFindCountry
            // 
            this.cmbFindCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFindCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFindCountry.FormattingEnabled = true;
            this.cmbFindCountry.Items.AddRange(new object[] {
            "Kenya"});
            this.cmbFindCountry.Location = new System.Drawing.Point(95, 14);
            this.cmbFindCountry.Name = "cmbFindCountry";
            this.cmbFindCountry.Size = new System.Drawing.Size(284, 23);
            this.cmbFindCountry.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(49, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 15);
            this.label3.TabIndex = 30;
            this.label3.Text = "Country";
            // 
            // txtMaxValue
            // 
            this.txtMaxValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaxValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaxValue.Location = new System.Drawing.Point(82, 195);
            this.txtMaxValue.Name = "txtMaxValue";
            this.txtMaxValue.Size = new System.Drawing.Size(290, 21);
            this.txtMaxValue.TabIndex = 67;
            // 
            // txtMinValue
            // 
            this.txtMinValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMinValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinValue.Location = new System.Drawing.Point(82, 163);
            this.txtMinValue.Name = "txtMinValue";
            this.txtMinValue.Size = new System.Drawing.Size(290, 21);
            this.txtMinValue.TabIndex = 66;
            // 
            // chkFilterByValue
            // 
            this.chkFilterByValue.AutoSize = true;
            this.chkFilterByValue.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.chkFilterByValue.Location = new System.Drawing.Point(379, 166);
            this.chkFilterByValue.Name = "chkFilterByValue";
            this.chkFilterByValue.Size = new System.Drawing.Size(93, 17);
            this.chkFilterByValue.TabIndex = 65;
            this.chkFilterByValue.Text = "Filter By Value";
            this.chkFilterByValue.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(53, 163);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 15);
            this.label10.TabIndex = 64;
            this.label10.Text = "Min";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(50, 195);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 15);
            this.label9.TabIndex = 63;
            this.label9.Text = "Max";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(33, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 15);
            this.label8.TabIndex = 62;
            this.label8.Text = "Locality";
            // 
            // txtFindArea
            // 
            this.txtFindArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFindArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFindArea.Location = new System.Drawing.Point(83, 128);
            this.txtFindArea.Name = "txtFindArea";
            this.txtFindArea.Size = new System.Drawing.Size(289, 21);
            this.txtFindArea.TabIndex = 61;
            this.txtFindArea.TextChanged += new System.EventHandler(this.txtFindArea_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 60;
            this.label1.Text = "Text to find";
            // 
            // txtFindValue
            // 
            this.txtFindValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFindValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFindValue.Location = new System.Drawing.Point(83, 94);
            this.txtFindValue.Name = "txtFindValue";
            this.txtFindValue.Size = new System.Drawing.Size(289, 21);
            this.txtFindValue.TabIndex = 58;
            this.txtFindValue.TextChanged += new System.EventHandler(this.txtFindValue_TextChanged);
            this.txtFindValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFindValue_KeyDown);
            // 
            // cmbFindCriteria
            // 
            this.cmbFindCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFindCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFindCriteria.FormattingEnabled = true;
            this.cmbFindCriteria.Items.AddRange(new object[] {
            "Plot",
            "Points of Interest",
            "Buildings",
            "Roads",
            "Property Agents"});
            this.cmbFindCriteria.Location = new System.Drawing.Point(82, 4);
            this.cmbFindCriteria.Name = "cmbFindCriteria";
            this.cmbFindCriteria.Size = new System.Drawing.Size(289, 23);
            this.cmbFindCriteria.TabIndex = 57;
            this.cmbFindCriteria.SelectedIndexChanged += new System.EventHandler(this.cmbFindCriteria_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 59;
            this.label2.Text = "Sub Criteria";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(172, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 56;
            this.label11.Text = "List Amount";
            // 
            // numNumberToDisplay
            // 
            this.numNumberToDisplay.Location = new System.Drawing.Point(235, 8);
            this.numNumberToDisplay.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numNumberToDisplay.Name = "numNumberToDisplay";
            this.numNumberToDisplay.Size = new System.Drawing.Size(64, 20);
            this.numNumberToDisplay.TabIndex = 55;
            this.numNumberToDisplay.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numNumberToDisplay.ValueChanged += new System.EventHandler(this.numNumberToDisplay_ValueChanged);
            // 
            // cmdNextTen
            // 
            this.cmdNextTen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdNextTen.Location = new System.Drawing.Point(85, 6);
            this.cmdNextTen.Name = "cmdNextTen";
            this.cmdNextTen.Size = new System.Drawing.Size(75, 23);
            this.cmdNextTen.TabIndex = 54;
            this.cmdNextTen.Text = "Next >>";
            this.cmdNextTen.UseVisualStyleBackColor = true;
            this.cmdNextTen.Click += new System.EventHandler(this.cmdNextTen_Click);
            // 
            // cmdPrevious
            // 
            this.cmdPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPrevious.Location = new System.Drawing.Point(4, 6);
            this.cmdPrevious.Name = "cmdPrevious";
            this.cmdPrevious.Size = new System.Drawing.Size(75, 23);
            this.cmdPrevious.TabIndex = 53;
            this.cmdPrevious.Text = "<< Prev";
            this.cmdPrevious.UseVisualStyleBackColor = true;
            this.cmdPrevious.Click += new System.EventHandler(this.cmdPrevious_Click);
            // 
            // dtgrdvwFind
            // 
            this.dtgrdvwFind.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgrdvwFind.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrdvwFind.Location = new System.Drawing.Point(0, 35);
            this.dtgrdvwFind.Name = "dtgrdvwFind";
            this.dtgrdvwFind.Size = new System.Drawing.Size(610, 245);
            this.dtgrdvwFind.TabIndex = 9;
            this.dtgrdvwFind.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgrdvwFind_CellDoubleClick);
            this.dtgrdvwFind.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgrdvwFind_CellClick);
            this.dtgrdvwFind.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgrdvwFind_CellContentClick);
            // 
            // frmFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 585);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statFind);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(508, 536);
            this.Name = "frmFind";
            this.Text = "Find";
            this.Load += new System.EventHandler(this.frmFind_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFind_FormClosing);
            this.statFind.ResumeLayout(false);
            this.statFind.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.grpGeoFilter.ResumeLayout(false);
            this.grpGeoFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberToDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdvwFind)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statFind;
        private System.Windows.Forms.ToolStripStatusLabel statValue;
        private System.Windows.Forms.ToolStripStatusLabel statLabel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox chkControlledArea;
        private System.Windows.Forms.ComboBox cmbFindSubCriteria;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chkExactValue;
        private System.Windows.Forms.Button cmdFind;
        private System.Windows.Forms.GroupBox grpGeoFilter;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbFindDistrict;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbFindCounty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbFindTownCity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbFindCountry;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaxValue;
        private System.Windows.Forms.TextBox txtMinValue;
        private System.Windows.Forms.CheckBox chkFilterByValue;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFindArea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFindValue;
        private System.Windows.Forms.ComboBox cmbFindCriteria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numNumberToDisplay;
        private System.Windows.Forms.Button cmdNextTen;
        private System.Windows.Forms.Button cmdPrevious;
        private System.Windows.Forms.DataGridView dtgrdvwFind;
        private System.Windows.Forms.ComboBox cmbAgentType;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ToolTip tltpFindForm;
    }
}