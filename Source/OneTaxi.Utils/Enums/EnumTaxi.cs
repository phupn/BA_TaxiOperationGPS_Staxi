using Staxi.Utils.Attributes;
namespace OneTaxi.Utils.Enums
{
    public enum EnumTrangThaiLenh : int
    {
        [FieldInfo(Name = "Không thay đổi")]
        None = 999,
        [FieldInfo(Name = "Không truyền đi")]
        KhongTruyenDi = 0, // chi de cho ben dien thoai nhin thay
        [FieldInfo(Name = "Điện thoại")]
        DienThoai = 1,      // Dien thoai da truyen di
        [FieldInfo(Name = "Tổng đài")]
        BoDam = 2,           // Tong dai da truyen di 
        [FieldInfo(Name = "Kết thúc")]
        KetThuc = 3,        // Cuoc goi da ket thuc TongDai & Dien thoai deu nhin thay
        [FieldInfo(Name = "Kết thúc của điện thoại")]
        KetThucCuaDienThoai = 4, // Chi co Dien thoai duoc nhin thay
        [FieldInfo(Name = "Điện thoại gửi sang mời khách")]
        DienThoaiGuiSangMoiKhach = 5, // điện thoại gửi thông tin cuốc khách sang mời khách.Cuộc gọi khiếu nại
        [FieldInfo(Name = "Tổng đài gửi sang mời khách")]
        TongGuiSangMoiKhach = 6, // Cuoc goi truyen di san gmoi khach, duoc goi di cho cả tổng đài vào
        [FieldInfo(Name = "Mời khách gửi")]
        MoiKhachGui = 7,
        [FieldInfo(Name = "Cảnh báo")]
        CanhBao = 8, // Cảnh báo xe đến điểm.
        [FieldInfo(Name = "Kết thúc tạm")]
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
    public enum EnumKieuCuocGoi : int
    {
        [FieldInfo(Name = "Không thay đổi")]
        None = 999,
        [FieldInfo(Name = "Trạng thái khác")]
        TrangThaiKhac = 0,
        [FieldInfo(Name = "Gọi taxi")]
        GoiTaxi = 1,
        [FieldInfo(Name = "Gọi lại")]
        GoiLai = 2,
        [FieldInfo(Name = "Gọi khiếu nại")]
        GoiKhieuNai = 3,
        [FieldInfo(Name = "Gọi dịch vụ")]
        GoiDichVu = 4,
        [FieldInfo(Name = "Gọi hỏi đàm")]
        GoiHoiDam = 5, // thoong tin lai xe bao dam, ..
        [FieldInfo(Name = "Gọi khác")]
        GoiKhac = 6,   // các cuộc hỏi gì đó không thuộc các cuộc trên
        [FieldInfo(Name = "Gọi nhỡ")]
        GoiNho = 7,    // Cuoc goi khong nhac may
        [FieldInfo(Name = "Gọi đến")]
        GoiDen = 99,   // Khach hang goi den
        [FieldInfo(Name = "Gọi đi")]
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
    public enum EnumTrangThaiCuocGoi : int
    {
        [FieldInfo(Name = "Không thay đổi")]
        None = 999,
        [FieldInfo(Name = "Khác")]
        TrangThaiKhac = 0,       // giong 999 - CP cu
        [FieldInfo(Name = "Đón được khách")]
        CuocGoiDonDuocKhach = 1,
        [FieldInfo(Name = "Trượt")]
        CuocGoiTruot = 2,
        [FieldInfo(Name = "Hoãn")]
        CuocGoiHoan = 3,
        [FieldInfo(Name = "Không xe")]
        CuocGoiKhongXe = 4,
        [FieldInfo(Name = "Chưa xác định")]
        CuocGoiChuaXacDinh = 5,  // la cuoc goi taxi nhung - chua co xe nhan-hoac chua xu ly kip da bi ket thuc (ketthuc tu dong)
        [FieldInfo(Name = "Không xe lần 1")]
        CuocGoiKhongXeLan1 = 6,
        [FieldInfo(Name = "Điều lại app lái xe")]
        DieuLaiAppLaiXe = 10,//Điều lại app lái xe thì thoát cuốc hiện tại và tạo cuốc mới tiến hành thực hiện lại,
        [FieldInfo(Name = "Nhầm khách")]
        NhamKhach = 11
    }
}
