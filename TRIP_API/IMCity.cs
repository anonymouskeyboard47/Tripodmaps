using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace TRIP_API
{
    public class IMCity
    {

        #region "PrivateVariables"

        private string strCityName;
        private long lCityCode;
        private long lCityID;
        private long lCityTypeID;
        private long bCapitalCity;
        private DataSet dtCityDataset;

#endregion


        #region "Properties"


        public string CityName
        {
            //USED TO SET AND RETRIEVE THE CityName value (String)
            get { return strCityName; }

            set { strCityName = value; }
        }

        public long CityCode
        {
            //USED TO SET AND RETRIEVE THE CityCode value (String)
            get { return lCityCode; }

            set { lCityCode = value; }
        }

        public long CityID
        {
            //USED TO SET AND RETRIEVE THE CityID value (String)
            get { return lCityID; }

            set { lCityID = value; }
        }

        public long CityTypeID
        {
            //USED TO SET AND RETRIEVE THE CityTypeID value (String)
            get { return lCityTypeID; }

            set { lCityTypeID = value; }
        }

        public long CapitalCity
        {
            //USED TO SET AND RETRIEVE THE Capital City Value (Boolean)
            get { return bCapitalCity; }

            set { bCapitalCity = value; }
        }

        public DataSet CityDataset
        {
            //USED TO SET AND RETRIEVE THE COUNTRY CODE STRING VALUE
            get { return dtCityDataset; }
        }


        #endregion


#region "IntitializationProcedures"

        public IMCity()
            : base()
        {
        }

#endregion


        #region "GeneralProcedures"



#endregion


        #region "DatabaseProcedures"

        public bool RetrieveCityIDAndNameByCityName(long lExactMatch, long lLimit, long lOffset)
        {

            //RETRIEVES A LIST OF ALL CITIES

            // trip_func_getcountryidandnamebycountryname(strnames "varchar",
            //iexactmatch int4, ilimit int4, ioffset int4)

            string strQuery = null;
            bool bQuerySuccess = false;
            IMLogin tripLogin = null;

            try
            {

                strQuery = "SELECT * FROM trip_func_getcityidandnamebycitytioname('" + strCityName + "'," + lExactMatch + "," 
                    + lLimit + "," + lOffset + ");";

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

                        foreach (DataTable myDataTablesCity in tripLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesCity.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;
                            }
                            else
                            {

                                dtCityDataset = tripLogin.PGDataSet;
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

        public bool RetrieveCityByCityID(long lExactMatch, long lLimit, long lOffset)
        {

            //RETRIEVES A LIST OF ALL CITIES USING THE CITYID

            // trip_func_getcountryidandnamebycountryname(strnames "varchar",
            //iexactmatch int4, ilimit int4, ioffset int4)

            string strQuery = null;
            bool bQuerySuccess = false;
            IMLogin tripLogin = null;

            try
            {

                strQuery = "SELECT * FROM trip_func_getcitymaindetailsbycityid(" + lCityID + ");";

                tripLogin = new IMLogin();

                bQuerySuccess = tripLogin.ExecutePGPostgresQuery(strQuery);


                if (tripLogin.PGDataSet == null)
                {
                    return false;
                }

                if (bQuerySuccess == true)
                {

                    foreach (DataTable myDataTablesCity in tripLogin.PGDataSet.Tables)
                    {
                        //Check if there is any data. If not exit
                        if (myDataTablesCity.Rows.Count == 0)
                        {
                            //Return a value indicating that the search was not successful
                            return false;
                        }

                        dtCityDataset = tripLogin.PGDataSet;
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

        public bool RetrieveCityByText(long lExactMatch, long lLimit, long lOffset)
        {

            //RETRIEVES A LIST OF ALL COUNTRIES

            // trip_func_getcountryidandnamebycountryname(strnames "varchar",
            //iexactmatch int4, ilimit int4, ioffset int4)

            string strQuery = null;
            bool bQuerySuccess = false;
            IMLogin tripLogin = null;

            try
            {

                strQuery = "SELECT * FROM trip_func_getcitybytext('" + strCityName + "'," + lExactMatch + "," + lLimit + "," + lOffset + ");";

                tripLogin = new IMLogin();

                bQuerySuccess = tripLogin.ExecutePGPostgresQuery(strQuery);


                if (tripLogin.PGDataSet == null)
                {
                    return false;
                }

                if (bQuerySuccess == true)
                {

                    foreach (DataTable myDataTablesCity in tripLogin.PGDataSet.Tables)
                    {

                        //Check if there is any data. If not exit
                        if (myDataTablesCity.Rows.Count == 0)
                        {

                            //Return a value indicating that the search was not successful
                            return false;
                        }

                        dtCityDataset = tripLogin.PGDataSet;
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
