using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
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
            ValidateSuccess = 0,            // Form khong phai
            NhapChinhXacXe = 1,            // Bạn phải nhập chính xác số hiệu xe.Nếu số hiệu xe thiếu, bạn báo quản trị bổ sung.
            NhapXeDonThuocXeNhan = 2,        // Bạn phải nhập xe đón thuộc xe nhận.
            NhapKenh = 3,                   // Bạn phải nhập kênh (vùng) theo quy định.
            NhapHoan = 4,                   // Bạn không thể nhập hoãn, khi điện thoại chưa báo hoãn.
            NhapTruot = 5,                  // Bạn không thể nhập trượt nếu chưa có xe nhận.
            NhapXinLoi = 6,                 // Bạn không thể chọn không xe xin lỗi khi đã có xe nhận.
            NhapXeNhan = 7,                 // Bạn vừa nhập xe nhận không thuộc xe đón.
            XeNhanDaDonOCuocGoiKhac = 8,    // Bạn vừa nhập xe nhận không thuộc xe đón.
            MoiKhachChuaCoXeDon = 9,          // Bạn mời khách chưa có xe đón.
            KhongTimThayXe = 10,
            PhaiNhapDiaChi = 11,
            XeTimKhongDungDinhDang = 12,
            XeNhanKhongDungDinhDang = 13
        }

        public const string MSG_VALIDATESUCCESS = "";
        public  const string MSG_1_NHAPCHINHXACXE = "Bạn phải nhập chính xác số hiệu xe.Bạn báo quản trị bổ sung xe nếu thiếu.";
        public  const string MSG_2_NHAPXEDONTHUOCXENHAN = "Trùng lặp xe Nhận/đón.";
        public  const string MSG_3_NHAPKENH = "Bạn phải nhập kênh (vùng) theo quy định.";
        public  const string MSG_4_NHAPHOAN = "Bạn không thể nhập hoãn, khi điện thoại chưa báo hoãn.";
        public  const string MSG_5_NHAPTRUOT = "Bạn không thể nhập trượt nếu chưa có xe nhận.";
        public  const string MSG_6_NHAPXINLOI = "Bạn không thể chọn không xe xin lỗi khi đã có xe nhận.";
        public  const string MSG_7_MANHINHKONGCOXEDECU = "Không tồn tại xe đề cử. Bạn phải chọn ra xe đề cử.";
        public  const string MSG_9_MoiKhachKhongXeDon = "[Lệnh mời khách] Cuội gọi phải là cuộc gọi taxi. Và đã có xe nhận.";
        public const string MSG_10_KhongTimThayXe = "Không tìm thấy xe trên bản đồ.";
        public const string MSG_11_PhaiNhapDiaChi = "Bạn phải nhập địa chỉ.";
        public const string MSG_12_XeTimKhongDungDinhDang = "Số xe bạn tìm không đúng định dạng.";
        public const string MSG_13_XeNhanKhongDungDinhDang = "Xe nhận đang nhập sai định dạng chuỗi. Hãy nhập theo: 111.123";

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

        public static readonly bool ConfigEnVang = Global.MoHinh == MoHinh.TD_DT_LaiXe && !Global.ChoPhepDienThoaiNhapXe;

        public static readonly Dictionary<short, string> MessageCodes = new Dictionary<short, string>()
        {
            { MA_LENH_MOIKHACH, "Mời khách" },
            { MA_LENH_XINSODT, "Xin số ĐT" },
            { MA_LENH_DADON, "Đã đón"},
            { 2397, "Trượt cuốc"},
            { 2398, "Mất kết nối"},
            { MA_LENH_DAKETTHUC, "Kết thúc cuốc"}
        };

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
        public static void OpenFormInfo(MessageConfirm message, frmDieuHanhBoDamNEW_V3 parent)
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


    }
}
