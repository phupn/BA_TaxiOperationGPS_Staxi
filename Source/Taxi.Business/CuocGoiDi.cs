using System;
using System.Data;

namespace Taxi.Business
{
   public  class CuocGoiDi
    {
       //Line, PhoneNumber,ThoiDiemGoi,DoDaiCuocGoi,VoiceFilePath
        private string mLine;

        public string Line
        {
            get { return mLine; }
            set { mLine = value; }
        }
        private string mPhoneNumber;

        public string PhoneNumber
        {
            get { return mPhoneNumber; }
            set { mPhoneNumber = value; }
        }

        private DateTime mThoiDiemGoi;

        public DateTime ThoiDiemGoi
        {
            get { return mThoiDiemGoi; }
            set { mThoiDiemGoi = value; }
        }
        private DateTime mDoDaiCuoiGoi;

        public DateTime DoDaiCuoiGoi
        {
            get { return mDoDaiCuoiGoi; }
            set { mDoDaiCuoiGoi = value; }
        }

        private string mVoiceFilePath;

        public string VoiceFilePath
        {
            get { return mVoiceFilePath; }
            set { mVoiceFilePath = value; }
        }

       public CuocGoiDi()
       {
       }
       public CuocGoiDi(string Line, string PhoneNumber, DateTime ThoiDiemGoi, DateTime DoDaiCuocGoi, string VoiceFilePath)
       {
           this.Line = Line;
           this.ThoiDiemGoi = ThoiDiemGoi;
           this.DoDaiCuoiGoi = DoDaiCuocGoi;
           this.PhoneNumber = PhoneNumber;
           this.VoiceFilePath = VoiceFilePath;
       }
       public bool Insert()
       {
          return  new Data.CuocGoiDi().Insert(Line, PhoneNumber, ThoiDiemGoi, DoDaiCuoiGoi, VoiceFilePath);
       }

       public static DataTable GetDSCuocGoiDi(DateTime TuNgayGio, DateTime DenNgayGio)
       {
           return new Data.CuocGoiDi().Select(TuNgayGio,DenNgayGio);
       }
       public static DataTable GetDSCuocGoiDi(DateTime TuNgayGio, DateTime DenNgayGio, DateTime Duration, string PhoneNumber,string Line)
       {
           return new Data.CuocGoiDi().GetDSCuocGoiDi(TuNgayGio, DenNgayGio,Duration, PhoneNumber,Line);

       }
       /// <summary>
       /// ham lay ra thong tin cuoc goi di
       /// </summary>
       public static DataTable GetDSCuocGoiDi(DateTime TuNgayGio, DateTime DenNgayGio, DateTime Duration, string PhoneNumber, string Line,string NhanVienID,string PhanLoai)
       {
           return new Data.CuocGoiDi().GetDSCuocGoiDi(TuNgayGio, DenNgayGio, Duration, PhoneNumber, Line,NhanVienID,PhanLoai);

       }
       public static bool Delete(DateTime TuNgayGio, DateTime DenNgayGio)
       {
           return new Data.CuocGoiDi().Delete(TuNgayGio, DenNgayGio);
       }

       public static bool DeleteNhungCuocGoiDiNhoHon3ThangGanDay()
       {
           DateTime TuNgayGio = new DateTime (2000,01,01,0,0,0);

           DateTime DenNgayGio = DieuHanhTaxi.GetTimeServer();
           DenNgayGio = DenNgayGio.Subtract(new TimeSpan(90,0,0,0));

           return new Data.CuocGoiDi().Delete(TuNgayGio, DenNgayGio);
       }
       /// <summary>
       /// ham tra ve cuoc goi di gan thoi diem goi nhat,  30 giay
       /// </summary>
       /// <param name="SoDienThoai"></param>
       /// <param name="ThoiDiem"></param>
       /// <returns></returns>
       public static string GetFileGhiAmCuocGoiDi(string SoDienThoai, DateTime ThoiDiem)
       {
           DataTable dt = new Data.CuocGoiDi().GetFileGhiAmCuocGoiDi(  SoDienThoai,ThoiDiem);
           if (dt != null && dt.Rows.Count > 0)
           {
               return dt.Rows[0]["VoiceFilePath"] == null ? "" : dt.Rows[0]["VoiceFilePath"].ToString();
           }

           return "";
       }
   }
}
