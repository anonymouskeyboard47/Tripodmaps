using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace TRIP_API
{
    public class IMAssetTypes
    {

        #region "Variable"

        private long lAssetTypeID = 0;
        private string strAssetTypeName = "";
        private string strAssetTypeDescription = "";
        private DateTime dtDateCreated;
        private DateTime dtDateRegistered;
        private DateTime dtDateDeRegistered;
        private DataSet datAssetTypes;

        #endregion


        #region "Properties"


        public long AssetTypeID
        {
            get { return lAssetTypeID; }
            set { lAssetTypeID = value; }
        }

        public string AssetTypeName
        {
            get { return strAssetTypeName; }
            set { strAssetTypeName = value; }
        }

        public string AssetTypeDescription
        {
            get { return strAssetTypeDescription; }
            set { strAssetTypeDescription = value; }
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

        public DataSet AssetTypeDataSet
        {
            get { return datAssetTypes; }
            set { datAssetTypes = value; }
        }


        #endregion
              


        #region "DatabaseFunctions"


        public bool ReturnAllAssetTypesMasterByAssetTypeID(long lLimit,
            long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getassettypemasterbyassettypeid(" + lAssetTypeID + "," + lLimit +
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

                                datAssetTypes = objLogin.PGDataSet;
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

        public bool ReturnAssetMasterByAssetTypeID()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getassettypemasterbyassettypeid(" + lAssetTypeID + ",0,0)";

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
                                    if (myDataRowsUsage["ASSETTYPEID"] != DBNull.Value)
                                    {
                                        lAssetTypeID = Convert.ToInt64(myDataRowsUsage["ASSETTYPEID"]);
                                    }

                                    if (myDataRowsUsage["ASSETTYPENAME"] != DBNull.Value)
                                    {
                                        strAssetTypeName = myDataRowsUsage["ASSETTYPENAME"].ToString();
                                    }

                                    if (myDataRowsUsage["ASSETTYPEDESCRIPTION"] != DBNull.Value)
                                    {
                                        strAssetTypeDescription = myDataRowsUsage["ASSETTYPEDESCRIPTION"].ToString();
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

        public bool ReturnFirstAssetTypeMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getfirstassettypesmaster()";

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
                                    if (myDataRowsUsage["ASSETTYPEID"] != DBNull.Value)
                                    {
                                        lAssetTypeID = Convert.ToInt64(myDataRowsUsage["ASSETTYPEID"]);
                                    }

                                    if (myDataRowsUsage["ASSETTYPENAME"] != DBNull.Value)
                                    {
                                        strAssetTypeName = myDataRowsUsage["ASSETTYPENAME"].ToString();
                                    }

                                    if (myDataRowsUsage["ASSETTYPEDESCRIPTION"] != DBNull.Value)
                                    {
                                        strAssetTypeDescription = myDataRowsUsage["ASSETTYPEDESCRIPTION"].ToString();
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

        public bool ReturnNextAssetTypeMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getnextassettypesmaster(" + lAssetTypeID + ")";

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
                                    if (myDataRowsUsage["ASSETTYPEID"] != DBNull.Value)
                                    {
                                        lAssetTypeID = Convert.ToInt64(myDataRowsUsage["ASSETTYPEID"]);
                                    }

                                    if (myDataRowsUsage["ASSETTYPENAME"] != DBNull.Value)
                                    {
                                        strAssetTypeName = myDataRowsUsage["ASSETTYPENAME"].ToString();
                                    }

                                    if (myDataRowsUsage["ASSETTYPEDESCRIPTION"] != DBNull.Value)
                                    {
                                        strAssetTypeDescription = myDataRowsUsage["ASSETTYPEDESCRIPTION"].ToString();
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

        public bool ReturnPreviousAssetTypeMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getpreviousassettypesmaster(" + lAssetTypeID + ")";

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
                                    if (myDataRowsUsage["ASSETTYPEID"] != DBNull.Value)
                                    {
                                        lAssetTypeID = Convert.ToInt64(myDataRowsUsage["ASSETTYPEID"]);
                                    }

                                    if (myDataRowsUsage["ASSETTYPENAME"] != DBNull.Value)
                                    {
                                        strAssetTypeName = myDataRowsUsage["ASSETTYPENAME"].ToString();
                                    }

                                    if (myDataRowsUsage["ASSETTYPEDESCRIPTION"] != DBNull.Value)
                                    {
                                        strAssetTypeDescription = myDataRowsUsage["ASSETTYPEDESCRIPTION"].ToString();
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

        public bool ReturnLastAssetTypeMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getlastassettypesmaster()";

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
                                    if (myDataRowsUsage["ASSETTYPEID"] != DBNull.Value)
                                    {
                                        lAssetTypeID = Convert.ToInt64(myDataRowsUsage["ASSETTYPEID"]);
                                    }

                                    if (myDataRowsUsage["ASSETTYPENAME"] != DBNull.Value)
                                    {
                                        strAssetTypeName = myDataRowsUsage["ASSETTYPENAME"].ToString();
                                    }

                                    if (myDataRowsUsage["ASSETTYPEDESCRIPTION"] != DBNull.Value)
                                    {
                                        strAssetTypeDescription = myDataRowsUsage["ASSETTYPEDESCRIPTION"].ToString();
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
