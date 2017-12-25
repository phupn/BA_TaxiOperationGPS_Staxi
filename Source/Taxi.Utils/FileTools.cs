using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Taxi.Utils
{
    /// <summary>
    ///  Lớp thao tac với file trong Taxi
    /// </summary>
    /// <Modified>        
    ///	Name		Date		    Comment 
    /// Côngnt      12/05/2007      Create
    /// </Modified>
    public class FileTools
    {  
        /// <summary>
        /// Kiểm tra thư mục có tồn tại không
        /// </summary>
        /// <param name="DirectoryPath">đường dẫn lưu file</param>
        /// <returns>true : tồn tại; false không tồn tại</returns>
        public static bool IsExsitDirectory(string DirectoryPath)
        {
            try
            {
                return new DirectoryInfo(DirectoryPath).Exists;
            }
            catch 
            {
                return false;
            }            
        }
        /// <summary>
        /// Kiểm tra một file có tồn tại không
        /// </summary>
        /// <param name="FilePath"> đường dẫn đầy đủ tới file</param>
        /// <returns>true : file đã tồn tại ; false : không tồn tại</returns>
        public static bool IsExsitFile(string FilePath)
        {
            try
            {
                FileInfo objFileInfo = new FileInfo(FilePath);

                return objFileInfo.Exists;
            }
            catch 
            {
                return false;
            }
        }
        /// <summary>
        /// Copy một file tới một nơi khác
        /// </summary>
        /// <param name="SourceFile">file nguồn </param>
        /// <param name="DestinationFile">file đích</param>
        /// <returns>true : copy thành công ; false : lỗi copy</returns>
        public static bool CopyFileTo(string SourceFile, string DestinationFile)
        {
            try
            {
                FileInfo objFileInfo = new FileInfo(SourceFile);
                objFileInfo.CopyTo(DestinationFile);
                return true;
            }
            catch 
            {
                return false;
            }
        }
        /// <summary>
        /// Xóa một file
        /// </summary>
        /// <param name="Filename"></param>
        /// <returns>true : xóa thành công ; false : lỗi xóa file</returns>
        public static bool  DeleteFile(string Filename)
        {
            try
            {
                FileInfo objFileInfo = new FileInfo(Filename);
                objFileInfo.Delete();
                return true;
            }
            catch 
            {
                return false;
            }
        }
        /// <summary>
        /// Get tên của file trong đường dẫn tới file
        /// </summary>
        /// <param name="FilePath">full paths và file name</param>
        /// <returns>filename + Extension</returns>
        public static string GetFileName(string FilePath)
        {
            FileInfo objFileInfo = new FileInfo(FilePath);

             return objFileInfo.Name + "." + objFileInfo.Extension;  
        }
        /// <summary>
        /// laays  phần mở rộng của file
        /// </summary>
        /// <param name="FilePath"></param>
        /// <returns>trả về phần mở rộng của file</returns>
        public static string GetExtensionFile(string FilePath)
        {
            FileInfo objFileInfo = new FileInfo(FilePath);
            return  objFileInfo.Extension;
        }

        public static string[] SearchFileInDirectory(string DirectoryName, string Filename)
        {
            try
            {
                string[] files = Directory.GetFiles(DirectoryName, Filename, SearchOption.AllDirectories);
                return files;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tìm file gốc.", ex);    
            }
        }

        public static void OpenFileExcel(string FileName)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "EXCEL.EXE";
            startInfo.Arguments = FileName;
            Process.Start(startInfo);
        }
        /// <summary>
        /// hàm thực hiện mở một thư mục
        /// </summary>
        public static void OpenDirectory(string directoryName)
        {
            Process.Start(directoryName);
        }
        /// <summary>
        /// tạo tên file báo cáo  
        /// </summary>
        public static string GetFilenameReport(string reportName, DateTime tuNgay, DateTime denNgay,bool coLayGioPhut)
        {   string reportNameTemp = reportName;
            if (coLayGioPhut)
            {
                reportNameTemp += string.Format("_{0:HH_mm_dd_MM_yyyy}_{1:HH_mm_dd_MM_yyyy}.xls", tuNgay, denNgay);
            }
            else
            {
                reportNameTemp += string.Format("_{0:dd_MM_yyyy}_{1:dd_MM_yyyy}.xls", tuNgay, denNgay);
            }
            return reportNameTemp;
        }
    }
}
