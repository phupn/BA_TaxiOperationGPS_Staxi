using System;
using System.Data;
 
using System.Text.RegularExpressions;
using Taxi.Utils;
namespace Taxi.Business
{
    /// <summary>
    /// Quản lý người dùng : Thêm, sửa, xóa người dùng.
    /// Cấp quyên, vai trò cho người dùng .....
    /// </summary>
    /// <modified>
    /// Người tạo            Ngày tạo            chú thích
    /// Cuongdb                ????              Edit from KiemToan
    /// </modified>
	public class Users
	{
        // Khai báo các tham biến
		private string mFullName;
		private bool mGrantCount;
		private string mLDAPAdsPath = "";
		private string mPassWord;
		private string mPassWordOld;
		private int mSecurityLevel = 0;
		private string mStatus;
		private string mUserName;
		private string mUserNameOld;
        private DateTime mNgaySinh;
        private bool mGioiTinh;
        private string mDiaChi;
        private string mQueQuan;
        private string mDienThoai;
        private string mTenPhong;
        private string mTenChucVu;
        private string mEmail;
        private int mChucVuID;
        private int mPhongID;
        private int mTrungTamID;
		private Taxi.Data.Users objUsers;

        #region Các thuộc tính của người dùng
        public string FullName
		{
			get{return mFullName;}
			set{mFullName = value;}
		}
 
		public int GrantCount
		{
			get{return GrantCount;}
		}
 
		public string LDAPAdsPath
		{
            get { return mLDAPAdsPath; }
            set { mLDAPAdsPath = value; }
		}
        public int TrungTamID
        {
            get { return mTrungTamID; }
            set { mTrungTamID = value; }
        }
		public string PassWord
		{
			set{
				if (mPassWordOld == value)
				{
					mPassWord = value;
				}
				else
				{
					mPassWord = StringTools.EncryptPassword(value);
				}
			}
			get
			{
				return mPassWord;
			}
		}
 
		public string PassWordOld
		{
			set{mPassWordOld = value;}
            get { return mPassWordOld; }
		}
        
		public int SecurityLevel
		{
			get{return mSecurityLevel;}
			set{mSecurityLevel = value;}
		}
 
		public string Status
		{
			get{return mStatus;}
			set{mStatus = value;}
		}

		public string UserName
		{
			set{mUserName = value;}
            get { return mUserName; }
		}
 
		public string UserNameOld
		{
			set{mUserNameOld = value;}
		}

        public string Email
        {
            get { return mEmail; }
            set { mEmail = value; }
        }

        public DateTime NgaySinh 
        {
            get { return mNgaySinh; }
            set { mNgaySinh = value; }
        }

        public bool GioiTinh 
        {
            get { return mGioiTinh; }
            set { mGioiTinh = value; }
        }

        public string DiaChi 
        {
            get { return mDiaChi; }
            set { mDiaChi = value; }
        }

        public string QueQuan 
        {
            get { return mQueQuan; }
            set { mQueQuan = value; }
        }

        public string DienThoai 
        {
            get { return mDienThoai; }
            set { mDienThoai = value; }
        }

        public string TenPhong 
        {
            get { return mTenPhong; }
            set { mTenPhong = value; }
        }

        public string TenChucVu 
        {
            get { return mTenChucVu; }
            set { mTenChucVu = value; }
        }
        public int ChucVUID
        {
            get { return mChucVuID; }
            set { mChucVuID = value; }
        }
        public int PhongID
        {
            get { return mPhongID; }
            set { mPhongID = value; }
        }
#endregion

