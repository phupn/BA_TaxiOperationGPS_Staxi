using Taxi.Common.EnumUtility;

namespace Taxi.Utils
{
    /// <summary>
    /// Màu hiển thị trạng thái xe
    /// </summary>
    public enum Enum_ColorOfVehicleStatus
    {
        /// <summary>
        /// 2.Xe không khách theo GPS
        /// </summary>
        KhongKhach = 2,
        /// <summary>
        /// 1.Xe có khách theo GPS
        /// </summary>
        CoKhach = 1,
        /// <summary>
        /// 3.Xe tắt máy theo GPS
        /// </summary>
        TatMay = 3,
        /// <summary>
        /// 4.Xe báo xin điểm đỗ
        /// </summary>
        XinDiemDo = 4,
        /// <summary>
        /// 5.Xe nhận đón khách nhưng tín hiệu GPS là tắt máy
        /// </summary>
        NhanDonKhach_TatMay = 5,
        /// <summary>
        /// 10.Xe nhận đón khách và tín hiệu GPS là đang di chuyển
        /// </summary>
        NhanDonKhach_DangDiChuyen = 10,
        /// <summary>
        /// 11.Xe nhận đón khách và tín hiệu GPS là đang có khách
        /// </summary>
        NhanDonKhach_DangCoKhach = 11,
        /// <summary>
        /// 6.Xe mất liên lạc,vẫn hiện trên cột 3, thay đổi màu
        /// </summary>
        XeMatLienLac = 6,
        /// <summary>
        /// 7.Xe bị mất tín hiệu GPS || GSM
        /// </summary>
        XeMTH = 7,
        /// <summary>
        /// 8.Xe xin ra ngoài lâu,bật cờ ẩn trên cột 3 (GiamSatXe : isHidden = true)
        /// </summary>
        XeXinRaBatCo = 8,
        /// <summary>
        /// 9.Xe xin ra ngoài,không bật cờ vẫn hiện trên cột 3
        /// </summary>
        XeXinRaNgoai = 9,
        /// <summary>
        /// 12.Xe báo trả khách
        /// </summary>
        XeBaoTraKhach = 12
    }

    public enum Enum_ColorOfVungDieuHanh
    {

    }

    public enum Enum_TabPageDieuHanhBanCo
    {
        BanCo = 1,
        BanDo = 2,
        GiamSatXe = 3
    }

    public enum Enum_ReasonType
    {
        UnKnown = 0,

        /// <summary>
        /// 1.Lý do báo về - Lái xe báo về trong Giám sát xe (BanCo_GiamSatXe - LyDoVe)
        /// </summary>
        LyDoBaoVe = 1,
        /// <summary>
        /// 2.Loại lỗi - xe vi phạm lỗi (BanCo_ViolateError)
        /// </summary>
        ViolateError = 2,
        /// <summary>
        /// 3.Lý do xe hỏng - ban vặt (BanCo_VehicleCorrupt)
        /// </summary>
        VehicleCorrupt = 3,
        /// <summary>
        /// 4.Lý do xe không đi kinh doanh (BanCo_VehicleNotWorking)
        /// </summary>
        VehicleNotWorking = 4,
        
        /// <summary>
        /// 5. Lý do xe không thực hiện được cuốc hàng
        /// </summary>
        VehicleLossTrip = 5
    }


    /// <summary>
    /// Chiều của thuê bao tuyến
    /// </summary>
    public enum Enum_Chieu
    {
        /// <summary>
        /// 1. Nội tỉnh - Một chiều
        /// </summary>
        [GroupChieu("1 chiều", Group = 1)]
        NoiTinh_MotChieu = 1,

        /// <summary>
        /// 2. Nội tỉnh - hai chiều
        /// </summary>
        [GroupChieu("2 chiều", Group = 1)]
        NoiTinh_HaiChieu = 2,

        /// <summary>
        /// 3. Theo ca - nữa ngày
        /// </summary>
        [GroupChieu("Nửa ngày", Group = 3)]
        TheoCa_NuaNgay = 3,

        /// <summary>
        /// 4. Theo ca - một ngày
        /// </summary>
        [GroupChieu("Cả ngày", Group = 3)]
        TheoCa_MotNgay = 4,

