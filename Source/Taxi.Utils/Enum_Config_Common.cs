using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Common.EnumUtility;

namespace Taxi.Utils
{
    #region === Enum ===
    /// <summary>
    /// Enum Geo Service
    /// </summary>
    public enum EnumGEOService
    {
        /// <summary>
        /// Ưu tiên tìm theo BA trước,
        /// Không có thì tìm theo google
        /// </summary>
        [EnumItem("Mặc định")]
        Default = 0,
        /// <summary>
        /// Tìm theo google
        /// </summary>
        [EnumItem("Google")]
        Google = 1,
        /// <summary>
        /// Tìm theo Bình Anh
        /// </summary>
        [EnumItem("Bình anh")]
        BinhAnh = 2
    }
    public enum KhungDiaChi
    {
        [EnumItem("Dưới")]
        Duoi=0,
        [EnumItem("Trên")]
        Tren=1
    }
    public enum SapXepCuocGoi
    {
        [EnumItem("Mặc định")]
        None = 0,
        /// <summary>
        /// 2 : Cuốc mới
        /// </summary>
        [EnumItem("Cuốc mới")]
        SapXepCuocMoi = 1,
        /// <summary>
        /// 2 : Thời gian
        /// </summary>
        [EnumItem("Thời gian")]
        SapXepThoiGian = 2,
        /// <summary>
        /// 3 : Loại cuốc
        /// </summary>
        [EnumItem("Loại cuốc")]
        SapXepKieuKhachHang=3,
        /// <summary>
        /// 4 : Loại cuốc,ưu tiên app kh
        /// </summary>
        [EnumItem("Loại cuốc,ưu tiên app kh")]
        SapXepKieuKhachHangApp=4
    }
    public enum NhapXeDon
    {
        [EnumItem("Mặc định")]
        None=0,
        [EnumItem("Chèn xe đến điểm")]
        XeDenDiem = 1,
        [EnumItem("Chèn xe MK")]
        XeMK=2,
        [EnumItem("Chèn xe nhận")]
        XeNhan = 3,  
        [EnumItem("Chèn xe MK - đến điểm - nhận")]
        XeMK_XeDenDiem_XeNhan = 4,
        [EnumItem("Chèn xe đến điểm - MK - nhận")]
        XeDenDiem_XeMK_XeNhan=5
    }
    /// <summary>
    /// Enum Service điều app
    /// </summary>
    public enum EnumServiceDieuApp
    {
        /// <summary>
        /// Ưu tiên tìm theo G5,
        /// </summary>
        [EnumItem("Mặc định-G5")]
        Default = 0,
        /// <summary>
        /// Cách điều G5
        /// </summary>
        [EnumItem("G5")]
        G5 = 1,
        /// <summary>
        /// Cách điều BaSao
        /// </summary>
        [EnumItem("BaSao")]
        BaSao = 2
    }
    /// <summary>
    /// 78.Cơ chế điều app
    /// </summary>
    public enum EnumCoCheDieuApp
    {
        /// <summary>
        /// 0:Mặc định
        /// </summary>
        [EnumItem("Mặc định")]
        Default=0,
        /// <summary>
        /// 1:Gửi cho tất cả nếu có gps
        /// </summary>
        [EnumItem("Gửi cho tất cả")]
        GuiTatCaCoGPS=1,
        /// <summary>
        /// 2:Điêu chỉ định
        /// </summary>
        [EnumItem("Điều chỉ định")]
        DieuChiDinhGPS=2
    }

    public enum Enum_SendSMSCuocDuongDai_App
    {
        NhapXeDon = 1,
        NhapLenhDaMoi = 2,
        NhapLenhKhac = 22
    }
    public enum Enum_SendSMSCuocDuongDai_Dam
    {
        NhapXeDon = 1,
        NhapXeDenDiem = 2,
        NhapLenhKhac = 23
    }

