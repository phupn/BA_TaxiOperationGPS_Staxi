using System;
using System.Collections.Generic;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;

namespace Taxi.Data.BanCo.Entity.Salary
{
    /// <summary>
    /// tỉ lệ doanh thu hưởng thêm
    /// </summary>
    /// <Modified>
    /// Name     Date         Comments
    /// PPM-HAUNV  9/12/2014   created
    /// </Modified>
     [TableInfo(TableName = "Luong_TiLeDoanhThuHuongThem")]
    public class TiLeDoanhThuHuongThem : TaxiOperationDbEntityBase<TiLeDoanhThuHuongThem>
     {
         #region Properties
        [Field(IsKey = true, IsIdentity = true)]
        [ValueField]
        public int Id { get; set; }
        [Field]
        public int FK_LoaiXeID { get; set; }
        public string TenLoaiXe { get; set; }
        [Field]
        public decimal DoanhThuTu { get; set; }
        [Field]
        public decimal DoanhThuDen { get; set; }
        [Field]
        public double PhanTramHuongThem { get; set; }
        [Field]
        public bool IsHuongPhanVuot { get; set; }
        [Field]
        public DateTime NgayApDung { get; set; }
        [Field]
        public string CreatedByUser { get; set; }
        [Field]
        public DateTime CreatedDate { get; set; }
        [Field]
        public string UpdatedByUser { get; set; }
        [Field]
        public DateTime? UpdatedDate { get; set; }
         #endregion
        public List<TiLeDoanhThuHuongThem> GetList()
        {
            return this.ExeStore("Luong_TiLeDoanhThuHuongThem_GetList").ToList<TiLeDoanhThuHuongThem>();
        }

        public bool CheckValue(int loaiXeID, decimal doanhThuTu, decimal doanhThuDen)
        {
            return (int.Parse(this.ExeStore("Luong_TiLeDoanhThuHuongThem_checkValue", loaiXeID, doanhThuTu, doanhThuDen).Rows[0][0].ToString()) > 0);
        }
        public bool CheckValue()
        {
            return CheckValue(this.FK_LoaiXeID, this.DoanhThuTu, this.DoanhThuDen);
        }

     }
}
