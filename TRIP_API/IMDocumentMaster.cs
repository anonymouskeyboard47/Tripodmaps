using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Npgsql;
using NpgsqlTypes;
using System.IO;

namespace TRIP_API
{
    public class IMDocumentMaster : IMDocumentVolumeFolders
    {

        #region "Variable"

        private long lDocumentID = 0;
        private long lDocumentProducerUserID = 0;
        private long lDocumentTypeID = 0;
        private DateTime dtDateProduced;
        private string strDocumentSerialNumber = "";
        private Byte[] bytImageStream;
        private long lProducedBy = 0;
        private string strSavePath = "";
        private string strDocumentDescription = "";
        private long lMimeTypeID = 0;
        private long lMimeApplicationVersionID = 0;
        private long lIsSystemDocument = 0;
        private string strDocumentSourceDescription = "";
        private long lFolioNo = 0;
        private long lStatusID = 0;
        private long lForInputOutput = 0;
        private DateTime dtDateCreated;
        private DateTime dtDateRegistered;
        private DateTime dtDateDeRegistered;
        private DataSet datDocumentMaster;
        private string strSourceDocumentPath;
        private string errMessage;


        #endregion


        #region "Properties"



        public long DocumentID
        {
            get { return lDocumentID; }
            set { lDocumentID = value; }
        }

        public long DocumentProducerUserID
        {
            get { return lDocumentProducerUserID; }
            set { lDocumentProducerUserID = value; }
        }

        public long DocumentTypeID
        {
            get { return lDocumentTypeID; }
            set { lDocumentTypeID = value; }
        }

        public DateTime DateProduced
        {
            get { return dtDateProduced; }
            set { dtDateProduced = value; }
        }

        public string DocumentSerialNumber
        {
            get { return strDocumentSerialNumber; }
            set { strDocumentSerialNumber = value; }
        }

        public Byte[] ImageStreamByte
        {
            get { return bytImageStream; }
            set { bytImageStream = value; }
        }

        public long ProducedBy
        {
            get { return lProducedBy; }
            set { lProducedBy = value; }
        }

        public string SavePath
        {
            get { return strSavePath; }
            set { strSavePath = value; }
        }

        public string DocumentDescription
        {
            get { return strDocumentDescription; }
            set { strDocumentDescription = value; }
        }

        public long MimeType
        {
            get { return lMimeTypeID; }
            set { lMimeTypeID = value; }
        }

        public long MimeApplicationVersionID
        {
            get { return lMimeApplicationVersionID; }
            set { lMimeApplicationVersionID = value; }
        }

       

        public long IsSystemDocument
        {
            get { return lIsSystemDocument; }
            set { lIsSystemDocument = value; }
        }

        public string DocumentSourceDescription
        {
            get { return strDocumentSourceDescription; }
            set { strDocumentSourceDescription = value; }
        }

        public new string ErrorMessage
        {
            get { return errMessage; }
            set { errMessage = value; }
        }

        public long FolioNo
        {
            get { return lFolioNo; }
            set { lFolioNo = value; }
        }

        public new long StatusID
        {
            get { return lStatusID; }
            set { lStatusID = value; }
        }

        public long ForInputOutput
        {
            get { return lForInputOutput; }
            set { lForInputOutput = value; }
        }

        public new DateTime DateCreated
        {
            get { return dtDateCreated; }
            set { dtDateCreated = value; }
        }

        public new DateTime DateRegistered
        {
            get { return dtDateRegistered; }
            set { dtDateRegistered = value; }
        }

        public new DateTime DateDeRegistered
        {
            get { return dtDateDeRegistered; }
            set { dtDateDeRegistered = value; }
        }

        public string SourceDocumentPath
        {
            get { return strSourceDocumentPath; }
            set { strSourceDocumentPath = value; }
        }



        #endregion



        #region "DatabaseFunctions"