    #endregion
    /// <summary>
    /// Cấu hình chung
    /// </summary>
    public enum Enum_Config_Common
    {
        /// <summary>
        /// 1 : Font size của lưới hiển thị cuộc gọi bên tiếp nhận
        /// </summary>
        LuoiCuocGoi_FontSize_TiepNhan = 1,
        /// <summary>
        /// 2 : Không cho phép nhập xe nhận trùng ở 2 điểm
        /// </summary>
        TongDai_HienThiCanhBao_NhapTrungXeNhan = 2,
        /// <summary>
        /// 3 : Có hiển thị Popup cuộc gọi hay không
        /// </summary>
        [EnumItemType("Hiển thị Popup cuộc gọi", "Có hiển thị Popup cuộc gọi hay không")]
        [DisplayValue("Có", "1", true)]
        [DisplayValue("Không", "0")]
        HienThiPopup = 3,
        /// <summary>
        /// 4 : Font size của lưới tiếp nhận bên phải
        /// </summary>
        LuoiCuocGoi_FontSize_TiepNhan_Right = 4,
        /// <summary>
        /// 5 : Hiển thị màu nền của Loại xe ở lưới cuộc gọi
        /// </summary>
        LuoiCuocGoi_MauNen_LoaiXe = 5,
        /// <summary>
        /// 6 : Hiển thị màu nền của lệnh mời khách
        /// = 1: chỉ đổi ở ô Lệnh
        /// = 2: đổi màu ở cả dòng
        /// ngược lại thì ko đổi màu
        /// </summary>
        LuoiCuocGoi_HienThiMauNen_LenhMoi = 6,
        /// <summary>
        /// 7 : Tên màu nền Lệnh Mời. Chỉ nhận tên màu (Red, Blue,Green,...)
        /// </summary>
        [EnumItemType("Màu nền Lệnh Mời", "màu nền Lệnh Mời của lưới bên phải", Type = Enum_ItemType.Color)]
        LuoiCuocGoi_MauNen_LenhMoi = 7,
        /// <summary>
        /// 8 : Tên màu nền Lệnh Mời của lưới bên phải. Chỉ nhận tên màu (Red, Blue,Green,...)
        /// </summary>
        [EnumItemType("Màu nền Lệnh Mời lưới phải", "màu nền Lệnh Mời của lưới bên phải", Type = Enum_ItemType.Color)]
        LuoiCuocGoi_MauNen_LenhMoi_Right = 8,
        /// <summary>
        /// 9 : Độ cao của dòng (lưới cuộc gọi tiếp nhận)
        /// </summary>
        LuoiCuocGoi_RowHeight_TiepNhan = 9,
        /// <summary>
        /// 10 : Độ cao của dòng (lưới cuộc gọi tiếp nhận bên phải)
        /// </summary>
        LuoiCuocGoi_RowHeight_TiepNhan_Right = 10,
        /// <summary>
        /// 11 : Độ cao của dòng (lưới cuộc gọi điều xe bên tổng đài)
        /// </summary>
        [EnumItemType("Chiều cao dòng lưới", "Chiều cao dòng lưới", TextMask = "\\d+", Length = 2)]
        LuoiCuocGoi_RowHeight_TongDai = 11,
        /// <summary>
        /// 12 : Font chữ lưới cuộc gọi-Tổng đài
        /// </summary>
        [EnumItemType("Size chữ lưới", " Size chữ lưới bình thường", TextMask = "\\d+", Length = 2)]
        LuoiCuocGoi_FontSize_TongDai = 12,
        /// <summary>
        /// 13 : Hiển thị màu nền của lệnh mời khách(Lưới bên phải
        /// = 1: chỉ đổi ở ô Lệnh
        /// = 2: đổi màu ở cả dòng
        /// ngược lại thì ko đổi màu
        /// </summary>
        // [EnumItemType("Font chữ lưới", " Font chữ lưới bình thường", TextMask = @"+\d", Length = 2)]
        LuoiCuocGoi_HienThiMauNen_LenhMoi_Right = 13,
        /// <summary>
        /// 14 : Cảnh báo xe đón không trùng xe nhận
        /// Hiển thị cảnh báo nhập trùng xe nhận
        /// 0 : Không cảnh báo
        /// 1 : Có cảnh báo nhưng không cho phép nhập
        /// 2 : Có cảnh báo nhưng vẫn cho nhập
        /// </summary>
        [EnumItemType("C.Báo xe đón không trùng xe nhận", "Cảnh Báo xe đón không trùng xe nhận")]
        [DisplayValue("Không cảnh báo", "0", true)]
        [DisplayValue("Có c.báo,ko cho phép nhập", "1")]
        [DisplayValue("Có c.báo,vẫn cho nhập", "2")]
        TongDai_HienThiCanhBao_XeDonTrungXeNhan = 14,
        /// <summary>
        /// 15:cuốc gọi thường không xe nhân thì đưa lên đầu.
        /// =0:Không thực hiện.
        /// =n:sau n phút chưa có xe nhận thì đưa lên đầu.
        /// </summary>
        [EnumItemType("H.thị l.đầu ko xe nhận", "H.thị l.đầu ko xe nhận")]
        LuoiCuocGoi_CuocGoi_HienThiLenDauKhongXeNhan = 15,
        /// <summary>
        /// 16:cuốc Staxi không xe nhân thì đưa lên đầu.
        /// =0:Không thực hiện.
        /// =n:sau n phút chưa có xe nhận thì đưa lên đầu.
        /// </summary>
        [EnumItemType("Staxi H.thị l.đầu ko xe nhận", "H.thị l.đầu ko xe nhận")]
        LuoiCuocGoi_Staxi_HienThiLenDauKhongXeNhan = 16,

        /// <summary>
        /// 17.Hiển thị xe đề cử trên bản đồ mini
        /// </summary>
        [EnumItemType("H.thị x.đề cử", "Hiển thị xe đề cử trên bản đồ mini")]
        BanDoMini_HienThiXeDeCu = 17,
        /// <summary>
        /// 18.Hiển thị xe nhận trên bản đồ mini
        /// </summary>
        [EnumItemType("H.thị x.nhận", "Hiển thị xe nhận trên bản đồ mini")]
        BanDoMini_HienThiXeNhan = 18,
        /// <summary>
        /// 19.Màu nền cuốc chưa xử lý.
        /// </summary>
        [EnumItemType("Màu nền cuốc chưa xử lý", "Màu nền cuốc chưa xử lý", Type = Enum_ItemType.Color)]
        Grid_CuocChuaXuLy_BackGround = 19,
        /// <summary>
        /// 20.Nhập xe đến điểm,không 
        /// </summary>
        [EnumItemType("Cho phép kết thúc cuốc không xe trước", "Cho phép kết thúc cuốc không xe trước khi có lệnh không xe xl khách của tổng đài")]
        [DisplayValue("Có", "0", true)]
        [DisplayValue("Không", "1")]
        DienThoai_ChoPhepKetThucKhongXeTruoc = 20,
        /// <summary>
        /// 21.Màu nền lưới cuốc gọi
        /// </summary>
        [EnumItemType("DTV.M.nền lưới cuốc gọi", "Màu nền lưới cuốc gọi", Type = Enum_ItemType.Color)]
        TongDai_MauNen_LuoiCuocGoi = 21,
        /// <summary>
        /// 22.Check xe vi phạm lỗi.
        /// </summary>
        [EnumItemType("K.Tra xe v.Phạm lỗi", "Kiểm tra xe vi phạm lỗi")]
        [DisplayValue("Không", "0", true)]
        [DisplayValue("Có", "1")]
        TongDai_CheckXeViPham = 22,
        /// <summary>
        /// 23.Đăng nhập nhiều máy trên 1 tài khoản.
        /// 0:cho phép.
        /// 1:không cho phép.
        /// </summary>
        [EnumItemType("Đăng nhập nhiều máy", "Đăng nhập nhiều máy trên 1 tài khoản")]
        [DisplayValue("Có", "0", true)]
        [DisplayValue("Không", "1")]
        DangNhapNhieuMay = 23,
        /// <summary>
        /// 24.Màu nền cuốc gọi hỏi đàm.
        /// </summary>

