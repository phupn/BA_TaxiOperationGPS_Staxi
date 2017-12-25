using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text.RegularExpressions;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
using Taxi.Data.BanCo.Entity.DM;

namespace Taxi.Data.BanCo.Entity.BaoCaoXe
{
    [TableInfo(TableName = "BanCo_VehicleNotWorking")]
    public class XeKhongKinhDoanh : TaxiOperationDbEntityBase<XeKhongKinhDoanh>
    {
        #region Properties
        private SqlInt32 _Id;
        [Field(IsKey = true, IsIdentity = true)]
        public SqlInt32 Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private SqlString _SoHieuXe;
        [Field]
        public SqlString SoHieuXe
        {
            get { return _SoHieuXe; }
            set { _SoHieuXe = value; }
        }

        private int _Reason;
        [Field]
        public int Reason
        {
            get { return _Reason; }
            set { _Reason = value; }
        }

        private SqlDateTime _ReportedDate;
        [Field]
        public SqlDateTime ReportedDate
        {
            get { return _ReportedDate; }
            set { _ReportedDate = value; }
        }

        private SqlString _Description;
        [Field]
        public SqlString Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        private SqlDateTime _CreatedDate;
        [Field]
        public SqlDateTime CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
        }

        private SqlString _CreatedByUser;
        [Field]
        public SqlString CreatedByUser
        {
            get { return _CreatedByUser; }
            set { _CreatedByUser = value; }
        }

        private SqlDateTime _UpdatedDate;
        [Field]
        public SqlDateTime UpdatedDate
        {
            get { return _UpdatedDate; }
            set { _UpdatedDate = value; }
        }

        private SqlString _UpdatedByUser;
        [Field]
        public SqlString UpdatedByUser
        {
            get { return _UpdatedByUser; }
            set { _UpdatedByUser = value; }
        }

        private SqlBoolean _IsDiTuyen;
        [Field]
        public SqlBoolean IsDiTuyen
        {
            get { return _IsDiTuyen; }
            set { _IsDiTuyen = value; }
        }
        public int SoHieuXe_Int{get { return SoHieuXe.To<int>(); }}
        //[Field]
        //private int STT { get; set; }
        //[Field]
        //private string TenLoaiXe { get; set; }
        //[Field]
        //private string GhiChu { get; set; }

        #endregion

        #region Method
        //public List<ConfigurationStatusModel> GetAllData()
        //{
        //    return GetAll().ToList<ConfigurationStatusModel>();
        //}

        //public DataTable GetAllData_Datatable()
        //{
        //    return GetAll();
        //}

        //public DataTable GetLaiXeHoatDong()
        //{
        //    return ExeStore("sp_getLaixeHoatDong");
        //}

        //public DataTable GetLyDo()
        //{
        //    return ExeStore("SP_BanCo_GiamSatXe_Reasons_GetByType", '3');
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Soxe"></param>
        /// <param name="loivp">-1 để dùng cho trường hợp check trùng(đã khai báo ra kinh doanh)</param>
        /// <param name="ngaydau"></param>
        /// <param name="ngaycuoi"></param>
        /// <returns></returns>
        public DataTable FormLoad_Refresh(string Soxe, string loivp, DateTime? ngaydau, DateTime? ngaycuoi)
        {
            return ExeStore("sp_BanCoVehicleNotWorking_TimKiem", ngaydau, ngaycuoi, Soxe, loivp);
        }

        //public DataTable GetAllLaiXe()
        //{
        //    return ExeStore("sp_BanCo_GiamSatXe_GetXeHDTrongNgay");
        //}

        //public DataTable Search(params object[] para) {
        //    return ExeStore("sp_BanCo_VehicleNotWorking_Search", para);
        //}

        //public List<XeKhongKinhDoanh> SearchXeKD(params object[] para)
        //{
        //    return Search(para).ToList<XeKhongKinhDoanh>();
        //}

        //public List<XeKhongKinhDoanh> GetListAll() {
        //    return GetAll().ToList<XeKhongKinhDoanh>();
        //}

        //public List<BC_XeKhongKD> GetByReason(params object[] para)
        //{
        //    return ExeStore("sp_BanCo_VehicleNotWorking_SelectByReason", para).ToList<BC_XeKhongKD>();
        //}

        /// <summary>
        /// Lấy ra xe theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public XeKhongKinhDoanh GetByID(int id)
        {
            return ExeStore("sp_BanCo_VehicleNotWorking_SelectByID", id).ToList<XeKhongKinhDoanh>().FirstOrDefault();
        }

        //public DataTable GetByReasonDt(params object[] para)
        //{
        //    return ExeStore("sp_BanCo_VehicleNotWorking_SelectByReason", para);
        //}

        //public string GetTenLyDo(params object[] para)
        //{
        //    return ExeStore("sp_BanCo_VehicleNotWorking_SelectTenLyDoByID",para).Rows[0]["Reason"].ToString();
        //}
        #endregion
    }
}
