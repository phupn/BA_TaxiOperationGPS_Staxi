namespace Taxi.Utils.Enums
{
    /// <summary>
    /// 0 : Thêm mới
    /// 1 : Chuyển sang đàm
    /// 2 : Tiếp nhận hủy
    /// 3 : Nhập xe nhận
    /// 4 : Mời khách
    /// 5 : Nhập xe đón
    /// 6 : Hoãn
    /// 7 : Trượt
    /// 8 : Không xe
    /// </summary>
    public enum Enum_FastTaxi_Status
    {
        KhongXacDinh = -1,
        /// <summary>
        /// Mobile gửi book taxi
        /// </summary>
        ThemMoi=0,
        /// <summary>
        /// Tiếp nhận chuyển sang đàm
        /// </summary>
        ChuyenSangDam=1,
        /// <summary>
        /// Tiếp nhận hủy cuốc - Cuộc gọi khác
        /// </summary>
        TiepNhanHuy=2,
        /// <summary>
        /// Tổng đài nhập xe nhận
        /// Nhập nhiều xe nhận
        /// Check xe nhận mới khác với xe nhận hiện tại
        /// </summary>
        NhapXeNhan=3,
        /// <summary>
        /// Mobile đã nhận thông báo có xe nhận của PMDH
        /// </summary>
        NhapXeNhan_DaNhan = 31,
        /// <summary>
        /// Tổng đài nhập xe đến điểm
        /// Nhập nhiều xe đến điểm
        /// Check xe nhận mới khác với xe nhận hiện tại
        /// </summary>
        NhapXeNhan_XeDenDiem = 32,
        /// <summary>
        /// Tổng đài mời khách
        /// Check Lệnh Tổng đài là "Mời Khách" và khác với lệnh trước đó
        /// </summary>
        MoiKhach=4,
        /// <summary>
        /// Tổng đài nhập xe xe đón
        /// </summary>
        NhapXeDon=5,
        /// <summary>
        /// Khách báo Hoãn
        /// </summary>
        Hoan=6,
        /// <summary>
        /// Đã Hoãn
        /// </summary>
        Hoan_DaHoan = 61,
        /// <summary>
        /// Tổng đài báo trượt
        /// </summary>
        Truot=7,
        /// <summary>
        /// Tổng đài báo không xe xin lỗi khách - Tiếp nhận kết thúc cuốc không xe : "Đã xin lỗi"
        /// </summary>
        KhongXe=8,
        /// <summary>
        /// Điện thoại đã xin lỗi
        /// </summary>
        KhongXe_DaXinLoi=81
    }
}