        [EnumItemType("M.nền c.gọi h.đàm", "Màu nền cuốc gọi hỏi đàm", Type = Enum_ItemType.Color)]
        Grid_CuocHoiDam_BackGround = 24,
        /// <summary>
        /// 25.lấy lịch sử cuốc khách theo số điện thoại
        /// </summary>
        [EnumItemType("Lấy l.sử C.Khách", "lấy lịch sử cuốc khách theo số điện thoại", "\\d+")]
        DienThoai_LayLichSuCuoc = 25,
        /// <summary>
        /// 26.Ẩn thông báo hoãn cuốc.
        /// </summary>
        [EnumItemType("Ẩn t.báo hoãn cuốc", "Ẩn thông báo hoãn cuốc")]
        TongDai_AnThongBaoKhiHoanCuoc = 26,
        /// <summary>
        /// 27.Sử dung bàn cờ trong tổng đài.
        /// </summary>
        [EnumItemType("Bàn cờ trong tổng đài", "Sử dung bàn cờ trong tổng đài")]
        [DisplayValue("Không", "0", true)]
        [DisplayValue("Có", "1")]
        TongDai_BanCo = 27,
        /// <summary>
        /// 28.Chèn cuốc Hoa Hồng
        /// </summary>
        ChenCuoc_HoaHong = 28,
        /// <summary>
        /// 29.Tên cột trên lưới của Trường Ghi chú tổng đài.
        /// </summary>
        [EnumItemType("Tên cột G.chú t.đài", "Tên cột trên lưới của Trường Ghi chú tổng đài")]
        TongDai_TenCotGhiChuTongDai = 29,
        /// <summary>
        /// 30.Lấy địa chỉ đón của cuốc lịch sử
        /// </summary>
        [EnumItemType("Lấy đ/c đón cuốc l.sử", "Lấy địa chỉ đón của cuốc lịch sử")]
        [DisplayValue("Không", "0", true)]
        [DisplayValue("Có", "1")]
        DienThoai_LayDiaChiLichSu = 30,
        /// <summary>
        /// 31.Chuyển các cuốc gọi gần cuốc gọi lại.
        /// </summary>
        [EnumItemType("TDV.S.xếp cuốc g.lại", "Chuyển các cuốc gọi gần cuốc gọi lại")]
        [DisplayValue("Không", "0", true)]
        [DisplayValue("Có", "1")]
        TongDai_ChuyenCacCuocGoiGanCuocGoiLai = 31,
        /// <summary>
        /// 32.Gộp line.
        /// </summary>
        [EnumItemType("Gộp line", "Gộp line")]
        GopLine = 32,

        /// <summary>
        /// 33.
        /// </summary>
        [EnumItemType("T.tin G/Chú KH", "Lấy thông tin ghi chú KH")]
        [DisplayValue("Không", "0", true)]
        [DisplayValue("Có", "1")]
        GetThongTinGhiChuKH = 33,

        /// <summary>
        /// 37. Server tổng đài siemens
        /// </summary>
        [EnumItemType("Server t.đài siemens", "Server tổng đài siemens")]
        TongDai_ServerSiemens_Address = 37,
        /// <summary>
        /// 44.Cấu hình Điều app
        /// </summary>
        [EnumItemType("Điều App", "Điều App")]
        [DisplayValue("Không", "0", true)]
        [DisplayValue("Có", "1")]
        DienThoai_DieuTuDong = 44,
        /// <summary>
        /// 45.Server tự động kết thúc khi có xe đón
        /// </summary>
        [EnumItemType("App.Server k.thúc khi có x.đón", "Server tự động kết thúc khi có xe đón")]
        [DisplayValue("Không", "0", true)]
        [DisplayValue("Có", "1")]
        Server_DieuTuDongTuKetThuc = 45,
        /// <summary>
        /// 46.Điều App khi không lấy được tọa độ sẽ cảnh báo.
        /// </summary>
        [EnumItemType("C.Báo App", "Điều App khi không lấy được tọa độ sẽ cảnh báo")]
        [DisplayValue("Không", "0", true)]
        [DisplayValue("Có", "1")]
        DienThoai_DieuApp_CanhBaoGPS = 46,
        /// <summary>
        /// 47.Điện thoại nhận phản ánh và khiếu nại
        /// </summary>
        [EnumItemType("DTV.P.Ánh & K.Nại", "Điện thoại nhận phản ánh và khiếu nại")]
        DienThoai_PhanAnhKhieuNai = 47,
        /// <summary>
        /// 48.AMI_HostName
        /// </summary>
        [EnumItemType("AMI_HostName", "AMI_HostName")]
        AMI_HostName = 48,
        /// <summary>
        /// 49.AMI_Port
        /// </summary>
        [EnumItemType("AMI_Port", "AMI_Port")]
        AMI_Port = 49,
        /// <summary>
        /// 50.AMI_UserName
        /// </summary>
        [EnumItemType("AMI_Password", "AMI_Password")]
        AMI_UserName = 50,
        /// <summary>
        /// 51.AMI_Password
        /// </summary>
        [EnumItemType("AMI_Password", "AMI_Password")]
        AMI_Password = 51,
        /// <summary>
        /// 52.Lấy thông tin khách hàng hiển thị lên.
        /// </summary>
        [EnumItemType("DTV.Hiển thị T.Tin KH", "Lấy thông tin khách hàng hiển thị lên")]
        [DisplayValue("Không", "0", true)]
        [DisplayValue("Có", "1")]
        DienThoai_InfoKH = 52,

