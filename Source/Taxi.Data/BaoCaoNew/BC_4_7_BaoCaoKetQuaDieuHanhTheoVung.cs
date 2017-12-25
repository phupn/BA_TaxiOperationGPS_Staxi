using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Utils;
using Taxi.Common.Extender;
namespace Taxi.Data.BaoCaoNew
{
    public class BC_4_7_BaoCaoKetQuaDieuHanhTheoVung : DbEntityBase<BC_4_7_BaoCaoKetQuaDieuHanhTheoVung>
    {
        private const string sp = "sp_BC_4_7_BaoCaoKetQuaDieuHanhTheoVung";
        public static object GetReport(DateTime fromDate, DateTime toDate, int vung)
        {
            return Inst.ExeStore(sp, fromDate, toDate, vung);
        }
        public long VungId { get; set; }
        public string Vung { get; set; }
        public DateTime? Ngay { get; set; }
        private string NgayStr { get { if (Ngay == null) return "Tổng hợp"; return Ngay.Value.ToString("dd/MM/yyyy"); } }
        public long Taxi_Tong { get; set; }
        public long Taxi_MG { get; set; }
        public long Taxi_VL { get; set; }
        public long DonDuoc_Tong { get; set; }
        public long DonDuoc_MG { get; set; }
        public long DonDuoc_VL { get; set; }
        public long KhongDonDuoc_Tong { get; set; }
        public long KhongDonDuoc_TruotHoan { get; set; }
        public long KhongDonDuoc_TruotHoan5Phut { get; set; }
        public long KhongDonDuoc_Khongxe { get; set; }
        public long KhongDonDuoc_Khac { get; set; }
        public float PhanTramdonDuoc { get; set; }
        public long CuocGoiLai_Cuoc { get; set; }
        public float CuocGoiLai_PhanTramGoiLai { get; set; }
        public float TyTrongVungNgay { get; set; }
        public float GPS_ViDo { get; set; }
        public float GPS_KinhDo { get; set; }
        public List<BC_4_7_BaoCaoKetQuaDieuHanhTheoVung> GetData(DateTime? fromDate, DateTime? toDate, long vung)
        {
            return ExeStore("sp_BC_4_7_BaoCaoKetQuaDieuHanhTheoVung", fromDate, toDate, vung).ToList<BC_4_7_BaoCaoKetQuaDieuHanhTheoVung>();
        }
    }
}
