using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Taxi.Business;
using TaxiOperation.API.Enties.KhachDat;

namespace TaxiOperation.API
{
    /// <summary>
    /// Summary description for TaxiOperation_Services
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class TaxiOperation_Services : System.Web.Services.WebService
    {
        private static string maLoi = "";
        private const string _domain = "Futabus";
        private const string _userName = "BookTaxi_Futa";
        private const string _password = "Q954KDmoHHBvg6NwKjj5CQ==";
        private static bool isAuthentication = false;//chứng thực
        public TaxiOperation_Services()
        {
        }
        public TaxiOperation_Services(string domain, string userName, string password)
        {
            if (string.IsNullOrEmpty(domain) || domain != _domain
                || userName != _userName || userName == null
                || password != _password || password == null)
            {
                maLoi = "E3"; /// E3 : Không đúng thông tin truy cập
            }
        }
        [WebMethod]
        public bool AuthenticationServices(string domain, string userName, string password)
        {
            if (string.IsNullOrEmpty(domain) || domain != _domain
                || userName != _userName || userName == null
                || password != _password || password == null)
            {
                maLoi = "E3"; // E3 : Không đúng thông tin truy cập
                isAuthentication = false;
                return false;
            }

            isAuthentication = true;
            return true;
        }

        /// <summary>
        /// Khách đặt, Request call function AuthenticationServices
        /// </summary>
        /// <param name="?"></param>
        /// <param name="khachDat"></param>
        /// <returns></returns>
        /// /// <remarks>
        /// ID  :  Mã cuốc khách đặt nếu Insert thành công
        /// F  : Lỗi Insert không thành công
        /// E1 : Lỗi trong quá trình cập nhật thông tin vào DB
        /// E2 : Lỗi Convert dữ liệu
        /// E3 : Không đúng thông tin truy cập
        /// E4 : Lỗi chưa xác thực
        /// 
        /// </remarks>
        [WebMethod]
        public string BookingTaxi_V2(KhachDat khachDat)
        {
            if (!isAuthentication)
            {
                maLoi = "E4";// lỗi không qua xác thực
            }
            if (maLoi == "E3" || maLoi == "E4")
            {
                return maLoi;
            }
            KhachDat model = new KhachDat();
            DateTime timeServer = model.GetTimerServer();
            if (string.IsNullOrEmpty(khachDat.TenKhachHang) || string.IsNullOrEmpty(khachDat.DiaChiDon)
                 || string.IsNullOrEmpty(khachDat.DiaChiTra) || string.IsNullOrEmpty(khachDat.SoDienThoai)
                 || string.IsNullOrEmpty(khachDat.FK_SystemBookID.ToString()))
            {
                return "E1";
            }
            if (khachDat.GioDon < timeServer || khachDat.SoLuongXe <= 0 || khachDat.FK_SystemBookID < 0 || khachDat.SoTien <= 0)
            {
                return "E2";
            }

            model.TenKhachHang = khachDat.TenKhachHang;
            model.DiaChiDon = khachDat.DiaChiDon;
            model.DiaChiTra = khachDat.DiaChiTra;
            model.SoDienThoai = khachDat.SoDienThoai;
            model.GioDon = khachDat.GioDon;
            model.GhiChu = khachDat.GhiChu;
            model.LoaiXe = khachDat.LoaiXe;
            model.SoLuongXe = khachDat.SoLuongXe;
            model.SoPhutBaoTruoc = khachDat.SoPhutBaoTruoc;
            model.SoTien = khachDat.SoTien;
            model.FK_SystemBookID = khachDat.FK_SystemBookID;
            model.SoKm = khachDat.SoKm;
            model.ThoiDiemBatDau = timeServer.Date;//đầu ngày
            model.ThoiDiemKetThuc = timeServer.AddDays(1).Date.AddSeconds(-1);//cuối ngày
            model.ThoiDiemTiepNhan = timeServer;
            model.NgayTrongTuanLapLai = "";
            model.CreatedDate = timeServer;
            model.UpdatedDate = timeServer;
            model.UpdatedDateKD = timeServer;

            try
            {
                return model.Insert().ToString();
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("[BookingTaxi_V2]", ex);
                return "F";
            }
        }

        /// <summary>
        /// hàm chèn cuốc khách đặt, Request call function AuthenticationServices
        /// </summary>
        /// <param name="tenKhachHang">Tên khách hàng</param>
        /// <param name="soDienThoai">Số điện thoại</param>
        /// <param name="diaChiDon"></param>
        /// <param name="diaChiTra"></param>
        /// <param name="soKm"></param>
        /// <param name="soTien"></param>
        /// <param name="loaiXe"></param>
        /// <param name="soLuongXe"></param>
        /// <param name="gioDon"></param>
        /// <param name="soPhutBaoTruoc"></param>
        /// <param name="ghiChu"></param>
        /// <param name="systemBookID">Mã hệ thống đặt cuốc</param>
        /// <returns></returns>
        /// 
        /// <remarks>
        /// Id  : Mã cuốc khách đặt nếu Insert thành công
        /// F  : Lỗi Insert không thành công
        /// E1 : Lỗi trong quá trình cập nhật thông tin vào DB
        /// E2 : Lỗi Convert dữ liệu
        /// E3 : Không đúng thông tin truy cập
        /// E4 : Lỗi chưa xác thực
        /// 
        /// </remarks>
        [WebMethod]
        public string BookingTaxi(string tenKhachHang, string soDienThoai, string diaChiDon, string diaChiTra, float soKm, int soTien,
             string loaiXe, int soLuongXe, DateTime gioDon, int soPhutBaoTruoc, string ghiChu, int systemBookID)
        {
            if (!isAuthentication)
            {
                if (maLoi != "E3")
                {
                    maLoi = "E4";// lỗi không qua xác thực
                }
            }
            if (maLoi == "E3" || maLoi == "E4")
            {
                return maLoi;
            }
            KhachDat model = new KhachDat();
            if (string.IsNullOrEmpty(tenKhachHang) || string.IsNullOrEmpty(diaChiDon)
                || string.IsNullOrEmpty(diaChiTra) || string.IsNullOrEmpty(soDienThoai)
                || string.IsNullOrEmpty(systemBookID.ToString()))
            {
                return "E1";
            }
            if (gioDon == null || soLuongXe <= 0 || soPhutBaoTruoc < 0 || systemBookID < 0 || soTien <= 0 || soKm <= 0)
            {
                return "E2";
            }
            DateTime timeServer = model.GetTimerServer();
            model.TenKhachHang = tenKhachHang;
            model.SoDienThoai = soDienThoai;
            model.DiaChiDon = diaChiDon;
            model.DiaChiTra = diaChiTra;
            model.SoKm = soKm;
            model.SoTien = soTien;
            model.LoaiXe = loaiXe;
            model.SoLuongXe = soLuongXe;
            model.GioDon = gioDon;
            model.SoPhutBaoTruoc = soPhutBaoTruoc;
            model.GhiChu = ghiChu;
            model.FK_SystemBookID = systemBookID;

            model.ThoiDiemBatDau = timeServer.Date;//đầu ngày
            model.ThoiDiemKetThuc = timeServer.AddDays(1).Date.AddSeconds(-1);//cuối ngày
            model.ThoiDiemTiepNhan = timeServer;
            model.NgayTrongTuanLapLai = "";
            model.CreatedDate = timeServer;
            model.UpdatedDate = timeServer;
            model.UpdatedDateKD = timeServer;
            try
            {
                return model.Insert().ToString();
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("[BookingTaxi_Insert]", ex);
                return "F";
            }
        }
        /// <summary>
        /// Cập nhật thông tin cuốc khách đặt, Request call function AuthenticationServices
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tenKhachHang"></param>
        /// <param name="soDienThoai"></param>
        /// <param name="diaChiDon"></param>
        /// <param name="diaChiTra"></param>
        /// <param name="soKm"></param>
        /// <param name="soTien"></param>
        /// <param name="loaiXe"></param>
        /// <param name="soLuongXe"></param>
        /// <param name="gioDon"></param>
        /// <param name="soPhutBaoTruoc"></param>
        /// <param name="ghiChu"></param>
        /// <param name="systemBookID"></param>
        /// <returns></returns>
        /// <remarks>
        /// 1  : Update thành công
        /// F  : Lỗi Update không thành công
        /// E1 : Lỗi trong quá trình cập nhật thông tin vào DB
        /// E2 : Lỗi Convert dữ liệu
        /// E3 : Không đúng thông tin truy cập
        /// E4 : Lỗi chưa xác thực
        /// 
        /// </remarks>
        [WebMethod]
        public string Update(int id, string tenKhachHang, string soDienThoai, string diaChiDon, string diaChiTra, float soKm, int soTien,
             string loaiXe, int soLuongXe, DateTime gioDon, int soPhutBaoTruoc, string ghiChu, int systemBookID)
        {
            if (!isAuthentication)
            {
                maLoi = "E4";// lỗi không qua xác thực
            }
            if (maLoi == "E3" || maLoi == "E4")
            {
                return maLoi;
            }
            KhachDat model = new KhachDat();
            if (string.IsNullOrEmpty(tenKhachHang) || string.IsNullOrEmpty(diaChiDon)
                || string.IsNullOrEmpty(diaChiTra) || string.IsNullOrEmpty(soDienThoai) || string.IsNullOrEmpty(systemBookID.ToString()))
            {
                return "E1";
            }
            if (gioDon == null || soLuongXe <= 0 || soPhutBaoTruoc < 0 || systemBookID < 0 || soTien <= 0 || soKm <= 0)
            {
                return "E2";
            }
            DateTime timeServer = model.GetTimerServer();
            model.PK_KhachDatID = id;
            model.TenKhachHang = tenKhachHang;
            model.SoDienThoai = soDienThoai;
            model.DiaChiDon = diaChiDon;
            model.DiaChiTra = diaChiTra;
            model.SoKm = soKm;
            model.SoTien = soTien;
            model.LoaiXe = loaiXe;
            model.SoLuongXe = soLuongXe;
            model.GioDon = gioDon;
            model.SoPhutBaoTruoc = soPhutBaoTruoc;
            model.GhiChu = ghiChu;
            model.FK_SystemBookID = systemBookID;
            model.UpdatedDate = timeServer;
            try
            {
                model.UpdateById();
                return "1";
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("[BookingTaxi_Update]", ex);
                return "F";
            }
        }

        /// <summary>
        /// Cập nhật khách đặt, Request call function AuthenticationServices
        /// </summary>
        /// <param name="khachDat"></param>
        /// <returns></returns>
        [WebMethod]
        public string Update_V2(KhachDat khachDat)
        {
            if (!isAuthentication)
            {
                maLoi = "E4";// lỗi không qua xác thực
            }
            if (maLoi == "E3" || maLoi == "E4")
            {
                return maLoi;
            }
            KhachDat model = new KhachDat();
            if (string.IsNullOrEmpty(khachDat.TenKhachHang) || string.IsNullOrEmpty(khachDat.DiaChiDon)
                || string.IsNullOrEmpty(khachDat.DiaChiTra) || string.IsNullOrEmpty(khachDat.SoDienThoai) || string.IsNullOrEmpty(khachDat.FK_SystemBookID.ToString()))
            {
                return "E1";
            }
            if (khachDat.GioDon == null || khachDat.SoLuongXe <= 0 || khachDat.SoPhutBaoTruoc < 0 || khachDat.FK_SystemBookID < 0 || khachDat.SoTien <= 0 || khachDat.SoKm <= 0)
            {
                return "E2";
            }
            DateTime timeServer = model.GetTimerServer();
            model.PK_KhachDatID = khachDat.PK_KhachDatID;
            model.TenKhachHang = khachDat.TenKhachHang;
            model.SoDienThoai = khachDat.SoDienThoai;
            model.DiaChiDon = khachDat.DiaChiDon;
            model.DiaChiTra = khachDat.DiaChiTra;
            model.SoKm = khachDat.SoKm;
            model.SoTien = khachDat.SoTien;
            model.LoaiXe = khachDat.LoaiXe;
            model.SoLuongXe = khachDat.SoLuongXe;
            model.GioDon = khachDat.GioDon;
            model.SoPhutBaoTruoc = khachDat.SoPhutBaoTruoc;
            model.GhiChu = khachDat.GhiChu;
            model.FK_SystemBookID = khachDat.FK_SystemBookID;
            model.UpdatedDate = timeServer;
            try
            {
                model.UpdateById();
                return "1";
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("[BookingTaxi_Update]", ex);
                return "F";
            }
        }
    }
}