        /// <summary>
        /// 53.Vùng mặc định
        /// </summary>
        [EnumItemType("Vùng mặc định", "Vùng mặc định", "\\d+", 2)]
        VungMacDinh = 53,
        /// <summary>
        /// 54.GridConfig
        /// </summary>
        [EnumItemType("DTV.Lưới phụ", "Lưới phụ của điện thoại viên")]
        [DisplayValue("Mặc định", "0", true)]
        [DisplayValue("Lưới line khác", "1")]
        [DisplayValue("Lưới chờ G.quyết", "2")]
        GridConfig = 54,
        /// <summary>
        /// 53.DefaultGateway
        /// </summary>
        IP_DefaultGateway = 55,
        /// <summary>
        /// 56.Nhập lệnh mời khách khi nhập xe đến điểm
        /// </summary>
        [EnumItemType("TDV.MK khi xe Đ.Điểm", "Nhập lệnh mời khách khi nhập xe đến điểm")]
        [DisplayValue("Không", "0", true)]
        [DisplayValue("Có", "1")]
        LenhMoiKhachKhiNhapXeDenDiem = 56,
        /// <summary>
        /// 57.Màu nền sân bay
        /// </summary>
        [EnumItemType("Màu nền sân bay", "Màu nền sân bay", Type = Enum_ItemType.Color)]
        Grid_CuocSanBay_BackGround = 57,
        /// <summary>
        /// 58.Dùng xe nhập xe đón
        /// </summary>
        [EnumItemType("Dùng xe nhập xe đón", "Dùng xe nhập xe đón", ValueEnum = typeof(NhapXeDon))]
        DungXe = 58,
        /// <summary>
        /// 59.cảnh báo khi nhập xe
        /// </summary>
        [EnumItemType("c.báo khi nhập xe", "Cảnh báo khi nhập xe")]
        [DisplayValue("Không", "1", true)]
        [DisplayValue("Có", "0")]
        CanhBaoKhiNhapXe = 59,
        /// <summary>
        /// 60.GEOService
        /// 0:BA-GG 1:google 2:BA
        /// </summary>
        [EnumItemType("GEOService", "GEOService", ValueEnum = typeof(EnumGEOService))]
        GEOService = 60,
        /// <summary>
        /// 61.Line Khách đặt
        /// </summary>
        [EnumItemType("Line khách đặt", "Line khách đặt", TextMask = "\\d+", Length = 3)]
        LineKhachDat = 61,
        /// <summary>
        /// 62.Màu server trả về muộn khi cuốc khách đã sang tổng đài.
        /// </summary>
        [EnumItemType("Màu server trả về muộn", "Màu server trả về muộn khi đã sang đàm rồi.", Type = Enum_ItemType.Color)]
        MauLaiXeNhanAppTongDai = 62,
        /// <summary>
        ///  63.Số cột trong cấu hình
        /// </summary>
        [EnumItemType("Số cột trong Config", "Số cột trong Config.\nLưu ý:nên đặt số chắn", TextMask = "\\d+", Length = 2)]
        [DisplayValue("Mặc định", "0", true)]
        [DisplayValue("2", "2")]
        [DisplayValue("4", "4")]
        [DisplayValue("6", "6")]
        [DisplayValue("8", "8")]
        [DisplayValue("10", "10")]
        ColConfig = 63,
        /// <summary>
        /// 64.Mã Lệnh giục xe trên server.
        /// </summary>
        [EnumItemType("Lệnh giục xe", "Mã lệnh giục xe gửi cho lái xe", TextMask = "\\d+")]
        [DisplayValue("", "33", true)]
        CmdIdGiucXe = 64,
        /// <summary>
        /// 65.Mã Lệnh giục xe trên server. 
        /// </summary>
        [EnumItemType("Lệnh ghi chú", "Mã lệnh ghi chú gửi cho lái xe", TextMask = "\\d+")]
        [DisplayValue("", "34", true)]
        CmdIdGhiChu = 65,
        [EnumItemType("Line khách đặt App", "Line khách đặt từ app", TextMask = "\\d+", Length = 3)]
        [DisplayValue("", "99", true)]
        LineKhachDatApp = 66,
        [EnumItemType("ĐTV Khung địa chỉ", "Điện thoại viên khung địa chỉ", ValueEnum = typeof(KhungDiaChi))]
        DienThoai_KhungDiaChi = 67,
        [EnumItemType("TĐV khung địa chỉ", "Tổng đài viên Khung địa chỉ", ValueEnum = typeof(KhungDiaChi))]
        TongDai_KhungDiaChi = 68,
        /// <summary>
        /// 69.Chuyển các cuốc gọi gần cuốc gọi lại.
        /// </summary>
        [EnumItemType("DTV.S.xếp cuốc g.lại", "Chuyển các cuốc gọi gần cuốc gọi lại")]
        [DisplayValue("Không", "0", true)]
        [DisplayValue("Có", "1")]
        DienThoai_ChuyenCacCuocGoiGanCuocGoiLai = 69,
        /// <summary>
        /// 70.TDV Sắp xếp cuốc gọi
        /// </summary>
        [EnumItemType("TĐV Sắp xếp cuốc gọi", "Tổng đài viên Sắp xếp cuốc gọi", ValueEnum = typeof(SapXepCuocGoi))]
        TongDai_SapXepCuocGoi = 70,
        /// <summary>
        /// 71.PBXIPVoicePath
        /// </summary>
        [EnumItemType("PBXIPVoicePath", "PBXIPVoicePath")]
        PBXIPVoicePath = 71,
        /// <summary>
        /// 72.Kiểm tra số điện thoại
        /// </summary>
        [EnumItemType("Kiểm tra số điện thoại", "Kiểm tra số điên thoại có phải là số di động")]
        [DisplayValue("Có", "0", true)]
        [DisplayValue("Không", "1")]
        CheckPhoneNumber = 72,
        /// <summary>
        /// 73.Chèn xe đến điểm vào xe nhận 
        /// </summary>
        [EnumItemType("Chèn xe đến điểm vào xe nhận", "Chèn xe đến điểm vào xe nhận")]
        [DisplayValue("Không", "0", true)]
        [DisplayValue("Có", "1")]
        ChenXeDenDiemVaoXeNhan = 73,
        /// <summary>
        /// 74.Cảnh báo lệnh lái xe
        /// </summary>
        [EnumItemType("Cảnh báo lệnh lái xe", "Cảnh báo lệnh lái xe")]
        [DisplayValue("Không", "0", true)]
        [DisplayValue("Có", "1")]
        CanhBaoLenhLaiXe = 74,
        [EnumItemType("Thay đổi lệnh số 7", "Cấu hình hiển text lệnh 7: Ko nói gì hoặc Gọi nhiều ko nghe")]
        [DisplayValue("Ko nói gì", "0", true)]
        [DisplayValue("Gọi nhiều ko nghe", "1")]
        CauHinhTextLenh7 = 75,
        [EnumItemType("Cho phép kết thúc cuốc lệnh số 7", "Cấu hình cho phép kết thúc cuốc lệnh số 7 hay không")]
        [DisplayValue("Không", "0", true)]
        [DisplayValue("Có", "1")]
        CauHinhKetThucCuocLenh7 = 76,
        /// <summary>
        /// 77.Service Điều app
        /// </summary>
        [EnumItemType("Servie Điều App", "Servie Điều App:0-Mặc định_G5,1-G5,2-BaSao", ValueEnum = typeof(EnumServiceDieuApp))]
        ServiceDieuApp = 77,
        /// <summary>
        /// 78.Cơ chế điều app
        /// </summary>
        [EnumItemType("Cơ chế Điều App", "Cơ chế Điều App", ValueEnum = typeof(EnumCoCheDieuApp))]
        CoCheDieuApp = 78,
        /// <summary>
        /// 79.Cuốc online
        /// </summary>
        [EnumItemType("Cuốc online", "Cuốc online:0-Không,1-Có hiển thị")]
        [DisplayValue("Không", "0", true)]
        [DisplayValue("Có", "1")]
        CuocOnline = 79,
        /// <summary>
        /// 80.Bỏ viết tắt ngõ
        /// </summary>
        [EnumItemType("Bỏ viết tắt ngõ", "Bỏ viết tắt ngõ:0-Không,1-Có bỏ")]
        [DisplayValue("Không", "0", true)]
        [DisplayValue("Có", "1")]
        BoVietTatNgo = 80,
        /// <summary>
        /// 81.Khoảng cách bắt khách khi điều app sẽ cảnh báo bắt khách quá xa.
        /// </summary>
        KhoangCachBatKhachCanhBao = 81,
        /// <summary>
        /// 82.Kết thúc cuốc khiếu nại
        /// </summary>
        KetThucCuocKhieuNai = 82,
        /// <summary>
        /// 83.Ẩn kiểu cuộc gọi khác
        /// </summary>
        AnKieuCuocGoiKhac = 83,
        /// <summary>
        /// 84.Line Đặt từ app
        /// </summary>
        LineDatTuApp = 84,
        /// <summary>
        /// 85.Ko liên lạc được khách
        /// </summary>
        CmdIdLenhKoLienLac = 85,
        /// <summary>
        /// 86.Lấy Tọa độ gps từ địa chỉ lịch sử cuốc
        /// Nhưng phải lấy đươc địa chỉ trước:key=30,HasValue=1
        /// </summary>
        DienThoai_LayGPSLichSuCuoc = 86,
        /// <summary>
        /// 87.Có xe nhận thì cho phép điều lại và nhầm khách,chuyển đàm
        /// </summary>
        DienThoai_DieuApp_CoXeNhanChoPhepDieuLai = 87,
        /// <summary>
        /// 88.Điều app không xe và cho phép điều lại
        /// </summary>
        DienThoai_AppkhongXe_ChoPhepDieuLai = 88,
        /// <summary>
        /// 89.Điều lại cho tick điều app luôn.
        /// </summary>
        DienThoai_DieuLai_TickDieuApp = 89,
        /// <summary>
        /// 90.Thời gian chuyển đàm.
        /// Mặc định là 90s=1p30s
        /// </summary>
        DienThoai_DieuApp_ThoiGianChuyenDam = 90,
        /// <summary>
        /// 91.Những cuốc chuyển đàm thì cho phép điều lại app.
        /// 
        /// </summary>
        DienThoai_ChuyenDam_DieuLai = 91,
        /// <summary>
        /// 92.Cơ chế chuyển đàm.
        /// 0-Mặc định.
        /// 1-Tất cả các trường hợp và trừ app không xe và không có xe nhận.
        /// 2-Tất cả các trường hợp và trừ cuốc bị timeout.
        /// 3-Tất cả các trường hợp và trừ cuốc bị timeout và có cảnh báo hết thời gian.
        /// 4-Tất cả các trường hợp không chuyển đàm.
        /// 5-Tất cả các trường hợp không chuyển đàm và có cảnh báo hết thời gian.
        /// </summary>
        DienThoai_DieuApp_ChuyenDam = 92,
        /// <summary>
        /// 93.Cảnh báo trùng địa chỉ
        /// </summary>
        DienThoai_CanhBaoTrungDiaChi = 93,
        /// <summary>
        /// 94.Chuyển Kiểu cuộc gọi khách MG thành Khách thường khi thay đổi địa chỉ
        /// </summary>
        DienThoai_ChuyenKhachMGThanhKhachThuong = 94,
        /// <summary>
        /// 95.Thời gian cho phép chọn chuyển đàm.
        /// </summary>
        DienThoai_DieuApp_ThoiGianChoPhepChonChuyenDam = 95,
        /// <summary>
        /// 96.Thời gian cho phép chọn điều lại
        /// </summary>
        DienThoai_DieuApp_ThoiGianChoPhepChonDieuLai = 96,
        /// <summary>
        /// 97.Cảnh báo mất kết nối với Server DH
        /// </summary>
        DienThoai_DieuApp_CanhBaoMatKetNoiVoiServerDieuHanh = 97,
        /// <summary>
        /// 98.Điều lại giữ cuốc cũ
        /// 1-Giữ cuốc cũ.
        /// 0-Tạo cuốc mới.
        /// </summary>
        DienThoai_DieuApp_DieuLaiGiuCuocCu = 98,
        /// <summary>
        /// 99.Số tick ngủ chút rồi gửi tiếp điều tiếp tiếp tục
        /// 
        /// </summary>
        DienThoai_DieuApp_SleepCuocSaoChep = 99,
        /// <summary>
        /// 100.Mã lệnh Đã mời
        /// </summary>
        DienThoai_DieuApp_DaMoiCmdId = 100,
        /// <summary>
        /// 101.Chuỗi kết nối Service TTDH
        /// </summary>
        ServiceConnectString = 101,
        /// <summary>
        /// 102. Chọn loại xe mặc định
        /// -2 : Không chọn loại xe nào
        /// -1 : Không chọn loại xe nào và chọn mặc định bất kỳ
        ///  0 : Mặc định chọn 4 chỗ
        ///  1 : Mặc định chọn 7 chỗ
        /// </summary>
        DienThoai_ChonLoaiXe = 102,
        /// <summary>
        /// 103.Cho phép trượt khi có xe nhận
        /// </summary>
        DienThoai_DieuApp_TruotKhiCoXeNhan = 103,
        /// <summary>
        /// 104.Số phút cho phép nhập xe đón khi có xe nhận.
        /// -1 : Không cho phép nhập xe đón khi có xe nhận.
        ///  0 : Cho phép nhập khi có xe nhận.
        /// n>0: Số phút cho phép nhập xe đón.
        /// </summary>
        DienThoai_DieuApp_SoPhutChoPhepNhapXeDonKhiCoXeNhan = 104,
        /// <summary>
        /// 105.Cấu hình MySql Asterisk
        /// </summary>
        Asterisk_MySQLServer = 105,
        /// <summary>
        /// 106.Cấu hình MySql Asterisk
        /// </summary>
        Asterisk_MySQLUser = 106,
        /// <summary>
        /// 107.Cấu hình MySql Asterisk
        /// </summary>
        Asterisk_MySQLPassword = 107,
        /// <summary>
        /// 108.Cấu hình MySql Asterisk
        /// </summary>
        Asterisk_MySQLDatabaseName = 108,
        /// <summary>
        /// 109.Cấu hình MySql Asterisk
        /// </summary>
        Asterisk_UrlService = 109,
        /// <summary>
        /// 110.Cấu hình MySql Asterisk
        /// </summary>
        Asterisk_FTPPath = 110,
        /// <summary>
        /// 111.Cấu hình MySql Asterisk
        /// </summary>
        Asterisk_FTPUserName = 111,
        /// <summary>
        /// 112.Cấu hình MySql Asterisk
        /// </summary>
        Asterisk_FTPPass = 112,
        /// <summary>
        /// 113.Cấu hình MySql Asterisk
        /// </summary>
        Asterisk_FTPDirectory = 113,
        /// <summary>
        /// 114.Cấu hình MySql Asterisk
        /// </summary>
        Asterisk_FTPLocalPath = 114,
        /// <summary>
        /// 115.Thời gian cho phép xử lý cuốc sao chép khi tắt pm và bật pm.
        /// </summary>
        DienThoai_DieuApp_XuLyCuocGoiSaoChep = 115,
        /// <summary>
        /// 116.Bắt buộc lấy GPS
        /// </summary>
        DienThoai_RequiredGPS = 116,
        /// <summary>
        /// 117.Bắt buộc hiển thị bản đồ.
        /// </summary>
        TongDai_RequiredShowMap = 117,
        /// <summary>
        /// 118.Cho phép cập nhật thói quen khách hàng.
        /// -1: Chặn không cập nhật thói quen
        /// 0 : Số điện thoại di động.
        /// 1 : Tất cả số.
        /// </summary>
        DienThoai_UpdateCustomerHabit = 118,
        /// <summary>
        /// 119.Điều lại cho phép dùng BookId cũ
        /// </summary>
        DienThoai_DieuLai_BookIdOld = 119,
        /// <summary>
        /// 120.Trượt trong khoảng thời gian bao lâu.
        /// </summary>
        DienThoai_DieuApp_Truot = 120,
        /// <summary>
        /// 121.Trunk để gọi ra
        /// </summary>
        MPCC_TrunkDial = 121,
        /// <summary>
        /// 122.Queue để gọi ra
        /// </summary>
        MPCC_Queue = 122,
        /// <summary>
        /// 123.Link gọi ra
        /// </summary>
        MPCC_LinkDial = 123,
        /// <summary>
        /// 124.Điều sân bay
        /// </summary>
        DieuSanBay = 124,
        /// <summary>
        /// 125. Vùng đàm mặc định
        /// </summary>
        VungDamMacDinh = 125,
        /// <summary>
        /// 126.zlink goi ra
        /// </summary>
        Zlink_LinkDial = 126,
        /// <summary>
        /// 127.Cho phép gọi nhanh từ PMDH đến tổng đài IP
        /// </summary>
        Asterisk_QuickCall = 127,
        /// <summary>
        /// 130. Địa chỉ link GPS
        /// </summary>
        DomainGPS = 130,
        /// <summary>
        /// 131. Channel goi ra
        /// </summary>
        ChannelDial = 131,
        /// <summary>
        /// 132. Số phút cho phép bấn phím H để hoàn thành cuốc
        /// </summary>
        App_Minute_Done_ByKeyH = 132,
        /// <summary>
        /// 133. check trạng thái của extension có bận hay ko
        /// </summary>
        MPCC_LinkCheckStatus = 133,
        /// <summary>
        /// 134. Điều app - nhận Mời khách từ app KH. Show cuốc online lên lưới chờ điều để mời khách
        /// </summary>
        App_CustomerSource_Invite = 134,
        /// <summary>
        /// 135. Cấu hình hệ thống có điều app hay không?
        /// </summary>
        CoDieuApp = 135,
        /// <summary>
        /// 136. Có hiển thị cột khách hẹn không?
        /// </summary>
        CotKhachHen = 136,
        /// <summary>
        /// 137. Có hiển thị cảnh báo cuốc sân bay
        /// </summary>
        CanhBaoCuocSanBay = 137,
        /// <summary>
        /// 138. Cấu hình thêm ký tự # sau số điện thoại để gọi ra
        /// </summary>
        Asterisk_SetNumberSign = 138,
        /// <summary>
        /// 139. Cấu hình Gửi tin nhắn SMS ở Server App
        /// </summary>
        App_SendSMS_Customer = 139,
        /// <summary>
        /// 140. Cấu hình nhập tuyến đường dài
        /// </summary>
        NhapTuyenDuongDai = 140,
        /// <summary>
        /// 141. Cấu hình điều xe hợp đồng
        /// </summary>
        App_DieuXeHopDong = 141,
        /// <summary>
        /// 142. Cấu hình App KH - Hủy :Server tự động điều lại hay ko.
        /// </summary>
        AppKH_Huy = 142,
        /// <summary>
        /// 143. Cấu hình App KH - không xe nhận tự chuyển đàm hay ko.
        /// </summary>
        AppKH_ChuyenDam = 143,
        /// <summary>
        /// 144. Cấu hình dùng map mặc định
        /// 0: Google - 1: Bình Anh
        /// </summary>        
        MAP_Provider = 144,
        /// <summary>
        /// 145. Cấu hình thuê bao tuyến
        /// </summary>
        CauHinhThueBaoTuyen = 145,
        /// <summary>
        /// 146. Cấu hình có nhận cảnh báo SOS từ App
        /// </summary>
        App_SOS_Alert = 146,

