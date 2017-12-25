using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Taxi.Utils;
using Taxi.Utils;

namespace Taxi.Business
{
    public class DanhBa
    {
        #region Members
        private string mPhoneNumber;

        public string PhoneNumber
        {
            get { return mPhoneNumber; }
            set { mPhoneNumber = value; }
        }

        private string mName;

        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }

        private string mAddress;

        public string Address
        {
            get { return mAddress; }
            set { mAddress = value; }
        }

        private string mAddress_Destination;
        public string Address_Destination
        {
            get { return mAddress_Destination; }
            set { mAddress_Destination = value; }
        }

        public KieuKhachHangGoiDen _KieuKhachHang;
        public KieuKhachHangGoiDen KieuKhachHang
        {
            get { return _KieuKhachHang; }
            set { _KieuKhachHang = value; }
        }
        #endregion

        #region Contructor
        public DanhBa()
        {
            mPhoneNumber = string.Empty;
            mName = string.Empty;
            mAddress = string.Empty;
        }
        public DanhBa(string PhoneNumber,string Name, string Address)
        {
            mPhoneNumber = PhoneNumber;
            mName = Name;
            mAddress = Address;
        }
        #endregion Contructor

        #region Methods
        public bool Insert()
        {
            return new Data.DanhBa().Insert(this.PhoneNumber, this.Name, this.Address);
        }

        private static bool IsDienThoaiDiDong(string PhoneNumber)
        {
            if (StringTools.TrimSpace(PhoneNumber).Length > 10) //01234781719
                return true;

            if ((PhoneNumber[0].ToString() == "9") || ((PhoneNumber[1].ToString() == "9")))
            {
                return true;
            }
            return false ;
        }
        public  static bool IsDienThoaiCoDinh(string PhoneNumber)
        {   // Du do dai de check dien thoai co dinh
            if ((PhoneNumber.Length>=8) && (PhoneNumber.Length <=10)) // 37856099 + 043 7856099
            {
                if ( PhoneNumber.Length == 8 ) return true;

                if ((PhoneNumber[0].ToString() == "4") || ((PhoneNumber[1].ToString() == "4")))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// ham tra ve dia tri tu mot so dien thoai
        /// </summary>
        /// <param name="PhoneNumber"></param>
        /// <param name="KieuKhachHang"></param>
        /// <returns></returns>
        public static string GetAddressFromPhoneNumber(string PhoneNumber, out  KieuKhachHangGoiDen KieuKhachHangGoi,out string MaDoiTac,out int Vung)
        {
            string DiaChi = "";
            KieuKhachHangGoiDen kieukhachgoi;
            bool GiaiMa = false ;
            string _MaDoiTac ="";
            int _Vung = 0;

             DiaChi =new Data.DanhBa().GetAddressFromPhoneNumber(PhoneNumber, out kieukhachgoi, out GiaiMa,out _MaDoiTac,out _Vung);
             if ((DiaChi!=null) &&  (DiaChi.Length > 0) && (GiaiMa))
             {
                 DiaChi = MaHoaDuLieu.GiaiMa(DiaChi);
             }
             KieuKhachHangGoi = kieukhachgoi;

             MaDoiTac = "";
             Vung = 0;
             if (KieuKhachHangGoi == KieuKhachHangGoiDen.KhachHangMoiGioi)
             {
                 Vung = _Vung;
                 MaDoiTac = _MaDoiTac;
             }
             return DiaChi;
        }
          

        /// <summary>
        /// tra ve dia chi cua so dien thoai 
        /// </summary>
        /// <param name="PhoneNumber"></param>
        /// <returns></returns>
        public static string  GetDanhBa(string PhoneNumber)
        {
            if(!DanhBa.IsDienThoaiDiDong(PhoneNumber))
            {
                if (DanhBa.IsDienThoaiCoDinh(PhoneNumber))
                {
                    DataTable dt = new DataTable();

                    dt = new Data.DanhBa().GetDanhBa(PhoneNumber.Substring(PhoneNumber.Length-8, 8));
                    string strDiaChi = "";
                    if (dt.Rows.Count > 0) // Co dia chi
                    {
                        strDiaChi =string.Format("[{0}]{1}",MaHoaDuLieu.GiaiMa(dt.Rows[0]["Name"].ToString()), MaHoaDuLieu.GiaiMa(dt.Rows[0]["Address"].ToString()));
                        
                    }
                    dt.Dispose();
                    dt = null;

                    return strDiaChi;
                }
            }
            return string.Empty; 
        }

        /// <summary>
        /// Tra ve danh sach buu dien
        /// </summary>
        /// <returns></returns>
        public static List<DanhBaCongTy> GetDanhBa_BuuDien()
        {
            DataTable dt =  new Data.DanhBa().GetDanhBa_BuuDien();
            List<DanhBaCongTy> lstDanhBaCongTy = new List<DanhBaCongTy>();
            
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    DanhBaCongTy objDanhBaCongTy = new DanhBaCongTy()
                    {
                        Name = item["Name"] != null && item["Name"].ToString() != "" ? MaHoaDuLieu.GiaiMa(item["Name"].ToString()) : "",
                        Address = item["Address"] != null && item["Address"].ToString() != "" ? MaHoaDuLieu.GiaiMa(item["Address"].ToString()) : "",
                        PhoneNumber = item["PhoneNumber"].ToString()
                    };
                    lstDanhBaCongTy.Add(objDanhBaCongTy);
                }
            }
            dt.Dispose();
            return lstDanhBaCongTy;
        }

