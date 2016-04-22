using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace TRIP_API
{
    public class IMPrivateCustomer : IMCustomer
    {

        private string errMessage;

        private string strTitle = "";
        private string strSurname = "";
        private string strFirstName = "";
        private string strMiddleName = "";
        private string strOtherName = "";
        private long lSex = 0;
        private long lHeight = 0;
        private long lPhysicalCustomerID = 0;
        private long lErrorCheck = 0;


        #region "Properties"

        public long ErrorCheck
        {


            get { return lErrorCheck; }

            set { lErrorCheck = value; }
        }

        public string Title
        {


            get { return strTitle; }

            set { strTitle = value; }
        }

        public string Surname
        {


            get { return strSurname; }

            set { strSurname = value; }
        }

        public string FirstName
        {


            get { return strFirstName; }

            set { strFirstName = value; }
        }

        public string MiddleName
        {


            get { return strMiddleName; }

            set { strMiddleName = value; }
        }

        public string OtherName
        {


            get { return strOtherName; }

            set { strOtherName = value; }
        }

        public long Sex
        {


            get { return lSex; }

            set { lSex = value; }
        }

        public long Height
        {


            get { return lHeight; }

            set { lHeight = value; }
        }

        public long PhysicalCustomerID
        {


            get { return lPhysicalCustomerID; }

            set { lPhysicalCustomerID = value; }
        }


        #endregion


        //region "InitializationProcedures"

        public IMPrivateCustomer()
        {

            CustomerNo = 0;
            CustomerSerialNumber = "";
            CustomerPriorityID = "";
            CustomerTypeID = 0;
            PINNo = "";
            EmailAddress = "";
            MainPhoneNumber = "";
            MobilePhoneNumber = "";
            MobilePhoneNumber = "";
            CountryOfBirthID = 0;
            lSex = 0;
            strOtherName = "";
            strMiddleName = "";
            strFirstName = "";
            strSurname = "";
            UserName = "";
            UserPassword = "";
            ConfirmPassword = "";
            Height = 0;
            AddressDetailsID = 0;
            AddressDetailsOwnerID = 0;
            AddressDetailsPostalCode = "";
            AddressDetailsPhysicalAddress = "";
            AddressDetailsPostalAddress = "";
            AddressDetailsCountryID = 0;
            AddressDetailsCityID = 0;
            AddressDetailsCountyID = 0;
            AddressDetailsConstituencyID = 0;
            AddressDetailsProvinceID = 0;
            AddressDetailsDistrictID = 0;
            AddressDetailsDivisionID = 0;
            AddressDetailsLocationID = 0;
            AddressDetailsSublocationID = 0;
            AddressDetailsEstateID = 0;
            AddressDetailsHouseNumber = "";
            AddressDetailsOwnerTypeID = 0;
            AddressDetailsSocialNetworkUserID = "";
            AddressDetailsTelephone1 = "";
            AddressDetailsTelephone2 = "";
            AddressDetailsMobilePhone1 = "";
            AddressDetailsMobilePhone2 = "";
            AddressDetailsFax1 = "";
            AddressDetailsFax2 = "";
            AddressDetailsCompanyEmail = "";
            AddressDetailsSalesEmail = "";
            AddressDetailsSupportEmail = "";
            AddressDetailsStatusID = 0;
            AddressDetailsUniversalAddress = "";
            AddressDetailsRoadID = 0;
            AddressDetailsProjection = "";
            AddressDetailsPointName = "";
            AddressDetailsBuildingID = 0;
            AddressDetailsRootID = 0;
            AddressDetailsAppartmentID = 0;
            AddressDetailsMapID = 0;            

        }



        #region "DatabaseProcedures"

        public bool QueryFind(string strQuery, bool bReturnData)
        {

            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();

            try
            {

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesPrivateCustomer in datRetData.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesPrivateCustomer.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;
                            }
                            else
                            {

                                if (bReturnData == true)
                                {

                                    foreach (DataRow myDataRowsPrivateCustomer in myDataTablesPrivateCustomer.Rows)
                                    {

                                        strTitle = myDataRowsPrivateCustomer["TITLE"].ToString();
                                        strSurname = myDataRowsPrivateCustomer["SURNAME"].ToString();
                                        strFirstName = myDataRowsPrivateCustomer["FIRSTNAME"].ToString();
                                        strMiddleName = myDataRowsPrivateCustomer["MIDDLENAME"].ToString();
                                        strOtherName = myDataRowsPrivateCustomer["OTHERNAME"].ToString();
                                        lSex = Convert.ToInt64(myDataRowsPrivateCustomer["SEX"]);

                                        CustomerNo = Convert.ToInt64(myDataRowsPrivateCustomer["CUSTOMERNO"]);
                                        DateOfBirth = Convert.ToDateTime(myDataRowsPrivateCustomer["DATEOFBIRTH"]);
                                        PINNo = myDataRowsPrivateCustomer["PINNO"].ToString();
                                        CustomerTypeID = Convert.ToInt64(myDataRowsPrivateCustomer["CUSTOMERTYPEID"]);
                                        CustomerPriorityID = myDataRowsPrivateCustomer["CUSTPRIORITYID"].ToString();
                                        DateCreated = Convert.ToDateTime(myDataRowsPrivateCustomer["DATECREATED"]);
                                        DateRegistered = Convert.ToDateTime(myDataRowsPrivateCustomer["DATEREGISTERED"]);
                                        DateDeRegistered = Convert.ToDateTime(myDataRowsPrivateCustomer["DATEDEREGISTERED"]);
                                        CustomerSerialNumber = myDataRowsPrivateCustomer["CUSTOMERSNO"].ToString();

                                        UserID = Convert.ToInt64(myDataRowsPrivateCustomer["USERID"]);

                                    }

                                }
                                else
                                {
                                    return false;
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
                errMessage = ex.Message + " : Source = " + ex.Source;
                return false;
            }

            finally
            {
                datRetData = null;

                objLogin = null;

            }
        }

        public bool ReturnPrivateCustomerMasterByCustomerNumber(long lExactValues, long lLimit, long lOffset, bool bReturnData)
        {

            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            CustomerPINNumber = "";
            CustomerPriorityID = "";
            CustomerSerialNumber = "";
            CustomerTypeID = 0;
            EmailAddress = "";
            MainPhoneNumber = "";
            MobilePhoneNumber = "";

            try
            {
                strQuery = "SELECT * FROM trip_func_getprivatecustomermasterbycustomerno (" +
                    CustomerNo + "," + lExactValues + "," + lLimit + "," + lOffset + ") AS " +
                    "(CUSTOMERNO int4, CUSTOMERSNO varchar, DATEOFBIRTH timestamp with time zone," +
                    "PINNO varchar, CUSTPRIORITYID varchar, " +
                    "CUSTOMERMASTERDATECREATED timestamp with time zone, CUSTOMERMASTERDATEREGISTERED timestamp with time zone, " +
                    "CUSTOMERMASTERDATEDEREGISTERED timestamp with time zone, CUSTOMERCOATRADEDEBTORS int4, USERID int4, " +
                    "CUSTOMERTYPEID int4, COUNTRYOFBIRTHID int4, TITLE varchar, SURNAME varchar, FIRSTNAME varchar, " +
                    "MIDDLENAME varchar, OTHERNAME text, SEX int4, HEIGHT real, CUSTOMERCITIZENSHIPCOUNTRYID int4, " +
                    "MAINCITIZENSHIP int4, CITIZENSHIPDATECREATED timestamp with time zone, " +
                    "CUSTOMERCITIZENSHIPDATEREGISTERED date, CUSTOMERCITIZENSHIPDATEDEREGISTERED date, " +
                    "ADDRESSDETAILSUNIVERSALLADDRESS varchar, COMPANYEMAIL varchar, SALESEMAIL varchar, " +
                    "TELEPHONE1 varchar, TELEPHONE2 varchar, MOBILEPHONE1 varchar, MOBILEPHONE2 varchar, " +
                    "FAX1 varchar, FAX2 varchar, ADDRESSDETAILSCOUNTRYID int4, ADDRESSDETAILSCITYID int4, " +
                    "ADDRESSDETAILSPROVINCEID int4, ADDRESSDETAILSDISTRICTID int4, ADDRESSDETAILSDIVISIONID int4, " +
                    "ADDRESSDETAILSLOCATIONID int4, ADDRESSDETAILSSUBLOCATIONID int4, ADDRESSDETAILSCONSITUENCYID int4, " +
                    "ADDRESSDETAILSCOUNTYID int4, ADDRESSDETAILSPOSTALADDRESS text, ADDRESSDETAILSPOSTALCODE varchar, " +
                    "ADDRESSDETAILSID int4, PHYSICALADDRESSCOORDINATE point, HOUSENUMBER varchar, BUILDINGID int4)";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesPrivateCustomer in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesPrivateCustomer.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                if (bReturnData == true)
                                {

                                    foreach (DataRow myDataRowsPrivateCustomer in myDataTablesPrivateCustomer.Rows)
                                    {
                                        if (myDataRowsPrivateCustomer["TITLE"] != DBNull.Value)
                                        {
                                            strTitle = myDataRowsPrivateCustomer["TITLE"].ToString();
                                        }

                                        if (myDataRowsPrivateCustomer["SURNAME"] != DBNull.Value)
                                        {
                                            strSurname = myDataRowsPrivateCustomer["SURNAME"].ToString();
                                        }

                                        if (myDataRowsPrivateCustomer["FIRSTNAME"] != DBNull.Value)
                                        {

                                            strFirstName = myDataRowsPrivateCustomer["FIRSTNAME"].ToString();

                                        }

                                        if (myDataRowsPrivateCustomer["MIDDLENAME"] != DBNull.Value)
                                        {

                                            strMiddleName = myDataRowsPrivateCustomer["MIDDLENAME"].ToString();

                                        }

                                        if (myDataRowsPrivateCustomer["OTHERNAME"] != DBNull.Value)
                                        {

                                            strOtherName = myDataRowsPrivateCustomer["OTHERNAME"].ToString();

                                        }

                                        if (myDataRowsPrivateCustomer["SEX"] != DBNull.Value)
                                        {

                                            lSex = Convert.ToInt64(myDataRowsPrivateCustomer["SEX"]);

                                        }

                                        if (myDataRowsPrivateCustomer["CUSTOMERNO"] != DBNull.Value)
                                        {

                                            CustomerNo = Convert.ToInt64(myDataRowsPrivateCustomer["CUSTOMERNO"]);

                                        }

                                        if (myDataRowsPrivateCustomer["DATEOFBIRTH"] != DBNull.Value)
                                        {

                                            DateOfBirth = Convert.ToDateTime(myDataRowsPrivateCustomer["DATEOFBIRTH"]);

                                        }

                                        if (myDataRowsPrivateCustomer["PINNO"] != DBNull.Value)
                                        {

                                            PINNo = myDataRowsPrivateCustomer["PINNO"].ToString();
                                            CustomerPINNumber = myDataRowsPrivateCustomer["PINNO"].ToString();

                                        }

                                        if (myDataRowsPrivateCustomer["CUSTOMERTYPEID"] != DBNull.Value)
                                        {

                                            CustomerTypeID = Convert.ToInt64(myDataRowsPrivateCustomer["CUSTOMERTYPEID"]);

                                        }

                                        if (myDataRowsPrivateCustomer["CUSTPRIORITYID"] != DBNull.Value)
                                        {

                                            CustomerPriorityID = myDataRowsPrivateCustomer["CUSTPRIORITYID"].ToString();

                                        }

                                        if (myDataRowsPrivateCustomer["CUSTOMERMASTERDATECREATED"] != DBNull.Value)
                                        {

                                            DateCreated = Convert.ToDateTime(myDataRowsPrivateCustomer["CUSTOMERMASTERDATECREATED"]);


                                        }


                                        if (myDataRowsPrivateCustomer["CUSTOMERMASTERDATEREGISTERED"] != DBNull.Value)
                                        {

                                            DateRegistered = Convert.ToDateTime(myDataRowsPrivateCustomer["CUSTOMERMASTERDATEREGISTERED"]);

                                        }

                                        if (myDataRowsPrivateCustomer["CUSTOMERMASTERDATEDEREGISTERED"] != DBNull.Value)
                                        {

                                            DateDeRegistered = Convert.ToDateTime(myDataRowsPrivateCustomer["CUSTOMERMASTERDATEDEREGISTERED"]);

                                        }

                                        if (myDataRowsPrivateCustomer["CUSTOMERSNO"] != DBNull.Value)
                                        {

                                            CustomerSerialNumber = myDataRowsPrivateCustomer["CUSTOMERSNO"].ToString();

                                        }

                                        if (myDataRowsPrivateCustomer["COUNTRYOFBIRTHID"] != DBNull.Value)
                                        {

                                            CountryOfBirthID = Convert.ToInt64(myDataRowsPrivateCustomer["COUNTRYOFBIRTHID"]);

                                        }

                                        if (myDataRowsPrivateCustomer["COMPANYEMAIL"] != DBNull.Value)
                                        {

                                            AddressDetailsCompanyEmail = myDataRowsPrivateCustomer["COMPANYEMAIL"].ToString();

                                        }

                                        if (myDataRowsPrivateCustomer["SALESEMAIL"] != DBNull.Value)
                                        {

                                            AddressDetailsSalesEmail = myDataRowsPrivateCustomer["SALESEMAIL"].ToString();

                                        }

                                        if (myDataRowsPrivateCustomer["TELEPHONE1"] != DBNull.Value)
                                        {

                                            AddressDetailsTelephone1 = myDataRowsPrivateCustomer["TELEPHONE1"].ToString();

                                        }

                                        if (myDataRowsPrivateCustomer["TELEPHONE2"] != DBNull.Value)
                                        {

                                            AddressDetailsTelephone2 = myDataRowsPrivateCustomer["TELEPHONE2"].ToString();

                                        }

                                        if (myDataRowsPrivateCustomer["MOBILEPHONE1"] != DBNull.Value)
                                        {

                                            AddressDetailsMobilePhone1 = myDataRowsPrivateCustomer["MOBILEPHONE1"].ToString();

                                        }

                                        if (myDataRowsPrivateCustomer["MOBILEPHONE2"] != DBNull.Value)
                                        {

                                            AddressDetailsMobilePhone2 = myDataRowsPrivateCustomer["MOBILEPHONE2"].ToString();

                                        }

                                        if (myDataRowsPrivateCustomer["FAX1"] != DBNull.Value)
                                        {

                                            AddressDetailsFax1 = myDataRowsPrivateCustomer["FAX1"].ToString();

                                        }

                                        if (myDataRowsPrivateCustomer["FAX2"] != DBNull.Value)
                                        {

                                            AddressDetailsFax2 = myDataRowsPrivateCustomer["FAX2"].ToString();

                                        }

                                        if (myDataRowsPrivateCustomer["ADDRESSDETAILSCOUNTRYID"] != DBNull.Value)
                                        {

                                            AddressDetailsCountryID = Convert.ToInt64(myDataRowsPrivateCustomer["ADDRESSDETAILSCOUNTRYID"]);

                                        }

                                        if (myDataRowsPrivateCustomer["ADDRESSDETAILSCITYID"] != DBNull.Value)
                                        {

                                            AddressDetailsCityID = Convert.ToInt64(myDataRowsPrivateCustomer["ADDRESSDETAILSCITYID"]);

                                        }

                                        if (myDataRowsPrivateCustomer["ADDRESSDETAILSPROVINCEID"] != DBNull.Value)
                                        {

                                            AddressDetailsProvinceID = Convert.ToInt64(myDataRowsPrivateCustomer["ADDRESSDETAILSPROVINCEID"]);

                                        }

                                        if (myDataRowsPrivateCustomer["ADDRESSDETAILSDISTRICTID"] != DBNull.Value)
                                        {

                                            AddressDetailsDistrictID = Convert.ToInt64(myDataRowsPrivateCustomer["ADDRESSDETAILSDISTRICTID"]);

                                        }

                                        if (myDataRowsPrivateCustomer["ADDRESSDETAILSDIVISIONID"] != DBNull.Value)
                                        {

                                            AddressDetailsDivisionID = Convert.ToInt64(myDataRowsPrivateCustomer["ADDRESSDETAILSDIVISIONID"]);

                                        }

                                        if (myDataRowsPrivateCustomer["ADDRESSDETAILSLOCATIONID"] != DBNull.Value)
                                        {

                                            AddressDetailsLocationID = Convert.ToInt64(myDataRowsPrivateCustomer["ADDRESSDETAILSLOCATIONID"]);

                                        }

                                        if (myDataRowsPrivateCustomer["ADDRESSDETAILSSUBLOCATIONID"] != DBNull.Value)
                                        {

                                            AddressDetailsSublocationID = Convert.ToInt64(myDataRowsPrivateCustomer["ADDRESSDETAILSSUBLOCATIONID"]);

                                        }

                                        if (myDataRowsPrivateCustomer["ADDRESSDETAILSCONSITUENCYID"] != DBNull.Value)
                                        {

                                            AddressDetailsConstituencyID = Convert.ToInt64(myDataRowsPrivateCustomer["ADDRESSDETAILSCONSITUENCYID"]);

                                        }

                                        if (myDataRowsPrivateCustomer["ADDRESSDETAILSCOUNTYID"] != DBNull.Value)
                                        {

                                            AddressDetailsCountyID = Convert.ToInt64(myDataRowsPrivateCustomer["ADDRESSDETAILSCOUNTYID"]);

                                        }

                                        if (myDataRowsPrivateCustomer["ADDRESSDETAILSPOSTALADDRESS"] != DBNull.Value)
                                        {

                                            AddressDetailsPostalAddress =
                                                myDataRowsPrivateCustomer["ADDRESSDETAILSPOSTALADDRESS"].ToString();

                                        }

                                        if (myDataRowsPrivateCustomer["ADDRESSDETAILSPOSTALCODE"] != DBNull.Value)
                                        {

                                            AddressDetailsPostalCode =
                                                myDataRowsPrivateCustomer["ADDRESSDETAILSPOSTALCODE"].ToString();

                                        }

                                        if (myDataRowsPrivateCustomer["ADDRESSDETAILSID"] != DBNull.Value)
                                        {

                                            AddressDetailsID = Convert.ToInt64(myDataRowsPrivateCustomer["ADDRESSDETAILSID"]);

                                        }

                                        if (myDataRowsPrivateCustomer["PHYSICALADDRESSCOORDINATE"] != DBNull.Value)
                                        {

                                            PhysicalAddressCoordinate = (NpgsqlTypes.NpgsqlPoint)myDataRowsPrivateCustomer["PHYSICALADDRESSCOORDINATE"];

                                        }

                                        if (myDataRowsPrivateCustomer["BUILDINGID"] != DBNull.Value)
                                        {

                                            AddressDetailsBuildingID = Convert.ToInt64(myDataRowsPrivateCustomer["BUILDINGID"]);

                                        }


                                        //if (myDataRowsPrivateCustomer["USERID"] != DBNull.Value)
                                        //{

                                        //UserID = Convert.ToInt64(myDataRowsPrivateCustomer["USERID"]);

                                        //}

                                    }

                                }
                                else
                                {
                                    return false;
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

        public bool ReturnPrivateCustomerMasterByCustomerNames(long lExactValues, long lLimit, long lOffset, bool bReturnData)
        {

            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            CustomerPINNumber = "";
            CustomerPriorityID = "";
            CustomerSerialNumber = "";
            CustomerTypeID = 0;
            EmailAddress = "";
            MainPhoneNumber = "";
            MobilePhoneNumber = "";

            try
            {
                strQuery = "SELECT * FROM trip_func_getprivatecustomermasterbycustomername (" +
                    FirstName + " " + MiddleName + " " + Surname + " " + OtherName + "," + lExactValues + "," + lLimit + "," + lOffset + ") AS " +
                    "(CUSTOMERNO int4,CUSTOMERSNO varchar,DATEOFBIRTH timestamp with time zone," +
                    "PINNO varchar, CUSTPRIORITYID varchar, " +
                    "CUSTOMERMASTERDATECREATED timestamp with time zone, CUSTOMERMASTERDATEREGISTERED timestamp with time zone, " +
                    "CUSTOMERMASTERDATEDEREGISTERED timestamp with time zone, CUSTOMERCOATRADEDEBTORS int4, USERID int4, " +
                    "CUSTOMERTYPEID int4, COUNTRYOFBIRTHID int4, TITLE varchar, SURNAME varchar, FIRSTNAME varchar, " +
                    "MIDDLENAME varchar, OTHERNAME text, SEX int4, HEIGHT real,CUSTOMERCITIZENSHIPCOUNTRYID int4, " +
                    "MAINCITIZENSHIP int4,CITIZENSHIPDATECREATED timestamp with time zone, " +
                    "CUSTOMERCITIZENSHIPDATEREGISTERED date,CUSTOMERCITIZENSHIPDATEDEREGISTERED date, " +
                    "ADDRESSDETAILSUNIVERSALLADDRESS varchar, COMPANYEMAIL varchar,SALESEMAIL varchar, " +
                    "TELEPHONE1 varchar,TELEPHONE2 varchar, MOBILEPHONE1 varchar, MOBILEPHONE2 varchar, " +
                    "FAX1 varchar,FAX2 varchar,ADDRESSDETAILSCOUNTRYID int4, ADDRESSDETAILSCITYID int4, " +
                    "ADDRESSDETAILSPROVINCEID int4, ADDRESSDETAILSDISTRICTID int4, ADDRESSDETAILSDIVISIONID int4, " +
                    "ADDRESSDETAILSLOCATIONID int4, ADDRESSDETAILSSUBLOCATIONID int4, ADDRESSDETAILSCONSITUENCYID int4, " +
                    "ADDRESSDETAILSCOUNTYID int4, ADDRESSDETAILSPOSTALADDRESS text, ADDRESSDETAILSPOSTALCODE varchar, " +
                    "ADDRESSDETAILSID int4,PHYSICALADDRESSCOORDINATE point,HOUSENUMBER varchar,BUILDINGID int4)";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesPrivateCustomer in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesPrivateCustomer.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                if (bReturnData == true)
                                {

                                    foreach (DataRow myDataRowsPrivateCustomer in myDataTablesPrivateCustomer.Rows)
                                    {
                                        if (myDataRowsPrivateCustomer["TITLE"] != DBNull.Value)
                                        {
                                            strTitle = myDataRowsPrivateCustomer["TITLE"].ToString();
                                        }

                                        if (myDataRowsPrivateCustomer["SURNAME"] != DBNull.Value)
                                        {
                                            strSurname = myDataRowsPrivateCustomer["SURNAME"].ToString();
                                        }

                                        if (myDataRowsPrivateCustomer["FIRSTNAME"] != DBNull.Value)
                                        {

                                            strFirstName = myDataRowsPrivateCustomer["FIRSTNAME"].ToString();

                                        }

                                        if (myDataRowsPrivateCustomer["MIDDLENAME"] != DBNull.Value)
                                        {

                                            strMiddleName = myDataRowsPrivateCustomer["MIDDLENAME"].ToString();

                                        }

                                        if (myDataRowsPrivateCustomer["OTHERNAME"] != DBNull.Value)
                                        {

                                            strOtherName = myDataRowsPrivateCustomer["OTHERNAME"].ToString();

                                        }

                                        if (myDataRowsPrivateCustomer["SEX"] != DBNull.Value)
                                        {

                                            lSex = Convert.ToInt64(myDataRowsPrivateCustomer["SEX"]);

                                        }

                                        if (myDataRowsPrivateCustomer["CUSTOMERNO"] != DBNull.Value)
                                        {

                                            CustomerNo = Convert.ToInt64(myDataRowsPrivateCustomer["CUSTOMERNO"]);

                                        }

                                        if (myDataRowsPrivateCustomer["DATEOFBIRTH"] != DBNull.Value)
                                        {

                                            DateOfBirth = Convert.ToDateTime(myDataRowsPrivateCustomer["DATEOFBIRTH"]);

                                        }

                                        if (myDataRowsPrivateCustomer["PINNO"] != DBNull.Value)
                                        {

                                            PINNo = myDataRowsPrivateCustomer["PINNO"].ToString();
                                            CustomerPINNumber = myDataRowsPrivateCustomer["PINNO"].ToString();

                                        }

                                        if (myDataRowsPrivateCustomer["CUSTOMERTYPEID"] != DBNull.Value)
                                        {

                                            CustomerTypeID = Convert.ToInt64(myDataRowsPrivateCustomer["CUSTOMERTYPEID"]);

                                        }

                                        if (myDataRowsPrivateCustomer["CUSTPRIORITYID"] != DBNull.Value)
                                        {

                                            CustomerPriorityID = myDataRowsPrivateCustomer["CUSTPRIORITYID"].ToString();

                                        }

                                        if (myDataRowsPrivateCustomer["CUSTOMERMASTERDATECREATED"] != DBNull.Value)
                                        {

                                            DateCreated = Convert.ToDateTime(myDataRowsPrivateCustomer["CUSTOMERMASTERDATECREATED"]);


                                        }


                                        if (myDataRowsPrivateCustomer["CUSTOMERMASTERDATEREGISTERED"] != DBNull.Value)
                                        {

                                            DateRegistered = Convert.ToDateTime(myDataRowsPrivateCustomer["CUSTOMERMASTERDATEREGISTERED"]);

                                        }

                                        if (myDataRowsPrivateCustomer["CUSTOMERMASTERDATEDEREGISTERED"] != DBNull.Value)
                                        {

                                            DateDeRegistered = Convert.ToDateTime(myDataRowsPrivateCustomer["CUSTOMERMASTERDATEDEREGISTERED"]);

                                        }

                                        if (myDataRowsPrivateCustomer["CUSTOMERSNO"] != DBNull.Value)
                                        {

                                            CustomerSerialNumber = myDataRowsPrivateCustomer["CUSTOMERSNO"].ToString();

                                        }

                                        if (myDataRowsPrivateCustomer["COUNTRYOFBIRTHID"] != DBNull.Value)
                                        {

                                            CountryOfBirthID = Convert.ToInt64(myDataRowsPrivateCustomer["COUNTRYOFBIRTHID"]);

                                        }

                                        if (myDataRowsPrivateCustomer["COMPANYEMAIL"] != DBNull.Value)
                                        {

                                            AddressDetailsCompanyEmail = myDataRowsPrivateCustomer["COMPANYEMAIL"].ToString();

                                        }

                                        if (myDataRowsPrivateCustomer["SALESEMAIL"] != DBNull.Value)
                                        {

                                            AddressDetailsSalesEmail = myDataRowsPrivateCustomer["SALESEMAIL"].ToString();

                                        }

                                        if (myDataRowsPrivateCustomer["TELEPHONE1"] != DBNull.Value)
                                        {

                                            AddressDetailsTelephone1 = myDataRowsPrivateCustomer["TELEPHONE1"].ToString();

                                        }

                                        if (myDataRowsPrivateCustomer["TELEPHONE2"] != DBNull.Value)
                                        {

                                            AddressDetailsTelephone2 = myDataRowsPrivateCustomer["TELEPHONE2"].ToString();

                                        }

                                        if (myDataRowsPrivateCustomer["MOBILEPHONE1"] != DBNull.Value)
                                        {

                                            AddressDetailsMobilePhone1 = myDataRowsPrivateCustomer["MOBILEPHONE1"].ToString();

                                        }

                                        if (myDataRowsPrivateCustomer["MOBILEPHONE2"] != DBNull.Value)
                                        {

                                            AddressDetailsMobilePhone2 = myDataRowsPrivateCustomer["MOBILEPHONE2"].ToString();

                                        }

                                        if (myDataRowsPrivateCustomer["FAX1"] != DBNull.Value)
                                        {

                                            AddressDetailsFax1 = myDataRowsPrivateCustomer["FAX1"].ToString();

                                        }

                                        if (myDataRowsPrivateCustomer["FAX2"] != DBNull.Value)
                                        {

                                            AddressDetailsFax2 = myDataRowsPrivateCustomer["FAX2"].ToString();

                                        }

                                        if (myDataRowsPrivateCustomer["ADDRESSDETAILSCOUNTRYID"] != DBNull.Value)
                                        {

                                            AddressDetailsCountryID = Convert.ToInt64(myDataRowsPrivateCustomer["ADDRESSDETAILSCOUNTRYID"]);

                                        }

                                        if (myDataRowsPrivateCustomer["ADDRESSDETAILSCITYID"] != DBNull.Value)
                                        {

                                            AddressDetailsCityID = Convert.ToInt64(myDataRowsPrivateCustomer["ADDRESSDETAILSCITYID"]);

                                        }

                                        if (myDataRowsPrivateCustomer["ADDRESSDETAILSPROVINCEID"] != DBNull.Value)
                                        {

                                            AddressDetailsProvinceID = Convert.ToInt64(myDataRowsPrivateCustomer["ADDRESSDETAILSPROVINCEID"]);

                                        }

                                        if (myDataRowsPrivateCustomer["ADDRESSDETAILSDISTRICTID"] != DBNull.Value)
                                        {

                                            AddressDetailsDistrictID = Convert.ToInt64(myDataRowsPrivateCustomer["ADDRESSDETAILSDISTRICTID"]);

                                        }

                                        if (myDataRowsPrivateCustomer["ADDRESSDETAILSDIVISIONID"] != DBNull.Value)
                                        {

                                            AddressDetailsDivisionID = Convert.ToInt64(myDataRowsPrivateCustomer["ADDRESSDETAILSDIVISIONID"]);

                                        }

                                        if (myDataRowsPrivateCustomer["ADDRESSDETAILSLOCATIONID"] != DBNull.Value)
                                        {

                                            AddressDetailsLocationID = Convert.ToInt64(myDataRowsPrivateCustomer["ADDRESSDETAILSLOCATIONID"]);

                                        }

                                        if (myDataRowsPrivateCustomer["ADDRESSDETAILSSUBLOCATIONID"] != DBNull.Value)
                                        {

                                            AddressDetailsSublocationID = Convert.ToInt64(myDataRowsPrivateCustomer["ADDRESSDETAILSSUBLOCATIONID"]);

                                        }

                                        if (myDataRowsPrivateCustomer["ADDRESSDETAILSCONSITUENCYID"] != DBNull.Value)
                                        {

                                            AddressDetailsConstituencyID = Convert.ToInt64(myDataRowsPrivateCustomer["ADDRESSDETAILSCONSITUENCYID"]);

                                        }

                                        if (myDataRowsPrivateCustomer["ADDRESSDETAILSCOUNTYID"] != DBNull.Value)
                                        {

                                            AddressDetailsCountyID = Convert.ToInt64(myDataRowsPrivateCustomer["ADDRESSDETAILSCOUNTYID"]);

                                        }

                                        if (myDataRowsPrivateCustomer["ADDRESSDETAILSPOSTALADDRESS"] != DBNull.Value)
                                        {

                                            AddressDetailsPostalAddress =
                                                myDataRowsPrivateCustomer["ADDRESSDETAILSPOSTALADDRESS"].ToString();

                                        }

                                        if (myDataRowsPrivateCustomer["ADDRESSDETAILSPOSTALCODE"] != DBNull.Value)
                                        {

                                            AddressDetailsPostalCode =
                                                myDataRowsPrivateCustomer["ADDRESSDETAILSPOSTALCODE"].ToString();

                                        }

                                        if (myDataRowsPrivateCustomer["ADDRESSDETAILSID"] != DBNull.Value)
                                        {

                                            AddressDetailsID = Convert.ToInt64(myDataRowsPrivateCustomer["ADDRESSDETAILSID"]);

                                        }

                                        if (myDataRowsPrivateCustomer["PHYSICALADDRESSCOORDINATE"] != DBNull.Value)
                                        {

                                            PhysicalAddressCoordinate = (NpgsqlTypes.NpgsqlPoint)myDataRowsPrivateCustomer["PHYSICALADDRESSCOORDINATE"];

                                        }

                                        if (myDataRowsPrivateCustomer["BUILDINGID"] != DBNull.Value)
                                        {

                                            AddressDetailsBuildingID = Convert.ToInt64(myDataRowsPrivateCustomer["BUILDINGID"]);

                                        }


                                        //if (myDataRowsPrivateCustomer["USERID"] != DBNull.Value)
                                        //{

                                        //UserID = Convert.ToInt64(myDataRowsPrivateCustomer["USERID"]);

                                        //}

                                    }

                                }
                                else
                                {
                                    return false;
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

        public bool RegisterPrivateCustomer()
        {

            string strQuery = null;
            bool bQuerySuccess = false;
            IMLogin tripLogin = null;
            Boolean bSuccessSave = false;
            Int16 iSaveStatus = 0;
            


            try
            {

                //Error codes
                //1 = Email Address missing
                //2 = Surname missing
                //3 = First name missing
                //4 = Telephone and Mobile missing. One must be provided
                //5 = Date of birth missing
                //6 = Passwords do not match
                //7 = Email Address already exists
                //8 = User name already exists


                strQuery = "SELECT * FROM trip_func_insertprivatecustomerdetails(" +
                    CustomerNo + ",'" +
                    CustomerSerialNumber + "', '" +
                    CustomerPriorityID + "'," +
                    CustomerTypeID + ", '" +
                    PINNo + "', '" +
                    EmailAddress + "' , '" +
                    MainPhoneNumber + "' , '" +
                    MobilePhoneNumber + "', " +
                    CountryOfBirthID + " , " +
                    lSex + " , '" +
                    strOtherName + "' , '" +
                    strMiddleName + "' , '" +
                    strFirstName + "' , '" +
                    strSurname + "' , '" +
                    strTitle + "' , " +
                    DateOfBirth.Year + " , " +
                    DateOfBirth.Month + " , " +
                    DateOfBirth.Day + " , '" +
                    UserName + "' , '" +
                    UserPassword + "' , '" +
                    ConfirmPassword + "'," +
                    Height + "," +
                    AddressDetailsID + "," +
                    PhysicalCustomerID + ",'" +
                    AddressDetailsPostalCode + "','" +
                    AddressDetailsPhysicalAddress + "','" +
                    AddressDetailsPostalAddress + "'," +
                    AddressDetailsCountryID + "," +
                    AddressDetailsCityID + "," +
                    AddressDetailsCountyID + "," +
                    AddressDetailsConstituencyID + "," +
                    AddressDetailsProvinceID + "," +
                    AddressDetailsDistrictID + "," +
                    AddressDetailsDivisionID + "," +
                    AddressDetailsLocationID + "," +
                    AddressDetailsSublocationID + "," +
                    AddressDetailsEstateID + ",'" +
                    AddressDetailsHouseNumber + "'," +
                    Convert.ToDouble(PhysicalAddressCoordinate.X) + "," +
                    Convert.ToDouble(PhysicalAddressCoordinate.Y) + "," +
                    AddressDetailsOwnerTypeID + ",'" +
                    AddressDetailsSocialNetworkUserID + "','" +
                    AddressDetailsTelephone1 + "','" +
                    AddressDetailsTelephone2 + "','" +
                    AddressDetailsMobilePhone1 + "','" +
                    AddressDetailsMobilePhone2 + "','" +
                    AddressDetailsFax1 + "','" +
                    AddressDetailsFax1 + "','" +
                    AddressDetailsCompanyEmail + "','" +
                    AddressDetailsSalesEmail + "','" +
                    AddressDetailsSupportEmail + "'," +
                    AddressDetailsStatusID + ",'" +
                    AddressDetailsUniversalAddress + "'," +
                    AddressDetailsRoadID + ",'" +
                    AddressDetailsProjection + "','" +
                    AddressDetailsPointName + "'," +
                    AddressDetailsBuildingID + "," +
                    AddressDetailsRootID + "," +
                    AddressDetailsAppartmentID + "," +
                    AddressDetailsMapID + ")";             


                tripLogin = new IMLogin();

                bQuerySuccess = tripLogin.ExecutePGPostgresQuery(strQuery);

                if (tripLogin.PGDataSet == null)
                {
                    return false;
                }
                else
                {

                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesPrivateCustomer in tripLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesPrivateCustomer.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;
                            }
                            else
                            {
                                foreach (DataRow myDataRowsPrivateCustomer in myDataTablesPrivateCustomer.Rows)
                                {

                                    if (Convert.ToInt16(myDataRowsPrivateCustomer[0]) >0)
                                    {                                    
                                        iSaveStatus = 1;
                                    }

                                }
                            }


                        }

                        if (iSaveStatus == 1)
                        {
                            //If the status is 1
                            bSuccessSave = true;

                        }
                        else
                        {
                            bSuccessSave = false;
                        }


                    }

                    return bSuccessSave;
                }

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
                return false;
            }
            finally
            {


                tripLogin = null;

            }
        }

        #endregion


    }
}
