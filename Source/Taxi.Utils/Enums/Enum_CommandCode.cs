using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Common.EnumUtility;

namespace Taxi.Utils.Enums
{
    /// <summary>
    /// Sử dụng trong phần cấu hình lệnh T_TaxiOperation_Command
    /// <code>typeof(Enum_CommandCode).GetField(Enum_CommandCode.GiucXe.ToString()).GetAttribute<Common.EnumUtility.EnumItemAttribute>()</code>
    /// </summary>
    public enum Enum_CommandCode
    {
        [EnumItem("Lệnh hệ thống", ValueEnum = "SYSTEM")]
        System = 1000,
        [EnumItem("Mặc Định", ValueEnum = "DEFAULT")]
        Default = 0,
        [EnumItem("[ĐTV]Đã Mời", ValueEnum = "DAMOIDT")]
        DTV_DaMoi = 1,
        [EnumItem("[ĐTV]Gặp Xe", ValueEnum = "GAPXE")]
        DTV_GapXe = 2,
        [EnumItem("[ĐTV]Đã Xin Lỗi", ValueEnum = "DAXINLOI")]
        DTV_DaXinLoi = 3,
        [EnumItem("[ĐTV]Hủy xe/Hoãn", ValueEnum = "HUYHOAN")]
        DTV_HuyHoan = 4,
        [EnumItem("[ĐTV]Chuyển điều app", ValueEnum = "CHUYENAPP")]
        DTV_ChuyenApp = 5,
        [EnumItem("[ĐTV]Chuyển điều đàm", ValueEnum = "CHUYENDIEUDAM")]
        DTV_ChuyenDam = 6,
        [EnumItem("[ĐTV]Không liên lạc được", ValueEnum = "KHONGLIENLACDUOC")]
        DTV_KoLienLacDuoc = 7,
        [EnumItem("[ĐTV]Hoàn Thành", ValueEnum = "HOANTHANH")]
        DTV_HoanThanh = 8,
        [EnumItem("[ĐTV]Trượt", ValueEnum = "TRUOTCHUA")]
        DTV_TruotChua = 9,
        [EnumItem("[ĐTV]Cho Số", ValueEnum = "CHOSO")]
        DTV_ChoSoDT = 10,
        [EnumItem("[ĐTV]Không Cho Số", ValueEnum = "KOCHOSO")]
        DTV_KoChoSoDT = 11,
        [EnumItem("[TĐV]Hoãn Cuốc", ValueEnum = "HOANCUOC")]
        TDV_HoanCuoc = 12,
        [EnumItem("[TĐV]Trượt Cuốc", ValueEnum = "TRUOTCUOC")]
        TDV_TruoTCuoc = 13,
        [EnumItem("[TĐV]Mời Khách", ValueEnum = "MOIKHACH")]
        TDV_MoiKhach = 14,
        [EnumItem("[TĐV]Không xe xin lỗi khách", ValueEnum = "KHONGXEXL")]
        TDV_KhongXeXL = 15,
        [EnumItem("[TĐV]Không xe lần 1", ValueEnum = "KHONGXE1")]
        TDV_KoXeLan1 = 16,
        [EnumItem("[ĐTV]Không thấy xe", ValueEnum = "KHONGTHAYXE")]
        DTV_KhongThayXe = 17,
        [EnumItem("[ĐTV]Giục Xe", ValueEnum = "GIUCXE")]
        DTV_GiucXe = 18,
        [EnumItem("[ĐTV]Hiển thị số trên applx", ValueEnum = "SHOWPHONENUMBER")]
        DTV_ShowPhoneNumber = 19,
        [EnumItem("Hoãn, điều đàm", ValueEnum = "HOAN_CHUYENDAM")]
        DTV_HoanChuyenDam = 20,
        [EnumItem("[ĐTV]Gửi SMS Xin Lỗi", ValueEnum = "SMSDAXINLOI")]
        DTV_SMSDaXinLoi = 21,
        [EnumItem("[ĐTV]Gửi SMS cuốc đường dài", ValueEnum = "SMSDTVCuocDuongDai")]
        DTV_SMSCuocDuongDai = 22,
        [EnumItem("[TĐV]Gửi SMS cuốc đường dài", ValueEnum = "SMSTDVCuocDuongDai")]
        TDV_SMSCuocDuongDai = 23,
        [EnumItem("[TĐV]Gửi SMS thông tin KH", ValueEnum = "SMSTDVCustomerInfo")]
        TDV_SMSCustomerInfo = 24,
        [EnumItem("[TĐV]Gửi SMS báo khách chờ ít phút", ValueEnum = "SMSVinaTDVCatchedUser")]
        TDV_SMSVinaTDVCatchedUser = 211,

