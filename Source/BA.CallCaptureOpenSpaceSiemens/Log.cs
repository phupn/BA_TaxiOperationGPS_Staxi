using System;
using System.Diagnostics;
using System.IO;

namespace BA.CallCaptureOpenSpaceSiemens
{
    public class LogError_Siemens
    {
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
                file.WriteLine(Message + " [" + ex.Message + "]");
                file.Close();
            }
            catch (IOException IOex)
            {
                throw (new Exception("WriteLogError ghi file: " + IOex.Message));
            }
        }
        /// <summary>
        /// Thực hiện ghi log for debug.
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
                StreamWriter file = new StreamWriter(LogFilePath, true);
                file.WriteLine(Message);
                file.Close();
            }
            catch (IOException IOex)
            {
                WriteLogError("WriteLogErrorForDebug: ", IOex);
            }
        }
    }

}
