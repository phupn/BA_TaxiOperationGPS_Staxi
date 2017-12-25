using System;
using System.Diagnostics;
using System.IO;
 

namespace Taxi.Business
{
    public class LogError
    {
        private static object lockobj= new object();

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
                file.WriteLine(Environment.NewLine+ex.StackTrace);
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
                LogFilePath += "\\" + string.Format("{0:yyyy}", DateTime.Now) + "\\" + string.Format("{0:MM}", DateTime.Now) + "\\" + string.Format("{0:dd}", DateTime.Now)+"\\Crash";
                if (!Directory.Exists(LogFilePath))
                {
                    Directory.CreateDirectory(LogFilePath);
                }
                LogFilePath = LogFilePath + "\\Crash_"+DateTime.Now.ToString("HHmmss") + ".log";
                StreamWriter file = new StreamWriter(LogFilePath, true);
                file.WriteLine("{0:HH:mm:ss dd/MM/yyyy} {0}",DateTime.Now);
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

        public static void WriteLogInfoApp(Guid bookId,string message)
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


        public static void WriteLogSetting(string message)
        {
            try
            {
                {
                    string LogFilePath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
                    LogFilePath += "\\Settings";
                    if (!Directory.Exists(LogFilePath))
                    {
                        Directory.CreateDirectory(LogFilePath);
                    }
                    LogFilePath = LogFilePath + "\\logDebug" + ".log";
                    var file = new StreamWriter(LogFilePath, true);
                    file.WriteLine(string.Format("{0:HH:mm:ss dd/MM/yyyy}", DateTime.Now) + " : " + message);
                    file.Close();
                }
            }
            catch
            {

            }
        }
    }
}
