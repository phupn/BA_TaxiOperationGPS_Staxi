using System;
using System.Data;
using System.Collections;
 
namespace Taxi.Business
{
    /// <summary>
    /// Quản lý các nhóm sự kiện trong hệ thống
    /// </summary>
    /// <Modified>
    /// Name                    date               comments
    /// Cuongdb                 ????             coppy from Kiểm Toán
    /// </Modified>
	public class EventGroup
	{
        // Khai báo các tham biếm
		private Taxi.Data.EventGroup objEventGroup;
		private int mID;
		private string mEventGroupName;
        // Khởi tạo sẹ kiện
		public EventGroup()
		{
			objEventGroup = new Taxi.Data.EventGroup();
		}
        /// <summary>
        /// Khởi tạo nhóm sự kiện theo mã nhóm sự kiện
        /// </summary>
        /// <Modified>
        /// Name                    date               comments
        /// Cuongdb                 ????             coppy from Kiểm Toán
        /// </Modified>
		public EventGroup(int ID)
		{
			objEventGroup = new Taxi.Data.EventGroup();
			mID = ID;
			DataRow aRow;
			aRow = objEventGroup.GetEventGroup(mID);
			mEventGroupName = aRow["EVENT_GROUP_NAME"].ToString();
		}
        /// <summary>
        /// Lấy danh sách các sự kiện trong 1 nhóm sự kiện
        /// </summary>
        /// <Modified>
        /// Name                    date               comments
        /// Cuongdb                 ????             coppy from Kiểm Toán
        /// </Modified>
		public DataTable GetEvents()
		{
			return objEventGroup.GetEvents(mID);
		}
        /// <summary>
        /// Lấy danh sách các nhóm sự kiện
        /// </summary>
        /// <Modified>
        /// Name                    date               comments
        /// Cuongdb                 ????             coppy from Kiểm Toán
        /// </Modified>
		public DataTable GetEventGroups()
		{
			return objEventGroup.GetEventGroups();
		}
        /// <summary>
        /// Thiết lập cơ chế ghi log cho các sự kiện truyền vào thuộc cùng lớp
        /// </summary>
        /// <Modified>
        /// Name                    date               comments
        /// Cuongdb                 ????             coppy from Kiểm Toán
        /// </Modified>
		public int SetLogMode(ArrayList LogMode)
		{
			if (LogMode!=null)
			{
				int i;
				string lstEventID = "(0,";
				for(i = 0;i<=LogMode.Count - 1;i++)
					lstEventID = lstEventID + LogMode[i].ToString() + ",";		
				lstEventID =lstEventID.Substring(1,lstEventID.Length - 2) ;
				return objEventGroup.SetLogMode(mID, lstEventID);
			}
			else
			{
				return -1;
			}
		}
        /// <summary>
        /// Thuộc tính mã nhóm sự kiện, Lấy mã nhóm sự kiện
        /// </summary>
        /// <Modified>
        /// Name                    date               comments
        /// Cuongdb                 ????             coppy from Kiểm Toán
        /// </Modified>
		public int ID
		{
			get{return mID;}
		}
        /// <summary>
        /// Thuộc tính tên nhóm sự kiện, Lấy tên nhóm sự kiện
        /// </summary>
        /// <Modified>
        /// Name                    date               comments
        /// Cuongdb                 ????             coppy from Kiểm Toán
        /// </Modified>
		public string Name
		{
			get{return mEventGroupName;}
			set {mEventGroupName=value;}
		}
	}
}
