using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Data.EnVang;
using Taxi.GUI;
using Taxi.Utils;

namespace TaxiApplication
{
    /// <summary>
    /// Quản lý chung cho phần Én Vàng
    /// </summary>
    /// <Modified>
    /// Name     Date         Comments
    /// LuanBH  8/10/2015   created
    /// </Modified>
    public static class EnVangManagement
    {
        public enum BangMaValidate
        {
            ValidateSuccess = 0,
            NhapThongTinDiaChi = 1,    // Bạn phải nhập thông tin vào trường địa chỉ.
            NhapMotLoaiCuocGoi = 2,    // Bạn phải chọn một loại cuộc gọi.
            NhapSoLuongXe = 3,    // Bạn phải nhập số lượng xe.
            NhapKenh = 4,    // Bạn phải nhập kênh (vùng) theo quy định.
            ChonKhongXeXinLoiKhach = 5, // Bạn không thể chọn không xe xin lỗi khách, khi có xe nhận.
            Msg6_KhongTimThayDCBanDo = 6,
            Msg7_ChuaNhapKenh = 7,
            Msg8_TaiBanDo = 8,
            Msg9_ChonKenhTK = 9,
            Msg10_ChonLoaiXe = 10,
            NhapChinhXacXe = 13,
            NhapXeDonThuocXeNhan = 14,
            DienThoaiDaHuy = 15,
            /// <summary>
            /// Đã giải quyết là cuốc không có xe nhận.
            /// </summary>
            DaGiaiQuyet = 16,
            /// <summary>
            /// Xe đón không thuộc DS xe nhận
            /// </summary>
            XeNhanKhongDungDinhDang = 17,
            KhongTimThayXe = 18,
            PhaiNhapDiaChi = 19,
            XeTimKhongDungDinhDang = 20,
            CoXeDangNghi = 21
        }

        public const string MSG_VALIDATESUCCESS = "";
        public const string MSG_1_NHAPTHONGTINDIACHI = "Bạn phải nhập thông tin vào trường địa chỉ.";
        public const string MSG_2_NHAPTHONGTINLOAICUOCGOI = "Bạn phải chọn một loại cuộc gọi.";
        public const string MSG_3_NHAPSOLUONGXE = "Bạn phải nhập số lượng xe.";
        public const string MSG_4_NHAPKENH = "Bạn phải nhập kênh (vùng) theo quy định. Kiểm tra lại kênh (vùng) cấu hình.";
        public const string MSG_5_CHONKHONGXE = "Bạn không thể chọn không xe xin lỗi khách, khi có xe nhận.";
        public const string MSG_6_BANDO = "Không tìm thấy địa chỉ này trên bản đồ";
        public const string MSG_7_CHUANHAPKENH = "Hãy nhập số kênh";
        public const string MSG_8_TAIBANDO = "Lỗi tải bản đồ";
        public const string MSG_9_CHONKENHTK = "Bạn hãy chọn kênh cần tìm kiếm";
        public const string MSG_10_BANDO = "Lỗi trong quá trình xử lý lấy tọa độ trên bản đồ";
        public const string MSG_11_BANDO = "Lỗi vẽ xe đề cử lên bản đồ";
        public const string MSG_12_BANDO = "Lỗi vẽ xe nhận lên bản đồ";
        public const string MSG_12_CHONLOAIXE = "Chưa chọn loại xe";
        public const string MSG_13_NHAPCHINHXACXE = "Bạn phải nhập chính xác số hiệu xe.Bạn báo quản trị bổ sung xe nếu thiếu.";
        public const string MSG_14_NHAPXEDONTHUOCXENHAN = "Trùng lặp xe Nhận/đến điểm/đón.";
        public const string MSG_15_DienThoaiDaHuy = "Khách hàng đã hủy cuốc.";
        public const string MSG_16_DaGiaiQuyet = "Đã giải quyết là cuốc không có xe nhận.";
        public const string MSG_17_XeNhanKhongDungDinhDang = "Xe nhận đang nhập sai định dạng chuỗi. Hãy nhập theo: 111.123";
        public const string MSG_18_KhongTimThayXe = "Không tìm thấy xe trên bản đồ.";
        public const string MSG_19_PhaiNhapDiaChi = "Bạn phải nhập địa chỉ.";
        public const string MSG_20_XeTimKhongDungDinhDang = "Số xe bạn tìm không đúng định dạng.";

