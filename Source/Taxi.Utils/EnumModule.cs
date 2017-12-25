using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Common.EnumUtility;

namespace Taxi.Utils
{
    public enum EnumModule
    {
        None = 0,
        Staxi_DienThoai = 1,
        Staxi_TongDai = 2,
        [EnumItem("Điện thoại")]
        G5_DienThoai = 3,
        [EnumItem("Tổng đài")]
        G5_TongDai = 4,
        EnVang_DienThoai = 5,
        EnVang_TongDai = 6,
        DieuHanhChinh = 7,
        [EnumItem("Tổng đài mini")]
        G5_TongDaiMini = 8,
    }

    public enum ExcelBinderType
    {
        None = 0,
        Grid = 1,
        GridGroup = 2
    }
}