        /// <summary>
        /// 5. Meter
        /// </summary>
        [GroupChieu("METER", Group = 4)]
        METER = 5,

        /// <summary>
        /// 6. Ngoại tỉnh - một chiều
        /// </summary>
        [GroupChieu("1 chiều", Group = 2)]
        NgoaiTinh_MotChieu = 6,

        /// <summary>
        /// 7. Ngoại tỉnh - hai chiều
        /// </summary>
        [GroupChieu("2 chiều", Group = 2)]
        NgoaiTinh_HaiChieu = 7,

        /// <summary>
        /// 8. METER
        /// </summary>
        [GroupChieu("METER", Group = 5)]
        METER_2 = 8
    }

    /// <summary>
    /// Loại cuộc gọi (Trường KieuCuocGoi)
    /// ycx-Yêu cầu xe
    /// bx-Bốc xếp
    /// gl-Gọi lại
    /// hg-Hỏi giá
    /// kn-Khiếu nại
    /// gk-Gọi khác
    /// xlk-Xin lỗi khách
    /// nb-Nội bộ
    /// nn-Nháy máy
    /// </summary>
    public enum Enum_CallType
    {
        /// <summary>
        /// 1.Gọi xe
        /// </summary>
        [EnumItem("Gọi xe")]
        GoiXe = 1,
        /// <summary>
        /// 2.Gọi nhỡ
        /// </summary>
        [EnumItem("Gọi nhỡ")]
        GoiNho = 2,
        /// <summary>
        /// 3.Gọi lại
        /// </summary>
        [EnumItem("Gọi lại")]
        GoiLai = 3,
        /// <summary>
        /// 4.Hỏi giá
        /// </summary>
        [EnumItem("Hỏi giá")]
        HoiGia = 4,

        /// <summary>
        /// 5.Bốc xếp
        /// </summary>
        [EnumItem("Bốc xếp")]
        BocXep = 5,
        /// <summary>
        /// 6.Khiếu nại
        /// </summary>
        [EnumItem("Phản ánh")]
        KhieuNai = 6,
        /// <summary>
        /// 7.Xin lỗi khách
        /// </summary>
        [EnumItem("Xin lỗi khách")]
        XinLoiKhach = 7,

        /// <summary>
        /// 8.Nội bộ
        /// </summary>
        [EnumItem("Nội bộ")]
        NoiBo = 8,

        /// <summary>
        /// 9.Nháy máy
        /// </summary>
        [EnumItem("Nháy máy")]
        NhayMay = 9,

        /// <summary>
        /// 10.Gọi khác
        /// </summary>
        [EnumItem("Gọi khác")]
        GoiKhac = 10,

        /// <summary>
        /// 11.Khách hẹn
        /// </summary>
        [EnumItem("Khách hẹn")]
        KhachHen = 11,

        /// <summary>
        /// 12.Khách hoãn
        /// </summary>
        [EnumItem("Khách hoãn")]
        KhachHoan = 12,

        /// <summary>
        /// 13. Hết xe
        /// </summary>
        [EnumItem("Hết xe")]
        HetXe = 13,

        /// <summary>
        /// 14. Giục xe
        /// </summary>
        [EnumItem("Giục xe")]
        GiucXe = 14,

        /// <summary>
        /// 15. Xe khách
        /// </summary>
        [EnumItem("Xe khách")]
        XeKhach = 15,

        /// <summary>
        /// 16. Hỏi thông tin
        /// </summary>
        [EnumItem("Hỏi thông tin")]
        HoiThongTin = 16,
    }

    /// <summary>
    /// ChayTuyen
    /// </summary>
    public enum Enum_GroupType
    {
        /// <summary>
        /// 1. Nội tỉnh
        /// </summary>
        NoiTinh = 1,
        /// <summary>
        /// 2. Ngoại tỉnh
        /// </summary>
        NgoaiTinh = 2,
        /// <summary>
        /// 3. theo ca
        /// </summary>
        TheoCa = 3,
        /// <summary>
        /// 5. Meter
        /// </summary>
        METER = 5,
        /// <summary>
        /// 4. thuê bao tự do
        /// </summary>
        ThueBaoTuDo = 4
    }

