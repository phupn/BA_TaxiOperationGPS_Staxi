using System;
using System.Data;
using System.Data.SqlClient;
using Taxi.Utils;
using System.Collections.Generic;
using Microsoft.ApplicationBlocks.Data;

namespace Taxi.Data
{
    /// <summary>
    /// Quản lý người dùng : Thêm, sửa, xóa người dùng.
    /// Cấp quyên, vai trò cho người dùng .....
    /// </summary>
    /// <modified>
    /// Người tạo            Ngày tạo            chú thích
    /// Cuongdb                ????              Edit from KiemToan
    /// </modified>
    public class Users : DBObject
    {
        private string mLDAPAdsPath;

        public Users()
        {

        }

        public DataTable GetUser(ref bool mGrantCount, string mUserName /* = "" */)
        {

            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@mUSER_ID", SqlDbType.NVarChar, 50), new SqlParameter("@mGRANT_COUNT", SqlDbType.VarChar, 4) };
            parameters[0].Value = mUserName;
            parameters[1].Direction = ParameterDirection.Output;
            DataSet ds = new DataSet();
            ds = this.RunProcedure("SP_SYS_USER_SELECT", parameters, "tblUsers");
            DataTable dt = ds.Tables[0];
            if ((parameters[1].Value != DBNull.Value))
            {
                if (int.Parse(parameters[1].Value.ToString()) > 0)
                {
                    mGrantCount = true;
                }
                else
                {
                    mGrantCount = false;
                }
            }
            ds.Dispose();
            ds = null;
            return dt;
        }

        public DataTable GetUserInfo(string mUserName)
        {

            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@mUSER_ID", SqlDbType.NVarChar, 50) };
            parameters[0].Value = mUserName;
            DataSet ds = new DataSet();
            ds = this.RunProcedure("[SP_SYS_USER_SELECT_INFO]", parameters, "tblUsers");
            DataTable dt = ds.Tables[0];
            ds.Dispose();
            ds = null;
            return dt;
        }
        /// <summary>
        /// Lấy danh sách người dùng bởi người quản trị
        /// </summary>
        public DataTable GetUserByAdmin()
        {
            SqlParameter[] parameters = new SqlParameter[] { };

            DataSet ds = new DataSet();
            ds = this.RunProcedure("SP_SYS_USER_SELECT_BY_ADMIN", parameters, "tblUsers");
            DataTable dt = ds.Tables[0];
            ds.Dispose();
            ds = null;
            return dt;
        }
        /// <summary>
        /// Lấy danh sách người dùng thuộc 1 phòng ban
        /// </summary>
        public DataTable LayDanhSachNguoiDungCua1Phong(int PhongID)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@PhongID", SqlDbType.Int) };
            parameters[0].Value = PhongID;

            DataSet ds = new DataSet();
            ds = this.RunProcedure("SP_SYS_USER_SELECT_1_Phong", parameters, "tblUsers");
            DataTable dt = ds.Tables[0];
            ds.Dispose();
            ds = null;
            return dt;
        }


        /// <summary>
        /// Lấy tất cả người dùng
        /// </summary>
        public DataTable GetAllUser()
        {
            SqlParameter[] parameters = new SqlParameter[] { };
            DataSet ds = new DataSet();
            ds = this.RunProcedure("SP_SYS_USER_SELECT_ALL", parameters, "tblUsers");
            DataTable dt = ds.Tables[0];
            ds.Dispose();
            ds = null;
            return dt;
        }


