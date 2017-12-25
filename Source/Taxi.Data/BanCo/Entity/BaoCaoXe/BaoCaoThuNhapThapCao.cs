using Taxi.Data.BanCo.DbConnections;
using System.Data;
using System;
using System.Linq;
using Taxi.Utils.Enums;
using Taxi.Common.Extender;
namespace Taxi.Data.BanCo.Entity.BaoCaoXe
{
    public class BaoCaoThuNhapThapCao : TaxiOperationDbEntityBase<BaoCaoThuNhapThapCao>
    {
        public DataTable GetDataReport(int top, EmployeeInComeType eit, DateTime? from, DateTime? to)
        {
            var table = this.ExeStore("EnVang_Report_T_TAXIOPERATION_TRUCK_END_BaoCaoThuNhapThapCao", top, eit, from, to);
            var data = table.AsEnumerable().GroupBy(dr => dr["MaLaiXe"].ToString()).Select(gr =>
            {
                var dr = gr.First();
                dr["SoXe"] = string.Join(",", gr.Select(gri => gri["SoXe"]).ToArray());
                dr["TongCuoc"] = gr.Sum(gri => gri["TongCuoc"].To<int>());
                dr["TongTien"] = gr.Sum(gri => gri["TongTien"].To<decimal>());
                return dr;
            }).ToList();
            return data.Count != 0 ? data.CopyToDataTable() : null;
        }
    }
}
