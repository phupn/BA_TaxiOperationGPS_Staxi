using System;
using System.Data;
using Taxi.Business.DieuXeDuongDai;
using Taxi.Data.DM;

namespace TaxiOperation_DieuXeDuongDai.Base
{
    public  class CommonDuongDai
    {
        /// <summary>
        /// Trạng thái đặt lịch đón khách
        /// </summary>        
        public static DataTable GetTrangThaiDatLichDonKhach()
        {
            var dt = new DataTable();
            dt.Columns.Add("TrangThai");
            dt.Columns.Add("GiaTri");
            dt.Columns["GiaTri"].DataType = typeof(int);
            dt.Rows.Add("Chờ xử lý", 1);
            dt.Rows.Add("Đón được", 2);
            dt.Rows.Add("Khách hủy", 3);
            dt.Rows.Add("Không xe", 4);
            dt.Rows.Add("Trượt", 5);
            dt.Rows.Add("Hoãn", 6);
            dt.AcceptChanges();
            return dt;
        }
        /// <summary>
        /// Trạng thái xe đi tỉnh
        /// </summary>        
        public static DataTable GetTrangThaiXeDiTinh()
        {
            var dt = new DataTable();
            dt.Columns.Add("TrangThai");
            dt.Columns.Add("GiaTri");
            dt.Columns["GiaTri"].DataType = typeof (int);
            dt.Rows.Add("Chưa điều", 1);
            dt.Rows.Add("Đã điều", 2);
            dt.Rows.Add("Khách hủy", 3);
            dt.Rows.Add("Trượt", 4);
            dt.Rows.Add("Hoãn", 5);
            dt.AcceptChanges();
            return dt;
        }
        public static DataTable GetTrangThaiXeDiTinhLyDoXoa()
        {
            var dt = new DataTable();
            dt.Columns.Add("TrangThai");
            dt.Columns.Add("GiaTri");
            dt.Columns["GiaTri"].DataType = typeof(int);
            dt.Rows.Add("Khách hủy", 3);
            dt.Rows.Add("Trượt", 4);
            dt.Rows.Add("Hoãn", 5);
            dt.AcceptChanges();
            return dt;
        }
        public static DataTable GetTrangThaiXoa()
        {
            var dt = new DataTable();
            dt.Columns.Add("TrangThai");
            dt.Columns.Add("GiaTri");
            dt.Columns["GiaTri"].DataType = typeof(bool);
            dt.Rows.Add("Chưa hủy", false);
            dt.Rows.Add("Đã hủy", true);
            dt.AcceptChanges();
            return dt;
        }

        public static DataTable GetTrangThaiXeDangKy()
        {
            var dt = new DataTable();
            dt.Columns.Add("TrangThai");
            dt.Columns.Add("GiaTri");
            dt.Columns["GiaTri"].DataType = typeof(int);
            dt.Rows.Add("Tất cả", 0);
            dt.Rows.Add("Chờ điều", 1);
            dt.Rows.Add("Đã điều", 2);
            dt.Rows.Add("Đã xóa", 3);
            dt.AcceptChanges();
            return dt;
        }

        private static DataTable _loaiXe;

        public static DataTable GetLoaiXe()
        {
            return _loaiXe ?? (_loaiXe = new LoaiXe().GetAllLoaiXe());
        }
        public static DateTime GetTimeServer()
        {
            return DUONGDAI_KHACHHEN.GetTimeServer();
        }
    }
}
