using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Taxi.Data;
using System.Drawing;
using Taxi.Utils;
using Taxi.Common.Extender;
using Taxi.Common.DbBase.Attributes;
using System.Reflection;
using Taxi.Common.ShSql;
using System.ComponentModel;
namespace Taxi.Business
{
    public class EnumConfigCommonAttribute : Attribute
    {
        public EnumConfigCommonAttribute(Enum_Config_Common enumItem)
        {
            this.EnumItem = enumItem;
        }
        public Enum_Config_Common EnumItem { get; set; }
        public Type ConvertType { get; set; }
        public Type @This { get; set; }
        public object ValueDefault { get; set; }
    }
    public class CommonPropertyInfo
    {
        public EnumConfigCommonAttribute PropertyAtt { get; set; }
        public string Name { set; get; }
        public Type PropertyType { set; get; }
    }
    [TableInfo(TableName = "Config_Common")]
    public class ConfigCommonEntity : DbEntityBase<ConfigCommonEntity>
    {      
        [Field(IsKey = true, IsIdentity = true)]
        public int Id { get; set; }
        [Field]
        public string Name { get; set; }
        [Field]
        public string HasValue { get; set; }
        [Field]
        public string Description { get; set; }
        [Field]
        public DateTime LastUpdate { get; set; }
    }

    public class Config_Common 
    {
        #region ==== Field ====
        public Enum_Config_Common Enum { get { return (Enum_Config_Common)Id; } }

        [Field(IsKey = true, IsIdentity = true)]
        public int Id { get; set; }
        [Field]
        public string Name { get; set; }
        [Field]
        public string HasValue { get; set; }
        [Field]
        public string Description { get; set; }
        [Field]
        public DateTime LastUpdate { get; set; }

        #endregion

