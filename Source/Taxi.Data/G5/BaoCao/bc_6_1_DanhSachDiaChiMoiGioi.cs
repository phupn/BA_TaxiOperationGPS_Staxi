#region ============= Copyright © 2016 BinhAnh =============
using System;
using System.Collections.Generic;
using Taxi.Utils;
using Taxi.Common.Extender;
#endregion ============= Copyright © 2016 BinhAnh =============

namespace Taxi.Data.G5.BaoCao
{
    public class bc_6_1_DanhSachDiaChiMoiGioi : DbEntityBase<bc_6_1_DanhSachDiaChiMoiGioi>
    {        
        private const string sp_bc_6_1_DanhSachDiaChiMoiGioi_V2 = "sp_bc_6_1_DanhSachDiaChiMoiGioi_V2";
     
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
        public string NgayKetThuc_Dis { get; set; }
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
        #endregion

        public static List<bc_6_1_DanhSachDiaChiMoiGioi> GetReport_V2(DateTime? TuNgay, DateTime? DenNgay, string MaDoiTac,string TenDoiTac, string DiaChi, string SoDienThoai, string MaNhanVien, int MucMG, string Vung, int TrangThaiHopDong)
        {
            return Inst.ExeStore(sp_bc_6_1_DanhSachDiaChiMoiGioi_V2, TuNgay, DenNgay, MaDoiTac,TenDoiTac,DiaChi,SoDienThoai, MaNhanVien, MucMG, Vung, TrangThaiHopDong).ToList<bc_6_1_DanhSachDiaChiMoiGioi>();
        }
    }
}
