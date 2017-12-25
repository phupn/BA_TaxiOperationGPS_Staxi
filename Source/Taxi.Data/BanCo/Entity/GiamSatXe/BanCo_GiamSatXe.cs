using System.Data;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using Taxi.Common.Extender;
using Taxi.Utils.Validators;
namespace Taxi.Data.BanCo.Entity.GiamSatXe
{
    [TableInfo(TableName = "BanCo_GiamSatXe")]
    public class BanCo_GiamSatXe : TaxiOperationDbEntityBase<BanCo_GiamSatXe>
    {
        #region
        [Field(IsKey = true, IsIdentity = true)]
        public long? Id { set; get; }

        [Field(Name = "Số xe")]
        [ValidatorRequire]
        public string SoHieuXe { set; get; }

        [Field(Name = "Thời điểm đi")]
        [ValidatorRequire]
        [ValidatorDenyDateMin(Stt = 2)]
        // [ValidatorGreaterDateNow(Stt = 3)]
        public DateTime? ThoiDiemBao { set; get; }

        [Field]
        public string MaLaiXe { set; get; }

        [Field(Name = "Lái xe")]
        [ValidatorRequire]
        public string TenLaiXe { set; get; }

        [Field]
        public string ViTriDiemBao { set; get; }

        [Field]
        public string ViTriDiemDen { set; get; }

        [Field]
        public string LoaiChoKhach { set; get; }

        [Field]
        public string TrangThaiLaiXeBao { set; get; }

        [Field(Name = "Điểm đỗ")]
        public int? DiemDo { set; get; }

        [Field]
        public string IsHoatDong { set; get; }

        [Field]
        public byte? Chieu { set; get; }

        [Field]
        public bool CheckedGPS { set; get; }

        [Field(Name = "Thời điểm về")]
        [ValidatorDenyDateMin(Stt = 2)]
        [ValidatorDateGreater("ThoiDiemBao")]
        public DateTime? ThoiDiemVe { set; get; }

        [Field(Name = "Lý do về Gara")]
        public int? LyDoVe { set; get; }

        [Field]
        public int DongHo { set; get; }

        [Field(Name = "Chỉ số đi")]
        [ValidatorRequire]
        [ValidatorIsNumeric(Stt = 2)]
        [ValidatorRange(RangeType.Greater, Min = 0, Stt = 3)]
        public long? CoDi { set; get; }

        [Field(Name = "Chỉ số về")]
        [ValidatorIsNumeric(Stt = 2)]
        [ValidatorRange(RangeType.Greater, Min = 0, Stt = 3)]
        [ValidatorGreater("CoDi", Stt = 4)]
        public long? CoVe { set; get; }

        [Field]
        public string NoiDungSuCo { set; get; }

        [Field]
        public string KetQuaXuLy { set; get; }

        [Field]
        public int SoPhutNghi { set; get; }

        [Field]
        public string GhiChu { set; get; }

        [Field]
        public bool Notified { set; get; }

        [Field]
        public bool IsTrucDem { set; get; }

        [Field]
        public bool IsHaiLai { set; get; }

        public string Reason { set; get; }
        [Field]
        public bool IsHidden { set; get; }
        [Field]
        public bool IsCaBa { set; get; }
        [Field]
        public bool IsGop { set; get; }
        public bool IsNullThoiDiemVe { get; set; }

        private string m_BienSoXe;
        public string BienKiemSoat
        {
            get { return m_BienSoXe; }
            set { m_BienSoXe = value; }
        }
        public string TenLoaiXe { get; set; }