        /// <summary>
        /// 147. Cấu hình có tự động check license không!
        /// </summary>
        AutoCheckLicense = 147,
        /// <summary>
        /// 148. Cấu hình cho phép chuyển điều App!
        /// </summary>
        ChoPhepChuyenDieuApp,
        /// <summary>
        /// 149. Cấu hình line điều xe cao cấp. Thành Công Car!
        /// </summary>
        LineDieuAppXeCaoCap,
        /// <summary>
        /// 150. Có lấy xe đề cử hay ko
        /// </summary>
        GPS_GetXeOnline,
        /// <summary>
        /// 151. Tự động logout ở máy khác hoặc tự động logout khi bị đăng xuất cưỡng chế
        /// </summary>
        ValidateLogin,
        /// <summary>
        /// 152. Sử dụng bản đồ online
        /// </summary>
        MapOnline,
        /// <summary>
        /// 153. Cấu hình Timeout gọi ra Asterisk
        /// </summary>
        Asterisk_CallOut_TimeOut,
        /// <summary>
        /// 155. Từ chối xin lỗi khách
        /// </summary>
        Grid_Vung_Color = 155,
        Grid_Line_Color_KhachVip = 156,
        Grid_Line_Color_KhachMG = 157,
        Grid_Line_Color_KhachVangBac = 158,
        Grid_Line_Color_KhachAo = 159,
        Grid_XeDungDiem_Color = 160,
        Grid_ThoiDiemGoi_Color_5 = 161,
        Grid_ThoiDiemGoi_Color_15 = 162,
        Grid_ThoiDiemHen_Color_15 = 163,
        Grid_ThoiDiemHen_Color_90 = 164,
        Grid_LoaiXe_Color_Config5 = 165,
        Grid_SoLuong_Color_1 = 166,
        Grid_SoLan_Color_1 = 167,
        Grid_SoLan_Color_2 = 168,
        Grid_DiaChi_App_Color = 169,
        Grid_DiaChi_CAR_Color = 170,
        Grid_DiaChi_GL_Color = 171,
        Grid_SDT_App_Color = 172,
        Grid_App_ChuyenDam_Color = 173,
        Grid_App_NoCar_Color = 174,
        Grid_App_NoCarAccept_Color = 175,
        Grid_FocusedRow_Color = 176,
        Grid_FocusedRow_BackColor = 177,
        Grid_ThoiDiemHen_Color = 178,
        AppLX_CMDID_ShowPhoneNumber = 180,
        /// <summary>
        /// 181.Link gọi ra của Asterisk Cloud
        /// </summary>
        Asterisk_LinkDial = 181,
        /// <summary>
        /// 182.Link gọi ra của Asterisk Cloud - crm id
        /// </summary>
        Asterisk_LinkDial_CRMID = 182,
        /// <summary>
        /// 73.Chèn xe đến điểm vào xe nhận 
        /// </summary>
        [EnumItemType("Chèn xe đến điểm vào xe MK", "Chèn xe đến điểm vào xe MK")]
        [DisplayValue("Không", "0", true)]
        [DisplayValue("Có", "1")]
        ChenXeDenDiemVaoXeMK = 183,
        /// <summary>
        /// 184. Nhập Chot Co Duong Dai
        /// 0 : khong dung
        /// 1 : mini
        /// 2 : full
        /// </summary>
        NhapChotCoDuongDai = 184,
        Grid_Font = 185,
        Grid_HorzLineColor = 186,
        TDV_NhapXeMK = 187,
        /// <summary>
        /// 188. Ban cuoc dam xuong app lx
        /// </summary>
        App_SendRadioTrip = 188,
        /// <summary>
        /// 189. Lay dia chi theo tha diem (Khi tha diem thi se nhap lai dia chi theo dia chi cua diem vua cap nhat)
        /// </summary>
        DTV_AddressByPinMap = 189,
        /// <summary>
        /// 190. Cấu hình mặc định điều app
        /// </summary>
        DTV_DefaultApp = 190,
        /// <summary>
        /// 191. Cấu hình Sắp xếp các cuốc có lệnh ưu tiên lên đầu
        /// </summary>
        TDV_ORDERBYCOMMAND = 191,
        /// <summary>
        /// 192. Cấu hình Cảnh báo xe nhận cuốc đàm trùng với xe nhận ở App
        /// </summary>
        TDV_VALIDATE_XENHAN_APP = 192,
        /// <summary>
        /// 193. Sắp xếp lưới điện thoại theo thời điểm hẹn
        /// </summary>
        DTV_THOIDIEMHEN_ORDER = 193,
        /// <summary>
        /// 194. Sắp xếp lưới điện thoại theo xe nhận
        /// </summary>
        DTV_XENHAN_ORDER = 194,
        /// <summary>
        /// 195. Gọi nhanh bằng cổng COM
        /// </summary>
        DTV_QUICKCALL_COM = 195,
        /// <summary>
        /// 196. Cho phép điều chỉ định ko cần tọa độ
        /// </summary>
        DTV_APP_NOT_LOCATION = 196,
        /// <summary>
        /// 197.Khung nhập cuộc gọi mini
        /// </summary>
        DTV_INPUT_MINI = 197,
        /// <summary>
        /// 198.DTV Fix Point Điểm MG
        /// </summary>
        DTV_INPUT_FIX_POINT_MG = 198,
        /// <summary>
        /// 199.DTV gửi SMS đã xin lỗi khách
        /// </summary>
        DTV_SMS_DAXINLOI_KHACH = 199,
        /// <summary>
        /// 200.DTV hiển thị cảnh báo mời khách
        /// </summary>
        DTV_ALERT_INVITE = 200,
        /// <summary>
        /// 201.DTV hiển thị cảnh báo Lái xe hủy cuốc
        /// </summary>
        DTV_ALERT_DriverCancel = 201,
        /// <summary>
        /// 202.TDV màu nền cuốc đã nhận
        /// </summary>
        Grid_CuocChuaXuLy_BackGround_DaNhan = 202,
        /// <summary>
        /// 203.SMS cuốc đường đài có thông tin tên lái xe
        /// </summary>
        SMS_CuocDuongDai_LaiXe = 203,

