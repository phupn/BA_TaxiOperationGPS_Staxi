using System;
using System.Collections.Generic;
using System.Text;
using Taxi.Utils;
using Taxi.Utils;
using System.IO;

namespace Taxi.Business
{
    /// <summary>
    /// voi cac thong so 
    /// Line,phonenumber,ngaythangnam,giophutgiay, goidi, goiden
    /// </summary>
    public class NgheLaiCuocGoi
    {
        /// <summary>
        /// // <summary>
        /// Thu muc vao co dang
        /// \\bus\XML\GhiAm\
        /// can ghep
        /// \\bus\XML\GhiAm\  + TxRec\REC200809\20080909\06--B-0988013299---20080909150710.wav
        /// </summary>
        /// <param name="FileNameDB">D:\Ghiam\TxRec\REC200809\20080909\06--B-0988013299---20080909150710.wav</param>
        /// <returns></returns>
         
        public static string GetFileNameCuocDi(string FileNameDB)
        {
            //FileNameDB = @"F:\TxRec\REC201306\20130624\12--B-0904620840---20130624101206.wav";
            if (FileNameDB.Length <= 0) return string.Empty;
            string sRootDir = Configuration.GetDuongDanThuMucFileAmThanh();
            if (!sRootDir.Contains(":"))
            {
                //string Filename = FileNameDB.Substring(FileNameDB.IndexOf("TxRec", 0), FileNameDB.Length - FileNameDB.IndexOf("TxRec", 0));
                string Filename = FileNameDB.Substring(FileNameDB.IndexOf("REC", 0), FileNameDB.Length - FileNameDB.IndexOf("REC", 0));

                Filename = @"" + (sRootDir + "\\" + Filename);//Filename = sRootDir + "\\" + Filename;

                if (FileTools.IsExsitFile(Filename))
                    return Filename;
                else return string.Empty;
            }
            return FileNameDB;
        }


        /// <summary>
        /// hàm trả về đường dẫn file âm thanh
        /// theo quy tắc số thời gian
        ///   - tìm đên thư mục của ngày đó, tìm file có Phonenumber và thoidiemgọi + kiểu gọi
        /// 
        /// C:\ : thư mục gốc
        /// C:\TxRec\REC200905\20090516\10--A-50435142581---20090516220241.wav  (A : Cuộc gọi đến)
        ///                                                                     (B : Cuộc gọi đi)   
        /// // lấy ds các file trong ngày
        /// 
        /// </summary>
        /// <param name="PhoneNumber"></param>
        /// <param name="ThoiDiemGoi"></param>
        /// <param name="typeCall"></param>
        /// <returns></returns>
        public static string GetFileVoiceCuaMotCuocGoi(string Line, string PhoneNumber, DateTime ThoiDiemGoi, TypeCall typeCall, string ThuMucFileVoice)
        {
            try
            {
                // Lấy tất cả file thư mục gốc của ngày C:\TxRec\REC200905\20090516
                // tìm các file có PhoneNumber và thơi điểm gọi

                string ThuMucLuuFile = "";
                if (ThuMucFileVoice.Substring(ThuMucFileVoice.Length - 1, 1) == "\\")
                    ThuMucLuuFile = ThuMucFileVoice + "TxRec";
                else ThuMucLuuFile = ThuMucFileVoice + "\\TxRec";

                if (ThoiDiemGoi.Month < 10)
                {
                    ThuMucLuuFile += string.Format("\\REC{0}0{1}", ThoiDiemGoi.Year, ThoiDiemGoi.Month);
                    ThuMucLuuFile += string.Format("\\{0}0{1}", ThoiDiemGoi.Year, ThoiDiemGoi.Month);

                }
                else
                {
                    ThuMucLuuFile += string.Format("\\REC{0}{1}", ThoiDiemGoi.Year, ThoiDiemGoi.Month);
                    ThuMucLuuFile += string.Format("\\{0}{1}", ThoiDiemGoi.Year, ThoiDiemGoi.Month);

                }
                if (ThoiDiemGoi.Day < 10)
                    ThuMucLuuFile += string.Format("0{0}", ThoiDiemGoi.Day);
                else
                    ThuMucLuuFile += string.Format("{0}", ThoiDiemGoi.Day);

                string FilenameThoiDiemGoi = "";

                FilenameThoiDiemGoi = ThoiDiemGoi.Year.ToString() + StringTools.GeMonthString(ThoiDiemGoi.Month) + StringTools.GeDayString(ThoiDiemGoi.Day) + StringTools.GeHourString(ThoiDiemGoi.Hour) + StringTools.GeMinuteString(ThoiDiemGoi.Minute) + StringTools.GeSecondString(ThoiDiemGoi.Second);

                string[] filePaths = Directory.GetFiles(ThuMucLuuFile);
                string retFilenameVoice = "";
                string KieuCuocGoi = "A";
                if (typeCall == TypeCall.Incoming) KieuCuocGoi = "A";
                else KieuCuocGoi = "B";

                List<string> listFilePathsOfPhone = new List<string>();

                // lay ra các cuoc goi cua so dien thoai 
                if ((filePaths != null) && (filePaths.Length > 0))
                {
                    
                    // lay ra các cuoc goi cua so dien thoai 
                    for (int i = 0; i < filePaths.Length; i++)
                    {
                        if ((filePaths[i].Contains(PhoneNumber)) &&  filePaths[i].Contains(KieuCuocGoi))
                        {
                            if (filePaths[i].Substring(filePaths[i].Length-17-1,14 ).CompareTo(FilenameThoiDiemGoi)>=0)
                                listFilePathsOfPhone.Add(filePaths[i]);                            
                        }
                    }
                    if (listFilePathsOfPhone.Count > 0)
                    {
                        retFilenameVoice = listFilePathsOfPhone[0];
                    }
                    else retFilenameVoice = "";
                }
                else retFilenameVoice = "";


                return retFilenameVoice;
            }
            catch (Exception ex)
            {
                return "";  // lỗi không tồn tại thưc mục câm thanh
            }
        }

