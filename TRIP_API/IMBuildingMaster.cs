using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

namespace TRIP_API
{
    public class IMBuildingMaster
    {

        
        #region  "PrivateVariables"

        private long lBuildingID = 0;
        private long lAddressID = 0;
        private long lMapID = 0;
        private string strBuildingName = "";
        private string strPhysicalAddress = "";
        private long lStreet1 = 0;
        private long lStreet2 = 0;
        private long lStreet3 = 0;
        private long lStreet4 = 0;
        private string strCurrentHouseNumber = "";
        private long lBuildingTypeID = 0;
        private string strBuildingHousingNumber = "";
        private string strBuildingDescription = "";
        private long lNoOfFloors = 0;
        private long lRentTypeID = 0;
        private string strBuildingSNO = "";
        private string strBuildingColour = "";
        private string strBuildingRegistrationNumber = "";

        private long lBuildingUsageID = 0;
        private long lRatingClassID = 0;
        private string strRatingClassMainDescription = "";
        private string strParcelNo = "";
        private string strAssembly = "";
        private string strValuationNo = "";
        private MemoryStream msBuildingPhoto;
        private Byte bytBuildingPhoto;
        private Guid gdBuildingGuid;
        private DataSet datBuildingMaster;

        private DateTime dtDateCreated;
        private DateTime dtDateRegistered;
        private DateTime dtDateDeRegistered;
        private DateTime dtDateConstructed;

        private string errMessage;



#endregion

        #region  "Properties"


    public long BuildingID
    {

        //USED TO SET AND RETRIEVE THE OrganizationCustomer Dataset (DATASET)
        get { return lBuildingID; }

        set { lBuildingID = value; }
    }

    public long AddressID
    {

        //USED TO SET AND RETRIEVE THE OrganizationCustomer Dataset (DATASET)
        get { return lAddressID; }

        set { lAddressID = value; }
    }

    public long MapID
    {

        //USED TO SET AND RETRIEVE THE OrganizationCustomer Dataset (DATASET)
        get { return lMapID; }

        set { lMapID = value; }
    }

    public long RatingClass
    {

        //USED TO SET AND RETRIEVE THE OrganizationCustomer Dataset (DATASET)
        get { return lRatingClassID; }

        set { lRatingClassID = value; }
    }

    public string RatingClassMainDescription
    {

        //USED TO SET AND RETRIEVE THE OrganizationCustomer Dataset (DATASET)
        get { return strRatingClassMainDescription; }

        set { strRatingClassMainDescription = value; }
    }

    public string ParcelNo
    {

        //USED TO SET AND RETRIEVE THE OrganizationCustomer Dataset (DATASET)
        get { return strParcelNo; }

        set { strParcelNo = value; }
    }

    public string Assembly
    {

        //USED TO SET AND RETRIEVE THE OrganizationCustomer Dataset (DATASET)
        get { return strAssembly; }

        set { strAssembly = value; }
    }

    public string ValuationNo
    {

        //USED TO SET AND RETRIEVE THE OrganizationCustomer Dataset (DATASET)
        get { return strValuationNo; }

        set { strValuationNo = value; }
    }

    public long BuildingUsage
    {

        //USED TO SET AND RETRIEVE THE OrganizationCustomer Dataset (DATASET)
        get { return lBuildingUsageID; }

        set { lBuildingUsageID = value; }
    }

    public string BuildingSNo
    {

        //USED TO SET AND RETRIEVE THE OrganizationCustomer Dataset (DATASET)
        get { return strBuildingSNO; }

        set { strBuildingSNO = value; }
    }

    public string BuildingName
    {

        //USED TO SET AND RETRIEVE THE OrganizationCustomer Dataset (DATASET)
        get { return strBuildingName; }

        set { strBuildingName = value; }
    }

    public string PhysicalAddress
    {

        //USED TO SET AND RETRIEVE THE OrganizationCustomer Dataset (DATASET)
        get { return strPhysicalAddress; }

        set { strPhysicalAddress = value; }
    }

    public long Street1
    {

        //USED TO SET AND RETRIEVE THE OrganizationCustomer Dataset (DATASET)
        get { return lStreet1; }

        set { lStreet1 = value; }
    }

    public long Street2
    {

        //USED TO SET AND RETRIEVE THE OrganizationCustomer Dataset (DATASET)
        get { return lStreet2; }

        set { lStreet2 = value; }
    }

    public long Street3
    {

        //USED TO SET AND RETRIEVE THE OrganizationCustomer Dataset (DATASET)
        get { return lStreet3; }

        set { lStreet3 = value; }
    }

    public long Street4
    {

        //USED TO SET AND RETRIEVE THE OrganizationCustomer Dataset (DATASET)
        get { return lStreet4; }

        set { lStreet4 = value; }
    }

    public string BuildingColour
    {

        //USED TO SET AND RETRIEVE THE OrganizationCustomer Dataset (DATASET)
        get { return strBuildingColour; }

        set { strBuildingColour = value; }
    }

    public string BuildingHousingNumber
    {

        //USED TO SET AND RETRIEVE THE OrganizationCustomer Dataset (DATASET)
        get { return strBuildingHousingNumber; }

        set { strBuildingHousingNumber = value; }
    }

    public string CurrentHouseNumber
    {

        //USED TO SET AND RETRIEVE THE OrganizationCustomer Dataset (DATASET)
        get { return strCurrentHouseNumber; }

        set { strCurrentHouseNumber = value; }
    }

    public long BuildingTypeID
    {

        //USED TO SET AND RETRIEVE THE OrganizationCustomer Dataset (DATASET)
        get { return lBuildingTypeID; }

        set { lBuildingTypeID = value; }
    }

    public string BuildingDescription
    {

        //USED TO SET AND RETRIEVE THE OrganizationCustomer Dataset (DATASET)
        get { return strBuildingDescription; }

        set { strBuildingDescription = value; }
    }

    public long NoOfFloors
    {

        //USED TO SET AND RETRIEVE THE OrganizationCustomer Dataset (DATASET)
        get { return lNoOfFloors; }

        set { lNoOfFloors = value; }
    }

