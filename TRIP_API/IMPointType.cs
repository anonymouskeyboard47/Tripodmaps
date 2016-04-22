using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NpgsqlTypes;
using System.IO;

namespace TRIP_API
{
    public class IMPointTypes
    {
        //Contains list of poi classes a particular point belongs to


        #region "Variable"

        private long lPointID = 0;
        private long lMapID = 0;
        private NpgsqlPoint npgpntPointCoordinate;
        private string strPointName = "";
        private string strPointDescription = "";
        private DateTime dtDateCreated;
        private DateTime dtDateRegistered;
        private DateTime dtDateDeRegistered;
        private DataSet datPoints;
        #endregion


        #region "Properties"

        public long PointID
        {
            get { return lPointID; }
            set { lPointID = value; }
        }

        public long MapID
        {
            get { return lMapID; }
            set { lMapID = value; }
        }

        public NpgsqlPoint PointCoordinate
        {
            get { return npgpntPointCoordinate; }
            set { npgpntPointCoordinate = value; }
        }

        public string PointName
        {
            get { return strPointName; }
            set { strPointName = value; }
        }

        public string PointDescription
        {
            get { return strPointDescription; }
            set { strPointDescription = value; }
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

        public DataSet PointsDataSet
        {
            get { return datPoints; }
            set { datPoints = value; }
        }

        #endregion


        #region "DatabaseFunctions"

        public bool ReturnAllPointsByPointID(long lLimit,
            long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getpointmasterbypointid(0," + lLimit +
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

                                datPoints = objLogin.PGDataSet;
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

        public bool ReturnPointsByPointID(long lLimit,
            long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getpointmasterbypointid(" + lPointID + "," + lLimit +
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
                                    if (myDataRowsPoints["POINTID"] != DBNull.Value)
                                    {
                                        lPointID = Convert.ToInt64(myDataRowsPoints["POINTID"]);
                                    }

                                    if (myDataRowsPoints["POINTNAME"] != DBNull.Value)
                                    {
                                        strPointName = myDataRowsPoints["POINTNAME"].ToString();
                                    }

                                    if (myDataRowsPoints["POINTDESCRIPTION"] != DBNull.Value)
                                    {
                                        strPointDescription = myDataRowsPoints["POINTDESCRIPTION"].ToString();
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
                return false;
            }

            finally
            {
                datRetData = null;

                objLogin = null;

            }
        }

        public bool ReturnAllPointIDAndPointNameByPointID(long lLimit,
            long lOffset)
        {

            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
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

                                datPoints = objLogin.PGDataSet;

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

        public bool ReturnPointIDAndPointNameByPointID(long lLimit,
            long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getpointidandnamebypointid(" + lPointID + "," + lLimit +
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
                                    if (myDataRowsPoints["POINTID"] != DBNull.Value)
                                    {
                                        lPointID = Convert.ToInt64(myDataRowsPoints["POINTID"]);
                                    }

                                    if (myDataRowsPoints["POINTNAME"] != DBNull.Value)
                                    {
                                        strPointName = myDataRowsPoints["POINTNAME"].ToString();
                                    }

                                    if (myDataRowsPoints["POINTDESCRIPTION"] != DBNull.Value)
                                    {
                                        strPointDescription = myDataRowsPoints["POINTDESCRIPTION"].ToString();
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
                return false;
            }

            finally
            {

                datRetData = null;
                objLogin = null;

            }
        }

        public bool ReturnFirstPointMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
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
                                    if (myDataRowsPoints["POINTID"] != DBNull.Value)
                                    {
                                        lPointID = Convert.ToInt64(myDataRowsPoints["POINTID"]);
                                    }

                                    if (myDataRowsPoints["POINTNAME"] != DBNull.Value)
                                    {
                                        strPointName = myDataRowsPoints["POINTNAME"].ToString();
                                    }

                                    if (myDataRowsPoints["POINTDESCRIPTION"] != DBNull.Value)
                                    {
                                        strPointDescription = myDataRowsPoints["POINTDESCRIPTION"].ToString();
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
                return false;
            }

            finally
            {
                datRetData = null;
                objLogin = null;

            }
        }

        public bool ReturnNextPointMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getnextpointtypemaster(" + lPointID + ")";

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
                                    if (myDataRowsPoints["POINTID"] != DBNull.Value)
                                    {
                                        lPointID = Convert.ToInt64(myDataRowsPoints["POINTID"]);
                                    }

                                    if (myDataRowsPoints["POINTNAME"] != DBNull.Value)
                                    {
                                        strPointName = myDataRowsPoints["POINTNAME"].ToString();
                                    }

                                    if (myDataRowsPoints["POINTDESCRIPTION"] != DBNull.Value)
                                    {
                                        strPointDescription = myDataRowsPoints["POINTDESCRIPTION"].ToString();
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
                return false;
            }

            finally
            {
                datRetData = null;
                objLogin = null;

            }
        }

        public bool ReturnPreviousPointMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getprevpointtypemaster(" + lPointID + ")";

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
                                    if (myDataRowsPoints["POINTID"] != DBNull.Value)
                                    {
                                        lPointID = Convert.ToInt64(myDataRowsPoints["POINTID"]);
                                    }

                                    if (myDataRowsPoints["POINTNAME"] != DBNull.Value)
                                    {
                                        strPointName = myDataRowsPoints["POINTNAME"].ToString();
                                    }

                                    if (myDataRowsPoints["POINTDESCRIPTION"] != DBNull.Value)
                                    {
                                        strPointDescription = myDataRowsPoints["POINTDESCRIPTION"].ToString();
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
                return false;
            }

            finally
            {
                datRetData = null;
                objLogin = null;

            }
        }

        public bool ReturnLastPointMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
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
                                    if (myDataRowsPoints["POINTID"] != DBNull.Value)
                                    {
                                        lPointID = Convert.ToInt64(myDataRowsPoints["POINTID"]);
                                    }

                                    if (myDataRowsPoints["POINTNAME"] != DBNull.Value)
                                    {
                                        strPointName = myDataRowsPoints["POINTNAME"].ToString();
                                    }

                                    if (myDataRowsPoints["POINTDESCRIPTION"] != DBNull.Value)
                                    {
                                        strPointDescription = myDataRowsPoints["POINTDESCRIPTION"].ToString();
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
