using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace TRIP_API
{
    public class IMOrgTypes
    {

        
 private long lCompanyTypeID;
 private string strCompanyTypeTitle;
 private DateTime dtDateCreated;
 private DateTime dtDateRegistered;
 private DateTime dtDateDeRegistered;
 private DataSet datOrgTypesDataset;



 //region "Properties"
 #region "Properties"

 public long CompanyTypeID {
    
     //USED TO SET AND RETRIEVE THE SALARYTYPE ID (STRING)
     get { return lCompanyTypeID; }
    
     set { lCompanyTypeID = value; }
 }


 public string CompanyTypeTitle {
    
     //USED TO SET AND RETRIEVE THE SalaryTypeName (STRING)
     get { return strCompanyTypeTitle; }
    
     set { strCompanyTypeTitle = value; }
 }


 public DateTime DateCreated {
    
     get { return dtDateCreated; }
    
     set { dtDateCreated = value; }
 }


 public DateTime DateRegistered {
    
     get { return dtDateRegistered; }
    
     set { dtDateRegistered = value; }
 }


 public DateTime DateDeregistered {
    
     get { return dtDateDeRegistered; }
    
     set { dtDateDeRegistered = value; }
 }


 public DataSet OrgTypesDataset {
    
     //USED TO RETRIEVE THE OrgaTypesDataset (STRING)
     get { return datOrgTypesDataset; }
 }


 #endregion


 //region "InitializationProcedures"

 //public New();
 //{
 //}


 //region "GeneralProcedures"


 //region "DatabaseProcedures"
 #region "DatabaseProcedures"

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
        
         if (bQuerySuccess == true) {

             foreach (DataTable myDataTablesOrgTypes in datRetData.Tables)
             {
                
                 //Check if there is any data. If not exit
                 if (myDataTablesOrgTypes.Rows.Count == 0)
                 {
                    
                     //Return a value indicating that the search was not successful
                     return false;
                        
                 }
                
                 if (bReturnData == true) {

                     foreach (DataRow myDataRowsOrgTypes in myDataTablesOrgTypes.Rows)
                     {

                         lCompanyTypeID = Convert.ToInt64(myDataRowsOrgTypes["COMPANYTYPEID"]);
                         strCompanyTypeTitle =  myDataRowsOrgTypes["COMPANYTYPETITLE"].ToString();
                         dtDateCreated = Convert.ToDateTime( myDataRowsOrgTypes["DATECREATED"]);
                         dtDateRegistered = Convert.ToDateTime(myDataRowsOrgTypes["DATEREGISTERED"]);
                         dtDateDeRegistered = Convert.ToDateTime(myDataRowsOrgTypes["DATEDEREGISTERED"]);
                        
                     }
                    
                 }
             }
            
                
             return true;
         }
         else {
            
                
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

 public bool RetrieveOrganizationTypeIDAndOrganizationTypeTitleList(long lExactMatch, long lLimit, long lOffset)
 {
    
     //RETRIEVES A LIST OF ALL COMPANYTYPES
     // trip_func_getcompanytypeidandcompanytypetitlebyname(strnames "varchar",
     //iexactmatch int4, ilimit int4, ioffset int4)
    
     string strQuery = null;
     Boolean bQuerySuccess = false;
     IMLogin tripLogin = null;
    
     try {
        
         strQuery = "SELECT * FROM trip_func_getcompanytypeidandcompanytypetitlebyname('" + strCompanyTypeTitle + "'," + 
             lExactMatch + "," + lLimit + "," + lOffset + ");";
        
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

                 foreach (DataTable myDataTablesOrgTypes in tripLogin.PGDataSet.Tables)
                 {

                     //Check if there is any data. If not exit
                     if (myDataTablesOrgTypes.Rows.Count == 0)
                     {

                         //Return a value indicating that the search was not successful
                         return false;

                     }

                     datOrgTypesDataset = tripLogin.PGDataSet;
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
         tripLogin = null;
        
     }
 }

 #endregion


    }
}
