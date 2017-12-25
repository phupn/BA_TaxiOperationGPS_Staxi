using Taxi.Common.EnumUtility;

namespace Taxi.Utils.Enums.DieuXeChieuVe
{
    /*
    0: Chờ điều
    1: Đã điều xe
    2: Đã đón
    3: Trượt
    4: Hoãn
    5: Không xe
    6: Hủy điều
     */
    /*
        Chấp nhận.
        Đã đón khách.
        Từ chối.
        Trượt.
        Hoãn.
        Không xe.
        Hủy điều.
     */
    public enum Enum_Bookings_OpStatus
    {
        /// <summary>
        /// Chờ xử lý
        /// </summary>
        [EnumItem("Chờ xử lý")]
        ChoXuLy = 0,
        /// <summary>
        /// Chấp nhận - Đồng ý ghép Book
        /// </summary>
        [EnumItem("Chấp nhận")]
        ChapNhan = 1,
        /// <summary>
        /// Đã đón khách
        /// </summary>
        ///[EnumItem("Đã đón khách")]
        DaDonKhach = 2,
        /// <summary>
        /// Từ chối - Không ghép Book - Cập nhật lại trạng thái Trip để chờ ghép cuốc khác
        /// </summary>
        [EnumItem("Từ chối")]
        TuChoi = 3,
        /// <summary>
        /// Trượt - Hủy Book - Cập nhật lại trạng thái Trip để chờ ghép cuốc khác
        /// </summary>
        [EnumItem("Trượt")]
        Truot = 4,
        /// <summary>
        /// Hoãn - Hủy Book - Cập nhật lại trạng thái Trip để chờ ghép cuốc khác
        /// </summary>
        [EnumItem("Hoãn")]
        Hoan = 5,
        /// <summary>
        /// Không xe - Hủy Book - Cập nhật lại trạng thái Trip để chờ ghép cuốc khác
        /// </summary>
        [EnumItem("Không xe")]
        KhongXe = 6,
        /// <summary>
        /// Hủy điều - Hủy Book - Cập nhật lại trạng thái Trip để chờ ghép cuốc khác
        /// </summary>
        [EnumItem("Hủy điều")]
        HuyDieu = 7,
        /// <summary>
        /// Không xử lý - Kết thúc Book vì DH không nhận xử lý - Chưa kết thúc Trip
        /// </summary>
        [EnumItem("Không xử lý")]
        KhongXuLy=8,
        /// <summary>
        /// Kết thúc Book - Chưa kết thúc Trip
        /// </summary>
        [EnumItem("Kết thúc")]
        KetThuc=9,
        /// <summary>
        /// Khách hàng hủy - Hủy Book - Không hủy Trip
        /// </summary>
        [EnumItem("Khách hàng hủy")]
        KhachHangHuy = 10,
        /// <summary>
        /// Kết thúc Book - Chưa kết thúc Trip - Bên mobile kết thúc.
        /// </summary>
        [EnumItem("Khách hàng kết thúc")]
        MobileKetThuc = 11
       
    }
}