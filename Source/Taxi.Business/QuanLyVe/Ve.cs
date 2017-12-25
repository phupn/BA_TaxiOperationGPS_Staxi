using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Taxi.Business.QuanLyVe
{
    public class Ve
    {
        #region Ve phat hanh
        //dbo].[VE.sp_T_VEPHATHANH_Insert]
        //    @NgayPhatHanh datetime,
        //    @SoHopDong int,
        //    @SeriDau int,
        //    @SeriCuoi int, 	 
        //    @FK_IDKhachHang int,
        //    @GhiChu nvarchar(50)
        public static bool InsertVePhatHanh(DateTime _NgayPhatHanh, int _SoHopDong, int _SeriDau, int _SeriCuoi,   int _FK_IDKhachHang, string _GhiChu)
        {
            return new Data.QuanLyVe.Ve().InsertVePhatHanh(_NgayPhatHanh, _SoHopDong, _SeriDau, _SeriCuoi, _FK_IDKhachHang, _GhiChu);
        }

        public static bool UpdateVePhatHanh(DateTime _NgayPhatHanh, int _SoHopDong, int _SeriDau, int _SeriCuoi,  int _FK_IDKhachHang, string _GhiChu)
        {
            return new Data.QuanLyVe.Ve().UpdateVePhatHanh(_NgayPhatHanh, _SoHopDong, _SeriDau, _SeriCuoi , _FK_IDKhachHang, _GhiChu);
        }

        public static bool   DeleteVePhatHanh(DateTime _NgayPhatHanh, int _SoHopDong,  int _FK_IDKhachHang )
        {
            return new Data.QuanLyVe.Ve().DeleteVePhatHanh(  _NgayPhatHanh,   _SoHopDong,    _FK_IDKhachHang );
        }
        /// <summary>
        /// lay tat ca ds ve phat hanh
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDSVePhatHanh()
        {
            return new Data.QuanLyVe.Ve().GetDSVePhatHanh(); 
        }

        public static DataTable GetVePhatHanh(DateTime _NgayPhatHanh, int _SoHopDong, int _FK_IDKhachHang)
        {
            return new Data.QuanLyVe.Ve().GetVePhatHanh(  _NgayPhatHanh,   _SoHopDong,   _FK_IDKhachHang);
        }
        public static DataTable GetVePhatHanhBySeri(int Seri)
        {
            return new Data.QuanLyVe.Ve().GetVePhatHanhBySeri(Seri);
        }
        #endregion Ve phat hanh

        #region Ve huy

        public static bool InsertVeHuy(DateTime _NgayHuy,int _SoHopDong, int _SeriDau, int _SeriCuoi, string _TenKhachhang, int _MaDonViVe, string _LyDoHuy, string _GhiChu,bool _TamNhap,string NguoiNhap)
        {
            return new Data.QuanLyVe.Ve().InsertVeHuy(_NgayHuy, _SoHopDong, _SeriDau, _SeriCuoi, _TenKhachhang, _MaDonViVe, _LyDoHuy, _GhiChu, _TamNhap, NguoiNhap); 
        }

        public static bool UpdateVeHuy(DateTime _NgayHuy, int _SoHopDong, int _SeriDau, int _SeriCuoi, int _FK_IDKhachHang, string _LyDoHuy, string _GhiChu)
        {
            return new Data.QuanLyVe.Ve().UpdateVeHuy(_NgayHuy, _SoHopDong, _SeriDau, _SeriCuoi, _FK_IDKhachHang, _LyDoHuy, _GhiChu); 
        }

        //[dbo].[VE.sp_T_VEHUY_Delete]
        //    @NgayHuy datetime,
        //    @SoHopDong int,
        //    @SeriDau int,	 
        //    @FK_IDKhachHang int
        public static bool DeleteVeHuy(DateTime _NgayHuy,int _SoHopDong, int _SeriDau, int _SeriCuoi, int _MaDonViVe)
        {
            return new Data.QuanLyVe.Ve().DeleteVeHuy(_NgayHuy,_SoHopDong, _SeriDau, _SeriCuoi, _MaDonViVe); 
        }

        //[VE.sp_T_VEHUY_SelectByID] 
        //    @NgayHuy datetime,
        //    @SoHopDong int,
        //    @SeriDau int,	 
        //    @FK_IDKhachHang int

        public static DataTable SelectVeHuyByID(DateTime _NgayHuy, int _SoHopDong, int _SeriDau, int _FK_IDKhachHang)
        {
            return new Data.QuanLyVe.Ve().SelectVeHuyByID(_NgayHuy, _SoHopDong, _SeriDau, _FK_IDKhachHang); 
        }

        public static DataTable SelectDSVeHuy()
        {
           return   new Data.QuanLyVe.Ve().SelectVeHuyAll( ); 
        }

        public static  DataTable GetVeHuyBySeri(int Seri)
        {
            return new Data.QuanLyVe.Ve().GetVeHuyBySeri(Seri); 
        }
         
        #endregion Ve huy



        #region VE DA SU DUNG
        public static DataTable GetDaSuDungBySeri(int Seri)
        {
            return new Data.QuanLyVe.Ve().GetDaSuDungBySeri(Seri);
        }
        public static DataTable GetDSVeSuDung()
        {
            return new Data.QuanLyVe.Ve().GetDSVeSuDung();
        }
        public static bool InsertVeSuDung(DateTime _NgaySuDung, int _SeriDau, string _SoHieuXe, int _SoTien,string _GhiChu)
        {
              return new Data.QuanLyVe.Ve().InsertVeSuDung(_NgaySuDung,   _SeriDau,   _SoHieuXe,_SoTien, _GhiChu);
        }
        public static bool UpdateVeSuDung(DateTime _NgaySuDung, int _SeriDau, string _SoHieuXe,int _SoTien, string _GhiChu)
        {
            return new Data.QuanLyVe.Ve().UpdateVeSuDung(_NgaySuDung, _SeriDau, _SoHieuXe,_SoTien, _GhiChu);
        }

        //[dbo].[VE.sp_T_VESUDUNG_Delete]
        //@NgaySuDung datetime,
        //@SeriDau int 

        public  static bool DeleteVeSuDung(DateTime _NgaySuDung, int _SeriDau)
        {
            return new Data.QuanLyVe.Ve().DeleteVeSuDung(_NgaySuDung, _SeriDau  );
        }
        #endregion VE DA SU DUNG
         

        public static DataTable  GetDSVeTheoHopDong(int SoHopDong, DateTime TuNgay, DateTime DenNgay)
        {
            return new Data.QuanLyVe.Ve().GetDSVeTheoHopDong(SoHopDong, TuNgay, DenNgay);
        }

        public static DataTable GetDSVeTheoHopDongDaSuDung(int SoHopDong, DateTime TuNgay, DateTime DenNgay)
        {
            return new Data.QuanLyVe.Ve().GetDSVeTheoHopDongDaSuDung(SoHopDong, TuNgay, DenNgay);
        }

        public static DataTable GetDSVeDaSuDungTheoNgay(DateTime TuNgay, DateTime DenNgay)
        {
            return new Data.QuanLyVe.Ve().GetDSVeDaSuDungTheoNgay(TuNgay, DenNgay);
        }

        public static DataTable TimKiemThongTinVe(int MaDonViVe, int  Seri, int Nam)
        {
            return new Data.QuanLyVe.Ve().TimKiemThongTinVe(MaDonViVe, Seri, Nam);
        }

        public static DataTable TimKiemThongTinSoHopDong(int MaDonVi, int SoHopDong,int Nam)
        {
            return new Data.QuanLyVe.Ve().TimKiemThongTinSoHopDong(MaDonVi, SoHopDong,Nam);
        }

        /// <summary>
        /// hàm trả về thông tin vé hủy
        ///     Nếu có hợp đồng thì tìm theo hợp đồng
        ///     Nếu có CôngtyID thì tìm theo công ty id
        ///     Nếu có SeriVé thì tìm theo seri vé
        /// </summary>
        /// <param name="NgayHuyTuNgay"></param>
        /// <param name="NgayHuyDenNgay"></param>
        /// <param name="HopDong"></param>
        /// <param name="CongTyID"></param>
        /// <param name="SeriVe"></param>
        /// <returns></returns>
        public static DataTable GetBCVe(DateTime NgayHuyTuNgay, DateTime NgayHuyDenNgay, int HopDong, int CongTyID, int SeriVe, string tenKhachHang, bool quyDinhHanMuc, bool isHopDongHuy)
        {
            return new Data.QuanLyVe.Ve().GetBCVe(NgayHuyTuNgay, NgayHuyDenNgay, HopDong, CongTyID, SeriVe,tenKhachHang, quyDinhHanMuc, isHopDongHuy );
        }
    }
}
