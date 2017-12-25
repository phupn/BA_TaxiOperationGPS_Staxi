using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Taxi.Business.BanGiaGoc
{
 public   class Dulieudauvaotinhtien
 {
     #region
     private bool _IsQuanToan;

     public bool IsQuanToan
     {
         get { return _IsQuanToan; }
         set { _IsQuanToan = value; }
     }
     private string _TuyenDuongID;
        public string TuyenDuongID
        {
            get { return _TuyenDuongID; }
            set
            {
                _TuyenDuongID = value;
            }
        }
        private string _Tentuyenduong;
        public string Tentuyenduong
        {
            get { return _Tentuyenduong; }
            set
            {
                _Tentuyenduong = value;
            }
        }
     
        private int _LoaiXeID;
        public int LoaiXeID
        {
            get { return _LoaiXeID; }
            set { _LoaiXeID = value; }
        }
        private string _TenLoaiXe;

        public string TenLoaiXe
        {
            get { return _TenLoaiXe; }
            set { _TenLoaiXe = value; }
        }
        private double _KmQuyDinh1Chieu;
        public double KmQuyDinh1Chieu
        {
            get { return _KmQuyDinh1Chieu; }
            set
            {
                _KmQuyDinh1Chieu = value;
            }
        }
        private double  _ThoiGianQuyDinh1Chieu;
     public double ThoiGianQuyDinh1Chieu
        {
            get { return _ThoiGianQuyDinh1Chieu; }
            set
            {
                _ThoiGianQuyDinh1Chieu = value;
            }
        }
        private double _GiaTien1Chieu;
        public double GiaTien1Chieu
        {
            get { return _GiaTien1Chieu; }
            set
            {
                _GiaTien1Chieu = value;
            }
        }
        private string _ConvertHToNgay1;
        public string ConvertHToNgay1
        {
            get { return _ConvertHToNgay1; }
            set
            {
                _ConvertHToNgay1 = value;
            }
        }
     
        private string _ConvertHToNgay2;
        public string ConvertHToNgay2
        {
            get { return _ConvertHToNgay2; }
            set
            {
                _ConvertHToNgay2 = value;
            }
        }
     
        private double _KmQuyDinh2Chieu;
        public double KmQuyDinh2Chieu
        {
            get { return _KmQuyDinh2Chieu; }
            set
            {
                _KmQuyDinh2Chieu = value;
            }
        }
     private double _ThoiGianQuyDinh2Chieu;
     public double ThoiGianQuyDinh2Chieu
        {
            get { return _ThoiGianQuyDinh2Chieu; }
            set
            {
                _ThoiGianQuyDinh2Chieu = value;
            }
        }
        private double _GiaTien2Chieu;
        public double GiaTien2Chieu
        {
            get { return _GiaTien2Chieu; }
            set
            {
                _GiaTien2Chieu = value;
            }
        }
        private string _VeTram;

        public string VeTram
        {
            get { return _VeTram; }
            set { _VeTram = value; }
        }

     public string GiaThueBao1Chieu()
     {
         return string.Format("{0}/{1}/{2}", this.GiaTien1Chieu, this.KmQuyDinh1Chieu, ThoiGianQuyDinh1Chieu);
     }
     public string GiaThueBao2Chieu()
     {
         return string.Format("{0}/{1}/{2}", this.GiaTien2Chieu, this.KmQuyDinh2Chieu, ThoiGianQuyDinh2Chieu);
     }
        #endregion

     public int insert(Dulieudauvaotinhtien Dulieudauvaotinhtienobj)
     {
         Taxi.Data.BanGiaGoc.Dulieudauvaotinhtien DulieudauvaotinhtienControl = new Taxi.Data.BanGiaGoc.Dulieudauvaotinhtien();
         return DulieudauvaotinhtienControl.Insert(Dulieudauvaotinhtienobj.IsQuanToan, Dulieudauvaotinhtienobj.TuyenDuongID, Dulieudauvaotinhtienobj.LoaiXeID, Dulieudauvaotinhtienobj.KmQuyDinh1Chieu, Dulieudauvaotinhtienobj.ThoiGianQuyDinh1Chieu, Dulieudauvaotinhtienobj.GiaTien1Chieu, Dulieudauvaotinhtienobj.KmQuyDinh2Chieu, Dulieudauvaotinhtienobj.ThoiGianQuyDinh2Chieu, Dulieudauvaotinhtienobj.GiaTien2Chieu, Dulieudauvaotinhtienobj.VeTram);
     }
     public int Update(Dulieudauvaotinhtien Dulieudauvaotinhtienobj)
     {
         Taxi.Data.BanGiaGoc.Dulieudauvaotinhtien DulieudauvaotinhtienControl = new Taxi.Data.BanGiaGoc.Dulieudauvaotinhtien();
         return DulieudauvaotinhtienControl.Update(Dulieudauvaotinhtienobj.IsQuanToan, Dulieudauvaotinhtienobj.TuyenDuongID, Dulieudauvaotinhtienobj.LoaiXeID, Dulieudauvaotinhtienobj.KmQuyDinh1Chieu, Dulieudauvaotinhtienobj.ThoiGianQuyDinh1Chieu, Dulieudauvaotinhtienobj.GiaTien1Chieu, Dulieudauvaotinhtienobj.KmQuyDinh2Chieu, Dulieudauvaotinhtienobj.ThoiGianQuyDinh2Chieu, Dulieudauvaotinhtienobj.GiaTien2Chieu, Dulieudauvaotinhtienobj.VeTram);
     }
     public int Delete(bool IsQuanToan, string TuyenDuongID,int LoaiXe)
     {
         Taxi.Data.BanGiaGoc.Dulieudauvaotinhtien DulieudauvaotinhtienControl = new Taxi.Data.BanGiaGoc.Dulieudauvaotinhtien();
         return DulieudauvaotinhtienControl.Delete(IsQuanToan,TuyenDuongID,LoaiXe);
     }


     public List<Dulieudauvaotinhtien> GetAll(bool IsQuanToan )
     {
         List<Dulieudauvaotinhtien> ListDulieudauvaotinhtien = new List<Dulieudauvaotinhtien>();
      Taxi.Data.BanGiaGoc.Dulieudauvaotinhtien DulieudauvaotinhtienControl = new Taxi.Data.BanGiaGoc.Dulieudauvaotinhtien();
      DataTable dt = DulieudauvaotinhtienControl.GetAll(IsQuanToan);
          if (dt != null)
          {
              if (dt.Rows.Count > 0)
              {
                  foreach (DataRow Rowsa in dt.Rows)
                  {
                      Dulieudauvaotinhtien Dulieudauvaotinhtienobj = new Dulieudauvaotinhtien();
                      Dulieudauvaotinhtienobj.GiaTien1Chieu = Convert.ToDouble(Rowsa["GiaTien1Chieu"]);
                      Dulieudauvaotinhtienobj.GiaTien2Chieu = Convert.ToDouble(Rowsa["GiaTien2Chieu"]);
                      Dulieudauvaotinhtienobj.KmQuyDinh1Chieu = Convert.ToDouble(Rowsa["KmQuyDinh1Chieu"]);
                      Dulieudauvaotinhtienobj.KmQuyDinh2Chieu = Convert.ToDouble(Rowsa["KmQuyDinh2Chieu"]);
                      Dulieudauvaotinhtienobj.ThoiGianQuyDinh1Chieu = Convert.ToDouble(Rowsa["ThoiGianQuyDinh1Chieu"]);
                      Dulieudauvaotinhtienobj.ThoiGianQuyDinh2Chieu = Convert.ToDouble(Rowsa["ThoiGianQuyDinh2Chieu"]);
                      Dulieudauvaotinhtienobj.LoaiXeID = Convert.ToInt32(Rowsa["LoaiXeID"]);
                      Dulieudauvaotinhtienobj.TuyenDuongID = Rowsa["TuyenDuongID"].ToString();
                      Dulieudauvaotinhtienobj.Tentuyenduong = Rowsa["TenTuyenDuong"].ToString();
                      Dulieudauvaotinhtienobj.IsQuanToan = Convert.ToBoolean(dt.Rows[0]["IsQuanToan"].ToString());
                      Dulieudauvaotinhtienobj.VeTram = Rowsa["VeTram"].ToString();
                      Dulieudauvaotinhtienobj.ConvertHToNgay1 = ConvertGioToNgay(Dulieudauvaotinhtienobj.ThoiGianQuyDinh1Chieu);
                      Dulieudauvaotinhtienobj.ConvertHToNgay2  = ConvertGioToNgay(Dulieudauvaotinhtienobj.ThoiGianQuyDinh2Chieu);

                      
                      ListDulieudauvaotinhtien.Add(Dulieudauvaotinhtienobj);
                  }
              }
             
                  
          }
          return ListDulieudauvaotinhtien;
     }
     public static string ConvertGioToNgay(double Gio)
     {
         string strNgay = "";
         if(Gio>24)
         {
             int  Nguyen =Convert.ToInt16(Gio.ToString ());              
             return string.Format("{0} ngày {1} giờ",Nguyen/24,Nguyen % 24);
         }
         else  return string.Format("{0:##.#}",Gio);

     }
     /// <summary>
     /// hafm tra ve ds ds cua mot tuyen duong ung voi cac loai xe
     /// </summary>
     /// <param name="IsQuanToan"></param>
     /// <param name="MaTuyenDuong"></param>
     /// <returns></returns>
     public List<Dulieudauvaotinhtien> GetDSGiaCuaMotTuyen(bool IsQuanToan, string MaTuyenDuong)
     {
         List<Dulieudauvaotinhtien> ListDulieudauvaotinhtien = new List<Dulieudauvaotinhtien>();
         Taxi.Data.BanGiaGoc.Dulieudauvaotinhtien DulieudauvaotinhtienControl = new Taxi.Data.BanGiaGoc.Dulieudauvaotinhtien();
         DataTable dt = DulieudauvaotinhtienControl.GetDulieuCuaMotTuyen(IsQuanToan, MaTuyenDuong);
         if (dt != null)
         {
             if (dt.Rows.Count > 0)
             {
                 foreach (DataRow Rowsa in dt.Rows)
                 {
                     Dulieudauvaotinhtien Dulieudauvaotinhtienobj = new Dulieudauvaotinhtien();
                     Dulieudauvaotinhtienobj.GiaTien1Chieu = Convert.ToDouble(Rowsa["GiaTien1Chieu"]);
                     Dulieudauvaotinhtienobj.GiaTien2Chieu = Convert.ToDouble(Rowsa["GiaTien2Chieu"]);
                     Dulieudauvaotinhtienobj.KmQuyDinh1Chieu = Convert.ToDouble(Rowsa["KmQuyDinh1Chieu"]);
                     Dulieudauvaotinhtienobj.KmQuyDinh2Chieu = Convert.ToDouble(Rowsa["KmQuyDinh2Chieu"]);
                     Dulieudauvaotinhtienobj.ThoiGianQuyDinh1Chieu = Convert.ToDouble(Rowsa["ThoiGianQuyDinh1Chieu"]);
                     Dulieudauvaotinhtienobj.ThoiGianQuyDinh2Chieu = Convert.ToDouble(Rowsa["ThoiGianQuyDinh2Chieu"]);
                     Dulieudauvaotinhtienobj.LoaiXeID = Convert.ToInt32(Rowsa["LoaiXeID"]);
                     Dulieudauvaotinhtienobj.TenLoaiXe = Rowsa["TenLoaiXe"].ToString();
                     Dulieudauvaotinhtienobj.TuyenDuongID = Rowsa["TuyenDuongID"].ToString();
                     Dulieudauvaotinhtienobj.Tentuyenduong = Rowsa["TenTuyenDuong"].ToString();
                     Dulieudauvaotinhtienobj.IsQuanToan = Convert.ToBoolean(dt.Rows[0]["IsQuanToan"].ToString());
                     Dulieudauvaotinhtienobj.VeTram = Rowsa["VeTram"].ToString();
                     Dulieudauvaotinhtienobj.ConvertHToNgay1 = ConvertGioToNgay(Dulieudauvaotinhtienobj.ThoiGianQuyDinh1Chieu);
                     Dulieudauvaotinhtienobj.ConvertHToNgay2 = ConvertGioToNgay(Dulieudauvaotinhtienobj.ThoiGianQuyDinh2Chieu);
                     ListDulieudauvaotinhtien.Add(Dulieudauvaotinhtienobj);
                 }
             }


         }
         return ListDulieudauvaotinhtien;
     }
      
     public List<Dulieudauvaotinhtien> GetAllGroupLoaixe(bool IsQuanToan,int LoaixeID)
     {
         List<Dulieudauvaotinhtien> ListDulieudauvaotinhtien = new List<Dulieudauvaotinhtien>();
         Taxi.Data.BanGiaGoc.Dulieudauvaotinhtien DulieudauvaotinhtienControl = new Taxi.Data.BanGiaGoc.Dulieudauvaotinhtien();
         DataTable dt = DulieudauvaotinhtienControl.GetByLoaixeID(IsQuanToan,LoaixeID);
         if (dt != null)
         {
             if (dt.Rows.Count > 0)
             {
                 foreach (DataRow Rowsa in dt.Rows)
                 {
                     Dulieudauvaotinhtien Dulieudauvaotinhtienobj = new Dulieudauvaotinhtien();
                     Dulieudauvaotinhtienobj.GiaTien1Chieu = Convert.ToDouble(Rowsa["GiaTien1Chieu"]);
                     Dulieudauvaotinhtienobj.GiaTien2Chieu = Convert.ToDouble(Rowsa["GiaTien2Chieu"]);
                     Dulieudauvaotinhtienobj.KmQuyDinh1Chieu = Convert.ToDouble(Rowsa["KmQuyDinh1Chieu"]);
                     Dulieudauvaotinhtienobj.KmQuyDinh2Chieu = Convert.ToDouble(Rowsa["KmQuyDinh2Chieu"]);
                     Dulieudauvaotinhtienobj.ThoiGianQuyDinh1Chieu = Convert.ToDouble(Rowsa["ThoiGianQuyDinh1Chieu"]);
                     Dulieudauvaotinhtienobj.ThoiGianQuyDinh2Chieu = Convert.ToDouble(Rowsa["ThoiGianQuyDinh2Chieu"]);
                     Dulieudauvaotinhtienobj.LoaiXeID = Convert.ToInt32(Rowsa["LoaiXeID"]);
                     Dulieudauvaotinhtienobj.TuyenDuongID = Rowsa["TuyenDuongID"].ToString();
                     Dulieudauvaotinhtienobj.Tentuyenduong = Rowsa["TenTuyenDuong"].ToString();
                     Dulieudauvaotinhtienobj.IsQuanToan = Convert.ToBoolean(dt.Rows[0]["IsQuanToan"].ToString());
                     Dulieudauvaotinhtienobj.VeTram = Rowsa["VeTram"].ToString();
                     Dulieudauvaotinhtienobj.ConvertHToNgay1 = ConvertGioToNgay(Dulieudauvaotinhtienobj.ThoiGianQuyDinh1Chieu);
                     Dulieudauvaotinhtienobj.ConvertHToNgay2 = ConvertGioToNgay(Dulieudauvaotinhtienobj.ThoiGianQuyDinh2Chieu);

                     ListDulieudauvaotinhtien.Add(Dulieudauvaotinhtienobj);
                 }
             }


         }
         return ListDulieudauvaotinhtien;
     }
     public Dulieudauvaotinhtien Selectone(bool IsQuanToan, string MaTuyenDuong, int LoaixeID)
     {
         Taxi.Data.BanGiaGoc.Dulieudauvaotinhtien DulieudauvaotinhtienControl = new Taxi.Data.BanGiaGoc.Dulieudauvaotinhtien();
         DataTable dt = DulieudauvaotinhtienControl.GetOne(IsQuanToan,MaTuyenDuong, LoaixeID);
         Dulieudauvaotinhtien Dulieudauvaotinhtienobj = new Dulieudauvaotinhtien();
         if (dt != null)
         {
             if (dt.Rows.Count > 0)
             {
                 Dulieudauvaotinhtienobj.GiaTien1Chieu = Convert.ToDouble(dt.Rows[0]["GiaTien1Chieu"]);
                 Dulieudauvaotinhtienobj.GiaTien2Chieu = Convert.ToDouble(dt.Rows[0]["GiaTien2Chieu"]);
                 Dulieudauvaotinhtienobj.KmQuyDinh1Chieu = Convert.ToDouble(dt.Rows[0]["KmQuyDinh1Chieu"]);
                 Dulieudauvaotinhtienobj.KmQuyDinh2Chieu = Convert.ToDouble(dt.Rows[0]["KmQuyDinh2Chieu"]);
                 Dulieudauvaotinhtienobj.ThoiGianQuyDinh1Chieu = Convert.ToDouble(dt.Rows[0]["ThoiGianQuyDinh1Chieu"]);
                 Dulieudauvaotinhtienobj.ThoiGianQuyDinh2Chieu = Convert.ToDouble(dt.Rows[0]["ThoiGianQuyDinh2Chieu"]);
                 Dulieudauvaotinhtienobj.LoaiXeID = Convert.ToInt32(dt.Rows[0]["LoaiXeID"]);
                 Dulieudauvaotinhtienobj.TuyenDuongID = dt.Rows[0]["TuyenDuongID"].ToString();
                 Dulieudauvaotinhtienobj.VeTram = dt.Rows[0]["VeTram"].ToString();
                 Dulieudauvaotinhtienobj.IsQuanToan = Convert.ToBoolean(dt.Rows[0]["IsQuanToan"].ToString() );
                 return Dulieudauvaotinhtienobj;
             }
             else
             {
                 return null;
             }
         }
         else
         {
             return null;
         }

     }

     /// <summary>
     /// lây ds dữ liệu của một tuyến đường
     /// </summary>
     /// <param name="g_IsQuanToan"></param>
     /// <param name="MaTuyenDuong"></param>
     /// <returns></returns>
     public static List<Dulieudauvaotinhtien> GetDulieuCuaMotTuyen(bool IsQuanToan, string MaTuyenDuong)
     {
          List<Dulieudauvaotinhtien> ListDulieudauvaotinhtien = new List<Dulieudauvaotinhtien>();
         Taxi.Data.BanGiaGoc.Dulieudauvaotinhtien DulieudauvaotinhtienControl = new Taxi.Data.BanGiaGoc.Dulieudauvaotinhtien();
         DataTable dt = DulieudauvaotinhtienControl.GetDulieuCuaMotTuyen(IsQuanToan, MaTuyenDuong);
         if (dt != null)
         {
             if (dt.Rows.Count > 0)
             {
                 foreach (DataRow Rowsa in dt.Rows)
                 {
                     Dulieudauvaotinhtien Dulieudauvaotinhtienobj = new Dulieudauvaotinhtien();
                     Dulieudauvaotinhtienobj.GiaTien1Chieu = Convert.ToDouble(Rowsa["GiaTien1Chieu"]);
                     Dulieudauvaotinhtienobj.GiaTien2Chieu = Convert.ToDouble(Rowsa["GiaTien2Chieu"]);
                     Dulieudauvaotinhtienobj.KmQuyDinh1Chieu = Convert.ToDouble(Rowsa["KmQuyDinh1Chieu"]);
                     Dulieudauvaotinhtienobj.KmQuyDinh2Chieu = Convert.ToDouble(Rowsa["KmQuyDinh2Chieu"]);
                     Dulieudauvaotinhtienobj.ThoiGianQuyDinh1Chieu = Convert.ToDouble(Rowsa["ThoiGianQuyDinh1Chieu"]);
                     Dulieudauvaotinhtienobj.ThoiGianQuyDinh2Chieu = Convert.ToDouble(Rowsa["ThoiGianQuyDinh2Chieu"]);
                     Dulieudauvaotinhtienobj.LoaiXeID = Convert.ToInt32(Rowsa["LoaiXeID"]);
                     Dulieudauvaotinhtienobj.TuyenDuongID = Rowsa["TuyenDuongID"].ToString();
                     Dulieudauvaotinhtienobj.Tentuyenduong = Rowsa["TenTuyenDuong"].ToString();
                     Dulieudauvaotinhtienobj.IsQuanToan = Convert.ToBoolean(dt.Rows[0]["IsQuanToan"].ToString());
                     Dulieudauvaotinhtienobj.VeTram = Rowsa["VeTram"].ToString();
                     Dulieudauvaotinhtienobj.ConvertHToNgay1 = ConvertGioToNgay(Dulieudauvaotinhtienobj.ThoiGianQuyDinh1Chieu);
                     Dulieudauvaotinhtienobj.ConvertHToNgay2 = ConvertGioToNgay(Dulieudauvaotinhtienobj.ThoiGianQuyDinh2Chieu);

                     ListDulieudauvaotinhtien.Add(Dulieudauvaotinhtienobj);
                 }
             }
         }
         else return null;

         return ListDulieudauvaotinhtien;
     }
 }
}
