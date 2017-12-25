using System;
using System.IO;
using System.Diagnostics;
using Taxi.Utils;
using System.Windows.Forms;

namespace Taxi.Business
{
  public class Configuration
  {

      /// <summary>
      /// lấy thông tin máy tính là máy nhập thuê bao tuyến
      /// </summary>
      /// <returns></returns>
      public static bool GetMayTinhNhapThueBao()
      {
          return System.Configuration.ConfigurationManager.AppSettings["NhapThueBaoKenh3"] == "1";
      }

      /// <summary>
      /// hàm trả về thông tin cấu hình Chuyển CS - bộ phận chăm sóc khách hàng.
      /// </summary>
      public static string GetThongTinCauHinhChuyenCS()
      {
          return System.Configuration.ConfigurationManager.AppSettings["ChuyenCS"].ToString();
      }

      private static int _TrangThaiBatSo = 3;

      /// <summary>
      /// ham tra ve trang thai bat so
      /// </summary>
      /// <returns></returns>
      public static int TrangThaiBatSo
      {
          get
          {
              if (_TrangThaiBatSo != null)
              {
                  return System.Configuration.ConfigurationManager.AppSettings["TrangThaiBatSo"] == null ? 1 : int.Parse(System.Configuration.ConfigurationManager.AppSettings["TrangThaiBatSo"]);
              }
              return 1;
          }
          set
          {
              _TrangThaiBatSo = value;
          }
      }


      /// <summary>
      /// ham tra ve dau so goi di = '9' + '0437856099'
      /// </summary>
      /// <returns></returns>
      private static string _DauSoGoiDi = "";

      /// <summary>
      /// ham tra ve dau so goi di = '9' + '0437856099'
      /// </summary>
      /// <returns></returns>
      public static string GetDauSoGoiDi
      {
          get
          {
              try
              {
                  if (_DauSoGoiDi != null)
                  {
                      return System.Configuration.ConfigurationManager.AppSettings["DauSoGoiDi"] == null ? "" : System.Configuration.ConfigurationManager.AppSettings["DauSoGoiDi"].ToString();
                  }

              }
              catch (Exception ex) { }
             
              return "";
          }
          set
          {
              _DauSoGoiDi = value;
          }
      }

      private static string _BoDauSoGoiDi = "";

      /// <summary>
      /// Hàm trả về đầu số mã vùng cần bỏ đi khi gọi tự động
      /// </summary>
      /// <returns></returns>
      public static string DauSoBoDi
      {
          get
            {
                if (_BoDauSoGoiDi != null)
                {
                    return System.Configuration.ConfigurationManager.AppSettings["BoDauSoGoiDi"] == null ? "" : System.Configuration.ConfigurationManager.AppSettings["BoDauSoGoiDi"].ToString();
                }
                return "";
            }
            set
            {
                _BoDauSoGoiDi = value;
            }
      }


      public static string GetSoDienThoaiGoiNhanh(string SoDienThoai)
      {
          int len = DauSoBoDi.Length;
          string strSoDienThoai = SoDienThoai.Substring(0, len);
          if (DauSoBoDi != "" && strSoDienThoai == DauSoBoDi)
              strSoDienThoai = SoDienThoai.Substring(len, SoDienThoai.Length - len);
          else 
               strSoDienThoai = SoDienThoai;
          return strSoDienThoai;
      }

      public static string GetSoDienThoaiCongTy()
      {
          return ThongTinCauHinh.SoDienThoaiCongTy; //System.Configuration.ConfigurationManager.AppSettings["SoDienThoaiCongTy"];
      }

      public static string GetCompanyName()
      {
          return license.Version() + " - " + ThongTinCauHinh.TenCongTy;// return System.Configuration.ConfigurationManager.AppSettings["CompanyName"];
      }
      /// <summary>
      /// giữ lại số cuộc gọi khi khách gọi đông quá.
      /// </summary>
      /// <returns></returns>
      public static  int GetSoCuocGoiGiuLai()
      {
          try
          {
              return int.Parse(System.Configuration.ConfigurationManager.AppSettings["SoCuocGoiGiuLai"].ToString());
          }
          catch (Exception ex)
          {
              return 800;
          }
      }

