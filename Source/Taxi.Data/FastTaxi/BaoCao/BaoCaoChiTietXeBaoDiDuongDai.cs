using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Controls.Base.BaoCao;
using Taxi.Utils;
using Taxi.Common.Extender;

namespace Taxi.Data.FastTaxi.BaoCao
{
    public class BaoCaoChiTietXeBaoDiDuongDai : DbEntityBase<BaoCaoChiTietXeBaoDiDuongDai>, IReportData
    {
        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }
        public string SoXe { get; set; }
        public DateTime? ThoiDiemDi { get; set; }
        public string DiaChiTra { get; set; }
        public int TrangThai { get; set; }
        public int TrangThaiDuyet { get; set; }
        public bool IsDaGui { get; set; }
        public bool IsKetThuc { get; set; }

        public DateTime ThoiGianDi { get; set; }
        public string SoDienThoai { get; set; }
        public string TenLaiXe { get; set; }
        public string DiaChiDon { get; set; }
        public int Chieu { get; set; }
        public float KmDuKien { get; set; }
        public DateTime TGDuKien { get; set; }
        public decimal TienDuKien { get; set; }
        public DateTime? GioTra { get; set; }
        public float CoDau { get; set; }
        public float CoCuoi { get; set; }
        
        public object GetData()
        {
            return this.ExeStore("sp_BaoCao_ChiTietXeBaoDiDuongDai").ToList<BaoCaoChiTietXeBaoDiDuongDai>();
        }
    }
}
