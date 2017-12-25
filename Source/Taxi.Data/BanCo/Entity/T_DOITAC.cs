using System;
using System.Collections.Generic;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
using System.Data;

namespace Taxi.Data.BanCo.Entity
{
    [TableInfo(TableName="T_DOITAC")]
    public class T_DOITAC : TaxiOperationDbEntityBase<T_DOITAC>
    {
        #region Properties
        [Field(IsKey=true,IsIdentity=true)]
        public int Ma_DoiTac { get; set; }

        [Field]
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
        public double? TiLeHoaHongNoiTinh { get; set; }

        [Field]
        public double? TiLeHoaHongNgoaiTinh { get; set; }

        [Field]
        public string Notes { get; set; }

        [Field]
        public int IsActive { get; set; }

        [Field]
        public string FK_MaNhanVien { get; set; }

        [Field]
        public string TenNhanVien { get; set; }

        [Field]
        public int? Vung { get; set; }

        [Field]
        public DateTime? NgayKyKet { get; set; }

        [Field]
        public int? FK_CongTyID { get; set; }

        [Field]
        public string SoNha { get; set; }

        [Field]
        public string TenDuong { get; set; }

        [Field]
        public DateTime? NgayKetThuc { get; set; }

        [Field]
        public string UpdatedBy { get; set; }

        [Field]
        public DateTime? UpdatedDate { get; set; }

        [Field]
        public string CreatedBy { get; set; }

        [Field]
        public DateTime? CreatedDate { get; set; }

        [Field]
        public double? KinhDo { get; set; }

        [Field]
        public double? ViDo { get; set; }
        #endregion Properties

        #region Methods
        public List<T_DOITAC> GetListAll()
        {
            return this.getAll().ToList<T_DOITAC>();
        }

        public DataTable getAll() 
        {
            return ExeStore("sp_T_DOITAC_GETALL");
        }

        public int UpdateDoiTac(params object[] para) 
        {
            return ExeStoreNoneQuery("spUpdate_T_DOITAC_V3",para);
        }

        public int UpdateTrangThai(params object[] para)
        {
            return ExeStoreNoneQuery("sp_T_DOITAC_UpdateIsActive", para);
        }

        public int InsertDoiTac(params object[] para) 
        {
            return ExeStoreNoneQuery("spInsert_T_DOITAC_V3", para);
        }

        public int GetMaDoiTac() 
        {
            int MaDoiTac = 1;
            DataTable dtMaDoiTac = ExeStore("sp_T_DOITAC_GETMADT");
            if(dtMaDoiTac.Rows.Count > 0)
            {
                MaDoiTac = int.Parse(dtMaDoiTac.Rows[0][0].ToString()) + 1;
            }
            return MaDoiTac;
        }
        #endregion Methods

        public void UpdateNewAddress(params object[] pInput)
        {
            this.ExeStore("sp_T_DoiTac_UpdateNewAddress", pInput);
        }
    }
}