        public const string LENH_DAMOI = "Đã mời";
        public const string LENH_DAMOI2 = "Đã mời lần 2";
        public const string LENH_GAPXE = "Gặp xe";
        public const string LENH_MAYBAN = "Máy bận";
        public const string LENH_KHONGLIENLACDUOC = "Từ chối";
        public const string LENH_HUYXE = "Hủy xe/Hoãn";
        public const string LENH_KOTRUCTIEP = "Ko trực tiếp";
        public const string LENH_KOTHAYXE = "Ko thấy xe";
        public const string LENH_KHONGNGHEMAY = "Ko nghe máy";
        public const string LENH_KHONGNOIGI = "Ko nói gì";
        public const string LENH_KHONGXE = "Ko xe xin lỗi khách";
        public const string LENH_MOIKHACH = "Mời khách";
        public const string LENH_HOILAIDIACHI = "Hỏi lại địa chỉ";
        public const string LENH_KHACHDAT = "KHÁCH ĐẶT";
        public const string LENH_DAXINLOI = "Đã xin lỗi khách";
        public const string LENH_CHO5PHUT = "Chờ 5 phút";
        public const string LENH_DOIXE = "Đổi xe 7C/4C";
        public const string LENH_G_GIUCXE = "Giục xe";
        public const string LENH_DANGGOI = "Đang gọi...";
        public const string LENH_CHOSODT = "Cho số";
        public const string LENH_TRUOTCHUA = "Trượt";
        public const string LENH_DADON = "Đã đón";
        public const string LENH_6_KIENTRAKHACH = "Kiểm tra khách";
        public const string LENH_7_MOIKHACHLAN2 = "Mời lần 2";
        public const string LENH_7_KhongXeXinLoiKhach = "Ko xe đã xl khách";
        public const string LENH_8_RADAUNGO = "Ra đầu ngõ";
        public const string LENH_9_TIEPTHIXEKHAC = "Tiếp thị 7C/4C";
        public const string LENH_MATKN = "Mất kết nối";
        public const string LENH_KTX_GoiChoKhach = "Gọi cho khách,không thấy xe";
        public const string LENH_XINSODT = "Xin số ĐT";
        public const string LENH_KHONGXENHAN = "Không có xe nhận";
        public const string LENH_LAIXEHUY = "Hủy";
        public const string LENH_TRUOTKHACH = "Trượt cuốc";

        public const short MA_LENH_MOIKHACH = 2303;
        public const short MA_LENH_XINSODT = 2344;
        public const short MA_LENH_DAKETTHUC = 2345;
        public const short MA_LENH_DADON = 2346;
        public const short MA_LENH_LAIXETRUOTCUOC = 2397;
        public const short MA_LENH_XINDIEMDO = 2340;

        public static readonly Dictionary<short, string> MessageCodes = new Dictionary<short, string>()
        {
            { MA_LENH_MOIKHACH, "Mời khách" },
            { MA_LENH_XINSODT, "Xin số ĐT" },
            { MA_LENH_DADON, "Đã đón"},
            { MA_LENH_LAIXETRUOTCUOC, "Trượt cuốc"},
            { 2398, "Mất kết nối"},
            { MA_LENH_DAKETTHUC, "Kết thúc cuốc"},
            { MA_LENH_XINDIEMDO, "Xin điểm đỗ"}
        };

        private static readonly List<int> MessageConfirmChoNhapXe = new List<int>()
        {
            MA_LENH_DAKETTHUC, MA_LENH_XINDIEMDO
        };

        private static readonly List<int> MessageConfirmKoChoNhapXe = new List<int>()
        {
            MA_LENH_XINDIEMDO
        };

        /// <summary>
        /// Choes the phep hien message confirm.
        /// </summary>
        /// <param name="maMessage">The ma message.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/27/2015   created
        /// </Modified>
        public static bool ChoPhepHienMessageConfirm(int maMessage)
        {
            if (Global.ChoPhepDienThoaiNhapXe)
                return MessageConfirmChoNhapXe.IndexOf(maMessage) > -1;
            else
                return MessageConfirmKoChoNhapXe.IndexOf(maMessage) > -1;
        }

        /// <summary>
        /// Validate trường cho phép nhập nhiều số hiệu xe
        /// </summary>
        /// <param name="cacSoHieuXe">The cac so hieu xe.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/10/2015   created
        /// </Modified>
        public static bool ValidateNhieuSoHieuXe(string cacSoHieuXe)
        {
            Regex RegexNhieuSoHieuXe = new Regex("^(([0-9A-z])*[.]*)+$");
            return RegexNhieuSoHieuXe.IsMatch(cacSoHieuXe);
        }

