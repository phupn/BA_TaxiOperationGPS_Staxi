#region ============= Copyright © 2016 BinhAnh =============
using System;
using System.Collections.Generic;
using Taxi.Utils;
using Taxi.Common.Extender;
#endregion ============= Copyright © 2016 BinhAnh =============

namespace Taxi.Data.G5.BaoCao
{
    public class bc_6_6_BaoCaoTongHopCuocMoiGioiTheoXe : DbEntityBase<bc_6_6_BaoCaoTongHopCuocMoiGioiTheoXe>
    {
        private const string sp_bc_6_6_BaoCaoTongHopCuocMoiGioiTheoXe = "sp_bc_6_6_BaoCaoTongHopCuocMoiGioiTheoXe";

        #region === Field ===
        public string XeDon { get; set; }
        public string SoXe { get; set; }
        public string MaDoiTac { get; set; }
        public string DiaChiDonKhach { get; set; }
        public DateTime ThoiDiemGoi { get; set; }
        public int CuocSanBay { get; set; }
        public int CuocThuong { get; set; }
        public string LenhDienThoai { get; set; }
        public string GhiChuDienThoai { get; set; }
        public string LenhTongDai { get; set; }
        public string MOIKHACH_LenhMoiKhach { get; set; }
        public string XeNhan { get; set; }
        public string XeDenDiem { get; set; }
        public string TenLoaiDoiTac { get; set; }
        public int CuocHoaHong { get { return CuocSanBay + CuocThuong; } }

        #endregion

        public static List<bc_6_6_BaoCaoTongHopCuocMoiGioiTheoXe> GetReport(DateTime TuNgay, DateTime DenNgay,string MaDoiTac, string SoXe, int LoaiDoiTacId, int CongTyId)
        {
            return Inst.ExeStore(sp_bc_6_6_BaoCaoTongHopCuocMoiGioiTheoXe, TuNgay, DenNgay,MaDoiTac,SoXe, LoaiDoiTacId, CongTyId).ToList<bc_6_6_BaoCaoTongHopCuocMoiGioiTheoXe>();
        }
    }
}