        //[EnumItem("Nhầm Khách", ValueEnum = "NHAMKHACH")]
        //NhamKhach = 2,
        //[EnumItem("", ValueEnum = "GIUKHACH")]
        //GiuKhach = 4,
        //[EnumItem("", ValueEnum = "HOIDC")]
        //HoiLaiDiaChi = 5,
        //[EnumItem("", ValueEnum = "CHUYENKENH")]
        //ChuyenKenh = 6,
        //[EnumItem("", ValueEnum = "KIEMTRAKHACH")]
        //KiemTraKhach = 9,
        //[EnumItem("", ValueEnum = "KHONGXEXLDT")]
        //KhongXeXLDT = 12,
        //[EnumItem("", ValueEnum = "MAYBAN")]
        //MayBan = 13,
        //[EnumItem("", ValueEnum = "TUCHOI")]
        //TuChoi = 14,
        //[EnumItem("", ValueEnum = "KHONGNGHEMAY")]
        //KhongNgheMay = 16,
        //[EnumItem("", ValueEnum = "DAMOILAN2")]
        //DaMoiLan2 = 17,
        //[EnumItem("", ValueEnum = "KHACHDAT")]
        //KhachDat = 21,
        //[EnumItem("", ValueEnum = "GIUROI")]
        //GiuRoi = "",
        //[EnumItem("", ValueEnum = "MOILAN2")]
        //MoiLan2 = "",
        //[EnumItem("", ValueEnum = "RADAUNGO")]
        //RaDauNgo = "",
        //[EnumItem("", ValueEnum = "MATKETNOI")]
        //MatKetNoi = "",
        //[EnumItem("", ValueEnum = "GOICHOKHACHKTX")]
        //GoiChoKhachKTX = "",
        //[EnumItem("", ValueEnum = "KOXENHAN")]
        //KoXeNhan = "",
        //[EnumItem("", ValueEnum = "APPDIEUDAM")]
        //AppDieuDam = "",
        //[EnumItem("", ValueEnum = "APPKHONGXE")]
        //AppKhongXe = "",
        //[EnumItem("", ValueEnum = "DANGRA")]
        //DangRa = "",
        //[EnumItem("", ValueEnum = "CHOKHACH")]
        //ChoKhach = "",
        //[EnumItem("", ValueEnum = "DOIXE")]
        //DoiXe = "",
        //[EnumItem("", ValueEnum = "DANGGOI")]
        //DangGoi = "",
        //[EnumItem("", ValueEnum = "DANGGOI_TD")]
        //DangGoiTD = "",
        //[EnumItem("", ValueEnum = "KHONGTRUCTIEP")]
        //KoTrucTiep = "",
        //[EnumItem("", ValueEnum = "KHONGNOIGI")]
        //KoNoiGi = "",
        //[EnumItem("", ValueEnum = "TIEPTHIXE")]
        //TiepThiXe = "",
        //[EnumItem("", ValueEnum = "THUEBAO")]
        //ThueBao = "",
        //[EnumItem("", ValueEnum = "THAYXE")]
        //ThayXe = "",
        //[EnumItem("", ValueEnum = "HIENTHISO")]
        //HienThiSoDT = "",
    }
}
