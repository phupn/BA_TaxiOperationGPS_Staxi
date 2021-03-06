using System;
using System.Data;
using System.Data.SqlClient;
using Taxi.Utils;

namespace Taxi.Data
{
	public class Log :DBObject
	{
		public Log()
		{		
		}
        /// <summary>
        /// Ghi sự kiện
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       Copy from Kiểm toán
        /// </Modìied>
		public int WriteLog(string UserID, string EventID, DateTime EventTime, string Log)
		{
			int rowAffected=1;
			SqlParameter[] parameters = new SqlParameter[] { 
				new SqlParameter("@muser_id", SqlDbType.NVarChar, 50), 
				new SqlParameter("@mevent_id", SqlDbType.VarChar, 50),
				new SqlParameter("@mevent_time", SqlDbType.DateTime), 
				new SqlParameter("@mlog", SqlDbType.NVarChar, 4000)};
			parameters[0].Value = UserID;
			parameters[1].Value = EventID;
			parameters[2].Value = EventTime;
			parameters[3].Value = Log;
			return this.RunProcedure("SP_LOG_INSERT", parameters,   rowAffected);
		}

        /// <summary>
        /// Ghi sự kiện
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       Copy from Kiểm toán
        /// </Modìied>
        public int WriteLog(string UserID, string EventID, string Log)
        {
            int rowAffected = 1;
            SqlParameter[] parameters = new SqlParameter[] { 
				new SqlParameter("@muser_id", SqlDbType.NVarChar, 50), 
				new SqlParameter("@mevent_id", SqlDbType.VarChar, 50),
				new SqlParameter("@mlog", SqlDbType.NVarChar, 4000)};
            parameters[0].Value = UserID;
            parameters[1].Value = EventID;
            parameters[2].Value = Log;
            return this.RunProcedure("SP_LOG_INSERT_V2", parameters, rowAffected);
        }
        /// <summary>
        /// tìm kiếm các sự kiện trong 1 khoảng thời gian
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       Copy from Kiểm toán
        /// </Modìied>
		public DataTable Search(string LogTimeFrom, string LogTimeTo, string lstUserID, string lstEventGroupID)
		{
			SqlParameter[] parameters = new SqlParameter[] { 
						new SqlParameter("@mlog_time_from", SqlDbType.VarChar, 20),
						new SqlParameter("@mlog_time_to", SqlDbType.VarChar, 20),
						new SqlParameter("@muser_id", SqlDbType.NVarChar, 4000),
						new SqlParameter("@mevent_group_id", SqlDbType.NVarChar, 200) };
			parameters[0].Value = LogTimeFrom;
			parameters[1].Value = LogTimeTo;
			parameters[2].Value = lstUserID;
			parameters[3].Value = lstEventGroupID;			
			return this.RunProcedure("SP_LOG_SEARCH", parameters, "tblLog").Tables[0];
		}
        /// <summary>
        /// Lấy trạng thái của sự kiện
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       Copy from Kiểm toán
        /// </Modìied>
		public DataTable GetLogStatistic(DateTime StatisticDay,  int EventGroupID )
		{
			SqlParameter[] parameters = new SqlParameter[] { 
						new SqlParameter("@StatisticDay", SqlDbType.NVarChar,12),
						new SqlParameter("@EventGroupID", SqlDbType.Int)};
			//parameters[0].Value =new Common.Functions.Dates().DateToChar(StatisticDay);
			parameters[1].Value = EventGroupID;			
			return this.RunProcedure("SP_LOG_GET_LOG_STATISTIC", parameters, "tblLog").Tables[0];
		}

        /// <summary>
        /// xóa các sự kiện trong 1 khoảng thời gian
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       Copy from Kiểm toán
        /// </Modìied>
		public int DeleteLog(string LogTimeFrom, string LogTimeTo)
		{
			int rowAffected=1;
			SqlParameter[] parameters = new SqlParameter[] { 
					new SqlParameter("@mlog_time_from", SqlDbType.VarChar, 20),
					new SqlParameter("@mlog_time_to", SqlDbType.VarChar, 20) };
			parameters[0].Value = LogTimeFrom;
			parameters[1].Value = LogTimeTo;
			return this.RunProcedure("SP_LOG_DELETE", parameters,   rowAffected);
		}
        /// <summary>
        /// Kết quả tìm kiếm
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb              ????       Copy from Kiểm toán
        /// </Modìied>
		public DataTable GetSearchResults(string strIDs)
		{
			SqlParameter[] parameters = new SqlParameter[] { 
					new SqlParameter("@strIDs", SqlDbType.VarChar, 255)};
			parameters[0].Value = strIDs;			
			return this.RunProcedure("SP_LOG_GET_SEARCH_RESULT", parameters, "tblLog").Tables[0];
		}
	}
}
