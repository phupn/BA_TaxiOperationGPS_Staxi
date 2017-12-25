using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;
using Taxi.Common.Extender;

namespace Taxi.Data.G5
{
    [TableInfo(TableName = "T_TaxiOperation")]
    public class T_TaxiOperation : DbEntityBase<T_TaxiOperation>
    {
        [Field(IsIdentity = true, IsKey = true)]
        public long Id { get; set; }

        [Field]
        public Guid BookId { get; set; }
        [Field]
        public string DiaChiDonKhach { get; set; }
        [Field]
        public string XeNhan { get; set; }
        [Field]
        public string XeDon { get; set; }
        [Field]
        public string LenhDienThoai { get; set; }
        [Field]
        public string LenhTongDai { get; set; }
        [Field]
        public string LenhLaiXe { get; set; }
        [Field]
        public string PhoneNumber { get; set; }
        [Field]
        public DateTime ThoiDiemGoi { get; set; }
        [Field]
        public Enum_G5_Type G5_Type { get; set; }
        [Field]
        public string MessageAlert { get; set; }

        /// <summary>
        /// Get danh sách các cuộc gọi theo xe nhận (không lấy những cuốc nhập nhiều xe)
        /// </summary>
        /// <param name="xeNhan"></param>
        /// <returns></returns>
        public List<T_TaxiOperation> GetList_XeDangNhanApp(long idCuoc, string xeNhan)
        {
            return ExeStore("SP_T_TaxiOperation_GetAllCuocDieuApp",idCuoc, xeNhan).ToList<T_TaxiOperation>();
        }

        public List<T_TaxiOperation> GetByID(long idCuoc)
        {
            return ExeStore("SP_T_TaxiOperation_GetByID", idCuoc).ToList<T_TaxiOperation>();
        }
    }
}
