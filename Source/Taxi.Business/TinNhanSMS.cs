
using System;
using System.Data;
using Taxi.Utils;

namespace Taxi.Business
{
    public class TinNhanSMS:DbEntityBase<TinNhanSMS>
    {
        public string ID { get; set; }
        public string TenNhanVien { get; set; }
        public string SoDienThoai { get; set; }
        public string ThongTinThem { get; set; }
        public bool Chon { get; set; }

        public DataTable LayDanhSachNguoiNhan(params object[] pInput)
        {
            DataTable result= new DataTable();
            try
            {
                result = Inst.ExeStore("sp_LayDanhSachNguoiNhan",pInput);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("LayDanhSachNguoiNhan: ", ex);
            }
            return result;
        }
    }
}