        /// <summary>
        /// Get AllUsers and User Info
        /// </summary>
        public DataTable GetAllUserInfo()
        {
            SqlParameter[] parameters = new SqlParameter[] { };
            DataSet ds = new DataSet();
            ds = this.RunProcedure("SP_SYS_USER_SELECT_ALL_INCLUDE_INFO", parameters, "tblUsers");
            DataTable dt = ds.Tables[0];
            ds.Dispose();
            ds = null;
            return dt;
        }
        /// <summary>
        /// Get AllUsers and User Info
        /// </summary>
        public DataTable GetAllUserInfo_ForReport()
        {
            SqlParameter[] parameters = new SqlParameter[] { };
            DataSet ds = new DataSet();
            ds = this.RunProcedure("SP_SYS_USER_SELECT_ALL_INCLUDE_INFO_REPORT", parameters, "tblUsers");
            DataTable dt = ds.Tables[0];
            ds.Dispose();
            ds = null;
            return dt;
        }

        /// <summary>
        /// Kiểm tra người dùng đăng nhập vào có hợp lệ không
        /// </summary>
        public int ValidateLogin(string mUserName, string mEncPassword)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@mUSER_ID", SqlDbType.NVarChar, 50), new SqlParameter("@mENCRYPTED_PASSWORD", SqlDbType.NVarChar, 4000), new SqlParameter("@mUSERs", SqlDbType.NVarChar, 4), new SqlParameter("@mLDAP_ADS_PATH", SqlDbType.NVarChar, 4000) };
                parameters[0].Value = mUserName;
                parameters[1].Value = mEncPassword;
                parameters[2].Direction = ParameterDirection.Output;
                parameters[3].Direction = ParameterDirection.Output;
                this.RunProcedure("SP_SYS_USER_VALIDATE", parameters);
                if (!(parameters[3].Value == null))
                {
                    mLDAPAdsPath = parameters[3].Value.ToString();
                }
                else
                {
                    mLDAPAdsPath = "";
                }
                return int.Parse(parameters[2].Value.ToString());
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// Tạo mới người dùng
        /// </summary>
        public int InsertUser(string mUserName, string mEncPassword, string mFullName, string mStatus, string mLDAPAdsPath,
                                int mSecurityLevel, string mEmail, DateTime mNgaySinh, bool mGioiTinh, string mDiaChi,
                                string mQueQuan, string mDienThoai, int mPhongID, int mChucVuID, int mTrungTamID)
        {
            SqlParameter[] parameters = new SqlParameter[] { 
				new SqlParameter("@mUSER_ID", SqlDbType.NVarChar, 50), 
				new SqlParameter("@mPASSWORD", SqlDbType.NVarChar, 4000), 
				new SqlParameter("@mFULLNAME", SqlDbType.NVarChar, 100), 
				new SqlParameter("@mSTATUS", SqlDbType.Char, 1), 
				new SqlParameter("@mLDAP_ADS_PATH", SqlDbType.NVarChar, 4000), 
				new SqlParameter("@mSECURITY_LEVEL", SqlDbType.Int),
                    new SqlParameter("@mEmail", SqlDbType.NVarChar,100),
                    new SqlParameter("@mNgaySinh", SqlDbType.DateTime),
                    new SqlParameter("@mGioiTinh", SqlDbType.Bit),
                    new SqlParameter("@mDiaChi", SqlDbType.NVarChar,255),
                    new SqlParameter("@mQueQuan", SqlDbType.NVarChar,255),
                    new SqlParameter("@mDienThoai", SqlDbType.NVarChar,20),
                    new SqlParameter("@mPhongID", SqlDbType.Int),
                    new SqlParameter("@mChucVuID", SqlDbType.Int) 
                     };
            parameters[0].Value = mUserName;
            parameters[1].Value = mEncPassword;
            parameters[2].Value = mFullName;
            parameters[3].Value = "1";
            parameters[4].Value = mLDAPAdsPath;
            parameters[5].Value = mSecurityLevel;
            parameters[6].Value = mEmail;
            parameters[7].Value = mNgaySinh;
            parameters[8].Value = mGioiTinh;
            parameters[9].Value = mDiaChi;
            parameters[10].Value = mQueQuan;
            parameters[11].Value = mDienThoai;
            parameters[12].Value = mPhongID;
            parameters[13].Value = mChucVuID;
            // if (mTrungTamID != 0) parameters[14].Value = mTrungTamID;
            try
            {
                RunProcedure("sp_SYS_USER_INSERT", parameters);
                return 0;
            }
            catch (Exception ex)
            {
                LogErrorUtils.WriteLogError("InsertUser: ", ex);
                return 1;
            }
        }

