using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Taxi.Business
{
    public class ProcessLog_IncomingFile
    {
        #region Members

        // Kenh, line (duong day may
        private int mChannel;
        public int Channel
        {
            get { return mChannel; }
            set { mChannel = value; }
        }

        // Thoi gian bat dau nghe
        private string mStartTime;
        // Thoi gian bat dau nghe, goi
        // Format : 2008-06-30 15:46:19
        public string StartTime
        {
            get { return mStartTime; }
            set { mStartTime = value; }
        }
        /// <summary>
        /// Quang thoi gian nghe, goi
        /// </summary>


        //Phone numer
        private string mPhoneNumber;
        /// <summary>
        /// PhoneNumber
        /// </summary>
        public string PhoneNumber
        {
            get { return mPhoneNumber; }
            set { mPhoneNumber = value; }
        }
        #endregion Members

        #region Contruction
        public ProcessLog_IncomingFile() { }
        public ProcessLog_IncomingFile(int Channel, string StartTime, string PhoneNumber)
        {
            this.Channel = Channel;
            this.StartTime = StartTime;
            this.PhoneNumber = PhoneNumber;
        }
        #endregion Contruction

        public static List<ProcessLog_IncomingFile> GetEarlyPhoneCall(string LogIncomingFullPath)
        {

            List<ProcessLog_IncomingFile> lstRecords = new List<ProcessLog_IncomingFile>();
             DataTable dt  ;
             

                dt = Taxi.Data.ProcessLog_IncomingFile.GetEarlyPhoneCall(LogIncomingFullPath);
                if ((dt != null) && (dt.Rows.Count > 0))
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ProcessLog_IncomingFile pLogIncomingFile = new ProcessLog_IncomingFile();
                        pLogIncomingFile.Channel = int.Parse(dr["ChanelNo"].ToString());
                        pLogIncomingFile.StartTime = dr["IiDateTime"].ToString();
                        pLogIncomingFile.PhoneNumber = dr["InCode"].ToString();

                        lstRecords.Add(pLogIncomingFile);

                    }
                }
                dt.Dispose();
                dt = null;
             
            return lstRecords;
             
        }

        public static bool DeletePhoneCallLogIncomming(DateTime CurrentTime, string LogIncomingFullPath)
        {
            return Data.ProcessLog_IncomingFile.DeletePhoneCallLogIncomming(  CurrentTime, LogIncomingFullPath);
        }
    }
}
