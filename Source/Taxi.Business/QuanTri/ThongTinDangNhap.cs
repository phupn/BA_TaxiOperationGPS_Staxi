using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Taxi.Utils;
using Taxi.Business.QuanTri;

namespace Taxi.Business
{
    /// <summary>
    /// Lấy thông tin đăng nhập của người dùng
    /// Cuongdb     19/2/2008
    /// </summary>
    public class ThongTinDangNhap
    {
        // Khai báo các tham biến
        static string mUserid = "";
        static string mFullName = "";
        static string mTenChucVu = "";
        static string mTenPhong = "";
        static int mPhongID = 0;
        static int mChucVuID = 0;
        static string mEmail = "";
        static string mDiaChi = "";
        static string mQueQuan = "";
        static string mDienThoai = "";
        /// <summary>
        /// Dùng cho cấu hình ExtentionID của openspace Siemens
        /// </summary>
        static string mLDAPPath = "";
        static DateTime mNgaySinh;
        static bool mGioiTinh;

        #region Thuoc Tinh Thong tin nguoi dung he thong
        public static string USER_ID
        {
            get { return mUserid; }
            set { mUserid = value; }
        }
        /// <summary>
        /// Dùng cho cấu hình ExtentionID của openspace Siemens
        /// </summary>
        public static string LDAP_ADS_Path
        {
            get { return mLDAPPath; }
            set { mLDAPPath = value; }
        }
        public static string FULLNAME
        {
            get { return mFullName; }
        }
        public static string TenChucVu
        {
            get { return mTenChucVu; }
        }
        public static string TenPhong
        {
            get { return mTenPhong; }
        }
        public static string Email
        {
            get { return mEmail; }
        }
        public static string DiaChi
        {
            get { return mDiaChi; }
        }
        public static string QueQuan
        {
            get { return mQueQuan; }
        }
        public static string DienThoai
        {
            get { return mDienThoai; }
        }
        public static DateTime NgaySinh
        {
            get { return mNgaySinh; }
        }
        public static bool GioiTinh
        {
            get { return mGioiTinh; }
        }
        public static int ChucVuID
        {
            get { return mChucVuID; }
        }
        public static int PhongID
        {
            get { return mPhongID; }
        }
        #endregion

        #region Thuoc Tinh vai tro va cac quyen trong he thong cua nguoi dung
        protected static ArrayList mPermissionList;

        public static ArrayList Permissions
        {
            get { return mPermissionList; }
        }

        protected static ArrayList mPermissionFullList;
        public static ArrayList PermissionsFull
        {
            get { return mPermissionFullList; }
        }

        protected static ArrayList mRoleList;

        public static ArrayList Roles
        {
            get { return mRoleList; }
        }

        public static string RoleNhanVienPA { get; set; }
        #endregion
        public static string Line_Vung { get; set; }

