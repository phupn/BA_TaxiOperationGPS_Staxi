using Taxi.Data.BanCo.DbConnections;
using System.Data;
using System;
namespace Taxi.Data.BanCo.Entity.BaoCaoXe
{
    /// <summary>
    /// 
    /// </summary>
    public class BaoCaoTongKetKinhDoanhCuaLaiXeTheoNgayVaThang : TaxiOperationDbEntityBase<BaoCaoTongKetKinhDoanhCuaLaiXeTheoNgayVaThang>
    {
        public DataTable GetDataReport(DateTime? from, DateTime? to, string laixe)
        {
            return this.ExeStore("EnVang_Report_T_TAXIOPERATION_TRUCK_END_BaoCaoTongKetKinhDoanhCuaLaiXeTheoNgayVaThang", from, to, laixe);
        }
    }
}
