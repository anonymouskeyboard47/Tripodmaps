using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Resources;


namespace TRIP_API
{
    public class IMCustomer : IMAddress
    {
            
        private long lCustomerNo = 0;
        private string strCustomerSNO = "";
        private DateTime dtDateOfBirth = DateTime.MinValue;
        private long lCountryOfBirthID = 0;
        //Where the company was first born or customer first born
        private string strPINNo = "";
        private long lCustomerTypeID = 0;
        private string lCustomerPriorityID = "";
        private string strCustomerPINNumber;
        private DateTime dtDateCreated = DateTime.MinValue;
        private DateTime dtDateRegistered = DateTime.MinValue;
        private DateTime dtDateDeRegistered = DateTime.MinValue;
        private long lUserID = 0;
        private string strEmailAddress = "";
        private string strMainPhoneNumber = "";
        private string strMobilePhoneNumber = "";
        private string strUserName = "";
        private string strUserPassword = "";
        private string strConfirmPassword = "";
        private DataSet datCustomer;

 

 #region "Properties"

     public string UserPassword {
        
         get { return strUserPassword; }
        
         set { strUserPassword = value; }
     }


     public string ConfirmPassword {
        
         get { return strConfirmPassword; }
        
         set { strConfirmPassword = value; }
     }


     public string UserName {
        
         get { return strUserName; }
        
         set { strUserName = value; }
     }


     public string MainPhoneNumber {
        
         get { return strMainPhoneNumber; }
        
         set { strMainPhoneNumber = value; }
     }


     public string MobilePhoneNumber {
        
         get { return strMobilePhoneNumber; }
        
         set { strMobilePhoneNumber = value; }
     }


     public string EmailAddress {
        
         get { return strEmailAddress; }
        
         set { strEmailAddress = value; }
     }


     public DateTime DateCreated {
        
         get { return dtDateCreated; }
        
         set { dtDateCreated = value; }
     }


     public long CustomerNo {
        
         get { return lCustomerNo; }
        
         set { lCustomerNo = value; }
     }


     public string CustomerSerialNumber {
        
         get { return strCustomerSNO; }
        
         set { strCustomerSNO = value; }
     }


     public DateTime DateOfBirth {
        
        
         get { return dtDateOfBirth; }
        
         set { dtDateOfBirth = value; }
     }


     public long CountryOfBirthID {
        
        
         get { return lCountryOfBirthID; }
        
         set { lCountryOfBirthID = value; }
     }


     public long UserID {
        
        
         get { return lUserID; }
        
         set { lUserID = value; }
     }


     public string PINNo {
        
        
         get { return strPINNo; }
        
         set { strPINNo = value; }
     }


     public long CustomerTypeID {
        
        
         get { return lCustomerTypeID; }
        
         set { lCustomerTypeID = value; }
     }


     public string CustomerPriorityID {
        
        
         get { return lCustomerPriorityID; }
        
         set { lCustomerPriorityID = value; }
     }


     public DateTime DateRegistered {
        
        
         get { return dtDateRegistered; }
        
         set { dtDateRegistered = value; }
     }


     public DateTime DateDeRegistered {
        
         get { return dtDateDeRegistered; }
        
         set { dtDateDeRegistered = value; }
     }


     public string CustomerPINNumber
     {

         get { return strCustomerPINNumber; }

         set { strCustomerPINNumber = value; }
     }


#endregion


 #region "InitializationProcedures"

 public IMCustomer()
            : base()
        {
        }

#endregion


 #region "DatabaseProcedures"
 
        public bool CheckIfEmailAddressIsAvailable(string strEmailAddress)
 
