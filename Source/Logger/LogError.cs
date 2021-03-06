using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Web;

namespace Taxi.Logger
{
    public class LogError
    {
        static string _filepath = "";
        public static string filePath 
        { 
            get
            {
                try
                {
                    if (ConfigurationManager.AppSettings["filePath"] != null)
                    {
                        _filepath = ConfigurationManager.AppSettings["filePath"];
                    }
                    else
                    {
                        _filepath = System.Web.Configuration.WebConfigurationManager.AppSettings["filePath"];
                    }
                }
                catch (Exception ex)
                {
                    WriteLogError("filePath: ", ex);
                }
                return _filepath;
            }
            set
            {
                _filepath = value;
            }            
        }

        /// <summary>
        /// Ghi log lỗi. AppSettings["filePath"]
        /// <param name="pMessage">Nội dung</param>
        /// <param name="ex">Lỗi</param>
        /// </summary>        
        public static void WriteLogError(string pMessage, Exception ex)
        {
            try
            {
                if (string.IsNullOrEmpty(filePath))
                {
                    filePath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
                }
                string LogFilePath = filePath;
                LogFilePath += "\\" + string.Format("{0:yyyy}", DateTime.Now) + "\\" + string.Format("{0:MM}", DateTime.Now) + "\\" + string.Format("{0:dd}", DateTime.Now);
                if (!Directory.Exists(LogFilePath))
                {
                    Directory.CreateDirectory(LogFilePath);
                }
                LogFilePath = LogFilePath + "\\logError" + ".log";
                StreamWriter file = new StreamWriter(LogFilePath, true);
                file.WriteLine(string.Format("{0: HH:mm:ss dd/MM/yyyy}", DateTime.Now) + " " + pMessage + " [" + ex.Message + "]");
                file.Close();
            }
            catch (IOException IOex)
            {

            }
        }


        /// <summary>
        /// thực hiện ghi log for debug. Nếu để trống thì sẽ lấy thư mục gốc chứa file chạy. AppSettings["filePath"]
        /// </summary>          
        public static void WriteLogErrorForDebug(string Message)
        {
            try
            {
                if (string.IsNullOrEmpty(filePath))
                {
                    filePath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
                }
                string LogFilePath = filePath;
                LogFilePath += "\\" + string.Format("{0:yyyy}", DateTime.Now) + "\\" + string.Format("{0:MM}", DateTime.Now) + "\\" + string.Format("{0:dd}", DateTime.Now);
                if (!Directory.Exists(LogFilePath))
                {
                    Directory.CreateDirectory(LogFilePath);
                }
                LogFilePath = LogFilePath + "\\logDebug" + ".log";
                StreamWriter file = new StreamWriter(LogFilePath, true);
                file.WriteLine(string.Format("{0: HH:mm:ss dd/MM/yyyy}", DateTime.Now) + " " + Message);
                file.Close();
            }
            catch (IOException IOex)
            {

            }
        }
    }
}
