using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tripodmaps
{
    public partial class frmBuildingTypes : Form
    {
        private long lCurrentBuildingTypeNumber = 0;
        string errMessage = "";

        public frmBuildingTypes()
        {
            InitializeComponent();
        }


        #region "FormOperations"


        private void tlstrpbtnNew_Click(object sender, EventArgs e)
        {
            lCurrentBuildingTypeNumber = 0;
            ClearForm();
        }

        private void tlstrpbtnSave_Click(object sender, EventArgs e)
        {
            SaveBuildingTypes();
        }

        private void frmBuildingTypes_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void LoadForm()
        {
            LoadFirstBuildingTypeMaster();
        }

        private void ClearForm()
        {
            txtBuildingTypeName.Text = "";
            txtBuildingTypeDescription.Text = "";
            dtDateCreated.Value = dtDateCreated.MinDate;
            dtDateRegistered.Value = dtDateRegistered.MinDate;
            dtDateDeregistered.Value = dtDateDeregistered.MinDate;
            statBuildingTypes0.Text = "";
            statBuildingTypes1.Text = "";
            statBuildingTypes2.Text = "";
        }

        private void tlstrpbtnFirst_Click(object sender, EventArgs e)
        {
            LoadFirstBuildingTypeMaster();
        }

        private void tlstrpbtnPrevious_Click(object sender, EventArgs e)
        {
            LoadPreviousBuildingTypeMaster();
        }

        private void tlstrpbtnNext_Click(object sender, EventArgs e)
        {
            LoadNextBuildingTypeMaster();
        }

        private void tlstrpbtnLast_Click(object sender, EventArgs e)
        {
            LoadLastBuildingTypeMaster();
        }



        #endregion

        #region "DatabaseOperations"


        private void LoadFirstBuildingTypeMaster()
        {

            TRIP_API.IMBuildingTypes imBuildingTypeMaster = new TRIP_API.IMBuildingTypes();

            try
            {

                imBuildingTypeMaster.ReturnFirstBuildingTypeMaster();

                lCurrentBuildingTypeNumber = imBuildingTypeMaster.BuildingTypeID;

                if (imBuildingTypeMaster.BuildingTypeID > 0)
                {
                    ClearForm();

                    if (imBuildingTypeMaster.BuildingTypeName != null)
                    {
                        txtBuildingTypeName.Text = imBuildingTypeMaster.BuildingTypeName.ToString();

                    }

                    if (imBuildingTypeMaster.BuildingTypeDescription != null)
                    {
                        txtBuildingTypeDescription.Text = imBuildingTypeMaster.BuildingTypeDescription.ToString();

                    }

                    if (imBuildingTypeMaster.DateCreated > dtDateCreated.MinDate)
                    {
                        dtDateCreated.Value = imBuildingTypeMaster.DateCreated;

                    }

                    if (imBuildingTypeMaster.DateRegistered > dtDateRegistered.MinDate)
                    {
                        dtDateRegistered.Value = imBuildingTypeMaster.DateRegistered;

                    }

                    if (imBuildingTypeMaster.DateDeRegistered > dtDateDeregistered.MinDate)
                    {
                        dtDateDeregistered.Value = imBuildingTypeMaster.DateDeRegistered;

                    }

                }
                else
                {
                    statBuildingTypes0.Text = "No records in the database or connection not working";
                }

            }

            catch (Exception ex)
            {
                string err = ex.Message + " Source=" + ex.Source;
            }

            finally
            {

                imBuildingTypeMaster = null;
            }

        }

        private void LoadNextBuildingTypeMaster()
        {
            
            TRIP_API.IMBuildingTypes imBuildingTypeMaster = new TRIP_API.IMBuildingTypes();

            try
            {


                imBuildingTypeMaster.BuildingTypeID = lCurrentBuildingTypeNumber;

                if (imBuildingTypeMaster.ReturnNextBuildingTypeMaster() == true)
                {

                    ClearForm();

                    lCurrentBuildingTypeNumber = imBuildingTypeMaster.BuildingTypeID;

                    if (imBuildingTypeMaster.BuildingTypeID > 0)
                    {
                        if (imBuildingTypeMaster.BuildingTypeName != null)
                        {
                            txtBuildingTypeName.Text = imBuildingTypeMaster.BuildingTypeName.ToString();

                        }

                        if (imBuildingTypeMaster.BuildingTypeDescription != null)
                        {
                            txtBuildingTypeDescription.Text = imBuildingTypeMaster.BuildingTypeDescription.ToString();

                        }

                        if (imBuildingTypeMaster.DateCreated > dtDateCreated.MinDate)
                        {
                            dtDateCreated.Value = imBuildingTypeMaster.DateCreated;

                        }

                        if (imBuildingTypeMaster.DateRegistered > dtDateRegistered.MinDate)
                        {
                            dtDateRegistered.Value = imBuildingTypeMaster.DateRegistered;

                        }

                        if (imBuildingTypeMaster.DateDeRegistered > dtDateDeregistered.MinDate)
                        {
                            dtDateDeregistered.Value = imBuildingTypeMaster.DateDeRegistered;

                        }

                    }
                }
                else
                {
                    statBuildingTypes0.Text = "You have reached the last database record";
                }

            }

            catch (Exception ex)
            {
                string err = ex.Message + " Source=" + ex.Source;
            }

            finally
            {

                imBuildingTypeMaster = null;
            }



        }

        private void LoadPreviousBuildingTypeMaster()
        {
           
            TRIP_API.IMBuildingTypes imBuildingTypeMaster = new TRIP_API.IMBuildingTypes();

            try
            {

                imBuildingTypeMaster.BuildingTypeID = lCurrentBuildingTypeNumber;
                if (imBuildingTypeMaster.ReturnPreviousBuildingTypeMaster() == true)
                {
                    ClearForm();

                    lCurrentBuildingTypeNumber = imBuildingTypeMaster.BuildingTypeID;

                    if (imBuildingTypeMaster.BuildingTypeID > 0)
                    {
                        if (imBuildingTypeMaster.BuildingTypeName != null)
                        {
                            txtBuildingTypeName.Text = imBuildingTypeMaster.BuildingTypeName.ToString();

                        }

                        if (imBuildingTypeMaster.BuildingTypeDescription != null)
                        {
                            txtBuildingTypeDescription.Text = imBuildingTypeMaster.BuildingTypeDescription.ToString();

                        }

                        if (imBuildingTypeMaster.DateCreated > dtDateCreated.MinDate)
                        {
                            dtDateCreated.Value = imBuildingTypeMaster.DateCreated;

                        }

                        if (imBuildingTypeMaster.DateRegistered > dtDateRegistered.MinDate)
                        {
                            dtDateRegistered.Value = imBuildingTypeMaster.DateRegistered;

                        }

                        if (imBuildingTypeMaster.DateDeRegistered > dtDateDeregistered.MinDate)
                        {
                            dtDateDeregistered.Value = imBuildingTypeMaster.DateDeRegistered;

                        }


                    }
                }
                else
                {
                    statBuildingTypes0.Text = "You have reached the first database record";
                }

            }

            catch (Exception ex)
            {
                string err = ex.Message + " Source=" + ex.Source;
            }

            finally
            {

                imBuildingTypeMaster = null;
            }



        }

        private void LoadLastBuildingTypeMaster()
        {

            ClearForm();

            TRIP_API.IMBuildingTypes imBuildingTypeMaster = new TRIP_API.IMBuildingTypes();

            try
            {
                imBuildingTypeMaster.ReturnLastBuildingTypeMaster();
                lCurrentBuildingTypeNumber = imBuildingTypeMaster.BuildingTypeID;

                if (imBuildingTypeMaster.BuildingTypeID > 0)
                {
                    if (imBuildingTypeMaster.BuildingTypeName != null)
                    {
                        txtBuildingTypeName.Text = imBuildingTypeMaster.BuildingTypeName.ToString();

                    }

                    if (imBuildingTypeMaster.BuildingTypeDescription != null)
                    {
                        txtBuildingTypeDescription.Text = imBuildingTypeMaster.BuildingTypeDescription.ToString();

                    }

                    if (imBuildingTypeMaster.DateCreated > dtDateCreated.MinDate)
                    {
                        dtDateCreated.Value = imBuildingTypeMaster.DateCreated;

                    }

                    if (imBuildingTypeMaster.DateRegistered > dtDateRegistered.MinDate)
                    {
                        dtDateRegistered.Value = imBuildingTypeMaster.DateRegistered;

                    }

                    if (imBuildingTypeMaster.DateDeRegistered > dtDateDeregistered.MinDate)
                    {
                        dtDateDeregistered.Value = imBuildingTypeMaster.DateDeRegistered;

                    }

                }

                else
                {
                    statBuildingTypes0.Text = "No records in the database or connection not working";

                }

            }

            catch (Exception ex)
            {
                string err = ex.Message + " Source=" + ex.Source;
            }

            finally
            {

                imBuildingTypeMaster = null;
            }



        }

        private void LoadBuildingTypeMasterByBuildingTypeID(long lArgBuildingTypeNumber)
        {

            ClearForm();

            TRIP_API.IMBuildingTypes imBuildingTypeMaster = new TRIP_API.IMBuildingTypes();

            try
            {

                if (lArgBuildingTypeNumber > 0)
                {
                    imBuildingTypeMaster.BuildingTypeID = lArgBuildingTypeNumber;
                    imBuildingTypeMaster.ReturnBuildingTypesByBuildingTypeID(0, 0);

                    if (imBuildingTypeMaster.BuildingTypeID > 0)
                    {

                        if (imBuildingTypeMaster.BuildingTypeID > 0)
                        {
                            txtBuildingTypeName.Text = imBuildingTypeMaster.BuildingTypeID.ToString();

                        }

                        if (imBuildingTypeMaster.BuildingTypeDescription != null)
                        {
                            txtBuildingTypeDescription.Text = imBuildingTypeMaster.BuildingTypeDescription.ToString();

                        }

                        if (imBuildingTypeMaster.DateCreated > dtDateCreated.MinDate)
                        {
                            dtDateCreated.Value = imBuildingTypeMaster.DateCreated;

                        }

                        if (imBuildingTypeMaster.DateCreated > dtDateRegistered.MinDate)
                        {
                            dtDateRegistered.Value = imBuildingTypeMaster.DateRegistered;

                        }

                        if (imBuildingTypeMaster.DateDeRegistered > dtDateDeregistered.MinDate)
                        {
                            dtDateDeregistered.Value = imBuildingTypeMaster.DateDeRegistered;

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

                imBuildingTypeMaster = null;
            }



        }

        private void SaveBuildingTypes()
        {
            TRIP_API.IMBuildingTypes  imBuildingTypesMaster;

            try
            {
                imBuildingTypesMaster = new TRIP_API.IMBuildingTypes();
                imBuildingTypesMaster.BuildingTypeID = lCurrentBuildingTypeNumber;
                imBuildingTypesMaster.BuildingTypeName = txtBuildingTypeName.Text;
                imBuildingTypesMaster.BuildingTypeDescription = txtBuildingTypeDescription.Text;

                imBuildingTypesMaster.SaveBuildingTypeMaster();

            }

            catch (Exception ex)
            {
                errMessage = ex.Message;
            }

            finally
            {
                imBuildingTypesMaster = null;
            }

        }

        #endregion

      

       

       
       


    }
}
