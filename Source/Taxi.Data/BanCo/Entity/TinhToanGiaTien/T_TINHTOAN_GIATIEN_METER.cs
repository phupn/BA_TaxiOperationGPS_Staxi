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
    [TableInfo(TableName = "T_TINHTOAN_GIATIEN_METER")]
    public class T_TINHTOAN_GIATIEN_METER : TaxiOperationDbEntityBase<T_TINHTOAN_GIATIEN_METER>
    {
        #region Properties
        [Field(IsKey = true, IsIdentity = false)]
        public int LoaiXe { get; set; }


        [Field]
        public float KmMoCua { get; set; }

        [Field]
        public float GiaMoCua { get; set; }

        [Field]
        public float KmNguong1 { get; set; }

        [Field]
        public float GiaNguong1 { get; set; }

        [Field]
        public float KmNguong2 { get; set; }

        [Field]
        public float GiaNguong2 { get; set; }

        [Field]
        public float KmNguong3 { get; set; }

        [Field]
        public float GiaNguong3 { get; set; }

        [Field]
        public float KmNguong2Chieu { get; set; }

        [Field]
        public float TiLeGiamGiaHaiChieu { get; set; }

        [Field]
        public string ThongTinThueBao { get; set; }

        [Field]
        public float N1_ChieuDiTu { get; set; }

        [Field]
        public float N1_ChieuDiDen { get; set; }

        [Field]
        public float N1_Giam { get; set; }

        [Field]
        public float N2_ChieuDiTu { get; set; }

        [Field]
        public float N2_Giam { get; set; }

        [Field]
        public bool IsAll { get; set; }
        #endregion

        public List<T_TINHTOAN_GIATIEN_METER> GetListAll() {
            return GetAll().ToList<T_TINHTOAN_GIATIEN_METER>();
        }

        public int UpdateMeter(params object[] para) {
            return ExeStoreNoneQuery("sp_T_TINHTOAN_GIATIEN_METER_Update", para);
        }

        public T_TINHTOAN_GIATIEN_METER GetByLoaiXe(params object[] para) {
            return ExeStore("sp_T_TINHTOAN_GIATIEN_METER_GetByLoaiXe", para).ToList<T_TINHTOAN_GIATIEN_METER>().FirstOrDefault<T_TINHTOAN_GIATIEN_METER>();
        }

        public int DeleteMeter(params object[] para)
        {
            return ExeStoreNoneQuery("sp_T_TINHTOAN_GIATIEN_METER_Delete",para);
        }

        public bool CheckTrungNgay(params object[] para)
        {
            DataTable dtCheck = new DataTable();
            dtCheck = ExeStore("sp_T_TINHTOAN_GIATIEN_METER_CheckTrungNgay", para);
            if (dtCheck != null && dtCheck.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public bool CheckTrungLoaiXe(params object[] para)
        {
            DataTable dtCheck = new DataTable();
            dtCheck = ExeStore("sp_T_TINHTOAN_GIATIEN_METER_CheckTrungLoaiXe", para);
            if (dtCheck != null && dtCheck.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public bool CheckTrungKhoangThoiGian(params object[] para)
        {
            DataTable dtCheck = new DataTable();
            dtCheck = ExeStore("sp_T_TINHTOAN_GIATIEN_METER_CheckKhoangThoiGian", para);
            if (dtCheck != null && dtCheck.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
