#region ============= Copyright © 2016 BinhAnh =============
using System;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;
#endregion ============= Copyright © 2016 BinhAnh =============

namespace Taxi.Data.G5.DanhMuc
{
    [TableInfo(TableName = "[T_DMCongTy]")]
    public  class DMCongTy : DbEntityBase<DMCongTy>
    {
        [Field(IsKey=true,IsIdentity=true)]
        [ValueField]
        public int PK_CongtyID { get; set; }
        [Field]
        [DisplayField]
        [ColumnField]
        public string TenCongTy { get; set; }
    }
}
