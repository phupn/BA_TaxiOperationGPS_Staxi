using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
using System;
using Taxi.Data.BanCo.Entity.DM;
using Taxi.Data.BanCo.Entity.GiamSatXe;

namespace Taxi.Data.BanCo.Entity.BaoCaoXe
{
    /// <summary>
    /// Quản lý các loại lý do, nguyên nhân của các chức năng
    /// </summary>
    [TableInfo(TableName = "BanCo_GiamSatXe_Reasons")]
    public class StatusManagement : TaxiOperationDbEntityBase<StatusManagement>
    {       
        #region Properties
        private SqlInt32 _Id;
        [Field(IsKey = true, IsIdentity = true)]
        public SqlInt32 Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private SqlString _Reason;
        [Field]
        public SqlString Reason
        {
            get { return _Reason; }
            set { _Reason = value; }
        }

        private SqlInt32 _Type;
        [Field]
        public  SqlInt32 Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        private SqlString _TenLyDo;
        
        public SqlString TenLyDo
        {
            get { return _TenLyDo; }
            set { _TenLyDo = value; }
        }

        [Field]
        public string ShortName { get; set; }
        [Field]
        public SqlInt16 Sort { get; set; }

        public string PhanTram { get; set; }

        public List<BC_XeKhongKD> lXeKKD { get; set; }

        public StatusManagement() { 
        
        }

        //public StatusManagement(int id,DateTime TuNgay,DateTime DenNgay,string SoHieuXe,string LyDo) {
        //    Id = id;
        //    Reason = new XeKhongKinhDoanh().GetTenLyDo(id);
        //    lXeKKD = new List<BC_XeKhongKD>();
        //    lXeKKD = new XeKhongKinhDoanh().GetByReason(id,SoHieuXe,TuNgay,DenNgay);
        //    PhanTram = "Chiếm " + Math.Round((decimal)(DemSoCuoc(id, SoHieuXe, TuNgay, DenNgay) / DemTongSoCuoc(TuNgay, DenNgay, SoHieuXe, LyDo)) * 100).ToString() + " % tổng số xe lưu";
        //}
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


        //public float DemTongSoCuoc(params object[] para) {
        //    float a = float.Parse(ExeStore("sp_BanCo_VehicleNotWorking_CountTongCuoc", para).Rows[0]["SoCuoc"].ToString());
        //    return float.Parse(ExeStore("sp_BanCo_VehicleNotWorking_CountTongCuoc", para).Rows[0]["SoCuoc"].ToString());
        //}

        //public float DemSoCuoc(params object[] para)
        //{
        //    return float.Parse(ExeStore("sp_BanCo_VehicleNotWorking_SelectByReason_DemSoCuocTheoID", para).Rows[0]["SoCuoc"].ToString());
        //}

        /// <summary>
        /// Lấy danh sách các lý do - nguyên nhân theo loại
        /// </summary>
        /// <param name="Type"></param>
        /// <returns></returns>
        public DataTable GetReasonsByType(Taxi.Utils.Enum_ReasonType Type)
        {
            return ExeStore("SP_BanCo_GiamSatXe_Reasons_GetByType", (int)Type);
        }

        public List<StatusManagement> GetListReason(Taxi.Utils.Enum_ReasonType Type)
        {
            return GetReasonsByType(Type).ToList<StatusManagement>();
        }

        //public DataTable GetStatus(char p)
        //{
        //    return ExeStore("sp_GetReason", p);
        //}

        public DataTable GetAllStatus()
        {
            return ExeStore("sp_GetAllType");
        }

        public DataTable GetGridView()
        {
            return ExeStore("sp_getStatusGridView");
        }

        public DataTable GetNguyenNhanBiTrung(string reasonname)
        {
            return ExeStore("sp_BanCoGiamSatXeReasons_getNguyenNhanTrung", reasonname);
        }


        public int InsertLyDo(params object[] para) {
            return new GiamSatXe_LienLac().ThemLayID("sp_BanCo_GiamSatXe_Reasons_Insert", para);
        }

        #endregion
    }
}
