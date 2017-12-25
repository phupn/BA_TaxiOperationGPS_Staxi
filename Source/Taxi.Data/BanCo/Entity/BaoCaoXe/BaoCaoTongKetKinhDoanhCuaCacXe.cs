using Taxi.Data.BanCo.DbConnections;
using System.Data;
using System;

namespace Taxi.Data.BanCo.Entity.BaoCaoXe
{
    public class BaoCaoTongKetKinhDoanhCuaCacXe : TaxiOperationDbEntityBase<BaoCaoTongKetKinhDoanhCuaCacXe>
    {
        public DataTable GetDataReport(DateTime? from, DateTime? to, string SoHieuXe)
        {
            return this.ExeStore("EnVang_Report_T_TAXIOPERATION_TRUCK_END_BaoCaoTongKetKinhDoanhCuaCacXe", from, to, SoHieuXe);
        }
    }
}