    public long RentTypeID
    {

        //USED TO SET AND RETRIEVE THE OrganizationCustomer Dataset (DATASET)
        get { return lRentTypeID; }

        set { lRentTypeID = value; }
    }

    public string BuildingRegistrationNumber
    {

        //USED TO SET AND RETRIEVE THE OrganizationCustomer Dataset (DATASET)
        get { return strBuildingRegistrationNumber; }

        set { strBuildingRegistrationNumber = value; }
    }

    public MemoryStream BuildingPhoto
    {

        //USED TO SET AND RETRIEVE THE OrganizationCustomer Dataset (DATASET)
        get { return msBuildingPhoto; }

        set { msBuildingPhoto = value; }
    }

    public Byte BuildingPhotoByte
    {

        //USED TO SET AND RETRIEVE THE OrganizationCustomer Dataset (DATASET)
        get { return bytBuildingPhoto; }

        set { bytBuildingPhoto = value; }
    }

    public Guid BuildingUID
    {
        get { return gdBuildingGuid; }

        set { gdBuildingGuid = value; }
    }

    public DataSet BuildingMasterDataset
    {
        get { return datBuildingMaster; }

        set { datBuildingMaster = value; }
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
        get { return dtDateDeRegistered; }

        set { dtDateDeRegistered = value; }
    }

    public DateTime DateConstructed
    {
        get { return dtDateConstructed; }

        set { dtDateConstructed = value; }
    }


#endregion 

        #region "DatabaseFunctions"