    /// <summary>
    /// Enum Loại cấu hình
    /// </summary>
    public enum Enum_ConfigType
    {
        CauHinhChung = 0,
        /// <summary>
        /// Loại cấu hình cảnh báo
        /// </summary>
        CanhBao = 1,
        /// <summary>
        /// Loại cấu hình màu sắc trạng thái xe
        /// </summary>
        MauSacTrangThaiXe = 2,
    }

    /// <summary>
    /// Enum cấu hình cảnh báo
    /// Map với BanCo_Config
    /// </summary>
    public enum Enum_Config_Alert
    {
        /// <summary>
        /// Xe di chuyển rỗng quá xa so với km quy định
        /// </summary>
        DiChuyenRong = 1,
        /// <summary>
        /// Xe đỗ quá lâu
        /// </summary>
        DungDoLau = 2,
        /// <summary>
        /// Lái xe đón khách mà không báo
        /// </summary>
        DonKhachKhongBao = 3,
        /// <summary>
        /// Tới điểm đón khách nhưng lâu không đón được khách, xe vẫn ở tại điểm
        /// </summary>
        TruotQuaLau = 4,
        /// <summary>
        /// 
        /// </summary>
        Bao = 5,
        /// <summary>
        /// Đỗ sai điểm
        /// </summary>
        SaiDiemDo = 6,
        /// <summary>
        /// Ăn ca quá lâu
        /// </summary>
        AnCa = 7,
        /// <summary>
        
        /// Rời xe quá lâu
        /// </summary>
        RoiXe = 8,
        /// <summary>
        /// Kinh doanh qua thời gian (Tính theo giờ)
        /// </summary>
        KDQuaGio = 9,
        /// <summary>
        /// Không báo điểm đỗ
        /// </summary>
        ChuaBaoDiemDo = 10,
        /// <summary>
        /// Thời giàn hiển thị lại thông báo
        /// </summary>
        ThoiGianHienThiLaiThongBao = 11,
        /// <summary>
        /// Quãng đường tính xăng
        /// </summary>
        QuangDuongTinhXang = 12,
        /// <summary>
        /// Lái xe báo khai thác
        /// </summary>
        SDTLaiXeKhaiThac = 13,
        /// <summary>
        /// Bộ Phận Bốc Xếp
        /// </summary>
        SDTBoPhanBocXep = 14,
        /// <summary>
        /// Line mặc định khi tổng đài chèn cuộc gọi
        /// </summary>
        LineDefault = 15,
        /// <summary>
        /// Xe chưa mở hàng
        /// </summary>
        XeChuaMoHang = 17,
        /// <summary>
        /// Xe đỗ lâu chưa có cuốc khách
        /// </summary>
        XeDoLauChuaCoCK = 18,
        /// <summary>
        /// Smartphone cách xe quá xa
        /// </summary>
        SmartphoneQuaXaXe = 19,
    }    

    /// <summary>
    /// Enum Trạng thái lái xe báo
    /// </summary>
    public enum Enum_TrangThaiLaiXeBao
    {
        /// <summary>
        /// bao ve gara , giao ca
        /// </summary>
        BaoVe = 0,
        /// <summary>
        /// Báo xe ra kinh doanh
        /// </summary>
        BaoRaKinhDoanh = 1,
        /// <summary>
        /// Báo xe đón được khách
        /// </summary>
        BaoDonDuocKhach = 2,
        /// <summary>
        /// Báo dừng đỗ, chuyển điểm, vùng
        /// </summary>
        BaoDiemDo = 3,
        /// <summary>
        /// Xe báo va chạm, hỏng, công an bắt,...
        /// </summary>
        BaoSuCoTaiNanCongAn = 4,
        /// <summary>
        /// Xe báo nghỉ
        /// </summary>
        BaoNghi = 5,
        /// <summary>
        /// Báo nghỉ ăn cơm,...
        /// </summary>
        BaoNghi_AnCa = 6,
        /// <summary>
        /// Báo rời xe, không ngồi trên xe
        /// </summary>
        BaoNghi_RoiXe = 7,

