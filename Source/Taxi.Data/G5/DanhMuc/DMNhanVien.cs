#region ============= Copyright © 2016 BinhAnh =============
using System;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;
#endregion ============= Copyright © 2016 BinhAnh =============
namespace Taxi.Data.G5.DanhMuc
{
    [TableInfo(TableName = "T_NHANVIEN")]
    public class DMNhanVien : DbEntityBase<DMNhanVien>
    {
        #region===Field===

        [Field(IsKey = true, IsIdentity = true)]
        public long ID { get; set; }

        [ValueField][Field]
        public string PK_MaNhanVien { get; set; }
        [Field]
        [DisplayField]
        [ColumnField]
        public string TenNhanVien { get; set; }
        [Field]
        public DateTime NgaySinh { get; set; }
        [Field]
        public string GioiTinh { get; set; }
        [Field]
        public string SoCMT { get; set; }
        [Field]
        public string DiaChi { get; set; }
        [Field]
        public string DienThoai { get; set; }
        [Field]
        public string DiDong { get; set; }
        [Field]
        public string Email { get; set; }
        [Field]
        public string VanBang { get; set; }
        [Field]
        public int FK_PhongID { get; set; }
        [Field]
        public int FK_ChucVu { get; set; }
        [Field]
        public string FK_SoHieuXeLai { get; set; }
        [Field]
        public string SoTheLaiXe { get; set; }
        [Field]
        public bool IsDelete { get; set; }
        [Field]
        public string ShortName { get; set; }
        [Field]
        public DateTime NgayVaoCty { get; set; }
        [Field]
        public DateTime NgayHetHan { get; set; }
        [Field]
        public DateTime NgayNghiLam { get; set; }
        [Field]
        public string HangBang { get; set; }
        [Field]
        public bool IsThamGiaBHXH { get; set; }
        [Field]
        public bool IsLaiXe { get; set; }
        [Field]
        public DateTime LastUpdate { get; set; }

        #endregion

        #region===Methods===

        #endregion
    }
}
