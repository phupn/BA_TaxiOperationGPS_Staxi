using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Taxi.Utils;

namespace Taxi.Business.QuanLyVe
{
    public class KhachHang
    {
        protected  int _IDKhachHang ;
        protected  string _TenKhachHang ;
        protected  string _DiaChi ;
        protected  string _NguoiLienHe ;
        protected  string _DienThoai ;
        protected  string _MaNhanVienQuanLy ;
        protected  DateTime _NgayKyKet ;
        
        public KhachHang()
        {
        }
        
        public  KhachHang( int _IDKhachHang ,string _TenKhachHang ,string _DiaChi ,string _NguoiLienHe ,string _DienThoai ,string _MaNhanVienQuanLy ,DateTime _NgayKyKet  )
        {
           this.IDKhachHang = _IDKhachHang ;
           this.TenKhachHang = _TenKhachHang ;
           this.DiaChi = _DiaChi ;
           this.NguoiLienHe = _NguoiLienHe ;
           this.DienThoai = _DienThoai ;
           this.MaNhanVienQuanLy = _MaNhanVienQuanLy ;
           this.NgayKyKet = _NgayKyKet ;
       }

       #region Properties
       public int IDKhachHang
        {
            get { return _IDKhachHang ; }
            set { _IDKhachHang = value ; }
        }
        public string TenKhachHang
        {
            get { return _TenKhachHang ; }
            set { _TenKhachHang = value ; }
        }
        public string DiaChi
        {
            get { return _DiaChi ; }
            set { _DiaChi = value ; }
        }
        public string NguoiLienHe
        {
            get { return _NguoiLienHe ; }
            set { _NguoiLienHe = value ; }
        }
        public string DienThoai
        {
            get { return _DienThoai ; }
            set { _DienThoai = value ; }
        }
        public string MaNhanVienQuanLy
        {
            get { return _MaNhanVienQuanLy ; }
            set { _MaNhanVienQuanLy = value ; }
        }
        public DateTime NgayKyKet
        {
            get { return _NgayKyKet ; }
            set { _NgayKyKet = value ; }
        }

        #endregion Properties

        /// <summary>
        /// insert tra ve ma khach hang
        /// </summary>
        /// <returns></returns>
        public int  Insert()
        {
            return new Data.QuanLyVe.KhachHang().Insert(this.TenKhachHang, this.DiaChi, this.NguoiLienHe, this.DienThoai, this.MaNhanVienQuanLy, this.NgayKyKet);

        }

        public bool Update()
         {

        return new Data.QuanLyVe.KhachHang().Update(this.IDKhachHang ,this.TenKhachHang , this.DiaChi, this.NguoiLienHe, this.DienThoai, this.MaNhanVienQuanLy, this.NgayKyKet);
        }

        public bool Delete()
        {
            return new Data.QuanLyVe.KhachHang().Delete(this.IDKhachHang);
        }

        public static KhachHang GetChiTietKhachHang(int IDKhachHang)
        {
            DataTable dt = new Data.QuanLyVe.KhachHang().GetChiTietKhachHang(IDKhachHang);
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                KhachHang objKH = new KhachHang();
                DataRow dr = dt.Rows[0];
        //       [IDKhachHang]
        //      ,[TenKhachHang]
        //      ,[DiaChi]
        //      ,[NguoiLienHe]
        //      ,[DienThoai]
        //      ,[MaNhanVienQuanLy]
        //      ,[NgayKyKet] 
                objKH.IDKhachHang = int.Parse(dr["IDKhachHang"].ToString());
                objKH.TenKhachHang = dr["TenKhachHang"].ToString();
                objKH.DiaChi = dr["DiaChi"].ToString();
                objKH.NguoiLienHe = dr["NguoiLienHe"].ToString();
                objKH.DienThoai = dr["DienThoai"].ToString();
                objKH.MaNhanVienQuanLy = dr["MaNhanVienQuanLy"].ToString();
                objKH.NgayKyKet = DateTime.Parse(dr["NgayKyKet"].ToString());

                return objKH;
            }

            return null; ;
        }

        /// <summary>
        /// lay ds khach hang
        ///   neu TenKhachHang !=null thi lay theo ten
        ///   if la null thi lay tat ca
        /// </summary>
        /// <param name="TenKhachHang"></param>
        /// <returns></returns>
        public static List<KhachHang> GetDSKhachHang(string TenKhachHang)
        {
            DataTable dt;
            if (TenKhachHang.Length > 0)
                dt = new Data.QuanLyVe.KhachHang().GetDSKhachHang(TenKhachHang);
            else dt = new Data.QuanLyVe.KhachHang().GetDSKhachHang();

            List<KhachHang> listKhachHang = new List<KhachHang>();

            if ((dt != null) && (dt.Rows.Count > 0))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    KhachHang objKH = new KhachHang();
                     
                    //       [IDKhachHang]
                    //      ,[TenKhachHang]
                    //      ,[DiaChi]
                    //      ,[NguoiLienHe]
                    //      ,[DienThoai]
                    //      ,[MaNhanVienQuanLy]
                    //      ,[NgayKyKet] 
                    objKH.IDKhachHang = int.Parse(dr["IDKhachHang"].ToString());
                    objKH.TenKhachHang = dr["TenKhachHang"].ToString();
                    objKH.DiaChi = dr["DiaChi"].ToString();
                    objKH.NguoiLienHe = dr["NguoiLienHe"].ToString();
                    objKH.DienThoai = dr["DienThoai"].ToString();
                    objKH.MaNhanVienQuanLy = dr["MaNhanVienQuanLy"].ToString();
                    objKH.NgayKyKet = DateTime.Parse(dr["NgayKyKet"].ToString());
                    listKhachHang.Add(objKH);
                }
                 
            }

            return listKhachHang; ;
        }
    }
}
