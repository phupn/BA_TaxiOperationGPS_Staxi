using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Data;
using Taxi.Data;
namespace Taxi.Business
{
    /// <summary>
    /// Quản lý các thông tin của hệ thống
    /// </summary>
    /// <modified>
    /// Người tạo             Ngày tạo           Chú thích
    /// Cuongdb                  ???          
    /// </modified>
    public class HeThong
    {
        #region Cac thuoc tinh cua he thong

        private string mDiaChiCSDL = "";
        public string DiaChiCSDL 
        {
            get { return mDiaChiCSDL; }
            set { mDiaChiCSDL = value; }
        }
        private string mTenCSDL = "";
        public string TenCSDL 
        {
            get { return mTenCSDL; }
            set { mTenCSDL = value; }
        }
        private string mUser_ID = "";
        public string USER_ID 
        {
            get { return mUser_ID; }
            set { mUser_ID = value; }
        }

        private string mMatKhau = "";
        public string MatKhau 
        {
            get { return mMatKhau; }
            set { mMatKhau = value; }
        }
        private string mDiaChiMayChu = "";
        public string DiaChiMayChu 
        {
            get { return mDiaChiMayChu; }
            set { mDiaChiMayChu = value; }
        }
        private string mThuMucSaoLuu = "";
        public string ThuMucSaoLuu 
        {
            get { return mThuMucSaoLuu; }
            set { mThuMucSaoLuu = value; }
        }
        private string mFileSaoLuu = "";
        public string FileSaoLuu 
        {
            get { return mFileSaoLuu; }
            set { mFileSaoLuu = value; }
        }
        #endregion

        Data.HeThong objPara = new Data.HeThong();
        public HeThong() 
        {
            if(objPara !=null )
            objPara = new  Data.HeThong();
        }
        /// <summary>
        /// sao lưu dữ liệu
        /// </summary>
        /// <modified>
        /// Người tạo             Ngày tạo           Chú thích
        /// Cuongdb                  ???          
        /// </modified>
        public void SaoLuuDuLieu(string FileSaoLuu) 
        {
            try 
            {
                objPara.SaoLuuDuLieu(FileSaoLuu);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Phục hồi dữ liệu
        /// </summary>
        /// <modified>
        /// Người tạo             Ngày tạo           Chú thích
        /// Cuongdb                  ???          
        /// </modified>
        public void PhucHoiDuLieu(string FilePhucHoi)
        {
            try
            {
                objPara.PhucHoiDuLieu(FilePhucHoi);
            }
            catch (Exception ex)
            {
                throw ex;
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
                objPara.ThietLap_ThamSo_SaoLuu(mTenFile, mLoaiSaoLuu, mNgayBatDauSaoLuu, mGioSaoLuu, mNgaySaoLuu, mSoLanTrongNgay);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Mã hóa chuỗi 
        /// </summary>
        /// <modified>
        /// Người tạo             Ngày tạo           Chú thích
        /// Cuongdb                  ???          
        /// </modified>
        public static string MaHoa(string ChuoiCanMaHoa)
        {
            string Khoa = "12345678";
            if (ChuoiCanMaHoa == "")
            {
                return "";
            }
            try
            {
                byte[] byKey = new byte[0];
                byte[] IV = { 1, 2, 3, 4, 1, 2, 3, 4 };
                byKey = System.Text.Encoding.UTF8.GetBytes(Khoa.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.UTF8.GetBytes(ChuoiCanMaHoa);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// Giải mã chuỗi
        /// </summary>
        /// <modified>
        /// Người tạo             Ngày tạo           Chú thích
        /// Cuongdb                  ???          
        /// </modified>
        public static string GiaiMa(string ChuoiCanGiaiMa)
        {
            string Khoa = "12345678";
            if (ChuoiCanGiaiMa == "")
                return "";
            try
            {
                byte[] byKey = new byte[0];
                byte[] IV = { 1, 2, 3, 4, 1, 2, 3, 4 };
                byte[] inputByteArray = new byte[ChuoiCanGiaiMa.Length];
                byKey = System.Text.Encoding.UTF8.GetBytes(Khoa.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(ChuoiCanGiaiMa);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return System.Text.Encoding.UTF8.GetString(ms.ToArray());
            }
            catch
            {
                return "";
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
            return objPara.LayLichSuSaoLuu();
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
            return objPara.DeleteBackUp_History(mids);
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
            return objPara.InsertBackUp_History(mBackUp_Date, mBackUp_File);
        }

        public static bool SaoLuuToanBoDB(string FileLuu)
        {
            return new Data.HeThong().SaoLuuToanBoDB(FileLuu);
        }
        /// <summary>
        /// sao luu mot phan
        /// </summary>
        /// <param name="FileLuu"></param>
        /// <returns></returns>
        public static bool SaoLuuMotPhanDB(string FileLuu)
        {
            try
            {
                // lây ta cả các cuộc gọi  nho hon 3 tháng lại đây
                string strT = "";
                System.IO.StreamWriter file = new System.IO.StreamWriter(FileLuu, true);
                List<DieuHanhTaxi> listDieuHanhTaxi = new DieuHanhTaxi().GetNhungCuocGoiNhoHon3ThangGanDay();
                if ((listDieuHanhTaxi != null) && (listDieuHanhTaxi.Count > 0))
                {

                    foreach (DieuHanhTaxi objDH in listDieuHanhTaxi)
                    {

                        file.WriteLine(objDH.toStringData());
                    }
                }              
               
                file.Close();
                DieuHanhTaxi.DeleteNhungCuocGoiNhoHon3ThangGanDay();
                

                return true; ;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
