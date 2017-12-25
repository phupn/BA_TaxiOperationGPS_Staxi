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
    /// Mức bảo hiểm xe
    /// </summary>
    /// <Modified>
    /// Name     Date         Comments
    /// PPM-HAUNV  9/12/2014   created
    /// </Modified>
    [TableInfo(TableName = "Luong_MucBaoHiemXe")]
    public class MucBaoHiemXe: TaxiOperationDbEntityBase<MucBaoHiemXe>
    {
        #region properties
        [Field(IsKey = true, IsIdentity = false)]
        [ValueField]
        public int FK_LoaiXeID { set; get; }
        public string TenLoaiXe { get; set; }
        [Field]
        public decimal TienBHDuoi10NgayCong { get; set; }
        [Field]
        public decimal TienBHDuoi20NgayCong { get; set; }
        [Field]
        public decimal TienBHTren20NgayCong { get; set; }
        [Field]
        public string CreatedByUser { get; set; }
        [Field]
        public DateTime CreatedDate { get; set; }
        [Field]
        public string UpdatedByUser { get; set; }
        [Field]
        public DateTime? UpdatedDate { get; set; }
        #endregion
        public List<MucBaoHiemXe> GetList()
        {
            return this.ExeStore("Luong_MucBaoHiemXe_GetList").ToList<MucBaoHiemXe>();
        }
    }
}
