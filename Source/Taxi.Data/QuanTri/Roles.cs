using System;
using System.Data;
using System.Data.SqlClient;
using Taxi.Utils;

namespace Taxi.Data
{
    /// <summary>
    /// Quản lý các vai trò trong hệ thống: Thêm, sửa, xóa vai trò
    /// Cấp và loại các quyền cho 1 vai trò
    /// </summary>
    /// <Modìied>
    /// Name                 date        comments
    /// Cuongdb              ????       Copy from Kiểm toán
    /// </Modìied>
    public class Roles : DBObject
	{
		public Roles()
		{			
		}
        /// <summary>
        /// Lấy thông tin vai trò
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       Copy from Kiểm toán
        /// </Modìied>
		public DataTable GetRoles(string mRoleID)
		{
			SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@mROLE_ID", SqlDbType.NVarChar, 50) };
			parameters[0].Value = mRoleID;			
			DataSet ds = new DataSet();
			ds = this.RunProcedure("sp_SYS_ROLE_SELECT", parameters, "tblRoles");
			return ds.Tables["tblRoles"];
		}

        /// <summary>
        /// Trả về danh sách các vai trò hiện có trong hệ thống
        /// </summary>
        /// <returns></returns>
        /// <Modified>
        /// Person  Date        Comments
        /// Tuânpv  21/11/2007  Tạo mới
        /// </Modified>
        public DataTable GetListRoles() 
        {
            SqlParameter[] parameters = new SqlParameter[] { };
            DataSet ds = new DataSet();
            ds = this.RunProcedure("SP_SYS_ROLE_SELECT_LIST", parameters, "tblRoles");
            return ds.Tables[0];
        }
        /// <summary>
        /// Lấy danh sách các quyền được cấp trong 1 vai trò
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       Copy from Kiểm toán
        /// </Modìied>
		public DataTable GetRolePermission( string mRoleID )
		{
			SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@mROLE_ID", SqlDbType.NVarChar, 50) };
			parameters[0].Value = mRoleID;			
			DataSet ds = new DataSet();
			ds = RunProcedure("SP_SYS_ROLE_PERMISSION_SELECT", parameters, "tblRolePermission");
			return ds.Tables["tblRolePermission"];
		}
        /// <summary>
        /// Lấy các quyền còn lại của hệ thống không có trong vai trò
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       tạo mới
        /// </Modìied>
        public DataTable GetPermissionNotInRole(string mRoleID)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@mROLE_ID", SqlDbType.NVarChar, 50) };
            parameters[0].Value = mRoleID;
            DataSet ds = new DataSet();
            ds = RunProcedure("SP_SYS_ROLE_NOT_PERMISSION_SELECT", parameters, "tblRoleNotPermission");
            return ds.Tables["tblRoleNotPermission"];
        }

        /// <summary>
        /// tạo mới 1 vai trò
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       Copy from Kiểm toán
        /// </Modìied>
		public int InsertRoles(string mRoleID, string mRoleName, string mDescription)
		{
			SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@mROLE_ID", SqlDbType.NVarChar, 50), 
                                                            new SqlParameter("@mROLE_NAME", SqlDbType.NVarChar, 100), 
                                                            new SqlParameter("@mDESCRIPTION", SqlDbType.NVarChar, 1000) };
			parameters[0].Value = mRoleID;
			parameters[1].Value = mRoleName;
			parameters[2].Value = mDescription;
			try
			{
				RunProcedure("sp_SYS_ROLE_INSERT", parameters);
				return 0;
			}
			catch (SqlException ex)
			{
				return 1;				
			}			
		}
        /// <summary>
        /// Cấp 1 số quyên cho 1 vai trò
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       Copy from Kiểm toán
        /// </Modìied>
		public int InsertRolePermission(string mRoleID, string mPermissionIDs)
		{
			SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@mROLE_ID", SqlDbType.NVarChar, 50), 
                                                                new SqlParameter("@mPERMISSION_IDs", SqlDbType.NVarChar, 4000) };
			parameters[0].Value = mRoleID;
			parameters[1].Value = mPermissionIDs;
			try
			{
				RunProcedure("sp_SYS_ROLE_PERMISSION_INSERT", parameters);
				return 0;
			}
            catch (SqlException ex)
            {
                return 1;
            }
		}
        /// <summary>
        /// Cập nhật thông tin thay đổi của vai trò
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       Copy from Kiểm toán
        /// </Modìied>
		public int UpdateRoles(string mRoleID, string mRoleName, string mDescription)
		{
			SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@mROLE_ID", SqlDbType.NVarChar, 50), 
                                                                new SqlParameter("@mROLE_NAME", SqlDbType.NVarChar, 100), 
                                                                new SqlParameter("@mDESCRIPTION", SqlDbType.NVarChar, 1000) };
			parameters[0].Value = mRoleID;
			parameters[1].Value = mRoleName;
			parameters[2].Value = mDescription;
			try
			{
				RunProcedure("sp_SYS_ROLE_UPDATE", parameters);
				return 0;
			}
            catch (SqlException ex)
            {
                return 1;
            }
		}
        /// <summary>
        /// Xóa 1 vai trò
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       Copy from Kiểm toán
        /// </Modìied>
		public int DeleteRoles( string mROLEID)
		{
			int rowAffected;
			SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@mROLE_ID", SqlDbType.NVarChar, 50) };
			parameters[0].Value = mROLEID;
			try
			{
				RunProcedure("SP_SYS_ROLE_DELETE", parameters);
				return 0;
			}
            catch (SqlException ex)
            {
                return 1;
            }
		}
        /// <summary>
        /// Xóa tất cả các quyền của vai trò
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       Copy from Kiểm toán
        /// </Modìied>
		public int DeleteRolePermission(string mROLEID)
		{
			SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@mROLE_ID", SqlDbType.NVarChar, 50) };
			parameters[0].Value = mROLEID;
			try
			{
				RunProcedure("SP_SYS_ROLE_PERMISSION_DELETE", parameters);
				return 0;
			}
            catch (SqlException ex)
            {
                return 1;
            }
		}
        /// <summary>
        /// Xóa một số quyền của vai trò
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       tạo mới
        /// </Modìied>
        public int DeleteSomePermissionInRole(string mRoleID, string mPermissionIDs)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@mROLE_ID", SqlDbType.NVarChar, 50), 
                                                                new SqlParameter("@mPERMISSION_IDs", SqlDbType.NVarChar, 4000) };
            parameters[0].Value = mRoleID;
            parameters[1].Value = mPermissionIDs;
            try
            {
                RunProcedure("sp_SYS_ROLE_DEL_SOME_PERMISSION", parameters);
                return 0;
            }
            catch (SqlException ex)
            {
                return 1;
            }
        }

	}
}
