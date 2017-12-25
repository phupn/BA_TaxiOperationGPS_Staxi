using System;
using System.Threading;
using System.Windows.Forms;
using Taxi.Business;

namespace StaxiManClient
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
            while (count <= 5)
            {
                count++;
                if(DieuHanhTaxi.GetTimeServer() > DateTime.MinValue)
                {
                    Application.Run(new MainForm());
                    break;
                }

                if (count >= 5)
                {
                    Application.Run(new frmSettings());
                }
                Thread.Sleep(1000);
            } 
            
        }
    }
}