        /// <summary>
        /// 204.SMS cuốc App đường đài gửi khi nào
        /// 1. Khi nhập xe đón        
        /// 2. Nhập khi đã mời
        /// </summary>
        SMS_CuocDuongDai_App_LaiXe_Send = 204,

        /// <summary>
        /// 205.SMS cuốc đàm đường đài gửi khi nào
        /// 1. Khi nhập xe đón        
        /// 2. Nhập khi nhập xe đến điểm
        /// </summary>
        SMS_CuocDuongDai_Dam_LaiXe_Send = 205,

        /// <summary>
        /// 206. Cấu hình Nhập xe nhận cuốc đàm trùng với xe nhận ở App thì gửi thông tin cuốc đàm xuống cho app qua thông báo
        /// </summary>
        TDV_XENHAN_RADIO_TO_APP = 206,

        /// <summary>
        /// 207. Bat So Số phút lấy cuộc gọi kết thúc khi khách gọi lại
        /// </summary>
        BATSO_SoPhutGoiLai = 207,

        /// <summary>
        /// 208.SMS dành riêng cho Taxi Vina
        /// </summary>
        SMS_TaxiVina = 208,

        /// <summary>
        /// 209.SMS Vina ReceiveCarInfo
        /// </summary>
        SMS_TaxiVina_ReceiveCarInfo = 209,

