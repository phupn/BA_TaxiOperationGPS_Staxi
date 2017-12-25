using System;
using System.Collections.Generic;
using System.Text;
using Taxi.Common.EnumUtility;
namespace Taxi.Utils
{
    public enum DanhBa_Type : int
    {
        /// <summary>
        /// Không thuộc danh bạ nào
        /// </summary>
        None = 0,
        /// <summary>
        /// Danh bạ công ty
        /// </summary>
        DanhBaCongTy = 1,
        /// <summary>
        /// Danh bạ khách ảo
        /// </summary>
        DanhBaKhachAo = 2,
        /// Danh bạ khách hàng
        /// </summary>
        DanhBaKhachHang = 3,
    }

    /// <summary>
    /// Trường sourceType trong bản T_TaxiOperation
    /// </summary>
    public enum SourceType:int
    {
        /// <summary>
        /// Cuốc đặt từ website ThanhCongTaxi.vn
        /// </summary>
        TripOnline_Web = 1,
        /// <summary>
        /// Cuốc từ web dichung
        /// </summary>
        FromPartner = 2,
        /// <summary>
        /// Cuốc đặt từ app Sảnh
        /// </summary>
        AppFloor = 6,
    }
    public enum TrangThaiLenhTaxi:int
    {
        [EnumItem("Không thay đổi")]
        None = 999,
        [EnumItem("Không truyền đi")]
        KhongTruyenDi = 0, // chi de cho ben dien thoai nhin thay
        [EnumItem("Điện thoại")]
        DienThoai =1,      // Dien thoai da truyen di
        [EnumItem("Tổng đài")]
        BoDam = 2,           // Tong dai da truyen di 
        [EnumItem("Kết thúc")]
        KetThuc = 3,        // Cuoc goi da ket thuc TongDai & Dien thoai deu nhin thay
        [EnumItem("Kết thúc của điện thoại")]
        KetThucCuaDienThoai = 4, // Chi co Dien thoai duoc nhin thay
        [EnumItem("Điện thoại gửi sang mời khách")]
        DienThoaiGuiSangMoiKhach = 5, // điện thoại gửi thông tin cuốc khách sang mời khách.Cuộc gọi khiếu nại
        [EnumItem("Tổng đài gửi sang mời khách")]
        TongGuiSangMoiKhach = 6, // Cuoc goi truyen di san gmoi khach, duoc goi di cho cả tổng đài vào
        [EnumItem("Mời khách gửi")]
        MoiKhachGui = 7,
        [EnumItem("Cảnh báo")]
        CanhBao = 8, // Cảnh báo xe đến điểm.
        [EnumItem("Kết thúc tạm")]
        KetThucTam = 9,
    }

    /// <summary>
    /// kiểu cuộc gọi 
    ///   - Gọi taxi
    ///   - GỌi lại
    ///   - Gọi khiếu nại
    ///   - Gọi dịch vụ 
    ///   - Hỏi đàm
    ///   - Khác
    ///   - Gọi nhỡ
    /// </summary>
    public enum KieuCuocGoi:int 
    {
        [EnumItem("Không thay đổi")]
        None=999,
        [EnumItem("Trạng thái khác")]
        TrangThaiKhac = 0,
        [EnumItem("Gọi taxi")]
        GoiTaxi = 1,
        [EnumItem("Gọi lại")]
        GoiLai = 2,
        [EnumItem("Gọi khiếu nại")]
        GoiKhieuNai = 3,
        [EnumItem("Gọi dịch vụ")]
        GoiDichVu = 4,
        [EnumItem("Gọi hỏi đàm")]
        GoiHoiDam = 5, // thoong tin lai xe bao dam, ..
        [EnumItem("Gọi khác")]
        GoiKhac = 6,   // các cuộc hỏi gì đó không thuộc các cuộc trên
        [EnumItem("Gọi nhỡ")]
        GoiNho = 7,    // Cuoc goi khong nhac may
        [EnumItem("Gọi đến")]
        GoiDen = 99,   // Khach hang goi den
        [EnumItem("Gọi đi")]
        GoiDi = 100,
    }