		public Users()
		{		
			objUsers = new Taxi.Data.Users(); 
			//objStrings=new Strings(); 
		}
        /// <summary>
        /// Khởi tạo và lấy thông tin người dùng cụ thể
        /// </summary>
        /// <modified>
        /// Người tạo            Ngày tạo            chú thích
        /// Cuongdb                ????              Edit from KiemToan
        /// </modified>
		public Users(string strUserName)
		{			
			objUsers=new Taxi.Data.Users();
			//objStrings=new Strings(); 
			UserName = strUserName;
            DataTable dt  = GetUserInfo(UserName);
			if (dt.Rows.Count >0)
			{
				DataRow dr = dt.Rows[0];
				//mSecurityLevel = dr["SECURITY_LEVEL"].ToString();
				mUserName = dr["USER_ID"].ToString();
				mFullName = dr["FULLNAME"].ToString() ;
                mDiaChi = dr["DiaChi"].ToString();
                mDienThoai = dr["DienThoai"].ToString();
                mQueQuan = dr["QueQuan"].ToString();
                mTenChucVu = dr["TenChucVu"].ToString();
                mTenPhong = dr["TenPhong"].ToString();
                mChucVuID = 1;// int.Parse(dr["ChucVuID"].ToString());
                mPhongID = int.Parse(dr["PhongID"].ToString());
                mEmail = dr["EMAIL"].ToString();
                mPassWordOld = dr["PASSWORD"].ToString();
                mPassWord = dr["PASSWORD"].ToString();
                mStatus = dr["STATUS"].ToString();
                mLDAPAdsPath = dr["LDAP_ADS_PATH"].ToString();
             //   if (dr["TrungTamID"]!= DBNull.Value) mTrungTamID = int.Parse(dr["TrungTamID"].ToString());
                string strGioiTinh = dr["GioiTinh"].ToString();
                if (strGioiTinh.ToUpper() == "TRUE")
                {
                    mGioiTinh = true;
                }
                else mGioiTinh = false;
                try
                {
                    mNgaySinh = (DateTime)dr["NgaySinh"];
                }
                catch { }
            }
		}
        /// <summary>
        /// Lấy danh sách người dùng
        /// </summary>
        /// <modified>
        /// Người tạo            Ngày tạo            chú thích
        /// Cuongdb                ????              Edit from KiemToan
        /// </modified>
		public DataTable GetUser()
		{
			return objUsers.GetUser(ref mGrantCount , mUserName);
		}
        /// <summary>
        /// Lấy thông tin người dùng
        /// Cuongdb     16/2/2008
        /// </summary>
        /// <returns></returns>
        public DataTable GetUserInfo(string strUser_ID)
        {
            return objUsers.GetUserInfo(strUser_ID);
        }
        /// <summary>
        /// Lấy danh sách người dùng bởi người quản trị
        /// </summary>
        /// <modified>
        /// Người tạo            Ngày tạo            chú thích
        /// Cuongdb                ????              Edit from KiemToan
        /// </modified>
		public DataTable GetUserByAdmin() 
		{
			return objUsers.GetUserByAdmin();
        }
        /// <summary>
        /// Lấy danh sách người thuộc 1  phòng ban
        /// </summary>
        /// <modified>
        /// Người tạo            Ngày tạo            chú thích
        /// Cuongdb                ????              Edit from KiemToan
        /// </modified>
        public DataTable LayDanhSachNguoiDungCua1Phong(int PhongID)
        {
            return objUsers.LayDanhSachNguoiDungCua1Phong(PhongID);
        }

        /// <summary>
        /// Lấy danh sách tất cả người dùng
        /// </summary>
        /// <modified>
        /// Người tạo            Ngày tạo            chú thích
        /// Cuongdb                ????              Edit from KiemToan
        /// </modified>
		public DataTable GetAllUser()
		{
            return objUsers.GetAllUser();
		}
        /// <summary>
        /// lấy ds nhân viên là tiếp  thị
        /// </summary>
        /// <returns></returns>
        public DataTable GetDSUserLaTiepThi( )
        {
            return new Data.UserRole().GetUserByRole("NVTT", -1);
        }
        /// <summary>
        /// Kiểm tra đăng nhập người dùng là nhân viên của Cục tần số
        /// </summary>
        /// <param name="UserName">Tên đăng nhập</param>
        /// <param name="Password">Mật khẩu</param>
        /// <returns></returns>
        public int ValidateLogin(string UserName, string Password)
        {
            return objUsers.ValidateLogin(UserName, Password);
        }
        /// <summary>
        /// Get AllUsers and User Info
        /// </summary>
        /// <returns></returns>
        ///<Modified>
        ///     Author      Date        Comments
        ///     Tuanpv    19/02/2008    Tạo mới
        ///</Modified>
        public DataTable GetAllUserInfo() 
        {
            return objUsers.GetAllUserInfo();
        }

        /// <summary>
        /// Get AllUsers and User Info
        /// </summary>
        /// <returns></returns>
        ///<Modified>
        ///     Author      Date        Comments
        ///     Tuanpv    19/02/2008    Tạo mới
        ///</Modified>
        public DataTable GetAllUserInfo_ForReport()
        {
            return objUsers.GetAllUserInfo_ForReport();
        }

        /// <summary>
        /// tạo mới người dùng
        /// </summary>
        /// <modified>
        /// Người tạo            Ngày tạo            chú thích
        /// Cuongdb                ????              Edit from KiemToan
        /// </modified>
		public int InsertUsers()
		{
            return objUsers.InsertUser(mUserName, mPassWord, mFullName, mStatus, mLDAPAdsPath, mSecurityLevel, mEmail, mNgaySinh, mGioiTinh, mDiaChi, mQueQuan, mDienThoai, mPhongID, mChucVuID,mTrungTamID);
		}

