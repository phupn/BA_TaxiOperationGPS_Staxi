using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Taxi.Data;

namespace Taxi.Data.BanCo.Entity
{
    /// <summary>
    /// Quản lý cơ chế ghi log hệ thống
    /// </summary>
    /// <Modìied>
    /// Name                 date        comments
    /// congnt              ????        
    /// </Modìied>
    public class LogEvent
    {
        // Khai báo các tham biến
		private object[] mArrData;
		private object[] mArrLabel;
		private string mEventGroupID;
		private long mID=0;
		private string mLog;
		private string mLogTimeFrom;
		private string mLogTimeTo;
		private string mUserID;
		private Log objLog;
		private string strIDs;
        #region Các thuộc tính
        public string IDs
        {
            set { if (value != null) strIDs = value; }
        }
        public long ID
        {
            get { return mID; }
        }
        public string EventGroupID
        {
            get { return mEventGroupID; }
            set { mEventGroupID = value; }
        }
        public string UserID
        {
            get { return mUserID; }
            set { mUserID = value; }
        }
        public string LogTimeFrom
        {
            get { return mLogTimeFrom; }
            set { mLogTimeFrom = value; }
        }

        public string LogTimeTo
        {
            get { return mLogTimeTo; }
            set { mLogTimeTo = value; }
        }
        public string Logs
        {
            get { return mLog; }
            set { mLog = value; }
        }

        public object[] ArrData
        {
            get { return mArrData; }
        }

        public object[] ArrLabel
        {
            get { return mArrLabel; }
        }
        #endregion
        // Khởi tạo đối tượng
        public LogEvent()
		{
			objLog = new Log();
		}
        /// <summary>
        /// Sử lý chuỗi tìm kiếm
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// congnt              ????        
        /// </Modìied>
		public string Search()
		{
			DataTable tblTemp;
			long i;
			string strTemp= "";
			tblTemp = objLog.Search(mLogTimeFrom, mLogTimeTo, mUserID, mEventGroupID);

			for(i = 0;i<=tblTemp.Rows.Count - 1;i++)
				strTemp = strTemp + tblTemp.Rows[(int)i]["ID"].ToString() + ",";
		
			if (strTemp.Length > 1)
				strTemp = strTemp.Substring(0,strTemp.Length - 1);												
			return strTemp;
		}
        /// <summary>
        /// tìm kiếm các sự kiện trong 1 khoảng thời gian
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// congnt              ????        
        /// </Modìied>
        public DataTable  Log_Search()
        {
            DataTable tblTemp;
            tblTemp = objLog.Search(mLogTimeFrom, mLogTimeTo, mUserID, mEventGroupID);
            return tblTemp;
        }
        /// <summary>
        /// Lấy chuỗi sử lý thời gian
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// congnt              ????        
        /// </Modìied>
		public void GetDaylyStatData(DateTime InputDay)
		{
			object[] objData=new object[]{};
			object[] objLabel= new object[]{"Thu thập", "Bảo quản", "Biên mục", "Lưu thông", "Quản lý nghiệp vụ", "Xuất nhập", "Quản lý phông", "Quản trị hệ thống"};
			int i;
			DataTable tbltemp;
			for(i = 0;i<=7;i++)
			{
				objData=new object[i];
				tbltemp = objLog.GetLogStatistic(InputDay, i + 1);
				if (tbltemp!=null)
					objData[i] = tbltemp.Rows.Count;
				else
					objData[i] = tbltemp.Rows.Count;																
			}			
			mArrData = objData;
			mArrLabel = objLabel;
			tbltemp = null;
		}
        /// <summary>
        /// Sử lý ngày trong tuần
        /// Cái này không dùng trong Cục tần số
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// congnt              ????        
        /// </Modìied>
		public void GetWeeklyStatData(DateTime FirstDayOfWeek)
		{
			DateTime curDate = FirstDayOfWeek;
			int i;
			object[] objData=new object[]{0,0,0,0,0,0,0} ;
			object[] objLabel=new object[]{"Thứ hai", "Thứ ba", "Thứ tư", "Thứ năm", "Thứ sáu", "Thứ bảy", "Chủ nhật"};

			DataTable tblTemp;

			for(i = 0;i<=6;i++)
			{
				if (curDate > System.DateTime.Now.Date)
					break;
				//objData=new object[i];
				tblTemp = objLog.GetLogStatistic(curDate,0);
				if (tblTemp!=null)
					objData[i] = tblTemp.Rows.Count;
				else
					objData[i] = tblTemp.Rows.Count;
															
				curDate = curDate.AddDays(1);
			}
			
			//objLabel =new object[objData.Length];
			mArrData = objData;
			mArrLabel = objLabel;
			tblTemp = null;
		}

		public void GetMonthlyStatData(int intMonth,int intYear)
		{
            //Common.Functions.Dates mDate=new Common.Functions.Dates();
            //DateTime curDate;
            //int DayCount = mDate.GetDayPerMonth(intMonth, intYear);
            //int i;
            //object[] objData=new object[]{} ;
            //object[] objLabel=new object[]{} ;
            //DataTable tblTemp;
            //string strData=string.Empty;
            //string strLabel=string.Empty;

            //for(i = 0;i<=DayCount - 1;i++)
            //{
            //    curDate =DateTime.Parse( (i + 1).ToString() + "/" + intMonth.ToString()  + "/" + intYear.ToString() );
            //    if (curDate >DateTime.Now.Date) break ;
            //    //objData=new object[i]; 				
            //    //objLabel=new object[i];
				
            //    tblTemp = objLog.GetLogStatistic(curDate,0);
            //    if (tblTemp!=null)
            //    {
            //        //objData[i] = tblTemp.Rows.Count;
            //        if (strData.Equals(string.Empty) )
            //            strData=tblTemp.Rows.Count.ToString();
            //        else
            //            strData=strData+";"+tblTemp.Rows.Count;
            //    }
            //    else									
            //    {
            //        if (strData.Equals(string.Empty) )
            //            strData="0";
            //        else
            //            strData=strData+";0";					
            //    }
            //    if (strLabel.Equals(string.Empty) )
            //        strLabel=""+(i + 1);
            //    else
            //        strLabel=strLabel+";"+(i + 1);					
				
            //}
            //objData=strData.Split(';') ;
            //objLabel=strLabel.Split(';') ;

            //mArrData = objData;
            //mArrLabel = objLabel;
            //tblTemp = null;
            //mDate = null;
		}
        /// <summary>
        /// Kết quả tìm kiếm
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// congnt              ????        
        /// </Modìied>
		public DataTable GetSearchResults()
		{
			return objLog.GetSearchResults(strIDs);
		}
        /// <summary>
        /// Xóa log
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// congnt              ????        
        /// </Modìied>
		public int DeleteLog()
		{
			return objLog.DeleteLog(mLogTimeFrom, mLogTimeTo);
		}
        /// <summary>
        /// Ghi sự kiện
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// congnt              ????        
        /// </Modìied>
		public int WriteLog(string UserID,string EventID,DateTime EventTime,string Log)
		{
			return objLog.WriteLog(UserID.Trim(), EventID.Trim(), EventTime, Log.Trim());
        }
        public int WriteLog(string UserID, string EventID, string Log)
        {
            return objLog.WriteLog(UserID.Trim(), EventID.Trim(), Log.Trim());
        }
    }
}
