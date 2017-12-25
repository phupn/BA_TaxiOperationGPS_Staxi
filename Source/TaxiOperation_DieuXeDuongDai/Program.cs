using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Taxi.Business;

namespace TaxiOperation_DieuXeDuongDai
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
            //Lấy thông tin cấu hình
            ThongTinCauHinh.GPS_MucZoom = 9;
            ThongTinCauHinh.GPS_ViDo=float.Parse("21.0226967");
            ThongTinCauHinh.GPS_KinhDo = float.Parse("105.8369637");
            ThongTinDangNhap.USER_ID = "Admin_Demo";
            Application.Run(new frmMain());
        }
    }
}
