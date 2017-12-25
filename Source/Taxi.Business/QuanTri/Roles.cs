using System;
using System.Data;

namespace Taxi.Business
{
    /// <summary>
    /// Quản lý các vai trò trong hệ thống: Thêm, sửa, xóa vai trò
    /// Cấp và loại các quyền cho 1 vai trò
    /// </summary>
    /// <Modìied>
    /// Name                 date        comments
    /// Cuongdb              ????       Copy from Kiểm toán
    /// </Modìied>
	public class Roles
	{
        // Khai báo các tham biến
		private string mDescription;
		private string mPermissionIDs;
		private string mRoleID;
		private string mRoleName;
		private Taxi.Data.Roles objRoles;

        #region Các thuộc tính của vai trò
        public string RoleID
		{
			set{mRoleID = value;}
		}
 
		public string RoleName
		{
			get{return mRoleName;}
			set{mRoleName = value;}
		}
 
		public string Description
		{
			get{return mDescription;}
			set{mDescription = value;}
		}
 
		public string PermissionIDs
		{
			get{return mPermissionIDs;}
			set{mPermissionIDs = value;}
        }
        #endregion

        /// <summary>
        /// Khởi tạo đối tượng 1 vai trò
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       Copy from Kiểm toán
        /// </Modìied>
        public Roles()
		{	
			objRoles= new Taxi.Data.Roles(); 
		}

        /// <summary>
        /// Lấy thông tin vai trò
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       Copy from Kiểm toán
        /// </Modìied>
		public DataTable GetRoles()
		{		
			return objRoles.GetRoles(mRoleID);															   
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
            return objRoles.GetListRoles();
        }

        /// <summary>
        /// Lấy danh sách các quyền được cấp trong 1 vai trò
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       Copy from Kiểm toán
        /// </Modìied>
		public DataTable GetRolePermission()
		{			
			return objRoles.GetRolePermission(mRoleID);		
		}
        /// <summary>
        /// Lấy các quyền còn lại của hệ thống không có trong vai trò
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       tạo mới
        /// </Modìied>
        public DataTable GetPermissionNotInRole()
        {
            return objRoles.GetPermissionNotInRole(mRoleID);
        }

        /// <summary>
        /// tạo mới 1 vai trò
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       Copy from Kiểm toán
        /// </Modìied>
		public int InsertRoles()
		{			
			return objRoles.InsertRoles(mRoleID, mRoleName, mDescription);
		}

        /// <summary>
        /// Cấp 1 số quyên cho 1 vai trò
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       Copy from Kiểm toán
        /// </Modìied>
		public int InsertRolePermission()
		{												   
			return objRoles.InsertRolePermission(mRoleID, mPermissionIDs);
		}

        /// <summary>
        /// Cập nhật thông tin thay đổi của vai trò
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       Copy from Kiểm toán
        /// </Modìied>
		public int UpdateRoles()
		{		
			return objRoles.UpdateRoles(mRoleID, mRoleName, mDescription);
		}

        /// <summary>
        /// Xóa 1 vai trò
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       Copy from Kiểm toán
        /// </Modìied>
		public int DeleteRoles()
		{
			return objRoles.DeleteRoles(mRoleID);
		}

        /// <summary>
        /// Xóa tất cả các quyền của vai trò
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       Copy from Kiểm toán
        /// </Modìied>
		public int DeleteRolePermission()
		{												   
			return objRoles.DeleteRolePermission(mRoleID);
		}

        /// <summary>
        /// Xóa một số quyền của vai trò
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       tạo mới
        /// </Modìied>
        public int DeleteSomePermissionInRole()
        {
            return objRoles.DeleteSomePermissionInRole(mRoleID, mPermissionIDs);
        }
	}
}
