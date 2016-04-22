using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace TRIP_API
{
    public class IMDocumentTypes
    {

        #region "Variable"


        private long lDocumentTypeID = 0;
        private string strDocumentType = "";
        private string strDocumentPurpose = "";
        private long lNoOfPrintOuts = 0;
        private long lNoOfScans = 0;
        private long lProducedByUserGroup = 0;
        private long lProducedForUserGroup = 0;
        private long lDefaultPrinterGroup = 0;
        private string strDefaultSavePath = "";
        private long lNoOfPhotocopies = 0;
        private string strQualityofPhotocopies = "";
        private DateTime dtDateCreated;
        private DateTime dtDateRegistered;
        private DateTime dtDateDeRegistered;
        private DataSet datDocumentTypes;

        private string errMessage;


        #endregion


        #region "Properties"


        public long DocumentTypeID
        {
            get { return lDocumentTypeID; }
            set { lDocumentTypeID = value; }
        }

        public string DocumentType
        {
            get { return strDocumentType; }
            set { strDocumentType = value; }
        }

        public string DocumentPurpose
        {
            get { return strDocumentPurpose; }
            set { strDocumentPurpose = value; }
        }

        public long NoOfPrintOuts
        {
            get { return lNoOfPrintOuts; }
            set { lNoOfPrintOuts = value; }
        }

        public long NoOfScans
        {
            get { return lNoOfScans; }
            set { lNoOfScans = value; }
        }

        public long ProducedByUserGroup
        {
            get { return lProducedByUserGroup; }
            set { lProducedByUserGroup = value; }
        }

        public long ProducedForUserGroup
        {
            get { return lProducedForUserGroup; }
            set { lProducedForUserGroup = value; }
        }

        public long DefaultPrinterGroup
        {
            get { return lDefaultPrinterGroup; }
            set { lDefaultPrinterGroup = value; }
        }

        public long NoOfPhotocopies
        {
            get { return lNoOfPhotocopies; }
            set { lNoOfPhotocopies = value; }
        }

        public string QualityOfPhotocopies
        {
            get { return strQualityofPhotocopies; }
            set { strQualityofPhotocopies = value; }
        }

        public string DefaultSavePath
        {
            get { return strDefaultSavePath; }
            set { strDefaultSavePath = value; }
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

        public DataSet DocumentTypesDataSet
        {
            get { return datDocumentTypes; }
            set { datDocumentTypes = value; }
        }


        #endregion



        #region "DatabaseFunctions"


        public bool ReturnAllDocumentTypesMasterByDocumentTypeID(long lLimit,
            long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getdocumenttypesbydocumenttypeid(0," + lLimit +
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

                                datDocumentTypes = objLogin.PGDataSet;
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

        public bool ReturnDocumentTypesMasterByDocumentTypeID(long lLimit,
            long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getdocumenttypesbydocumenttypeid(" + lDocumentTypeID + "," + lLimit +
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
                                    if (myDataRowsDocumentType["DOCUMENTTYPEID"] != DBNull.Value)
                                    {
                                        lDocumentTypeID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTTYPEID"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTTYPE"] != DBNull.Value)
                                    {
                                        strDocumentType = myDataRowsDocumentType["DOCUMENTTYPE"].ToString();
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTPURPOSE"] != DBNull.Value)
                                    {
                                        strDocumentPurpose = myDataRowsDocumentType["DOCUMENTPURPOSE"].ToString();
                                    }

                                    if (myDataRowsDocumentType["NOOFPRINTOUTS"] != DBNull.Value)
                                    {
                                        lNoOfPrintOuts = Convert.ToInt64(myDataRowsDocumentType["NOOFPRINTOUTS"]);
                                    }

                                    if (myDataRowsDocumentType["NOOFSCANS"] != DBNull.Value)
                                    {
                                        lNoOfScans = Convert.ToInt64(myDataRowsDocumentType["NOOFSCANS"]);
                                    }

                                    if (myDataRowsDocumentType["DEFAULTPRINTERGROUP"] != DBNull.Value)
                                    {
                                        lDefaultPrinterGroup = Convert.ToInt64(myDataRowsDocumentType["DEFAULTPRINTERGROUP"]);
                                    }

                                    if (myDataRowsDocumentType["PRODUCEDBYUSERGROUP"] != DBNull.Value)
                                    {
                                        lProducedByUserGroup = Convert.ToInt64(myDataRowsDocumentType["PRODUCEDBYUSERGROUP"]);
                                    }

                                    if (myDataRowsDocumentType["PRODUCEDFORUSERGROUP"] != DBNull.Value)
                                    {
                                        lProducedForUserGroup = Convert.ToInt64(myDataRowsDocumentType["PRODUCEDFORUSERGROUP"]);
                                    }

                                    if (myDataRowsDocumentType["NOOFPHOTOCOPIES"] != DBNull.Value)
                                    {
                                        lNoOfPhotocopies = Convert.ToInt64(myDataRowsDocumentType["NOOFPHOTOCOPIES"]);
                                    }

                                    if (myDataRowsDocumentType["QUALITYOFPHOTOCOPIES"] != DBNull.Value)
                                    {
                                        strQualityofPhotocopies =
                                            myDataRowsDocumentType["QUALITYOFPHOTOCOPIES"].ToString();
                                    }

                                    if (myDataRowsDocumentType["DEFAULTSAVEPATH"] != DBNull.Value)
                                    {
                                        strDefaultSavePath = myDataRowsDocumentType["PRODUCEDFORUSERGROUP"].ToString();
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
                return false;
            }

            finally
            {
                datRetData = null;
                objLogin = null;

            }
        }

        public bool ReturnAllDocumentTypesIDAndDocumentTypeByDocumentTypeID(long lLimit,
            long lOffset)
        {

            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery =
                    "SELECT * FROM trip_func_getdocumenttypeidanddocumenttypebydocumenttypeid(0," + lLimit +
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
                                datDocumentTypes = objLogin.PGDataSet;
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

        public bool ReturnDocumentTypesIDAndDocumentTypeByDocumentTypeID(long lLimit,
            long lOffset)
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
                                    if (myDataRowsDocumentType["DOCUMENTTYPEID"] != DBNull.Value)
                                    {
                                        lDocumentTypeID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTTYPEID"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTTYPE"] != DBNull.Value)
                                    {
                                        strDocumentType = myDataRowsDocumentType["DOCUMENTTYPE"].ToString();
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTPURPOSE"] != DBNull.Value)
                                    {
                                        strDocumentPurpose = myDataRowsDocumentType["DOCUMENTPURPOSE"].ToString();
                                    }

                                    if (myDataRowsDocumentType["NOOFPRINTOUTS"] != DBNull.Value)
                                    {
                                        lNoOfPrintOuts = Convert.ToInt64(myDataRowsDocumentType["NOOFPRINTOUTS"]);
                                    }

                                    if (myDataRowsDocumentType["NOOFSCANS"] != DBNull.Value)
                                    {
                                        lNoOfScans = Convert.ToInt64(myDataRowsDocumentType["NOOFSCANS"]);
                                    }

                                    if (myDataRowsDocumentType["DEFAULTPRINTERGROUP"] != DBNull.Value)
                                    {
                                        lDefaultPrinterGroup = Convert.ToInt64(myDataRowsDocumentType["DEFAULTPRINTERGROUP"]);
                                    }

                                    if (myDataRowsDocumentType["PRODUCEDBYUSERGROUP"] != DBNull.Value)
                                    {
                                        lProducedByUserGroup = Convert.ToInt64(myDataRowsDocumentType["PRODUCEDBYUSERGROUP"]);
                                    }

                                    if (myDataRowsDocumentType["PRODUCEDFORUSERGROUP"] != DBNull.Value)
                                    {
                                        lProducedForUserGroup = Convert.ToInt64(myDataRowsDocumentType["PRODUCEDFORUSERGROUP"]);
                                    }

                                    if (myDataRowsDocumentType["NOOFPHOTOCOPIES"] != DBNull.Value)
                                    {
                                        lNoOfPhotocopies = Convert.ToInt64(myDataRowsDocumentType["NOOFPHOTOCOPIES"]);
                                    }

                                    if (myDataRowsDocumentType["QUALITYOFPHOTOCOPIES"] != DBNull.Value)
                                    {
                                        strQualityofPhotocopies =
                                            myDataRowsDocumentType["QUALITYOFPHOTOCOPIES"].ToString();
                                    }

                                    if (myDataRowsDocumentType["DEFAULTSAVEPATH"] != DBNull.Value)
                                    {
                                        strDefaultSavePath = myDataRowsDocumentType["PRODUCEDFORUSERGROUP"].ToString();
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
                                    if (myDataRowsDocumentType["DOCUMENTTYPEID"] != DBNull.Value)
                                    {
                                        lDocumentTypeID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTTYPEID"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTTYPE"] != DBNull.Value)
                                    {
                                        strDocumentType = myDataRowsDocumentType["DOCUMENTTYPE"].ToString();
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTPURPOSE"] != DBNull.Value)
                                    {
                                        strDocumentPurpose = myDataRowsDocumentType["DOCUMENTPURPOSE"].ToString();
                                    }

                                    if (myDataRowsDocumentType["NOOFPRINTOUTS"] != DBNull.Value)
                                    {
                                        lNoOfPrintOuts = Convert.ToInt64(myDataRowsDocumentType["NOOFPRINTOUTS"]);
                                    }

                                    if (myDataRowsDocumentType["NOOFSCANS"] != DBNull.Value)
                                    {
                                        lNoOfScans = Convert.ToInt64(myDataRowsDocumentType["NOOFSCANS"]);
                                    }

                                    if (myDataRowsDocumentType["DEFAULTPRINTERGROUP"] != DBNull.Value)
                                    {
                                        lDefaultPrinterGroup = Convert.ToInt64(myDataRowsDocumentType["DEFAULTPRINTERGROUP"]);
                                    }

                                    if (myDataRowsDocumentType["PRODUCEDBYUSERGROUP"] != DBNull.Value)
                                    {
                                        lProducedByUserGroup = Convert.ToInt64(myDataRowsDocumentType["PRODUCEDBYUSERGROUP"]);
                                    }

                                    if (myDataRowsDocumentType["PRODUCEDFORUSERGROUP"] != DBNull.Value)
                                    {
                                        lProducedForUserGroup = Convert.ToInt64(myDataRowsDocumentType["PRODUCEDFORUSERGROUP"]);
                                    }

                                    if (myDataRowsDocumentType["NOOFPHOTOCOPIES"] != DBNull.Value)
                                    {
                                        lNoOfPhotocopies = Convert.ToInt64(myDataRowsDocumentType["NOOFPHOTOCOPIES"]);
                                    }

                                    if (myDataRowsDocumentType["QUALITYOFPHOTOCOPIES"] != DBNull.Value)
                                    {
                                        strQualityofPhotocopies =
                                            myDataRowsDocumentType["QUALITYOFPHOTOCOPIES"].ToString();
                                    }

                                    if (myDataRowsDocumentType["DEFAULTSAVEPATH"] != DBNull.Value)
                                    {
                                        strDefaultSavePath = myDataRowsDocumentType["PRODUCEDFORUSERGROUP"].ToString();
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
                return false;
            }

            finally
            {
                datRetData = null;
                objLogin = null;

            }
        }

        public bool ReturnNextDocumentType()
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
                                    if (myDataRowsDocumentType["DOCUMENTTYPEID"] != DBNull.Value)
                                    {
                                        lDocumentTypeID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTTYPEID"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTTYPE"] != DBNull.Value)
                                    {
                                        strDocumentType = myDataRowsDocumentType["DOCUMENTTYPE"].ToString();
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTPURPOSE"] != DBNull.Value)
                                    {
                                        strDocumentPurpose = myDataRowsDocumentType["DOCUMENTPURPOSE"].ToString();
                                    }

                                    if (myDataRowsDocumentType["NOOFPRINTOUTS"] != DBNull.Value)
                                    {
                                        lNoOfPrintOuts = Convert.ToInt64(myDataRowsDocumentType["NOOFPRINTOUTS"]);
                                    }

                                    if (myDataRowsDocumentType["NOOFSCANS"] != DBNull.Value)
                                    {
                                        lNoOfScans = Convert.ToInt64(myDataRowsDocumentType["NOOFSCANS"]);
                                    }

                                    if (myDataRowsDocumentType["DEFAULTPRINTERGROUP"] != DBNull.Value)
                                    {
                                        lDefaultPrinterGroup = Convert.ToInt64(myDataRowsDocumentType["DEFAULTPRINTERGROUP"]);
                                    }

                                    if (myDataRowsDocumentType["PRODUCEDBYUSERGROUP"] != DBNull.Value)
                                    {
                                        lProducedByUserGroup = Convert.ToInt64(myDataRowsDocumentType["PRODUCEDBYUSERGROUP"]);
                                    }

                                    if (myDataRowsDocumentType["PRODUCEDFORUSERGROUP"] != DBNull.Value)
                                    {
                                        lProducedForUserGroup = Convert.ToInt64(myDataRowsDocumentType["PRODUCEDFORUSERGROUP"]);
                                    }

                                    if (myDataRowsDocumentType["NOOFPHOTOCOPIES"] != DBNull.Value)
                                    {
                                        lNoOfPhotocopies = Convert.ToInt64(myDataRowsDocumentType["NOOFPHOTOCOPIES"]);
                                    }

                                    if (myDataRowsDocumentType["QUALITYOFPHOTOCOPIES"] != DBNull.Value)
                                    {
                                        strQualityofPhotocopies =
                                            myDataRowsDocumentType["QUALITYOFPHOTOCOPIES"].ToString();
                                    }

                                    if (myDataRowsDocumentType["DEFAULTSAVEPATH"] != DBNull.Value)
                                    {
                                        strDefaultSavePath = myDataRowsDocumentType["PRODUCEDFORUSERGROUP"].ToString();
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
                return false;
            }

            finally
            {
                datRetData = null;
                objLogin = null;

            }
        }

        public bool ReturnPreviousDocumentType()
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
                                    if (myDataRowsDocumentType["DOCUMENTTYPEID"] != DBNull.Value)
                                    {
                                        lDocumentTypeID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTTYPEID"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTTYPE"] != DBNull.Value)
                                    {
                                        strDocumentType = myDataRowsDocumentType["DOCUMENTTYPE"].ToString();
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTPURPOSE"] != DBNull.Value)
                                    {
                                        strDocumentPurpose = myDataRowsDocumentType["DOCUMENTPURPOSE"].ToString();
                                    }

                                    if (myDataRowsDocumentType["NOOFPRINTOUTS"] != DBNull.Value)
                                    {
                                        lNoOfPrintOuts = Convert.ToInt64(myDataRowsDocumentType["NOOFPRINTOUTS"]);
                                    }

                                    if (myDataRowsDocumentType["NOOFSCANS"] != DBNull.Value)
                                    {
                                        lNoOfScans = Convert.ToInt64(myDataRowsDocumentType["NOOFSCANS"]);
                                    }

                                    if (myDataRowsDocumentType["DEFAULTPRINTERGROUP"] != DBNull.Value)
                                    {
                                        lDefaultPrinterGroup = Convert.ToInt64(myDataRowsDocumentType["DEFAULTPRINTERGROUP"]);
                                    }

                                    if (myDataRowsDocumentType["PRODUCEDBYUSERGROUP"] != DBNull.Value)
                                    {
                                        lProducedByUserGroup = Convert.ToInt64(myDataRowsDocumentType["PRODUCEDBYUSERGROUP"]);
                                    }

                                    if (myDataRowsDocumentType["PRODUCEDFORUSERGROUP"] != DBNull.Value)
                                    {
                                        lProducedForUserGroup = Convert.ToInt64(myDataRowsDocumentType["PRODUCEDFORUSERGROUP"]);
                                    }

                                    if (myDataRowsDocumentType["NOOFPHOTOCOPIES"] != DBNull.Value)
                                    {
                                        lNoOfPhotocopies = Convert.ToInt64(myDataRowsDocumentType["NOOFPHOTOCOPIES"]);
                                    }

                                    if (myDataRowsDocumentType["QUALITYOFPHOTOCOPIES"] != DBNull.Value)
                                    {
                                        strQualityofPhotocopies =
                                            myDataRowsDocumentType["QUALITYOFPHOTOCOPIES"].ToString();
                                    }

                                    if (myDataRowsDocumentType["DEFAULTSAVEPATH"] != DBNull.Value)
                                    {
                                        strDefaultSavePath = myDataRowsDocumentType["PRODUCEDFORUSERGROUP"].ToString();
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
                return false;
            }

            finally
            {
                datRetData = null;
                objLogin = null;

            }
        }

        public bool ReturnLastDocumentType()
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
                                    if (myDataRowsDocumentType["DOCUMENTTYPEID"] != DBNull.Value)
                                    {
                                        lDocumentTypeID = Convert.ToInt64(myDataRowsDocumentType["DOCUMENTTYPEID"]);
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTTYPE"] != DBNull.Value)
                                    {
                                        strDocumentType = myDataRowsDocumentType["DOCUMENTTYPE"].ToString();
                                    }

                                    if (myDataRowsDocumentType["DOCUMENTPURPOSE"] != DBNull.Value)
                                    {
                                        strDocumentPurpose = myDataRowsDocumentType["DOCUMENTPURPOSE"].ToString();
                                    }

                                    if (myDataRowsDocumentType["NOOFPRINTOUTS"] != DBNull.Value)
                                    {
                                        lNoOfPrintOuts = Convert.ToInt64(myDataRowsDocumentType["NOOFPRINTOUTS"]);
                                    }

                                    if (myDataRowsDocumentType["NOOFSCANS"] != DBNull.Value)
                                    {
                                        lNoOfScans = Convert.ToInt64(myDataRowsDocumentType["NOOFSCANS"]);
                                    }

                                    if (myDataRowsDocumentType["DEFAULTPRINTERGROUP"] != DBNull.Value)
                                    {
                                        lDefaultPrinterGroup = Convert.ToInt64(myDataRowsDocumentType["DEFAULTPRINTERGROUP"]);
                                    }

                                    if (myDataRowsDocumentType["PRODUCEDBYUSERGROUP"] != DBNull.Value)
                                    {
                                        lProducedByUserGroup = Convert.ToInt64(myDataRowsDocumentType["PRODUCEDBYUSERGROUP"]);
                                    }

                                    if (myDataRowsDocumentType["PRODUCEDFORUSERGROUP"] != DBNull.Value)
                                    {
                                        lProducedForUserGroup = Convert.ToInt64(myDataRowsDocumentType["PRODUCEDFORUSERGROUP"]);
                                    }

                                    if (myDataRowsDocumentType["NOOFPHOTOCOPIES"] != DBNull.Value)
                                    {
                                        lNoOfPhotocopies = Convert.ToInt64(myDataRowsDocumentType["NOOFPHOTOCOPIES"]);
                                    }

                                    if (myDataRowsDocumentType["QUALITYOFPHOTOCOPIES"] != DBNull.Value)
                                    {
                                        strQualityofPhotocopies =
                                            myDataRowsDocumentType["QUALITYOFPHOTOCOPIES"].ToString();
                                    }

                                    if (myDataRowsDocumentType["DEFAULTSAVEPATH"] != DBNull.Value)
                                    {
                                        strDefaultSavePath = myDataRowsDocumentType["PRODUCEDFORUSERGROUP"].ToString();
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
                return false;
            }

            finally
            {
                datRetData = null;
                objLogin = null;

            }
        }

        public bool SaveDocumentTypes()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT trip_func_insertupdatecapturedocumenttypes(" + 
                            lDocumentTypeID + ",'" + 
                            strDocumentType  + "','" + 
                            strDocumentPurpose  + "'," +
                            lNoOfPrintOuts  + "," +
                            lNoOfScans + "," +
                            lProducedByUserGroup + "," +
                            lProducedForUserGroup + "," +
                            lDefaultPrinterGroup + ",'" +
                            strDefaultSavePath + "'," +
                            lNoOfPhotocopies + ",'" + 
                            strQualityofPhotocopies + "')";

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
                                datDocumentTypes = objLogin.PGDataSet;
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
