using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Common.EnumUtility;

namespace Taxi.Utils
{
    /// <summary>
    /// Thực hiện các chức nằng từ hãng theo yêu cầu.
    /// Lưu ý:Thêm 1 chức mừng thì thêm vào enum,Không sửa sẽ ảnh hưởng các hãng khác
    /// </summary>
    public enum TaxiFunction
    {
        [EnumItem("Không làm gì")]
        None=0,
        [EnumItem("Nhập xe nhận")]
        NhapXeNhan=1,
        [EnumItem("Nhập xe điến điểm")]
        NhapXeDenDiem = 2,
        [EnumItem("Nhập xe dừng điểm")]
        NhapXeDungDiem = 3,
        [EnumItem("Nhập xe đón")]
        NhapXeDon = 4,
        [EnumItem("Nhập ghi chú")]
        NhapGhiChu = 5,
        [EnumItem("Mở bản đồ")]
        MoBanDo = 6,
    }
}
