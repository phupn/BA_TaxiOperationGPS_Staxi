using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Taxi.GUI;
using TaxiOperation_TongDai;
using Taxi.GUI;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmDieuHanhBoDamNEW_V2());
        }
    }
}