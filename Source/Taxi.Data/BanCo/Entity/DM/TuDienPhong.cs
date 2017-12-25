using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;

namespace Taxi.Data.BanCo.Entity.DM
{
    [TableInfo(TableName = "T_TUDIEN_PHONG")]
    public class TuDienPhong : TaxiOperationDbEntityBase<TuDienPhong>
    {
        #region Properties

        [Field(IsKey = true, IsIdentity = true)]
        public int PhongID { get; set; }

        [Field]
        public string TenPhong { get; set; }

        [Field]
        public string GhiChu { get; set; }

        [Field]
        public string ShortName { get; set; }

        #endregion

        // get all
        public List<TuDienPhong> GetListAll()
        {
            return GetAll().ToList<TuDienPhong>();
        }

        // thêm mới
        public int Insert(params object[] para) {
            return ExeStoreNoneQuery("sp_T_TUDIEN_PHONG_ThemMoi_BC", para);
        }

        // cập nhật
        public int Update(params object[] para)
        {
            return ExeStoreNoneQuery("sp_T_TUDIEN_PHONG_CapNhat_BC", para);
        }

        // xóa
        public int Delete(params object[] para)
        {
            return ExeStoreNoneQuery("sp_T_TUDIEN_PHONG_Xoa_BC", para);
        }

        // check trùng tên
        public bool CheckTonTaiTenPhong(params object[] para)
        {

            var result = ExeStoreWithOutput("sp_T_TuDien_Phong_CheckTonTaiTen", para);

            int iCount = result.Value["iCount"].To<int>();

            if (iCount > 0) return true;

            return false;
        }

        public List<TuDienPhong> GetTenPhong() {
            return ExeStore("sp_T_TUDIEN_PHONG_GetAll").ToList<TuDienPhong>();
        }
    }
}