        /// <summary>
        /// Cập nhật thông tin thay đổi của người dùng
        /// </summary>
        public int UpdateUser(string mUserName, string mEncPassword,
                                string mFullName, string mStatus, string mLDAPAdsPath,
                                int mSecurityLevel, string mEmail, DateTime mNgaySinh,
                                bool mGioiTinh, string mDiaChi, string mQueQuan,
                                string mDienThoai, int mPhongID, int mChucVuID, int mTrungTamID)
        {

            SqlParameter[] parameters = new SqlParameter[] { 
				new SqlParameter("@mUSER_ID", SqlDbType.NVarChar, 50), 
				new SqlParameter("@mPASSWORD", SqlDbType.NVarChar, 4000), 
				new SqlParameter("@mFULLNAME", SqlDbType.NVarChar, 100), 
				new SqlParameter("@mSTATUS", SqlDbType.Char, 1), 
				new SqlParameter("@mLDAP_ADS_PATH", SqlDbType.NVarChar, 4000), 
				new SqlParameter("@mSECURITY_LEVEL", SqlDbType.Int),
                    new SqlParameter("@mEmail", SqlDbType.NVarChar,100),
                    new SqlParameter("@mNgaySinh", SqlDbType.DateTime),
                    new SqlParameter("@mGioiTinh", SqlDbType.Bit),
                    new SqlParameter("@mDiaChi", SqlDbType.NVarChar,255),
                    new SqlParameter("@mQueQuan", SqlDbType.NVarChar,255),
                    new SqlParameter("@mDienThoai", SqlDbType.NVarChar,20),
                    new SqlParameter("@mPhongID", SqlDbType.Int) 
                    
                     };
            parameters[0].Value = mUserName;
            parameters[1].Value = mEncPassword;
            parameters[2].Value = mFullName;
            parameters[3].Value = mStatus;
            parameters[4].Value = mLDAPAdsPath;
            parameters[5].Value = mSecurityLevel;
            parameters[6].Value = mEmail;
            parameters[7].Value = mNgaySinh;
            parameters[8].Value = mGioiTinh;
            parameters[9].Value = mDiaChi;
            parameters[10].Value = mQueQuan;
            parameters[11].Value = mDienThoai;
            parameters[12].Value = mPhongID;


            try
            {
                RunProcedure("sp_SYS_USER_UPDATE", parameters);
                return 0;
            }
            catch(Exception ex)
            {
                LogErrorUtils.WriteLogError("UpdateUser: ",ex);
                return 1;
            }
        }

