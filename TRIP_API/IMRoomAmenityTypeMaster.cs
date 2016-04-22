using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace TRIP_API
{
    public class IMRoomAmenityTypeMaster
    {

        #region "Variable"


        private long lRoomAmenityTypeID = 0;
        private string strRoomAmenityTypeName = "";
        private string strRoomAmenityTypeDescription = "";
        private DateTime dtDateCreated;
        private DateTime dtDateRegistered;
        private DateTime dtDateDeRegistered;
        private DataSet datRoomAmenityTypes;


        #endregion


        #region "Properties"


        public long RoomAmenityTypeMasterID
        {
            get { return lRoomAmenityTypeID; }
            set { lRoomAmenityTypeID = value; }
        }

        public string RoomAmenityTypeMasterName
        {
            get { return strRoomAmenityTypeName; }
            set { strRoomAmenityTypeName = value; }
        }

        public string RoomAmenityTypeMasterDescription
        {
            get { return strRoomAmenityTypeDescription; }
            set { strRoomAmenityTypeDescription = value; }
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

        public DataSet RoomAmenityTypeDataSet
        {
            get { return datRoomAmenityTypes; }
            set { datRoomAmenityTypes = value; }
        }


        #endregion


        #region "DatabaseFunctions"


        public bool ReturnAllRoomAmenityTypeByRoomAmenityTypeID(long lLimit, long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getroomamenitytypesmasterbyroomtypeid(0," + lLimit +
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

                        foreach (DataTable myDataTablesRoomAmenityType in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesRoomAmenityType.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                datRoomAmenityTypes = objLogin.PGDataSet;
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

        public bool ReturnRoomAmenityTypeByRoomAmenityTypeID(long lLimit, long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getroomamenitytypesmasterbyroomtypeid(" + lRoomAmenityTypeID + "," + lLimit +
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

                        foreach (DataTable myDataTablesRoomAmenityType in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesRoomAmenityType.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsRoomAmenityType in myDataTablesRoomAmenityType.Rows)
                                {
                                    if (myDataRowsRoomAmenityType["ROOMAMENITYTYPEMASTERID"] != DBNull.Value)
                                    {
                                        lRoomAmenityTypeID = Convert.ToInt64(myDataRowsRoomAmenityType["ROOMAMENITYTYPEMASTERID"]);
                                    }

                                    if (myDataRowsRoomAmenityType["ROOMAMENITYTYPEMASTERNAME"] != DBNull.Value)
                                    {
                                        strRoomAmenityTypeName = myDataRowsRoomAmenityType["ROOMAMENITYTYPEMASTERNAME"].ToString();
                                    }

                                    if (myDataRowsRoomAmenityType["ROOMAMENITYTYPEMASTERDESCRIPTION"] != DBNull.Value)
                                    {
                                        strRoomAmenityTypeDescription = myDataRowsRoomAmenityType["ROOMAMENITYTYPEMASTERDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsRoomAmenityType["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsRoomAmenityType["DATECREATED"]);
                                    }

                                    if (myDataRowsRoomAmenityType["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsRoomAmenityType["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsRoomAmenityType["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsRoomAmenityType["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsRoomAmenityType["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsRoomAmenityType["USERID"]);

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

        public bool ReturnAllRoomAmenityTypeIDAndRoomAmenityTypeNameByRoomAmenityTypeID(long lLimit, long lOffset)
        {

            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getroomamenitytypeidandnamebyroomamenitytypeid(0," + lLimit +
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

                        foreach (DataTable myDataTablesRoomAmenityType in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesRoomAmenityType.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                datRoomAmenityTypes = objLogin.PGDataSet;

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

        public bool ReturnRoomAmenityTypeIDAndRoomAmenityTypeNameByRoomAmenityTypeID(long lLimit, long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getroomamenitytypeidandnamebyroomamenitytypeid(" + lRoomAmenityTypeID + "," + lLimit +
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

                        foreach (DataTable myDataTablesRoomAmenityType in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesRoomAmenityType.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsRoomAmenityType in myDataTablesRoomAmenityType.Rows)
                                {
                                    if (myDataRowsRoomAmenityType["ROOMAMENITYTYPEMASTERID"] != DBNull.Value)
                                    {
                                        lRoomAmenityTypeID = Convert.ToInt64(myDataRowsRoomAmenityType["ROOMAMENITYTYPEMASTERID"]);
                                    }

                                    if (myDataRowsRoomAmenityType["ROOMAMENITYTYPEMASTERNAME"] != DBNull.Value)
                                    {
                                        strRoomAmenityTypeName = myDataRowsRoomAmenityType["ROOMAMENITYTYPEMASTERNAME"].ToString();
                                    }

                                    if (myDataRowsRoomAmenityType["ROOMAMENITYTYPEMASTERDESCRIPTION"] != DBNull.Value)
                                    {
                                        strRoomAmenityTypeDescription = myDataRowsRoomAmenityType["ROOMAMENITYTYPEMASTERDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsRoomAmenityType["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsRoomAmenityType["DATECREATED"]);
                                    }

                                    if (myDataRowsRoomAmenityType["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsRoomAmenityType["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsRoomAmenityType["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsRoomAmenityType["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsRoomAmenityType["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsRoomAmenityType["USERID"]);

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

        public bool ReturnFirstRoomAmenityTypeMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getfirstroomamenitytypemaster()";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesRoomAmenityType in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesRoomAmenityType.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsRoomAmenityType in myDataTablesRoomAmenityType.Rows)
                                {
                                    if (myDataRowsRoomAmenityType["ROOMAMENITYTYPEMASTERID"] != DBNull.Value)
                                    {
                                        lRoomAmenityTypeID = Convert.ToInt64(myDataRowsRoomAmenityType["ROOMAMENITYTYPEMASTERID"]);
                                    }

                                    if (myDataRowsRoomAmenityType["ROOMAMENITYTYPEMASTERNAME"] != DBNull.Value)
                                    {
                                        strRoomAmenityTypeName = myDataRowsRoomAmenityType["ROOMAMENITYTYPEMASTERNAME"].ToString();
                                    }

                                    if (myDataRowsRoomAmenityType["ROOMAMENITYTYPEMASTERDESCRIPTION"] != DBNull.Value)
                                    {
                                        strRoomAmenityTypeDescription = myDataRowsRoomAmenityType["ROOMAMENITYTYPEMASTERDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsRoomAmenityType["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsRoomAmenityType["DATECREATED"]);
                                    }

                                    if (myDataRowsRoomAmenityType["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsRoomAmenityType["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsRoomAmenityType["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsRoomAmenityType["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsRoomAmenityType["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsRoomAmenityType["USERID"]);

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

        public bool ReturnNextRoomAmenityTypeMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getnextroomamenitytypemaster(" + lRoomAmenityTypeID + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesRoomAmenityType in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesRoomAmenityType.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsRoomAmenityType in myDataTablesRoomAmenityType.Rows)
                                {
                                    if (myDataRowsRoomAmenityType["ROOMAMENITYTYPEMASTERID"] != DBNull.Value)
                                    {
                                        lRoomAmenityTypeID = Convert.ToInt64(myDataRowsRoomAmenityType["ROOMAMENITYTYPEMASTERID"]);
                                    }

                                    if (myDataRowsRoomAmenityType["ROOMAMENITYTYPEMASTERNAME"] != DBNull.Value)
                                    {
                                        strRoomAmenityTypeName = myDataRowsRoomAmenityType["ROOMAMENITYTYPEMASTERNAME"].ToString();
                                    }

                                    if (myDataRowsRoomAmenityType["ROOMAMENITYTYPEMASTERDESCRIPTION"] != DBNull.Value)
                                    {
                                        strRoomAmenityTypeDescription = myDataRowsRoomAmenityType["ROOMAMENITYTYPEMASTERDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsRoomAmenityType["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsRoomAmenityType["DATECREATED"]);
                                    }

                                    if (myDataRowsRoomAmenityType["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsRoomAmenityType["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsRoomAmenityType["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsRoomAmenityType["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsRoomAmenityType["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsRoomAmenityType["USERID"]);

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

        public bool ReturnPreviousRoomAmenityTypeMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getprevroomamenitytypemaster(" + lRoomAmenityTypeID + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesRoomAmenityType in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesRoomAmenityType.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsRoomAmenityType in myDataTablesRoomAmenityType.Rows)
                                {
                                    if (myDataRowsRoomAmenityType["ROOMAMENITYTYPEMASTERID"] != DBNull.Value)
                                    {
                                        lRoomAmenityTypeID = Convert.ToInt64(myDataRowsRoomAmenityType["ROOMAMENITYTYPEMASTERID"]);
                                    }

                                    if (myDataRowsRoomAmenityType["ROOMAMENITYTYPEMASTERNAME"] != DBNull.Value)
                                    {
                                        strRoomAmenityTypeName = myDataRowsRoomAmenityType["ROOMAMENITYTYPEMASTERNAME"].ToString();
                                    }

                                    if (myDataRowsRoomAmenityType["ROOMAMENITYTYPEMASTERDESCRIPTION"] != DBNull.Value)
                                    {
                                        strRoomAmenityTypeDescription = myDataRowsRoomAmenityType["ROOMAMENITYTYPEMASTERDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsRoomAmenityType["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsRoomAmenityType["DATECREATED"]);
                                    }

                                    if (myDataRowsRoomAmenityType["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsRoomAmenityType["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsRoomAmenityType["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsRoomAmenityType["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsRoomAmenityType["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsRoomAmenityType["USERID"]);

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

        public bool ReturnLastRoomAmenityTypeMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getlastroomamenitytypemaster()";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesRoomAmenityType in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesRoomAmenityType.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsRoomAmenityType in myDataTablesRoomAmenityType.Rows)
                                {
                                    if (myDataRowsRoomAmenityType["ROOMAMENITYTYPEMASTERID"] != DBNull.Value)
                                    {
                                        lRoomAmenityTypeID = Convert.ToInt64(myDataRowsRoomAmenityType["ROOMAMENITYTYPEMASTERID"]);
                                    }

                                    if (myDataRowsRoomAmenityType["ROOMAMENITYTYPEMASTERNAME"] != DBNull.Value)
                                    {
                                        strRoomAmenityTypeName = myDataRowsRoomAmenityType["ROOMAMENITYTYPEMASTERNAME"].ToString();
                                    }

                                    if (myDataRowsRoomAmenityType["ROOMAMENITYTYPEMASTERDESCRIPTION"] != DBNull.Value)
                                    {
                                        strRoomAmenityTypeDescription = myDataRowsRoomAmenityType["ROOMAMENITYTYPEMASTERDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsRoomAmenityType["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsRoomAmenityType["DATECREATED"]);
                                    }

                                    if (myDataRowsRoomAmenityType["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsRoomAmenityType["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsRoomAmenityType["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsRoomAmenityType["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsRoomAmenityType["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsRoomAmenityType["USERID"]);

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

        public bool SaveRoomAmenityTypeMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT trip_func_insertupdatecaptureroomamenitytypemaster(" +
                    lRoomAmenityTypeID + ",'" + strRoomAmenityTypeName.Trim() + "','" 
                    + strRoomAmenityTypeDescription.Trim() + "')";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesRoomAmenityType in objLogin.PGDataSet.Tables)
                        {
                            //Check if there is any data. If not exit
                            if (myDataTablesRoomAmenityType.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;
                            }
                            else
                            {
                                datRoomAmenityTypes = objLogin.PGDataSet;
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
