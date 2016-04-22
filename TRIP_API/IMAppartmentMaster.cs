using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace TRIP_API
{
    class IMAppartmentMaster
    {


        #region "PrivateVariables"


        private long lBuildingID = 0;
        private long lAppartmentID;
        private long lAppartmentTypeID = 0;
        private string strAppartmentNumber = "";
        private string strAppartmentDescription = "";
        private string strAppartmentHousingNumber = "";
        private DateTime dtAppartmentDateConstructed;
        private double dAppartmentSize = 0.0;
        private long lAppartmentNoOfExitDoors = 0;
        private double dAppartmentVolume = 0.0;
        private string strAppartmentPicture = "";
        private long lAppartmentNoOfWindows = 0;
        private DateTime dtDateCreated;
        private long lNoOfWashrooms = 0;
        private long lNoOfBalconies = 0;
        private long lNoOfFloors = 0;
        private long lOnFloorNo = 0;
        private DateTime dtDateRegistered;
        private DateTime dtDateDeregistered;
        private DataSet datAppartmentMasterDataset;


        #endregion


        #region "Properties"

        public long BuildingID
        {
            get { return lBuildingID; }
            set { lBuildingID = value; }
        }

        public long AppartmentID
        {
            get { return lAppartmentID; }
            set { lAppartmentID = value; }
        }

        public long AppartmentTypeID
        {
            get { return lAppartmentTypeID; }
            set { lAppartmentTypeID = value; }
        }

        public string AppartmentNumber
        {
            get { return strAppartmentNumber; }
            set { strAppartmentNumber = value; }
        }

        public string AppartmentDescription
        {
            get { return strAppartmentDescription; }
            set { strAppartmentDescription = value; }
        }

        public string AppartmentHousingNumber
        {
            get { return strAppartmentHousingNumber; }
            set { strAppartmentHousingNumber = value; }
        }

        public DateTime AppartmentDateConstructed
        {
            get { return dtAppartmentDateConstructed; }
            set { dtAppartmentDateConstructed = value; }
        }

        public double AppartmentSize
        {
            get { return dAppartmentSize; }
            set { dAppartmentSize = value; }
        }

        public double AppartmentVolume
        {
            get { return dAppartmentVolume; }
            set { dAppartmentVolume = value; }
        }

        public long AppartmentNoOfExitDoors
        {
            get { return lAppartmentNoOfExitDoors; }
            set { lAppartmentNoOfExitDoors = value; }
        }

        public string AppartmentPicture
        {
            get { return strAppartmentPicture; }
            set { strAppartmentPicture = value; }
        }

        public long AppartmentNoOfWindows
        {
            get { return lAppartmentNoOfWindows; }
            set { lAppartmentNoOfWindows = value; }
        }

        public long NoOfWashrooms
        {
            get { return lNoOfWashrooms; }
            set { lNoOfWashrooms = value; }
        }

        public long NoOfBalconies
        {
            get { return lNoOfBalconies; }
            set { lNoOfBalconies = value; }
        }

        public long NoOfFloors
        {
            get { return lNoOfFloors; }
            set { lNoOfFloors = value; }
        }

        public long OnFloorNo
        {
            get { return lOnFloorNo; }
            set { lOnFloorNo = value; }
        }

        public DataSet AppartmentMasterDataset
        {
            get { return datAppartmentMasterDataset; }
            set { datAppartmentMasterDataset = value; }
        }

        public DateTime DateCreated
        {
            get { return dtDateCreated; }
            set { dtDateCreated = value; }
        }

        public DateTime DateRegistered
        {
            get { return dtDateRegistered; }
            set { dtDateRegistered = value; }
        }

        public DateTime DateDeRegistered
        {
            get { return dtDateDeregistered; }
            set { dtDateDeregistered = value; }
        }


        #endregion


        #region "DatabaseFunctions"

        public bool ReturnAllAppartmentMasterByAppartmentIDAndBuildingID(long lLimit,
            long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getappartmentmasterbyappartmentidandbuildingid(" + lBuildingID + ",0," + lLimit +
                    "," + lOffset + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesAppartment in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesAppartment.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                datAppartmentMasterDataset = objLogin.PGDataSet;
                            }
                        }

                    }
                    else
                    {
                        return false;

                    }

                    return true;
                }

            }

            catch (Exception ex)
            {
                return false;
            }

            finally
            {
                datRetData = null;

                objLogin = null;

            }
        }

        public bool ReturnAppartmentMasterByAppartmentIDAndBuildingID(long lLimit,
            long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getappartmentmasterbyappartmentidandbuildingid(" + lBuildingID + "," + lAppartmentID + "," + lLimit +
                    "," + lOffset + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesAppartment in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesAppartment.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsAppartment in myDataTablesAppartment.Rows)
                                {
                                    if (myDataRowsAppartment["BUILDINGID"] != DBNull.Value)
                                    {
                                        lBuildingID = Convert.ToInt64(myDataRowsAppartment["BUILDINGID"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTID"] != DBNull.Value)
                                    {
                                        lAppartmentID = Convert.ToInt64(myDataRowsAppartment["APPARTMENTID"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTNUMBER"] != DBNull.Value)
                                    {
                                        strAppartmentNumber = myDataRowsAppartment["APPARTMENTNUMBER"].ToString();
                                    }

                                    if (myDataRowsAppartment["APPARTMENTTYPEID"] != DBNull.Value)
                                    {
                                        lAppartmentTypeID = Convert.ToInt64(myDataRowsAppartment["APPARTMENTTYPEID"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTDATECONSTRUCTED"] != DBNull.Value)
                                    {
                                        dtAppartmentDateConstructed = 
                                            Convert.ToDateTime(Convert.ToDateTime(myDataRowsAppartment["APPARTMENTDATECONSTRUCTED"]));
                                    }

                                    if (myDataRowsAppartment["APPARTMENTSIZE"] != DBNull.Value)
                                    {
                                        dAppartmentSize = Convert.ToDouble(myDataRowsAppartment["APPARTMENTSIZE"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTNOOFEXITDOORS"] != DBNull.Value)
                                    {
                                        lAppartmentNoOfExitDoors = Convert.ToInt64(myDataRowsAppartment["APPARTMENTNOOFEXITDOORS"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTVOLUME"] != DBNull.Value)
                                    {
                                        dAppartmentVolume = Convert.ToDouble(myDataRowsAppartment["APPARTMENTVOLUME"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTNOOFWINDOWS"] != DBNull.Value)
                                    {
                                        lAppartmentNoOfWindows = Convert.ToInt64(myDataRowsAppartment["APPARTMENTNOOFWINDOWS"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTHOUSINGNUMBER"] != DBNull.Value)
                                    {
                                        strAppartmentHousingNumber = myDataRowsAppartment["APPARTMENTHOUSINGNUMBER"].ToString();
                                    }

                                    if (myDataRowsAppartment["APPARTMENTDESCRIPTION"] != DBNull.Value)
                                    {
                                        strAppartmentDescription = myDataRowsAppartment["APPARTMENTDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsAppartment["NOOFWASHROOMS"] != DBNull.Value)
                                    {
                                        lNoOfWashrooms = Convert.ToInt64(myDataRowsAppartment["NOOFWASHROOMS"]);
                                    }

                                    if (myDataRowsAppartment["NOOFBALCONIES"] != DBNull.Value)
                                    {
                                        lNoOfBalconies = Convert.ToInt64(myDataRowsAppartment["NOOFBALCONIES"]);
                                    }

                                    if (myDataRowsAppartment["NOOFFLOORS"] != DBNull.Value)
                                    {
                                        lNoOfFloors = Convert.ToInt64(myDataRowsAppartment["NOOFFLOORS"]);
                                    }

                                    if (myDataRowsAppartment["ONFLOORNO"] != DBNull.Value)
                                    {
                                        lOnFloorNo = Convert.ToInt64(myDataRowsAppartment["ONFLOORNO"]);
                                    }

                                    if (myDataRowsAppartment["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsAppartment["DATECREATED"]);
                                    }

                                    if (myDataRowsAppartment["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsAppartment["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsAppartment["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeregistered = Convert.ToDateTime(myDataRowsAppartment["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsAppartment["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsAppartment["USERID"]);

                                    //}
                                }


                            }
                        }

                    }
                    else
                    {
                        return false;

                    }

                    return true;
                }

            }

            catch (Exception ex)
            {
                return false;
            }

            finally
            {
                datRetData = null;

                objLogin = null;

            }
        }

        public bool ReturnAllAppartmentIDAndAppartmentNameByBuildingID(long lLimit,
            long lOffset)
        {

            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getappartmentidnumberbldidbybuildingid(" + lBuildingID + ",0," + lLimit +
                    "," + lOffset + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesAppartment in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesAppartment.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                datAppartmentMasterDataset = objLogin.PGDataSet;

                            }
                        }

                    }
                    else
                    {
                        return false;

                    }

                    return true;
                }

            }

            catch (Exception ex)
            {
                return false;
            }

            finally
            {
                datRetData = null;
                objLogin = null;

            }
        }

        public bool ReturnAppartmentIDAndAppartmentNameByBuildingID(long lLimit,
            long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getappartmentidnumberbldidbybuildingid(" + lBuildingID + "," + lAppartmentID + "," + lLimit +
                    "," + lOffset + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesAppartment in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesAppartment.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {



                                foreach (DataRow myDataRowsAppartment in myDataTablesAppartment.Rows)
                                {
                                    if (myDataRowsAppartment["BUILDINGID"] != DBNull.Value)
                                    {
                                        lBuildingID = Convert.ToInt64(myDataRowsAppartment["BUILDINGID"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTID"] != DBNull.Value)
                                    {
                                        lAppartmentID = Convert.ToInt64(myDataRowsAppartment["APPARTMENTID"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTNUMBER"] != DBNull.Value)
                                    {
                                        strAppartmentNumber = myDataRowsAppartment["APPARTMENTNUMBER"].ToString();
                                    }

                                    if (myDataRowsAppartment["APPARTMENTTYPEID"] != DBNull.Value)
                                    {
                                        lAppartmentTypeID = Convert.ToInt64(myDataRowsAppartment["APPARTMENTTYPEID"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTDATECONSTRUCTED"] != DBNull.Value)
                                    {
                                        dtAppartmentDateConstructed = 
                                            Convert.ToDateTime(Convert.ToDateTime(myDataRowsAppartment["APPARTMENTDATECONSTRUCTED"]));
                                    }

                                    if (myDataRowsAppartment["APPARTMENTSIZE"] != DBNull.Value)
                                    {
                                        dAppartmentSize = Convert.ToDouble(myDataRowsAppartment["APPARTMENTSIZE"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTNOOFEXITDOORS"] != DBNull.Value)
                                    {
                                        lAppartmentNoOfExitDoors = Convert.ToInt64(myDataRowsAppartment["APPARTMENTNOOFEXITDOORS"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTVOLUME"] != DBNull.Value)
                                    {
                                        dAppartmentVolume = Convert.ToDouble(myDataRowsAppartment["APPARTMENTVOLUME"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTNOOFWINDOWS"] != DBNull.Value)
                                    {
                                        lAppartmentNoOfWindows = Convert.ToInt64(myDataRowsAppartment["APPARTMENTNOOFWINDOWS"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTHOUSINGNUMBER"] != DBNull.Value)
                                    {
                                        strAppartmentHousingNumber = myDataRowsAppartment["APPARTMENTHOUSINGNUMBER"].ToString();
                                    }

                                    if (myDataRowsAppartment["APPARTMENTDESCRIPTION"] != DBNull.Value)
                                    {
                                        strAppartmentDescription = myDataRowsAppartment["APPARTMENTDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsAppartment["NOOFWASHROOMS"] != DBNull.Value)
                                    {
                                        lNoOfWashrooms = Convert.ToInt64(myDataRowsAppartment["NOOFWASHROOMS"]);
                                    }

                                    if (myDataRowsAppartment["NOOFBALCONIES"] != DBNull.Value)
                                    {
                                        lNoOfBalconies = Convert.ToInt64(myDataRowsAppartment["NOOFBALCONIES"]);
                                    }

                                    if (myDataRowsAppartment["NOOFFLOORS"] != DBNull.Value)
                                    {
                                        lNoOfFloors = Convert.ToInt64(myDataRowsAppartment["NOOFFLOORS"]);
                                    }

                                    if (myDataRowsAppartment["ONFLOORNO"] != DBNull.Value)
                                    {
                                        lOnFloorNo = Convert.ToInt64(myDataRowsAppartment["ONFLOORNO"]);
                                    }

                                    if (myDataRowsAppartment["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsAppartment["DATECREATED"]);
                                    }

                                    if (myDataRowsAppartment["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsAppartment["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsAppartment["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeregistered = Convert.ToDateTime(myDataRowsAppartment["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsAppartment["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsAppartment["USERID"]);

                                    //}

                                }

                            }
                        }

                    }
                    else
                    {
                        return false;

                    }

                    return true;
                }

            }

            catch (Exception ex)
            {
                return false;
            }

            finally
            {

                datRetData = null;
                objLogin = null;

            }
        }

        public bool ReturnFirstAppartmentMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getfirstappartmentmaster(" + lBuildingID + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesAppartment in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesAppartment.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsAppartment in myDataTablesAppartment.Rows)
                                {
                                    if (myDataRowsAppartment["BUILDINGID"] != DBNull.Value)
                                    {
                                        lBuildingID = Convert.ToInt64(myDataRowsAppartment["BUILDINGID"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTID"] != DBNull.Value)
                                    {
                                        lAppartmentID = Convert.ToInt64(myDataRowsAppartment["APPARTMENTID"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTNUMBER"] != DBNull.Value)
                                    {
                                        strAppartmentNumber = myDataRowsAppartment["APPARTMENTNUMBER"].ToString();
                                    }

                                    if (myDataRowsAppartment["APPARTMENTTYPEID"] != DBNull.Value)
                                    {
                                        lAppartmentTypeID = Convert.ToInt64(myDataRowsAppartment["APPARTMENTTYPEID"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTDATECONSTRUCTED"] != DBNull.Value)
                                    {
                                        dtAppartmentDateConstructed = Convert.ToDateTime(myDataRowsAppartment["APPARTMENTDATECONSTRUCTED"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTSIZE"] != DBNull.Value)
                                    {
                                        dAppartmentSize = Convert.ToDouble(myDataRowsAppartment["APPARTMENTSIZE"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTNOOFEXITDOORS"] != DBNull.Value)
                                    {
                                        lAppartmentNoOfExitDoors = Convert.ToInt64(myDataRowsAppartment["APPARTMENTNOOFEXITDOORS"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTVOLUME"] != DBNull.Value)
                                    {
                                        dAppartmentVolume = Convert.ToDouble(myDataRowsAppartment["APPARTMENTVOLUME"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTNOOFWINDOWS"] != DBNull.Value)
                                    {
                                        lAppartmentNoOfWindows = Convert.ToInt64(myDataRowsAppartment["APPARTMENTNOOFWINDOWS"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTHOUSINGNUMBER"] != DBNull.Value)
                                    {
                                        strAppartmentHousingNumber = myDataRowsAppartment["APPARTMENTHOUSINGNUMBER"].ToString();
                                    }

                                    if (myDataRowsAppartment["APPARTMENTDESCRIPTION"] != DBNull.Value)
                                    {
                                        strAppartmentDescription = myDataRowsAppartment["APPARTMENTDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsAppartment["NOOFWASHROOMS"] != DBNull.Value)
                                    {
                                        lNoOfWashrooms = Convert.ToInt64(myDataRowsAppartment["NOOFWASHROOMS"]);
                                    }

                                    if (myDataRowsAppartment["NOOFBALCONIES"] != DBNull.Value)
                                    {
                                        lNoOfBalconies = Convert.ToInt64(myDataRowsAppartment["NOOFBALCONIES"]);
                                    }

                                    if (myDataRowsAppartment["NOOFFLOORS"] != DBNull.Value)
                                    {
                                        lNoOfFloors = Convert.ToInt64(myDataRowsAppartment["NOOFFLOORS"]);
                                    }

                                    if (myDataRowsAppartment["ONFLOORNO"] != DBNull.Value)
                                    {
                                        lOnFloorNo = Convert.ToInt64(myDataRowsAppartment["ONFLOORNO"]);
                                    }

                                    if (myDataRowsAppartment["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsAppartment["DATECREATED"]);
                                    }

                                    if (myDataRowsAppartment["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsAppartment["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsAppartment["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeregistered = Convert.ToDateTime(myDataRowsAppartment["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsAppartment["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsAppartment["USERID"]);

                                    //}
                                }


                            }
                        }

                    }
                    else
                    {
                        return false;

                    }

                    return true;
                }

            }

            catch (Exception ex)
            {
                return false;
            }

            finally
            {
                datRetData = null;
                objLogin = null;

            }
        }

        public bool ReturnNextAppartmentMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getnextappartmentmaster(" + lBuildingID + "," + lAppartmentID + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesAppartment in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesAppartment.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsAppartment in myDataTablesAppartment.Rows)
                                {
                                    if (myDataRowsAppartment["BUILDINGID"] != DBNull.Value)
                                    {
                                        lBuildingID = Convert.ToInt64(myDataRowsAppartment["BUILDINGID"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTID"] != DBNull.Value)
                                    {
                                        lAppartmentID = Convert.ToInt64(myDataRowsAppartment["APPARTMENTID"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTNUMBER"] != DBNull.Value)
                                    {
                                        strAppartmentNumber = myDataRowsAppartment["APPARTMENTNUMBER"].ToString();
                                    }

                                    if (myDataRowsAppartment["APPARTMENTTYPEID"] != DBNull.Value)
                                    {
                                        lAppartmentTypeID = Convert.ToInt64(myDataRowsAppartment["APPARTMENTTYPEID"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTDATECONSTRUCTED"] != DBNull.Value)
                                    {
                                        dtAppartmentDateConstructed = Convert.ToDateTime(myDataRowsAppartment["APPARTMENTDATECONSTRUCTED"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTSIZE"] != DBNull.Value)
                                    {
                                        dAppartmentSize = Convert.ToDouble(myDataRowsAppartment["APPARTMENTSIZE"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTNOOFEXITDOORS"] != DBNull.Value)
                                    {
                                        lAppartmentNoOfExitDoors = Convert.ToInt64(myDataRowsAppartment["APPARTMENTNOOFEXITDOORS"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTVOLUME"] != DBNull.Value)
                                    {
                                        dAppartmentVolume = Convert.ToDouble(myDataRowsAppartment["APPARTMENTVOLUME"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTNOOFWINDOWS"] != DBNull.Value)
                                    {
                                        lAppartmentNoOfWindows = Convert.ToInt64(myDataRowsAppartment["APPARTMENTNOOFWINDOWS"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTHOUSINGNUMBER"] != DBNull.Value)
                                    {
                                        strAppartmentHousingNumber = myDataRowsAppartment["APPARTMENTHOUSINGNUMBER"].ToString();
                                    }

                                    if (myDataRowsAppartment["APPARTMENTDESCRIPTION"] != DBNull.Value)
                                    {
                                        strAppartmentDescription = myDataRowsAppartment["APPARTMENTDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsAppartment["NOOFWASHROOMS"] != DBNull.Value)
                                    {
                                        lNoOfWashrooms = Convert.ToInt64(myDataRowsAppartment["NOOFWASHROOMS"]);
                                    }

                                    if (myDataRowsAppartment["NOOFBALCONIES"] != DBNull.Value)
                                    {
                                        lNoOfBalconies = Convert.ToInt64(myDataRowsAppartment["NOOFBALCONIES"]);
                                    }

                                    if (myDataRowsAppartment["NOOFFLOORS"] != DBNull.Value)
                                    {
                                        lNoOfFloors = Convert.ToInt64(myDataRowsAppartment["NOOFFLOORS"]);
                                    }

                                    if (myDataRowsAppartment["ONFLOORNO"] != DBNull.Value)
                                    {
                                        lOnFloorNo = Convert.ToInt64(myDataRowsAppartment["ONFLOORNO"]);
                                    }

                                    if (myDataRowsAppartment["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsAppartment["DATECREATED"]);
                                    }

                                    if (myDataRowsAppartment["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsAppartment["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsAppartment["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeregistered = Convert.ToDateTime(myDataRowsAppartment["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsAppartment["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsAppartment["USERID"]);

                                    //}
                                }


                            }
                        }

                    }
                    else
                    {
                        return false;

                    }

                    return true;
                }

            }

            catch (Exception ex)
            {
                return false;
            }

            finally
            {
                datRetData = null;
                objLogin = null;

            }
        }

        public bool ReturnPreviousAppartmentMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getprevappartmentmaster(" + lBuildingID + "," + lAppartmentID + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesAppartment in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesAppartment.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsAppartment in myDataTablesAppartment.Rows)
                                {
                                    if (myDataRowsAppartment["BUILDINGID"] != DBNull.Value)
                                    {
                                        lBuildingID = Convert.ToInt64(myDataRowsAppartment["BUILDINGID"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTID"] != DBNull.Value)
                                    {
                                        lAppartmentID = Convert.ToInt64(myDataRowsAppartment["APPARTMENTID"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTNUMBER"] != DBNull.Value)
                                    {
                                        strAppartmentNumber = myDataRowsAppartment["APPARTMENTNUMBER"].ToString();
                                    }

                                    if (myDataRowsAppartment["APPARTMENTTYPEID"] != DBNull.Value)
                                    {
                                        lAppartmentTypeID = Convert.ToInt64(myDataRowsAppartment["APPARTMENTTYPEID"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTDATECONSTRUCTED"] != DBNull.Value)
                                    {
                                        dtAppartmentDateConstructed = Convert.ToDateTime(myDataRowsAppartment["APPARTMENTDATECONSTRUCTED"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTSIZE"] != DBNull.Value)
                                    {
                                        dAppartmentSize = Convert.ToDouble(myDataRowsAppartment["APPARTMENTSIZE"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTNOOFEXITDOORS"] != DBNull.Value)
                                    {
                                        lAppartmentNoOfExitDoors = Convert.ToInt64(myDataRowsAppartment["APPARTMENTNOOFEXITDOORS"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTVOLUME"] != DBNull.Value)
                                    {
                                        dAppartmentVolume = Convert.ToDouble(myDataRowsAppartment["APPARTMENTVOLUME"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTNOOFWINDOWS"] != DBNull.Value)
                                    {
                                        lAppartmentNoOfWindows = Convert.ToInt64(myDataRowsAppartment["APPARTMENTNOOFWINDOWS"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTHOUSINGNUMBER"] != DBNull.Value)
                                    {
                                        strAppartmentHousingNumber = myDataRowsAppartment["APPARTMENTHOUSINGNUMBER"].ToString();
                                    }

                                    if (myDataRowsAppartment["APPARTMENTDESCRIPTION"] != DBNull.Value)
                                    {
                                        strAppartmentDescription = myDataRowsAppartment["APPARTMENTDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsAppartment["NOOFWASHROOMS"] != DBNull.Value)
                                    {
                                        lNoOfWashrooms = Convert.ToInt64(myDataRowsAppartment["NOOFWASHROOMS"]);
                                    }

                                    if (myDataRowsAppartment["NOOFBALCONIES"] != DBNull.Value)
                                    {
                                        lNoOfBalconies = Convert.ToInt64(myDataRowsAppartment["NOOFBALCONIES"]);
                                    }

                                    if (myDataRowsAppartment["NOOFFLOORS"] != DBNull.Value)
                                    {
                                        lNoOfFloors = Convert.ToInt64(myDataRowsAppartment["NOOFFLOORS"]);
                                    }

                                    if (myDataRowsAppartment["ONFLOORNO"] != DBNull.Value)
                                    {
                                        lOnFloorNo = Convert.ToInt64(myDataRowsAppartment["ONFLOORNO"]);
                                    }

                                    if (myDataRowsAppartment["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsAppartment["DATECREATED"]);
                                    }

                                    if (myDataRowsAppartment["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsAppartment["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsAppartment["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeregistered = Convert.ToDateTime(myDataRowsAppartment["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsAppartment["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsAppartment["USERID"]);

                                    //}
                                }


                            }
                        }

                    }
                    else
                    {
                        return false;

                    }

                    return true;
                }

            }

            catch (Exception ex)
            {
                return false;
            }

            finally
            {
                datRetData = null;
                objLogin = null;

            }
        }

        public bool ReturnLastAppartmentMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getlastappartmentmaster(" + lBuildingID + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesAppartment in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesAppartment.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsAppartment in myDataTablesAppartment.Rows)
                                {
                                    if (myDataRowsAppartment["BUILDINGID"] != DBNull.Value)
                                    {
                                        lBuildingID = Convert.ToInt64(myDataRowsAppartment["BUILDINGID"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTID"] != DBNull.Value)
                                    {
                                        lAppartmentID = Convert.ToInt64(myDataRowsAppartment["APPARTMENTID"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTNUMBER"] != DBNull.Value)
                                    {
                                        strAppartmentNumber = myDataRowsAppartment["APPARTMENTNUMBER"].ToString();
                                    }

                                    if (myDataRowsAppartment["APPARTMENTTYPEID"] != DBNull.Value)
                                    {
                                        lAppartmentTypeID = Convert.ToInt64(myDataRowsAppartment["APPARTMENTTYPEID"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTDATECONSTRUCTED"] != DBNull.Value)
                                    {
                                        dtAppartmentDateConstructed = Convert.ToDateTime(myDataRowsAppartment["APPARTMENTDATECONSTRUCTED"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTSIZE"] != DBNull.Value)
                                    {
                                        dAppartmentSize = Convert.ToDouble(myDataRowsAppartment["APPARTMENTSIZE"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTNOOFEXITDOORS"] != DBNull.Value)
                                    {
                                        lAppartmentNoOfExitDoors = Convert.ToInt64(myDataRowsAppartment["APPARTMENTNOOFEXITDOORS"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTVOLUME"] != DBNull.Value)
                                    {
                                        dAppartmentVolume = Convert.ToDouble(myDataRowsAppartment["APPARTMENTVOLUME"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTNOOFWINDOWS"] != DBNull.Value)
                                    {
                                        lAppartmentNoOfWindows = Convert.ToInt64(myDataRowsAppartment["APPARTMENTNOOFWINDOWS"]);
                                    }

                                    if (myDataRowsAppartment["APPARTMENTHOUSINGNUMBER"] != DBNull.Value)
                                    {
                                        strAppartmentHousingNumber = myDataRowsAppartment["APPARTMENTHOUSINGNUMBER"].ToString();
                                    }

                                    if (myDataRowsAppartment["APPARTMENTDESCRIPTION"] != DBNull.Value)
                                    {
                                        strAppartmentDescription = myDataRowsAppartment["APPARTMENTDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsAppartment["NOOFWASHROOMS"] != DBNull.Value)
                                    {
                                        lNoOfWashrooms = Convert.ToInt64(myDataRowsAppartment["NOOFWASHROOMS"]);
                                    }

                                    if (myDataRowsAppartment["NOOFBALCONIES"] != DBNull.Value)
                                    {
                                        lNoOfBalconies = Convert.ToInt64(myDataRowsAppartment["NOOFBALCONIES"]);
                                    }

                                    if (myDataRowsAppartment["NOOFFLOORS"] != DBNull.Value)
                                    {
                                        lNoOfFloors = Convert.ToInt64(myDataRowsAppartment["NOOFFLOORS"]);
                                    }

                                    if (myDataRowsAppartment["ONFLOORNO"] != DBNull.Value)
                                    {
                                        lOnFloorNo = Convert.ToInt64(myDataRowsAppartment["ONFLOORNO"]);
                                    }

                                    if (myDataRowsAppartment["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsAppartment["DATECREATED"]);
                                    }

                                    if (myDataRowsAppartment["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsAppartment["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsAppartment["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeregistered = Convert.ToDateTime(myDataRowsAppartment["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsAppartment["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsAppartment["USERID"]);

                                    //}
                                }


                            }
                        }

                    }
                    else
                    {
                        return false;

                    }

                    return true;
                }

            }

            catch (Exception ex)
            {
                return false;
            }

            finally
            {
                datRetData = null;
                objLogin = null;

            }
        }


        #endregion


    }
}
