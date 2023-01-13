using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MaSoft.MaPos.Core
{
    public static partial class StaticVariables
    {
        public static string HostIp = "...";
        public static string UserName = "root";
        public static string DbPassword = "...";
        public static string Db = "...";

        public static string EMailAddress = "";
        public static string Password = "";
        public static Boolean ServerMode = false;
        public static string ProfileName = "";
        public static string ProfileFullPath = "";
        public static int GroupId = 1;

        public static int UserRowID = 0;
        public static float TotalCredit = 0;
        public static string IpAddress = "";

        public static bool NewVersionExist = false;
        public static string ProgVersInfo = "";

        public static string SmtpHost = "mail.***.com";
        public static string SmtpUserName = "info@***.com";
        public static string SmtpPassword = "***";
        public static int SmtpPort = 587;

        public static bool ClickSubPageActive = false;
        public static string RequestSite = "";

        public static bool   UserAuthenticated = false;
        public static string UserPassword = "";

        public static CultureInfo cultureInfo = null;

        public static string ConnectionString()
        {
            return "Data Source=" + HostIp + ";Initial Catalog=" + Db + ";User ID=" + UserName + ";Password=" + DbPassword;
        }
    }
}
