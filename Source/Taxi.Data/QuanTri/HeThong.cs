using System;
using System.Data;
using System.Data.SqlClient;
using Taxi.Utils;

namespace Taxi.Data
{
    /// <summary>
    /// Quản lý các thông tin của hệ thống
    /// </summary>
    /// <modified>
    /// Người tạo             Ngày tạo           Chú thích
    /// Cuongdb                  ???          
    /// </modified>
   public class HeThong :  DBObject
    {
        public HeThong() { }


        /// <summary>
        /// sao lưu dữ liệu
        /// </summary>
        /// <modified>
        /// Người tạo             Ngày tạo           Chú thích
        /// Cuongdb                  ???          
        /// </modified>
        public void SaoLuuDuLieu(string FileName)
        {
            SqlParameter[] para = { new SqlParameter("@FileName", SqlDbType.NVarChar, 255) };
            para[0].Value = FileName;

            RunProcedure("sp_DB_BACKUP", para,   rowsAffected);
            if (this.ErrorCode != 0)
            {
                throw new Exception("Thư mục sao lưu không tồn tại, hoặc hệ thống không có quyền ghi trên thư mục sao lưu!");
            }
        }
        /// <summary>
        /// Phục hồi dữ liệu
        /// </summary>
        /// <modified>
        /// Người tạo             Ngày tạo           Chú thích
        /// Cuongdb                  ???          
        /// </modified>
        public void PhucHoiDuLieu(string FileName)
        {
            SqlParameter[] para = { new SqlParameter("@FileName", SqlDbType.NVarChar, 255) };
            para[0].Value = FileName;
            RunProcedure("sp_DB_RESTORE", para,   rowsAffected);
            if (this.ErrorCode != 0)
            {
                throw new Exception("Có lỗi trong quá trình phục hồi dữ liệu!");
            }
        }
        /// <summary>
        /// Quản lý thiết lập cơ chế sao lưu
        /// </summary>
        /// <modified>
        /// Người tạo             Ngày tạo           Chú thích
        /// Cuongdb                  ???          
        /// </modified>
        public void ThietLap_ThamSo_SaoLuu(string mTenFile, int mLoaiSaoLuu, string mNgayBatDauSaoLuu, string mGioSaoLuu, int mNgaySaoLuu, int mSoLanTrongNgay)
        {
            try
            {
                int rowAffected = 1;
                SqlParameter[] parameters = new SqlParameter[] { 
				    new SqlParameter("@FileName", SqlDbType.NVarChar,255), 
				    new SqlParameter("@BackupType", SqlDbType.Int), 
                    new SqlParameter("@BackupDate", SqlDbType.Char,8), 
                    new SqlParameter("@BackupTime", SqlDbType.Char,8), 
				    new SqlParameter("@BackupDay", SqlDbType.Int),
                    new SqlParameter("@SoLanTrongNgay", SqlDbType.Int)
				};
                parameters[0].Value = mTenFile;
                parameters[1].Value = mLoaiSaoLuu;
                parameters[2].Value = mNgayBatDauSaoLuu;
                parameters[3].Value = mGioSaoLuu;
                parameters[4].Value = mNgaySaoLuu;
                parameters[5].Value = mSoLanTrongNgay;
                RunProcedure("store_SetupBackupParam", parameters,    rowAffected);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Lấy danh sách lịch sử sao lưu trong hệ thống
        /// </summary>
        /// <modified>
        /// Người tạo             Ngày tạo           Chú thích
        /// Cuongdb                  10/3/2008         
        /// </modified>
        public DataTable LayLichSuSaoLuu()
        {
            SqlParameter[] parameters = new SqlParameter[] { };
            DataSet ds = new DataSet();
            ds = RunProcedure("SP_SYS_BACKUP_HISTORY_SELECT", parameters, "tabBACKUP_HISTORY");
            return ds.Tables[0];
        }
        /// <summary>
        /// Xóa lịch sử sao lưu tại 1 thời điểm
        /// </summary>
        /// <modified>
        /// Người tạo             Ngày tạo           Chú thích
        /// Cuongdb                  10/3/2008          tạo mới
        /// </modified>
        public int DeleteBackUp_History(string mids)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@mids", SqlDbType.NVarChar, 2000) };
            parameters[0].Value = mids;
            try
            {
                RunProcedure("sp_SYS_BACKUP_HISTORY_DELETE", parameters);
                return 0;
            }
            catch
            {
                return 1;
            }
        }
        /// <summary>
        /// Ghi lại lịch sử sao lưu
        /// </summary>
        /// <Modìied>
        /// Name                 date        comments
        /// Cuongdb            10/3/2008       tạo mới
        /// </Modìied>
        public int InsertBackUp_History(DateTime mBackUp_Date, string mBackUp_File)
        {
            SqlParameter[] parameters = new SqlParameter[]
                                        { new SqlParameter("@BackUp_Date", SqlDbType.DateTime),
                                        new SqlParameter("@BackUp_File", SqlDbType.NVarChar, 255) };
            parameters[0].Value = mBackUp_Date;
            parameters[1].Value = mBackUp_File;
            try
            {
                this.RunProcedure("SP_SYS_BACKUP_HISTORY_INSERT", parameters);
                return 0;
            }
            catch (Exception ex)
            {
                return 1;
            }

        }

        public bool SaoLuuToanBoDB(string FileLuu)
        {
            string strSQL = "BACKUP DATABASE " + this.myConnection.Database + "  TO DISK ='" + FileLuu + "'";
        
             try
             {
                 int err = this.RunSQL(strSQL);
                 return (err==0);
             }
             catch(Exception ex)
             {
                 return false;
             }
        }
    }
}

