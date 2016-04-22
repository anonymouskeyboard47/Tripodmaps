using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Resources;
using NpgsqlTypes;


namespace TRIP_API
{
    public class IMAddress
    {
        private string errMessage;
        private long lAddressDetailsID = 0;
        private long lAddressDetailsOwnerID = 0;
        private long lAddressDetailsOwnerTypeID = 0;
        private string strAddressDetailsPostalCode = "";
        private string strAddressDetailsPhysicalAddress = "";
        private string strAddressDetailsPostalAddress = "";

        private long lAddressDetailsCountryID = 0;
        private long lAddressDetailsCityID = 0;
        private long lAddressDetailsCountyID = 0;
        private long lAddressDetailsConstituencyID = 0;
        private long lAddressDetailsProvinceID = 0;
        private long lAddressDetailsDistrictID = 0;
        private long lAddressDetailsDivisionID = 0;
        private long lAddressDetailsLocationID = 0;
        private long lAddressDetailsSublocationID = 0;
        private long lAddressDetailsEstateID = 0;

        private string strAddressDetailsHouseNumber = "";
        private NpgsqlPoint pPhysicalAddressCoordinate;
        private string strAddressDetailsSocialNetworkUserID = "";
        private string strAddressDetailsTelephone1 = "";
        private string strAddressDetailsTelephone2 = "";
        private string strAddressDetailsMobilePhone1 = "";
        private string strAddressDetailsMobilePhone2 = "";
        private string strAddressDetailsFax1 = "";
        private string strAddressDetailsFax2 = "";
        private string strAddressDetailsCompanyEmail = "";
        private string strAddressDetailsSalesEmail = "";
        private string strAddressDetailsSupportEmail = "";

        private DateTime dtDateCreated;
        private DateTime dtDateRegistered;
        private DateTime dtDateDeRegistered;
        private long lAddressDetailsStatusID = 0;

        private string strAddressDetailsUniversalAddress = "";
        private long lAddressDetailsRoadID = 0;

        private string strAddressDetailsProjection = "";
        private string strAddressDetailsPointName = "";
        private long lAddressDetailsBuildingID = 0;
        private long lAddressDetailsRootID = 0;
        private long lAddressDetailsAppartmentID = 0;
        private long lAddressDetailsMapID = 0;
        private long lExactMatch = 0;

        private DataSet datAddressDetails;


        #region "Properties"


        public long AddressDetailsID
        {

            get { return lAddressDetailsID; }

            set { lAddressDetailsID = value; }
        }

        public long AddressDetailsOwnerID
        {

            get { return lAddressDetailsOwnerID; }

            set { lAddressDetailsOwnerID = value; }
        }

        public long AddressDetailsOwnerTypeID
        {

            get { return lAddressDetailsOwnerTypeID; }

            set { lAddressDetailsOwnerTypeID = value; }
        }

        public string AddressDetailsPostalCode
        {

            get { return strAddressDetailsPostalCode; }

            set { strAddressDetailsPostalCode = value; }
        }

        public string AddressDetailsPhysicalAddress
        {

            get { return strAddressDetailsPhysicalAddress; }

            set { strAddressDetailsPhysicalAddress = value; }
        }

        public string AddressDetailsPostalAddress
        {

            get { return strAddressDetailsPostalAddress; }

            set { strAddressDetailsPostalAddress = value; }
        }

        public long AddressDetailsCountyID
        {

            get { return lAddressDetailsCountyID; }

            set { lAddressDetailsCountyID = value; }
        }

        public long AddressDetailsConstituencyID
        {

            get { return lAddressDetailsConstituencyID; }

            set { lAddressDetailsConstituencyID = value; }
        }

        public long AddressDetailsCountryID
        {

            get { return lAddressDetailsCountryID; }

            set { lAddressDetailsCountryID = value; }
        }

        public long AddressDetailsCityID
        {

            get { return lAddressDetailsCityID; }

            set { lAddressDetailsCityID = value; }
        }

        public long AddressDetailsProvinceID
        {

            get { return lAddressDetailsProvinceID; }

            set { lAddressDetailsProvinceID = value; }
        }

        public long AddressDetailsDistrictID
        {

            get { return lAddressDetailsDistrictID; }

            set { lAddressDetailsDistrictID = value; }
        }

        public long AddressDetailsDivisionID
        {

            get { return lAddressDetailsDivisionID; }

            set { lAddressDetailsDivisionID = value; }
        }

        public long AddressDetailsLocationID
        {

            get { return lAddressDetailsLocationID; }

            set { lAddressDetailsLocationID = value; }
        }

        public long AddressDetailsSublocationID
        {

            get { return lAddressDetailsSublocationID; }

            set { lAddressDetailsSublocationID = value; }
        }

        public long AddressDetailsEstateID
        {

            get { return lAddressDetailsEstateID; }

            set { lAddressDetailsEstateID = value; }
        }

        public string AddressDetailsHouseNumber
        {

            get { return strAddressDetailsHouseNumber; }

            set { strAddressDetailsHouseNumber = value; }
        }

        public NpgsqlPoint PhysicalAddressCoordinate
        {

            get { return pPhysicalAddressCoordinate; }

            set { pPhysicalAddressCoordinate = value; }
        }

        public string AddressDetailsSocialNetworkUserID
        {

            get { return strAddressDetailsSocialNetworkUserID; }

            set { strAddressDetailsSocialNetworkUserID = value; }
        }

        public string AddressDetailsTelephone1
        {

            get { return strAddressDetailsTelephone1; }

            set { strAddressDetailsTelephone1 = value; }
        }

        public string AddressDetailsTelephone2
        {

            get { return strAddressDetailsTelephone2; }

            set { strAddressDetailsTelephone2 = value; }
        }

        public string AddressDetailsMobilePhone1
        {

            get { return strAddressDetailsMobilePhone1; }

            set { strAddressDetailsMobilePhone1 = value; }
        }

        public string AddressDetailsMobilePhone2
        {

            get { return strAddressDetailsMobilePhone2; }

            set { strAddressDetailsMobilePhone2 = value; }
        }

        public string AddressDetailsFax1
        {

            get { return strAddressDetailsFax1; }

            set { strAddressDetailsFax1 = value; }
        }

        public string AddressDetailsFax2
        {

            get { return strAddressDetailsFax2; }

            set { strAddressDetailsFax2 = value; }
        }

        public string AddressDetailsCompanyEmail
        {

            get { return strAddressDetailsCompanyEmail; }

            set { strAddressDetailsCompanyEmail = value; }
        }

        public string AddressDetailsSalesEmail
        {

            get { return strAddressDetailsSalesEmail; }

            set { strAddressDetailsSalesEmail = value; }
        }