        public static string GetFileNameCuocDen(string FileNameDB)
        {
            //// tao thu muc 
            //string sDirREC = "REC" + ThoiDiemGoi.Year.ToString() + StringTools.GeMonthString(ThoiDiemGoi.Month);
            //string sDirDay = ThoiDiemGoi.Year.ToString() + StringTools.GeMonthString(ThoiDiemGoi.Month) + StringTools.GeDayString(ThoiDiemGoi.Day);
            //string filename =
            //sRootDir = sRootDir + "\\" + sDirREC + "\\" + sDirDay;

            return string.Empty;
        }
        /// <summary>
        /// hàm trả về thư mục đầy đủ trỏ tới file.
        /// ThuMucLuuAmThanh\TxRec\REC201103\201103012
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ThoiDiemCuocGoiDiDen"></param>
        /// <returns></returns>
        public static string  GetFullDirectory(string ThuMucLuuAmThanh, DateTime ThoiDiemCuocGoiDiDen)
        {


            string ThuMucLuuFile = ThuMucLuuAmThanh;
            //if (ThuMucLuuAmThanh.Substring(ThuMucLuuAmThanh.Length - 1, 1) == "\\")
            //    ThuMucLuuFile = ThuMucLuuAmThanh + "TxRec";
            //else ThuMucLuuFile = ThuMucLuuAmThanh + "\\TxRec";

            if (ThoiDiemCuocGoiDiDen.Month < 10)
            {
                ThuMucLuuFile += string.Format("\\REC{0}0{1}", ThoiDiemCuocGoiDiDen.Year, ThoiDiemCuocGoiDiDen.Month);
                ThuMucLuuFile += string.Format("\\{0}0{1}", ThoiDiemCuocGoiDiDen.Year, ThoiDiemCuocGoiDiDen.Month);
            }
            else
            {
                ThuMucLuuFile += string.Format("\\REC{0}{1}", ThoiDiemCuocGoiDiDen.Year, ThoiDiemCuocGoiDiDen.Month);
                ThuMucLuuFile += string.Format("\\{0}{1}", ThoiDiemCuocGoiDiDen.Year, ThoiDiemCuocGoiDiDen.Month);
            }
            if (ThoiDiemCuocGoiDiDen.Day < 10)
                ThuMucLuuFile += string.Format("0{0}", ThoiDiemCuocGoiDiDen.Day);
            else
                ThuMucLuuFile += string.Format("{0}", ThoiDiemCuocGoiDiDen.Day);

            return ThuMucLuuFile;
        }
        /// <summary>
        /// lay cuoc goi di tu PBX IP
        /// FileNameDB = 12--B-0904620840---20130624101206.wav
        /// return : ThuMuc Share file + FileNameDB
        ///         \\192.168.0..2\12--B-0904620840---20130624101206.wav
        /// </summary>
        /// <param name="FileNameDB"></param>
        /// <returns></returns>
        public static string GetFileNameCuocDiFromPBXIP(string FileNameDB)
        {
            return Config_Common.PBXIPVoicePath + "\\" + FileNameDB;
        }
    }
}
