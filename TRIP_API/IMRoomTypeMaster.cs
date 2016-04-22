using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace TRIP_API
{
    public class IMRoomTypeMaster
    {

        #region "Variable"

        private long lRoomTypeID = 0;
        private string strRoomTypeName = "";
        private string strRoomTypeDescription = "";
        private DateTime dtDateCreated;
        private DateTime dtDateRegistered;
        private DateTime dtDateDeRegistered;
        private DataSet datRoomTypes;
        #endregion


        #region "Properties"

        public long RoomTypeMasterID
        {
            get { return lRoomTypeID; }
            set { lRoomTypeID = value; }
        }

        public string RoomTypeMasterName
        {
            get { return strRoomTypeName; }
            set { strRoomTypeName = value; }
        }

        public string RoomTypeMasterDescription
        {
            get { return strRoomTypeDescription; }
            set { strRoomTypeDescription = value; }
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

        public DataSet RoomTypeMasterDataSet
        {
            get { return datRoomTypes; }
            set { datRoomTypes = value; }
        }

        #endregion


        #region "DatabaseFunctions"


        public bool ReturnAllRoomTypeMasterByRoomTypeMasterID(long lLimit, long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getroomtypemasterbyroomtypeid(0," + lLimit +
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

                        foreach (DataTable myDataTablesRoomType in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesRoomType.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                datRoomTypes = objLogin.PGDataSet;
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

        public bool ReturnRoomTypeMasterByRoomTypeMasterID(long lLimit, long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getroomtypemasterbyroomtypeid(" + lRoomTypeID + "," + lLimit +
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

                        foreach (DataTable myDataTablesRoomType in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesRoomType.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsRoomType in myDataTablesRoomType.Rows)
                                {
                                    if (myDataRowsRoomType["ROOMTYPEMASTERID"] != DBNull.Value)
                                    {
                                        lRoomTypeID = Convert.ToInt64(myDataRowsRoomType["ROOMTYPEMASTERID"]);
                                    }

                                    if (myDataRowsRoomType["ROOMTYPEMASTERNAME"] != DBNull.Value)
                                    {
                                        strRoomTypeName = myDataRowsRoomType["ROOMTYPEMASTERNAME"].ToString();
                                    }

                                    if (myDataRowsRoomType["ROOMTYPEMASTERDESCRIPTION"] != DBNull.Value)
                                    {
                                        strRoomTypeDescription = myDataRowsRoomType["ROOMTYPEMASTERDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsRoomType["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsRoomType["DATECREATED"]);
                                    }

                                    if (myDataRowsRoomType["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsRoomType["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsRoomType["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsRoomType["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsRoomType["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsRoomType["USERID"]);

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

        public bool ReturnAllRoomTypeMasterIDAndNameByRoomTypeMasterID(long lLimit, long lOffset)
        {

            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getroomtypeidandnamebyroomtypeid(0," + lLimit +
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

                        foreach (DataTable myDataTablesRoomType in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesRoomType.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                datRoomTypes = objLogin.PGDataSet;

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

        public bool ReturnRoomTypeMasterIDAndNameByRoomTypeMasterID(long lLimit, long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getroomtypeidandnamebyroomtypeid(" + lRoomTypeID + "," + lLimit +
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

                        foreach (DataTable myDataTablesRoomType in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesRoomType.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsRoomType in myDataTablesRoomType.Rows)
                                {
                                    if (myDataRowsRoomType["ROOMTYPEMASTERID"] != DBNull.Value)
                                    {
                                        lRoomTypeID = Convert.ToInt64(myDataRowsRoomType["ROOMTYPEMASTERID"]);
                                    }

                                    if (myDataRowsRoomType["ROOMTYPEMASTERNAME"] != DBNull.Value)
                                    {
                                        strRoomTypeName = myDataRowsRoomType["ROOMTYPEMASTERNAME"].ToString();
                                    }

                                    if (myDataRowsRoomType["ROOMTYPEMASTERDESCRIPTION"] != DBNull.Value)
                                    {
                                        strRoomTypeDescription = myDataRowsRoomType["ROOMTYPEMASTERDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsRoomType["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsRoomType["DATECREATED"]);
                                    }

                                    if (myDataRowsRoomType["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsRoomType["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsRoomType["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsRoomType["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsRoomType["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsRoomType["USERID"]);

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

        public bool ReturnFirstRoomTypeMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getfirstroomtypemaster()";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesRoomType in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesRoomType.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsRoomType in myDataTablesRoomType.Rows)
                                {
                                    if (myDataRowsRoomType["ROOMTYPEMASTERID"] != DBNull.Value)
                                    {
                                        lRoomTypeID = Convert.ToInt64(myDataRowsRoomType["ROOMTYPEMASTERID"]);
                                    }

                                    if (myDataRowsRoomType["ROOMTYPEMASTERNAME"] != DBNull.Value)
                                    {
                                        strRoomTypeName = myDataRowsRoomType["ROOMTYPEMASTERNAME"].ToString();
                                    }

                                    if (myDataRowsRoomType["ROOMTYPEMASTERDESCRIPTION"] != DBNull.Value)
                                    {
                                        strRoomTypeDescription = myDataRowsRoomType["ROOMTYPEMASTERDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsRoomType["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsRoomType["DATECREATED"]);
                                    }

                                    if (myDataRowsRoomType["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsRoomType["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsRoomType["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsRoomType["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsRoomType["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsRoomType["USERID"]);

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

        public bool ReturnNextRoomTypeMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getnextroomtypemaster(" + lRoomTypeID + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesRoomType in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesRoomType.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsRoomType in myDataTablesRoomType.Rows)
                                {
                                    if (myDataRowsRoomType["ROOMTYPEMASTERID"] != DBNull.Value)
                                    {
                                        lRoomTypeID = Convert.ToInt64(myDataRowsRoomType["ROOMTYPEMASTERID"]);
                                    }

                                    if (myDataRowsRoomType["ROOMTYPEMASTERNAME"] != DBNull.Value)
                                    {
                                        strRoomTypeName = myDataRowsRoomType["ROOMTYPEMASTERNAME"].ToString();
                                    }

                                    if (myDataRowsRoomType["ROOMTYPEMASTERDESCRIPTION"] != DBNull.Value)
                                    {
                                        strRoomTypeDescription = myDataRowsRoomType["ROOMTYPEMASTERDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsRoomType["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsRoomType["DATECREATED"]);
                                    }

                                    if (myDataRowsRoomType["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsRoomType["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsRoomType["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsRoomType["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsRoomType["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsRoomType["USERID"]);

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

        public bool ReturnPreviousRoomTypeMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getprevroomtypemaster(" + lRoomTypeID + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesRoomType in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesRoomType.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsRoomType in myDataTablesRoomType.Rows)
                                {
                                    if (myDataRowsRoomType["ROOMTYPEMASTERID"] != DBNull.Value)
                                    {
                                        lRoomTypeID = Convert.ToInt64(myDataRowsRoomType["ROOMTYPEMASTERID"]);
                                    }

                                    if (myDataRowsRoomType["ROOMTYPEMASTERNAME"] != DBNull.Value)
                                    {
                                        strRoomTypeName = myDataRowsRoomType["ROOMTYPEMASTERNAME"].ToString();
                                    }

                                    if (myDataRowsRoomType["ROOMTYPEMASTERDESCRIPTION"] != DBNull.Value)
                                    {
                                        strRoomTypeDescription = myDataRowsRoomType["ROOMTYPEMASTERDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsRoomType["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsRoomType["DATECREATED"]);
                                    }

                                    if (myDataRowsRoomType["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsRoomType["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsRoomType["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsRoomType["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsRoomType["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsRoomType["USERID"]);

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

        public bool ReturnLastRoomTypeMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getlastroomtypemaster()";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesRoomType in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesRoomType.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsRoomType in myDataTablesRoomType.Rows)
                                {
                                    if (myDataRowsRoomType["ROOMTYPEMASTERID"] != DBNull.Value)
                                    {
                                        lRoomTypeID = Convert.ToInt64(myDataRowsRoomType["ROOMTYPEMASTERID"]);
                                    }

                                    if (myDataRowsRoomType["ROOMTYPEMASTERNAME"] != DBNull.Value)
                                    {
                                        strRoomTypeName = myDataRowsRoomType["ROOMTYPEMASTERNAME"].ToString();
                                    }

                                    if (myDataRowsRoomType["ROOMTYPEMASTERDESCRIPTION"] != DBNull.Value)
                                    {
                                        strRoomTypeDescription = myDataRowsRoomType["ROOMTYPEMASTERDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsRoomType["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsRoomType["DATECREATED"]);
                                    }

                                    if (myDataRowsRoomType["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsRoomType["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsRoomType["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsRoomType["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsRoomType["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsRoomType["USERID"]);

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

        public bool SaveRoomTypeMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT trip_func_insertupdatecaptureroomtypemaster(" + 
                    lRoomTypeID +  ",'" + strRoomTypeName.Trim() + "','" + strRoomTypeDescription.Trim() + "')";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesRoomType in objLogin.PGDataSet.Tables)
                        {
                            //Check if there is any data. If not exit
                            if (myDataTablesRoomType.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;
                            }
                            else
                            {
                                datRoomTypes = objLogin.PGDataSet;
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