        {
    
             string strQuery = null;
             bool bQuerySuccess = false;
             IMLogin tripLogin = null;
             Boolean bEmailAddressExists = false;
            
             try {
                
                 strQuery = "trip_func_checklogin('" +  strEmailAddress.Trim()  + "',1)";
                
                 tripLogin = new IMLogin();
                
                 bQuerySuccess = tripLogin.ExecutePGPostgresQuery(strQuery);
                
                
                 if (tripLogin.PGDataSet == null) {
                     return false;

                 }
                 else
                 {
                     if (bQuerySuccess == true)
                     {

                         foreach (DataTable myDataTablesCustomer in tripLogin.PGDataSet.Tables)
                         {

                             //Check if there is any data. If not exit
                             if (myDataTablesCustomer.Rows.Count == 0)
                             {

                                 //Return a value indicating that the search was not successful
                                 return false;

                             }
                             else
                             {

                                 foreach (DataRow myDataRowsCustomer in myDataTablesCustomer.Rows)
                                 {

                                     if (myDataRowsCustomer[0].ToString() == "1")
                                     {
                                         bEmailAddressExists = true;
                                     }
                                     else
                                     {
                                         bEmailAddressExists = false;
                                     }

                                 }

                             }
                         }

                         return bEmailAddressExists;

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
                 tripLogin = null;
                
             }
 
        }
 
        public bool CheckIfUserNameIsAvailable(string strSurname)
 {
    
     string strQuery = null;
     bool bQuerySuccess = false;
     //DataTable myDataTables = null;
     DataRow myDataRows = default(DataRow);
     IMLogin tripLogin = null;
     Boolean bUserNameExists = false;
    
     try {
        
         strQuery = "SELECT * FROM trip_func_checklogin('" + strSurname.Trim() + "',0)";
        
         tripLogin = new IMLogin();
        
         bQuerySuccess = tripLogin.ExecutePGPostgresQuery(strQuery);
        
        
         if (tripLogin.PGDataSet == null) {
             return false;

         }
         else
         {

             if (bQuerySuccess == true)
             {

                 foreach (DataTable myDataTablesCustomer in tripLogin.PGDataSet.Tables)
                 {

                     //Check if there is any data. If not exit
                     if (myDataTablesCustomer.Rows.Count == 0)
                     {

                         //Return a value indicating that the search was not successful
                         return false;
                     }
                     else
                     {
                         foreach (DataRow myDataRowsCustomer in myDataTablesCustomer.Rows)
                         {

                             if (myDataRows[0].ToString() == "1")
                             {
                                 bUserNameExists = true;
                             }
                             else
                             {
                                 bUserNameExists = false;
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
         
         return bUserNameExists;
     
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
 
        public bool QueryFind(string strQuery, bool bReturnData)
 {
    
     DataSet datRetData = new DataSet();
     bool bQuerySuccess = false;
     IMLogin objLogin = new IMLogin();
    
     try {
        
        
         bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);
        
         if (datRetData == null) {
             return false;
         }

         else
         {
             if (bQuerySuccess == true)
             {

                 foreach (DataTable myDataTablesCustomer in datRetData.Tables)
                 {

                     //Check if there is any data. If not exit
                     if (myDataTablesCustomer.Rows.Count == 0)
                     {

                         //Return a value indicating that the search was not successful
                         return false;

                     }
                     else
                     {
                         if (bReturnData == true)
                         {
                             //Return the data for the customer

                             foreach (DataRow myDataRowsCustomer in myDataTablesCustomer.Rows)
                             {

                                 lCustomerNo = Convert.ToInt64(myDataRowsCustomer["CUSTOMERNO"]);
                                 dtDateOfBirth = Convert.ToDateTime(myDataRowsCustomer["DATEOFBIRTH"]);
                                 lCountryOfBirthID = Convert.ToInt64(myDataRowsCustomer["COUNTRYOFBIRTH"]);
                                 strPINNo = myDataRowsCustomer["PINNO"].ToString();
                                 lCustomerPriorityID = myDataRowsCustomer["CUSTPRIORITYID"].ToString();
                                 dtDateCreated = Convert.ToDateTime(myDataRowsCustomer["DATECREATED"]);
                                 strCustomerSNO = myDataRowsCustomer["CUSTOMERSNO"].ToString();
                                 dtDateRegistered = Convert.ToDateTime(myDataRowsCustomer["DATEREGISTERED"]);
                                 dtDateDeRegistered = Convert.ToDateTime(myDataRowsCustomer["DATEDEREGISTERED"]);
                                 lUserID = Convert.ToInt64(myDataRowsCustomer["USERID"]);
                                 lCustomerTypeID = Convert.ToInt64(myDataRowsCustomer["CUSTOMERTYPEID"]);
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

        public bool LoadAllCustomers(long iLimit, long iOffset, bool bArrangeNamesInSingleColumn)
        {
            string strQuery = null;
            bool bQuerySuccess = false;
            DataTable myDataTables = null;
            DataRow myDataRows = default(DataRow);
            IMLogin tripLogin = null;

            try
            {

                strQuery = "SELECT * FROM trip_func_getcustomermaindetailsbycustomerno(" + 
                    lCustomerNo + "," + iLimit + "," + iOffset + ")";                

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

                        foreach (DataTable myDataTablesCustomer in tripLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesCustomer.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;
                            }
                            else
                            {
                                if (bArrangeNamesInSingleColumn == true)
                                {
                                    foreach (DataRow myDataRowsCustomer in myDataTablesCustomer.Rows)
                                    {
                                        //must be changed so that all name field go into a single row
                                        datCustomer = tripLogin.PGDataSet;
                                    }
                                }
                                else
                                {
                                    datCustomer = tripLogin.PGDataSet;
                                }

                                return true;

                            }

                        }


                    }
                    else
                    {
                        return false;
                    }

                }

                return true;

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

        public void ReturnFirstCustomerNo()
        {
            string strQuery = null;
            bool bQuerySuccess = false;
            //DataTable myDataTables = null;
            //DataRow myDataRows = default(DataRow);
            IMLogin tripLogin = null;
            lCustomerNo = 0;

            try
            {

                strQuery = "SELECT * FROM trip_func_getfirstcustomerno()";

                tripLogin = new IMLogin();

                bQuerySuccess = tripLogin.ExecutePGPostgresQuery(strQuery);


                if (tripLogin.PGDataSet == null)
                {
                    lCustomerNo = 0;
                }
                else
                {

                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesCustomer in tripLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesCustomer.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                lCustomerNo = 0;
                            }
                            else
                            {

                                foreach (DataRow myDataRowsCustomer in myDataTablesCustomer.Rows)
                                {

                                    lCustomerNo = Convert.ToInt64(myDataRowsCustomer[0]);
                                }
                                

                            }

                        }


                    }
                    else
                    {
                        lCustomerNo= 0;
                    }

                }

                //return true;

            }

            catch (Exception ex)
            {
                lCustomerNo = 0;
            }

            finally
            {
                tripLogin = null;
            }

        }

        public void ReturnPreviousCustomerNo()
        {
            string strQuery = null;
            bool bQuerySuccess = false;
            //DataTable myDataTables = null;
            //DataRow myDataRows = default(DataRow);
            IMLogin tripLogin = null;

            try
            {

                strQuery = "SELECT * FROM trip_func_getprevcustomerno(" + lCustomerNo + ")";

                tripLogin = new IMLogin();

                bQuerySuccess = tripLogin.ExecutePGPostgresQuery(strQuery);


                if (tripLogin.PGDataSet == null)
                {
                    lCustomerNo = 0;
                }
                else
                {

                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesCustomer in tripLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesCustomer.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                lCustomerNo = 0;
                            }
                            else
                            {

                                foreach (DataRow myDataRowsCustomer in myDataTablesCustomer.Rows)
                                {
                                    lCustomerNo = Convert.ToInt64(myDataRowsCustomer[0]);
                                    
                                }

                            }

                        }


                    }
                    else
                    {
                        lCustomerNo = 0;
                    }

                }

                //return true;

            }

            catch (Exception ex)
            {
                lCustomerNo = 0;
            }

            finally
            {
                tripLogin = null;
            }

        }

        public void ReturnNextCustomerNo()
        {
            string strQuery = null;
            bool bQuerySuccess = false;
            //DataTable myDataTables = null;
            //DataRow myDataRows = default(DataRow);
            IMLogin tripLogin = null;
            try
            {

                strQuery = "SELECT * FROM trip_func_getnextcustomerno(" + CustomerNo + ")";

                tripLogin = new IMLogin();

                bQuerySuccess = tripLogin.ExecutePGPostgresQuery(strQuery);


                if (tripLogin.PGDataSet == null)
                {
                    lCustomerNo = 0;
                }
                else
                {

                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesCustomer in tripLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesCustomer.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                lCustomerNo = 0;
                            }
                            else
                            {

                                foreach (DataRow myDataRowsCustomer in myDataTablesCustomer.Rows)
                                {
                                    lCustomerNo = Convert.ToInt64(myDataRowsCustomer[0]);

                                }


                            }

                        }


                    }
                    else
                    {
                        lCustomerNo = 0;
                    }

                }

                //return true;

            }

            catch (Exception ex)
            {
                lCustomerNo = 0;
            }

            finally
            {
                tripLogin = null;
            }

        }

        public void ReturnLastCustomerNo()
        {
            string strQuery = null;
            bool bQuerySuccess = false;
            //DataTable myDataTables = null;
            //DataRow myDataRows = default(DataRow);
            IMLogin tripLogin = null;
            lCustomerNo = 0;

            try
            {

                strQuery = "SELECT * FROM trip_func_getlastcustomerno()";

                tripLogin = new IMLogin();

                bQuerySuccess = tripLogin.ExecutePGPostgresQuery(strQuery);


                if (tripLogin.PGDataSet == null)
                {
                    lCustomerNo = 0;
                }
                else
                {

                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesCustomer in tripLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesCustomer.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                lCustomerNo = 0;
                            }
                            else
                            {

                                foreach (DataRow myDataRowsCustomer in myDataTablesCustomer.Rows)
                                {
                                    lCustomerNo = Convert.ToInt64(myDataRowsCustomer[0]);

                                }


                            }

                        }


                    }
                    else
                    {
                        lCustomerNo = 0;
                    }

                }

                //return true;

            }

            catch (Exception ex)
            {
                lCustomerNo = 0;
            }

            finally
            {
                tripLogin = null;
            }

        }

        public void CheckCustomerType()
        {
            string strQuery = null;
            bool bQuerySuccess = false;
            //DataTable myDataTables = null;
            //DataRow myDataRows = default(DataRow);
            IMLogin tripLogin = null;
            lCustomerTypeID = 0;

            try
            {

                strQuery = "SELECT * FROM trip_func_checkcustomertype(" + lCustomerNo + ")";

                tripLogin = new IMLogin();

                bQuerySuccess = tripLogin.ExecutePGPostgresQuery(strQuery);


                if (tripLogin.PGDataSet == null)
                {
                    lCustomerTypeID = 0;
                }
                else
                {

                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesCustomer in tripLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesCustomer.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                lCustomerTypeID = 0;
                            }
                            else
                            {

                                foreach (DataRow myDataRowsCustomer in myDataTablesCustomer.Rows)
                                {

                                    lCustomerTypeID = Convert.ToInt64(myDataRowsCustomer[0]);
                                }


                            }

                        }


                    }
                    else
                    {
                        lCustomerTypeID = 0;
                    }

                }

                //return true;

            }

            catch (Exception ex)
            {
                lCustomerTypeID = 0;
            }

            finally
            {
                tripLogin = null;
            }

        }

#endregion


    }
}
