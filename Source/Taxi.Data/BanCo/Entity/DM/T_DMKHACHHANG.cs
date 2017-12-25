using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
using System.Data;
using System.Data.SqlClient;

namespace Taxi.Data.BanCo.Entity.DM
{
    [TableInfo(TableName = "T_DMKHACHHANG")]
    public class T_DMKHACHHANG : TaxiOperationDbEntityBase<T_DMKHACHHANG>
    {
        [Field(IsKey = true, IsIdentity = false)]
        [ValueField]
        public string MaKH { set; get; }

        [Field]
        [DisplayField]
        [ColumnField(ColumnName = "Tên khách hàng")]
        public string Name { set; get; }

        [Field]
        [ColumnField(ColumnName = "Địa chỉ")]
        public string Address { set; get; }

        [Field]
        public string Phones { set; get; }

        [Field]
        public string Fax { set; get; }

        [Field]
        public string Email { set; get; }

        [Field]
        public DateTime? Birthday { set; get; }

        [Field]
        public string Notes { set; get; }

        [Field]
        public bool IsActive { set; get; }

        [Field]
        public int Type { set; get; }

        [Field]
        public string Road { set; get; }
        [Field]
        public float KinhDo { set; get; }
        [Field]
        public float ViDo { set; get; }
        [Field]
        public string VietTat { set; get; }

        [Field]
        public DateTime? NgayKyKet { set; get; }
        [Field]
        public DateTime? NgayKetThuc { set; get; }
        public string RoadName { get; set; }
        public string TypeName { get; set; }
        public string IsActives
        {
            get
            {
                return IsActive ? "x" : "";
            }
        }

        /// <summary>
        /// Lấy tất cả danh sách khách hàng
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public List<T_DMKHACHHANG> GetListAll(params object[] para) {
            return ExeStore("V3_SP_T_DMKHACHANG_GET_ID_V2", para).ToList<T_DMKHACHHANG>() ;
        }

        /// <summary>
        /// Lấy danh sách khách hàng theo ngày tháng
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public List<T_DMKHACHHANG> GetListAll_GetLast(params object[] para)
        {
            return ExeStore("V3_SP_T_DMKHACHANG_GET_LAST", para).ToList<T_DMKHACHHANG>();
        }

        public T_DMKHACHHANG GetKhachHang_ByPhone(params object[] para)
        {
            return ExeStore("V3_SP_T_DMKHACHANG_SEARCH_PHONES", para).ToList<T_DMKHACHHANG>().FirstOrDefault();
        }

        public DataTable GetAllKh(params object[] para) {
            return ExeStore("V3_SP_T_DMKHACHANG_GET_ID_V2", para);
        }
         
        public int UpdateKhachHang(params object[] para) {
            return ExeStoreNoneQuery("V3_SP_T_DMKHACHANG_UPDATE_V3", para);
        }

        public int InsertKhachHang(params object[] para)
        {
            return ExeStoreNoneQuery("V3_SP_T_DMKHACHANG_INSERT_V3", para);
        }

        public bool CheckPhone()
        {
            var table = Builder.TableInfo.TableName;
            var p = new Param();
            p["@Phone"] = this.Phones;
            p["@MaKH"] = this.MaKH;
            return DataBaseService.ExeSql(string.Format("SELECT Count(0) From {0} where [Phones]=@Phone and MaKH<>@MaKH", table), p).Rows[0][0].As<int>()>0;
        }

        public bool CheckPhone(string phone,string maKH)
        {
            this.MaKH = maKH;
            this.Phones = phone;
            return this.CheckPhone();
        }
    }
}
