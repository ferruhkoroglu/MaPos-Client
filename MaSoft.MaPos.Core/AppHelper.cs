using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Diagnostics;
using System.Reflection;

namespace MaSoft.MaPos.Core
{
    public static class AppHelper
    {
        private static string IniFileName = "Connection.td";
        public static SqlConnection sqlCon = new SqlConnection();
        public static SqlConnection sqlConForVisual = new SqlConnection();
        public static bool LoadedMainForm = false;

        public static bool IsDebug(Assembly assembly)
        {
            object[] attributes = assembly.GetCustomAttributes(typeof(DebuggableAttribute), true);
            if (attributes == null || attributes.Length == 0)
                return true;

            var d = (DebuggableAttribute)attributes[0];
            if (d.IsJITTrackingEnabled) return true;
            return false;
        }

        public static bool ConnectTest()
        {
            using (SqlConnection sqlcon = new SqlConnection())
            {
                sqlcon.ConnectionString = StaticVariables.ConnectionString();

                try
                {
                    try
                    {
                        sqlcon.Open();
                        return true;
                    }
                    finally
                    {
                        sqlcon.Close();
                    }
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool ConnectionOpen()
        {
            if (sqlCon.State == ConnectionState.Open)
                sqlCon.Close();

            sqlCon.ConnectionString = StaticVariables.ConnectionString();
            try
            {
                sqlCon.Open();
                return true;
            }
            catch
            {
                //MessageBox.Show("Bağlantı sağlanırken hata oluştu !");
                return false;
            }
        }

        public static bool ConnectionOpenByParam(SqlConnection sqlconTmp)
        {
            if (sqlconTmp.State == ConnectionState.Open)
                sqlconTmp.Close();

            sqlconTmp.ConnectionString = StaticVariables.ConnectionString();
            try
            {
                sqlconTmp.Open();
                return true;
            }
            catch
            {
                //MessageBox.Show("Bağlantı sağlanırken hata oluştu !");
                return false;
            }
        }

        public static void ConnectionClose()
        {
            try
            {
                sqlCon.Close();
            }
            catch
            {
                // hata oluşur ise handle edilsin...
            }
        }

        public static void ConnectionCloseByParam(SqlConnection sqlconTmp)
        {
            try
            {
                sqlconTmp.Close();
            }
            catch
            {
                // hata oluşur ise handle edilsin...
            }
        }

        public static string GetFileName()
        {
            return AppDomain.CurrentDomain.BaseDirectory + "\\" + IniFileName;
        }

        public static bool ExistIniFile()
        {
            return File.Exists(GetFileName());
        }

        public static bool InternetConnectionExist()
        {
            bool processResult = false;
            try
            {
                processResult = ((new WebClient()).DownloadString("http://checkip.amazonaws.com/").Replace("\n", "").Replace("\r", "") != "");
            }
            catch
            {
                //
            }

            return processResult;
        }

        public static void SaveSettings()
        {
            IniFile IniFile = new IniFile(GetFileName());
            try
            {
                IniFile.Write("EmailAdress", StaticVariables.UserName);
                IniFile.Write("Password", StaticVariables.Password);
            }
            finally
            {
                IniFile = null;
            }
        }

        public static void LoadSettings()
        {
            if (!ExistIniFile())
                return;

            IniFile iniFile = new IniFile(GetFileName());
            try
            {
                StaticVariables.EMailAddress = iniFile.Read("EmailAdress");
                StaticVariables.Password = iniFile.Read("Password");

                // Varsayılan False... 
                try
                {
                    if (iniFile.KeyExists("ClickSubPageActive"))
                        StaticVariables.ClickSubPageActive = Convert.ToBoolean(iniFile.Read("ClickSubPageActive"));
                }
                catch
                {
                    //
                }


                // Varsayılan ""... 
                try
                {
                    if (iniFile.KeyExists("RequestSite"))
                        StaticVariables.RequestSite = Convert.ToString(iniFile.Read("RequestSite"));
                }
                catch
                {
                    //
                }

            }
            finally
            {
                iniFile = null;
            }
        }

        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
                hash.Append(bytes[i].ToString("x2"));

            return hash.ToString();
        }


        public static bool UserAuthentication(string Password)
        {
            bool result = false;
            try
            {
                ConnectionOpen();

                SqlCommand sqlCmd = null;
                try
                {
                    sqlCmd = new SqlCommand(" SELECT * FROM Users WITH (NOLOCK)  " +
                                                                " WHERE Password = @Password", sqlCon);

                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@Password";
                    param.Value = Password;
                    sqlCmd.Parameters.Add(param);

                    SqlDataReader rdSQL = sqlCmd.ExecuteReader();

                    if (rdSQL.Read())
                        result = true;
                }
                finally
                {
                    sqlCmd.Dispose();
                    sqlCmd= null;
                }
            }
            finally
            {
                // İşlem bittikten sonra kapatılmalı bağlantı...
                ConnectionClose();
            }

            return result;
        }

        public static string GetExtIpAddress()
        {
            return (new WebClient()).DownloadString("http://checkip.amazonaws.com/").Replace("\n", "").Replace("\r", "");
        }

        public static bool AddOrUpdateIpAddressToLog(string IpAddress, string EMailAddress)
        {
            bool result = false;
            try
            {
                ConnectionOpen();

                string strSQL = " IF NOT EXISTS (SELECT * FROM IpLog WHERE IpAddress = '" + IpAddress + "' ) " +
                                       " INSERT INTO IpLog (IpAddress, EMailAddress)" +
                                       " VALUES ( '" + IpAddress + "', '" + EMailAddress + "' ) " +
                                " ELSE " +
                                       " UPDATE IpLog " +
                                       " SET ConnDateTime = " + Convert.ToString(DateTime.Now.ToOADate()).Replace(",", ".") + ", " +
                                       "      EMailAddress = '" + EMailAddress + "' " +
                                       " WHERE IpAddress = '" + IpAddress + "'";

                SqlCommand sqlCmd = new SqlCommand(strSQL, sqlCon);
                sqlCmd.CommandType = CommandType.Text;

                sqlCmd.ExecuteNonQuery();
            }
            catch
            {
                //
            }
            finally
            {
                // İşlem bittikten sonra kapatılmalı bağlantı...
                ConnectionClose();
            }

            return result;
        }

        public static bool ExistEmailAddress(string EMailAddress)
        {
            bool result = true;
            try
            {
                ConnectionOpen();

                string strSQL = " SELECT COUNT(*) AS CNTR FROM Users " + " WHERE Email = '" + EMailAddress + "' ";

                SqlCommand sqlCmd = new SqlCommand(strSQL, sqlCon);
                int count = (int)sqlCmd.ExecuteScalar();

                result = (count > 0);
            }
            catch
            {
                //
            }
            finally
            {
                // İşlem bittikten sonra kapatılmalı bağlantı...
                ConnectionClose();
            }

            return result;
        }

        public static string GetNewVersionInfo()
        {
            string result = "";
            try
            {
                ConnectionOpen();

                string strSQL = " SELECT VersionNo FROM LastVersion ";

                SqlCommand sqlCmd = new SqlCommand(strSQL, sqlCon);
                result = (string)sqlCmd.ExecuteScalar();
            }
            catch
            {
                //
            }
            finally
            {
                // İşlem bittikten sonra kapatılmalı bağlantı...
                ConnectionClose();
            }

            return result;
        }

        public static bool AddEmailAddress(string EMailAddress, string password)
        {
            bool result = false;
            try
            {
                ConnectionOpen();

                string strSQL = " INSERT INTO Users (Email, password, PasswordMd5) " +
                                " VALUES ( '" + EMailAddress + "', '" + password + "', '" + MD5Hash(password) + "' ) ";

                SqlCommand sqlCmd = new SqlCommand(strSQL, sqlCon);
                sqlCmd.CommandType = CommandType.Text;

                int count = (int)sqlCmd.ExecuteNonQuery();
                result = (count > 0);
            }
            catch
            {
                //
            }
            finally
            {
                // İşlem bittikten sonra kapatılmalı bağlantı...
                ConnectionClose();
            }

            return result;
        }

        public static bool RemoveSearchTerm(int RowID, int UserRowID)
        {
            bool result = false;
            try
            {
                ConnectionOpen();

                string strSQL = " DELETE FROM SearchTerms " +
                                " WHERE RowID = " + Convert.ToString(RowID) + " AND " +
                                "       UserRowID = " + UserRowID.ToString();

                SqlCommand sqlCmd = new SqlCommand(strSQL, sqlCon);
                sqlCmd.CommandType = CommandType.Text;

                int count = (int)sqlCmd.ExecuteNonQuery();
                result = (count > 0);
            }
            catch
            {
                //
            }
            finally
            {
                // İşlem bittikten sonra kapatılmalı bağlantı...
                ConnectionClose();
            }

            return result;
        }

        public static bool UpdateStatusSearchTerm(int RowID, int UserRowID, int IsActive = 1)
        {
            bool result = false;
            try
            {
                ConnectionOpen();

                string strSQL = " UPDATE SearchTerms " +
                                " SET IsActive = " + Convert.ToString(IsActive) +
                                " WHERE RowID = " + Convert.ToString(RowID) + " AND " +
                                "       UserRowID = " + UserRowID.ToString();

                SqlCommand sqlCmd = new SqlCommand(strSQL, sqlCon);
                sqlCmd.CommandType = CommandType.Text;

                int count = (int)sqlCmd.ExecuteNonQuery();
                result = (count > 0);
            }
            catch
            {
                //
            }
            finally
            {
                // İşlem bittikten sonra kapatılmalı bağlantı...
                ConnectionClose();
            }

            return result;
        }


        public static bool AddSearchTerms(int UserRowID, string HitType, string SearchTerm, string TargetSite, int DailyHitCount, int MinSecond, int MaxSecond, int IsActive, string GoogleSearchUrl, int IsAdminHit, int IsClickLink = 0, string LinkInfo = "", string Backlink = "")
        {
            bool result = false;
            try
            {
                ConnectionOpen();

                string strSQL = " INSERT INTO SearchTerms " +
                                                " ([UserRowID] " +
                                                " ,[HitType] " +
                                                " ,[SearchTerm] " +
                                                " ,[TargetSite] " +
                                                " ,[DailyHitCount] " +
                                                " ,[MinSecond] " +
                                                " ,[MaxSecond] " +
                                                " ,[IsActive] " +
                                                " ,[GoogleSearchUrl] " +
                                                " ,[IsAdminHit] " +
                                                " ,[IsClickLink] " +
                                                " ,[LinkInfo]) " +
                                                " ,[Backlink]) " +
                                            " VALUES " +
                                            " ( " +
                                                " " + UserRowID.ToString() + ", " +
                                                " '" + HitType + "', " +
                                                " '" + SearchTerm + "', " +
                                                " '" + TargetSite + "', " +
                                                " " + DailyHitCount.ToString() + ", " +
                                                " " + MinSecond.ToString() + ", " +
                                                " " + MaxSecond.ToString() + ", " +
                                                " " + IsActive.ToString() + ", " +
                                                " '" + GoogleSearchUrl + "', " +
                                                " " + IsAdminHit.ToString() + ", " +
                                                " " + IsClickLink.ToString() + ", " +
                                                " '" + LinkInfo + "', " +
                                                " '" + Backlink + "' " +
                                            " ) ";

                SqlCommand sqlCmd = new SqlCommand(strSQL, sqlCon);
                sqlCmd.CommandType = CommandType.Text;

                int count = (int)sqlCmd.ExecuteNonQuery();
                result = (count > 0);
            }
            catch
            {
                //
            }
            finally
            {
                // İşlem bittikten sonra kapatılmalı bağlantı...
                ConnectionClose();
            }

            return result;
        }


        public static int GetUserRowId(string Email)
        {
            int result = 0;
            try
            {
                ConnectionOpen();

                string strSQL = " SELECT RowID FROM Users  " +
                                " WHERE Email = '" + Email + "'";

                using (DataTable tblUsers = new DataTable("Users"))
                {
                    using (SqlDataAdapter daHallNames = new SqlDataAdapter(strSQL, sqlCon))
                    {
                        daHallNames.Fill(tblUsers);

                        if (tblUsers.DefaultView.Count > 0)
                            result = Convert.ToInt32(tblUsers.Rows[0]["RowID"]);
                    }
                }
            }
            finally
            {
                // İşlem bittikten sonra kapatılmalı bağlantı...
                ConnectionClose();
            }

            return result;
        }

        public static string GetUserPassword(string Email)
        {
            string result = "";
            try
            {
                ConnectionOpen();

                string strSQL = " SELECT Password FROM Users  " +
                                " WHERE Email = '" + Email + "'";

                using (DataTable tblUsers = new DataTable("Users"))
                {
                    using (SqlDataAdapter daHallNames = new SqlDataAdapter(strSQL, sqlCon))
                    {
                        daHallNames.Fill(tblUsers);

                        if (tblUsers.DefaultView.Count > 0)
                            result = Convert.ToString(tblUsers.Rows[0]["Password"]);
                    }
                }
            }
            finally
            {
                // İşlem bittikten sonra kapatılmalı bağlantı...
                ConnectionClose();
            }

            return result;
        }

        public static bool AddWorkingSearchTerm(int SearchTermRowID, string ProgVersionInfo, int UserRowID, string Email, string IpAddress, double SpentCredit)
        {
            bool result = false;
            try
            {
                ConnectionOpen();

                SqlCommand sqlCmd = new SqlCommand("tsp_InsertWorkingSearchTerm", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.AddWithValue("@SearchTermRowID", SearchTermRowID);
                sqlCmd.Parameters.AddWithValue("@ProgVersionInfo", ProgVersionInfo);
                sqlCmd.Parameters.AddWithValue("@UserRowID", UserRowID);
                sqlCmd.Parameters.AddWithValue("@Email", Email);
                sqlCmd.Parameters.AddWithValue("@IpAddress", IpAddress);
                sqlCmd.Parameters.AddWithValue("@SpentCredit", SpentCredit);

                sqlCmd.ExecuteNonQuery();
            }
            catch
            {
                //
            }
            finally
            {
                // İşlem bittikten sonra kapatılmalı bağlantı...
                ConnectionClose();
            }

            return result;
        }

    }
}
