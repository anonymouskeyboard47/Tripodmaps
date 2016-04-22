using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace TRIP_API
{
    public class IMRoadClassMaster
    {

        #region "Variable"

        private long lRoadClassID = 0;
        private string strRoadClassName = "";
        private string strRoadClassDescription = "";
        private DateTime dtDateCreated;
        private DateTime dtDateRegistered;
        private DateTime dtDateDeRegistered;
        private DataSet datRoadClass;
        #endregion


        #region "Properties"

        public long RoadClassMasterID
        {
            get { return lRoadClassID; }
            set { lRoadClassID = value; }
        }

        public string RoadClassMasterName
        {
            get { return strRoadClassName; }
            set { strRoadClassName = value; }
        }

        public string RoadClassMasterDescription
        {
            get { return strRoadClassDescription; }
            set { strRoadClassDescription = value; }
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

        public DataSet RoadClassDataSet
        {
            get { return datRoadClass; }
            set { datRoadClass = value; }
        }

        #endregion


        #region "DatabaseFunctions"


        public bool ReturnAllRoadClassByRoadClassID(long lLimit,
            long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getroadclassmasterbyroadclassid(0," + lLimit +
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

                        foreach (DataTable myDataTablesRoadClass in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesRoadClass.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                datRoadClass = objLogin.PGDataSet;
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

        public bool ReturnRoadClassByRoadClassID(long lLimit,
            long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getroadclassmasterbyroadclassid(" + lRoadClassID + "," + lLimit +
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

                        foreach (DataTable myDataTablesRoadClass in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesRoadClass.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsRoadClass in myDataTablesRoadClass.Rows)
                                {
                                    if (myDataRowsRoadClass["ROADCLASSID"] != DBNull.Value)
                                    {
                                        lRoadClassID = Convert.ToInt64(myDataRowsRoadClass["ROADCLASSID"]);
                                    }

                                    if (myDataRowsRoadClass["ROADCLASSNAME"] != DBNull.Value)
                                    {
                                        strRoadClassName = myDataRowsRoadClass["ROADCLASSNAME"].ToString();
                                    }

                                    if (myDataRowsRoadClass["ROADCLASSDESCRIPTION"] != DBNull.Value)
                                    {
                                        strRoadClassDescription = myDataRowsRoadClass["ROADCLASSDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsRoadClass["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsRoadClass["DATECREATED"]);
                                    }

                                    if (myDataRowsRoadClass["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsRoadClass["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsRoadClass["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsRoadClass["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsRoadClass["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsRoadClass["USERID"]);

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

        public bool ReturnAllRoadClassIDAndRoadClassNameByRoadClassID(long lLimit,
            long lOffset)
        {

            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getroadclassidandnamebyroadclassid(0," + lLimit +
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

                        foreach (DataTable myDataTablesRoadClass in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesRoadClass.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                datRoadClass = objLogin.PGDataSet;

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

        public bool ReturnRoadClassIDAndRoadClassNameByRoadClassID(long lLimit,
            long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getroadclassidandnamebyroadclassid(" + lRoadClassID + "," + lLimit +
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

                        foreach (DataTable myDataTablesRoadClass in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesRoadClass.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsRoadClass in myDataTablesRoadClass.Rows)
                                {
                                    if (myDataRowsRoadClass["ROADCLASSID"] != DBNull.Value)
                                    {
                                        lRoadClassID = Convert.ToInt64(myDataRowsRoadClass["ROADCLASSID"]);
                                    }

                                    if (myDataRowsRoadClass["ROADCLASSNAME"] != DBNull.Value)
                                    {
                                        strRoadClassName = myDataRowsRoadClass["ROADCLASSNAME"].ToString();
                                    }

                                    if (myDataRowsRoadClass["ROADCLASSDESCRIPTION"] != DBNull.Value)
                                    {
                                        strRoadClassDescription = myDataRowsRoadClass["ROADCLASSDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsRoadClass["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsRoadClass["DATECREATED"]);
                                    }

                                    if (myDataRowsRoadClass["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsRoadClass["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsRoadClass["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsRoadClass["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsRoadClass["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsRoadClass["USERID"]);

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

        public bool ReturnFirstRoadClassMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getfirstroadclassmaster()";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesRoadClass in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesRoadClass.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsRoadClass in myDataTablesRoadClass.Rows)
                                {
                                    if (myDataRowsRoadClass["ROADCLASSID"] != DBNull.Value)
                                    {
                                        lRoadClassID = Convert.ToInt64(myDataRowsRoadClass["ROADCLASSID"]);
                                    }

                                    if (myDataRowsRoadClass["ROADCLASSNAME"] != DBNull.Value)
                                    {
                                        strRoadClassName = myDataRowsRoadClass["ROADCLASSNAME"].ToString();
                                    }

                                    if (myDataRowsRoadClass["ROADCLASSDESCRIPTION"] != DBNull.Value)
                                    {
                                        strRoadClassDescription = myDataRowsRoadClass["ROADCLASSDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsRoadClass["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsRoadClass["DATECREATED"]);
                                    }

                                    if (myDataRowsRoadClass["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsRoadClass["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsRoadClass["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsRoadClass["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsRoadClass["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsRoadClass["USERID"]);

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

        public bool ReturnNextRoadClassMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getnextroadclassmaster(" + lRoadClassID + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesRoadClass in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesRoadClass.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsRoadClass in myDataTablesRoadClass.Rows)
                                {
                                    if (myDataRowsRoadClass["ROADCLASSID"] != DBNull.Value)
                                    {
                                        lRoadClassID = Convert.ToInt64(myDataRowsRoadClass["ROADCLASSID"]);
                                    }

                                    if (myDataRowsRoadClass["ROADCLASSNAME"] != DBNull.Value)
                                    {
                                        strRoadClassName = myDataRowsRoadClass["ROADCLASSNAME"].ToString();
                                    }

                                    if (myDataRowsRoadClass["ROADCLASSDESCRIPTION"] != DBNull.Value)
                                    {
                                        strRoadClassDescription = myDataRowsRoadClass["ROADCLASSDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsRoadClass["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsRoadClass["DATECREATED"]);
                                    }

                                    if (myDataRowsRoadClass["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsRoadClass["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsRoadClass["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsRoadClass["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsRoadClass["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsRoadClass["USERID"]);

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

        public bool ReturnPreviousRoadClassMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getprevroadclassmaster(" + lRoadClassID + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesRoadClass in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesRoadClass.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsRoadClass in myDataTablesRoadClass.Rows)
                                {
                                    if (myDataRowsRoadClass["ROADCLASSID"] != DBNull.Value)
                                    {
                                        lRoadClassID = Convert.ToInt64(myDataRowsRoadClass["ROADCLASSID"]);
                                    }

                                    if (myDataRowsRoadClass["ROADCLASSNAME"] != DBNull.Value)
                                    {
                                        strRoadClassName = myDataRowsRoadClass["ROADCLASSNAME"].ToString();
                                    }

                                    if (myDataRowsRoadClass["ROADCLASSDESCRIPTION"] != DBNull.Value)
                                    {
                                        strRoadClassDescription = myDataRowsRoadClass["ROADCLASSDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsRoadClass["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsRoadClass["DATECREATED"]);
                                    }

                                    if (myDataRowsRoadClass["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsRoadClass["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsRoadClass["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsRoadClass["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsRoadClass["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsRoadClass["USERID"]);

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

        public bool ReturnLastRoadClassMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getlastroadclassmaster()";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesRoadClass in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesRoadClass.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsRoadClass in myDataTablesRoadClass.Rows)
                                {
                                    if (myDataRowsRoadClass["ROADCLASSID"] != DBNull.Value)
                                    {
                                        lRoadClassID = Convert.ToInt64(myDataRowsRoadClass["ROADCLASSID"]);
                                    }

                                    if (myDataRowsRoadClass["ROADCLASSNAME"] != DBNull.Value)
                                    {
                                        strRoadClassName = myDataRowsRoadClass["ROADCLASSNAME"].ToString();
                                    }

                                    if (myDataRowsRoadClass["ROADCLASSDESCRIPTION"] != DBNull.Value)
                                    {
                                        strRoadClassDescription = myDataRowsRoadClass["ROADCLASSDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsRoadClass["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsRoadClass["DATECREATED"]);
                                    }

                                    if (myDataRowsRoadClass["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsRoadClass["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsRoadClass["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsRoadClass["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsRoadClass["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsRoadClass["USERID"]);

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
