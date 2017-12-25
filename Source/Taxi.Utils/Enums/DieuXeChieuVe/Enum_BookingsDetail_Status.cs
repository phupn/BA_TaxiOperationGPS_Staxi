using Taxi.Common.EnumUtility;

namespace Taxi.Utils.Enums.DieuXeChieuVe
{
    /*
     * -1: Hủy điều
     * 0: Đang đợi phản hồi từ điều hành
     * 1: Được chấp nhận
     * 2: Từ chối
     * 3: Không trả lời(timeout)
     */
    public enum Enum_BookingsDetail_Status
    {
        
        [EnumItem("Đang chời phản hồi")]
        DangDoiPhanHoi = 0,
        [EnumItem("được chấp nhận")]
        DuocChapNhan = 1,
        [EnumItem("Từ chối")]
        TuChoi = 2,
        [EnumItem("Không trả lời")]
        KhongTraLoi=3
    }
    
}
