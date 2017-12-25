using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Taxi.Business;
//using Taxi.Data.AutoUpdate;
using Taxi.Utils;

namespace Taxi.GUI
{

    static class Program
    {
        [DllImport("user32.dll")]
        private static extern int SystemParametersInfo(int uAction, int uParam, int lpvParam, int fuWinIni);

        private const int SPI_SETKEYBOARDCUES = 4107; //100B
        private const int SPIF_SENDWININICHANGE = 2;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SystemParametersInfo(SPI_SETKEYBOARDCUES, 0, 1, 0);

            //license.CheckLicense();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Global.Module = EnumModule.EnVang_TongDai;
            // Ghi lại log khi sảy ra lỗi bất thường của phần mềm.
            //Tham khảo:http://stackoverflow.com/questions/11573730/winforms-application-crashes
            // https://social.msdn.microsoft.com/Forums/vstudio/en-US/ea7769d6-808c-4303-be66-4c671ae9942f/how-to-make-winform-net-application-never-crash

            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            //D:\Ftp\Customer\AutoUpdate\Test
            
            //AutoUpdate objAutoUpdate = new AutoUpdate().GetUpdateByDateTime(Utils.Module.TongDaiVien,Taxi.Utils.license.Version());
            //if (objAutoUpdate != null)
            //{
            //    //@"Test,AutoUpdate.exe,TongDaiV2@CODE".Split(',');
            //    System.Diagnostics.Process.Start(objAutoUpdate.UpdateFolder +
            //                                "AutoUpdate.exe",
            //                                objAutoUpdate.ModuleName);
                
            //}
            //else
            {
                // Application.Run(new frmKhachCanXe());
                Application.Run(new frmDieuHanhBoDamNEW_V4());
                // Application.Run(new frmTest());
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