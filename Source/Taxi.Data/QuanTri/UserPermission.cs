using System;
using System.Data;
using System.Data.SqlClient;
using Taxi.Utils;

namespace Taxi.Data
{
    /// <summary>
    /// Quản lý các quyền của người dùng: thêm, xóa quyền của người dùng 
    /// </summary>
    /// <Modìied>
    /// Name                 date        comments
    /// Cuongdb              ????       copy and edit from Kiểm toán
    /// </Modìied>
    public class UserPermission : DBObject
	{
		public UserPermission()
		{			
		}
        /// <summary>
        /// Lấy các quyền của người dùng
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       tạo mới
        /// </Modìied>
		public DataTable GetUserPermission( string mUserName)
		{
			SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@mUSER_ID", SqlDbType.NVarChar, 50)};
			parameters[0].Value = mUserName;			
			DataSet ds = new DataSet();
            ds = RunProcedure("sp_SYS_USER_PERMISSION_SELECT", parameters, "tabUserPermission");
			return ds.Tables[0];
		}

        /// <summary>
        /// Lấy các quyền (cả quyền trong vai trò) của người dùng
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// LONGNM              06/05/2008       tạo mới
        /// </Modìied>
        public DataTable GetUserPermissionFull(string mUserName)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@mUSER_ID", SqlDbType.NVarChar, 50) };
            parameters[0].Value = mUserName;
            DataSet ds = new DataSet();
            ds = RunProcedure("sp_SYS_USER_PERMISSION_SELECT_ALL", parameters, "tabUserPermission");
            return ds.Tables[0];
        }
        /// <summary>
        /// Lấy các quyền mà nười dùng chưa được cấp
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       tạo mới
        /// </Modìied>
        public DataTable GetPermissionNotInUser(string mUserName)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@mUSER_ID", SqlDbType.NVarChar, 50) };
            parameters[0].Value = mUserName;
            DataSet ds = new DataSet();
            ds = RunProcedure("SP_SYS_USER_PERMISSION_SELECT_NOT_IN_USER", parameters, "tabUserPermission");
            return ds.Tables[0];
        }

		public DataTable GetEffectivePermissionList(string mUserName, string mPermissionID /* = "%" */)
		{
			SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@mUSER_ID", SqlDbType.NVarChar, 50), new SqlParameter("@mPERMISSION_ID", SqlDbType.NVarChar, 9)};
			parameters[0].Value = mUserName;
			parameters[1].Value = mPermissionID;			
			DataSet ds = new DataSet();
			ds = RunProcedure("SP_SYS_USER_PERMISSION_LIST", parameters, "tabEffectivePermission");
			return ds.Tables[0];
		}
        /// <summary>
        /// Thêm 1 số quyền cho người dùng
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       tạo mới
        /// </Modìied>
		public int InsertUserPermission(string mUserName, string mPermissionIDs, string mGrantOptions, string mGrantUserID)
		{
			SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@mUSER_ID", SqlDbType.NVarChar, 50), new SqlParameter("@mPERMISSION_IDs", SqlDbType.NVarChar, 4000), new SqlParameter("@mGRANT_OPTIONs", SqlDbType.NVarChar, 4000), new SqlParameter("@mGRANT_USER_ID", SqlDbType.NVarChar, 50) };
			parameters[0].Value = mUserName;
			parameters[1].Value = mPermissionIDs;
			parameters[2].Value = mGrantOptions;
			parameters[3].Value = mGrantUserID;
            try
            {
                RunProcedure("SP_SYS_USER_PERMISSION_INSERT", parameters);
                return 0;
            }
            catch 
            {
                return -1;
            }
			
		}
        /// <summary>
        /// Xóa một số quyền của người dùng
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       tạo mới
        /// </Modìied>
        public int DeleteUserSomePermission(string mUserName, string mPermissionIDs)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@mUSER_ID", SqlDbType.NVarChar, 50), new SqlParameter("@mPERMISSION_IDs", SqlDbType.NVarChar, 4000)};
            parameters[0].Value = mUserName;
            parameters[1].Value = mPermissionIDs;
            try
            {
                RunProcedure("SP_SYS_USER_SOME_PERMISSION_DELETE", parameters);
                return 0;
            }
            catch 
            {
                return -1;
            }
            
        }
        /// <summary>
        /// Xóa tất cả quyền của người dùng
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       tạo mới
        /// </Modìied>
		public int DeleteUserPermission( string mUserName /* = "" */,  string mGrantUserID /* = "" */)
		{
			SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@mUSER_ID", SqlDbType.NVarChar, 50), new SqlParameter("@mGRANT_USER_ID", SqlDbType.NVarChar, 50) };
			parameters[0].Value = mUserName;
			parameters[1].Value = mGrantUserID;
            try
            {
                this.RunProcedure("SP_SYS_USER_PERMISSION_DELETE", parameters);
                return 0;
            }
            catch
            {
                return -1;
            }
			
		}
	}
}
