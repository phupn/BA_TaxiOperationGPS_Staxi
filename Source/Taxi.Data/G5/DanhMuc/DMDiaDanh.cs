#region ============= Copyright © 2016 BinhAnh =============
using System;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;
#endregion ============= Copyright © 2016 BinhAnh =============
namespace Taxi.Data.G5.DanhMuc
{
    [TableInfo(TableName = "T_DM_DIADANH")]
    public class DMDiaDanh : DbEntityBase<DMDiaDanh>
    {
        #region===Field===
        [Field(IsKey = true, IsIdentity = true)]
        public int PK_DiaDanh { get; set; }
        [Field]
        public string TenDiaDanh { get; set; }
        [Field]
        public string DiaChi { get; set; }
        [Field]
        public string DienThoai { get; set; }
        [Field]
        public string MoTa { get; set; }
        [Field]
        public string www { get; set; }
        [Field]
        public float KinhDo { get; set; }
        [Field]
        public float ViDo { get; set; }
        [Field]
        public int FK_LoaiDiaDanh { get; set; }
        #endregion

        #region===Methods===

        #endregion
    }
}
