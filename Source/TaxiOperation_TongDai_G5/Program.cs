using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Taxi.Business.AutoUpdate;
using Taxi.Business.QuanTri;
using Taxi.Controls.VersionInfo;
using Taxi.Utils;

namespace Taxi.GUI
{
    static class Program
    {
        public static bool OpenDetailFormOnClose { get; set; }
        private static int count = 0;
        [DllImport("user32.dll")]
        private static extern int SystemParametersInfo(int uAction, int uParam, int lpvParam, int fuWinIni);
        private const int SPI_SETKEYBOARDCUES = 4107; 

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SystemParametersInfo(SPI_SETKEYBOARDCUES, 0, 1, 0);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Global.Module = EnumModule.G5_TongDai;
            QuanTriCauHinh.IpAddress = QuanTriCauHinh.GetLocalIPAddress();
            ServiceVersion.CheckVersionStart();
            while (count <= 5)
            {
                count++;
                if (Business.DieuHanhTaxi.GetTimeServer() > DateTime.MinValue)
                {
                    AutoUpdate objAutoUpdate = new AutoUpdate().GetUpdateByDateTime(Module.TongDaiVien,license.Version());
                    if ((objAutoUpdate != null || ServiceVersion.IsRequired) && !Debugger.IsAttached)
                    {
                         Process.Start("AutoUpdate.exe", objAutoUpdate.ModuleName);
                    }
                    else
                    {
                        Application.Run(new frmDieuHanhBoDamNEW_V3());
                    }
                    break;
                }

                if (count >= 5)
                {
                    Application.Run(new frmSettings());
                }
                System.Threading.Thread.Sleep(1000);
            }  
        }
    }
}