using System;
using System.Collections.Generic;
using System.Linq;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
using Taxi.Utils;
using Taxi.Data.BanCo.Entity.DieuXe;

namespace Taxi.Data.BanCo.Entity.GiamSatXe
{
    [TableInfo(TableName = "T_TAXIOPERATION_TRUCK_END")]
    public class TaxiOperation_Truck_End : TaxiOperationDbEntityBase<TaxiOperation_Truck_End>, ICloneable
    {
        #region Properties
        [Field(IsKey = true, IsIdentity = true)]
        public int Id {set;get;}

        [Field]
        public string SoDT {set;get;}
        [Field]
        public DateTime TGTiepNhan {set;get;}
        [Field]
        public int Line {set;get;}
        [Field]
        public string DiaChiDon {set;get;}
        [Field]
        public int DuongPhoDon {set;get;}
        [Field]
        public int QuanHuyenDon {set;get;}
        [Field]
        public double KinhDo_Khach {set;get;}
        [Field]
        public double ViDo_Khach {set;get;}

        [Field]
        public string LoaiXe {set;get;}
        [Field]
        public int Vung  {set;get;}
        /// <summary>
        /// Số hiệu xe
        /// </summary>
        [Field]
        public string SoXe {set;get;}
        [Field]
        public string MaLaiXe { set; get; }
        [Field]
        public int ChiSoDi {set;get;}
        [Field]
        public double KinhDo_BD {set;get;}
        [Field]
        public double  ViDo_BD {set;get;}
        [Field]
        public double KinhDo_Don {set;get;}
        [Field]
        public double ViDo_Don {set;get;}
        [Field]
        public DateTime? TGGap {set;get;}
        [Field]
        public string DiaChiTra {set;get;}
        [Field]
        public int DuongPhoTra {set;get;}
        [Field]
        public int QuanHuyenTra {set;get;}
        [Field]
        public double KinhDo_Tra {set;get;}
        [Field]
        public double ViDo_Tra {set;get;}
        [Field]
        public string TuyenDuong {set;get;}
        [Field]
        public int Chieu {set;get;}
        [Field]
        public string GiaThueBao {set;get;}
        [Field]
        public int BuXang_Don_GPS { set; get; }
        [Field]
        public int BuXang_Don {set;get;}
        [Field]
        public KieuCuocHang KieuCuocHang { set; get; }
        
        public int KieuCuocHang_Int
        {
            get { return (int)KieuCuocHang; }
        }
        [Field]
        public DateTime? TGTra {set;get;}
        [Field]
        public int ChiSoVe {set;get;}
        [Field]
        public int KmCoDH {set;get;}
        [Field]
        public double KmThucDi {set;get;}
        [Field]
        public decimal TienDH { set; get; }
        [Field]
        public int BuXang_Truot_GPS { set; get; }
        [Field]
        public int BuXang_Truot {set;get;}
        [Field]
        public decimal PhatSinh { set; get; }
        [Field]
        public float KmVuot { set; get; }
        [Field]
        public float KmVuot_Auto { set; get; }
        [Field]
        public decimal TienTroiKM { set; get; }
        [Field]
        public int PhutVuot { set; get; }
        [Field]
        public int PhutVuot_Auto { set; get; }
        [Field]
        public decimal TienTroiPhut { set; get; }

        [Field]
        public string PhuTroi {set;get;}
        [Field]
        public decimal ThanhTien { set; get; }
        [Field]
        public int DiemDoMoi {set;get;}
        [Field]
        public int LyDoTruot {set;get;}
        [Field]
        public string GhiChu {set;get;}
        [Field]
        public TrangThaiCuocGoiTaxi KetQua { set; get; }

        public bool KetQua_Hoan
        {
            get { return KetQua == TrangThaiCuocGoiTaxi.CuocGoiHoan; }
        }
        public bool KetQua_Truot
        {
            get { return KetQua == TrangThaiCuocGoiTaxi.CuocGoiTruot; }
        }
        public bool KetQua_KhongXe
        {
            get { return KetQua == TrangThaiCuocGoiTaxi.CuocGoiKhongXe; }
        }

        [Field]
        public int LayTGTuDong_Don {set;get;}
        [Field]
        public int LayTGTuDong_Tra { set; get; }
        [Field]
        public int DongBo {set;get;}
        [Field]
        public long CuocKhachID {set;get;}

        [Field]
        public Enum_CallType KieuCuocGoi { set; get; }
                
        public int KieuCuocGoi_Int
        {
            get { return (int)KieuCuocGoi; }
        }

