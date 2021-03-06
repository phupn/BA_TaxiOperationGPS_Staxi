using System;
using System.Data;
using System.Data.SqlClient;
using Taxi.Utils;

namespace Taxi.Data
{
    /// <summary>
    /// Quản lý vai trò của người dùng : Thêm, xóa vai tro cho 1 người dùng, nhóm người dùng
    /// </summary>
    /// <Modìied>
    /// Name                 date        comments
    /// Cuongdb              ????       copy from Kiem toan
    /// </Modìied>
    public class UserRole : DBObject
	{
		public UserRole()
		{			
		}
        /// <summary>
        /// Lấy danh sách các vai trò mà người dùng được cấp
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????         copy from Kiem toan
        /// </Modìied>
		public DataTable GetUserRole( string mUserName )
		{
			SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@mUSER_ID", SqlDbType.NVarChar, 50)};
			parameters[0].Value = mUserName;
			
			DataSet ds = new DataSet();
			ds = this.RunProcedure("SP_SYS_USER_ROLE_SELECT", parameters, "tabUserRole");
			DataTable dt = ds.Tables[0];
			ds.Dispose();
			ds = null;
			return dt;
		}
        /// <summary>
        /// Lấy danh sách vai trò mà người dùng chưa được cấp
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       tạo mới
        /// </Modìied>
        public DataTable GetRoleNotInUser(string mUserName)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@mUSER_ID", SqlDbType.NVarChar, 50) };
            parameters[0].Value = mUserName;

