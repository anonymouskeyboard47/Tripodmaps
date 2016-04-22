using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace TRIP_API
{
    public class IMOrgActivities
    {

         private long lActivityID;
 private string strActivityTitle;
 private DateTime dtDateRegistered;
 private DateTime dtDateDeRegistered;
 private DateTime dtDateCreated;
 private DataSet datOrganizationActivity;

 

 #region "Properties"

 public long ActivityID {
    
     get { return lActivityID; }
    
     set { lActivityID = value; }
 }


 public string ActivityTitle {
    
     get { return strActivityTitle; }
    
     set { strActivityTitle = value; }
 }


 public DateTime DateRegistered {
    
     get { return dtDateRegistered; }
    
     set { dtDateRegistered = value; }
 }


 public DateTime DateDeregistered {
    
     get { return dtDateDeRegistered; }
    
     set { dtDateDeRegistered = value; }
 }


 public DateTime DateCreated {
    
     get { return dtDateCreated; }
    
     set { dtDateCreated = value; }
 }


 public DataSet OrganizationActivityDataSet {
    
     get { return datOrganizationActivity; }
    
     set { datOrganizationActivity = value; }
 }

#endregion
 

 #region "InitializationProcedures"

 //public New() : IMOrgActivities()
 //{
 //}

#endregion

 

 #region "GeneralProcedures"


#endregion
 

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
                    
                     foreach (DataTable myDataTablesActivities in datRetData.Tables) {
                        
                         //Check if there is any data. If not exit
                         if (myDataTablesActivities.Rows.Count == 0) 
                         {
                            
                             //Return a value indicating that the search was not successful
                             return false;
                                
                         }
                        
                         if (bReturnData == true) {

                             foreach (DataRow myDataRowsOrgActivities in myDataTablesActivities.Rows)
                             {

                                 lActivityID = Convert.ToInt64(myDataRowsOrgActivities["ACTIVITYID"]);
                                 strActivityTitle = myDataRowsOrgActivities["ACTIVITYTITLE"].ToString();
                                 dtDateRegistered = Convert.ToDateTime(myDataRowsOrgActivities["DATEREGISTERED"]);
                                 dtDateRegistered = Convert.ToDateTime(myDataRowsOrgActivities["DATEDEREGISTERED"]);

                                 dtDateRegistered = Convert.ToDateTime(myDataRowsOrgActivities["DATECREATED"]);
                                
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
             bool bQuerySuccess = false;
             IMLogin tripLogin = null;
             Boolean bEmailAddressExists = false;
            
             try {
                
                 strQuery = "SELECT * FROM trip_func_getcompanyactivityidandactivitytitlebyname('" + strActivityTitle + "'," + 
                     lExactMatch + "," + lLimit + "," + lOffset + ");";
                
                 tripLogin = new IMLogin();
                
                 bQuerySuccess = tripLogin.ExecutePGPostgresQuery(strQuery);
                
                
                 if (tripLogin.PGDataSet == null) 
                 {
                     return false;
                 }

                 if (bQuerySuccess == true)
                 {

                     foreach (DataTable myDataTablesOrgActivities in tripLogin.PGDataSet.Tables)
                     {

                         //Check if there is any data. If not exit
                         if (myDataTablesOrgActivities.Rows.Count == 0)
                         {
                             //Return a value indicating that the search was not successful
                             return false;
                         }


                         datOrganizationActivity = tripLogin.PGDataSet;
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
                    
                 tripLogin = null;
                
             }
         }

        #endregion

        
        }

}