        [Field]
        public string GhiChuTiepNhan { set; get; }
        [Field]
        public int DiemXuatPhat { set; get; }

        [Field]
        public int SoLuong { set; get; }

        [Field]
        public double KmGPS { set; get; }
        [Field]
        public string LenhTiepNhan { set; get; }
        [Field]
        public string LenhDieuXe { set; get; }

        [Field]
        public int ChayTuyen { set; get; }

        [Field]
        public int SoLanGoiLai { set; get; }

        [Field]
        public int FK_CuocGoiID_Copy {set;get;}

        [Field]
        public string MaKH { set; get; }

        [Field]
        public KieuKhachHangGoiDen KieuKhachHangGoiDen { set; get; }

        public int KieuKhachHangGoiDen_Int
        {
            get { return (int)KieuKhachHangGoiDen; }
        }
        /// <summary>
        /// Mã nhân viên tiếp nhận
        /// </summary>
        [Field]
        public string MaNVTiepNhan { set; get; }

        /// <summary>
        /// Mã nhân viên điều xe
        /// </summary>
        [Field]
        public string MaNVDieuXe { set; get; }

        /// <summary>
        /// Đánh dấu cuộc gọi có phải do bộ phận bốc xếp gọi không
        /// </summary>
        [Field]
        public bool CoBocXep { set; get; }

        /// <summary>
        /// Trạng thái lệnh của bộ phận nào cập nhật
        /// </summary>
        [Field]
        public TrangThaiLenhTaxi TrangThaiLenh { set; get; }

        [Field]
        public int FK_TypesOfGoods { set; get; }

        [Field]
        public int FK_DiemDo { set; get; }

        [Field]
        public LoaiCuocHangThucHien LoaiCuocHang { set; get; }

        [Field]
        public DateTime? LastModified { set; get; }

        [Field]
        public bool LaCuocGoiChen { set; get; }

        public string TenTuyenDuong { set; get; }
        public string NameVungDH { set; get; }
        public string TenKhachHang { set; get; }
        public string TenLoaiXe { get; set; }
        public string TenNhomKhachHang { get; set; }
        public string TenCuocGoi { get; set; }
        public string TenKieuCuocHang { get; set; }
        public string TenHangHoa { get; set; }
        [Field]
        public string XeDeCu { set; get; }
        /// <summary>
        /// chuối xe đề cử kèm cả thông số tọa độ, khoảng cách, trạng thái,...
        /// </summary>
        [Field]
        public string XeDeCu_TD { set; get; }
        [Field]
        public long IdCuocGoiLai { set; get; }
        [Field]
        public string ThoiDiemGoiLai { set; get; }
        public DateTime? ThoiDiemKhongNhacMay { set; get; }
        [Field]
        public string FileVoicePath { set; get; }
        [Field]
        public DateTime TGDieuXe { set; get; }
        [Field]
        public int IsCaBa { set; get; }
        [Field]
        public bool IsCash { set; get; }
        #endregion

        public List<TaxiOperation_Truck_End> GetCuocTheoTuyenDuong(DateTime? from, DateTime? to, string lsTuyenDuongID)
        {
            return this.ExeStore("EnVang_Report_T_TAXIOPERATION_TRUCK_END_CuocTheoTuyenDuong", from, to, lsTuyenDuongID).ToList<TaxiOperation_Truck_End>();
        }

        public List<TaxiOperation_Truck_End> GetCuocTheoDiem(DateTime? from, DateTime? to)
        {
            return this.ExeStore("EnVang_Report_T_TAXIOPERATION_TRUCK_END_CuocTheoDiem", from, to).ToList<TaxiOperation_Truck_End>();
        }

        public List<TaxiOperation_Truck_End> BCKhachHopDongThang(DateTime? from, DateTime? to,int TypeKhachHang)
        {
            return this.ExeStore("EnVang_Report_T_TAXIOPERATION_TRUCK_END_BCKhachHopDongThang", from, to, TypeKhachHang).ToList<TaxiOperation_Truck_End>();
        }

        public TaxiOperation_Truck GetListTruckByKey(int id)
        {
            return this.ExeStore("sp_GetListTruckEndByKey", id).ToList<TaxiOperation_Truck>().FirstOrDefault();
        }

