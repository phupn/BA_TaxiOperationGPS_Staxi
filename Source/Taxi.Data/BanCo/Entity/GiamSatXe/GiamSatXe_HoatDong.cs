using System;
using System.Collections.Generic;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
using System.Data;

namespace Taxi.Data.BanCo.Entity.GiamSatXe
{
    [TableInfo(TableName = "BanCo_GiamSatXe_HoatDong")]
    public class GiamSatXe_HoatDong : TaxiOperationDbEntityBase<GiamSatXe_HoatDong>
    {
        #region Properties
        [Field(IsKey=true,IsIdentity=false)]
        [ValueField]
        [DisplayField]
        [ColumnField(ColumnName = "Số hiệu xe")]
        public string SoHieuXe { get; set; }

        [Field]
        public string MaLaiXe { get; set; }

        [Field]
        public DateTime ThoiDiemBao { get; set; }

        [Field]
        public char IsHoatDong { get; set; }

        [Field]
        public int? DiemDo { get; set; }
        public int Node { get; set; }
        public int SoPhutNghi { get; set; }
        public int TrangThaiLaiXeBao { get; set; }
        /// <summary>
        /// 
        /// </summary>
        // [ColumnField(ColumnName = "Tên nhân viên")]
        public string TenNhanVien { set; get; }

        public string ShortName { set; get; }

        public string TenVietTat { set; get; }
        public bool IsHidden { set; get; }
        /// <summary>
        /// Loại xe
        /// </summary>
        public int FK_LoaiXeID { set; get; }
        public int Sort_BanCo { set; get; }

        /// <summary>
        /// Tên điểm đỗ
        /// </summary>
        public string TenDiemDo { get; set; }

        #endregion
        public List<GiamSatXe_HoatDong> GetAllXeHoatDong()
        {
            var kq = this.ExeStore("sp_BanCo_GiamSatXe_GetAllXeHoatDong");
            return kq.ToList<GiamSatXe_HoatDong>();
           // return GetAll().ToList<GiamSatXe_HoatDong>();
        }

        public List<GiamSatXe_HoatDong> GetAllXeHoatDong_V2()
        {
            return ExeStore("sp_BanCo_GiamSatXe_GetAllXeHoatDong_V2").ToList<GiamSatXe_HoatDong>();
        }
        /// <summary>
        /// Lấy danh sách xe báo điểm trả
        /// </summary>
        /// <returns></returns>
        public List<GiamSatXe_HoatDong> GetAllXeHoatDong_BaoDiemTra()
        {
            var kq = this.ExeStore("sp_BanCo_GiamSatXe_GetAllXeHoatDong_BaoDiemTra");
            return kq.ToList<GiamSatXe_HoatDong>();
            // return GetAll().ToList<GiamSatXe_HoatDong>();
        }

        /// <summary>
        /// Lấy danh sách xe báo điểm trả
        /// </summary>
        /// <returns></returns>
        public List<GiamSatXe_HoatDong> GetAllXeHoatDong_BaoDiemTra_V2()
        {
            return this.ExeStore("sp_BanCo_GiamSatXe_GetAllXeHoatDong_BaoDiemTra_V2").ToList<GiamSatXe_HoatDong>();
        }

        /// <summary>
        /// Lấy tất cả xe có kèm lái xe mặc định
        /// </summary>
        /// <returns></returns>
        public List<GiamSatXe_HoatDong> GetListAll_MaNhanVien()
        {
            return ExeStore("SP_DM_XE_GETALL_MaLX").ToList<GiamSatXe_HoatDong>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<GiamSatXe_HoatDong> GetXeBaoRoiXe()
        {
            return this.ExeStore("sp_BanCo_GiamSatXe_XeBaoRoiXe_2").ToList<GiamSatXe_HoatDong>();
        }

        /// <summary>
        /// Get số ngày kinh doanh theo loại xe
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public DataTable GetSoNgayKD_LoaiXe(DateTime? from, DateTime? to)
        {
            return ExeStore("EnVang_Report_GetSoNgayXeDiKinhDoanh_LoaiXe", from, to);
        }

        /// <summary>
        /// Get số ngày kinh doanh
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public DataTable GetSoNgayKD(DateTime? from, DateTime? to)
        {
            return ExeStore("EnVang_Report_GetSoNgayXeDiKinhDoanh", from, to);
        }

        /// <summary>
        /// số xe, điểm đỗ, hoạt động, loại
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public int UpdateDiemDoMoi(params object[] para)
        {
            return ExeStoreNoneQuery("SP_T_TAXIOPERATION_VEHICLE_STOP_UPDATE", para);
        }
        /// <summary>
        /// Lấy những xe hoạt động Dự án EnVangVip
        /// </summary>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// HauNV  01/09/2015   created
        /// </Modified>
        public List<GiamSatXe_HoatDong> EnVangVip_GetXeHoatDong()
        {
            return ExeStore("sp_BanCo_GiamSatXe_EnVangVip_GetXeHoatDong").ToList<GiamSatXe_HoatDong>();
        }
    }

    public struct DiemDo_Node
    {
        public int DiemDo { get; set; }
        public int Node { get; set; }
        public DateTime Time { get; set; }
    }
}
