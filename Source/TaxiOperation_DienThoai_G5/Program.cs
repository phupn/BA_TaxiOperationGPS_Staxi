#region ============= Copyright © 2016 BinhAnh =============

using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Business.AutoUpdate;
using Taxi.Business.QuanTri;
using Taxi.Controls.VersionInfo;
using Taxi.GUI;
using Taxi.Utils;
#endregion ============= Copyright © 2016 BinhAnh =============

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
            try
            {
                //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://192.168.100.188:8080/MPCCNotifier/mptelecom/DoAction.jsp?event=GetRealTimeList");
                //try
                //{
                //    WebResponse response = request.GetResponse();
                //    JArray array = new JArray();
                //    using (var twitpicResponse = (HttpWebResponse)request.GetResponse())
                //    {

                //        using (var reader = new StreamReader(twitpicResponse.GetResponseStream()))
                //        {
                //            JavaScriptSerializer js = new JavaScriptSerializer();
                //            var objText = reader.ReadToEnd();

                //            JObject joResponse = JObject.Parse(objText);
                //            //JObject result = (JObject)joResponse["result"];
                //            //array = (JArray)result["Detail"];
                //            //string statu = array[0]["dlrStat"].ToString();
                //        }

                //    }
                //}
                //catch (WebException ex)
                //{
                //    LogError.WriteLogError("ProcessGoiDi:", ex);
                //    //return "";
                //}

                ////ThreadPool.SetMinThreads(20, 20);
                ////Application.EnableVisualStyles();
                ////Application.SetCompatibleTextRenderingDefault(false);
                ////Global.Module = EnumModule.G5_DienThoai;
                ////Application.Run(new FormMainRibbon());
                //////Application.Run(new FrmCommandModule());
                ////return;
                ThreadPool.SetMinThreads(20, 20);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Global.Module = EnumModule.G5_DienThoai;
                QuanTriCauHinh.IpAddress = QuanTriCauHinh.GetLocalIPAddress();
                ServiceVersion.CheckVersionStart();
                while (count <= 5)
                {
                    count++;
                    if (DieuHanhTaxi.GetTimeServer() > DateTime.MinValue)
                    {
                        AutoUpdate objAutoUpdate = new AutoUpdate().GetUpdateByDateTime(Module.DienThoaiVien,license.Version());
                        if ((objAutoUpdate != null || ServiceVersion.IsRequired) && !Debugger.IsAttached)
                        {
                            Process.Start("AutoUpdate.exe", objAutoUpdate.ModuleName);
                        }
                        else
                        {
                            Application.Run(new frmDieuHanhDienThoaiNEWCP_V3());                           
                        }
                        return;
                    }
                    else
                    {
                        if (count >= 5)
                        {
                            Application.Run(new frmSettings());
                        }
                    }
                    Thread.Sleep(1000);
                }

            }
            catch (Exception)
            {
                try
                {
                    if (!string.IsNullOrEmpty(ThongTinDangNhap.USER_ID) && !string.IsNullOrEmpty(QuanTriCauHinh.IpAddress) && ThongTinDangNhap.IsUserPostionTrust(ThongTinDangNhap.USER_ID, QuanTriCauHinh.IpAddress)) // ngôi đúng vị trí checkout
                    {
                        ThongTinDangNhap.CheckOut(ThongTinDangNhap.USER_ID, QuanTriCauHinh.IpAddress);
                    }
                }
                catch (Exception ex1)
                {
                    LogError.WriteLogError("frmDieuHanhDienThoaiNEWCP_V3_FormClosed:", ex1);
                }
            }
        }
    }
}