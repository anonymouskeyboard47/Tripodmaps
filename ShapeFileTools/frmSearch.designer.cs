namespace Tripodmaps
{
    partial class frmSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearch));
            this.dtgrdvwFind = new System.Windows.Forms.DataGridView();
            this.cmbAgentType = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.chkControlledArea = new System.Windows.Forms.CheckBox();
            this.cmbFindSubCriteria = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmdFind = new System.Windows.Forms.Button();
            this.txtMaxValue = new System.Windows.Forms.TextBox();
            this.txtMinValue = new System.Windows.Forms.TextBox();
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
            this.chkExactValue = new System.Windows.Forms.CheckBox();
            this.chkFilterByValue = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdvwFind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberToDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgrdvwFind
            // 
            this.dtgrdvwFind.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgrdvwFind.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrdvwFind.Location = new System.Drawing.Point(2, 146);
            this.dtgrdvwFind.Name = "dtgrdvwFind";
            this.dtgrdvwFind.Size = new System.Drawing.Size(800, 144);
            this.dtgrdvwFind.TabIndex = 0;
            this.dtgrdvwFind.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgrdvwFind_CellDoubleClick);
            this.dtgrdvwFind.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgrdvwFind_CellClick);
            this.dtgrdvwFind.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgrdvwFind_CellContentClick);
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
            this.cmbAgentType.Location = new System.Drawing.Point(79, 83);
            this.cmbAgentType.Name = "cmbAgentType";
            this.cmbAgentType.Size = new System.Drawing.Size(291, 23);
            this.cmbAgentType.TabIndex = 92;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(11, 83);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(67, 15);
            this.label16.TabIndex = 93;
            this.label16.Text = "Agent Type";
            // 
            // chkControlledArea
            // 
            this.chkControlledArea.AutoSize = true;
            this.chkControlledArea.Location = new System.Drawing.Point(456, 99);
            this.chkControlledArea.Name = "chkControlledArea";
            this.chkControlledArea.Size = new System.Drawing.Size(251, 17);
            this.chkControlledArea.TabIndex = 90;
            this.chkControlledArea.Text = "Filter property only in a controlled planned Areas";
            this.chkControlledArea.UseVisualStyleBackColor = true;
            // 
            // cmbFindSubCriteria
            // 
            this.cmbFindSubCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFindSubCriteria.DropDownWidth = 350;
            this.cmbFindSubCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFindSubCriteria.FormattingEnabled = true;
            this.cmbFindSubCriteria.Location = new System.Drawing.Point(456, 3);
            this.cmbFindSubCriteria.Name = "cmbFindSubCriteria";
            this.cmbFindSubCriteria.Size = new System.Drawing.Size(289, 23);
            this.cmbFindSubCriteria.TabIndex = 88;
            this.cmbFindSubCriteria.SelectedIndexChanged += new System.EventHandler(this.cmbFindSubCriteria_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(1, 3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 15);
            this.label12.TabIndex = 89;
            this.label12.Text = "Main Criteria";
            // 
            // cmdFind
            // 
            this.cmdFind.Image = global::Tripodmaps.Properties.Resources.Find_icon2424;
            this.cmdFind.Location = new System.Drawing.Point(751, 3);
            this.cmdFind.Name = "cmdFind";
            this.cmdFind.Size = new System.Drawing.Size(46, 23);
            this.cmdFind.TabIndex = 87;
            this.cmdFind.UseVisualStyleBackColor = true;
            this.cmdFind.Click += new System.EventHandler(this.cmdFind_Click);
            // 
            // txtMaxValue
            // 
            this.txtMaxValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaxValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaxValue.Location = new System.Drawing.Point(456, 55);
            this.txtMaxValue.Name = "txtMaxValue";
            this.txtMaxValue.Size = new System.Drawing.Size(289, 21);
            this.txtMaxValue.TabIndex = 86;
            // 
            // txtMinValue
            // 
            this.txtMinValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMinValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinValue.Location = new System.Drawing.Point(79, 57);
            this.txtMinValue.Name = "txtMinValue";
            this.txtMinValue.Size = new System.Drawing.Size(288, 21);
            this.txtMinValue.TabIndex = 85;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(50, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 15);
            this.label10.TabIndex = 84;
            this.label10.Text = "Min";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(424, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 15);
            this.label9.TabIndex = 83;
            this.label9.Text = "Max";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(407, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 15);
            this.label8.TabIndex = 82;
            this.label8.Text = "Locality";
            // 
            // txtFindArea
            // 
            this.txtFindArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFindArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFindArea.Location = new System.Drawing.Point(456, 30);
            this.txtFindArea.Name = "txtFindArea";
            this.txtFindArea.Size = new System.Drawing.Size(289, 21);
            this.txtFindArea.TabIndex = 81;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 80;
            this.label1.Text = "Text to find";
            // 
            // txtFindValue
            // 
            this.txtFindValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFindValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFindValue.Location = new System.Drawing.Point(79, 31);
            this.txtFindValue.Name = "txtFindValue";
            this.txtFindValue.Size = new System.Drawing.Size(288, 21);
            this.txtFindValue.TabIndex = 78;
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
            this.cmbFindCriteria.Location = new System.Drawing.Point(79, 3);
            this.cmbFindCriteria.Name = "cmbFindCriteria";
            this.cmbFindCriteria.Size = new System.Drawing.Size(288, 23);
            this.cmbFindCriteria.TabIndex = 77;
            this.cmbFindCriteria.SelectedIndexChanged += new System.EventHandler(this.cmbFindCriteria_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(384, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 79;
            this.label2.Text = "Sub Criteria";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(170, 125);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 97;
            this.label11.Text = "List Amount";
            // 
            // numNumberToDisplay
            // 
            this.numNumberToDisplay.Location = new System.Drawing.Point(238, 122);
            this.numNumberToDisplay.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numNumberToDisplay.Name = "numNumberToDisplay";
            this.numNumberToDisplay.Size = new System.Drawing.Size(53, 20);
            this.numNumberToDisplay.TabIndex = 96;
            this.numNumberToDisplay.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numNumberToDisplay.ValueChanged += new System.EventHandler(this.numNumberToDisplay_ValueChanged);
            // 
            // cmdNextTen
            // 
            this.cmdNextTen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdNextTen.Location = new System.Drawing.Point(405, 119);
            this.cmdNextTen.Name = "cmdNextTen";
            this.cmdNextTen.Size = new System.Drawing.Size(75, 23);
            this.cmdNextTen.TabIndex = 95;
            this.cmdNextTen.Text = "Next >>";
            this.cmdNextTen.UseVisualStyleBackColor = true;
            this.cmdNextTen.Click += new System.EventHandler(this.cmdNextTen_Click);
            // 
            // cmdPrevious
            // 
            this.cmdPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPrevious.Location = new System.Drawing.Point(324, 119);
            this.cmdPrevious.Name = "cmdPrevious";
            this.cmdPrevious.Size = new System.Drawing.Size(75, 23);
            this.cmdPrevious.TabIndex = 94;
            this.cmdPrevious.Text = "<< Prev";
            this.cmdPrevious.UseVisualStyleBackColor = true;
            this.cmdPrevious.Click += new System.EventHandler(this.cmdPrevious_Click);
            // 
            // chkExactValue
            // 
            this.chkExactValue.AutoSize = true;
            this.chkExactValue.Location = new System.Drawing.Point(456, 81);
            this.chkExactValue.Name = "chkExactValue";
            this.chkExactValue.Size = new System.Drawing.Size(86, 17);
            this.chkExactValue.TabIndex = 99;
            this.chkExactValue.Text = "Exact Match";
            this.chkExactValue.UseVisualStyleBackColor = true;
            // 
            // chkFilterByValue
            // 
            this.chkFilterByValue.AutoSize = true;
            this.chkFilterByValue.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.chkFilterByValue.Location = new System.Drawing.Point(652, 81);
            this.chkFilterByValue.Name = "chkFilterByValue";
            this.chkFilterByValue.Size = new System.Drawing.Size(93, 17);
            this.chkFilterByValue.TabIndex = 98;
            this.chkFilterByValue.Text = "Filter By Value";
            this.chkFilterByValue.UseVisualStyleBackColor = true;
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(804, 293);
            this.Controls.Add(this.chkExactValue);
            this.Controls.Add(this.chkFilterByValue);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.numNumberToDisplay);
            this.Controls.Add(this.cmdNextTen);
            this.Controls.Add(this.cmdPrevious);
            this.Controls.Add(this.cmbAgentType);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.chkControlledArea);
            this.Controls.Add(this.cmbFindSubCriteria);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmdFind);
            this.Controls.Add(this.txtMaxValue);
            this.Controls.Add(this.txtMinValue);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtFindArea);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFindValue);
            this.Controls.Add(this.cmbFindCriteria);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtgrdvwFind);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSearch";
            this.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockBottomAutoHide;
            this.TabText = "Search Results";
            this.Text = "Search Results";
            this.Load += new System.EventHandler(this.frmSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdvwFind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberToDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgrdvwFind;
        private System.Windows.Forms.ComboBox cmbAgentType;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox chkControlledArea;
        private System.Windows.Forms.ComboBox cmbFindSubCriteria;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button cmdFind;
        private System.Windows.Forms.TextBox txtMaxValue;
        private System.Windows.Forms.TextBox txtMinValue;
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
        private System.Windows.Forms.CheckBox chkExactValue;
        private System.Windows.Forms.CheckBox chkFilterByValue;
    }
}
