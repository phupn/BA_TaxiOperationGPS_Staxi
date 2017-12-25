
using System.Collections.Generic;
using Taxi.Common.DbBase.Attributes;
using Taxi.Data.BanCo.DbConnections;
using System.Data;
using Taxi.Common.Extender;

namespace Taxi.Data.BanCo.Entity.TuyenThueBao
{
    [TableInfo(TableName = "THUEBAO.T_VUOTGIOQUYDINH")]
    public class VuotGioQuyDinh : TaxiOperationDbEntityBase<VuotGioQuyDinh>
    {
        [Field(IsKey = true)]
        public int FK_LoaiXeID { get; set; }

        [Field]
        public float GiaDinhMucVuot1KmMotChieu { get; set; }

        [Field]
        public float GiaDinhMucVuot1GioMotChieu { get; set; }

        [Field]
        public float GiaDinhMucVuot1KmHaiChieu { get; set; }

        [Field]
        public float GiaDinhMucVuot1GioHaiChieu { get; set; }
         [Field]
        public float TienLuuDem { get; set; }

        public List<VuotGioQuyDinh> GetListAll()
        {
            return getAllVuotGio().ToList<VuotGioQuyDinh>();
        }

        #region form vuot gio quy dinh
        public DataTable getAllVuotGio()
        {
            return ExeStore("sp_THUEBAO_T_VUOTGIOQUYDINH_SelectAll");
        }

        public int InsertVuotGio(params object[] para)
        {
            return ExeStoreNoneQuery("sp_THUEBAO_T_VUOTGIOQUYDINH_Insert", para);
        }

        public int UpdateVuotGio(params object[] para)
        {
            return ExeStoreNoneQuery("sp_THUEBAO_T_VUOTGIOQUYDINH_Update", para);
        }

        public int DeleteVuotGio(params object[] para)
        {
            return ExeStoreNoneQuery("sp_THUEBAO_T_VUOTGIOQUYDINH_Delete", para);
        }
        #endregion
    }
}