        /// <summary>
        /// Validate 1 số hiệu xe
        /// </summary>
        /// <param name="soHieuXe">The so hieu xe.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/10/2015   created
        /// </Modified>
        public static bool ValidateSoHieuXe(string soHieuXe)
        {
            Regex RegexSoHieuXe = new Regex("^(([0-9A-z])*)+$");
            return RegexSoHieuXe.IsMatch(soHieuXe);
        }

        /// <summary>
        /// Kiểm tra xem phần tử trong danh sách nhập có thuộc danh sách gốc không
        /// </summary>
        /// <param name="dsKiemTra">The ds kiem tra.</param>
        /// <param name="dsGoc">The ds goc.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  7/21/2015   created
        /// </Modified>
        public static bool KiemTraPTDSThuocDSKhac(string dsKiemTraStr, string dsGocStr)
        {
            bool ret = true;
            if (string.IsNullOrEmpty(dsKiemTraStr)) return true;
            if (string.IsNullOrEmpty(dsGocStr)) return false;
            string[] dsKiemTra = dsKiemTraStr.Split(".".ToCharArray());
            string[] dsGoc = dsGocStr.Split(".".ToCharArray());
            if (dsKiemTra.Length <= 0 || dsGoc.Length <= 0) return true;
            for (int i = 0; i < dsKiemTra.Length; i++)
            {
                bool timThayXe = false;
                foreach (string xe in dsGoc)
                {
                    if (xe == dsKiemTra[i])
                    {
                        timThayXe = true;
                        break; // thoát khỏi vòng ds xe
                    }
                }
                ret &= timThayXe;
                if (!ret) { break; }  // có một xe không thuộc ds
            }
            return ret;
        }

        /// <summary>
        /// Kiểm tra xem phần tử trong danh sách nhập có thuộc danh sách gốc không
        /// </summary>
        /// <param name="dsKiemTra">The ds kiem tra.</param>
        /// <param name="dsGoc">The ds goc.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  7/21/2015   created
        /// </Modified>
        public static bool KiemTraPTDSThuocDSKhac(string dsKiemTraStr, List<string> dsGoc)
        {
            bool ret = true;
            if (string.IsNullOrEmpty(dsKiemTraStr)) return true;
            if (dsGoc == null || dsGoc.Count <= 0) return false;
            string[] dsKiemTra = dsKiemTraStr.Split(".".ToCharArray());
            for (int i = 0; i < dsKiemTra.Length; i++)
            {
                bool timThayXe = false;
                foreach (string xe in dsGoc)
                {
                    if (xe == dsKiemTra[i])
                    {
                        timThayXe = true;
                        break; // thoát khỏi vòng ds xe
                    }
                }
                ret &= timThayXe;
                if (!ret) { break; }  // có một xe không thuộc ds
            }
            return ret;
        }

        /// <summary>
        /// Mở cửa sổ thông báo
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="parent">The parent.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/10/2015   created
        /// </Modified>
        public static void OpenFormInfo(MessageConfirm message, frmDieuHanhDienThoaiNEWCP_V4 parent)
        {
            frmInfo frmThongTin = new frmInfo();
            string frmCaption = string.Empty;
            if (MessageCodes.ContainsKey(message.MaMessage))
                frmCaption = MessageCodes[message.MaMessage];
            bool isButtonVisible = true;
            bool doUseTimer = true;
            switch(message.MaMessage)
            {
                case MA_LENH_DADON:
                    isButtonVisible = false;
                    break;
                case MA_LENH_DAKETTHUC:
                    doUseTimer = false;
                    break;
                default:
                    break;
            }
            frmThongTin.SetModel(message, frmCaption, parent, isButtonVisible, doUseTimer);
            frmThongTin.Show();
        }

        /// <summary>
        /// Kiểm tra xe nghỉ
        /// </summary>
        /// <param name="privateCodes">The private codes.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/28/2015   created
        /// </Modified>
        public static string CheckRestingVehicle(string privateCodes)
        {
            var restingVehicles = CuocGoi.EnVangVip_sp_GetRestingVehicle(privateCodes);
            if (!string.IsNullOrEmpty(restingVehicles))
            {
                return string.Format("{0} đang nghỉ. Xin chọn xe khác.", restingVehicles);
            }
            return string.Empty;
        }
    }
}
