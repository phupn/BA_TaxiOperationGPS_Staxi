using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace Taxi.Data
{  /// Lop xu ly file Log_Incoming.mdb
    public class ProcessLog_IncomingFile:Taxi.Utils.Base
    {
        /// <summary>
        /// Lay so Record moi dua vao LogIncoming.mdb 
        /// </summary>
        /// <param name="LogIncomingFilePath">Duong dan tro toi file LogIncoming</param>
        /// <param name="NumberRecord">So ban ghi dau tien can lay ra</param>
        /// <returns>tra ve danh sach cac record can lay ra</returns>
        public static DataTable GetEarlyPhoneCall(string LogIncomingFilePath)
        {

            OleDbConnection dbConn = new OleDbConnection();
            OleDbCommand dbComm = new OleDbCommand ();           
            DataTable dt = new DataTable();

            try
            {  
                OleDbDataReader dbReader;                
                //channel
                DataColumn dcChannel = new DataColumn("ChanelNo", Type.GetType("System.String"));
                dt.Columns.Add(dcChannel);
                //StartTime
                DataColumn dcStartTime = new DataColumn("IiDateTime", Type.GetType("System.String"));
                dt.Columns.Add(dcStartTime);
                //Duration
                DataColumn dcInMemo = new DataColumn("InMemo", Type.GetType("System.String"));
                dt.Columns.Add(dcInMemo);
                //code  
                DataColumn dcCode = new DataColumn("InCode", Type.GetType("System.String"));
                dt.Columns.Add(dcCode);
                //Fomin
                DataColumn dcT1 = new DataColumn("T1", Type.GetType("System.String"));
                dt.Columns.Add(dcT1);



                dbConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; data source=" + LogIncomingFilePath);

                string strSQL = "SELECT  *  FROM SMS_table WHERE T1 <> '1' ORDER BY IiDateTime DESC";


                dbConn.Open();
                dbComm = new OleDbCommand(strSQL, dbConn);
                dbReader = dbComm.ExecuteReader();

                bool boolHasData = false;
                while (dbReader.Read())
                {
                    //
                    DataRow dr = dt.NewRow();
                    dr["ChanelNo"] = dbReader["ChanelNo"].ToString();
                    dr["InCode"] = dbReader["InCode"].ToString();
                    dr["IiDateTime"] = dbReader["IiDateTime"].ToString();
                    dr["InMemo"] = dbReader["InMemo"].ToString();
                    dr["T1"] = dbReader["T1"].ToString();

                    dt.Rows.Add(dr);
                    boolHasData = true;
                    
                }

                dbReader.Close();
                dbReader.Dispose();

                if (boolHasData)
                {
                    //Thiet lap T=1 den danh dau nhung cuoc goi da nhan
                    strSQL = "UPDATE  SMS_table SET T1 = '1' WHERE T1 <> '1'";
                    dbComm = new OleDbCommand(strSQL, dbConn);
                    dbComm.ExecuteNonQuery();
                }

                         
                dbComm.Dispose();

                dbConn.Close();
                dbConn.Dispose ();

                return dt;
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                throw new Exception("DL: Không đọc được dữ liệu phần cứng" + s);
                return null;
            }
            finally
            {

                dt.Dispose();
                dt = null;

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
        /// <summary>
        /// xoa nhung cuoc goi den cach day 
        /// </summary>
        /// <param name="LogIncomingFullPath"></param>
        /// <returns></returns>
        public static bool DeletePhoneCallLogIncomming(DateTime CurrentTime, string LogIncomingFullPath)
        {
            OleDbConnection dbConn =new OleDbConnection ();
            OleDbCommand dbComm=new OleDbCommand ();
             
            try
            {
                DateTime XoaTu = CurrentTime.Subtract(new TimeSpan(0, 10, 0));


                dbConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; data source=" + LogIncomingFullPath);

                string strSQL = "DELETE  FROM SMS_table WHERE   IiDateTime <= '" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", XoaTu) + "'";


                dbConn.Open();
                dbComm = new OleDbCommand(strSQL, dbConn);
                dbComm.ExecuteNonQuery();


                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Loi xoa DeletePhoneCallLogIncomming.", ex);
                return false;
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
