using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
using System.Data;
using System.Data.SqlClient;


namespace Taxi.Data.BanCo.Entity.DM
{
    [TableInfo(TableName = "T_TUDIEN_CHUCVU")]
    public class TuDienChucVu : TaxiOperationDbEntityBase<TuDienChucVu>
    {
        #region Properties

        [Field(IsKey = true, IsIdentity = true)]
        public int ChucVuID { get; set; }

        [Field]
        public string TenChucVu { get; set; }

        [Field]
        public string GhiChu { get; set; }

        [Field]
        public string ShortName { get; set; }

        #endregion

        public List<TuDienChucVu> GetListAll()
        {
            return GetAll().ToList<TuDienChucVu>();
        }

        public int Insert(params object[] para)
        {
            return ExeStoreNoneQuery("sp_T_TUDIEN_CHUCVU_ThemMoi_BC", para);
        }

        public int Update(params object[] para)
        {
            return ExeStoreNoneQuery("sp_T_TUDIEN_CHUCVU_CapNhat_BC", para);
        }

        public int Delete(params object[] para)
        {
            return ExeStoreNoneQuery("sp_T_TUDIEN_CHUCVU_Xoa_BC", para);
        }

        public bool CheckTonTaiTenChucVu(params object[] para)
        {

            var result = ExeStoreWithOutput("sp_T_TuDien_ChucVu_CheckTonTaiTen", para);

            int iCount = result.Value["iCount"].To<int>(); ;

            if (iCount > 0) return true;

            return false;
        }

        public List<TuDienChucVu> GetTenChucVu() {
            return ExeStore("sp_T_TUDIEN_CHUCVU_GetAll").ToList<TuDienChucVu>();
        }
    }
}
