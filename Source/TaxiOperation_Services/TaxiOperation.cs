using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxiOperation
{
    public class TaxiOperation
    {
        public long ID { get; set; }
        public string TenKhachHang { get; set; }
        public string DiaChiDon { get; set; }
        public string DiaChiTraKhach { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public DateTime GioDon { get; set; }
        public string GhiChu { get; set; }
        public string LoaiXe { get; set; }
        public int SoLuongXe { get; set; }
        public string LenhDienThoai { get; set; }
        public string Line { get; set; }
        public Brand brand { get; set; }
        public short Source { get; set; }
        public float Lat { get; set; }
        public float Lng { get; set; }
        /// <summary>
        /// ID của bên gửi cuốc
        /// </summary>
        public string SenderID { get; set; }
        public string Ext1 { get; set; }
        public string Ext2 { get; set; }

    }

    public enum Brand
    {
        HaNoi = 1,
        VinhPhuc = 2,
        HaNam = 3,
        ThuaThienHue = 4,
        QuangNinh = 5
    }
    
    public class CallInfo
    {
        /// <summary>
        /// Thời điểm gọi
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// Địa chỉ đón khách
        /// </summary>
        public string AddressPick { get; set; }
        /// <summary>
        /// Tên khách hàng
        /// </summary>
        public string CustName { get; set; }
        /// <summary>
        /// Địa chỉ khách hàng
        /// </summary>
        public string CustAddress { get; set; }
        /// <summary>
        /// SĐT
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Loại cuộc gọi
        /// </summary>
        public int CallType { get; set; }
        /// <summary>
        /// Nguồn cuốc
        /// </summary>
        public int CallSource { get; set; }
        /// <summary>
        /// Vùng
        /// </summary>
        public int Region { get; set; }
        /// <summary>
        /// Loại cuốc
        /// </summary>
        public int TripType { get; set; }
        /// <summary>
        /// Mã cuộc gọi từ Tổng Đài IP (AMI)
        /// </summary>
        public string UniqueID { get; set; }
        /// <summary>
        /// Trạng thái cuộc gọi
        /// </summary>
        public int CallStatus { get; set; }


    }
}