namespace Tripodmaps
{
    partial class Licence
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Licence));
            this.rtbLicence = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnDontAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbLicence
            // 
            this.rtbLicence.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbLicence.DetectUrls = false;
            this.rtbLicence.Location = new System.Drawing.Point(12, 47);
            this.rtbLicence.Name = "rtbLicence";
            this.rtbLicence.ReadOnly = true;
            this.rtbLicence.Size = new System.Drawing.Size(594, 335);
            this.rtbLicence.TabIndex = 0;
            this.rtbLicence.Text = "";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(543, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please read the following licence agreement. You will need to accept the agreemen" +
                "t in order to use Tripodmaps data, tools, or features";
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnAccept.Location = new System.Drawing.Point(72, 390);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(225, 23);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "I Agree to Licence Terms. Please continue.";
            this.btnAccept.UseVisualStyleBackColor = true;
            // 
            // btnDontAccept
            // 
            this.btnDontAccept.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDontAccept.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDontAccept.Location = new System.Drawing.Point(306, 390);
            this.btnDontAccept.Name = "btnDontAccept";
            this.btnDontAccept.Size = new System.Drawing.Size(241, 23);
            this.btnDontAccept.TabIndex = 3;
            this.btnDontAccept.Text = "I DO NOT Agree to Licence Terms. Goodbye.";
            this.btnDontAccept.UseVisualStyleBackColor = true;
            // 
            // Licence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 422);
            this.Controls.Add(this.btnDontAccept);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbLicence);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(626, 456);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(626, 456);
            this.Name = "Licence";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Licence Agreement";
            this.Load += new System.EventHandler(this.Licence_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbLicence;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnDontAccept;
    }
}