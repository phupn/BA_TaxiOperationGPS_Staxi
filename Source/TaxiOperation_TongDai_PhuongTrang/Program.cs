using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Taxi.Business.AutoUpdate;
using Taxi.Utils;

namespace Taxi.GUI
{

    static class Program
    {
        public static bool OpenDetailFormOnClose { get; set; }
        private static int count = 0;
        [DllImport("user32.dll")]
        private static extern int SystemParametersInfo(int uAction, int uParam, int lpvParam, int fuWinIni);

        private const int SPI_SETKEYBOARDCUES = 4107; //100B
        private const int SPIF_SENDWININICHANGE = 2;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            SystemParametersInfo(SPI_SETKEYBOARDCUES, 0, 1, 0);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Global.Module = EnumModule.G5_TongDai;
            while (count <= 5)
            {
                count++;
                if (Taxi.Business.DieuHanhTaxi.GetTimeServer() > DateTime.MinValue)
                {
                    AutoUpdate objAutoUpdate = new AutoUpdate().GetUpdateByDateTime(Utils.Module.TongDaiVien, Taxi.Utils.license.Version());
                    if (objAutoUpdate != null)
                    {
                        System.Diagnostics.Process.Start("AutoUpdate.exe", objAutoUpdate.ModuleName);
                    }
                    else
                    {
                        license.CheckLicense();
                        Application.Run(new frmDieuHanhBoDamNEW_V3());
                    }
                    break;
                }
                else
                {
                    if (count >= 5)
                    {
                        Application.Run(new frmSettings());
                    }
                }
                System.Threading.Thread.Sleep(1000);
            }  
        }
    }
}