      public static string GetDuongDanThuMucFileAmThanh()
      {
          return ThongTinCauHinh.ThuMucFileAmThanh;
      }

      public static string GetLastDateTimeCall()
      {
          return System.Configuration.ConfigurationManager.AppSettings["LastDateTimeCall"];
      }
      
      public static  string LogIncomingPath()
      {
          return ThongTinCauHinh.ThuMucDuLieuTanasonic + "\\Log_Incoming.MDB"; 
      }

      public static string VocFilePath()
      {
          DateTime TimeServer = DieuHanhTaxi.GetTimeServer();
          return ThongTinCauHinh.ThuMucDuLieuTanasonic + "\\" + "Voc" + TimeServer.Year.ToString() + "-" + StringTools.GeMonthString(TimeServer.Month) + ".mdb";
      }

      public static string InComFilenamePath()
      {
          return ThongTinCauHinh.ThuMucDuLieuTanasonic + "\\INCOM.MDB"; 
      }

      public static int GetTimerCapturePhone()
      {
        return 1000;
      }
      public static int GetTimerTickForCAMON()
      {
          return 5000;
      }
      
      public static int GetDienThoai_ThoiDiemChuyenTongDai()
      {
          int TimerLength = 50;// giay
          try
          {
              return  ThongTinCauHinh.SoGiayGioiHanThoiGianChuyenTongDai;  
          }
          catch (Exception ex)
          {
              return TimerLength;
          }
      }

      public static int GetGioiHanThoiGianDieuXe()
      {
          int TimerLength = 3;// phút
          try
          {
              return ThongTinCauHinh.SoGiayGioiHanThoiGianDieuXe;  
          }
          catch (Exception ex)
          {
              return TimerLength;
          }
      }

      public static int GetGioiHanThoiGianDonKhach()
      {
          int TimerLength = 420;// giay
          try
          {
              return ThongTinCauHinh.SoGiayGioiHanThoiGianDonKhach;  
              
          }
          catch (Exception ex)
          {
              return TimerLength;
          }
      }

      public static string GetReportPath()
      {
          string ReportPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
          return ReportPath + "\\Reports";
      }

      #region ThongTinMatLienLac
      public static int GetSoPhutGioiHanMatLienLac()
      {
          int TimerLength = 60;// phút
          try
          {
               return ThongTinCauHinh.SoPhutGioiHanMatLienLac; 
               
          }
          catch (Exception ex)
          {
              return TimerLength;
          }
      }
      public static int GetSoPhutGioiHanMatLienLacBaoNghi()
      {
          int TimerLength = 60;// phút
          try
          {
              return ThongTinCauHinh.SoPhutGioiHanMatLienLacBaoNghi; 
               
          }
          catch (Exception ex)
          {
              return TimerLength;
          }
      }
      public static int GetSoPhutGioiHanMatLienLacBaoDiSanBay()
      {
          int TimerLength = 60;// phút
          try
          {
              return  ThongTinCauHinh.SoPhutGioiHanMatLienLacBaoDiSanBay;  
               
          }
          catch (Exception ex)
          {
              return TimerLength;
          }
      }

      public static int GetSoPhutGioiHanMatLienLacBaoDiDuongDai()
      {
          int TimerLength = 60;// phút
          try
          {
              TimerLength = ThongTinCauHinh.SoPhutGioiHanMatLienLacBaoDiDuongDai;
             // TimerLength = int.Parse(System.Configuration.ConfigurationManager.AppSettings["SoPhutGioiHanMatLienLacBaoDiDuongDai"].ToString());
              return TimerLength;
          }
          catch (Exception ex)
          {
              return TimerLength;
          }
      }
      #endregion ThongTinMatLienLac

