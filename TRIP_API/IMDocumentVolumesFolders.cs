using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Npgsql;
using NpgsqlTypes;
using System.IO;

namespace TRIP_API
{
    public class IMDocumentVolumeFolders : IMDocumentVolumes
    {

        #region "Variable"

        private long lDocumentFolderID = 0;
        private long lDocumentVolumeID = 0;
        private string strDocumentFolderName = "";
        private string strDocumentFolderDescription = "";
        private long lDocumentFolderRootFolderID = 0;    
        private long lStatusID = 0;
        private long lLimitToDocumentTypeID = 0;
        private DateTime dtDateProduced;
        private DateTime dtDateCreated;
        private DateTime dtDateRegistered;
        private DateTime dtDateDeRegistered;
        private DataSet datDocumentVolumeFolder;
        private string errMessage;


        #endregion


        #region "Properties"

        public long DocumentFolderID
        {
            get { return lDocumentFolderID; }
            set { lDocumentFolderID = value; }
        }

        public long DocumentVolumeID
        {
            get { return lDocumentVolumeID; }
            set { lDocumentVolumeID = value; }
        }

        public string DocumentFolderName
        {
            get { return strDocumentFolderName; }
            set { strDocumentFolderName = value; }
        }

        public string DocumentFolderDescription
        {
            get { return strDocumentFolderDescription; }
            set { strDocumentFolderDescription = value; }
        }

        public long DocumentFolderRootFolderID
        {
            get { return lDocumentFolderRootFolderID; }
            set { lDocumentFolderRootFolderID = value; }
        }

        public new string ErrorMessage
        {
            get { return errMessage; }
            set { errMessage = value; }
        }

        public new long DocumentVolumeFolderStatusID
        {
            get { return lStatusID; }
            set { lStatusID = value; }
        }

        public new long LimitDocumentVolumeFolderToDocumentTypeID
        {
            get { return lLimitToDocumentTypeID; }
            set { lLimitToDocumentTypeID = value; }
        }

        public new DateTime DateDocumentVolumeProduced
        {
            get { return dtDateProduced; }
            set { dtDateProduced = value; }
        }

        public new DateTime DateDocumentVolumeCreated
        {
            get { return dtDateCreated; }
            set { dtDateCreated = value; }
        }

        public DateTime DateDocumentVolumeRegistered
        {
            get { return dtDateRegistered; }
            set { dtDateRegistered = value; }
        }

        public DateTime DateDocumentVolumeDeRegistered
        {
            get { return dtDateDeRegistered; }
            set { dtDateDeRegistered = value; }
        }
       

        #endregion


        #region "DatabaseFunctions"