        public string AddressDetailsSupportEmail
        {

            get { return strAddressDetailsSupportEmail; }

            set { strAddressDetailsSupportEmail = value; }
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

        public long AddressDetailsStatusID
        {

            get { return lAddressDetailsStatusID; }

            set { lAddressDetailsStatusID = value; }
        }

        public string AddressDetailsUniversalAddress
        {

            get { return strAddressDetailsUniversalAddress; }

            set { strAddressDetailsUniversalAddress = value; }
        }

        public long AddressDetailsRoadID
        {
            get { return lAddressDetailsRoadID; }
            set { lAddressDetailsRoadID = value; }
        }

        public string AddressDetailsProjection
        {
            get { return strAddressDetailsProjection; }
            set { strAddressDetailsProjection = value; }
        }

        public string AddressDetailsPointName
        {

            get { return strAddressDetailsPointName; }

            set { strAddressDetailsPointName = value; }
        }

        public long AddressDetailsBuildingID
        {

            get { return lAddressDetailsBuildingID; }

            set { lAddressDetailsBuildingID = value; }
        }

        public long AddressDetailsRootID
        {

            get { return lAddressDetailsRootID; }

            set { lAddressDetailsRootID = value; }
        }

        public long AddressDetailsAppartmentID
        {

            get { return lAddressDetailsAppartmentID; }

            set { lAddressDetailsAppartmentID = value; }
        }

        public long AddressDetailsMapID
        {
            get { return lAddressDetailsMapID; }
            set { lAddressDetailsMapID = value; }
        }

        public DataSet AddressDetailsDataSet
        {
            get { return datAddressDetails; }
            set { datAddressDetails = value; }
        }

        public long ExactMatch
        {

            get { return lExactMatch; }

            set { lExactMatch = value; }
        }



        #endregion


        #region "InitializationProcedures"


        public IMAddress()
            : base()
        {

        }


        #endregion


        #region "ControlProcedures"
        //Control related procedures

        public bool IsCoordinateZeroCoordinate()
        {
            Boolean bIsZeroCoordinate = true;

            if (pPhysicalAddressCoordinate.X != 0.0f)
            {
                bIsZeroCoordinate = false;
            }

            if (pPhysicalAddressCoordinate.Y != 0.0f)
            {
                bIsZeroCoordinate = false;
            }

            return bIsZeroCoordinate;
        }

        #endregion


        #region "DatabaseFunctions"

        public bool ReturnAddressDetailsByMapID(long lLimit, long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getaddressdetailsbymapid(" + lAddressDetailsMapID + "," + lLimit +
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

                                foreach (DataRow myDataRowsPoints in myDataTablesBuilding.Rows)
                                {
                                    if (myDataRowsPoints["ADDRESSDETAILSID"] != DBNull.Value)
                                    {
                                        lAddressDetailsID = Convert.ToInt64(myDataRowsPoints["ADDRESSDETAILSID"]);
                                    }

                                    if (myDataRowsPoints["ADDRESSOWNERID"] != DBNull.Value)
                                    {
                                        lAddressDetailsOwnerID = Convert.ToInt64(myDataRowsPoints["ADDRESSOWNERID"]);
                                    }

                                    if (myDataRowsPoints["ADDRESSOWNERTYPEID"] != DBNull.Value)
                                    {
                                        lAddressDetailsOwnerTypeID = Convert.ToInt64(myDataRowsPoints["ADDRESSOWNERTYPEID"]);
                                    }

                                    if (myDataRowsPoints["POSTALCODE"] != DBNull.Value)
                                    {
                                        strAddressDetailsPostalCode = myDataRowsPoints["POSTALCODE"].ToString();
                                    }

                                    if (myDataRowsPoints["PHYSICALADDRESS"] != DBNull.Value)
                                    {
                                        strAddressDetailsPhysicalAddress = myDataRowsPoints["PHYSICALADDRESS"].ToString();
                                    }

                                    if (myDataRowsPoints["POSTALADDRESS"] != DBNull.Value)
                                    {
                                        strAddressDetailsPostalAddress = myDataRowsPoints["POSTALADDRESS"].ToString();
                                    }

                                    if (myDataRowsPoints["COUNTRYID"] != DBNull.Value)
                                    {
                                        lAddressDetailsCountryID = Convert.ToInt64(myDataRowsPoints["COUNTRYID"]);
                                    }

                                    if (myDataRowsPoints["CITYID"] != DBNull.Value)
                                    {
                                        lAddressDetailsCityID = Convert.ToInt64(myDataRowsPoints["CITY"]);
                                    }

                                    if (myDataRowsPoints["COUNTYID"] != DBNull.Value)
                                    {
                                        lAddressDetailsCountyID = Convert.ToInt64(myDataRowsPoints["COUNTYID"]);
                                    }

                                    if (myDataRowsPoints["COUNSTITUENCYID"] != DBNull.Value)
                                    {
                                        lAddressDetailsConstituencyID = Convert.ToInt64(myDataRowsPoints["COUNSTITUENCYID"]);
                                    }

                                    if (myDataRowsPoints["PROVINCEID"] != DBNull.Value)
                                    {
                                        lAddressDetailsProvinceID = Convert.ToInt64(myDataRowsPoints["PROVINCEID"]);
                                    }

                                    if (myDataRowsPoints["DISTRICTID"] != DBNull.Value)
                                    {
                                        lAddressDetailsDistrictID = Convert.ToInt64(myDataRowsPoints["DISTRICTID"]);
                                    }

                                    if (myDataRowsPoints["DIVISIONID"] != DBNull.Value)
                                    {
                                        lAddressDetailsDivisionID = Convert.ToInt64(myDataRowsPoints["DIVISIONID"]);
                                    }

                                    if (myDataRowsPoints["LOCATIONID"] != DBNull.Value)
                                    {
                                        lAddressDetailsLocationID = Convert.ToInt64(myDataRowsPoints["LOCATIONID"]);
                                    }

                                    if (myDataRowsPoints["SUBLOCATIONID"] != DBNull.Value)
                                    {
                                        lAddressDetailsSublocationID = Convert.ToInt64(myDataRowsPoints["SUBLOCATIONID"]);
                                    }

                                    if (myDataRowsPoints["ESTATEID"] != DBNull.Value)
                                    {
                                        lAddressDetailsEstateID = Convert.ToInt64(myDataRowsPoints["ESTATEID"]);
                                    }

                                    if (myDataRowsPoints["HOUSENUMBER"] != DBNull.Value)
                                    {
                                        strAddressDetailsHouseNumber = myDataRowsPoints["ESTATEID"].ToString();
                                    }

                                    if (myDataRowsPoints["PHYSICALADDRESSCOORDINATE"] != DBNull.Value)
                                    {
                                        pPhysicalAddressCoordinate = (NpgsqlPoint)myDataRowsPoints["PHYSICALADDRESSCOORDINATE"];
                                    }

                                    if (myDataRowsPoints["SOCIALNETWORKUSERID"] != DBNull.Value)
                                    {
                                        strAddressDetailsSocialNetworkUserID = myDataRowsPoints["SOCIALNETWORKUSERID"].ToString();
                                    }

                                    if (myDataRowsPoints["TELEPHONE1"] != DBNull.Value)
                                    {
                                        strAddressDetailsTelephone1 = myDataRowsPoints["TELEPHONE1"].ToString();
                                    }

                                    if (myDataRowsPoints["TELEPHONE2"] != DBNull.Value)
                                    {
                                        strAddressDetailsTelephone2 = myDataRowsPoints["TELEPHONE2"].ToString();
                                    }

                                    if (myDataRowsPoints["MOBILEPHONE1"] != DBNull.Value)
                                    {
                                        strAddressDetailsMobilePhone1 = myDataRowsPoints["MOBILEPHONE1"].ToString();
                                    }

                                    if (myDataRowsPoints["MOBILEPHONE2"] != DBNull.Value)
                                    {
                                        strAddressDetailsMobilePhone2 = myDataRowsPoints["MOBILEPHONE2"].ToString();
                                    }

                                    if (myDataRowsPoints["FAX1"] != DBNull.Value)
                                    {
                                        strAddressDetailsFax1 = myDataRowsPoints["FAX1"].ToString();
                                    }

                                    if (myDataRowsPoints["FAX2"] != DBNull.Value)
                                    {
                                        strAddressDetailsFax2 = myDataRowsPoints["FAX2"].ToString();
                                    }

                                    if (myDataRowsPoints["COMPANYEMAIL"] != DBNull.Value)
                                    {
                                        strAddressDetailsCompanyEmail = myDataRowsPoints["COMPANYEMAIL"].ToString();
                                    }

                                    if (myDataRowsPoints["SALESEMAIL"] != DBNull.Value)
                                    {
                                        strAddressDetailsSalesEmail = myDataRowsPoints["SALESEMAIL"].ToString();
                                    }

                                    if (myDataRowsPoints["SUPPORTEMAIL"] != DBNull.Value)
                                    {
                                        strAddressDetailsSupportEmail = myDataRowsPoints["SUPPORTEMAIL"].ToString();
                                    }

                                    if (myDataRowsPoints["STATUSID"] != DBNull.Value)
                                    {
                                        lAddressDetailsStatusID = Convert.ToInt64(myDataRowsPoints["STATUSID"]);
                                    }

                                    if (myDataRowsPoints["UNIVERSALADDRESS"] != DBNull.Value)
                                    {
                                        strAddressDetailsUniversalAddress = myDataRowsPoints["UNIVERSALADDRESS"].ToString();
                                    }

                                    if (myDataRowsPoints["ROADID"] != DBNull.Value)
                                    {
                                        lAddressDetailsRoadID = Convert.ToInt64(myDataRowsPoints["ROADID"]);
                                    }

                                    if (myDataRowsPoints["PROJECTION"] != DBNull.Value)
                                    {
                                        strAddressDetailsProjection = myDataRowsPoints["PROJECTION"].ToString();
                                    }

                                    if (myDataRowsPoints["POINTNAME"] != DBNull.Value)
                                    {
                                        strAddressDetailsPointName = myDataRowsPoints["POINTNAME"].ToString();
                                    }

                                    if (myDataRowsPoints["BUILDINGID"] != DBNull.Value)
                                    {
                                        lAddressDetailsBuildingID = Convert.ToInt64(myDataRowsPoints["BUILDINGID"]);
                                    }

                                    if (myDataRowsPoints["ADDRESSROOTID"] != DBNull.Value)
                                    {
                                        lAddressDetailsRootID = Convert.ToInt64(myDataRowsPoints["ADDRESSROOTID"]);
                                    }

                                    if (myDataRowsPoints["APPARTMENTID"] != DBNull.Value)
                                    {
                                        lAddressDetailsAppartmentID = Convert.ToInt64(myDataRowsPoints["APPARTMENTID"]);
                                    }

                                    if (myDataRowsPoints["MAPID"] != DBNull.Value)
                                    {
                                        lAddressDetailsMapID = Convert.ToInt64(myDataRowsPoints["MAPID"]);
                                    }

                                    if (myDataRowsPoints["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsPoints["DATECREATED"]);
                                    }

                                    if (myDataRowsPoints["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsPoints["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsPoints["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsPoints["DATEDEREGISTERED"]);
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

        public bool ReturnAllAddressDetailsByAddressDetailsID(long lLimit, long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getaddressdetailsbyaddressdetailsid(0," + lLimit +
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

                        foreach (DataTable myDataTablesPoints in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesPoints.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                datAddressDetails = objLogin.PGDataSet;
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

        public bool ReturnAddressDetailsByAddressDetailsID(long lLimit, long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getaddressdetailsbyaddressdetailsid(" + lAddressDetailsID + "," + lLimit +
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

                        foreach (DataTable myDataTablesPoints in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesPoints.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsPoints in myDataTablesPoints.Rows)
                                {
                                    if (myDataRowsPoints["ADDRESSDETAILSID"] != DBNull.Value)
                                    {
                                        lAddressDetailsID = Convert.ToInt64(myDataRowsPoints["ADDRESSDETAILSID"]);
                                    }

                                    if (myDataRowsPoints["ADDRESSOWNERID"] != DBNull.Value)
                                    {
                                        lAddressDetailsOwnerID = Convert.ToInt64(myDataRowsPoints["ADDRESSOWNERID"]);
                                    }

                                    if (myDataRowsPoints["ADDRESSOWNERTYPEID"] != DBNull.Value)
                                    {
                                        lAddressDetailsOwnerTypeID = Convert.ToInt64(myDataRowsPoints["ADDRESSOWNERTYPEID"]);
                                    }

                                    if (myDataRowsPoints["POSTALCODE"] != DBNull.Value)
                                    {
                                        strAddressDetailsPostalCode = myDataRowsPoints["POSTALCODE"].ToString();
                                    }

                                    if (myDataRowsPoints["PHYSICALADDRESS"] != DBNull.Value)
                                    {
                                        strAddressDetailsPhysicalAddress = myDataRowsPoints["PHYSICALADDRESS"].ToString();
                                    }

                                    if (myDataRowsPoints["POSTALADDRESS"] != DBNull.Value)
                                    {
                                        strAddressDetailsPostalAddress = myDataRowsPoints["POSTALADDRESS"].ToString();
                                    }

                                    if (myDataRowsPoints["COUNTRYID"] != DBNull.Value)
                                    {
                                        lAddressDetailsCountryID = Convert.ToInt64(myDataRowsPoints["COUNTRYID"]);
                                    }

                                    if (myDataRowsPoints["CITYID"] != DBNull.Value)
                                    {
                                        lAddressDetailsCityID = Convert.ToInt64(myDataRowsPoints["CITY"]);
                                    }

                                    if (myDataRowsPoints["COUNTYID"] != DBNull.Value)
                                    {
                                        lAddressDetailsCountyID = Convert.ToInt64(myDataRowsPoints["COUNTYID"]);
                                    }

                                    if (myDataRowsPoints["COUNSTITUENCYID"] != DBNull.Value)
                                    {
                                        lAddressDetailsConstituencyID = Convert.ToInt64(myDataRowsPoints["COUNSTITUENCYID"]);
                                    }

                                    if (myDataRowsPoints["PROVINCEID"] != DBNull.Value)
                                    {
                                        lAddressDetailsProvinceID = Convert.ToInt64(myDataRowsPoints["PROVINCEID"]);
                                    }

                                    if (myDataRowsPoints["DISTRICTID"] != DBNull.Value)
                                    {
                                        lAddressDetailsDistrictID = Convert.ToInt64(myDataRowsPoints["DISTRICTID"]);
                                    }

                                    if (myDataRowsPoints["DIVISIONID"] != DBNull.Value)
                                    {
                                        lAddressDetailsDivisionID = Convert.ToInt64(myDataRowsPoints["DIVISIONID"]);
                                    }

                                    if (myDataRowsPoints["LOCATIONID"] != DBNull.Value)
                                    {
                                        lAddressDetailsLocationID = Convert.ToInt64(myDataRowsPoints["LOCATIONID"]);
                                    }

                                    if (myDataRowsPoints["SUBLOCATIONID"] != DBNull.Value)
                                    {
                                        lAddressDetailsSublocationID = Convert.ToInt64(myDataRowsPoints["SUBLOCATIONID"]);
                                    }

                                    if (myDataRowsPoints["ESTATEID"] != DBNull.Value)
                                    {
                                        lAddressDetailsEstateID = Convert.ToInt64(myDataRowsPoints["ESTATEID"]);
                                    }

                                    if (myDataRowsPoints["HOUSENUMBER"] != DBNull.Value)
                                    {
                                        strAddressDetailsHouseNumber = myDataRowsPoints["ESTATEID"].ToString();
                                    }

                                    if (myDataRowsPoints["PHYSICALADDRESSCOORDINATE"] != DBNull.Value)
                                    {
                                        pPhysicalAddressCoordinate = (NpgsqlPoint)myDataRowsPoints["PHYSICALADDRESSCOORDINATE"];
                                    }

                                    if (myDataRowsPoints["SOCIALNETWORKUSERID"] != DBNull.Value)
                                    {
                                        strAddressDetailsSocialNetworkUserID = myDataRowsPoints["SOCIALNETWORKUSERID"].ToString();
                                    }

                                    if (myDataRowsPoints["TELEPHONE1"] != DBNull.Value)
                                    {
                                        strAddressDetailsTelephone1 = myDataRowsPoints["TELEPHONE1"].ToString();
                                    }

                                    if (myDataRowsPoints["TELEPHONE2"] != DBNull.Value)
                                    {
                                        strAddressDetailsTelephone2 = myDataRowsPoints["TELEPHONE2"].ToString();
                                    }

                                    if (myDataRowsPoints["MOBILEPHONE1"] != DBNull.Value)
                                    {
                                        strAddressDetailsMobilePhone1 = myDataRowsPoints["MOBILEPHONE1"].ToString();
                                    }

                                    if (myDataRowsPoints["MOBILEPHONE2"] != DBNull.Value)
                                    {
                                        strAddressDetailsMobilePhone2 = myDataRowsPoints["MOBILEPHONE2"].ToString();
                                    }

                                    if (myDataRowsPoints["FAX1"] != DBNull.Value)
                                    {
                                        strAddressDetailsFax1 = myDataRowsPoints["FAX1"].ToString();
                                    }

                                    if (myDataRowsPoints["FAX2"] != DBNull.Value)
                                    {
                                        strAddressDetailsFax2 = myDataRowsPoints["FAX2"].ToString();
                                    }

                                    if (myDataRowsPoints["COMPANYEMAIL"] != DBNull.Value)
                                    {
                                        strAddressDetailsCompanyEmail = myDataRowsPoints["COMPANYEMAIL"].ToString();
                                    }

                                    if (myDataRowsPoints["SALESEMAIL"] != DBNull.Value)
                                    {
                                        strAddressDetailsSalesEmail = myDataRowsPoints["SALESEMAIL"].ToString();
                                    }

                                    if (myDataRowsPoints["SUPPORTEMAIL"] != DBNull.Value)
                                    {
                                        strAddressDetailsSupportEmail = myDataRowsPoints["SUPPORTEMAIL"].ToString();
                                    }

                                    if (myDataRowsPoints["STATUSID"] != DBNull.Value)
                                    {
                                        lAddressDetailsStatusID = Convert.ToInt64(myDataRowsPoints["STATUSID"]);
                                    }

                                    if (myDataRowsPoints["UNIVERSALADDRESS"] != DBNull.Value)
                                    {
                                        strAddressDetailsUniversalAddress = myDataRowsPoints["UNIVERSALADDRESS"].ToString();
                                    }

                                    if (myDataRowsPoints["ROADID"] != DBNull.Value)
                                    {
                                        lAddressDetailsRoadID = Convert.ToInt64(myDataRowsPoints["ROADID"]);
                                    }

                                    if (myDataRowsPoints["PROJECTION"] != DBNull.Value)
                                    {
                                        strAddressDetailsProjection = myDataRowsPoints["PROJECTION"].ToString();
                                    }

                                    if (myDataRowsPoints["POINTNAME"] != DBNull.Value)
                                    {
                                        strAddressDetailsPointName = myDataRowsPoints["POINTNAME"].ToString();
                                    }

                                    if (myDataRowsPoints["BUILDINGID"] != DBNull.Value)
                                    {
                                        lAddressDetailsBuildingID = Convert.ToInt64(myDataRowsPoints["BUILDINGID"]);
                                    }

                                    if (myDataRowsPoints["ADDRESSROOTID"] != DBNull.Value)
                                    {
                                        lAddressDetailsRootID = Convert.ToInt64(myDataRowsPoints["ADDRESSROOTID"]);
                                    }

                                    if (myDataRowsPoints["APPARTMENTID"] != DBNull.Value)
                                    {
                                        lAddressDetailsAppartmentID = Convert.ToInt64(myDataRowsPoints["APPARTMENTID"]);
                                    }

                                    if (myDataRowsPoints["MAPID"] != DBNull.Value)
                                    {
                                        lAddressDetailsMapID = Convert.ToInt64(myDataRowsPoints["MAPID"]);
                                    }

                                    if (myDataRowsPoints["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsPoints["DATECREATED"]);
                                    }

                                    if (myDataRowsPoints["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsPoints["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsPoints["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsPoints["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsPoints["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsPoints["USERID"]);

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

        public bool ReturnAllAddressDetailsIDPointNamePointByAddressDetailsID(long lLimit, long lOffset)
        {

            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getpointidandnamebypointid(0," + lLimit +
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

                        foreach (DataTable myDataTablesPoints in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesPoints.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                datAddressDetails = objLogin.PGDataSet;

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

        public bool ReturnAddressDetailsIDPointNamePointByAddressDetailsID(long lLimit, long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getpointidandnamebypointid(" + lAddressDetailsID + "," + lLimit +
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

                        foreach (DataTable myDataTablesPoints in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesPoints.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {



                                foreach (DataRow myDataRowsPoints in myDataTablesPoints.Rows)
                                {
                                    if (myDataRowsPoints["ADDRESSDETAILSID"] != DBNull.Value)
                                    {
                                        lAddressDetailsID = Convert.ToInt64(myDataRowsPoints["ADDRESSDETAILSID"]);
                                    }

                                    if (myDataRowsPoints["PHYSICALADDRESSCOORDINATE"] != DBNull.Value)
                                    {
                                        pPhysicalAddressCoordinate = (NpgsqlPoint)myDataRowsPoints["PHYSICALADDRESSCOORDINATE"];
                                    }

                                    if (myDataRowsPoints["UNIVERSALADDRESS"] != DBNull.Value)
                                    {
                                        strAddressDetailsUniversalAddress = myDataRowsPoints["UNIVERSALADDRESS"].ToString();
                                    }

                                    if (myDataRowsPoints["ROADID"] != DBNull.Value)
                                    {
                                        lAddressDetailsRoadID = Convert.ToInt64(myDataRowsPoints["ROADID"]);
                                    }

                                    if (myDataRowsPoints["POINTNAME"] != DBNull.Value)
                                    {
                                        strAddressDetailsPointName = myDataRowsPoints["POINTNAME"].ToString();
                                    }

                                    if (myDataRowsPoints["BUILDINGID"] != DBNull.Value)
                                    {
                                        lAddressDetailsBuildingID = Convert.ToInt64(myDataRowsPoints["BUILDINGID"]);
                                    }

                                    if (myDataRowsPoints["MAPID"] != DBNull.Value)
                                    {
                                        lAddressDetailsMapID = Convert.ToInt64(myDataRowsPoints["MAPID"]);
                                    }



                                    //if (myDataRowsPoints["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsPoints["USERID"]);

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

        public bool ReturnAddressDetailsIDPointNamePointInBuildingID(long lLimit, long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getpointidnameandidbybuildingid(" + lAddressDetailsBuildingID + ","
                    + lLimit + "," + lOffset + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesPoints in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesPoints.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {



                                foreach (DataRow myDataRowsPoints in myDataTablesPoints.Rows)
                                {
                                    if (myDataRowsPoints["ADDRESSDETAILSID"] != DBNull.Value)
                                    {
                                        lAddressDetailsID = Convert.ToInt64(myDataRowsPoints["ADDRESSDETAILSID"]);
                                    }

                                    if (myDataRowsPoints["POINTNAME"] != DBNull.Value)
                                    {
                                        strAddressDetailsPointName = myDataRowsPoints["POINTNAME"].ToString();
                                    }

                                    if (myDataRowsPoints["BUILDINGID"] != DBNull.Value)
                                    {
                                        lAddressDetailsBuildingID = Convert.ToInt64(myDataRowsPoints["BUILDINGID"]);
                                    }



                                    //if (myDataRowsPoints["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsPoints["USERID"]);

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

        public bool ReturnAllReturnAddressDetailsIDPointNamePointInBuildingID(long lLimit, long lOffset)
        {

            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getaddressdetailspointnameandidbybuildingid(" + lAddressDetailsBuildingID + ","
                    + lLimit + "," + lOffset + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesPoints in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesPoints.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;
                            }
                            else
                            {
                                datAddressDetails = objLogin.PGDataSet;
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

        public bool ReturnAddressDetailsByPointName(long lLimit, long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getaddressdetailsidbypointnames('" +
                    strAddressDetailsPointName + "'," + lExactMatch + "," + lLimit + "," + lOffset + ")";

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

                                foreach (DataRow myDataRowsPoints in myDataTablesBuilding.Rows)
                                {
                                    if (myDataRowsPoints[0] != DBNull.Value)
                                    {
                                        lAddressDetailsMapID = Convert.ToInt64(myDataRowsPoints[0]);
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

        public bool ReturnAllAddressDetailsByPointName(long lLimit, long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getaddressdetailsidbypointnames('" +
                    strAddressDetailsPointName + "'," + lExactMatch + "," + lLimit + "," + lOffset + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesAddresses in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesAddresses.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsAddresses in myDataTablesAddresses.Rows)
                                {

                                    //Check if there is any data. If not exit
                                    if (myDataTablesAddresses.Rows.Count == 0)
                                    {
                                        //Return a value indicating that the search was not successful
                                        return false;
                                    }
                                    else
                                    {

                                        datAddressDetails = objLogin.PGDataSet;
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

        public bool ReturnFirstAddressDetails()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getfirstpointtypemaster()";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesPoints in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesPoints.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsPoints in myDataTablesPoints.Rows)
                                {
                                    if (myDataRowsPoints["ADDRESSDETAILSID"] != DBNull.Value)
                                    {
                                        lAddressDetailsID = Convert.ToInt64(myDataRowsPoints["ADDRESSDETAILSID"]);
                                    }

                                    if (myDataRowsPoints["ADDRESSOWNERID"] != DBNull.Value)
                                    {
                                        lAddressDetailsOwnerID = Convert.ToInt64(myDataRowsPoints["ADDRESSOWNERID"]);
                                    }

                                    if (myDataRowsPoints["ADDRESSOWNERTYPEID"] != DBNull.Value)
                                    {
                                        lAddressDetailsOwnerTypeID = Convert.ToInt64(myDataRowsPoints["ADDRESSOWNERTYPEID"]);
                                    }

                                    if (myDataRowsPoints["POSTALCODE"] != DBNull.Value)
                                    {
                                        strAddressDetailsPostalCode = myDataRowsPoints["POSTALCODE"].ToString();
                                    }

                                    if (myDataRowsPoints["PHYSICALADDRESS"] != DBNull.Value)
                                    {
                                        strAddressDetailsPhysicalAddress = myDataRowsPoints["PHYSICALADDRESS"].ToString();
                                    }

                                    if (myDataRowsPoints["POSTALADDRESS"] != DBNull.Value)
                                    {
                                        strAddressDetailsPostalAddress = myDataRowsPoints["POSTALADDRESS"].ToString();
                                    }

                                    if (myDataRowsPoints["COUNTRYID"] != DBNull.Value)
                                    {
                                        lAddressDetailsCountryID = Convert.ToInt64(myDataRowsPoints["COUNTRYID"]);
                                    }

                                    if (myDataRowsPoints["CITYID"] != DBNull.Value)
                                    {
                                        lAddressDetailsCityID = Convert.ToInt64(myDataRowsPoints["CITY"]);
                                    }

                                    if (myDataRowsPoints["COUNTYID"] != DBNull.Value)
                                    {
                                        lAddressDetailsCountyID = Convert.ToInt64(myDataRowsPoints["COUNTYID"]);
                                    }

                                    if (myDataRowsPoints["COUNSTITUENCYID"] != DBNull.Value)
                                    {
                                        lAddressDetailsConstituencyID = Convert.ToInt64(myDataRowsPoints["COUNSTITUENCYID"]);
                                    }

                                    if (myDataRowsPoints["PROVINCEID"] != DBNull.Value)
                                    {
                                        lAddressDetailsProvinceID = Convert.ToInt64(myDataRowsPoints["PROVINCEID"]);
                                    }

                                    if (myDataRowsPoints["DISTRICTID"] != DBNull.Value)
                                    {
                                        lAddressDetailsDistrictID = Convert.ToInt64(myDataRowsPoints["DISTRICTID"]);
                                    }

                                    if (myDataRowsPoints["DIVISIONID"] != DBNull.Value)
                                    {
                                        lAddressDetailsDivisionID = Convert.ToInt64(myDataRowsPoints["DIVISIONID"]);
                                    }

                                    if (myDataRowsPoints["LOCATIONID"] != DBNull.Value)
                                    {
                                        lAddressDetailsLocationID = Convert.ToInt64(myDataRowsPoints["LOCATIONID"]);
                                    }

                                    if (myDataRowsPoints["SUBLOCATIONID"] != DBNull.Value)
                                    {
                                        lAddressDetailsSublocationID = Convert.ToInt64(myDataRowsPoints["SUBLOCATIONID"]);
                                    }

                                    if (myDataRowsPoints["ESTATEID"] != DBNull.Value)
                                    {
                                        lAddressDetailsEstateID = Convert.ToInt64(myDataRowsPoints["ESTATEID"]);
                                    }

                                    if (myDataRowsPoints["HOUSENUMBER"] != DBNull.Value)
                                    {
                                        strAddressDetailsHouseNumber = myDataRowsPoints["ESTATEID"].ToString();
                                    }

                                    if (myDataRowsPoints["PHYSICALADDRESSCOORDINATE"] != DBNull.Value)
                                    {
                                        pPhysicalAddressCoordinate = (NpgsqlPoint)myDataRowsPoints["PHYSICALADDRESSCOORDINATE"];
                                    }

                                    if (myDataRowsPoints["SOCIALNETWORKUSERID"] != DBNull.Value)
                                    {
                                        strAddressDetailsSocialNetworkUserID = myDataRowsPoints["SOCIALNETWORKUSERID"].ToString();
                                    }

                                    if (myDataRowsPoints["TELEPHONE1"] != DBNull.Value)
                                    {
                                        strAddressDetailsTelephone1 = myDataRowsPoints["TELEPHONE1"].ToString();
                                    }

                                    if (myDataRowsPoints["TELEPHONE2"] != DBNull.Value)
                                    {
                                        strAddressDetailsTelephone2 = myDataRowsPoints["TELEPHONE2"].ToString();
                                    }

                                    if (myDataRowsPoints["MOBILEPHONE1"] != DBNull.Value)
                                    {
                                        strAddressDetailsMobilePhone1 = myDataRowsPoints["MOBILEPHONE1"].ToString();
                                    }

                                    if (myDataRowsPoints["MOBILEPHONE2"] != DBNull.Value)
                                    {
                                        strAddressDetailsMobilePhone2 = myDataRowsPoints["MOBILEPHONE2"].ToString();
                                    }

                                    if (myDataRowsPoints["FAX1"] != DBNull.Value)
                                    {
                                        strAddressDetailsFax1 = myDataRowsPoints["FAX1"].ToString();
                                    }

                                    if (myDataRowsPoints["FAX2"] != DBNull.Value)
                                    {
                                        strAddressDetailsFax2 = myDataRowsPoints["FAX2"].ToString();
                                    }

                                    if (myDataRowsPoints["COMPANYEMAIL"] != DBNull.Value)
                                    {
                                        strAddressDetailsCompanyEmail = myDataRowsPoints["COMPANYEMAIL"].ToString();
                                    }

                                    if (myDataRowsPoints["SALESEMAIL"] != DBNull.Value)
                                    {
                                        strAddressDetailsSalesEmail = myDataRowsPoints["SALESEMAIL"].ToString();
                                    }

                                    if (myDataRowsPoints["SUPPORTEMAIL"] != DBNull.Value)
                                    {
                                        strAddressDetailsSupportEmail = myDataRowsPoints["SUPPORTEMAIL"].ToString();
                                    }

                                    if (myDataRowsPoints["STATUSID"] != DBNull.Value)
                                    {
                                        lAddressDetailsStatusID = Convert.ToInt64(myDataRowsPoints["STATUSID"]);
                                    }

                                    if (myDataRowsPoints["UNIVERSALADDRESS"] != DBNull.Value)
                                    {
                                        strAddressDetailsUniversalAddress = myDataRowsPoints["UNIVERSALADDRESS"].ToString();
                                    }

                                    if (myDataRowsPoints["ROADID"] != DBNull.Value)
                                    {
                                        lAddressDetailsRoadID = Convert.ToInt64(myDataRowsPoints["ROADID"]);
                                    }

                                    if (myDataRowsPoints["PROJECTION"] != DBNull.Value)
                                    {
                                        strAddressDetailsProjection = myDataRowsPoints["PROJECTION"].ToString();
                                    }

                                    if (myDataRowsPoints["POINTNAME"] != DBNull.Value)
                                    {
                                        strAddressDetailsPointName = myDataRowsPoints["POINTNAME"].ToString();
                                    }

                                    if (myDataRowsPoints["BUILDINGID"] != DBNull.Value)
                                    {
                                        lAddressDetailsBuildingID = Convert.ToInt64(myDataRowsPoints["BUILDINGID"]);
                                    }

                                    if (myDataRowsPoints["ADDRESSROOTID"] != DBNull.Value)
                                    {
                                        lAddressDetailsRootID = Convert.ToInt64(myDataRowsPoints["ADDRESSROOTID"]);
                                    }

                                    if (myDataRowsPoints["APPARTMENTID"] != DBNull.Value)
                                    {
                                        lAddressDetailsAppartmentID = Convert.ToInt64(myDataRowsPoints["APPARTMENTID"]);
                                    }

                                    if (myDataRowsPoints["MAPID"] != DBNull.Value)
                                    {
                                        lAddressDetailsMapID = Convert.ToInt64(myDataRowsPoints["MAPID"]);
                                    }

                                    if (myDataRowsPoints["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsPoints["DATECREATED"]);
                                    }

                                    if (myDataRowsPoints["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsPoints["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsPoints["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsPoints["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsPoints["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsPoints["USERID"]);

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

        public bool ReturnNextAddressDetails()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getnextpointtypemaster(" + lAddressDetailsID + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesPoints in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesPoints.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsPoints in myDataTablesPoints.Rows)
                                {
                                    if (myDataRowsPoints["ADDRESSDETAILSID"] != DBNull.Value)
                                    {
                                        lAddressDetailsID = Convert.ToInt64(myDataRowsPoints["ADDRESSDETAILSID"]);
                                    }

                                    if (myDataRowsPoints["ADDRESSOWNERID"] != DBNull.Value)
                                    {
                                        lAddressDetailsOwnerID = Convert.ToInt64(myDataRowsPoints["ADDRESSOWNERID"]);
                                    }

                                    if (myDataRowsPoints["ADDRESSOWNERTYPEID"] != DBNull.Value)
                                    {
                                        lAddressDetailsOwnerTypeID = Convert.ToInt64(myDataRowsPoints["ADDRESSOWNERTYPEID"]);
                                    }

                                    if (myDataRowsPoints["POSTALCODE"] != DBNull.Value)
                                    {
                                        strAddressDetailsPostalCode = myDataRowsPoints["POSTALCODE"].ToString();
                                    }

                                    if (myDataRowsPoints["PHYSICALADDRESS"] != DBNull.Value)
                                    {
                                        strAddressDetailsPhysicalAddress = myDataRowsPoints["PHYSICALADDRESS"].ToString();
                                    }

                                    if (myDataRowsPoints["POSTALADDRESS"] != DBNull.Value)
                                    {
                                        strAddressDetailsPostalAddress = myDataRowsPoints["POSTALADDRESS"].ToString();
                                    }

                                    if (myDataRowsPoints["COUNTRYID"] != DBNull.Value)
                                    {
                                        lAddressDetailsCountryID = Convert.ToInt64(myDataRowsPoints["COUNTRYID"]);
                                    }

                                    if (myDataRowsPoints["CITYID"] != DBNull.Value)
                                    {
                                        lAddressDetailsCityID = Convert.ToInt64(myDataRowsPoints["CITY"]);
                                    }

                                    if (myDataRowsPoints["COUNTYID"] != DBNull.Value)
                                    {
                                        lAddressDetailsCountyID = Convert.ToInt64(myDataRowsPoints["COUNTYID"]);
                                    }

                                    if (myDataRowsPoints["COUNSTITUENCYID"] != DBNull.Value)
                                    {
                                        lAddressDetailsConstituencyID = Convert.ToInt64(myDataRowsPoints["COUNSTITUENCYID"]);
                                    }

                                    if (myDataRowsPoints["PROVINCEID"] != DBNull.Value)
                                    {
                                        lAddressDetailsProvinceID = Convert.ToInt64(myDataRowsPoints["PROVINCEID"]);
                                    }

                                    if (myDataRowsPoints["DISTRICTID"] != DBNull.Value)
                                    {
                                        lAddressDetailsDistrictID = Convert.ToInt64(myDataRowsPoints["DISTRICTID"]);
                                    }

                                    if (myDataRowsPoints["DIVISIONID"] != DBNull.Value)
                                    {
                                        lAddressDetailsDivisionID = Convert.ToInt64(myDataRowsPoints["DIVISIONID"]);
                                    }

                                    if (myDataRowsPoints["LOCATIONID"] != DBNull.Value)
                                    {
                                        lAddressDetailsLocationID = Convert.ToInt64(myDataRowsPoints["LOCATIONID"]);
                                    }

                                    if (myDataRowsPoints["SUBLOCATIONID"] != DBNull.Value)
                                    {
                                        lAddressDetailsSublocationID = Convert.ToInt64(myDataRowsPoints["SUBLOCATIONID"]);
                                    }

                                    if (myDataRowsPoints["ESTATEID"] != DBNull.Value)
                                    {
                                        lAddressDetailsEstateID = Convert.ToInt64(myDataRowsPoints["ESTATEID"]);
                                    }

                                    if (myDataRowsPoints["HOUSENUMBER"] != DBNull.Value)
                                    {
                                        strAddressDetailsHouseNumber = myDataRowsPoints["ESTATEID"].ToString();
                                    }

                                    if (myDataRowsPoints["PHYSICALADDRESSCOORDINATE"] != DBNull.Value)
                                    {
                                        pPhysicalAddressCoordinate = (NpgsqlPoint)myDataRowsPoints["PHYSICALADDRESSCOORDINATE"];
                                    }

                                    if (myDataRowsPoints["SOCIALNETWORKUSERID"] != DBNull.Value)
                                    {
                                        strAddressDetailsSocialNetworkUserID = myDataRowsPoints["SOCIALNETWORKUSERID"].ToString();
                                    }

                                    if (myDataRowsPoints["TELEPHONE1"] != DBNull.Value)
                                    {
                                        strAddressDetailsTelephone1 = myDataRowsPoints["TELEPHONE1"].ToString();
                                    }

                                    if (myDataRowsPoints["TELEPHONE2"] != DBNull.Value)
                                    {
                                        strAddressDetailsTelephone2 = myDataRowsPoints["TELEPHONE2"].ToString();
                                    }

                                    if (myDataRowsPoints["MOBILEPHONE1"] != DBNull.Value)
                                    {
                                        strAddressDetailsMobilePhone1 = myDataRowsPoints["MOBILEPHONE1"].ToString();
                                    }

                                    if (myDataRowsPoints["MOBILEPHONE2"] != DBNull.Value)
                                    {
                                        strAddressDetailsMobilePhone2 = myDataRowsPoints["MOBILEPHONE2"].ToString();
                                    }

                                    if (myDataRowsPoints["FAX1"] != DBNull.Value)
                                    {
                                        strAddressDetailsFax1 = myDataRowsPoints["FAX1"].ToString();
                                    }

                                    if (myDataRowsPoints["FAX2"] != DBNull.Value)
                                    {
                                        strAddressDetailsFax2 = myDataRowsPoints["FAX2"].ToString();
                                    }

                                    if (myDataRowsPoints["COMPANYEMAIL"] != DBNull.Value)
                                    {
                                        strAddressDetailsCompanyEmail = myDataRowsPoints["COMPANYEMAIL"].ToString();
                                    }

                                    if (myDataRowsPoints["SALESEMAIL"] != DBNull.Value)
                                    {
                                        strAddressDetailsSalesEmail = myDataRowsPoints["SALESEMAIL"].ToString();
                                    }

                                    if (myDataRowsPoints["SUPPORTEMAIL"] != DBNull.Value)
                                    {
                                        strAddressDetailsSupportEmail = myDataRowsPoints["SUPPORTEMAIL"].ToString();
                                    }

                                    if (myDataRowsPoints["STATUSID"] != DBNull.Value)
                                    {
                                        lAddressDetailsStatusID = Convert.ToInt64(myDataRowsPoints["STATUSID"]);
                                    }

                                    if (myDataRowsPoints["UNIVERSALADDRESS"] != DBNull.Value)
                                    {
                                        strAddressDetailsUniversalAddress = myDataRowsPoints["UNIVERSALADDRESS"].ToString();
                                    }

                                    if (myDataRowsPoints["ROADID"] != DBNull.Value)
                                    {
                                        lAddressDetailsRoadID = Convert.ToInt64(myDataRowsPoints["ROADID"]);
                                    }

                                    if (myDataRowsPoints["PROJECTION"] != DBNull.Value)
                                    {
                                        strAddressDetailsProjection = myDataRowsPoints["PROJECTION"].ToString();
                                    }

                                    if (myDataRowsPoints["POINTNAME"] != DBNull.Value)
                                    {
                                        strAddressDetailsPointName = myDataRowsPoints["POINTNAME"].ToString();
                                    }

                                    if (myDataRowsPoints["BUILDINGID"] != DBNull.Value)
                                    {
                                        lAddressDetailsBuildingID = Convert.ToInt64(myDataRowsPoints["BUILDINGID"]);
                                    }

                                    if (myDataRowsPoints["ADDRESSROOTID"] != DBNull.Value)
                                    {
                                        lAddressDetailsRootID = Convert.ToInt64(myDataRowsPoints["ADDRESSROOTID"]);
                                    }

                                    if (myDataRowsPoints["APPARTMENTID"] != DBNull.Value)
                                    {
                                        lAddressDetailsAppartmentID = Convert.ToInt64(myDataRowsPoints["APPARTMENTID"]);
                                    }

                                    if (myDataRowsPoints["MAPID"] != DBNull.Value)
                                    {
                                        lAddressDetailsMapID = Convert.ToInt64(myDataRowsPoints["MAPID"]);
                                    }

                                    if (myDataRowsPoints["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsPoints["DATECREATED"]);
                                    }

                                    if (myDataRowsPoints["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsPoints["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsPoints["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsPoints["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsPoints["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsPoints["USERID"]);

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

        public bool ReturnPreviousAddressDetails()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getprevpointtypemaster(" + lAddressDetailsID + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesPoints in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesPoints.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsPoints in myDataTablesPoints.Rows)
                                {
                                    if (myDataRowsPoints["ADDRESSDETAILSID"] != DBNull.Value)
                                    {
                                        lAddressDetailsID = Convert.ToInt64(myDataRowsPoints["ADDRESSDETAILSID"]);
                                    }

                                    if (myDataRowsPoints["ADDRESSOWNERID"] != DBNull.Value)
                                    {
                                        lAddressDetailsOwnerID = Convert.ToInt64(myDataRowsPoints["ADDRESSOWNERID"]);
                                    }

                                    if (myDataRowsPoints["ADDRESSOWNERTYPEID"] != DBNull.Value)
                                    {
                                        lAddressDetailsOwnerTypeID = Convert.ToInt64(myDataRowsPoints["ADDRESSOWNERTYPEID"]);
                                    }

                                    if (myDataRowsPoints["POSTALCODE"] != DBNull.Value)
                                    {
                                        strAddressDetailsPostalCode = myDataRowsPoints["POSTALCODE"].ToString();
                                    }

                                    if (myDataRowsPoints["PHYSICALADDRESS"] != DBNull.Value)
                                    {
                                        strAddressDetailsPhysicalAddress = myDataRowsPoints["PHYSICALADDRESS"].ToString();
                                    }

                                    if (myDataRowsPoints["POSTALADDRESS"] != DBNull.Value)
                                    {
                                        strAddressDetailsPostalAddress = myDataRowsPoints["POSTALADDRESS"].ToString();
                                    }

                                    if (myDataRowsPoints["COUNTRYID"] != DBNull.Value)
                                    {
                                        lAddressDetailsCountryID = Convert.ToInt64(myDataRowsPoints["COUNTRYID"]);
                                    }

                                    if (myDataRowsPoints["CITYID"] != DBNull.Value)
                                    {
                                        lAddressDetailsCityID = Convert.ToInt64(myDataRowsPoints["CITY"]);
                                    }

                                    if (myDataRowsPoints["COUNTYID"] != DBNull.Value)
                                    {
                                        lAddressDetailsCountyID = Convert.ToInt64(myDataRowsPoints["COUNTYID"]);
                                    }

                                    if (myDataRowsPoints["COUNSTITUENCYID"] != DBNull.Value)
                                    {
                                        lAddressDetailsConstituencyID = Convert.ToInt64(myDataRowsPoints["COUNSTITUENCYID"]);
                                    }

                                    if (myDataRowsPoints["PROVINCEID"] != DBNull.Value)
                                    {
                                        lAddressDetailsProvinceID = Convert.ToInt64(myDataRowsPoints["PROVINCEID"]);
                                    }

                                    if (myDataRowsPoints["DISTRICTID"] != DBNull.Value)
                                    {
                                        lAddressDetailsDistrictID = Convert.ToInt64(myDataRowsPoints["DISTRICTID"]);
                                    }

                                    if (myDataRowsPoints["DIVISIONID"] != DBNull.Value)
                                    {
                                        lAddressDetailsDivisionID = Convert.ToInt64(myDataRowsPoints["DIVISIONID"]);
                                    }

                                    if (myDataRowsPoints["LOCATIONID"] != DBNull.Value)
                                    {
                                        lAddressDetailsLocationID = Convert.ToInt64(myDataRowsPoints["LOCATIONID"]);
                                    }

                                    if (myDataRowsPoints["SUBLOCATIONID"] != DBNull.Value)
                                    {
                                        lAddressDetailsSublocationID = Convert.ToInt64(myDataRowsPoints["SUBLOCATIONID"]);
                                    }

                                    if (myDataRowsPoints["ESTATEID"] != DBNull.Value)
                                    {
                                        lAddressDetailsEstateID = Convert.ToInt64(myDataRowsPoints["ESTATEID"]);
                                    }

                                    if (myDataRowsPoints["HOUSENUMBER"] != DBNull.Value)
                                    {
                                        strAddressDetailsHouseNumber = myDataRowsPoints["ESTATEID"].ToString();
                                    }

                                    if (myDataRowsPoints["PHYSICALADDRESSCOORDINATE"] != DBNull.Value)
                                    {
                                        pPhysicalAddressCoordinate = (NpgsqlPoint)myDataRowsPoints["PHYSICALADDRESSCOORDINATE"];
                                    }

                                    if (myDataRowsPoints["SOCIALNETWORKUSERID"] != DBNull.Value)
                                    {
                                        strAddressDetailsSocialNetworkUserID = myDataRowsPoints["SOCIALNETWORKUSERID"].ToString();
                                    }

                                    if (myDataRowsPoints["TELEPHONE1"] != DBNull.Value)
                                    {
                                        strAddressDetailsTelephone1 = myDataRowsPoints["TELEPHONE1"].ToString();
                                    }

                                    if (myDataRowsPoints["TELEPHONE2"] != DBNull.Value)
                                    {
                                        strAddressDetailsTelephone2 = myDataRowsPoints["TELEPHONE2"].ToString();
                                    }

                                    if (myDataRowsPoints["MOBILEPHONE1"] != DBNull.Value)
                                    {
                                        strAddressDetailsMobilePhone1 = myDataRowsPoints["MOBILEPHONE1"].ToString();
                                    }

                                    if (myDataRowsPoints["MOBILEPHONE2"] != DBNull.Value)
                                    {
                                        strAddressDetailsMobilePhone2 = myDataRowsPoints["MOBILEPHONE2"].ToString();
                                    }

                                    if (myDataRowsPoints["FAX1"] != DBNull.Value)
                                    {
                                        strAddressDetailsFax1 = myDataRowsPoints["FAX1"].ToString();
                                    }

                                    if (myDataRowsPoints["FAX2"] != DBNull.Value)
                                    {
                                        strAddressDetailsFax2 = myDataRowsPoints["FAX2"].ToString();
                                    }

                                    if (myDataRowsPoints["COMPANYEMAIL"] != DBNull.Value)
                                    {
                                        strAddressDetailsCompanyEmail = myDataRowsPoints["COMPANYEMAIL"].ToString();
                                    }

                                    if (myDataRowsPoints["SALESEMAIL"] != DBNull.Value)
                                    {
                                        strAddressDetailsSalesEmail = myDataRowsPoints["SALESEMAIL"].ToString();
                                    }

                                    if (myDataRowsPoints["SUPPORTEMAIL"] != DBNull.Value)
                                    {
                                        strAddressDetailsSupportEmail = myDataRowsPoints["SUPPORTEMAIL"].ToString();
                                    }

                                    if (myDataRowsPoints["STATUSID"] != DBNull.Value)
                                    {
                                        lAddressDetailsStatusID = Convert.ToInt64(myDataRowsPoints["STATUSID"]);
                                    }

                                    if (myDataRowsPoints["UNIVERSALADDRESS"] != DBNull.Value)
                                    {
                                        strAddressDetailsUniversalAddress = myDataRowsPoints["UNIVERSALADDRESS"].ToString();
                                    }

                                    if (myDataRowsPoints["ROADID"] != DBNull.Value)
                                    {
                                        lAddressDetailsRoadID = Convert.ToInt64(myDataRowsPoints["ROADID"]);
                                    }

                                    if (myDataRowsPoints["PROJECTION"] != DBNull.Value)
                                    {
                                        strAddressDetailsProjection = myDataRowsPoints["PROJECTION"].ToString();
                                    }

                                    if (myDataRowsPoints["POINTNAME"] != DBNull.Value)
                                    {
                                        strAddressDetailsPointName = myDataRowsPoints["POINTNAME"].ToString();
                                    }

                                    if (myDataRowsPoints["BUILDINGID"] != DBNull.Value)
                                    {
                                        lAddressDetailsBuildingID = Convert.ToInt64(myDataRowsPoints["BUILDINGID"]);
                                    }

                                    if (myDataRowsPoints["ADDRESSROOTID"] != DBNull.Value)
                                    {
                                        lAddressDetailsRootID = Convert.ToInt64(myDataRowsPoints["ADDRESSROOTID"]);
                                    }

                                    if (myDataRowsPoints["APPARTMENTID"] != DBNull.Value)
                                    {
                                        lAddressDetailsAppartmentID = Convert.ToInt64(myDataRowsPoints["APPARTMENTID"]);
                                    }

                                    if (myDataRowsPoints["MAPID"] != DBNull.Value)
                                    {
                                        lAddressDetailsMapID = Convert.ToInt64(myDataRowsPoints["MAPID"]);
                                    }

                                    if (myDataRowsPoints["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsPoints["DATECREATED"]);
                                    }

                                    if (myDataRowsPoints["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsPoints["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsPoints["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsPoints["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsPoints["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsPoints["USERID"]);

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

        public bool ReturnLastAddressDetails()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getlastpointtypemaster()";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesPoints in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesPoints.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsPoints in myDataTablesPoints.Rows)
                                {
                                    if (myDataRowsPoints["ADDRESSDETAILSID"] != DBNull.Value)
                                    {
                                        lAddressDetailsID = Convert.ToInt64(myDataRowsPoints["ADDRESSDETAILSID"]);
                                    }

                                    if (myDataRowsPoints["ADDRESSOWNERID"] != DBNull.Value)
                                    {
                                        lAddressDetailsOwnerID = Convert.ToInt64(myDataRowsPoints["ADDRESSOWNERID"]);
                                    }

                                    if (myDataRowsPoints["ADDRESSOWNERTYPEID"] != DBNull.Value)
                                    {
                                        lAddressDetailsOwnerTypeID = Convert.ToInt64(myDataRowsPoints["ADDRESSOWNERTYPEID"]);
                                    }

                                    if (myDataRowsPoints["POSTALCODE"] != DBNull.Value)
                                    {
                                        strAddressDetailsPostalCode = myDataRowsPoints["POSTALCODE"].ToString();
                                    }

                                    if (myDataRowsPoints["PHYSICALADDRESS"] != DBNull.Value)
                                    {
                                        strAddressDetailsPhysicalAddress = myDataRowsPoints["PHYSICALADDRESS"].ToString();
                                    }

                                    if (myDataRowsPoints["POSTALADDRESS"] != DBNull.Value)
                                    {
                                        strAddressDetailsPostalAddress = myDataRowsPoints["POSTALADDRESS"].ToString();
                                    }

                                    if (myDataRowsPoints["COUNTRYID"] != DBNull.Value)
                                    {
                                        lAddressDetailsCountryID = Convert.ToInt64(myDataRowsPoints["COUNTRYID"]);
                                    }

                                    if (myDataRowsPoints["CITYID"] != DBNull.Value)
                                    {
                                        lAddressDetailsCityID = Convert.ToInt64(myDataRowsPoints["CITY"]);
                                    }

                                    if (myDataRowsPoints["COUNTYID"] != DBNull.Value)
                                    {
                                        lAddressDetailsCountyID = Convert.ToInt64(myDataRowsPoints["COUNTYID"]);
                                    }

                                    if (myDataRowsPoints["COUNSTITUENCYID"] != DBNull.Value)
                                    {
                                        lAddressDetailsConstituencyID = Convert.ToInt64(myDataRowsPoints["COUNSTITUENCYID"]);
                                    }

                                    if (myDataRowsPoints["PROVINCEID"] != DBNull.Value)
                                    {
                                        lAddressDetailsProvinceID = Convert.ToInt64(myDataRowsPoints["PROVINCEID"]);
                                    }

                                    if (myDataRowsPoints["DISTRICTID"] != DBNull.Value)
                                    {
                                        lAddressDetailsDistrictID = Convert.ToInt64(myDataRowsPoints["DISTRICTID"]);
                                    }

                                    if (myDataRowsPoints["DIVISIONID"] != DBNull.Value)
                                    {
                                        lAddressDetailsDivisionID = Convert.ToInt64(myDataRowsPoints["DIVISIONID"]);
                                    }

                                    if (myDataRowsPoints["LOCATIONID"] != DBNull.Value)
                                    {
                                        lAddressDetailsLocationID = Convert.ToInt64(myDataRowsPoints["LOCATIONID"]);
                                    }

                                    if (myDataRowsPoints["SUBLOCATIONID"] != DBNull.Value)
                                    {
                                        lAddressDetailsSublocationID = Convert.ToInt64(myDataRowsPoints["SUBLOCATIONID"]);
                                    }

                                    if (myDataRowsPoints["ESTATEID"] != DBNull.Value)
                                    {
                                        lAddressDetailsEstateID = Convert.ToInt64(myDataRowsPoints["ESTATEID"]);
                                    }

                                    if (myDataRowsPoints["HOUSENUMBER"] != DBNull.Value)
                                    {
                                        strAddressDetailsHouseNumber = myDataRowsPoints["ESTATEID"].ToString();
                                    }

                                    if (myDataRowsPoints["PHYSICALADDRESSCOORDINATE"] != DBNull.Value)
                                    {
                                        pPhysicalAddressCoordinate = (NpgsqlPoint)myDataRowsPoints["PHYSICALADDRESSCOORDINATE"];
                                    }

                                    if (myDataRowsPoints["SOCIALNETWORKUSERID"] != DBNull.Value)
                                    {
                                        strAddressDetailsSocialNetworkUserID = myDataRowsPoints["SOCIALNETWORKUSERID"].ToString();
                                    }

                                    if (myDataRowsPoints["TELEPHONE1"] != DBNull.Value)
                                    {
                                        strAddressDetailsTelephone1 = myDataRowsPoints["TELEPHONE1"].ToString();
                                    }

                                    if (myDataRowsPoints["TELEPHONE2"] != DBNull.Value)
                                    {
                                        strAddressDetailsTelephone2 = myDataRowsPoints["TELEPHONE2"].ToString();
                                    }

                                    if (myDataRowsPoints["MOBILEPHONE1"] != DBNull.Value)
                                    {
                                        strAddressDetailsMobilePhone1 = myDataRowsPoints["MOBILEPHONE1"].ToString();
                                    }

                                    if (myDataRowsPoints["MOBILEPHONE2"] != DBNull.Value)
                                    {
                                        strAddressDetailsMobilePhone2 = myDataRowsPoints["MOBILEPHONE2"].ToString();
                                    }

                                    if (myDataRowsPoints["FAX1"] != DBNull.Value)
                                    {
                                        strAddressDetailsFax1 = myDataRowsPoints["FAX1"].ToString();
                                    }

                                    if (myDataRowsPoints["FAX2"] != DBNull.Value)
                                    {
                                        strAddressDetailsFax2 = myDataRowsPoints["FAX2"].ToString();
                                    }

                                    if (myDataRowsPoints["COMPANYEMAIL"] != DBNull.Value)
                                    {
                                        strAddressDetailsCompanyEmail = myDataRowsPoints["COMPANYEMAIL"].ToString();
                                    }

                                    if (myDataRowsPoints["SALESEMAIL"] != DBNull.Value)
                                    {
                                        strAddressDetailsSalesEmail = myDataRowsPoints["SALESEMAIL"].ToString();
                                    }

                                    if (myDataRowsPoints["SUPPORTEMAIL"] != DBNull.Value)
                                    {
                                        strAddressDetailsSupportEmail = myDataRowsPoints["SUPPORTEMAIL"].ToString();
                                    }

                                    if (myDataRowsPoints["STATUSID"] != DBNull.Value)
                                    {
                                        lAddressDetailsStatusID = Convert.ToInt64(myDataRowsPoints["STATUSID"]);
                                    }

                                    if (myDataRowsPoints["UNIVERSALADDRESS"] != DBNull.Value)
                                    {
                                        strAddressDetailsUniversalAddress = myDataRowsPoints["UNIVERSALADDRESS"].ToString();
                                    }

                                    if (myDataRowsPoints["ROADID"] != DBNull.Value)
                                    {
                                        lAddressDetailsRoadID = Convert.ToInt64(myDataRowsPoints["ROADID"]);
                                    }

                                    if (myDataRowsPoints["PROJECTION"] != DBNull.Value)
                                    {
                                        strAddressDetailsProjection = myDataRowsPoints["PROJECTION"].ToString();
                                    }

                                    if (myDataRowsPoints["POINTNAME"] != DBNull.Value)
                                    {
                                        strAddressDetailsPointName = myDataRowsPoints["POINTNAME"].ToString();
                                    }

                                    if (myDataRowsPoints["BUILDINGID"] != DBNull.Value)
                                    {
                                        lAddressDetailsBuildingID = Convert.ToInt64(myDataRowsPoints["BUILDINGID"]);
                                    }

                                    if (myDataRowsPoints["ADDRESSROOTID"] != DBNull.Value)
                                    {
                                        lAddressDetailsRootID = Convert.ToInt64(myDataRowsPoints["ADDRESSROOTID"]);
                                    }

                                    if (myDataRowsPoints["APPARTMENTID"] != DBNull.Value)
                                    {
                                        lAddressDetailsAppartmentID = Convert.ToInt64(myDataRowsPoints["APPARTMENTID"]);
                                    }

                                    if (myDataRowsPoints["MAPID"] != DBNull.Value)
                                    {
                                        lAddressDetailsMapID = Convert.ToInt64(myDataRowsPoints["MAPID"]);
                                    }

                                    if (myDataRowsPoints["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsPoints["DATECREATED"]);
                                    }

                                    if (myDataRowsPoints["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsPoints["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsPoints["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsPoints["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsPoints["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsPoints["USERID"]);

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

        public bool SaveAddressDetails()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            //Make text Postgres compatible
            strAddressDetailsPointName = strAddressDetailsPointName.Replace("'", "''");
            strAddressDetailsPostalAddress = strAddressDetailsPostalAddress.Replace("'", "''");
            strAddressDetailsPostalCode = strAddressDetailsPostalCode.Replace("'", "''");
            strAddressDetailsProjection = strAddressDetailsProjection.Replace("'", "''");
            strAddressDetailsSalesEmail = strAddressDetailsSalesEmail.Replace("'", "''");
            strAddressDetailsSupportEmail = strAddressDetailsSupportEmail.Replace("'", "''");
            strAddressDetailsCompanyEmail = strAddressDetailsCompanyEmail.Replace("'", "''");
            strAddressDetailsHouseNumber = strAddressDetailsHouseNumber.Replace("'", "''");
            strAddressDetailsTelephone1 = strAddressDetailsTelephone1.Replace("'", "''");
            strAddressDetailsUniversalAddress = strAddressDetailsUniversalAddress.Replace("'", "''");
            strAddressDetailsFax1 = strAddressDetailsFax1.Replace("'", "''");
            strAddressDetailsFax2 = strAddressDetailsFax2.Replace("'", "''");

            strAddressDetailsPointName = strAddressDetailsPointName.Replace("\\", "\\\\");
            strAddressDetailsPostalAddress = strAddressDetailsPostalAddress.Replace("\\", "\\\\");
            strAddressDetailsPostalCode = strAddressDetailsPostalCode.Replace("\\", "\\\\");
            strAddressDetailsProjection = strAddressDetailsProjection.Replace("\\", "\\\\");
            strAddressDetailsSalesEmail = strAddressDetailsSalesEmail.Replace("\\", "\\\\");
            strAddressDetailsSupportEmail = strAddressDetailsSupportEmail.Replace("\\", "\\\\");
            strAddressDetailsCompanyEmail = strAddressDetailsCompanyEmail.Replace("\\", "\\\\");
            strAddressDetailsHouseNumber = strAddressDetailsHouseNumber.Replace("\\", "\\\\");
            strAddressDetailsTelephone1 = strAddressDetailsTelephone1.Replace("\\", "\\\\");
            strAddressDetailsTelephone2 = strAddressDetailsTelephone2.Replace("\\", "\\\\");
            strAddressDetailsUniversalAddress = strAddressDetailsUniversalAddress.Replace("\\", "\\\\");
            strAddressDetailsFax1 = strAddressDetailsFax1.Replace("\\", "\\\\");
            strAddressDetailsFax2 = strAddressDetailsFax2.Replace("\\", "\\\\");


            try
            {
                strQuery = "SELECT  trip_func_insertupdatecaptureadressdetails(" +
                lAddressDetailsID + "," +
                lAddressDetailsOwnerID + ",'" +
                strAddressDetailsPostalCode + "','" +
                strAddressDetailsPhysicalAddress + "','" +
                strAddressDetailsPostalAddress + "'," +
                lAddressDetailsCountryID + "," +
                lAddressDetailsCityID + "," +
                lAddressDetailsCountyID + "," +
                lAddressDetailsConstituencyID + "," +
                lAddressDetailsProvinceID + "," +
                lAddressDetailsDistrictID + "," +
                lAddressDetailsDivisionID + "," +
                lAddressDetailsLocationID + "," +
                lAddressDetailsSublocationID + "," +
                lAddressDetailsEstateID + ",'" +
                strAddressDetailsHouseNumber + "','(" +
                pPhysicalAddressCoordinate.X + "," + pPhysicalAddressCoordinate.Y + ")'," +
                lAddressDetailsOwnerTypeID + ",'" +
                strAddressDetailsSocialNetworkUserID + "','" +
                strAddressDetailsTelephone1 + "','" +
                strAddressDetailsTelephone2 + "','" +
                strAddressDetailsMobilePhone1 + "','" +
                strAddressDetailsMobilePhone2 + "','" +
                strAddressDetailsFax1 + "','" +
                strAddressDetailsFax2 + "','" +
                strAddressDetailsCompanyEmail + "','" +
                strAddressDetailsSalesEmail + "','" +
                strAddressDetailsSupportEmail + "'," +
                lAddressDetailsStatusID + ",'" +
                strAddressDetailsUniversalAddress + "'," +
                lAddressDetailsRoadID + ",'" +
                strAddressDetailsProjection + "','" +
                strAddressDetailsPointName + "'," +
                lAddressDetailsBuildingID + "," +
                lAddressDetailsRootID + "," +
                lAddressDetailsAppartmentID + "," +
                lAddressDetailsMapID + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesAddress in objLogin.PGDataSet.Tables)
                        {
                            //Check if there is any data. If not exit
                            if (myDataTablesAddress.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;
                            }
                            else
                            {
                                datAddressDetails = objLogin.PGDataSet;
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

        public bool CheckIfMapIDExistsInDatabase()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                if (lAddressDetailsMapID > 0)
                {
                    strQuery = "SELECT * FROM trip_func_checkifaddressmapidexists(" + lAddressDetailsMapID + ")";

                    bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                    if (datRetData == null)
                    {
                        return false;
                    }
                    else
                    {
                        if (bQuerySuccess == true)
                        {

                            foreach (DataTable myDataTablesAddressDetail in objLogin.PGDataSet.Tables)
                            {
                                //Check if there is any data. If not exit
                                if (myDataTablesAddressDetail.Rows.Count == 0)
                                {
                                    //Return a value indicating that the search was not successful
                                    return false;
                                }
                                else
                                {

                                    foreach (DataRow myDataRowsAddressDetails in myDataTablesAddressDetail.Rows)
                                    {
                                        if (myDataRowsAddressDetails[0] != DBNull.Value)
                                        {
                                            lAddressDetailsMapID = Convert.ToInt64(myDataRowsAddressDetails[0]);
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




        #endregion


    }
}