        /// <summary>
        /// lấy thông tin người dùng, danh sách vai trò và quyền của người dùng trong hệ thống
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    19/2/2008   Tạo mới
        /// </Modified>
        private static void LayThongTinVaiTro_Quyen(string strUserName)
        {
            try
            {
                mPermissionList = new ArrayList();
                mPermissionFullList = new ArrayList();
                mRoleList = new ArrayList();

                UserPermission objUserPermission = new UserPermission();
                UserRole objUserRole = new UserRole();

                objUserPermission.UserName = strUserName;
                // Lấy các quyền của người dùng
                DataTable tabTemp = objUserPermission.GetUserPermission();
                DataTable dtPermissionFull = objUserPermission.GetUserPermissionFull();
                for (int count = 0; count <= dtPermissionFull.Rows.Count - 1; count++)
                {
                    mPermissionFullList.Add(dtPermissionFull.Rows[count]["PERMISSION_ID"]);
                }
                int intCount;
                for (intCount = 0; intCount <= tabTemp.Rows.Count - 1; intCount++)
                {
                    mPermissionList.Add(tabTemp.Rows[intCount]["PERMISSION_ID"]);
                }

                objUserRole.UserName = strUserName;
                // Lấy các vai trò của người dùng
                tabTemp = objUserRole.GetUserRole();

                for (intCount = 0; intCount <= tabTemp.Rows.Count - 1; intCount++)
                    mRoleList.Add(tabTemp.Rows[intCount]["ROLE_ID"].ToString().ToUpper());

                if ((IsInRole(DanhSachVaiTro.NVNHANPHANANH)) &&
                    (IsInRole(DanhSachVaiTro.NVGIAIQUYETPHANANH)) &&
                    (IsInRole(DanhSachVaiTro.NVGIAIQUYETPHANANH_II))
                    )
                {
                    RoleNhanVienPA = "All";
                }
                else if (IsInRole(DanhSachVaiTro.NVGIAIQUYETPHANANH_II))
                {
                    RoleNhanVienPA = DanhSachVaiTro.NVGIAIQUYETPHANANH_II;
                }
                else if (IsInRole(DanhSachVaiTro.NVGIAIQUYETPHANANH))
                {
                    RoleNhanVienPA = DanhSachVaiTro.NVGIAIQUYETPHANANH;
                }
                else if (IsInRole(DanhSachVaiTro.NVNHANPHANANH))
                {
                    RoleNhanVienPA = DanhSachVaiTro.NVNHANPHANANH;
                }
                else RoleNhanVienPA = "";
            }
            catch { }
        }
        /// <summary>
        /// lấy thông tin hành chính, hệ thống người dùng
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    19/2/2008   Tạo mới
        /// </Modified>
        private static void LayThongTinNguoiDung(string strUserName)
        {
            try
            {
                mUserid = strUserName;
                Users objUser = new Users(strUserName);
                mDiaChi = objUser.DiaChi;
                mFullName = objUser.FullName;
                mQueQuan = objUser.QueQuan;
                mTenChucVu = objUser.TenChucVu;
                mTenPhong = objUser.TenPhong;
                mNgaySinh = objUser.NgaySinh;
                mEmail = objUser.Email;
                mDienThoai = objUser.DienThoai;
                mGioiTinh = objUser.GioiTinh;
                mChucVuID = objUser.ChucVUID;
                mPhongID = objUser.PhongID;
                mLDAPPath = objUser.LDAPAdsPath;
            }
            catch { }
        }
        /// <summary>
        /// Kiểm tra người dùng có vai trò này hay không
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    19/2/2008   Tạo mới
        /// </Modified>
        public static bool IsInRole(string role)
        {
            return mRoleList.Contains(role.ToUpper());
        }
        /// <summary>
        /// kiểm tra người dùng có quyền này hay không
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    19/2/2008   Tạo mới
        /// </Modified>
        public static bool HasPermission(string permissionId)
        {
            return mPermissionFullList.Contains(permissionId);
        }
        /// <summary>
        /// Kiểm tra người dùng đăng nhập vào có hợp lệ không
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    19/2/2008    Tạo mới
        /// </Modified>
        public static bool ValidateLogin(string strUserName, string mPassword)
        {
            Data.Users objUsers = new Data.Users();
            string mEncPassWord = StringTools.EncryptPassword(mPassword);
            if (objUsers.ValidateLogin(strUserName, mEncPassWord) > 0)
            {
                LayThongTinVaiTro_Quyen(strUserName);
                LayThongTinNguoiDung(strUserName);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checkin he thong 
        /// </summary>
        public static bool CheckIn(string Username, string IPAddress)
        {
            return new Data.Users().CheckIn(Username, IPAddress);
        }

        #region=== Phần điều sân bay ===
        public static bool CheckIn_V2(string Username, string IPAddress, bool IsDieuSanBay)
        {
            return new Data.Users().CheckIn_V2(Username, IPAddress, IsDieuSanBay);
        }
        /// <summary>
        /// Check có user nào đang điều sân bay không
        /// chỉ cho phép 1 user được điều sân bay tại một thời điểm
        /// </summary>
        /// <returns></returns>
        public static string CheckUserDieuSanBay()
        {
            return new Data.Users().CheckUserDieuSanBay();
        }
        /// <summary>
        /// check user đăng nhập có phải là trưởng ca không
        /// </summary>
        public static bool CheckTruongCa(string userId)
        {
            return new Data.Users().CheckTruongCa(userId);
        }
        #endregion
        /// <summary>
        /// hàm trả về thông tin của máy này 
        /// Máy tính : 192.168.1.20 - Chưa đăng nhập
        /// Máy tính : 192.168.1.20 - dunglt đã đăng nhập
        /// </summary>
        public static string GetThongTinDangNhapCuaMayNay()
        {
            string IP = QuanTriCauHinh.IpAddress;
            string UserID = GetUserDaNgoiMayNayChuaCheckOut(IP);
            if (!string.IsNullOrEmpty(UserID))
                return "Máy tính : " + IP + " - " + UserID + " đã đăng nhập";
            else
                return "Máy tính : " + IP + " - chưa có người đăng nhập";
        }

        /// <summary>
        /// May tinh này đã checkin bưởi một ai đó khác
        /// trả về true :
        /// ngược lại false :
        /// </summary>
        public static bool IsPCCheckInWithOutUser(string Username, string IPAddress)
        {
            return new Data.Users().CheckPCCheckInWithOutUser(Username, IPAddress);
        }
        /// <summary>
        /// Kiem tra User này đã check in vào hệ thong, nhưng tại máy khác
        /// True : Đã checkin
        /// False: Không checkin
        /// </summary>
        public static bool IsUserCheckInAtOtherPC(string Username, string IPAddress)
        {
            return new Data.Users().CheckUserCheckInAtOtherPC(Username, IPAddress);
        }
        /// <summary>
        /// kiểm tra user này có check in lại đúng vị trí máy không ? trường hợp hệ thống mất điện
        ///  user checkin lại hệ thống
        /// </summary>
        public static bool IsUserPostionTrust(string Username, string IPAddress)
        {
            return new Data.Users().CheckPositionOfUserAndIPAddress(Username, IPAddress);
        }
        /// <summary>
        /// checkout khỏi hệ thống
        /// </summary>
        public static bool CheckOut(string Username, string IPAddress)
        {
            return new Data.Users().CheckOut(Username, IPAddress);
        }
        /// <summary>
        /// check out co thiết lập thời gian checkout cưỡng chế
        /// </summary>
        public static bool CheckOutByTime(string Username, string IPAddress, DateTime ThoiDiemCheckOutCuongChe)
        {
            return new Data.Users().CheckOutByTime(Username, IPAddress, ThoiDiemCheckOutCuongChe);
        }

        public static bool CheckOutByIpAddress(string IPAddress)
        {
            return new Data.Users().CheckOutByIpAddress(IPAddress);
        }

        public static string GetUserDaNgoiMayNayChuaCheckOut(string IPAddress)
        {
            return new Data.Users().GetUserDaNgoiMayNayChuaCheckOut(IPAddress);
        }

        /// <summary>
        /// nếu thời điểm kiểm tra là datetime.MinValue thì lấy thời điểm hiện tại
        /// ngược lại thì hiện thị theo thời điểm đó (
        /// </summary>
        public static DataTable GetDSNhungNhanVienLamViec(DateTime TuThoiDiem, DateTime DenThoiDiem)
        {
            return new Data.Users().GetDSNhungNhanVienLamViec(TuThoiDiem, DenThoiDiem);
        }
        /// <summary>
        /// lấy nhưng nhân viên đang lam việc
        /// </summary>
        public static DataTable GetNhungNhanVienDangLamViec()
        {
            return new Data.Users().GetNhungNhanVienDangLamViec();

        }



        /// <summary>
        /// ham tra ve thong tin so luong dang nhap CS trong vung
        /// </summary>
        public static int GetSoLuongCSDangNhapThuocVung(string Vung)
        {
            List<string> lstDSMayCSDangDangNhap = new Data.Users().GetDSMayCSDangNhapThuocVung(Vung);
            if (lstDSMayCSDangDangNhap != null)
                return lstDSMayCSDangDangNhap.Count;
            return 0;
        }
        /// <summary>
        /// hàm trả về ds máy cs đang đăngnhập thuộc vùng.
        /// </summary>
        public static List<string> GetDSMayCSDangDangNhap(string Vung)
        {
            return new Data.Users().GetDSMayCSDangNhapThuocVung(Vung);
        }

        #region -----New v3-----
        /// <summary>
        /// Check out tất cả các user đã đăng nhập vào máy này
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="IPAddress"></param>
        /// <returns></returns>
        public static bool CheckOut_AllInIP(object Username, string IPAddress)
        {
            return new Data.Users().CheckOut_AllInIP(Username, IPAddress);
        }

        /// <summary>
        /// Check out khi đã đăng nhập vào máy khác mà chưa checkout.
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="IPAddress"></param>
        /// <returns></returns>
        public static bool CheckOut_AllIn_OtherIP(object Username, string IPAddress)
        {
            return new Data.Users().CheckOut_AllIn_OtherIP(Username, IPAddress);
        }

        /// <summary>
        /// Lấy vùng/kênh của các user đang login trên hệ thống
        /// </summary>
        /// <returns></returns>
        public static DataTable GetLines_UserLogin()
        {
            return new Data.Users().GetLines_UserLogin();
        }

        public static bool isMayCS1(string IPAddress)
        {
            return new Data.Users().MayCSSo(IPAddress) == 1;
        }

        #endregion
    }
}
