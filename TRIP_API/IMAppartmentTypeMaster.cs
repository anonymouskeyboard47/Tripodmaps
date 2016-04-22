using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace TRIP_API
{
    class IMAppartmentTypeMaster
    {
   
         #region "privateVariables"  


        private long lAppartmentTypeID = 0;
        private string strAppartmentTypeName = "";
        private string strAppartmentTypeDescription = "";
        private DateTime dtDateCreated;
        private DataSet datAppartmentTypeMasterDataset;
         
         
         #endregion


        #region "Properties"


        public long AppartmentTypeID
        {
            get { return lAppartmentTypeID; }
            set { lAppartmentTypeID = value; }
        }

        public string AppartmentTypeName
        {
            get { return strAppartmentTypeName; }
            set { strAppartmentTypeName = value; }
        }

        public string AppartmentTypeDescription
        {
            get { return strAppartmentTypeDescription; }
            set { strAppartmentTypeDescription = value; }
        }

        public DateTime DateCreated
        {
            get { return dtDateCreated; }
            set { dtDateCreated = value; }
        }

        public DataSet AppartmentTypeMasterDataset
        {
            get { return datAppartmentTypeMasterDataset; }
            set { datAppartmentTypeMasterDataset = value; }
        }


        #endregion


        #region "DatabaseFunctions"


        public bool ReturnAllAppartmentTypeMasterByAppartmentTypeID(long lLimit,
            long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getappartmenttypemasterbyappartmenttypeid(0," + lLimit +
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

                        foreach (DataTable myDataRowsAppartmentType in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataRowsAppartmentType.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                datAppartmentTypeMasterDataset = objLogin.PGDataSet;
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

        public bool ReturnAppartmentTypeMasterByAppartmentTypeID(long lLimit,
            long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getappartmenttypemasterbyappartmenttypeid(" + lAppartmentTypeID + "," 
                    + lLimit + "," + lOffset + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTableAppartmentType in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTableAppartmentType.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsAppartmentType in myDataTableAppartmentType.Rows)
                                {
                                    if (myDataRowsAppartmentType["APPARTMENTTYPEID"] != DBNull.Value)
                                    {
                                        lAppartmentTypeID = Convert.ToInt64(myDataRowsAppartmentType["APPARTMENTTYPEID"]);
                                    }

                                    if (myDataRowsAppartmentType["APPARTMENTTYPENAME"] != DBNull.Value)
                                    {
                                        strAppartmentTypeName = myDataRowsAppartmentType["APPARTMENTTYPENAME"].ToString();
                                    }

                                    if (myDataRowsAppartmentType["APPARTMENTTYPEDESCRIPTION"] != DBNull.Value)
                                    {
                                        strAppartmentTypeDescription = 
                                            myDataRowsAppartmentType["APPARTMENTTYPEDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsAppartmentType["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsAppartmentType["DATECREATED"]);
                                    }

                                    //if (myDataRowsAppartmentType["DATEREGISTERED"] != DBNull.Value)
                                    //{
                                    //    dtDateregistered = Convert.ToDateTime(myDataRowsAppartmentType["DATEREGISTERED"]);
                                    //}

                                    //if (myDataRowsAppartmentType["DATEDEREGISTERED"] != DBNull.Value)
                                    //{
                                    //    dtDateDeregistered = Convert.ToDateTime(myDataRowsAppartmentType["DATEDEREGISTERED"]);
                                    //}

                                    //if (myDataRowsAppartmentType["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsAppartmentType["USERID"]);

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

        public bool ReturnAllAppartmentTypeIDAndAppartmentTypeNameByAppartmentTypeID(long lLimit,
            long lOffset)
        {

            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getappartmenttypeidandnamebyappartmenttypeid(0," + lLimit +
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

                        foreach (DataTable myDataRowsAppartmentType in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataRowsAppartmentType.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                datAppartmentTypeMasterDataset = objLogin.PGDataSet;

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

        public bool ReturnAppartmentTypeIDAndAppartmentTypeNameByAppartmentTypeID(long lLimit,
            long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getappartmenttypeidandnamebyappartmenttypeid(" + lAppartmentTypeID + "," 
                    + lLimit + "," + lOffset + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTableAppartmentType in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTableAppartmentType.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsAppartmentType in myDataTableAppartmentType.Rows)
                                {
                                    if (myDataRowsAppartmentType["APPARTMENTTYPEID"] != DBNull.Value)
                                    {
                                        lAppartmentTypeID = Convert.ToInt64(myDataRowsAppartmentType["APPARTMENTTYPEID"]);
                                    }

                                    if (myDataRowsAppartmentType["APPARTMENTTYPENAME"] != DBNull.Value)
                                    {
                                        strAppartmentTypeName = myDataRowsAppartmentType["APPARTMENTTYPENAME"].ToString();
                                    }

                                    if (myDataRowsAppartmentType["APPARTMENTTYPEDESCRIPTION"] != DBNull.Value)
                                    {
                                        strAppartmentTypeDescription = 
                                            myDataRowsAppartmentType["APPARTMENTTYPEDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsAppartmentType["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsAppartmentType["DATECREATED"]);
                                    }

                                    //if (myDataRowsAppartmentType["DATEREGISTERED"] != DBNull.Value)
                                    //{
                                    //    dtDateregistered = Convert.ToDateTime(myDataRowsAppartmentType["DATEREGISTERED"]);
                                    //}

                                    //if (myDataRowsAppartmentType["DATEDEREGISTERED"] != DBNull.Value)
                                    //{
                                    //    dtDateDeregistered = Convert.ToDateTime(myDataRowsAppartmentType["DATEDEREGISTERED"]);
                                    //}

                                    //if (myDataRowsAppartmentType["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsAppartmentType["USERID"]);

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

        public bool ReturnFirstAppartmentTypeMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getfirstappartmenttypemaster()";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTableAppartmentType in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTableAppartmentType.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsAppartmentType in myDataTableAppartmentType.Rows)
                                {
                                    if (myDataRowsAppartmentType["APPARTMENTTYPEID"] != DBNull.Value)
                                    {
                                        lAppartmentTypeID = Convert.ToInt64(myDataRowsAppartmentType["APPARTMENTTYPEID"]);
                                    }

                                    if (myDataRowsAppartmentType["APPARTMENTTYPENAME"] != DBNull.Value)
                                    {
                                        strAppartmentTypeName = myDataRowsAppartmentType["APPARTMENTTYPENAME"].ToString();
                                    }

                                    if (myDataRowsAppartmentType["APPARTMENTTYPEDESCRIPTION"] != DBNull.Value)
                                    {
                                        strAppartmentTypeDescription = 
                                            myDataRowsAppartmentType["APPARTMENTTYPEDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsAppartmentType["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsAppartmentType["DATECREATED"]);
                                    }

                                    //if (myDataRowsAppartmentType["DATEREGISTERED"] != DBNull.Value)
                                    //{
                                    //    dtDateregistered = Convert.ToDateTime(myDataRowsAppartmentType["DATEREGISTERED"]);
                                    //}

                                    //if (myDataRowsAppartmentType["DATEDEREGISTERED"] != DBNull.Value)
                                    //{
                                    //    dtDateDeregistered = Convert.ToDateTime(myDataRowsAppartmentType["DATEDEREGISTERED"]);
                                    //}

                                    //if (myDataRowsAppartmentType["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsAppartmentType["USERID"]);

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

        public bool ReturnNextAppartmentTypeMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getnextappartmenttypemaster(" + lAppartmentTypeID + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTableAppartmentType in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTableAppartmentType.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsAppartmentType in myDataTableAppartmentType.Rows)
                                {
                                    if (myDataRowsAppartmentType["APPARTMENTTYPEID"] != DBNull.Value)
                                    {
                                        lAppartmentTypeID = Convert.ToInt64(myDataRowsAppartmentType["APPARTMENTTYPEID"]);
                                    }

                                    if (myDataRowsAppartmentType["APPARTMENTTYPENAME"] != DBNull.Value)
                                    {
                                        strAppartmentTypeName = myDataRowsAppartmentType["APPARTMENTTYPENAME"].ToString();
                                    }

                                    if (myDataRowsAppartmentType["APPARTMENTTYPEDESCRIPTION"] != DBNull.Value)
                                    {
                                        strAppartmentTypeDescription = 
                                            myDataRowsAppartmentType["APPARTMENTTYPEDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsAppartmentType["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsAppartmentType["DATECREATED"]);
                                    }

                                    //if (myDataRowsAppartmentType["DATEREGISTERED"] != DBNull.Value)
                                    //{
                                    //    dtDateregistered = Convert.ToDateTime(myDataRowsAppartmentType["DATEREGISTERED"]);
                                    //}

                                    //if (myDataRowsAppartmentType["DATEDEREGISTERED"] != DBNull.Value)
                                    //{
                                    //    dtDateDeregistered = Convert.ToDateTime(myDataRowsAppartmentType["DATEDEREGISTERED"]);
                                    //}

                                    //if (myDataRowsAppartmentType["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsAppartmentType["USERID"]);

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

        public bool ReturnPreviousAppartmentTypeMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getprevappartmenttypemaster(" + lAppartmentTypeID + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTableAppartmentType in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTableAppartmentType.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsAppartmentType in myDataTableAppartmentType.Rows)
                                {
                                    if (myDataRowsAppartmentType["APPARTMENTTYPEID"] != DBNull.Value)
                                    {
                                        lAppartmentTypeID = Convert.ToInt64(myDataRowsAppartmentType["APPARTMENTTYPEID"]);
                                    }

                                    if (myDataRowsAppartmentType["APPARTMENTTYPENAME"] != DBNull.Value)
                                    {
                                        strAppartmentTypeName = myDataRowsAppartmentType["APPARTMENTTYPENAME"].ToString();
                                    }

                                    if (myDataRowsAppartmentType["APPARTMENTTYPEDESCRIPTION"] != DBNull.Value)
                                    {
                                        strAppartmentTypeDescription = 
                                            myDataRowsAppartmentType["APPARTMENTTYPEDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsAppartmentType["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsAppartmentType["DATECREATED"]);
                                    }

                                    //if (myDataRowsAppartmentType["DATEREGISTERED"] != DBNull.Value)
                                    //{
                                    //    dtDateregistered = Convert.ToDateTime(myDataRowsAppartmentType["DATEREGISTERED"]);
                                    //}

                                    //if (myDataRowsAppartmentType["DATEDEREGISTERED"] != DBNull.Value)
                                    //{
                                    //    dtDateDeregistered = Convert.ToDateTime(myDataRowsAppartmentType["DATEDEREGISTERED"]);
                                    //}

                                    //if (myDataRowsAppartmentType["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsAppartmentType["USERID"]);

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

        public bool ReturnLastAppartmentTypeMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            DataTable myDataTables = default(DataTable);
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getlastappartmenttypemaster()";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTableAppartmentType in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTableAppartmentType.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsAppartmentType in myDataTableAppartmentType.Rows)
                                {
                                    if (myDataRowsAppartmentType["APPARTMENTTYPEID"] != DBNull.Value)
                                    {
                                        lAppartmentTypeID = Convert.ToInt64(myDataRowsAppartmentType["APPARTMENTTYPEID"]);
                                    }

                                    if (myDataRowsAppartmentType["APPARTMENTTYPENAME"] != DBNull.Value)
                                    {
                                        strAppartmentTypeName = myDataRowsAppartmentType["APPARTMENTTYPENAME"].ToString();
                                    }

                                    if (myDataRowsAppartmentType["APPARTMENTTYPEDESCRIPTION"] != DBNull.Value)
                                    {
                                        strAppartmentTypeDescription = 
                                            myDataRowsAppartmentType["APPARTMENTTYPEDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsAppartmentType["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsAppartmentType["DATECREATED"]);
                                    }

                                    //if (myDataRowsAppartmentType["DATEREGISTERED"] != DBNull.Value)
                                    //{
                                    //    dtDateregistered = Convert.ToDateTime(myDataRowsAppartmentType["DATEREGISTERED"]);
                                    //}

                                    //if (myDataRowsAppartmentType["DATEDEREGISTERED"] != DBNull.Value)
                                    //{
                                    //    dtDateDeregistered = Convert.ToDateTime(myDataRowsAppartmentType["DATEDEREGISTERED"]);
                                    //}

                                    //if (myDataRowsAppartmentType["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsAppartmentType["USERID"]);

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