        BaoDiemCuaTrungTam_DCTraKhach = 8,
        /// <summary>
        /// thiet lap gia tri nay khi tong dai check ma khong duoc
        /// </summary>
        TongDaiCheck = 9,
        /// <summary>
        /// Xe tự khai thác khách vẫy
        /// </summary>
        KhaiThac = 10,
        /// <summary>
        /// Xe mất liên lạc
        /// </summary>
        MatLienLac=11,
        /// <summary>
        /// Xe báo hoạt động
        /// </summary>
        XeRaHoatDong = 12,
        /// <summary>
        /// Xe báo trả khách
        /// </summary>
        XeBaoTraKhach = 13,
        /// <summary>
        /// Xe mất tín hiệu
        /// </summary>
        MatTinHieu = 14,
        /// <summary>
        /// Trạng thái không xác định
        /// </summary>
        KhongXacDinh = 99,
    }
    /// <summary>
    /// Vùng làm việc
    /// Giúp định vị được vùng làm việc đến sử dụng phím tắt đến vùng làm việc mà mong muốn
    /// </summary>
    public enum VungLamViec
    {
        #region Vùng bàn cờ
        /// <summary>
        /// Chuyển đến vùng bàn cờ
        /// </summary>
        VungBanCo= 10,
        /// <summary>
        /// Chuyển đến vùng bàn cờ 
        ///     -Tab Cuộc gọi chờ giải quyết
        /// </summary>
        VungBanCo_CuocGoiChoGiaiQuyet=11,
        /// <summary>
        /// Chuyển đến vùng bàn cờ
        ///     - Tab Cuộc gọi đã giải quyết
        /// </summary>
        VungBanCo_CuocGoiDaGiaiQuyet=12,
        /// <summary>
        /// Chuyển đến vùng bàn cờ
        ///     - Tab nhật ký thuê bao
        /// </summary>
        VungBanCo_NhatKyThueBao=13,
        #endregion

        #region Bàn cờ
        /// <summary>
        /// Chuyển đến vùng bản đồ
        /// </summary>
        VungBanDo=20,
        #endregion

        #region Giám sát xe
        /// <summary>
        /// Chuyển đến vùng giám sát xe 
        /// </summary>
        VungGiamSatXe=30,
        #endregion

        #region Forcus vào Số hiệu xe và Địa chỉ
        /// <summary>
        /// Forcus vào ô textbox số hiệu
        /// </summary>
        VungBanCo_SoHieu_focus=41,
        /// <summary>
        /// Forcus vào ô textbox Địa chỉ
        /// </summary>
        VungBanCo_DiaChi_focus=42,
        #endregion

        #region Tich vào các ô
        /// <summary>
        /// Đổi trạng thái của All
        /// </summary>
        VungBanCo_CheckAll=50,
        /// <summary>
        /// Đổi trạng thái của Kênh 1
        /// </summary>
        VungBanCo_Check1=51,
        /// <summary>
        /// Đổi trạng thái của Kênh 2
        /// </summary>
        VungBanCo_Check2=52,
        /// <summary>
        /// Đổi trạng thái của Kênh 3
        /// </summary>
        VungBanCo_check3=53,
        /// <summary>
        /// Đổi trạng thái của Kênh 4
        /// </summary>
        VungBanCo_check4=54,
        /// <summary>
        /// Đổi trạng thái của Kênh 5
        /// </summary>
        VungBanCo_check5=55,
        #endregion
    }
    /// <summary>
    /// Máy tính sử dụng chức năng nào
    /// </summary>
    public enum Enum_ChucNangNhiemVu
    {
        [EnumItem("Điện thoại")]
        DienThoaiVien = 1,

        [EnumItem("Tổng đài")]
        TongDaiVien = 2,

        MoiKhach = 3,

        [EnumItem("Lái xe")]
        LenhLaiXe = 4,
    }

    /// <summary>
    /// Enum hoạt động của đối tác
    /// </summary>
    public enum Enum_HoatDongDoiTac
    {
        [EnumItem("Xóa")]
        Xoa = 0,

        [EnumItem("Dừng hoạt động")]
        DungHoatDong = 1,

        [EnumItem("Hoạt động")]
        HoatDong = 2
    }

