using Taxi.Data.BanCo.DbConnections;
using System.Data;
using System;
using Taxi.Common.Extender;
using System.Linq;
namespace Taxi.Data.BanCo.Entity.BaoCaoXe
{
    public class BaoCaoSoNgayXeDiKinhDoanh : TaxiOperationDbEntityBase<BaoCaoSoNgayXeDiKinhDoanh>
    {
        public DataTable GetDataInRangeDate(DateTime? from, DateTime? to, string laixe)
        {
            return this.ExeStore("EnVang_Report_BanCo_GiamSatXe_HoatDong_BaoCaoSoNgayXeDiKinhDoanh", from, to, laixe);
        }

        public DataTable GetDataInRangeDate_V2(DateTime? from, DateTime? to, string laixe)
        {
            return this.ExeStore("EnVang_Report_BanCo_GiamSatXe_HoatDong_BaoCaoSoNgayXeDiKinhDoanh_V2", from, to, laixe);
        }

        public DataTable GetDataReport(DateTime? from, DateTime? to, string laixe)
        {
            var table = GetDataInRangeDate(from, to, laixe);

            table.Columns.Add("SoNgayKinhDoanh", typeof(int));
            table.Columns.Add("SoNgayTrucDem", typeof(int));
            table.Columns.Add("GhiChu");

            var data = table.AsEnumerable().GroupBy(dr => dr["TenNhanVien"].ToString()).Select(gr =>
            {
                var dr = gr.First();

                //dr["SoNgayKinhDoanh"] = gr.Count(gri => gri["TrangThaiLaiXeBao"].To<int>() == 0 || gri["TrangThaiLaiXeBao"].To<int>() == 1);
                dr["SoNgayKinhDoanh"] = gr.Count(gri => gri["TenNhanVien"] != DBNull.Value);
                dr["SoNgayTrucDem"] = gr.Count(gri => gri["IsTrucDem"].To<bool>());

                return dr;
            }).ToList();

            return data.Count != 0 ? data.CopyToDataTable() : null;
        }
    }
}
