using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Taxi.Business 
{
    public class ThoatCuoc999
    {

        public static DataTable GetAllDSCauHinh()
        {
            return new Data.ThoatCuoc999().GetAllCauHinh();
        }
        /// <summary>
        /// hamf tra ve cau hinh cua mot vung (phut, so cuoc goi gioi han)
        /// </summary>
        /// <param name="vung"></param>
        /// <returns></returns>
        public static DataTable GetCauHinhByVung(int vung)
        {
            return new Data.ThoatCuoc999().GetCauHinhByVung(vung);
        }
        /// <summary>
        /// ham tra ve thong tin cau hinh bat tat thoat cuar cuar mot vung
        /// </summary>
        /// <param name="vung"></param>
        /// <returns></returns>
        public static DataTable GetCauHinhBATTATByVung(int vung)
        {
            return new Data.ThoatCuoc999().GetCauHinhBATTATByVung(vung);
        }
        /// <summary>
        /// hàm insert vào cấu hình tuyến 999
        /// </summary>
        /// <param name="vung"></param>
        /// <param name="soCuocGioiHan"></param>
        /// <param name="soPhutGioiHan"></param>
        /// <returns></returns>
        public static bool InsertCauHinh(int vung, int soCuocGioiHan, int soPhutGioiHan, string nguoiTao)
        {
            return new Data.ThoatCuoc999().InsertCauHinh(vung, soCuocGioiHan, soPhutGioiHan,nguoiTao);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vung"></param>
        /// <param name="soCuocGioiHan"></param>
        /// <param name="soPhutGioiHan"></param>
        /// <param name="nguoiSua"></param>
        /// <returns></returns>
        public static bool UpdateCauHinh(int vung, int soCuocGioiHan, int soPhutGioiHan, string nguoiSua)
        {
            return new Data.ThoatCuoc999().UpdateCauHinh(vung, soCuocGioiHan, soPhutGioiHan, nguoiSua);
        }
        /// <summary>
        /// lấy đẩy đủ thong tin đặt cấu hình thoát cuốc
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataTable GetThongTinCauHinhBatCuoc()
        {
            return new Data.ThoatCuoc999().GetThongTinCauHinhBatCuoc( );
        }
        /// <summary>
        /// ham thuc hien bat thoat cuoc che do 999
        /// </summary>
        /// <param name="vung"></param>
        /// <param name="p"></param>
        public static bool BatThoatCuoc999(int vung, string nguoiBat)
        {
            return new Data.ThoatCuoc999().BatThoatCuoc999(vung, nguoiBat);
        }
        /// <summary>
        /// Ham thuc hien tat phan thoat cuoc 999
        /// </summary>
        /// <param name="vung"></param>
        /// <param name="nguoiTat"></param>
        public static bool TatThoatCuoc999(int vung, string nguoiTat)
        {
            return new Data.ThoatCuoc999().TatThoatCuoc999(vung, nguoiTat);
        }
    }
}
