using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
using Taxi.Utils;

namespace Taxi.Data.DM
{
    [TableInfo(TableName = "T_KhachHangDungThe")]
    public class KhachHangDungThe : DbEntityBase<KhachHangDungThe>
    {
        [Field(IsKey=true)]
        public string MaThe { get; set; }
        [Field]
        public DateTime TuNgay { get; set; }
        [Field]
        public DateTime DenNgay { get; set; }
        [Field]
        public string MaKhachHang { get; set; }
        [Field]
        public string TenKhachHang { get; set; }
        [Field]
        public string SoDienThoai { get; set; }
        [Field]
        public string DiaChi { get; set; }
        public string GetMaThe()
        {
            return "MKH" + (GetTimeServer() ?? DateTime.Now).ToString("yyyyMMddHHmmssmmm");
        }
        public List<KhachHangDungThe> GetData(string maThe, DateTime? tuNgay, DateTime? denNgay, string maKhachHang, string tenKhachHang, string soDienThoai,string diaChi)
        {
            return ExeStore("sp_KhachHangDungThe_GetData", maThe, tuNgay, denNgay, maKhachHang, tenKhachHang, soDienThoai, diaChi).ToList<KhachHangDungThe>();
        }
        public KhachHangDungThe GetKH(string sdt, DateTime ngayApDung)
        {
            try
            {
                var dt = ExeStore("sp_KhachHangDungThe_GetKH", sdt, ngayApDung).ToList<KhachHangDungThe>();
                if (dt.Count != 1)
                {
                    return null;
                }
                else
                {
                    return dt.First();
                }
            }
            catch (Exception)
            {
                return null;
            }
           
            
        }

        public string GetGhiChuByPhoneOfKhachHang(string phone)
        {
            try
            {
                var dt = ExeStore("sp_KhachHang_GetGhiChu", phone);
                if (dt == null || dt.Rows.Count == 0 || dt.Rows[0][0] == DBNull.Value)
                {
                    return string.Empty;
                }
                else
                {
                    return dt.Rows[0][0].ToString();
                }
            }
            catch (Exception)
            {

                return string.Empty;
            }
          
        }
    }
}
