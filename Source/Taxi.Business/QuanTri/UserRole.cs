using System;
using System.Data;
namespace Taxi.Business
{
    /// <summary>
    /// Quản lý vai trò của người dùng : Thêm, xóa vai tro cho 1 người dùng, nhóm người dùng
    /// </summary>
    /// <Modìied>
    /// Name                 date        comments
    /// Cuongdb              ????       tạo mới
    /// </Modìied>
	public class UserRole
	{
        // Khai báo các tham biến
		private string mGrantOption;
		private string mGrantOptions;
		private string mGrantUserID="Admin";
		private string mRoleID;
		private string mRoleIDs;
		private string mUserIDs;
		private string mUserIDsDel;
		private string mUserName;
		private Data.UserRole objUserRole;

        #region Các thuộc tính
        public string GrantOption
		{
			get{return mGrantOption;}
			set{mGrantOption = value;}
		}
 
		public string GrantOptions
		{
			get{return mGrantOptions;}
			set{mGrantOptions = value;}
		}
 
		public string GrantUserID
		{
			get{return mGrantUserID;}
			set{mGrantUserID = value;}
		}
 
		public string RoleID
		{
			get{return mRoleID;}
			set{mRoleID = value;}
		}
 
		public string RoleIDs
		{
			get{return this.mRoleIDs;}
			set{this.mRoleIDs = value;}
		}
 
		public string UserIDs
		{
			get{return this.mUserIDs;}
			set{this.mUserIDs = value;}
		}
 
		public string UserIDsDel
		{
			get{return this.mUserIDsDel;}
			set{this.mUserIDsDel = value;}
		}
 
		public string UserName
		{
			set{this.mUserName = value;}
        }
        #endregion

        // Khởi tạo đới tượng
        public UserRole()
		{
			mUserName = "";
			mUserIDs = "";
			mUserIDsDel = "";
			mRoleID = "";
			mRoleIDs = "";
			objUserRole = new Data.UserRole();
		}
        /// <summary>
        /// Lấy danh sách các vai trò mà người dùng được cấp
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       tạo mới
        /// </Modìied>
		public DataTable GetUserRole()
		{
			return this.objUserRole.GetUserRole(this.mUserName);
		}
        /// <summary>
        /// Lấy danh sách vai trò mà người dùng chưa được cấp
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       tạo mới
        /// </Modìied>
        public DataTable GetRoleNotInUser()
        {
            return this.objUserRole.GetRoleNotInUser(this.mUserName);
        }
        /// <summary>
        /// Lấy danh sách người dùng trong cùng 1 phòng có cùng vai trò truyền vào
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       tạo mới
        /// </Modìied>
		public DataTable GetUserByRole(int PhongID)
		{
			return this.objUserRole.GetUserByRole(this.mRoleID,PhongID);
		}
        /// <summary>
        /// Lấy danh sách người dùng khong có trong vai trò thuọc cùng phòng truyền vào
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       tạo mới
        /// </Modìied>
        public DataTable GetUserNotInRole(int PhongID)
        {
            return this.objUserRole.GetUserNotInRole(this.mRoleID,PhongID);
        }
        /// <summary>
        /// Cấp mới 1 số vai trò cho người dùng
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       tạo mới
        /// </Modìied>
		public int InsertUserRole()
		{
			return this.objUserRole.InsertUserRole(this.mUserName, this.mRoleIDs, this.mGrantOptions, this.mGrantUserID);
		}
        /// <summary>
        /// Xóa một số vai trò của người dùng 
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       tạo mới
        /// </Modìied>
        public int DeleteUserSomeRole()
        {
            return this.objUserRole.DeleteUserSomeRole(this.mUserName, this.mRoleIDs);
        }
        /// <summary>
        /// Thêm mới 1 số người dùng vào vai trò này
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       tạo mới
        /// </Modìied>
		public int InsertUserByRole()
		{
			return this.objUserRole.InsertUserByRole(this.mRoleID, this.mUserIDs, this.mUserIDsDel, this.mGrantUserID);
		}
        /// <summary>
        /// Xóa tất cả quyền của người dùng
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       tạo mới
        /// </Modìied>
		public int DeleteUserRole()
		{
			return this.objUserRole.DeleteUserRole(this.mUserName, this.mGrantUserID);
		}
        /// <summary>
        /// Xóa tất cả người dùng trong vai trò truyền vào
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       tạo mới
        /// </Modìied>
		public int DeleteUserByRole()
		{
			return this.objUserRole.DeleteUserByRole(this.mRoleID);
		}
	}
}
