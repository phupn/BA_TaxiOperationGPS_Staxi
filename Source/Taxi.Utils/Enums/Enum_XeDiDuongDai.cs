using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Common.EnumUtility;

namespace Taxi.Utils.Enums
{
    /// <summary>
        //0 : Không xác đinh
        //1 : Chờ ghép khách
        //2 : Đã ghép khách
        //3 : Khách đã lên xe
        //4 : Hủy điều
        //5 : Kết thúc
    /// </summary>
    public enum Enum_XeBaoDiDuongDai_TrangThai
    {
        
        None=-1,
        //[EnumItem("Không xác đinh")]
        KhongXacDinh = 0,
        [EnumItem("Chờ ghép khách")]
        ChoGhepKhach = 1,
        [EnumItem("Đã ghép khách")]
        DaGhepKhach = 2,
        [EnumItem("Khách đã lên xe")]
        KhachDaLenXe = 3,
        [EnumItem("Hủy cuốc đi đường dài")]
        HuyDieu = 4,
        //[EnumItem("Kết thúc")]
        //KetThuc = 5
    }
    /// <summary>
    /// 0 : Chờ duyệt
    //  1 : Đã duyệt
    //  2 : Không duyệt
    /// </summary>
    public enum Enum_XeBaoDiDuongDai_TrangThaiDuyet
    {
        None=-1,
        [EnumItem("Chờ duyệt")]
        ChoDuyet = 0,
        [EnumItem("Đã duyệt")]
        DaDuyet = 1,
        [EnumItem("Không duyệt")]
        KhongDuyet = 2,
    }
    public enum Enum_SendServer
    {
        None=-1,
        [EnumItem("Đồng ý gửi")]
        DaGui=1,
        [EnumItem("Không đồng ý gửi")]
        ChuaGui=2
    }
}
