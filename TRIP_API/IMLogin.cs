using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using Npgsql;
using NpgsqlTypes;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Mono.Security.Protocol.Tls;
using Mono.Security.Authenticode;
using System.Threading;
using System.Text.RegularExpressions;
using System.IO;

namespace TRIP_API
{
    public class IMLogin
    {
        //Variables
        private string strReturnError;
        private string strDBUserName;
        private string strDBPassword;
        private string strDBDatabase;
        private string strDBDBPath;
        private DataSet datPGDataset;
        private bool bDBLoggedIn;
        private string errMessage;
        private string _CurrentPassword = "";
        MemoryStream _MSErrorImage = new MemoryStream();
        

        //Properties
        #region "Properties"

        public string ReturnError 
        {
            get 
            {       
                return strReturnError;    
            }
    
            set    
            {        
                strReturnError = value;     
            }

        }

        public string CurrentPassword
        {
            get
            {
                return _CurrentPassword;
            }

            set
            {
                _CurrentPassword = value;
            }

        }       

        public string DBUserName 
        {
                
                get
                {
                    return strDBUserName;
                }
                

                set
                {
                    strDBUserName = value;
                }
            
        }
    
        public string DBPassword 
        {

        get
        {
            return strDBPassword;
        }

        set{
            strDBPassword = value;
        }

    }
    
        public string DBDatabase 
    {

        get{
            return strDBDatabase;
        }

        set{
            strDBDatabase = value;
        }

    }
    
        public string DBDBPath 

    {
        get{
            return strDBDBPath;
        }

        set{
            strDBDBPath = value;
        }

    }
            
        public DataSet PGDataSet
    {

        get{
            return datPGDataset;
        }

        set{
            datPGDataset = value;
        }

    }


        #endregion


        //Database Methods
        #region "DatabaseMethods"

             
        public Boolean ExecutePGPostgresQuery(string strQuery) {
            
            NpgsqlConnection conn = null;
            DataSet myDS = new DataSet();
            NpgsqlDataAdapter da = null;

            //string strConnString = "Server=192.168.1.3;Port=5432;User Id=postgres;Password=jocker;Database=tripsys;";
            string strConnString = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=jocker;Database=tripsys;";
            //string strConnString = "Server=91.123.194.190;Port=5432;User Id=postgres;Password=jocker;Database=tripsys;";
            string strTablesQuery = "";

            try
            {

                strTablesQuery = strQuery;
                
                conn = new NpgsqlConnection(strConnString);
                conn.Open();


                da = new NpgsqlDataAdapter(strTablesQuery, conn);

                if (da != null)
                {
                    da.Fill(myDS);
                }

                conn.Close();

                datPGDataset = myDS;

                return true;

            }

        
            catch (Exception ex)
            {
                errMessage = ex.Message + " :Source = " + ex.Source;
                return false;        
            }

        
            finally 
            {
                conn.Close();
                myDS = null;
                da = null;
            }
               
    }

        //Business Logic Methods

        //Checks if a user exists or not
        public bool AuthenticateUser(string strUserName, string strPassword)
        
   
        {
            string strQuery = null;
            bool bQuerySuccess = false;

            try
            {
                //strQuery = "SELECT * FROM "USERNAME"" ~* 'jack' OR ""EMAILADDRESS"" ~* 'jack'"

                strQuery = "SELECT trip_func_login('" + strUserName.Trim() + "','" + strPassword + "')";

                bQuerySuccess = ExecutePGPostgresQuery(strQuery);

                //If the dataset is not empty
                if (datPGDataset != null)
                {
                    //If the query execution returned a true value
                    if (bQuerySuccess == true)
                    {
                        foreach (DataTable myDataTables in datPGDataset.Tables)
                        {
                            //Check if there is any data. If not exit
                            if (myDataTables.Rows.Count != 0)
                            {
                                foreach (DataRow myDataRows in myDataTables.Rows)
                                {
                                    bDBLoggedIn = Convert.ToBoolean(myDataRows[0].ToString());                                    
                                }
                            }

                            else //Check if there is any data. If not exit
                            {
                                //Authentication was not successful
                                return false;
                            }

                        }
                        return bDBLoggedIn;

                    }
                    else //If the query execution returned a true value
                    {
                        return false;
                    }
                }

                else //If the dataset is not empty
                {
                    return false;
                }            
            }

            catch (Exception ex)
            {
                strReturnError = ex.Message;
                return false;
            }

            finally
            {
                datPGDataset = null;
            }
        }

        //SSL Connection
        public bool ExecutePGPostgresQuerySSL(string strQuery)
        
        {            
            string conStr =            
            "Server=127.0.0.1;" +
            "Port=5432;" +
            "User Id=postgres;" +
            "Password=jocker;" +
            "Protocol=3;" +
            "Database=tripsys;" +
            "SSL=True;" +
            "Sslmode=Require;";

            NpgsqlConnection conn = new NpgsqlConnection(conStr);

            conn.ProvideClientCertificatesCallback += new ProvideClientCertificatesCallback (MyProvideClientCertificates);

            conn.CertificateSelectionCallback +=  new CertificateSelectionCallback (MyCertificateSelectionCallback);

            conn.CertificateValidationCallback += new CertificateValidationCallback (MyCertificateValidationCallback);

            conn.PrivateKeySelectionCallback += new PrivateKeySelectionCallback (MyPrivateKeySelectionCallback);

            try
            {
                conn.Open();
                //System.Console.WriteLine("Verbindung aufgebaut");
                return true;
            }

            catch (Exception e)
            {
                System.Console.WriteLine(e);
                return false;
            }

            finally
            {
                conn.Close();
                System.Console.ReadLine();
            }

        }

