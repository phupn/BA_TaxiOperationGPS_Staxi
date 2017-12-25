using System;
using System.Data;
using Taxi.Data.BanGiaGoc;

namespace Taxi.Business.BanGiaGoc
{
    public class TuyenDuong
    {

        public DataTable GetAllTuyenDuong()
        {

            return this.TableTuyenDuong(0); 
        }
        public DataTable TableTuyenDuong(int LoaiTuyenDuong)
        {
            try
            {
                return new Tuyen().TableTuyenDuong(LoaiTuyenDuong);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("TuyenDuong.TableTuyenDuong", ex);
                return null;
            }
        }

        public DataTable GetKieuTuyenDuong()
        {
            try
            {
                return new Tuyen().GetKieuTuyenDuong();
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("TuyenDuong.GetKieuTuyenDuong", ex);
                return null;
            }
        }
        public string TuyenDuongID(string TenTuyenDuong)
        {
            try
            {
                DataTable dt = new Tuyen().TableTuyenDuongbyTen(TenTuyenDuong);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["TuyenDuongID"].ToString();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("TuyenDuong.TuyenDuongID", ex);
                return null;
            }
            
        }

        public DataTable TableTuyenDuongbyTen(String TenTuyenDuong)
        {
            try
            {
                return new Tuyen().TableTuyenDuongbyTen(TenTuyenDuong);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("TuyenDuong.TableTuyenDuongbyTen", ex);
                return null;
            }
            
        }
        public bool CheckTonTaiTenTuyenDuong(string TenTuyenDuong)
        {
            string Ten = TuyenDuongID(TenTuyenDuong);
            if (!string.IsNullOrEmpty(Ten)) return true;
            return false;
        }

        /// <summary>
        /// insert, mã tự động sinh
        /// </summary>
        public static bool Insert(string TenTuyenDuong, int KieuTuyenTuong)
        {
            try
            {
                return new Tuyen().Insert(TenTuyenDuong, KieuTuyenTuong);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("TuyenDuong.Insert", ex);
                return false;
            }
          
        }

        public static bool Update(string MaTuyenDuong, string TenTuyenDuong, int KieuTuyenTuong)
        {
            try
            {
                return new Tuyen().Update(MaTuyenDuong, TenTuyenDuong, KieuTuyenTuong);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("TuyenDuong.Update", ex);
                return false;
            }            
        }
        public static bool Delete(string MaTuyenDuong)
        {
            try
            {
                return new Tuyen().Delete(MaTuyenDuong);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("TuyenDuong.Delete", ex);
                return false;
            }            
        }
    }
}