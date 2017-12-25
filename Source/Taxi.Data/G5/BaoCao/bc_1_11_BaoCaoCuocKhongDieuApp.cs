#region ============= Copyright © 2016 BinhAnh =============
using System;
using System.Collections.Generic;
using Taxi.Utils;
using Taxi.Common.Extender;
#endregion ============= Copyright © 2016 BinhAnh =============


namespace Taxi.Data.G5.BaoCao
{
    public class bc_1_11_BaoCaoCuocKhongDieuApp : DbEntityBase<bc_1_11_BaoCaoCuocKhongDieuApp>
    {
        private const string sp_bc_1_11_BaoCaoCuocKhongDieuApp = "sp_bc_1_11_BaoCaoCuocKhongDieuApp";
        private const string sp_bc_1_11_BaoCaoCuocKhongDieuApp_UpdateToaDo = "sp_bc_1_11_BaoCaoCuocKhongDieuApp_UpdateToaDo";

        #region === Field ===
        public int ID { get; set; }
        public string Line { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime ThoiDiemGoi { get; set; }
        public string DiaChiDonKhach { get; set; }
        public float GPS_KinhDo { get; set; }
        public float GPS_ViDo { get; set; }
        public string MaNhanVienDienThoai { get; set; }
        public bool BaXacNhan { get; set; }
        public string CachLay { get; set; }
        public string MoTa { get; set; }

        #endregion

        public static List<bc_1_11_BaoCaoCuocKhongDieuApp> GetReport(DateTime TuNgay, DateTime DenNgay,string pSoDienThoai)
        {
            return Inst.ExeStore(sp_bc_1_11_BaoCaoCuocKhongDieuApp, TuNgay, DenNgay,pSoDienThoai).ToList<bc_1_11_BaoCaoCuocKhongDieuApp>();
        }
    }
}
