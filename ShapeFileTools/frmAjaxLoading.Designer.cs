namespace Tripodmaps
{
    partial class frmAjaxLoading
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAjaxLoading));
            this.picAjaxLoading = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picAjaxLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // picAjaxLoading
            // 
            this.picAjaxLoading.Image = global::Tripodmaps.Properties.Resources.ajax_loader_snake;
            this.picAjaxLoading.InitialImage = ((System.Drawing.Image)(resources.GetObject("picAjaxLoading.InitialImage")));
            this.picAjaxLoading.Location = new System.Drawing.Point(31, 16);
            this.picAjaxLoading.Name = "picAjaxLoading";
            this.picAjaxLoading.Size = new System.Drawing.Size(55, 46);
            this.picAjaxLoading.TabIndex = 0;
            this.picAjaxLoading.TabStop = false;
            // 
            // frmAjaxLoading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(109, 74);
            this.ControlBox = false;
            this.Controls.Add(this.picAjaxLoading);
            this.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAjaxLoading";
            this.Opacity = 0.7;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Please Wait ....";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Load += new System.EventHandler(this.frmLoading_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picAjaxLoading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picAjaxLoading;




    }
}