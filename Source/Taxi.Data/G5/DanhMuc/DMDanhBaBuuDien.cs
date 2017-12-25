#region ============= Copyright © 2016 BinhAnh =============
using System;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;
#endregion ============= Copyright © 2016 BinhAnh =============
namespace Taxi.Data.G5.DanhMuc
{
    [TableInfo(TableName = "T_DANHBA_BUUDIEN")]
    public class DMDanhBaBuuDien : DbEntityBase<DMDanhBaBuuDien>
    {
        #region===Field===
        [Field(IsKey= true)]
        public string PhoneNumber { get; set; }
        [Field]
        public string Name { get; set; }
        [Field]
        public string Address { get; set; }
        #endregion

        #region===Methods===

        #endregion
    }
}
