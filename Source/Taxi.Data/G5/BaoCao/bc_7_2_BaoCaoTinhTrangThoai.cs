#region ============= Copyright © 2016 BinhAnh =============
using System;
using System.Collections.Generic;
using Taxi.Utils;
using Taxi.Common.Extender;
#endregion ============= Copyright © 2016 BinhAnh =============
namespace Taxi.Data.G5.BaoCao
{
    public class bc_7_2_BaoCaoTinhTrangThoai : DbEntityBase<bc_7_2_BaoCaoTinhTrangThoai>
    {
        #region === Field ===
        public string ViTri { get; set; }
        public string TenNV { get; set; }
        public DateTime ThoiDiemDangNhap { get; set; }
        public int ThoiGianDangNhap { get; set; }
        public int DaCoXeNhan { get; set; }
        public int ChuaCoXeNhan { get; set; }
        public int ChuaChuyenDam { get; set; }
        public int Tong { get; set; }
        public int DieuG5 { get; set; }
        #endregion

        public static List<bc_7_2_BaoCaoTinhTrangThoai> GetReport()
        {
            return Inst.ExeStore("sp_bc_7_2_BaoCaoTinhTrangThoai").ToList<bc_7_2_BaoCaoTinhTrangThoai>();
        }
    }
}
