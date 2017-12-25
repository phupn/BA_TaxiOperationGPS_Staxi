using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Taxi.GUI;
using Taxi.Utils;

namespace Taxi.GUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //license.CheckLicense();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMoiKhach_V3 ());
        }
    }
}