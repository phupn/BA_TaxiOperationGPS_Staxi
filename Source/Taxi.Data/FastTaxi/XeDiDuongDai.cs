using System;
using System.Collections.Generic;
using System.Data;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
using Taxi.Controls.Base.BaoCao;
using Taxi.Utils;
using System.Linq;
using Taxi.Utils.Enums;
namespace Taxi.Data.FastTaxi
{
    [TableInfo(TableName = "T_SANBAY_DUONGDAI")]
    public class XeDiDuongDai : DbEntityBase<XeDiDuongDai>, IReportData
    {
        #region Field
        [Field(IsIdentity=true,IsKey=true)]
        public long ID { get; set; }
        /// <summary>
        /// Id cha
        /// </summary>
        [Field]
        public long ParentID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field]
        public int Line { get; set; }
        [Field]
        public string FK_SoHieuXe { get; set; }
        
        public string BienSoXe { get; set; }
        [Field]
        public float Xe_ViDo { get; set; }
        [Field]
        public float Xe_KinhDo { get; set; }
        [Field]
        public string DiaDiemDi { get; set; }
        [Field]
        public string DiaDiemDen { get; set; }
        [Field]
        public int FK_TinhThanhDiID { get; set; }
        [Field]
        public int FK_TinhThanhDenID { get; set; }
        [Field]
        public int FK_QuanHuyenDiID { get; set; }
        [Field]
        public int FK_QuanHuyenDenID { get; set; }
        [Field]
        public int FK_PhuongXaDiID { get; set; }
        [Field]
        public int FK_PhuongXaDenID { get; set; }
        [Field]
        public float Di_ViDo { get; set; }
        [Field]
        public float Di_KinhDo { get; set; }
        [Field]
        public float Den_ViDo { get; set; }
        [Field]
        public float Den_KinhDo { get; set; }
        [Field]
        public int CoDau { get; set; }
        [Field]
        public int CoCuoi { get; set; }
        [Field]
        public DateTime? ThoiDiemDi { get; set; }
        [Field]
        public DateTime? ThoiDiemVe { get; set; }
        [Field]
        public bool Is1Chieu { get; set; }
        [Field]
        public decimal TongTien { get; set; }
        [Field]
        public string GhiChu { get; set; }
        [Field]
        public string TenLaiXe { get; set; }
        [Field]
        public string SoDienThoai { get; set; }
        [Field]
        public bool isChiaSeChuyenDi { get; set; }
        [Field]
        public string NguoiDuyet { get; set; }
        [Field]
        public DateTime? ThoiDiemDuyet { get; set; }
        [Field]
        public int TrangThai { get; set; }
        public string TrangThai_String
        {
            get
            {
                switch (TrangThai)
                {
                    case (int)Enum_XeBaoDiDuongDai_TrangThai.ChoGhepKhach: return "Chờ ghép khách";
                    case (int)Enum_XeBaoDiDuongDai_TrangThai.DaGhepKhach: return "Đã ghép khách";
                    case (int)Enum_XeBaoDiDuongDai_TrangThai.HuyDieu: return "Hủy điều";
                    case (int)Enum_XeBaoDiDuongDai_TrangThai.KhachDaLenXe: return "Khách đã lên xe";
                    case (int)Enum_XeBaoDiDuongDai_TrangThai.KhongXacDinh: return "Không xác định";
                }
                return string.Empty;
            }
        }
        [Field]
        public int TrangThaiDuyet { get; set; }
        public string TrangThaiDuyet_String
        {
            get
            {
                switch (TrangThaiDuyet)
                {
                    case (int)Enum_XeBaoDiDuongDai_TrangThaiDuyet.ChoDuyet:return "Chờ duyệt";
                   case (int)Enum_XeBaoDiDuongDai_TrangThaiDuyet.DaDuyet:return "Đã duyệt";
                   case (int)Enum_XeBaoDiDuongDai_TrangThaiDuyet.KhongDuyet: return "Không duyệt";
                }
                return string.Empty;
            }
        }
        [Field]
        public bool isDelete { get; set; }
        [Field]
        public int KmDuKien { get; set; }
        [Field]
        public DateTime TGDuKien { get; set; }
        [Field]
        public float TienDuKien { get; set; }
        [Field]
        public string LoTrinh { get; set; }
        [Field]
        public string LoTrinh_Diem { get; set; }
        [Field]
        public DateTime CreatedDate { get; set; }
        [Field]
        public string CreatedByUser { get; set; }
        [Field]
        public DateTime? UpdatedDate { get; set; }
        [Field]
        public string UpdatedByUser { get; set; }
        [Field]
        public DateTime? DeleteDate { get; set; }
        [Field]
        public string DeleteByUser { get; set; }
        /// <summary>
        /// Đã addTrip lên server FastTaxi Thành Công
        /// </summary>
        [Field]
        public bool IsAddedStaxi { get; set; }
        [Field]
        public bool IsKetThuc { get; set; }
        public string isChiaSeChuyenDiStr
        {
            get { return isChiaSeChuyenDi ? "X" : ""; }
        }
        public string Is1ChieuStr { get { return Is1Chieu ? "1 chiều" : "2 chiều"; } }
        public int? OpStatus { get; set; }
        public long? PK_BooID { get; set; }
        public bool? OpIsDelete { get; set; }
        public int? SoHieuXe
        {
            get
            {
                try
                {
                    return FK_SoHieuXe.To<int>();
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        #endregion

        #region
        /// <summary>
        /// Lấy thông tin xe và lái xe.
        /// </summary>
        /// <param name="soXe"></param>
        /// <returns></returns>
        public DataTable GetThongTinXeVaLaiXeTheoSoXe(string soXe)
        {
            return ExeStore("sp_FT_LayThongTinXeVaNhanVienTheoSoXe", soXe);
        }

        public List<XeDiDuongDai> GetDataByDate(DateTime? start,DateTime? end)
        {
            return ExeStore("sp_FT_XeDiDuongDai_GetDataByDate", start, end).ToList<XeDiDuongDai>();
        }
        public List<XeDiDuongDai> LayXeChuaKetThucTheoLine(string line)
        {
            return ExeStore("sp_FT_XeDiDuongDai_LayXeChuaKetThucTheoLine", line).ToList<XeDiDuongDai>();
        }
        /// <summary>
        /// lấy dữ liệu được thay đổi gần đây theo line
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="thoiDiemTruocLayDuLieu"></param>
        /// <returns></returns>
        public List<XeDiDuongDai> GetDataByDateTime(string line, DateTime thoiDiemTruocLayDuLieu)
        {
            return ExeStore("sp_FT_XeDiDuongDai_GetDataByDateTimeV2", line, thoiDiemTruocLayDuLieu).ToList<XeDiDuongDai>();
        }
        /// <summary>
        /// Kiểm tra
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CheckTripDaGhepChua(long id)
        {
            var row = ExeStore("sp_FT_TAXIRETURN_BOOKINGS_CheckTripDaGhepChua", id).Rows;
            return row.Count > 0 && row[0][0].To<int>() > 0;
        }
        /// <summary>
        /// Kiểm tra xe kết thúc cuốc đi đường dài chưa.
        /// </summary>
        /// <param name="soxe"></param>
        /// <returns></returns>
        public bool CheckXeChuaKetThucDuongDai(string soxe)
        {
            var row = ExeStore("sp_FT_CheckXeChuaKetThucDuongDai", soxe).Rows;
            return row.Count > 0 && row[0][0].To<int>() > 0;
        }
        public List<XeDiDuongDai> SearchKetThuc(DateTime start, DateTime end, int thanhPhoID, string soXe)
        {
            return ExeStore("sp_FT_XeDiDuongDai_SearchKetThuc", start,end,thanhPhoID,soXe).ToList<XeDiDuongDai>();
        }
        public List<XeDiDuongDai> Search(DateTime start, DateTime end, int thanhPhoID, string soXe)
        {
            return ExeStore("sp_FT_XeDiDuongDai_Search", start, end, thanhPhoID, soXe).ToList<XeDiDuongDai>();
        }

        public List<XeDiDuongDai> GetListBy(string soXes)
        {
            return ExeStore("sp_FT_XeDiDuongDai_GetListBy", soXes).ToList<XeDiDuongDai>();
        }
        /// <summary>
        /// Kiểm tra có bị trùng với số điện thoại lái xe báo đi đường dài chưa kết thúc.
        /// </summary>
        /// <param name="soDienThoai"></param>
        /// <returns></returns>
        public bool CheckSoDienThoai(string soDienThoai)
        {
            return ExeStore("sp_FT_XeDiDuongDai_CheckSoDienThoai", soDienThoai).Rows[0][0].To<int>() > 0;
        }

        public bool HuyDieu()
        {
            ExeStoreNoneQuery("sp_FT_XeDiDuongDai_HuyDieu",this.ID,this.UpdatedByUser);
            return false;
        }
        public List<long> GetDataDelete(string lsId)
        {
            var dt = ExeStore("sp_FT_XeDiDuongDai_GetDataDelete", lsId);
            List<long> lsReturn = new List<long>();
            if (dt.Rows.Count > 0)
                for (int i = 0; i < dt.Rows.Count; i++) lsReturn.Add(dt.Rows[i][0].To<long>());
            return lsReturn;
        }
        /// <summary>
        /// Cập nhật lại trạng thái của xe báo đi đường dài.
        /// Nếu là Trạng thái là None thì sẽ ko làm thay đổi trạng thái hiện tại của server
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <param name="UserId"></param>
        public void UpdateStatus(long id, Taxi.Utils.Enums.Enum_XeBaoDiDuongDai_TrangThai status, string UserId, bool IsKetThuc = false)
        {
            ExeStoreNoneQuery("sp_FT_XeDiDuongDai_UpdateStatusV2", id, (int)status, UserId, IsKetThuc);
        }
        /// <summary>
        /// Thay đổi trạng thái trip và book
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <param name="UserId"></param>
        /// <param name="IsKetThuc"></param>
        /// <param name="statusOp"></param>
        /// <param name="idBook"></param>
        public void UpdateStatusV2(long id, Taxi.Utils.Enums.Enum_XeBaoDiDuongDai_TrangThai status, string UserId, bool IsKetThuc, Taxi.Utils.Enums.DieuXeChieuVe.Enum_Bookings_OpStatus statusOp,long idBook)
        {
            ExeStoreNoneQuery("sp_FT_XeDiDuongDai_UpdateStatusV3", id, (int)status, UserId, IsKetThuc, (int)statusOp,idBook);
        }
        public void UpdateIsAddedStaxi(long id, string userId, bool status)
        {
            ExeStoreNoneQuery("sp_FT_XeDiDuongDai_UpdateIsAddedStaxi", id, userId, status);
        }
        //public void ReplaceTrip(long id,string DiaDiemDen)
        #endregion
        #region Làm báo cáo
        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }
        public string SoXe { get; set; }
        public int IsDaGui { get; set; }
        public string DiaChiTra { get; set; }
        public string Staxi
        {
            get
            {
                return this.isChiaSeChuyenDi ? "Đồng ý gửi" : "Không đồng ý";
            }
        }
        public object GetData()
        {
            return this.ExeStore("sp_BaoCao_ChiTietXeBaoDiDuongDai").ToList<XeDiDuongDai>().OrderByDescending(p=>p.ThoiDiemDi).OrderBy(p=>p.FK_SoHieuXe.To<int>()).ToList();
        }
        #endregion
    }
}
