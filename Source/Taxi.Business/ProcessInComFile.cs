using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Taxi.Business
{   /// Nhan vao mot so dien thoai va thoi gian
    /// Check xem co so dien thoai nao trong InCom co cung so va lon hon thoi gian nay khong
    /// Neu co thi lay ra thoi gian--> So chuong do
    public class ProcessInComFile
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
        private string mSetTime;
        // Thoi gian bat dau nghe, goi
        // Format : 2008-06-30 15:46:19
        public string SetTime
        {
            get { return mSetTime; }
            set { mSetTime = value; }
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

        public ProcessInComFile()
        { }
        public ProcessInComFile(string Channel, string PhoneNumber, string SetTime)
        {
            this.Channel =int.Parse (Channel);
            this.PhoneNumber = PhoneNumber;
            this.SetTime = SetTime;
        }
        /// <summary>
        /// Truyen cao mot so dien thoai va thoi gian bat dau
        /// Neu trong file co so nay va co thoi gian lon hon thi la cuoc goi nho
        /// Output : Null ; khong co trong do
        ///          Datetime : la thoi ma khach hang cup may, va xu ly
        /// </summary>
        /// <param name="PhoneNumber"></param>
        /// <param name="StartTime"></param>
        /// <returns></returns>
        public static DateTime GetSetTimeOfCall(string PhoneNumber, DateTime StartTime, string InComFilename)
        {
            DateTime dateSettime= Data.ProcessInComFile.GetSetTimeOfCall(PhoneNumber, StartTime, InComFilename);

            if (dateSettime != DateTime.MinValue)
            {
                return dateSettime ;
            }
            return DateTime.MinValue ;
        }
    }
}
