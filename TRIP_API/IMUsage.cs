using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace TRIP_API
{
    public class IMUsage
    {
        #region "Variable"

        private long lUsageID = 0;
        private string strUsageName = "";
        private string strUsageDescription = "";
        private DateTime dtDateCreated;
        private DateTime dtDateRegistered;
        private DateTime dtDateDeRegistered;
        private DataSet datUsage;

        #endregion

        #region "Properties"

        public long UsageID
        {
            get { return lUsageID; }
            set { lUsageID = value; }
        }


        public string UsageName
        {
            get { return strUsageName; }
            set { strUsageName = value; }
        }

        public string UsageDescription
        {
            get { return strUsageDescription; }
            set { strUsageDescription = value; }
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
            get { return dtDateRegistered; }
            set { dtDateDeRegistered = value; }
        }

        public DataSet UsageDataset
        {
            get { return datUsage; }
            set { datUsage = value; }
        }

        #endregion

        #region "DatabaseFunctions"

        public bool ReturnAllUsageMasterByUsageID(long lLimit,
            long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getusagemasterbyusageid(" + lUsageID + "," + lLimit +
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

                        foreach (DataTable myDataTablesUsage in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesUsage.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {
                                
                                    datUsage = objLogin.PGDataSet;
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

        public bool ReturnUsageMasterByUsageID(long lLimit,
            long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getusagemasterbyusageid(" + lUsageID + "," + lLimit +
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

                        foreach (DataTable myDataTablesUsage in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesUsage.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsUsage in myDataTablesUsage.Rows)
                                {
                                    if (myDataRowsUsage["USAGEID"] != DBNull.Value)
                                    {
                                        lUsageID = Convert.ToInt64(myDataRowsUsage["USAGEID"]);
                                    }

                                    if (myDataRowsUsage["USAGENAME"] != DBNull.Value)
                                    {
                                        strUsageName = myDataRowsUsage["USAGENAME"].ToString();
                                    }

                                    if (myDataRowsUsage["USAGEDESCRIPTION"] != DBNull.Value)
                                    {
                                        strUsageDescription = myDataRowsUsage["USAGEDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsUsage["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsUsage["DATECREATED"]);
                                    }

                                    if (myDataRowsUsage["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsUsage["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsUsage["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsUsage["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsUsage["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsUsage["USERID"]);

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

        public bool ReturnAllUsageIDAndUsageNameByUsageID(long lLimit,
            long lOffset)
        {

            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getusageidandusagenamebyusageid(" + lUsageID + "," + lLimit +
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

                        foreach (DataTable myDataTablesUsage in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesUsage.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {
                                                                
                                    datUsage = objLogin.PGDataSet;
                                
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

        public bool ReturnUsageIDAndUsageNameByUsageID(long lLimit,
            long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getusageidandusagenamebyusageid(" + lUsageID + "," + lLimit +
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

                        foreach (DataTable myDataTablesUsage in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesUsage.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                              

                                    foreach (DataRow myDataRowsUsage in myDataTablesUsage.Rows)
                                    {
                                        if (myDataRowsUsage["USAGEID"] != DBNull.Value)
                                        {
                                            lUsageID = Convert.ToInt64(myDataRowsUsage["USAGEID"]);
                                        }

                                        if (myDataRowsUsage["USAGENAME"] != DBNull.Value)
                                        {
                                            strUsageName = myDataRowsUsage["USAGENAME"].ToString();
                                        }

                                        if (myDataRowsUsage["USAGEDESCRIPTION"] != DBNull.Value)
                                        {
                                            strUsageDescription = myDataRowsUsage["USAGEDESCRIPTION"].ToString();
                                        }

                                        if (myDataRowsUsage["DATECREATED"] != DBNull.Value)
                                        {
                                            dtDateCreated = Convert.ToDateTime(myDataRowsUsage["DATECREATED"]);
                                        }

                                        if (myDataRowsUsage["DATEREGISTERED"] != DBNull.Value)
                                        {
                                            dtDateRegistered = Convert.ToDateTime(myDataRowsUsage["DATEREGISTERED"]);
                                        }

                                        if (myDataRowsUsage["DATEDEREGISTERED"] != DBNull.Value)
                                        {
                                            dtDateDeRegistered = Convert.ToDateTime(myDataRowsUsage["DATEDEREGISTERED"]);                                            
                                        }

                                        //if (myDataRowsUsage["USERID"] != DBNull.Value)
                                        //{

                                        //UserID = Convert.ToInt64(myDataRowsUsage["USERID"]);

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


        public bool ReturnFirstUsageMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getfirstusagemaster()";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesUsage in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesUsage.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsUsage in myDataTablesUsage.Rows)
                                {
                                    if (myDataRowsUsage["USAGEID"] != DBNull.Value)
                                    {
                                        lUsageID = Convert.ToInt64(myDataRowsUsage["USAGEID"]);
                                    }

                                    if (myDataRowsUsage["USAGENAME"] != DBNull.Value)
                                    {
                                        strUsageName = myDataRowsUsage["USAGENAME"].ToString();
                                    }

                                    if (myDataRowsUsage["USAGEDESCRIPTION"] != DBNull.Value)
                                    {
                                        strUsageDescription = myDataRowsUsage["USAGEDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsUsage["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsUsage["DATECREATED"]);
                                    }

                                    if (myDataRowsUsage["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsUsage["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsUsage["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsUsage["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsUsage["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsUsage["USERID"]);

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

        public bool ReturnNextUsageMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getnextusagemaster(" + lUsageID + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesUsage in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesUsage.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsUsage in myDataTablesUsage.Rows)
                                {
                                    if (myDataRowsUsage["USAGEID"] != DBNull.Value)
                                    {
                                        lUsageID = Convert.ToInt64(myDataRowsUsage["USAGEID"]);
                                    }

                                    if (myDataRowsUsage["USAGENAME"] != DBNull.Value)
                                    {
                                        strUsageName = myDataRowsUsage["USAGENAME"].ToString();
                                    }

                                    if (myDataRowsUsage["USAGEDESCRIPTION"] != DBNull.Value)
                                    {
                                        strUsageDescription = myDataRowsUsage["USAGEDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsUsage["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsUsage["DATECREATED"]);
                                    }

                                    if (myDataRowsUsage["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsUsage["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsUsage["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsUsage["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsUsage["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsUsage["USERID"]);

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

        public bool ReturnPreviousUsageMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getprevusagemaster(" + lUsageID + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesUsage in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesUsage.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsUsage in myDataTablesUsage.Rows)
                                {
                                    if (myDataRowsUsage["USAGEID"] != DBNull.Value)
                                    {
                                        lUsageID = Convert.ToInt64(myDataRowsUsage["USAGEID"]);
                                    }

                                    if (myDataRowsUsage["USAGENAME"] != DBNull.Value)
                                    {
                                        strUsageName = myDataRowsUsage["USAGENAME"].ToString();
                                    }

                                    if (myDataRowsUsage["USAGEDESCRIPTION"] != DBNull.Value)
                                    {
                                        strUsageDescription = myDataRowsUsage["USAGEDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsUsage["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsUsage["DATECREATED"]);
                                    }

                                    if (myDataRowsUsage["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsUsage["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsUsage["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsUsage["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsUsage["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsUsage["USERID"]);

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

        public bool ReturnLastUsageMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getlastusagemaster()";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesUsage in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesUsage.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsUsage in myDataTablesUsage.Rows)
                                {
                                    if (myDataRowsUsage["USAGEID"] != DBNull.Value)
                                    {
                                        lUsageID = Convert.ToInt64(myDataRowsUsage["USAGEID"]);
                                    }

                                    if (myDataRowsUsage["USAGENAME"] != DBNull.Value)
                                    {
                                        strUsageName = myDataRowsUsage["USAGENAME"].ToString();
                                    }

                                    if (myDataRowsUsage["USAGEDESCRIPTION"] != DBNull.Value)
                                    {
                                        strUsageDescription = myDataRowsUsage["USAGEDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsUsage["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsUsage["DATECREATED"]);
                                    }

                                    if (myDataRowsUsage["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsUsage["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsUsage["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsUsage["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsUsage["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsUsage["USERID"]);

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
