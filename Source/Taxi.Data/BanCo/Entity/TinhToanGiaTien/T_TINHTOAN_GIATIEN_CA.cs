using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
using System.Data;

namespace Taxi.Data.BanCo.Entity.TinhToanGiaTien
{
    [TableInfo(TableName = "T_TINHTOAN_GIATIEN_CA")]
    public class T_TINHTOAN_GIATIEN_CA : TaxiOperationDbEntityBase<T_TINHTOAN_GIATIEN_CA>
    {
        #region Properties
        [Field(IsKey = true, IsIdentity = false)]
        public int LoaiXe { get; set; }

        [Field]
        public float GiaTienNuaNgay { get; set; }

        [Field]
        public float ThoiGianNuaNgay { get; set; }

        [Field]
        public float KmNuaNgay { get; set; }

        [Field]
        public float GiaTienMotNgay { get; set; }

        [Field]
        public float ThoiGianMotNgay { get; set; }

        [Field]
        public float KmMotNgay { get; set; }
        #endregion

        public List<T_TINHTOAN_GIATIEN_CA> GetListAll() {
            return GetAll().ToList<T_TINHTOAN_GIATIEN_CA>();
        }

        public T_TINHTOAN_GIATIEN_CA GetByLoaiXe(params object[] para) {
            return ExeStore("sp_T_TINHTOAN_GIATIEN_CA_GetByLoaiXe",para).ToList<T_TINHTOAN_GIATIEN_CA>().FirstOrDefault<T_TINHTOAN_GIATIEN_CA>();
        }

        public DataTable GetAllCa() {
            return ExeStore("sp_T_TINHTOAN_GIATIEN_CA_GetAll");
        }

        public int DeleteTheoCa(params object[] para)
        {
            return ExeStoreNoneQuery("sp_T_TINHTOAN_GIATIEN_CA_Delete", para);
        }

        public bool CheckTrungNgay(params object[] para) {
            DataTable dtCheck = new DataTable();
            dtCheck = ExeStore("sp_T_TINHTOAN_GIATIEN_CA_CheckTrungNgay", para);
            if (dtCheck != null && dtCheck.Rows.Count > 0) {
                return true;
            }
            return false;
        }

        public int UpdateTheoCa(params object[] para) {
            return ExeStoreNoneQuery("sp_T_TINHTOAN_GIATIEN_CA_Update", para);
        }

        public bool CheckTrungLoaiXe(params object[] para)
        {
            DataTable dtCheck = new DataTable();
            dtCheck = ExeStore("sp_T_TINHTOAN_GIATIEN_CA_CheckTrungLoaiXe", para);
            if (dtCheck != null && dtCheck.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public bool CheckKhoangThoiGian(params object[] para)
        {
            DataTable dtCheck = new DataTable();
            dtCheck = ExeStore("sp_T_TINHTOAN_GIATIEN_CA_CheckKhoangThoiGian", para);
            if (dtCheck != null && dtCheck.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public int InsertCa(params object[] para) {
            return ExeStoreNoneQuery("sp_T_TINHTOAN_GIATIEN_CA_Insert", para);
        }

        public T_TINHTOAN_GIATIEN_CA GetBangGiaMoiNhat(params object[] para)
        {
            return ExeStore("sp_T_TINHTOAN_GIATIEN_CA_GetBangGiaByLoaiXeMoiNhat",para).ToList<T_TINHTOAN_GIATIEN_CA>().FirstOrDefault<T_TINHTOAN_GIATIEN_CA>();
        }

        public int UpdateCaCu(params object[] para)
        {
            return ExeStoreNoneQuery("sp_T_TINHTOAN_GIATIEN_CA_UpdateNgayApDungDen", para);
        }

        //hàm tìm kiếm theo loại xe
        public T_TINHTOAN_GIATIEN_CA SearchTheoCa(params object[] para) {
            return ExeStore("sp_T_TINHTOAN_GIATIEN_CA_SearchGia",para).ToList<T_TINHTOAN_GIATIEN_CA>().FirstOrDefault<T_TINHTOAN_GIATIEN_CA>();
        }
    }
}
