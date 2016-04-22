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
    public partial class frmRoomAmenityTypes : Form
    {
        
        private long lCurrentRoomAmenityTypeMasterNumber = 0;

        private string errMessage;
       

        #region "FormOperations"

         
        private void tlstrpbtnSave_Click(object sender, EventArgs e)
        {
            SaveRoomAmenityTypeMaster();         
        }

        private void tlstrpbtnNew_Click(object sender, EventArgs e)
        {
            lCurrentRoomAmenityTypeMasterNumber = 0;
            ClearForm();
        }

        public frmRoomAmenityTypes()
        {
            InitializeComponent();
        }

        private void frmRoomAmenityTypes_Load(object sender, EventArgs e)
        {
            LoadForm();

        }

        private void LoadForm()
        {
            LoadFirstRoomAmenityTypeMaster();
        }

        private void ClearForm()
        {
            txtRoomAmenityTypeMasterName.Text = "";
            txtRoomAmenityTypeMasterDescription.Text = "";
            dtDateCreated.Value = dtDateCreated.MinDate;
            dtDateRegistered.Value = dtDateRegistered.MinDate;
            dtDateDeregistered.Value = dtDateDeregistered.MinDate;
            statRoomAmenity0.Text = "";
            statRoomAmenity1.Text = "";
            statRoomAmenity2.Text = "";

        }

        private void tlstrpbtnPrint_Click(object sender, EventArgs e)
        {
            PrintCurrentRecord();
        }

        private void tlstrpbtnFirst_Click(object sender, EventArgs e)
        {
            LoadFirstRoomAmenityTypeMaster();
        }

        private void tlstrpbtnPrevious_Click(object sender, EventArgs e)
        {
            LoadPreviousRoomAmenityTypeMaster();
        }

        private void tlstrpbtnNext_Click(object sender, EventArgs e)
        {
            LoadNextRoomAmenityTypeMaster();
        }

        private void tlstrpbtnLast_Click(object sender, EventArgs e)
        {
            LoadLastRoomAmenityTypeMaster();
        }


        #endregion


        #region "DatabaseOperations"


        private void LoadFirstRoomAmenityTypeMaster()
        {

            ClearForm();

            TRIP_API.IMRoomAmenityTypeMaster imRoomAmenityTypesMaster = new TRIP_API.IMRoomAmenityTypeMaster();

            try
            {

                imRoomAmenityTypesMaster.ReturnFirstRoomAmenityTypeMaster();

                lCurrentRoomAmenityTypeMasterNumber = imRoomAmenityTypesMaster.RoomAmenityTypeMasterID;

                if (imRoomAmenityTypesMaster.RoomAmenityTypeMasterID > 0)
                {
                    if (imRoomAmenityTypesMaster.RoomAmenityTypeMasterName != null)
                    {
                        txtRoomAmenityTypeMasterName.Text = imRoomAmenityTypesMaster.RoomAmenityTypeMasterName.ToString();

                    }

                    if (imRoomAmenityTypesMaster.RoomAmenityTypeMasterDescription != null)
                    {
                        txtRoomAmenityTypeMasterDescription.Text = imRoomAmenityTypesMaster.RoomAmenityTypeMasterDescription.ToString();

                    }

                    if (imRoomAmenityTypesMaster.DateCreated > dtDateCreated.MinDate)
                    {
                        dtDateCreated.Value = imRoomAmenityTypesMaster.DateCreated;

                    }

                    if (imRoomAmenityTypesMaster.DateCreated > dtDateRegistered.MinDate)
                    {
                        dtDateRegistered.Value = imRoomAmenityTypesMaster.DateRegistered;

                    }

                    if (imRoomAmenityTypesMaster.DateDeRegistered > dtDateDeregistered.MinDate)
                    {
                        dtDateDeregistered.Value = imRoomAmenityTypesMaster.DateDeRegistered;

                    }

                }
                else
                {
                    statRoomAmenity0.Text = "No records in the database or connection not working";

                }

            }

            catch (Exception ex)
            {
                string err = ex.Message + " Source=" + ex.Source;
            }

            finally
            {

                imRoomAmenityTypesMaster = null;
            }

        }

        private void LoadNextRoomAmenityTypeMaster()
        {
            TRIP_API.IMRoomAmenityTypeMaster imRoomAmenityTypesMaster = new TRIP_API.IMRoomAmenityTypeMaster();

            try
            {


                imRoomAmenityTypesMaster.RoomAmenityTypeMasterID = lCurrentRoomAmenityTypeMasterNumber;

                if (imRoomAmenityTypesMaster.ReturnNextRoomAmenityTypeMaster() == true)
                {
                    ClearForm();
                    lCurrentRoomAmenityTypeMasterNumber = imRoomAmenityTypesMaster.RoomAmenityTypeMasterID;

                    if (imRoomAmenityTypesMaster.RoomAmenityTypeMasterID > 0)
                    {
                        if (imRoomAmenityTypesMaster.RoomAmenityTypeMasterName != null)
                        {
                            txtRoomAmenityTypeMasterName.Text = imRoomAmenityTypesMaster.RoomAmenityTypeMasterName.ToString();

                        }

                        if (imRoomAmenityTypesMaster.RoomAmenityTypeMasterDescription != null)
                        {
                            txtRoomAmenityTypeMasterDescription.Text = imRoomAmenityTypesMaster.RoomAmenityTypeMasterDescription.ToString();

                        }

                        if (imRoomAmenityTypesMaster.DateCreated > dtDateCreated.MinDate)
                        {
                            dtDateCreated.Value = imRoomAmenityTypesMaster.DateCreated;

                        }

                        if (imRoomAmenityTypesMaster.DateCreated > dtDateRegistered.MinDate)
                        {
                            dtDateRegistered.Value = imRoomAmenityTypesMaster.DateRegistered;

                        }

                        if (imRoomAmenityTypesMaster.DateDeRegistered > dtDateDeregistered.MinDate)
                        {
                            dtDateDeregistered.Value = imRoomAmenityTypesMaster.DateDeRegistered;

                        }

                    }
                }
                else
                {
                    statRoomAmenity0.Text = "You have reached the last database record";
                }

            }

            catch (Exception ex)
            {
                string err = ex.Message + " Source=" + ex.Source;
            }

            finally
            {

                imRoomAmenityTypesMaster = null;
            }



        }

        private void LoadPreviousRoomAmenityTypeMaster()
        {
            TRIP_API.IMRoomAmenityTypeMaster imRoomAmenityTypesMaster = new TRIP_API.IMRoomAmenityTypeMaster();

            try
            {

                imRoomAmenityTypesMaster.RoomAmenityTypeMasterID = lCurrentRoomAmenityTypeMasterNumber;
                if (imRoomAmenityTypesMaster.ReturnPreviousRoomAmenityTypeMaster() == true)
                {
                    ClearForm();
                    lCurrentRoomAmenityTypeMasterNumber = imRoomAmenityTypesMaster.RoomAmenityTypeMasterID;

                    if (imRoomAmenityTypesMaster.RoomAmenityTypeMasterID > 0)
                    {
                        if (imRoomAmenityTypesMaster.RoomAmenityTypeMasterName != null)
                        {
                            txtRoomAmenityTypeMasterName.Text = imRoomAmenityTypesMaster.RoomAmenityTypeMasterName.ToString();

                        }

                        if (imRoomAmenityTypesMaster.RoomAmenityTypeMasterDescription != null)
                        {
                            txtRoomAmenityTypeMasterDescription.Text = imRoomAmenityTypesMaster.RoomAmenityTypeMasterDescription.ToString();

                        }

                        if (imRoomAmenityTypesMaster.DateCreated > dtDateCreated.MinDate)
                        {
                            dtDateCreated.Value = imRoomAmenityTypesMaster.DateCreated;

                        }

                        if (imRoomAmenityTypesMaster.DateCreated > dtDateRegistered.MinDate)
                        {
                            dtDateRegistered.Value = imRoomAmenityTypesMaster.DateRegistered;

                        }

                        if (imRoomAmenityTypesMaster.DateDeRegistered > dtDateDeregistered.MinDate)
                        {
                            dtDateDeregistered.Value = imRoomAmenityTypesMaster.DateDeRegistered;

                        }


                    }
                }
                else
                {
                    statRoomAmenity0.Text = "You have reached the first database record";
                }

            }

            catch (Exception ex)
            {
                string err = ex.Message + " Source=" + ex.Source;
            }

            finally
            {

                imRoomAmenityTypesMaster = null;
            }



        }

        private void LoadLastRoomAmenityTypeMaster()
        {
            ClearForm();

            TRIP_API.IMRoomAmenityTypeMaster imRoomAmenityTypesMaster = new TRIP_API.IMRoomAmenityTypeMaster();

            try
            {


                imRoomAmenityTypesMaster.ReturnLastRoomAmenityTypeMaster();
                lCurrentRoomAmenityTypeMasterNumber = imRoomAmenityTypesMaster.RoomAmenityTypeMasterID;

                if (imRoomAmenityTypesMaster.RoomAmenityTypeMasterID > 0)
                {

                    if (imRoomAmenityTypesMaster.RoomAmenityTypeMasterName != null)
                    {
                        txtRoomAmenityTypeMasterName.Text = imRoomAmenityTypesMaster.RoomAmenityTypeMasterName.ToString();

                    }

                    if (imRoomAmenityTypesMaster.RoomAmenityTypeMasterDescription != null)
                    {
                        txtRoomAmenityTypeMasterDescription.Text = imRoomAmenityTypesMaster.RoomAmenityTypeMasterDescription.ToString();

                    }

                    if (imRoomAmenityTypesMaster.DateCreated > dtDateCreated.MinDate)
                    {
                        dtDateCreated.Value = imRoomAmenityTypesMaster.DateCreated;

                    }

                    if (imRoomAmenityTypesMaster.DateCreated > dtDateRegistered.MinDate)
                    {
                        dtDateRegistered.Value = imRoomAmenityTypesMaster.DateRegistered;

                    }

                    if (imRoomAmenityTypesMaster.DateDeRegistered > dtDateDeregistered.MinDate)
                    {
                        dtDateDeregistered.Value = imRoomAmenityTypesMaster.DateDeRegistered;

                    }

                }
                else
                {
                    statRoomAmenity0.Text = "No records in the database or connection not working";
                }
            }

            catch (Exception ex)
            {
                string err = ex.Message + " Source=" + ex.Source;
            }

            finally
            {

                imRoomAmenityTypesMaster = null;
            }



        }

        private void LoadRoomAmenityTypeMasterByBuildingTypeID(long lArgRoomAmenityTypeMasterNumber)
        {

            ClearForm();

            TRIP_API.IMRoomAmenityTypeMaster imRoomAmenityTypesMaster = new TRIP_API.IMRoomAmenityTypeMaster();

            try
            {

                if (lArgRoomAmenityTypeMasterNumber > 0)
                {
                    imRoomAmenityTypesMaster.RoomAmenityTypeMasterID = lArgRoomAmenityTypeMasterNumber;
                    imRoomAmenityTypesMaster.ReturnRoomAmenityTypeByRoomAmenityTypeID(0, 0);

                    if (imRoomAmenityTypesMaster.RoomAmenityTypeMasterID > 0)
                    {

                        if (imRoomAmenityTypesMaster.RoomAmenityTypeMasterID > 0)
                        {
                            txtRoomAmenityTypeMasterName.Text = imRoomAmenityTypesMaster.RoomAmenityTypeMasterID.ToString();

                        }

                        if (imRoomAmenityTypesMaster.RoomAmenityTypeMasterDescription != null)
                        {
                            txtRoomAmenityTypeMasterDescription.Text = imRoomAmenityTypesMaster.RoomAmenityTypeMasterDescription.ToString();

                        }

                        if (imRoomAmenityTypesMaster.DateCreated > dtDateCreated.MinDate)
                        {
                            dtDateCreated.Value = imRoomAmenityTypesMaster.DateCreated;

                        }

                        if (imRoomAmenityTypesMaster.DateCreated > dtDateRegistered.MinDate)
                        {
                            dtDateRegistered.Value = imRoomAmenityTypesMaster.DateRegistered;

                        }

                        if (imRoomAmenityTypesMaster.DateDeRegistered > dtDateDeregistered.MinDate)
                        {
                            dtDateDeregistered.Value = imRoomAmenityTypesMaster.DateDeRegistered;

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

                imRoomAmenityTypesMaster = null;
            }



        }

        private void SaveRoomAmenityTypeMaster()
        {
            TRIP_API.IMRoomAmenityTypeMaster imRoomAmenityTypeMaster;

            try
            {
                imRoomAmenityTypeMaster = new TRIP_API.IMRoomAmenityTypeMaster();
                imRoomAmenityTypeMaster.RoomAmenityTypeMasterID = lCurrentRoomAmenityTypeMasterNumber;
                imRoomAmenityTypeMaster.RoomAmenityTypeMasterName = txtRoomAmenityTypeMasterName.Text;
                imRoomAmenityTypeMaster.RoomAmenityTypeMasterDescription = txtRoomAmenityTypeMasterDescription.Text;

                imRoomAmenityTypeMaster.SaveRoomAmenityTypeMaster();

            }

            catch (Exception ex)
            {
                errMessage = ex.Message;
            }

            finally
            {
                imRoomAmenityTypeMaster = null;
            }

        }

        private void PrintCurrentRecord()
        {
            try
            {

            }

            catch (Exception ex)
            {
                errMessage = ex.Message;
            }

            finally
            {

            }

        }


        #endregion
       

    }
}