      public static string GetLogoImagePath()
      {
          //string ReportPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
          return GetReportPath() + "\\logo.jpg";
      }

      /// <summary>
      /// lay so đầu tiên của tổng đài, dùng cho trường hợp hệ thống có sử dụng số tổng đài
      /// </summary>
      /// <returns></returns>
      public static string GetSoDauCuaTongDai()
      {
          return ThongTinCauHinh.SoDauCuaTongDai;
         // return System.Configuration.ConfigurationManager.AppSettings["SoDauCuaTongDai"].ToString();
      }
      /// <summary>
      /// <add key="NgaySaoLuuTatCaGanDay"  value=""/>
      ///<add key="NgaySaoLuuMotPhanGanDay"  value=""/>
      /// </summary>
      /// <returns></returns>
      public static string GetNgaySaoLuuTatCaGanDay()
      {

          return System.Configuration.ConfigurationManager.AppSettings["NgaySaoLuuTatCaGanDay"].ToString();
      }
      /// <summary>
      /// hàm trả về số phút cảnhbáo mời khách.
      /// </summary>
      /// <returns></returns>
      public static int GetSoPhutCanhBaoMoiKhach()
      {
          string strSoPhutCanhBao = System.Configuration.ConfigurationManager.AppSettings["SoPhutCanhBaoMoiKhach"].ToString();
          try
          {
              return Convert.ToInt32(strSoPhutCanhBao);
          }
          catch (Exception ex)
          {
              return 5;
          }
      }
      public static bool SetNgaySaoLuuTatCaGanDay(string NgaySaoLuuTatCaGanDay)
      {
          try
          {
              System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

              config.AppSettings.Settings["NgaySaoLuuTatCaGanDay"].Value = NgaySaoLuuTatCaGanDay;
              config.Save(System.Configuration.ConfigurationSaveMode.Modified);
              System.Configuration.ConfigurationManager.RefreshSection("appSettings");
              return true;
          }
          catch (Exception ex)
          {
              return false;
          }
          }
      /// <summary>
      /// cap nhật trạng thái lưu một phần.
      /// </summary>
      /// <returns></returns>
      public static string GetNgaySaoLuuMotPhanGanDay()
      {

          return System.Configuration.ConfigurationManager.AppSettings["NgaySaoLuuMotPhanGanDay"].ToString();
      }
      public static bool SetNgaySaoLuuMotPhanGanDay(string NgaySaoLuuMotPhanGanDay)
      {
          try{
          System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

          config.AppSettings.Settings["NgaySaoLuuMotPhanGanDay"].Value = NgaySaoLuuMotPhanGanDay;
          config.Save(System.Configuration.ConfigurationSaveMode.Modified);
          System.Configuration.ConfigurationManager.RefreshSection("appSettings");
         return true;
          }
          catch (Exception ex)
          {
              return false;
          }
      }

      public static int GetUDPPort()
      {
          int UDPPort = 2000;
          string strUDPPort = System.Configuration.ConfigurationManager.AppSettings["UDPport"].ToString();
          int.TryParse(strUDPPort, out UDPPort);
          return UDPPort;
      }

      private static string _IsCardT4;

      /// <summary>
      /// ham tra ve trang thai bat so
      /// </summary>
      /// <returns></returns>
      public static bool IsCardT4
      {
          get
          {
              if (string.IsNullOrEmpty(_IsCardT4))
              {
                  _IsCardT4 = System.Configuration.ConfigurationManager.AppSettings["T4"] == null ? "0" : System.Configuration.ConfigurationManager.AppSettings["T4"].ToString();
              }
              return _IsCardT4 == "1";
          }
      }

      /// <summary>
      /// Password service
      /// </summary>
      public static string LineIPPBX
      {
          get
          {
              if (System.Configuration.ConfigurationManager.AppSettings["LineIPPBX"] != null)
              {
                  return System.Configuration.ConfigurationManager.AppSettings["LineIPPBX"];
              }
              else
              {
                  return "";
              }
          }
      }

