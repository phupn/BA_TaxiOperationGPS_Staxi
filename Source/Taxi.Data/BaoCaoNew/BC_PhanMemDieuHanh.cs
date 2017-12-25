
using System;
using System.Data;
using Taxi.Utils;

namespace Taxi.Data.BaoCaoNew
{
    public class BC_PhanMemDieuHanh : DbEntityBase<BC_PhanMemDieuHanh>
    {
        public DataTable BC_1_6_BaoCaoTongCuocKhachThoat999(params object[] pInputs)//Lỗi kiểu dữ liệu DateTime
        {
            return this.ExeStore("[GROUP.BC_1_6_BaoCaoTongHopThoatCuoc999_V2]", pInputs);
        }

        public DataTable GROUP_BC_1_7_BaoCaoChiTietKhachThoat999(DateTime pTuNgay,DateTime pDenNgay,string pTruongCa,string pNVMK)
        {
            return this.ExeStore("[GROUP.BC_1_7_ChiTietCuocKhach999_V2]", pTuNgay, pDenNgay, pTruongCa, pNVMK);
        }
    }
}
