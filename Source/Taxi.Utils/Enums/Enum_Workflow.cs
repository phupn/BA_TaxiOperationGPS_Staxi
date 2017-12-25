using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Common.EnumUtility;

namespace Taxi.Utils.Enums
{
    public enum Enum_Workflow
    {
        [EnumItem("Tập lệnh Mobile")]
        Mobile=1,
        [EnumItem("Tập lệnh tổng đài viên")]
        TongDaiVien = 2,
        [EnumItem("Tập lệnh điện thoại viên")]
        DienThoaiVien=3,
    }
}