    /// <summary>
    /// Cuộc gọi taxi (Cuộc gọi taxi và cuộc gọi lại)
    ///  Cuộc gọi taxi :
    ///     - Đón được (có xe nhận)
    ///     - Trượt (xe đến nhưng đã đi xe khách hoặc không thấy khách (khách vui tính)
    ///     - Hoãn (khách hàng chủ động hoãn.
    ///     - Không xe (không có xe nhận điểm )
    /// </summary>
    public enum TrangThaiCuocGoiTaxi : int
    {
        [EnumItem("Không thay đổi")]
        None = 99,
        [EnumItem("Khác")]
        TrangThaiKhac = 0,       // giong 999 - CP cu
        /// <summary>
        /// Cuốc đón được khách
        /// </summary>
        [EnumItem("Đón được khách")]
        CuocGoiDonDuocKhach = 1,
        /// <summary>
        /// 2. Cuộc gọi trượt
        /// </summary>
        [EnumItem("Trượt")]
        CuocGoiTruot = 2,
        /// <summary>
        /// 3. Cuộc gọi hoãn
        /// </summary>
        [EnumItem("Hoãn")]
        CuocGoiHoan = 3,
        /// <summary>
        /// 4. Cuốc không xe
        /// </summary>
        [EnumItem("Không xe")]
        CuocGoiKhongXe = 4,
        [EnumItem("Chưa xác định")]
        CuocGoiChuaXacDinh = 5,  // la cuoc goi taxi nhung - chua co xe nhan-hoac chua xu ly kip da bi ket thuc (ketthuc tu dong)
        [EnumItem("Không xe lần 1")]
        CuocGoiKhongXeLan1 = 6,
        [EnumItem("Điều lại app lái xe")]
        DieuLaiAppLaiXe = 10,//Điều lại app lái xe thì thoát cuốc hiện tại và tạo cuốc mới tiến hành thực hiện lại,
        /// <summary>
        /// 11. Nhầm khách
        /// </summary>
        [EnumItem("Nhầm khách")]
        NhamKhach = 11,
        [EnumItem("Nhầm khách điều lại xe")]
        NhamKhachDieuLai = 12
     }

    /// <summary>
    /// Dung tam thoi
    /// </summary>
    //public enum TrangThaiCuocGoi
    //{
    //    CuocGoiDen = 0, //La ta ca cac cuoc goi toi cong ty, sau do moi phan ra
    //    CuocGoiLai = 1,
    //    CuocGoiKhac = 2,
    //    CuocGoiDonDuocKhach = 3,
    //    CuocGoiTruot = 4,
    //    CuocGoiHoan = 5,
    //    CuocGoiKhongXe = 6,
    //    CuocGoiDaNhacMay = 7,
    //    CuocGoiChuaCoVoiceFile = 8,
    //    CuocGoiNho = 9, //Nhỡ
    //}
    public enum KieuKhachHangGoiDen
    {
        KhachHangKhongHieu = 0, // khach vui ve, khach ao
        KhachHangBinhThuong=1,
        KhachHangMoiGioi=2,
        KhachHangVIP=3,
        KhachHangGoiLai=4, // khách hàng gọi lại
        KhachHangHen=9,
        KhachHangVang = 5,
        KhachHangBac = 6,
        KhachHangMoiGioiKhac = 7, //MG không xác định,
        KhachHangKhaiThac = 8 //MG không xác định
    }

    public enum TypeCall
    {
        AllCall = 0,
        Incoming = 1,
        DialOut = 2,

    }

    public enum KieuLaiXeBao
    {
        BaoVe =0, // bao ve gara , giao ca
        BaoRaHoatDong=1,
        BaoDonDuocKhach=2,
        BaoDiemDo =3,
        /// <summary>
        /// va cham
        /// </summary>
        BaoSuCoTaiNanCongAn=4,
        BaoNghi=5,
        BaoNghi_AnCa = 6,
        BaoNghi_RoiXe =7,
        BaoDiemCuaTrungTam_DCTraKhach = 8,
        TongDaiCheck =9, // thiet lap gia tri nay khi tong dai check ma khong duoc
        KhongXacDinh =99,
        /// <summary>
        /// Xe gặp sự cố ; sự cố vé thẻ
        /// </summary>
        BaoHong = 10
    }


    /// <summary>
    /// Xe dagn cho khach di dau
    /// - noi thanh
    /// - san bay
    /// -duong dai
    /// </summary>
    
    public enum LoaiChoKhach
    {
        ChoKhachKhongXacDinh =99,
        ChoKhachNoiTinh=0,
        ChoKhachDuongDai =1,
        ChoKhachSanBay =2,
    }

    public enum LoaiChieuChoKhach
    {
        ChieuKhongXacDinh = 0,
        MotChieu          = 1,
        HaiChieu          = 2,
        MotChieuSanBayCoKhach = 3,
        MotChieuDonKhachTinh = 4,  // từ hà nội đi, đón khách ở tỉnh
        DuongDaiThueBao      = 5
    }
    
    public enum KieuMatLienLac
    {
        XeMatLienLac = 1,
        XeXinNghi = 2,
        XeDiSanBay = 3,
        XeDiDuongDai = 4,
    }
    
    /// <summary>
    /// khach danh gia cuoc goi
    /// 1 : TOT
    /// 2 : TRUNG BINH
    /// </summary>
    public enum KieuKhachDanhGiaCAMON:int 
    {
        ChuaDanhGia =0,
        DanhGiaTot = 1,    
        DanhGiaTrungBinh = 2,
    }

    public enum KieuDanhBa : int
    {

        MoiGioi = 1,
        CongTy = 2,
        KhachAo = 3,
        Online = 4,
        BuuDien = 5,
        ThanThiet = 6
    }

