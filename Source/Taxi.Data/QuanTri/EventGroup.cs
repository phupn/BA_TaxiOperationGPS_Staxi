using System;
using System.Data;
using System.Data.SqlClient;
using Taxi.Utils;

namespace Taxi.Data
{
    /// <summary>
    /// Quản lý các nhóm sự kiện trong hệ thống
    /// </summary>
    /// <Modified>
    /// Name                    date               comments
    /// Cuongdb                 ????             coppy from Kiểm Toán
    /// </Modified>
    public class EventGroup : DBObject
	{
		public EventGroup()
		{
		}
        /// <summary>
        /// Lấy danh sách các sự kiện trong 1 nhóm sự kiện
        /// </summary>
        /// <Modified>
        /// Name                    date               comments
        /// Cuongdb                 ????             coppy from Kiểm Toán
        /// </Modified>
		public DataTable GetEvents(int GroupID)
		{
			SqlParameter[] parameters= new SqlParameter[]{new SqlParameter("@mgroup_id",SqlDbType.Int)};
			parameters[0].Value = GroupID;	
			return RunProcedure("SP_GROUPEVENT_GET_EVENT_LIST", parameters, "tblEvent").Tables[0];	
		}
        /// <summary>
        /// Thiết lập cơ chế ghi log cho các sự kiện truyền vào thuộc cùng lớp
        /// </summary>
        /// <Modified>
        /// Name                    date               comments
        /// Cuongdb                 ????             coppy from Kiểm Toán
        /// </Modified>
		public int SetLogMode(int EventGroupID, string lstEventID)
		{
			int rowAffected=0;
			SqlParameter[] parameters = new SqlParameter[] { 
				new SqlParameter("@mevent_group_id", SqlDbType.Int),
				new SqlParameter("@mlist_event", SqlDbType.VarChar, 4000)};

			parameters[0].Value = EventGroupID;
			parameters[1].Value = lstEventID;

			return RunProcedure("SP_GROUPEVENT_SET_LOG_MODE", parameters,   rowAffected);
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
			SqlParameter[] parameters = new SqlParameter[] {};
			//parameters[0].Direction = ParameterDirection.Output;
			return this.RunProcedure("SP_GROUPEVENT_GET_LIST", parameters, "tblEventGroup").Tables[0];
		}
        /// <summary>
        /// Lấy thông tin sự kiện
        /// </summary>
        /// <Modified>
        /// Name                    date               comments
        /// Cuongdb                 ????             coppy from Kiểm Toán
        /// </Modified>
		public DataRow GetEventGroup(int EventGroupID)
		{
			SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@mid", SqlDbType.Int)};
			parameters[0].Value = EventGroupID;			
			return this.RunProcedure("SP_GROUPEVENT_GET", parameters, "tblEventGroup").Tables[0].Rows[0];
		}
	}
}
