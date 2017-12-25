#region ============= Copyright © 2016 BinhAnh =============
using System;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;
using Taxi.Common.Extender;
using System.Collections.Generic;
#endregion ============= Copyright © 2016 BinhAnh =============
namespace Taxi.Data.G5.DanhMuc
{
    [TableInfo(TableName = "T_DANHBA_KHACHAO")]
    public class DMKhachAo : DbEntityBase<DMKhachAo>
    {
        private const string sp_DMKhachAo_GetData = "sp_DMKhachAo_GetData";
        #region===Field===
        [Field(IsKey = true)]
        public string PhoneNumber { get; set; }
        [Field]
        public string Name { get; set; }
        [Field]
        public string Address { get; set; }
        #endregion

        #region===Methods===
        public static List<DMKhachAo> GetData(string PhoneNumber, string Name, string Address)
        {
            return Inst.ExeStore(sp_DMKhachAo_GetData, PhoneNumber, Name, Address).ToList<DMKhachAo>();
        }
        #endregion
    }
}
