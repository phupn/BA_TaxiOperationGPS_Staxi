using System;
using System.Collections.Generic;
using Taxi.Utils;
using Taxi.Common.Extender;
namespace Taxi.Data.G5
{
    public class bc_4_8_BaoCaoTongHoCuocGoiDiTheoNhanVien : DbEntityBase<bc_4_8_BaoCaoTongHoCuocGoiDiTheoNhanVien>
    {
        public DateTime Ngay { get; set; }
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public int MoiKhach { get; set; }
        public int Tong { get; set; }
        public int Khac { get; set; }
        public int CuocGoiTaxi { get; set; }
        public static List<bc_4_8_BaoCaoTongHoCuocGoiDiTheoNhanVien> GetReport(DateTime tuNgay, DateTime denNgay, string maNhanVien)
        {
            return Inst.ExeStore("BC_4_8_TongHopCuocGoiDiTheoNhanVien", tuNgay, denNgay, maNhanVien).ToList<bc_4_8_BaoCaoTongHoCuocGoiDiTheoNhanVien>();
        }
    }
}
