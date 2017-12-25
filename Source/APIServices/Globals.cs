using System;
using System.Collections.Generic;
using System.Web;

namespace APIServices
{
    public class Globals
    {
        /// <summary>
        /// laasy thoong tin cau hinh so giay kiem tra xe hoat dong
        /// mac dinh la 120 giay
        /// </summary>
        public static int  GetSoGiayKiemTraXeHoatDong()
        {
            return 120;
        }

        public static string GetDSMaCungXN()
        {
            return "329,6025";
        }
        /// <summary>
        /// ham tinh khoang cach giua hai diem
        /// theo cach tinh 2 diem tren mat phang, sai so chap nhan duoc
        ///  SET @kc = SQRT(SQUARE( ABS( @KinhDo2-@KinhDo1)) + SQUARE( ABS(@ViDo2-@ViDo1))) 
	    //    return @kc * 111189.57696 -- SELECT 60 * 1.1515 * 1.609344 * 1000;  
        /// </summary>
        /// <param name="kinhDo1"></param>
        /// <param name="viDo1"></param>
        /// <param name="kinhDo2"></param>
        /// <param name="viDo2"></param>
        /// <returns>khoang cach giua 2 diem toa do tinh ra met</returns>
        public static double  TinhKhoangCachFast(float kinhDo1, float viDo1, float kinhDo2, float viDo2)
        {
            return   Math.Sqrt(Math.Abs(kinhDo2 - kinhDo1) * Math.Abs(kinhDo2 - kinhDo1) + Math.Abs(viDo2 - viDo1) * Math.Abs(viDo2 - viDo1)) * 111189.57696;
  
        }
    }
}
