using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Taxi.Business.AutoUpdate;
using Taxi.GUI;
using Taxi.Utils;

namespace Taxi.Controls
{
    static class Program
    {
        public static bool OpenDetailFormOnClose { get; set; }
        private static int count = 0;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Global.Module=EnumModule.G5_DienThoai;
            while (count <= 5)
            {
                count++;
                if (Taxi.Business.DieuHanhTaxi.GetTimeServer() > DateTime.MinValue)
                {
                    AutoUpdate objAutoUpdate = new AutoUpdate().GetUpdateByDateTime(Utils.Module.DienThoaiVien, Taxi.Utils.license.Version());
                    if (objAutoUpdate != null && !Debugger.IsAttached)
                    {
                        System.Diagnostics.Process.Start("AutoUpdate.exe", objAutoUpdate.ModuleName);
                    }
                    else
                    {
                        license.CheckLicense();
                        Application.Run(new frmDieuHanhDienThoaiNEWCP_V3());
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