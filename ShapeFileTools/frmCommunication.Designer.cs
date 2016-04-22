namespace DemoWinForm
{
    partial class frmCommunication
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.txtSourceIP = new System.Windows.Forms.TextBox();
            this.txtErrors = new System.Windows.Forms.TextBox();
            this.txtConsoleMessages = new System.Windows.Forms.TextBox();
            this.txtReceivedUDP = new System.Windows.Forms.TextBox();
            this.lblSourceIP = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCoordinates = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 429);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(776, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // txtSourceIP
            // 
            this.txtSourceIP.Location = new System.Drawing.Point(127, 6);
            this.txtSourceIP.Name = "txtSourceIP";
            this.txtSourceIP.Size = new System.Drawing.Size(508, 20);
            this.txtSourceIP.TabIndex = 1;
            // 
            // txtErrors
            // 
            this.txtErrors.Location = new System.Drawing.Point(127, 332);
            this.txtErrors.Multiline = true;
            this.txtErrors.Name = "txtErrors";
            this.txtErrors.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtErrors.Size = new System.Drawing.Size(508, 50);
            this.txtErrors.TabIndex = 2;
            // 
            // txtConsoleMessages
            // 
            this.txtConsoleMessages.Location = new System.Drawing.Point(127, 262);
            this.txtConsoleMessages.Multiline = true;
            this.txtConsoleMessages.Name = "txtConsoleMessages";
            this.txtConsoleMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConsoleMessages.Size = new System.Drawing.Size(508, 64);
            this.txtConsoleMessages.TabIndex = 3;
            // 
            // txtReceivedUDP
            // 
            this.txtReceivedUDP.Location = new System.Drawing.Point(127, 45);
            this.txtReceivedUDP.Multiline = true;
            this.txtReceivedUDP.Name = "txtReceivedUDP";
            this.txtReceivedUDP.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReceivedUDP.Size = new System.Drawing.Size(508, 211);
            this.txtReceivedUDP.TabIndex = 4;
            // 
            // lblSourceIP
            // 
            this.lblSourceIP.AutoSize = true;
            this.lblSourceIP.Location = new System.Drawing.Point(67, 6);
            this.lblSourceIP.Name = "lblSourceIP";
            this.lblSourceIP.Size = new System.Drawing.Size(54, 13);
            this.lblSourceIP.TabIndex = 5;
            this.lblSourceIP.Text = "Source IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "UDP Messages";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Console Messages";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(86, 332);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Errors";
            // 
            // txtCoordinates
            // 
            this.txtCoordinates.Location = new System.Drawing.Point(655, 6);
            this.txtCoordinates.Multiline = true;
            this.txtCoordinates.Name = "txtCoordinates";
            this.txtCoordinates.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCoordinates.Size = new System.Drawing.Size(100, 250);
            this.txtCoordinates.TabIndex = 9;
            // 
            // frmCommunication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 451);
            this.Controls.Add(this.txtCoordinates);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblSourceIP);
            this.Controls.Add(this.txtReceivedUDP);
            this.Controls.Add(this.txtConsoleMessages);
            this.Controls.Add(this.txtErrors);
            this.Controls.Add(this.txtSourceIP);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmCommunication";
            this.Text = "frmCommunication";
            this.Load += new System.EventHandler(this.frmCommunication_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TextBox txtSourceIP;
        private System.Windows.Forms.TextBox txtErrors;
        private System.Windows.Forms.TextBox txtConsoleMessages;
        private System.Windows.Forms.TextBox txtReceivedUDP;
        private System.Windows.Forms.Label lblSourceIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCoordinates;
    }
}