using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Common.DbBase.Attributes;
using Taxi.Data.BanCo.DbConnections;
using System.Data;
using Taxi.Common.Extender;

namespace Taxi.Data.BanCo.Entity.TuyenThueBao
{
    [TableInfo(TableName = "THUEBAO.T_NHATKYTHUEBAO")]
    public class NhatKyThueBao : TaxiOperationDbEntityBase<NhatKyThueBao>
    {
        #region properties
        [Field(IsKey = true, IsIdentity = true)]
        public int ID { get; set; }


        [Field]
        public DateTime ThoiDiem { get; set; }

        [Field]
        public string SoHieuXe { get; set; }

        [Field]
        public string TenLaiXe { get; set; }

        [Field]
        public int DiemXuatPhatID { get; set; }

        [Field]
        public int TuyenDuongID { get; set; }

        [Field]
        public string TenTuyenDuong { get; set; }

        [Field]
        public DateTime ThoiGianDon { get; set; }

        [Field]
        public int KmDon { get; set; }

        [Field]
        public DateTime ThoiGianTra { get; set; }


        [Field]
        public int KmTra { get; set; }

        [Field]
        public int KmDongHo { get; set; }

        [Field]
        public float KmThucDi { get; set; }

        [Field]
        public int DongHoTien { get; set; }

        [Field]
        public string PhuTroi { get; set; }

        [Field]
        public float TienThucThu { get; set; }

        [Field]
        public string GhiChu { get; set; }

        [Field]
        public int Chieu { get; set; }

        [Field]
        public int LoaiXeID { get; set; }

        [Field]
        public string GiaThueBao { get; set; }

        [Field]
        public DateTime CreatedDate { get; set; }

        [Field]
        public string CreatedByUser { get; set; }

        [Field]
        public DateTime UpdatedDate { get; set; }

        [Field]
        public string UpdatedByUser { get; set; }

        [Field]
        public int SoLanSua { get; set; }

        [Field]
        public int DongBo { get; set; }

        [Field]
        public int TuDong { get; set; }

        [Field]
        public DateTime ThoiGianDongBoTuDong { get; set; }

        [Field]
        public int LayGioDonTuDong { get; set; }

        [Field]
        public long CuocKhachID { get; set; }

        #endregion

  
        public DataTable getNhatKyThueBaoBySoHieuXe(params object[] para)
        {
            return ExeStore("sp_T_NHATKYTHUEBAO_Search", para);
        }

        public NhatKyThueBao getNKTBBySoXe(params object[] para) {
            return getNhatKyThueBaoBySoHieuXe(para).ToList<NhatKyThueBao>().FirstOrDefault<NhatKyThueBao>();
        }

        public DataTable getNhatKyThueBao(params object[] para)
        {

            return ExeStore("sp_T_NHATKYTHUEBAO_SELECTBYID", para);
        }

        public NhatKyThueBao getNhatKyByID(params object[] para) {
            return getNhatKyThueBao(para).ToList<NhatKyThueBao>().FirstOrDefault<NhatKyThueBao>();
        }
    }
}
