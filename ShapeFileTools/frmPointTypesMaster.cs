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
    public partial class frmPointTypesMaster : Form
    {
        private long lCurrentPointTypeMasterNumber = 0;
        private string errPointTypes;

        public frmPointTypesMaster()
        {
            InitializeComponent();
        }

        #region "FormOperations"


        private void LoadForm()
        {
            LoadFirstPointTypeMaster();
        }

        private void ClearForm()
        {
            txtPointTypeMasterName.Text = "";
            txtPointTypeMasterDescription.Text = "";
            dtDateCreated.Value = dtDateCreated.MinDate;
            dtDateRegistered.Value = dtDateRegistered.MinDate;
            dtDateDeregistered.Value = dtDateDeregistered.MinDate;
            statPointTypesMaster0.Text = "";
            statPointTypesMaster1.Text = "";
            statPointTypesMaster2.Text = "";
        }

        private void frmPointTypesMaster_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void tlstrpbtnFirst_Click(object sender, EventArgs e)
        {
            LoadFirstPointTypeMaster();
        }

        private void tlstrpbtnPrevious_Click(object sender, EventArgs e)
        {
            LoadPreviousPointTypeMaster();
        }

        private void tlstrpbtnNext_Click(object sender, EventArgs e)
        {
            LoadNextPointTypeMaster();
        }

        private void tlstrpbtnLast_Click(object sender, EventArgs e)
        {
            LoadLastPointTypeMaster();
        }

        private void tlstrpbtnSave_Click(object sender, EventArgs e)
        {
            SavePointTypes();
        }

        private void tlstrpbtnNew_Click(object sender, EventArgs e)
        {
            lCurrentPointTypeMasterNumber = 0;
            ClearForm();
        }

        #endregion


        #region "DatabaseOperations"


        private void LoadFirstPointTypeMaster()
        {

            TRIP_API.IMPointTypesMaster imPointTypesMaster = new TRIP_API.IMPointTypesMaster();

            try
            {

                imPointTypesMaster.ReturnFirstPointTypeMaster();

                lCurrentPointTypeMasterNumber = imPointTypesMaster.PointTypeMasterID;

                if (imPointTypesMaster.PointTypeMasterID > 0)
                {
                    ClearForm();

                    if (imPointTypesMaster.PointTypeMasterName != null)
                    {
                        txtPointTypeMasterName.Text = imPointTypesMaster.PointTypeMasterName.ToString();

                    }

                    if (imPointTypesMaster.PointTypeMasterDescription != null)
                    {
                        txtPointTypeMasterDescription.Text = imPointTypesMaster.PointTypeMasterDescription.ToString();

                    }

                    if (imPointTypesMaster.DateCreated > dtDateCreated.MinDate)
                    {
                        dtDateCreated.Value = imPointTypesMaster.DateCreated;

                    }

                    if (imPointTypesMaster.DateCreated > dtDateRegistered.MinDate)
                    {
                        dtDateRegistered.Value = imPointTypesMaster.DateRegistered;

                    }

                    if (imPointTypesMaster.DateDeRegistered > dtDateDeregistered.MinDate)
                    {
                        dtDateDeregistered.Value = imPointTypesMaster.DateDeRegistered;

                    }

                }
                else
                {
                    statPointTypesMaster0.Text = "No records in the database or connection not working";

                }

            }

            catch (Exception ex)
            {
                errPointTypes = ex.Message + " Source=" + ex.Source;
            }

            finally
            {

                imPointTypesMaster = null;
            }

        }

        private void LoadNextPointTypeMaster()
        {
            TRIP_API.IMPointTypesMaster imPointTypesMaster = new TRIP_API.IMPointTypesMaster();

            try
            {

                imPointTypesMaster.PointTypeMasterID = lCurrentPointTypeMasterNumber;

                if (imPointTypesMaster.ReturnNextPointTypeMaster() == true)
                {
                    ClearForm();
                    lCurrentPointTypeMasterNumber = imPointTypesMaster.PointTypeMasterID;

                    if (imPointTypesMaster.PointTypeMasterID > 0)
                    {
                        if (imPointTypesMaster.PointTypeMasterName != null)
                        {
                            txtPointTypeMasterName.Text = imPointTypesMaster.PointTypeMasterName.ToString();

                        }

                        if (imPointTypesMaster.PointTypeMasterDescription != null)
                        {
                            txtPointTypeMasterDescription.Text = imPointTypesMaster.PointTypeMasterDescription.ToString();

                        }

                        if (imPointTypesMaster.DateCreated > dtDateCreated.MinDate)
                        {
                            dtDateCreated.Value = imPointTypesMaster.DateCreated;

                        }

                        if (imPointTypesMaster.DateCreated > dtDateRegistered.MinDate)
                        {
                            dtDateRegistered.Value = imPointTypesMaster.DateRegistered;

                        }

                        if (imPointTypesMaster.DateDeRegistered > dtDateDeregistered.MinDate)
                        {
                            dtDateDeregistered.Value = imPointTypesMaster.DateDeRegistered;

                        }

                    }
                }
                else
                {
                    statPointTypesMaster0.Text = "You have reached the last database record";
                }

            }

            catch (Exception ex)
            {
                errPointTypes = ex.Message + " Source=" + ex.Source;
            }

            finally
            {

                imPointTypesMaster = null;
            }



        }

        private void LoadPreviousPointTypeMaster()
        {
            TRIP_API.IMPointTypesMaster imPointTypesMaster = new TRIP_API.IMPointTypesMaster();

            try
            {

                imPointTypesMaster.PointTypeMasterID = lCurrentPointTypeMasterNumber;

                if (imPointTypesMaster.ReturnPreviousPointTypeMaster() == true)
                {
                    ClearForm();
                    lCurrentPointTypeMasterNumber = imPointTypesMaster.PointTypeMasterID;

                    if (imPointTypesMaster.PointTypeMasterID > 0)
                    {
                        if (imPointTypesMaster.PointTypeMasterName != null)
                        {
                            txtPointTypeMasterName.Text = imPointTypesMaster.PointTypeMasterName.ToString();

                        }

                        if (imPointTypesMaster.PointTypeMasterDescription != null)
                        {
                            txtPointTypeMasterDescription.Text = imPointTypesMaster.PointTypeMasterDescription.ToString();

                        }

                        if (imPointTypesMaster.DateCreated > dtDateCreated.MinDate)
                        {
                            dtDateCreated.Value = imPointTypesMaster.DateCreated;

                        }

                        if (imPointTypesMaster.DateCreated > dtDateRegistered.MinDate)
                        {
                            dtDateRegistered.Value = imPointTypesMaster.DateRegistered;

                        }

                        if (imPointTypesMaster.DateDeRegistered > dtDateDeregistered.MinDate)
                        {
                            dtDateDeregistered.Value = imPointTypesMaster.DateDeRegistered;

                        }


                    }
                }
                else
                {
                    statPointTypesMaster0.Text = "You have reached the last database record";
                }

            }

            catch (Exception ex)
            {
                errPointTypes = ex.Message + " Source=" + ex.Source;
            }

            finally
            {

                imPointTypesMaster = null;
            }



        }

        private void LoadLastPointTypeMaster()
        {

            TRIP_API.IMPointTypesMaster imPointTypesMaster = new TRIP_API.IMPointTypesMaster();

            try
            {
                imPointTypesMaster.ReturnLastPointTypeMaster();
                lCurrentPointTypeMasterNumber = imPointTypesMaster.PointTypeMasterID;

                if (imPointTypesMaster.PointTypeMasterID > 0)
                {
                    ClearForm();

                    if (imPointTypesMaster.PointTypeMasterName != null)
                    {
                        txtPointTypeMasterName.Text = imPointTypesMaster.PointTypeMasterName.ToString();

                    }

                    if (imPointTypesMaster.PointTypeMasterDescription != null)
                    {
                        txtPointTypeMasterDescription.Text = imPointTypesMaster.PointTypeMasterDescription.ToString();

                    }

                    if (imPointTypesMaster.DateCreated > dtDateCreated.MinDate)
                    {
                        dtDateCreated.Value = imPointTypesMaster.DateCreated;

                    }

                    if (imPointTypesMaster.DateCreated > dtDateRegistered.MinDate)
                    {
                        dtDateRegistered.Value = imPointTypesMaster.DateRegistered;

                    }

                    if (imPointTypesMaster.DateDeRegistered > dtDateDeregistered.MinDate)
                    {
                        dtDateDeregistered.Value = imPointTypesMaster.DateDeRegistered;

                    }

                }
                else
                {
                    statPointTypesMaster0.Text = "No records in the database or connection not working";
                }


            }

            catch (Exception ex)
            {
                errPointTypes = ex.Message + " Source=" + ex.Source;
            }

            finally
            {

                imPointTypesMaster = null;
            }



        }

        private void LoadPointTypeMasterByBuildingTypeID(long lArgPointTypeMasterNumber)
        {

            ClearForm();

            TRIP_API.IMPointTypesMaster imPointTypesMaster = new TRIP_API.IMPointTypesMaster();

            try
            {

                if (lArgPointTypeMasterNumber > 0)
                {
                    imPointTypesMaster.PointTypeMasterID = lArgPointTypeMasterNumber;
                    imPointTypesMaster.ReturnPointTypesByPointTypeID (0, 0);

                    if (imPointTypesMaster.PointTypeMasterID > 0)
                    {

                        if (imPointTypesMaster.PointTypeMasterID > 0)
                        {
                            txtPointTypeMasterName.Text = imPointTypesMaster.PointTypeMasterID.ToString();

                        }

                        if (imPointTypesMaster.PointTypeMasterDescription != null)
                        {
                            txtPointTypeMasterDescription.Text = imPointTypesMaster.PointTypeMasterDescription.ToString();

                        }

                        if (imPointTypesMaster.DateCreated > dtDateCreated.MinDate)
                        {
                            dtDateCreated.Value = imPointTypesMaster.DateCreated;

                        }

                        if (imPointTypesMaster.DateCreated > dtDateRegistered.MinDate)
                        {
                            dtDateRegistered.Value = imPointTypesMaster.DateRegistered;

                        }

                        if (imPointTypesMaster.DateDeRegistered > dtDateDeregistered.MinDate)
                        {
                            dtDateDeregistered.Value = imPointTypesMaster.DateDeRegistered;

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

                imPointTypesMaster = null;
            }



        }

        private void SavePointTypes()
        {
            TRIP_API.IMPointTypesMaster imPointTypesMaster;

            try
            {
                imPointTypesMaster = new TRIP_API.IMPointTypesMaster();
                imPointTypesMaster.PointTypeMasterID = lCurrentPointTypeMasterNumber;
                imPointTypesMaster.PointTypeMasterName = txtPointTypeMasterName.Text;
                imPointTypesMaster.PointTypeMasterDescription = txtPointTypeMasterDescription.Text;

                imPointTypesMaster.SavePointTypeMaster();

            }

            catch (Exception ex)
            {
                errPointTypes = ex.Message;
            }

            finally
            {
                imPointTypesMaster = null;
            }

        }


        #endregion

        private void txtPointTypeDescription_TextChanged(object sender, EventArgs e)
        {

        }

        

        


    }
}
