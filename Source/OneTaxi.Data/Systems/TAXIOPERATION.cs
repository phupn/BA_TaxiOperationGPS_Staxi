using OneTaxi.Utils;
using OneTaxi.Utils.Enums;
using Staxi.Utils.DbBase.Attributes;
using System;

namespace OneTaxi.Data.Systems
{
    [TableInfo(TableName = TableName)]
    public class TAXIOPERATION : DataEntityBase<TAXIOPERATION>
    {
        private const string TableName = "T_TAXIOPERATION";

        #region === Field ===
        public long ID{get;set;}       
        public int Line{get;set;}
        public int Vung{get;set;}
        public string PhoneNumber{get;set;}
        public DateTime ThoiDiemGoi{get;set;}
        public int SoLuotDoChuong{get;set;}
        public DateTime Duration{get;set;}
        public string DiaChiGoi{get;set;}
        public string DiaChiDonKhach{get;set;}
        public bool CoGPS{get;set;}
        public float GPS_KinhDo{get;set;}
        public float GPS_ViDo {get;set;}
        public string DiaChiTraKhach{get;set;}
        public float GPS_KinhDo_TraKhach{get;set;}
        public float GPS_ViDo_TraKhach {get;set;}
        public int KieuKhachHangGoiDen{get;set;}
        public int SoLuong{get;set;}
        public string LoaiXe{get;set;}
        public string LenhDienThoai{get;set;}
        public string LenhTongDai{get;set;}
        public string GhiChuDienThoai{get;set;}
        public string GhiChuTongDai{get;set;}
        public string MaNhanVienDienThoai{get;set;}
        public string MaNhanVienTongDai{get;set;}
        public string XeNhan{get;set;}
        public string XeDenDiem{get;set;}
        public string XeDungDiem{get;set;}
        public string XeDon{get;set;}
        public EnumKieuCuocGoi KieuCuocGoi{get;set;}
        public EnumTrangThaiCuocGoi TrangThaiCuocGoi{get;set;}
        public EnumTrangThaiLenh TrangThaiLenh{get;set;}
        public int ThoiGianDieuXe{get;set;}
        public int ThoiGianDonKhach{get;set;}
        public int TongThoiGianDamThoai{get;set;}
        public int FK_IDKhachDat{get;set;}
        public string CuocGoiLaiIDs{get;set;}
        public int SoLanGoiLai{get;set;}
        public string MaDoiTac{get;set;}
        public string FileVoicePath{get;set;}
        /// <summary>
        /// Giúp mở rộng thêm các vùng điều.
        /// Ví dụ:Cuốc bắt từ hà nội về bắc ninh.
        /// </summary>
        public int IsHeThong{get;set;}
        public bool IsCuocGiaLap{get;set;}
        public int LoaiCuocKhach{get;set;}
        
	    /// <summary>
	    /// Cuốc đặt từ app KH
	    /// </summary>
        public bool G5_IsApp{get;set;}
        public float G5_App_Lat{get;set;}
        public float G5_App_lng{get;set;}
        public Guid  G5_App_BookId{get;set;}
	    public Guid G5_BookId{get;set;}
        public string G5_LenhLaiXe{get;set;}
        public int G5_Type{get;set;}
        public long G5_CopyId{get;set;}
        public string SaleOffCode{get;set;}
        public int G5_CarType{get;set;}
        public string G5_SendDate{get;set;}
        public int G5_StepLast{get;set;}
        #endregion
    }
}
