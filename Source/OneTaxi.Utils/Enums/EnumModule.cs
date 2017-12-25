using Staxi.Utils.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTaxi.Utils.Enums
{
    public enum EnumModule
    {
        [FieldInfo(Name = "Cấu hình Server")]
        None = 0,
        [FieldInfo(Name = "Điện thoại")]
        DienThoai = 1,
        [FieldInfo(Name = "Tổng đài")]
        TongDai = 2,
        [FieldInfo(Name = "Tổng đài mini")]
        TongDaiMini = 3,
        [FieldInfo(Name = "Điều hành chính")]
        DieuHanhChinh=4
    }
}