        #region "GeuzaFili"

        public bool GeuzaFili(string ingiaFili, string imebadilishwaFili)
        {
            bool bSuccess = false;

            if (_CurrentPassword == "") return bSuccess;

            try
            {
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(@_CurrentPassword);

                string filiImegeuzwa = imebadilishwaFili;
                FileStream fsCrypt = new FileStream(filiImegeuzwa, FileMode.Create);

                RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateEncryptor(key, key),
                    CryptoStreamMode.Write);

                FileStream fsIn = new FileStream(ingiaFili, FileMode.Open);

                int data;
                while ((data = fsIn.ReadByte()) != -1)
                    cs.WriteByte((byte)data);


                fsIn.Close();
                cs.Close();
                fsCrypt.Close();

                bSuccess = true;
            }

            catch (Exception ex)
            {
                errMessage = ex.Message;
            }

            return bSuccess;

        }

        public MemoryStream RudishaFiliKwaMafikira(string inputFile)
        {
            if (_CurrentPassword == "") return _MSErrorImage;

            FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);
            try
            {
                MemoryStream msOut = new MemoryStream();
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(@_CurrentPassword);

                RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt, RMCrypto.CreateDecryptor(key, key), CryptoStreamMode.Read);

                int data;
                while ((data = cs.ReadByte()) != -1)
                {
                    msOut.WriteByte((byte)data);
                }
                cs.Close();
                fsCrypt.Close();

                msOut.Position = 0;

                return msOut;
            }
            catch
            {
                fsCrypt.Close(); // release file lock
                return _MSErrorImage;
            }
        }

        public bool RudishaFili(string inputFile, string outputFile)
        {
            bool bSuccess = false;
            if (_CurrentPassword == "") return bSuccess;

            FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);
            try
            {
                FileStream fsOut = new FileStream(outputFile, FileMode.Create);
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(@_CurrentPassword);

                RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt, RMCrypto.CreateDecryptor(key, key), CryptoStreamMode.Read);

                int data;
                while ((data = cs.ReadByte()) != -1)
                {
                    fsOut.WriteByte((byte)data);
                }
                cs.Close();
                fsCrypt.Close();
                fsOut.Close();
                bSuccess = true;
            }
            catch
            {
                fsCrypt.Close(); // release file lock
            }

            return bSuccess;
        }

        static void MyProvideClientCertificates(X509CertificateCollection clienteCertis)
        {
            X509Certificate cert = new X509Certificate("mycert.crt");
            clienteCertis.Add(cert);
        }
        
        static X509Certificate MyCertificateSelectionCallback(X509CertificateCollection clienteCertis, X509Certificate serverCerti, string hostDestino, X509CertificateCollection serverRequestedCertificates)
        {
            return clienteCertis[0];
        }

        static AsymmetricAlgorithm MyPrivateKeySelectionCallback(X509Certificate certificate, string targetHost)
        {
            PrivateKey key = null;
            try
            {
                //it is very important that the key has the .pvk format in windows!!!
                key = PrivateKey.CreateFromFile("myKey.pvk", "xxx");
            }
            catch (CryptographicException ex)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(ex);
                Console.WriteLine();
                Console.WriteLine();
            }

            if (key == null)
                return null;

            return key.RSA;
        }

        static bool MyCertificateValidationCallback(X509Certificate certificate, int[] certificateErrors)
        {
            /*
            * CertVALID = 0,
            * CertEXPIRED = -2146762495,//0x800B0101
            * CertVALIDITYPERIODNESTING = -2146762494,//0x800B0102
            * CertROLE = -2146762493,//0x800B0103
            * CertPATHLENCONST = -2146762492,//0x800B0104
            * CertCRITICAL = -2146762491,//0x800B0105
            * CertPURPOSE = -2146762490,//0x800B0106
            * CertISSUERCHAINING = -2146762489,//0x800B0107
            * CertMALFORMED = -2146762488,//0x800B0108
            * CertUNTRUSTEDROOT = -2146762487,//0x800B0109
            * CertCHAINING = -2146762486,//0x800B010A
            * CertREVOKED = -2146762485,//0x800B010C
            * CertUNTRUSTEDTESTROOT = -2146762484,//0x800B010D
            * CertREVOCATION_FAILURE = -2146762483,//0x800B010E
            * CertCN_NO_MATCH = -2146762482,//0x800B010F
            * CertWRONG_USAGE = -2146762481,//0x800B0110
            * CertUNTRUSTEDCA = -2146762480,//0x800B0112
            */

            //error: -2146762487, -2146762481
            System.Console.WriteLine(certificateErrors[0]);
            return true;
        }

        #endregion


        

        
        #endregion

    }
}

