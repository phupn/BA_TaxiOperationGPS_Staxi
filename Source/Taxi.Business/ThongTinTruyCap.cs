using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Data;
using Taxi.Utils;

namespace Taxi.Business
{
    /// <summary>
    /// Ghi nhan lai thong tin cua nguoi dung truy cap vao he thong WebGPS
    /// </summary>
   public  class ThongTinTruyCap
   {
       #region Properties      
       private string mUserName;
       private DateTime mThoiDiemTruyCap;
       private string mIPAddress;
       private string mLoaiTrinhDuyet;
       private string mGhiChu;

       public string UserName
       {
           get { return mUserName; }
           set { mUserName = value; }
       }

       public DateTime ThoiDiemTruyCap
       {
           get { return mThoiDiemTruyCap; }
           set { mThoiDiemTruyCap = value; }
       }

       public string IPAddress
       {
           get { return mIPAddress; }
           set { mIPAddress = value; }
       }

       public string LoaiTrinhDuyet
       {
           get { return mLoaiTrinhDuyet; }
           set { mLoaiTrinhDuyet = value; }
       }

       public string GhiChu
       {
           get { return mGhiChu; }
           set { mGhiChu = value; }
       }
       #endregion 

       /// <summary>
       /// lay thong tin truy cap trong khoang thoi gian
       /// </summary>
       /// <param name="TuNgayGio"></param>
       /// <param name="DenNgayGio"></param>
       /// <returns></returns>
       public List<ThongTinTruyCap> GetDSThongTinTruyCap(DateTime TuNgayGio, DateTime DenNgayGio)
       {

           return null;
       }
       /// <summary>
       ///  lay thong tin truy cap trong khoang thoi gian cua mot username
       /// </summary>
       /// <param name="Username"></param>
       /// <param name="TuNgayGio"></param>
       /// <param name="DenNgayGio"></param>
       /// <returns></returns>
       public List<ThongTinTruyCap> GetDSThongTinTruyCap(string Username, DateTime TuNgayGio, DateTime DenNgayGio)
       {

           return null;
       }
       /// <summary>
       /// lay thong tin truy cap trong khoang thoi gian cua mot username ung voi IP nhap vao
       /// </summary>
       /// <param name="Username"></param>
       /// <param name="IPAddress"></param>
       /// <param name="TuNgayGio"></param>
       /// <param name="DenNgayGio"></param>
       /// <returns></returns>
       public List<ThongTinTruyCap> GetDSThongTinTruyCap(string Username, string IPAddress, DateTime TuNgayGio, DateTime DenNgayGio)
       {
           DataTable dt;
           List<ThongTinTruyCap> lstLog = new List<ThongTinTruyCap>();

           dt = new Data.ThongTinTruyCap().GetDSThongTinTruyCap(Username, IPAddress, TuNgayGio, DenNgayGio);

           if ((dt != null) && (dt.Rows.Count > 0))
           {
               foreach (DataRow dr in dt.Rows)
               {
                   ThongTinTruyCap tt = new ThongTinTruyCap();

                   tt.UserName = StringTools.TrimSpace(dr["Username"].ToString());

                   if (StringTools.TrimSpace(dr["IPAddress"].ToString()).Length > 0)
                   {
                       tt.IPAddress = StringTools.TrimSpace(dr["IPAddress"].ToString());
                   }
                   if (StringTools.TrimSpace(dr["LoaiTrinhDuyet"].ToString()).Length > 0)
                   {
                       tt.LoaiTrinhDuyet = StringTools.TrimSpace(dr["LoaiTrinhDuyet"].ToString());
                   }
                   if (StringTools.TrimSpace(dr["GhiChu"].ToString()).Length > 0)
                   {
                       tt.GhiChu = StringTools.TrimSpace(dr["GhiChu"].ToString());
                   }


                   tt.ThoiDiemTruyCap = (DateTime)dr["ThoiDiemTruyCap"];
                   lstLog.Add(tt);
               }
           }
           return lstLog;           
       }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="Username"></param>
       /// <param name="IPAddress"></param>
       /// <param name="TuNgayGio"></param>
       /// <param name="DenNgayGio"></param>
       /// <returns></returns>
       public DataTable GetTableThongTinTruyCap(string Username, string IPAddress, DateTime TuNgayGio, DateTime DenNgayGio)
       {
           DataTable dt = new Data.ThongTinTruyCap().GetDSThongTinTruyCap(Username, IPAddress, TuNgayGio, DenNgayGio);
           return dt;
       }
       /// <summary>
       /// chen thoong tin co nguoi dung truy cap vao he thong
       /// </summary>
       /// <returns></returns>
       public bool Insert(string Username, string IPAddress, string typeBrown, DateTime ThoiDiem, string GhiChu)
       {
           Data.ThongTinTruyCap clsThongtin = new Data.ThongTinTruyCap();
           return clsThongtin.insertNew(Username, IPAddress, typeBrown, ThoiDiem, GhiChu);
       }

       /// <summary>
       /// xoa noi dung cua bang du lieu tu khoang thoi dia
       /// </summary>
       /// <param name="TuNgayGioi"></param>
       /// <param name="DenNgayGio"></param>
       /// <returns></returns>
       public bool Delete(DateTime TuNgayGio , DateTime DenNgayGio)
       {

           Data.ThongTinTruyCap clsThongtin = new Data.ThongTinTruyCap();
           return clsThongtin.deleteData(TuNgayGio, DenNgayGio);
       }
   }
}
