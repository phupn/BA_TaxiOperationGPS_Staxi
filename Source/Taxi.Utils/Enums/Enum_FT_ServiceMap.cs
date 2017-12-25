using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.EnumUtility;

namespace Taxi.Utils.Enums
{
    public enum Enum_FT_ServiceMap
    {
        [EnumItem("Mặc định")]
        None = 0,
        [EnumItem("Google")]
        Google = 1,
        [EnumItem("Bình anh")]
        BinhAnh=2
    }
}