        #region ==== Propertion =====
        /// <summary>
        /// Cấu hình chung
        /// </summary>
        public static Dictionary<Enum_Config_Common, string> G_DictConfig_Common;
        /// <summary>
        /// 8 : Tên màu nền Lệnh Mời của lưới bên phải. Chỉ nhận tên màu (Red, Blue,Green,...)
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.LuoiCuocGoi_MauNen_LenhMoi_Right)]
        public static Color LuoiCuocGoi_MauNen_LenhMoi_Right { get; set; }

        /// <summary>
        /// 7 : Tên màu nền Lệnh Mời. Chỉ nhận tên màu (Red, Blue,Green,...)
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.LuoiCuocGoi_MauNen_LenhMoi)]
        public static Color LuoiCuocGoi_MauNen_LenhMoi { get; set; }

        /// <summary>
        /// 6 : Hiển thị màu nền của lệnh mời khách
        /// = 1: chỉ đổi ở ô Lệnh
        /// = 2: đổi màu ở cả dòng
        /// ngược lại thì ko đổi màu
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.LuoiCuocGoi_HienThiMauNen_LenhMoi)]
        public static string LuoiCuocGoi_HienThiMauNen_LenhMoi { get; set; }

        /// <summary>
        /// 13 : Hiển thị màu nền của lệnh mời khách(Lưới bên phải
        /// = 1: chỉ đổi ở ô Lệnh
        /// = 2: đổi màu ở cả dòng
        /// ngược lại thì ko đổi màu
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.LuoiCuocGoi_HienThiMauNen_LenhMoi_Right)]
        public static string LuoiCuocGoi_HienThiMauNen_LenhMoi_Right { get; set; }

        /// <summary>
        /// 5 : Hiển thị màu nền của Loại xe ở lưới cuộc gọi
        /// </summary>     
        private static string[] LuoiCuocGoi_MauNenLoaiXe;
        public static string[] LuoiCuocGoi_MauNen_LoaiXe
        {
            get 
            {
                return LuoiCuocGoi_MauNenLoaiXe ?? (LuoiCuocGoi_MauNenLoaiXe = _LuoiCuocGoi_MauNen_LoaiXe.Split(';'));
            }
            set { LuoiCuocGoi_MauNenLoaiXe = value; }
        }
        [EnumConfigCommon(Enum_Config_Common.LuoiCuocGoi_MauNen_LoaiXe)]
        public static string _LuoiCuocGoi_MauNen_LoaiXe { get; set; }
        /// <summary>
        /// 1 : Font size của lưới hiển thị cuộc gọi bên tiếp nhận
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.LuoiCuocGoi_FontSize_TiepNhan, ValueDefault = 8)]
        public static int LuoiCuocGoi_FontSize_TiepNhan { get; set; }

        /// <summary>
        /// 4 : Font size của lưới tiếp nhận bên phải
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.LuoiCuocGoi_FontSize_TiepNhan_Right, ValueDefault = 8)]
        public static int LuoiCuocGoi_FontSize_TiepNhan_Right { get; set; }
        /// <summary>
        /// 9 : Độ cao của dòng (lưới cuộc gọi tiếp nhận)
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.LuoiCuocGoi_RowHeight_TiepNhan, ValueDefault = 20)]
        public static int LuoiCuocGoi_RowHeight_TiepNhan { get; set; }
        /// <summary>
        /// 10 : Độ cao của dòng (lưới cuộc gọi tiếp nhận bên phải)
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.LuoiCuocGoi_RowHeight_TiepNhan_Right, ValueDefault = 20)]
        public static int LuoiCuocGoi_RowHeight_TiepNhan_Right { get; set; }
        /// <summary>
        /// 11 : Độ cao của dòng (lưới cuộc gọi điều xe bên tổng đài)
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.LuoiCuocGoi_RowHeight_TongDai)]
        public static int LuoiCuocGoi_RowHeight_TongDai { get; set; }
        /// <summary>
        /// 12 : Font chữ lưới cuộc gọi-Tổng đài
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.LuoiCuocGoi_FontSize_TongDai)]
        public static int LuoiCuocGoi_FontSize_TongDai { get; set; }

        /// <summary>
        /// 3 : Có hiển thị Popup cuộc gọi hay không
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.HienThiPopup)]
        public static bool HienThiPopup { get; set; }
        /// <summary>
        /// 2 : Không cho phép nhập xe nhận trùng ở 2 điểm
        /// 0 : Không cảnh báo
        /// 1 : Có cảnh báo nhưng không cho phép nhập
        /// 2 : Có cảnh báo nhưng vẫn cho nhập
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.TongDai_HienThiCanhBao_NhapTrungXeNhan)]
        public static int TongDai_HienThiCanhBao_NhapTrungXeNhan { get; set; }
        /// <summary>
        /// 14 : Cảnh báo xe đón không trùng xe nhận
        /// Hiển thị cảnh báo nhập trùng xe nhận
        /// 0 : Không cảnh báo
        /// 1 : Có cảnh báo nhưng không cho phép nhập
        /// 2 : Có cảnh báo nhưng vẫn cho nhập
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.TongDai_HienThiCanhBao_XeDonTrungXeNhan)]
        public static int TongDai_HienThiCanhBao_XeDonTrungXeNhan { get; set; }
        /// <summary>
        /// 15:cuốc gọi thường không xe nhân thì đưa lên đầu.
        /// =0:Không thực hiện.
        /// =n:sau n phút chưa có xe nhận thì đưa lên đầu.
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.LuoiCuocGoi_CuocGoi_HienThiLenDauKhongXeNhan)]
        public static int LuoiCuocGoi_CuocGoi_HienThiLenDauKhongXeNhan { get; set; }
        /// <summary>
        /// 16:cuốc Staxi không xe nhân thì đưa lên đầu.
        /// =0:Không thực hiện.
        /// =n:sau n phút chưa có xe nhận thì đưa lên đầu.
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.LuoiCuocGoi_Staxi_HienThiLenDauKhongXeNhan)]
        public static int LuoiCuocGoi_Staxi_HienThiLenDauKhongXeNhan { get; set; }
        /// <summary>
        /// 17.Hiển thị xe đề cử trên bản đồ mini
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.BanDoMini_HienThiXeDeCu)]
        public static bool BanDoMini_HienThiXeDeCu { get; set; }

        /// <summary>
        /// 18.Hiển thị xe nhận trên bản đồ mini
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.BanDoMini_HienThiXeNhan)]
        public static bool BanDoMini_HienThiXeNhan { get; set; }
        /// <summary>
        /// 19.Màu nền cuốc chưa xử lý.
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.Grid_CuocChuaXuLy_BackGround)]
        public static Color Grid_CuocChuaXuLy_BackGround { get; set; }
        /// <summary>
        /// 20.Cho phép kết thúc cuốc không xe trước khi có lệnh không xe xl khách của tổng đài
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DienThoai_ChoPhepKetThucKhongXeTruoc)]
        public static int DienThoai_ChoPhepKetThucKhongXeTruoc { get; set; }
        /// <summary>
        /// 21.Màu nền lưới cuốc gọi
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.TongDai_MauNen_LuoiCuocGoi)]
        public static Color TongDai_MauNen_LuoiCuocGoi { get; set; }
        /// <summary>
        /// 22.Check xe vi phạm lỗi.
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.TongDai_CheckXeViPham)]
        public static bool TongDai_CheckXeViPham { get; set; }
        /// <summary>
        /// 23.Đăng nhập nhiều máy trên 1 tài khoản.
        /// 1:cho phép.
        /// 0:không cho phép.
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DangNhapNhieuMay)]
        public static bool DangNhapNhieuMay { get; set; }
        /// <summary>
        /// 24.Màu nền cuốc gọi hỏi đàm.
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.Grid_CuocHoiDam_BackGround)]
        public static Color Grid_CuocHoiDam_BackGround { get; set; }
        /// <summary>
        /// 25.lấy lịch sử cuốc khách theo số điện thoại
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DienThoai_LayLichSuCuoc)]
        public static int DienThoai_LayLichSuCuoc { get; set; }
        /// <summary>
        /// 26.Ẩn thông báo hoãn cuốc.
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.TongDai_AnThongBaoKhiHoanCuoc)]
        public static bool TongDai_AnThongBaoKhiHoanCuoc { get; set; }
        /// <summary>
        ///  27.Sử dung bàn cờ trong tổng đài.
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.TongDai_BanCo)]
        public static bool TongDai_BanCo { get; set; }

        /// <summary>
        /// 28.Chèn cuốc Hoa Hồng
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.ChenCuoc_HoaHong)]
        public static bool ChenCuoc_HoaHong { get; set; }
        /// <summary>
        /// 29.Tên cột trên lưới của Trường Ghi chú tổng đài
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.TongDai_TenCotGhiChuTongDai)]
        public static string TongDai_TenCotGhiChuTongDai { get; set; }
        /// <summary>
        /// 30.Lấy địa chỉ đón của cuốc lịch sử
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DienThoai_LayDiaChiLichSu)]
        public static bool DienThoai_LayDiaChiLichSu { get; set; }
        /// <summary>
        /// 31.Chuyển các cuốc gọi gần cuốc gọi lại.
        /// </summary>
        /// <value>
        /// <c>true</c> if [chuyen cac cuoc goi gan cuoc goi lai]; otherwise, <c>false</c>.
        /// </value>
        /// <Modified>
        /// Name     Date         Comments
        /// HauNV  21/09/2015   created
        /// </Modified>
        [EnumConfigCommon(Enum_Config_Common.TongDai_ChuyenCacCuocGoiGanCuocGoiLai)]
        public static bool TongDai_ChuyenCacCuocGoiGanCuocGoiLai { get; set; }
        /// <summary>
        /// 69.DTV Chuyển các cuốc gọi gần cuốc gọi lại
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DienThoai_ChuyenCacCuocGoiGanCuocGoiLai)]
        public static bool DienThoai_ChuyenCacCuocGoiGanCuocGoiLai { get; set; }
        /// <summary>
        /// 32.Gộp line cần thì nhấn gộp line.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [gop line]; otherwise, <c>false</c>.
        /// </value>
        /// <Modified>
        /// Name     Date         Comments
        /// HauNV  22/09/2015   created
        /// </Modified>
        [EnumConfigCommon(Enum_Config_Common.GopLine)]
        public static bool GopLine { get; set; }

        /// <summary>
        /// 33. Lấy thông tin ghi chú của KH
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.GetThongTinGhiChuKH)]
        public static bool GetThongTinGhiChuKH { get; set; }

        /// <summary>
        /// 37. Server tổng đài siemens
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.TongDai_ServerSiemens_Address)]
        public static string TongDai_ServerSiemens_Address { get; set; }
        /// <summary>
        /// 44.Cấu hình Điều app
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DienThoai_DieuTuDong)]
        public static bool DienThoai_DieuTuDong { get; set; }
        /// <summary>
        /// 40.Điều App khi không lấy được tọa độ sẽ cảnh báo.
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DienThoai_DieuApp_CanhBaoGPS)]
        public static bool DienThoai_DieuApp_CanhBaoGPS { get; set; }
        /// <summary>
        /// 47.Điện thoại nhận phản ánh khiếu nại
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DienThoai_PhanAnhKhieuNai)]
        public static bool DienThoai_PhanAnhKhieuNai { get; set; }
        // [EnumConfigCommon(Enum_Config_Common.G5_PinMap)]
        public static bool G5_PinMap { get; set; }
        /// <summary>
        /// 48.AMI_HostName
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.AMI_HostName)]
        public static string AMI_HostName { get; set; }
        /// <summary>
        /// 49.AMI_Port
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.AMI_Port)]
        public static int AMI_Port { get; set; }
        /// <summary>
        /// 50.AMI_UserName
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.AMI_UserName)]
        public static string AMI_UserName { get; set; }
        /// <summary>
        /// 51.AMI_Password
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.AMI_Password)]
        public static string AMI_Password { get; set; }
        /// <summary>
        /// 52.Lấy thông tin khách hàng hiển thị lên.
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DienThoai_InfoKH)]
        public static bool DienThoai_InfoKH { get; set; }

        /// <summary>
        /// 53.Vùng mặc định
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.VungMacDinh)]
        public static string VungMacDinh { get; set; }
        /// <summary>
        /// 54.GridConfig
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.GridConfig)]
        public static int GridConfig { get; set; }
        ///// <summary>
        ///// 55.DefaultGateway
        ///// </summary>
        [EnumConfigCommon(Enum_Config_Common.IP_DefaultGateway)]
        public static string IP_DefaultGateway { get; set; }
        /// <summary>
        /// 56.Nhập lệnh mời khách khi nhập xe điểm
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.LenhMoiKhachKhiNhapXeDenDiem)]
        public static int LenhMoiKhachKhiNhapXeDenDiem { get; set; }
        /// <summary>
        /// 57.Màu nền sân bay
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.Grid_CuocSanBay_BackGround)]
        public static Color Grid_CuocSanBay_BackGround { get; set; }
        /// <summary>
        /// 58.Dùng xe
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DungXe)]
        public static NhapXeDon DungXe { get; set; }
        /// <summary>
        /// 59.cảnh báo khi nhập xe
        /// 0-Dùng cảnh báo
        /// 1-Bỏ cảnh báo
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.CanhBaoKhiNhapXe)]
        public static int CanhBaoKhiNhapXe { get; set; }

        /// <summary>
        ///  60.Service Địa chỉ
        ///  [DisplayValue("Mặc định", "0", true)]
        ///  [DisplayValue("Google", "1")]
        ///  [DisplayValue("Bình anh", "2")]
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.GEOService, ConvertType = typeof(int))]
        public static EnumGEOService GEOService { get; set; }

        /// <summary>
        /// 62.Màu lái xe nhận từ app bên tổng đài
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.MauLaiXeNhanAppTongDai)]
        public static Color MauLaiXeNhanAppTongDai { get; set; }
        /// <summary>
        /// 63.Số cột config
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.ColConfig)]
        public static int ColConfig { get; set; }
        /// <summary>
        /// 64.Mã lệnh giục xe trên server trả về.
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.CmdIdGiucXe)]
        public static int CmdIdGiucXe { get; set; }
        /// <summary>
        /// 65.Mã lệnh ghi chú trên server trả về.
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.CmdIdGhiChu)]
        public static int CmdIdGhiChu { get; set; }
        /// <summary>
        /// 67.Khung địa chỉ của điện thoại viên
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DienThoai_KhungDiaChi, ConvertType = typeof(int))]
        public static KhungDiaChi DienThoai_KhungDiaChi { get; set; }
        /// <summary>
        /// 68.Khung địa chỉ của tổng đài viên
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.TongDai_KhungDiaChi, ConvertType = typeof(int))]
        public static KhungDiaChi TongDai_KhungDiaChi { get; set; }

        /// <summary>
        /// 70.TDV Sắp xếp cuốc gọi
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.TongDai_SapXepCuocGoi, ConvertType = typeof(int))]
        public static SapXepCuocGoi TongDai_SapXepCuocGoi { get; set; }

        /// <summary>
        /// 71.PBXIPVoicePath của PMDH
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.PBXIPVoicePath)]
        public static string PBXIPVoicePath { get; set; }
        /// <summary>
        /// 72.Kiểm tra số điện thoại
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.CheckPhoneNumber)]
        public static int CheckPhoneNumber { get; set; }
        /// <summary>
        /// 73.Chèn xe đến điểm vào xe nhận
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.ChenXeDenDiemVaoXeNhan)]
        public static int ChenXeDenDiemVaoXeNhan { get; set; }
        /// <summary>
        /// 74.Cảnh báo lệnh lái xe
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.CanhBaoLenhLaiXe)]
        public static int CanhBaoLenhLaiXe { get; set; }
        /// <summary>
        /// 75.Cấu hình hiển text lệnh 7: Ko nói gì hoặc Gọi nhiều ko nghe
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.CauHinhTextLenh7)]
        public static int CauHinhTextLenh7 { get; set; }
        /// <summary>
        /// 76.Cấu hình cho phép kết thúc cuốc lệnh 7 
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.CauHinhKetThucCuocLenh7)]
        public static int CauHinhKetThucCuocLenh7 { get; set; }
        /// <summary>
        /// 77.Cấu hình ServiceDieuApp
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.ServiceDieuApp)]
        public static EnumServiceDieuApp ServiceDieuApp { get; set; }
        /// <summary>
        /// 78.Cơ chế điều app
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.CoCheDieuApp)]
        public static EnumCoCheDieuApp CoCheDieuApp { get; set; }
        /// <summary>
        /// 79.Cuốc online
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.CuocOnline)]
        public static bool CuocOnline { get; set; }
        /// <summary>
        /// 80.Bỏ viết tắt ngõ.
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.BoVietTatNgo)]
        public static bool BoVietTatNgo { get; set; }
        //public stat
        /// <summary>
        /// 82.Kết thúc cuốc khiếu nại
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.KetThucCuocKhieuNai)]
        public static bool KetThucCuocKhieuNai { get; set; }
        /// <summary>
        /// 83.Ẩn kiểu cuộc gọi khác trên form DTV.
        /// Dùng bên Futa(Phương trang)
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.AnKieuCuocGoiKhac)]
        public static bool AnKieuCuocGoiKhac { get; set; }
        /// <summary>
        /// 85.CmdId Lệnh ko liên lạc được khách.
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.CmdIdLenhKoLienLac)]
        public static int CmdIdLenhKoLienLac { get; set; }
        /// <summary>
        /// 86.Lấy Tọa độ gps từ địa chỉ lịch sử cuốc
        /// Nhưng phải lấy đươc địa chỉ trước:key=30,HasValue=1
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DienThoai_LayGPSLichSuCuoc)]
        public static bool DienThoai_LayGPSLichSuCuoc { get; set; }
        /// <summary>
        /// 87.Có xe nhận thì cho phép điều lại và nhầm khách,chuyển đàm
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DienThoai_DieuApp_CoXeNhanChoPhepDieuLai)]
        public static bool DienThoai_DieuApp_CoXeNhanChoPhepDieuLai { get; set; }
        /// <summary>
        /// 88.Điều app không xe và cho phép điều lại
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DienThoai_AppkhongXe_ChoPhepDieuLai)]
        public static bool DienThoai_AppkhongXe_ChoPhepDieuLai { get; set; }
        /// <summary>
        /// 89.Điều lại cho tick điều app
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DienThoai_DieuLai_TickDieuApp)]
        public static bool DienThoai_DieuLai_TickDieuApp { get; set; }
        /// <summary>
        /// 90.Thời gian chuyển đàm.
        /// Mặc định là 90s=1p30s
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DienThoai_DieuApp_ThoiGianChuyenDam)]
        public static int DienThoai_DieuApp_ThoiGianChuyenDam { get; set; }
        /// <summary>
        /// 91.Những cuốc chuyển đàm thì cho phép điều lại app.
        /// </summary> 
        [EnumConfigCommon(Enum_Config_Common.DienThoai_ChuyenDam_DieuLai)]
        public static bool DienThoai_ChuyenDam_DieuLai { get; set; }
        /// <summary>
        /// 92.Cơ chế chuyển đàm.
        /// 0-Mặc định.
        /// 1-Tất cả các trường hợp và trừ app ko xe và ko xe nhận.
        /// 2-Tất cả các trường hợp và trừ cuốc bị timeout.
        /// 3-Tất cả các trường hợp và trừ cuốc bị timeout và có cảnh báo hết thời gian xử lý.
        /// 4-Tất cả các trường hợp không chuyển đàm.
        /// 5-Tất cả các trường hợp không chuyển đàm và có cảnh báo hết thời gian.
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DienThoai_DieuApp_ChuyenDam)]
        public static int DienThoai_DieuApp_ChuyenDam { get; set; }
        /// <summary>
        /// 93.Cảnh bảo trùng địa chỉ.
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DienThoai_CanhBaoTrungDiaChi)]
        public static bool DienThoai_CanhBaoTrungDiaChi { get; set; }
        /// <summary>
        /// 94.Chuyển Kiểu cuộc gọi khách MG thành Khách thường khi thay đổi địa chỉ
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DienThoai_ChuyenKhachMGThanhKhachThuong)]
        public static bool DienThoai_ChuyenKhachMGThanhKhachThuong { get; set; }
        /// <summary>
        /// 95.Thời gian cho phép chọn chuyển đàm.
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DienThoai_DieuApp_ThoiGianChoPhepChonChuyenDam)]
        public static int DienThoai_DieuApp_ThoiGianChoPhepChonChuyenDam { get; set; }
        /// <summary>
        /// 96.Thời gian cho phép chọn điều lại.
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DienThoai_DieuApp_ThoiGianChoPhepChonDieuLai)]
        public static int DienThoai_DieuApp_ThoiGianChoPhepChonDieuLai { get; set; }
        /// <summary>
        /// 97.Cảnh báo mất kết nối với Server DH
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DienThoai_DieuApp_CanhBaoMatKetNoiVoiServerDieuHanh)]
        public static bool DienThoai_DieuApp_CanhBaoMatKetNoiVoiServerDieuHanh { get; set; }
        /// <summary>
        /// 98.Điều lại giữ cuốc cũ
        /// 1-Giữ cuốc cũ.
        /// 0-Tạo cuốc mới.
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DienThoai_DieuApp_DieuLaiGiuCuocCu)]
        public static bool DienThoai_DieuApp_DieuLaiGiuCuocCu { get; set; }
        /// <summary>
        /// 99.Số tick ngủ chút rồi gửi tiếp.
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DienThoai_DieuApp_SleepCuocSaoChep)]
        public static int DienThoai_DieuApp_SleepCuocSaoChep { get; set; }
        /// <summary>
        /// 100.Mã lệnh đã mời
        /// 43
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DienThoai_DieuApp_DaMoiCmdId)]
        public static int DienThoai_DieuApp_DaMoiCmdId { get; set; }
        /// <summary>
        /// 101.Chuỗi kết nối service điều
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.ServiceConnectString)]
        public static string ServiceConnectString { get; set; } 
        /// <summary>
        /// 102. Chọn loại xe mặc định
        /// -2 : Không chọn loại xe nào
        /// -1 : Không chọn loại xe nào và chọn mặc định bất kỳ
        ///  0 : Mặc định chọn 4 chỗ
        ///  1 : Mặc định chọn 7 chỗ
        ///  2 : Mặc định chọn xe hợp đồng
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DienThoai_ChonLoaiXe, ConvertType = typeof(long))]
        public static int DienThoai_ChonLoaiXe { get; set; }
        /// <summary>
        /// 103.Cho phép trượt khi có xe nhận
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DienThoai_DieuApp_TruotKhiCoXeNhan)]
        public static bool DienThoai_DieuApp_TruotKhiCoXeNhan { get; set; }
        /// <summary>
        /// 104.Số Phút cho phép nhập xe đón khi có xe nhận đón điều app
        /// -1 : Không cho phép nhập xe đón khi có xe nhận.
        ///  0 : Cho phép nhập khi có xe nhận.
        /// n>0: Số phút cho phép nhập xe đón.
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DienThoai_DieuApp_SoPhutChoPhepNhapXeDonKhiCoXeNhan, ConvertType = typeof(long))]
        public static int DienThoai_DieuApp_SoPhutChoPhepNhapXeDonKhiCoXeNhan { get; set; }
        /// <summary>
        /// 115.Thời gian cho phép xử lý cuốc sao chép khi tắt pm và bật pm.
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DienThoai_DieuApp_XuLyCuocGoiSaoChep)]
        public static int DienThoai_DieuApp_XuLyCuocGoiSaoChep { get; set; }
        /// <summary>
        /// 116.Bắt buộc lấy GPS
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DienThoai_RequiredGPS)]
        public static bool DienThoai_RequiredGPS { get; set; }
        /// <summary>
        /// 117.Băt buộc hiển thị bản đồ bên Tổng đài(Ctrl+B)
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.TongDai_RequiredShowMap)]
        public static bool TongDai_RequiredShowMap { get; set; }
        /// <summary>
        /// 118.Cho phép cập nhật thói quen khách hàng.
        /// -1: Chặn không cập nhật thói quen
        /// 0 : Số điện thoại di động.
        /// 1 : Tất cả số.
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DienThoai_UpdateCustomerHabit, ConvertType = typeof(long))]
        public static int DienThoai_UpdateCustomerHabit { get; set; }
        /// <summary>
        /// 119.Điều lại cho phép dùng BookId cũ
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DienThoai_DieuLai_BookIdOld)]
        public static bool DienThoai_DieuLai_BookIdOld { get; set; }
        /// <summary>
        /// 120.Trượt trong khoảng thời gian bao lâu.
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DienThoai_DieuApp_Truot)]
        public static int DienThoai_DieuApp_Truot { get; set; }
        /// <summary>
        /// 121.Trunk để gọi ra
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.MPCC_TrunkDial)]
        public static string MPCC_TrunkDial { get; set; }
        /// <summary>
        /// 122.Queue để gọi ra
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.MPCC_Queue)]
        public static string MPCC_Queue { get; set; }
        /// <summary>
        /// 123.Link gọi ra
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.MPCC_LinkDial)]
        public static string MPCC_LinkDial { get; set; }
        /// <summary>
        /// 124.Điều sân bay
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DieuSanBay)]
        public static int DieuSanBay { get; set; }

        /// <summary>
        /// 125.Cho phép gọi nhanh từ PMDH đến tổng đài IP
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.VungDamMacDinh)]
        public static bool VungDamMacDinh { get; set; }

        /// <summary>
        /// 126.zlink gọi ra
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.Zlink_LinkDial)]
        public static string Zlink_LinkDial { get; set; }

        /// <summary>
        /// 127.Cho phép gọi nhanh từ PMDH đến tổng đài IP
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.Asterisk_QuickCall)]
        public static bool Asterisk_QuickCall { get; set; }

        /// <summary>
        /// 130.Link trang gps xem Lộ Trình từ BC MG 6.10
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DomainGPS)]
        public static string GPS_Domain_Route { get; set; }
        /// <summary>
        /// 131.Channel Goi Ra
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.ChannelDial)]
        public static string ChannelDial { get; set; }

        /// <summary>
        /// 132. Số phút cho phép bấn phím H để hoàn thành cuốc
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.App_Minute_Done_ByKeyH)]
        public static int App_Minute_Done_ByKeyH { get; set; }
        /// <summary>
        /// 133. check trạng thái của extension có bận hay ko
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.MPCC_LinkCheckStatus)]
        public static string MPCC_LinkCheckStatus { get; set; }
        /// <summary>
        /// 134. Điều app - nhận Mời khách từ app KH. Show cuốc online lên lưới chờ điều để mời khách
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.App_CustomerSource_Invite)]
        public static bool App_CustomerSource_Invite { get; set; }

        /// <summary>
        /// 135. Có cho phép hệ thống điều app hay không?       
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.CoDieuApp)]
        public static bool CoDieuApp { get; set; }

        /// <summary>
        /// 136. Có cấu hình hiển thị cột khách hẹn bên DTV không?
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.CotKhachHen)]
        public static bool CotKhachHen { get; set; }

        /// <summary>
        /// 137. Có cấu hình hiển thị cảnh báo bên DTV không?
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.CanhBaoCuocSanBay)]
        public static bool CanhBaoCuocSanBay { get; set; }

        /// <summary>
        /// 138. Cấu hình thêm ký tự # sau số điện thoại để gọi ra
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.Asterisk_SetNumberSign)]
        public static string Asterisk_SetNumberSign { get; set; }

        /// <summary>
        /// 139. Cấu hình Gửi tin nhắn SMS ở Server App
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.App_SendSMS_Customer)]
        public static bool App_SendSMS_Customer { get; set; }

        /// <summary>
        /// 140. Cấu hình nhập tuyến đường dài theo mẫu BaSao
        /// </summary>        
        [EnumConfigCommon(Enum_Config_Common.NhapTuyenDuongDai)]
        public static bool NhapTuyenDuongDai { get; set; }

        /// <summary>
        /// 141. Cấu hình điều xe hợp đồng
        /// </summary>        
        [EnumConfigCommon(Enum_Config_Common.App_DieuXeHopDong)]
        public static bool App_DieuXeHopDong { get; set; }

        /// <summary>
        /// 142. Cấu hình App KH - Hủy :Server tự động điều lại hay ko.
        /// </summary>        
        [EnumConfigCommon(Enum_Config_Common.AppKH_Huy)]
        public static bool AppKH_Huy { get; set; }

        /// <summary>
        /// 143. Cấu hình App KH - không xe nhận tự chuyển đàm hay ko.
        /// </summary>        
        [EnumConfigCommon(Enum_Config_Common.AppKH_ChuyenDam)]
        public static bool AppKH_ChuyenDam { get; set; }

        /// <summary>
        /// 144. Cấu hình dùng map mặc định
        /// 0: Google - 1: Bình Anh
        /// </summary>        
        [EnumConfigCommon(Enum_Config_Common.MAP_Provider)]
        public static int MAP_Provider { get; set; }

        /// <summary>
        /// 145. Cấu hình thuê bao tuyến theo Hải Phòng - Sử dụng các bảng [TrungKien] VD: Trung Kiên, Vạn An ...
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.CauHinhThueBaoTuyen)]
        public static bool CauHinhThueBaoTuyen { get; set; }

        /// <summary>
        /// 146. Cấu hình có nhận cảnh báo SOS từ App
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.App_SOS_Alert)]
        public static bool App_SOS_Alert { get; set; }

        /// <summary>
        /// 147. Cấu hình tự động check License!
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.AutoCheckLicense)]
        public static bool AutoCheckLicense { get; set; }

        /// <summary>
        /// 148. Cấu hình cho phép chuyển sang điều app
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.ChoPhepChuyenDieuApp)]
        public static bool ChoPhepChuyenDieuApp { get; set; }

        /// <summary>
        /// 149. Cấu hình Line điều xe cao cấp -> Thành Công Car!
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.LineDieuAppXeCaoCap)]
        public static bool LienDieuAppXeCaoCap { get; set; }
        
        /// <summary>
        /// 150. Có lấy xe đề cử hay ko
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.GPS_GetXeOnline)]
        public static bool GPS_GetXeOnline { get; set; }

        /// <summary>
        /// 151. Tự động logout ở máy khác hoặc tự động logout khi bị đăng xuất cưỡng chế
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.ValidateLogin)]
        public static bool ValidateLogin { get; set; }

        /// <summary>
        /// 152. sử dụng bản đồ online
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.MapOnline)]
        public static bool MapOnline { get; set; }

        /// <summary>
        /// 153. Cấu hình Timeout gọi ra Asterisk
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.Asterisk_CallOut_TimeOut)]
        public static int Asterisk_CallOut_TimeOut { get; set; }

        /// <summary>
        /// 155. Cấu hình mau cua cot vung tren luoi neu = 0
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.Grid_Vung_Color)]
        public static Color Grid_Vung_Color { get; set; }

        /// <summary>
        /// 156. Cấu hình màu lệnh Khách Vip
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.Grid_Line_Color_KhachVip)]
        public static Color Grid_Line_Color_KhachVip { get; set; }

        /// <summary>
        /// 157. Cấu hình màu lệnh Khách MG
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.Grid_Line_Color_KhachMG)]
        public static Color Grid_Line_Color_KhachMG { get; set; }

        /// <summary>
        /// 158. Cấu hình màu lệnh Khách vàng bạc
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.Grid_Line_Color_KhachVangBac)]
        public static Color Grid_Line_Color_KhachVangBac { get; set; }

        /// <summary>
        /// 159. Cấu hình màu lệnh Khách ảo
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.Grid_Line_Color_KhachAo)]
        public static Color Grid_Line_Color_KhachAo { get; set; }

        /// <summary>
        /// 160. Cấu hình màu Xe dừng điểm
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.Grid_XeDungDiem_Color)]
        public static Color Grid_XeDungDiem_Color { get; set; }

        /// <summary>
        /// 161. Cấu hình màu Thời điểm gọi > 5' và nhỏ hơn 16'
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.Grid_ThoiDiemGoi_Color_5)]
        public static Color Grid_ThoiDiemGoi_Color_5 { get; set; }

        /// <summary>
        /// 162. Cấu hình màu Thời điểm gọi Lớn hơn 15
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.Grid_ThoiDiemGoi_Color_15)]
        public static Color Grid_ThoiDiemGoi_Color_15 { get; set; }

        /// <summary>
        /// 163. Cấu hình màu Thời điểm hẹn nhỏ hơn 15'
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.Grid_ThoiDiemHen_Color_15)]
        public static Color Grid_ThoiDiemHen_Color_15 { get; set; }

        /// <summary>
        /// 164. Cấu hình màu  Thời điểm hẹn nhỏ hơn 90'
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.Grid_ThoiDiemHen_Color_90)]
        public static Color Grid_ThoiDiemHen_Color_90 { get; set; }

        /// <summary>
        /// 165. Cấu hình màu Loại xe đặc biệt (config số 5)
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.Grid_LoaiXe_Color_Config5)]
        public static Color Grid_LoaiXe_Color_Config5 { get; set; }

        /// <summary>
        /// 166. Cấu hình màu Số lượng > 1
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.Grid_SoLuong_Color_1)]
        public static Color Grid_SoLuong_Color_1 { get; set; }

        /// <summary>
        /// 167. Cấu hình màu Số lần > 1
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.Grid_SoLan_Color_1)]
        public static Color Grid_SoLan_Color_1 { get; set; }

        /// <summary>
        /// 168. Cấu hình màu Số lần > 2
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.Grid_SoLan_Color_2)]
        public static Color Grid_SoLan_Color_2 { get; set; }

        /// <summary>
        /// 169. Cấu hình màu địa chỉ cuốc app
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.Grid_DiaChi_App_Color)]
        public static Color Grid_DiaChi_App_Color { get; set; }

        /// <summary>
        /// 170. Cấu hình màu địa chỉ cuốc app xe Car
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.Grid_DiaChi_CAR_Color)]
        public static Color Grid_DiaChi_CAR_Color { get; set; }

        /// <summary>
        /// 171. Cấu hình màu địa chỉ gọi lại
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.Grid_DiaChi_GL_Color)]
        public static Color Grid_DiaChi_GL_Color { get; set; }

        /// <summary>
        /// 172. Cấu hình màu sdt cuốc app
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.Grid_SDT_App_Color)]
        public static Color Grid_SDT_App_Color { get; set; }
        /// <summary>
        /// 173. Cấu hình màu app chuyển đàm
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.Grid_App_ChuyenDam_Color)]
        public static Color Grid_App_ChuyenDam_Color { get; set; }

        /// <summary>
        /// 174. Cấu hình màu app không xe
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.Grid_App_NoCar_Color)]
        public static Color Grid_App_NoCar_Color { get; set; }

        /// <summary>
        /// 175. Cấu hình màu app ko xe nhận
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.Grid_App_NoCarAccept_Color)]
        public static Color Grid_App_NoCarAccept_Color { get; set; }

        /// <summary>
        /// 176. Cấu hình màu chữ khi chọn 1 dòng trên lưới cuộc gọi
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.Grid_FocusedRow_Color)]
        public static Color Grid_FocusedRow_Color { get; set; }

        /// <summary>
        /// 177. Cấu hình màu nền khi chọn 1 dòng trên lưới cuộc gọi
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.Grid_FocusedRow_BackColor)]
        public static Color Grid_FocusedRow_BackColor { get; set; }

        /// <summary>
        /// 178. Cấu hình màu  Thời điểm hẹn
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.Grid_ThoiDiemHen_Color)]
        public static Color Grid_ThoiDiemHen_Color { get; set; }

        //179 : chưa có

        /// <summary>
        /// 180. Cấu hình cmdid của phần hiển thị số trên applx
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.AppLX_CMDID_ShowPhoneNumber)]
        public static int AppLX_CMDID_ShowPhoneNumber { get; set; }
        
        /// <summary>
        /// 181.Link gọi ra Asterisk Cloud
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.Asterisk_LinkDial)]
        public static string Asterisk_LinkDial { get; set; }

        /// <summary>
        /// 182.Link gọi ra Asterisk Cloud : CRM ID
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.Asterisk_LinkDial_CRMID)]
        public static string Asterisk_LinkDial_CRMID { get; set; }

        /// <summary>
        /// 183.Chèn xe đến điểm vào xe MK
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.ChenXeDenDiemVaoXeMK)]
        public static bool ChenXeDenDiemVaoXeMK { get; set; }
        /// <summary>
        /// 184. Nhập Chot Co Duong Dai
        /// 0 : khong dung
        /// 1 : mini
        /// 2 : full
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.NhapChotCoDuongDai)]
        public static int NhapChotCoDuongDai { get; set; }
        /// <summary>
        /// 185.Font của lưới cuộc gọi
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.Grid_Font)]
        public static string Grid_Font { get; set; }
        /// <summary>
        /// 186.Màu viền của lưới cuộc gọi
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.Grid_HorzLineColor)]
        public static Color Grid_HorzLineColor { get; set; }
        /// <summary>
        /// 187.Cho nhập xe MK bằng phím *. Mặc định là nhập xe đến điểm
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.TDV_NhapXeMK)]
        public static bool TDV_NhapXeMK { get; set; }
        /// <summary>
        /// 188. Ban cuoc dam xuong app lx
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.App_SendRadioTrip)]
        public static bool App_SendRadioTrip { get; set; }
        /// <summary>
        /// 189. Lay dia chi theo tha diem (Khi tha diem thi se nhap lai dia chi theo dia chi cua diem vua cap nhat)
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DTV_AddressByPinMap)]
        public static bool DTV_AddressByPinMap { get; set; }

        /// <summary>
        /// 190. Cấu hình mặc định điều app
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DTV_DefaultApp)]
        public static bool DTV_DefaultApp { get; set; }

        /// <summary>
        /// 191. Cấu hình Sắp xếp các cuốc có lệnh ưu tiên lên đầu (Giục xe + Không thấy xe + Hủy hoãn_)
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.TDV_ORDERBYCOMMAND)]
        public static bool TDV_ORDERBYCOMMAND { get; set; }

        /// <summary>
        /// 192. Cấu hình Cảnh báo xe nhận cuốc đàm trùng với xe nhận ở App
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.TDV_VALIDATE_XENHAN_APP)]
        public static bool TDV_VALIDATE_XENHAN_APP { get; set; }
        /// <summary>
        /// 193. Sắp xếp lưới điện thoại theo thời điểm hẹn
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DTV_THOIDIEMHEN_ORDER)]
        public static bool DTV_THOIDIEMHEN_ORDER { get; set; }

        /// <summary>
        /// 194. Sắp xếp lưới điện thoại theo Xe Nhan
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DTV_XENHAN_ORDER)]
        public static bool DTV_XENHAN_ORDER { get; set; }
        /// <summary>
        /// 195.Cho phép gọi nhanh từ hộp gọi nhanh COM
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DTV_QUICKCALL_COM)]
        public static bool DTV_QUICKCALL_COM { get; set; }
        /// <summary>
        /// 196.Cho phép điều chỉ định ko cần tọa độ
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DTV_APP_NOT_LOCATION)]
        public static bool DTV_APP_NOT_LOCATION { get; set; }
        /// <summary>
        /// 197.Khung nhập cuộc gọi mini
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DTV_INPUT_MINI)]
        public static bool DTV_INPUT_MINI { get; set; }
        /// <summary>
        /// 198.DTV Fix Point Điểm MG
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DTV_INPUT_FIX_POINT_MG)]
        public static bool DTV_INPUT_FIX_POINT_MG { get; set; }
        /// <summary>
        /// 199.DTV gửi SMS đã xin lỗi khách
        /// =0 Không gửi
        /// =1 Có gửi tự động
        /// =2 Khi nào bấm lệnh gửi thì mới gửi
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DTV_SMS_DAXINLOI_KHACH)]
        public static int DTV_SMS_DAXINLOI_KHACH { get; set; }

        /// <summary>
        /// 200.DTV hiển thị cảnh báo mời khách
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DTV_ALERT_INVITE)]
        public static int DTV_ALERT_INVITE { get; set; }
        /// <summary>
        /// 202.Màu nền cuốc chưa xử lý nhưng đã nhận.
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.Grid_CuocChuaXuLy_BackGround_DaNhan)]
        public static Color Grid_CuocChuaXuLy_BackGround_DaNhan { get; set; }
        /// <summary>
        /// 203.SMS cuốc đường đài có thông tin tên lái xe
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.SMS_CuocDuongDai_LaiXe)]
        public static bool SMS_CuocDuongDai_LaiXe { get; set; }

        /// <summary>
        /// 204.SMS cuốc App đường đài gửi khi nào
        /// 1. Khi nhập xe đón        
        /// 2. Nhập khi đã mời
        /// 23.Lệnh khác
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.SMS_CuocDuongDai_App_LaiXe_Send)]
        public static Enum_SendSMSCuocDuongDai_App SMS_CuocDuongDai_App_LaiXe_Send { get; set; }

        /// <summary>
        /// 205.SMS cuốc đàm đường đài gửi khi nào
        /// 1. Khi nhập xe đón        
        /// 2. Nhập khi nhập xe đến điểm
        /// 23.Lệnh khác
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.SMS_CuocDuongDai_Dam_LaiXe_Send)]
        public static Enum_SendSMSCuocDuongDai_Dam SMS_CuocDuongDai_Dam_LaiXe_Send { get; set; }

        /// <summary>
        /// 206. Cấu hình Nhập xe nhận cuốc đàm trùng với xe nhận ở App thì gửi thông tin cuốc đàm xuống cho app qua thông báo
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.TDV_XENHAN_RADIO_TO_APP)]
        public static bool TDV_XENHAN_RADIO_TO_APP { get; set; }

        /// <summary>
        /// 208.SMS dành riêng cho Taxi Vina
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.SMS_TaxiVina)]
        public static bool SMS_TaxiVina { get; set; }
        
        /// <summary>
        /// 209.SMS Vina ReceiveCarInfo
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.SMS_TaxiVina_ReceiveCarInfo)]
        public static bool SMS_TaxiVina_ReceiveCarInfo { get; set; }

        /// <summary>
        /// 210.SMS Vina_ViewCar
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.SMS_TaxiVina_ViewCar)]
        public static bool SMS_TaxiVina_ViewCar { get; set; }

        /// <summary>
        /// 211.SMS Vina_CatchedUser
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.SMS_TaxiVina_CatchedUser)]
        public static bool SMS_TaxiVina_CatchedUser { get; set; }

        /// <summary>
        /// 212.SMS Vina_NoCar
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.SMS_TaxiVina_NoCar)]
        public static bool SMS_TaxiVina_NoCar { get; set; }

        /// <summary>
        /// 213.SMS Vina_ThankCustomer
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.SMS_TaxiVina_ThankCustomer)]
        public static bool SMS_TaxiVina_ThankCustomer { get; set; }
        /// <summary>
        /// 214.SMS Vina_Other
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.SMS_TaxiVina_Other)]
        public static bool SMS_TaxiVina_Other { get; set; }
        /// <summary>
        /// 215.Số phút mặc định báo khách chờ (VINATAXI)
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.SMS_PHUTKHACHCHO)]
        public static string SMS_PHUTKHACHCHO { get; set; }

        /// <summary>
        /// 216.Địa chỉ đón IN HOA
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DTV_Address_UPPER)]
        public static bool DTV_Address_UPPER { get; set; }
        /// <summary>
        /// 217. TĐV Màu chữ Ghi Chú ĐTV
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.TDV_Grid_GhiChuDTV)]
        public static Color TDV_Grid_GhiChuDTV { get; set; }

        /// <summary>
        /// 218. Co dùng thời điểm hẹn
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DTV_ThoiGianHen)]
        public static bool DTV_ThoiGianHen { get; set; }
        /// <summary>
        /// 219. TĐV Màu nền Lệnh khác
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.TDV_Grid_LenhDTV)]
        public static Color TDV_Grid_LenhDTV { get; set; }
        /// <summary>
        /// 220.  TĐV Màu nền Thoidiemhen
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.TDV_Grid_ThoiGianHen)]
        public static Color TDV_Grid_ThoiGianHen { get; set; }

        /// <summary>
        /// 221.  DTV Focus địa chỉ đón khi bấm Alt + Z (điều App)
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DTV_ALTZ_FOCUSADDRESS)]
        public static int DTV_ALTZ_FOCUSADDRESS { get; set; }
        /// <summary>
        /// 222. DTV phát âm thanh cảnh báo khi có Lệnh Lái Xe mới
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DTV_ALERT_SOUND_LENHLX)]
        public static bool DTV_ALERT_SOUND_LENHLX { get; set; }
        /// <summary>
        /// 224. Sử dụng chỉ đường trên điện thoại viên
        /// 0 : không sử dụng
        /// 13: ID của Thành Công taxi
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DTV_ROUTE_SERVICE)]
        public static int DTV_ROUTE_SERVICE { get; set; }
        /// <summary>
        /// 225. Fix giá báo cho KH
        /// </summary>
        [EnumConfigCommon(Enum_Config_Common.DTV_FixPrice)]
        public static bool DTV_FixPrice { get; set; }
        #endregion

        #region ==== LoadConfig_Common ====
        #region == #remove ==
        public static void LoadConfig_Common()
        {
            //return;
            G_DictConfig_Common = GetAllConfig().ToDictionary(T => (Enum_Config_Common)T.Id, T => T.HasValue);

            if (G_DictConfig_Common.ContainsKey(Enum_Config_Common.LuoiCuocGoi_MauNen_LenhMoi_Right) && G_DictConfig_Common[Enum_Config_Common.LuoiCuocGoi_MauNen_LenhMoi_Right] != "")
                LuoiCuocGoi_MauNen_LenhMoi_Right = Color.FromName(G_DictConfig_Common[Enum_Config_Common.LuoiCuocGoi_MauNen_LenhMoi_Right]);
            else
                LuoiCuocGoi_MauNen_LenhMoi_Right = Color.White;
            TongDai_HienThiCanhBao_NhapTrungXeNhan = G_DictConfig_Common.ContainsKey(Enum_Config_Common.TongDai_HienThiCanhBao_NhapTrungXeNhan) ? G_DictConfig_Common[Enum_Config_Common.TongDai_HienThiCanhBao_NhapTrungXeNhan].To<int>() : 0;
            if (G_DictConfig_Common.ContainsKey(Enum_Config_Common.LuoiCuocGoi_MauNen_LenhMoi) && G_DictConfig_Common[Enum_Config_Common.LuoiCuocGoi_MauNen_LenhMoi] != "")
                LuoiCuocGoi_MauNen_LenhMoi = Color.FromName(G_DictConfig_Common[Enum_Config_Common.LuoiCuocGoi_MauNen_LenhMoi]);
            else
                LuoiCuocGoi_MauNen_LenhMoi = Color.Orange;

            if (G_DictConfig_Common.ContainsKey(Enum_Config_Common.LuoiCuocGoi_HienThiMauNen_LenhMoi) && G_DictConfig_Common[Enum_Config_Common.LuoiCuocGoi_HienThiMauNen_LenhMoi] != "")
                LuoiCuocGoi_HienThiMauNen_LenhMoi = G_DictConfig_Common[Enum_Config_Common.LuoiCuocGoi_HienThiMauNen_LenhMoi];
            else
                LuoiCuocGoi_HienThiMauNen_LenhMoi = "0";

            if (G_DictConfig_Common.ContainsKey(Enum_Config_Common.LuoiCuocGoi_HienThiMauNen_LenhMoi_Right) && G_DictConfig_Common[Enum_Config_Common.LuoiCuocGoi_HienThiMauNen_LenhMoi_Right] != "")
                LuoiCuocGoi_HienThiMauNen_LenhMoi_Right = G_DictConfig_Common[Enum_Config_Common.LuoiCuocGoi_HienThiMauNen_LenhMoi_Right];
            else
                LuoiCuocGoi_HienThiMauNen_LenhMoi_Right = "0";

            if (G_DictConfig_Common.ContainsKey(Enum_Config_Common.LuoiCuocGoi_MauNen_LoaiXe) && G_DictConfig_Common[Enum_Config_Common.LuoiCuocGoi_MauNen_LoaiXe] != "")
                LuoiCuocGoi_MauNen_LoaiXe = G_DictConfig_Common[Enum_Config_Common.LuoiCuocGoi_MauNen_LoaiXe].Split(';');

            LuoiCuocGoi_FontSize_TiepNhan = G_DictConfig_Common.ContainsKey(Enum_Config_Common.LuoiCuocGoi_FontSize_TiepNhan) ? G_DictConfig_Common[Enum_Config_Common.LuoiCuocGoi_FontSize_TiepNhan].To<int>() : 8;
            LuoiCuocGoi_FontSize_TiepNhan_Right = G_DictConfig_Common.ContainsKey(Enum_Config_Common.LuoiCuocGoi_FontSize_TiepNhan_Right) ? G_DictConfig_Common[Enum_Config_Common.LuoiCuocGoi_FontSize_TiepNhan_Right].To<int>() : 8;
            LuoiCuocGoi_RowHeight_TiepNhan = G_DictConfig_Common.ContainsKey(Enum_Config_Common.LuoiCuocGoi_RowHeight_TiepNhan) ? G_DictConfig_Common[Enum_Config_Common.LuoiCuocGoi_RowHeight_TiepNhan].To<int>() : 20;
            LuoiCuocGoi_RowHeight_TiepNhan_Right = G_DictConfig_Common.ContainsKey(Enum_Config_Common.LuoiCuocGoi_RowHeight_TiepNhan_Right) ? G_DictConfig_Common[Enum_Config_Common.LuoiCuocGoi_RowHeight_TiepNhan_Right].To<int>() : 20;
            LuoiCuocGoi_RowHeight_TongDai = G_DictConfig_Common.ContainsKey(Enum_Config_Common.LuoiCuocGoi_RowHeight_TongDai) ? G_DictConfig_Common[Enum_Config_Common.LuoiCuocGoi_RowHeight_TongDai].To<int>() : 20;
            LuoiCuocGoi_FontSize_TongDai = G_DictConfig_Common.ContainsKey(Enum_Config_Common.LuoiCuocGoi_FontSize_TongDai) ? G_DictConfig_Common[Enum_Config_Common.LuoiCuocGoi_FontSize_TongDai].To<int>() : 10;

            HienThiPopup = G_DictConfig_Common.ContainsKey(Enum_Config_Common.HienThiPopup) && G_DictConfig_Common[Enum_Config_Common.HienThiPopup] == "1";
            TongDai_HienThiCanhBao_XeDonTrungXeNhan = G_DictConfig_Common.ContainsKey(Enum_Config_Common.TongDai_HienThiCanhBao_XeDonTrungXeNhan) ? G_DictConfig_Common[Enum_Config_Common.TongDai_HienThiCanhBao_XeDonTrungXeNhan].To<int>() : 0;
            LuoiCuocGoi_CuocGoi_HienThiLenDauKhongXeNhan = G_DictConfig_Common.ContainsKey(Enum_Config_Common.LuoiCuocGoi_CuocGoi_HienThiLenDauKhongXeNhan) ? G_DictConfig_Common[Enum_Config_Common.LuoiCuocGoi_CuocGoi_HienThiLenDauKhongXeNhan].To<int>() : 0;
            LuoiCuocGoi_Staxi_HienThiLenDauKhongXeNhan = G_DictConfig_Common.ContainsKey(Enum_Config_Common.LuoiCuocGoi_Staxi_HienThiLenDauKhongXeNhan) ? G_DictConfig_Common[Enum_Config_Common.LuoiCuocGoi_Staxi_HienThiLenDauKhongXeNhan].To<int>() : 0;
            BanDoMini_HienThiXeDeCu = G_DictConfig_Common.ContainsKey(Enum_Config_Common.BanDoMini_HienThiXeDeCu) && G_DictConfig_Common[Enum_Config_Common.BanDoMini_HienThiXeDeCu] == "1";
            BanDoMini_HienThiXeNhan = G_DictConfig_Common.ContainsKey(Enum_Config_Common.BanDoMini_HienThiXeNhan) && G_DictConfig_Common[Enum_Config_Common.BanDoMini_HienThiXeNhan] == "1";
            DienThoai_ChoPhepKetThucKhongXeTruoc = G_DictConfig_Common.ContainsKey(Enum_Config_Common.DienThoai_ChoPhepKetThucKhongXeTruoc) ? G_DictConfig_Common[Enum_Config_Common.DienThoai_ChoPhepKetThucKhongXeTruoc].To<int>() : 0;

            if (G_DictConfig_Common.ContainsKey(Enum_Config_Common.Grid_CuocChuaXuLy_BackGround) && G_DictConfig_Common[Enum_Config_Common.Grid_CuocChuaXuLy_BackGround] != "")
            {
                Grid_CuocChuaXuLy_BackGround = Color.FromName(G_DictConfig_Common[Enum_Config_Common.Grid_CuocChuaXuLy_BackGround]);
            }

            if (G_DictConfig_Common.ContainsKey(Enum_Config_Common.TongDai_MauNen_LuoiCuocGoi) && G_DictConfig_Common[Enum_Config_Common.TongDai_MauNen_LuoiCuocGoi] != "")
            {
                TongDai_MauNen_LuoiCuocGoi = Color.FromName(G_DictConfig_Common[Enum_Config_Common.TongDai_MauNen_LuoiCuocGoi]); 
            }
            if (G_DictConfig_Common.ContainsKey(Enum_Config_Common.Grid_CuocHoiDam_BackGround) && G_DictConfig_Common[Enum_Config_Common.Grid_CuocHoiDam_BackGround] != "")
            {
                //TongDai_MauNen_CuocGoiHoiDam = Color.FromName(G_DictConfig_Common[Enum_Config_Common.Grid_CuocHoiDam_BackGround]); 
            }
            TongDai_CheckXeViPham = G_DictConfig_Common.ContainsKey(Enum_Config_Common.TongDai_CheckXeViPham) && G_DictConfig_Common[Enum_Config_Common.TongDai_CheckXeViPham] == "1";
            DangNhapNhieuMay = G_DictConfig_Common.ContainsKey(Enum_Config_Common.DangNhapNhieuMay) && G_DictConfig_Common[Enum_Config_Common.DangNhapNhieuMay] == "1";
            TongDai_AnThongBaoKhiHoanCuoc = G_DictConfig_Common.ContainsKey(Enum_Config_Common.TongDai_AnThongBaoKhiHoanCuoc) && G_DictConfig_Common[Enum_Config_Common.TongDai_AnThongBaoKhiHoanCuoc] == "1";
            DienThoai_LayLichSuCuoc = G_DictConfig_Common.ContainsKey(Enum_Config_Common.DienThoai_LayLichSuCuoc) ? G_DictConfig_Common[Enum_Config_Common.DienThoai_LayLichSuCuoc].To<int>() : 0;

            if (G_DictConfig_Common.ContainsKey(Enum_Config_Common.ChenCuoc_HoaHong) && G_DictConfig_Common[Enum_Config_Common.ChenCuoc_HoaHong] != "")
            {
                ChenCuoc_HoaHong = G_DictConfig_Common[Enum_Config_Common.ChenCuoc_HoaHong].Equals("1");
            }
            else
            {
                ChenCuoc_HoaHong = true;
            }
            // Thông tin bàn cờ
            TongDai_BanCo = G_DictConfig_Common.ContainsKey(Enum_Config_Common.TongDai_BanCo) && G_DictConfig_Common[Enum_Config_Common.TongDai_BanCo] == "1";
            DienThoai_LayDiaChiLichSu = G_DictConfig_Common.ContainsKey(Enum_Config_Common.DienThoai_LayDiaChiLichSu) && G_DictConfig_Common[Enum_Config_Common.DienThoai_LayDiaChiLichSu] == "1";
            if (G_DictConfig_Common.ContainsKey(Enum_Config_Common.TongDai_TenCotGhiChuTongDai) && !string.IsNullOrEmpty(G_DictConfig_Common[Enum_Config_Common.TongDai_TenCotGhiChuTongDai]))
            {
                TongDai_TenCotGhiChuTongDai = G_DictConfig_Common[Enum_Config_Common.TongDai_TenCotGhiChuTongDai].Trim();
            }
            TongDai_ChuyenCacCuocGoiGanCuocGoiLai = G_DictConfig_Common.ContainsKey(Enum_Config_Common.TongDai_ChuyenCacCuocGoiGanCuocGoiLai) && G_DictConfig_Common[Enum_Config_Common.TongDai_ChuyenCacCuocGoiGanCuocGoiLai] == "1";
            DienThoai_ChuyenCacCuocGoiGanCuocGoiLai = G_DictConfig_Common.ContainsKey(Enum_Config_Common.DienThoai_ChuyenCacCuocGoiGanCuocGoiLai) && G_DictConfig_Common[Enum_Config_Common.DienThoai_ChuyenCacCuocGoiGanCuocGoiLai] == "1";
            GopLine = G_DictConfig_Common.ContainsKey(Enum_Config_Common.GopLine) && G_DictConfig_Common[Enum_Config_Common.GopLine] == "1";
            GetThongTinGhiChuKH = G_DictConfig_Common.ContainsKey(Enum_Config_Common.GetThongTinGhiChuKH) && G_DictConfig_Common[Enum_Config_Common.GetThongTinGhiChuKH] == "1";
            if (G_DictConfig_Common.ContainsKey(Enum_Config_Common.TongDai_ServerSiemens_Address) && !string.IsNullOrEmpty(G_DictConfig_Common[Enum_Config_Common.TongDai_ServerSiemens_Address]))
            {
                TongDai_ServerSiemens_Address = G_DictConfig_Common[Enum_Config_Common.TongDai_ServerSiemens_Address].Trim();
            }
            DienThoai_DieuTuDong = G_DictConfig_Common.ContainsKey(Enum_Config_Common.DienThoai_DieuTuDong) && G_DictConfig_Common[Enum_Config_Common.DienThoai_DieuTuDong] == "1";
            DienThoai_DieuApp_CanhBaoGPS = G_DictConfig_Common.ContainsKey(Enum_Config_Common.DienThoai_DieuApp_CanhBaoGPS) && G_DictConfig_Common[Enum_Config_Common.DienThoai_DieuApp_CanhBaoGPS] == "1";

            DienThoai_PhanAnhKhieuNai = G_DictConfig_Common.ContainsKey(Enum_Config_Common.DienThoai_PhanAnhKhieuNai) && G_DictConfig_Common[Enum_Config_Common.DienThoai_PhanAnhKhieuNai] == "1";
            if (G_DictConfig_Common.ContainsKey(Enum_Config_Common.AMI_HostName) && !string.IsNullOrEmpty(G_DictConfig_Common[Enum_Config_Common.AMI_HostName]))
            {
                AMI_HostName = G_DictConfig_Common[Enum_Config_Common.AMI_HostName].Trim();
            }
            if (G_DictConfig_Common.ContainsKey(Enum_Config_Common.AMI_Password) && !string.IsNullOrEmpty(G_DictConfig_Common[Enum_Config_Common.AMI_Password]))
            {
                AMI_Password = G_DictConfig_Common[Enum_Config_Common.AMI_Password].Trim();
            }
            AMI_Port = G_DictConfig_Common.ContainsKey(Enum_Config_Common.AMI_Port) ? G_DictConfig_Common[Enum_Config_Common.AMI_Port].To<int>() : 0;

            if (G_DictConfig_Common.ContainsKey(Enum_Config_Common.AMI_UserName) && !string.IsNullOrEmpty(G_DictConfig_Common[Enum_Config_Common.AMI_UserName]))
            {
                AMI_UserName = G_DictConfig_Common[Enum_Config_Common.AMI_UserName].Trim();
            }
            DienThoai_InfoKH = G_DictConfig_Common.ContainsKey(Enum_Config_Common.DienThoai_InfoKH) && G_DictConfig_Common[Enum_Config_Common.DienThoai_InfoKH] == "1";

            IP_DefaultGateway = !G_DictConfig_Common.ContainsKey(Enum_Config_Common.IP_DefaultGateway) ? string.Empty : G_DictConfig_Common[Enum_Config_Common.IP_DefaultGateway];

            VungMacDinh = !G_DictConfig_Common.ContainsKey(Enum_Config_Common.VungMacDinh) ? string.Empty : G_DictConfig_Common[Enum_Config_Common.VungMacDinh];

            GridConfig = G_DictConfig_Common.ContainsKey(Enum_Config_Common.GridConfig) ? G_DictConfig_Common[Enum_Config_Common.GridConfig].To<int>() : 0;

            LenhMoiKhachKhiNhapXeDenDiem = G_DictConfig_Common.ContainsKey(Enum_Config_Common.LenhMoiKhachKhiNhapXeDenDiem) ? G_DictConfig_Common[Enum_Config_Common.LenhMoiKhachKhiNhapXeDenDiem].To<int>() : 0;
            //MauNen_SanBay = G_DictConfig_Common.ContainsKey(Enum_Config_Common.MauNen_SanBay) ? G_DictConfig_Common[Enum_Config_Common.MauNen_SanBay] : string.Empty;
            DungXe = (NhapXeDon)(G_DictConfig_Common.ContainsKey(Enum_Config_Common.DungXe) ? G_DictConfig_Common[Enum_Config_Common.DungXe].To<int>() : 0);
            CanhBaoKhiNhapXe = G_DictConfig_Common.ContainsKey(Enum_Config_Common.CanhBaoKhiNhapXe) ? G_DictConfig_Common[Enum_Config_Common.CanhBaoKhiNhapXe].To<int>() : 0;
            MauLaiXeNhanAppTongDai = Color.FromName(G_DictConfig_Common.ContainsKey(Enum_Config_Common.MauLaiXeNhanAppTongDai) ? G_DictConfig_Common[Enum_Config_Common.MauLaiXeNhanAppTongDai] : string.Empty);
            ColConfig = G_DictConfig_Common.ContainsKey(Enum_Config_Common.ColConfig) ? G_DictConfig_Common[Enum_Config_Common.ColConfig].To<int>() : 0;
            if (ColConfig % 2 == 1) ColConfig = (ColConfig / 2);
            if (ColConfig < 4) ColConfig = 4;
            CmdIdGiucXe = G_DictConfig_Common.ContainsKey(Enum_Config_Common.CmdIdGiucXe) ? G_DictConfig_Common[Enum_Config_Common.CmdIdGiucXe].To<int>() : 0;
            CmdIdGhiChu = G_DictConfig_Common.ContainsKey(Enum_Config_Common.CmdIdGhiChu) ? G_DictConfig_Common[Enum_Config_Common.CmdIdGhiChu].To<int>() : 0;
            DienThoai_KhungDiaChi = (KhungDiaChi)(G_DictConfig_Common.ContainsKey(Enum_Config_Common.DienThoai_KhungDiaChi) ? G_DictConfig_Common[Enum_Config_Common.DienThoai_KhungDiaChi].To<int>() : 0);
            TongDai_KhungDiaChi = (KhungDiaChi)(G_DictConfig_Common.ContainsKey(Enum_Config_Common.TongDai_KhungDiaChi) ? G_DictConfig_Common[Enum_Config_Common.TongDai_KhungDiaChi].To<int>() : 0);
            if (G_DictConfig_Common.ContainsKey(Enum_Config_Common.IP_DefaultGateway) && !string.IsNullOrEmpty(G_DictConfig_Common[Enum_Config_Common.IP_DefaultGateway]))
            {
                IP_DefaultGateway = G_DictConfig_Common[Enum_Config_Common.IP_DefaultGateway].Trim();
            }
            GEOService = (EnumGEOService)(G_DictConfig_Common.ContainsKey(Enum_Config_Common.GEOService) ? G_DictConfig_Common[Enum_Config_Common.GEOService].To<int>() : 0);
            TongDai_SapXepCuocGoi = (SapXepCuocGoi)(!G_DictConfig_Common.ContainsKey(Enum_Config_Common.TongDai_SapXepCuocGoi) || G_DictConfig_Common[Enum_Config_Common.TongDai_SapXepCuocGoi] == "" ? 0 : G_DictConfig_Common[Enum_Config_Common.TongDai_SapXepCuocGoi].To<int>());

            PBXIPVoicePath = G_DictConfig_Common.ContainsKey(Enum_Config_Common.PBXIPVoicePath) ? G_DictConfig_Common[Enum_Config_Common.PBXIPVoicePath] : string.Empty;
            CheckPhoneNumber = G_DictConfig_Common.ContainsKey(Enum_Config_Common.CheckPhoneNumber) ? G_DictConfig_Common[Enum_Config_Common.CheckPhoneNumber].To<int>() : 0;
            ChenXeDenDiemVaoXeNhan = G_DictConfig_Common.ContainsKey(Enum_Config_Common.ChenXeDenDiemVaoXeNhan) ? G_DictConfig_Common[Enum_Config_Common.ChenXeDenDiemVaoXeNhan].To<int>() : 0;
            CanhBaoLenhLaiXe = G_DictConfig_Common.ContainsKey(Enum_Config_Common.CanhBaoLenhLaiXe) ? G_DictConfig_Common[Enum_Config_Common.CanhBaoLenhLaiXe].To<int>() : 0;
            CauHinhTextLenh7 = G_DictConfig_Common.ContainsKey(Enum_Config_Common.CauHinhTextLenh7) ? G_DictConfig_Common[Enum_Config_Common.CauHinhTextLenh7].To<int>() : 0;
            CauHinhKetThucCuocLenh7 = G_DictConfig_Common.ContainsKey(Enum_Config_Common.CauHinhKetThucCuocLenh7) ? G_DictConfig_Common[Enum_Config_Common.CauHinhKetThucCuocLenh7].To<int>() : 0;
            ServiceDieuApp = (EnumServiceDieuApp)(G_DictConfig_Common.ContainsKey(Enum_Config_Common.ServiceDieuApp) ? G_DictConfig_Common[Enum_Config_Common.ServiceDieuApp].To<int>() : 0);
            CoCheDieuApp = (EnumCoCheDieuApp)(G_DictConfig_Common.ContainsKey(Enum_Config_Common.CoCheDieuApp) ? G_DictConfig_Common[Enum_Config_Common.CoCheDieuApp].To<int>() : 0);
            CuocOnline = (G_DictConfig_Common.ContainsKey(Enum_Config_Common.CuocOnline) && (G_DictConfig_Common[Enum_Config_Common.CuocOnline] == "1"));
            BoVietTatNgo = (G_DictConfig_Common.ContainsKey(Enum_Config_Common.BoVietTatNgo) && (G_DictConfig_Common[Enum_Config_Common.BoVietTatNgo] == "1"));
            KetThucCuocKhieuNai = (G_DictConfig_Common.ContainsKey(Enum_Config_Common.KetThucCuocKhieuNai) && (G_DictConfig_Common[Enum_Config_Common.KetThucCuocKhieuNai] == "1"));
            AnKieuCuocGoiKhac = (G_DictConfig_Common.ContainsKey(Enum_Config_Common.AnKieuCuocGoiKhac) && (G_DictConfig_Common[Enum_Config_Common.AnKieuCuocGoiKhac] == "1"));
            CmdIdLenhKoLienLac = (G_DictConfig_Common.ContainsKey(Enum_Config_Common.CmdIdLenhKoLienLac) ? G_DictConfig_Common[Enum_Config_Common.CmdIdLenhKoLienLac].To<int>() : 0);
            DienThoai_LayGPSLichSuCuoc = (G_DictConfig_Common.ContainsKey(Enum_Config_Common.DienThoai_LayGPSLichSuCuoc) && (G_DictConfig_Common[Enum_Config_Common.DienThoai_LayGPSLichSuCuoc] == "1"));
            DienThoai_DieuApp_CoXeNhanChoPhepDieuLai = (G_DictConfig_Common.ContainsKey(Enum_Config_Common.DienThoai_DieuApp_CoXeNhanChoPhepDieuLai) && (G_DictConfig_Common[Enum_Config_Common.DienThoai_DieuApp_CoXeNhanChoPhepDieuLai] == "1"));
            DienThoai_AppkhongXe_ChoPhepDieuLai = (G_DictConfig_Common.ContainsKey(Enum_Config_Common.DienThoai_AppkhongXe_ChoPhepDieuLai) && (G_DictConfig_Common[Enum_Config_Common.DienThoai_AppkhongXe_ChoPhepDieuLai] == "1"));
            DienThoai_DieuLai_TickDieuApp = (G_DictConfig_Common.ContainsKey(Enum_Config_Common.DienThoai_DieuLai_TickDieuApp) && (G_DictConfig_Common[Enum_Config_Common.DienThoai_DieuLai_TickDieuApp] == "1"));

            DienThoai_DieuApp_ThoiGianChuyenDam = (G_DictConfig_Common.ContainsKey(Enum_Config_Common.DienThoai_DieuApp_ThoiGianChuyenDam) && G_DictConfig_Common[Enum_Config_Common.DienThoai_DieuApp_ThoiGianChuyenDam].To<int>() > 60 ? G_DictConfig_Common[Enum_Config_Common.DienThoai_DieuApp_ThoiGianChuyenDam].To<int>() : 90);
            DienThoai_ChuyenDam_DieuLai = (G_DictConfig_Common.ContainsKey(Enum_Config_Common.DienThoai_ChuyenDam_DieuLai) && (G_DictConfig_Common[Enum_Config_Common.DienThoai_ChuyenDam_DieuLai] == "1"));
            DienThoai_DieuApp_ChuyenDam = (G_DictConfig_Common.ContainsKey(Enum_Config_Common.DienThoai_DieuApp_ChuyenDam) ? G_DictConfig_Common[Enum_Config_Common.DienThoai_DieuApp_ChuyenDam].To<int>() : 0);
            DienThoai_CanhBaoTrungDiaChi = (G_DictConfig_Common.ContainsKey(Enum_Config_Common.DienThoai_CanhBaoTrungDiaChi) && (G_DictConfig_Common[Enum_Config_Common.DienThoai_CanhBaoTrungDiaChi] == "1"));
            DienThoai_ChuyenKhachMGThanhKhachThuong = (G_DictConfig_Common.ContainsKey(Enum_Config_Common.DienThoai_ChuyenKhachMGThanhKhachThuong) && (G_DictConfig_Common[Enum_Config_Common.DienThoai_ChuyenKhachMGThanhKhachThuong] == "1"));
            DienThoai_DieuApp_ThoiGianChoPhepChonChuyenDam = (G_DictConfig_Common.ContainsKey(Enum_Config_Common.DienThoai_DieuApp_ThoiGianChoPhepChonChuyenDam) ? G_DictConfig_Common[Enum_Config_Common.DienThoai_DieuApp_ThoiGianChoPhepChonChuyenDam].To<int>() : 0);
            DienThoai_DieuApp_ThoiGianChoPhepChonDieuLai = (G_DictConfig_Common.ContainsKey(Enum_Config_Common.DienThoai_DieuApp_ThoiGianChoPhepChonDieuLai) ? G_DictConfig_Common[Enum_Config_Common.DienThoai_DieuApp_ThoiGianChoPhepChonDieuLai].To<int>() : 0);
            DienThoai_DieuApp_CanhBaoMatKetNoiVoiServerDieuHanh = (G_DictConfig_Common.ContainsKey(Enum_Config_Common.DienThoai_DieuApp_CanhBaoMatKetNoiVoiServerDieuHanh) && (G_DictConfig_Common[Enum_Config_Common.DienThoai_DieuApp_CanhBaoMatKetNoiVoiServerDieuHanh] == "1"));
            DienThoai_DieuApp_DieuLaiGiuCuocCu = (G_DictConfig_Common.ContainsKey(Enum_Config_Common.DienThoai_DieuApp_DieuLaiGiuCuocCu) && (G_DictConfig_Common[Enum_Config_Common.DienThoai_DieuApp_DieuLaiGiuCuocCu] == "1"));
            DienThoai_DieuApp_SleepCuocSaoChep = (G_DictConfig_Common.ContainsKey(Enum_Config_Common.DienThoai_DieuApp_SleepCuocSaoChep) ? G_DictConfig_Common[Enum_Config_Common.DienThoai_DieuApp_SleepCuocSaoChep].To<int>() : 0);
            DienThoai_DieuApp_DaMoiCmdId = (G_DictConfig_Common.ContainsKey(Enum_Config_Common.DienThoai_DieuApp_DaMoiCmdId) ? G_DictConfig_Common[Enum_Config_Common.DienThoai_DieuApp_DaMoiCmdId].To<int>() : 0);
            ServiceConnectString = (G_DictConfig_Common.ContainsKey(Enum_Config_Common.ServiceConnectString) ? G_DictConfig_Common[Enum_Config_Common.ServiceConnectString].To<string>() : string.Empty);
            DienThoai_ChonLoaiXe = (G_DictConfig_Common.ContainsKey(Enum_Config_Common.DienThoai_ChonLoaiXe) ? (int)G_DictConfig_Common[Enum_Config_Common.DienThoai_ChonLoaiXe].To<long>() : 0);
            DienThoai_DieuApp_TruotKhiCoXeNhan = (G_DictConfig_Common.ContainsKey(Enum_Config_Common.DienThoai_DieuApp_TruotKhiCoXeNhan) && (G_DictConfig_Common[Enum_Config_Common.DienThoai_DieuApp_TruotKhiCoXeNhan] == "1"));
            DienThoai_DieuApp_SoPhutChoPhepNhapXeDonKhiCoXeNhan = (G_DictConfig_Common.ContainsKey(Enum_Config_Common.DienThoai_DieuApp_SoPhutChoPhepNhapXeDonKhiCoXeNhan) ? G_DictConfig_Common[Enum_Config_Common.DienThoai_DieuApp_SoPhutChoPhepNhapXeDonKhiCoXeNhan].To<int>() : 0);
            DienThoai_DieuApp_XuLyCuocGoiSaoChep = DienThoai_DieuApp_XuLyCuocGoiSaoChep = (G_DictConfig_Common.ContainsKey(Enum_Config_Common.DienThoai_DieuApp_XuLyCuocGoiSaoChep) ? G_DictConfig_Common[Enum_Config_Common.DienThoai_DieuApp_XuLyCuocGoiSaoChep].To<int>() : 0);
            DienThoai_RequiredGPS = (G_DictConfig_Common.ContainsKey(Enum_Config_Common.DienThoai_RequiredGPS) && (G_DictConfig_Common[Enum_Config_Common.DienThoai_RequiredGPS] == "1"));
            TongDai_RequiredShowMap = (G_DictConfig_Common.ContainsKey(Enum_Config_Common.TongDai_RequiredShowMap) && (G_DictConfig_Common[Enum_Config_Common.TongDai_RequiredShowMap] == "1"));
            DienThoai_UpdateCustomerHabit = (G_DictConfig_Common.ContainsKey(Enum_Config_Common.DienThoai_UpdateCustomerHabit) ? (int)G_DictConfig_Common[Enum_Config_Common.DienThoai_UpdateCustomerHabit].To<long>() : 0);
            DienThoai_DieuLai_BookIdOld = GetValue<bool>(Enum_Config_Common.DienThoai_DieuLai_BookIdOld);//(// (G_DictConfig_Common.ContainsKey(Enum_Config_Common.DienThoai_DieuLai_BookIdOld) && (G_DictConfig_Common[Enum_Config_Common.DienThoai_DieuLai_BookIdOld] == "1"));
            MPCC_TrunkDial = (G_DictConfig_Common.ContainsKey(Enum_Config_Common.MPCC_TrunkDial) ? G_DictConfig_Common[Enum_Config_Common.MPCC_TrunkDial] : "");
            MPCC_Queue = (G_DictConfig_Common.ContainsKey(Enum_Config_Common.MPCC_Queue) ? G_DictConfig_Common[Enum_Config_Common.MPCC_Queue] : "");
            MPCC_LinkDial = (G_DictConfig_Common.ContainsKey(Enum_Config_Common.MPCC_LinkDial) ? G_DictConfig_Common[Enum_Config_Common.MPCC_LinkDial] : "");
            Asterisk_QuickCall = GetValue<bool>(Enum_Config_Common.Asterisk_QuickCall);
            ChannelDial = GetValue<string>(Enum_Config_Common.ChannelDial);
            DieuSanBay = GetValue<int>(Enum_Config_Common.DieuSanBay);
            CoDieuApp = GetValue<bool>(Enum_Config_Common.CoDieuApp);
            CotKhachHen = GetValue<bool>(Enum_Config_Common.CotKhachHen);
            CanhBaoCuocSanBay = GetValue<bool>(Enum_Config_Common.CanhBaoCuocSanBay);
            NhapTuyenDuongDai = GetValue<bool>(Enum_Config_Common.NhapTuyenDuongDai);
            CauHinhThueBaoTuyen = GetValue<bool>(Enum_Config_Common.CauHinhThueBaoTuyen);
            AutoCheckLicense = GetValue<bool>(Enum_Config_Common.AutoCheckLicense);
        }

        #endregion

        #region == New ===
        private static DateTime _LastUpdate;
        private static List<CommonPropertyInfo> listProperty;
        private static Type @this;
        public static void LoadConfigCommonByLastUpdate()
        {
            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += (s, e) =>
            {

                var list = GetLastDate(_LastUpdate);
                if (list != null && list.Count > 0)
                {
                    if (@this == null)
                        @this = typeof(Config_Common);
                    if (listProperty == null)
                    {
                        listProperty = @this.GetProperties(BindingFlags.Static | BindingFlags.Public).Select(p =>
                        {
                            p.SetValue(@this, GetDefaultValue(p.PropertyType), null);
                            var att = p.GetAttribute<EnumConfigCommonAttribute>();
                            if (att != null)
                            {
                                return new CommonPropertyInfo
                                {
                                    Name = p.Name,
                                    PropertyAtt = att,
                                    PropertyType = p.PropertyType
                                };
                            }
                            return null;
                        }).Where(p => p != null).ToList();
                    }
                    list.Join(listProperty, p => p.Enum, pro => pro.PropertyAtt.EnumItem, (T1, T2) =>
                         new { T1, T2 }
                    )
                    .All(p =>
                    {
                        if (p.T1.LastUpdate > _LastUpdate)
                            _LastUpdate = p.T1.LastUpdate;
                        if (p.T2.PropertyAtt.ConvertType != null && p.T2.PropertyAtt.ConvertType != p.T2.PropertyType)
                        {
                            @this.GetProperty(p.T2.Name).SetValue(@this, ConvertToType(ConvertToType(p.T1.HasValue, p.T2.PropertyAtt.ConvertType, p.T2.PropertyAtt.ValueDefault), p.T2.PropertyType, p.T2.PropertyAtt.ValueDefault), null);

                        }
                        else @this.GetProperty(p.T2.Name).SetValue(@this, ConvertToType(p.T1.HasValue, p.T2.PropertyType, p.T2.PropertyAtt.ValueDefault), null);

                        return true;
                    });

                }
            };
            backgroundWorker.RunWorkerCompleted += (s, e) =>
            {
                if (e.Error != null)
                    LogError.WriteLogError("LoadConfigCommonByLastUpdate", e.Error);
            };
            backgroundWorker.RunWorkerAsync();
        }
        public static void LoadConfigCommon()
        {
            try
            {
                if (@this == null)
                    @this = typeof(Config_Common);
                if (listProperty == null)
                {
                    listProperty = @this.GetProperties(BindingFlags.Static | BindingFlags.Public).Select(p =>
                    {
                        p.SetValue(@this, GetDefaultValue(p.PropertyType), null);
                        var att = p.GetAttribute<EnumConfigCommonAttribute>();
                        if (att != null)
                        {
                            return new CommonPropertyInfo
                            {
                                Name = p.Name,
                                PropertyAtt = att,
                                PropertyType = p.PropertyType
                            };
                        }
                        return null;
                    }).Where(p => p != null).ToList();
                }

                _LastUpdate = DateTime.Now;//CommonBL.GetTimeServer();
                var list = GetAllConfig();
                if (list != null && list.Count > 0)
                {
                    list.Join(listProperty, p => p.Enum, pro => pro.PropertyAtt.EnumItem, (T1, T2) =>
                         new { T1, T2 }
                    )
                    .All(p =>
                    {
                        if (p.T1.LastUpdate > _LastUpdate)
                            _LastUpdate = p.T1.LastUpdate;
                        if (p.T2.PropertyAtt.ConvertType != null && p.T2.PropertyAtt.ConvertType != p.T2.PropertyType)
                        {
                            @this.GetProperty(p.T2.Name).SetValue(@this, ConvertToType(ConvertToType(p.T1.HasValue, p.T2.PropertyAtt.ConvertType, p.T2.PropertyAtt.ValueDefault), p.T2.PropertyType, p.T2.PropertyAtt.ValueDefault), null);

                        }
                        else @this.GetProperty(p.T2.Name).SetValue(@this, ConvertToType(p.T1.HasValue, p.T2.PropertyType, p.T2.PropertyAtt.ValueDefault), null);

                        return true;
                    });
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("LoadConfigCommon: ",ex);
            }
        }
        public static Tr GetValue<Tr>(Enum_Config_Common TEnum)
        {
            return (Tr)GetValue(TEnum, typeof(Tr));
        }
        public static object GetValue(Enum_Config_Common TEnum, Type type)
        {
            return GetValue(G_DictConfig_Common, TEnum, type);
        }
        public static object GetValue(Dictionary<Enum_Config_Common, string> DictConfig_Common, Enum_Config_Common TEnum, Type type)
        {
            if (DictConfig_Common.ContainsKey(TEnum))
            {
                return ConvertToType(DictConfig_Common[TEnum], type);
            }
            else
            {
                return GetDefaultValue(type);
            }
        }
        public static object ConvertToType(object obj, Type type, object valueDefult = null)
        {

            if (obj != null)
            {
                if (type == typeof(Color))
                {
                    return Color.FromName(obj.ToString());
                }
                else if (type.IsEnum)
                {
                    return ConvertToType(obj, typeof(int), valueDefult);
                }
                else
                {
                    var convert = SqlTypeDescriptor.Inst.GetConverter(type);
                    if (convert == null) throw new Exception(string.Format("Không thấy kiểu dữ liệu {0}", type.Name));
                    return convert.CanConvertFrom(obj.GetType()) ? convert.ConvertFrom(obj) : (valueDefult ?? GetDefaultValue(type));
                }
            }
            else
            {
                return (valueDefult ?? GetDefaultValue(type));
            }
        }
        private static object GetDefaultValue(Type t)
        {
            if (t == typeof(string) || t == typeof(String)) return "";
            if (t.IsValueType)
                return Activator.CreateInstance(t);

            return null;
        }
        #endregion

        #region === Data ===

        /// <summary>
        /// Lấy tất cả các config
        /// </summary>
        public static List<Config_Common> GetAllConfig()
        {
            using (var dt = new Config_CommonDA().GetAllConfig())
            {
                List<Config_Common> lstConfig = new List<Config_Common>();
                if (dt != null && dt.Rows.Count > 0)
                {
                    lstConfig = dt.Rows.Cast<DataRow>().Select(ConvertRow).ToList();
                }
                return lstConfig;
            }
        }
        public static List<Config_Common> GetLastDate(DateTime dt)
        {
            return new Config_CommonDA().GetLastDate(dt).Rows.Cast<DataRow>().Select(ConvertRow).ToList();
        }
        public static Config_Common ConvertRow(DataRow dr)
        {
            return new Config_Common
                         {
                             Id = (int)dr["Id"],
                             Name = dr["Name"].ToString(),
                             HasValue = dr["HasValue"].ToString(),
                             Description = dr["Description"].ToString(),
                             LastUpdate = dr.Table.Columns.Contains("LastUpdate") ? dr["LastUpdate"].To<DateTime>() : DateTime.MinValue
                         };
        }
        public static bool Update(Enum_Config_Common enumId, string value)
        {
            try
            {
                var item = enumId.GetType().GetField(enumId.ToString()).GetAttribute<EnumItemTypeAttribute>();
                if (item != null)
                {
                    using (var dt = new Config_CommonDA())
                    {
                        return dt.Update((int)enumId, value, item.Name, item.Description);
                    }
                }
                else
                {
                    using (var dt = new Config_CommonDA())
                    {
                        return dt.Update((int)enumId, value);
                    }
                }

            }
            catch (Exception ex)
            {
                LogError.WriteLogError("Config_Common.Update", ex);
                return false;
            }

        }
        public static bool Update(int Id, string value)
        {
            return Update((Enum_Config_Common)Id, value);

        }

        #endregion

        #endregion

    }
}
