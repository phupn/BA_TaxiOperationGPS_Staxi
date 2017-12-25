using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
using System.Data;
using System.Data.SqlClient;
using Taxi.Data.BanCo.Entity.BaoCaoXe.BaoCaoTongHop;

namespace Taxi.Data.BanCo.Entity.DM
{
    [TableInfo(TableName = "T_DMXE")]
    public class DMXe : TaxiOperationDbEntityBase<DMXe>
    {
        #region Properties

        [Field(IsKey = true, IsIdentity = false)]
        [ValueField]
        [DisplayField]
        [ColumnField(ColumnName = "Số hiệu xe")]
        public string PK_SoHieuXe { get; set; }

        [Field]
        public string BienKiemSoat { get; set; }

        [Field]
        public string SoMay { get; set; }

        [Field]
        public string SoKhung { get; set; }

        [Field]
        public int FK_LoaiXeID { get; set; }

        [Field]
        public int FK_GaraID { get; set; }

        [Field]
        public int SoCho { get; set; }

        [Field]
        public int FK_LoaiNhienLieu { get; set; }
        public int? PK_SoHieuXeInt { get { return string.IsNullOrEmpty(PK_SoHieuXe) ? (int?) null : PK_SoHieuXe.To<int>(); } }
        public DateTime LastUpdate { get; set; }
        #endregion

        public List<DMXe> GetListAll() {
            return GetSoHieuXe().ToList<DMXe>();
        }

        public DataTable GetSoHieuXe() {
            return ExeStore("sp_T_DMXe_GetSoHieuXe");
        }

        public DataTable GetAllLaiXe()
        {
            return ExeStore("SP_DMLAIXE_GETALL");
        }

        DataTable dt = new DataTable();
        public int getLoaiXeID(params object[] para)
        {
            int id = 0;
            dt = ExeStore("sp_T_DMXE_GetLoaiXeID", para);
            if (dt.Rows.Count > 0)
            {
                id = int.Parse(dt.Rows[0]["FK_LoaiXeID"].ToString());
            }
            return id;
        }

        public DataTable getAllUser()
        {
            return ExeStore("SP_SYS_USER_SELECT_ALL");
        }

        public DataTable GetNV() {
            return ExeStore("sp_T_DMXe_GetTenNV");
        }

        /// <summary>
        /// Lấy ra DMXe theo số xe
        /// </summary>
        /// <param name="soXe"></param>
        /// <returns></returns>
        public DMXe GetDMXeTheoSoXe(string soXe)
        {
            return ExeStore("sp_T_DMXe_GetTheo_SoXe", soXe).ToList<DMXe>().FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bienkiemsoat"></param>
        /// <returns></returns>
        public DMXe GetDMXeTheoBienKiemSoat(string bienkiemsoat)
        {
            return ExeStore("sp_T_DMXe_GetTheo_BienSoXe", bienkiemsoat).ToList<DMXe>().FirstOrDefault();
        }

        public DataTable Seach(bool chuaChonLoaiXe, bool chuaChonGara, int loaiXe, long gara, string pkSoHieuXe)
        {
            return ExeStore("SP_T_DMXE_Seach", chuaChonLoaiXe, chuaChonGara, loaiXe, gara, pkSoHieuXe);
        }
        /// <summary>
        /// Checks the vehicle.
        /// </summary>
        /// <param name="Vehicle">The vehicle.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// HauNV  07/09/2015   created
        /// </Modified>
        public string CheckVehicle(string Vehicle)
        {
            string val = string.Empty;
            var dt=ExeStore("sp_T_DMXE_CheckVehicle", Vehicle);
            if (dt != null && dt.Rows.Count > 0)
            {
               foreach(var r in dt.Rows.OfType<DataRow>()){
                   val += r[0].ToString() + '.';
               }
            }
            return val;
        }

        public List<DMXe> GetData(string soHieuXe)
        {
            return ExeStore("sp_DMXe_GetData", soHieuXe).ToList<DMXe>();
        }
        public List<DMXe> GetLastUpdate(DateTime lastUpdate)
        {
            return ExeStore("sp_DMXe_GetLastUpdate", lastUpdate).ToList<DMXe>();
        }
    }
}
