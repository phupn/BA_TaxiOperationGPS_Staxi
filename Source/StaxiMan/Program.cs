using StaxiMan_DAL;
using System;
using System.Threading;
using System.Windows.Forms;

namespace StaxiMan
{

    static class Program
    {
        public static bool OpenDetailFormOnClose { get; set; }
        private static int count = 0;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            while (count <= 5)
            {
                count++;
                if(DALCommon.Inst.GetTimeServer() > DateTime.MinValue)
                {
                    Application.Run(new StaxiManagement());
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
