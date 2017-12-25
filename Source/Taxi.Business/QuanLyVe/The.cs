using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Taxi.Business.QuanLyVe
{
   public  class The
    {
        /// <summary>
        /// hamf tra ve ds ve cua mot don vi
        /// </summary>
        /// <param name="MaDonViVe"></param>
        /// <returns></returns>
       public static DataTable GetDSThe(int MaDonViVe)
       {
           return new Data.QuanLyVe.The().GetDSThe(MaDonViVe);

       }
       public static DataTable GetDSThe( )
       {
           return new Data.QuanLyVe.The().GetDSThe();
       }
        /// <summary>
        /// ham tra ve chi tiet thong tin cua ve
        /// </summary>
        /// <param name="MaThe"></param>
        /// <param name="MaDonViVe"></param>
        /// <returns></returns>
       public static DataTable GetChiTietThe(string MaThe, int MaDonViVe,int Nam)
        {
            return new Data.QuanLyVe.The().GetChiTietThe(MaThe, MaDonViVe,Nam);
        }

        /// <summary>
        /// [VE.sp_T_THE_Insert]	
        //@MaSoThe varchar(10),
        //@NgayHuy datetime, 
        //@TenCongTy nvarchar(50),
        //@GhiChu nvarchar(50),@MaDonViVe varchar(2)
        /// </summary>
       public static bool Insert(string MaThe, DateTime NgayHuy, string TenCongTyHopDong, string GhiChu, int MaDonViVe)
        {
            return new Data.QuanLyVe.The().Insert(MaThe, NgayHuy, TenCongTyHopDong, GhiChu, MaDonViVe);

        }
       public static bool Update(string MaThe, DateTime NgayHuy, string TenCongTyHopDong, string GhiChu, int MaDonViVe)
        {
            return new Data.QuanLyVe.The().Update(MaThe, NgayHuy, TenCongTyHopDong, GhiChu, MaDonViVe);

        }

       public static bool Delete(string MaThe, int MaDonViVe)
        {
            return new Data.QuanLyVe.The().Delete(MaThe , MaDonViVe);
        }
    }
}
