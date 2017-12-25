using System;
using System.Data;
using System.Threading;
using Taxi.Common.Extender;
using Taxi.Utils;

namespace Taxi.Data.G5.BaoCao
{
    public class bc_1_3_BaoCaoChiTietCuocGoiDen : DbEntityBase<bc_1_3_BaoCaoChiTietCuocGoiDen> 
    {
        private const string spReport = "sp_bc_1_3_BaoCaoChiTietCuocGoiDen";
        private const string sp_bc_1_3_BaoCaoChiTietCuocGoiDen_DeleteCuocGoi = "sp_bc_1_3_BaoCaoChiTietCuocGoiDen_DeleteCuocGoi";
        /// <summary>
        /// Báo cáo Tổng hợp cuốc khách điều hành
        /// </summary>
        /// <returns>Danh sách thông tin về cuốc khách điều hành</returns>
        public static DataTable GetReport(DateTime start, DateTime end, string KieuCuocGoi, string SoDienThoai, string DiaChi, string ID_DTTD, string ID_CS, string Line, string Vung, string NhacMaySau, string XeNhan, string XeDon, TimeSpan TGDamThoai, TimeSpan TGChuyenDam, int KetQua, int CachDieu, int LoaiKH, string Xe, string LenhKhachDat, string MaDoiTac, bool CuocChen=false)
        {

            DataTable dtAll = new DataTable();
            try
            {
                int countLoop = (end - start).TotalDays.To<int>();
                for (int i = 1; i <= countLoop + 1; i++)
                {
                    if (start.AddDays(1) < end)
                        dtAll.Merge(Inst.ExeStore(spReport, start, start.AddDays(1), KieuCuocGoi, SoDienThoai, DiaChi, ID_DTTD, ID_CS, Line, Vung, NhacMaySau, XeNhan, XeDon, TGDamThoai, TGChuyenDam, KetQua, CachDieu, LoaiKH, Xe, LenhKhachDat, MaDoiTac, CuocChen));
                    else
                        dtAll.Merge(Inst.ExeStore(spReport, start, end, KieuCuocGoi, SoDienThoai, DiaChi, ID_DTTD, ID_CS, Line, Vung, NhacMaySau, XeNhan, XeDon, TGDamThoai, TGChuyenDam, KetQua, CachDieu, LoaiKH, Xe, LenhKhachDat, MaDoiTac, CuocChen));
                    start = start.AddDays(1);
                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                LogErrorUtils.WriteLogError("GetReport "+dtAll.Rows.Count,ex);                
            }

            return dtAll;

            //return Inst.ExeStore(spReport, start, end, KieuCuocGoi, SoDienThoai, DiaChi, ID_DTTD, ID_CS, Line, Vung, NhacMaySau, XeNhan, XeDon, TGDamThoai, TGChuyenDam, KetQua, CachDieu, LoaiKH, Xe, LenhKhachDat, MaDoiTac,CuocChen);
        }

        public static DataTable GetReportLongTrip(params  object[] inputs)
        {
            return Inst.ExeStore("sp_bc_1_3_BaoCaoChiTietCuocGoiDen_DuongDai", inputs);
        }
        public static bool DeleteMultilCuocGoi(string id)
        {
            if (Inst.ExeStoreNoneQuery(sp_bc_1_3_BaoCaoChiTietCuocGoiDen_DeleteCuocGoi,id)>0)
            {
                return true;
            }
            return false;
        }


        public bool KiemTraLaCuocSanh(string maMoiGioi)
        {
            try
            {
                DataTable dt = ExeStore("sp_KiemTraLaCuocSanh", maMoiGioi);
                if (dt.Rows.Count > 0)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        public void CapNhatGhiChu(string pText,string pID)
        {
            ExeStore("sp_CapNhatGhiChu", pText,long.Parse(pID));
        }      
    }
}