        public string TenLaiXeVietTat
        {
            get
            {
                if (TenLaiXe != null)
                {
                    var lx = TenLaiXe.Split('-');
                    if (lx.Length > 1)
                    {
                        TenLaiXe = lx[1];
                    }
                    var ten = TenLaiXe.To<string>().ToLower().Split(' ');
                    var tentat = ten.Where(s => s.Trim() != "" && s.Trim().Length > 0).Aggregate("", (current, s) => current + s.Trim().Substring(0, 1));
                    return string.Format("{0}-{1}", tentat.ToLower(), TenLaiXe.ToLower());
                }
                return string.Empty;
            }
        }
        /// <summary>
        /// Fix khi lỗi tên lái xe có tên viết tắt ở đầu
        /// </summary>
        public string TenLaiXeFix
        {
            get
            {
                return string.IsNullOrEmpty(TenLaiXe)
                    ? string.Empty
                    : TenLaiXe.Split('-').Length <= 1 ? TenLaiXe : TenLaiXe.Split('-')[1];
            }
        }

        public int? SoHieuXeInt{get { return string.IsNullOrEmpty(SoHieuXe) ? (int?) null : SoHieuXe.To<int>(); }}
        #endregion


        /// <summary>
        /// Lấy ra xe trong thời gian gần nhất theo số hiệu xe, khác với id
        /// và thời điểm báo < thoiDiemBao
        /// </summary>
        /// <param name="soHieuXe">The so hieu xe.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// PhongNC  24/09/2014   created
        /// </Modified>
        public BanCo_GiamSatXe GetLastestBySoHieuXe(string soHieuXe, long Id, DateTime thoiDiemBao)
        {
            return ExeStore("sp_BanCo_GiamSatXeV2_GetLastestByXe", soHieuXe, Id, thoiDiemBao).ToList<BanCo_GiamSatXe>().FirstOrDefault();
        }

        public List<BanCo_GiamSatXe> GetXeHoatDongTrongNgay(DateTime date)
        {
            return ExeStore("sp_BanCo_GiamSatXe_GetXeHoatDongTrongNgay", date).ToList<BanCo_GiamSatXe>();
        }

        public List<BanCo_GiamSatXe> GetXeHoatDongTrongNgay_V2(DateTime date, string tenLaiXe, string soXe)
        {
            return ExeStore("sp_BanCo_GiamSatXe_GetXeHoatDongTrongNgayV2", date, tenLaiXe, soXe).ToList<BanCo_GiamSatXe>();
        }

        /// <summary>
        /// Sử dụng bên lương
        /// </summary>
        /// <param name="date"></param>
        /// <param name="tenLaiXe"></param>
        /// <param name="soXe"></param>
        /// <returns></returns>
        public List<BanCo_GiamSatXe> GetXeHoatDongTrongNgay_Luong(DateTime date, string tenLaiXe, string soXe)
        {
            return ExeStore("sp_BanCo_GiamSatXe_GetXeHoatDongTrongNgayLuongV2", date, tenLaiXe, soXe).ToList<BanCo_GiamSatXe>();
        }
        public List<BanCo_GiamSatXe> GetXeHoatDongTrongNgay_V3(DateTime date)
        {
            return ExeStore("sp_BanCo_GiamSatXe_GetXeHoatDongTrongNgay_V3", date).ToList<BanCo_GiamSatXe>();
        }

        public List<BanCo_GiamSatXe> Get_GiamSatXe_LienLac(params object[] para)
        {
            return ExeStore("SP_XE_GetInfo_GiamSatXe", para).ToList<BanCo_GiamSatXe>();
        }

        /// <summary>
        /// lấy danh sách xe chưa khai báo trong bảng Giám Sát Xe để khai báo ra kinh doanh
        /// </summary>
        /// <returns></returns>
        public List<BanCo_GiamSatXe> GetListAll_NotIn_GiamSatXe()
        {
            return ExeStore("SP_DM_XE_GETALL_XE_NOTIN_GIAMSATXE").ToList<BanCo_GiamSatXe>();
        }

        /// <summary>
        /// lấy danh sách xe chưa báo về
        /// </summary>
        /// <returns></returns>
        public List<BanCo_GiamSatXe> GetListAll_XeChuaVe()
        {
            return ExeStore("SP_DM_XE_GETALL_XE_CHUA_BAO_VE").ToList<BanCo_GiamSatXe>();
        }
        
        public void DoInsert()
        {
            this.ExeStoreNoneQuery("sp_BanCo_GiamSatXeV2_ThemMoi");
        }

