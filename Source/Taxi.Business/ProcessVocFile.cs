using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Taxi.Utils;

namespace Taxi.Business
{  /// Process Voc file of hardware tra ve
   public class ProcessVocFile
   {
       #region Members
       private string mSign;
       // Tin hieu
       public string Sign
       {
           get { return mSign; }
           set { mSign = value; }
       }
       // Kenh, line (duong day may
       private int mChannel;
       public int Channel
       {
           get { return mChannel; }
           set { mChannel = value; }
       }

       private string mNameCode;
       public string NameCode
       {
           get { return mNameCode; }
           set { mNameCode = value; }
       }

       private string mTRK;

       public string TRK
       {
           get { return mTRK; }
           set { mTRK = value; }
       }

       private string mEXT;

       public string EXT
       {
           get { return mEXT; }
           set { mEXT = value; }
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
 
       private string mDuration;
       ///
       /// Quang thoi gian nghe, goi
       /// Format : 00:00:15
       /// 
       public string Duration
       {
           get { return mDuration; }
           set { mDuration = value; }
       }

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

       private string mInOut;
       /// <summary>
       /// Nghe , goi (DialOut, Incoming)
       /// </summary>
       public string InOut
       {
           get { return mInOut; }
           set { mInOut = value; }
       }

       private string mKindOfPhone;
       /// <summary>
       /// Kieu dien thoai, Co dinh, Di dong
       /// City, DDD
       /// </summary>
       public string KindOfPhone
       {
           get { return mKindOfPhone; }
           set { mKindOfPhone = value; }
       }

       private string mWavFileFullPath;
       /// <summary>
       /// Duong dan chi toi file wav
       /// </summary>
       public string WavFileFullPath
       {
           get { return mWavFileFullPath; }
           set { mWavFileFullPath = value; }
       }

       //Phan mo rong trong file  [Voc<YYYY-MM>.MDB
       private string K1;
       private string K2;
#endregion Members

       #region contruction 
       public ProcessVocFile() { }
       public  ProcessVocFile(int Channel,string StartTime,string Duration,string PhoneNumber,string InOut,string KindOfPhone,string WavFileFullPath)
       {
           this.Channel = Channel ;
           this.StartTime = StartTime ;
           this.Duration = Duration;
           this.PhoneNumber = PhoneNumber ;
           this.InOut = InOut;
           this.KindOfPhone = KindOfPhone;
           this.WavFileFullPath = WavFileFullPath;
       }
       #endregion contruction

       #region Memthods

       /// <summary>
       /// Lay ra danh sach so Record moi nhat trong file VOC 
       /// </summary>
       /// <param name="VOCFullPath"> Duong dan toi file VOC</param>
       /// <param name="intRecord">So record can lay</param>
       /// <returns>Mot danh sach thong tin file Voc</returns>
       public static List<ProcessVocFile> GetEarlyPhoneCall(string VOCFullPath,int intRecord)
       {
           DataTable dt = new DataTable();
           List<ProcessVocFile> lstRecords = new List<ProcessVocFile>();
           dt =Taxi.Data.ProcessVocFile.GetEarlyPhoneCall(VOCFullPath, intRecord);   
           if(dt.Rows.Count >0)
           {
               foreach(DataRow dr in dt.Rows )
               {
                   ProcessVocFile pVocFile = new ProcessVocFile();
                   pVocFile.Channel = int.Parse(dr["channel"].ToString());
                   pVocFile.StartTime = dr["StartTime"].ToString();
                   pVocFile.Duration = dr["Duration"].ToString();
                   pVocFile.PhoneNumber = dr["code"].ToString();
                   pVocFile.InOut = dr["Fomin"].ToString();
                   pVocFile.KindOfPhone = dr["Type"].ToString();
                   pVocFile.WavFileFullPath = dr["filepalh"].ToString();
                   lstRecords.Add(pVocFile);
                   
               }
           }
           dt.Dispose();
           dt = null;
           return lstRecords;
       }
       /// <summary>
       /// Lay file VOC full path
       /// </summary>
       /// <returns></returns>
       public static string GetVOCFileFullPath()
       {
           return Configuration.VocFilePath() + "\\" + "Voc" + DateTime.Now.Year.ToString () + "-" + StringTools.GeMonthString( DateTime.Now.Month) +".mdb";
       }
       /// <summary>
       /// Lay theo thoi gian cua may chu
       /// </summary>
       /// <returns></returns>
       public static string GetVOCFileFullPath(DateTime TimeServer)
       {
           return Configuration.VocFilePath() + "\\" + "Voc" + TimeServer.Year.ToString() + "-" + StringTools.GeMonthString(TimeServer.Month) + ".mdb";
       }
       #endregion Memthods

       /// <summary>
       /// Lay thoi gian thoi diem bat dau nghe
       /// Tim la so chuong do
       /// </summary>
       /// <returns>thoi gian bat dau nhac may nghe</returns>
       public static DateTime GetStartTimeHearCall(string PhoneNumber, DateTime  StartTimeCall,string VOCFilenamePath)
       {
           return  Data.ProcessVocFile.GetStartTimeHearCall(PhoneNumber, StartTimeCall, VOCFilenamePath);     
       }
       /// <summary>
       /// lay thong tin ve dodaicuocgoi, filepath of am thanh
       /// </summary>
       /// <param name="PhoneNumber"></param>
       /// <param name="StartTimeCall"></param>
       /// <param name="VOCFilenamePath"></param>
       /// <param name="Duration"></param>
       /// <param name="VoiceFilePath"></param>
       /// <returns></returns>
       public static bool GetVoiceFile_DurationHearCall(string PhoneNumber, DateTime StartTimeCall, string VOCFilenamePath, out  DateTime Duration, out string VoiceFilePath)
       {
           return Data.ProcessVocFile.GetVoiceFile_DurationHearCall(PhoneNumber, StartTimeCall, VOCFilenamePath, out  Duration, out VoiceFilePath);
       }
    

       public static bool UpdateVoiceFile_DurationHearCall()
       {
           // Tim trong cuoc goi duoc nghe
           try
           {
               DateTime timeServer = DieuHanhTaxi.GetTimeServer();
               string VOCFileName = ProcessVocFile.GetVOCFileFullPath(timeServer);
               DataTable dtCalls = new DataTable();
               dtCalls = Data.ProcessVocFile.GetListVoiceFile_DurationHearCall(VOCFileName);

               if ((dtCalls != null) && (dtCalls.Rows.Count > 0))
               {
                   foreach (DataRow dr in dtCalls.Rows)
                   {
                  
                       if (!DieuHanhTaxi.UpdateCuocGoiDenFileVoice_Duration (dr["Line"].ToString(), dr["PhoneNumber"].ToString(), (DateTime)dr["ThoiDiemGoi"], (DateTime)dr["DoDaiCuocGoi"], dr["VoiceFilePath"].ToString()))
                       {
                           ////  LogError.WriteLog("Loi luu xuong DB cuoc goi Duration ", new Exception("[ UpdateVoiceFile_DurationHearCall ]"));
                       }
                   }
               }
               dtCalls.Dispose();
               dtCalls = null;
               
               return true;
           }
           catch (Exception ex)
           {
               ////  LogError.WriteLog("Loi cap nhat Duration -VoiceFile GetListVoiceFile_DurationHearCall : ", ex); return false;
           }
           return false;
       }
       public static DataTable GetEarlyPhoneDialOut(string VOCFilenamePath)
       {
           return Data.ProcessVocFile.GetEarlyPhoneDialOut(VOCFilenamePath);
       }

       public static bool DeletePhoneCallVocFile(DateTime CurrentTime, string VOCFilenamePath)
       {
           return Data.ProcessVocFile.DeletePhoneCallVocFile(CurrentTime, VOCFilenamePath); 
       }
   }


}
