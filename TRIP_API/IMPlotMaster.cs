using System;
using System.Collections.Generic;
using System.Text;
using NpgsqlTypes;
using System.Data;

namespace TRIP_API
{
    public class IMPlotMaster
    {
        private long lPlotID = 0;
        private long lMapID = 0;
        private long lRegistryFileSystemID = 0;
        private string strLandReferenceNumber = "";
        private string strTitleDeedFileNumber = "";
        private string strRegistryMapSheetNo = "";
        private string strParcelNo = "";
        private double dbPlotArea = 0;
        private long lAddressDetailsID = 0;

        public NpgsqlPolygon plgPlotPolygon;
        private NpgsqlPoint pntPlotCentroid;
        private DateTime dtDateCreated;
        private DateTime dtDateRegistered;
        private DateTime dtDateDeRegistered;
        private DataSet datPlotMaster;
        private string errMessage;


        #region "Properties"


        public long PlotID
        {
            get { return lPlotID; }
            set { lPlotID = value; }
        }

        public long MapID
        {
            get { return lMapID; }
            set { lMapID = value; }
        }

        public long RegistryFileSystemID
        {
            get { return lRegistryFileSystemID; }
            set { lRegistryFileSystemID = value; }
        }

        public string LandReferenceNumber
        {
            get { return strLandReferenceNumber; }
            set { strLandReferenceNumber = value; }
        }

        public string TitleDeedFileNumber
        {
            get { return strTitleDeedFileNumber; }
            set { strTitleDeedFileNumber = value; }
        }

        public string RegistryMapSheetNo
        {
            get { return strRegistryMapSheetNo; }
            set { strRegistryMapSheetNo = value; }
        }
        
        public string ParcelNo
        {
            get { return strParcelNo; }
            set { strParcelNo = value; }
        }        

        public double PlotArea
        {
            get { return dbPlotArea; }
            set { dbPlotArea = value; }
        }

        public long AddressDetailsID
        {
            get { return lAddressDetailsID; }
            set { lAddressDetailsID = value; }
        }

        public NpgsqlPolygon PlotPolygon
        {
            get { return plgPlotPolygon; }
            set { plgPlotPolygon = value; }
        }

