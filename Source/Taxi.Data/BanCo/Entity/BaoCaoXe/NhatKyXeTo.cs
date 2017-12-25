using Taxi.Data.BanCo.DbConnections;
using System.Data;
using System;
namespace Taxi.Data.BanCo.Entity.BaoCaoXe
{
    public class NhatKyXeTo : TaxiOperationDbEntityBase<NhatKyXeTo>
    {
        public DataTable GetDataReport(DateTime? to, string SoXe)
        {
            return this.ExeStore("EnVang_Report_T_TAXIOPERATION_TRUCK_END_NhatKyXeTo", to, SoXe);
        }
    }
}