    #region ------New v3------------
    /// <summary>
    ///  Loai cuoc khach
    ///     Khong xacs dinh
    ///     Khach  noi tinh
    ///     Khach di duong dai
    ///     Khach di san bay
    /// </summary>
    public enum LoaiCuocKhach
    {
        ChoKhachKhongXacDinh = 99,
        /// <summary>
        /// 1 : Khách nội tỉnh
        /// </summary>
        ChoKhachNoiTinh = 1,
        /// <summary>
        /// 2 : Khách đường dài
        /// </summary>
        ChoKhachDuongDai = 2,
        /// <summary>
        /// 3 : Khách sân bay
        /// </summary>
        ChoKhachSanBay = 3,
        /// <summary>
        /// 4 : Khách hợp đồng
        /// </summary>
        ChoKhachHopDong = 4,
    }

    public enum KieuNhapTrenGridTongDai
    {
       [EnumItem("Chuyển kênh")]
        NhapChuyenKenh = 1,
        [EnumItem("Nhập xe nhận")]
        NhapXeNhan = 2,
        [EnumItem("Nhập xe đón")]
        NhapXeDon = 3,
        [EnumItem("Nhập xe đến điểm")]
        NhapXeNhanDenDiem = 4,
        [EnumItem("Nhập Ghi chú tổng đài")]
        NhapGhiChuTongDai = 5,
        TimKiemXe=6,
        NhapDiaChiTra=7,
        NhapXeDungDiem=8,
        NhapXeMK = 9,
        [EnumItem("Nhập số phút báo khách chờ")]
        NhapPhutKhachCho = 10,
    }

    public enum KieuCanhBaoKhiNhapThongTin
    {
        XeDonKhongThuocXeNhan = 1,
        XeNhanQuaXa = 2,
        ChuaDuSoLuongXeDon = 3,
        TrungXeDon = 4,
        TrungXeNhanApp = 5,
    }

    /// <summary>
    /// Loại tin nhắn màn hình gửi về
    /// </summary>
    public enum LoaiTinNhanMH
    {
        /// <summary>
        /// Báo nhân điểm
        /// </summary>
        NhanDiem = '1',
        /// <summary>
        /// Báo mời khách ra xe
        /// </summary>
        MoiKhach = '2',
        /// <summary>
        /// Lái xe báo hủy ko đi cuốc này nữa
        /// </summary>
        Huy = '3',
        /// <summary>
        /// Báo khách đã lên xe
        /// </summary>
        KhachDaLenXe = '4',

    }

    public enum MapModeEnum
    {
        EditPoint = 0,
        EditArea,
        ReadOnly
    }

    public enum XacNhanXeDon
    {
        //cuoc khach binh thuong
        MacDinh = 0,
        //Khong Xac Dinh
        KhongXacDinh = 1,
        //Lái xe không báo
        LaiXeKhongBao = 2,
        //Thiếu Xe Đón
        ThieuXeDon = 3,
    }

    public enum KieuBaoSuCo
    {
        XeGapSuCo = 1,
        VeThe = 2
    }

    public enum NoiDungSuCo
    {
        DongHo = 1,
        VaChamXeMay = 2,
        HetDien = 3,
        ChayDen = 4,
        VaChamVatTinh = 5,
        VaChamOto = 6,
        AcQuy = 7,
        HongLop = 8,
        VoKinh = 9,
        Khac = 0
    }

    /// <summary>
    /// Mô hình phòng điều hành
    /// </summary>
    public enum MoHinh
    {   None,
        TD_DT = 0,
        TongDaiMini = 1,
        TD_DT_MK = 2,
        TD_DT_LaiXe = 3
    }

    /// <summary>
    /// Lưới hiển thị điều hành
    /// </summary>
    public enum Grid_Config
    {
        /// <summary>
        /// Mặc định
        /// DTV : không có lưới của line khác bên phải
        /// TDV : có hiển thị lưới chờ giải quyết bên dưới
        /// </summary>
        Default = 0,
        /// <summary>
        /// DTV - Có hiển thị lưới của line khác
        /// </summary>
        Has_Grid_Right = 1,
        /// <summary>
        /// TDV - Có hiển thị lưới chờ giải quyết bên dưới
        /// </summary>
        Has_Grid_Bottom = 2
    }

    /// <summary>
    /// idxCompany ở file config
    /// </summary>
    public enum CongTy_Index
    {
        PhuBinh = 20
    }

    /// <summary>
    /// Module phần mềm
    /// </summary>
    public enum Module
    {
        /// <summary>
        /// 1. DienThoaiVien
        /// </summary>
        DienThoaiVien = 1,
        /// <summary>
        /// 2. TongDaiVien
        /// </summary>
        TongDaiVien = 2,
        /// <summary>
        /// 3. MoiKhach
        /// </summary>
        MoiKhach = 3,
        /// <summary>
        /// 4. DieuHanhChinh
        /// </summary>
        DieuHanhChinh = 4
    }
    #endregion

    /// <summary>
    /// Nhóm xe điều app
    /// </summary>
    public enum StaxiCarType_Type:int
    {
        /// <summary>
        /// 0 : Dòng xe taxi thường
        /// </summary>
        Taxi = 0,
        /// <summary>
        /// 1 : Dòng xe sân bay
        /// </summary>
        AriPort = 1,
        /// <summary>
        /// 2 : Dòng xe hợp đồng
        /// </summary>
        Car = 2
    }
}
