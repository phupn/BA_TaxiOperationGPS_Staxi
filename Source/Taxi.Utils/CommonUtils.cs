using System;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using BALicenseManager;
using Taxi.Utils.Settings;
using System.Drawing;
namespace Taxi.Utils
{
    public class CommonUtils
    {
        public static MySettings MySettingObject { set; get; }

        private static string _connectionString = string.Empty;

        public static string ConnectionString
        {
            get 
            {
                if (string.IsNullOrEmpty(_connectionString) || _connectionString.Trim()=="") _connectionString=ConfigurationManager.AppSettings["ConnectionString"];

                //if (MySettingObject == null)
                //{
                //    //Read Setting file
                //    string path = System.Windows.Forms.Application.StartupPath;
                //    path = Path.Combine(path, "Settings");
                //    // Create folder if it doesn't already exist
                //    if (!Directory.Exists(path))
                //        Directory.CreateDirectory(path);
                //    //Set Setting Object
                //    MySettingObject = new MySettings();
                //    MySettingObject.SettingsPath = Path.Combine(path, "Settings.xml");
                //    MySettingObject.EncryptionKey = "sampleKey";
                //    MySettingObject.Load();
                //}

                //if (string.IsNullOrEmpty(_ConnectionString))
                //    _ConnectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}",
                //                            MySettingObject.DataSource,
                //                            MySettingObject.InitialCatalog,
                //                            MySettingObject.UserID,
                //                            MySettingObject.Password);
                return _connectionString; 
            }            
        }

        public static Color SetTransparency(int A, Color color)
        {
            return Color.FromArgb(A, color.R, color.G, color.B);
        }
    }

    public class BALicenseManager
    {
        public static int CheckValidateLicense(string pLicenseCode, string pLicenseKey, DateTime pTime, string macAddress, string cPUID)
        {
            var temp = new ProductLicense();
            return temp.IsActivated(pLicenseCode, pLicenseKey, pTime, macAddress, cPUID);
        }
    }

    public class LogErrorUtils  
    {
        private static object lockobj = new object();

        public static void WriteLogInfo(string Message)
        {
            try
            {
                string LogFilePath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);//Path.GetTempPath();//
                LogFilePath += "\\" + string.Format("{0:yyyy}", DateTime.Now) + "\\" + string.Format("{0:MM}", DateTime.Now) + "\\" + string.Format("{0:dd}", DateTime.Now);
                if (!Directory.Exists(LogFilePath))
                {
                    Directory.CreateDirectory(LogFilePath);
                }
                LogFilePath = LogFilePath + "\\logInfo" + ".log";
                var file = new StreamWriter(LogFilePath, true);
                file.WriteLine(string.Format("{0 : HH:mm:ss dd/MM/yyyy}", DateTime.Now) + " " + Message);
                file.Close();
            }
            catch (IOException IOex)
            {
                throw (new Exception("logInfo.log nghi file: " + IOex.Message));
            }
        }

        public static void WriteLogError(string Message, Exception ex)
        {
            try
            {
                string LogFilePath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);//Path.GetTempPath();//
                LogFilePath += "\\" + string.Format("{0:yyyy}", DateTime.Now) + "\\" + string.Format("{0:MM}", DateTime.Now) + "\\" + string.Format("{0:dd}", DateTime.Now);
                if (!Directory.Exists(LogFilePath))
                {
                    Directory.CreateDirectory(LogFilePath);
                }
                LogFilePath = LogFilePath + "\\logError" + ".log";
                StreamWriter file = new StreamWriter(LogFilePath, true);
                file.WriteLine(string.Format("{0 : HH:mm:ss dd/MM/yyyy} {1} [{2}]", DateTime.Now, Message, ex.Message, ex.StackTrace));
                file.WriteLine(Environment.NewLine + ex.StackTrace);
                file.Close();
            }
            catch
            {
            }
        }
        public static void WriteLogCrashe(Exception ex)
        {
            try
            {
                string LogFilePath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);//Path.GetTempPath();//
                LogFilePath += "\\" + string.Format("{0:yyyy}", DateTime.Now) + "\\" + string.Format("{0:MM}", DateTime.Now) + "\\" + string.Format("{0:dd}", DateTime.Now) + "\\Crash";
                if (!Directory.Exists(LogFilePath))
                {
                    Directory.CreateDirectory(LogFilePath);
                }
                LogFilePath = LogFilePath + "\\Crash_" + DateTime.Now.ToString("HHmmss") + ".log";
                StreamWriter file = new StreamWriter(LogFilePath, true);
                file.WriteLine("{0:HH:mm:ss dd/MM/yyyy} {0}", DateTime.Now);
                file.WriteLine("[{0}]-{1}", ex.Source, ex.StackTrace);
                file.Close();
            }
            catch (IOException IOex)
            {
                // throw (new Exception("logError.log nghi file: " + IOex.Message));
            }
        }
        /// <summary>
        /// thực hiện ghi log for debug.
        /// </summary>        
        public static void WriteLogErrorForDebug(string Message)
        {
            try
            {
                string LogFilePath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);//Path.GetTempPath();//
                LogFilePath += "\\" + string.Format("{0:yyyy}", DateTime.Now) + "\\" + string.Format("{0:MM}", DateTime.Now) + "\\" + string.Format("{0:dd}", DateTime.Now);
                if (!Directory.Exists(LogFilePath))
                {
                    Directory.CreateDirectory(LogFilePath);
                }
                LogFilePath = LogFilePath + "\\logDebug" + ".log";
                var file = new StreamWriter(LogFilePath, true);
                file.WriteLine(string.Format("{0:HH:mm:ss dd/MM/yyyy}", DateTime.Now) + " : " + Message);
                file.Close();
            }
            catch
            {

            }
        }

        public static void WriteLogInfoApp(Guid bookId, string message)
        {
            try
            {
                lock (lockobj)
                {
                    string logFilePath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);//Path.GetTempPath();//
                    logFilePath += string.Format("\\{0:yyyy}\\{0:MM}\\{0:dd}\\LogApp\\", DateTime.Now);
                    if (!Directory.Exists(logFilePath))
                    {
                        Directory.CreateDirectory(logFilePath);
                    }
                    logFilePath = logFilePath + string.Format("{0:hh}_{1:hh}.LogApp", DateTime.Now, DateTime.Now.AddHours(1));
                    var file = new StreamWriter(logFilePath, true);
                    file.WriteLine("{0:HH:mm:ss dd/MM/yyyy} - {2} - {1}", DateTime.Now, message, bookId);
                    file.Close();
                }

            }
            catch
            {

            }
        }

        public static void WriteLogInfoCuocGoi(long IdCuocGoi, string message)
        {
            try
            {
                //lock (lockobj)
                {
                    string logFilePath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);//Path.GetTempPath();//
                    logFilePath += string.Format("\\{0:yyyy}\\{0:MM}\\{0:dd}\\LogTrip\\", DateTime.Now);
                    if (!Directory.Exists(logFilePath))
                    {
                        Directory.CreateDirectory(logFilePath);
                    }
                    logFilePath = logFilePath + string.Format("{0}.LogTrip", IdCuocGoi);
                    var file = new StreamWriter(logFilePath, true);
                    file.WriteLine("{0:HH:mm:ss dd/MM/yyyy} - {2} - {1}", DateTime.Now, message, IdCuocGoi);
                    file.Close();
                }

            }
            catch
            {

            }
        }
    }
}