    //0 is provided as the building id returning all buildings
    public bool ReturnAllBuildingMasterByBuildingID(long lLimit, long lOffset)
    {
        DataSet datRetData = new DataSet();
        bool bQuerySuccess = false;
        IMLogin objLogin = new IMLogin();
        string strQuery = null;

        try
        {
            strQuery = "SELECT * FROM trip_func_getbuildingmasterbybuildingid(0" + lLimit +
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

                    foreach (DataTable myDataTablesBuilding in objLogin.PGDataSet.Tables)
                    {

                        //Check if there is any data. If not exit
                        if (myDataTablesBuilding.Rows.Count == 0)
                        {

                            //Return a value indicating that the search was not successful
                            return false;

                        }
                        else
                        {

                            datBuildingMaster = objLogin.PGDataSet;
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
            errMessage = ex.Message;
            return false;
        }

        finally
        {
            datRetData = null;

            objLogin = null;

        }
    }

    public bool ReturnBuildingMasterByBuildingID(long lLimit, long lOffset)
    {
        DataSet datRetData = new DataSet();
        bool bQuerySuccess = false;
        IMLogin objLogin = new IMLogin();
        string strQuery = null;

        try
        {
            strQuery = "SELECT * FROM trip_func_getbuildingmasterbybuildingid(" + lBuildingID + "," + lLimit +
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

                    foreach (DataTable myDataTablesBuilding in objLogin.PGDataSet.Tables)
                    {

                        //Check if there is any data. If not exit
                        if (myDataTablesBuilding.Rows.Count == 0)
                        {

                            //Return a value indicating that the search was not successful
                            return false;

                        }
                        else
                        {

                            foreach (DataRow myDataRowsBuilding in myDataTablesBuilding.Rows)
                            {
                                if (myDataRowsBuilding["BUILDINGID"] != DBNull.Value)
                                {
                                    lBuildingID = Convert.ToInt64(myDataRowsBuilding["BUILDINGID"]);
                                }

                                if (myDataRowsBuilding["MAPID"] != DBNull.Value)
                                {
                                    lMapID = Convert.ToInt64(myDataRowsBuilding["MAPID"]);
                                }

                                if (myDataRowsBuilding["BUILDINGNAME"] != DBNull.Value)
                                {
                                    strBuildingName = myDataRowsBuilding["BUILDINGNAME"].ToString();
                                }

                                if (myDataRowsBuilding["BUILDINGDESCRIPTION"] != DBNull.Value)
                                {
                                    strBuildingDescription = myDataRowsBuilding["BUILDINGDESCRIPTION"].ToString();
                                }

                                if (myDataRowsBuilding["CURRENTHOUSENUMBER"] != DBNull.Value)
                                {
                                    strCurrentHouseNumber = myDataRowsBuilding["CURRENTHOUSENUMBER"].ToString();
                                }

                                if (myDataRowsBuilding["PHYSICALADDRESS"] != DBNull.Value)
                                {
                                    strPhysicalAddress = myDataRowsBuilding["PHYSICALADDRESS"].ToString();
                                }

                                if (myDataRowsBuilding["BUILDINGSNO"] != DBNull.Value)
                                {
                                    strBuildingSNO = myDataRowsBuilding["BUILDINGSNO"].ToString();
                                }

                                if (myDataRowsBuilding["STREET1"] != DBNull.Value)
                                {
                                    lStreet1 = Convert.ToInt64(myDataRowsBuilding["STREET1"]);
                                }

                                if (myDataRowsBuilding["STREET2"] != DBNull.Value)
                                {
                                    lStreet2 = Convert.ToInt64(myDataRowsBuilding["STREET2"]);
                                }

                                if (myDataRowsBuilding["STREET3"] != DBNull.Value)
                                {
                                    lStreet3 = Convert.ToInt64(myDataRowsBuilding["STREET3"]);
                                }

                                if (myDataRowsBuilding["STREET4"] != DBNull.Value)
                                {
                                    lStreet4 = Convert.ToInt64(myDataRowsBuilding["STREET4"]);
                                }

                                if (myDataRowsBuilding["BUILDINGTYPEID"] != DBNull.Value)
                                {
                                    lBuildingTypeID = Convert.ToInt64(myDataRowsBuilding["BUILDINGTYPEID"]);
                                }

                                if (myDataRowsBuilding["USAGEID"] != DBNull.Value)
                                {
                                    lBuildingUsageID = Convert.ToInt64(myDataRowsBuilding["USAGEID"]);
                                }


                                if (myDataRowsBuilding["NOOFFLOORS"] != DBNull.Value)
                                {
                                    lNoOfFloors = Convert.ToInt64(myDataRowsBuilding["NOOFFLOORS"]);
                                }

                                if (myDataRowsBuilding["BLDCOLOR"] != DBNull.Value)
                                {
                                    strBuildingColour = myDataRowsBuilding["BLDCOLOR"].ToString();
                                }

                                if (myDataRowsBuilding["DATECREATED"] != DBNull.Value)
                                {
                                    dtDateCreated = Convert.ToDateTime(myDataRowsBuilding["DATECREATED"]);
                                }

                                if (myDataRowsBuilding["DATEREGISTERED"] != DBNull.Value)
                                {
                                    dtDateRegistered = Convert.ToDateTime(myDataRowsBuilding["DATEREGISTERED"]);
                                }

                                if (myDataRowsBuilding["DATEDEREGISTERED"] != DBNull.Value)
                                {
                                    dtDateDeRegistered = Convert.ToDateTime(myDataRowsBuilding["DATEDEREGISTERED"]);
                                }

                                if (myDataRowsBuilding["DATECONSTRUCTED"] != DBNull.Value)
                                {
                                    dtDateConstructed = Convert.ToDateTime(myDataRowsBuilding["DATECONSTRUCTED"]);
                                }

                                //if (myDataRowsBuilding["USERID"] != DBNull.Value)
                                //{

                                //UserID = Convert.ToInt64(myDataRowsBuilding["USERID"]);

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

    public bool ReturnBuildingMasterByMapID(long lLimit,long lOffset)
    {
        DataSet datRetData = new DataSet();
        bool bQuerySuccess = false;
        IMLogin objLogin = new IMLogin();
        string strQuery = null;

        try
        {
            strQuery = "SELECT * FROM trip_func_getbuildingmasterbymapid(" + lMapID + "," + lLimit + "," + lOffset + ")";

            bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

            if (datRetData == null)
            {
                return false;
            }
            else
            {
                if (bQuerySuccess == true)
                {

                    foreach (DataTable myDataTablesBuilding in objLogin.PGDataSet.Tables)
                    {

                        //Check if there is any data. If not exit
                        if (myDataTablesBuilding.Rows.Count == 0)
                        {

                            //Return a value indicating that the search was not successful
                            return false;

                        }
                        else
                        {

                            foreach (DataRow myDataRowsBuilding in myDataTablesBuilding.Rows)
                            {
                                if (myDataRowsBuilding["BUILDINGID"] != DBNull.Value)
                                {
                                    lBuildingID = Convert.ToInt64(myDataRowsBuilding["BUILDINGID"]);
                                }

                                if (myDataRowsBuilding["MAPID"] != DBNull.Value)
                                {
                                    lMapID = Convert.ToInt64(myDataRowsBuilding["MAPID"]);
                                }

                                if (myDataRowsBuilding["BUILDINGNAME"] != DBNull.Value)
                                {
                                    strBuildingName = myDataRowsBuilding["BUILDINGNAME"].ToString();
                                }

                                if (myDataRowsBuilding["BUILDINGDESCRIPTION"] != DBNull.Value)
                                {
                                    strBuildingDescription = myDataRowsBuilding["BUILDINGDESCRIPTION"].ToString();
                                }

                                if (myDataRowsBuilding["CURRENTHOUSENUMBER"] != DBNull.Value)
                                {
                                    strCurrentHouseNumber = myDataRowsBuilding["CURRENTHOUSENUMBER"].ToString();
                                }

                                if (myDataRowsBuilding["PHYSICALADDRESS"] != DBNull.Value)
                                {
                                    strPhysicalAddress = myDataRowsBuilding["PHYSICALADDRESS"].ToString();
                                }

                                if (myDataRowsBuilding["BUILDINGSNO"] != DBNull.Value)
                                {
                                    strBuildingSNO = myDataRowsBuilding["BUILDINGSNO"].ToString();
                                }

                                if (myDataRowsBuilding["STREET1"] != DBNull.Value)
                                {
                                    lStreet1 = Convert.ToInt64(myDataRowsBuilding["STREET1"]);
                                }

                                if (myDataRowsBuilding["STREET2"] != DBNull.Value)
                                {
                                    lStreet2 = Convert.ToInt64(myDataRowsBuilding["STREET2"]);
                                }

                                if (myDataRowsBuilding["STREET3"] != DBNull.Value)
                                {
                                    lStreet3 = Convert.ToInt64(myDataRowsBuilding["STREET3"]);
                                }

                                if (myDataRowsBuilding["STREET4"] != DBNull.Value)
                                {
                                    lStreet4 = Convert.ToInt64(myDataRowsBuilding["STREET4"]);
                                }

                                if (myDataRowsBuilding["BUILDINGTYPEID"] != DBNull.Value)
                                {
                                    lBuildingTypeID = Convert.ToInt64(myDataRowsBuilding["BUILDINGTYPEID"]);
                                }

                                if (myDataRowsBuilding["USAGEID"] != DBNull.Value)
                                {
                                    lBuildingUsageID = Convert.ToInt64(myDataRowsBuilding["USAGEID"]);
                                }


                                if (myDataRowsBuilding["NOOFFLOORS"] != DBNull.Value)
                                {
                                    lNoOfFloors = Convert.ToInt64(myDataRowsBuilding["NOOFFLOORS"]);
                                }

                                if (myDataRowsBuilding["BLDCOLOR"] != DBNull.Value)
                                {
                                    strBuildingColour = myDataRowsBuilding["BLDCOLOR"].ToString();
                                }

                                if (myDataRowsBuilding["DATECREATED"] != DBNull.Value)
                                {
                                    dtDateCreated = Convert.ToDateTime(myDataRowsBuilding["DATECREATED"]);
                                }

                                if (myDataRowsBuilding["DATEREGISTERED"] != DBNull.Value)
                                {
                                    dtDateRegistered = Convert.ToDateTime(myDataRowsBuilding["DATEREGISTERED"]);
                                }

                                if (myDataRowsBuilding["DATEDEREGISTERED"] != DBNull.Value)
                                {
                                    dtDateDeRegistered = Convert.ToDateTime(myDataRowsBuilding["DATEDEREGISTERED"]);
                                }

                                if (myDataRowsBuilding["DATECONSTRUCTED"] != DBNull.Value)
                                {
                                    dtDateConstructed = Convert.ToDateTime(myDataRowsBuilding["DATECONSTRUCTED"]);
                                }

                                //if (myDataRowsBuilding["USERID"] != DBNull.Value)
                                //{

                                //UserID = Convert.ToInt64(myDataRowsBuilding["USERID"]);

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
            errMessage = ex.Message;
            return false;
        }

        finally
        {
            datRetData = null;

            objLogin = null;

        }
    }

    public bool ReturnMapIDByBuildingID()
    {
        DataSet datRetData = new DataSet();
        bool bQuerySuccess = false;
        IMLogin objLogin = new IMLogin();
        string strQuery = null;

        try
        {
            strQuery = "SELECT * FROM trip_func_getmapidbybuildingid(" + lBuildingID + ")";

            bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

            if (datRetData == null)
            {
                return false;
            }
            else
            {
                if (bQuerySuccess == true)
                {

                    foreach (DataTable myDataTablesBuilding in objLogin.PGDataSet.Tables)
                    {

                        //Check if there is any data. If not exit
                        if (myDataTablesBuilding.Rows.Count == 0)
                        {
                            //Return a value indicating that the search was not successful
                            return false;

                        }
                        else
                        {
                            foreach (DataRow myDataRowsBuilding in myDataTablesBuilding.Rows)
                            {

                                if (myDataRowsBuilding[0] != DBNull.Value)
                                {
                                    lMapID = Convert.ToInt64(myDataRowsBuilding[0]);
                                }

                                //if (myDataRowsBuilding["USERID"] != DBNull.Value)
                                //{

                                //UserID = Convert.ToInt64(myDataRowsBuilding["USERID"]);

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
            errMessage = ex.Message;
            return false;
        }

        finally
        {
            datRetData = null;

            objLogin = null;

        }
    }

    public bool ReturnBuildingIDNameMapIDMapID(long lLimit, long lOffset)
    {
        DataSet datRetData = new DataSet();
        bool bQuerySuccess = false;
        IMLogin objLogin = new IMLogin();
        string strQuery = null;

        try
        {
            strQuery = "SELECT * FROM trip_func_getbuildingidbuildingnamebymapid(" + lMapID + "," + lLimit + "," + lOffset + ")";

            bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

            if (datRetData == null)
            {
                return false;
            }
            else
            {
                if (bQuerySuccess == true)
                {

                    foreach (DataTable myDataTablesBuilding in objLogin.PGDataSet.Tables)
                    {

                        //Check if there is any data. If not exit
                        if (myDataTablesBuilding.Rows.Count == 0)
                        {

                            //Return a value indicating that the search was not successful
                            return false;

                        }
                        else
                        {

                            foreach (DataRow myDataRowsBuilding in myDataTablesBuilding.Rows)
                            {
                                if (myDataRowsBuilding["BUILDINGID"] != DBNull.Value)
                                {
                                    lBuildingID = Convert.ToInt64(myDataRowsBuilding["BUILDINGID"]);
                                }

                                if (myDataRowsBuilding["MAPID"] != DBNull.Value)
                                {
                                    lMapID = Convert.ToInt64(myDataRowsBuilding["MAPID"]);
                                }

                                if (myDataRowsBuilding["BUILDINGNAME"] != DBNull.Value)
                                {
                                    strBuildingName = myDataRowsBuilding["BUILDINGNAME"].ToString();
                                }

                               
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
            errMessage = ex.Message;
            return false;
        }

        finally
        {
            datRetData = null;

            objLogin = null;

        }
    }

    public bool ReturnAllBuildingIDAndBuildingNameByBuildingID(long lLimit, long lOffset)
    {

        DataSet datRetData = new DataSet();
        bool bQuerySuccess = false;
        IMLogin objLogin = new IMLogin();
        string strQuery = null;

        try
        {
            strQuery = "SELECT * FROM trip_func_getbuildingnamebybuildingid(0," + lLimit +
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

                    foreach (DataTable myDataTablesBuilding in objLogin.PGDataSet.Tables)
                    {

                        //Check if there is any data. If not exit
                        if (myDataTablesBuilding.Rows.Count == 0)
                        {

                            //Return a value indicating that the search was not successful
                            return false;

                        }
                        else
                        {

                            datBuildingMaster = objLogin.PGDataSet;

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

    public bool ReturnBuildingIDAndUsageNameByBuildingID(long lLimit, long lOffset)
    {
        DataSet datRetData = new DataSet();
        bool bQuerySuccess = false;
        IMLogin objLogin = new IMLogin();
        string strQuery = null;

        try
        {
            strQuery = "SELECT * FROM trip_func_getbuildingnamebybuildingid(" + lBuildingID + "," + lLimit +
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

                    foreach (DataTable myDataTablesBuilding in objLogin.PGDataSet.Tables)
                    {

                        //Check if there is any data. If not exit
                        if (myDataTablesBuilding.Rows.Count == 0)
                        {

                            //Return a value indicating that the search was not successful
                            return false;

                        }
                        else
                        {                            
                            foreach (DataRow myDataRowsBuilding in myDataTablesBuilding.Rows)
                            {
                                if (myDataRowsBuilding["BUILDINGID"] != DBNull.Value)
                                {
                                    lBuildingID = Convert.ToInt64(myDataRowsBuilding["BUILDINGID"]);
                                }

                                if (myDataRowsBuilding["BUILDINGNAME"] != DBNull.Value)
                                {
                                    strBuildingName = myDataRowsBuilding["BUILDINGNAME"].ToString();
                                }

                                //if (myDataRowsBuilding["USERID"] != DBNull.Value)
                                //{

                                //UserID = Convert.ToInt64(myDataRowsBuilding["USERID"]);

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

    public bool CheckIfMapIDExistsInDatabase()
    {
        DataSet datRetData = new DataSet();
        bool bQuerySuccess = false;
        IMLogin objLogin = new IMLogin();
        string strQuery = null;

        try
        {
            if (lMapID > 0)
            {
                strQuery = "SELECT * FROM trip_func_checkifbuildingmapidexists(" + lMapID + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesBuilding in objLogin.PGDataSet.Tables)
                        {
                            //Check if there is any data. If not exit
                            if (myDataTablesBuilding.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;
                            }
                            else
                            {

                                foreach (DataRow myDataRowsBuilding in myDataTablesBuilding.Rows)
                                {
                                    if (myDataRowsBuilding[0] != DBNull.Value)
                                    {
                                        lMapID = Convert.ToInt64(myDataRowsBuilding[0]);
                                        return true;
                                    }
                                }
                                                                
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }                    
                }
            }

            return false;
        }

        catch (Exception ex)
        {            
            errMessage = ex.Message + " : Source = " + ex.Source;
            return false;
        }

        finally 
        {
 
        }
    }

    public bool ReturnFirstBuildingMaster()
    {
        DataSet datRetData = new DataSet();
        bool bQuerySuccess = false;
        IMLogin objLogin = new IMLogin();
        string strQuery = null;

        try
        {
            strQuery = "SELECT * FROM trip_func_getfirstbuildingmaster()";

            bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

            if (datRetData == null)
            {
                return false;
            }
            else
            {
                if (bQuerySuccess == true)
                {

                    foreach (DataTable myDataTablesBuilding in objLogin.PGDataSet.Tables)
                    {

                        //Check if there is any data. If not exit
                        if (myDataTablesBuilding.Rows.Count == 0)
                        {
                            //Return a value indicating that the search was not successful
                            return false;

                        }
                        else
                        {

                            foreach (DataRow myDataRowsBuilding in myDataTablesBuilding.Rows)
                            {
                                if (myDataRowsBuilding["BUILDINGID"] != DBNull.Value)
                                {
                                    lBuildingID = Convert.ToInt64(myDataRowsBuilding["BUILDINGID"]);
                                }

                                if (myDataRowsBuilding["MAPID"] != DBNull.Value)
                                {
                                    lMapID = Convert.ToInt64(myDataRowsBuilding["MAPID"]);
                                }

                                if (myDataRowsBuilding["BUILDINGNAME"] != DBNull.Value)
                                {
                                    strBuildingName = myDataRowsBuilding["BUILDINGNAME"].ToString();
                                }

                                if (myDataRowsBuilding["BUILDINGDESCRIPTION"] != DBNull.Value)
                                {
                                    strBuildingDescription = myDataRowsBuilding["BUILDINGDESCRIPTION"].ToString();
                                }

                                if (myDataRowsBuilding["CURRENTHOUSENUMBER"] != DBNull.Value)
                                {
                                    strCurrentHouseNumber = myDataRowsBuilding["CURRENTHOUSENUMBER"].ToString();
                                }

                                if (myDataRowsBuilding["PHYSICALADDRESS"] != DBNull.Value)
                                {
                                    strPhysicalAddress = myDataRowsBuilding["PHYSICALADDRESS"].ToString();
                                }

                                if (myDataRowsBuilding["BUILDINGSNO"] != DBNull.Value)
                                {
                                    strBuildingSNO = myDataRowsBuilding["BUILDINGSNO"].ToString();
                                }

                                if (myDataRowsBuilding["STREET1"] != DBNull.Value)
                                {
                                    lStreet1 = Convert.ToInt64(myDataRowsBuilding["STREET1"]);
                                }

                                if (myDataRowsBuilding["STREET2"] != DBNull.Value)
                                {
                                    lStreet2 = Convert.ToInt64(myDataRowsBuilding["STREET2"]);
                                }

                                if (myDataRowsBuilding["STREET3"] != DBNull.Value)
                                {
                                    lStreet3 = Convert.ToInt64(myDataRowsBuilding["STREET3"]);
                                }

                                if (myDataRowsBuilding["STREET4"] != DBNull.Value)
                                {
                                    lStreet4 = Convert.ToInt64(myDataRowsBuilding["STREET4"]);
                                }

                                if (myDataRowsBuilding["BUILDINGTYPEID"] != DBNull.Value)
                                {
                                    lBuildingTypeID = Convert.ToInt64(myDataRowsBuilding["BUILDINGTYPEID"]);
                                }

                                if (myDataRowsBuilding["USAGEID"] != DBNull.Value)
                                {
                                    lBuildingUsageID = Convert.ToInt64(myDataRowsBuilding["USAGEID"]);
                                }


                                if (myDataRowsBuilding["NOOFFLOORS"] != DBNull.Value)
                                {
                                    lNoOfFloors = Convert.ToInt64(myDataRowsBuilding["NOOFFLOORS"]);
                                }

                                if (myDataRowsBuilding["BLDCOLOR"] != DBNull.Value)
                                {
                                    strBuildingColour = myDataRowsBuilding["BLDCOLOR"].ToString();
                                }

                                if (myDataRowsBuilding["DATECREATED"] != DBNull.Value)
                                {
                                    dtDateCreated = Convert.ToDateTime(myDataRowsBuilding["DATECREATED"]);
                                }

                                if (myDataRowsBuilding["DATEREGISTERED"] != DBNull.Value)
                                {
                                    dtDateRegistered = Convert.ToDateTime(myDataRowsBuilding["DATEREGISTERED"]);
                                }

                                if (myDataRowsBuilding["DATEDEREGISTERED"] != DBNull.Value)
                                {
                                    dtDateDeRegistered = Convert.ToDateTime(myDataRowsBuilding["DATEDEREGISTERED"]);
                                }

                                if (myDataRowsBuilding["DATECONSTRUCTED"] != DBNull.Value)
                                {
                                    dtDateConstructed = Convert.ToDateTime(myDataRowsBuilding["DATECONSTRUCTED"]);
                                }

                                

                                //if (myDataRowsBuilding["USERID"] != DBNull.Value)
                                //{

                                //UserID = Convert.ToInt64(myDataRowsBuilding["USERID"]);

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

    public bool ReturnNextBuildingMaster()
    {
        DataSet datRetData = new DataSet();
        bool bQuerySuccess = false;
        IMLogin objLogin = new IMLogin();
        string strQuery = null;

        try
        {
            strQuery = "SELECT * FROM trip_func_getnextbuildingmaster(" + lBuildingID + ")";

            bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

            if (datRetData == null)
            {
                return false;
            }
            else
            {
                if (bQuerySuccess == true)
                {

                    foreach (DataTable myDataTablesBuilding in objLogin.PGDataSet.Tables)
                    {

                        //Check if there is any data. If not exit
                        if (myDataTablesBuilding.Rows.Count == 0)
                        {
                            //Return a value indicating that the search was not successful
                            return false;

                        }
                        else
                        {

                            foreach (DataRow myDataRowsBuilding in myDataTablesBuilding.Rows)
                            {
                                if (myDataRowsBuilding["BUILDINGID"] != DBNull.Value)
                                {
                                    lBuildingID = Convert.ToInt64(myDataRowsBuilding["BUILDINGID"]);
                                }

                                if (myDataRowsBuilding["MAPID"] != DBNull.Value)
                                {
                                    lMapID = Convert.ToInt64(myDataRowsBuilding["MAPID"]);
                                }

                                if (myDataRowsBuilding["BUILDINGNAME"] != DBNull.Value)
                                {
                                    strBuildingName = myDataRowsBuilding["BUILDINGNAME"].ToString();
                                }

                                if (myDataRowsBuilding["BUILDINGDESCRIPTION"] != DBNull.Value)
                                {
                                    strBuildingDescription = myDataRowsBuilding["BUILDINGDESCRIPTION"].ToString();
                                }

                                if (myDataRowsBuilding["CURRENTHOUSENUMBER"] != DBNull.Value)
                                {
                                    strCurrentHouseNumber = myDataRowsBuilding["CURRENTHOUSENUMBER"].ToString();
                                }

                                if (myDataRowsBuilding["PHYSICALADDRESS"] != DBNull.Value)
                                {
                                    strPhysicalAddress = myDataRowsBuilding["PHYSICALADDRESS"].ToString();
                                }

                                if (myDataRowsBuilding["BUILDINGSNO"] != DBNull.Value)
                                {
                                    strBuildingSNO = myDataRowsBuilding["BUILDINGSNO"].ToString();
                                }

                                if (myDataRowsBuilding["STREET1"] != DBNull.Value)
                                {
                                    lStreet1 = Convert.ToInt64(myDataRowsBuilding["STREET1"]);
                                }

                                if (myDataRowsBuilding["STREET2"] != DBNull.Value)
                                {
                                    lStreet2 = Convert.ToInt64(myDataRowsBuilding["STREET2"]);
                                }

                                if (myDataRowsBuilding["STREET3"] != DBNull.Value)
                                {
                                    lStreet3 = Convert.ToInt64(myDataRowsBuilding["STREET3"]);
                                }

                                if (myDataRowsBuilding["STREET4"] != DBNull.Value)
                                {
                                    lStreet4 = Convert.ToInt64(myDataRowsBuilding["STREET4"]);
                                }

                                if (myDataRowsBuilding["BUILDINGTYPEID"] != DBNull.Value)
                                {
                                    lBuildingTypeID = Convert.ToInt64(myDataRowsBuilding["BUILDINGTYPEID"]);
                                }

                                if (myDataRowsBuilding["USAGEID"] != DBNull.Value)
                                {
                                    lBuildingUsageID = Convert.ToInt64(myDataRowsBuilding["USAGEID"]);
                                }


                                if (myDataRowsBuilding["NOOFFLOORS"] != DBNull.Value)
                                {
                                    lNoOfFloors = Convert.ToInt64(myDataRowsBuilding["NOOFFLOORS"]);
                                }

                                if (myDataRowsBuilding["BLDCOLOR"] != DBNull.Value)
                                {
                                    strBuildingColour = myDataRowsBuilding["BLDCOLOR"].ToString();
                                }

                                if (myDataRowsBuilding["DATECREATED"] != DBNull.Value)
                                {
                                    dtDateCreated = Convert.ToDateTime(myDataRowsBuilding["DATECREATED"]);
                                }

                                if (myDataRowsBuilding["DATEREGISTERED"] != DBNull.Value)
                                {
                                    dtDateRegistered = Convert.ToDateTime(myDataRowsBuilding["DATEREGISTERED"]);
                                }

                                if (myDataRowsBuilding["DATEDEREGISTERED"] != DBNull.Value)
                                {
                                    dtDateDeRegistered = Convert.ToDateTime(myDataRowsBuilding["DATEDEREGISTERED"]);
                                }

                                if (myDataRowsBuilding["DATECONSTRUCTED"] != DBNull.Value)
                                {
                                    dtDateConstructed = Convert.ToDateTime(myDataRowsBuilding["DATECONSTRUCTED"]);
                                }

                                //if (myDataRowsBuilding["USERID"] != DBNull.Value)
                                //{

                                //UserID = Convert.ToInt64(myDataRowsBuilding["USERID"]);

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

    public bool ReturnPreviousBuildingMaster()
    {
        DataSet datRetData = new DataSet();
        bool bQuerySuccess = false;
        IMLogin objLogin = new IMLogin();
        string strQuery = null;

        try
        {
            strQuery = "SELECT * FROM trip_func_getprevbuildingmaster(" + lBuildingID + ")";

            bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

            if (datRetData == null)
            {
                return false;
            }
            else
            {
                if (bQuerySuccess == true)
                {

                    foreach (DataTable myDataTablesBuilding in objLogin.PGDataSet.Tables)
                    {

                        //Check if there is any data. If not exit
                        if (myDataTablesBuilding.Rows.Count == 0)
                        {
                            //Return a value indicating that the search was not successful
                            return false;

                        }
                        else
                        {

                            foreach (DataRow myDataRowsBuilding in myDataTablesBuilding.Rows)
                            {
                                if (myDataRowsBuilding["BUILDINGID"] != DBNull.Value)
                                {
                                    lBuildingID = Convert.ToInt64(myDataRowsBuilding["BUILDINGID"]);
                                }

                                if (myDataRowsBuilding["MAPID"] != DBNull.Value)
                                {
                                    lMapID = Convert.ToInt64(myDataRowsBuilding["MAPID"]);
                                }

                                if (myDataRowsBuilding["BUILDINGNAME"] != DBNull.Value)
                                {
                                    strBuildingName = myDataRowsBuilding["BUILDINGNAME"].ToString();
                                }

                                if (myDataRowsBuilding["BUILDINGDESCRIPTION"] != DBNull.Value)
                                {
                                    strBuildingDescription = myDataRowsBuilding["BUILDINGDESCRIPTION"].ToString();
                                }

                                if (myDataRowsBuilding["CURRENTHOUSENUMBER"] != DBNull.Value)
                                {
                                    strCurrentHouseNumber = myDataRowsBuilding["CURRENTHOUSENUMBER"].ToString();
                                }

                                if (myDataRowsBuilding["PHYSICALADDRESS"] != DBNull.Value)
                                {
                                    strPhysicalAddress = myDataRowsBuilding["PHYSICALADDRESS"].ToString();
                                }

                                if (myDataRowsBuilding["BUILDINGSNO"] != DBNull.Value)
                                {
                                    strBuildingSNO = myDataRowsBuilding["BUILDINGSNO"].ToString();
                                }

                                if (myDataRowsBuilding["STREET1"] != DBNull.Value)
                                {
                                    lStreet1 = Convert.ToInt64(myDataRowsBuilding["STREET1"]);
                                }

                                if (myDataRowsBuilding["STREET2"] != DBNull.Value)
                                {
                                    lStreet2 = Convert.ToInt64(myDataRowsBuilding["STREET2"]);
                                }

                                if (myDataRowsBuilding["STREET3"] != DBNull.Value)
                                {
                                    lStreet3 = Convert.ToInt64(myDataRowsBuilding["STREET3"]);
                                }

                                if (myDataRowsBuilding["STREET4"] != DBNull.Value)
                                {
                                    lStreet4 = Convert.ToInt64(myDataRowsBuilding["STREET4"]);
                                }

                                if (myDataRowsBuilding["BUILDINGTYPEID"] != DBNull.Value)
                                {
                                    lBuildingTypeID = Convert.ToInt64(myDataRowsBuilding["BUILDINGTYPEID"]);
                                }

                                if (myDataRowsBuilding["USAGEID"] != DBNull.Value)
                                {
                                    lBuildingUsageID = Convert.ToInt64(myDataRowsBuilding["USAGEID"]);
                                }


                                if (myDataRowsBuilding["NOOFFLOORS"] != DBNull.Value)
                                {
                                    lNoOfFloors = Convert.ToInt64(myDataRowsBuilding["NOOFFLOORS"]);
                                }

                                if (myDataRowsBuilding["BLDCOLOR"] != DBNull.Value)
                                {
                                    strBuildingColour = myDataRowsBuilding["BLDCOLOR"].ToString();
                                }

                                if (myDataRowsBuilding["DATECREATED"] != DBNull.Value)
                                {
                                    dtDateCreated = Convert.ToDateTime(myDataRowsBuilding["DATECREATED"]);
                                }

                                if (myDataRowsBuilding["DATEREGISTERED"] != DBNull.Value)
                                {
                                    dtDateRegistered = Convert.ToDateTime(myDataRowsBuilding["DATEREGISTERED"]);
                                }

                                if (myDataRowsBuilding["DATEDEREGISTERED"] != DBNull.Value)
                                {
                                    dtDateDeRegistered = Convert.ToDateTime(myDataRowsBuilding["DATEDEREGISTERED"]);
                                }

                                if (myDataRowsBuilding["DATECONSTRUCTED"] != DBNull.Value)
                                {
                                    dtDateConstructed = Convert.ToDateTime(myDataRowsBuilding["DATECONSTRUCTED"]);
                                }

                                //if (myDataRowsBuilding["USERID"] != DBNull.Value)
                                //{

                                //UserID = Convert.ToInt64(myDataRowsBuilding["USERID"]);

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

    public bool ReturnLastBuildingMaster()
    {
        DataSet datRetData = new DataSet();
        bool bQuerySuccess = false;
        IMLogin objLogin = new IMLogin();
        string strQuery = null;

        try
        {
            strQuery = "SELECT * FROM trip_func_getlastbuildingmaster()";

            bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

            if (datRetData == null)
            {
                return false;
            }
            else
            {
                if (bQuerySuccess == true)
                {

                    foreach (DataTable myDataTablesBuilding in objLogin.PGDataSet.Tables)
                    {

                        //Check if there is any data. If not exit
                        if (myDataTablesBuilding.Rows.Count == 0)
                        {
                            //Return a value indicating that the search was not successful
                            return false;

                        }
                        else
                        {

                            foreach (DataRow myDataRowsBuilding in myDataTablesBuilding.Rows)
                            {
                                if (myDataRowsBuilding["BUILDINGID"] != DBNull.Value)
                                {
                                    lBuildingID = Convert.ToInt64(myDataRowsBuilding["BUILDINGID"]);
                                }

                                if (myDataRowsBuilding["MAPID"] != DBNull.Value)
                                {
                                    lMapID = Convert.ToInt64(myDataRowsBuilding["MAPID"]);
                                }

                                if (myDataRowsBuilding["BUILDINGNAME"] != DBNull.Value)
                                {
                                    strBuildingName = myDataRowsBuilding["BUILDINGNAME"].ToString();
                                }

                                if (myDataRowsBuilding["BUILDINGDESCRIPTION"] != DBNull.Value)
                                {
                                    strBuildingDescription = myDataRowsBuilding["BUILDINGDESCRIPTION"].ToString();
                                }

                                if (myDataRowsBuilding["CURRENTHOUSENUMBER"] != DBNull.Value)
                                {
                                    strCurrentHouseNumber = myDataRowsBuilding["CURRENTHOUSENUMBER"].ToString();
                                }

                                if (myDataRowsBuilding["PHYSICALADDRESS"] != DBNull.Value)
                                {
                                    strPhysicalAddress = myDataRowsBuilding["PHYSICALADDRESS"].ToString();
                                }

                                if (myDataRowsBuilding["BUILDINGSNO"] != DBNull.Value)
                                {
                                    strBuildingSNO = myDataRowsBuilding["BUILDINGSNO"].ToString();
                                }

                                if (myDataRowsBuilding["STREET1"] != DBNull.Value)
                                {
                                    lStreet1 = Convert.ToInt64(myDataRowsBuilding["STREET1"]);
                                }

                                if (myDataRowsBuilding["STREET2"] != DBNull.Value)
                                {
                                    lStreet2 = Convert.ToInt64(myDataRowsBuilding["STREET2"]);
                                }

                                if (myDataRowsBuilding["STREET3"] != DBNull.Value)
                                {
                                    lStreet3 = Convert.ToInt64(myDataRowsBuilding["STREET3"]);
                                }

                                if (myDataRowsBuilding["STREET4"] != DBNull.Value)
                                {
                                    lStreet4 = Convert.ToInt64(myDataRowsBuilding["STREET4"]);
                                }

                                if (myDataRowsBuilding["BUILDINGTYPEID"] != DBNull.Value)
                                {
                                    lBuildingTypeID = Convert.ToInt64(myDataRowsBuilding["BUILDINGTYPEID"]);
                                }

                                if (myDataRowsBuilding["USAGEID"] != DBNull.Value)
                                {
                                    lBuildingUsageID = Convert.ToInt64(myDataRowsBuilding["USAGEID"]);
                                }


                                if (myDataRowsBuilding["NOOFFLOORS"] != DBNull.Value)
                                {
                                    lNoOfFloors = Convert.ToInt64(myDataRowsBuilding["NOOFFLOORS"]);
                                }

                                if (myDataRowsBuilding["BLDCOLOR"] != DBNull.Value)
                                {
                                    strBuildingColour = myDataRowsBuilding["BLDCOLOR"].ToString();
                                }

                                if (myDataRowsBuilding["DATECREATED"] != DBNull.Value)
                                {
                                    dtDateCreated = Convert.ToDateTime(myDataRowsBuilding["DATECREATED"]);
                                }

                                if (myDataRowsBuilding["DATEREGISTERED"] != DBNull.Value)
                                {
                                    dtDateRegistered = Convert.ToDateTime(myDataRowsBuilding["DATEREGISTERED"]);
                                }

                                if (myDataRowsBuilding["DATEDEREGISTERED"] != DBNull.Value)
                                {
                                    dtDateDeRegistered = Convert.ToDateTime(myDataRowsBuilding["DATEDEREGISTERED"]);
                                }

                                if (myDataRowsBuilding["DATECONSTRUCTED"] != DBNull.Value)
                                {
                                    dtDateConstructed = Convert.ToDateTime(myDataRowsBuilding["DATECONSTRUCTED"]);
                                }

                                //if (myDataRowsBuilding["USERID"] != DBNull.Value)
                                //{

                                //UserID = Convert.ToInt64(myDataRowsBuilding["USERID"]);

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

    public bool SaveBuildingMaster()
    {
        DataSet datRetData = new DataSet();
        bool bQuerySuccess = false;
        IMLogin objLogin = new IMLogin();
        string strQuery = null;

        try
        {
            strQuery = "SELECT  trip_func_insertupdatecapturebuildingmaster(" + 
                lBuildingID + ",'" + 
                strBuildingName + "','" + 
                strPhysicalAddress + "'," +  
                lStreet1 + "," +  
                lStreet2 + "," +  
                lStreet3 + "," +  
                lStreet4 + ",'" +  
                strBuildingHousingNumber + "','" +  
                strCurrentHouseNumber + "'," +  
                lBuildingTypeID + ",'" +  
                strBuildingDescription + "'," +  
                lNoOfFloors + ",'" +
                strBuildingColour + "','" +  
                strBuildingSNO + "','" +  
                dtDateConstructed + "'," +  
                lBuildingUsageID + "," +
                1 + ")";

            

            bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

            if (datRetData == null)
            {
                return false;
            }
            else
            {
                if (bQuerySuccess == true)
                {

                    foreach (DataTable myDataTablesBuildingMaster in objLogin.PGDataSet.Tables)
                    {
                        //Check if there is any data. If not exit
                        if (myDataTablesBuildingMaster.Rows.Count == 0)
                        {
                            //Return a value indicating that the search was not successful
                            return false;
                        }
                        else
                        {
                            datBuildingMaster = objLogin.PGDataSet;
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
            errMessage = ex.Message + " :Source" + ex.Source;
            return false;
        }

        finally
        {
            datRetData = null;
            objLogin = null;

        }
    }

    public bool SaveBuildingMasterMapOID()
    {
        DataSet datRetData = new DataSet();
        bool bQuerySuccess = false;
        IMLogin objLogin = new IMLogin();
        string strQuery = null;

        try
        {
            strQuery = "SELECT  trip_func_insertupdatecapturebuildingmasterandmapid(" +
                lBuildingID + ",'" +
                strBuildingName + "','" +
                strPhysicalAddress + "'," +
                lStreet1 + "," +
                lStreet2 + "," +
                lStreet3 + "," +
                lStreet4 + ",'" +
                strBuildingHousingNumber + "','" +
                strCurrentHouseNumber + "'," +
                lBuildingTypeID + ",'" +
                strBuildingDescription + "'," +
                lNoOfFloors + ",'" +
                strBuildingColour + "','" +
                strBuildingSNO + "','" +
                dtDateConstructed + "'," +
                lBuildingUsageID + "," +
                1 + "," +  //usage status set to default 1 in cases where building details are updated
                lMapID + ")";



            bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

            if (datRetData == null)
            {
                return false;
            }
            else
            {
                if (bQuerySuccess == true)
                {

                    foreach (DataTable myDataTablesBuildingMaster in objLogin.PGDataSet.Tables)
                    {
                        //Check if there is any data. If not exit
                        if (myDataTablesBuildingMaster.Rows.Count == 0)
                        {
                            //Return a value indicating that the search was not successful
                            return false;
                        }
                        else
                        {
                            datBuildingMaster = objLogin.PGDataSet;
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
            errMessage = ex.Message;
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