        /// <summary>
        /// Thực hiện thêm mới có đối số truyền vào
        /// </summary>
        /// <param name="pa">The pa.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// PhongNC  23/09/2014   created
        /// </Modified>
        public void DoInsert(params object[] pa)
        {
            this.ExeStoreNoneQuery("sp_BanCo_GiamSatXeV2_ThemMoi_Params", pa);
        }
        public void DoInsert_V2(params object[] pa)
        {
            this.ExeStoreNoneQuery("sp_BanCo_GiamSatXeV2_ThemMoi_Params_v2", pa);
        }

        public void DoUpdate()
        {
            this.ExeStoreNoneQuery("sp_BanCo_GiamSatXeV2_Sua");
        }


        /// <summary>
        /// Thực hiện update có đối số truyền vào
        /// </summary>
        /// <param name="pa">The pa.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// PhongNC  23/09/2014   created
        /// </Modified>
        public void DoUpdate(params object[] pa)
        {
            this.ExeStoreNoneQuery("sp_BanCo_GiamSatXeV2_Sua_Params",pa);
        }

        public void DoUpdate_v2(params object[] pa)
        {
            this.ExeStoreNoneQuery("sp_BanCo_GiamSatXeV2_Sua_Params_v2", pa);
        }

        public int DoDelete(string userDelete)
        {
            int output = 0;
            var result = this.ExeStoreNoneQueryWithOutput("sp_BanCo_GiamSatXe_Delete_v2", Id, userDelete,output);
            return result.Value["Output"].To<int>();
        }

        /// <summary>
        /// Xóa ép
        /// </summary>
        /// <param name="userDelete"></param>
        /// <returns></returns>
        public int DoDelete_Force(string userDelete)
        {
            int output = 0;
            var result = this.ExeStoreNoneQueryWithOutput("sp_BanCo_GiamSatXe_Delete_Force", Id, userDelete, output);
            return result.Value["Output"].To<int>();
        }

        public DateTime Date
        {
            get { return ThoiDiemBao.Value; }
        }
        public List<BanCo_GiamSatXe> GetXeHoatDongTrongNgayVoi2TrangThai_KD_BV(DateTime date)
        {

            //return ExeStore("sp_BanCo_GiamSatXe_GetXeHoatDongTrongNgay_v2", date).ToList<BanCo_GiamSatXe>();
              return ExeStore("sp_BanCo_GiamSatXe_GetXeHoatDongTrongNgayVoi2TrangThai_KD_BV", date).ToList<BanCo_GiamSatXe>();
        }

        public string CheckListKinhDoanh(string listSoHieuXe)
        {
            var listKD = ExeStore("sp_CheckListKinhDoanh", listSoHieuXe).ToList<ListSoHieuXe>();
            return string.Join(",", listSoHieuXe.Split('.').ToList().Where(p => !listKD.Any(p1 => p1.SoHieuXe.Trim().Equals(p.Trim()))).Select(p => p.Trim()));
        }

        public List<BanCo_GiamSatXe> LichHoatDongSearch(DateTime start, DateTime end, string maLaiXe, string soXe,string loaiXe)
        {
            return this.ExeStore("Luong_ChotCo_GetLichHoatDongSearch", start, end, maLaiXe, soXe, loaiXe).ToList<BanCo_GiamSatXe>();
        }
        /// <summary>
        /// Kiểm tra xem có xe nào chưa mở hàng không.
        /// </summary>
        /// <returns></returns>
        public bool CheckXeChuaMoHang()
        {
            return ExeStore("sp_BanCo_GiamSatXe_CheckXeChuaMoHang").Rows[0][0].To<int>() > 0; 
        }
        /// <summary>
        /// Lấy danh sách chưa mở hàng
        /// </summary>
        /// <returns></returns>
        public DataTable GetXeChuaMoHang()
        {
            return ExeStore("sp_BanCo_GiamSatXe_GetXeChuaMoHang");
        }
    }

    public class ListSoHieuXe
    {
        public string SoHieuXe { get; set; }
    }
}
