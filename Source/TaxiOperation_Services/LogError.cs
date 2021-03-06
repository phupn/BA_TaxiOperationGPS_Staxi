using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;


namespace TaxiOperation_Services
{
    public class LogError
    {
        //public static void WriteLog(string Message, Exception ex)
        //{
        //    try
        //    {
        //        string LogFilePath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);//Path.GetTempPath();//
        //        LogFilePath += "\\" + string.Format("{0:yyyy}", DateTime.Now) + "\\" + string.Format("{0:MM}", DateTime.Now) + "\\" + string.Format("{0:dd}", DateTime.Now);
        //        if (!System.IO.Directory.Exists(LogFilePath))
        //        {
        //            System.IO.Directory.CreateDirectory(LogFilePath);
        //        }
        //        LogFilePath = LogFilePath + "\\logError" + ".log";
        //        System.IO.StreamWriter file = new System.IO.StreamWriter(LogFilePath, true);
        //        file.WriteLine(string.Format("{0 : HH:mm:ss dd/MM/yyyy}", DateTime.Now) + " " + Message + " [" + ex.Message + "]");
        //        file.Close();
        //    }
        //    catch (IOException IOex)
        //    {
        //        throw (new Exception("logError.log nghi file: " + IOex.Message));
        //    }
        //}

        static string filePath = System.Web.Configuration.WebConfigurationManager.AppSettings["filePath"];
        public static void WriteLogError(string Message, Exception ex)
        {
            try
            {
                string LogFilePath = filePath;// Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);//Path.GetTempPath();//
                LogFilePath += "\\" + string.Format("{0:yyyy}", DateTime.Now) + "\\" + string.Format("{0:MM}", DateTime.Now) + "\\" + string.Format("{0:dd}", DateTime.Now);
                if (!System.IO.Directory.Exists(LogFilePath))
                {
                    System.IO.Directory.CreateDirectory(LogFilePath);
                }
                LogFilePath = LogFilePath + "\\logError" + ".log";
                System.IO.StreamWriter file = new System.IO.StreamWriter(LogFilePath, true);
                file.WriteLine(string.Format("{0 : HH:mm:ss dd/MM/yyyy}", DateTime.Now) + " " + Message + " [" + ex.Message + "]");
                file.Close();
            }
            catch (IOException IOex)
            {
                throw (new Exception("logError.log nghi file: " + IOex.Message));
            }
        }


        /// <summary>
        /// thực hiện ghi log for debug.
        /// </summary>
        /// <param name="Message"></param>
        public static void WriteLogErrorForDebug(string Message)
        {
            try
            {
                string LogFilePath = filePath;//Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);//Path.GetTempPath();//
                LogFilePath += "\\" + string.Format("{0:yyyy}", DateTime.Now) + "\\" + string.Format("{0:MM}", DateTime.Now) + "\\" + string.Format("{0:dd}", DateTime.Now);
                if (!System.IO.Directory.Exists(LogFilePath))
                {
                    System.IO.Directory.CreateDirectory(LogFilePath);
                }
                LogFilePath = LogFilePath + "\\logDebug" + ".log";
                System.IO.StreamWriter file = new System.IO.StreamWriter(LogFilePath, true);
                file.WriteLine(string.Format("{0 : HH:mm:ss dd/MM/yyyy}", DateTime.Now) + " " + Message);
                file.Close();
            }
            catch (IOException IOex)
            {
                throw (new Exception("WriteLogErrorForDebug ghi file: " + IOex.Message));
            }
        }
    }
}
