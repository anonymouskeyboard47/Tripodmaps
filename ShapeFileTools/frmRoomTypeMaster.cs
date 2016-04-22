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
    public partial class frmRoomTypeMaster : Form
    {
        private long lCurrentRoomTypeMasterNumber = 0;
        private string errRoom;

        public frmRoomTypeMaster()
        {
            InitializeComponent();
        }


        #region "FormOperations"


        private void frmRoomTypeMaster_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void LoadForm()
        {
            LoadFirstRoomTypeMaster();
        }

        private void ClearForm()
        {
            txtRoomTypeMasterName.Text = "";
            txtRoomTypeMasterDescription.Text = "";
            dtDateCreated.Value = dtDateCreated.MinDate;
            dtDateRegistered.Value = dtDateRegistered.MinDate;
            dtDateDeregistered.Value = dtDateDeregistered.MinDate;
            statstrpRoomType0.Text = "";
            statstrpRoomType1.Text = "";
            statstrpRoomType2.Text = "";
        }

        private void tlstrpbtnFirst_Click(object sender, EventArgs e)
        {
            LoadFirstRoomTypeMaster();
        }

        private void tlstrpbtnPrevious_Click(object sender, EventArgs e)
        {
            LoadPreviousRoomTypeMaster();
        }

        private void tlstrpbtnNext_Click(object sender, EventArgs e)
        {
            LoadNextRoomTypeMaster();
        }

        private void tlstrpbtnLast_Click(object sender, EventArgs e)
        {
            LoadLastRoomTypeMaster();
        }
         
        private void tlstrpbtnNew_Click(object sender, EventArgs e)
        {
            lCurrentRoomTypeMasterNumber = 0;
            ClearForm();
        }

        private void tlstrpbtnSave_Click(object sender, EventArgs e)
        {
            SaveRoomTypes();
        }

        #endregion


        #region "DatabaseOperations"


        private void LoadFirstRoomTypeMaster()
        {

            TRIP_API.IMRoomTypeMaster imRoomTypesMaster = new TRIP_API.IMRoomTypeMaster();

            try
            {

                imRoomTypesMaster.ReturnFirstRoomTypeMaster();
                lCurrentRoomTypeMasterNumber = imRoomTypesMaster.RoomTypeMasterID;

                if (imRoomTypesMaster.RoomTypeMasterID > 0)
                {
                    ClearForm();

                    if (imRoomTypesMaster.RoomTypeMasterName != null)
                    {
                        txtRoomTypeMasterName.Text = imRoomTypesMaster.RoomTypeMasterName.ToString();

                    }

                    if (imRoomTypesMaster.RoomTypeMasterDescription != null)
                    {
                        txtRoomTypeMasterDescription.Text = imRoomTypesMaster.RoomTypeMasterDescription.ToString();

                    }

                    if (imRoomTypesMaster.DateCreated > dtDateCreated.MinDate)
                    {
                        dtDateCreated.Value = imRoomTypesMaster.DateCreated;

                    }

                    if (imRoomTypesMaster.DateCreated > dtDateRegistered.MinDate)
                    {
                        dtDateRegistered.Value = imRoomTypesMaster.DateRegistered;

                    }

                    if (imRoomTypesMaster.DateDeRegistered > dtDateDeregistered.MinDate)
                    {
                        dtDateDeregistered.Value = imRoomTypesMaster.DateDeRegistered;

                    }

                }

                else
                {

                    statstrpRoomType0.Text = "No records in the database or connection not working";
                }

            }

            catch (Exception ex)
            {
                string err = ex.Message + " Source=" + ex.Source;
            }

            finally
            {

                imRoomTypesMaster = null;
            }

        }

        private void LoadPreviousRoomTypeMaster()
        {
            TRIP_API.IMRoomTypeMaster imRoomTypesMaster = new TRIP_API.IMRoomTypeMaster();

            try
            {

                imRoomTypesMaster.RoomTypeMasterID = lCurrentRoomTypeMasterNumber;

                if (imRoomTypesMaster.ReturnPreviousRoomTypeMaster() == true)
                {
                    ClearForm();
                    lCurrentRoomTypeMasterNumber = imRoomTypesMaster.RoomTypeMasterID;

                    if (imRoomTypesMaster.RoomTypeMasterID > 0)
                    {
                        if (imRoomTypesMaster.RoomTypeMasterName != null)
                        {
                            txtRoomTypeMasterName.Text = imRoomTypesMaster.RoomTypeMasterName.ToString();

                        }

                        if (imRoomTypesMaster.RoomTypeMasterDescription != null)
                        {
                            txtRoomTypeMasterDescription.Text = imRoomTypesMaster.RoomTypeMasterDescription.ToString();

                        }

                        if (imRoomTypesMaster.DateCreated > dtDateCreated.MinDate)
                        {
                            dtDateCreated.Value = imRoomTypesMaster.DateCreated;

                        }

                        if (imRoomTypesMaster.DateCreated > dtDateRegistered.MinDate)
                        {
                            dtDateRegistered.Value = imRoomTypesMaster.DateRegistered;

                        }

                        if (imRoomTypesMaster.DateDeRegistered > dtDateDeregistered.MinDate)
                        {
                            dtDateDeregistered.Value = imRoomTypesMaster.DateDeRegistered;

                        }


                    }
                }
                else
                {

                    statstrpRoomType0.Text = "You have reached the first database record";

                }

            }

            catch (Exception ex)
            {
                string err = ex.Message + " Source=" + ex.Source;
            }

            finally
            {

                imRoomTypesMaster = null;
            }



        }

        private void LoadNextRoomTypeMaster()
        {
            TRIP_API.IMRoomTypeMaster imRoomTypesMaster = new TRIP_API.IMRoomTypeMaster();

            try
            {


                imRoomTypesMaster.RoomTypeMasterID = lCurrentRoomTypeMasterNumber;

                if (imRoomTypesMaster.ReturnNextRoomTypeMaster() == true)
                {
                    ClearForm();
                    lCurrentRoomTypeMasterNumber = imRoomTypesMaster.RoomTypeMasterID;

                    if (imRoomTypesMaster.RoomTypeMasterID > 0)
                    {
                        if (imRoomTypesMaster.RoomTypeMasterName != null)
                        {
                            txtRoomTypeMasterName.Text = imRoomTypesMaster.RoomTypeMasterName.ToString();

                        }

                        if (imRoomTypesMaster.RoomTypeMasterDescription != null)
                        {
                            txtRoomTypeMasterDescription.Text = imRoomTypesMaster.RoomTypeMasterDescription.ToString();

                        }

                        if (imRoomTypesMaster.DateCreated > dtDateCreated.MinDate)
                        {
                            dtDateCreated.Value = imRoomTypesMaster.DateCreated;

                        }

                        if (imRoomTypesMaster.DateCreated > dtDateRegistered.MinDate)
                        {
                            dtDateRegistered.Value = imRoomTypesMaster.DateRegistered;

                        }

                        if (imRoomTypesMaster.DateDeRegistered > dtDateDeregistered.MinDate)
                        {
                            dtDateDeregistered.Value = imRoomTypesMaster.DateDeRegistered;

                        }

                    }

                }

                else
                {
                    statstrpRoomType0.Text = "You have reached the last database record";
                }

            }

            catch (Exception ex)
            {
                string err = ex.Message + " Source=" + ex.Source;
            }

            finally
            {

                imRoomTypesMaster = null;
            }



        }

        private void LoadLastRoomTypeMaster()
        {
           

            TRIP_API.IMRoomTypeMaster imRoomTypesMaster = new TRIP_API.IMRoomTypeMaster();

            try
            {


                imRoomTypesMaster.ReturnLastRoomTypeMaster();
                lCurrentRoomTypeMasterNumber = imRoomTypesMaster.RoomTypeMasterID;

                if (imRoomTypesMaster.RoomTypeMasterID > 0)
                {
                    ClearForm();

                    if (imRoomTypesMaster.RoomTypeMasterName != null)
                    {
                        txtRoomTypeMasterName.Text = imRoomTypesMaster.RoomTypeMasterName.ToString();

                    }

                    if (imRoomTypesMaster.RoomTypeMasterDescription != null)
                    {
                        txtRoomTypeMasterDescription.Text = imRoomTypesMaster.RoomTypeMasterDescription.ToString();

                    }

                    if (imRoomTypesMaster.DateCreated > dtDateCreated.MinDate)
                    {
                        dtDateCreated.Value = imRoomTypesMaster.DateCreated;

                    }

                    if (imRoomTypesMaster.DateCreated > dtDateRegistered.MinDate)
                    {
                        dtDateRegistered.Value = imRoomTypesMaster.DateRegistered;

                    }

                    if (imRoomTypesMaster.DateDeRegistered > dtDateDeregistered.MinDate)
                    {
                        dtDateDeregistered.Value = imRoomTypesMaster.DateDeRegistered;

                    }

                }

                else
                {
                    statstrpRoomType0.Text = "No records in the database or connection not working";
                }

            }

            catch (Exception ex)
            {
                string err = ex.Message + " Source=" + ex.Source;
            }

            finally
            {

                imRoomTypesMaster = null;
            }



        }

        private void LoadRoomTypeMasterByBuildingTypeID(long lArgRoomTypeMasterNumber)
        {

            ClearForm();

            TRIP_API.IMRoomTypeMaster imRoomTypesMaster = new TRIP_API.IMRoomTypeMaster();

            try
            {

                if (lArgRoomTypeMasterNumber > 0)
                {
                    imRoomTypesMaster.RoomTypeMasterID = lArgRoomTypeMasterNumber;
                    imRoomTypesMaster.ReturnRoomTypeMasterByRoomTypeMasterID(0, 0);

                    if (imRoomTypesMaster.RoomTypeMasterID > 0)
                    {

                        if (imRoomTypesMaster.RoomTypeMasterID > 0)
                        {
                            txtRoomTypeMasterName.Text = imRoomTypesMaster.RoomTypeMasterID.ToString();

                        }

                        if (imRoomTypesMaster.RoomTypeMasterDescription != null)
                        {
                            txtRoomTypeMasterDescription.Text = imRoomTypesMaster.RoomTypeMasterDescription.ToString();

                        }

                        if (imRoomTypesMaster.DateCreated > dtDateCreated.MinDate)
                        {
                            dtDateCreated.Value = imRoomTypesMaster.DateCreated;

                        }

                        if (imRoomTypesMaster.DateCreated > dtDateRegistered.MinDate)
                        {
                            dtDateRegistered.Value = imRoomTypesMaster.DateRegistered;

                        }

                        if (imRoomTypesMaster.DateDeRegistered > dtDateDeregistered.MinDate)
                        {
                            dtDateDeregistered.Value = imRoomTypesMaster.DateDeRegistered;

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

                imRoomTypesMaster = null;
            }



        }

        private void SaveRoomTypes()
        {
            TRIP_API.IMRoomTypeMaster imRoomTypesMaster;

            try
            {
                imRoomTypesMaster = new TRIP_API.IMRoomTypeMaster();
                imRoomTypesMaster.RoomTypeMasterID = lCurrentRoomTypeMasterNumber;
                imRoomTypesMaster.RoomTypeMasterName = txtRoomTypeMasterName.Text;
                imRoomTypesMaster.RoomTypeMasterDescription = txtRoomTypeMasterDescription.Text;

                imRoomTypesMaster.SaveRoomTypeMaster();

            }

            catch (Exception ex)
            {
                errRoom = ex.Message + " : Source = " + ex.Source;

            }

            finally
            {
                imRoomTypesMaster = null;
            }

        }


        #endregion

    }
}
