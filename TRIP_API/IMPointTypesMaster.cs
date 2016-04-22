using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace TRIP_API
{
    public class IMPointTypesMaster
    {

        #region "Variable"

        private long lPointTypeMasterID = 0;
        private string strPointTypeMasterName = "";
        private string strPointTypeMasterDescription = "";
        private DateTime dtDateCreated;
        private DateTime dtDateRegistered;
        private DateTime dtDateDeRegistered;
        private DataSet datPointTypesMaster;
        #endregion


        #region "Properties"

        public long PointTypeMasterID
        {
            get { return lPointTypeMasterID; }
            set { lPointTypeMasterID = value; }
        }

        public string PointTypeMasterName
        {
            get { return strPointTypeMasterName; }
            set { strPointTypeMasterName = value; }
        }

        public string PointTypeMasterDescription
        {
            get { return strPointTypeMasterDescription; }
            set { strPointTypeMasterDescription = value; }
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

        public DataSet PointTypesMasterDataSet
        {
            get { return datPointTypesMaster; }
            set { datPointTypesMaster = value; }
        }

        #endregion


        #region "DatabaseFunctions"

        public bool ReturnAllPointTypesByPointTypeID(long lLimit,
            long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getpointtypemasterbypointtypeid(0," + lLimit +
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

                        foreach (DataTable myDataTablesPointTypes in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesPointTypes.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                datPointTypesMaster = objLogin.PGDataSet;
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

        public bool ReturnPointTypesByPointTypeID(long lLimit,
            long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getpointtypemasterbypointtypeid(" + lPointTypeMasterID + "," + lLimit +
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

                        foreach (DataTable myDataTablesPointTypes in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesPointTypes.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsPointTypes in myDataTablesPointTypes.Rows)
                                {
                                    if (myDataRowsPointTypes["POINTTYPEMASTERID"] != DBNull.Value)
                                    {
                                        lPointTypeMasterID = Convert.ToInt64(myDataRowsPointTypes["POINTTYPEMASTERID"]);
                                    }

                                    if (myDataRowsPointTypes["POINTTYPEMASTERNAME"] != DBNull.Value)
                                    {
                                        strPointTypeMasterName = myDataRowsPointTypes["POINTTYPEMASTERNAME"].ToString();
                                    }

                                    if (myDataRowsPointTypes["POINTTYPEMASTERDESCRIPTION"] != DBNull.Value)
                                    {
                                        strPointTypeMasterDescription = myDataRowsPointTypes["POINTTYPEMASTERDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsPointTypes["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsPointTypes["DATECREATED"]);
                                    }

                                    if (myDataRowsPointTypes["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsPointTypes["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsPointTypes["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsPointTypes["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsPointTypes["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsPointTypes["USERID"]);

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

        public bool ReturnAllPointTypeMasterIDAndPointTypeNameByPointTypeID(long lLimit,
            long lOffset)
        {

            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getpointtypeidandnamebypointtypeid(0," + lLimit +
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

                        foreach (DataTable myDataTablesPointTypes in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesPointTypes.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                datPointTypesMaster = objLogin.PGDataSet;

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

        public bool ReturnPointTypeIDAndPointTypeNameByPointTypeID(long lLimit,
            long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getpointtypeidandnamebypointtypeid(" + lPointTypeMasterID + "," + lLimit +
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

                        foreach (DataTable myDataTablesPointTypes in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesPointTypes.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {



                                foreach (DataRow myDataRowsPointTypes in myDataTablesPointTypes.Rows)
                                {
                                    if (myDataRowsPointTypes["POINTTYPEMASTERID"] != DBNull.Value)
                                    {
                                        lPointTypeMasterID = Convert.ToInt64(myDataRowsPointTypes["POINTTYPEMASTERID"]);
                                    }

                                    if (myDataRowsPointTypes["POINTTYPEMASTERNAME"] != DBNull.Value)
                                    {
                                        strPointTypeMasterName = myDataRowsPointTypes["POINTTYPEMASTERNAME"].ToString();
                                    }

                                    if (myDataRowsPointTypes["POINTTYPEMASTERDESCRIPTION"] != DBNull.Value)
                                    {
                                        strPointTypeMasterDescription = myDataRowsPointTypes["POINTTYPEMASTERDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsPointTypes["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsPointTypes["DATECREATED"]);
                                    }

                                    if (myDataRowsPointTypes["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsPointTypes["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsPointTypes["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsPointTypes["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsPointTypes["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsPointTypes["USERID"]);

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

        public bool ReturnFirstPointTypeMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
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

                        foreach (DataTable myDataTablesPointTypes in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesPointTypes.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsPointTypes in myDataTablesPointTypes.Rows)
                                {
                                    if (myDataRowsPointTypes["POINTTYPEMASTERID"] != DBNull.Value)
                                    {
                                        lPointTypeMasterID = Convert.ToInt64(myDataRowsPointTypes["POINTTYPEMASTERID"]);
                                    }

                                    if (myDataRowsPointTypes["POINTTYPEMASTERNAME"] != DBNull.Value)
                                    {
                                        strPointTypeMasterName = myDataRowsPointTypes["POINTTYPEMASTERNAME"].ToString();
                                    }

                                    if (myDataRowsPointTypes["POINTTYPEMASTERDESCRIPTION"] != DBNull.Value)
                                    {
                                        strPointTypeMasterDescription = myDataRowsPointTypes["POINTTYPEMASTERDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsPointTypes["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsPointTypes["DATECREATED"]);
                                    }

                                    if (myDataRowsPointTypes["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsPointTypes["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsPointTypes["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsPointTypes["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsPointTypes["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsPointTypes["USERID"]);

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

        public bool ReturnNextPointTypeMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getnextpointtypemaster(" + lPointTypeMasterID + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesPointTypes in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesPointTypes.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsPointTypes in myDataTablesPointTypes.Rows)
                                {
                                    if (myDataRowsPointTypes["POINTTYPEMASTERID"] != DBNull.Value)
                                    {
                                        lPointTypeMasterID = Convert.ToInt64(myDataRowsPointTypes["POINTTYPEMASTERID"]);
                                    }

                                    if (myDataRowsPointTypes["POINTTYPEMASTERNAME"] != DBNull.Value)
                                    {
                                        strPointTypeMasterName = myDataRowsPointTypes["POINTTYPEMASTERNAME"].ToString();
                                    }

                                    if (myDataRowsPointTypes["POINTTYPEMASTERDESCRIPTION"] != DBNull.Value)
                                    {
                                        strPointTypeMasterDescription = myDataRowsPointTypes["POINTTYPEMASTERDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsPointTypes["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsPointTypes["DATECREATED"]);
                                    }

                                    if (myDataRowsPointTypes["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsPointTypes["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsPointTypes["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsPointTypes["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsPointTypes["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsPointTypes["USERID"]);

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

        public bool ReturnPreviousPointTypeMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getprevpointtypemaster(" + lPointTypeMasterID + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesPointTypes in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesPointTypes.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsPointTypes in myDataTablesPointTypes.Rows)
                                {
                                    if (myDataRowsPointTypes["POINTTYPEMASTERID"] != DBNull.Value)
                                    {
                                        lPointTypeMasterID = Convert.ToInt64(myDataRowsPointTypes["POINTTYPEMASTERID"]);
                                    }

                                    if (myDataRowsPointTypes["POINTTYPEMASTERNAME"] != DBNull.Value)
                                    {
                                        strPointTypeMasterName = myDataRowsPointTypes["POINTTYPEMASTERNAME"].ToString();
                                    }

                                    if (myDataRowsPointTypes["POINTTYPEMASTERDESCRIPTION"] != DBNull.Value)
                                    {
                                        strPointTypeMasterDescription = myDataRowsPointTypes["POINTTYPEMASTERDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsPointTypes["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsPointTypes["DATECREATED"]);
                                    }

                                    if (myDataRowsPointTypes["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsPointTypes["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsPointTypes["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsPointTypes["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsPointTypes["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsPointTypes["USERID"]);

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

        public bool ReturnLastPointTypeMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
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

                        foreach (DataTable myDataTablesPointTypes in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesPointTypes.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsPointTypes in myDataTablesPointTypes.Rows)
                                {
                                    if (myDataRowsPointTypes["POINTTYPEMASTERID"] != DBNull.Value)
                                    {
                                        lPointTypeMasterID = Convert.ToInt64(myDataRowsPointTypes["POINTTYPEMASTERID"]);
                                    }

                                    if (myDataRowsPointTypes["POINTTYPEMASTERNAME"] != DBNull.Value)
                                    {
                                        strPointTypeMasterName = myDataRowsPointTypes["POINTTYPEMASTERNAME"].ToString();
                                    }

                                    if (myDataRowsPointTypes["POINTTYPEMASTERDESCRIPTION"] != DBNull.Value)
                                    {
                                        strPointTypeMasterDescription = myDataRowsPointTypes["POINTTYPEMASTERDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsPointTypes["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsPointTypes["DATECREATED"]);
                                    }

                                    if (myDataRowsPointTypes["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsPointTypes["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsPointTypes["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsPointTypes["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsPointTypes["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsPointTypes["USERID"]);

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

        public bool SavePointTypeMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT trip_func_insertupdatecapturepointtypemaster(" +
                    lPointTypeMasterID + ",'" + strPointTypeMasterName.Trim() + "','" + strPointTypeMasterDescription.Trim() + "')";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesPointType in objLogin.PGDataSet.Tables)
                        {
                            //Check if there is any data. If not exit
                            if (myDataTablesPointType.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;
                            }
                            else
                            {
                                datPointTypesMaster = objLogin.PGDataSet;
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
