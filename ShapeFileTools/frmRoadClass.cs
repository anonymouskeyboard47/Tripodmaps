using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TRIP_API;

namespace Tripodmaps
{
    public partial class frmRoadClass : Form
    {

        private long lCurrentRoadClassMasterNumber = 0;

        public frmRoadClass()
        {
            InitializeComponent();
        }

        



        #region "FormOperations"


        private void frmRoadClass_Load(object sender, EventArgs e)
        {
            LoadForm();

        }
        
        private void LoadForm()
        {
            LoadFirstRoadClassMaster();
        }

        private void ClearForm()
        { 
            txtRoadClassMasterName.Text = "";
            txtRoadClassMasterDescription.Text = "";
            dtDateCreated.Value = dtDateCreated.MinDate;
            dtDateRegistered.Value = dtDateRegistered.MinDate;
            dtDateDeregistered.Value = dtDateDeregistered.MinDate;

        }


        #endregion


        #region "DatabaseOperations"


        private void LoadFirstRoadClassMaster()
        {

            ClearForm();

            TRIP_API.IMRoadClassMaster imRoadClassMaster = new TRIP_API.IMRoadClassMaster();

            try
            {

                imRoadClassMaster.ReturnFirstRoadClassMaster();

                lCurrentRoadClassMasterNumber = imRoadClassMaster.RoadClassMasterID;

                if (imRoadClassMaster.RoadClassMasterID > 0)
                {
                    if (imRoadClassMaster.RoadClassMasterName != null)
                    {
                        txtRoadClassMasterName.Text = imRoadClassMaster.RoadClassMasterName.ToString();

                    }

                    if (imRoadClassMaster.RoadClassMasterDescription != null)
                    {
                        txtRoadClassMasterDescription.Text = imRoadClassMaster.RoadClassMasterDescription.ToString();

                    }

                    if (imRoadClassMaster.DateCreated > dtDateCreated.MinDate)
                    {
                        dtDateCreated.Value = imRoadClassMaster.DateCreated;

                    }

                    if (imRoadClassMaster.DateCreated > dtDateRegistered.MinDate)
                    {
                        dtDateRegistered.Value = imRoadClassMaster.DateRegistered;

                    }

                    if (imRoadClassMaster.DateDeRegistered > dtDateDeregistered.MinDate)
                    {
                        dtDateDeregistered.Value = imRoadClassMaster.DateDeRegistered;

                    }

                }

            }

            catch (Exception ex)
            {
                string err = ex.Message + " Source=" + ex.Source;
            }

            finally
            {

                imRoadClassMaster = null;
            }

        }

