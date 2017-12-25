#region ============= Copyright © 2016 BinhAnh =============
using System;
using System.Collections.Generic;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;
using Taxi.Common.Extender;
#endregion ============= Copyright © 2016 BinhAnh =============

namespace Taxi.Data.G5.DanhMuc
{
    [TableInfo(TableName = "T_TUDIEN_LOAIXE")]
    public class LoaiXe : DbEntityBase<LoaiXe>
    {
        #region===Field===
        [Field(IsKey = true, IsIdentity = true)]
        [ValueField]
        public int LoaiXeID { get; set; }
        [Field]
        [DisplayField]
        [ColumnField]
        public string TenLoaiXe { get; set; }
        [Field]
        public int SoCho { get; set; }
        [Field]
        public string LoaiXeID_GPS { get; set; }
        [Field]
        public int LoaiXeID_FastTaxi { get; set; }
        [Field]
        public string TenHienThi { get; set; }
        [Field]
        public bool IsDelete { get; set; }
        [Field]
        public int Sort { get; set; }
        [Field]
        public string Font { get; set; }
        [Field]
        public int Sort_BanCo { get; set; }
        [Field]
        public bool IsXeTo { get; set; }
        [Field]
        public string BackColor { get; set; }
        [Field]
        public string ForeColor { get; set; }
        [Field]
        public string VietTat { get; set; }
        [Field]
        public string PhimTat { get; set; }
        [Field]
        public string HangXe { get; set; }
        [Field]
        public string KichThuoc { get; set; }
        [Field]
        public string TaiTrongQuyDinh { get; set; }
        [Field]
        public string TaiTrongChoPhep { get; set; }
        [Field]
        public string G5_CarType { get; set; }
        [Field]
        public bool G5_SanBay { get; set; }

        #endregion

        #region===Methods===
      
        #endregion
    }
}
