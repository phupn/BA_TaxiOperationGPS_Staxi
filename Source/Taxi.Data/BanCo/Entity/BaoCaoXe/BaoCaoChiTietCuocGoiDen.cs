using Taxi.Data.BanCo.DbConnections;
using System.Data;
using System;
using System.Linq;
using Taxi.Common.Extender;
using Taxi.Data.BanCo.Entity.GiamSatXe;
namespace Taxi.Data.BanCo.Entity.BaoCaoXe
{
    public class BaoCaoChiTietCuocGoiDen : TaxiOperationDbEntityBase<BaoCaoChiTietCuocGoiDen>
    {
        public DataTable GetDataReport(DateTime? from, DateTime? to, string soxe)
        {
            var config = BanCo_Config.Inst.GetListAll().First(c => c.Id == Taxi.Utils.Enum_Config_Alert.SDTBoPhanBocXep);

            var table = this.ExeStore("EnVang_Report_T_TAXIOPERATION_TRUCK_END_BaoCaoChiTietCuocGoiDen", from, to, soxe);

            table.Columns.Add("TongCuoc");
            table.Columns.Add("ThanhCong");
            table.Columns.Add("Truot");
            table.Columns.Add("Hoan");
            table.Columns.Add("KhongXe");
            table.Columns.Add("GoiLai");
            table.Columns.Add("HoiGia");
            table.Columns.Add("BocXepKhachGoi");
            table.Columns.Add("SDTBocXep");
            table.Columns.Add("XinLoi");
            table.Columns.Add("KhieuNai");
            table.Columns.Add("GhiChu");

            var data = table.AsEnumerable().GroupBy(dr => dr["MaLaiXe"].ToString()).Select(gr =>
            {
                var dr = gr.First();

                var tongcuoc = 0;
                var thanhcong = 0;
                var truot = 0;
                var hoan = 0;
                var khongxe = 0;
                var goilai = 0;
                var hoigia = 0;
                var bocxepkhachgoi = 0;
                var sdtbocxep = 0;
                var xinloi = 0;
                var khieunai = 0;
                foreach (var gri in gr)
                {
                    var kch = gri["KieuCuocGoi"].To<int>();
                    var kq = gri["KetQua"].To<int>();

                    if (kq != 2 && kq != 3 && kq != 4 && kch == 1) thanhcong++;
                    if (kq == 2 && kch == 1) truot++;
                    if (kq == 3 && kch == 1) hoan++;
                    if (kq == 4 && kch == 1) khongxe++;
                    if (kch == 3) goilai++;
                    if (kch == 4) hoigia++;
                    if (kch == 5) bocxepkhachgoi++;
                    if (kch == 2) xinloi++;
                    if (kch == 6) khieunai++;

                    if (config != null && config.Value == gri["SoDT"].ToString()) sdtbocxep++;
                }

                tongcuoc = thanhcong + truot + hoan + khongxe;

                dr["TongCuoc"] = tongcuoc;
                dr["ThanhCong"] = thanhcong;
                dr["Truot"] = truot;
                dr["Hoan"] = hoan;
                dr["KhongXe"] = khongxe;
                dr["GoiLai"] = goilai;
                dr["HoiGia"] = hoigia;
                dr["BocXepKhachGoi"] = bocxepkhachgoi;
                dr["SDTBocXep"] = sdtbocxep;
                dr["XinLoi"] = xinloi;
                dr["KhieuNai"] = khieunai;

                return dr;
            }).ToList();

            return data.Count != 0 ? data.CopyToDataTable() : null;
        }
    }
}
