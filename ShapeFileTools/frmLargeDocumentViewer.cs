using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Tripodmaps
{
    public partial class frmLargeDocumentViewer : Form
    {
        private string errMessage;
        public frmLargeDocumentViewer()
        {
            InitializeComponent();
        }

        public void LoadDocument(string strFilePath)
        {
            try
            {
                //string strFilter = "Image Files (*.jpg,*.jpeg,*.png,*.bmp)|*.jpg;*.jpeg;*.png;*.bmp" +
                    //"|Movie Files (*.avi, *.mpeg,*.mpg)|*.avi;*.mpeg;*.mpg |PDF|*.pdf";

                if (File.Exists(strFilePath))
                {
                    if (strFilePath.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
                    {
                        pdfViewer.Visible = true;
                        panel1.Visible = false;
                        picDocument.Visible = false;
                        pdfViewer.FileName = strFilePath;
                    }

                    if (strFilePath.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase))
                    {
                        pdfViewer.Visible = false;
                        panel1.Visible = true;
                        picDocument.Visible = true;
                        picDocument.Image = Image.FromFile(strFilePath);

                        this.vScrollBar1.Maximum = this.picDocument.Image.Height - this.panel1.Height;
                        this.hScrollBar1.Maximum = this.picDocument.Image.Width - this.panel1.Width;

                        this.vScrollBar1.Maximum = this.picDocument.Image.Height - this.panel1.Height;
                        this.hScrollBar1.Maximum = this.picDocument.Image.Width - this.panel1.Width;

                    }

                    if (strFilePath.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase))
                    {
                        pdfViewer.Visible = false;
                        panel1.Visible = true;
                        picDocument.Visible = true;
                        picDocument.Image = Image.FromFile(strFilePath);

                        this.vScrollBar1.Maximum = this.picDocument.Image.Height - this.panel1.Height;
                        this.hScrollBar1.Maximum = this.picDocument.Image.Width - this.panel1.Width;

                        this.vScrollBar1.Maximum = this.picDocument.Image.Height - this.panel1.Height;
                        this.hScrollBar1.Maximum = this.picDocument.Image.Width - this.panel1.Width;

                    }

                    if (strFilePath.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase))
                    {
                        pdfViewer.Visible = false;
                        panel1.Visible = true;
                        picDocument.Visible = true;
                        picDocument.Image = Image.FromFile(strFilePath);

                        this.vScrollBar1.Maximum = this.picDocument.Image.Height - this.panel1.Height;
                        this.hScrollBar1.Maximum = this.picDocument.Image.Width - this.panel1.Width;

                        this.vScrollBar1.Maximum = this.picDocument.Image.Height - this.panel1.Height;
                        this.hScrollBar1.Maximum = this.picDocument.Image.Width - this.panel1.Width;

                    }

                    if (strFilePath.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                    {
                        pdfViewer.Visible = false;
                        panel1.Visible = true;
                        picDocument.Visible = true;
                        picDocument.Image = Image.FromFile(strFilePath);

                        this.vScrollBar1.Maximum = this.picDocument.Image.Height - this.panel1.Height;
                        this.hScrollBar1.Maximum = this.picDocument.Image.Width - this.panel1.Width;

                        this.vScrollBar1.Maximum = this.picDocument.Image.Height - this.panel1.Height;
                        this.hScrollBar1.Maximum = this.picDocument.Image.Width - this.panel1.Width;

                    }
                }

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {
                opnfldlgBuildings = null;
            }
        }

        private void frmLargeDocumentViewer_Load(object sender, EventArgs e)
        {

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {            
            
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            this.picDocument.Top = -this.vScrollBar1.Value;
        }

        private void hScrollBar1_Scroll_1(object sender, ScrollEventArgs e)
        {
            this.picDocument.Left = -this.hScrollBar1.Value; 
        }

        private void vScrollBar1_Scroll_1(object sender, ScrollEventArgs e)
        {
            this.picDocument.Top = -this.vScrollBar1.Value;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pdfViewer_Load(object sender, EventArgs e)
        {

        }

        private void vScrollBar1_Scroll_2(object sender, ScrollEventArgs e)
        {
            this.picDocument.Top = -this.vScrollBar1.Value;
        }

        private void hScrollBar1_Scroll_2(object sender, ScrollEventArgs e)
        {
            this.picDocument.Left = -this.hScrollBar1.Value;
        }

        private void tlstrpcmd_Click(object sender, EventArgs e)
        {
            picDocument.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void tlstrpcmdActualImageSize_Click(object sender, EventArgs e)
        {
            picDocument.SizeMode = PictureBoxSizeMode.AutoSize;
        }

    }
}