            DataSet ds = new DataSet();
            ds = this.RunProcedure("SP_SYS_USER_ROLE_SELECT_ROLE_NOT_IN_USER", parameters, "tabUserRole");
            DataTable dt = ds.Tables[0];
            ds.Dispose();
            ds = null;
            return dt;
        }
        /// <summary>
        /// Lấy danh sách người dùng trong cùng 1 phòng có cùng vai trò truyền vào
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       tạo mới
        /// </Modìied>
		public DataTable GetUserByRole(string mRoleID,int PhongID)
		{
			SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@mROLE_ID", SqlDbType.NVarChar, 50),new SqlParameter("@PhongID", SqlDbType.Int)};
			parameters[0].Value = mRoleID;
            parameters[1].Value = PhongID;		
			DataSet ds = new DataSet();
			ds = this.RunProcedure("SP_SYS_USER_ROLE_SEL_BY_ROLE", parameters, "tabUserRole");
			DataTable dt = ds.Tables[0];
			ds.Dispose();
			ds = null;
			return dt;
		}
        /// <summary>
        /// Lấy danh sách người dùng khong có trong vai trò thuọc cùng phòng truyền vào
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       tạo mới
        /// </Modìied>
        public DataTable GetUserNotInRole(string mRoleID,int PhongID)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@mROLE_ID", SqlDbType.NVarChar, 50), new SqlParameter("@PhongID", SqlDbType.Int) };
            parameters[0].Value = mRoleID;
            parameters[1].Value = PhongID;		
            DataSet ds = new DataSet();
            ds = this.RunProcedure("SP_SYS_USER_ROLE_SEL_NOT_IN_ROLE", parameters, "tabUserNotInRole");
            DataTable dt = ds.Tables[0];
            ds.Dispose();
            ds = null;
            return dt;
        }

        /// <summary>
        /// Thêm mới 1 số người dùng vào vai trò này
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       tạo mới
        /// </Modìied>
		public int InsertUserByRole(string mRoleID, string mUserIDs, string mUserIDsDel, string mGrantUserID)
		{
			SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@mROLE_ID", SqlDbType.NVarChar, 50), 
                new SqlParameter("@mUSER_IDs", SqlDbType.NVarChar, 4000), 
                new SqlParameter("@mUSER_IDs_DEL", SqlDbType.NVarChar, 4000), 
                new SqlParameter("@mGRANT_USER_ID", SqlDbType.NVarChar, 50) };
			parameters[0].Value = mRoleID;
			parameters[1].Value = mUserIDs;
			parameters[2].Value = mUserIDsDel;
			parameters[3].Value = mGrantUserID;
            try
            {
                this.RunProcedure("SP_SYS_USER_ROLE_INS_BY_ROLE", parameters);
                return 0;
            }
            catch (Exception ex)
            {
                return -1;
            }
			
		}
        /// <summary>
        /// Cấp mới 1 số vai trò cho người dùng
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       tạo mới
        /// </Modìied>
		public int InsertUserRole(string mUserName, string mRoleIDs, string mGrantOptions, string mGrantUserID)
		{
			int rowAffected;
			SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@mUSER_ID", SqlDbType.NVarChar, 50), new SqlParameter("@mROLE_IDs", SqlDbType.NVarChar, 4000), new SqlParameter("@mGRANT_OPTIONs", SqlDbType.NVarChar, 4000), new SqlParameter("@mGRANT_USER_ID", SqlDbType.NVarChar, 50) };
			parameters[0].Value = mUserName;
			parameters[1].Value = mRoleIDs;
			parameters[2].Value = mGrantOptions;
			parameters[3].Value = mGrantUserID;
			try
			{
				RunProcedure("SP_SYS_USER_ROLE_INSERT", parameters);
				rowAffected = 0;
			}
			catch (SqlException ex)
			{
				rowAffected = ex.ErrorCode;				
			}
			return rowAffected;
		}
        /// <summary>
        /// Xóa một số vai trò của người dùng 
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       tạo mới
        /// </Modìied>
        public int DeleteUserSomeRole(string mUserName, string mRoleIDs)
        {
            int rowAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@mUSER_ID", SqlDbType.NVarChar, 50), new SqlParameter("@mROLE_IDs", SqlDbType.NVarChar, 4000)};
            parameters[0].Value = mUserName;
            parameters[1].Value = mRoleIDs;
            try
            {
                RunProcedure("SP_SYS_USER_SOME_ROLE_DELETE", parameters);
                rowAffected = 0;
            }
            catch (SqlException ex)
            {
                rowAffected = ex.ErrorCode;
            }
            return rowAffected;
        }

        // Cập nhật vai trò của người dùng
        public int UpdateUserRole(string mUserName, string mRoleID, string mGrantOption, string mGrantUserID)
		{
			int rowAffected;
			SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@mUSER_ID", SqlDbType.NVarChar, 50), new SqlParameter("@mROLE_ID", SqlDbType.Char, 9), new SqlParameter("@mGRANT_OPTION", SqlDbType.Char, 1), new SqlParameter("@mGRANT_USER_ID", SqlDbType.NVarChar, 50) };
			parameters[0].Value = mUserName;
			parameters[1].Value = mRoleID;
			parameters[2].Value = mGrantOption;
			parameters[3].Value = mGrantUserID;
			try
			{
				RunProcedure("SP_SYS_USER_ROLE_UPDATE", parameters);
				rowAffected = 0;
			}
			catch (SqlException ex)
			{
				rowAffected = ex.ErrorCode;				
			}
			return rowAffected;
		}

        /// <summary>
        /// Xóa tất cả quyền của người dùng
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       tạo mới
        /// </Modìied>
		public int DeleteUserRole(string mUserName /* = "" */, string mGrantUserID /* = "" */)
		{
			SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@mUSER_ID", SqlDbType.NVarChar, 50), new SqlParameter("@mGRANT_USER_ID", SqlDbType.NVarChar, 50) };
			parameters[0].Value = mUserName;
			parameters[1].Value = mGrantUserID;
            try
            {
                this.RunProcedure("SP_SYS_USER_ROLE_DELETE", parameters);
                return 0;
            }
            catch 
            {
                return -1;
            }
			
		}
        /// <summary>
        /// Xóa tất cả người dùng trong vai trò truyền vào
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       tạo mới
        /// </Modìied>
		public int DeleteUserByRole( string mRoleID /* = "" */)
		{
			SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@mROLE_ID", SqlDbType.NVarChar, 50) };
			parameters[0].Value = mRoleID;
            try
            {
                this.RunProcedure("SP_SYS_USER_ROLE_DEL_BY_ROLE", parameters);
                return 0;
            }
            catch 
            {
                return -1;
            }
			
		}
	}
}