        public int ToTruck()
        {
            return this.ExeStoreNoneQuery("sp_TaxiOperation_Truck_End_To_Truck",this.Id);
        }
        public List<TaxiOperation_Truck> GetAllByDate_SoHieuXe(DateTime date, string sohieuxe, string soDienThoai, string diaChi)
        {
            return this.ExeStore("SP_T_TAXIOPERATION_TRUCK_GetAllByDate_SoHieuXe", date, sohieuxe, soDienThoai, diaChi).ToList<TaxiOperation_Truck>();
        }
        #region Methods Common
        
        public object Clone()
        {
            return MemberwiseClone();
        }
        #endregion

        #region Temps
        ///// <summary>
        ///// Lay danh sach cuoc goi theo vung hoac line tuong ung
        ///// </summary>
        ///// <param name="LineVung"></param>
        ///// <returns></returns>
        //public List<TaxiOperation_Truck_End> GetAllByLine_Vung(params object[] para)
        //{
        //    return ExeStore("SP_T_TAXIOPERATION_TRUCK_END_LayAllOfVungChoPhep", para).ToList<TaxiOperation_Truck_End>();
        //}

        ///// <summary>
        ///// Lay danh sach cuoc goi theo vung hoac line tuong ung
        ///// V3 có thêm thông tin tìm kiếm
        ///// </summary>
        ///// <param name="LineVung"></param>
        ///// <returns></returns>
        //public List<TaxiOperation_Truck_End> GetAllByLine_Vung(string vung, int ismaytinh, ThongTinTimKiem tttk)
        //{
        //    return ExeStore("SP_T_TAXIOPERATION_TRUCK_END_LayAllOfVungChoPhep_v2", vung, ismaytinh, tttk.SoXe, tttk.DienThoai, tttk.DiaChi, tttk.IsAllLine_Vung).ToList<TaxiOperation_Truck_End>();
        //}

        #endregion
        #region Get Data For Grid
       
        /// <summary>
        /// Lay danh sach cuoc goi theo vung hoac line tuong ung
        /// V3 có thêm địa chỉ trả trong thông tin tìm kiếm
        /// </summary>
        /// <param name="LineVung"></param>
        /// <returns></returns>
        public List<TaxiOperation_Truck_End> GetAllByLine_Vung_v3(string vung, int ismaytinh, ThongTinTimKiem tttk)
        {
            return ExeStore("SP_T_TAXIOPERATION_TRUCK_END_LayAllOfVungChoPhep_v3", vung, ismaytinh, tttk.SoXe, tttk.DienThoai, tttk.DiaChi, tttk.DiaChiTra, tttk.IsAllLine_Vung).ToList<TaxiOperation_Truck_End>();
        }

        /// <summary>
        /// Lấy báo cáo chi tiết cuộc gọi đến
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="nvTongDai"></param>
        /// <param name="ketQua"></param>
        /// <param name="loaiXe"></param>
        /// <param name="kieuCG"></param>
        /// <param name="nvDienThoai"></param>
        /// <param name="diaChi"></param>
        /// <param name="soXe"></param>
        /// <param name="sdt"></param>
        /// <param name="line"></param>
        /// <param name="vung"></param>
        /// <returns></returns>
        public List<TaxiOperation_Truck_End> Get_BaoCaoChiTietCuocGoiDen(DateTime? from, DateTime? to, string sdt, string line, string vung, string kieuCG,
            string nvDienThoai, string nvTongDai, string ketQua, string loaiXe, string diaChi, string soXe)
        {

            return this.ExeStore("EnVang_Report_T_TAXIOPERATION_TRUCK_END_BaoCaoChiTietCuocGoiDen", 
                from, to, sdt, line, vung, kieuCG,
                nvDienThoai, nvTongDai, ketQua, loaiXe, diaChi, soXe).ToList<TaxiOperation_Truck_End>();
        }

        #endregion

        #region Bàn cờ
        public List<TaxiOperation_Truck_End> GetAllXeNhan_KetThuc(DateTime ThoiDiemThayDoiDuLieu)
        {
            return ExeStore("SP_T_TAXIOPERATION_TRUCK_END_GET_XENHAN", ThoiDiemThayDoiDuLieu).ToList<TaxiOperation_Truck_End>();
        }
        #endregion

        public List<TaxiOperation_Truck> GetTrunkByDate(DateTime dt)
        {
            return ExeStore("SP_T_TAXIOPERATION_TRUCK_GetTrunkByDate",dt).ToList<TaxiOperation_Truck>();
        }
    }

    public static class Extensions
    {
        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
    }
    
    public class SubTypeGroup
    {
        public int Id {set;get;}
        public string Name {set;get;}
        public SubTypeGroup(int id, string name)
        {
            Id = id;
            Name = name;

        }
    }

}