      /// <summary>
      /// Password service
      /// </summary>
      public static string LineIPPBX2
      {
          get
          {
              if (System.Configuration.ConfigurationManager.AppSettings["LineIPPBX2"] != null)
              {
                  return System.Configuration.ConfigurationManager.AppSettings["LineIPPBX2"];
              }
              else
              {
                  return "";
              }
          }
      }
      /// <summary>
      /// Line dung de get thong tin cuoc goi cho bo phan moi khach
      /// </summary>
      public static string LineMoiKhach
      {
          get
          {
              if (System.Configuration.ConfigurationManager.AppSettings["LineMK"] != null)
              {
                  return System.Configuration.ConfigurationManager.AppSettings["LineMK"];
              }
              else
              {
                  return "";
              }
          }
      }
      /// <summary>
      /// Password service
      /// </summary>
      public static bool IsMKAsterisk
      {
          get
          {
              if (System.Configuration.ConfigurationManager.AppSettings["IsMKAsterisk"] != null)
              {
                  return System.Configuration.ConfigurationManager.AppSettings["IsMKAsterisk"] == "1";
              }
              else
              {
                  return false;
              }
          }
      }
      public static bool IsDebug
      {
          get
          {
              if (System.Configuration.ConfigurationManager.AppSettings["IsDebug"] != null)
              {
                  return System.Configuration.ConfigurationManager.AppSettings["IsDebug"] == "1";
              }
              else
              {
                  return false;
              }
          }
      }
      #region Cấu hình CẢM ƠN
      /// <summary>
      /// hàm lấy thông tin đặt số phút sau thời điểm hiện tại để lấy các cuộc gọi 
      /// Mặc định là 60 phút nếu không đặt
      /// </summary>
      /// <returns></returns>
      public static int CAMON_GetConfigSoPhucLayCuocGoiCachDay()
      {
          int iRet = 60;
          try
          {
              iRet = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["LayCuocGoiCachDaySoPhut"].ToString());
          }
          catch (Exception ex)
          {
              iRet = 60;
             
          }
          return iRet;
      }
      /// <summary>
      /// hàm lấy thông tin đặt ẩn sau số phút
      /// mặc định là 5 phút.
      /// </summary>
      /// <returns></returns>
      public static int CAMON_GetLaySoPhutAnSau()
      {
          int iRet = 5;
          try
          {         
              iRet = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["AnSauSoPhut"].ToString());
              
          }
          catch (Exception ex)
          {
              iRet = 5;              
          }
          return iRet;
      }
      /// <summary>
      /// Đặt số phút lấy cuốc gọi cách đây
      /// </summary>
      /// <param name="SoPhutLayCuocGoiCachDay"></param>
      /// <returns></returns>
      public static bool CAMON_SetConfigSoPhucLayCuocGoiCachDay(int SoPhutLayCuocGoiCachDay)
      {
           try{
              System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
              config.AppSettings.Settings["LayCuocGoiCachDaySoPhut"].Value = SoPhutLayCuocGoiCachDay.ToString ();
              config.Save(System.Configuration.ConfigurationSaveMode.Modified);
              System.Configuration.ConfigurationManager.RefreshSection("appSettings");
              return true;
          }
          catch (Exception ex)
          {
              return false;
          }
      }
      /// <summary>
      /// đặt số phút ẩn sau
      /// </summary>
      /// <param name="LaySoPhutAnSau"></param>
      /// <returns></returns>
      public static bool CAMON_SetConfigLaySoPhutAnSau(int LaySoPhutAnSau)
      {
          try
          {
              System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
              config.AppSettings.Settings["AnSauSoPhut"].Value = LaySoPhutAnSau.ToString();
              config.Save(System.Configuration.ConfigurationSaveMode.Modified);
              System.Configuration.ConfigurationManager.RefreshSection("appSettings");
              return true;
          }
          catch (Exception ex)
          {
              return false;
          }
      }
      #endregion Cấu hình CẢM ƠN
  }
}
