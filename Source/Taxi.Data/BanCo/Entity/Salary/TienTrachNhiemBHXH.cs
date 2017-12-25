using System;
using System.Collections.Generic;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
namespace Taxi.Data.BanCo.Entity.Salary
{
    /// <summary>
    /// Tiền trách nhiệm - bảo hiểm xã hội cho từng chức vụ
    /// </summary>
    /// <Modified>
    /// Name     Date         Comments
    /// PPM-HAUNV  9/12/2014   created
    /// </Modified>
    [TableInfo(TableName = "Luong_TienTrachNhiem_BHXH")]
    public class TienTrachNhiemBHXH : TaxiOperationDbEntityBase<TienTrachNhiemBHXH>
    {
        #region properties
        [Field(IsKey = true, IsIdentity = false)]
        [ValueField]
        public int FK_ChucVuID { set; get; }
        public string TenChucVu { get; set; }
        [Field]
        public decimal TienTrachNhiem { get; set; }
        [Field]
        public decimal TienBHXH { get; set; }
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
        public List<TienTrachNhiemBHXH> GetList()
        {
            return this.ExeStore("Luong_tienTrachNhiem_BHXH_GetList").ToList<TienTrachNhiemBHXH>();
        }
    }
}
