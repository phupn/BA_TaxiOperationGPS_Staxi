using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.OleDb;

namespace Taxi.Data
{
    public class ProcessVocFile: Taxi.Utils.Base
    {
        /// <summary>
        /// Doc du lieu tu file VOC<YYYY-MM>
        /// </summary>
        /// <param name="VocFilePath">Duong dan tro toi file</param>
        /// <param name="NumberRecord">So ban ghi som nhat can doc, thuong doc la 3</param>
        /// <returns>tra ve mot datatable luu du lieu của 3 ban ghi som nhất</returns>
        public static  DataTable GetEarlyPhoneCall(string VocFilePath,int NumberRecord)
        {
            OleDbConnection dbConn = new OleDbConnection ();
            OleDbCommand dbComm = new OleDbCommand ();
            DataTable dt = new DataTable();
            try
            {
                
                //channel
                DataColumn dcChannel = new DataColumn("channel", Type.GetType("System.String"));
                dt.Columns.Add(dcChannel);
                //StartTime
                DataColumn dcStartTime = new DataColumn("StartTime", Type.GetType("System.String"));
                dt.Columns.Add(dcStartTime);
                //Duration
                DataColumn dcDuration = new DataColumn("Duration", Type.GetType("System.String"));
                dt.Columns.Add(dcDuration);
                //code
                DataColumn dcCode = new DataColumn("code", Type.GetType("System.String"));
                dt.Columns.Add(dcCode);
                //Fomin
                DataColumn dcFomin = new DataColumn("Fomin", Type.GetType("System.String"));
                dt.Columns.Add(dcFomin);
                //Type 
                DataColumn dcType = new DataColumn("Type", Type.GetType("System.String"));
                dt.Columns.Add(dcType);
                //filepalh
                DataColumn dcFilepath = new DataColumn("filepalh", Type.GetType("System.String"));
                dt.Columns.Add(dcFilepath);

                
                OleDbDataReader dbReader;

                dbConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; data source=" + VocFilePath);

                string strSQL = "SELECT  TOP " + NumberRecord.ToString() + " * FROM VOC ORDER BY StartTime DESC";


                dbConn.Open();
                dbComm = new OleDbCommand(strSQL, dbConn);
                dbReader = dbComm.ExecuteReader();
                
                while (dbReader.Read())
                {
                    //
                    DataRow dr = dt.NewRow();
                    dr["channel"] = dbReader["channel"].ToString();
                    dr["StartTime"] = dbReader["StartTime"].ToString();
                    dr["Duration"] = dbReader["Duration"].ToString();
                    dr["code"] = dbReader["code"].ToString();
                    dr["Fomin"] = dbReader["Fomin"].ToString();
                    dr["Type"] = dbReader["Type"].ToString();
                    dr["filepalh"] = dbReader["filepalh"].ToString();
                    dt.Rows.Add(dr);

                }
                dbReader.Close();
                dbReader.Dispose();
                dbComm.Dispose();
                dbConn.Close();
                dbConn.Dispose();

                return dt;
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                throw new Exception("Loi duoc du lieu phan cung - GetEarlyPhoneCall");
               
            }
            finally
            {
                if (dt != null)
                {
                    dt.Dispose();
                    dt = null;
                }
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
            return null;  
        }

        /// <summary>
       /// Lay thoi gian thoi diem bat dau nghe
       /// Tim la so chuong do
       /// </summary>
       /// <returns>thoi gian bat dau nhac may nghe</returns>
        public static DateTime GetStartTimeHearCall(string PhoneNumber, DateTime  StartTimeCall, string VOCFilenamePath)
        {
            OleDbConnection dbConn = new OleDbConnection ();
            OleDbCommand dbComm =  new OleDbCommand ();
            try
            {
                DateTime dateTime = DateTime.MinValue; ;

              
                OleDbDataReader dbReader;

                dbConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; data source=" + VOCFilenamePath );

                string strSQL = "SELECT  *  FROM voc WHERE (code ='" + PhoneNumber + "') AND (StartTime >='" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", StartTimeCall) + "')  AND (Fomin='Incoming') ";

                dbConn.Open();
                dbComm = new OleDbCommand(strSQL, dbConn);
                dbReader = dbComm.ExecuteReader();
                bool HasData = false;
                while (dbReader.Read())
                {
                    dateTime = DateTime.Parse(dbReader["StartTime"].ToString());
                    HasData = true;
                }
                dbReader.Close();
                dbReader.Dispose();

                if (HasData)
                {
                    //Thiet lap T=1 den danh dau nhung cuoc goi da nhan
                    strSQL = "UPDATE  voc SET EXT = '1' WHERE (EXT <> '1') AND (Fomin='Incoming') ";
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
                throw new Exception("DL: Không đọc được dữ liệu phần cứng" + s);
                
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
            return DateTime.MinValue;
        }
        
        /// <summary>
        /// lay thông tin cuộc gọi đi
        /// </summary>
        /// <param name="VOCFilenamePath"></param>
        /// <returns></returns>
        public static DataTable GetEarlyPhoneDialOut(string  VOCFilenamePath)
        {
            DataTable dt = new DataTable();
            OleDbConnection dbConn=new OleDbConnection ();
            OleDbCommand dbComm =new OleDbCommand ();
            try
            {   
                //Line, PhoneNumber,ThoiDiemGoi,DoDaiCuocGoi,VoiceFilePath
                
                //channel
                DataColumn dcChannel = new DataColumn("Line", Type.GetType("System.String"));
                dt.Columns.Add(dcChannel);
                //StartTime
                DataColumn dcStartTime = new DataColumn("PhoneNumber", Type.GetType("System.String"));
                dt.Columns.Add(dcStartTime);
                //Duration
                DataColumn dcInMemo = new DataColumn("ThoiDiemGoi", Type.GetType("System.DateTime"));
                dt.Columns.Add(dcInMemo);
                //code  
                DataColumn dcCode = new DataColumn("DoDaiCuocGoi", Type.GetType("System.DateTime"));
                dt.Columns.Add(dcCode);
                //Fomin
                DataColumn dcT1 = new DataColumn("VoiceFilePath", Type.GetType("System.String"));
                dt.Columns.Add(dcT1);


                
                OleDbDataReader dbReader;

                dbConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; data source=" + VOCFilenamePath);
                //Fomin='DialOut'
                string strSQL = "SELECT  channel,code,StartTime,Duration ,filepalh  FROM VOC WHERE (K1 <> '1') AND (Fomin='DialOut') AND (Duration <> '00:00:00') ORDER BY StartTime DESC";

                dbConn.Open();
                dbComm = new OleDbCommand(strSQL, dbConn);
                dbReader = dbComm.ExecuteReader();
                bool boolHasData = false;
                while (dbReader.Read())
                {
                    //Line, PhoneNumber,ThoiDiemGoi,DoDaiCuocGoi,VoiceFilePath
                    DataRow dr = dt.NewRow();
                    dr["Line"] = dbReader["channel"].ToString();
                    dr["PhoneNumber"] = dbReader["code"].ToString();
                    dr["ThoiDiemGoi"] =DateTime .Parse (dbReader["StartTime"].ToString());

                    string sDuration = dbReader["Duration"].ToString();
                    int Hours = Convert .ToInt32 (sDuration.Substring(0,2));
                    int Minute = Convert .ToInt32 (sDuration.Substring(3,2));
                    int Second = Convert .ToInt32 (sDuration.Substring(6,2));
                    dr["DoDaiCuocGoi"] = new DateTime(1900, 1, 1, Hours, Minute, Second);

                    dr["VoiceFilePath"] = dbReader["filepalh"].ToString();

                    dt.Rows.Add(dr);
                    boolHasData = true;
                }

                dbReader.Close();
                dbReader.Dispose();

                if (boolHasData)
                {
                    //Thiet lap T=1 den danh dau nhung cuoc goi da nhan
                    strSQL = "UPDATE  VOC SET K1 = '1' WHERE (K1 <> '1') AND (Fomin='DialOut') AND  (Duration <> '00:00:00')";
                    dbComm = new OleDbCommand(strSQL, dbConn);
                    dbComm.ExecuteNonQuery();
                }

                    dbComm.Dispose();

                    dbConn.Close();
                    dbConn.Dispose();
                
                return dt;
            }
            catch (Exception ex)
            {
                string s = ex.Message;
               throw  new Exception("DL: Không đọc được dữ liệu phần cứng - Doc du lieu cuoc goi di " + s);
                
            }
            finally
            {
                if (dt != null)
                {
                    dt.Dispose();
                    dt = null;
                }
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
            return null;
        }


        public static bool GetVoiceFile_DurationHearCall(string PhoneNumber, DateTime StartTimeCall, string VOCFilenamePath, out DateTime Duration, out string VoiceFilePath)
        {
            Duration = DateTime.MinValue;
            VoiceFilePath =string.Empty ;
            OleDbConnection dbConn = new OleDbConnection ();
            OleDbCommand dbComm = new OleDbCommand ();
            try
            { 
                OleDbDataReader dbReader;

                dbConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; data source=" + VOCFilenamePath);

                string strSQL = "SELECT  *  FROM voc WHERE (code ='" + PhoneNumber + "') AND (StartTime >='" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", StartTimeCall) + "') AND (Duration <> '00:00:00') AND (K1<>'1')  AND (Fomin='Incoming') AND ( LEN (filepalh)>0) ";

                dbConn.Open();
                dbComm = new OleDbCommand(strSQL, dbConn);
                dbReader = dbComm.ExecuteReader();
                bool HasData = false;
                while (dbReader.Read())
                {

                    string sDuration = dbReader["Duration"].ToString();
                    int Hours = Convert.ToInt32(sDuration.Substring(0, 2));
                    int Minute = Convert.ToInt32(sDuration.Substring(3, 2));
                    int Second = Convert.ToInt32(sDuration.Substring(6, 2));

                    Duration = new DateTime(1900, 1, 1, Hours, Minute, Second);
                    VoiceFilePath = dbReader["filepalh"].ToString();

                    HasData = true;
                }
                dbReader.Close();
                dbReader.Dispose();

                if (HasData)
                {
                    //Thiet lap K1=1 den danh dau nhung cuoc goi da nhan
                    strSQL = "UPDATE  VOC SET K1 = '1' WHERE (K1 <> '1') AND (Fomin='Incoming') AND  (Duration <> '00:00:00')  AND ( LEN (filepalh)>0) ";
                    dbComm = new OleDbCommand(strSQL, dbConn);
                    dbComm.ExecuteNonQuery();
                }
                
                dbComm.Dispose();
                dbConn.Close();
                dbConn.Dispose();

                return HasData;
            }
            catch (Exception ex)
            {
                string s = ex.Message;
               throw  new Exception("DL: Không đọc được dữ liệu phần cứng" + s);
               
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
            return false;
        }

        public static DataTable GetListVoiceFile_DurationHearCall(string VOCFilenamePath)
        {

            OleDbConnection dbConn = new OleDbConnection ();
            OleDbCommand dbComm = new OleDbCommand ();
            DataTable dt = new DataTable();
            try
            {
                //Line, PhoneNumber,ThoiDiemGoi,DoDaiCuocGoi,VoiceFilePath
                
                //channel
                DataColumn dcChannel = new DataColumn("Line", Type.GetType("System.String"));
                dt.Columns.Add(dcChannel);
                //StartTime
                DataColumn dcStartTime = new DataColumn("PhoneNumber", Type.GetType("System.String"));
                dt.Columns.Add(dcStartTime);
                //Duration
                DataColumn dcInMemo = new DataColumn("ThoiDiemGoi", Type.GetType("System.DateTime"));
                dt.Columns.Add(dcInMemo);
                //code  
                DataColumn dcCode = new DataColumn("DoDaiCuocGoi", Type.GetType("System.DateTime"));
                dt.Columns.Add(dcCode);
                //Fomin
                DataColumn dcT1 = new DataColumn("VoiceFilePath", Type.GetType("System.String"));
                dt.Columns.Add(dcT1);


                OleDbDataReader dbReader;

                dbConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; data source=" + VOCFilenamePath);
                //Fomin='Incomming'
                string strSQL = "SELECT  *  FROM voc WHERE     (Duration <> '00:00:00') AND (K1<>'1')  AND (Fomin='Incoming') AND ( LEN (filepalh)>1) ";

                dbConn.Open();
                dbComm = new OleDbCommand(strSQL, dbConn);
                dbReader = dbComm.ExecuteReader();
                bool boolHasData = false;
                while (dbReader.Read())
                {
                    //Line, PhoneNumber,ThoiDiemGoi,DoDaiCuocGoi,VoiceFilePath
                    DataRow dr = dt.NewRow();
                    dr["Line"] = dbReader["channel"].ToString();
                    dr["PhoneNumber"] = dbReader["code"].ToString();
                    dr["ThoiDiemGoi"] = DateTime.Parse(dbReader["StartTime"].ToString());

                    string sDuration = dbReader["Duration"].ToString();
                    int Hours = Convert.ToInt32(sDuration.Substring(0, 2));
                    int Minute = Convert.ToInt32(sDuration.Substring(3, 2));
                    int Second = Convert.ToInt32(sDuration.Substring(6, 2));
                    dr["DoDaiCuocGoi"] = new DateTime(1900, 1, 1, Hours, Minute, Second);

                    dr["VoiceFilePath"] = dbReader["filepalh"].ToString();

                    dt.Rows.Add(dr);
                    boolHasData = true;
                }

                dbReader.Close();
                dbReader.Dispose();
                if (boolHasData)
                {
                    //Thiet lap T=1 den danh dau nhung cuoc goi da nhan
                    strSQL = "UPDATE  VOC SET K1 = '1' WHERE  (Duration <> '00:00:00') AND (K1<>'1')  AND (Fomin='Incoming') AND ( LEN (filepalh)>1)";
                    dbComm = new OleDbCommand(strSQL, dbConn);
                    dbComm.ExecuteNonQuery();
                }
                dbComm.Dispose();

                dbConn.Close();
                dbConn.Dispose();

                return dt;
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                throw new Exception("DL: Không đọc được dữ liệu phần cứng" + s +"  " + ex.InnerException.Message );
                
            }
            finally
            {
                if (dt != null)
                {
                    dt.Dispose();
                    dt = null;
                }
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
            return null;
       }

        /// <summary>
        /// xoa nhung cuoc goi den cach day 
        /// </summary>
        /// <param name="LogIncomingFullPath"></param>
        /// <returns></returns>
        public static bool DeletePhoneCallVocFile(DateTime CurrentTime, string VOCFilenamePath)
        {
            OleDbConnection dbConn =  new OleDbConnection ();
            OleDbCommand dbComm = new OleDbCommand();
            try
            {
                DateTime XoaTu = CurrentTime.Subtract(new TimeSpan(0, 10, 0)); 

                dbConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; data source=" + VOCFilenamePath);

                string strSQL = "DELETE  FROM VOC WHERE   StartTime <= '" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", XoaTu) + "'";


                dbConn.Open();
                dbComm = new OleDbCommand(strSQL, dbConn);
                dbComm.ExecuteNonQuery();

                dbComm.Dispose();

                dbConn.Close();
                dbConn.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                
                throw new Exception("Loi xoa DeletePhoneCallVocFile.", ex);
                
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
           return false; 
        }


    }
}