        /// <summary>
        /// Tra ve danh sach buu dien
        /// </summary>
        public static List<DanhBaCongTy> GetDanhBa_BuuDien_1()
        {
            DataTable dt = new Data.DanhBa().GetDanhBa_BuuDien_1();
            List<DanhBaCongTy> lstDanhBaCongTy = new List<DanhBaCongTy>();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    DanhBaCongTy objDanhBaCongTy = new DanhBaCongTy()
                    {
                        Name = item["Name"] != null && item["Name"].ToString() != "" ? item["Name"].ToString() : "",
                        Address = item["Address"] != null && item["Address"].ToString() != "" ? item["Address"].ToString() : "",
                        PhoneNumber = item["PhoneNumber"].ToString()
                    };
                    lstDanhBaCongTy.Add(objDanhBaCongTy);
                }
            }
            dt.Dispose();
            return lstDanhBaCongTy;
        }

        /// <summary>
        /// Tra ve danh sach buu dien
        /// </summary>
        /// <returns></returns>
        public static List<DanhBaCongTy> GetDanhBa_BuuDien_2()
        {
            DataTable dt = new Data.DanhBa().GetDanhBa_BuuDien_2();
            List<DanhBaCongTy> lstDanhBaCongTy = new List<DanhBaCongTy>();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    DanhBaCongTy objDanhBaCongTy = new DanhBaCongTy()
                    {
                        Name = item["Name"] != null && item["Name"].ToString() != "" ? MaHoaDuLieu.GiaiMa(item["Name"].ToString()) : "",
                        Address = item["Address"] != null && item["Address"].ToString() != "" ? MaHoaDuLieu.GiaiMa(item["Address"].ToString()) : "",
                        PhoneNumber = item["PhoneNumber"].ToString()
                    };
                    lstDanhBaCongTy.Add(objDanhBaCongTy);
                }
            }
            dt.Dispose();
            return lstDanhBaCongTy;
        }

        /// <summary>
        /// Tra ve danh sach buu dien
        /// </summary>
        /// <returns></returns>
        public static List<DanhBaCongTy> GetDanhBa_BuuDien_3()
        {
            DataTable dt = new Data.DanhBa().GetDanhBa_BuuDien_3();
            List<DanhBaCongTy> lstDanhBaCongTy = new List<DanhBaCongTy>();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    DanhBaCongTy objDanhBaCongTy = new DanhBaCongTy()
                    {
                        Name = item["Name"] != null && item["Name"].ToString() != "" ? MaHoaDuLieu.GiaiMa(item["Name"].ToString()) : "",
                        Address = item["Address"] != null && item["Address"].ToString() != "" ? MaHoaDuLieu.GiaiMa(item["Address"].ToString()) : "",
                        PhoneNumber = item["PhoneNumber"].ToString()
                    };
                    lstDanhBaCongTy.Add(objDanhBaCongTy);
                }
            }
            dt.Dispose();
            return lstDanhBaCongTy;
        }

        /// <summary>
        /// Tra ve danh sach buu dien
        /// </summary>
        /// <returns></returns>
        public static List<DanhBaCongTy> GetDanhBa_BuuDien_4()
        {
            DataTable dt = new Data.DanhBa().GetDanhBa_BuuDien_4();
            List<DanhBaCongTy> lstDanhBaCongTy = new List<DanhBaCongTy>();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    DanhBaCongTy objDanhBaCongTy = new DanhBaCongTy()
                    {
                        Name = item["Name"] != null && item["Name"].ToString() != "" ? MaHoaDuLieu.GiaiMa(item["Name"].ToString()) : "",
                        Address = item["Address"] != null && item["Address"].ToString() != "" ? MaHoaDuLieu.GiaiMa(item["Address"].ToString()) : "",
                        PhoneNumber = item["PhoneNumber"].ToString()
                    };
                    lstDanhBaCongTy.Add(objDanhBaCongTy);
                }
            }
            dt.Dispose();
            return lstDanhBaCongTy;
        }

        /// <summary>
        /// Tra ve danh sach buu dien
        /// </summary>
        /// <returns></returns>
        public static List<DanhBaCongTy> GetDanhBa_BuuDien_5()
        {
            DataTable dt = new Data.DanhBa().GetDanhBa_BuuDien_5();
            List<DanhBaCongTy> lstDanhBaCongTy = new List<DanhBaCongTy>();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    DanhBaCongTy objDanhBaCongTy = new DanhBaCongTy()
                    {
                        Name = item["Name"] != null && item["Name"].ToString() != "" ? MaHoaDuLieu.GiaiMa(item["Name"].ToString()) : "",
                        Address = item["Address"] != null && item["Address"].ToString() != "" ? MaHoaDuLieu.GiaiMa(item["Address"].ToString()) : "",
                        PhoneNumber = item["PhoneNumber"].ToString()
                    };
                    lstDanhBaCongTy.Add(objDanhBaCongTy);
                }
            }
            dt.Dispose();
            return lstDanhBaCongTy;
        }

        /// <summary>
        /// tra ve so dient hoai toi thieu
        ///  input : 0437856099,0905228313,01689581628
        ///  output: 37856099,905228313,1689581628
        /// 
        /// </summary>
        /// <param name="PhoneNumber"></param>
        /// <returns></returns>
        public static string GetSoDienThoaiToiThieu(string PhoneNumber)
        {
            if (PhoneNumber.Length <= 8) return PhoneNumber;
            
            if (DanhBa.IsDienThoaiCoDinh (PhoneNumber))
            {
                if (PhoneNumber.Length > 8)
                    return PhoneNumber.Substring(PhoneNumber.Length - 8, 8);
            }
            if (DanhBa.IsDienThoaiDiDong(PhoneNumber))
            {
                if (PhoneNumber.Substring(0, 1) == "0")
                    return PhoneNumber.Substring(1, PhoneNumber.Length - 1);
            }

            return PhoneNumber;
        }



        #endregion Methods
    }
}