        /// <summary>
        /// Xóa một người dùng
        /// </summary>
        public int DeleteUser(string mUserName)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@mUSER_ID", SqlDbType.NVarChar, 50) };
            parameters[0].Value = mUserName;
            try
            {
                RunProcedure("sp_SYS_USER_DELETE", parameters);
                return 0;
            }
            catch(Exception ex)
            {
                LogErrorUtils.WriteLogError("DeleteUser", ex);
                return 1;
            }
        }

        // Cái này chưa dùng trong cục tấn số. Không cần xóa
        public string getLDAPAdsPath
        {
            get
            {
                return (mLDAPAdsPath + "");
            }
        }

        public bool CheckIn(string Username, string IPAddress)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Username",SqlDbType.NVarChar,50),
                    new SqlParameter("@IPAddress",SqlDbType.VarChar,20)                                         
                };
                parameters[0].Value = Username;
                parameters[1].Value = IPAddress;



                rowAffected = this.RunProcedure("sp_T_CHECKIN_CHECKOUT_CheckIn", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool CheckIn_V2(string Username, string IPAddress, bool IsDieuSanBay)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Username",SqlDbType.NVarChar,50),
                    new SqlParameter("@IPAddress",SqlDbType.VarChar,20),
                    new SqlParameter("@IsDieuSanBay",SqlDbType.Bit)                                         
                };
                parameters[0].Value = Username;
                parameters[1].Value = IPAddress;
                parameters[2].Value = IsDieuSanBay;



                rowAffected = this.RunProcedure("sp_T_CHECKIN_CHECKOUT_CheckIn_V2", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }
        /// <summary>
        /// Kiểm tra xem có user nào đang điều sân bay chưa
        /// chỉ cho phép có 1 user được điều sân bay
        /// </summary>
        /// <returns>username </returns>
        public string CheckUserDieuSanBay()
        {
            DataSet ds = new DataSet();
            SqlParameter[] parameters = new SqlParameter[0];
            ds = this.RunProcedure("sp_T_CHECKIN_CHECKOUT_CheckUserDieuSanBay", parameters, "tblUsers");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["Username"].ToString();
            }
            return null;
        }
        /// <summary>
        /// Check xem user đăng nhập có phải là trưởng ca không
        /// </summary>
        public bool CheckTruongCa(string userId)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@userId",SqlDbType.NVarChar,50)                                    
                };
            parameters[0].Value = userId;
            DataSet ds = new DataSet();
            ds = this.RunProcedure("sp_SYS_USER_ROLE_CheckTruongCa", parameters, "tblUsers");
            DataTable dt = ds.Tables[0];
            ds.Dispose();
            ds = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Kiểm tra PC này có đang checkin bởi user khác không
        /// </summary>
        public bool CheckPCCheckInWithOutUser(string Username, string IPAddress)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {                     
                    new SqlParameter("@IPAddress",SqlDbType.VarChar,20),
                    new SqlParameter("@Username",SqlDbType.NVarChar,50),
                    new SqlParameter("@IsExist",SqlDbType.Int)                     
                };

                parameters[0].Value = IPAddress;
                parameters[1].Value = Username;
                parameters[2].Direction = ParameterDirection.Output;
                this.RunProcedure("sp_T_CHECKIN_CHECKOUT_CheckPCCheckInWithOutUser", parameters, rowAffected);
                return (int.Parse(parameters[2].Value.ToString()) > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// kiem tra truoc khi checkout, xem user nay co ngoi dung vi tri khong
        /// true : dang check in
        /// false : may nay hien khong ai check [sp_T_CHECKIN_CHECKOUT_CheckUserCheckInAtOtherPC]
        /// </summary>
        public bool CheckUserCheckInAtOtherPC(string Username, string IPAddress)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {                     
                    new SqlParameter("@IPAddress",SqlDbType.VarChar,20),
                    new SqlParameter("@Username",SqlDbType.NVarChar,50),
                    new SqlParameter("@IsExist",SqlDbType.Int)                     
                };

                parameters[0].Value = IPAddress;
                parameters[1].Value = Username;
                parameters[2].Direction = ParameterDirection.Output;



                this.RunProcedure("sp_T_CHECKIN_CHECKOUT_CheckUserCheckInAtOtherPC", parameters, rowAffected);

                return (int.Parse(parameters[2].Value.ToString()) > 0);
            }
            catch (Exception ex)
            {
                LogErrorUtils.WriteLogError("CheckUserCheckInAtOtherPC: ",ex);
                return false;
            }
        }

        /// <summary>
        /// Kiem tra xem User co nguoi dung vi tri   da check in khong ?
        /// true : dang check in
        /// false : may nay hien khong ai check
        /// </summary>
        public bool CheckPositionOfUserAndIPAddress(string Username, string IPAddress)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {                     
                    new SqlParameter("@IPAddress",SqlDbType.VarChar,20),
                    new SqlParameter("@Username",SqlDbType.NVarChar,50),
                    new SqlParameter("@IsExist",SqlDbType.Int)                     
                };

                parameters[0].Value = IPAddress;
                parameters[1].Value = Username;
                parameters[2].Direction = ParameterDirection.Output;



                this.RunProcedure("[sp_T_CHECKIN_CHECKOUT_CheckUserIPAddressTrust]", parameters, rowAffected);

                return (int.Parse(parameters[2].Value.ToString()) > 0);
            }
            catch (Exception ex)
            {
                LogErrorUtils.WriteLogError("CheckPositionOfUserAndIPAddress: ",ex);
                return false;
            }
        }

        public bool CheckOut(object Username, string IPAddress)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Username",SqlDbType.NVarChar,50),
                    new SqlParameter("@IPAddress",SqlDbType.VarChar,20)                                         
                };
                parameters[0].Value = Username;
                parameters[1].Value = IPAddress;



                rowAffected = this.RunProcedure("sp_T_CHECKIN_CHECKOUT_CheckOut", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool CheckOut_Module(object Username, string IPAddress, string Module)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Username",SqlDbType.NVarChar,50),
                    new SqlParameter("@IPAddress",SqlDbType.VarChar,20),
                    new SqlParameter("@Module",SqlDbType.VarChar,5)
                };
                parameters[0].Value = Username;
                parameters[1].Value = IPAddress;
                parameters[2].Value = Module;

                rowAffected = this.RunProcedure("SP_T_CHECKIN_CHECKOUT_CheckOut_Module", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool CheckOutByTime(string Username, string IPAddress, DateTime ThoiDiemCheckOutCuongChe)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Username",SqlDbType.NVarChar,50),
                    new SqlParameter("@IPAddress",SqlDbType.VarChar,20),  
                    new SqlParameter("@ThoiDiemCheckOutCuongChe",SqlDbType.DateTime),                   
                };
                parameters[0].Value = Username;
                parameters[1].Value = IPAddress;
                parameters[2].Value = ThoiDiemCheckOutCuongChe;

                rowAffected = this.RunProcedure("sp_T_CHECKIN_CHECKOUT_CheckOutByTime", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool CheckOutByIpAddress(string IPAddress)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IPAddress",SqlDbType.VarChar,20)                  
                };
                parameters[0].Value = IPAddress;

                rowAffected = this.RunProcedure("sp_T_CHECKIN_CHECKOUT_CheckOutByIPAddress", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public string GetUserDaNgoiMayNayChuaCheckOut(string IPAddress)
        {
            //[sp_T_CHECKIN_CHECKOUT_GetUserDaNgoiMayNayChuaCheckOut]	  
            //    @IPAddress varchar(20) , 
            //    @Username nvarchar(50) OUTPUT 
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {                   
                    new SqlParameter("@IPAddress",SqlDbType.VarChar,20),  
                    new SqlParameter("@Username",SqlDbType.NVarChar,50)                    
                };
                parameters[0].Value = IPAddress;
                parameters[1].Direction = ParameterDirection.Output;
                this.RunProcedure("sp_T_CHECKIN_CHECKOUT_GetUserDaNgoiMayNayChuaCheckOut", parameters, rowAffected);
                if (parameters[1].Value != null)
                {
                    return parameters[1].Value.ToString();
                }

                return "";
            }
            catch (Exception e)
            {
                return "";
            }
        }

        /// <summary>
        /// lấy những nhân viên đang làm việc tại thời điểm hiện tại
        /// </summary>
        /// <returns></returns>
        public DataTable GetNhungNhanVienDangLamViec()
        {
            SqlParameter[] parameters = new SqlParameter[] { };
            DataSet ds = new DataSet();
            ds = this.RunProcedure("sp_T_CHECKIN_CHECKOUT_GetDSNhanVienDangLamViec", parameters, "tblUsers");
            DataTable dt = ds.Tables[0];
            ds.Dispose();
            ds = null;

            return dt;
        }

        /// <summary>
        /// get nhung nhan viên làm việc trong khoang thoi gian nao đó
        /// </summary>
        /// <param name="TuThoiDiem"></param>
        /// <param name="DenThoiDiem"></param>
        /// <returns></returns>
        public DataTable GetDSNhungNhanVienLamViec(DateTime TuThoiDiem, DateTime DenThoiDiem)
        {
            //[sp_T_CHECKIN_CHECKOUT_GetDSNhanVienLamViecTrongKhoang]		 
            //     @TuThoiDiem DateTime ,
            //     @DenThoiDiem DateTime  
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TuThoiDiem",SqlDbType.DateTime),
                    new SqlParameter("@DenThoiDiem",SqlDbType.DateTime)     
            };
            parameters[0].Value = TuThoiDiem;
            parameters[1].Value = DenThoiDiem;

            DataSet ds = new DataSet();
            ds = this.RunProcedure("sp_T_CHECKIN_CHECKOUT_GetDSNhanVienLamViecTrongKhoang", parameters, "tblUsers");
            DataTable dt = ds.Tables[0];
            ds.Dispose();
            ds = null;

            return dt;
        }


        /// <summary>
        /// tra ve DS IPAddress  may CS dang dang nhap trong vung
        /// </summary>
        /// <param name="Vung"></param>
        /// <returns></returns>
        public List<string> GetDSMayCSDangNhapThuocVung(string Vung)
        {
            List<string> lstIP_CSKH = new List<string>();

            string strSQL = "";
            strSQL += "SELECT [IPAddress]    ";
            strSQL += "FROM [T_CHECKIN_CHECKOUT] WHERE IPAddress <> '127.0.0.1' AND IPAddress IN (	";
            strSQL += "SELECT IP_Address FROM T_QUANTRICAUHINH_HETHONGMAYTINH ";
            strSQL += "WHERE IsMayTinh  ='MK' AND Line_Vung = '" + Vung + "' AND IsHoatDong ='1') AND ThoiDiemCheckOut IS NULL ";
            int retSoLuongCSDangNhap = 0;
            DataTable dt = RunSQL(strSQL, "tb");
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        lstIP_CSKH.Add(dr["IPAddress"].ToString());
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            return lstIP_CSKH;
        }
        /// <summary>
        /// ham lay id cua nhan vien tiep thi
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public DataTable GetCongTyIDByUserID(string userName)
        {
            try
            {
                string sql = "";
                sql += "SELECT FK_CongTyID CongtyID, ct.TenCongTy, uc.UserID , SU.FullName  ";
                sql += " FROM t_user_congty uc ";
                sql += "  INNER JOIN dbo.T_DMCongTy ct ";
                sql += "  ON uc.FK_CongtyID = ct.PK_CongtyID ";
                sql += "  JOIN dbo.SYS_USER SU ";
                sql += "  ON uc.UserID = SU.[USER_ID] ";
                sql += " WHERE UC.UserID = '" + userName + "'";

                DataTable dt = RunSQL(sql, "tbl");
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Cập nhật thông tin thay đổi của người dùng
        /// </summary>
        public void UpdateOneUser(string mUserName, string mFullName, string mEncPassword, string mEmail)
        {

            SqlParameter[] parameters = new SqlParameter[] { 
				new SqlParameter("@mUSER_ID", SqlDbType.NVarChar, 50), 
                new SqlParameter("@mFULLNAME", SqlDbType.NVarChar, 100),
				new SqlParameter("@mPASSWORD", SqlDbType.NVarChar, 4000),				 
                new SqlParameter("@mEmail", SqlDbType.NVarChar,100)};

            parameters[0].Value = mUserName;
            parameters[1].Value = mFullName;
            parameters[2].Value = mEncPassword;
            parameters[3].Value = mEmail;

            try
            {
                SqlHelper.ExecuteNonQuery(this.ConnectionString, "sp_SYS_USER_UPDATE_ONE", parameters);
            }
            catch
            {
                throw new Exception("Có lỗi xảy ra, cập nhật thông tin của người dùng không thực hiện được.");
            }
        }

        public DataSet GetQuyenKhaiThacMoiGioi(int congTyID, bool tonTai)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter ("@CongTyID",SqlDbType.Int ),
                    new SqlParameter ("@TonTai",SqlDbType.Bit)
                };
                parameters[0].Value = congTyID;
                parameters[1].Value = tonTai;
                ds = this.RunProcedure("[SP_GETQUYEN_KHAITHAC_MOIGIOI]", parameters, "tblQuyenMoiGioi");
                return ds;
            }
            catch
            {
                return null;
            }
        }

        public int InserUpdateNVTiepThi(int congTyID, string userID, bool choPhep)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] { 
				    new SqlParameter("@CongTyID", SqlDbType.Int ), 
                    new SqlParameter("@UserID", SqlDbType.NVarChar, 50),
				    new SqlParameter("@ChoPhep", SqlDbType.Bit)				 
                };

                parameters[0].Value = congTyID;
                parameters[1].Value = userID;
                parameters[2].Value = choPhep;


                SqlHelper.ExecuteNonQuery(this.ConnectionString, "[SP_INSERT_DELETE_NVTIEPTHI]", parameters);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        #region ----New v3-----
        /// <summary>
        /// Check out tất cả các user đã đăng nhập vào máy này
        /// </summary>
        public bool CheckOut_AllInIP(object Username, string IPAddress)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Username",SqlDbType.NVarChar,50),
                    new SqlParameter("@IPAddress",SqlDbType.VarChar,20)                                         
                };
                parameters[0].Value = Username;
                parameters[1].Value = IPAddress;

                rowAffected = RunProcedure("sp_T_CHECKIN_CHECKOUT_CheckOut_Force", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch(Exception ex)
            {
                LogErrorUtils.WriteLogError("CheckOut_AllInIP: ",ex);
                return false;
            }
        }

        /// <summary>
        /// Check out khi đã đăng nhập vào máy khác mà chưa checkout.
        /// </summary>
        public bool CheckOut_AllIn_OtherIP(object Username, string IPAddress)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Username",SqlDbType.NVarChar,50),
                    new SqlParameter("@IPAddress",SqlDbType.VarChar,20)                                         
                };
                parameters[0].Value = Username;
                parameters[1].Value = IPAddress;

                rowAffected = RunProcedure("sp_T_CHECKIN_CHECKOUT_CheckOutOtherIPs", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }


        /// <summary>
        /// Lấy vùng/kênh của các user đang login trên hệ thống
        /// </summary>
        public DataTable GetLines_UserLogin()
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] { };
                return (RunProcedure("SP_T_QUANTRICAUHINH_HETHONGMAYTINH_LINEVUNG", parameters, "dtIP")).Tables[0];
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Lấy IPaddress của máy tính theo vùng/kenh
        /// </summary>
        public DataTable GetIPByVungKenh(string VungKenh)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@VungKenh",SqlDbType.VarChar,20)                                       
                };
                parameters[0].Value = VungKenh;
                return (RunProcedure("SP_T_QUANTRICAUHINH_HETHONGMAYTINH_GetIPByKenhVung", parameters, "dtIP")).Tables[0];
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Danh sach may CS thuoc Vung
        /// </summary>
        public byte MayCSSo(string IPAddress)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter("@IPAddress", SqlDbType.VarChar, 15),
                    new SqlParameter("@MK", SqlDbType.TinyInt)
                };
                parameters[0].Value = IPAddress;
                parameters[1].Direction = ParameterDirection.Output;
                RunProcedure("SP_T_T_QUANTRICAUHINH_HETHONGMAYTINH_SELECT_MK", parameters, "dtIP");
                return Convert.ToByte(parameters[1].Value);
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        #endregion
    }
}
