#region ============= Copyright © 2016 BinhAnh =============
using System;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;
#endregion ============= Copyright © 2016 BinhAnh =============

namespace Taxi.Data.G5.DanhMuc
{
    [TableInfo(TableName = "T_DMGARA")]
    public class Gara : DbEntityBase<Gara>
    {
        #region===Field===
        [Field(IsKey = true, IsIdentity = true)]
        [ValueField]
        public int ID { get; set; }
        [Field]
        [DisplayField]
        [ColumnField]
        public string Name { get; set; }
        [Field]
        public string VietTat { get; set; }
        [Field]
        public float KinhDo { get; set; }
        [Field]
        public float ViDo { get; set; }
        [Field]
        public int BanKinh { get; set; }
        [Field]
        public int IDGPS { get; set; }
        public int FK_GaraID { get { return ID; } }
        #endregion

        #region===Methods===

        #endregion
    }
}
