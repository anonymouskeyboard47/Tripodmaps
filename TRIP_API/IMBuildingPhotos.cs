using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace TRIP_API
{
    public class IMBuildingPhotos : IMDocumentMaster
    {


        #region "Variable"
        
        private long lBuildingID;
        private long lPhotoID = 0;
        private long lStatusID = 0;
        private Byte bytBuildingPhoto;

        private DateTime dtDateCreated;
        private DateTime dtDateRegistered;
        private DateTime dtDateDeRegistered;
        private DataSet datBuildingPhotos;
        private string errMessage;
        #endregion


        #region "Properties"

        public long BuildingID
        {
            get { return lBuildingID; }
            set { lBuildingID = value; }
        }

        public long PhotoID
        {
            get { return lPhotoID; }
            set { lPhotoID = value; }
        }

        public long StatusID
        {
            get { return lStatusID; }
            set { lStatusID = value; }
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

        public DataSet BuildingPhotos
        {
            get { return datBuildingPhotos; }
            set { datBuildingPhotos = value; }
        }

        #endregion


        #region "DatabaseFunctions"

        public bool ReturnAllBuildingPhotosByBuildingID(long lLimit, long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getbuildingphotosbybuildingidandphotoid(" + lBuildingID + "," + "0" + 
                    "," + lLimit + "," + lOffset + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesBuildingPhotos in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesBuildingPhotos.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                datBuildingPhotos = objLogin.PGDataSet;
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
                errMessage = ex.Message;
                return false;
            }

            finally
            {
                datRetData = null;

                objLogin = null;

            }
        }

        public bool ReturnBuildingPhotosByBuildingID(long lLimit, long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getbuildingphotosbybuildingidandphotoid(" + lBuildingID + "," + lPhotoID +
                    "," + lLimit + "," + lOffset + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesBuildingPhotos in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesBuildingPhotos.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsBuildingPhotos in myDataTablesBuildingPhotos.Rows)
                                {
                                    if (myDataRowsBuildingPhotos["BUILDINGID"] != DBNull.Value)
                                    {
                                        lBuildingID = Convert.ToInt64(myDataRowsBuildingPhotos["BUILDINGID"]);
                                    }

                                    if (myDataRowsBuildingPhotos["PHOTOID"] != DBNull.Value)
                                    {
                                        lPhotoID =  Convert.ToInt64(myDataRowsBuildingPhotos["PHOTOID"]);
                                    }

                                    if (myDataRowsBuildingPhotos["DOCUMENTID"] != DBNull.Value)
                                    {
                                        DocumentID = Convert.ToInt64(myDataRowsBuildingPhotos["DOCUMENTID"]);
                                    }

                                    if (myDataRowsBuildingPhotos["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsBuildingPhotos["DATECREATED"]);
                                    }

                                    if (myDataRowsBuildingPhotos["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsBuildingPhotos["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsBuildingPhotos["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsBuildingPhotos["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsBuildingPhotos["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsBuildingPhotos["USERID"]);

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
                errMessage = ex.Message;
                return false;
            }

            finally
            {
                datRetData = null;

                objLogin = null;

            }
        }

        public bool ReturnAlBuildingIDAndBuildingPhotoIDByBuildingIDAndPhotoID(long lLimit, long lOffset)
        {

            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getbuildingandphotoidbybuildingidandphotoid(" + lBuildingID + "," + "0" +
                    "," + lLimit + "," + lOffset + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesBuildingPhotos in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesBuildingPhotos.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                datBuildingPhotos = objLogin.PGDataSet;

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
                errMessage = ex.Message;
                return false;
            }

            finally
            {
                datRetData = null;
                objLogin = null;

            }
        }

        public bool ReturnBuildingIDAndBuildingPhotoIDByBuildingIDAndPhotoID(long lLimit, long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getbuildingandphotoidbybuildingidandphotoid(" + lBuildingID + "," + lPhotoID +
                    "," + lLimit + "," + lOffset + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesBuildingPhotos in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesBuildingPhotos.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {



                                foreach (DataRow myDataRowsBuildingPhotos in myDataTablesBuildingPhotos.Rows)
                                {
                                    if (myDataRowsBuildingPhotos["BUILDINGID"] != DBNull.Value)
                                    {
                                        lBuildingID = Convert.ToInt64(myDataRowsBuildingPhotos["BUILDINGID"]);
                                    }

                                    if (myDataRowsBuildingPhotos["PHOTOID"] != DBNull.Value)
                                    {
                                        lPhotoID =  Convert.ToInt64(myDataRowsBuildingPhotos["PHOTOID"]);
                                    }

                                    if (myDataRowsBuildingPhotos["DOCUMENTID"] != DBNull.Value)
                                    {
                                        DocumentID = Convert.ToInt64(myDataRowsBuildingPhotos["DOCUMENTID"]);
                                    }

                                    if (myDataRowsBuildingPhotos["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsBuildingPhotos["DATECREATED"]);
                                    }

                                    if (myDataRowsBuildingPhotos["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsBuildingPhotos["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsBuildingPhotos["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsBuildingPhotos["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsBuildingPhotos["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsBuildingPhotos["USERID"]);

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
                errMessage = ex.Message;
                return false;
            }

            finally
            {

                datRetData = null;
                objLogin = null;

            }
        }

        public bool ReturnFirstBuildingPhoto()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getfirstbuildingphoto(" + lBuildingID + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesBuildingPhotos in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesBuildingPhotos.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsBuildingPhotos in myDataTablesBuildingPhotos.Rows)
                                {
                                    if (myDataRowsBuildingPhotos["BUILDINGID"] != DBNull.Value)
                                    {
                                        lBuildingID = Convert.ToInt64(myDataRowsBuildingPhotos["BUILDINGID"]);
                                    }

                                    if (myDataRowsBuildingPhotos["PHOTOID"] != DBNull.Value)
                                    {
                                        lPhotoID =  Convert.ToInt64(myDataRowsBuildingPhotos["PHOTOID"]);
                                    }

                                    if (myDataRowsBuildingPhotos["DOCUMENTID"] != DBNull.Value)
                                    {
                                        DocumentID = Convert.ToInt64(myDataRowsBuildingPhotos["DOCUMENTID"]);
                                    }

                                    if (myDataRowsBuildingPhotos["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsBuildingPhotos["DATECREATED"]);
                                    }

                                    if (myDataRowsBuildingPhotos["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsBuildingPhotos["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsBuildingPhotos["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsBuildingPhotos["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsBuildingPhotos["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsBuildingPhotos["USERID"]);

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
                errMessage = ex.Message;
                return false;
            }

            finally
            {
                datRetData = null;
                objLogin = null;

            }
        }

        public bool ReturnNextBuildingPhoto()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getnextbuildingphoto(" + lBuildingID + "," + lPhotoID + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesBuildingPhotos in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesBuildingPhotos.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsBuildingPhotos in myDataTablesBuildingPhotos.Rows)
                                {
                                    if (myDataRowsBuildingPhotos["BUILDINGID"] != DBNull.Value)
                                    {
                                        lBuildingID = Convert.ToInt64(myDataRowsBuildingPhotos["BUILDINGID"]);
                                    }

                                    if (myDataRowsBuildingPhotos["PHOTOID"] != DBNull.Value)
                                    {
                                        lPhotoID =  Convert.ToInt64(myDataRowsBuildingPhotos["PHOTOID"]);
                                    }

                                    if (myDataRowsBuildingPhotos["DOCUMENTID"] != DBNull.Value)
                                    {
                                        DocumentID = Convert.ToInt64(myDataRowsBuildingPhotos["DOCUMENTID"]);
                                    }

                                    if (myDataRowsBuildingPhotos["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsBuildingPhotos["DATECREATED"]);
                                    }

                                    if (myDataRowsBuildingPhotos["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsBuildingPhotos["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsBuildingPhotos["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsBuildingPhotos["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsBuildingPhotos["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsBuildingPhotos["USERID"]);

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

        public bool ReturnPreviousBuildingPhoto()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getprevbuildingphoto(" + lBuildingID + "," + lPhotoID + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesBuildingPhotos in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesBuildingPhotos.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsBuildingPhotos in myDataTablesBuildingPhotos.Rows)
                                {
                                    if (myDataRowsBuildingPhotos["BUILDINGID"] != DBNull.Value)
                                    {
                                        lBuildingID = Convert.ToInt64(myDataRowsBuildingPhotos["BUILDINGID"]);
                                    }

                                    if (myDataRowsBuildingPhotos["PHOTOID"] != DBNull.Value)
                                    {
                                        lPhotoID =  Convert.ToInt64(myDataRowsBuildingPhotos["PHOTOID"]);
                                    }

                                    if (myDataRowsBuildingPhotos["DOCUMENTID"] != DBNull.Value)
                                    {
                                        DocumentID = Convert.ToInt64(myDataRowsBuildingPhotos["DOCUMENTID"]);
                                    }

                                    if (myDataRowsBuildingPhotos["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsBuildingPhotos["DATECREATED"]);
                                    }

                                    if (myDataRowsBuildingPhotos["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsBuildingPhotos["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsBuildingPhotos["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsBuildingPhotos["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsBuildingPhotos["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsBuildingPhotos["USERID"]);

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

        public bool ReturnLastBuildingPhoto()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getlastbuildingphoto(" + lBuildingID + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesBuildingPhotos in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesBuildingPhotos.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsBuildingPhotos in myDataTablesBuildingPhotos.Rows)
                                {
                                    if (myDataRowsBuildingPhotos["BUILDINGID"] != DBNull.Value)
                                    {
                                        lBuildingID = Convert.ToInt64(myDataRowsBuildingPhotos["BUILDINGID"]);
                                    }

                                    if (myDataRowsBuildingPhotos["PHOTOID"] != DBNull.Value)
                                    {
                                        lPhotoID =  Convert.ToInt64(myDataRowsBuildingPhotos["PHOTOID"]);
                                    }

                                    if (myDataRowsBuildingPhotos["DOCUMENTID"] != DBNull.Value)
                                    {
                                        DocumentID = Convert.ToInt64(myDataRowsBuildingPhotos["DOCUMENTID"]);
                                    }

                                    if (myDataRowsBuildingPhotos["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsBuildingPhotos["DATECREATED"]);
                                    }

                                    if (myDataRowsBuildingPhotos["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsBuildingPhotos["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsBuildingPhotos["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsBuildingPhotos["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsBuildingPhotos["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsBuildingPhotos["USERID"]);

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

        public bool SaveBuildingPhoto()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {

                strQuery = "SELECT trip_func_insertupdatecapturebuildingphoto(" + 
                    lBuildingID + "," + lPhotoID + "," + DocumentID + ")";

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
                                datBuildingPhotos = objLogin.PGDataSet;
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
