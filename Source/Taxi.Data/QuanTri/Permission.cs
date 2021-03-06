using System;
using System.Data;
using System.Data.SqlClient;
using Taxi.Utils;

namespace Taxi.Data
{
    /// <summary>
    /// Quản lý các quyền trong hệ thống
    /// </summary>
    /// <Modìied>
    /// Name                 date        comments
    /// Cuongdb              ????       Copy from Kiểm toán
    /// </Modìied>
    public class Permission : DBObject
	{
		public Permission()
		{			
		}
        /// <summary>
        /// Lấy ra thông tin 1 quyền
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       Copy from Kiểm toán
        /// </Modìied>
		public DataTable GetPermission(string mPERMISSION_ID)
		{
			SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@mPERMISSION_ID", SqlDbType.VarChar, 9)};
			parameters[0].Value = mPERMISSION_ID;			
			DataSet ds = new DataSet();
			ds = RunProcedure("SP_SYS_PERMISSION_SELECT", parameters, "tabPermissions");
			return ds.Tables[0];
		}
        /// <summary>
        /// Tạo mới 1 quyền
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       Copy from Kiểm toán
        /// </Modìied>
		public int InsertPermission(string mPermissionID, string mPermissioName, string mDescription)
		{
			int rowAffected;
			SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@mPERMISSION_ID", SqlDbType.Char, 9), new SqlParameter("@mPERMISSION_NAME", SqlDbType.VarChar, 100), new SqlParameter("@mDESCRIPTION", SqlDbType.VarChar, 4000) };
			parameters[0].Value = mPermissionID;
			parameters[1].Value = mPermissioName;
			parameters[2].Value = mDescription;
			try
			{
				RunProcedure("sp_SYS_PERMISSION_INSERT", parameters);
				rowAffected = 0;
			}
			catch (SqlException ex)
			{
				rowAffected = ex.ErrorCode;				
			}
			return rowAffected;
		}
        /// <summary>
        /// cập nhật thông tin thay đổi của quyền
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       Copy from Kiểm toán
        /// </Modìied>
		public int UpdatePermission(string mPermissionID, string mPermissioName, string mDescription)
		{
			int rowAffected;
			SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@mPERMISSION_ID", SqlDbType.Char, 9), new SqlParameter("@mPERMISSION_NAME", SqlDbType.VarChar, 100), new SqlParameter("@mDESCRIPTION", SqlDbType.VarChar, 4000) };
			parameters[0].Value = mPermissionID;
			parameters[1].Value = mPermissioName;
			parameters[2].Value = mDescription;
			try
			{
				RunProcedure("sp_SYS_PERMISSION_UPDATE", parameters);
				rowAffected = 0;
			}
			catch (SqlException ex)
			{
				rowAffected = ex.ErrorCode;				
			}
			return rowAffected;
		}
        /// <summary>
        /// Xóa 1 quyền
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       Copy from Kiểm toán
        /// </Modìied>
		public int DeletePermission(string mPermissionID)
		{
			int rowAffected;
			SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@mPERMISSION_ID", SqlDbType.VarChar, 50) };
			parameters[0].Value = mPermissionID;
			try
			{
				RunProcedure("SP_SYS_PERMISSION_DELETE", parameters);
				rowAffected = 0;
			}
			catch (SqlException ex)
			{
				rowAffected = ex.ErrorCode;				
			}
			return rowAffected;
		}

        public DataTable GetAll()
        {
            SqlParameter[] parameters = new SqlParameter[] {};
            DataSet ds = new DataSet();
            ds = RunProcedure("SP_SYS_PERMISSION_GETALL", parameters, "tabPermissions");
            return ds.Tables[0];
        }
    }
}
