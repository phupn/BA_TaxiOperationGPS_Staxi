using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;

namespace Taxi.Data.BanCo.Entity.Salary
{
    /// <summary>
    /// tỉ lệ hưởng lương.
    /// </summary>
    /// <Modified>
    /// Name     Date         Comments
    /// PPM-HAUNV  9/12/2014   created
    /// </Modified>
    [TableInfo(TableName = "Luong_TiLeHuongLuong")]
    public class TiLeHuongLuong : TaxiOperationDbEntityBase<TiLeHuongLuong>
    {
        #region Properties
        [Field(IsKey = true, IsIdentity = true)]
        public int Id { get; set; }
        [Field]
        [ValueField]
        public int FK_LoaiXeID { get; set; }
        public string TenLoaiXe { get; set; }
        [Field]
        public double PhanTramDuongNgan { get; set; }
        [Field]
        public double PhanTramDuongDai { get; set; }
        [Field]
        public double DinhMucNhienLieu { get; set; }
        [Field]
        public double KmDinhMucNhienLieu { get; set; }
        [Field]
        public double PhanTramMotChieu { get; set; }
        [Field]
        public double PhanTramKmVuot1Chieu { get; set; }
        [Field]
        public double PhanTramGioVuot1Chieu { get; set; }
        [Field]
        public double PhanTramKmVuot2Chieu { get; set; }
        [Field]
        public double PhanTramGioVuot2Chieu { get; set; }
        [Field]
        public DateTime ApDungTu { get; set; }
        [Field]
        public DateTime ApDungDen { get; set; }
        [Field]
        public string Xe { get; set; }
        public string XangDau
        {
            get
            {
                return string.Format("{0}/{1}", DinhMucNhienLieu, KmDinhMucNhienLieu);
            }
        }

        [Field]
        public string CreatedByUser { get; set; }
        [Field]
        public DateTime CreatedDate { get; set; }
        [Field]
        public string UpdatedByUser { get; set; }
        [Field]
        public DateTime? UpdatedDate { get; set; }
        #endregion
        public List<TiLeHuongLuong> GetList()
        {
            return this.ExeStore("Luong_TiLeHuongLuong_getList").ToList<TiLeHuongLuong>();
        }

        /// <summary>
        /// Gets tỷ lệ hưởng lương theo loại xe
        /// </summary>
        /// <param name="loaiXeID">The loai xe identifier.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// PhongNC  17/09/2014   created
        /// </Modified>
        public TiLeHuongLuong GetByLoaiXeID(int loaiXeID)
        {
            List<TiLeHuongLuong> ls = this.ExeStore("Luong_TiLeHuongLuong_getByLoaiXeID", loaiXeID).ToList<TiLeHuongLuong>();
            if (ls != null && ls.Count > 0)
            {
                return ls[0];
            }
            return null;
        }
    }
}
