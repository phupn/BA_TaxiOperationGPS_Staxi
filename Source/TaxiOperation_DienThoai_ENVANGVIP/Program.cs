using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.GUI;
using Taxi.Utils;

namespace Taxi.Controls
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            license.CheckLicense();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Ghi lại log khi sảy ra lỗi bất thường của phần mềm.
            //Tham khảo:http://stackoverflow.com/questions/11573730/winforms-application-crashes
            // https://social.msdn.microsoft.com/Forums/vstudio/en-US/ea7769d6-808c-4303-be66-4c671ae9942f/how-to-make-winform-net-application-never-crash

            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
             Thread.CurrentThread.CurrentUICulture  = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
            Global.Module = EnumModule.EnVang_DienThoai;
            if(Global.MoHinh == MoHinh.TD_DT_LaiXe)
            {
                Application.Run(new frmDieuHanhDienThoaiNEWCP_V4()); 
            }
            else
            {
                Application.Run(new frmDieuHanhDienThoaiNEWCP_V3()); 
            }
        }
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            LogError.WriteLogCrashe((Exception)e.ExceptionObject);
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            LogError.WriteLogCrashe(e.Exception);
        }
    }
}