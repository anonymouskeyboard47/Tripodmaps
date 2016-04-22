using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Npgsql;
using NpgsqlTypes;
using System.IO;

namespace TRIP_API
{
    public class IMDocumentVolumes : IMDocumentTypes
    {

        #region "Variable"

        private long lDocumentVolumeID = 0;
        private string strVolumeName = "";
        private long lVolumeRootID = 0;        
        private double dVolumeWeight = 0.0;
        private string strVolumeDescription = "";
        private long lStatusID = 0;
        private long lLimitToDocumentTypeID = 0;
        private DateTime dtDateProduced;
        private DateTime dtDateCreated;
        private DateTime dtDateRegistered;
        private DateTime dtDateDeRegistered;
        private DataSet datDocumentVolume;
        private string errMessage;


        #endregion


        #region "Properties"

        public long DocumentVolumeID
        {
            get { return lDocumentVolumeID; }
            set { lDocumentVolumeID = value; }
        }

        public string VolumeName
        {
            get { return strVolumeName; }
            set { strVolumeName = value; }
        }

        public long VolumeRootID
        {
            get { return lVolumeRootID; }
            set { lVolumeRootID = value; }
        }

        public double VolumeWeight
        {
            get { return dVolumeWeight; }
            set { dVolumeWeight = value; }
        }

        public string VolumeDescription
        {
            get { return strVolumeDescription; }
            set { strVolumeDescription = value; }
        }

        public string ErrorMessage
        {
            get { return errMessage; }
            set { errMessage = value; }
        }

        public long StatusID
        {
            get { return lStatusID; }
            set { lStatusID = value; }
        }

        public long LimitToDocumentTypeID
        {
            get { return lLimitToDocumentTypeID; }
            set { lLimitToDocumentTypeID = value; }
        }