        public bool ReturnAllDocumentsOfDocumentTypeByDocumentTypeID(long lLimit, long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_documentsofdocumenttypebydocumenttypeid(" +
                    lDocumentTypeID + "," + lLimit + "," + lOffset + ")";

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

                                datDocumentMaster = objLogin.PGDataSet;
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

        public bool ReturnAllDocumentsOfDocumentTypeInDocumentVolumeFolderByDocumentVolumeID(long lLimit, long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getdocumentsofdocumenttypeindocumentvolumefolderbydocumentvolumeid("
                    + lDocumentTypeID + "," + lLimit + "," + lOffset + ")";

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

                                    if (myDataRowsDocumentType["DOCUMENTID"] != DBNull.Value)
                                    {
                                        lDocumentID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTID"]);
                                    }


                                    if (myDataRowsDocumentType["DOCUMENTPRODUCERID"] != DBNull.Value)
                                    {
                                        lDocumentProducerUserID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTPRODUCERID"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTTYPEID"] != DBNull.Value)
                                    {
                                        lDocumentTypeID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTTYPEID"]);
                                    }

                                    if (myDataRowsDocumentType["DATEPRODUCED"] != DBNull.Value)
                                    {
                                        dtDateProduced = Convert.ToDateTime(myDataRowsDocumentType["DATEPRODUCED"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTSERIALNUMBER"] != DBNull.Value)
                                    {
                                        strDocumentSerialNumber = myDataRowsDocumentType["DOCUMENTSERIALNUMBER"].ToString();
                                    }

                                    if (myDataRowsDocumentType["IMAGE"] != DBNull.Value)
                                    {
                                        bytImageStream = (Byte[])(myDataRowsDocumentType["IMAGE"]);
                                    }

                                    if (myDataRowsDocumentType["PRODUCEDBY"] != DBNull.Value)
                                    {
                                        lProducedBy = Convert.ToInt64(myDataRowsDocumentType["PRODUCEDBY"]);
                                    }

                                    if (myDataRowsDocumentType["SAVEPATH"] != DBNull.Value)
                                    {
                                        strSavePath = myDataRowsDocumentType["SAVEPATH"].ToString();
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTDESCRIPTION"] != DBNull.Value)
                                    {
                                        strDocumentDescription = myDataRowsDocumentType["DOCUMENTDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsDocumentType["MIMETYPEID"] != DBNull.Value)
                                    {
                                        lMimeTypeID = Convert.ToInt64(myDataRowsDocumentType["MIMETYPEID"]);
                                    }

                                    if (myDataRowsDocumentType["MIMEAPPLICATIONVERSIONID"] != DBNull.Value)
                                    {
                                        lMimeApplicationVersionID =
                                            Convert.ToInt64(myDataRowsDocumentType["MIMEAPPLICATIONVERSIONID"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTFOLDERID"] != DBNull.Value)
                                    {
                                        DocumentFolderID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTFOLDERID"]);
                                    }

                                    if (myDataRowsDocumentType["ISSYSTEMDOCUMENT"] != DBNull.Value)
                                    {
                                        lIsSystemDocument = Convert.ToInt64(myDataRowsDocumentType["ISSYSTEMDOCUMENT"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTSOURCEDESCRIPTION"] != DBNull.Value)
                                    {
                                        strDocumentSourceDescription = myDataRowsDocumentType["DOCUMENTSOURCEDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsDocumentType["FOLIONO"] != DBNull.Value)
                                    {
                                        lFolioNo = Convert.ToInt64(myDataRowsDocumentType["FOLIONO"]);
                                    }

                                    if (myDataRowsDocumentType["STATUSID"] != DBNull.Value)
                                    {
                                        lStatusID = Convert.ToInt64(myDataRowsDocumentType["STATUSID"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTVOLUMEID"] != DBNull.Value)
                                    {
                                        DocumentVolumeID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTVOLUMEID"]);
                                    }

                                    if (myDataRowsDocumentType["FORINPUTOUTPUT"] != DBNull.Value)
                                    {
                                        lForInputOutput =
                                            Convert.ToInt64(myDataRowsDocumentType["FORINPUTOUTPUT"]);
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

        public bool ReturnAllDocumentTypesIDAndDocumentTypeByDocumentTypeID(long lLimit, long lOffset)
        {

            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery =
                    "SELECT * FROM trip_func_getdocumenttypeidanddocumenttypebydocumenttypeid(" + lDocumentTypeID + "," + lLimit +
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

                                datDocumentMaster = objLogin.PGDataSet;

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

        public bool ReturnDocumentIDAndDocumentSerialNumberByDocumentTypeID(long lLimit, long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery =
                    "SELECT * FROM trip_func_getdocumenttypeidanddocumenttypebydocumenttypeid(" + lDocumentTypeID + "," + lLimit +
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
                                    if (myDataRowsDocumentType["DOCUMENTID"] != DBNull.Value)
                                    {
                                        lDocumentID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTID"]);
                                    }


                                    if (myDataRowsDocumentType["DOCUMENTPRODUCERID"] != DBNull.Value)
                                    {
                                        lDocumentProducerUserID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTPRODUCERID"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTTYPEID"] != DBNull.Value)
                                    {
                                        lDocumentTypeID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTTYPEID"]);
                                    }

                                    if (myDataRowsDocumentType["DATEPRODUCED"] != DBNull.Value)
                                    {
                                        dtDateProduced = Convert.ToDateTime(myDataRowsDocumentType["DATEPRODUCED"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTSERIALNUMBER"] != DBNull.Value)
                                    {
                                        strDocumentSerialNumber = myDataRowsDocumentType["DOCUMENTSERIALNUMBER"].ToString();
                                    }

                                    if (myDataRowsDocumentType["IMAGE"] != DBNull.Value)
                                    {
                                        bytImageStream = (Byte[])(myDataRowsDocumentType["IMAGE"]);
                                    }

                                    if (myDataRowsDocumentType["PRODUCEDBY"] != DBNull.Value)
                                    {
                                        lProducedBy = Convert.ToInt64(myDataRowsDocumentType["PRODUCEDBY"]);
                                    }

                                    if (myDataRowsDocumentType["SAVEPATH"] != DBNull.Value)
                                    {
                                        strSavePath = myDataRowsDocumentType["SAVEPATH"].ToString();
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTDESCRIPTION"] != DBNull.Value)
                                    {
                                        strDocumentDescription = myDataRowsDocumentType["DOCUMENTDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsDocumentType["MIMETYPEID"] != DBNull.Value)
                                    {
                                        lMimeTypeID = Convert.ToInt64(myDataRowsDocumentType["MIMETYPEID"]);
                                    }

                                    if (myDataRowsDocumentType["MIMEAPPLICATIONVERSIONID"] != DBNull.Value)
                                    {
                                        lMimeApplicationVersionID =
                                            Convert.ToInt64(myDataRowsDocumentType["MIMEAPPLICATIONVERSIONID"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTFOLDERID"] != DBNull.Value)
                                    {
                                        DocumentFolderID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTFOLDERID"]);
                                    }

                                    if (myDataRowsDocumentType["ISSYSTEMDOCUMENT"] != DBNull.Value)
                                    {
                                        lIsSystemDocument = Convert.ToInt64(myDataRowsDocumentType["ISSYSTEMDOCUMENT"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTSOURCEDESCRIPTION"] != DBNull.Value)
                                    {
                                        strDocumentSourceDescription = myDataRowsDocumentType["DOCUMENTSOURCEDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsDocumentType["FOLIONO"] != DBNull.Value)
                                    {
                                        lFolioNo = Convert.ToInt64(myDataRowsDocumentType["FOLIONO"]);
                                    }

                                    if (myDataRowsDocumentType["STATUSID"] != DBNull.Value)
                                    {
                                        lStatusID = Convert.ToInt64(myDataRowsDocumentType["STATUSID"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTVOLUMEID"] != DBNull.Value)
                                    {
                                        DocumentVolumeID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTVOLUMEID"]);
                                    }

                                    if (myDataRowsDocumentType["FORINPUTOUTPUT"] != DBNull.Value)
                                    {
                                        lForInputOutput =
                                            Convert.ToInt64(myDataRowsDocumentType["FORINPUTOUTPUT"]);
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

        public bool ReturnFirstDocument()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getfirstdocumenttype()";

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
                                    if (myDataRowsDocumentType["DOCUMENTID"] != DBNull.Value)
                                    {
                                        lDocumentID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTID"]);
                                    }


                                    if (myDataRowsDocumentType["DOCUMENTPRODUCERID"] != DBNull.Value)
                                    {
                                        lDocumentProducerUserID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTPRODUCERID"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTTYPEID"] != DBNull.Value)
                                    {
                                        lDocumentTypeID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTTYPEID"]);
                                    }

                                    if (myDataRowsDocumentType["DATEPRODUCED"] != DBNull.Value)
                                    {
                                        dtDateProduced = Convert.ToDateTime(myDataRowsDocumentType["DATEPRODUCED"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTSERIALNUMBER"] != DBNull.Value)
                                    {
                                        strDocumentSerialNumber = myDataRowsDocumentType["DOCUMENTSERIALNUMBER"].ToString();
                                    }

                                    if (myDataRowsDocumentType["IMAGE"] != DBNull.Value)
                                    {
                                        bytImageStream = (Byte[])(myDataRowsDocumentType["IMAGE"]);
                                    }

                                    if (myDataRowsDocumentType["PRODUCEDBY"] != DBNull.Value)
                                    {
                                        lProducedBy = Convert.ToInt64(myDataRowsDocumentType["PRODUCEDBY"]);
                                    }

                                    if (myDataRowsDocumentType["SAVEPATH"] != DBNull.Value)
                                    {
                                        strSavePath = myDataRowsDocumentType["SAVEPATH"].ToString();
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTDESCRIPTION"] != DBNull.Value)
                                    {
                                        strDocumentDescription = myDataRowsDocumentType["DOCUMENTDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsDocumentType["MIMETYPEID"] != DBNull.Value)
                                    {
                                        lMimeTypeID = Convert.ToInt64(myDataRowsDocumentType["MIMETYPEID"]);
                                    }

                                    if (myDataRowsDocumentType["MIMEAPPLICATIONVERSIONID"] != DBNull.Value)
                                    {
                                        lMimeApplicationVersionID =
                                            Convert.ToInt64(myDataRowsDocumentType["MIMEAPPLICATIONVERSIONID"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTFOLDERID"] != DBNull.Value)
                                    {
                                        DocumentFolderID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTFOLDERID"]);
                                    }

                                    if (myDataRowsDocumentType["ISSYSTEMDOCUMENT"] != DBNull.Value)
                                    {
                                        lIsSystemDocument = Convert.ToInt64(myDataRowsDocumentType["ISSYSTEMDOCUMENT"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTSOURCEDESCRIPTION"] != DBNull.Value)
                                    {
                                        strDocumentSourceDescription = myDataRowsDocumentType["DOCUMENTSOURCEDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsDocumentType["FOLIONO"] != DBNull.Value)
                                    {
                                        lFolioNo = Convert.ToInt64(myDataRowsDocumentType["FOLIONO"]);
                                    }

                                    if (myDataRowsDocumentType["STATUSID"] != DBNull.Value)
                                    {
                                        lStatusID = Convert.ToInt64(myDataRowsDocumentType["STATUSID"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTVOLUMEID"] != DBNull.Value)
                                    {
                                        DocumentVolumeID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTVOLUMEID"]);
                                    }

                                    if (myDataRowsDocumentType["FORINPUTOUTPUT"] != DBNull.Value)
                                    {
                                        lForInputOutput =
                                            Convert.ToInt64(myDataRowsDocumentType["FORINPUTOUTPUT"]);
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

        public bool ReturnNextDocument()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getnextdocumenttype(" + lDocumentTypeID + ")";

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
                                    if (myDataRowsDocumentType["DOCUMENTID"] != DBNull.Value)
                                    {
                                        lDocumentID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTID"]);
                                    }


                                    if (myDataRowsDocumentType["DOCUMENTPRODUCERID"] != DBNull.Value)
                                    {
                                        lDocumentProducerUserID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTPRODUCERID"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTTYPEID"] != DBNull.Value)
                                    {
                                        lDocumentTypeID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTTYPEID"]);
                                    }

                                    if (myDataRowsDocumentType["DATEPRODUCED"] != DBNull.Value)
                                    {
                                        dtDateProduced = Convert.ToDateTime(myDataRowsDocumentType["DATEPRODUCED"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTSERIALNUMBER"] != DBNull.Value)
                                    {
                                        strDocumentSerialNumber = myDataRowsDocumentType["DOCUMENTSERIALNUMBER"].ToString();
                                    }

                                    if (myDataRowsDocumentType["IMAGE"] != DBNull.Value)
                                    {
                                        bytImageStream = (Byte[])(myDataRowsDocumentType["IMAGE"]);
                                    }

                                    if (myDataRowsDocumentType["PRODUCEDBY"] != DBNull.Value)
                                    {
                                        lProducedBy = Convert.ToInt64(myDataRowsDocumentType["PRODUCEDBY"]);
                                    }

                                    if (myDataRowsDocumentType["SAVEPATH"] != DBNull.Value)
                                    {
                                        strSavePath = myDataRowsDocumentType["SAVEPATH"].ToString();
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTDESCRIPTION"] != DBNull.Value)
                                    {
                                        strDocumentDescription = myDataRowsDocumentType["DOCUMENTDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsDocumentType["MIMETYPEID"] != DBNull.Value)
                                    {
                                        lMimeTypeID = Convert.ToInt64(myDataRowsDocumentType["MIMETYPEID"]);
                                    }

                                    if (myDataRowsDocumentType["MIMEAPPLICATIONVERSIONID"] != DBNull.Value)
                                    {
                                        lMimeApplicationVersionID =
                                            Convert.ToInt64(myDataRowsDocumentType["MIMEAPPLICATIONVERSIONID"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTFOLDERID"] != DBNull.Value)
                                    {
                                        DocumentFolderID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTFOLDERID"]);
                                    }

                                    if (myDataRowsDocumentType["ISSYSTEMDOCUMENT"] != DBNull.Value)
                                    {
                                        lIsSystemDocument = Convert.ToInt64(myDataRowsDocumentType["ISSYSTEMDOCUMENT"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTSOURCEDESCRIPTION"] != DBNull.Value)
                                    {
                                        strDocumentSourceDescription = myDataRowsDocumentType["DOCUMENTSOURCEDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsDocumentType["FOLIONO"] != DBNull.Value)
                                    {
                                        lFolioNo = Convert.ToInt64(myDataRowsDocumentType["FOLIONO"]);
                                    }

                                    if (myDataRowsDocumentType["STATUSID"] != DBNull.Value)
                                    {
                                        lStatusID = Convert.ToInt64(myDataRowsDocumentType["STATUSID"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTVOLUMEID"] != DBNull.Value)
                                    {
                                        DocumentVolumeID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTVOLUMEID"]);
                                    }

                                    if (myDataRowsDocumentType["FORINPUTOUTPUT"] != DBNull.Value)
                                    {
                                        lForInputOutput =
                                            Convert.ToInt64(myDataRowsDocumentType["FORINPUTOUTPUT"]);
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

        public bool ReturnPreviousDocument()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getprevdocumenttype(" + lDocumentTypeID + ")";

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
                                    if (myDataRowsDocumentType["DOCUMENTID"] != DBNull.Value)
                                    {
                                        lDocumentID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTID"]);
                                    }


                                    if (myDataRowsDocumentType["DOCUMENTPRODUCERID"] != DBNull.Value)
                                    {
                                        lDocumentProducerUserID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTPRODUCERID"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTTYPEID"] != DBNull.Value)
                                    {
                                        lDocumentTypeID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTTYPEID"]);
                                    }

                                    if (myDataRowsDocumentType["DATEPRODUCED"] != DBNull.Value)
                                    {
                                        dtDateProduced = Convert.ToDateTime(myDataRowsDocumentType["DATEPRODUCED"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTSERIALNUMBER"] != DBNull.Value)
                                    {
                                        strDocumentSerialNumber = myDataRowsDocumentType["DOCUMENTSERIALNUMBER"].ToString();
                                    }

                                    if (myDataRowsDocumentType["IMAGE"] != DBNull.Value)
                                    {
                                        bytImageStream = (Byte[])(myDataRowsDocumentType["IMAGE"]);
                                    }

                                    if (myDataRowsDocumentType["PRODUCEDBY"] != DBNull.Value)
                                    {
                                        lProducedBy = Convert.ToInt64(myDataRowsDocumentType["PRODUCEDBY"]);
                                    }

                                    if (myDataRowsDocumentType["SAVEPATH"] != DBNull.Value)
                                    {
                                        strSavePath = myDataRowsDocumentType["SAVEPATH"].ToString();
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTDESCRIPTION"] != DBNull.Value)
                                    {
                                        strDocumentDescription = myDataRowsDocumentType["DOCUMENTDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsDocumentType["MIMETYPEID"] != DBNull.Value)
                                    {
                                        lMimeTypeID = Convert.ToInt64(myDataRowsDocumentType["MIMETYPEID"]);
                                    }

                                    if (myDataRowsDocumentType["MIMEAPPLICATIONVERSIONID"] != DBNull.Value)
                                    {
                                        lMimeApplicationVersionID =
                                            Convert.ToInt64(myDataRowsDocumentType["MIMEAPPLICATIONVERSIONID"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTFOLDERID"] != DBNull.Value)
                                    {
                                        DocumentFolderID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTFOLDERID"]);
                                    }

                                    if (myDataRowsDocumentType["ISSYSTEMDOCUMENT"] != DBNull.Value)
                                    {
                                        lIsSystemDocument = Convert.ToInt64(myDataRowsDocumentType["ISSYSTEMDOCUMENT"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTSOURCEDESCRIPTION"] != DBNull.Value)
                                    {
                                        strDocumentSourceDescription = myDataRowsDocumentType["DOCUMENTSOURCEDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsDocumentType["FOLIONO"] != DBNull.Value)
                                    {
                                        lFolioNo = Convert.ToInt64(myDataRowsDocumentType["FOLIONO"]);
                                    }

                                    if (myDataRowsDocumentType["STATUSID"] != DBNull.Value)
                                    {
                                        lStatusID = Convert.ToInt64(myDataRowsDocumentType["STATUSID"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTVOLUMEID"] != DBNull.Value)
                                    {
                                        DocumentVolumeID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTVOLUMEID"]);
                                    }

                                    if (myDataRowsDocumentType["FORINPUTOUTPUT"] != DBNull.Value)
                                    {
                                        lForInputOutput =
                                            Convert.ToInt64(myDataRowsDocumentType["FORINPUTOUTPUT"]);
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

        public bool ReturnLastDocument()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getlastdocumenttype()";

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
                                    if (myDataRowsDocumentType["DOCUMENTID"] != DBNull.Value)
                                    {
                                        lDocumentID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTID"]);
                                    }


                                    if (myDataRowsDocumentType["DOCUMENTPRODUCERID"] != DBNull.Value)
                                    {
                                        lDocumentProducerUserID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTPRODUCERID"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTTYPEID"] != DBNull.Value)
                                    {
                                        lDocumentTypeID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTTYPEID"]);
                                    }

                                    if (myDataRowsDocumentType["DATEPRODUCED"] != DBNull.Value)
                                    {
                                        dtDateProduced = Convert.ToDateTime(myDataRowsDocumentType["DATEPRODUCED"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTSERIALNUMBER"] != DBNull.Value)
                                    {
                                        strDocumentSerialNumber = myDataRowsDocumentType["DOCUMENTSERIALNUMBER"].ToString();
                                    }

                                    if (myDataRowsDocumentType["IMAGE"] != DBNull.Value)
                                    {
                                        bytImageStream = (Byte[])(myDataRowsDocumentType["IMAGE"]);
                                    }

                                    if (myDataRowsDocumentType["PRODUCEDBY"] != DBNull.Value)
                                    {
                                        lProducedBy = Convert.ToInt64(myDataRowsDocumentType["PRODUCEDBY"]);
                                    }

                                    if (myDataRowsDocumentType["SAVEPATH"] != DBNull.Value)
                                    {
                                        strSavePath = myDataRowsDocumentType["SAVEPATH"].ToString();
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTDESCRIPTION"] != DBNull.Value)
                                    {
                                        strDocumentDescription = myDataRowsDocumentType["DOCUMENTDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsDocumentType["MIMETYPEID"] != DBNull.Value)
                                    {
                                        lMimeTypeID = Convert.ToInt64(myDataRowsDocumentType["MIMETYPEID"]);
                                    }

                                    if (myDataRowsDocumentType["MIMEAPPLICATIONVERSIONID"] != DBNull.Value)
                                    {
                                        lMimeApplicationVersionID= 
                                            Convert.ToInt64(myDataRowsDocumentType["MIMEAPPLICATIONVERSIONID"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTFOLDERID"] != DBNull.Value)
                                    {
                                        DocumentFolderID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTFOLDERID"]);
                                    }

                                    if (myDataRowsDocumentType["ISSYSTEMDOCUMENT"] != DBNull.Value)
                                    {
                                        lIsSystemDocument = Convert.ToInt64(myDataRowsDocumentType["ISSYSTEMDOCUMENT"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTSOURCEDESCRIPTION"] != DBNull.Value)
                                    {
                                        strDocumentSourceDescription = myDataRowsDocumentType["DOCUMENTSOURCEDESCRIPTION"].ToString();
                                    }

                                    if (myDataRowsDocumentType["FOLIONO"] != DBNull.Value)
                                    {
                                        lFolioNo = Convert.ToInt64(myDataRowsDocumentType["FOLIONO"]);
                                    }

                                    if (myDataRowsDocumentType["STATUSID"] != DBNull.Value)
                                    {
                                        lStatusID = Convert.ToInt64(myDataRowsDocumentType["STATUSID"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTVOLUMEID"] != DBNull.Value)
                                    {
                                        DocumentVolumeID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTVOLUMEID"]);
                                    }

                                    if (myDataRowsDocumentType["FORINPUTOUTPUT"] != DBNull.Value)
                                    {
                                        lForInputOutput =
                                            Convert.ToInt64(myDataRowsDocumentType["FORINPUTOUTPUT"]);
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

        public bool SaveDocument()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {


                strQuery = "SELECT trip_func_insertupdatecapturedocumenttypes(" +
                            lDocumentTypeID + ",'" +
                            lDocumentProducerUserID + "','" +
                            dtDateProduced + "'," +
                            strDocumentSerialNumber + "," +
                            bytImageStream + "," +
                            lProducedBy + "," +
                            strSavePath + "," +
                            strDocumentDescription + ",'" +
                            lMimeTypeID + "'," +
                            lMimeApplicationVersionID + "'," +
                            DocumentFolderID + ",'" +
                            lIsSystemDocument + ",'" +
                            strDocumentSourceDescription + ",'" +
                            lFolioNo + ",'" +
                            lStatusID + ",'" +
                            DocumentVolumeID + ",'" +
                            lForInputOutput + "')";

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
                                datDocumentMaster = objLogin.PGDataSet;
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

        public bool LoadDocumentBinartToSystem()
        {
            try
            {
                FileStream srcStream = new FileStream(strSourceDocumentPath, FileMode.Open, FileAccess.Read);
                bytImageStream = new byte[srcStream.Length];
                int read = srcStream.Read(bytImageStream, 0, bytImageStream.Length);

                //string sql = "INSERT INTO hrnvpict(ma_nv,pict) VALUES(@ma_nhan_vien ,@arrImage)";
                //comm.Parameters.Add(new NpgsqlParameter("@arrImage", DbType.Binary)).Value = arrImage;
                //comm.Parameters.Add(new NpgsqlParameter("@ma_nhanvien", DbType.String, 40)).Value = _ma_nv;
                //comm.ExecuteNonQuery();

                return true;
            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
                return false;

            }

            finally
            {

            }

        }

        public bool GetDocumentImage()
        {

            try
            {
                string cmd = "select pict from hrnvpict where trim(ma_nv)= '" + "'_ma_nv'" + "'";
                //bytImageStream = (Byte[])comm.ExecuteScalar();
                //MemoryStream pic = new MemoryStream(result);
                //pictureBox1.Image = Image.FromStream(pic)
                //comm.ExecuteNonQuery();
                return true;
            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
                return false;

            }

            finally
            {

            }

        }



        #endregion

    }
}
