using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tripodmaps
{
    public partial class frmDocumentTypes : Form
    {
        private long lCurrentDocumentType = 0;
        private string errMessage;
        public frmDocumentTypes()
        {
            InitializeComponent();
        }

        #region "FormOperations"


        private bool CheckIfStringValueIsNumeric(string strArgValue)
        {
            bool IsNumber = false;

            try
            {

                for (int i = 0; i < strArgValue.Length; i++)
                {
                    if (char.IsNumber(strArgValue[i]))
                    {
                        IsNumber = true;
                    }
                }

                return IsNumber;
            }

            catch (Exception ex)
            {
                errMessage = ex.Message;
                return IsNumber;
                
            }


        }

        private void tlstrpbtnNew_Click(object sender, EventArgs e)
        {
            lCurrentDocumentType = 0;
            ClearForm();
        }

        private void tlstrpbtnSave_Click(object sender, EventArgs e)
        {
            SaveBuildingTypes();
        }

        private void frmDocumentTypes_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void LoadForm()
        {
            LoadFirstDocumentType();
        }

        private void ClearForm()
        {
            txtDocumentType.Text = "";
            txtDocumentTypeDescription.Text = "";
            txtDocumentTypeNoOfPrintouts.Text = "";
            txtDocumentTypeNoOfScanIns.Text = "";
            txtDocumentTypeNoOfPhotocopies.Text = "";
            txtDocumentTypeQualityOfCopies.Text = "";
            txtDocumentTypeDefaultPrinterGroup.Text = "";
            txtDocumentTypeProducedByUserGroup.Text = "";
            txtDocumentTypeProducedForUserGroup.Text = "";
            txtDocumentTypeDefaultSavePath.Text = "";
            dtDateCreated.Value = dtDateCreated.MinDate;
            dtDateRegistered.Value = dtDateRegistered.MinDate;
            dtDateDeregistered.Value = dtDateDeregistered.MinDate;
            statDocumentTypes0.Text = "";
            statDocumentTypes1.Text = "";
            statDocumentTypes2.Text = "";
            statDocumentTypes0.Text = "";
            statDocumentTypes1.Text = "";
            statDocumentTypes2.Text = "";

        }

        private void tlstrpbtnFirst_Click(object sender, EventArgs e)
        {
            LoadFirstDocumentType();
        }

        private void tlstrpbtnPrevious_Click(object sender, EventArgs e)
        {
            LoadPreviousDocumentType();
        }

        private void tlstrpbtnNext_Click(object sender, EventArgs e)
        {
            LoadNextDocumentType();
        }

        private void tlstrpbtnLast_Click(object sender, EventArgs e)
        {
            LoadLastDocumentType();
        }



        #endregion


        
        #region "DatabaseOperations"



        private void LoadFirstDocumentType()
        {
            
            TRIP_API.IMDocumentTypes imDocTypes = new TRIP_API.IMDocumentTypes();

            try
            {

                imDocTypes.ReturnFirstDocumentType();
                lCurrentDocumentType = imDocTypes.DocumentTypeID;

                if (imDocTypes.DocumentTypeID > 0)
                {
                    ClearForm();

                    if (imDocTypes.DocumentType != null)
                    {
                        txtDocumentType.Text = imDocTypes.DocumentType;

                    }

                    if (imDocTypes.DocumentPurpose != null)
                    {
                        txtDocumentTypeDescription.Text = imDocTypes.DocumentPurpose;

                    }

                    if (imDocTypes.NoOfPrintOuts != 0)
                    {
                        txtDocumentTypeNoOfPrintouts.Text = imDocTypes.NoOfPrintOuts.ToString();

                    }

                    if (imDocTypes.NoOfScans != 0)
                    {
                        txtDocumentTypeNoOfScanIns.Text = imDocTypes.NoOfScans.ToString();

                    }

                    if (imDocTypes.ProducedByUserGroup != 0)
                    {
                        txtDocumentTypeProducedByUserGroup.Text = imDocTypes.ProducedByUserGroup.ToString();

                    }

                    if (imDocTypes.ProducedForUserGroup != 0)
                    {
                        txtDocumentTypeProducedForUserGroup.Text = imDocTypes.ProducedForUserGroup.ToString();

                    }

                    if (imDocTypes.DefaultPrinterGroup != 0)
                    {
                        txtDocumentTypeDefaultPrinterGroup.Text = imDocTypes.DefaultPrinterGroup.ToString();

                    }

                    if (imDocTypes.DefaultSavePath != null)
                    {
                        txtDocumentTypeDefaultSavePath.Text = imDocTypes.DefaultSavePath;

                    }

                    if (imDocTypes.NoOfPhotocopies != 0)
                    {
                        txtDocumentTypeNoOfPhotocopies.Text = imDocTypes.NoOfPhotocopies.ToString();

                    }

                    if (imDocTypes.QualityOfPhotocopies != null)
                    {
                        txtDocumentTypeQualityOfCopies.Text = imDocTypes.QualityOfPhotocopies;

                    }

                    if (imDocTypes.DateCreated > dtDateCreated.MinDate)
                    {
                        dtDateCreated.Value = imDocTypes.DateCreated;

                    }

                    if (imDocTypes.DateRegistered > dtDateRegistered.MinDate)
                    {
                        dtDateRegistered.Value = imDocTypes.DateRegistered;

                    }

                    if (imDocTypes.DateDeRegistered > dtDateDeregistered.MinDate)
                    {
                        dtDateDeregistered.Value = imDocTypes.DateDeRegistered;

                    }

                }
                else
                {
                    statDocumentTypes0.Text = "No records in the database or connection not working";
                }

            }

            catch (Exception ex)
            {
                string err = ex.Message + " Source=" + ex.Source;
            }

            finally
            {

                imDocTypes = null;
            }



        }

        private void LoadNextDocumentType()
        {           

            TRIP_API.IMDocumentTypes imDocTypes = new TRIP_API.IMDocumentTypes();

            try
            {

                imDocTypes.DocumentTypeID = lCurrentDocumentType;

                if (imDocTypes.ReturnNextDocumentType() == true)
                {
                    ClearForm();
                    lCurrentDocumentType = imDocTypes.DocumentTypeID;

                    if (imDocTypes.DocumentTypeID > 0)
                    {                        

                        if (imDocTypes.DocumentType != null)
                        {
                            txtDocumentType.Text = imDocTypes.DocumentType;

                        }

                        if (imDocTypes.DocumentPurpose != null)
                        {
                            txtDocumentTypeDescription.Text = imDocTypes.DocumentPurpose;

                        }

                        if (imDocTypes.NoOfPrintOuts != 0)
                        {
                            txtDocumentTypeNoOfPrintouts.Text = imDocTypes.NoOfPrintOuts.ToString();

                        }

                        if (imDocTypes.NoOfScans != 0)
                        {
                            txtDocumentTypeNoOfScanIns.Text = imDocTypes.NoOfScans.ToString();

                        }

                        if (imDocTypes.ProducedByUserGroup != 0)
                        {
                            txtDocumentTypeProducedByUserGroup.Text = imDocTypes.ProducedByUserGroup.ToString();

                        }

                        if (imDocTypes.ProducedForUserGroup != 0)
                        {
                            txtDocumentTypeProducedForUserGroup.Text = imDocTypes.ProducedForUserGroup.ToString();

                        }

                        if (imDocTypes.DefaultPrinterGroup != 0)
                        {
                            txtDocumentTypeDefaultPrinterGroup.Text = imDocTypes.DefaultPrinterGroup.ToString();

                        }

                        if (imDocTypes.DefaultSavePath != null)
                        {
                            txtDocumentTypeDefaultSavePath.Text = imDocTypes.DefaultSavePath;

                        }

                        if (imDocTypes.NoOfPhotocopies != 0)
                        {
                            txtDocumentTypeNoOfPhotocopies.Text = imDocTypes.NoOfPhotocopies.ToString();

                        }

                        if (imDocTypes.QualityOfPhotocopies != null)
                        {
                            txtDocumentTypeQualityOfCopies.Text = imDocTypes.QualityOfPhotocopies;

                        }

                        if (imDocTypes.DateCreated > dtDateCreated.MinDate)
                        {
                            dtDateCreated.Value = imDocTypes.DateCreated;

                        }

                        if (imDocTypes.DateRegistered > dtDateRegistered.MinDate)
                        {
                            dtDateRegistered.Value = imDocTypes.DateRegistered;

                        }

                        if (imDocTypes.DateDeRegistered > dtDateDeregistered.MinDate)
                        {
                            dtDateDeregistered.Value = imDocTypes.DateDeRegistered;

                        }

                    }
                }
                else
                {
                    statDocumentTypes0.Text = "You have reached the last database record";
                }

            }

            catch (Exception ex)
            {
                string err = ex.Message + " Source=" + ex.Source;
            }

            finally
            {

                imDocTypes = null;
            }



        }

        private void LoadPreviousDocumentType()
        {

            TRIP_API.IMDocumentTypes imDocTypes = new TRIP_API.IMDocumentTypes();

            try
            {
                imDocTypes.DocumentTypeID = lCurrentDocumentType;

                if (imDocTypes.ReturnPreviousDocumentType() == true)
                {
                    ClearForm();
                    lCurrentDocumentType = imDocTypes.DocumentTypeID;

                    if (imDocTypes.DocumentTypeID > 0)
                    {
                        if (imDocTypes.DocumentType != null)
                        {
                            txtDocumentType.Text = imDocTypes.DocumentType;

                        }

                        if (imDocTypes.DocumentPurpose != null)
                        {
                            txtDocumentTypeDescription.Text = imDocTypes.DocumentPurpose;

                        }

                        if (imDocTypes.NoOfPrintOuts != 0)
                        {
                            txtDocumentTypeNoOfPrintouts.Text = imDocTypes.NoOfPrintOuts.ToString();

                        }

                        if (imDocTypes.NoOfScans != 0)
                        {
                            txtDocumentTypeNoOfScanIns.Text = imDocTypes.NoOfScans.ToString();

                        }

                        if (imDocTypes.ProducedByUserGroup != 0)
                        {
                            txtDocumentTypeProducedByUserGroup.Text = imDocTypes.ProducedByUserGroup.ToString();

                        }

                        if (imDocTypes.ProducedForUserGroup != 0)
                        {
                            txtDocumentTypeProducedForUserGroup.Text = imDocTypes.ProducedForUserGroup.ToString();

                        }

                        if (imDocTypes.DefaultPrinterGroup != 0)
                        {
                            txtDocumentTypeDefaultPrinterGroup.Text = imDocTypes.DefaultPrinterGroup.ToString();

                        }

                        if (imDocTypes.DefaultSavePath != null)
                        {
                            txtDocumentTypeDefaultSavePath.Text = imDocTypes.DefaultSavePath;

                        }

                        if (imDocTypes.NoOfPhotocopies != 0)
                        {
                            txtDocumentTypeNoOfPhotocopies.Text = imDocTypes.NoOfPhotocopies.ToString();

                        }

                        if (imDocTypes.QualityOfPhotocopies != null)
                        {
                            txtDocumentTypeQualityOfCopies.Text = imDocTypes.QualityOfPhotocopies;

                        }

                        if (imDocTypes.DateCreated > dtDateCreated.MinDate)
                        {
                            dtDateCreated.Value = imDocTypes.DateCreated;

                        }

                        if (imDocTypes.DateRegistered > dtDateRegistered.MinDate)
                        {
                            dtDateRegistered.Value = imDocTypes.DateRegistered;

                        }

                        if (imDocTypes.DateDeRegistered > dtDateDeregistered.MinDate)
                        {
                            dtDateDeregistered.Value = imDocTypes.DateDeRegistered;

                        }

                    }
                }
                else
                {
                    statDocumentTypes0.Text = "You have reached the first database record";
                }

            }

            catch (Exception ex)
            {
                string err = ex.Message + " Source=" + ex.Source;
            }

            finally
            {

                imDocTypes = null;
            }



        }

        private void LoadLastDocumentType()
        {

            TRIP_API.IMDocumentTypes imDocTypes = new TRIP_API.IMDocumentTypes();

            try
            {

                imDocTypes.ReturnLastDocumentType();
                lCurrentDocumentType = imDocTypes.DocumentTypeID;

                if (imDocTypes.DocumentTypeID > 0)
                {
                    ClearForm();

                    if (imDocTypes.DocumentType != null)
                    {
                        txtDocumentType.Text = imDocTypes.DocumentType;

                    }

                    if (imDocTypes.DocumentPurpose != null)
                    {
                        txtDocumentTypeDescription.Text = imDocTypes.DocumentPurpose;

                    }

                    if (imDocTypes.NoOfPrintOuts != 0)
                    {
                        txtDocumentTypeNoOfPrintouts.Text = imDocTypes.NoOfPrintOuts.ToString();

                    }

                    if (imDocTypes.NoOfScans != 0)
                    {
                        txtDocumentTypeNoOfScanIns.Text = imDocTypes.NoOfScans.ToString();

                    }

                    if (imDocTypes.ProducedByUserGroup != 0)
                    {
                        txtDocumentTypeProducedByUserGroup.Text = imDocTypes.ProducedByUserGroup.ToString();

                    }

                    if (imDocTypes.ProducedForUserGroup != 0)
                    {
                        txtDocumentTypeProducedForUserGroup.Text = imDocTypes.ProducedForUserGroup.ToString();

                    }

                    if (imDocTypes.DefaultPrinterGroup != 0)
                    {
                        txtDocumentTypeDefaultPrinterGroup.Text = imDocTypes.DefaultPrinterGroup.ToString();

                    }

                    if (imDocTypes.DefaultSavePath != null)
                    {
                        txtDocumentTypeDefaultSavePath.Text = imDocTypes.DefaultSavePath;

                    }

                    if (imDocTypes.NoOfPhotocopies != 0)
                    {
                        txtDocumentTypeNoOfPhotocopies.Text = imDocTypes.NoOfPhotocopies.ToString();

                    }

                    if (imDocTypes.QualityOfPhotocopies != null)
                    {
                        txtDocumentTypeQualityOfCopies.Text = imDocTypes.QualityOfPhotocopies;

                    }

                    if (imDocTypes.DateCreated > dtDateCreated.MinDate)
                    {
                        dtDateCreated.Value = imDocTypes.DateCreated;

                    }

                    if (imDocTypes.DateRegistered > dtDateRegistered.MinDate)
                    {
                        dtDateRegistered.Value = imDocTypes.DateRegistered;

                    }

                    if (imDocTypes.DateDeRegistered > dtDateDeregistered.MinDate)
                    {
                        dtDateDeregistered.Value = imDocTypes.DateDeRegistered;

                    }

                }
                else
                {
                    statDocumentTypes0.Text = "No records in the database or connection not working";
                }

            }

            catch (Exception ex)
            {
                string err = ex.Message + " Source=" + ex.Source;
            }

            finally
            {

                imDocTypes = null;
            }



        }

        private void LoadUsageMasterByCustomerNo(long lArgDocumentTypeNumber)
        {

            ClearForm();

            TRIP_API.IMDocumentTypes imDocTypes = new TRIP_API.IMDocumentTypes();

            try
            {

                if (lArgDocumentTypeNumber > 0)
                {
                    imDocTypes.DocumentTypeID = lArgDocumentTypeNumber;
                    imDocTypes.ReturnAllDocumentTypesMasterByDocumentTypeID(0, 0);

                    if (imDocTypes.DocumentTypeID > 0)
                    {

                        if (imDocTypes.DocumentType != null)
                        {
                            txtDocumentType.Text = imDocTypes.DocumentType;

                        }

                        if (imDocTypes.DocumentPurpose != null)
                        {
                            txtDocumentTypeDescription.Text = imDocTypes.DocumentPurpose;

                        }

                        if (imDocTypes.NoOfPrintOuts != 0)
                        {
                            txtDocumentTypeNoOfPrintouts.Text = imDocTypes.NoOfPrintOuts.ToString();

                        }

                        if (imDocTypes.NoOfScans != 0)
                        {
                            txtDocumentTypeNoOfScanIns.Text = imDocTypes.NoOfScans.ToString();

                        }

                        if (imDocTypes.ProducedByUserGroup != 0)
                        {
                            txtDocumentTypeProducedByUserGroup.Text = imDocTypes.ProducedByUserGroup.ToString();

                        }

                        if (imDocTypes.ProducedForUserGroup != 0)
                        {
                            txtDocumentTypeProducedForUserGroup.Text = imDocTypes.ProducedForUserGroup.ToString();

                        }

                        if (imDocTypes.DefaultPrinterGroup != 0)
                        {
                            txtDocumentTypeDefaultPrinterGroup.Text = imDocTypes.DefaultPrinterGroup.ToString();

                        }

                        if (imDocTypes.DefaultSavePath != null)
                        {
                            txtDocumentTypeDefaultSavePath.Text = imDocTypes.DefaultSavePath;

                        }

                        if (imDocTypes.NoOfPhotocopies != 0)
                        {
                            txtDocumentTypeNoOfPhotocopies.Text = imDocTypes.NoOfPhotocopies.ToString();

                        }

                        if (imDocTypes.QualityOfPhotocopies != null)
                        {
                            txtDocumentTypeQualityOfCopies.Text = imDocTypes.QualityOfPhotocopies;

                        }

                        if (imDocTypes.DateCreated > dtDateCreated.MinDate)
                        {
                            dtDateCreated.Value = imDocTypes.DateCreated;

                        }

                        if (imDocTypes.DateCreated > dtDateRegistered.MinDate)
                        {
                            dtDateRegistered.Value = imDocTypes.DateRegistered;

                        }

                        if (imDocTypes.DateDeRegistered > dtDateDeregistered.MinDate)
                        {
                            dtDateDeregistered.Value = imDocTypes.DateDeRegistered;

                        }

                    }

                }

            }

            catch (Exception ex)
            {
                string err = ex.Message + " Source=" + ex.Source;
            }

            finally
            {

                imDocTypes = null;
            }

        }

        private void SaveBuildingTypes()
        {
            TRIP_API.IMDocumentTypes imDocumentTypes;

            try
            {
                imDocumentTypes = new TRIP_API.IMDocumentTypes();
                imDocumentTypes.DocumentTypeID = lCurrentDocumentType;
                imDocumentTypes.DocumentType = txtDocumentType.Text;
                imDocumentTypes.DocumentPurpose = txtDocumentTypeDescription.Text;

                if (CheckIfStringValueIsNumeric(txtDocumentTypeNoOfScanIns.Text))
                {
                    imDocumentTypes.NoOfScans = Convert.ToInt64(txtDocumentTypeNoOfScanIns.Text);
                }

                if (CheckIfStringValueIsNumeric(txtDocumentTypeProducedByUserGroup.Text))
                {
                    imDocumentTypes.ProducedByUserGroup = Convert.ToInt64(txtDocumentTypeProducedByUserGroup.Text);
                }

                if (CheckIfStringValueIsNumeric(txtDocumentTypeProducedByUserGroup.Text))
                {
                    imDocumentTypes.ProducedForUserGroup = Convert.ToInt64(txtDocumentTypeProducedByUserGroup.Text);
                }

                if (CheckIfStringValueIsNumeric(txtDocumentTypeNoOfPrintouts.Text))
                {
                    imDocumentTypes.NoOfPrintOuts = Convert.ToInt64(txtDocumentTypeNoOfPrintouts.Text);
                }

                if (CheckIfStringValueIsNumeric(txtDocumentTypeNoOfPhotocopies.Text))  
                {
                    imDocumentTypes.NoOfPhotocopies = Convert.ToInt64(txtDocumentTypeNoOfPhotocopies.Text);    
                }
                
               
                if (CheckIfStringValueIsNumeric(txtDocumentTypeDefaultPrinterGroup.Text))                   
                {
                    imDocumentTypes.DefaultPrinterGroup =  Convert.ToInt64(txtDocumentTypeDefaultPrinterGroup.Text);    
                }

                if (CheckIfStringValueIsNumeric(txtDocumentTypeDefaultSavePath.Text))
                {
                    imDocumentTypes.DefaultSavePath = txtDocumentTypeDefaultSavePath.Text;
                }

                if (CheckIfStringValueIsNumeric(txtDocumentTypeQualityOfCopies.Text))
                {
                    imDocumentTypes.QualityOfPhotocopies = txtDocumentTypeQualityOfCopies.Text;
                }

                imDocumentTypes.SaveDocumentTypes();

            }

            catch (Exception ex)
            {
                errMessage = ex.Message;
            }

            finally
            {
                imDocumentTypes = null;
            }

        }

        #endregion

        
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dtDateDeregistered_ValueChanged(object sender, EventArgs e)
        {

        }

        

       

        

        


    }
}