        /// <summary>
        /// Cập nhật thông tin người dùng
        /// </summary>
        /// <modified>
        /// Người tạo            Ngày tạo            chú thích
        /// Cuongdb                ????              Edit from KiemToan
        /// </modified>
		public int UpdateUsers() 
		{
            return objUsers.UpdateUser(mUserName, mPassWord, mFullName, mStatus, mLDAPAdsPath, mSecurityLevel, mEmail , mNgaySinh, mGioiTinh, mDiaChi, mQueQuan, mDienThoai, mPhongID, mChucVuID,mTrungTamID);
		}

        /// <summary>
        /// Xóa người dùng
        /// </summary>
        /// <modified>
        /// Người tạo            Ngày tạo            chú thích
        /// Cuongdb                ????              Edit from KiemToan
        /// </modified>
		public int DeleteUsers()
		{
            try
            {
                return objUsers.DeleteUser(mUserName);
            }
            catch(Exception ex) 
            {
                throw ex;
            }
		}
        public const string NOT_VALID_PASSWORD_STRENGTH = "Mật khẩu phải có độ dài >= 6 ký tự!";
        /// <summary>
        /// Kiểm tra độ an toàn của mật khẩu
        /// </summary>
        /// <returns></returns>
        public static bool CheckPasswordStrength(string Password)
        {
            //^            # anchor at the start
            //(?=.*\d)     # must contain at least one numeric character
            //(?=.*[a-z])  # must contain one lowercase character
            //(?=.*[A-Z])  # must contain one uppercase character
            //.{8,10}      # From 8 to 10 characters in length
            //\s           # allows a space 
            //$            # anchor at the end",
            //RegexOptions.IgnorePatternWhitespace
            
            Regex regex = new Regex(@"^          # anchor at the start                                    
                                    .{6,20}      # From 6 to 20 characters in length
                                    $            # anchor at the end",
                                    RegexOptions.IgnorePatternWhitespace); 
             return regex.IsMatch(Password);
        }
        /// <summary>
        /// hamf tra ve cong ty id cua nhan vien tiep thi 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public  static DataTable  GetCongTyIDByUserID(string userName)
        {
            return new Data.Users().GetCongTyIDByUserID(userName);
        }

        /// <summary>
        /// Cập nhật thông tin người dùng
        /// </summary>
        /// <modified>
        /// Người tạo            Ngày tạo            chú thích
        /// thinhpq                20/01/2009              Create new 
        /// </modified>
        public void UpdateOneUser(string UserName, string FullName, string PassWord, string Email)
        {
            Data.Users clsUsers = new Data.Users();
            clsUsers.UpdateOneUser(UserName, FullName, PassWord, Email);
        }

        /// <summary>
        /// Tìm trong ds
        /// hàm trả về ID - Tên nhân viên của một NhanVienID
        /// </summary>
        /// <param name="dtNhanVien"></param>
        /// <param name="NhanVienID"></param>
        /// <returns></returns>
        public  static string  GetTenIDNhanVien(DataTable dtNhanVien, string NhanVienID)
        {
            if (dtNhanVien != null && dtNhanVien.Rows.Count > 0)
            {
                foreach (DataRow dr in dtNhanVien.Rows)
                {
                    if ( dr["USER_ID"].ToString () == NhanVienID)
                    {
                        return   dr["FULLNAME"].ToString();
                    }
                }
            }
            return string.Empty;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="congTyID"></param>
        /// <param name="tonTai"></param>
        /// <returns></returns>
        public DataTable GetQuyenKhaiThacMoiGioi(int congTyID, bool tonTai)
        {
            DataSet ds = new Taxi.Data.Users().GetQuyenKhaiThacMoiGioi(congTyID, tonTai);
            return ds.Tables[0];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="congTyID"></param>
        /// <param name="userID"></param>
        /// <param name="choPhep"></param>
        /// <returns></returns>
        public int InserUpdateNVTiepThi(int congTyID, string userID, bool choPhep)
        {
            return new Taxi.Data.Users().InserUpdateNVTiepThi(congTyID, userID, choPhep);
        }


        #region --------New v3

        /// <summary>
        /// Lấy IPaddress của máy tính theo vùng/kenh
        /// </summary>
        /// <param name="VungKenh"></param>
        /// <returns></returns>
        public static string GetIPByVungKenh(string VungKenh)
        {
            DataTable dt = new Taxi.Data.Users().GetIPByVungKenh(VungKenh);
            if (dt != null && dt.Rows.Count > 0)
                return dt.Rows[0]["Username"].ToString() + "-" + dt.Rows[0]["IPAddress"].ToString();
            else
                return "";
        }
        #endregion
    }
}
