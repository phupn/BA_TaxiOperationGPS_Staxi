using Taxi.Data.BanCo.DbConnections;
using System.Data;
using Taxi.Data.BanCo.Entity.DieuXe;
namespace Taxi.Data.BanCo.Entity.GiamSatXe
{
    public class CuocGoiV2 : TaxiOperationDbEntityBase<CuocGoiV2>
    {
        public DataTable TONGDAI_LayCuocGoiDaGiaiQuyet(string vung, int start, int end, ThongTinTimKiem tttk)
        {
            return this.ExeStore("V3_TONGDAI_spT_TAXIOPERATION_KETTHUC_LayDSCuocKetThuc_v3", vung, start, end, tttk.DienThoai, tttk.DiaChi, tttk.DiaChiTra);
        }
    }
}
