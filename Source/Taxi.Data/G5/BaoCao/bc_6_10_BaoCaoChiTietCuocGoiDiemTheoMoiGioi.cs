#region ============= Copyright © 2016 BinhAnh =============
using System;
using System.Collections.Generic;
using Taxi.Utils;
using Taxi.Common.Extender;
#endregion ============= Copyright © 2016 BinhAnh =============


namespace Taxi.Data.G5.BaoCao
{
    public class bc_6_10_BaoCaoChiTietCuocGoiDiemTheoMoiGioi : DbEntityBase<bc_6_10_BaoCaoChiTietCuocGoiDiemTheoMoiGioi>
    {
        private const string sp_bc_6_10_BaoCaoChiTietCuocGoiDiemTheoMoiGioi = "sp_bc_6_10_BaoCaoChiTietCuocGoiDiemTheoMoiGioi";
        private const string sp_bc_6_10_BaoCaoChiTietCuocGoiDiemTheoMoiGioi_V2 = "sp_bc_6_10_BaoCaoChiTietCuocGoiDiemTheoMoiGioi_V2";

        #region===Field===
        public string  MaDoiTac { get; set; }
        public DateTime ThoiDiemGoi { get; set; }
        public string PhoneNumber { get; set; }
        public string DiaChiDonKhach { get; set; }
        public KieuCuocGoi KieuCuocGoi { get; set; }
        public TrangThaiCuocGoiTaxi TrangThaiCuocGoi { get; set; }
        public int SoLuong { get; set; }
        public string TenCongTy { get; set; }
        public string TenDoiTac { get; set; }
        public string XeNhan { get; set; }
        public string XeDenDiem { get; set; }
        public string XeDon { get; set; }
        public DateTime ThoiDiemThayDoiDuLieu { get; set; }
         
        private int _donDuoc;
        public int DonDuoc
        {
            get { return string.IsNullOrEmpty(XeDon)? 0:XeDon.Split('.').Length; }
            set { _donDuoc = value; }
        }
        #endregion
        public static List<bc_6_10_BaoCaoChiTietCuocGoiDiemTheoMoiGioi> GetReport(DateTime TuNgay, DateTime DenNgay,string MaDoiTac, int LoaiDoiTacId, int CongTyId)
        {
            return Inst.ExeStore(sp_bc_6_10_BaoCaoChiTietCuocGoiDiemTheoMoiGioi, TuNgay, DenNgay,MaDoiTac, LoaiDoiTacId, CongTyId).ToList<bc_6_10_BaoCaoChiTietCuocGoiDiemTheoMoiGioi>();
        }

        public static List<bc_6_10_BaoCaoChiTietCuocGoiDiemTheoMoiGioi> GetReport_V2(DateTime TuNgay, DateTime DenNgay, string MaDoiTac, string SoDT, string XeDon,string TenDoiTac, string DiaChi, int TrangThaiDon)
        {
            return Inst.ExeStore(sp_bc_6_10_BaoCaoChiTietCuocGoiDiemTheoMoiGioi_V2, TuNgay, DenNgay, MaDoiTac, SoDT, XeDon,TenDoiTac, DiaChi, TrangThaiDon).ToList<bc_6_10_BaoCaoChiTietCuocGoiDiemTheoMoiGioi>();
        }
    }
}
