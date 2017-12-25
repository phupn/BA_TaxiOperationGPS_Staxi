using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AutoUpdate.Engine.Utility
{
    /// <summary>
    /// Summary description for LogFile
    /// </summary>
    public class LogFile
    {
        /// <summary>
        /// Write error to logfile
        /// </summary>
        /// <param name="msg">Message</param>
        public static void Write(string msg)
        {
            try
            {
                StreamWriter f = new StreamWriter("Logs.txt", true);
                f.WriteLine(DateTime.Now.ToString() + ": " + msg);
                f.Close();
            }
            catch { }
        }
    }
}
