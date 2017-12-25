#region ============= Copyright © 2016 BinhAnh =============
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using Taxi.Utils;
using Taxi.Common.Extender;
#endregion ============= Copyright © 2016 BinhAnh =============


namespace Taxi.Data.G5.BaoCao
{
    public class bc_1_8_BaoCaoChiTietKhachDat : DbEntityBase<bc_1_8_BaoCaoChiTietKhachDat>
    {
        private const string sp_bc_1_8_BaoCaoChiTietKhachDat = "sp_bc_1_8_BaoCaoChiTietKhachDat";

        #region === Field ===
        public DateTime  ThoiDiemTiepNhan { get; set; }
        public DateTime ThoiGianDonKhach { get; set; }
        public DateTime? ThoiDiemChenCuoc { get; set; }
        public DateTime ThoiDiemBatDau { get; set; }
        public DateTime ThoiDiemKetThuc { get; set; }
        public DateTime  GioDon { get; set; }
        public string PhoneNumber { get; set; }
        public string DiaChiDonKhach { get; set; }
        public string XeNhan { get; set; }
        public string XeDenDiem { get; set; }
        public string XeDon { get; set; }
        public string LenhDienThoai { get; set; }
        public string LenhTongDai { get; set; }
        public string LenhMoiKhach { get; set; }
        public bool DonDuoc { get; set; }
        public bool TruotHoan { get; set; }
        public bool KhongXe { get; set; }
        public bool Khac { get; set; }
        public string TiepNhanKhachDat { get; set; }
        public string MaNhanVienTongDai { get; set; }
        public string MaNhanVienDienThoai { get; set; }
        public string MaNhanVienMoiKhach { get; set; }
        
        #endregion

        public static List<bc_1_8_BaoCaoChiTietKhachDat> GetReport(DateTime TuNgay, DateTime DenNgay, string MaDoiTac, DateTime? ThoiGianDon, bool IsSanBay, bool CuocChuaPhucVu)
        {
            DataTable dtAll = new DataTable();
            int countLoop = (DenNgay - TuNgay).TotalDays.To<int>();
            for (int i = 1; i <= countLoop + 1; i++)
            {
                if (TuNgay.AddDays(1)<DenNgay)
                    dtAll.Merge(Inst.ExeStore(sp_bc_1_8_BaoCaoChiTietKhachDat, TuNgay, TuNgay.AddDays(1), MaDoiTac, ThoiGianDon, IsSanBay, CuocChuaPhucVu));
                else
                    dtAll.Merge(Inst.ExeStore(sp_bc_1_8_BaoCaoChiTietKhachDat, TuNgay, DenNgay, MaDoiTac, ThoiGianDon, IsSanBay, CuocChuaPhucVu));
                TuNgay = TuNgay.AddDays(1);
                Thread.Sleep(100);
            }
            return dtAll.ToList<bc_1_8_BaoCaoChiTietKhachDat>();
            //return Inst.ExeStore(sp_bc_1_8_BaoCaoChiTietKhachDat, TuNgay, DenNgay, MaDoiTac, ThoiGianDon, IsSanBay, CuocChuaPhucVu).ToList<bc_1_8_BaoCaoChiTietKhachDat>();
        }
    }
}
