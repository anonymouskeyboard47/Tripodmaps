using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tripodmaps
{
    public partial class frmSearch : Tripodmaps.ToolWindow
    {
        private string errMessage = "";
        private long lDirection = 0;
        private long lOffset = 0;
        private long lExactVal = 0;

        private Bitmap blank;
        private Bitmap x;
        private Bitmap o;
        private int bitmapPadding = 6;    


        #region "FormEvents"


        public frmSearch()
        {
            InitializeComponent();
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            dtgrdvwFind.ReadOnly = true;
        }

        private void cmbFindCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbFindSubCriteria.Items.Clear();
            dtgrdvwFind.DataSource = null;
            dtgrdvwFind.Columns.Clear();
            txtFindValue.Text = "";
            txtMaxValue.Text = "";
            txtMinValue.Text = "";
            chkExactValue.Checked = false;
            chkFilterByValue.Checked = false;
            ChangeByCriteria();            
            
        }

        private void cmbFindSubCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtgrdvwFind.DataSource = null;
            dtgrdvwFind.Columns.Clear();
            txtFindValue.Text = "";
            txtMaxValue.Text = "";
            txtMinValue.Text = "";
            chkExactValue.Checked = false;
            chkFilterByValue.Checked = false;
            FindBySelection();            
        }

        private void cmdPrevious_Click(object sender, EventArgs e)
        {
            lDirection = 2;
            dtgrdvwFind.Columns.Clear();
            LoadBySelection();
        }        

        private void dtgrdvwFind_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgrdvwFind.RowCount > 0)
            {
                if (dtgrdvwFind.SelectedRows.Count > 0)
                {
                    if (!dtgrdvwFind.SelectedRows[0].IsNewRow)
                    {
                        MapZoomToParcel(Convert.ToInt64(dtgrdvwFind.SelectedRows[0].Cells["PLOTID"].Value));
                    }
                }
            }

        }

        private void dtgrdvwFind_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgrdvwFind.RowCount > 0)
            {
                if (dtgrdvwFind.SelectedRows.Count > 0)
                {
                    if (!dtgrdvwFind.SelectedRows[0].IsNewRow)
                    {
                        MapZoomToParcel(Convert.ToInt64(dtgrdvwFind.SelectedRows[0].Cells["PLOTID"].Value));
                    }
                }
            }

        }

        private void dtgrdvwFind_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dtgrdvwFind.RowCount > 0)
            {
                if (dtgrdvwFind.SelectedRows.Count > 0)
                {

                    if (!dtgrdvwFind.SelectedRows[0].IsNewRow)
                    {
                        MapZoomToParcel(Convert.ToInt64(dtgrdvwFind.SelectedRows[0].Cells["PLOTID"].Value));
                    }
                }
            }



        }

        private void cmdFind_Click(object sender, EventArgs e)
        {
            dtgrdvwFind.Columns.Clear();
            LoadBySelection();
        }

        private void cmdNextTen_Click(object sender, EventArgs e)
        {
            lDirection = 1;
            dtgrdvwFind.Columns.Clear();
            LoadBySelection();
        }

        private void numNumberToDisplay_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                lOffset = 0;
                dtgrdvwFind.Columns.Clear();
                LoadBySelection();
            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;

            }

            finally
            {


            }
        }

        private void txtFindValue_TextChanged(object sender, EventArgs e)
        {
            lOffset = 0;
            lDirection = 1;
        }

        private void txtFindValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtgrdvwFind.Columns.Clear();
                LoadBySelection();
            }
        }



        #endregion



        #region "DataGridColumns"

        private void ChangeByCriteria()
        {
            int cmbCriteria;

            cmbCriteria = -1;
            cmbCriteria = cmbFindCriteria.SelectedIndex;

            switch (cmbCriteria)
            {
                case 0:
                    //Plot
                    cmbFindSubCriteria.Items.Add("Plot Number");
                    cmbFindSubCriteria.Items.Add("Plots for Sale");
                    cmbFindSubCriteria.Items.Add("Plot for Lease");
                    cmbFindSubCriteria.Items.Add("Size of Plot in Acres with sale details");
                    cmbFindSubCriteria.Items.Add("Size of Plot in Acres with lease details");
                    cmbFindSubCriteria.Items.Add("Size of Plot in Acres with any details");
                    cmbFindSubCriteria.Items.Add("Plots near map centre");
                    break;

                case 1:
                    //Points of interest
                    cmbFindSubCriteria.Items.Add("Point Name");
                    cmbFindSubCriteria.Items.Add("Point Category e.g. Hospital, School, Hotel");
                    cmbFindSubCriteria.Items.Add("Point Sub Category e.g. Clinic, 3 Star Hotel");
                    break;

                case 2:
                    //Buildings
                    cmbFindSubCriteria.Items.Add("Building Name");
                    cmbFindSubCriteria.Items.Add("Building with Rental Space");
                    cmbFindSubCriteria.Items.Add("Building with Rental Space and X number of rooms");
                    cmbFindSubCriteria.Items.Add("Building with Appartments with Certain Amenities and X Rooms");
                    cmbFindSubCriteria.Items.Add("Buildings with certain point categories");
                    cmbFindSubCriteria.Items.Add("Buildings with Usage e.g Residential, Commercial");
                    cmbFindSubCriteria.Items.Add("Buildings Type - Permanent, Semi-Permanent");
                    break;

                case 3:
                    //Roads
                    cmbFindSubCriteria.Items.Add("Road Name");
                    cmbFindSubCriteria.Items.Add("Road Class");
                    cmbFindSubCriteria.Items.Add("Road Surface Type - e.g. Murram, Tarmac");
                    break;

                case 4:
                    //Property Agents
                    cmbFindSubCriteria.Items.Add("Property Agent Name");
                    cmbFindSubCriteria.Items.Add("Property Agent in Geographical Area");
                    cmbFindSubCriteria.Items.Add("Property Agent with X number of TripodStars");
                    break;


            }
        }

        private void FindBySelection()
        {
            int cmbSubCriteria;

            cmbSubCriteria = -1;

            //Plots
            if (cmbFindCriteria.SelectedIndex == 0)
            {
                cmbSubCriteria = cmbFindSubCriteria.SelectedIndex;

                switch (cmbSubCriteria)
                {
                    case 0:
                        FindByPlotNumber();
                        break;

                    case 1:
                        FindByPlotsForSale();
                        break;

                    case 2:
                        FindByPlotsForLease();
                        break;

                    case 3:
                        FindByBuildingName();
                        break;

                    case 4:
                        FindByRoadNames();
                        break;

                    case 5:
                        FindByCustomerNumber();
                        break;

                    case 6:
                        FindByCustomerName();
                        break;

                    case 7:
                        FindByPrivateCustomerSurnameName();
                        break;

                    case 8:
                        FindByCompanyCustomerCompanyName();
                        break;

                    case 9:
                        FindByCustomerPINCode();
                        break;
                }
            }

            //Points of interest
            if (cmbFindCriteria.SelectedIndex == 1)
            {
                cmbSubCriteria = cmbFindSubCriteria.SelectedIndex;

                switch (cmbSubCriteria)
                {
                    case 0:
                        FindByPointsOfInterest();
                        break;

                    case 1:
                        FindByPointsOfInterest();
                        break;

                    case 2:
                        FindParcelsForSaleOrLease();
                        break;


                }
            }

            //Buildings
            if (cmbFindCriteria.SelectedIndex == 2)
            {
                cmbSubCriteria = cmbFindSubCriteria.SelectedIndex;

                switch (cmbSubCriteria)
                {
                    case 0:
                        //FindByBuildingName
                        break;

                    case 1:
                        //Building with Rental Space
                        break;


                    case 2:
                        //Building with Rental Space and X number of rooms
                        break;

                    case 3:
                        //Building with Appartments with Certain Amenities and X Rooms
                        break;

                    case 4:
                        //Buildings with certain point categories
                        break;

                    case 5:
                        //Buildings with Usage e.g Residential, Commercial
                        break;

                    case 6:
                        //Buildings Type - Permanent, Semi-Permanent
                        break;

                }
            }


            //Buildings
            if (cmbFindCriteria.SelectedIndex == 2)
            {
                cmbSubCriteria = cmbFindSubCriteria.SelectedIndex;

                switch (cmbSubCriteria)
                {
                    case 0:
                        //RoadName
                        break;

                    case 1:
                        //Road Class
                        break;


                    case 2:
                        //Road Surface Type - e.g. Murram, Tarmac
                        break;

                    case 3:
                        //Building with Appartments with Certain Amenities and X Rooms
                        break;

                    case 4:
                        //Buildings with certain point categories
                        break;

                    case 5:
                        //Buildings with Usage e.g Residential, Commercial
                        break;

                    case 6:
                        //Buildings Type - Permanent, Semi-Permanent
                        break;

                }
            }


        }

        public void FindByPlotsForSale()
        {
            try
            {
                DataGridViewImageColumn imageColumn;

                Bitmap unMarked = blank;
                imageColumn = new DataGridViewImageColumn();

                //Add twice the padding for the left and 
                //right sides of the cell.
                imageColumn.Width = x.Width + 2 * bitmapPadding + 1;

                imageColumn.Image = unMarked;


                dtgrdvwFind.DataMember = "";
                dtgrdvwFind.Columns.Clear();

                dtgrdvwFind.Columns.Add("PLOTID", "PLOT ID");

                dtgrdvwFind.Columns.Add(imageColumn);


                dtgrdvwFind.Columns.Add("PARCELNO", "PARCEL NUMBER");
                dtgrdvwFind.Columns["PARCELNO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgrdvwFind.Columns.Add("SALEPRICE", "SALE PRICE");
                dtgrdvwFind.Columns.Add("PLOTAREA", "PLOT AREA");
                dtgrdvwFind.Columns.Add("LOCALITY", "LOCALITY");
                dtgrdvwFind.Columns.Add("DEEDPLANNUMBER", "DEED PLAN NUMBER");
                dtgrdvwFind.Columns.Add("REGISTRYSHEETNO", "REGISTRY SHEET NUMBER");
                dtgrdvwFind.Columns.Add("TITLEDEEDNUMBER", "TITLE DEED NUMBER");
                dtgrdvwFind.Columns.Add("PHYSICALADDRESS", "PHYSICAL ADDRESS");
                dtgrdvwFind.Columns.Add("UNIVERSALADDRESS", "UNIVERSALADDRESS");
                dtgrdvwFind.Columns.Add("PROVINCE", "PROVINCE");
                dtgrdvwFind.Columns.Add("DISTRICT", "DISTRICT");
                dtgrdvwFind.Columns.Add("DIVISION", "DIVISION");
                dtgrdvwFind.Columns.Add("LOCATION", "LOCATION");
                dtgrdvwFind.Columns.Add("SUBLOCATION", "SUB-LOCATION");
                dtgrdvwFind.Columns.Add("COORDINATES", "COORDINATES");

                dtgrdvwFind.ColumnHeadersVisible = true;
                dtgrdvwFind.AutoSize = true;
                dtgrdvwFind.Columns["PLOTID"].Visible = false;

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }

        }

        public void FindByPlotsForLease()
        {
            try
            {
                DataGridViewImageColumn imageColumn;

                Bitmap unMarked = blank;
                imageColumn = new DataGridViewImageColumn();

                //Add twice the padding for the left and 
                //right sides of the cell.
                imageColumn.Width = x.Width + 2 * bitmapPadding + 1;

                imageColumn.Image = unMarked;


                dtgrdvwFind.DataMember = "";
                dtgrdvwFind.Columns.Clear();

                dtgrdvwFind.Columns.Add("PLOTID", "PLOT ID");

                dtgrdvwFind.Columns.Add(imageColumn);

                dtgrdvwFind.Columns.Add("PLOTID", "PLOT ID");
                dtgrdvwFind.Columns.Add("PARCELNO", "PARCEL NUMBER");
                dtgrdvwFind.Columns["PARCELNO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgrdvwFind.Columns.Add("LEASEPRICE", "LEASE PRICE");
                dtgrdvwFind.Columns.Add("PLOTAREA", "PLOT AREA");
                dtgrdvwFind.Columns.Add("LOCALITY", "LOCALITY");
                dtgrdvwFind.Columns.Add("DEEDPLANNUMBER", "DEED PLAN NUMBER");
                dtgrdvwFind.Columns.Add("REGISTRYSHEETNO", "REGISTRY SHEET NUMBER");
                dtgrdvwFind.Columns.Add("TITLEDEEDNUMBER", "TITLE DEED NUMBER");
                dtgrdvwFind.Columns.Add("PHYSICALADDRESS", "PHYSICAL ADDRESS");
                dtgrdvwFind.Columns.Add("UNIVERSALADDRESS", "UNIVERSALADDRESS");
                dtgrdvwFind.Columns.Add("PROVINCE", "PROVINCE");
                dtgrdvwFind.Columns.Add("DISTRICT", "DISTRICT");
                dtgrdvwFind.Columns.Add("DIVISION", "DIVISION");
                dtgrdvwFind.Columns.Add("LOCATION", "LOCATION");
                dtgrdvwFind.Columns.Add("SUBLOCATION", "SUB-LOCATION");
                dtgrdvwFind.Columns.Add("COORDINATES", "COORDINATES");

                dtgrdvwFind.ColumnHeadersVisible = true;
                dtgrdvwFind.AutoSize = true;
                dtgrdvwFind.Columns["PLOTID"].Visible = false;

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }

        }

        public void FindParcelsForSaleOrLease()
        {
            try
            {
                dtgrdvwFind.DataMember = "";
                dtgrdvwFind.Columns.Clear();
                dtgrdvwFind.Columns.Add("PLOTID", "PLOT ID");
                dtgrdvwFind.Columns.Add("PARCELNO", "PARCEL NUMBER");
                dtgrdvwFind.Columns["PARCELNO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgrdvwFind.Columns.Add("SALEPRICE", "SALE PRICE");
                dtgrdvwFind.Columns.Add("PLOTAREA", "PLOT AREA");
                dtgrdvwFind.Columns.Add("LOCALITY", "LOCALITY");
                dtgrdvwFind.Columns.Add("DEEDPLANNUMBER", "DEED PLAN NUMBER");
                dtgrdvwFind.Columns.Add("REGISTRYSHEETNO", "REGISTRY SHEET NUMBER");
                dtgrdvwFind.Columns.Add("TITLEDEEDNUMBER", "TITLE DEED NUMBER");
                dtgrdvwFind.Columns.Add("PHYSICALADDRESS", "PHYSICAL ADDRESS");
                dtgrdvwFind.Columns.Add("UNIVERSALADDRESS", "UNIVERSALADDRESS");
                dtgrdvwFind.Columns.Add("PROVINCE", "PROVINCE");
                dtgrdvwFind.Columns.Add("DISTRICT", "DISTRICT");
                dtgrdvwFind.Columns.Add("DIVISION", "DIVISION");
                dtgrdvwFind.Columns.Add("LOCATION", "LOCATION");
                dtgrdvwFind.Columns.Add("SUBLOCATION", "SUB-LOCATION");
                dtgrdvwFind.Columns.Add("COORDINATES", "COORDINATES");

                dtgrdvwFind.ColumnHeadersVisible = true;
                dtgrdvwFind.AutoSize = true;
                dtgrdvwFind.Columns["PLOTID"].Visible = false;

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }

        }

        public void FindByPointsOfInterest()
        {
            try
            {
                DataGridViewImageColumn imageColumn;

                Bitmap unMarked = blank;
                imageColumn = new DataGridViewImageColumn();

                //Add twice the padding for the left and 
                //right sides of the cell.
                imageColumn.Width = x.Width + 2 * bitmapPadding + 1;

                imageColumn.Image = unMarked;


                dtgrdvwFind.DataMember = "";
                dtgrdvwFind.Columns.Clear();

                dtgrdvwFind.Columns.Add("ADDRESSID", "ADDRESSID");

                dtgrdvwFind.Columns.Add(imageColumn);

                dtgrdvwFind.Columns.Add("ADDRESSID", "ADDRESSID");
                dtgrdvwFind.Columns.Add("NAME", "NAME");
                dtgrdvwFind.Columns.Add("COORDINATES", "COORDINATES");
                dtgrdvwFind.Columns.Add("PHYSICALADDRESS", "PHYSICAL ADDRESS");
                dtgrdvwFind.Columns.Add("UNIVERSALADDRESS", "UNIVERSALADDRESS");
                dtgrdvwFind.Columns.Add("PROVINCE", "PROVINCE");
                dtgrdvwFind.Columns.Add("DISTRICT", "DISTRICT");
                dtgrdvwFind.Columns.Add("DIVISION", "DIVISION");
                dtgrdvwFind.Columns.Add("LOCATION", "LOCATION");
                dtgrdvwFind.Columns.Add("SUBLOCATION", "SUB-LOCATION");
                dtgrdvwFind.Columns.Add("COORDINATES", "COORDINATES");

                dtgrdvwFind.ColumnHeadersVisible = true;
                dtgrdvwFind.AutoSize = true;
                dtgrdvwFind.Columns["ADDRESSID"].Visible = false;

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }

        }

        public void FindByPlotNumber()
        {

            try
            {
                cmbFindCriteria.SelectedIndex = 0;
                cmbFindSubCriteria.SelectedIndex = 0;

                DataGridViewImageColumn imageColumn;

                Bitmap unMarked = blank;
                imageColumn = new DataGridViewImageColumn();

                //Add twice the padding for the left and 
                //right sides of the cell.
                //imageColumn.Width = x.Width + 2 * bitmapPadding + 1;

                imageColumn.Name = "IMAGE";
                imageColumn.Image = unMarked;


                dtgrdvwFind.DataMember = "";
                dtgrdvwFind.Columns.Clear();

                dtgrdvwFind.Columns.Add("PLOTID", "PLOT ID");

                dtgrdvwFind.Columns.Add(imageColumn);

                dtgrdvwFind.Columns.Add("PARCELNO", "PARCEL NUMBER");
                dtgrdvwFind.Columns["PARCELNO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgrdvwFind.Columns["PARCELNO"].ToolTipText =
                    "Similar to L.R (Land Reference), Mazrui Number (IMN), Government Land (G.L)";
                dtgrdvwFind.Columns.Add("PLOTAREA", "PLOT AREA");
                dtgrdvwFind.Columns.Add("LOCALITY", "LOCALITY");
                dtgrdvwFind.Columns.Add("DEEDPLANNUMBER", "DEED PLAN NUMBER");
                dtgrdvwFind.Columns.Add("REGISTRYSHEETNO", "REGISTRY SHEET NUMBER");
                dtgrdvwFind.Columns.Add("TITLEDEEDNUMBER", "TITLE DEED NUMBER");
                dtgrdvwFind.Columns.Add("PHYSICALADDRESS", "PHYSICAL ADDRESS");
                dtgrdvwFind.Columns.Add("UNIVERSALADDRESS", "UNIVERSALADDRESS");
                dtgrdvwFind.Columns.Add("PROVINCE", "PROVINCE");
                dtgrdvwFind.Columns.Add("DISTRICT", "DISTRICT");
                dtgrdvwFind.Columns.Add("DIVISION", "DIVISION");
                dtgrdvwFind.Columns.Add("LOCATION", "LOCATION");
                dtgrdvwFind.Columns.Add("SUBLOCATION", "SUB-LOCATION");
                dtgrdvwFind.Columns.Add("COORDINATES", "COORDINATES");

                dtgrdvwFind.ColumnHeadersVisible = true;
                dtgrdvwFind.AutoSize = true;
                dtgrdvwFind.Columns["PLOTID"].Visible = false;

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }


        }

        public void FindByBuildingName()
        {
            try
            {
                DataGridViewImageColumn imageColumn;

                Bitmap unMarked = blank;
                imageColumn = new DataGridViewImageColumn();

                //Add twice the padding for the left and 
                //right sides of the cell.
                imageColumn.Width = x.Width + 2 * bitmapPadding + 1;

                imageColumn.Image = unMarked;


                dtgrdvwFind.DataMember = "";
                dtgrdvwFind.Columns.Clear();

                dtgrdvwFind.Columns.Add("BUILDINGID", "BUILDING ID");

                dtgrdvwFind.Columns.Add(imageColumn);

                dtgrdvwFind.Columns.Add("BUILDINGNAME", "BUILDING NAME");
                dtgrdvwFind.Columns.Add("BUILDINGTYPE", "BUILDING TYPE");
                dtgrdvwFind.Columns.Add("CURRENTHOUSENUMBER", "CURRENT HOUSE NUMBER");
                dtgrdvwFind.Columns.Add("BUILDINGHOUSENUMBER", "HOUSE NUMBER");
                dtgrdvwFind.Columns.Add("BUILDINGHOUSENUMBER", "HOUSE TYPE");
                dtgrdvwFind.Columns.Add("NOOFFLOORS", "NO OF FLOORS");
                dtgrdvwFind.Columns.Add("PHYSICALADDRESS", "PHYSICAL ADDRESS");
                dtgrdvwFind.Columns.Add("UNIVERSALADDRESS", "UNIVERSALADDRESS");
                dtgrdvwFind.Columns.Add("PROVINCE", "PROVINCE");
                dtgrdvwFind.Columns.Add("DISTRICT", "DISTRICT");
                dtgrdvwFind.Columns.Add("DIVISION", "DIVISION");
                dtgrdvwFind.Columns.Add("LOCATION", "LOCATION");
                dtgrdvwFind.Columns.Add("SUBLOCATION", "SUB-LOCATION");
                dtgrdvwFind.Columns.Add("COORDINATES", "COORDINATES");

                dtgrdvwFind.ColumnHeadersVisible = true;
                dtgrdvwFind.AutoSize = true;

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }

        }

        public void FindByRoadNames()
        {
            try
            {
                DataGridViewImageColumn imageColumn;

                Bitmap unMarked = blank;
                imageColumn = new DataGridViewImageColumn();

                //Add twice the padding for the left and 
                //right sides of the cell.
                imageColumn.Width = x.Width + 2 * bitmapPadding + 1;

                imageColumn.Image = unMarked;


                dtgrdvwFind.DataMember = "";
                dtgrdvwFind.Columns.Clear();

                dtgrdvwFind.Columns.Add("ROADID", "ROAD ID");

                dtgrdvwFind.Columns.Add(imageColumn);

                dtgrdvwFind.Columns.Add("ROADNAME", "ROAD NAME");
                dtgrdvwFind.Columns.Add("ROADCLASS", "ROAD CLASS");
                dtgrdvwFind.Columns.Add("PROVINCE", "PROVINCE");
                dtgrdvwFind.Columns.Add("DISTRICT", "DISTRICT");
                dtgrdvwFind.Columns.Add("DIVISION", "DIVISION");
                dtgrdvwFind.Columns.Add("LOCATION", "LOCATION");
                dtgrdvwFind.Columns.Add("SUBLOCATION", "SUB-LOCATION");

                dtgrdvwFind.ColumnHeadersVisible = true;
                dtgrdvwFind.AutoSize = true;

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }

        }

        public void FindByCustomerNumber()
        {
            try
            {
                DataGridViewImageColumn imageColumn;

                Bitmap unMarked = blank;
                imageColumn = new DataGridViewImageColumn();

                //Add twice the padding for the left and 
                //right sides of the cell.
                imageColumn.Width = x.Width + 2 * bitmapPadding + 1;

                imageColumn.Image = unMarked;


                dtgrdvwFind.DataMember = "";
                dtgrdvwFind.Columns.Clear();

                dtgrdvwFind.Columns.Add("CUSTOMERNUMBER", "CUSTOMER ACCOUNT NUMBER");

                dtgrdvwFind.Columns.Add(imageColumn);


                dtgrdvwFind.Columns.Add("FIRSTNAME", "FIRSTNAME");
                dtgrdvwFind.Columns.Add("MIDDLENAME", "MIDDLENAME");
                dtgrdvwFind.Columns.Add("SURNAME", "SURNAME");
                dtgrdvwFind.Columns.Add("PINNUMBER", "PIN NUMBER");
                dtgrdvwFind.Columns.Add("PHYSICALADDRESS", "PHYSICAL ADDRESS");
                dtgrdvwFind.Columns.Add("UNIVERSALADDRESS", "UNIVERSALADDRESS");
                dtgrdvwFind.Columns.Add("PROVINCE", "PROVINCE");
                dtgrdvwFind.Columns.Add("DISTRICT", "DISTRICT");
                dtgrdvwFind.Columns.Add("DIVISION", "DIVISION");
                dtgrdvwFind.Columns.Add("LOCATION", "LOCATION");
                dtgrdvwFind.Columns.Add("SUBLOCATION", "SUB-LOCATION");
                dtgrdvwFind.Columns.Add("COORDINATES", "COORDINATES");

                dtgrdvwFind.ColumnHeadersVisible = true;
                dtgrdvwFind.AutoSize = true;

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }
        }

        public void FindByCustomerName()
        {
            try
            {
                DataGridViewImageColumn imageColumn;

                Bitmap unMarked = blank;
                imageColumn = new DataGridViewImageColumn();

                //Add twice the padding for the left and 
                //right sides of the cell.
                imageColumn.Width = x.Width + 2 * bitmapPadding + 1;

                imageColumn.Image = unMarked;


                dtgrdvwFind.DataMember = "";
                dtgrdvwFind.Columns.Clear();

                dtgrdvwFind.Columns.Add("CUSTOMERNUMBER", "CUSTOMER ACCOUNT NUMBER");

                dtgrdvwFind.Columns.Add(imageColumn);

                dtgrdvwFind.Columns.Add("FIRSTNAME", "FIRSTNAME");
                dtgrdvwFind.Columns.Add("MIDDLENAME", "MIDDLENAME");
                dtgrdvwFind.Columns.Add("SURNAME", "SURNAME");
                dtgrdvwFind.Columns.Add("PINNUMBER", "PIN NUMBER");
                dtgrdvwFind.Columns.Add("PHYSICALADDRESS", "PHYSICAL ADDRESS");
                dtgrdvwFind.Columns.Add("UNIVERSALADDRESS", "UNIVERSALADDRESS");
                dtgrdvwFind.Columns.Add("PROVINCE", "PROVINCE");
                dtgrdvwFind.Columns.Add("DISTRICT", "DISTRICT");
                dtgrdvwFind.Columns.Add("DIVISION", "DIVISION");
                dtgrdvwFind.Columns.Add("LOCATION", "LOCATION");
                dtgrdvwFind.Columns.Add("SUBLOCATION", "SUB-LOCATION");
                dtgrdvwFind.Columns.Add("COORDINATES", "COORDINATES");
                dtgrdvwFind.ColumnHeadersVisible = true;
                dtgrdvwFind.AutoSize = true;

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }

        }

        public void FindByPrivateCustomerSurnameName()
        {
            try
            {
                DataGridViewImageColumn imageColumn;

                Bitmap unMarked = blank;
                imageColumn = new DataGridViewImageColumn();

                //Add twice the padding for the left and 
                //right sides of the cell.
                imageColumn.Width = x.Width + 2 * bitmapPadding + 1;

                imageColumn.Image = unMarked;


                dtgrdvwFind.DataMember = "";
                dtgrdvwFind.Columns.Clear();

                dtgrdvwFind.Columns.Add("CUSTOMERNUMBER", "CUSTOMER ACCOUNT NUMBER");

                dtgrdvwFind.Columns.Add(imageColumn);

                dtgrdvwFind.Columns.Add("FIRSTNAME", "FIRSTNAME");
                dtgrdvwFind.Columns.Add("MIDDLENAME", "MIDDLENAME");
                dtgrdvwFind.Columns.Add("SURNAME", "SURNAME");
                dtgrdvwFind.Columns.Add("PINNUMBER", "PIN NUMBER");
                dtgrdvwFind.Columns.Add("PHYSICALADDRESS", "PHYSICAL ADDRESS");
                dtgrdvwFind.Columns.Add("UNIVERSALADDRESS", "UNIVERSALADDRESS");
                dtgrdvwFind.Columns.Add("PROVINCE", "PROVINCE");
                dtgrdvwFind.Columns.Add("DISTRICT", "DISTRICT");
                dtgrdvwFind.Columns.Add("DIVISION", "DIVISION");
                dtgrdvwFind.Columns.Add("LOCATION", "LOCATION");
                dtgrdvwFind.Columns.Add("SUBLOCATION", "SUB-LOCATION");
                dtgrdvwFind.Columns.Add("COORDINATES", "COORDINATES");

                dtgrdvwFind.ColumnHeadersVisible = true;
                dtgrdvwFind.AutoSize = true;

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }

        }

        public void FindByCompanyCustomerCompanyName()
        {
            try
            {
                DataGridViewImageColumn imageColumn;

                Bitmap unMarked = blank;
                imageColumn = new DataGridViewImageColumn();

                //Add twice the padding for the left and 
                //right sides of the cell.
                imageColumn.Width = x.Width + 2 * bitmapPadding + 1;

                imageColumn.Image = unMarked;


                dtgrdvwFind.DataMember = "";
                dtgrdvwFind.Columns.Clear();

                dtgrdvwFind.Columns.Add("CUSTOMERNUMBER", "CUSTOMER ACCOUNT NUMBER");

                dtgrdvwFind.Columns.Add(imageColumn);

                dtgrdvwFind.Columns.Add("COMPANYNAME", "COMPANY NAME");
                dtgrdvwFind.Columns.Add("VATNUMBER", "VAT NUMBER");
                dtgrdvwFind.Columns.Add("PINNUMBER", "PIN NUMBER");
                dtgrdvwFind.Columns.Add("PHYSICALADDRESS", "PHYSICAL ADDRESS");
                dtgrdvwFind.Columns.Add("UNIVERSALADDRESS", "UNIVERSALADDRESS");
                dtgrdvwFind.Columns.Add("PROVINCE", "PROVINCE");
                dtgrdvwFind.Columns.Add("DISTRICT", "DISTRICT");
                dtgrdvwFind.Columns.Add("DIVISION", "DIVISION");
                dtgrdvwFind.Columns.Add("LOCATION", "LOCATION");
                dtgrdvwFind.Columns.Add("SUBLOCATION", "SUB-LOCATION");
                dtgrdvwFind.Columns.Add("COORDINATES", "COORDINATES");



                dtgrdvwFind.ColumnHeadersVisible = true;
                dtgrdvwFind.AutoSize = true;

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }

        }

        public void FindByCustomerPINCode()
        {
            try
            {
                DataGridViewImageColumn imageColumn;

                Bitmap unMarked = blank;
                imageColumn = new DataGridViewImageColumn();

                //Add twice the padding for the left and 
                //right sides of the cell.
                imageColumn.Width = x.Width + 2 * bitmapPadding + 1;

                imageColumn.Image = unMarked;


                dtgrdvwFind.DataMember = "";
                dtgrdvwFind.Columns.Clear();

                dtgrdvwFind.Columns.Add("CUSTOMERNUMBER", "CUSTOMER ACCOUNT NUMBER");

                dtgrdvwFind.Columns.Add(imageColumn);

                dtgrdvwFind.Columns.Add("CUSTOMERNAME", "CUSTOMER NAME");
                dtgrdvwFind.Columns.Add("VATNUMBER", "VAT NUMBER");
                dtgrdvwFind.Columns.Add("PINNUMBER", "PIN NUMBER");
                dtgrdvwFind.Columns.Add("PHYSICALADDRESS", "PHYSICAL ADDRESS");
                dtgrdvwFind.Columns.Add("UNIVERSALADDRESS", "UNIVERSALADDRESS");
                dtgrdvwFind.Columns.Add("PROVINCE", "PROVINCE");
                dtgrdvwFind.Columns.Add("DISTRICT", "DISTRICT");
                dtgrdvwFind.Columns.Add("DIVISION", "DIVISION");
                dtgrdvwFind.Columns.Add("LOCATION", "LOCATION");
                dtgrdvwFind.Columns.Add("SUBLOCATION", "SUB-LOCATION");
                dtgrdvwFind.Columns.Add("COORDINATES", "COORDINATES");


                dtgrdvwFind.ColumnHeadersVisible = true;
                dtgrdvwFind.AutoSize = true;

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {

            }

        }


        #endregion



        #region "DataGridLoadMethods"


        public void LoadParcelsForSaleOrLease()
        {

        }

        public void LoadByPlotNumber()
        {
            TRIP_API.IMPlotMaster imPlotMaster = null;
            FindByPlotNumber();

            try
            {
                imPlotMaster = new TRIP_API.IMPlotMaster();
                imPlotMaster.ParcelNo = txtFindValue.Text.Trim();

                if (chkExactValue.Checked == true)
                {
                    lExactVal = 1;
                }
                else
                {
                    lExactVal = 0;
                }
                    
                


                imPlotMaster.ReturnAllPlotMasterByParcelNo(lExactVal, Convert.ToInt64(numNumberToDisplay.Value), lOffset);

                if (imPlotMaster.PlotMasterDataSet != null)
                {
                    if (imPlotMaster.PlotMasterDataSet.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow myDataRowsPlot in imPlotMaster.PlotMasterDataSet.Tables[0].Rows)
                        {
                            dtgrdvwFind.AutoGenerateColumns = false;
                            dtgrdvwFind.DataSource = imPlotMaster.PlotMasterDataSet.Tables[0];

                            dtgrdvwFind.Columns["PLOTID"].DataPropertyName = "PLOTID";
                            dtgrdvwFind.Columns["PARCELNO"].DataPropertyName = "PARCELNO";
                            dtgrdvwFind.Columns["REGISTRYSHEETNO"].DataPropertyName = "REGISTRYMAPSHEETNO";
                            dtgrdvwFind.Columns["TITLEDEEDNUMBER"].DataPropertyName = "TITLEDEEDNUMBER";
                            dtgrdvwFind.Columns["PLOTAREA"].DataPropertyName = "PLOTAREA";

                        }
                    }

                    if (lDirection == 1)
                    {
                        if (lOffset == 0)
                        {
                            lOffset = lOffset + Convert.ToInt64(numNumberToDisplay.Value);
                        }
                    }
                }

                dtgrdvwFind.Focus();

                if (lDirection == 1)
                {                   
                        if (imPlotMaster.PlotMasterDataSet != null)
                        {
                            lOffset = lOffset + Convert.ToInt64(numNumberToDisplay.Value);
                        }
                }

                else if (lDirection == 2)
                {
                    if (imPlotMaster.PlotMasterDataSet != null)
                    {
                        if ((lOffset - Convert.ToInt64(numNumberToDisplay.Value)) >= 0)
                        {
                            lOffset = lOffset - Convert.ToInt64(numNumberToDisplay.Value);
                        }



                        if (lOffset < 0)
                        {
                            lOffset = 0;
                        }
                    }
                }

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {
                if (imPlotMaster != null)
                {
                    imPlotMaster = null;
                }
            }

        }

        public void LoadByPointOfInterest()
        {
            TRIP_API.IMAddress imAddress = null;
            FindByPointsOfInterest();

            try
            {
                imAddress = new TRIP_API.IMAddress();
                imAddress.AddressDetailsPointName = txtFindValue.Text.Trim();

                if (chkExactValue.Checked == true)
                {
                    imAddress.ExactMatch = 1;
                }
                else
                {
                    imAddress.ExactMatch = 0;
                }

                imAddress.ReturnAllAddressDetailsByPointName(Convert.ToInt64(numNumberToDisplay.Value), lOffset);

                if (imAddress.AddressDetailsDataSet != null)
                {
                    if (imAddress.AddressDetailsDataSet.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow myDataRowsPlot in imAddress.AddressDetailsDataSet.Tables[0].Rows)
                        {
                            dtgrdvwFind.AutoGenerateColumns = false;
                            dtgrdvwFind.DataSource = imAddress.AddressDetailsDataSet.Tables[0];

                            dtgrdvwFind.Columns["ADDRESSID"].DataPropertyName = "ADDRESSDETAILSID";
                            dtgrdvwFind.Columns["NAME"].DataPropertyName = "POINTNAME";
                        }
                    }
                }

                dtgrdvwFind.Focus();

                if (lDirection == 1)
                {
                    lOffset = lOffset + Convert.ToInt64(numNumberToDisplay.Value);
                }
                else if (lDirection == 2)
                {
                    lOffset = lOffset - Convert.ToInt64(numNumberToDisplay.Value);

                    if (lOffset < 0)
                    {
                        lOffset = 0;
                    }
                }

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {
                if (imAddress != null)
                {
                    imAddress = null;
                }
            }

        }

        public void LoadByPlotNumber(string strFindValue)
        {

            TRIP_API.IMPlotMaster imPlotMaster = null;
            FindByPlotNumber();

            try
            {
                imPlotMaster = new TRIP_API.IMPlotMaster();
                imPlotMaster.ParcelNo = strFindValue.Trim();
                imPlotMaster.ReturnAllPlotMasterByParcelNo(0, 10, lOffset);
                txtFindValue.Text = strFindValue.Trim();
                cmbFindCriteria.SelectedIndex = 0;

                if (imPlotMaster.PlotMasterDataSet != null)
                {
                    if (imPlotMaster.PlotMasterDataSet.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow myDataRowsPlot in imPlotMaster.PlotMasterDataSet.Tables[0].Rows)
                        {
                            dtgrdvwFind.AutoGenerateColumns = false;
                            dtgrdvwFind.DataSource = imPlotMaster.PlotMasterDataSet.Tables[0];

                            dtgrdvwFind.Columns["PLOTID"].DataPropertyName = "PLOTID";
                            dtgrdvwFind.Columns["PARCELNO"].DataPropertyName = "PARCELNO";
                            dtgrdvwFind.Columns["REGISTRYSHEETNO"].DataPropertyName = "REGISTRYMAPSHEETNO";
                            dtgrdvwFind.Columns["TITLEDEEDNUMBER"].DataPropertyName = "TITLEDEEDNUMBER";
                            dtgrdvwFind.Columns["PLOTAREA"].DataPropertyName = "PLOTAREA";
                            dtgrdvwFind.Columns.Add("PROVINCE", "PROVINCE");
                            dtgrdvwFind.Columns.Add("DISTRICT", "DISTRICT");
                            dtgrdvwFind.Columns.Add("DIVISION", "DIVISION");
                            dtgrdvwFind.Columns.Add("LOCATION", "LOCATION");
                            dtgrdvwFind.Columns.Add("SUBLOCATION", "SUB-LOCATION");


                        }
                    }
                }
            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {
                if (imPlotMaster != null)
                {
                    imPlotMaster = null;
                }
            }

        }        

        private void LoadBySelection()
        {
            //statLabel1.Text = "Searching ..... ";

            int cmbCriteria;

            cmbCriteria = -1;
            cmbCriteria = cmbFindSubCriteria.SelectedIndex;


            if (cmbFindCriteria.SelectedIndex == 0)
            {
                switch (cmbCriteria)
                {
                    case 0:
                        LoadByPlotNumber();
                        break;

                    case 1:

                        break;

                    case 2:
                        LoadParcelsForSaleOrLease();
                        break;

                    case 3:
                        break;

                    case 4:
                        break;

                    case 5:
                        break;

                    case 6:
                        break;

                    case 7:
                        break;

                    case 8:
                        break;

                    case 9:
                        break;

                }
            }

            if (cmbFindCriteria.SelectedIndex == 1)
            {
                switch (cmbCriteria)
                {
                    case 0:
                        //Point Name
                        LoadByPointOfInterest();
                        break;

                    case 1:
                        break;

                    case 2:
                        break;
                }
            }

            //statLabel1.Text = "";
            lDirection = 0;

            if (dtgrdvwFind.Rows.Count > 0)
            {
                int cntRecords = 0;

                cntRecords = dtgrdvwFind.Rows.Count - 1;
                //statLabel1.Text = cntRecords.ToString();
            }

        }



        #endregion



        #region "GIS"

        public void MapZoomToParcel(long lArgPlotID)
        {
            TRIP_API.IMPlotMaster imPlotMaster = null;

            try
            {
                if (lArgPlotID != 0)
                {

                    TripodMainForm frmMain = (TripodMainForm)Application.OpenForms["TripodMainForm"];

                    imPlotMaster = new TRIP_API.IMPlotMaster();

                    imPlotMaster.PlotID = lArgPlotID;

                    imPlotMaster.ReturnPlotMasterByPlotID(0, 0);

                    if (imPlotMaster.MapID > 0)
                    {
                        frmMain.ZoomToLandParcel(imPlotMaster.MapID);
                    }
                }
            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
            }

            finally
            {
                if (imPlotMaster != null)
                {
                    imPlotMaster = null;
                }
            }
        }

        #endregion




    }
}
