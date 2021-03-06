using System;
using System.Data; 
namespace Taxi.Business
{
    /// <summary>
    /// Quản lý các quyền trong hệ thống
    /// </summary>
    /// <Modìied>
    /// Name                 date        comments
    /// Cuongdb              ????       Copy from Kiểm toán
    /// </Modìied>
	public class Permission
	{
        // Khai báo các tham biến
		private string mDescription;
		private string mPermissionID;
		private string mPermissionName;
		private Data.Permission objPermission;

        #region Các thuộc tính
        public string PermissionID
		{
			get{return mPermissionID;}
			set{mPermissionID = value;}
		} 
		public string PermissionName
		{
			get{return mPermissionName;}
			set{mPermissionName = value;}
		}
 
		public string Description
		{
			get{return mDescription;}
			set{mDescription = value;}
        }
        #endregion
        /// <summary>
        /// Khởi tạo đối tượng quyền
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       Copy from Kiểm toán
        /// </Modìied>
        public Permission()
		{
			objPermission=new Taxi.Data.Permission(); 
		}
        /// <summary>
        /// Lấy ra thông tin quyền
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       Copy from Kiểm toán
        /// </Modìied>
		public DataTable GetPermission()
		{
			return objPermission.GetPermission(mPermissionID);
		}
        /// <summary>
        /// Tạo mới 1 quyền
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       Copy from Kiểm toán
        /// </Modìied>
		public int InsertPermissions()
		{
			return objPermission.InsertPermission(mPermissionID, mPermissionName, mDescription);
        }

        /// <summary>
        /// cập nhật thông tin thay đổi của quyền
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       Copy from Kiểm toán
        /// </Modìied>
        public int UpdatePermission()
		{
			return objPermission.UpdatePermission(mPermissionID, mPermissionName, mDescription);
		}
        /// <summary>
        /// Xóa 1 quyền
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       Copy from Kiểm toán
        /// </Modìied>
		public int DeletePermission()
		{
			return objPermission.DeletePermission(mPermissionID);
		}

        public DataTable GetAll()
        {
            return objPermission.GetAll();
        }
	}
}