        private void LoadNextRoadClassMaster()
        {
            TRIP_API.IMRoadClassMaster imRoadClassMaster = new TRIP_API.IMRoadClassMaster();

            try
            {


                imRoadClassMaster.RoadClassMasterID = lCurrentRoadClassMasterNumber;

                if (imRoadClassMaster.ReturnNextRoadClassMaster() == true)
                {
                    ClearForm();
                    lCurrentRoadClassMasterNumber = imRoadClassMaster.RoadClassMasterID;

                    if (imRoadClassMaster.RoadClassMasterID > 0)
                    {
                        if (imRoadClassMaster.RoadClassMasterName != null)
                        {
                            txtRoadClassMasterName.Text = imRoadClassMaster.RoadClassMasterName.ToString();

                        }

                        if (imRoadClassMaster.RoadClassMasterDescription != null)
                        {
                            txtRoadClassMasterDescription.Text = imRoadClassMaster.RoadClassMasterDescription.ToString();

                        }

                        if (imRoadClassMaster.DateCreated > dtDateCreated.MinDate)
                        {
                            dtDateCreated.Value = imRoadClassMaster.DateCreated;

                        }

                        if (imRoadClassMaster.DateCreated > dtDateRegistered.MinDate)
                        {
                            dtDateRegistered.Value = imRoadClassMaster.DateRegistered;

                        }

                        if (imRoadClassMaster.DateDeRegistered > dtDateDeregistered.MinDate)
                        {
                            dtDateDeregistered.Value = imRoadClassMaster.DateDeRegistered;

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

                imRoadClassMaster = null;
            }



        }

        private void LoadPreviousRoadClassMaster()
        {
            TRIP_API.IMRoadClassMaster imRoadClassMaster = new TRIP_API.IMRoadClassMaster();

            try
            {

                imRoadClassMaster.RoadClassMasterID = lCurrentRoadClassMasterNumber;
                if (imRoadClassMaster.ReturnPreviousRoadClassMaster() == true)
                {
                    ClearForm();
                    lCurrentRoadClassMasterNumber = imRoadClassMaster.RoadClassMasterID;

                    if (imRoadClassMaster.RoadClassMasterID > 0)
                    {
                        if (imRoadClassMaster.RoadClassMasterName != null)
                        {
                            txtRoadClassMasterName.Text = imRoadClassMaster.RoadClassMasterName.ToString();

                        }

                        if (imRoadClassMaster.RoadClassMasterDescription != null)
                        {
                            txtRoadClassMasterDescription.Text = imRoadClassMaster.RoadClassMasterDescription.ToString();

                        }

                        if (imRoadClassMaster.DateCreated > dtDateCreated.MinDate)
                        {
                            dtDateCreated.Value = imRoadClassMaster.DateCreated;

                        }

                        if (imRoadClassMaster.DateCreated > dtDateRegistered.MinDate)
                        {
                            dtDateRegistered.Value = imRoadClassMaster.DateRegistered;

                        }

                        if (imRoadClassMaster.DateDeRegistered > dtDateDeregistered.MinDate)
                        {
                            dtDateDeregistered.Value = imRoadClassMaster.DateDeRegistered;

                        }


                    }
                }
                else
                {


                }

            }

            catch (Exception ex)
            {
                string err = ex.Message + " Source=" + ex.Source;
            }

            finally
            {

                imRoadClassMaster = null;
            }



        }

        private void LoadLastRoadClassMaster()
        {
            ClearForm();

            TRIP_API.IMRoadClassMaster imRoadClassMaster = new TRIP_API.IMRoadClassMaster();

            try
            {


                imRoadClassMaster.ReturnLastRoadClassMaster();
                lCurrentRoadClassMasterNumber = imRoadClassMaster.RoadClassMasterID;

                if (imRoadClassMaster.RoadClassMasterID > 0)
                {

                    if (imRoadClassMaster.RoadClassMasterName != null)
                    {
                        txtRoadClassMasterName.Text = imRoadClassMaster.RoadClassMasterName.ToString();

                    }

                    if (imRoadClassMaster.RoadClassMasterDescription != null)
                    {
                        txtRoadClassMasterDescription.Text = imRoadClassMaster.RoadClassMasterDescription.ToString();

                    }

                    if (imRoadClassMaster.DateCreated > dtDateCreated.MinDate)
                    {
                        dtDateCreated.Value = imRoadClassMaster.DateCreated;

                    }

                    if (imRoadClassMaster.DateCreated > dtDateRegistered.MinDate)
                    {
                        dtDateRegistered.Value = imRoadClassMaster.DateRegistered;

                    }

                    if (imRoadClassMaster.DateDeRegistered > dtDateDeregistered.MinDate)
                    {
                        dtDateDeregistered.Value = imRoadClassMaster.DateDeRegistered;

                    }

                }

            }

            catch (Exception ex)
            {
                string err = ex.Message + " Source=" + ex.Source;
            }

            finally
            {

                imRoadClassMaster = null;
            }



        }

        private void LoadRoadClassMasterByBuildingTypeID(long lArgRoadClassMasterNumber)
        {

            ClearForm();

            TRIP_API.IMRoadClassMaster imRoadClassMaster = new TRIP_API.IMRoadClassMaster();

            try
            {

                if (lArgRoadClassMasterNumber > 0)
                {
                    imRoadClassMaster.RoadClassMasterID = lArgRoadClassMasterNumber;
                    imRoadClassMaster.ReturnRoadClassByRoadClassID(0, 0);

                    if (imRoadClassMaster.RoadClassMasterID > 0)
                    {

                        if (imRoadClassMaster.RoadClassMasterID > 0)
                        {
                            txtRoadClassMasterName.Text = imRoadClassMaster.RoadClassMasterID.ToString();

                        }

                        if (imRoadClassMaster.RoadClassMasterDescription != null)
                        {
                            txtRoadClassMasterDescription.Text = imRoadClassMaster.RoadClassMasterDescription.ToString();

                        }

                        if (imRoadClassMaster.DateCreated > dtDateCreated.MinDate)
                        {
                            dtDateCreated.Value = imRoadClassMaster.DateCreated;

                        }

                        if (imRoadClassMaster.DateCreated > dtDateRegistered.MinDate)
                        {
                            dtDateRegistered.Value = imRoadClassMaster.DateRegistered;

                        }

                        if (imRoadClassMaster.DateDeRegistered > dtDateDeregistered.MinDate)
                        {
                            dtDateDeregistered.Value = imRoadClassMaster.DateDeRegistered;

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

                imRoadClassMaster = null;
            }



        }


        #endregion

    }
}
