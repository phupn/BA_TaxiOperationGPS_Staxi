using System.Collections.Generic;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
using System.Data;
using System.Linq;

namespace Taxi.Data.BanCo.Entity.GiamSatXe
{
    [TableInfo(TableName = "T_TUDIEN_LOAIXE")]
    public class TuDien_LoaiXe : TaxiOperationDbEntityBase<TuDien_LoaiXe>
    {

        [Field(IsKey = true, IsIdentity = true)]
        [ValueField]
        public int LoaiXeID { get; set; }

        [Field]
        [DisplayField]
        [ColumnField(ColumnName = "Tên loại xe")]
        public string TenLoaiXe { get; set; }

        [Field]
        public int? SoCho { get; set; }

        [Field]
        public string LoaiXeID_GPS { get; set; }

        [Field]
        public string VietTat { get; set; }

        [Field]
        public string PhimTat { get; set; }

        [Field]
        public int Sort { get; set; }
        [Field]
        public string Font { get; set; }
        [Field]
        public string BackColor { get; set; }
        [Field]
        public string ForeColor { get; set; }

        #region field bảng giá cước

        public string FK_TuyenDuongID { get; set; }

        
        public int FK_DiemXuatPhatID { get; set; }

        
        public int FK_LoaiXeID { get; set; }

        
        public float KmQuyDinh1Chieu { get; set; }

        
        public float ThoiGianQuyDinh1Chieu { get; set; }

        
        public float GiaTien1Chieu { get; set; }

        
        public float KmQuyDinh2Chieu { get; set; }

        
        public float ThoiGianQuyDinh2Chieu { get; set; }

        
        public float GiaTien2Chieu { get; set; }

        
        public float GiaDinhMucVuot1KmMotChieu { get; set; }

        
        public float GiaDinhMucVuot1GioMotChieu { get; set; }

        
        public float GiaDinhMucVuot1KmHaiChieu { get; set; }

        
        public float GiaDinhMucVuot1GioHaiChieu { get; set; }

        
        public int VeTram { get; set; }
        #endregion 

        public List<TuDien_LoaiXe> GetListAll()
        {
            return GetAll().ToList<TuDien_LoaiXe>().OrderBy(o => o.Sort).ToList();
        }

        public DataTable GetDanhSachXe() {
            return ExeStore("sp_T_TUDIEN_LOAIXE_LayDS");
        }

        public DataTable getDsXeByID(string id) {
            return ExeStore("sp_T_TUDIEN_LOAIXE_LayListID", id);
        }

        public DataTable getDsXeNotInBgc(params object[] para)
        {
            return ExeStore("sp_T_TUDIEN_LOAIXE_GetNotIn",para);
        }

        public DataTable LayDanhSachXeTheoIDFastTaxi(params object[] para)
        {
            return ExeStore("sp_LayDanhSachXeTheoFastTaxi", para);
        }
    }
}
