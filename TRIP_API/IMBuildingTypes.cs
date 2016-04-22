using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace TRIP_API
{
    public class IMBuildingTypes
    {


        #region "Variable"

        private long lBuildingTypeID = 0;
        private string strBuildingTypeName = "";
        private string strBuildingTypeDescription = "";
        private DateTime dtDateCreated;
        private DateTime dtDateRegistered;
        private DateTime dtDateDeRegistered;
        private DataSet datBuildingTypes;
        #endregion


        #region "Properties"

        public long BuildingTypeID
        {
            get { return lBuildingTypeID; }
            set { lBuildingTypeID = value; }
        }

        public string BuildingTypeName
        {
            get { return strBuildingTypeName; }
            set { strBuildingTypeName = value; }
        }

        public string BuildingTypeDescription
        {
            get { return strBuildingTypeDescription; }
            set { strBuildingTypeDescription = value; }
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
            get { return dtDateDeRegistered; }
            set { dtDateDeRegistered = value; }
        }

        public DataSet BuildingTypesDataSet
        {
            get { return datBuildingTypes; }
            set { datBuildingTypes = value; }
        }

        #endregion


        #region "DatabaseFunctions"

        public bool ReturnAllBuildingTypesByBuildingTypeID(long lLimit,
            long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getbuildingtypemasterbybuildingtypeid(0," + lLimit +
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

                        foreach (DataTable myDataTablesBuildingTypes in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesBuildingTypes.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                datBuildingTypes = objLogin.PGDataSet;
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

        public bool ReturnBuildingTypesByBuildingTypeID(long lLimit,
            long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getbuildingtypemasterbybuildingtypeid(" + lBuildingTypeID + "," + lLimit +
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

                        foreach (DataTable myDataTablesBuildingTypes in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesBuildingTypes.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsBuildingTypes in myDataTablesBuildingTypes.Rows)
                                {
                                    if (myDataRowsBuildingTypes["BUILDINGTYPEID"] != DBNull.Value)
                                    {
                                        lBuildingTypeID = Convert.ToInt64(myDataRowsBuildingTypes["BUILDINGTYPEID"]);
                                    }

                                    if (myDataRowsBuildingTypes["BUILDINGTYPENAME"] != DBNull.Value)
                                    {
                                        strBuildingTypeName = myDataRowsBuildingTypes["BUILDINGTYPENAME"].ToString();
                                    }

                                    if (myDataRowsBuildingTypes["BUILDINGTYPEDESCRIPTION"] != DBNull.Value)
                                    {
                                        strBuildingTypeDescription = myDataRowsBuildingTypes["BUILDINGTYPEDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsBuildingTypes["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsBuildingTypes["DATECREATED"]);
                                    }

                                    if (myDataRowsBuildingTypes["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsBuildingTypes["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsBuildingTypes["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsBuildingTypes["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsBuildingTypes["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsBuildingTypes["USERID"]);

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

        public bool ReturnAllBuildingTypeIDAndBuildingTypeNameByBuildingTypeID(long lLimit,
            long lOffset)
        {

            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getbuildingtypeidandbuildingtypenamebybuildingtypeid(0," + lLimit +
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

                        foreach (DataTable myDataTablesBuildingTypes in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesBuildingTypes.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                datBuildingTypes = objLogin.PGDataSet;

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

        public bool ReturnBuildingTypeIDAndBuildingTypeNameByBuildingTypeID(long lLimit,
            long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getbuildingtypeidandbuildingtypenamebybuildingtypeid(" + lBuildingTypeID + "," + lLimit +
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

                        foreach (DataTable myDataTablesBuildingTypes in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesBuildingTypes.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {



                                foreach (DataRow myDataRowsBuildingTypes in myDataTablesBuildingTypes.Rows)
                                {
                                    if (myDataRowsBuildingTypes["BUILDINGTYPEID"] != DBNull.Value)
                                    {
                                        lBuildingTypeID = Convert.ToInt64(myDataRowsBuildingTypes["BUILDINGTYPEID"]);
                                    }

                                    if (myDataRowsBuildingTypes["BUILDINGTYPENAME"] != DBNull.Value)
                                    {
                                        strBuildingTypeName = myDataRowsBuildingTypes["BUILDINGTYPENAME"].ToString();
                                    }

                                    if (myDataRowsBuildingTypes["BUILDINGTYPEDESCRIPTION"] != DBNull.Value)
                                    {
                                        strBuildingTypeDescription = myDataRowsBuildingTypes["BUILDINGTYPEDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsBuildingTypes["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsBuildingTypes["DATECREATED"]);
                                    }

                                    if (myDataRowsBuildingTypes["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsBuildingTypes["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsBuildingTypes["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsBuildingTypes["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsBuildingTypes["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsBuildingTypes["USERID"]);

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

        public bool ReturnFirstBuildingTypeMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getfirstbuildingtypemaster()";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesBuildingTypes in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesBuildingTypes.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsBuildingTypes in myDataTablesBuildingTypes.Rows)
                                {
                                    if (myDataRowsBuildingTypes["BUILDINGTYPEID"] != DBNull.Value)
                                    {
                                        lBuildingTypeID = Convert.ToInt64(myDataRowsBuildingTypes["BUILDINGTYPEID"]);
                                    }

                                    if (myDataRowsBuildingTypes["BUILDINGTYPENAME"] != DBNull.Value)
                                    {
                                        strBuildingTypeName = myDataRowsBuildingTypes["BUILDINGTYPENAME"].ToString();
                                    }

                                    if (myDataRowsBuildingTypes["BUILDINGTYPEDESCRIPTION"] != DBNull.Value)
                                    {
                                        strBuildingTypeDescription = myDataRowsBuildingTypes["BUILDINGTYPEDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsBuildingTypes["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsBuildingTypes["DATECREATED"]);
                                    }

                                    if (myDataRowsBuildingTypes["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsBuildingTypes["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsBuildingTypes["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsBuildingTypes["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsBuildingTypes["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsBuildingTypes["USERID"]);

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

        public bool ReturnNextBuildingTypeMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getnextbuildingtypemaster(" + lBuildingTypeID + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesBuildingTypes in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesBuildingTypes.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsBuildingTypes in myDataTablesBuildingTypes.Rows)
                                {
                                    if (myDataRowsBuildingTypes["BUILDINGTYPEID"] != DBNull.Value)
                                    {
                                        lBuildingTypeID = Convert.ToInt64(myDataRowsBuildingTypes["BUILDINGTYPEID"]);
                                    }

                                    if (myDataRowsBuildingTypes["BUILDINGTYPENAME"] != DBNull.Value)
                                    {
                                        strBuildingTypeName = myDataRowsBuildingTypes["BUILDINGTYPENAME"].ToString();
                                    }

                                    if (myDataRowsBuildingTypes["BUILDINGTYPEDESCRIPTION"] != DBNull.Value)
                                    {
                                        strBuildingTypeDescription = myDataRowsBuildingTypes["BUILDINGTYPEDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsBuildingTypes["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsBuildingTypes["DATECREATED"]);
                                    }

                                    if (myDataRowsBuildingTypes["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsBuildingTypes["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsBuildingTypes["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsBuildingTypes["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsBuildingTypes["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsBuildingTypes["USERID"]);

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

        public bool ReturnPreviousBuildingTypeMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getprevbuildingtypemaster(" + lBuildingTypeID + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesBuildingTypes in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesBuildingTypes.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsBuildingTypes in myDataTablesBuildingTypes.Rows)
                                {
                                    if (myDataRowsBuildingTypes["BUILDINGTYPEID"] != DBNull.Value)
                                    {
                                        lBuildingTypeID = Convert.ToInt64(myDataRowsBuildingTypes["BUILDINGTYPEID"]);
                                    }

                                    if (myDataRowsBuildingTypes["BUILDINGTYPENAME"] != DBNull.Value)
                                    {
                                        strBuildingTypeName = myDataRowsBuildingTypes["BUILDINGTYPENAME"].ToString();
                                    }

                                    if (myDataRowsBuildingTypes["BUILDINGTYPEDESCRIPTION"] != DBNull.Value)
                                    {
                                        strBuildingTypeDescription = myDataRowsBuildingTypes["BUILDINGTYPEDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsBuildingTypes["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsBuildingTypes["DATECREATED"]);
                                    }

                                    if (myDataRowsBuildingTypes["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsBuildingTypes["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsBuildingTypes["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsBuildingTypes["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsBuildingTypes["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsBuildingTypes["USERID"]);

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

        public bool ReturnLastBuildingTypeMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getlastbuildingtypemaster()";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesBuildingTypes in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesBuildingTypes.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsBuildingTypes in myDataTablesBuildingTypes.Rows)
                                {
                                    if (myDataRowsBuildingTypes["BUILDINGTYPEID"] != DBNull.Value)
                                    {
                                        lBuildingTypeID = Convert.ToInt64(myDataRowsBuildingTypes["BUILDINGTYPEID"]);
                                    }

                                    if (myDataRowsBuildingTypes["BUILDINGTYPENAME"] != DBNull.Value)
                                    {
                                        strBuildingTypeName = myDataRowsBuildingTypes["BUILDINGTYPENAME"].ToString();
                                    }

                                    if (myDataRowsBuildingTypes["BUILDINGTYPEDESCRIPTION"] != DBNull.Value)
                                    {
                                        strBuildingTypeDescription = myDataRowsBuildingTypes["BUILDINGTYPEDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsBuildingTypes["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsBuildingTypes["DATECREATED"]);
                                    }

                                    if (myDataRowsBuildingTypes["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsBuildingTypes["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsBuildingTypes["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsBuildingTypes["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsBuildingTypes["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsBuildingTypes["USERID"]);

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

        public bool SaveBuildingTypeMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT trip_func_insertupdatecapturebuildingtypemaster(" +
                    lBuildingTypeID + ",'" + strBuildingTypeName.Trim() + "','" + strBuildingTypeDescription.Trim() + "')";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesBuildingType in objLogin.PGDataSet.Tables)
                        {
                            //Check if there is any data. If not exit
                            if (myDataTablesBuildingType.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;
                            }
                            else
                            {
                                datBuildingTypes = objLogin.PGDataSet;
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
