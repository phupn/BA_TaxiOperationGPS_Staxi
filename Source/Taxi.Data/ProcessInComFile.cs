using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace Taxi.Data
{
    public class ProcessInComFile:Taxi.Utils.Base
    {
        /// <summary>
        ///  /// <summary>
        /// Truyen cao mot so dien thoai va thoi gian bat dau
        /// Neu trong file co so nay va co thoi gian lon hon thi la cuoc goi nho
        /// Output : Null ; khong co trong do
        ///          Datetime : la thoi ma khach hang cup may, va xu ly
        /// </summary>
        /// <param name="PhoneNumber"></param>
        /// <param name="StartTime"></param>
        /// <returns></returns>
        /// </summary>

        public static DateTime GetSetTimeOfCall(string PhoneNumber, DateTime StartTime, string IncomFilename)
        {
            OleDbConnection dbConn = new OleDbConnection ();
            OleDbCommand dbComm = new OleDbCommand ();
            try
            {
                DateTime dateTime = DateTime.MinValue; ;


                OleDbDataReader dbReader;

                dbConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; data source=" + IncomFilename);

                string strSQL = "SELECT  *  FROM inlog WHERE (incode ='" + PhoneNumber + "') AND (settime >= '" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", StartTime) + "' )";


                dbConn.Open();
                dbComm = new OleDbCommand(strSQL, dbConn);
                dbReader = dbComm.ExecuteReader();
                bool HasData = false;
                while (dbReader.Read())
                {
                    dateTime = DateTime.Parse(dbReader["settime"].ToString());
                    HasData = true;
                }
                dbReader.Close();

                if (HasData)
                {
                    //Thiet lap T=1 den danh dau nhung cuoc goi da nhan
                    strSQL = "DELETE FROM inlog  WHERE (incode ='" + PhoneNumber + "') AND    (settime >= '" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", StartTime) + "' )";
                    dbComm = new OleDbCommand(strSQL, dbConn);
                    dbComm.ExecuteNonQuery();


                }
                dbComm.Dispose();

                dbConn.Close();
                dbConn.Dispose();

                return dateTime;
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                new Exception("DL: Không đọc được dữ liệu phần cứng" + s);
                return DateTime.MinValue;
            }
            finally
            {
                if (dbComm != null)
                {
                    dbComm.Dispose();
                }
                if (dbConn != null)
                {
                    dbConn.Close();
                    dbConn.Dispose();
                }
            }
        }

      
    }
}