        public bool ReturnAllDocumentFoldersByDocumentVolumeID(long lLimit, long lOffset)
        {
            //Return all folders for a Volume and order by RootID
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getdocumentfolderbydocumentvolumeid(0 ," + lLimit +
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

                                datDocumentVolumeFolder = objLogin.PGDataSet;
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

        public bool ReturnDocumentFoldersByDocumentFolderID(long lLimit, long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getdocumentfolderbydocumentvolumeid(" + lDocumentVolumeID + "," + lLimit +
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
                                    if (myDataRowsDocumentType["DOCUMENTFOLDERID"] != DBNull.Value)
                                    {
                                        lDocumentFolderID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTFOLDERID"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTVOLUMEID"] != DBNull.Value)
                                    {
                                        lDocumentVolumeID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTVOLUMEID"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTFOLDERNAME"] != DBNull.Value)
                                    {
                                        strDocumentFolderName = myDataRowsDocumentType["DOCUMENTFOLDERNAME"].ToString();
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTFOLDERDESCRIPTION"] != DBNull.Value)
                                    {
                                        strDocumentFolderDescription = myDataRowsDocumentType["DOCUMENTFOLDERDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTFOLDERROOTFOLDERID"] != DBNull.Value)
                                    {
                                        lDocumentFolderRootFolderID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTFOLDERROOTFOLDERID"]);
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

        public bool ReturnAllDocumentFolderMainDetails(long lLimit, long lOffset)
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
                                datDocumentVolumeFolder = objLogin.PGDataSet;
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

        public bool ReturnDocumentFolderMainDetails(long lLimit, long lOffset)
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
                                    if (myDataRowsDocumentType["DOCUMENTFOLDERID"] != DBNull.Value)
                                    {
                                        lDocumentFolderID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTFOLDERID"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTVOLUMEID"] != DBNull.Value)
                                    {
                                        lDocumentVolumeID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTVOLUMEID"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTFOLDERNAME"] != DBNull.Value)
                                    {
                                        strDocumentFolderName = myDataRowsDocumentType["DOCUMENTFOLDERNAME"].ToString();
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTFOLDERROOTFOLDERID"] != DBNull.Value)
                                    {
                                        lDocumentFolderRootFolderID = 
                                            Convert.ToInt64(myDataRowsDocumentType["DOCUMENTFOLDERROOTFOLDERID"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTFOLDERDESCRIPTION"] != DBNull.Value)
                                    {
                                        strDocumentFolderDescription = 
                                            myDataRowsDocumentType["DOCUMENTFOLDERDESCRIPTION"].ToString();
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

        public bool ReturnFirstDocumentFolder()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getfirstdocumentfolder(" + lDocumentVolumeID + ")";

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
                                    if (myDataRowsDocumentType["DOCUMENTFOLDERID"] != DBNull.Value)
                                    {
                                        lDocumentFolderID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTFOLDERID"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTVOLUMEID"] != DBNull.Value)
                                    {
                                        lDocumentVolumeID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTVOLUMEID"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTFOLDERNAME"] != DBNull.Value)
                                    {
                                        strDocumentFolderName = myDataRowsDocumentType["DOCUMENTFOLDERNAME"].ToString();
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTFOLDERDESCRIPTION"] != DBNull.Value)
                                    {
                                        strDocumentFolderDescription = 
                                            myDataRowsDocumentType["DOCUMENTFOLDERDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTFOLDERROOTFOLDERID"] != DBNull.Value)
                                    {
                                        lDocumentFolderRootFolderID = 
                                            Convert.ToInt64(myDataRowsDocumentType["DOCUMENTFOLDERROOTFOLDERID"]);
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

        public bool ReturnNextDocumentDocumentFolder()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getfirstdocumentfolder(" + lDocumentVolumeID + "," + lDocumentFolderID + ")";

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
                                    if (myDataRowsDocumentType["DOCUMENTFOLDERID"] != DBNull.Value)
                                    {
                                        lDocumentFolderID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTFOLDERID"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTVOLUMEID"] != DBNull.Value)
                                    {
                                        lDocumentVolumeID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTVOLUMEID"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTFOLDERNAME"] != DBNull.Value)
                                    {
                                        strDocumentFolderName = myDataRowsDocumentType["DOCUMENTFOLDERNAME"].ToString();
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTFOLDERDESCRIPTION"] != DBNull.Value)
                                    {
                                        strDocumentFolderDescription = 
                                            myDataRowsDocumentType["DOCUMENTFOLDERDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTFOLDERROOTFOLDERID"] != DBNull.Value)
                                    {
                                        lDocumentFolderRootFolderID = 
                                            Convert.ToInt64(myDataRowsDocumentType["DOCUMENTFOLDERROOTFOLDERID"]);
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

        public bool ReturnPreviousDocumentDocumentFolder()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getprevdocumentfolder(" + lDocumentVolumeID + "," + lDocumentFolderID + ")";

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
                                    if (myDataRowsDocumentType["DOCUMENTFOLDERID"] != DBNull.Value)
                                    {
                                        lDocumentFolderID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTFOLDERID"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTVOLUMEID"] != DBNull.Value)
                                    {
                                        lDocumentVolumeID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTVOLUMEID"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTFOLDERNAME"] != DBNull.Value)
                                    {
                                        strDocumentFolderName = myDataRowsDocumentType["DOCUMENTFOLDERNAME"].ToString();
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTFOLDERDESCRIPTION"] != DBNull.Value)
                                    {
                                        strDocumentFolderDescription = 
                                            myDataRowsDocumentType["DOCUMENTFOLDERDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTFOLDERROOTFOLDERID"] != DBNull.Value)
                                    {
                                        lDocumentFolderRootFolderID = 
                                            Convert.ToInt64(myDataRowsDocumentType["DOCUMENTFOLDERROOTFOLDERID"]);
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

        public bool ReturnLastDocumentDocumentFolder()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getlastdocumentfolder(" + lDocumentVolumeID + ")";

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
                                    if (myDataRowsDocumentType["DOCUMENTFOLDERID"] != DBNull.Value)
                                    {
                                        lDocumentFolderID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTFOLDERID"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTVOLUMEID"] != DBNull.Value)
                                    {
                                        lDocumentVolumeID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTVOLUMEID"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTFOLDERNAME"] != DBNull.Value)
                                    {
                                        strDocumentFolderName = myDataRowsDocumentType["DOCUMENTFOLDERNAME"].ToString();
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTFOLDERDESCRIPTION"] != DBNull.Value)
                                    {
                                        strDocumentFolderDescription = 
                                            myDataRowsDocumentType["DOCUMENTFOLDERDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTFOLDERROOTFOLDERID"] != DBNull.Value)
                                    {
                                        lDocumentFolderRootFolderID = 
                                            Convert.ToInt64(myDataRowsDocumentType["DOCUMENTFOLDERROOTFOLDERID"]);
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

        public bool SaveDocumentDocumentFolder()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT trip_func_insertupdatecapturedocumentvolumes(" +
                    lDocumentFolderID + ",'" +                          
                    lDocumentVolumeID + ",'" + 
                    strDocumentFolderName  + "'," + 
                    strDocumentFolderDescription  + "," +
                    lDocumentFolderRootFolderID  + ",'" +
                    lLimitToDocumentTypeID + "'," +
                    lStatusID + ",'" +
                    dtDateProduced + "')";

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
                                datDocumentVolumeFolder = objLogin.PGDataSet;
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
