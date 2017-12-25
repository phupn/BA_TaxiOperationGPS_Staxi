using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;

namespace Taxi.Data.G5.DanhMuc
{
    [TableInfo(TableName = TableName)]
    public class DMDoiTac : DbEntityBase<DMDoiTac>
    {
        private const string TableName = "[T_DOITAC]";
        #region=== Properties ===
        [Field(IsIdentity = true, IsKey = true)]
        [ValueField]
        public string Ma_DoiTac { get; set; }
        [Field]
        [DisplayField]
        [ColumnField]
        public string Name { get; set; }
        [Field]
        public string Address { get; set; }
        [Field]
        public string Phones { get; set; }
        [Field]
        public string Fax { get; set; }
        [Field]
        public string Email { get; set; }
        [Field]
        public float TiLeHoaHongNoiTinh { get; set; }
        [Field]
        public float TiLeHoaHongNgoaiTinh { get; set; }
        [Field]
        public string Notes { get; set; }
        [Field]
        public bool IsActive { get; set; }
        [Field]
        public string FK_MaNhanVien { get; set; }
        [Field]
        public string TenNhanVien { get; set; }
        [Field]
        public int Vung { get; set; }
        [Field]
        public DateTime NgayKyKet { get; set; }
        [Field]
        public int FK_CongTyID { get; set; }
        [Field]
        public string SoNha { get; set; }
        [Field]
        public string TenDuong { get; set; }
        [Field]
        public DateTime NgayKetThuc { get; set; }
        [Field]
        public string UpdatedBy { get; set; }
        [Field]
        public DateTime UpdatedDate { get; set; }
        [Field]
        public string CreatedBy { get; set; }
        [Field]
        public DateTime CreatedDate { get; set; }
        [Field]
        public float KinhDo { get; set; }
        [Field]
        public float ViDo { get; set; }
        [Field]
        public string viettat { get; set; }
        [Field]
        public int LoaiDoiTacID { get; set; }
        #endregion

        #region === Methods===

        #endregion
    }
}
