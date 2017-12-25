
using System;
using System.Configuration;

namespace AutoUpdate.Engine.Utility
{

    public static class Constants
    {
        public static string APP_FOLDER = Environment.CurrentDirectory + "\\";
        /// <summary>
        /// Thư mục con chứa file update
        /// </summary>
        public static string APP_SUB = "";
        /// <summary>
        /// Tên Module Update
        /// </summary>
        public static string APP_NAME = "";
        /// <summary>
        /// Tên hãng cần update
        /// </summary>
        public static string XN_NAME = "";
        
#if WAN
        public static string DOMAIN = "baprocess.binhanh.com.vn";
        public static string FTP_URL = "ftp://{0}/";
#else
        public static string DOMAIN = "";
        public static string FTP_URL = ConfigurationManager.AppSettings["FTP_URL"];
#endif
        public static string FTP_USERNAME = ConfigurationManager.AppSettings["FTP_USERNAME"];
        public static string FTP_PASSWORD = ConfigurationManager.AppSettings["FTP_PASSWORD"];
        
        public static byte DOWNLOAD_TIME_SLEEP = 10;
        public static bool FTP_ENABLE_SSL = false;
    }
}