    /// <summary>
    /// Enum nhật ký đồng bộ
    /// </summary>
    public enum Enum_DongBoNhatKy
    {
        [EnumItem("Bằng tay")]
        BangTay = 0,

        [EnumItem("Tự động")]
        TuDong = 1,
    }

    /// <summary>
    /// kiểu khách hàng gọi đến
    /// Phân biệt khách hàng vãng lai hay khách thân thiết,khách hoa hồng
    /// </summary>
    public enum Enum_KieuKhachHangGoiDen
    {
        KhachHangKhongHieu = 0, // khach vui ve, khach ao
        KhachHangBinhThuong = 1, // khách lẻ
        KhachHangMoiGioi = 2,
        KhachHangThanThiet = 3,
        KhachHangGoiLai = 4, // khách hàng gọi lại
        KhachHangMoiGioiKhac = 5, //MG không xác định
        LaiXeKhaiThac = 6,
        KhachHangHen = 7,//Khách đặt
    }
    /// <summary>
    /// Cấu hình các loại trạng thái khác, không liên quan với nhau vào đây.
    /// </summary>
    public enum Enum_Truck_TrangThaiKhac
    {
        /// <summary>
        /// Là cuốc quay đầu
        /// </summary>
        IsQuayDau = 1
    }


    /// <summary>
    /// LoaiCuocHang
    /// </summary>
    public enum LoaiCuocHangThucHien
    {
        /// <summary>
        /// 3. Cuốc hàng mở cửa
        /// </summary>
        MoCua = 3,
        /// <summary>
        /// 4 : Thuê bao tính theo ca
        /// </summary>
        ThueBaoCa = 4,
        /// <summary>
        /// 5 : Thuê bao nội tỉnh
        /// </summary>
        ThueBaoNoiTinh = 5,
        /// <summary>
        /// 6 : Thuê bao ngoại tỉnh
        /// </summary>
        ThueBaoNgoaiTinh = 6,
        /// <summary>
        /// 7 : Thuê bao đồng hồ
        /// </summary>
        ThueBaoMeter = 7,
        /// <summary>
        /// 8 : Thuê bao tự do
        /// </summary>
        ThueBaoTuDo = 8,
        /// <summary>
        /// 1 : Đánh dấu là cuốc thuê bao tuyến khi chưa phân loại được là cuốc hàng như thế nào
        /// </summary>
        CuocThuBaoTuyen = 1,
        /// <summary>
        /// 0 : Đánh dấu là cuốc thường khi chưa phân loại được là cuốc hàng như thế nào
        /// </summary>
        CuocBinhThuong = 0
    }

    /// <summary>
    /// Kiểu cuốc hàng
    /// KieuCuocHang
    /// </summary>
    public enum KieuCuocHang
    {
        /// <summary>
        ///0. cuốc khách bình thường
        /// </summary>
        [EnumItem("Bình thường")]
        BinhThuong = 0,

        /// <summary>
        /// 1.Lái xe khai thác
        /// </summary>
        [EnumItem("LX khai thác")]
        LaiXeKhaiThac = 1,

        /// <summary>
        /// 2.Lái xe khai thác đường dài
        /// </summary>
        [EnumItem("LX khai thác đường dài")]
        LaiXeKhaiThacDuongDai = 2
    }

    /// <summary>
    /// phân biệt đang sử dụng module nào
    /// </summary>
    public enum TaxiOperation_Module
    {
        /// <summary>
        /// Xe tải Én Vàng
        /// </summary>
        DieuXeTai = 0,
        /// <summary>
        /// Điều hành taxi
        /// </summary>
        DieuXeTaxi = 1,
        /// <summary>
        /// Phần mềm Lương
        /// </summary>
        Luong = 2
    }
    public class GroupChieuAttribute : EnumItemAttribute
    {
        public int Group { set; get; }
        public GroupChieuAttribute(string name) : base(name) { }
    }
    public enum PHDH_CommandWorkflow
    {
        None = 0,
        [EnumItem("Tổng đài")]
        TongDaiVien = 1,
        [EnumItem("Điện thoại")]
        DienThoaiVien = 2
    }
}
