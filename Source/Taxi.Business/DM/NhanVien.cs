using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Taxi.Business.DM
{
 public  class NhanVien
 {
     #region Properties
     private string mMaNhanVien;

     public string MaNhanVien
     {
         get { return mMaNhanVien; }
         set { mMaNhanVien = value; }
     }
     private string mTenNhanVien;

     public string TenNhanVien
     {
         get { return mTenNhanVien; }
         set { mTenNhanVien = value; }
     }
     private DateTime? mNgaySinh;

     public DateTime? NgaySinh
     {
         get { return mNgaySinh; }
         set { mNgaySinh = value; }
     }
     /// <summary>
     /// Gioi tinh, true : Nam; false Nu
     /// </summary>
     private bool mGioiTinh;

     public bool GioiTinh
     {
         get { return mGioiTinh; }
         set { mGioiTinh = value; }
     }
     private string mSoCMT;

     public string SoCMT
     {
         get { return mSoCMT; }
         set { mSoCMT = value; }
     }
     private string mDiaChi;

     public string DiaChi
     {
         get { return mDiaChi; }
         set { mDiaChi = value; }
     }

     private string mDienThoai;

     public string DienThoai
     {
         get { return mDienThoai; }
         set { mDienThoai = value; }
     }
     private string mDiDong;

     public string DiDong
     {
         get { return mDiDong; }
         set { mDiDong = value; }
     }
     private string mEmail;

     public string Email
     {
         get { return mEmail; }
         set { mEmail = value; }
     }
     private string mVanBang;

     public string VanBang
     {
         get { return mVanBang; }
         set { mVanBang = value; }
     }

     private int mPhongID;

     public int PhongID
     {
         get { return mPhongID; }
         set { mPhongID = value; }
     }
     private int mChucVu;

     public int ChucVuID
     {
         get { return mChucVu; }
         set { mChucVu = value; }
     }
     private string mSoHieuXeLai;

     public string SoHieuXeLai
     {
         get { return mSoHieuXeLai; }
         set { mSoHieuXeLai = value; }
     }
     private string mSoTheLaiXe;

     public string SoTheLaiXe
     {
         get { return mSoTheLaiXe; }
         set { mSoTheLaiXe = value; }
     }
     private DateTime _NgayTiepNhan;

     public DateTime NgayTiepNhan
     {
         get { return _NgayTiepNhan; }
         set { _NgayTiepNhan = value; }
     }
     #endregion Properties

     #region Constructors
     public NhanVien()
     { }
     public NhanVien(string MaNhanVien, string TenNhanVien, DateTime NgaySinh, bool GioiTinh,string SoCMT,string DiaChi, string DienThoai,  string DiDong,  string Email, string VanBang, int PhongID, int ChucVuID, string SoHieuXeLai,string SoTheLaiXe)
     {
         this.MaNhanVien = MaNhanVien;
         this.TenNhanVien = TenNhanVien;
         this.NgaySinh = NgaySinh;
         this.GioiTinh = GioiTinh;
         this.SoCMT = SoCMT;
         this.DiaChi = DiaChi;
         this.DienThoai = DienThoai;
         this.DiDong = DiDong;
         this.Email = Email;
         this.VanBang = VanBang;
         this.PhongID = PhongID;
         this.ChucVuID = ChucVuID;
         this.SoHieuXeLai = SoHieuXeLai;
         this.SoTheLaiXe = SoTheLaiXe;
     }
     #endregion Constructors

     public bool Insert()
     {
         return new Data.DM.NhanVien().Insert(this.MaNhanVien, this.TenNhanVien, this.NgaySinh??DateTime.Now,this.GioiTinh , this.SoCMT, this.DiaChi, this.DienThoai, this.DiDong, this.Email, this.VanBang, this.PhongID, this.ChucVuID, this.SoHieuXeLai,this.SoTheLaiXe );           
     }

     public bool Update()
     {
         return new Data.DM.NhanVien().Update(this.MaNhanVien, this.TenNhanVien, this.NgaySinh ?? DateTime.Now, this.GioiTinh, this.SoCMT, this.DiaChi, this.DienThoai, this.DiDong, this.Email, this.VanBang, this.PhongID, this.ChucVuID, this.SoHieuXeLai, this.SoTheLaiXe);           
     }

     public List<NhanVien> GetListNhanViens()
     {
         try
         {
             DataTable dt = new DataTable();
             List<NhanVien> lstNhanVien = new List<NhanVien>();

             dt = new Data.DM.NhanVien().GetDanhSachNhanViens(string.Empty);
             if (dt.Rows.Count > 0)
             {
                 foreach (DataRow dr in dt.Rows)
                 {
                     NhanVien objNV = new NhanVien();
                     objNV.MaNhanVien = dr["PK_MaNhanVien"].ToString();
                     objNV.TenNhanVien = dr["TenNhanVien"].ToString();
                     if (dr["NgaySinh"] != null && dr["NgaySinh"]!=DBNull.Value)
                     objNV.NgaySinh = DateTime.Parse(dr["NgaySinh"].ToString());
                     objNV.GioiTinh = dr["GioiTinh"].ToString() == "1" ? true : false;
                     objNV.SoCMT = dr["SoCMT"].ToString();
                     objNV.DiaChi = dr["DiaChi"].ToString();
                     objNV.DienThoai = dr["DienThoai"].ToString();
                     objNV.DiDong = dr["DiDong"].ToString();
                     objNV.Email = dr["Email"].ToString();
                     objNV.VanBang = dr["VanBang"].ToString();
                     if (dr["FK_PhongID"] != null && dr["FK_PhongID"] != DBNull.Value)
                     objNV.PhongID = int.Parse(dr["FK_PhongID"].ToString());
                     if (dr["FK_ChucVu"] != null && dr["FK_ChucVu"] != DBNull.Value)
                     objNV.ChucVuID = int.Parse(dr["FK_ChucVu"].ToString());
                     objNV.SoHieuXeLai = dr["FK_SoHieuXeLai"].ToString().Trim();
                     objNV.SoTheLaiXe = dr["SoTheLaiXe"].ToString().Trim(); 
                     lstNhanVien.Add(objNV);

                 }
                 return lstNhanVien;
             }
             else return null;
         }
         catch (Exception ex)
         {
             return null;
         }
        
     }

     public NhanVien GetDetailsNhanVien(string MaNhaVien)
     {
         try
         {
             DataTable dt = new DataTable();
            

             dt = new Data.DM.NhanVien().GetDanhSachNhanViens(string.Empty);
             if (dt.Rows.Count > 0)
             {
                 DataRow dr = dt.Rows[0];

                 //  @PK_MaNhanVien char(6),
                 // @TenNhanVien nvarchar(50),
                 // @NgaySinh datetime,
                 //@SoCMT varchar(15),
                 //@DiaChi nvarchar(50),
                 // @DienThoai char(15),
                 // @DiDong char(15),
                 // @Email nvarchar(50),
                 //@VanBang nvarchar(50),
                 //@FK_PhongID int,
                 //@FK_ChucVu int,
                 //@FK_SoHieuXeLai char(4)
                 NhanVien objNV = new NhanVien();
                 objNV.MaNhanVien = dr["PK_MaNhanVien"].ToString();
                 objNV.TenNhanVien = dr["TenNhanVien"].ToString();
                 objNV.NgaySinh = DateTime.Parse(dr["NgaySinh"].ToString());
                 objNV.GioiTinh = dr["GioiTinh"].ToString() == "1" ? true : false;
                 objNV.SoCMT = dr["SoCMT"].ToString();
                 objNV.DiaChi = dr["DiaChi"].ToString();
                 objNV.DienThoai = dr["DienThoai"].ToString();
                 objNV.DiDong = dr["DiDong"].ToString();
                 objNV.Email = dr["Email"].ToString();
                 objNV.VanBang = dr["VanBang"].ToString();
                 objNV.PhongID = int.Parse(dr["FK_PhongID"].ToString());
                 objNV.ChucVuID = int.Parse(dr["FK_ChucVu"].ToString());
                 objNV.SoHieuXeLai = dr["FK_SoHieuXeLai"].ToString();
                 objNV.SoTheLaiXe = dr["SoTheLaiXe"].ToString(); 
                 return objNV;
             }
             else
                 return null;
         }
         catch (Exception ex)
         {
             return null;
         }
        
     }

     /// <summary>
     /// tra về thongn tin cua lai xe, khi nhap thong tin MaTheLaixe
     /// </summary>
     /// <param name="MaTheLaiXe"></param>
     /// <returns></returns>
     public static NhanVien GetNhanVienByTheLaiXe(string SoTheLaiXe)
     {
         try
         {
             DataTable dt = new DataTable();


             dt = new Data.DM.NhanVien().GetNhanVienByTheLaiXe(SoTheLaiXe);
             if (dt.Rows.Count > 0)
             {
                 DataRow dr = dt.Rows[0];

                 //  @PK_MaNhanVien char(6),
                 // @TenNhanVien nvarchar(50),
                 // @NgaySinh datetime,
                 //@SoCMT varchar(15),
                 //@DiaChi nvarchar(50),
                 // @DienThoai char(15),
                 // @DiDong char(15),
                 // @Email nvarchar(50),
                 //@VanBang nvarchar(50),
                 //@FK_PhongID int,
                 //@FK_ChucVu int,
                 //@FK_SoHieuXeLai char(4)
                 NhanVien objNV = new NhanVien();
                 objNV.MaNhanVien = dr["PK_MaNhanVien"].ToString();
                 objNV.TenNhanVien = dr["TenNhanVien"].ToString();
                 objNV.NgaySinh = DateTime.Parse(dr["NgaySinh"].ToString());
                 objNV.GioiTinh = dr["GioiTinh"].ToString() == "1" ? true : false;
                 objNV.SoCMT = dr["SoCMT"].ToString();
                 objNV.DiaChi = dr["DiaChi"].ToString();
                 objNV.DienThoai = dr["DienThoai"].ToString();
                 objNV.DiDong = dr["DiDong"].ToString();
                 objNV.Email = dr["Email"].ToString();
                 objNV.VanBang = dr["VanBang"].ToString();
                 objNV.PhongID = int.Parse(dr["FK_PhongID"].ToString());
                 objNV.ChucVuID = int.Parse(dr["FK_ChucVu"].ToString());
                 objNV.SoHieuXeLai = dr["FK_SoHieuXeLai"].ToString();
                 objNV.SoTheLaiXe = dr["SoTheLaiXe"].ToString();
                 return objNV;
             }
             else
                 return null;
         }
         catch (Exception ex)
         {
             return null;
         }

     }

     public static List<NhanVien> GetNhanVienSearch(string thongTinTimKiem)
     {
         try
         {
             DataTable dt = new DataTable();


             dt = new Data.DM.NhanVien().GetNhanVienSearch(thongTinTimKiem);
             if (dt.Rows.Count > 0)
             {
                 List<NhanVien> lstNhanVien = new List<NhanVien>();
                 foreach (DataRow dr in dt.Rows)
                 {
                     NhanVien objNV = new NhanVien();
                     objNV.MaNhanVien = dr["PK_MaNhanVien"].ToString();
                     objNV.TenNhanVien = dr["TenNhanVien"].ToString();
                     objNV.GioiTinh = dr["GioiTinh"].ToString() == "1" ? true : false;
                     objNV.SoCMT = dr["SoCMT"].ToString();
                     objNV.DiaChi = dr["DiaChi"].ToString();
                     objNV.DienThoai = dr["DienThoai"].ToString();
                     objNV.DiDong = dr["DiDong"].ToString();
                     objNV.Email = dr["Email"].ToString();
                     objNV.VanBang = dr["VanBang"].ToString();
                     objNV.SoHieuXeLai = dr["FK_SoHieuXeLai"].ToString();
                     objNV.SoTheLaiXe = dr["SoTheLaiXe"].ToString();
                     lstNhanVien.Add(objNV);
                 }
                 return lstNhanVien;
             }
             else
                 return null;
         }
         catch (Exception ex)
         {
             return null;
         }

     }
     /// <summary>
     /// check thong tin ma the lai xe da ton tai chua
     /// </summary>
     /// <param name="SoTheLaiXe"></param>
     /// <returns></returns>
     public static bool CheckTheLaiXeTonTai(string SoTheLaiXe)
     {
         try
         {
             DataTable dt = new DataTable();


             dt = new Data.DM.NhanVien().GetNhanVienByTheLaiXe(SoTheLaiXe);
             if ((dt != null) && (dt.Rows.Count > 0))
             {
                 return true;
             }
             else return false;

         }
         catch (Exception ex)
         {
             return false;
         }
     }

     public bool Delete(string MaNhanVien)
     {
         return new Data.DM.NhanVien().Delete(MaNhanVien);   
     }

     /// <summary>
     /// Sinh ma doi tac, neuchua co thi gan la NV0001
     /// Neu co roi thi lay max + 1
     /// </summary>
     /// <returns>Ma tiep theo</returns>
     public static string GetNextMaNhanVien()
     {
         try
         {
             string strMaxKey = new Data.DM.NhanVien().GetMaxKeyNhanVien();
             string strNextKey = string.Empty;

             if (strMaxKey.Length >= 6)
             {
                 string sID = strMaxKey.Substring(2, 4);
                 long ID = long.Parse(sID);
                 ID += 1;
                 sID = ID.ToString();
                 while (sID.ToString().Length < 4)
                 {
                     sID = "0" + sID;
                 }
                 return "NV" + sID;
             }
             else
             {
                 return "NV0001"; // ma dau tien
             }
         }
         catch (Exception ex)
         {
             return string.Empty;
         }
     }
     /// <summary>
     /// sinh mã nhân viên tiếp theo
     /// </summary>
     /// <returns></returns>
     public static string GetNextMaNhanVienV2()
     {
         //const string strMaNV = "NV";
         //try
         //{
         //    string strMaxKey = new Data.DM.NhanVien().GetMaxKeyNhanVienV2(strMaNV);

         //    if (strMaxKey.Length >= 6)
         //    {
         //        string sID = strMaxKey.Substring(3, strMaxKey.Length - 3);
         //        long ID = long.Parse(sID);

         //        ID += 1;

         //        string sID_Temp = ID.ToString();
         //        while (sID_Temp.Length < sID.Length)
         //        {
         //            sID_Temp = "0" + sID_Temp;
         //        }
         //        return strMaNV + "xx" + sID_Temp;
         //    }
         //    else
         //    {
         //        return strMaNV + "0001"; // ma dau tien
         //    }
         //}
         //catch (Exception ex)
         //{
         //    return string.Empty;
         //}
         return new Data.DM.NhanVien().GetMaxKeyNhanVienV2();
     }
     /// <summary>
     /// ham thuc hien tim kiem trong tin ve nhan vien
     /// voi tham so dau vao la mot cau lenh sql can tim kiem
     /// </summary>
     /// <param name="strSQL"></param>
     /// <returns></returns>
     public static List<NhanVien> GetNhanViens(string strSQL)
     {
         try
         {
             DataTable dt = new DataTable();
             List<NhanVien> lstNhanVien = new List<NhanVien>();

             dt = new Data.DM.NhanVien().GetNhanViens(strSQL);
             if (dt.Rows.Count > 0)
             {
                 foreach (DataRow dr in dt.Rows)
                 {
                     //  @PK_MaNhanVien char(6),
                     // @TenNhanVien nvarchar(50),
                     // @NgaySinh datetime,
                     //@SoCMT varchar(15),
                     //@DiaChi nvarchar(50),
                     // @DienThoai char(15),
                     // @DiDong char(15),
                     // @Email nvarchar(50),
                     //@VanBang nvarchar(50),
                     //@FK_PhongID int,
                     //@FK_ChucVu int,
                     //@FK_SoHieuXeLai char(4)
                     NhanVien objNV = new NhanVien();
                     objNV.MaNhanVien = dr["PK_MaNhanVien"].ToString();
                     objNV.TenNhanVien = dr["TenNhanVien"].ToString();
                     DateTime ngaySinh;
                     DateTime.TryParse(dr["NgaySinh"].ToString(), out ngaySinh);
                     objNV.NgaySinh = ngaySinh;
                     objNV.GioiTinh = dr["GioiTinh"].ToString() == "1" ? true : false;
                     objNV.SoCMT = dr["SoCMT"].ToString();
                     objNV.DiaChi = dr["DiaChi"].ToString();
                     objNV.DienThoai = dr["DienThoai"].ToString();
                     objNV.DiDong = dr["DiDong"].ToString();
                     objNV.Email = dr["Email"].ToString();
                     objNV.VanBang = dr["VanBang"].ToString();
                     int phongID;
                     int.TryParse(dr["FK_PhongID"].ToString(), out phongID);
                     objNV.PhongID = phongID;
                     int chucVuID; int.TryParse(dr["FK_ChucVu"].ToString(), out chucVuID);
                     objNV.ChucVuID = chucVuID;
                     objNV.SoHieuXeLai = dr["FK_SoHieuXeLai"].ToString();
                     objNV.SoTheLaiXe = dr["SoTheLaiXe"].ToString();
                     lstNhanVien.Add(objNV);
                 }
                 return lstNhanVien;
             }
             else return null;
         }
         catch (Exception ex)
         {
             return null;
         }
        
     }
 }
}
