using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace TRIP_API
{
    public class IMCountries
    {
         private string strCountryCode;
         private string strCountryName;
         private string strCurrencyName;
         private string strCurrencyCode;
         private string strCountryTravelAgentCode;
         private long lCountryID;
         private string strCountrySovereign;
         private string strCountryPhoneCode;
         private DataSet dtCountryDataset;
         private long lCountryAllowedCitzenship;

#region "Properties"

 public string CountryCode {
     //USED TO SET AND RETRIEVE THE COUNTRY CODE STRING VALUE
     get { return strCountryCode; }
    
     set { strCountryCode = value; }
 }

 public string CountryName {
     //USED TO SET AND RETRIEVE THE COUNTRY NAME STRING VALUE
     get { return strCountryName; }
    
     set { strCountryName = value; }
 }

 public string CurrencyName {
     //USED TO SET AND RETRIEVE THE CONNECTION STRING VALUE
     get { return strCurrencyName; }
    
     set { strCurrencyName = value; }
 }

 public string CurrencyCode {
     //USED TO SET AND RETRIEVE THE CURRENCY CODE STRING VALUE
     get { return strCurrencyCode; }
    
     set { strCurrencyCode = value; }
 }

 public string CountryTravelAgentCode {
     get { return strCountryTravelAgentCode; }
    
     set { strCountryTravelAgentCode = value; }
 }

 public long CountryID {
     get { return lCountryID; }
    
     set { lCountryID = value; }
 }

 public string CountryPhoneCode {
     get { return strCountryPhoneCode; }
    
     set { strCountryPhoneCode = value; }
 }

 public string CountrySovereign {
     get { return strCountrySovereign; }
    
     set { strCountrySovereign = value; }
 }

 public DataSet CountryDataset {
     //USED TO SET AND RETRIEVE THE COUNTRY CODE STRING VALUE
     get { return dtCountryDataset; }
 }

 //Number of allowed citizenships for citizens of this country
 public long CitizenshipNumberMaximum
 {

     get { return lCountryAllowedCitzenship; }

     set { lCountryAllowedCitzenship = value; }
 }


#endregion


 //region "InitializationProcedures"

 public IMCountries() : base()
 {
    
 }

 

 #region "GeneralProcedures"

 
        public bool RetrieveCountryIDAndNameByCountryName(long lExactMatch, long lLimit, long lOffset)
 {
    
     //RETRIEVES A LIST OF ALL COUNTRIES
    
     // trip_func_getcountryidandnamebycountryname(strnames "varchar",
     //iexactmatch int4, ilimit int4, ioffset int4)
    
     string strQuery = null;
     bool bQuerySuccess = false;
     IMLogin tripLogin = null;
    
     try {
        
         strQuery = "SELECT * FROM trip_func_getcountryidandnamebycountryname('" + strCountryName + "'," + lExactMatch + "," + 
             lLimit + "," + lOffset + ");";
        
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

                 foreach (DataTable myDataTablesCountry in tripLogin.PGDataSet.Tables)
                 {

                     //Check if there is any data. If not exit
                     if (myDataTablesCountry.Rows.Count == 0)
                     {

                         //Return a value indicating that the search was not successful
                         return false;

                     }
                     else
                     {

                         dtCountryDataset = tripLogin.PGDataSet;
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
       
         tripLogin = null;
        
     }
 }
 
        public bool RetrieveCountryByCountryID(long lExactMatch, long lLimit, long lOffset)
 {
    
     //RETRIEVES A LIST OF ALL COUNTRIES
    
     // trip_func_getcountryidandnamebycountryname(strnames "varchar",
     //iexactmatch int4, ilimit int4, ioffset int4)
    
     string strQuery = null;
     bool bQuerySuccess = false;
     IMLogin tripLogin = null;
    
     try {
        
         strQuery = "SELECT * FROM trip_func_getcountrymaindetailsbycountryid(" + lCountryID + ");";
        
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

                 foreach (DataTable myDataTablesCountry in tripLogin.PGDataSet.Tables)
                 {

                     //Check if there is any data. If not exit
                     if (myDataTablesCountry.Rows.Count == 0)
                     {
                         //Return a value indicating that the search was not successful
                         return false;

                     }
                     else
                     {
                         dtCountryDataset = tripLogin.PGDataSet;
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
            
         tripLogin = null;        
     }
 }

        public bool RetrieveCurrencyNameCodeCountryNameCountryIDList() 
        {
    
             //RETRIEVES A LIST OF ALL COUNTRIES
            
             // trip_func_getcountryidandnamebycountryname(strnames "varchar",
             //iexactmatch int4, ilimit int4, ioffset int4)
            
             string strQuery = null;
             bool bQuerySuccess = false;
             IMLogin tripLogin = null;
            
             try 
             {
                 
                 strQuery = "SELECT * FROM trip_func_getcurrencynamecodecountrynamecountrylist() AS (" + 
                            "\"CURRENCYLIST\"" + "text," +
                            "\"COUNTRYID\"" + "int4)";
                
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

                         foreach (DataTable myDataTablesCountry in tripLogin.PGDataSet.Tables)
                         {

                             //Check if there is any data. If not exit
                             if (myDataTablesCountry.Rows.Count == 0)
                             {

                                 //Return a value indicating that the search was not successful
                                 return false;

                             }
                             else
                             {

                                 dtCountryDataset = tripLogin.PGDataSet;
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
               
                 tripLogin = null;
                
             }
 }

        public bool RetrieveCountryByText(long lExactMatch, long lLimit, long lOffset)
 {
    
     //RETRIEVES A LIST OF ALL COUNTRIES
    
     // trip_func_getcountryidandnamebycountryname(strnames "varchar",
     //iexactmatch int4, ilimit int4, ioffset int4)
    
     string strQuery = null;
     bool bQuerySuccess = false;
     IMLogin tripLogin = null;
    
     try {
        
         strQuery = "SELECT * FROM trip_func_getcountrybytext('" + strCountryName + "'," + lExactMatch + "," + lLimit + "," + lOffset + ");";
        
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

                 foreach (DataTable myDataTablesCountry in tripLogin.PGDataSet.Tables)
                 {

                     //Check if there is any data. If not exit
                     if (myDataTablesCountry.Rows.Count == 0)
                     {

                         //Return a value indicating that the search was not successful
                         return false;
                     }
                     else
                     {

                         dtCountryDataset = tripLogin.PGDataSet;
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
            
         tripLogin = null;
        
     }
 }

 #endregion

    }
}