        public DateTime DateProduced
        {
            get { return dtDateProduced; }
            set { dtDateProduced = value; }
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
       

        #endregion



        #region "DatabaseFunctions"


        public bool ReturnAllDocumentVolumesByDocumentTypeID(long lLimit,
            long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getdocumentvolumebydocumentvolumeid(0 ," + lLimit +
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

                                datDocumentVolume = objLogin.PGDataSet;
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
                errMessage = ex.Message + " : Source = " + ex.Source;
                return false;
            }

            finally
            {
                datRetData = null;

                objLogin = null;

            }
        }

        public bool ReturnDocumentVolumeByDocumentVolumeID(long lLimit,
            long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getdocumentvolumebydocumentvolumeid(" + 
                    lDocumentVolumeID + "," + lLimit + "," + lOffset + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesDocumentType in objLogin.PGDataSet.Tables)
                        {
                            //Check if there is any data. If not exit
                            if (myDataTablesDocumentType.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;
                            }
                            else
                            {

                                foreach (DataRow myDataRowsDocumentType in myDataTablesDocumentType.Rows)
                                {
                                    if (myDataRowsDocumentType["DOCUMENTVOLUMEID"] != DBNull.Value)
                                    {
                                        lDocumentVolumeID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTVOLUMEID"]);
                                    }

                                    if (myDataRowsDocumentType["VOLUMENAME"] != DBNull.Value)
                                    {
                                        strVolumeName = myDataRowsDocumentType["VOLUMENAME"].ToString();
                                    }

                                    if (myDataRowsDocumentType["VOLUMEROOTID"] != DBNull.Value)
                                    {
                                        lVolumeRootID = Convert.ToInt64(myDataRowsDocumentType["VOLUMEROOTID"]);
                                    }

                                    if (myDataRowsDocumentType["VOLUMEWEIGHT"] != DBNull.Value)
                                    {
                                        dVolumeWeight = Convert.ToDouble(myDataRowsDocumentType["VOLUMEWEIGHT"]);
                                    }

                                    if (myDataRowsDocumentType["VOLUMEDESCRIPTION"] != DBNull.Value)
                                    {
                                        strVolumeDescription = myDataRowsDocumentType["VOLUMEDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsDocumentType["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsDocumentType["DATECREATED"]);
                                    }

                                    if (myDataRowsDocumentType["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsDocumentType["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsDocumentType["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsDocumentType["DATEDEREGISTERED"]);
                                    }

                                    if (myDataRowsDocumentType["DATEPRODUCED"] != DBNull.Value)
                                    {
                                        dtDateProduced = Convert.ToDateTime(myDataRowsDocumentType["DATEPRODUCED"]);
                                    }

                                    if (myDataRowsDocumentType["LIMITTODOCUMENTTYPEID"] != DBNull.Value)
                                    {
                                        lLimitToDocumentTypeID = Convert.ToInt64(myDataRowsDocumentType["LIMITTODOCUMENTTYPEID"]);
                                    }

                                    //if (myDataRowsDocumentType["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsDocumentType["USERID"]);

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
                errMessage = ex.Message + " : Source = " + ex.Source;
                return false;
            }

            finally
            {
                datRetData = null;
                objLogin = null;

            }
        }

        public bool ReturnAllDocumentVolumeIDVolumeNameVolumeRootAndDescriptionByVolumeID(long lLimit,
            long lOffset)
        {

            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery =
                    "SELECT * FROM trip_func_getvolumeidvolumenamevolumerootanddescriptionbyvolumeid(" + 
                    lDocumentVolumeID + "," + lLimit + "," + lOffset + ")";

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
                                datDocumentVolume = objLogin.PGDataSet;
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
                errMessage = ex.Message + " : Source = " + ex.Source;
                return false;
            }

            finally
            {
                datRetData = null;
                objLogin = null;

            }
        }

        public bool ReturnDocumentVolumeIDVolumeNameVolumeRootAndDescriptionByVolumeID(long lLimit,
            long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery =
                    "SELECT * FROM trip_func_getvolumeidvolumenamevolumerootanddescriptionbyvolumeid(" + 
                    lDocumentVolumeID + "," + lLimit + "," + lOffset + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesDocumentType in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesDocumentType.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;
                            }
                            else
                            {

                                foreach (DataRow myDataRowsDocumentType in myDataTablesDocumentType.Rows)
                                {
                                    if (myDataRowsDocumentType["DOCUMENTVOLUMEID"] != DBNull.Value)
                                    {
                                        lDocumentVolumeID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTVOLUMEID"]);
                                    }

                                    if (myDataRowsDocumentType["VOLUMENAME"] != DBNull.Value)
                                    {
                                        strVolumeName = myDataRowsDocumentType["VOLUMENAME"].ToString();
                                    }

                                    if (myDataRowsDocumentType["VOLUMEROOTID"] != DBNull.Value)
                                    {
                                        lVolumeRootID = Convert.ToInt64(myDataRowsDocumentType["VOLUMEROOTID"]);
                                    }

                                    if (myDataRowsDocumentType["VOLUMEDESCRIPTION"] != DBNull.Value)
                                    {
                                        strVolumeDescription = myDataRowsDocumentType["VOLUMEDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsDocumentType["LIMITTODOCUMENTTYPEID"] != DBNull.Value)
                                    {
                                        lLimitToDocumentTypeID = Convert.ToInt64(myDataRowsDocumentType["LIMITTODOCUMENTTYPEID"]);
                                    }
                                   

                                    //if (myDataRowsDocumentType["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsDocumentType["USERID"]);

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
                errMessage = ex.Message + " : Source = " + ex.Source;
                return false;
            }

            finally
            {
                datRetData = null;
                objLogin = null;

            }
        }

        public bool ReturnFirstDocumentType()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getfirstdocumentvolume()";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesDocumentType in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesDocumentType.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;
                            }
                            else
                            {

                                foreach (DataRow myDataRowsDocumentType in myDataTablesDocumentType.Rows)
                                {
                                    if (myDataRowsDocumentType["DOCUMENTVOLUMEID"] != DBNull.Value)
                                    {
                                        lDocumentVolumeID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTVOLUMEID"]);
                                    }

                                    if (myDataRowsDocumentType["VOLUMENAME"] != DBNull.Value)
                                    {
                                        strVolumeName = myDataRowsDocumentType["VOLUMENAME"].ToString();
                                    }

                                    if (myDataRowsDocumentType["VOLUMEROOTID"] != DBNull.Value)
                                    {
                                        lVolumeRootID = Convert.ToInt64(myDataRowsDocumentType["VOLUMEROOTID"]);
                                    }

                                    if (myDataRowsDocumentType["VOLUMEWEIGHT"] != DBNull.Value)
                                    {
                                        dVolumeWeight = Convert.ToDouble(myDataRowsDocumentType["VOLUMEWEIGHT"]);
                                    }

                                    if (myDataRowsDocumentType["VOLUMEDESCRIPTION"] != DBNull.Value)
                                    {
                                        strVolumeDescription = myDataRowsDocumentType["VOLUMEDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsDocumentType["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsDocumentType["DATECREATED"]);
                                    }

                                    if (myDataRowsDocumentType["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsDocumentType["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsDocumentType["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsDocumentType["DATEDEREGISTERED"]);
                                    }

                                    if (myDataRowsDocumentType["DATEPRODUCED"] != DBNull.Value)
                                    {
                                        dtDateProduced = Convert.ToDateTime(myDataRowsDocumentType["DATEPRODUCED"]);
                                    }

                                    if (myDataRowsDocumentType["LIMITTODOCUMENTTYPEID"] != DBNull.Value)
                                    {
                                        lLimitToDocumentTypeID = Convert.ToInt64(myDataRowsDocumentType["LIMITTODOCUMENTTYPEID"]);
                                    }

                                    //if (myDataRowsDocumentType["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsDocumentType["USERID"]);

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
                errMessage = ex.Message + " : Source = " + ex.Source;
                return false;
            }

            finally
            {
                datRetData = null;
                objLogin = null;

            }
        }

        public bool ReturnNextDocumentVolume()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getfirstdocumentvolume(" + lDocumentVolumeID + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesDocumentType in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesDocumentType.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;
                            }
                            else
                            {

                                foreach (DataRow myDataRowsDocumentType in myDataTablesDocumentType.Rows)
                                {
                                    if (myDataRowsDocumentType["DOCUMENTVOLUMEID"] != DBNull.Value)
                                    {
                                        lDocumentVolumeID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTVOLUMEID"]);
                                    }

                                    if (myDataRowsDocumentType["VOLUMENAME"] != DBNull.Value)
                                    {
                                        strVolumeName = myDataRowsDocumentType["VOLUMENAME"].ToString();
                                    }

                                    if (myDataRowsDocumentType["VOLUMEROOTID"] != DBNull.Value)
                                    {
                                        lVolumeRootID = Convert.ToInt64(myDataRowsDocumentType["VOLUMEROOTID"]);
                                    }

                                    if (myDataRowsDocumentType["VOLUMEWEIGHT"] != DBNull.Value)
                                    {
                                        dVolumeWeight = Convert.ToDouble(myDataRowsDocumentType["VOLUMEWEIGHT"]);
                                    }

                                    if (myDataRowsDocumentType["VOLUMEDESCRIPTION"] != DBNull.Value)
                                    {
                                        strVolumeDescription = myDataRowsDocumentType["VOLUMEDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsDocumentType["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsDocumentType["DATECREATED"]);
                                    }

                                    if (myDataRowsDocumentType["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsDocumentType["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsDocumentType["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsDocumentType["DATEDEREGISTERED"]);
                                    }

                                    if (myDataRowsDocumentType["DATEPRODUCED"] != DBNull.Value)
                                    {
                                        dtDateProduced = Convert.ToDateTime(myDataRowsDocumentType["DATEPRODUCED"]);
                                    }

                                    if (myDataRowsDocumentType["LIMITTODOCUMENTTYPEID"] != DBNull.Value)
                                    {
                                        lLimitToDocumentTypeID = Convert.ToInt64(myDataRowsDocumentType["LIMITTODOCUMENTTYPEID"]);
                                    }

                                    //if (myDataRowsDocumentType["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsDocumentType["USERID"]);

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

        public bool ReturnPreviousDocumentVolume()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getprevdocumenttype(" + lDocumentVolumeID + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesDocumentType in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesDocumentType.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;
                            }
                            else
                            {

                                foreach (DataRow myDataRowsDocumentType in myDataTablesDocumentType.Rows)
                                {
                                    if (myDataRowsDocumentType["DOCUMENTVOLUMEID"] != DBNull.Value)
                                    {
                                        lDocumentVolumeID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTVOLUMEID"]);
                                    }

                                    if (myDataRowsDocumentType["VOLUMENAME"] != DBNull.Value)
                                    {
                                        strVolumeName = myDataRowsDocumentType["VOLUMENAME"].ToString();
                                    }

                                    if (myDataRowsDocumentType["VOLUMEROOTID"] != DBNull.Value)
                                    {
                                        lVolumeRootID = Convert.ToInt64(myDataRowsDocumentType["VOLUMEROOTID"]);
                                    }

                                    if (myDataRowsDocumentType["VOLUMEWEIGHT"] != DBNull.Value)
                                    {
                                        dVolumeWeight = Convert.ToDouble(myDataRowsDocumentType["VOLUMEWEIGHT"]);
                                    }

                                    if (myDataRowsDocumentType["VOLUMEDESCRIPTION"] != DBNull.Value)
                                    {
                                        strVolumeDescription = myDataRowsDocumentType["VOLUMEDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsDocumentType["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsDocumentType["DATECREATED"]);
                                    }

                                    if (myDataRowsDocumentType["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsDocumentType["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsDocumentType["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsDocumentType["DATEDEREGISTERED"]);
                                    }

                                    if (myDataRowsDocumentType["DATEPRODUCED"] != DBNull.Value)
                                    {
                                        dtDateProduced = Convert.ToDateTime(myDataRowsDocumentType["DATEPRODUCED"]);
                                    }

                                    if (myDataRowsDocumentType["LIMITTODOCUMENTTYPEID"] != DBNull.Value)
                                    {
                                        lLimitToDocumentTypeID = Convert.ToInt64(myDataRowsDocumentType["LIMITTODOCUMENTTYPEID"]);
                                    }

                                    //if (myDataRowsDocumentType["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsDocumentType["USERID"]);

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
                errMessage = ex.Message + " : Source = " + ex.Source;
                return false;
            }

            finally
            {
                datRetData = null;
                objLogin = null;

            }
        }

        public bool ReturnLastDocumentVolume()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getlastdocumentvolume()";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesDocumentType in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesDocumentType.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;
                            }
                            else
                            {

                                foreach (DataRow myDataRowsDocumentType in myDataTablesDocumentType.Rows)
                                {
                                    if (myDataRowsDocumentType["DOCUMENTVOLUMEID"] != DBNull.Value)
                                    {
                                        lDocumentVolumeID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTVOLUMEID"]);
                                    }

                                    if (myDataRowsDocumentType["VOLUMENAME"] != DBNull.Value)
                                    {
                                        strVolumeName = myDataRowsDocumentType["VOLUMENAME"].ToString();
                                    }

                                    if (myDataRowsDocumentType["VOLUMEROOTID"] != DBNull.Value)
                                    {
                                        lVolumeRootID = Convert.ToInt64(myDataRowsDocumentType["VOLUMEROOTID"]);
                                    }

                                    if (myDataRowsDocumentType["VOLUMEWEIGHT"] != DBNull.Value)
                                    {
                                        dVolumeWeight = Convert.ToDouble(myDataRowsDocumentType["VOLUMEWEIGHT"]);
                                    }

                                    if (myDataRowsDocumentType["VOLUMEDESCRIPTION"] != DBNull.Value)
                                    {
                                        strVolumeDescription = myDataRowsDocumentType["VOLUMEDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsDocumentType["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsDocumentType["DATECREATED"]);
                                    }

                                    if (myDataRowsDocumentType["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsDocumentType["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsDocumentType["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsDocumentType["DATEDEREGISTERED"]);
                                    }

                                    if (myDataRowsDocumentType["DATEPRODUCED"] != DBNull.Value)
                                    {
                                        dtDateProduced = Convert.ToDateTime(myDataRowsDocumentType["DATEPRODUCED"]);
                                    }

                                    if (myDataRowsDocumentType["LIMITTODOCUMENTTYPEID"] != DBNull.Value)
                                    {
                                        lLimitToDocumentTypeID = Convert.ToInt64(myDataRowsDocumentType["LIMITTODOCUMENTTYPEID"]);
                                    }

                                    //if (myDataRowsDocumentType["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsDocumentType["USERID"]);

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
                errMessage = ex.Message + " : Source = " + ex.Source;
                return false;
            }

            finally
            {
                datRetData = null;
                objLogin = null;

            }
        }

        public bool SaveDocumentVolumes()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT trip_func_insertupdatecapturedocumentvolumes(" + 
                            lDocumentVolumeID + ",'" + 
                            strVolumeName  + "'," + 
                            lVolumeRootID  + "," +
                            dVolumeWeight  + ",'" +
                            strVolumeDescription + "'," +
                            lStatusID + ",'" +
                            dtDateProduced + "'," + 
                            lLimitToDocumentTypeID + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesDocumentTypes in objLogin.PGDataSet.Tables)
                        {
                            //Check if there is any data. If not exit
                            if (myDataTablesDocumentTypes.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;
                            }
                            else
                            {
                                datDocumentVolume = objLogin.PGDataSet;
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
                errMessage = ex.Message + " : Source = " + ex.Source;
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
