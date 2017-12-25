using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;
using Taxi.Common.Extender;

namespace Taxi.Business
{
    [TableInfo(TableName = "[T_TAXIOPERATION_HISTORY]")]
    public class TaxiperationHistory : DbEntityBase<TaxiperationHistory>
    {
        #region == Field ==
        public long ID { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime ThoiDiemGoi { get; set; }
        public string DiaChiDonKhach { get; set; }        
        public int KieuKhachHangGoiDen { get; set; }
        public string LoaiXe { get; set; }
        public int SoLuong { get; set; }
        public string SanBay_DuongDai { get; set; }
        public int Vung { get; set; }
        public string Line { get; set; }
        public string LenhDienThoai { get; set; }
        public string LenhTongDai { get; set; }
        public string MaNhanVienDienThoai { get; set; }
        public string MaNhanVienTongDai { get; set; }
        public string XeNhan { get; set; }
        public string XeDon { get; set; }
        public string DiaChiTraKhach { get; set; }
        public string GhiChuDienThoai { get; set; }
        public string GhiChuTongDai { get; set; }
        public int ThoiGianDieuXe { get; set; }
        public int ThoiGianDonKhach { get; set; }
        public int KieuCuocGoi { get; set; }
        public int TrangThaiCuocGoi { get; set; }
        public int ThoiDiemChuyenTongDai { get; set; }
        public string MaDoiTac { get; set; }
        public string MOIKHACH_LenhMoiKhach { get; set; }
        public DateTime MOIKHACH_ThoiDiemMoi_Giu { get; set; }
        public string MOIKHACH_XinLoi_DaXinLoi { get; set; }
        public DateTime  MOIKHACH_XinLoi_ThoiDiem { get; set; }
        public bool MOIKHACH_KhieuNai_DaXyLy { get; set; }
        public string MOIKHACH_KhieuNai_ThongTinThem { get; set; }
        public DateTime MOIKHACH_KhieuNai_ThoiDiem { get; set; }
        public string MOIKHACH_NhanVien { get; set; }
        public string BANTINBANGIA_NoiDungXuLy { get; set; }
        public bool BANTINBANGIA_IsXuLy { get; set; }
        public string BANTINBANGIA_NhanVien { get; set; }
        public DateTime  BANTINBANGIA_ThoiDiemXuLy { get; set; }
        public DateTime ThoiDiemThayDoiDuLieu { get; set; }
        public string MOIKHACH_NhungThoiDiemMoi { get; set; }
        public string MOIKHACH_NhungNhanVienMoi { get; set; }
        public float GPS_KinhDo { get; set; }
        public float GPS_ViDo { get; set; }
        public string XeDenDiem { get; set; }
        public string AlertID { get; set; }
        public bool ChuyenMK { get; set; }
        public DateTime FT_SendDate { get; set; }
        public DateTime FT_Date { get; set; }
        public bool FT_IsFT { get; set; }
        public int FT_Status { get; set; }
        public long FT_ID { get; set; }
        public float FT_Cust_Lat { get; set; }
        public float FT_Cust_Lng { get; set; }
        public int FT_Priority { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool FT_AllowCall { get; set; }
        public string XeDungDiem { get; set; }
        public int FT_KM { get; set; }
        public int TrangThaiLenh { get; set; }
        public string GhiChuLaiXe { get; set; }
        public int DaGuiDSXeNhan { get; set; }
        public int CenterConfirm { get; set; }
        public bool KhongDungMobileService { get; set; }
        public Guid BookId { get; set; }
        public string LenhLaiXe { get; set; }
        public int G5_Type { get; set; }
        public string G5_Type_Display { get; set; }
        public long G5_CopyId { get; set; }
        public string SaleOffCode { get; set; }
        public string G5_CarType { get; set; }
        public DateTime G5_SendDate { get; set; }
        public string G5_Step { get; set; }
        public int G5_StepLast { get; set; }
        public string BTBG_NoiDungXuLy { get; set; }
        public DateTime HistoryDate { get; set; }

        #endregion

        public static List<TaxiperationHistory> GetData(DateTime start,DateTime end,string phoneNumber,string diaChi,string Line,string Vung,string IDCuoc,string BookID)
        {
            return Inst.ExeStore("sp_TaxiperationHistory_GetData", start,end,phoneNumber,diaChi,Line,Vung).ToList<TaxiperationHistory>();
        }

        public DataTable GetDataTable(DateTime start,DateTime end,string phoneNumber,string diaChi,string line,string vung,string IDCuoc,string pBookID)
        {
            try
            {
                DateTime from = start;
                DateTime to = end;
                DataTable dtAll = new DataTable();
                int countMinute = (to - from).TotalMinutes.To<int>() / 10;
                for (int i = 1; i <= countMinute + 1; i++)
                {
                    try
                    {
                        dtAll.Merge(this.ExeStore("sp_TaxiperationHistory_GetData", from, from.AddMinutes(10), phoneNumber, diaChi, line, vung, IDCuoc, pBookID));
                    }
                    catch (Exception ex)
                    {
                        LogError.WriteLogError("GetDataTable: ", ex);
                    }
                    from = from.AddMinutes(10);
                    Thread.Sleep(50);
                }
                return dtAll;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetDataTable: ", ex);                
                return new DataTable();
            }
        }
    }
}
