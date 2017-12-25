using Taxi.Common.EnumUtility;

namespace Taxi.Utils.Enums.DieuXeChieuVe
{
    /*
      * -1:Hủy điều 
      * 0: Chưa gửi
      * 1: Đang gửi
      * 2: Đã kết thúc gửi
     */
    public enum Enum_Bookings_Status
    {
        [EnumItem("Chưa gửi")]
        ChuaGui = 0,
        [EnumItem("Đang gửi")]
        DangGui = 1,
        [EnumItem("Đã kết thúc gủi")]
        DaKetThucGui=2
    }
}