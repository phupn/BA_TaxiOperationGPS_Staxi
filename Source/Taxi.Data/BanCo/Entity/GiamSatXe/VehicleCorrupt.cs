using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;

namespace Taxi.Data.BanCo.Entity.GiamSatXe
{
    /// <summary>
    /// Xe hỏng - ban vặt trên đường
    /// </summary>
    [TableInfo(TableName = "BanCo_VehicleCorrupt")]
    public class VehicleCorrupt : TaxiOperationDbEntityBase<VehicleCorrupt>
    {
        #region Properties

        [Field(IsKey = true, IsIdentity = true)]
        public int Id { get; set; }

        [Field]
        public string SoHieuXe { get; set; }

        [Field]
        public string MaLaiXe { get; set; }

        [Field]
        public DateTime ReportedDate { get; set; }

        [Field]
        public int StatusId { get; set; }

        [Field]
        public string Description { get; set; }

        [Field]
        public DateTime CreatedDate { get; set; }

        [Field]
        public string CreatedByUser { get; set; }

        [Field]
        public DateTime? UpdatedDate { get; set; }

        [Field]
        public string UpdatedByUser { get; set; }

        #endregion

        #region Method
        public List<ConfigurationStatusModel> GetAllData()
        {
            return GetAll().ToList<ConfigurationStatusModel>();
        }

        public DataTable GetAllData_Datatable()
        {
            return GetAll();
        }

        public DataTable GetLaiXe()
        {
            return ExeStore("sp_BanCo_GiamSatXe_GetXeHDTrongNgay");
        }

        public DataTable FormLoad_Refresh(string malaixe, string loivp, DateTime ngaydau, DateTime ngaycuoi)
        {
            return ExeStore("sp_BanCoVehicleCorrupt_TimKiem", ngaydau, ngaycuoi.AddDays(1), malaixe, loivp);
        }

        public DataTable GetByDay(DateTime tungay, DateTime denngay) {
            return ExeStore("sp_BanCoVehicleCorrupt_GetByDay", tungay,denngay);
        }
        #endregion
    }
}
