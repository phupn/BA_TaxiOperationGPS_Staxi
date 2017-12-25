using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
using Taxi.Data.BanCo.Entity.BaoCaoXe.BaoCaoTongHop;

namespace Taxi.Data.BanCo.Entity.BaoCaoXe
{
    /// <summary>
    /// Xe vi phạm lỗi
    /// </summary>
    [TableInfo(TableName = "BanCo_ViolateError")]
    public class ConfigurationViolateError : TaxiOperationDbEntityBase<ConfigurationViolateError>, IDayReport
    {
        #region Properties

        [Field(IsKey = true, IsIdentity = true)]
        public int ID { get; set; }

        [Field]
        public int FK_ErrorType { get; set; }

        [Field]
        public DateTime ErrorDate { get; set; }

        [Field]
        public string MaLaiXe { get; set; }

        [Field]
        public string FK_SoHieuXeLai { get; set; }

        [Field]
        public int FK_DiemDo { get; set; }

        /// <summary>
        /// Tên điểm đỗ
        /// </summary>
        public string NameVungDH { get; set; }

        [Field]
        public DateTime CreatedDate { get; set; }

        [Field]
        public string Description { get; set; }
        public string TenNhanVien { get; set; }
        public string Reason { get; set; }
        public string MaNhanVien { get; set; }
        public int SoHieuXe_int{get { return FK_SoHieuXeLai.To<int>(); }}
        public string GhiChu { get; set; }
        #endregion

        #region Method

        public List<ConfigurationViolateError> GetInRangeDate(DateTime? from, DateTime? to)
        {
            return this.ExeStore("EnVang_Report_BanCo_ViolateError_GetInRangeDate", from, to).ToList<ConfigurationViolateError>();
        }

        public List<ConfigurationViolateError> GetAllData()
        {
            return GetAll().ToList<ConfigurationViolateError>();
        }

        public DataTable GetAllData_Datatable()
        {
            return GetAll();
        }

        public DataTable GetAllData_Datatable(string store)
        {
            return ExeStore(store);
        }

        public DataTable GetAllData_Datatable(string store, params object[] para)
        {
            return ExeStore(store, para);
        }

        public DataTable GetLaiXe()
        {
            return ExeStore("sp_BanCo_GiamSatXe_GetXeHDTrongNgay");
        }

        public DataTable GetLaiXeViPhamLoi(string MaLaiXe, string LoiViPham, DateTime NgayDau, DateTime NgayCuoi)
        {
            return ExeStore("sp_BanCoViolateError_TimKiemLoiViPhamTheoLoi", MaLaiXe, LoiViPham, NgayDau, NgayCuoi);
        }

        public DataTable GetAllLaiXeViPhamLoi() {
            return ExeStore("sp_BanCoViolateError_LoadAllErrorTable");
        }

        public DataTable Search(params object[] para)
        {
            DataTable dt = new DataTable();
            dt = ExeStore("sp_BanCo_ViolateError_Search", para);
            return dt;
        }

        public DataTable Search_LaiXeViPham(params object[] para)
        {
            return ExeStore("sp_BanCo_ViolateError_Search_BC", para);
        }

        public DataTable GetByDate(DateTime dt)
        {
            return ExeStore("sp_BanCoViolateError_GetDataByDate", dt);
        }
        #endregion

        public DateTime Date
        {
            get { return ErrorDate; }
        }
    }
}