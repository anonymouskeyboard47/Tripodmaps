using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace TRIP_API
{

    public class IMOrganizationCustomer : IMCustomer
    {

        private long lOrganizationID = 0;
        private string strOrganizationName = "";
        private string strVATNumber = "";
        private string strCompanyRegistrationNo = "";
        private long lCompanyTypeID = 0;
        private long lRoundingOff = 0;
        private long lDefaultCurrencyID = 0;
        private bool bVATRegistered = false;
        private System.DateTime dtCompanyRegistrationDate = DateTime.MinValue;
        private DataSet datOrganizationCustomer;

        // "Properties"
        #region "Properties"

        public long OrganizationID
        {

            get { return lOrganizationID; }

            set { lOrganizationID = value; }
        }


        public string OrganizationName
        {

            get { return strOrganizationName; }

            set { strOrganizationName = value; }
        }


        public string CompanyRegistrationNo
        {

            get { return strCompanyRegistrationNo; }

            set { strCompanyRegistrationNo = value; }
        }


        public long CompanyTypeID
        {

            get { return lCompanyTypeID; }

            set { lCompanyTypeID = value; }
        }


        public long RoundingOff
        {

            get { return lRoundingOff; }

            set { lRoundingOff = value; }
        }


        public long DefaultCurrencyID
        {

            get { return lDefaultCurrencyID; }

            set { lDefaultCurrencyID = value; }
        }


        public bool VATRegistered
        {

            get { return bVATRegistered; }

            set { bVATRegistered = value; }
        }


        public string VATNumber
        {

            get { return strVATNumber; }

            set { strVATNumber = value; }
        }


        public DateTime CompanyRegistrationDate
        {

            get { return dtCompanyRegistrationDate; }

            set { dtCompanyRegistrationDate = value; }
        }


        public DataSet OrganizationCustomerDataSet
        {

            //USED TO SET AND RETRIEVE THE OrganizationCustomer Dataset (DATASET)
            get { return datOrganizationCustomer; }

            set { datOrganizationCustomer = value; }
        }


        #endregion

        // "InitializationProcedures"

        //public New() : base()
        //{
        //}



        // "GeneralProcedures"




        // "DatabaseProcedures"

        #region "DatabaseProcedures"

        public bool Find(string strQuery, bool bReturnData)
        {

            DataSet datRetData = new DataSet();
            Boolean bQuerySuccess = false;
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

                        foreach (DataTable myDataTablesOrganizationCustomer in datRetData.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesOrganizationCustomer.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }

                            else
                            {

                                if (bReturnData == true)
                                {

                                    foreach (DataRow myDataRowsOrganizationCustomer in myDataTablesOrganizationCustomer.Rows)
                                    {

                                        CustomerNo = Convert.ToInt64(myDataRowsOrganizationCustomer["CUSTOMERNO"]);
                                        lOrganizationID = Convert.ToInt64(myDataRowsOrganizationCustomer["ORGANIZATIONID"]);
                                        strOrganizationName = myDataRowsOrganizationCustomer["ORGANIZATIONNAME"].ToString();
                                        strCompanyRegistrationNo = myDataRowsOrganizationCustomer["COMPANYREGISTRATIONNO"].ToString();
                                        lCompanyTypeID = Convert.ToInt64(myDataRowsOrganizationCustomer["COMPANYTYPEID"]);
                                        lRoundingOff = Convert.ToInt64(myDataRowsOrganizationCustomer["ROUNDINGOFF"]);
                                        lDefaultCurrencyID = Convert.ToInt64(myDataRowsOrganizationCustomer["DEFAULTCURRENCYID"]);
                                        dtCompanyRegistrationDate = Convert.ToDateTime(myDataRowsOrganizationCustomer["COMPANYREGISTRATIONDATE"]);

                                        if (Convert.ToInt64(myDataRowsOrganizationCustomer["VATRGISTERED"]) == 1)
                                        {
                                            bVATRegistered = true;
                                            strVATNumber = myDataRowsOrganizationCustomer["VATRNUMBER"].ToString();
                                        }
                                        else
                                        {
                                            bVATRegistered = false;
                                        }
                                    }

                                }
                                else
                                {

                                    return false;
                                }
                            }
                        }

                        return true;
                    }

                    else
                    {
                        return false;

                    }
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

        public bool ReturnOrganizationCustomerMasterByCustomerNumber(long lExactValues, long lLimit, long lOffset, bool bReturnData)
        {

            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
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
                strQuery = "SELECT * FROM trip_func_getorganizationcustomermasterbycustomerno (" +
                    CustomerNo + "," + lExactValues + "," + lLimit + "," + lOffset + ") AS (" +
               "CUSTOMERNO int4," +
               "CUSTOMERSNO varchar," +
               "DATEOFBIRTH timestamp with time zone," +
               "PINNO varchar, " +
               "CUSTPRIORITYID varchar, " +
               "CUSTOMERMASTERDATECREATED timestamp with time zone, " +
               "CUSTOMERMASTERDATEREGISTERED timestamp with time zone," +
               "CUSTOMERMASTERDATEDEREGISTERED timestamp with time zone," +
               "CUSTOMERCOATRADEDEBTORS int4, " +
               "USERID int4, " +
               "CUSTOMERTYPEID int4, " +
               "COUNTRYOFBIRTHID int4, " +
               "ORGANIZATIONNAME varchar," +
               "COMPANYREGISTRATIONNO varchar," +
               "COMPANYTYPEID int4," +
               "ORGANIZATIONID int4," +
               "DEFAULTCURRENCYID int4," +
               "VATREGISTERED boolean," +
               "COMPANYREGISTRATIONDATE date," +
               "VATREGISTRATIONNUMBER varchar," +
               "ADDRESSDETAILSUNIVERSALLADDRESS varchar, " +
               "COMPANYEMAIL  varchar," +
               "SALESEMAIL  varchar," +
               "TELEPHONE1  varchar," +
               "TELEPHONE2  varchar, " +
               "MOBILEPHONE1  varchar, " +
               "MOBILEPHONE2  varchar, " +
               "FAX1  varchar," +
               "FAX2  varchar," +
               "ADDRESSDETAILSCOUNTRYID int4, " +
               "ADDRESSDETAILSCITYID int4, " +
               "ADDRESSDETAILSPROVINCEID  int4," +
               "ADDRESSDETAILSDISTRICTID int4, " +
               "ADDRESSDETAILSDIVISIONID int4, " +
               "ADDRESSDETAILSLOCATIONID int4, " +
               "ADDRESSDETAILSSUBLOCATIONID int4, " +
               "ADDRESSDETAILSCONSITUENCYID int4," +
               "ADDRESSDETAILSCOUNTYID int4, " +
               "ADDRESSDETAILSPOSTALADDRESS text," +
               "ADDRESSDETAILSPOSTALCODE varchar, " +
               "ADDRESSDETAILSID int4," +
               "PHYSICALADDRESSCOORDINATE point," +
               "HOUSENUMBER varchar)";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesOrganizationCustomer in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesOrganizationCustomer.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                if (bReturnData == true)
                                {

                                    foreach (DataRow myDataRowsOrganizationCustomer in myDataTablesOrganizationCustomer.Rows)
                                    {
                                        if (myDataRowsOrganizationCustomer["ORGANIZATIONID"] != DBNull.Value)
                                        {
                                            lOrganizationID = Convert.ToInt64(myDataRowsOrganizationCustomer["ORGANIZATIONID"]);
                                        }

                                        if (myDataRowsOrganizationCustomer["ORGANIZATIONNAME"] != DBNull.Value)
                                        {
                                            strOrganizationName = myDataRowsOrganizationCustomer["ORGANIZATIONNAME"].ToString();
                                        }

                                        if (myDataRowsOrganizationCustomer["COMPANYREGISTRATIONNO"] != DBNull.Value)
                                        {

                                            strCompanyRegistrationNo = myDataRowsOrganizationCustomer["COMPANYREGISTRATIONNO"].ToString();

                                        }

                                        if (myDataRowsOrganizationCustomer["COMPANYTYPEID"] != DBNull.Value)
                                        {

                                            lCompanyTypeID = Convert.ToInt64(myDataRowsOrganizationCustomer["COMPANYTYPEID"]);

                                        }

                                        if (myDataRowsOrganizationCustomer["DEFAULTCURRENCYID"] != DBNull.Value)
                                        {

                                            lDefaultCurrencyID = Convert.ToInt64(myDataRowsOrganizationCustomer["DEFAULTCURRENCYID"]);

                                        }

                                        if (myDataRowsOrganizationCustomer["VATREGISTERED"] != DBNull.Value)
                                        {

                                            bVATRegistered = Convert.ToBoolean(myDataRowsOrganizationCustomer["VATREGISTERED"]);

                                        }

                                        if (myDataRowsOrganizationCustomer["VATREGISTRATIONNUMBER"] != DBNull.Value)
                                        {

                                            strVATNumber = myDataRowsOrganizationCustomer["VATREGISTRATIONNUMBER"].ToString();

                                        }

                                        if (myDataRowsOrganizationCustomer["COMPANYREGISTRATIONDATE"] != DBNull.Value)
                                        {

                                            dtCompanyRegistrationDate = Convert.ToDateTime(myDataRowsOrganizationCustomer["COMPANYREGISTRATIONDATE"]);

                                        }

                                        if (myDataRowsOrganizationCustomer["CUSTOMERNO"] != DBNull.Value)
                                        {

                                            CustomerNo = Convert.ToInt64(myDataRowsOrganizationCustomer["CUSTOMERNO"]);

                                        }

                                        if (myDataRowsOrganizationCustomer["DATEOFBIRTH"] != DBNull.Value)
                                        {

                                            DateOfBirth = Convert.ToDateTime(myDataRowsOrganizationCustomer["DATEOFBIRTH"]);

                                        }

                                        if (myDataRowsOrganizationCustomer["PINNO"] != DBNull.Value)
                                        {

                                            PINNo = myDataRowsOrganizationCustomer["PINNO"].ToString();
                                            CustomerPINNumber = myDataRowsOrganizationCustomer["PINNO"].ToString();
                                        }

                                        if (myDataRowsOrganizationCustomer["CUSTOMERTYPEID"] != DBNull.Value)
                                        {

                                            CustomerTypeID = Convert.ToInt64(myDataRowsOrganizationCustomer["CUSTOMERTYPEID"]);

                                        }

                                        if (myDataRowsOrganizationCustomer["CUSTPRIORITYID"] != DBNull.Value)
                                        {

                                            CustomerPriorityID = myDataRowsOrganizationCustomer["CUSTPRIORITYID"].ToString();

                                        }

                                        if (myDataRowsOrganizationCustomer["CUSTOMERMASTERDATECREATED"] != DBNull.Value)
                                        {

                                            DateCreated = Convert.ToDateTime(myDataRowsOrganizationCustomer["CUSTOMERMASTERDATECREATED"]);

                                        }


                                        if (myDataRowsOrganizationCustomer["CUSTOMERMASTERDATEREGISTERED"] != DBNull.Value)
                                        {

                                            DateRegistered = Convert.ToDateTime(myDataRowsOrganizationCustomer["CUSTOMERMASTERDATEREGISTERED"]);

                                        }

                                        if (myDataRowsOrganizationCustomer["CUSTOMERMASTERDATEDEREGISTERED"] != DBNull.Value)
                                        {

                                            DateDeRegistered = Convert.ToDateTime(myDataRowsOrganizationCustomer["CUSTOMERMASTERDATEDEREGISTERED"]);

                                        }

                                        if (myDataRowsOrganizationCustomer["CUSTOMERSNO"] != DBNull.Value)
                                        {

                                            CustomerSerialNumber = myDataRowsOrganizationCustomer["CUSTOMERSNO"].ToString();

                                        }

                                        if (myDataRowsOrganizationCustomer["COMPANYEMAIL"] != DBNull.Value)
                                        {

                                            AddressDetailsCompanyEmail = myDataRowsOrganizationCustomer["COMPANYEMAIL"].ToString();

                                        }

                                        if (myDataRowsOrganizationCustomer["SALESEMAIL"] != DBNull.Value)
                                        {

                                            AddressDetailsSalesEmail = myDataRowsOrganizationCustomer["SALESEMAIL"].ToString();

                                        }

                                        if (myDataRowsOrganizationCustomer["TELEPHONE1"] != DBNull.Value)
                                        {

                                            AddressDetailsTelephone1 = myDataRowsOrganizationCustomer["TELEPHONE1"].ToString();

                                        }

                                        if (myDataRowsOrganizationCustomer["TELEPHONE2"] != DBNull.Value)
                                        {

                                            AddressDetailsTelephone2 = myDataRowsOrganizationCustomer["TELEPHONE2"].ToString();

                                        }

                                        if (myDataRowsOrganizationCustomer["MOBILEPHONE1"] != DBNull.Value)
                                        {

                                            AddressDetailsMobilePhone1 = myDataRowsOrganizationCustomer["MOBILEPHONE1"].ToString();

                                        }

                                        if (myDataRowsOrganizationCustomer["MOBILEPHONE2"] != DBNull.Value)
                                        {

                                            AddressDetailsMobilePhone2 = myDataRowsOrganizationCustomer["MOBILEPHONE2"].ToString();

                                        }

                                        if (myDataRowsOrganizationCustomer["FAX1"] != DBNull.Value)
                                        {

                                            AddressDetailsFax1 = myDataRowsOrganizationCustomer["FAX1"].ToString();

                                        }

                                        if (myDataRowsOrganizationCustomer["FAX2"] != DBNull.Value)
                                        {

                                            AddressDetailsFax2 = myDataRowsOrganizationCustomer["FAX2"].ToString();

                                        }


                                        if (myDataRowsOrganizationCustomer["ADDRESSDETAILSCOUNTRYID"] != DBNull.Value)
                                        {

                                            AddressDetailsCountryID = Convert.ToInt64(myDataRowsOrganizationCustomer["ADDRESSDETAILSCOUNTRYID"]);

                                        }


                                        if (myDataRowsOrganizationCustomer["ADDRESSDETAILSCITYID"] != DBNull.Value)
                                        {

                                            AddressDetailsCityID = Convert.ToInt64(myDataRowsOrganizationCustomer["ADDRESSDETAILSCITYID"]);

                                        }

                                        if (myDataRowsOrganizationCustomer["ADDRESSDETAILSPROVINCEID"] != DBNull.Value)
                                        {

                                            AddressDetailsProvinceID = Convert.ToInt64(myDataRowsOrganizationCustomer["ADDRESSDETAILSPROVINCEID"]);

                                        }

                                        if (myDataRowsOrganizationCustomer["ADDRESSDETAILSDISTRICTID"] != DBNull.Value)
                                        {

                                            AddressDetailsDistrictID = Convert.ToInt64(myDataRowsOrganizationCustomer["ADDRESSDETAILSDISTRICTID"]);

                                        }

                                        if (myDataRowsOrganizationCustomer["ADDRESSDETAILSDIVISIONID"] != DBNull.Value)
                                        {

                                            AddressDetailsDivisionID = Convert.ToInt64(myDataRowsOrganizationCustomer["ADDRESSDETAILSDIVISIONID"]);

                                        }

                                        if (myDataRowsOrganizationCustomer["ADDRESSDETAILSLOCATIONID"] != DBNull.Value)
                                        {

                                            AddressDetailsLocationID = Convert.ToInt64(myDataRowsOrganizationCustomer["ADDRESSDETAILSLOCATIONID"]);

                                        }

                                        if (myDataRowsOrganizationCustomer["ADDRESSDETAILSSUBLOCATIONID"] != DBNull.Value)
                                        {

                                            AddressDetailsSublocationID = Convert.ToInt64(myDataRowsOrganizationCustomer["ADDRESSDETAILSSUBLOCATIONID"]);

                                        }

                                        if (myDataRowsOrganizationCustomer["ADDRESSDETAILSCONSITUENCYID"] != DBNull.Value)
                                        {

                                            AddressDetailsConstituencyID = Convert.ToInt64(myDataRowsOrganizationCustomer["ADDRESSDETAILSCONSITUENCYID"]);

                                        }

                                        if (myDataRowsOrganizationCustomer["ADDRESSDETAILSCOUNTYID"] != DBNull.Value)
                                        {

                                            AddressDetailsCountyID = Convert.ToInt64(myDataRowsOrganizationCustomer["ADDRESSDETAILSCOUNTYID"]);

                                        }

                                        if (myDataRowsOrganizationCustomer["ADDRESSDETAILSPOSTALADDRESS"] != DBNull.Value)
                                        {

                                            AddressDetailsPostalAddress =
                                                myDataRowsOrganizationCustomer["ADDRESSDETAILSPOSTALADDRESS"].ToString();

                                        }

                                        if (myDataRowsOrganizationCustomer["ADDRESSDETAILSPOSTALCODE"] != DBNull.Value)
                                        {

                                            AddressDetailsPostalCode =
                                                myDataRowsOrganizationCustomer["ADDRESSDETAILSPOSTALCODE"].ToString();

                                        }

                                        if (myDataRowsOrganizationCustomer["ADDRESSDETAILSID"] != DBNull.Value)
                                        {

                                            AddressDetailsID = Convert.ToInt64(myDataRowsOrganizationCustomer["ADDRESSDETAILSID"]);

                                        }

                                        if (myDataRowsOrganizationCustomer["PHYSICALADDRESSCOORDINATE"] != DBNull.Value)
                                        {

                                            PhysicalAddressCoordinate = (NpgsqlTypes.NpgsqlPoint)myDataRowsOrganizationCustomer["PHYSICALADDRESSCOORDINATE"];

                                        }

                                        //if (myDataRowsOrganizationCustomer["USERID"] != DBNull.Value)
                                        //{

                                        //UserID = Convert.ToInt64(myDataRowsOrganizationCustomer["USERID"]);

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

        public bool RetrieveOrganizationCustomerByOrganizationID(int lOrganizationID, int iLimit, int iOffset, bool bReturnData)
        {
            //
            //iorganizationid int4, ilimit int4, ioffset int4


            DataSet datRetData = new DataSet();
            Boolean bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getorganizationmasterdetailsbyorganizationid(" + lOrganizationID + "," + iLimit +
                    "," + iOffset + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }

                if (bQuerySuccess == true)
                {

                    foreach (DataTable myDataTablesOrganizationCustomer in datRetData.Tables)
                    {

                        //Check if there is any data. If not exit
                        if (myDataTablesOrganizationCustomer.Rows.Count == 0)
                        {

                            //Return a value indicating that the search was not successful
                            return false;

                        }

                        if (bReturnData == true)
                        {

                            foreach (DataRow myDataRowsOrganizationCustomer in myDataTablesOrganizationCustomer.Rows)
                            {

                                CustomerNo = Convert.ToInt64(myDataRowsOrganizationCustomer["CUSTOMERNO"]);
                                lOrganizationID = Convert.ToInt32(myDataRowsOrganizationCustomer["ORGANIZATIONID"]);
                                strOrganizationName = myDataRowsOrganizationCustomer["ORGANIZATIONNAME"].ToString();
                                strCompanyRegistrationNo = myDataRowsOrganizationCustomer["COMPANYREGISTRATIONNO"].ToString();
                                lCompanyTypeID = Convert.ToInt64(myDataRowsOrganizationCustomer["COMPANYTYPEID"]);
                                lRoundingOff = Convert.ToInt64(myDataRowsOrganizationCustomer["ROUNDINGOFF"]);
                                lDefaultCurrencyID = Convert.ToInt64(myDataRowsOrganizationCustomer["DEFAULTCURRENCYID"]);
                                dtCompanyRegistrationDate = Convert.ToDateTime(myDataRowsOrganizationCustomer["COMPANYREGISTRATIONDATE"]);

                                if (Convert.ToInt64(myDataRowsOrganizationCustomer["VATRGISTERED"]) == 1)
                                {
                                    bVATRegistered = true;
                                    strVATNumber = myDataRowsOrganizationCustomer["VATRNUMBER"].ToString();
                                }
                                else
                                {
                                    bVATRegistered = false;
                                }

                            }

                        }
                    }


                    return true;
                }
                else
                {


                    return false;

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

        public bool RetrieveOrganizationCustomerMainDetailsByOrganizationName(string strOrganizationName, int iLimit, int iOffset,
            bool bReturnData)
        {
            //
            //iorganizationid int4, ilimit int4, ioffset int4


            DataSet datRetData = new DataSet();
            Boolean bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getorganizationmasterdetailsbyorganizationid('" +
                    strOrganizationName + "'," + iLimit + "," + iOffset + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }

                if (bQuerySuccess == true)
                {

                    foreach (DataTable myDataTablesOrganizationCustomer in datRetData.Tables)
                    {

                        //Check if there is any data. If not exit
                        if (myDataTablesOrganizationCustomer.Rows.Count == 0)
                        {

                            //Return a value indicating that the search was not successful
                            return false;
                        }

                        if (bReturnData == true)
                        {

                            foreach (DataRow myDataRowsOrganizationCustomer in myDataTablesOrganizationCustomer.Rows)
                            {

                                CustomerNo = Convert.ToInt64(myDataRowsOrganizationCustomer["CUSTOMERNO"]);
                                lOrganizationID = Convert.ToInt64(myDataRowsOrganizationCustomer["ORGANIZATIONID"]);
                                strOrganizationName = myDataRowsOrganizationCustomer["ORGANIZATIONNAME"].ToString();
                                strCompanyRegistrationNo = myDataRowsOrganizationCustomer["COMPANYREGISTRATIONNO"].ToString();
                                lCompanyTypeID = Convert.ToInt64(myDataRowsOrganizationCustomer["COMPANYTYPEID"]);
                                lRoundingOff = Convert.ToInt64(myDataRowsOrganizationCustomer["ROUNDINGOFF"]);
                                lDefaultCurrencyID = Convert.ToInt64(myDataRowsOrganizationCustomer["DEFAULTCURRENCYID"]);
                                dtCompanyRegistrationDate = Convert.ToDateTime(myDataRowsOrganizationCustomer["COMPANYREGISTRATIONDATE"]);

                                if (Convert.ToInt64(myDataRowsOrganizationCustomer["VATRGISTERED"]) == 1)
                                {
                                    bVATRegistered = true;
                                    strVATNumber = myDataRowsOrganizationCustomer["VATRNUMBER"].ToString();
                                }
                                else
                                {
                                    bVATRegistered = false;
                                }


                            }

                        }
                    }


                    return true;
                }
                else
                {


                    return false;

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

        public bool RetrieveOrganizationMasterByOrganizationOrganizationName(string strOrganizationName, int iLimit, int iOffset,
            bool bReturnData)
        {
            //
            //iorganizationid int4, ilimit int4, ioffset int4


            DataSet datRetData = new DataSet();
            Boolean bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getorganizationmasterdetailsbyorganizationid('" + strOrganizationName + "'," + iLimit + "," + iOffset + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }

                if (bQuerySuccess == true)
                {

                    foreach (DataTable myDataTablesOrganizationCustomer in datRetData.Tables)
                    {

                        //Check if there is any data. If not exit
                        if (myDataTablesOrganizationCustomer.Rows.Count == 0)
                        {

                            //Return a value indicating that the search was not successful
                            return false;
                        }

                        if (bReturnData == true)
                        {

                            foreach (DataRow myDataRowsOrganizationCustomer in myDataTablesOrganizationCustomer.Rows)
                            {

                                CustomerNo = Convert.ToInt64(myDataRowsOrganizationCustomer["CUSTOMERNO"]);
                                lOrganizationID = Convert.ToInt64(myDataRowsOrganizationCustomer["ORGANIZATIONID"]);
                                strOrganizationName = myDataRowsOrganizationCustomer["ORGANIZATIONNAME"].ToString();
                                strCompanyRegistrationNo = myDataRowsOrganizationCustomer["COMPANYREGISTRATIONNO"].ToString();
                                lCompanyTypeID = Convert.ToInt64(myDataRowsOrganizationCustomer["COMPANYTYPEID"]);
                                lRoundingOff = Convert.ToInt64(myDataRowsOrganizationCustomer["ROUNDINGOFF"]);
                                lDefaultCurrencyID = Convert.ToInt64(myDataRowsOrganizationCustomer["DEFAULTCURRENCYID"]);
                                dtCompanyRegistrationDate = Convert.ToDateTime(myDataRowsOrganizationCustomer["COMPANYREGISTRATIONDATE"]);

                                if (Convert.ToInt64(myDataRowsOrganizationCustomer["VATRGISTERED"]) == 1)
                                {
                                    bVATRegistered = true;
                                    strVATNumber = myDataRowsOrganizationCustomer["VATRNUMBER"].ToString();
                                }
                                else
                                {
                                    bVATRegistered = false;
                                }

                            }

                        }
                    }


                    return true;
                }
                else
                {


                    return false;

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

        public bool RegisterOrganizationCustomer()
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

                strQuery = "SELECT * FROM trip_func_insertorganizationcustomerdetails(0, 0,'" +
                    CustomerSerialNumber + "'," +
                    CustomerPriorityID + " , " +
                    CustomerTypeID + " , '" +
                    CustomerPINNumber + "','" +
                    EmailAddress + "','" +
                    MainPhoneNumber + "','" +
                    MobilePhoneNumber + "'," +
                    CountryOfBirthID + ",'" +
                    strOrganizationName + "','" +
                    strCompanyRegistrationNo + "'," +
                    bVATRegistered + "," +
                    DateOfBirth.Year + "," +
                    DateOfBirth.Month + "," +
                    DateOfBirth.Day + "," +
                    lCompanyTypeID + "," +
                    2 + "," +
                    DefaultCurrencyID + ",'" +
                    UserName + "','" +
                    UserPassword + "','" +
                    ConfirmPassword + "')";

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

                        foreach (DataTable myDataTablesOrganizationCustomer in tripLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesOrganizationCustomer.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;
                            }
                            else
                            {
                                foreach (DataRow myDataRowsOrganizationCustomer in myDataTablesOrganizationCustomer.Rows)
                                {


                                    iSaveStatus = Convert.ToInt16(myDataRowsOrganizationCustomer[0]);

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
