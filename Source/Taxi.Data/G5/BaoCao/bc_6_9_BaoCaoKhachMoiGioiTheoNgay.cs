#region ============= Copyright © 2016 BinhAnh =============
using System;
using System.Collections.Generic;
using Taxi.Utils;
using Taxi.Common.Extender;
#endregion ============= Copyright © 2016 BinhAnh =============


namespace Taxi.Data.G5.BaoCao
{
    public class bc_6_9_BaoCaoKhachMoiGioiTheoNgay : DbEntityBase<bc_6_9_BaoCaoKhachMoiGioiTheoNgay>
    {
        private const string sp_bc_6_9_BaoCaoKhachMoiGioiTheoNgay = "sp_bc_6_9_BaoCaoKhachMoiGioiTheoNgay";

        #region===Field===

        #endregion
        public static List<bc_6_9_BaoCaoKhachMoiGioiTheoNgay> GetReport(DateTime TuNgay, DateTime DenNgay, int LoaiDoiTacId, int CongTyId)
        {
            return Inst.ExeStore(sp_bc_6_9_BaoCaoKhachMoiGioiTheoNgay, TuNgay, DenNgay, LoaiDoiTacId, CongTyId).ToList<bc_6_9_BaoCaoKhachMoiGioiTheoNgay>();
        }
    }
}
