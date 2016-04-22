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
    public partial class frmUsageMaster : Form
    {
        
        private long lCurrentUsageNumber = 0;


        public frmUsageMaster()
        {
            InitializeComponent();
        }


        #region "FormOperations"


        private void frmUsageMaster_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void tlstrpbtnFirst_Click(object sender, EventArgs e)
        {
            LoadFirstUsageMaster();
        }

        private void tlstrpbtnPrevious_Click(object sender, EventArgs e)
        {
            LoadPreviousUsageMaster();
        }

        private void tlstrpbtnNext_Click(object sender, EventArgs e)
        {
            LoadNextUsageMaster();
        }

        private void tlstrpbtnLast_Click(object sender, EventArgs e)
        {
            LoadLastUsageMaster();
        }

        private void LoadForm()
        {
            LoadFirstUsageMaster();
        }

        private void ClearForm()
        {
            txtUsageName.Text = "";
            txtUsageDescription.Text = "";
            dtDateCreated.Value = dtDateCreated.MinDate;
            dtDateRegistered.Value = dtDateRegistered.MinDate;
            dtDateDeregistered.Value = dtDateDeregistered.MinDate;
            statUsageTypes0.Text = "";
            statUsageTypes1.Text = "";
            statUsageTypes2.Text = "";

        }


        #endregion



        #region "DatabaseOperations"


        private void LoadFirstUsageMaster()
        {           

            TRIP_API.IMUsage imUsageMaster = new TRIP_API.IMUsage();

            try
            {

                imUsageMaster.ReturnFirstUsageMaster();

                lCurrentUsageNumber = imUsageMaster.UsageID;

                if (imUsageMaster.UsageID > 0)
                {
                    ClearForm();

                    if (imUsageMaster.UsageName != null)
                    {
                        txtUsageName.Text = imUsageMaster.UsageName.ToString();
                    }

                    if (imUsageMaster.UsageDescription != null)
                    {
                        txtUsageDescription.Text = imUsageMaster.UsageDescription.ToString();
                    }

                    if (imUsageMaster.DateCreated > dtDateCreated.MinDate)
                    {
                        dtDateCreated.Value = imUsageMaster.DateCreated;
                    }

                    if (imUsageMaster.DateCreated > dtDateRegistered.MinDate)
                    {
                        dtDateRegistered.Value = imUsageMaster.DateRegistered;
                    }

                    if (imUsageMaster.DateDeRegistered > dtDateDeregistered.MinDate)
                    {
                        dtDateDeregistered.Value = imUsageMaster.DateDeRegistered;
                    }

                }
                else
                {
                    statUsageTypes0.Text = "No records in the database or connection not working";
           
                }

            }

            catch (Exception ex)
            {
                string err = ex.Message + " Source=" + ex.Source;
            }

            finally
            {

                imUsageMaster = null;
            }



        }

        private void LoadNextUsageMaster()
        {
            
            TRIP_API.IMUsage imUsageMaster = new TRIP_API.IMUsage();

            try
            {                

                imUsageMaster.UsageID = lCurrentUsageNumber;

                if (imUsageMaster.ReturnNextUsageMaster() == true)
                {
                    ClearForm();
                    lCurrentUsageNumber = imUsageMaster.UsageID;

                    if (imUsageMaster.UsageID > 0)
                    {
                        if (imUsageMaster.UsageName != null)
                        {
                            txtUsageName.Text = imUsageMaster.UsageName.ToString();

                        }

                        if (imUsageMaster.UsageDescription != null)
                        {
                            txtUsageDescription.Text = imUsageMaster.UsageDescription.ToString();

                        }

                        if (imUsageMaster.DateCreated > dtDateCreated.MinDate)
                        {
                            dtDateCreated.Value = imUsageMaster.DateCreated;

                        }

                        if (imUsageMaster.DateCreated > dtDateRegistered.MinDate)
                        {
                            dtDateRegistered.Value = imUsageMaster.DateRegistered;

                        }

                        if (imUsageMaster.DateDeRegistered > dtDateDeregistered.MinDate)
                        {
                            dtDateDeregistered.Value = imUsageMaster.DateDeRegistered;

                        }

                    }
                }
                else
                {
                    statUsageTypes0.Text = "You have reached the last database record";
                }

            }

            catch (Exception ex)
            {
                string err = ex.Message + " Source=" + ex.Source;
            }

            finally
            {

                imUsageMaster = null;
            }



        }

        private void LoadPreviousUsageMaster()
        {

            TRIP_API.IMUsage imUsageMaster = new TRIP_API.IMUsage();

            try
            {

                imUsageMaster.UsageID = lCurrentUsageNumber;

                if (imUsageMaster.ReturnPreviousUsageMaster() == true)
                {
                    ClearForm();
                    lCurrentUsageNumber = imUsageMaster.UsageID;

                    if (imUsageMaster.UsageID > 0)
                    {
                        lCurrentUsageNumber = imUsageMaster.UsageID;

                        if (imUsageMaster.UsageName != null)
                        {
                            txtUsageName.Text = imUsageMaster.UsageName.ToString();

                        }

                        if (imUsageMaster.UsageDescription != null)
                        {
                            txtUsageDescription.Text = imUsageMaster.UsageDescription.ToString();

                        }

                        if (imUsageMaster.DateCreated > dtDateCreated.MinDate)
                        {
                            dtDateCreated.Value = imUsageMaster.DateCreated;

                        }

                        if (imUsageMaster.DateCreated > dtDateRegistered.MinDate)
                        {
                            dtDateRegistered.Value = imUsageMaster.DateRegistered;

                        }

                        if (imUsageMaster.DateDeRegistered > dtDateDeregistered.MinDate)
                        {
                            dtDateDeregistered.Value = imUsageMaster.DateDeRegistered;

                        }


                    }
                }
                else
                { 
                    statUsageTypes0.Text = "You have reached the last database record";
                }

            }

            catch (Exception ex)
            {
                string err = ex.Message + " Source=" + ex.Source;
            }

            finally
            {

                imUsageMaster = null;
            }



        }

        private void LoadLastUsageMaster()
        {            

            TRIP_API.IMUsage imUsageMaster = new TRIP_API.IMUsage();

            try
            {

                imUsageMaster.ReturnLastUsageMaster();
                lCurrentUsageNumber = imUsageMaster.UsageID;

                if (imUsageMaster.UsageID > 0)
                {
                    ClearForm();

                    if (imUsageMaster.UsageName != null)
                    {
                        txtUsageName.Text = imUsageMaster.UsageName.ToString();

                    }

                    if (imUsageMaster.UsageDescription != null)
                    {
                        txtUsageDescription.Text = imUsageMaster.UsageDescription.ToString();

                    }

                    if (imUsageMaster.DateCreated > dtDateCreated.MinDate)
                    {
                        dtDateCreated.Value = imUsageMaster.DateCreated;

                    }

                    if (imUsageMaster.DateCreated > dtDateRegistered.MinDate)
                    {
                        dtDateRegistered.Value = imUsageMaster.DateRegistered;

                    }

                    if (imUsageMaster.DateDeRegistered > dtDateDeregistered.MinDate)
                    {
                        dtDateDeregistered.Value = imUsageMaster.DateDeRegistered;

                    }

                }
                else
                {
                    statUsageTypes0.Text = "No records in the database or connection not working";
                }

            }

            catch (Exception ex)
            {
                string err = ex.Message + " Source=" + ex.Source;
            }

            finally
            {

                imUsageMaster = null;
            }



        }

        public void LoadUsageMasterByUsageID(long lArgUsageNumber)
        {
            
            ClearForm();

            TRIP_API.IMUsage imUsageMaster = new TRIP_API.IMUsage();            

            try
            {

                if (lArgUsageNumber > 0)
                {
                    imUsageMaster.UsageID = lArgUsageNumber;
                    imUsageMaster.ReturnUsageMasterByUsageID(0, 0);

                    if (imUsageMaster.UsageID > 0)
                    {

                        if (imUsageMaster.UsageID > 0)
                        {
                            txtUsageName.Text = imUsageMaster.UsageID.ToString();

                        }

                        if (imUsageMaster.UsageDescription != null)
                        {
                            txtUsageDescription.Text = imUsageMaster.UsageDescription.ToString();

                        }

                        if (imUsageMaster.DateCreated > dtDateCreated.MinDate)
                        {
                            dtDateCreated.Value = imUsageMaster.DateCreated;

                        }

                        if (imUsageMaster.DateCreated > dtDateRegistered.MinDate)
                        {
                            dtDateRegistered.Value = imUsageMaster.DateRegistered;

                        }

                        if (imUsageMaster.DateDeRegistered > dtDateDeregistered.MinDate)
                        {
                            dtDateDeregistered.Value = imUsageMaster.DateDeRegistered;

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

                imUsageMaster = null;
            }



        }


        #endregion



        #region "Interfaces"


        


        #endregion

       
       


    }
}