        /// <summary>
        /// 210.SMS Vina_ViewCar
        /// </summary>
        SMS_TaxiVina_ViewCar = 210,

        /// <summary>
        /// 211.SMS Vina_CatchedUser
        /// </summary>
        SMS_TaxiVina_CatchedUser = 211,

        /// <summary>
        /// 212.SMS Vina_NoCar
        /// </summary>
        SMS_TaxiVina_NoCar = 212,

        /// <summary>
        /// 213.SMS Vina_ThankCustomer
        /// </summary>
        SMS_TaxiVina_ThankCustomer = 213,

        /// <summary>
        /// 214.SMS Vina_Other
        /// </summary>
        SMS_TaxiVina_Other = 214,

        /// <summary>
        /// 215.Số phút mặc định báo khách chờ (VINATAXI)
        /// </summary>
        SMS_PHUTKHACHCHO = 215,

        /// <summary>
        /// 216.Địa chỉ đón IN HOA
        /// </summary>
        DTV_Address_UPPER = 216,

        /// <summary>
        /// 217. TDV Grid Color Ghi Chu DTV
        /// </summary>
        TDV_Grid_GhiChuDTV = 217,

        /// <summary>
        /// 218. có dùng thời gian hẹn
        /// </summary>
        DTV_ThoiGianHen = 218,

        /// <summary>
        /// 219. TĐV Màu nền Lệnh khác
        /// </summary>
        TDV_Grid_LenhDTV = 219,

        /// <summary>
        /// 220. TĐV Màu nền Thoidiemhen
        /// </summary>
        TDV_Grid_ThoiGianHen = 220,

        /// <summary>
        /// 221. DTV Focus địa chỉ đón khi bấm Alt + Z (điều App)
        /// </summary>
        DTV_ALTZ_FOCUSADDRESS = 221,

        /// <summary>
        /// 222. DTV phát âm thanh cảnh báo khi có Lệnh Lái Xe mới
        /// </summary>
        DTV_ALERT_SOUND_LENHLX = 222,

        /// <summary>
        /// 224. Sử dụng chỉ đường trên điện thoại viên
        /// 0 : không sử dụng
        /// 13: ID của Thành Công taxi
        /// </summary>
        DTV_ROUTE_SERVICE = 224,
        DTV_FixPrice = 225,
    } 
}
