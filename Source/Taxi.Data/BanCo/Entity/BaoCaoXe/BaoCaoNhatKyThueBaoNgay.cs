using Taxi.Data.BanCo.DbConnections;
using System.Data;
using System;
namespace Taxi.Data.BanCo.Entity.BaoCaoXe
{
    public class BaoCaoNhatKyThueBaoNgay : TaxiOperationDbEntityBase<BaoCaoNhatKyThueBaoNgay>
    {
        public DataTable GetDataReport(DateTime? date, string laixe)
        {
            return this.ExeStore("EnVang_Report_T_TAXIOPERATION_TRUCK_END_BaoCaoNhatKyThueBaoNgay_V2", date, laixe);
        }
    }
}
