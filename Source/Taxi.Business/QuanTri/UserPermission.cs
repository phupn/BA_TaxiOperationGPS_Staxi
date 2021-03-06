using System;
using System.Data;
 
namespace Taxi.Business
{
    /// <summary>
    /// Quản lý các quyền của người dùng: thêm, xóa quyền của người dùng 
    /// </summary>
    /// <Modìied>
    /// Name                 date        comments
    /// Cuongdb              ????       copy and edit from Kiểm toán
    /// </Modìied>
	public class UserPermission
	{
        // Khai báo các tham biến
		private string mGrantOption;
		private string mGrantOptions;
		private string mGrantUserID = "ADMIN";
		private string mPermissionID;
		private string mPermissionIDs;
		private string mUserName;
		private Data.UserPermission objUserPermission;

        #region Các thuộc tính
        public string UserName
		{
			set{mUserName = value;}
		}
 
		public string PermissionIDs
		{
			get{return mPermissionIDs;}
			set{mPermissionIDs = value;}
		}
 
		public string PermissionID
		{
			get{return mPermissionID;}
			set{mPermissionID = value;}
		}
 
		public string GrantUserID
		{
			get{return mGrantUserID;}
			set{mGrantUserID = value;}
		}
 
		public string GrantOptions
		{
			get{return mGrantOptions;}
			set{mGrantOptions = value;}
		}
 
		public string GrantOption
		{
			get{return mGrantOption;}
			set{mGrantOption = value;}
        }
        #endregion

        /// <summary>
        /// Khởi tạo đối tượng
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       tạo mới
        /// </Modìied>
        public UserPermission()
		{
			mUserName = "";
			mPermissionID = "";
			mPermissionIDs = "";
			mGrantOption = "";
			mGrantOptions = "";
			mGrantUserID = "ADMIN";
			objUserPermission = new Data.UserPermission();

		}
        /// <summary>
        /// Lấy các quyền của người dùng
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       tạo mới
        /// </Modìied>
		public DataTable GetUserPermission()
		{
			return objUserPermission.GetUserPermission(mUserName);
		}

        /// <summary>
        /// Lấy các quyền của người dùng
        /// </summary>
        /// <Modìied>
        /// Name             date           comments
        /// LONGNM           06/05/2008     tạo mới
        /// </Modìied>
        public DataTable GetUserPermissionFull()
        {
            return objUserPermission.GetUserPermissionFull(mUserName);
        }

        /// <summary>
        /// Lấy các quyền mà nười dùng chưa được cấp
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       tạo mới
        /// </Modìied>
        public DataTable GetPermissionNotInUser()
        {
            return objUserPermission.GetPermissionNotInUser(mUserName);
        }
       
		public DataTable GetEffectivePermissionList()
		{
			return objUserPermission.GetEffectivePermissionList(mUserName, mPermissionID);
		}
        /// <summary>
        /// Thêm 1 số quyền cho người dùng
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       tạo mới
        /// </Modìied>
		public int InsertUserPermission()
		{
			return objUserPermission.InsertUserPermission(mUserName, mPermissionIDs, mGrantOptions, mGrantUserID);
		}
        /// <summary>
        /// Xóa một số quyền của người dùng
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       tạo mới
        /// </Modìied>
        public int DeleteUserSomePermission()
        {
            return objUserPermission.DeleteUserSomePermission(mUserName, mPermissionIDs);
        }
        /// <summary>
        /// Xóa tất cả quyền của người dùng
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       tạo mới
        /// </Modìied>
		public int DeleteUserPermission()
		{
			return objUserPermission.DeleteUserPermission(mUserName, mGrantUserID);
		}
	}
}
