#region ============= Copyright © 2016 BinhAnh =============
using System;
using System.Collections.Generic;
using Taxi.Utils;
using Taxi.Common.Extender;
#endregion ============= Copyright © 2016 BinhAnh =============

namespace Taxi.Data.G5.BaoCao
{
    public class bc_6_2_DiaChiMoiGioiCuocGoiThap : DbEntityBase<bc_6_2_DiaChiMoiGioiCuocGoiThap>
    {
        private const string sp_bc_6_2_DiaChiMoiGioiCuocGoiThap = "sp_bc_6_2_DiaChiMoiGioiCuocGoiThap";
        private const string sp_bc_6_2_DiaChiMoiGioiCuocGoiThap_V2 = "sp_bc_6_2_DiaChiMoiGioiCuocGoiThap_V2";

        #region === Properties ===
        public string Ma_DoiTac { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phones { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public float TiLeHoaHongNoiTinh { get; set; }
        public float TiLeHoaHongNgoaiTinh { get; set; }
        public string Notes { get; set; }
        public bool IsActive { get; set; }
        public string FK_MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public int Vung { get; set; }
        public DateTime NgayKyKet { get; set; }
        public string FK_CongTyID { get; set; }
        public string TenCongTy { get; set; }
        public string SoNha { get; set; }
        public string TenDuong { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public float KinhDo { get; set; }
        public float ViDo { get; set; }
        public string viettat { get; set; }
        public int LoaiDoiTacID { get; set; }
        public string TenLoaiDoiTac { get; set; }
        public string IdCapNhat
        {
            get
            {
                return string.IsNullOrEmpty(UpdatedBy) ? CreatedBy : UpdatedBy;
            }
        }
        public int SoCuocGoi { get; set; }
        public int DonDuocKhach { get; set; }
        public int CuocSanBay { get; set; }
        public int CuocThuong { get; set; }
        public int DuongDai { get; set; }
        public float PhiHoaHong { get; set; }
        #endregion

        public static List<bc_6_2_DiaChiMoiGioiCuocGoiThap> GetReport(DateTime TuNgay, DateTime DenNgay, string MaDoiTac, int SoLuong, int LoaiDoiTacId, int CongTyId)
        {
            return Inst.ExeStore(sp_bc_6_2_DiaChiMoiGioiCuocGoiThap, TuNgay, DenNgay, MaDoiTac, SoLuong, LoaiDoiTacId, CongTyId).ToList<bc_6_2_DiaChiMoiGioiCuocGoiThap>();
        }
        public static List<bc_6_2_DiaChiMoiGioiCuocGoiThap> GetReport_V2(DateTime TuNgay, DateTime DenNgay, string MaDoiTac, int SoCuoc, string MaNhanVien, string TenDoiTac, string DiaChi, string SoDienThoai)
        {
            return Inst.ExeStore(sp_bc_6_2_DiaChiMoiGioiCuocGoiThap_V2, TuNgay, DenNgay, MaDoiTac, SoCuoc, MaNhanVien, TenDoiTac, DiaChi, SoDienThoai).ToList<bc_6_2_DiaChiMoiGioiCuocGoiThap>();
        }
    }
}