        public NpgsqlPoint PlotCentroid
        {
            get { return pntPlotCentroid; }
            set { pntPlotCentroid = value; }
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

        public DataSet PlotMasterDataSet
        {
            get { return datPlotMaster; }
            set { datPlotMaster = value; }
        }


        #endregion


        #region "DatabaseFunctions"


        //0 is provided as the Plot id returning all Plots
        public bool ReturnAllPlotMasterByPlotID(long lLimit, long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getplotmasterbyplotid(0" + lLimit +
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
                        foreach (DataTable myDataTablesPlot in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesPlot.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;
                            }
                            else
                            {
                                datPlotMaster = objLogin.PGDataSet;
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

        public bool ReturnPlotMasterByPlotID(long lLimit, long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getplotmasterplotid(" + lPlotID + "," + lLimit +
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
                        foreach (DataTable myDataTablesPlot in objLogin.PGDataSet.Tables)
                        {
                            //Check if there is any data. If not exit
                            if (myDataTablesPlot.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;
                            }
                            else
                            {
                                foreach (DataRow myDataRowsPlot in myDataTablesPlot.Rows)
                                {
                                    if (myDataRowsPlot["PLOTID"] != DBNull.Value)
                                    {
                                        lPlotID = Convert.ToInt64(myDataRowsPlot["PLOTID"]);
                                    }

                                    if (myDataRowsPlot["MAPID"] != DBNull.Value)
                                    {
                                        lMapID = Convert.ToInt64(myDataRowsPlot["MAPID"]);
                                    }

                                    if (myDataRowsPlot["PARCELNO"] != DBNull.Value)
                                    {
                                        strParcelNo = myDataRowsPlot["PARCELNO"].ToString();
                                    }

                                    if (myDataRowsPlot["REGISTRYMAPSHEETNO"] != DBNull.Value)
                                    {
                                        strRegistryMapSheetNo = myDataRowsPlot["REGISTRYMAPSHEETNO"].ToString();
                                    }

                                    if (myDataRowsPlot["LANDREFERENCENUMBER"] != DBNull.Value)
                                    {
                                        strLandReferenceNumber = myDataRowsPlot["LANDREFERENCENUMBER"].ToString();
                                    }

                                    if (myDataRowsPlot["TITLEDEEDNUMBER"] != DBNull.Value)
                                    {
                                        strTitleDeedFileNumber= myDataRowsPlot["TITLEDEEDNUMBER"].ToString();
                                    }

                                    if (myDataRowsPlot["PLOTPOLYGON"] != DBNull.Value)
                                    {
                                        plgPlotPolygon = (NpgsqlPolygon) myDataRowsPlot["PLOTPOLYGON"];
                                    }

                                    if (myDataRowsPlot["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsPlot["DATECREATED"]);
                                    }

                                    if (myDataRowsPlot["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsPlot["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsPlot["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsPlot["DATEDEREGISTERED"]);
                                    }

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

        public bool ReturnAllPlotMasterByParcelNo(long lExactValue, long lLimit, long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getplotmasterbyparcelno('" + strParcelNo + "',"
                    + lExactValue + "," + lLimit + "," + lOffset + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {
                        foreach (DataTable myDataTablesPlot in objLogin.PGDataSet.Tables)
                        {
                            //Check if there is any data. If not exit
                            if (myDataTablesPlot.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;
                            }
                            else
                            {
                                foreach (DataRow myDataRowsPlot in myDataTablesPlot.Rows)
                                {
                                    //Check if there is any data. If not exit
                                    if (myDataTablesPlot.Rows.Count == 0)
                                    {
                                        //Return a value indicating that the search was not successful
                                        return false;
                                    }
                                    else
                                    {
                                        datPlotMaster = objLogin.PGDataSet;
                                    }
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

        public bool ReturnPlotMasterByParcelNo(long lLimit, long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getplotmasterbyparcelno('" + strParcelNo + "'," + lLimit +
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
                        foreach (DataTable myDataTablesPlot in objLogin.PGDataSet.Tables)
                        {
                            //Check if there is any data. If not exit
                            if (myDataTablesPlot.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;
                            }
                            else
                            {
                                foreach (DataRow myDataRowsPlot in myDataTablesPlot.Rows)
                                {
                                    if (myDataRowsPlot["PLOTID"] != DBNull.Value)
                                    {
                                        lPlotID = Convert.ToInt64(myDataRowsPlot["PLOTID"]);
                                    }

                                    if (myDataRowsPlot["MAPID"] != DBNull.Value)
                                    {
                                        lMapID = Convert.ToInt64(myDataRowsPlot["MAPID"]);
                                    }

                                    if (myDataRowsPlot["PARCELNO"] != DBNull.Value)
                                    {
                                        strParcelNo = myDataRowsPlot["PARCELNO"].ToString();
                                    }

                                    if (myDataRowsPlot["REGISTRYMAPSHEETNO"] != DBNull.Value)
                                    {
                                        strRegistryMapSheetNo = myDataRowsPlot["REGISTRYMAPSHEETNO"].ToString();
                                    }

                                    if (myDataRowsPlot["LANDREFERENCENUMBER"] != DBNull.Value)
                                    {
                                        strLandReferenceNumber = myDataRowsPlot["LANDREFERENCENUMBER"].ToString();
                                    }

                                    if (myDataRowsPlot["TITLEDEEDNUMBER"] != DBNull.Value)
                                    {
                                        strTitleDeedFileNumber = myDataRowsPlot["TITLEDEEDNUMBER"].ToString();
                                    }

                                    if (myDataRowsPlot["PLOTPOLYGON"] != DBNull.Value)
                                    {
                                        plgPlotPolygon = (NpgsqlPolygon)myDataRowsPlot["PLOTPOLYGON"];
                                    }

                                    if (myDataRowsPlot["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsPlot["DATECREATED"]);
                                    }

                                    if (myDataRowsPlot["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsPlot["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsPlot["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsPlot["DATEDEREGISTERED"]);
                                    }

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

        public bool ReturnPlotMasterByRegistryMapSheetNo(long lLimit, long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getplotmasterbyparcelno('" + strRegistryMapSheetNo + "'," + lLimit +
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
                        foreach (DataTable myDataTablesPlot in objLogin.PGDataSet.Tables)
                        {
                            //Check if there is any data. If not exit
                            if (myDataTablesPlot.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;
                            }
                            else
                            {
                                foreach (DataRow myDataRowsPlot in myDataTablesPlot.Rows)
                                {
                                    if (myDataRowsPlot["PLOTID"] != DBNull.Value)
                                    {
                                        lPlotID = Convert.ToInt64(myDataRowsPlot["PLOTID"]);
                                    }

                                    if (myDataRowsPlot["MAPID"] != DBNull.Value)
                                    {
                                        lMapID = Convert.ToInt64(myDataRowsPlot["MAPID"]);
                                    }

                                    if (myDataRowsPlot["PARCELNO"] != DBNull.Value)
                                    {
                                        strParcelNo = myDataRowsPlot["PARCELNO"].ToString();
                                    }

                                    if (myDataRowsPlot["REGISTRYMAPSHEETNO"] != DBNull.Value)
                                    {
                                        strRegistryMapSheetNo = myDataRowsPlot["REGISTRYMAPSHEETNO"].ToString();
                                    }

                                    if (myDataRowsPlot["LANDREFERENCENUMBER"] != DBNull.Value)
                                    {
                                        strLandReferenceNumber = myDataRowsPlot["LANDREFERENCENUMBER"].ToString();
                                    }

                                    if (myDataRowsPlot["TITLEDEEDNUMBER"] != DBNull.Value)
                                    {
                                        strTitleDeedFileNumber = myDataRowsPlot["TITLEDEEDNUMBER"].ToString();
                                    }

                                    if (myDataRowsPlot["PLOTPOLYGON"] != DBNull.Value)
                                    {
                                        plgPlotPolygon = (NpgsqlPolygon)myDataRowsPlot["PLOTPOLYGON"];
                                    }

                                    if (myDataRowsPlot["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsPlot["DATECREATED"]);
                                    }

                                    if (myDataRowsPlot["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsPlot["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsPlot["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsPlot["DATEDEREGISTERED"]);
                                    }

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

        public bool ReturnPlotMasterByMapID(long lLimit, long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getplotmasterbymapid(" + lMapID + "," + lLimit + "," + lOffset + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesPlot in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesPlot.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsPlot in myDataTablesPlot.Rows)
                                {
                                    if (myDataRowsPlot["PLOTID"] != DBNull.Value)
                                    {
                                        lPlotID = Convert.ToInt64(myDataRowsPlot["PLOTID"]);
                                    }

                                    if (myDataRowsPlot["MAPID"] != DBNull.Value)
                                    {
                                        lMapID = Convert.ToInt64(myDataRowsPlot["MAPID"]);
                                    }

                                    if (myDataRowsPlot["PARCELNO"] != DBNull.Value)
                                    {
                                        strParcelNo = myDataRowsPlot["PARCELNO"].ToString();
                                    }

                                    if (myDataRowsPlot["REGISTRYMAPSHEETNO"] != DBNull.Value)
                                    {
                                        strRegistryMapSheetNo = myDataRowsPlot["REGISTRYMAPSHEETNO"].ToString();
                                    }

                                    if (myDataRowsPlot["LANDREFERENCENUMBER"] != DBNull.Value)
                                    {
                                        strLandReferenceNumber = myDataRowsPlot["LANDREFERENCENUMBER"].ToString();
                                    }

                                    if (myDataRowsPlot["TITLEDEEDNUMBER"] != DBNull.Value)
                                    {
                                        strTitleDeedFileNumber = myDataRowsPlot["TITLEDEEDNUMBER"].ToString();
                                    }

                                    if (myDataRowsPlot["PLOTPOLYGON"] != DBNull.Value)
                                    {
                                        plgPlotPolygon = (NpgsqlPolygon)myDataRowsPlot["PLOTPOLYGON"];
                                    }

                                    if (myDataRowsPlot["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsPlot["DATECREATED"]);
                                    }

                                    if (myDataRowsPlot["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsPlot["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsPlot["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsPlot["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsPlot["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsPlot["USERID"]);

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

        public bool ReturnPlotIDParcelNoByMapID(long lLimit, long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getplotidparcelnobymapid(" + lMapID + "," + lLimit + "," + lOffset + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesPlot in objLogin.PGDataSet.Tables)
                        {
                            //Check if there is any data. If not exit
                            if (myDataTablesPlot.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsPlot in myDataTablesPlot.Rows)
                                {
                                    if (myDataRowsPlot["PLOTID"] != DBNull.Value)
                                    {
                                        lPlotID = Convert.ToInt64(myDataRowsPlot["PLOTID"]);
                                    }

                                    if (myDataRowsPlot["MAPID"] != DBNull.Value)
                                    {
                                        lMapID = Convert.ToInt64(myDataRowsPlot["MAPID"]);
                                    }

                                    if (myDataRowsPlot["PARCELNO"] != DBNull.Value)
                                    {
                                        strParcelNo = myDataRowsPlot["PARCELNO"].ToString();
                                    }
                                    
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

        public bool ReturnAllPlotIDAndParcelNoByPlotID(long lLimit, long lOffset)
        {

            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getplotidparcelnoplotid(0," + lLimit +
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

                        foreach (DataTable myDataTablesPlot in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesPlot.Rows.Count == 0)
                            {

                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                datPlotMaster = objLogin.PGDataSet;

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

        public bool ReturnPlotIDAndUsageNameByPlotID(long lLimit, long lOffset)
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getplotnamebyplotid(" + lPlotID + "," + lLimit +
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

                        foreach (DataTable myDataTablesPlot in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesPlot.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;
                            }
                            else
                            {
                                foreach (DataRow myDataRowsPlot in myDataTablesPlot.Rows)
                                {
                                    //Check if there is any data. If not exit
                                    if (myDataTablesPlot.Rows.Count == 0)
                                    {
                                        //Return a value indicating that the search was not successful
                                        return false;
                                    }
                                    else
                                    {
                                        datPlotMaster = objLogin.PGDataSet;
                                    }

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
                errMessage = ex.Message + " :Source = " + ex.Source;
                return false;
            }

            finally
            {

                datRetData = null;
                objLogin = null;

            }
        }

        public bool CheckIfMapIDExistsInDatabase()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                if (lMapID > 0)
                {
                    strQuery = "SELECT * FROM trip_func_checkifplotmapidexists(" + lMapID + ")";

                    bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                    if (datRetData == null)
                    {
                        return false;
                    }
                    else
                    {
                        if (bQuerySuccess == true)
                        {

                            foreach (DataTable myDataTablesPlot in objLogin.PGDataSet.Tables)
                            {
                                //Check if there is any data. If not exit
                                if (myDataTablesPlot.Rows.Count == 0)
                                {
                                    //Return a value indicating that the search was not successful
                                    return false;
                                }
                                else
                                {

                                    foreach (DataRow myDataRowsPlot in myDataTablesPlot.Rows)
                                    {
                                        if (myDataRowsPlot[0] != DBNull.Value)
                                        {
                                            lMapID = Convert.ToInt64(myDataRowsPlot[0]);
                                            return true;
                                        }
                                    }

                                }
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }

                return false;
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

        public bool ReturnFirstPlotMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getfirstplotmaster()";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesPlot in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesPlot.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsPlot in myDataTablesPlot.Rows)
                                {
                                    if (myDataRowsPlot["PLOTID"] != DBNull.Value)
                                    {
                                        lPlotID = Convert.ToInt64(myDataRowsPlot["PLOTID"]);
                                    }

                                    if (myDataRowsPlot["MAPID"] != DBNull.Value)
                                    {
                                        lMapID = Convert.ToInt64(myDataRowsPlot["MAPID"]);
                                    }

                                    if (myDataRowsPlot["PARCELNO"] != DBNull.Value)
                                    {
                                        strParcelNo = myDataRowsPlot["PARCELNO"].ToString();
                                    }

                                    if (myDataRowsPlot["REGISTRYMAPSHEETNO"] != DBNull.Value)
                                    {
                                        strRegistryMapSheetNo = myDataRowsPlot["REGISTRYMAPSHEETNO"].ToString();
                                    }

                                    if (myDataRowsPlot["LANDREFERENCENUMBER"] != DBNull.Value)
                                    {
                                        strLandReferenceNumber = myDataRowsPlot["LANDREFERENCENUMBER"].ToString();
                                    }

                                    if (myDataRowsPlot["TITLEDEEDNUMBER"] != DBNull.Value)
                                    {
                                        strTitleDeedFileNumber = myDataRowsPlot["TITLEDEEDNUMBER"].ToString();
                                    }

                                    if (myDataRowsPlot["PLOTPOLYGON"] != DBNull.Value)
                                    {
                                        plgPlotPolygon = (NpgsqlPolygon)myDataRowsPlot["PLOTPOLYGON"];
                                    }

                                    if (myDataRowsPlot["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsPlot["DATECREATED"]);
                                    }

                                    if (myDataRowsPlot["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsPlot["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsPlot["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsPlot["DATEDEREGISTERED"]);
                                    }
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

        public bool ReturnNextPlotMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getnextplotmaster(" + lPlotID + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesPlot in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesPlot.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsPlot in myDataTablesPlot.Rows)
                                {
                                    if (myDataRowsPlot["PLOTID"] != DBNull.Value)
                                    {
                                        lPlotID = Convert.ToInt64(myDataRowsPlot["PLOTID"]);
                                    }

                                    if (myDataRowsPlot["MAPID"] != DBNull.Value)
                                    {
                                        lMapID = Convert.ToInt64(myDataRowsPlot["MAPID"]);
                                    }

                                    if (myDataRowsPlot["PARCELNO"] != DBNull.Value)
                                    {
                                        strParcelNo = myDataRowsPlot["PARCELNO"].ToString();
                                    }

                                    if (myDataRowsPlot["REGISTRYMAPSHEETNO"] != DBNull.Value)
                                    {
                                        strRegistryMapSheetNo = myDataRowsPlot["REGISTRYMAPSHEETNO"].ToString();
                                    }

                                    if (myDataRowsPlot["LANDREFERENCENUMBER"] != DBNull.Value)
                                    {
                                        strLandReferenceNumber = myDataRowsPlot["LANDREFERENCENUMBER"].ToString();
                                    }

                                    if (myDataRowsPlot["TITLEDEEDNUMBER"] != DBNull.Value)
                                    {
                                        strTitleDeedFileNumber = myDataRowsPlot["TITLEDEEDNUMBER"].ToString();
                                    }

                                    if (myDataRowsPlot["PLOTPOLYGON"] != DBNull.Value)
                                    {
                                        plgPlotPolygon = (NpgsqlPolygon)myDataRowsPlot["PLOTPOLYGON"];
                                    }

                                    if (myDataRowsPlot["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsPlot["DATECREATED"]);
                                    }

                                    if (myDataRowsPlot["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsPlot["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsPlot["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsPlot["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsPlot["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsPlot["USERID"]);

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

        public bool ReturnPreviousPlotMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getprevplotmaster(" + lPlotID + ")";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesPlot in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesPlot.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsPlot in myDataTablesPlot.Rows)
                                {
                                    if (myDataRowsPlot["PLOTID"] != DBNull.Value)
                                    {
                                        lPlotID = Convert.ToInt64(myDataRowsPlot["PLOTID"]);
                                    }

                                    if (myDataRowsPlot["MAPID"] != DBNull.Value)
                                    {
                                        lMapID = Convert.ToInt64(myDataRowsPlot["MAPID"]);
                                    }

                                    if (myDataRowsPlot["PARCELNO"] != DBNull.Value)
                                    {
                                        strParcelNo = myDataRowsPlot["PARCELNO"].ToString();
                                    }

                                    if (myDataRowsPlot["REGISTRYMAPSHEETNO"] != DBNull.Value)
                                    {
                                        strRegistryMapSheetNo = myDataRowsPlot["REGISTRYMAPSHEETNO"].ToString();
                                    }

                                    if (myDataRowsPlot["LANDREFERENCENUMBER"] != DBNull.Value)
                                    {
                                        strLandReferenceNumber = myDataRowsPlot["LANDREFERENCENUMBER"].ToString();
                                    }

                                    if (myDataRowsPlot["TITLEDEEDNUMBER"] != DBNull.Value)
                                    {
                                        strTitleDeedFileNumber = myDataRowsPlot["TITLEDEEDNUMBER"].ToString();
                                    }

                                    if (myDataRowsPlot["PLOTPOLYGON"] != DBNull.Value)
                                    {
                                        plgPlotPolygon = (NpgsqlPolygon)myDataRowsPlot["PLOTPOLYGON"];
                                    }

                                    if (myDataRowsPlot["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsPlot["DATECREATED"]);
                                    }

                                    if (myDataRowsPlot["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsPlot["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsPlot["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsPlot["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsPlot["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsPlot["USERID"]);

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

        public bool ReturnLastPlotMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT * FROM trip_func_getlastplotmaster()";

                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {

                        foreach (DataTable myDataTablesPlot in objLogin.PGDataSet.Tables)
                        {

                            //Check if there is any data. If not exit
                            if (myDataTablesPlot.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;

                            }
                            else
                            {

                                foreach (DataRow myDataRowsPlot in myDataTablesPlot.Rows)
                                {
                                    if (myDataRowsPlot["PLOTID"] != DBNull.Value)
                                    {
                                        lPlotID = Convert.ToInt64(myDataRowsPlot["PLOTID"]);
                                    }

                                    if (myDataRowsPlot["MAPID"] != DBNull.Value)
                                    {
                                        lMapID = Convert.ToInt64(myDataRowsPlot["MAPID"]);
                                    }

                                    if (myDataRowsPlot["PARCELNO"] != DBNull.Value)
                                    {
                                        strParcelNo = myDataRowsPlot["PARCELNO"].ToString();
                                    }

                                    if (myDataRowsPlot["REGISTRYMAPSHEETNO"] != DBNull.Value)
                                    {
                                        strRegistryMapSheetNo = myDataRowsPlot["REGISTRYMAPSHEETNO"].ToString();
                                    }

                                    if (myDataRowsPlot["LANDREFERENCENUMBER"] != DBNull.Value)
                                    {
                                        strLandReferenceNumber = myDataRowsPlot["LANDREFERENCENUMBER"].ToString();
                                    }

                                    if (myDataRowsPlot["TITLEDEEDNUMBER"] != DBNull.Value)
                                    {
                                        strTitleDeedFileNumber = myDataRowsPlot["TITLEDEEDNUMBER"].ToString();
                                    }

                                    if (myDataRowsPlot["PLOTPOLYGON"] != DBNull.Value)
                                    {
                                        plgPlotPolygon = (NpgsqlPolygon)myDataRowsPlot["PLOTPOLYGON"];
                                    }

                                    if (myDataRowsPlot["DATECREATED"] != DBNull.Value)
                                    {
                                        dtDateCreated = Convert.ToDateTime(myDataRowsPlot["DATECREATED"]);
                                    }

                                    if (myDataRowsPlot["DATEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateRegistered = Convert.ToDateTime(myDataRowsPlot["DATEREGISTERED"]);
                                    }

                                    if (myDataRowsPlot["DATEDEREGISTERED"] != DBNull.Value)
                                    {
                                        dtDateDeRegistered = Convert.ToDateTime(myDataRowsPlot["DATEDEREGISTERED"]);
                                    }

                                    //if (myDataRowsPlot["USERID"] != DBNull.Value)
                                    //{

                                    //UserID = Convert.ToInt64(myDataRowsPlot["USERID"]);

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

        public bool SavePlotMaster()
        {
            DataSet datRetData = new DataSet();
            bool bQuerySuccess = false;
            IMLogin objLogin = new IMLogin();
            string strQuery = null;

            try
            {
                strQuery = "SELECT  trip_func_insertupdatecaptureplotmaster(" +
                    lPlotID + ",'" +
                    strParcelNo + "','" +
                    strTitleDeedFileNumber + "','" +
                    strRegistryMapSheetNo + "','" +
                    strLandReferenceNumber + "'," +
                    lMapID + "," +
                    lRegistryFileSystemID + ",(" +
                    plgPlotPolygon + ")," +
                    lAddressDetailsID + "," +
                    dbPlotArea + ")";



                bQuerySuccess = objLogin.ExecutePGPostgresQuery(strQuery);

                if (datRetData == null)
                {
                    return false;
                }
                else
                {
                    if (bQuerySuccess == true)
                    {
                        foreach (DataTable myDataTablesPlotMaster in objLogin.PGDataSet.Tables)
                        {
                            //Check if there is any data. If not exit
                            if (myDataTablesPlotMaster.Rows.Count == 0)
                            {
                                //Return a value indicating that the search was not successful
                                return false;
                            }
                            else
                            {
                                datPlotMaster = objLogin.PGDataSet;
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
                errMessage = ex.Message + " :Source" + ex.Source;
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
