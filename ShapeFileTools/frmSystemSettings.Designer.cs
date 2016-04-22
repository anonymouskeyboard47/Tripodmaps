namespace DemoWinForm
{
    partial class frmSystemSettings
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
            this.tabGeneral = new System.Windows.Forms.TabControl();
            this.tabGeneralSettings = new System.Windows.Forms.TabPage();
            this.tabUserSettings = new System.Windows.Forms.TabPage();
            this.tabDisplaySettings = new System.Windows.Forms.TabPage();
            this.tabRoutingSettings = new System.Windows.Forms.TabPage();
            this.tabTrafficSettings = new System.Windows.Forms.TabPage();
            this.tabGeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.tabGeneralSettings);
            this.tabGeneral.Controls.Add(this.tabUserSettings);
            this.tabGeneral.Controls.Add(this.tabDisplaySettings);
            this.tabGeneral.Controls.Add(this.tabRoutingSettings);
            this.tabGeneral.Controls.Add(this.tabTrafficSettings);
            this.tabGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabGeneral.Location = new System.Drawing.Point(0, 0);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.SelectedIndex = 0;
            this.tabGeneral.Size = new System.Drawing.Size(747, 530);
            this.tabGeneral.TabIndex = 0;
            // 
            // tabGeneralSettings
            // 
            this.tabGeneralSettings.Location = new System.Drawing.Point(4, 22);
            this.tabGeneralSettings.Name = "tabGeneralSettings";
            this.tabGeneralSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneralSettings.Size = new System.Drawing.Size(739, 504);
            this.tabGeneralSettings.TabIndex = 0;
            this.tabGeneralSettings.Text = "General Settings";
            this.tabGeneralSettings.UseVisualStyleBackColor = true;
            // 
            // tabUserSettings
            // 
            this.tabUserSettings.Location = new System.Drawing.Point(4, 22);
            this.tabUserSettings.Name = "tabUserSettings";
            this.tabUserSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabUserSettings.Size = new System.Drawing.Size(739, 504);
            this.tabUserSettings.TabIndex = 1;
            this.tabUserSettings.Text = "User Settings";
            this.tabUserSettings.UseVisualStyleBackColor = true;
            // 
            // tabDisplaySettings
            // 
            this.tabDisplaySettings.Location = new System.Drawing.Point(4, 22);
            this.tabDisplaySettings.Name = "tabDisplaySettings";
            this.tabDisplaySettings.Size = new System.Drawing.Size(739, 504);
            this.tabDisplaySettings.TabIndex = 2;
            this.tabDisplaySettings.Text = "Display Settings";
            this.tabDisplaySettings.UseVisualStyleBackColor = true;
            // 
            // tabRoutingSettings
            // 
            this.tabRoutingSettings.Location = new System.Drawing.Point(4, 22);
            this.tabRoutingSettings.Name = "tabRoutingSettings";
            this.tabRoutingSettings.Size = new System.Drawing.Size(739, 504);
            this.tabRoutingSettings.TabIndex = 3;
            this.tabRoutingSettings.Text = "Routing Settings";
            this.tabRoutingSettings.UseVisualStyleBackColor = true;
            // 
            // tabTrafficSettings
            // 
            this.tabTrafficSettings.Location = new System.Drawing.Point(4, 22);
            this.tabTrafficSettings.Name = "tabTrafficSettings";
            this.tabTrafficSettings.Size = new System.Drawing.Size(739, 504);
            this.tabTrafficSettings.TabIndex = 4;
            this.tabTrafficSettings.Text = "Traffic Settings";
            this.tabTrafficSettings.UseVisualStyleBackColor = true;
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 530);
            this.Controls.Add(this.tabGeneral);
            this.Name = "Options";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.Options_Load);
            this.tabGeneral.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabGeneral;
        private System.Windows.Forms.TabPage tabGeneralSettings;
        private System.Windows.Forms.TabPage tabUserSettings;
        private System.Windows.Forms.TabPage tabDisplaySettings;
        private System.Windows.Forms.TabPage tabRoutingSettings;
        private System.Windows.Forms.TabPage tabTrafficSettings;
    }
}