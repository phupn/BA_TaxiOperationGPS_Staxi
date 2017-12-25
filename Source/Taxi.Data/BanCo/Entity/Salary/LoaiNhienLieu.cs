using Taxi.Data.BanCo.DbConnections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;

namespace Taxi.Data.BanCo.Entity.Salary
{
    /// <summary>
    /// Loại nhiên liệu
    /// </summary>
    /// <Modified>
    /// Name     Date         Comments
    /// PhongNC  12/09/2014   created
    /// </Modified>
    [TableInfo(TableName = "Luong_LoaiNhieuLieu")]
    public class LoaiNhienLieu : TaxiOperationDbEntityBase<LoaiNhienLieu>
    {
        [Field(IsKey = true, IsIdentity = true)]
        [ValueField]
        public int PK_LoaiNhienLieu { get; set; }

        [Field]
        [DisplayField]
        [ColumnField(Name = "Gara")]
        public string TenLoaiNhienLieu { get; set; }

        /// <summary>
        /// Load tất cả loại nhiên liệu
        /// </summary>
        /// <returns></returns>
        public List<LoaiNhienLieu> GetAll()
        {
            return base.GetAll().ToList<LoaiNhienLieu>();
        }

        public List<LoaiNhienLieu> GetListAll()
        {
            return GetAll().ToList<LoaiNhienLieu>();
        }
    }
}
