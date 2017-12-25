using System;
using System.Collections.Generic;
using Taxi.Common.Extender;
using Taxi.Data.BanCo.Entity.DM;
using Taxi.Data.BanCo.Entity.GiamSatXe;
using Taxi.Data.BanCo.Entity.TuyenThueBao;
using Taxi.Utils;
using Taxi.Data;
using System.Data;
using System.Linq;
using Taxi.Entity;
using Taxi.Utils.Enums;
using Taxi.Data.EnVang;

namespace Taxi.Business
{
    /// <summary>
    /// Thong tin cuoc khach
    /// </summary>
    /// <Modified>        
    ///	Name		Date		    Comment 
    /// Congnt      16/07            Create
    /// Luu thong tin cua cuoc khach, lien quan toi truc chinh cua chuong trinh
    /// BatSo, DienThoai, TongDai,DieuHanhChinh
    /// </Modified>
    public class CuocGoi
    {
        #region ================ Properties ================

        #region ------ Common -------------------
        private long id;
        /// <summary>
        /// Ma cuoc goi
        /// </summary>
        /// 
        public long IDCuocGoi
        {
            get { return id; }
            set { id = value; }
        }
        private DateTime thoiDiemGoi;
        public DateTime ThoiDiemGoi
        {
            get { return thoiDiemGoi; }
            set { thoiDiemGoi = value; }
        }

        private DateTime _thoiGianHen;

        public DateTime ThoiGianHen
        {
            get { return _thoiGianHen; }
            set { _thoiGianHen = value; }
        }

        public string ThoiGianHenText
        {
            get
            {
                if (_thoiGianHen.Year > 100 && ThoiGianHen > ThoiDiemGoi)
                    return _thoiGianHen.ToString("HH:mm dd/MM/yyyy");
                else
                    return "";
            }
        }

        /// <summary>
        /// Nếu là cuốc fasttaxi thì lấy FT_Date và không phải thì lấy thoidiemgoi;
        /// </summary>
        public DateTime ThoiDiemGoi_FT
        {
            get { return FT_IsFT && FT_Date.HasValue ? FT_Date.Value : ThoiDiemGoi; }
        }

        private int soLanGoi;
        /// <summary>
        /// số lần khách đã gọi (gọi lại)
        /// </summary>
        public int SoLanGoi
        {
            get { return soLanGoi; }
            set { soLanGoi = value; }
        }
        private int line;
        /// <summary>
        /// line dien thoai
        /// </summary>
        public int Line
        {
            get { return line; }
            set { line = value; }
        }

        private string phoneNumber;
        /// <summary>
        /// so dien thoai goi den
        /// </summary>
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        private int soChuong;
        /// <summary>
        /// so chuong 
        /// </summary>
        public int SoLuotDoChuong
        {
            get { return soChuong; }
            set { soChuong = value; }
        }
        private DateTime thoiLuongGoi;
        /// <summary>
        /// thoi luong goi tinh bang gio phut giay
        /// Kieu : 1900/01/01 00:04:07  
        /// ThoiLuong : 4 phut 7 giay
        /// </summary>
        public DateTime TongThoiGianDamThoai
        {
            get { return thoiLuongGoi; }
            set { thoiLuongGoi = value; }
        }

        private string diaChiLuu;
        /// <summary>
        /// Thông tin khách hàng (lấy dùng tạm)
        /// </summary>
        public string DiaChiGoi
        {
            get { return diaChiLuu; }
            set { diaChiLuu = value; }
        }
        private string diaChiDonKhach;
        /// <summary>
        /// dia chi thuc hien don khach
        /// </summary>
        public string DiaChiDonKhach
        {
            get { return diaChiDonKhach; }
            set { diaChiDonKhach = value; }
        }
        private int vung;
        /// <summary>
        /// vung (kenh) cua diem dia chi don khach
        /// </summary>
        public int Vung
        {
            get { return vung; }
            set { vung = value; }
        }
        private string loaiXe;
        /// <summary>
        /// loai xe
        /// ds cac loai xe khac chon
        /// vd ; KIA, VIO, INO, LIMO
        /// </summary>
        public string LoaiXe
        {
            get { return loaiXe; }
            set { loaiXe = value; }
        }
        private int soLuongXe;
        /// <summary>
        /// so luong xe
        /// </summary>
        public int SoLuong
        {
            get { return soLuongXe; }
            set { soLuongXe = value; }
        }

        private KieuKhachHangGoiDen loaiKhachHang;
        /// <summary>
        /// kieu khach hang goi den 
        /// KhachHangKhongHieu = 0, // khach vui ve, khach ao
        /// KhachHangBinhThuong=1,
        /// KhachHangMoiGioi=2,
        /// KhachHangVIP=3,
        /// KhachHangHen=9,
        /// </summary>
        public KieuKhachHangGoiDen KieuKhachHangGoiDen
        {
            get { return loaiKhachHang; }
            set { loaiKhachHang = value; }
        }
        private bool isCuocGiaLap;
        /// <summary>
        /// la cuoc gia lap
        /// </summary>
        public bool IsCuocGiaLap
        {
            get { return isCuocGiaLap; }
            set { isCuocGiaLap = value; }
        }

        private TrangThaiCuocGoiTaxi trangThaiCuocGoi;
        /// <summary>
        /// trang thai cuoc goi taxi
        ///  KhongXacDinh, DonDuoc, Truot, Hoan, KhongXe
        /// </summary>
        public TrangThaiCuocGoiTaxi TrangThaiCuocGoi
        {
            get { return trangThaiCuocGoi; }
            set { trangThaiCuocGoi = value; }
        }
        private KieuCuocGoi kieuCuocGoi;

        public KieuCuocGoi KieuCuocGoi
        {
            get { return kieuCuocGoi; }
            set { kieuCuocGoi = value; }
        }
        private LoaiCuocKhach loaiCuocKhach;
        /// <summary>
        /// loai cuoc khach
        /// </summary>
        public LoaiCuocKhach LoaiCuocKhach
        {
            get { return loaiCuocKhach; }
            set { loaiCuocKhach = value; }
        }
        private string lenhDienThoai;
        /// <summary>
        /// lenh dien thoai, lenh tu nhan vien dien thoai chuyen sang
        /// cho nhan vien tong dai
        /// </summary>
        public string LenhDienThoai
        {
            get { return lenhDienThoai; }
            set { lenhDienThoai = value; }
        }
        private string lenhTongDai;
        /// <summary>
        /// lenh tong dai chuyen sang ben dien thoai
        /// </summary>
        public string LenhTongDai
        {
            get { return lenhTongDai; }
            set { lenhTongDai = value; }
        }
        private TrangThaiLenhTaxi trangThaiLenh;
        /// <summary>
        /// trang thai lenh  gan den thay thong tin ben nao thay doi trang thai cuoi cung
        /// </summary>
        public TrangThaiLenhTaxi TrangThaiLenh
        {
            get { return trangThaiLenh; }
            set { trangThaiLenh = value; }
        }
        private string ghiChuDienThoai;
        /// <summary>
        /// ghi chu thong ti n cuar NVDT chuyen sang cho nhan vien tong dai
        /// </summary>
        public string GhiChuDienThoai
        {
            get { return ghiChuDienThoai; }
            set { ghiChuDienThoai = value; }
        }
        private string ghiChuTongDai;
        /// <summary>
        /// thong tin ghi chu cua nhan vien Tong dai
        /// </summary>
        public string GhiChuTongDai
        {
            get { return ghiChuTongDai; }
            set { ghiChuTongDai = value; }
        }
        private string maNhanVienDienThoai;
        /// <summary>
        /// ma nhan vien dien thoai
        /// </summary>
        public string MaNhanVienDienThoai
        {
            get { return maNhanVienDienThoai; }
            set { maNhanVienDienThoai = value; }
        }
        private string maNhanVienTongDai;
        /// <summary>
        ///  ma nhien vien tong dai
        /// </summary>
        public string MaNhanVienTongDai
        {
            get { return maNhanVienTongDai; }
            set { maNhanVienTongDai = value; }
        }
        private string xeNhan;
        /// <summary>
        /// Xe nhan
        /// </summary>
        public string XeNhan
        {
            get { return xeNhan; }
            set { xeNhan = value; }
        }

        private string xeNhan_TD;
        /// <summary>
        /// Toa Do Xe nhan
        /// </summary>
        public string XeNhan_TD
        {
            get { return xeNhan_TD; }
            set { xeNhan_TD = value; }
        }

        private string xeDon;
        /// <summary>
        /// xe don 
        /// </summary>
        public string XeDon
        {
            get { return xeDon; }
            set { xeDon = value; }
        }
        private string diaChiTraKhach;
        /// <summary>
        /// thong tin dia chi tra khach
        /// </summary>
        public string DiaChiTraKhach
        {
            get { return diaChiTraKhach; }
            set { diaChiTraKhach = value; }
        }
        private int thoiGianChuyenTongDai;
        /// <summary>
        /// so giay tinh ca luc nghe may den khi chuyen tong dai
        /// </summary>
        public int ThoiDiemChuyenTongDai
        {
            get { return thoiGianChuyenTongDai; }
            set { thoiGianChuyenTongDai = value; }
        }
        /// <summary>
        /// dung để hiển thị trên lưới
        /// </summary>
        public string HienThi_ThoiGianChuyenTongDai
        {
            get { return StringTools.ConvertSoGiay_PhutGiay(thoiGianChuyenTongDai); }
        }
        private int thoiGianDieuXe;
        /// <summary>
        /// thoi gian dieu duoc xe nhan (theo giay)
        /// </summary>
        public int ThoiGianDieuXe
        {
            get { return thoiGianDieuXe; }
            set { thoiGianDieuXe = value; }
        }
        /// <summary>
        /// hiển thị trên lưới
        /// </summary>
        public string HienThi_ThoiGianDieuXe
        {
            get { return StringTools.ConvertSoGiay_PhutGiay(thoiGianDieuXe); }
        }
        private int thoiGianDonKhach;
        /// <summary>
        /// thoigian don duoc khach tu luc co xe don
        /// </summary>
        public int ThoiGianDonKhach
        {
            get { return thoiGianDonKhach; }
            set { thoiGianDonKhach = value; }
        }
        public string HienThi_ThoiGianDonKhach
        {
            get { return StringTools.ConvertSoGiay_PhutGiay(thoiGianDonKhach); }
        }
        private string fileVoicePath;
        /// <summary>
        /// duoc dan file am thanh luu
        /// </summary>
        public string FileVoicePath
        {
            get { return fileVoicePath; }
            set { fileVoicePath = value; }
        }
        private string maDoiTac;

        public string MaDoiTac
        {
            get { return maDoiTac; }
            set { maDoiTac = value; }
        }
        private int vungGPSID;
        /// <summary>
        /// dung cua diem khach goi, tai mot 
        /// </summary>
        public int VungGPSID
        {
            get { return vungGPSID; }
            set { vungGPSID = value; }
        }

        /// <summary>
        /// dia chi cua khach co lay duoc thong tin toa do
        /// </summary>
        public bool CoGPS
        {
            get
            {
                if (gps_KinhDo > 0 && gps_ViDo > 0)
                    return true;
                else
                    return false;
            }
            set { }
        }
        private double gps_KinhDo;
        /// <summary>
        /// kinh do cua diem khach goi
        /// </summary>
        public double GPS_KinhDo
        {
            get { return gps_KinhDo; }
            set { gps_KinhDo = value; }
        }
        private double gps_ViDo;
        /// <summary>
        /// vi do cua diem khach goi
        /// </summary>
        public double GPS_ViDo
        {
            get { return gps_ViDo; }
            set { gps_ViDo = value; }
        }
        private string danhSachXeDeCu;
        /// <summary>
        /// danh sach xe de cu (123.234)
        /// </summary>
        public string DanhSachXeDeCu
        {
            get { return danhSachXeDeCu; }
            set { danhSachXeDeCu = value; }
        }

        private string danhSachXeDeCu_TD;
        /// <summary>
        /// tọa độ danh sach xe de cu (KD VD 0,5,KD VD. 0,8)
        /// </summary>
        public string DanhSachXeDeCu_TD
        {
            get { return danhSachXeDeCu_TD; }
            set { danhSachXeDeCu_TD = value; }
        }

        private DateTime thoiDiemCapNhatXeDeCu;
        /// <summary>
        /// thoi diem cap nhat xe de cu
        /// </summary>
        public DateTime ThoiDiemCapNhatXeDeCu
        {
            get { return thoiDiemCapNhatXeDeCu; }
            set { thoiDiemCapNhatXeDeCu = value; }
        }
        private DateTime thoiDiemCapNhat;
        /// <summary>
        /// thoi diem cap nhat du lieu cuoi cung cua cuoc goi
        /// </summary>
        public DateTime ThoiDiemThayDoiDuLieu
        {
            get { return thoiDiemCapNhat; }
            set { thoiDiemCapNhat = value; }
        }

        //hangtm bổ sung
        private string mPhanLoai;
        public string PhanLoai
        {
            get { return mPhanLoai; }
            set { mPhanLoai = value; }
        }

        private string mKetQua;
        public string KetQua
        {
            set { mKetQua = value; }
            get { return mKetQua; }
        }

        //-------New v3---------
        // THONG TIM CAM ON 
        private DateTime _CamOn_ThoiDiemChen;

        public DateTime CamOn_ThoiDiemChen
        {
            get { return _CamOn_ThoiDiemChen; }
            set { _CamOn_ThoiDiemChen = value; }
        }
        private bool _CamOn_DaCamOn;

        public bool CamOn_DaCamOn
        {
            get { return _CamOn_DaCamOn; }
            set { _CamOn_DaCamOn = value; }
        }
        private KieuKhachDanhGiaCAMON _CamOn_DanhGia;

        public KieuKhachDanhGiaCAMON CamOn_DanhGia
        {
            get { return _CamOn_DanhGia; }
            set { _CamOn_DanhGia = value; }
        }
        private string _CamOn_YKien;

        public string CamOn_YKien
        {
            get { return _CamOn_YKien; }
            set { _CamOn_YKien = value; }
        }
        private DateTime _CamOn_ThoiDiemSuaCuoi;

        public DateTime CamOn_ThoiDiemSuaCuoi
        {
            get { return _CamOn_ThoiDiemSuaCuoi; }
            set { _CamOn_ThoiDiemSuaCuoi = value; }
        }

        private string _CamOn_NhanVien;

        public string CamOn_NhanVien
        {
            get { return _CamOn_NhanVien; }
            set { _CamOn_NhanVien = value; }
        }
        private string _CamOn_NhanVienSuaCuoi;

        public string CamOn_NhanVienSuaCuoi
        {
            get { return _CamOn_NhanVienSuaCuoi; }
            set { _CamOn_NhanVienSuaCuoi = value; }
        }

        /// <summary>
        /// Du lieu duoc lay ra tu THoiDiemGoi (chi ngay 2008-22-09)
        /// </summary>
        private string mThoiDiemGoiNgay;
        public string ThoiDiemGoiNgay
        {
            get { return mThoiDiemGoiNgay; }
            set { mThoiDiemGoiNgay = value; }
        }
        /// <summary>
        /// Du lieu duoc lay ra tu ThoiDiemGoi (Chi lay gio HH-mm-ss)
        /// </summary>
        private string mThoiDiemGoiGio;
        public string ThoiDiemGoiGio
        {
            get { return mThoiDiemGoiGio; }
            set { mThoiDiemGoiGio = value; }
        }
        //@GoiTaxi char(1),
        private bool mGoiTaxi;
        public bool GoiTaxi
        {
            get { return mGoiTaxi; }
            set { mGoiTaxi = value; }
        }
        //@GoiKhieuNai char(1),
        private bool mGoiKhieuNai;
        public bool GoiKhieuNai
        {
            get { return mGoiKhieuNai; }
            set { mGoiKhieuNai = value; }
        }
        //@ThongTinKhac char(1),
        private bool mThongTinKhac;

        public bool ThongTinKhac
        {
            get { return mThongTinKhac; }
            set { mThongTinKhac = value; }
        }
        //@GoiLai char(1),
        private bool mGoiLai;

        public bool GoiLai
        {
            get { return mGoiLai; }
            set { mGoiLai = value; }
        }

        private bool _GoiHoiDam;

        public bool GoiHoiDam
        {
            get { return _GoiHoiDam; }
            set { _GoiHoiDam = value; }
        }

        private bool _GoiDichVu;

        public bool GoiDichVu
        {
            get { return _GoiDichVu; }
            set { _GoiDichVu = value; }
        }

        private bool _GoiNho;

        public bool GoiNho
        {
            get { return _GoiNho; }
            set { _GoiNho = value; }
        }

        private string _xeDenDiem;
        /// <summary>
        /// Xe den diem
        /// </summary>
        public string XeDenDiem
        {
            get { return _xeDenDiem; }
            set { _xeDenDiem = value; }
        }

        private string _xeDenDiemDonKhach;
        /// <summary>
        /// Xe den diem
        /// </summary>
        public string XeDenDiemDonKhach
        {
            get { return _xeDenDiemDonKhach; }
            set { _xeDenDiemDonKhach = value; }
        }

        private string _xeDenDiemDonKhach_TD;
        /// <summary>
        /// Xe den diem don khach co toa do
        /// </summary>
        public string XeDenDiemDonKhach_TD
        {
            get { return _xeDenDiemDonKhach_TD; }
            set { _xeDenDiemDonKhach_TD = value; }
        }

        private string _xeDenDiemDonKhachDeCu;
        /// <summary>
        /// Xe den diem
        /// </summary>
        public string XeDenDiemDonKhachDeCu
        {
            get { return _xeDenDiemDonKhachDeCu; }
            set { _xeDenDiemDonKhachDeCu = value; }
        }

        private string _xeDenDiemDonKhachDeCu_TD;
        /// <summary>
        /// Xe den diem don khach co toa do
        /// </summary>
        public string XeDenDiemDonKhachDeCu_TD
        {
            get { return _xeDenDiemDonKhachDeCu_TD; }
            set { _xeDenDiemDonKhachDeCu_TD = value; }
        }

        private XacNhanXeDon _XacNhanXeDon;
        public XacNhanXeDon XacNhanXeDon
        {
            get { return _XacNhanXeDon; }
            set { _XacNhanXeDon = value; }
        }
        /// <summary>
        /// Đủ xe đón so với số lượng hay không
        /// </summary>
        private bool _DuXeDon;
        public bool DuXeDon
        {
            get { return _DuXeDon; }
            set { _DuXeDon = value; }
        }

        private string mCuocGoiLaiIDs;

        public string CuocGoiLaiIDs
        {
            get { return mCuocGoiLaiIDs; }
            set { mCuocGoiLaiIDs = value; }
        }


        private bool _chuyenMK;
        /// <summary>
        /// Chuyển cuộc gọi sang mời khách
        /// </summary>
        public bool ChuyenMK
        {
            get { return _chuyenMK; }
            set { _chuyenMK = value; }
        }

        /// <summary>
        /// Không dùng service mobile
        /// </summary>
        /// <value>
        /// <c>true</c> if [not using mobile service]; otherwise, <c>false</c>.
        /// </value>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  9/1/2015   created
        /// </Modified>
        public bool? KhongDungMobileService { get; set; }

        public string XeDenDiem_CB { get; set; }

        /// <summary>
        /// Giá tiền của cuốc đường dài hoặc sân bay
        /// </summary>
        public int MoneyTrip { get; set; }
        /// <summary>
        /// Hiển thị sdt trên app lx như cuốc đặt từ app kh
        /// </summary>
        public bool ShowPhoneAppDriver { get; set; }
        #endregion

        #region ------ THONG TIN MOI KHACH ------

        private string _MOIKHACH_LenhMoiKhach;

        public string MOIKHACH_LenhMoiKhach
        {
            get { return _MOIKHACH_LenhMoiKhach; }
            set { _MOIKHACH_LenhMoiKhach = value; }
        }
        private DateTime _MOIKHACH_ThoiDiemMoi_Giu;

        public DateTime MOIKHACH_ThoiDiemMoi_Giu
        {
            get { return _MOIKHACH_ThoiDiemMoi_Giu; }
            set { _MOIKHACH_ThoiDiemMoi_Giu = value; }
        }
        private bool _MOIKHACH_XinLoi_DaXinLoi;

        public bool MOIKHACH_XinLoi_DaXinLoi
        {
            get { return _MOIKHACH_XinLoi_DaXinLoi; }
            set { _MOIKHACH_XinLoi_DaXinLoi = value; }
        }
        private DateTime _MOIKHACH_XinLoi_ThoiDiem;

        public DateTime MOIKHACH_XinLoi_ThoiDiem
        {
            get { return _MOIKHACH_XinLoi_ThoiDiem; }
            set { _MOIKHACH_XinLoi_ThoiDiem = value; }
        }
        private bool _MOIKHACH_KhieuNai_DaXyLy;

        public bool MOIKHACH_KhieuNai_DaXyLy
        {
            get { return _MOIKHACH_KhieuNai_DaXyLy; }
            set { _MOIKHACH_KhieuNai_DaXyLy = value; }
        }
        private string _MOIKHACH_KhieuNai_ThongTinThem;

        public string MOIKHACH_KhieuNai_ThongTinThem
        {
            get { return _MOIKHACH_KhieuNai_ThongTinThem; }
            set { _MOIKHACH_KhieuNai_ThongTinThem = value; }
        }
        private string _MOIKHACH_NhanVien;

        public string MOIKHACH_NhanVien
        {
            get { return _MOIKHACH_NhanVien; }
            set { _MOIKHACH_NhanVien = value; }
        }

        #endregion THONG TIN MOI KHACH

        #region ------ BANTIBANGIA --------------

        private string _BTBG_NoiDungXuLy;

        public string BTBG_NoiDungXuLy
        {
            get { return _BTBG_NoiDungXuLy; }
            set { _BTBG_NoiDungXuLy = value; }
        }
        private bool _BTBG_IsDaXuLy;

        public bool BTBG_IsDaXuLy
        {
            get { return _BTBG_IsDaXuLy; }
            set { _BTBG_IsDaXuLy = value; }
        }
        private string _BTBG_NhanVien;

        public string BTBG_NhanVien
        {
            get { return _BTBG_NhanVien; }
            set { _BTBG_NhanVien = value; }
        }
        private DateTime _BTBG_ThoiDiemXuLy;

        public DateTime BTBG_ThoiDiemXuLy
        {
            get { return _BTBG_ThoiDiemXuLy; }
            set { _BTBG_ThoiDiemXuLy = value; }
        }

        #endregion BANTIBANGIA

        #region ------ Man hinh dieu xe ---------
        private bool _ManHinh_DaGuiXe;
        /// <summary>
        /// thông tin đã gửi tới xe
        /// </summary>
        public bool ManHinh_DaGuiXe
        {
            get { return _ManHinh_DaGuiXe; }
            set { _ManHinh_DaGuiXe = value; }
        }
        private DateTime _ManHinh_ThoiDiemGoiXe;
        /// <summary>
        /// thời điểm cuối gửi tới xe
        /// </summary>
        public DateTime ManHinh_ThoiDiemGoiXe
        {
            get { return _ManHinh_ThoiDiemGoiXe; }
            set { _ManHinh_ThoiDiemGoiXe = value; }
        }
        private byte _ManHinh_SoLanGuiXe;

        /// <summary>
        /// số lần gửi tới xe
        /// </summary>
        public byte ManHinh_SoLanGuiXe
        {
            get { return _ManHinh_SoLanGuiXe; }
            set { _ManHinh_SoLanGuiXe = value; }
        }


        #endregion

        #region ------ FastTaxi ------
        public DateTime? FT_SendDate { get; set; }
        public DateTime? FT_Date { get; set; }
        public bool FT_IsFT { get; set; }
        /// <summary>
        /// Trạng thái gửi nhận của FastTaxi
        /// </summary>
        public Enum_FastTaxi_Status FT_Status { get; set; }
        public long FT_ID { get; set; }
        public float FT_Cust_Lat { get; set; }
        public float FT_Cust_Lng { get; set; }
        public bool FT_AllowCall { get; set; }
        /// <summary>
        /// Khoảng cách giữa điểm đón với vị trị khách hàng.
        /// </summary>
        public float FT_KM { get; set; }
        #endregion

        #region ------ Envang --------

        public string MH_LenhLaiXe { get; set; }
        public DateTime? MH_ThoiDiemGuiXe { get; set; }
        public int MH_SoLanGuiToiXe { get; set; }
        public bool MH_DaGuiXe { get; set; }
        public string GhiChuLaiXe { get; set; }
        public byte? DaGuiDSXeNhan { get; set; }
        public byte? CenterConfirm { get; set; }
        public double GPS_KinhDo_Tra { get; set; }
        public double GPS_ViDo_Tra { get; set; }

        public bool isResendMobile;
        /// <summary>
        /// Xe điều chỉ định
        /// </summary>
        public string XeDieuChiDinh { get; set; }
        #endregion

        #region ------ G5 ------------
        public Guid BookId { get; set; }
        public string LenhLaiXe { get; set; }
        /// <summary>
        /// Trạng thái điều tự động
        /// </summary>
        public Enum_G5_Type G5_Type { get; set; }
        public string XeDungDiem { get; set; }
        public long G5_CopyId { get; set; }
        public string SaleOffCode { get; set; }
        private string _sanBay_DuongDai;

        public string SanBay_DuongDai
        {
            get { return _sanBay_DuongDai; }
            set { _sanBay_DuongDai = value; }
        }

        public string G5_CarType { get; set; }
        /// <summary>
        /// Các bước thực hiện
        /// </summary>
        public string G5_Step { get; set; }
        /// <summary>
        /// Thời gian gửi lên server
        /// </summary>
        public DateTime? G5_SendDate { get; set; }
        /// <summary>
        /// Đang thực hiện bước nào.
        /// </summary>
        public Enum_G5_Step G5_StepLast { get; set; }
        public bool IsKetThuc { get; set; }
        public string icon { get; set; }
        public int IsHeThong { get; set; }
        public string XeNhanG5
        {
            get
            {
                return kieuCuocGoi == KieuCuocGoi.GoiTaxi ? xeNhan : string.Empty;
            }
        }
        public int ICon
        {
            get
            {
                if (G5_Type == Enum_G5_Type.DieuApp)
                {
                    if (LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong)
                    {
                        return 5;
                    }
                    return 1;
                }
                else if (G5_Type == Enum_G5_Type.CuocKhongXeApp)
                {
                    return 2;
                }
                else if (G5_Type == Enum_G5_Type.CuocAppKH)
                {
                    return 3;
                }
                else if (G5_Type == Enum_G5_Type.CuocVangLai)
                {
                    return 6;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Dùng add cảnh báo cuốc sân bay cách 15 phút
        /// </summary>
        public bool Is15 { get; set; }
        /// <summary>
        ///  Dùng add cảnh báo cuốc sân bay cách 90 phút
        /// </summary>
        public bool Is90 { get; set; }
        public bool Is60 { get; set; }

        /// <summary>
        /// Trạng thái gửi sms lưu tạm
        /// </summary>
        public Enum_G5_PMDH_SMS_Status? SendSMS_Status { get; set; }
        #endregion

        #region Tính tiền xe đường dài

        private string _longLoaiXeID;
        public string Long_LoaiXeID { get { return _longLoaiXeID; } set { _longLoaiXeID = value; } }
        private string _longTuyenID;
        public string Long_TuyenID { get { return _longTuyenID; } set { _longTuyenID = value; } }
        private int _longChieuID;
        public int Long_ChieuID { get { return _longChieuID; } set { _longChieuID = value; } }
        public int Long_GiaTien { get; set; }
        public int Long_Km { get; set; }
        public int Long_ThoiGian { get; set; }

        public string Long_Tuyen 
        {
            get
            {
                if (_longTuyenID!=null && CommonBL.DicTuyenDuong.ContainsKey(_longTuyenID))
                {
                    return CommonBL.DicTuyenDuong[_longTuyenID];
                }

                if (CommonBL.ListTuyenDuong != null && Config_Common.NhapTuyenDuongDai)
                {
                    DMTuyenThueBao temp = CommonBL.ListTuyenDuong.FirstOrDefault(a => a.TuyenDuongID == _longTuyenID);
                    if (temp != null)
                    {
                        if (!CommonBL.DicTuyenDuong.ContainsKey(_longTuyenID))
                            CommonBL.DicTuyenDuong.Add(_longTuyenID, temp.TenTuyenDuong);
                        return temp.TenTuyenDuong;
                    }
                    else
                    {
                        if (!CommonBL.DicTuyenDuong.ContainsKey(_longTuyenID))
                            CommonBL.DicTuyenDuong.Add(_longTuyenID, string.Empty);
                        return string.Empty;
                    }
                }
                else return string.Empty;
            }
        }

        public string Long_Chieu
        {
            get
            {
                if (CommonBL.ListKieuTuyen != null && Config_Common.NhapTuyenDuongDai)
                {
                    THUEBAO_T_KIEUTUYEN temp= CommonBL.ListKieuTuyen.FirstOrDefault(a => a.Id == _longChieuID);
                    if (temp != null)
                        return temp.TypeName;
                    else return string.Empty;
                }
                else return string.Empty;
            }
        }

        public string Long_LoaiXe
        {
            get
            {
                if (CommonBL.ListHangXe != null && Config_Common.NhapTuyenDuongDai)
                {
                    TuDien_LoaiXe temp= CommonBL.ListHangXe.FirstOrDefault(a => a.LoaiXeID == _longLoaiXeID.To<int>());
                    if (temp != null)
                        return temp.TenLoaiXe;
                    else return string.Empty;
                }
                else return string.Empty;
            }
        }

        public string SMSDuongDai { get; set; }
        
        public int Money_Contract { get; set; }

        #endregion

        #endregion Properties

        #region ================ Contructor ================
        public CuocGoi()
        {
        }

        public CuocGoi( long id, DateTime thoiDiemGoi, byte soLanGoi, int line, string phoneNumber, string diaChiLuu, string diaChiDonKhach,
                        byte vungDieuDam, KieuKhachHangGoiDen loaiKhachHang, string loaiXe, string lenhDienThoai, string ghiChu, string xeNhan, 
                        string maDoiTac, float kinhDo, float viDo)
        {
            IDCuocGoi = id;
            ThoiDiemGoi = thoiDiemGoi;
            Line = line;
            SoLanGoi = soLanGoi;
            PhoneNumber = phoneNumber;
            DiaChiGoi = diaChiLuu;
            DiaChiDonKhach = diaChiDonKhach;
            Vung = vungDieuDam;
            KieuKhachHangGoiDen = loaiKhachHang;
            //-- Nhưng thông tin khác không có
            SoLuotDoChuong = 0;
            TongThoiGianDamThoai = new DateTime(1900, 01, 01, 00, 00, 00);
            LoaiXe = loaiXe;
            SoLuong = 0;
            IsCuocGiaLap = false;
            TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiChuaXacDinh;
            KieuCuocGoi = KieuCuocGoi.TrangThaiKhac;
            LoaiCuocKhach = LoaiCuocKhach.ChoKhachKhongXacDinh;
            LenhDienThoai = lenhDienThoai;
            LenhTongDai = string.Empty;
            GhiChuDienThoai = ghiChu;
            GhiChuTongDai = string.Empty;
            MaNhanVienDienThoai = string.Empty;
            MaNhanVienTongDai = string.Empty;
            //xeNhan = string.Empty;
            XeDon = string.Empty;
            DiaChiTraKhach = string.Empty;
            ThoiDiemChuyenTongDai = 0;
            ThoiGianDieuXe = 0;
            ThoiGianDonKhach = 0;
            FileVoicePath = string.Empty;
            MaDoiTac = maDoiTac;
            VungGPSID = 0;
            GPS_KinhDo = kinhDo;
            GPS_ViDo = viDo;
            DanhSachXeDeCu = "";
            ThoiDiemCapNhatXeDeCu = new DateTime(1900, 1, 1, 0, 0, 0);
            XeNhan = xeNhan;
        }

        /// <summary>
        /// Khởi taọ dữ liệu cho cuộc gọi lần đầu điện thoại
        /// </summary>
        /// <Modified>        
        ///	Name		Date		    Comment 
        /// Côngnt      16/07           Create
        /// </Modified>
        public CuocGoi(long id, DateTime thoiDiemGoi, byte soLanGoi, int line, string phoneNumber, string diaChiLuu, string diaChiDonKhach,
                                      byte vungDieuDam, KieuKhachHangGoiDen loaiKhachHang, string loaiXe, string lenhDienThoai, string ghiChu)
        {
            IDCuocGoi = id;
            ThoiDiemGoi = thoiDiemGoi;
            Line = line;
            SoLanGoi = soLanGoi;
            PhoneNumber = phoneNumber;
            DiaChiGoi = diaChiLuu;
            DiaChiDonKhach = diaChiDonKhach;
            Vung = vungDieuDam;
            KieuKhachHangGoiDen = loaiKhachHang;
            //-- Nhưng thông tin khác không có
            SoLuotDoChuong = 0;
            TongThoiGianDamThoai = new DateTime(1900, 01, 01, 00, 00, 00);
            LoaiXe = loaiXe;
            SoLuong = 0;
            IsCuocGiaLap = false;
            TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiChuaXacDinh;
            KieuCuocGoi = KieuCuocGoi.TrangThaiKhac;
            LoaiCuocKhach = LoaiCuocKhach.ChoKhachKhongXacDinh;
            LenhDienThoai = lenhDienThoai;
            LenhTongDai = string.Empty;
            GhiChuDienThoai = ghiChu;
            GhiChuTongDai = string.Empty;
            MaNhanVienDienThoai = string.Empty;
            MaNhanVienTongDai = string.Empty;
            xeNhan = string.Empty;
            XeDon = string.Empty;
            DiaChiTraKhach = string.Empty;
            ThoiDiemChuyenTongDai = 0;
            ThoiGianDieuXe = 0;
            ThoiGianDonKhach = 0;
            FileVoicePath = string.Empty;
            MaDoiTac = string.Empty;
            VungGPSID = 0;
            GPS_KinhDo = 0;
            GPS_ViDo = 0;
            DanhSachXeDeCu = "";
            ThoiDiemCapNhatXeDeCu = new DateTime(1900, 1, 1, 0, 0, 0);

        }


        /// <summary>
        /// Khởi tạo thông tin cuộc gọi update từ tổng đài sang
        /// </summary>
        public CuocGoi(long idCuocGoi, TrangThaiCuocGoiTaxi trangThaiCG, string lenhTongDai, string ghiChuTongDai, string lenhDT, string ghiChuDT, string nhanVienTD, string nhanVienDT,
                                     string xeNhan, int thoiGianDieuXe, string fileVoicePath, int vung, double gpsKinhDo, double gpsViDo,
                                     string DSXeDeCu, DateTime thoiDiemCapNhatXeDeCu, TrangThaiLenhTaxi trangThaiLenh, string lenhMoiKhach, string xeDenDiem, string xeDenDiemDonKhach, string diaChiDonKhach, string MK_NhanVien)
        {
            IDCuocGoi = idCuocGoi;
            TrangThaiCuocGoi = trangThaiCG;
            LenhTongDai = lenhTongDai;
            GhiChuTongDai = ghiChuTongDai;
            LenhDienThoai = lenhDT;
            GhiChuDienThoai = ghiChuDT;
            MaNhanVienTongDai = nhanVienTD;
            MaNhanVienDienThoai = nhanVienDT;
            XeNhan = xeNhan;
            ThoiGianDieuXe = thoiGianDieuXe;
            FileVoicePath = fileVoicePath;
            Vung = vung;
            GPS_KinhDo = gpsKinhDo;
            GPS_ViDo = gpsViDo;
            DanhSachXeDeCu = DSXeDeCu;
            ThoiDiemCapNhatXeDeCu = thoiDiemCapNhatXeDeCu;
            TrangThaiLenh = trangThaiLenh;
            MOIKHACH_LenhMoiKhach = lenhMoiKhach;
            MOIKHACH_NhanVien = MK_NhanVien;
            XeDenDiem = xeDenDiem;
            XeDenDiemDonKhach = xeDenDiemDonKhach;
            DiaChiDonKhach = diaChiDonKhach;
        }


        public CuocGoi(long idCuocGoi, DateTime thoiDiemGoi, int line, string phoneNumber, int soLanGoi, string diaChiDonKhach, int vung, string loaiXe, int soLuongXe, KieuKhachHangGoiDen loaiKhachHang,
                               bool isCuocGiaLap, KieuCuocGoi kieuCuocGoi, string lenhDienThoai, string ghiChuDT, TrangThaiLenhTaxi trangThaiLenh,
                               string maNVDT, int thoiGianChuyenTD, string dsXeDeCu, DateTime thoiDiemXeDeCu, string dsXeDeCu_TD, double KD, double VD, string xeNhan)
        {
            IDCuocGoi = idCuocGoi;
            ThoiDiemGoi = thoiDiemGoi;
            Line = line;
            PhoneNumber = phoneNumber;
            SoLanGoi = soLanGoi;
            DiaChiDonKhach = diaChiDonKhach;
            Vung = vung;
            LoaiXe = loaiXe;
            SoLuong = soLuongXe;
            KieuKhachHangGoiDen = loaiKhachHang;
            IsCuocGiaLap = isCuocGiaLap;
            KieuCuocGoi = kieuCuocGoi;
            LenhDienThoai = lenhDienThoai;
            GhiChuDienThoai = ghiChuDT;

            MaNhanVienDienThoai = maNVDT;
            ThoiDiemChuyenTongDai = thoiGianChuyenTD;
            TrangThaiLenh = trangThaiLenh;

            DanhSachXeDeCu = dsXeDeCu;
            ThoiDiemCapNhatXeDeCu = thoiDiemXeDeCu;
            DanhSachXeDeCu_TD = dsXeDeCu_TD;
            GPS_ViDo = VD;
            GPS_KinhDo = KD;
            XeNhan = xeNhan;
        }

        public CuocGoi(long idCuocGoi, DateTime thoiDiemGoi, int line, string phoneNumber, int soLanGoi, string diaChiDonKhach, int vung, string loaiXe, int soLuongXe, KieuKhachHangGoiDen loaiKhachHang,
                               bool isCuocGiaLap, KieuCuocGoi kieuCuocGoi, string lenhDienThoai, string ghiChuDT, string lenhTongDai, string ghiChuTD, TrangThaiLenhTaxi trangThaiLenh,
                               string maNVDT, string maNVTD, int thoiGianChuyenTD, string dsXeDeCu, DateTime thoiDiemXeDeCu, string dsXeDeCu_TD, double KD, double VD, string xeNhan, string xeNhan_TD, string MK_Lenh, string MK_NhanVien, string xeDenDiem, string xeDenDiemDonKhach, string xeDenDiemDonKhach_TD)
        {
            IDCuocGoi = idCuocGoi;
            ThoiDiemGoi = thoiDiemGoi;
            Line = line;
            PhoneNumber = phoneNumber;
            SoLanGoi = soLanGoi;
            DiaChiDonKhach = diaChiDonKhach;
            Vung = vung;
            LoaiXe = loaiXe;
            SoLuong = soLuongXe;
            KieuKhachHangGoiDen = loaiKhachHang;
            IsCuocGiaLap = isCuocGiaLap;
            KieuCuocGoi = kieuCuocGoi;
            LenhDienThoai = lenhDienThoai;
            GhiChuDienThoai = ghiChuDT;
            LenhTongDai = lenhTongDai;
            GhiChuTongDai = ghiChuTD;
            MaNhanVienDienThoai = maNVDT;
            MaNhanVienTongDai = maNVTD;
            ThoiDiemChuyenTongDai = thoiGianChuyenTD;
            TrangThaiLenh = trangThaiLenh;

            DanhSachXeDeCu = dsXeDeCu;
            ThoiDiemCapNhatXeDeCu = thoiDiemXeDeCu;
            DanhSachXeDeCu_TD = dsXeDeCu_TD;
            GPS_ViDo = VD;
            GPS_KinhDo = KD;
            XeNhan = xeNhan;
            XeNhan_TD = xeNhan_TD;
            MOIKHACH_NhanVien = MK_NhanVien;
            MOIKHACH_LenhMoiKhach = MK_Lenh;
            XeDenDiem = xeDenDiem;
            XeDenDiemDonKhach = xeDenDiemDonKhach;
            XeDenDiemDonKhach_TD = xeDenDiemDonKhach_TD;
        }
        public CuocGoi(long idCuocGoi, DateTime thoiDiemGoi, int line, string phoneNumber, int soLanGoi, string diaChiDonKhach, int vung, string loaiXe, int soLuongXe, KieuKhachHangGoiDen loaiKhachHang,
                              bool isCuocGiaLap, KieuCuocGoi kieuCuocGoi, string lenhDienThoai, string ghiChuDT, string lenhTongDai, string ghiChuTD, TrangThaiLenhTaxi trangThaiLenh,
                              string maNVDT, string maNVTD, int thoiGianChuyenTD, string dsXeDeCu, DateTime thoiDiemXeDeCu, string dsXeDeCu_TD, double KD, double VD, string xeNhan, string xeNhan_TD, string MK_Lenh, string MK_NhanVien, string xeDenDiem, string xeDenDiemDonKhach, string xeDenDiemDonKhach_TD, TrangThaiCuocGoiTaxi trangthaicuocgoiTaxi)
        {
            IDCuocGoi = idCuocGoi;
            ThoiDiemGoi = thoiDiemGoi;
            Line = line;
            PhoneNumber = phoneNumber;
            SoLanGoi = soLanGoi;
            DiaChiDonKhach = diaChiDonKhach;
            Vung = vung;
            LoaiXe = loaiXe;
            SoLuong = soLuongXe;
            KieuKhachHangGoiDen = loaiKhachHang;
            IsCuocGiaLap = isCuocGiaLap;
            KieuCuocGoi = kieuCuocGoi;
            LenhDienThoai = lenhDienThoai;
            GhiChuDienThoai = ghiChuDT;
            LenhTongDai = lenhTongDai;
            GhiChuTongDai = ghiChuTD;
            MaNhanVienDienThoai = maNVDT;
            MaNhanVienTongDai = maNVTD;
            ThoiDiemChuyenTongDai = thoiGianChuyenTD;
            TrangThaiLenh = trangThaiLenh;

            DanhSachXeDeCu = dsXeDeCu;
            ThoiDiemCapNhatXeDeCu = thoiDiemXeDeCu;
            DanhSachXeDeCu_TD = dsXeDeCu_TD;
            GPS_ViDo = VD;
            GPS_KinhDo = KD;
            XeNhan = xeNhan;
            XeNhan_TD = xeNhan_TD;
            MOIKHACH_NhanVien = MK_NhanVien;
            MOIKHACH_LenhMoiKhach = MK_Lenh;
            XeDenDiem = xeDenDiem;
            XeDenDiemDonKhach = xeDenDiemDonKhach;
            XeDenDiemDonKhach_TD = xeDenDiemDonKhach_TD;
            TrangThaiCuocGoi = trangthaicuocgoiTaxi;
        }


        public CuocGoi(long idCuocGoi, TrangThaiCuocGoiTaxi trangThaiCG, string lenhTongDai, string ghiChuTongDai, string lenhDT, string ghiChuDT, string nhanVienTD, string nhanVienDT,
                                    string xeNhan, int thoiGianDieuXe, string fileVoicePath, int vung, double gpsKinhDo, double gpsViDo,
                                    string DSXeDeCu, DateTime thoiDiemCapNhatXeDeCu, TrangThaiLenhTaxi trangThaiLenh, string lenhMoiKhach, string xeDenDiem, string xeDenDiemDonKhach, string diaChiDonKhach, string MK_NhanVien, string xeDenDiemDonKhachDeCu, string xeDenDiemDonKhachDeCu_TD)
        {
            IDCuocGoi = idCuocGoi;
            TrangThaiCuocGoi = trangThaiCG;
            LenhTongDai = lenhTongDai;
            GhiChuTongDai = ghiChuTongDai;
            LenhDienThoai = lenhDT;
            GhiChuDienThoai = ghiChuDT;
            MaNhanVienTongDai = nhanVienTD;
            MaNhanVienDienThoai = nhanVienDT;
            XeNhan = xeNhan;
            ThoiGianDieuXe = thoiGianDieuXe;
            FileVoicePath = fileVoicePath;
            Vung = vung;
            GPS_KinhDo = gpsKinhDo;
            GPS_ViDo = gpsViDo;
            DanhSachXeDeCu = DSXeDeCu;
            ThoiDiemCapNhatXeDeCu = thoiDiemCapNhatXeDeCu;
            TrangThaiLenh = trangThaiLenh;
            MOIKHACH_LenhMoiKhach = lenhMoiKhach;
            MOIKHACH_NhanVien = MK_NhanVien;
            XeDenDiem = xeDenDiem;
            XeDenDiemDonKhach = xeDenDiemDonKhach;
            DiaChiDonKhach = diaChiDonKhach;
            XeDenDiemDonKhachDeCu = xeDenDiemDonKhachDeCu;
            XeDenDiemDonKhachDeCu_TD = xeDenDiemDonKhachDeCu_TD;
        }


        #endregion Contructor

        #region ================ Function Common ===========
        /// <summary>
        /// Lấy dữ liệu trả về Cuộc gọi
        /// </summary>
        public static CuocGoi GetCuocGoiByDataRow(DataRow dr)
        {
            CuocGoi cuocGoi = new CuocGoi();
            try
            {
                #region ------ Common ------
                cuocGoi.IDCuocGoi = !dr.Table.Columns.Contains("ID") || dr["ID"] == DBNull.Value ? 0 : Convert.ToInt64(dr["ID"]);
                cuocGoi.ThoiDiemGoi = !dr.Table.Columns.Contains("ThoiDiemGoi") || dr["ThoiDiemGoi"] == DBNull.Value ? new DateTime(1900, 1, 1, 0, 0, 0) : Convert.ToDateTime(dr["ThoiDiemGoi"].ToString());
                if (dr["Line"] != DBNull.Value && (string)dr["Line"] != "")
                    cuocGoi.Line = Convert.ToInt32(dr["Line"].ToString());
                cuocGoi.SoLanGoi = !dr.Table.Columns.Contains("SoLanGoi") || dr["SoLanGoi"] == DBNull.Value ? 0 : int.Parse(dr["SoLanGoi"].ToString());
                cuocGoi.PhoneNumber = !dr.Table.Columns.Contains("PhoneNumber") || dr["PhoneNumber"] == DBNull.Value ? string.Empty : dr["PhoneNumber"].ToString();
                cuocGoi.DiaChiGoi = !dr.Table.Columns.Contains("DiaChiGoi") || dr["DiaChiGoi"] == DBNull.Value ? string.Empty : dr["DiaChiGoi"].ToString();
                cuocGoi.DiaChiDonKhach = !dr.Table.Columns.Contains("DiaChiDonKhach") || dr["DiaChiDonKhach"] == DBNull.Value ? string.Empty : dr["DiaChiDonKhach"].ToString();
                cuocGoi.Vung = !dr.Table.Columns.Contains("Vung") || dr["Vung"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Vung"]);
                cuocGoi.KieuKhachHangGoiDen = !dr.Table.Columns.Contains("KieuKhachHangGoiDen") || dr["KieuKhachHangGoiDen"] == DBNull.Value ? KieuKhachHangGoiDen.KhachHangKhongHieu : (KieuKhachHangGoiDen)(Convert.ToInt32(dr["KieuKhachHangGoiDen"]));
                cuocGoi.FT_Date = !dr.Table.Columns.Contains("FT_Date") || dr["FT_Date"] == DBNull.Value ? (DateTime?)null : DateTime.Parse(dr["FT_Date"].ToString());
                cuocGoi.FT_SendDate = !dr.Table.Columns.Contains("FT_SendDate") || dr["FT_SendDate"] == DBNull.Value ? (DateTime?)null : DateTime.Parse(dr["FT_SendDate"].ToString());
                cuocGoi.FT_IsFT = !dr.Table.Columns.Contains("FT_IsFT") || dr["FT_IsFT"] != DBNull.Value && Boolean.Parse(dr["FT_IsFT"].ToString());
                cuocGoi.FT_Status = !dr.Table.Columns.Contains("FT_Status") || dr["FT_Status"] == DBNull.Value ? Enum_FastTaxi_Status.KhongXacDinh : (Enum_FastTaxi_Status)dr["FT_Status"];
                cuocGoi.DiaChiTraKhach = !dr.Table.Columns.Contains("DiaChiTraKhach") || dr["DiaChiTraKhach"] == DBNull.Value ? string.Empty : dr["DiaChiTraKhach"].ToString();
                cuocGoi.FT_Cust_Lat = !dr.Table.Columns.Contains("FT_Cust_Lat") || dr["FT_Cust_Lat"] == DBNull.Value ? 0 : float.Parse(dr["FT_Cust_Lat"].ToString());
                cuocGoi.FT_Cust_Lng = !dr.Table.Columns.Contains("FT_Cust_Lng") || dr["FT_Cust_Lng"] == DBNull.Value ? 0 : float.Parse(dr["FT_Cust_Lng"].ToString());
                cuocGoi.FT_ID = !dr.Table.Columns.Contains("FT_ID") || dr["FT_ID"] == DBNull.Value ? 0 : long.Parse(dr["FT_ID"].ToString());
                cuocGoi.FT_AllowCall = !dr.Table.Columns.Contains("FT_AllowCall") || dr["FT_AllowCall"] != DBNull.Value && Boolean.Parse(dr["FT_AllowCall"].ToString());
                cuocGoi.FT_KM = !dr.Table.Columns.Contains("FT_KM") || dr["FT_KM"] == DBNull.Value ? 0 : float.Parse(dr["FT_KM"].ToString());
                //-- Nhưng thông tin khác không có
                cuocGoi.SoLuotDoChuong = !dr.Table.Columns.Contains("SoLuotDoChuong") || dr["SoLuotDoChuong"] == DBNull.Value ? 0 : int.Parse(dr["SoLuotDoChuong"].ToString());
                cuocGoi.TongThoiGianDamThoai = !dr.Table.Columns.Contains("TongThoiGianDamThoai") || dr["TongThoiGianDamThoai"] == DBNull.Value ? new DateTime(1900, 01, 01, 0, 0, 0) : new DateTime(1900, 01, 01, 0, 0, 0).AddMinutes(double.Parse(dr["TongThoiGianDamThoai"].ToString()));
                cuocGoi.LoaiXe = !dr.Table.Columns.Contains("LoaiXe") || dr["LoaiXe"] == DBNull.Value ? string.Empty : dr["LoaiXe"].ToString();
                cuocGoi.SoLuong = !dr.Table.Columns.Contains("SoLuong") || dr["SoLuong"] == DBNull.Value ? 0 : int.Parse(dr["SoLuong"].ToString());
                cuocGoi.IsCuocGiaLap = dr.Table.Columns.Contains("IsCuocGiaLap") && dr["IsCuocGiaLap"] != DBNull.Value && Convert.ToBoolean(dr["IsCuocGiaLap"].ToString());
                cuocGoi.TrangThaiCuocGoi = !dr.Table.Columns.Contains("TrangThaiCuocGoi") || dr["TrangThaiCuocGoi"] == DBNull.Value ? TrangThaiCuocGoiTaxi.CuocGoiChuaXacDinh : (TrangThaiCuocGoiTaxi)int.Parse(dr["TrangThaiCuocGoi"].ToString());
                cuocGoi.KieuCuocGoi = !dr.Table.Columns.Contains("KieuCuocGoi") || dr["KieuCuocGoi"] == DBNull.Value ? KieuCuocGoi.TrangThaiKhac : (KieuCuocGoi)int.Parse(dr["KieuCuocGoi"].ToString());
                cuocGoi.TrangThaiLenh = !dr.Table.Columns.Contains("TrangThaiLenh") || dr["TrangThaiLenh"] == DBNull.Value ? TrangThaiLenhTaxi.KhongTruyenDi : (TrangThaiLenhTaxi)int.Parse(dr["TrangThaiLenh"].ToString());
                cuocGoi.ThoiDiemThayDoiDuLieu = !dr.Table.Columns.Contains("ThoiDiemThayDoiDuLieu") || dr["ThoiDiemThayDoiDuLieu"] == DBNull.Value ? new DateTime(1900, 01, 01, 0, 0, 0) : DateTime.Parse(dr["ThoiDiemThayDoiDuLieu"].ToString());
                cuocGoi.LoaiCuocKhach = !dr.Table.Columns.Contains("LoaiCuocKhach") || dr["LoaiCuocKhach"] == DBNull.Value ? LoaiCuocKhach.ChoKhachNoiTinh : (LoaiCuocKhach)int.Parse(dr["LoaiCuocKhach"].ToString());
                cuocGoi.LenhDienThoai = !dr.Table.Columns.Contains("LenhDienThoai") || dr["LenhDienThoai"] == DBNull.Value ? string.Empty : dr["LenhDienThoai"].ToString();
                cuocGoi.LenhTongDai = !dr.Table.Columns.Contains("LenhTongDai") || dr["LenhTongDai"] == DBNull.Value ? string.Empty : dr["LenhTongDai"].ToString();
                cuocGoi.GhiChuDienThoai = !dr.Table.Columns.Contains("GhiChuDienThoai") || dr["GhiChuDienThoai"] == DBNull.Value ? string.Empty : dr["GhiChuDienThoai"].ToString();
                cuocGoi.GhiChuTongDai = !dr.Table.Columns.Contains("GhiChuTongDai") || dr["GhiChuTongDai"] == DBNull.Value ? string.Empty : dr["GhiChuTongDai"].ToString();
                cuocGoi.MaNhanVienDienThoai = !dr.Table.Columns.Contains("MaNhanVienDienThoai") || dr["MaNhanVienDienThoai"] == DBNull.Value ? string.Empty : dr["MaNhanVienDienThoai"].ToString();
                cuocGoi.MaNhanVienTongDai = !dr.Table.Columns.Contains("MaNhanVienTongDai") || dr["MaNhanVienTongDai"] == DBNull.Value ? string.Empty : dr["MaNhanVienTongDai"].ToString();
                cuocGoi.XeNhan = !dr.Table.Columns.Contains("XeNhan") || dr["XeNhan"] == DBNull.Value ? string.Empty : dr["XeNhan"].ToString();
                cuocGoi.XeNhan_TD = !dr.Table.Columns.Contains("XeNhan_TD") || dr["XeNhan_TD"] == DBNull.Value ? string.Empty : dr["XeNhan_TD"].ToString();
                cuocGoi.ThoiDiemChuyenTongDai = !dr.Table.Columns.Contains("ThoiDiemChuyenTongDai") || dr["ThoiDiemChuyenTongDai"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ThoiDiemChuyenTongDai"]);
                cuocGoi.ThoiGianDieuXe = !dr.Table.Columns.Contains("ThoiGianDieuXe") || dr["ThoiGianDieuXe"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ThoiGianDieuXe"]);
                cuocGoi.ThoiGianDonKhach = !dr.Table.Columns.Contains("ThoiGianDonKhach") || dr["ThoiGianDonKhach"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ThoiGianDonKhach"]);
                cuocGoi.FileVoicePath = !dr.Table.Columns.Contains("FileVoicePath") || dr["FileVoicePath"] == DBNull.Value ? string.Empty : dr["FileVoicePath"].ToString();
                cuocGoi.MaDoiTac = !dr.Table.Columns.Contains("MaDoiTac") || dr["MaDoiTac"] == DBNull.Value ? string.Empty : dr["MaDoiTac"].ToString();
                cuocGoi.VungGPSID = !dr.Table.Columns.Contains("FK_VungID") || dr["FK_VungID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["FK_VungID"]); 
                cuocGoi.GPS_KinhDo = !dr.Table.Columns.Contains("GPS_KinhDo") || dr["GPS_KinhDo"] == DBNull.Value ? 0 : Convert.ToDouble(dr["GPS_KinhDo"]);
                cuocGoi.GPS_ViDo = !dr.Table.Columns.Contains("GPS_ViDo") || dr["GPS_ViDo"] == DBNull.Value ? 0 : Convert.ToDouble(dr["GPS_ViDo"]);
                cuocGoi.DanhSachXeDeCu = !dr.Table.Columns.Contains("DanhSachXe_DeCu") || dr["DanhSachXe_DeCu"] == DBNull.Value ? string.Empty : dr["DanhSachXe_DeCu"].ToString();
                cuocGoi.DanhSachXeDeCu_TD = !dr.Table.Columns.Contains("DanhSachXe_DeCu_TD") || dr["DanhSachXe_DeCu_TD"] == DBNull.Value ? string.Empty : dr["DanhSachXe_DeCu_TD"].ToString();
                cuocGoi.ThoiDiemCapNhatXeDeCu = !dr.Table.Columns.Contains("ThoiDiemCapNhatXeDeCu") || dr["ThoiDiemCapNhatXeDeCu"] == DBNull.Value ? new DateTime(1900, 1, 1, 0, 0, 0) : Convert.ToDateTime(dr["ThoiDiemCapNhatXeDeCu"]);
                cuocGoi.MOIKHACH_LenhMoiKhach = !dr.Table.Columns.Contains("MOIKHACH_LenhMoiKhach") || dr["MOIKHACH_LenhMoiKhach"] == DBNull.Value ? string.Empty : dr["MOIKHACH_LenhMoiKhach"].ToString();
                cuocGoi.MOIKHACH_NhanVien = !dr.Table.Columns.Contains("MOIKHACH_NhanVien") || dr["MOIKHACH_NhanVien"] == DBNull.Value ? string.Empty : dr["MOIKHACH_NhanVien"].ToString();
                cuocGoi.XeDenDiem = !dr.Table.Columns.Contains("XeDenDiem") || dr["XeDenDiem"] == DBNull.Value ? string.Empty : dr["XeDenDiem"].ToString();
                cuocGoi.XeDenDiem_CB = cuocGoi.XeDenDiem;
                cuocGoi.XeDenDiemDonKhach = !dr.Table.Columns.Contains("XeDenDiemDonKhach") || dr["XeDenDiemDonKhach"] == DBNull.Value ? string.Empty : dr["XeDenDiemDonKhach"].ToString();
                cuocGoi.XeDenDiemDonKhach_TD = !dr.Table.Columns.Contains("XeDenDiemDonKhach_TD") || dr["XeDenDiemDonKhach_TD"] == DBNull.Value ? string.Empty : dr["XeDenDiemDonKhach_TD"].ToString();
                cuocGoi.BTBG_NoiDungXuLy = !dr.Table.Columns.Contains("BANTINBANGIA_NoiDungXuLy") || dr["BANTINBANGIA_NoiDungXuLy"] == DBNull.Value ? string.Empty : dr["BANTINBANGIA_NoiDungXuLy"].ToString();
                cuocGoi.BTBG_NhanVien = !dr.Table.Columns.Contains("BANTINBANGIA_NhanVien") || dr["BANTINBANGIA_NhanVien"] == DBNull.Value ? string.Empty : dr["BANTINBANGIA_NhanVien"].ToString();
                cuocGoi.BTBG_IsDaXuLy = dr.Table.Columns.Contains("BANTINBANGIA_IsXuLy") && dr["BANTINBANGIA_IsXuLy"] != DBNull.Value && Convert.ToBoolean(dr["BANTINBANGIA_IsXuLy"].ToString());
                cuocGoi.BTBG_ThoiDiemXuLy = !dr.Table.Columns.Contains("BANTINBANGIA_ThoiDiemXuLy") || dr["BANTINBANGIA_ThoiDiemXuLy"] == DBNull.Value ? new DateTime(1900, 1, 1, 0, 0, 0) : Convert.ToDateTime(dr["BANTINBANGIA_ThoiDiemXuLy"].ToString());
                cuocGoi.MH_LenhLaiXe = !dr.Table.Columns.Contains("MH_LenhLaiXe") || dr["MH_LenhLaiXe"] == DBNull.Value ? string.Empty : dr["MH_LenhLaiXe"].ToString();

                cuocGoi.MH_SoLanGuiToiXe = !dr.Table.Columns.Contains("MH_SoLanGuiToiXe") || dr["MH_SoLanGuiToiXe"] == DBNull.Value ? 0 : Convert.ToByte(dr["MH_SoLanGuiToiXe"].ToString());
                if (dr.Table.Columns.Contains("MH_ThoiDiemGuiXe") && dr["MH_ThoiDiemGuiXe"] != DBNull.Value)
                    cuocGoi.MH_ThoiDiemGuiXe = Convert.ToDateTime(dr["MH_ThoiDiemGuiXe"].ToString());
                cuocGoi.KhongDungMobileService = dr.Table.Columns.Contains("KhongDungMobileService") && dr["KhongDungMobileService"] != DBNull.Value && Convert.ToBoolean(dr["KhongDungMobileService"].ToString());

                cuocGoi.XeDon = !dr.Table.Columns.Contains("XeDon") || dr["XeDon"] == DBNull.Value ? string.Empty : dr["XeDon"].ToString();
                if (dr.Table.Columns.Contains("DaGuiDSXeNhan") && dr["DaGuiDSXeNhan"] != DBNull.Value)
                    cuocGoi.DaGuiDSXeNhan = Convert.ToByte(dr["DaGuiDSXeNhan"].ToString());
                if (dr.Table.Columns.Contains("CenterConfirm") && dr["CenterConfirm"] != DBNull.Value)
                    cuocGoi.CenterConfirm = Convert.ToByte(dr["CenterConfirm"].ToString());
                //
                if (dr.Table.Columns.Contains("GhiChuLaiXe") && dr["GhiChuLaiXe"] != DBNull.Value)
                {
                    cuocGoi.GhiChuLaiXe = dr["GhiChuLaiXe"].ToString();
                }
                if (dr.Table.Columns.Contains("ThoiDiemThayDoiDuLieu") && dr["ThoiDiemThayDoiDuLieu"] != DBNull.Value)
                {
                    cuocGoi.ThoiDiemThayDoiDuLieu = dr["ThoiDiemThayDoiDuLieu"].To<DateTime>();
                }
                if (dr.Table.Columns.Contains("GPS_KinhDo_Tra") && dr["GPS_KinhDo_Tra"] != DBNull.Value)
                {
                    cuocGoi.GPS_KinhDo_Tra = float.Parse(dr["GPS_KinhDo_Tra"].ToString());
                }
                if (dr.Table.Columns.Contains("GPS_ViDo_Tra") && dr["GPS_ViDo_Tra"] != DBNull.Value)
                {
                    cuocGoi.GPS_ViDo_Tra = float.Parse(dr["GPS_ViDo_Tra"].ToString());
                }
                cuocGoi.IsHeThong = (dr.Table.Columns.Contains("IsHeThong") && dr["IsHeThong"] != DBNull.Value ? dr["IsHeThong"].To<int>() : 0);
                #endregion

                #region ------ G5 -----

                cuocGoi.BookId = dr.Table.Columns.Contains("BookId") && dr["BookId"] != DBNull.Value
                    ? Guid.Parse(dr["BookId"].ToString())
                    : Guid.Empty;

                cuocGoi.LenhLaiXe = dr.Table.Columns.Contains("LenhLaiXe") && dr["LenhLaiXe"] != DBNull.Value
                    ? dr["LenhLaiXe"].ToString()
                    : string.Empty;

                cuocGoi.XeDungDiem = dr.Table.Columns.Contains("XeDungDiem") && dr["XeDungDiem"] != DBNull.Value
                    ? dr["XeDungDiem"].ToString()
                    : string.Empty;

                cuocGoi.SaleOffCode = dr.Table.Columns.Contains("SaleOffCode") && dr["SaleOffCode"] != DBNull.Value
                    ? dr["SaleOffCode"].ToString()
                    : string.Empty;

                cuocGoi.G5_CopyId = dr.Table.Columns.Contains("G5_CopyId") && dr["G5_CopyId"] != DBNull.Value
                    ? long.Parse(dr["G5_CopyId"].ToString())
                    : 0;

                if (dr.Table.Columns.Contains("G5_Type"))
                {
                    cuocGoi.G5_Type = dr["G5_Type"] == DBNull.Value ? 0 : (Enum_G5_Type)int.Parse(dr["G5_Type"].ToString());
                }
                else
                {
                    cuocGoi.G5_Type = Enum_G5_Type.None;
                }
                cuocGoi.SanBay_DuongDai = dr.Table.Columns.Contains("SanBay_DuongDai") && dr["SanBay_DuongDai"] != DBNull.Value ? dr["SanBay_DuongDai"].ToString() : string.Empty;
                cuocGoi.G5_CarType = dr.Table.Columns.Contains("G5_CarType") && dr["G5_CarType"] != DBNull.Value ? dr["G5_CarType"].ToString() : string.Empty;

                cuocGoi.G5_Step = dr.Table.Columns.Contains("G5_Step") && dr["G5_Step"] != DBNull.Value
                   ? dr["G5_Step"].ToString()
                   : string.Empty;
                cuocGoi.G5_SendDate = dr.Table.Columns.Contains("G5_SendDate") && dr["G5_SendDate"] != DBNull.Value
                   ? dr["G5_SendDate"].To<DateTime?>()
                   : null;
                cuocGoi.G5_StepLast = (Enum_G5_Step)(dr.Table.Columns.Contains("G5_StepLast") && dr["G5_StepLast"] != DBNull.Value
                   ? dr["G5_StepLast"].To<int>()
                   : 0);
                cuocGoi.IsKetThuc = (dr.Table.Columns.Contains("IsKetThuc") && dr["IsKetThuc"] != DBNull.Value && dr["IsKetThuc"].To<bool>());
                cuocGoi.CuocGoiLaiIDs = dr.Table.Columns.Contains("CuocGoiLaiIDs") && dr["CuocGoiLaiIDs"] != DBNull.Value ? dr["CuocGoiLaiIDs"].ToString() : string.Empty;
                cuocGoi.ThoiGianHen = dr.Table.Columns.Contains("ThoiGianHen") && dr["ThoiGianHen"] != DBNull.Value ? dr["ThoiGianHen"].To<DateTime>() : DateTime.MinValue;

                cuocGoi.MoneyTrip = (dr.Table.Columns.Contains("MoneyTrip") && dr["MoneyTrip"] != DBNull.Value
                   ? dr["MoneyTrip"].To<int>()
                   : 0);
                #endregion

                if (Config_Common.TDV_XENHAN_RADIO_TO_APP)
                {
                    try
                    {                        
                        if (CommonBL.DictApp_Current == null)
                        {
                            CommonBL.DictApp_Current = new Dictionary<string, Guid>();
                        }
                        if (!CommonBL.DictApp_Current.ContainsKey(cuocGoi.XeNhan))
                            CommonBL.DictApp_Current.Add(cuocGoi.XeNhan, cuocGoi.BookId);
                    }
                    catch (Exception ex)
                    {
                        LogError.WriteLogError("TDV_XENHAN_RADIO_TO_APP Add to Dict", ex);
                    }
                }
                #region Cấu hình đường dài

                if (Config_Common.NhapTuyenDuongDai)
                {
                    cuocGoi.Long_TuyenID  = dr["Long_TuyenID"].ToString();
                    cuocGoi.Long_LoaiXeID = dr["Long_LoaiXeID"].ToString();
                    cuocGoi.Long_ChieuID  = dr["Long_ChieuID"]==null?0:dr["Long_ChieuID"].To<int>();
                    cuocGoi.Long_GiaTien  = dr["Long_GiaTien"]==null?0:dr["Long_GiaTien"].To<int>();
                    cuocGoi.Long_Km       = dr["Long_Km"]==null?0:dr["Long_Km"].To<int>();
                    cuocGoi.Long_ThoiGian = dr["Long_ThoiGian"] == null ? 0 : dr["Long_ThoiGian"].To<int>();
                }
                #endregion
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetCuocGoiByDataRow", ex);
            }
            return cuocGoi;
        }
        #endregion

        #region ================ DienThoai Module ==========

        public long InsertCuocGoiLanDauByDiaChiFromMEM_V2(CuocGoi objCuocGoiMoi)
        {
            try
            {
                return new Data.CuocGoi().InsertCuocGoiLanDauByDiaChiFromMEM_V2(objCuocGoiMoi.Line.ToString(),
                                                                            objCuocGoiMoi.PhoneNumber,
                                                                            objCuocGoiMoi.ThoiDiemGoi,
                                                                            objCuocGoiMoi.diaChiDonKhach,
                                                                            objCuocGoiMoi.Vung,
                                                                            objCuocGoiMoi.KieuKhachHangGoiDen,
                                                                            objCuocGoiMoi.MaDoiTac,
                                                                            (byte)objCuocGoiMoi.SoLanGoi,
                                                                            long.Parse(objCuocGoiMoi.CuocGoiLaiIDs),
                                                                            objCuocGoiMoi.LoaiXe,
                                                                            objCuocGoiMoi.LenhDienThoai,
                                                                            objCuocGoiMoi.GhiChuDienThoai,
                                                                            (float)objCuocGoiMoi.GPS_KinhDo,
                                                                            (float)objCuocGoiMoi.GPS_ViDo,
                                                                            objCuocGoiMoi.DiaChiTraKhach);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("InsertCuocGoiLanDauByDiaChiFromMEM : ", ex);
                return 0;
            }
        }

        /// <summary>
        /// Xoa cuoc goi khong xu ly cach day 30 phut
        /// </summary>
        public void DeleteCallAuto()
        {
            new Data.CuocGoi().DeleteCallAuto();
        }
 
        #region Cuoc Goi Line Khac

        /// <summary>
        /// hàm thực hiện lấy tất cả các cuộc gọi cuộc gọi khác line được cho phép
        /// </summary>
        /// <Modified>        
        ///	Name		Date		    Comment 
        /// phupn      07/01           Create
        /// </Modified>
        public static List<CuocGoi> DIENTHOAI_LayAllCuocGoi_Khac(string lineChoPhep)
        {
            List<CuocGoi> listCuocGoi = new List<CuocGoi>();
            using (DataTable dt = new Data.CuocGoi().DIENTHOAI_LayAllCuocGoi_Khac(lineChoPhep))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        listCuocGoi.Add(GetCuocGoiByDataRow(dr));
                    }
                }
            }
            return listCuocGoi;
        }

        public static List<CuocGoi> DIENTHOAI_LayDSCuocGoiMoi_V3_Khac(string lineChoPhep, DateTime thoiDiemLayTruoc)
        {
            List<CuocGoi> listCuocGoi = new List<CuocGoi>();
            DataTable dt = new Data.CuocGoi().DIENTHOAI_LayDSCuocGoiMoi_V3_Khac(lineChoPhep, thoiDiemLayTruoc);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    listCuocGoi.Add(GetCuocGoiByDataRow(row));
                }
            }
            return listCuocGoi;
        }

        public static List<CuocGoi> DIENTHOAI_LayDSCuocGoiThayDoiByTongDai_V3_Khac(string linesDuocCapPhep, DateTime thoiDiemNhanDulieuTruoc)
        {
            List<CuocGoi> listCuocGoi = new List<CuocGoi>();
            DataTable dt = new Data.CuocGoi().DIENTHOAI_LayDSCuocGoiThayDoiByTongDai_V3_Khac(linesDuocCapPhep, thoiDiemNhanDulieuTruoc);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow objCG in dt.Rows)
                {
                    listCuocGoi.Add(GetCuocGoiByDataRow(objCG));
                }
            }

            return listCuocGoi;
        }

        public static List<long> DIENTHOAI_LayCacIDCuocGoiKetThuc_Khac(string listIDCuocGoiHienTai, string linesDuocCapPhep)
        {
            List<long> listID = new List<long>();
            using (DataTable dt = new Data.CuocGoi().DIENTHOAI_LayCacIDCuocGoiKetThuc_Khac(listIDCuocGoiHienTai, linesDuocCapPhep))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["ID"] != DBNull.Value)
                        {
                            listID.Add(Convert.ToInt64(dr["ID"].ToString()));
                        }
                    }
                }
            }
            return listID;
        }

        public static CuocGoi GetCuocGoiByDataRow_Khac(DataRow dr)
        {
            CuocGoi cuocGoi = new CuocGoi();
            try
            {
                cuocGoi.IDCuocGoi = dr["ID"] == DBNull.Value ? 0 : Convert.ToInt64(dr["ID"]);
                cuocGoi.Line = Convert.ToInt32(dr["Line"].ToString());
                cuocGoi.ThoiDiemGoi = dr["ThoiDiemGoi"] == DBNull.Value ? new DateTime(1900, 1, 1, 0, 0, 0) : Convert.ToDateTime(dr["ThoiDiemGoi"].ToString());
                cuocGoi.DiaChiDonKhach = dr["DiaChiDonKhach"] == DBNull.Value ? string.Empty : dr["DiaChiDonKhach"].ToString();
                cuocGoi.Vung = dr["Vung"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Vung"]);
                cuocGoi.LoaiXe = dr["LoaiXe"] == DBNull.Value ? string.Empty : dr["LoaiXe"].ToString();
                cuocGoi.SoLuong = dr["SoLuong"] == DBNull.Value ? 0 : int.Parse(dr["SoLuong"].ToString());
                cuocGoi.XeNhan = dr["XeNhan"] == DBNull.Value ? string.Empty : dr["XeNhan"].ToString();
                cuocGoi.XeDenDiem = dr["XeDenDiem"] == DBNull.Value ? string.Empty : dr["XeDenDiem"].ToString();
                cuocGoi.LenhDienThoai = dr["LenhDienThoai"] == DBNull.Value ? string.Empty : dr["LenhDienThoai"].ToString();
                cuocGoi.LenhTongDai = dr["LenhTongDai"] == DBNull.Value ? string.Empty : dr["LenhTongDai"].ToString();
                cuocGoi.MaNhanVienDienThoai = dr["MaNhanVienDienThoai"] == DBNull.Value ? string.Empty : dr["MaNhanVienDienThoai"].ToString();
                cuocGoi.MaNhanVienTongDai = dr["MaNhanVienTongDai"] == DBNull.Value ? string.Empty : dr["MaNhanVienTongDai"].ToString();
                cuocGoi.PhoneNumber = dr["PhoneNumber"].ToString();
                cuocGoi.ThoiDiemThayDoiDuLieu = dr["ThoiDiemThayDoiDuLieu"] == DBNull.Value ? new DateTime(1900, 1, 1, 0, 0, 0) : Convert.ToDateTime(dr["ThoiDiemThayDoiDuLieu"].ToString());
                if (dr["DaGuiDSXeNhan"] != DBNull.Value)
                    cuocGoi.DaGuiDSXeNhan = Convert.ToByte(dr["DaGuiDSXeNhan"].ToString());
                if (dr["CenterConfirm"] != DBNull.Value)
                    cuocGoi.CenterConfirm = Convert.ToByte(dr["CenterConfirm"].ToString());
                cuocGoi.GhiChuDienThoai = dr["GhiChuDienThoai"].ToString();
                cuocGoi.GhiChuTongDai = dr["GhiChuTongDai"].ToString();
                cuocGoi.GhiChuLaiXe = dr["GhiChuLaiXe"].ToString();
                cuocGoi.LenhLaiXe = dr["LenhLaiXe"].ToString();
                cuocGoi.G5_Step = dr["G5_Step"].ToString();
                cuocGoi.G5_SendDate = dr["G5_SendDate"].To<DateTime?>();
                cuocGoi.G5_Type = (Enum_G5_Type)dr["G5_Type"].To<int>();
                cuocGoi.BookId = dr["BookId"].To<Guid>();
                cuocGoi.G5_StepLast = (Enum_G5_Step)dr["G5_StepLast"].To<int>();
                cuocGoi.BTBG_NoiDungXuLy = dr["BTBG_NoiDungXuLy"].ToString();
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetCuocGoiByDataRow_Khac", ex);
            }
            return cuocGoi;
        }
        #endregion

        /// <summary>
        /// Hàm thực hiện lấy ds cuộc gọi đã giải quyết
        /// </summary>
        /// <param name="linesChoPhep"> line cho phép , '1;4;5;7'</param>
        /// <param name="soDong"> số dòng của MACDINH = 20</param>
        public static List<CuocGoi> DIENTHOAI_LayCuocGoiDaGiaiQuyet(string linesChoPhep, int soDong)
        {
            List<CuocGoi> listCuocGoi = new List<CuocGoi>();
            using (DataTable dt = new Data.CuocGoi().DIENTHOAI_LayCuocGoiDaGiaiQuyet(linesChoPhep, soDong))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        listCuocGoi.Add(GetCuocGoiByDataRow(dr));
                    }
                }
            }
            return listCuocGoi;
        }
        public static List<CuocGoi> DIENTHOAI_LayCuocGoiDaGiaiQuyetSB(string linesChoPhep, int soDong)
        {
            List<CuocGoi> listCuocGoi = new List<CuocGoi>();
            using (DataTable dt = new Data.CuocGoi().DIENTHOAI_LayCuocGoiDaGiaiQuyetSB(linesChoPhep, soDong))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        listCuocGoi.Add(GetCuocGoiByDataRow(dr));
                    }
                }
            }
            return listCuocGoi;
        }
        public static List<CuocGoi> DIENTHOAI_LayCuocGoiDaGiaiQuyetNotFT(string linesChoPhep, int soDong)
        {
            List<CuocGoi> listCuocGoi = new List<CuocGoi>();
            using (DataTable dt = new Data.CuocGoi().DIENTHOAI_LayCuocGoiDaGiaiQuyetNotFT(linesChoPhep, soDong))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        listCuocGoi.Add(GetCuocGoiByDataRow(dr));
                    }
                }
            }
            return listCuocGoi;
        }

        public static List<CuocGoi> DIENTHOAI_LayDSCuocGoiThayDoiByTongDai_V3(string linesDuocCapPhep, DateTime thoiDiemNhanDulieuTruoc)
        {
            List<CuocGoi> listCuocGoi = new List<CuocGoi>();
            DataTable dt = new Data.CuocGoi().DIENTHOAI_LayDSCuocGoiThayDoiByTongDai_V3(linesDuocCapPhep, thoiDiemNhanDulieuTruoc);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    listCuocGoi.Add(GetCuocGoiByDataRow(dr));
                }
            }

            return listCuocGoi;
        }

        public static List<CuocGoi> DIENTHOAI_LayDSCuocGoiThayDoiByTongDai_V4(string linesDuocCapPhep, DateTime thoiDiemNhanDulieuTruoc)
        {
            List<CuocGoi> listCuocGoi = new List<CuocGoi>();
            DataTable dt = new Data.CuocGoi().DIENTHOAI_LayDSCuocGoiThayDoiByTongDai_V4(linesDuocCapPhep, thoiDiemNhanDulieuTruoc);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    listCuocGoi.Add(GetCuocGoiByDataRow(dr));
                }
            }

            return listCuocGoi;
        }

        public static List<long> DIENTHOAI_LayCacIDCuocGoiKetThucByTongDai(string listIDCuocGoiHienTai, string linesDuocCapPhep)
        {
            List<long> listID = new List<long>();
            using (DataTable dt = new Data.CuocGoi().DIENTHOAI_LayCacIDCuocGoiKetThucByTongDai(listIDCuocGoiHienTai, linesDuocCapPhep))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["ID"] != DBNull.Value)
                        {
                            listID.Add(Convert.ToInt64(dr["ID"].ToString()));
                        }
                    }
                }
            }
            return listID;
        }

        /// <summary>
        /// Hàm thực hiện Update thông tin cuốc khách.
        /// chỉ lưu một phần dữ liệu của điện thoại cập nhật
        /// </summary>
        public static bool DIENTHOAI_UpdateThongTinCuocGoi(CuocGoi cuocGoi)
        {
            return new Data.CuocGoi().DIENTHOAI_UpdateThongTinCuocGoi(cuocGoi.IDCuocGoi, cuocGoi.DiaChiDonKhach, cuocGoi.PhoneNumber, cuocGoi.Vung, cuocGoi.LoaiXe, cuocGoi.SoLuong, cuocGoi.TrangThaiCuocGoi,
                                                                      cuocGoi.KieuCuocGoi, cuocGoi.LenhDienThoai, cuocGoi.TrangThaiLenh, cuocGoi.GhiChuDienThoai, cuocGoi.MaNhanVienDienThoai,
                                                                      cuocGoi.ThoiDiemChuyenTongDai, cuocGoi.GPS_KinhDo, cuocGoi.GPS_ViDo, cuocGoi.DanhSachXeDeCu, cuocGoi.DanhSachXeDeCu_TD, cuocGoi.xeDon, cuocGoi.KieuKhachHangGoiDen, cuocGoi.LoaiCuocKhach);
        }

        public static bool DIENTHOAI_UpdateThongTinCuocGoi_Mini(CuocGoi cuocGoi)
        {
            return new Data.CuocGoi().DIENTHOAI_UpdateThongTinCuocGoi_Mini(cuocGoi.IDCuocGoi, cuocGoi.DiaChiDonKhach, cuocGoi.PhoneNumber, cuocGoi.Vung, cuocGoi.LoaiXe, cuocGoi.SoLuong, cuocGoi.TrangThaiCuocGoi,
                                                                      cuocGoi.KieuCuocGoi, cuocGoi.LenhDienThoai, cuocGoi.TrangThaiLenh, cuocGoi.GhiChuDienThoai, cuocGoi.MaNhanVienDienThoai,
                                                                      cuocGoi.ThoiDiemChuyenTongDai, cuocGoi.GPS_KinhDo, cuocGoi.GPS_ViDo, cuocGoi.DanhSachXeDeCu, cuocGoi.DanhSachXeDeCu_TD, cuocGoi.xeDon, cuocGoi.KieuKhachHangGoiDen, cuocGoi.xeNhan, cuocGoi.XeDenDiem, cuocGoi.LoaiCuocKhach);
        }

        public static List<CuocGoi> DIENTHOAI_LayAllCuocGoiChuaGiaiQuyet(string Vung, string SoDT, string DiaChi)
        {
            List<CuocGoi> listCuocGoi = new List<CuocGoi>();
            using (DataTable dt = new Data.CuocGoi().DIENTHOAI_LayDSCuocGoiDangGiaiQuyet(Vung, SoDT, DiaChi))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        listCuocGoi.Add(GetCuocGoiByDataRow(dr));
                    }
                }
            }
            return listCuocGoi;
        }
        public static List<CuocGoi> DIENTHOAI_LayAllCuocGoiChuaGiaiQuyet_V2(string Vung, string SoDT, string DiaChi, string XeNhan)
        {
            List<CuocGoi> listCuocGoi = new List<CuocGoi>();
            using (DataTable dt = new Data.CuocGoi().DIENTHOAI_LayDSCuocGoiDangGiaiQuyet_V2(Vung, SoDT, DiaChi, XeNhan))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        listCuocGoi.Add(GetCuocGoiByDataRow(dr));
                    }
                }
            }
            return listCuocGoi;
        }
        public static List<CuocGoi> TongDai_LayDanhSachCacCuocDieuApp(string soDT, string diachi,string soXe)
        {
            try
            {
                List<CuocGoi> lstCuocGoi = new List<CuocGoi>();
                DataTable dt = new Data.CuocGoi().TongDai_LayDanhSachCacCuocDieuApp(soDT, diachi,soXe);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        lstCuocGoi.Add(GetCuocGoiByDataRow(dr));
                    }
                }
                return lstCuocGoi;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("TongDai_LayDanhSachCacCuocDieuApp: ", ex);
                return new List<CuocGoi>();
            }
        }


        /// <summary>
        /// Chỉ lấy cuoc đang chờ giải quyết
        /// Y/c ThanhCong
        /// </summary>
        public static List<CuocGoi> DIENTHOAI_LayAllCuocGoiChuaGiaiQuyet_TC(string Vung, string SoDT, string DiaChi)
        {
            List<CuocGoi> listCuocGoi = new List<CuocGoi>();
            using (DataTable dt = new Data.CuocGoi().DIENTHOAI_LayDSCuocGoiDangGiaiQuyet_TC(Vung, SoDT, DiaChi))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        listCuocGoi.Add(GetCuocGoiByDataRow(dr));
                    }
                }
            }
            return listCuocGoi;
        }

        /// <summary>
        /// hàm thực hiện update thông tin cuộc gọi phía điện thoại
        /// </summary>
        public static bool DIENTHOAI_UpdateDSXeDeCu(CuocGoi cuocGoi)
        {
            return new Data.CuocGoi().DIENTHOAI_UpdateDSXeDeCu(cuocGoi.IDCuocGoi, cuocGoi.DanhSachXeDeCu, cuocGoi.DanhSachXeDeCu_TD);
        }

        /// <summary>
        /// Hàm kiểm tra xem bảng T_Taxioperation có vượt quá giới hạn cuộc gọi không.
        /// </summary>
        /// <returns>true : có</returns>
        public static bool DIENTHOAI_CheckCuocGoiLimit()
        {
            return new Data.CuocGoi().DIENTHOAI_CheckCuocGoiLimit();
        }

        /// <summary>
        /// Cập nhật cuộc gọi đã giải quyết thành cuộc gọi chưa giải quyết
        /// </summary>
        public static bool DIENTHOAI_UpdateCGKetThuc2ChuaGiaiQuyet(long IDCuocGoi)
        {
            return new Data.CuocGoi().DIENTHOAI_UpdateCGKetThuc2ChuaGiaiQuyet(IDCuocGoi);
        }

        public static int DIENTHOAI_DemCuocGoiDonDuoc(DateTime tuNgay, DateTime denNgay, string maNhanVien)
        {
            return new Data.CuocGoi().DIENTHOAI_DemCuocGoiDonDuoc(tuNgay, denNgay, maNhanVien);
        }
        #endregion

        #region ================ TongDai Module ============

        /// <summary>
        /// Ham thực hiện cập nhật thông tin cuộc gọi từ phía tổng đài
        /// Một số dữ liệu sẽ cập nhật
        ///   - [ID] 
        ///,[TrangThaiCuocGoi]
        ///,[KieuCuocGoi] 
        ///,[LenhTongDai]
        ///,[TrangThaiLenh] 
        ///,[GhiChuTongDai] 
        ///,[MaNhanVienTongDai]
        ///,[XeNhan]
        ///,[XeDon]
        ///,[DiaChiTraKhach] 
        ///,[ThoiGianDieuXe]
        ///,[ThoiGianDonKhach] 
        ///,[ThoiDiemCapNhat]
        /// </summary>
        /// <param name="cuocGoi"></param>
        /// <Modified>        
        ///	Name		Date		    Comment 
        /// Cong        20/07/11        Create
        /// </Modified>
        public static bool TONGDAI_UpdateThongTinCuocGoi(CuocGoi cuocGoi)
        {
            return new Data.CuocGoi().TONGDAI_UpdateThongTinCuocGoi(cuocGoi.IDCuocGoi, cuocGoi.TrangThaiCuocGoi, cuocGoi.LenhTongDai,
                                                                    cuocGoi.GhiChuTongDai, cuocGoi.TrangThaiLenh, cuocGoi.MaNhanVienTongDai, cuocGoi.XeNhan,
                                                                    cuocGoi.XeDon, cuocGoi.DiaChiTraKhach, cuocGoi.ThoiGianDieuXe, cuocGoi.ThoiGianDonKhach,
                                                                    cuocGoi.ChuyenMK, cuocGoi.XeDenDiem);

        }
        public static bool TONGDAI_UpdateThongTinCuocGoi_BanCo(CuocGoi cuocGoi)
        {
            return new Data.CuocGoi().TONGDAI_UpdateThongTinCuocGoi_BanCo(cuocGoi.IDCuocGoi, cuocGoi.TrangThaiCuocGoi, cuocGoi.LenhTongDai,
                                                                    cuocGoi.GhiChuTongDai, cuocGoi.TrangThaiLenh, cuocGoi.MaNhanVienTongDai, cuocGoi.XeNhan,
                                                                    cuocGoi.XeDon, cuocGoi.DiaChiTraKhach, cuocGoi.ThoiGianDieuXe, cuocGoi.ThoiGianDonKhach,
                                                                    cuocGoi.ChuyenMK, cuocGoi.XeDenDiem);

        }
        public static bool TONGDAI_UpdateThongTinCuocGoi_EV(CuocGoi cuocGoi)
        {
            return new Data.CuocGoi().TONGDAI_UpdateThongTinCuocGoi_EV(cuocGoi.IDCuocGoi, cuocGoi.TrangThaiCuocGoi, cuocGoi.LenhTongDai,
                                                                    cuocGoi.GhiChuTongDai, cuocGoi.TrangThaiLenh, cuocGoi.MaNhanVienTongDai, cuocGoi.XeNhan,
                                                                    cuocGoi.XeDon, cuocGoi.DiaChiTraKhach, cuocGoi.ThoiGianDieuXe, cuocGoi.ThoiGianDonKhach,
                                                                    cuocGoi.ChuyenMK, cuocGoi.XeDenDiem, cuocGoi.KhongDungMobileService.Value);

        }

        public static bool TONGDAI_UpdateThongTinCuocGoi_NhanXuLy(CuocGoi cuocGoi)
        {
            return new Data.CuocGoi().TONGDAI_UpdateThongTinCuocGoi_NhanXuLy(cuocGoi.IDCuocGoi, cuocGoi.MaNhanVienTongDai, cuocGoi.TrangThaiCuocGoi, cuocGoi.TrangThaiLenh);

        }

        public static bool TONGDAI_UpdateThongTinCuocGoi_NhanXuLy_TatCa(string VungChoPhep, string idNVTD)
        {
            return new Data.CuocGoi().TONGDAI_UpdateThongTinCuocGoi_NhanXuLy_TatCa(VungChoPhep, idNVTD);

        }

        public static bool TONGDAI_UpdateThongTinCuocGoi_NhanXuLy_ID(string idNVTD, int soCuocGoiNhanXuLy, List<CuocGoi> lstcuocGoi, string VungChoPhep)
        {
            int soCuocGoiHienTai = lstcuocGoi.Count;
            if (soCuocGoiHienTai > 0)
            {
                if (soCuocGoiNhanXuLy < lstcuocGoi.Count)
                {
                    string IDNhanXuLy = "";
                    for (int i = 0; i <= soCuocGoiNhanXuLy - 1; i++)
                    {
                        IDNhanXuLy += lstcuocGoi[i].IDCuocGoi + ";";
                    }
                    IDNhanXuLy = IDNhanXuLy.TrimEnd(';');
                    return new Data.CuocGoi().TONGDAI_UpdateThongTinCuocGoi_NhanXuLy_TheoID(IDNhanXuLy, idNVTD);
                }
                else
                {
                    return new Data.CuocGoi().TONGDAI_UpdateThongTinCuocGoi_NhanXuLy_TatCa(VungChoPhep, idNVTD);
                }
            }
            return false;

        }

        public static bool TONGDAI_UpdateChuyenVung(long idCuocGoi, string MaNhanVienTD, int Vung, string LenhTongDai)
        {
            return new Data.CuocGoi().TONGDAI_UpdateChuyenVung(idCuocGoi, MaNhanVienTD, Vung, LenhTongDai);
        }

        public static bool TONGDAI_UpdateCuocGoiTaxi(long idCuocGoi)
        {
            return new Data.CuocGoi().TONGDAI_UpdateCuocGoiTaxi(idCuocGoi);
        }

        public static bool TONGDAI_UpdateThongTinCuocGoi_KETTHUC(CuocGoi cuocGoi)
        {

            return new Data.CuocGoi().TONGDAI_UpdateThongTinCuocGoi_KETTHUC(cuocGoi.IDCuocGoi, cuocGoi.TrangThaiCuocGoi, cuocGoi.LenhTongDai,
                                                                    cuocGoi.GhiChuTongDai, cuocGoi.TrangThaiLenh, cuocGoi.MaNhanVienTongDai, cuocGoi.XeNhan,
                                                                    cuocGoi.XeDon, cuocGoi.DiaChiTraKhach, cuocGoi.ThoiGianDieuXe, cuocGoi.ThoiGianDonKhach);

        }
        /// <summary>
        /// ham tra ve ds cac id cua cuoc goi da ket thuc boi dien thoai nhung van con phia tong dai
        /// </summary>
        /// <param name="listIDCuocGoiHienTai">Nhung ID cuoc goi hien tai phia tong dai</param>
        /// <param name="vungsDuocCapPhep">cac vung duoc cap phep cua kenh(vung)</param>
        /// <returns></returns>
        /// <Modified>        
        ///	Name		Date		    Comment 
        /// Cong        01/08/11        Create
        /// </Modified>
        public static List<long> TONGDAI_LayCacIDCuocGoiKetThucByDienThoai(string listIDCuocGoiHienTai, string vungsDuocCapPhep)
        {
            List<long> listID = new List<long>();
            using (DataTable dt = new Data.CuocGoi().TONGDAI_LayCacIDCuocGoiKetThucByDienThoai(listIDCuocGoiHienTai, vungsDuocCapPhep))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["ID"] != DBNull.Value)
                        {
                            listID.Add(Convert.ToInt64(dr["ID"].ToString()));
                        }
                    }
                }
            }
            return listID;
        }

        public static List<long> TONGDAI_LayCacIDCuocGoiKetThucByDienThoai_ChuaNhan(string listIDCuocGoiHienTai, string vungsDuocCapPhep)
        {
            List<long> listID = new List<long>();
            using (DataTable dt = new Data.CuocGoi().TONGDAI_LayCacIDCuocGoiKetThucByDienThoai_ChuaNhan(listIDCuocGoiHienTai, vungsDuocCapPhep))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["ID"] != DBNull.Value)
                        {
                            listID.Add(Convert.ToInt64(dr["ID"].ToString()));
                        }
                    }
                }
            }
            return listID;
        }

        public static bool TONGDAI_UpdateGhiChuTongDai(long idCuocGoi, string GhiChuTongDai)
        {
            return new Data.CuocGoi().TONGDAI_UpdateGhiChuTongDai(idCuocGoi, GhiChuTongDai);
        }

        /// <summary>
        /// Cập nhật tọa độ của danh sách xe nhận
        /// </summary>
        public static bool TONGDAI_UPDATE_XENHAN_TOADO(long idCuocGoi, string dsToaDoXeNhan)
        {
            return new Data.CuocGoi().TONGDAI_UPDATE_XENHAN_TOADO(idCuocGoi, dsToaDoXeNhan);

        }

        public static int TONGDAI_DemCuocGoiDonDuoc(DateTime tuNgay, DateTime denNgay, string maNhanVien)
        {
            return new Data.CuocGoi().TONGDAI_DemCuocGoiDonDuoc(tuNgay, denNgay, maNhanVien);
        }

        public static DataTable TONGDAI_LayThongTinXeDon_ID(long IDCuocGoi)
        {
            return new Data.CuocGoi().TONGDAI_LayThongTinXeDon_ID(IDCuocGoi);
        }

        /// <summary>
        /// Kiểm tra xem xe đã đón khách trong khoảng 5' gần đây ko.
        /// </summary>
        public string TONGDAI_UPDATE_XEDON_CHECKVALID(string pXeDon, DateTime pThoiDiemGoi, out string KenhVung_Trung)
        {
            string strXeDon = "";
            string[] arrXeDon = pXeDon.Split('.');
            string kenh ;
            KenhVung_Trung = "";
            if (arrXeDon.Length > 0)
            {
                for (int i = 0; i < arrXeDon.Length; i++)
                {
                    if (arrXeDon[i].Length > 3)
                    {
                        kenh = new Data.CuocGoi().TONGDAI_UPDATE_XEDON_CHECKVALID(arrXeDon[i], pThoiDiemGoi);
                        if (string.IsNullOrEmpty(kenh) || kenh == "0") continue;

                        KenhVung_Trung += kenh + " ; ";
                        strXeDon += arrXeDon[i] + ".";
                    }
                }
            }
            return strXeDon;
        }

        /// <summary>
        /// Cập nhật cuộc gọi đã giải quyết thành cuộc gọi chưa giải quyết
        /// </summary>
        public static bool TONGDAI_UpdateCGKetThuc2ChuaGiaiQuyet(long IDCuocGoi)
        {
            return new Data.CuocGoi().TONGDAI_UpdateCGKetThuc2ChuaGiaiQuyet(IDCuocGoi);
        }
        #endregion TongDai Module

        #region ================ DieuHanhChinh =============

        /// <summary>
        /// lay nhung cuoc moi 
        /// </summary>
        /// <Modified>        
        ///	Name		Date		    Comment 
        /// Côngnt      03/10           Create
        /// </Modified>
        public static List<CuocGoi> DIEUHANHCHINH_LayDSCuocGoiMoi(DateTime thoiDiemLayTruoc, string Vung)
        {
            List<CuocGoi> listCuocGoi = new List<CuocGoi>();
            List<CuocGoiDienThoaiLanDauType> listCuocGoiLanDau = new Data.CuocGoi().DIEUHANHCHINH_LayDSCuocGoiMoi(thoiDiemLayTruoc, Vung);
            if (listCuocGoiLanDau != null && listCuocGoiLanDau.Count > 0)
            {
                foreach (CuocGoiDienThoaiLanDauType objCuocLanDau in listCuocGoiLanDau)
                {
                    listCuocGoi.Add(new CuocGoi(objCuocLanDau.IDCuocGoi, objCuocLanDau.ThoiDiemGoi, objCuocLanDau.SoLanGoi, objCuocLanDau.Line, objCuocLanDau.PhoneNumber,
                                                 objCuocLanDau.DiaChiGoi, objCuocLanDau.DiaChiDonKhach, objCuocLanDau.Vung, objCuocLanDau.KieuKhachHangGoiDen, objCuocLanDau.LoaiXe, objCuocLanDau.LenhDienThoai, objCuocLanDau.GhiChuDienThoai));
                }
            }
            return listCuocGoi;
        }

        public static List<CuocGoi> DIEUHANHCHINH_LayAllCuocGoi_V3(string lineChoPhep)
        {
            List<CuocGoi> listCuocGoi = new List<CuocGoi>();
            using (DataTable dt = new Data.CuocGoi().DIEUHANHCHINH_LayAllCuocGoi_V3(lineChoPhep))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        listCuocGoi.Add(GetCuocGoiByDataRow(dr));
                    }
                }
            }
            return listCuocGoi;
        }

        public static List<CuocGoi> DIEUHANHCHINH_LayAllCuocGoi_KETTHUC_V3(int SoDongLayRa)
        {
            List<CuocGoi> listCuocGoi = new List<CuocGoi>();

            using (DataTable dt = new Data.DieuHanhTaxi().Get_CuocGoi_KetThucBySoDong(SoDongLayRa))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        listCuocGoi.Add(GetCuocGoiByDataRow(dr));
                    }
                }
            }
            return listCuocGoi;
        }

        public static List<CuocGoi> DIEUHANHCHINH_LayDSCuocGoiThayDoi_V3(string Vung, DateTime thoiDiemNhanDulieuTruoc)
        {
            List<CuocGoi> listCuocGoi = new List<CuocGoi>();
            DataTable dt = new Data.CuocGoi().DIEUHANHCHINH_LayDSCuocGoiThayDoi_V3(Vung, thoiDiemNhanDulieuTruoc);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow objCG in dt.Rows)
                {
                    listCuocGoi.Add(new CuocGoi(objCG["ID"] == DBNull.Value ? 0 : Convert.ToInt64(objCG["ID"].ToString()),
                                                objCG["TrangThaiCuocGoi"] == null ? TrangThaiCuocGoiTaxi.CuocGoiChuaXacDinh : (TrangThaiCuocGoiTaxi)int.Parse(objCG["TrangThaiCuocGoi"].ToString()),
                                                objCG["LenhTongDai"] == DBNull.Value ? string.Empty : objCG["LenhTongDai"].ToString(),
                                                objCG["GhiChuTongDai"] == DBNull.Value ? string.Empty : objCG["GhiChuTongDai"].ToString(),
                                                objCG["LenhDienThoai"] == DBNull.Value ? string.Empty : objCG["LenhDienThoai"].ToString(),
                                                objCG["GhiChuDienThoai"] == DBNull.Value ? string.Empty : objCG["GhiChuDienThoai"].ToString(),
                                                objCG["MaNhanVienTongDai"] == DBNull.Value ? string.Empty : objCG["MaNhanVienTongDai"].ToString(),
                                                objCG["MaNhanVienDienThoai"] == DBNull.Value ? string.Empty : objCG["MaNhanVienDienThoai"].ToString(),
                                                objCG["XeNhan"] == DBNull.Value ? string.Empty : objCG["XeNhan"].ToString(),
                                                objCG["ThoiGianDieuXe"] == DBNull.Value ? 0 : int.Parse(objCG["ThoiGianDieuXe"].ToString()),
                                                 objCG["FileVoicePath"] == DBNull.Value ? string.Empty : objCG["FileVoicePath"].ToString(),
                        //objCG["FK_VungID"] == DBNull.Value ? 0 : int.Parse(objCG["FK_VungID"].ToString()),
                                                 objCG["Vung"] == DBNull.Value ? 0 : int.Parse(objCG["Vung"].ToString()),
                                                 objCG["GPS_KinhDo"] == DBNull.Value ? 0 : double.Parse(objCG["GPS_KinhDo"].ToString()),
                                                 objCG["GPS_ViDo"] == DBNull.Value ? 0 : double.Parse(objCG["GPS_ViDo"].ToString()),
                                                 objCG["DanhSachXe_DeCu"] == DBNull.Value ? string.Empty : objCG["DanhSachXe_DeCu"].ToString(),
                                                 objCG["ThoiDiemCapNhatXeDeCu"] == DBNull.Value ? new DateTime(1900, 01, 01, 0, 0, 0) : DateTime.Parse(objCG["ThoiDiemCapNhatXeDeCu"].ToString()),
                                                 objCG["TrangThaiLenh"] == DBNull.Value ? TrangThaiLenhTaxi.KhongTruyenDi : (TrangThaiLenhTaxi)int.Parse(objCG["TrangThaiLenh"].ToString()),
                                                 objCG["MOIKHACH_LenhMoiKhach"] == DBNull.Value ? string.Empty : objCG["MOIKHACH_LenhMoiKhach"].ToString(),
                                                 objCG["XeDenDiem"] == DBNull.Value ? string.Empty : objCG["XeDenDiem"].ToString(),
                                                 objCG["XeDenDiemDonKhach"] == DBNull.Value ? string.Empty : objCG["XeDenDiemDonKhach"].ToString(),
                                                 objCG["DiaChiDonKhach"] == DBNull.Value ? string.Empty : objCG["DiaChiDonKhach"].ToString(),
                        //objCG["BANTINBANGIA_IsXuLy"] == DBNull.Value ? string.Empty : objCG["BANTINBANGIA_IsXuLy"].ToString()
                                                 objCG["MOIKHACH_NhanVien"] == DBNull.Value ? string.Empty : objCG["MOIKHACH_NhanVien"].ToString(),
                                                 objCG["XeDenDiemDonKhachDeCu"] == DBNull.Value ? string.Empty : objCG["XeDenDiemDonKhachDeCu"].ToString(),
                                                 objCG["XeDenDiemDonKhachDeCu_TD"] == DBNull.Value ? string.Empty : objCG["XeDenDiemDonKhachDeCu_TD"].ToString()
                                                 ));
                }
            }

            return listCuocGoi;
        }

        public static List<long> DIEUHANHCHINH_LayCacIDCuocGoiKetThuc_V3(string listIDCuocGoiHienTai, string Vung)
        {
            List<long> listID = new List<long>();
            using (DataTable dt = new Data.CuocGoi().DIEUHANHCHINH_LayCacIDCuocGoiKetThuc_V3(listIDCuocGoiHienTai, Vung))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["ID"] != DBNull.Value)
                        {
                            listID.Add(Convert.ToInt64(dr["ID"].ToString()));
                        }
                    }
                }
            }
            return listID;
        }

        public static bool DeleteCuocGoiChoGiaiQuyet(long IdCuocGoi)
        {
            return new Data.DieuHanhTaxi().DeleteCuocGoiChoGiaiQuyet(IdCuocGoi);
        }

        #endregion DieuHanhChinh

        #region ================ MoiKhach ==================

        /// <summary>
        /// Tra ve mot danh sach cac doi tuong 
        /// lay tat ca cac trong Cac cuoc goi chua ket thuc
        /// </summary>
        /// <returns></returns>
        /// ID, Line, PhoneNumber, ThoiDiemGoi, SoLuotDoChuong, DiaChiGoi, ThoiDiemKetThucGoi, DiaChiDonKhach, GoiTaxi, GoiLai, GoiKhieuNai, 
        ///       ThongTinKhac, LoaiXe, ChonTaxi4Cho, ChonTaxi7Cho, SanBay_DuongDai, Vung, LenhDienThoai, LenhTongDai, MaNhanVienDienThoai, 
        //       MaNhanVienTongDai, XeNhan, XeDon, DiaChiTraKhach, GhiChu, TrangThaiLenh
        public List<CuocGoi> GetAllOf_DienThoai(string SQLCondition)
        {
            List<CuocGoi> lstCuocGoi = new List<CuocGoi>();
            try
            {
                DataTable dt = new Data.DieuHanhTaxi().GetAll_DienThoai(SQLCondition);
                if (dt != null)
                {
                    if (dt.Rows.Count <= 0) return null;
                    else
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            lstCuocGoi.Add(GetDieuHanhTaxi(dr));
                        }

                    }
                }
                return lstCuocGoi;
            }
            catch 
            {
                return null;
            }
        }

        private CuocGoi GetDieuHanhTaxi(DataRow drTaxiOpe)
        {
            CuocGoi objDHTaxi = new CuocGoi();
            objDHTaxi.IDCuocGoi = long.Parse(drTaxiOpe["ID"].ToString());
            objDHTaxi.Line = int.Parse(drTaxiOpe["Line"].ToString());
            objDHTaxi.PhoneNumber = drTaxiOpe["PhoneNumber"].ToString();
            objDHTaxi.ThoiDiemGoi = (DateTime)drTaxiOpe["ThoiDiemGoi"];
            objDHTaxi.TongThoiGianDamThoai = (DateTime)drTaxiOpe["Duration"];// ko dung
            objDHTaxi.FileVoicePath = drTaxiOpe["FileVoicePath"].ToString();
            objDHTaxi.ThoiDiemGoiGio = string.Format("{0:yyyy-MM-dd HH:mm:ss}", objDHTaxi.ThoiDiemGoi).Substring(11, 8);
            objDHTaxi.ThoiDiemGoiNgay = string.Format("{0:yyyy-MM-dd HH:mm:ss}", objDHTaxi.ThoiDiemGoi).Substring(0, 10);
            try
            {
                objDHTaxi.TrangThaiCuocGoi = (TrangThaiCuocGoiTaxi) byte.Parse(drTaxiOpe["TrangThaiCuocGoi"].ToString());
            }
            catch
            {
                objDHTaxi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.TrangThaiKhac;
            }
            try
            {
                objDHTaxi.KieuCuocGoi = (KieuCuocGoi)byte.Parse(drTaxiOpe["KieuCuocGoi"].ToString());
            }
            catch { objDHTaxi.KieuCuocGoi = KieuCuocGoi.GoiTaxi; }

            if (StringTools.TrimSpace(drTaxiOpe["ThoiDiemChuyenTongDai"].ToString()).Length > 0)
            {
                objDHTaxi.ThoiDiemChuyenTongDai = int.Parse(drTaxiOpe["ThoiDiemChuyenTongDai"].ToString());
            }
            else
                objDHTaxi.ThoiDiemChuyenTongDai = 0;

            if (StringTools.TrimSpace(drTaxiOpe["SoLuotDoChuong"].ToString()).Length > 0)
                objDHTaxi.SoLuotDoChuong = int.Parse(drTaxiOpe["SoLuotDoChuong"].ToString());
            objDHTaxi.DiaChiDonKhach = drTaxiOpe["DiaChiDonKhach"].ToString();
            objDHTaxi.KieuKhachHangGoiDen = (KieuKhachHangGoiDen)int.Parse(drTaxiOpe["KieuKhachHangGoiDen"].ToString());
            objDHTaxi.GoiTaxi = drTaxiOpe["GoiTaxi"].ToString() == "1";
            objDHTaxi.GoiLai = drTaxiOpe["GoiLai"].ToString() == "1";
            // goi khieu nai
            if (drTaxiOpe["GoiKhieuNai"] == null) objDHTaxi.GoiKhieuNai = false;
            else objDHTaxi.GoiKhieuNai = drTaxiOpe["GoiKhieuNai"].ToString() == "1";

            objDHTaxi.ThongTinKhac = drTaxiOpe["ThongTinKhac"].ToString() == "1";//GoiKhac
            objDHTaxi.LoaiXe = drTaxiOpe["LoaiXe"].ToString();
            if (StringTools.TrimSpace(drTaxiOpe["SoLuong"].ToString()).Length > 0)
                objDHTaxi.SoLuong = int.Parse(drTaxiOpe["SoLuong"].ToString());
            else objDHTaxi.SoLuong = 0;

            if (StringTools.TrimSpace(drTaxiOpe["Vung"].ToString()).Length > 0)
                objDHTaxi.Vung = int.Parse(drTaxiOpe["Vung"].ToString());
            else objDHTaxi.Vung = 0;
            objDHTaxi.LenhDienThoai = drTaxiOpe["LenhDienThoai"].ToString();
            objDHTaxi.LenhTongDai = drTaxiOpe["LenhTongDai"].ToString();
            objDHTaxi.MaNhanVienDienThoai = drTaxiOpe["MaNhanVienDienThoai"].ToString();
            objDHTaxi.MaNhanVienTongDai = drTaxiOpe["MaNhanVienTongDai"].ToString();
            objDHTaxi.XeNhan = drTaxiOpe["XeNhan"].ToString();
            objDHTaxi.XeDenDiem = drTaxiOpe["XeDenDiem"].ToString();
            objDHTaxi.XeDenDiemDonKhach = drTaxiOpe["XeDenDiemDonKhach"].ToString();
            objDHTaxi.XeDon = drTaxiOpe["XeDon"].ToString();
            objDHTaxi.XeNhan_TD = drTaxiOpe["XeNhan_TD"].ToString();
            objDHTaxi.GPS_KinhDo = drTaxiOpe["GPS_KinhDo"] == DBNull.Value ? 1 : double.Parse(drTaxiOpe["GPS_KinhDo"].ToString());
            objDHTaxi.GPS_ViDo = drTaxiOpe["GPS_ViDo"] == DBNull.Value ? 1 : double.Parse(drTaxiOpe["GPS_ViDo"].ToString());
            objDHTaxi.DanhSachXeDeCu = drTaxiOpe["DanhSachXe_DeCu"].ToString();
            objDHTaxi.DanhSachXeDeCu_TD = drTaxiOpe["DanhSachXe_DeCu_TD"].ToString();
            objDHTaxi.DiaChiTraKhach = drTaxiOpe["DiaChiTraKhach"].ToString();
            objDHTaxi.GhiChuDienThoai = drTaxiOpe["GhiChuDienThoai"].ToString();
            objDHTaxi.GhiChuTongDai = drTaxiOpe["GhiChuTongDai"].ToString();
            if (StringTools.TrimSpace(drTaxiOpe["TrangThaiLenh"].ToString()).Length > 0)
                objDHTaxi.TrangThaiLenh = (TrangThaiLenhTaxi)int.Parse(drTaxiOpe["TrangThaiLenh"].ToString());
            else objDHTaxi.TrangThaiLenh = TrangThaiLenhTaxi.KhongTruyenDi;

            //objDHTaxi.CuocGoiLaiIDs = StringTools.TrimSpace(drTaxiOpe["CuocGoiLaiIDs"].ToString());
            //if (objDHTaxi.CuocGoiLaiIDs.Contains(";"))
            //    objDHTaxi.ThongTinGoiLai = GetThongTinGoiLai(objDHTaxi.CuocGoiLaiIDs); ;
            if (drTaxiOpe["ThoiGianDieuXe"].ToString().Length > 0)
                objDHTaxi.ThoiGianDieuXe = int.Parse(drTaxiOpe["ThoiGianDieuXe"].ToString());
            if (drTaxiOpe["ThoiGianDonKhach"].ToString().Length > 0)
                objDHTaxi.ThoiGianDonKhach = int.Parse(drTaxiOpe["ThoiGianDonKhach"].ToString());

            // THONG TIN CAM ON CUOC GOI
            //[CAMON_DaCamOn],[CAMON_ThoiDiemCamOn],[CAMON_DanhGia],[CAMON_YKien],[CAMON_NhanVien],[CAMON_ThoiDiemSuaCuoi],[CAMON_NhanVienSua]
            objDHTaxi.CamOn_DaCamOn = drTaxiOpe["CAMON_DaCamOn"].ToString() == "True";
            if (drTaxiOpe["CAMON_ThoiDiemCamOn"] == null || drTaxiOpe["CAMON_ThoiDiemCamOn"].ToString().Length <= 0)
                objDHTaxi.CamOn_ThoiDiemChen = DateTime.MinValue;
            else objDHTaxi.CamOn_ThoiDiemChen = DateTime.Parse(drTaxiOpe["CAMON_ThoiDiemCamOn"].ToString());

            if (drTaxiOpe["CAMON_DanhGia"] == null || drTaxiOpe["CAMON_DanhGia"].ToString().Length <= 0) objDHTaxi.CamOn_DanhGia = KieuKhachDanhGiaCAMON.ChuaDanhGia;
            else objDHTaxi.CamOn_DanhGia = ((KieuKhachDanhGiaCAMON)int.Parse(drTaxiOpe["CAMON_DanhGia"].ToString()));

            if (drTaxiOpe["CAMON_YKien"] == null) objDHTaxi.CamOn_YKien = "";
            else objDHTaxi.CamOn_YKien = drTaxiOpe["CAMON_YKien"].ToString();

            if (drTaxiOpe["CAMON_NhanVien"] == null) objDHTaxi.CamOn_NhanVien = "";
            else objDHTaxi.CamOn_NhanVien = drTaxiOpe["CAMON_NhanVien"].ToString();

            if (drTaxiOpe["CAMON_ThoiDiemSuaCuoi"] == null || drTaxiOpe["CAMON_ThoiDiemSuaCuoi"].ToString().Length <= 0) objDHTaxi.CamOn_ThoiDiemSuaCuoi = DateTime.MinValue;
            else objDHTaxi.CamOn_ThoiDiemSuaCuoi = DateTime.Parse(drTaxiOpe["CAMON_ThoiDiemSuaCuoi"].ToString());
            // ---------------------------

            // THONG TIN MOI KHACH
            if (drTaxiOpe["MOIKHACH_LenhMoiKhach"] == null) objDHTaxi.MOIKHACH_LenhMoiKhach = "";
            else objDHTaxi.MOIKHACH_LenhMoiKhach = drTaxiOpe["MOIKHACH_LenhMoiKhach"].ToString();

            if (drTaxiOpe["MOIKHACH_ThoiDiemMoi_Giu"] == null) objDHTaxi.MOIKHACH_ThoiDiemMoi_Giu = DateTime.MinValue;
            else if (drTaxiOpe["MOIKHACH_ThoiDiemMoi_Giu"].ToString().Length > 10)
                objDHTaxi.MOIKHACH_ThoiDiemMoi_Giu = Convert.ToDateTime(drTaxiOpe["MOIKHACH_ThoiDiemMoi_Giu"].ToString());

            if (drTaxiOpe["MOIKHACH_XinLoi_DaXinLoi"] != null && drTaxiOpe["MOIKHACH_XinLoi_DaXinLoi"].ToString().Length > 0) objDHTaxi.MOIKHACH_XinLoi_DaXinLoi = Convert.ToBoolean(drTaxiOpe["MOIKHACH_XinLoi_DaXinLoi"].ToString());
            else objDHTaxi.MOIKHACH_XinLoi_DaXinLoi = false;
            if (drTaxiOpe["MOIKHACH_XinLoi_ThoiDiem"] == null) objDHTaxi.MOIKHACH_XinLoi_ThoiDiem = DateTime.MinValue;
            else if (drTaxiOpe["MOIKHACH_XinLoi_ThoiDiem"].ToString().Length > 10)
                objDHTaxi.MOIKHACH_XinLoi_ThoiDiem = Convert.ToDateTime(drTaxiOpe["MOIKHACH_XinLoi_ThoiDiem"].ToString());

            if (drTaxiOpe["MOIKHACH_KhieuNai_DaXyLy"] != null && drTaxiOpe["MOIKHACH_KhieuNai_DaXyLy"].ToString().Length > 0)
                objDHTaxi.MOIKHACH_KhieuNai_DaXyLy = Convert.ToBoolean(drTaxiOpe["MOIKHACH_KhieuNai_DaXyLy"].ToString());
            else objDHTaxi.MOIKHACH_KhieuNai_DaXyLy = false;


            if (drTaxiOpe["MOIKHACH_KhieuNai_ThongTinThem"] == null) objDHTaxi.MOIKHACH_KhieuNai_ThongTinThem = "";
            else objDHTaxi.MOIKHACH_KhieuNai_ThongTinThem = drTaxiOpe["MOIKHACH_KhieuNai_ThongTinThem"].ToString();

            if (drTaxiOpe["MOIKHACH_NhanVien"] == null) objDHTaxi.MOIKHACH_NhanVien = "";
            else objDHTaxi.MOIKHACH_NhanVien = drTaxiOpe["MOIKHACH_NhanVien"].ToString();

            // ---------------------------

            // ----  BAN TIN BAN GIA -----
            if (drTaxiOpe["BANTINBANGIA_NoiDungXuLy"] == null) objDHTaxi.BTBG_NoiDungXuLy = "";
            else objDHTaxi.BTBG_NoiDungXuLy = drTaxiOpe["BANTINBANGIA_NoiDungXuLy"].ToString();

            if (drTaxiOpe["BANTINBANGIA_NhanVien"] == null) objDHTaxi.BTBG_NhanVien = "";
            else objDHTaxi.BTBG_NhanVien = drTaxiOpe["BANTINBANGIA_NhanVien"].ToString();

            if (drTaxiOpe["BANTINBANGIA_IsXuLy"] == null) objDHTaxi.BTBG_IsDaXuLy = false;
            else
            {
                try
                {
                    objDHTaxi.BTBG_IsDaXuLy = Convert.ToBoolean(drTaxiOpe["BANTINBANGIA_IsXuLy"].ToString());
                }
                catch
                {
                    objDHTaxi.BTBG_IsDaXuLy = false;
                }
            }
            if (drTaxiOpe["BANTINBANGIA_ThoiDiemXuLy"] == null) objDHTaxi.BTBG_ThoiDiemXuLy = DateTime.MinValue;
            else
            {
                try
                {
                    objDHTaxi.BTBG_ThoiDiemXuLy = Convert.ToDateTime(drTaxiOpe["BANTINBANGIA_ThoiDiemXuLy"].ToString());
                }
                catch
                {
                    objDHTaxi.BTBG_ThoiDiemXuLy = DateTime.MinValue;
                }
            }
            //----------------------------
            return objDHTaxi;
        }

        /// <summary>
        /// Cập nhật thời điểm mời khách
        /// </summary>
        public static bool Update_ThoiDiemMoiKhach(long IDDieuHanh, string NhanVienMoiID)
        {
            return new Data.DieuHanhTaxi().Update_ThoiDiemMoiKhach(IDDieuHanh, NhanVienMoiID);
        }

        public static bool UpdateCSPhanBoCuocGoi(string strSQL)
        {
            return new Data.CuocGoi().UpdateCSPhanBoCuocGoi(strSQL);
        }

        public bool Update_MOIKHACH_KhieuNai()
        {
            return new Data.CuocGoi().Update_MOIKHACH(this.IDCuocGoi, this.DiaChiDonKhach, MOIKHACH_LenhMoiKhach, false, MOIKHACH_KhieuNai_DaXyLy, MOIKHACH_KhieuNai_ThongTinThem, MOIKHACH_NhanVien);
        }

        /// <summary>
        /// Update trang thai lenh khi ket thuc
        /// </summary>
        public bool Update_KetThucCuocGoi(long IDDieuHanh, TrangThaiLenhTaxi pTrangThaiLenh)
        {
            return new Data.CuocGoi().Update_KetThucCuocGoi(IDDieuHanh, pTrangThaiLenh);
        }

        //Lấy các cuộc gọi như tổng đài
        public bool Update_MOIKHACH_MoiKhachGiu()
        {
            return new Data.CuocGoi().Update_MOIKHACH(this.IDCuocGoi, this.DiaChiDonKhach, MOIKHACH_LenhMoiKhach, false, false, "", this.MOIKHACH_NhanVien);
        }

        public bool Update_MOIKHACH_KhongXeXinLoi()
        {
            return new Data.CuocGoi().Update_MOIKHACH(this.IDCuocGoi, this.DiaChiDonKhach, MOIKHACH_LenhMoiKhach, MOIKHACH_XinLoi_DaXinLoi, false, "", this.MOIKHACH_NhanVien);
        }

        /// <summary>
        /// Cuộc gọi không xác định xe đón
        /// </summary>
        /// <param name="IDCuocGoi"></param>
        /// <returns></returns>
        public static bool UpdateCuocKhachKetThucKhongXacDinhXeDon(long IDCuocGoi)
        {
            return new Data.CuocGoi().UpdateCuocKhachKetThucKhongXacDinhXeDon(IDCuocGoi);
        }

        /// <summary>
        /// hamf kiem tra xe da dang nhan diem chua
        ///   true : dang nhan diem
        ///   false la dang khong nhan diem nao
        /// </summary>
        public static bool KiemTraXeNhanDaDangNhanCuocKhach(long ID, string SoHieuXe)
        {
            return new Data.CuocGoi().KiemTraXeNhanDaDangNhanCuocKhach(ID, SoHieuXe);
        }

        /// <summary>
        /// MOIKHACH - cập nhật thông tin đã kết thúc 
        /// </summary>
        public static bool MOIKHACH_UpdateThongTinCuocGoiKetThuc(long idCuocGoi, string xeDon, bool truot, string ghiChu, string nhanVien)
        {
            return new Data.CuocGoi().MOIKHACH_UpdateThongTinCuocGoiKetThuc(idCuocGoi, xeDon, truot, ghiChu, nhanVien);
        }


        #region ---V3---
        public static List<CuocGoi> MK_LayCuocGoiMoiTuDTV_TDV(string vungsDuocCapPhep, DateTime thoiDiemLayDuLieuTruoc, int MayCS)
        {
            List<CuocGoi> listCuocGoi = new List<CuocGoi>();
            List<CuocGoiEntity> listCuocGoiEntity = new Data.CuocGoi().MK_LayCuocGoiMoiTuDTV_TDV(vungsDuocCapPhep, thoiDiemLayDuLieuTruoc, MayCS);
            if (listCuocGoiEntity != null && listCuocGoiEntity.Count > 0)
            {
                foreach (CuocGoiEntity objCG in listCuocGoiEntity)
                {//TinNhan (update)
                    listCuocGoi.Add(new CuocGoi(objCG.IDCuocGoi, objCG.ThoiDiemGoi, objCG.Line, objCG.PhoneNumber, objCG.SoLanGoi, objCG.DiaChiDonKhach, objCG.Vung, objCG.LoaiXe, objCG.SoLuongXe, objCG.LoaiKhachHang,
                                                 objCG.IsCuocGiaLap, objCG.KieuCuocGoi, objCG.LenhDienThoai, objCG.GhiChuDienThoai, objCG.LenhTongDai, objCG.GhiChuTongDai, objCG.TrangThaiLenh,
                                                 objCG.MaNhanVienDienThoai, objCG.MaNhanVienTongDai, objCG.ThoiGianChuyenTongDai, objCG.DanhSachXeDeCu, objCG.ThoiDiemCapNhatXeDeCu, objCG.DanhSachXeDeCu_TD, objCG.GPS_KinhDo, objCG.GPS_ViDo,
                                                 objCG.XeNhan, objCG.XeNhan_TD, objCG.MOIKHACH_LenhMoiKhach, objCG.MOIKHACH_NhanVien, objCG.XeDenDiem, objCG.XeDenDiemDonKhach, objCG.XeDenDiemDonKhach_TD, objCG.TrangThaiCuocGoi));

                }
            }
            return listCuocGoi;
        }


        public static List<long> MK_LayCacIDCuocGoiKetThucByDTV_TDV(string listIDCuocGoiHienTai, string vungsDuocCapPhep, int MayCS)
        {
            List<long> listID = new List<long>();
            using (DataTable dt = new Data.CuocGoi().MK_LayCacIDCuocGoiKetThucByDTV_TDV(listIDCuocGoiHienTai, vungsDuocCapPhep, MayCS))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["ID"] != DBNull.Value)
                        {
                            listID.Add(Convert.ToInt64(dr["ID"].ToString()));
                        }
                    }
                }
            }
            return listID;
        }

        public static bool MK_UpdateThongTinCuocGoi(CuocGoi cuocGoi)
        {
            return new Data.CuocGoi().MK_UpdateThongTinCuocGoi(cuocGoi.IDCuocGoi, cuocGoi.TrangThaiCuocGoi, cuocGoi.MOIKHACH_LenhMoiKhach, cuocGoi.TrangThaiLenh,
                                                                cuocGoi.MOIKHACH_NhanVien, cuocGoi.XeDon);
        }

        public static bool MK_UpdateThongTinCuocGoi_V4(CuocGoi cuocGoi)
        {
            return new Data.CuocGoi().MK_UpdateThongTinCuocGoi_V4(cuocGoi.IDCuocGoi, cuocGoi.TrangThaiCuocGoi, cuocGoi.MOIKHACH_LenhMoiKhach, cuocGoi.TrangThaiLenh,
                                                                cuocGoi.MOIKHACH_NhanVien, cuocGoi.XeDon, cuocGoi.DiaChiDonKhach);
        }

        public static List<CuocGoi> MK_LayCuocGoiDaGiaiQuyet(string vungsDuocCapPhep, int soDong, int MayCS)
        {
            List<CuocGoi> listCuocGoi = new List<CuocGoi>();
            using (DataTable dt = new Data.CuocGoi().MK_LayCuocGoiDaGiaiQuyet(vungsDuocCapPhep, soDong, MayCS))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        listCuocGoi.Add(GetCuocGoiByDataRow(dr));
                    }
                }
            }
            return listCuocGoi;
        }

        public static List<CuocGoi> MK_LayAllCuocGoi(string vungsDuocCapPhep, int MayCS)
        {
            //LogError.WriteLogInfo(vungsDuocCapPhep+"-"+MayCS);
            List<CuocGoi> listCuocGoi = new List<CuocGoi>();
            using (DataTable dt = new Data.CuocGoi().MK_LayAllCuocGoi(vungsDuocCapPhep, MayCS))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        listCuocGoi.Add(GetCuocGoiByDataRow(dr));
                    }
                }
            }
            //LogError.WriteLogInfo(listCuocGoi.Count.ToString());
            return listCuocGoi;
        }

        #endregion
        #endregion

        #region ================ ManHinh Điều xe ===========

        /// <summary>
        /// hàm trả về giá trị true khi điều kiện là 
        ///   - Chưa từng gửi tới xe một lần nào
        ///   - Thời gian gửi lần trước và thời gian của server đủ điều kiện không có spam
        /// </summary>
        /// <param name="timeServer"></param>
        /// <returns></returns>
        public bool ManHinh_DuDieuKienGuiToiXe(DateTime timeServer)
        {
            //   if this.ManHinh_ThoiDiemGuiXe is null OR this.ManHinh_ThoiDiemGuiXe = MinDate  (chua gui lan nao)
            //          return true
            //   else
            //      timeSpan = timeServer - this.ManHinh_ThoiDiemGuiXe
            //      if timeSpan.TotalSeconds > SoGiayGioiHan 
            //               return true
            return true;
        }
        /// <summary>
        /// thực hiện cập nhật thông tin ghi nhận gửi tới màn hình
        /// </summary>
        public static bool TONGDAI_UpdateThongTinGuiToiXe(long idCuocGoi)
        {
            return new Data.CuocGoi().TONGDAI_UpdateThongTinGuiToiXe(idCuocGoi);
        }

        #endregion

        #region ================ FastTaxi ==================

        #region Điện thoại
        public static List<CuocGoi> DIENTHOAI_LayDSCuocGoiMoi_FT(string lineChoPhep, DateTime thoiDiemLayTruoc)
        {

            var listCuocGoi = new List<CuocGoi>();
            using (var dt = new Data.CuocGoi().DIENTHOAI_LayDSCuocGoiMoi_FT(lineChoPhep, thoiDiemLayTruoc))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    listCuocGoi.AddRange(from DataRow dr in dt.Rows select GetCuocGoiByDataRow(dr));
                }
            }
            return listCuocGoi;
        }
        public static List<CuocGoi> DIENTHOAI_LayDSCuocGoiMoi_FTNotFT(string lineChoPhep, DateTime thoiDiemLayTruoc)
        {
            var listCuocGoi = new List<CuocGoi>();
            using (var dt = new Data.CuocGoi().DIENTHOAI_LayDSCuocGoiMoi_FTNotFT(lineChoPhep, thoiDiemLayTruoc))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    listCuocGoi.AddRange(from DataRow dr in dt.Rows select GetCuocGoiByDataRow(dr));
                }
            }
            return listCuocGoi;
        }
        public static bool FT_DIENTHOAI_UpdateThongTinCuocGoi(CuocGoi cuocGoi)
        {
            return new Data.CuocGoi().FT_DIENTHOAI_UpdateThongTinCuocGoi(cuocGoi.IDCuocGoi, cuocGoi.DiaChiDonKhach, cuocGoi.DiaChiTraKhach, cuocGoi.PhoneNumber, cuocGoi.Vung, cuocGoi.LoaiXe, cuocGoi.SoLuong, cuocGoi.TrangThaiCuocGoi,
                                                                      cuocGoi.KieuCuocGoi, cuocGoi.LenhDienThoai, cuocGoi.TrangThaiLenh, cuocGoi.GhiChuDienThoai, cuocGoi.MaNhanVienDienThoai,
                                                                      cuocGoi.ThoiDiemChuyenTongDai, cuocGoi.GPS_KinhDo, cuocGoi.GPS_ViDo, cuocGoi.DanhSachXeDeCu, cuocGoi.DanhSachXeDeCu_TD, cuocGoi.xeDon, cuocGoi.KieuKhachHangGoiDen, cuocGoi.LoaiCuocKhach, cuocGoi.FT_IsFT, cuocGoi.FT_Date, cuocGoi.FT_SendDate, cuocGoi.FT_Status);
        }
        public static bool FT_DIENTHOAI_UpdateThongTinCuocGoiV2(CuocGoi cuocGoi)
        {
            return new Data.CuocGoi().FT_DIENTHOAI_UpdateThongTinCuocGoiV2(cuocGoi.IDCuocGoi, cuocGoi.DiaChiDonKhach, cuocGoi.DiaChiTraKhach, cuocGoi.PhoneNumber, cuocGoi.Vung, cuocGoi.LoaiXe, cuocGoi.SoLuong, cuocGoi.TrangThaiCuocGoi,
                                                                      cuocGoi.KieuCuocGoi, cuocGoi.LenhDienThoai, cuocGoi.TrangThaiLenh, cuocGoi.GhiChuDienThoai, cuocGoi.MaNhanVienDienThoai,
                                                                      cuocGoi.ThoiDiemChuyenTongDai, cuocGoi.GPS_KinhDo, cuocGoi.GPS_ViDo, cuocGoi.DanhSachXeDeCu, cuocGoi.DanhSachXeDeCu_TD, cuocGoi.xeDon, cuocGoi.KieuKhachHangGoiDen, cuocGoi.LoaiCuocKhach, cuocGoi.FT_IsFT, cuocGoi.FT_Date, cuocGoi.FT_SendDate
                                                                      , cuocGoi.FT_Status, cuocGoi.IsHeThong);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cuocGoi"></param>
        /// <returns></returns>
        public static bool FT_DIENTHOAI_UpdateThongTinCuocGoi_Mini(CuocGoi cuocGoi)
        {
            return new Data.CuocGoi().FT_DIENTHOAI_UpdateThongTinCuocGoi_Mini(cuocGoi.IDCuocGoi, cuocGoi.DiaChiDonKhach, cuocGoi.DiaChiTraKhach, cuocGoi.PhoneNumber, cuocGoi.Vung, cuocGoi.LoaiXe, cuocGoi.SoLuong, cuocGoi.TrangThaiCuocGoi,
                                                                      cuocGoi.KieuCuocGoi, cuocGoi.LenhDienThoai, cuocGoi.TrangThaiLenh, cuocGoi.GhiChuDienThoai, cuocGoi.MaNhanVienDienThoai,
                                                                      cuocGoi.ThoiDiemChuyenTongDai, cuocGoi.GPS_KinhDo, cuocGoi.GPS_ViDo, cuocGoi.DanhSachXeDeCu, cuocGoi.DanhSachXeDeCu_TD, cuocGoi.xeDon, cuocGoi.KieuKhachHangGoiDen, cuocGoi.xeNhan, cuocGoi.XeDenDiem, cuocGoi.LoaiCuocKhach, cuocGoi.FT_IsFT, cuocGoi.FT_Date, cuocGoi.FT_SendDate, cuocGoi.FT_Status);
        }
        public static bool FT_ReturnSendByID(long id, bool flg)
        {
            return new Data.CuocGoi().FT_ReturnSendByID(id, flg);
        }
        public static List<CuocGoi> FT_DIENTHOAI_LayAllCuocGoi_Khac(string lineChoPhep)
        {
            var listCuocGoi = new List<CuocGoi>();
            using (var dt = new Data.CuocGoi().FT_DIENTHOAI_LayAllCuocGoi_Khac(lineChoPhep))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    listCuocGoi.AddRange(from DataRow dr in dt.Rows select GetCuocGoiByDataRow(dr));
                }
            }
            return listCuocGoi;
        }

        public static List<CuocGoi> FT_DIENTHOAI_LayAllCuocGoi(string linechophep)
        {

            var listCuocGoi = new List<CuocGoi>();
            using (var dt = new Data.CuocGoi().FT_DIENTHOAI_LayAllCuocGoi(linechophep))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    listCuocGoi.AddRange(from DataRow dr in dt.Rows select GetCuocGoiByDataRow(dr));
                }
            }
            return listCuocGoi;
        }
        public static List<CuocGoi> FT_DIENTHOAI_LayAllCuocGoiNotFT(string linechophep)
        {

            var listCuocGoi = new List<CuocGoi>();
            using (var dt = new Data.CuocGoi().FT_DIENTHOAI_LayAllCuocGoiNotFT(linechophep))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    listCuocGoi.AddRange(from DataRow dr in dt.Rows select GetCuocGoiByDataRow(dr));
                }
            }
            return listCuocGoi;
        }
        public string GetLenhDienThoaiCurrent()
        {
            return new Data.CuocGoi().GetLenhDienThoaiCurrent(this.id);
        }
        /// <summary>
        /// Hàm cập nhật thông tin staxi chỉ sử dụng cập nhật tự động.
        /// Vùng,DanhSachXeDeCu,DanhSachXeDeCu_TD,KieuCuocGoi,SoLuong,FT_KM
        /// </summary>
        /// <param name="cuocGoi"></param>
        /// <returns></returns>
        public static bool DIENTHOAI_UpdateThongTinCuocSTaxi(CuocGoi cuocGoi)
        {
            return new Data.CuocGoi().DIENTHOAI_UpdateThongTinCuocSTaxi(cuocGoi.IDCuocGoi, cuocGoi.Vung, cuocGoi.DanhSachXeDeCu, cuocGoi.DanhSachXeDeCu_TD, (int)cuocGoi.KieuCuocGoi, cuocGoi.SoLuong, cuocGoi.FT_KM);
        }
        public static DataTable DienThoai_LayLichSuTheoSoDienThoai(string SoDienThoai, DateTime ThoiDiemGoi, int SoDong)
        {
            return new Data.CuocGoi().DienThoai_LayLichSuTheoSoDienThoai(SoDienThoai, ThoiDiemGoi, SoDong);
        }
        public static List<CuocGoi> DienThoai_LayLichSuTheoSoDienThoaiV2(string SoDienThoai, DateTime ThoiDiemGoi, int SoDong)
        {
            return new Data.CuocGoi().DienThoai_LayLichSuTheoSoDienThoai(SoDienThoai, ThoiDiemGoi, SoDong).Select().Select(p => GetCuocGoiByDataRow(p)).ToList();
        }
        #endregion

        #region Tổng đài
        /// <summary>
        /// Hàm trả về ds cuộc gọi của tổng đài với vungsDuocCapPhep của fastTaxi
        /// </summary>
        public static List<CuocGoi> FT_TONGDAI_LayAllCuocGoi(string vungsDuocCapPhep, ref List<CuocGoi> lstCuocGoi_ChuaNhan)
        {
            var listCuocGoi = new List<CuocGoi>();
            var ds = new Data.CuocGoi().FT_TONGDAI_LayAllCuocGoi(vungsDuocCapPhep);
            if (ds.Tables.Count > 0)
            {
                using (var dtCuocGoiDaNhan = ds.Tables[0])
                {
                    if (dtCuocGoiDaNhan != null && dtCuocGoiDaNhan.Rows.Count > 0)
                    {
                        listCuocGoi.AddRange(from DataRow dr in dtCuocGoiDaNhan.Rows select GetCuocGoiByDataRow(dr));
                    }
                }
                if (Global.GridConfig_CuocGoi == Grid_Config.Has_Grid_Bottom)
                {
                    using (var dtCuocGoiChuaNhan = ds.Tables[1])
                    {
                        if (dtCuocGoiChuaNhan != null && dtCuocGoiChuaNhan.Rows.Count > 0)
                        {
                            lstCuocGoi_ChuaNhan.AddRange(from DataRow dr in dtCuocGoiChuaNhan.Rows select GetCuocGoiByDataRow(dr));
                        }
                    }
                }
            }
            return listCuocGoi;
        }
        public static List<CuocGoi> FT_TONGDAI_LayAllCuocGoiNotFT(string vungsDuocCapPhep, ref List<CuocGoi> lstCuocGoi_ChuaNhan)
        {
            var listCuocGoi = new List<CuocGoi>();
            var ds = new Data.CuocGoi().FT_TONGDAI_LayAllCuocGoiNotFT(vungsDuocCapPhep);
            if (ds.Tables.Count > 0)
            {
                using (var dtCuocGoiDaNhan = ds.Tables[0])
                {
                    if (dtCuocGoiDaNhan != null && dtCuocGoiDaNhan.Rows.Count > 0)
                    {
                        listCuocGoi.AddRange(from DataRow dr in dtCuocGoiDaNhan.Rows select GetCuocGoiByDataRow(dr));
                    }
                }
                if (Global.GridConfig_CuocGoi == Grid_Config.Has_Grid_Bottom)
                {
                    using (var dtCuocGoiChuaNhan = ds.Tables[1])
                    {
                        if (dtCuocGoiChuaNhan != null && dtCuocGoiChuaNhan.Rows.Count > 0)
                        {
                            lstCuocGoi_ChuaNhan.AddRange(from DataRow dr in dtCuocGoiChuaNhan.Rows select GetCuocGoiByDataRow(dr));
                        }
                    }
                }
            }
            return listCuocGoi;
        }
        public static List<CuocGoi> FT_TONGDAI_LayCuocGoiDaGiaiQuyet(string vungsDuocCapPhep, int soDong)
        {
            var listCuocGoi = new List<CuocGoi>();
            using (DataTable dt = new Data.CuocGoi().FT_TONGDAI_LayCuocGoiDaGiaiQuyet(vungsDuocCapPhep, soDong))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    listCuocGoi.AddRange(from DataRow dr in dt.Rows select GetCuocGoiByDataRow(dr));
                }
            }
            return listCuocGoi;
        }
        public static List<CuocGoi> FT_TONGDAI_LayCuocGoiDaGiaiQuyetNotFT(string vungsDuocCapPhep, int soDong)
        {
            var listCuocGoi = new List<CuocGoi>();
            using (DataTable dt = new Data.CuocGoi().FT_TONGDAI_LayCuocGoiDaGiaiQuyetNotFT(vungsDuocCapPhep, soDong))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    listCuocGoi.AddRange(from DataRow dr in dt.Rows select GetCuocGoiByDataRow(dr));
                }
            }
            return listCuocGoi;
        }
        public static List<CuocGoi> FT_TONGDAI_LayCuocGoiDaNhanXuLy(string vungsDuocCapPhep, DateTime thoiDiemLayDuLieuTruoc)
        {
            List<CuocGoi> listCuocGoi = new List<CuocGoi>();
            using (var dt = new Data.CuocGoi().FT_TONGDAI_LayCuocGoiDaNhanXuLy(vungsDuocCapPhep, thoiDiemLayDuLieuTruoc))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    listCuocGoi.AddRange(from DataRow dr in dt.Rows select GetCuocGoiByDataRow(dr));
                }
            }
            return listCuocGoi;
        }
        /// <summary>
        /// Lấy các cuốc đã nhận xử lý không phải là FT
        /// </summary>
        public static List<CuocGoi> FT_TONGDAI_LayCuocGoiDaNhanXuLyNotFT(string vungsDuocCapPhep, DateTime thoiDiemLayDuLieuTruoc)
        {
            List<CuocGoi> listCuocGoi = new List<CuocGoi>();
            using (var dt = new Data.CuocGoi().FT_TONGDAI_LayCuocGoiDaNhanXuLyNotFT(vungsDuocCapPhep, thoiDiemLayDuLieuTruoc))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    listCuocGoi.AddRange(from DataRow dr in dt.Rows select GetCuocGoiByDataRow(dr));
                }
            }
            return listCuocGoi;
        }
        public static bool FT_TONGDAI_UpdateThongTinCuocGoi_V4(CuocGoi cuocGoi)
        {
            return new Data.CuocGoi().FT_TONGDAI_UpdateThongTinCuocGoi_V4(cuocGoi.IDCuocGoi, cuocGoi.TrangThaiCuocGoi, cuocGoi.LenhTongDai,
                                                                    cuocGoi.GhiChuTongDai, cuocGoi.TrangThaiLenh, cuocGoi.MaNhanVienTongDai, cuocGoi.XeNhan,
                                                                    cuocGoi.XeDon, cuocGoi.DiaChiTraKhach, cuocGoi.ThoiGianDieuXe, cuocGoi.ThoiGianDonKhach,
                                                                    cuocGoi.ChuyenMK, cuocGoi.XeDenDiem, cuocGoi.DiaChiDonKhach);
        }

        public static bool FT_TONGDAI_UpdateThongTinCuocGoi_EV(CuocGoi cuocGoi)
        {
            return new Data.CuocGoi().FT_TONGDAI_UpdateThongTinCuocGoi_EV(cuocGoi.IDCuocGoi, cuocGoi.TrangThaiCuocGoi, cuocGoi.LenhTongDai,
                                                                    cuocGoi.GhiChuTongDai, cuocGoi.TrangThaiLenh, cuocGoi.MaNhanVienTongDai, cuocGoi.XeNhan,
                                                                    cuocGoi.XeDon, cuocGoi.DiaChiTraKhach, cuocGoi.ThoiGianDieuXe, cuocGoi.ThoiGianDonKhach,
                                                                    cuocGoi.ChuyenMK, cuocGoi.XeDenDiem, cuocGoi.DiaChiDonKhach, cuocGoi.KhongDungMobileService.Value);
        }
        public static bool FT_TONGDAI_UpdateThongTinCuocGoi_KETTHUC(CuocGoi cuocGoi)
        {

            return new Data.CuocGoi().TONGDAI_UpdateThongTinCuocGoi_KETTHUC(cuocGoi.IDCuocGoi, cuocGoi.TrangThaiCuocGoi, cuocGoi.LenhTongDai,
                                                                    cuocGoi.GhiChuTongDai, cuocGoi.TrangThaiLenh, cuocGoi.MaNhanVienTongDai, cuocGoi.XeNhan,
                                                                    cuocGoi.XeDon, cuocGoi.DiaChiTraKhach, cuocGoi.ThoiGianDieuXe, cuocGoi.ThoiGianDonKhach);
        }
        /// <summary>
        /// Lấy các cuốc có cuốc FT
        /// </summary>
        public static List<CuocGoi> FT_TONGDAI_LayCuocGoiMoiTuDienThoai(string vungsDuocCapPhep, DateTime thoiDiemLayDuLieuTruoc)
        {
            List<CuocGoi> listCuocGoi = new List<CuocGoi>();
            using (var dt = new Data.CuocGoi().FT_TONGDAI_LayCuocGoiMoiTuDienThoai(vungsDuocCapPhep, thoiDiemLayDuLieuTruoc))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    listCuocGoi.AddRange(from DataRow dr in dt.Rows select GetCuocGoiByDataRow(dr));
                }
            }
            return listCuocGoi;
        }
        /// <summary>
        /// Lấy dữ cuốc không phải là FT.
        /// </summary>
        /// <param name="vungsDuocCapPhep"></param>
        /// <param name="thoiDiemLayDuLieuTruoc"></param>
        /// <returns></returns>
        public static List<CuocGoi> FT_TONGDAI_LayCuocGoiMoiTuDienThoaiNotFT(string vungsDuocCapPhep, DateTime thoiDiemLayDuLieuTruoc)
        {
            List<CuocGoi> listCuocGoi = new List<CuocGoi>();
            using (var dt = new Data.CuocGoi().FT_TONGDAI_LayCuocGoiMoiTuDienThoaiNotFT(vungsDuocCapPhep, thoiDiemLayDuLieuTruoc))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    listCuocGoi.AddRange(from DataRow dr in dt.Rows select GetCuocGoiByDataRow(dr));
                }
            }
            return listCuocGoi;
        }
        #endregion

        #region Viết lịch sử
        public static bool FT_History_Create(int IdCuocGoi, string Content, int Status, bool T_Result = true,
            bool FT_Result = true)
        {
            return new Data.CuocGoi().FT_History_Create(IdCuocGoi, Content, Status, T_Result, FT_Result);
        }

        public static DataTable FT_GetHistoryByIdCuoc(long id)
        {
            return new Data.CuocGoi().FT_GetHistoryByIdCuoc(id);
        }
        #endregion

        #endregion

        #region ================ Envang ====================
        public static List<CuocGoi> DIENTHOAI_LayDSCuocGoiMoi_EnVangVip(string lineChoPhep, DateTime thoiDiemLayTruoc)
        {
            List<CuocGoi> listCuocGoi = new List<CuocGoi>();
            using (var dt = new Data.CuocGoi().DIENTHOAI_LayDSCuocGoiMoi_EnVangVip(lineChoPhep, thoiDiemLayTruoc))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    listCuocGoi.AddRange(from DataRow dr in dt.Rows select GetCuocGoiByDataRow(dr));
                }
            }
            //List<CuocGoiDienThoaiLanDauType> listCuocGoiLanDau = new List<CuocGoiDienThoaiLanDauType>();
            //listCuocGoiLanDau = new Data.CuocGoi().DIENTHOAI_LayDSCuocGoiMoi_EnVangVip(lineChoPhep, thoiDiemLayTruoc);
            //if (listCuocGoiLanDau != null && listCuocGoiLanDau.Count > 0)
            //{
            //    foreach (CuocGoiDienThoaiLanDauType objCuocLanDau in listCuocGoiLanDau)
            //    {
            //        var rows = new CuocGoi(objCuocLanDau.IDCuocGoi, objCuocLanDau.ThoiDiemGoi, objCuocLanDau.SoLanGoi,
            //            objCuocLanDau.Line, objCuocLanDau.PhoneNumber,
            //            objCuocLanDau.DiaChiGoi, objCuocLanDau.DiaChiDonKhach, objCuocLanDau.Vung,
            //            objCuocLanDau.KieuKhachHangGoiDen, objCuocLanDau.LoaiXe,
            //            objCuocLanDau.LenhDienThoai, objCuocLanDau.GhiChuDienThoai, objCuocLanDau.XeNhan,
            //            objCuocLanDau.MaDoiTac,
            //            objCuocLanDau.GPS_KinhDo, objCuocLanDau.GPS_ViDo)
            //        {
            //            DiaChiTraKhach = objCuocLanDau.DiaChiTraKhach,
            //            FT_Date = objCuocLanDau.FT_Date,
            //            FT_IsFT = objCuocLanDau.FT_IsFT,
            //            FT_SendDate = objCuocLanDau.FT_SendDate,
            //            FT_Cust_Lat = objCuocLanDau.FT_Cust_Lat,
            //            FT_Cust_Lng = objCuocLanDau.FT_Cust_Lng,
            //            FT_ID = objCuocLanDau.FT_ID,
            //            FT_AllowCall = objCuocLanDau.FT_AllowCall,
            //            MH_LenhLaiXe = objCuocLanDau.MH_LenhLaiXe,
            //            MH_DaGuiXe = objCuocLanDau.MH_DaGuiXe,
            //            MH_SoLanGuiToiXe = objCuocLanDau.MH_SoLanGuiToiXe,
            //            MH_ThoiDiemGuiXe = objCuocLanDau.MH_ThoiDiemGuiXe,
            //            GhiChuLaiXe = objCuocLanDau.GhiChuLaiXe,
            //            DaGuiDSXeNhan = objCuocLanDau.DaGuiDSXeNhan,
            //            CenterConfirm = objCuocLanDau.CenterConfirm,
            //            XeNhan = objCuocLanDau.XeNhan,
            //            XeDon = objCuocLanDau.XeDon,
            //            DanhSachXeDeCu = objCuocLanDau.DanhSachXeDeCu,
            //            LenhTongDai = objCuocLanDau.LenhTongDai,
            //            GhiChuTongDai = objCuocLanDau.GhiChuTongDai,
            //            KhongDungMobileService = objCuocLanDau.KhongDungMobileService
            //        };
            //        listCuocGoi.Add(rows);
            //    }
            //}
            return listCuocGoi;
        }
        public static List<CuocGoi> DIENTHOAI_LayAllOfLineChoPhep_EnVangVip(string lineChoPhep)
        {
            List<CuocGoi> listCuocGoi = new List<CuocGoi>();
            using (var dt = new Data.CuocGoi().DIENTHOAI_LayAllOfLineChoPhep_EnVangVip(lineChoPhep))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    listCuocGoi.AddRange(from DataRow dr in dt.Rows select GetCuocGoiByDataRow(dr));
                }
            }
            //List<CuocGoiDienThoaiLanDauType> listCuocGoiLanDau = new Data.CuocGoi().DIENTHOAI_LayAllOfLineChoPhep_EnVangVip(lineChoPhep);
            //if (listCuocGoiLanDau != null && listCuocGoiLanDau.Count > 0)
            //{
            //    foreach (CuocGoiDienThoaiLanDauType objCuocLanDau in listCuocGoiLanDau)
            //    {
            //        var rows = new CuocGoi(objCuocLanDau.IDCuocGoi, objCuocLanDau.ThoiDiemGoi, objCuocLanDau.SoLanGoi,
            //            objCuocLanDau.Line, objCuocLanDau.PhoneNumber,
            //            objCuocLanDau.DiaChiGoi, objCuocLanDau.DiaChiDonKhach, objCuocLanDau.Vung,
            //            objCuocLanDau.KieuKhachHangGoiDen, objCuocLanDau.LoaiXe,
            //            objCuocLanDau.LenhDienThoai, objCuocLanDau.GhiChuDienThoai, objCuocLanDau.XeNhan,
            //            objCuocLanDau.MaDoiTac,
            //            objCuocLanDau.GPS_KinhDo, objCuocLanDau.GPS_ViDo)
            //        {
            //            IDCuocGoi = objCuocLanDau.IDCuocGoi,
            //            DiaChiTraKhach = objCuocLanDau.DiaChiTraKhach,
            //            FT_Date = objCuocLanDau.FT_Date,
            //            FT_IsFT = objCuocLanDau.FT_IsFT,
            //            FT_SendDate = objCuocLanDau.FT_SendDate,
            //            FT_Cust_Lat = objCuocLanDau.FT_Cust_Lat,
            //            FT_Cust_Lng = objCuocLanDau.FT_Cust_Lng,
            //            FT_ID = objCuocLanDau.FT_ID,
            //            FT_AllowCall = objCuocLanDau.FT_AllowCall,
            //            MH_LenhLaiXe = objCuocLanDau.MH_LenhLaiXe,
            //            MH_DaGuiXe = objCuocLanDau.MH_DaGuiXe,
            //            MH_SoLanGuiToiXe = objCuocLanDau.MH_SoLanGuiToiXe,
            //            MH_ThoiDiemGuiXe = objCuocLanDau.MH_ThoiDiemGuiXe,
            //            GhiChuLaiXe = objCuocLanDau.GhiChuLaiXe,
            //            XeDon = objCuocLanDau.XeDon,
            //            DaGuiDSXeNhan = objCuocLanDau.DaGuiDSXeNhan,
            //            CenterConfirm = objCuocLanDau.CenterConfirm,
            //            KieuCuocGoi = objCuocLanDau.KieuCuocGoi,
            //            DanhSachXeDeCu = objCuocLanDau.DanhSachXeDeCu,
            //            LenhTongDai=objCuocLanDau.LenhTongDai,
            //            GhiChuTongDai = objCuocLanDau.GhiChuTongDai,
            //            KhongDungMobileService = objCuocLanDau.KhongDungMobileService
            //        };
            //        listCuocGoi.Add(rows);
            //    }
            //}
            return listCuocGoi;
        }
        public static bool DIENTHOAI_UpdateThongTinCuocGoi_EnVangVip(CuocGoi cuocGoi)
        {
            return new Data.CuocGoi().DIENTHOAI_UpdateThongTinCuocGoi_EnVangVip(cuocGoi.IDCuocGoi, cuocGoi.DiaChiDonKhach, cuocGoi.DiaChiTraKhach, cuocGoi.PhoneNumber, cuocGoi.Vung, cuocGoi.LoaiXe, cuocGoi.SoLuong, cuocGoi.TrangThaiCuocGoi,
                                                                      cuocGoi.KieuCuocGoi, cuocGoi.LenhDienThoai, cuocGoi.TrangThaiLenh, cuocGoi.GhiChuDienThoai, cuocGoi.MaNhanVienDienThoai,
                                                                      cuocGoi.ThoiDiemChuyenTongDai, cuocGoi.GPS_KinhDo, cuocGoi.GPS_ViDo, cuocGoi.DanhSachXeDeCu
                                                                      , cuocGoi.DanhSachXeDeCu_TD, cuocGoi.xeDon, cuocGoi.KieuKhachHangGoiDen
                                                                      , cuocGoi.LoaiCuocKhach, cuocGoi.FT_IsFT, cuocGoi.FT_Date, cuocGoi.FT_SendDate, cuocGoi.FT_Status, cuocGoi.XeNhan, cuocGoi.GPS_ViDo_Tra, cuocGoi.GPS_KinhDo_Tra);
        }

        /// <summary>
        /// Cập nhật trường đánh dấu đã gửi danh sách xe nhận
        /// </summary>
        /// <param name="iDCuocGoi">The i d cuoc goi.</param>
        /// <param name="daGuiDSXeNhan">The da GUI ds xe nhan.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  7/28/2015   created
        /// </Modified>
        public static bool DIENTHOAI_CapNhatDaGuiDSXeNhan_EnVangVip(long iDCuocGoi, byte? daGuiDSXeNhan)
        {
            return new Data.CuocGoi().DIENTHOAI_CapNhatDaGuiDSXeNhan_EnVangVip(iDCuocGoi, daGuiDSXeNhan);
        }

        /// <summary>
        /// Lấy về các cuộc gọi đã thay đổi
        /// </summary>
        /// <param name="linesDuocCapPhep">The lines duoc cap phep.</param>
        /// <param name="thoiDiemNhanDulieuTruoc">The thoi diem nhan dulieu truoc.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  7/28/2015   created
        /// </Modified>
        public static List<CuocGoi> DIENTHOAI_LayDSCuocGoiThayDoiByTongDai_V4_Khac(string linesDuocCapPhep, DateTime thoiDiemNhanDulieuTruoc)
        {
            List<CuocGoi> listCuocGoi = new List<CuocGoi>();
            DataTable dt = new Data.CuocGoi().DIENTHOAI_LayDSCuocGoiThayDoiByTongDai_V4_Khac(linesDuocCapPhep, thoiDiemNhanDulieuTruoc);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow objCG in dt.Rows)
                {
                    listCuocGoi.Add(GetCuocGoiByDataRow_Khac(objCG));
                }
            }
            return listCuocGoi;
        }

        /// <summary>
        /// Lấy về xe ưa thích của khách hàng
        /// </summary>
        /// <param name="idCuocGoi">The identifier cuoc goi.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  7/29/2015   created
        /// </Modified>
        public static ThongTinKhachHangVip DIENTHOAI_LayXeUaThich_EnVangVIP(long idCuocGoi)
        {
            ThongTinKhachHangVip thongTin = new ThongTinKhachHangVip();
            DataTable dt = new Data.CuocGoi().DIENTHOAI_LayXeUaThich_EnVangVIP(idCuocGoi);
            if (dt != null && dt.Rows.Count > 0)
            {
                thongTin.PrivateCode_Favourite = dt.Rows[0]["PrivateCode_Favourite"] == DBNull.Value ? string.Empty : dt.Rows[0]["PrivateCode_Favourite"].ToString();
                thongTin.Location = dt.Rows[0]["Location"] == DBNull.Value ? string.Empty : dt.Rows[0]["Location"].ToString();
            }
            return thongTin;
        }

        /// <summary>
        /// Lấy về message confirm cho én vàng vip
        /// </summary>
        /// <param name="lineChoPhep">The line cho phep.</param>
        /// <param name="isDienThoai">if set to <c>true</c> [is dien thoai].</param>
        /// <param name="openedMessageKeys">The opened message keys.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  9/8/2015   created
        /// </Modified>
        public static List<MessageConfirm> DIENTHOAI_LayMessageConfirm_EnVangVIP(string lineChoPhep, bool isDienThoai, string openedMessageKeys)
        {
            List<MessageConfirm> messages = new List<MessageConfirm>();
            DataTable dt = new Data.CuocGoi().DIENTHOAI_LayMessageConfirm_EnVangVIP(lineChoPhep, isDienThoai, openedMessageKeys);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow objCG in dt.Rows)
                {
                    MessageConfirm newMessage = new MessageConfirm();
                    newMessage.IDCuocGoi = objCG["IDCuocGoi"] == DBNull.Value ? 0 : Convert.ToInt64(objCG["IDCuocGoi"].ToString());
                    newMessage.CanConfirm = objCG["CanConfirm"] == DBNull.Value ? false : Convert.ToBoolean(objCG["CanConfirm"].ToString());
                    newMessage.DiaChiDonKhach = objCG["DiaChiDonKhach"] == DBNull.Value ? string.Empty : objCG["DiaChiDonKhach"].ToString();
                    newMessage.SoHieuXe = objCG["XeDon"] == DBNull.Value ? string.Empty : objCG["XeDon"].ToString();
                    newMessage.MaMessage = objCG["MaMessage"] == DBNull.Value ? Convert.ToInt16(0) : Convert.ToInt16(objCG["MaMessage"].ToString());
                    newMessage.MessageContent = objCG["MessageContent"] == DBNull.Value ? string.Empty : objCG["MessageContent"].ToString();
                    newMessage.Timeout = objCG["Timeout"] == DBNull.Value ? Convert.ToInt16(30) : Convert.ToInt16(objCG["Timeout"].ToString());
                    newMessage.ClosingTime = objCG["ClosingTime"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(objCG["ClosingTime"].ToString());
                    newMessage.BienSoXe = objCG["BienSoXe"] == DBNull.Value ? "" : objCG["BienSoXe"].ToString();
                    newMessage.XeDon = newMessage.SoHieuXe;
                    messages.Add(newMessage);
                }
            }
            return messages;
        }


        /// <summary>
        /// Sửa lệnh lái xe
        /// </summary>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  7/30/2015   created
        /// </Modified>
        public static int DIENTHOAI_SuaMessageConfirm_EnVangVip(long idCuocGoi, string lenhLaiXe, short pMaMessage, bool pCoMoLai, string pSoHieuXe)
        {
            return new Data.CuocGoi().DIENTHOAI_SuaMessageConfirm_EnVangVip(idCuocGoi, lenhLaiXe, pMaMessage, pCoMoLai, pSoHieuXe);
        }

        /// <summary>
        /// Ens the vang_ GUI tin cho lai xe.
        /// </summary>
        /// <param name="idCuocGoi">The identifier cuoc goi.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/10/2015   created
        /// </Modified>
        public static bool EnVangVIP_GuiTinChoLaiXe(long idCuocGoi)
        {
            return new Data.CuocGoi().EnVangVIP_GuiTinChoLaiXe(idCuocGoi);
        }

        /// <summary>
        /// Lấy về các cuốc cho phần tổng đài
        /// </summary>
        /// <param name="vungsDuocCapPhep">The vungs duoc cap phep.</param>
        /// <param name="lstCuocGoi_ChuaNhan">The LST cuoc goi_ chua nhan.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/18/2015   created
        /// </Modified>
        public static List<CuocGoi> EnVangVIP_TONGDAI_LayAllCuocGoi(string vungsDuocCapPhep, ref List<CuocGoi> lstCuocGoi_ChuaNhan)
        {
            var listCuocGoi = new List<CuocGoi>();
            var ds = new Data.CuocGoi().EnVangVIP_TONGDAI_LayAllCuocGoi(vungsDuocCapPhep);
            if (ds.Tables.Count > 0)
            {
                using (var dtCuocGoiDaNhan = ds.Tables[0])
                {
                    if (dtCuocGoiDaNhan != null && dtCuocGoiDaNhan.Rows.Count > 0)
                    {
                        listCuocGoi.AddRange(from DataRow dr in dtCuocGoiDaNhan.Rows select GetCuocGoiByDataRow(dr));
                    }
                }
                if (Global.GridConfig_CuocGoi == Grid_Config.Has_Grid_Bottom)
                {
                    using (var dtCuocGoiChuaNhan = ds.Tables[1])
                    {
                        if (dtCuocGoiChuaNhan != null && dtCuocGoiChuaNhan.Rows.Count > 0)
                        {
                            lstCuocGoi_ChuaNhan.AddRange(from DataRow dr in dtCuocGoiChuaNhan.Rows select GetCuocGoiByDataRow(dr));
                        }
                    }
                }
            }
            return listCuocGoi;
        }

        public static List<CuocGoi> EnVangVIP_TONGDAI_LayAllCuocGoi_DaDonKhach(string vungsDuocCapPhep, ref List<CuocGoi> lstCuocGoi_ChuaNhan)
        {
            var listCuocGoi = new List<CuocGoi>();
            var ds = new Data.CuocGoi().EnVangVIP_TONGDAI_LayAllCuocGoi_DaDonKhach(vungsDuocCapPhep);
            if (ds.Tables.Count > 0)
            {
                using (var dtCuocGoiDaNhan = ds.Tables[0])
                {
                    if (dtCuocGoiDaNhan != null && dtCuocGoiDaNhan.Rows.Count > 0)
                    {
                        listCuocGoi.AddRange(from DataRow dr in dtCuocGoiDaNhan.Rows select GetCuocGoiByDataRow(dr));
                    }
                }
            }
            return listCuocGoi;
        }

        public static List<CuocGoi> EnVangVIP_TONGDAI_LayCuocGoiMoiTuDienThoai(string vungsDuocCapPhep, DateTime thoiDiemLayDuLieuTruoc)
        {
            List<CuocGoi> listCuocGoi = new List<CuocGoi>();
            using (var dt = new Data.CuocGoi().EnVangVip_TONGDAI_LayCuocGoiMoiTuDienThoai(vungsDuocCapPhep, thoiDiemLayDuLieuTruoc))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    listCuocGoi.AddRange(from DataRow dr in dt.Rows select GetCuocGoiByDataRow(dr));
                }
            }
            return listCuocGoi;
        }

        public static List<CuocGoi> EnVangVIP_TONGDAI_LayCuocGoiMoiTuDienThoai_DaDonKhach(string vungsDuocCapPhep, DateTime thoiDiemLayDuLieuTruoc)
        {
            List<CuocGoi> listCuocGoi = new List<CuocGoi>();
            using (var dt = new Data.CuocGoi().EnVangVip_TONGDAI_LayCuocGoiMoiTuDienThoai_DaDonKhach(vungsDuocCapPhep, thoiDiemLayDuLieuTruoc))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    listCuocGoi.AddRange(from DataRow dr in dt.Rows select GetCuocGoiByDataRow(dr));
                }
            }
            return listCuocGoi;
        }
        public static List<long> EnVangVip_TONGDAI_LayCacIDCuocGoiKetThucByDienThoai(string listIDCuocGoiHienTai, string vungsDuocCapPhep)
        {
            List<long> listID = new List<long>();
            using (DataTable dt = new Data.CuocGoi().EnVangVip_TONGDAI_LayCacIDCuocGoiKetThucByDienThoai(listIDCuocGoiHienTai, vungsDuocCapPhep))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["ID"] != DBNull.Value)
                        {
                            listID.Add(Convert.ToInt64(dr["ID"].ToString()));
                        }
                    }
                }
            }
            return listID;
        }

        public static List<long> EnVangVIP_LayCacIDCuocGoiKetThucByDienThoai_DaDonKhach(string listIDCuocGoiHienTai, string vungsDuocCapPhep)
        {
            List<long> listID = new List<long>();
            using (DataTable dt = new Data.CuocGoi().EnVangVIP_TONGDAI_LayCacIDCuocGoiKetThucByDienThoai_DaDonKhach(listIDCuocGoiHienTai, vungsDuocCapPhep))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["ID"] != DBNull.Value)
                        {
                            listID.Add(Convert.ToInt64(dr["ID"].ToString()));
                        }
                    }
                }
            }
            return listID;
        }

        /// <summary>
        /// Tạo nhiều cuộc gọi cho én vàng vip dựa trên số lượng xe
        /// </summary>
        /// <param name="idCuocGoi">The identifier cuoc goi.</param>
        /// <param name="soLuong">The so luong.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/19/2015   created
        /// </Modified>
        public static bool EnVangVIP_TaoNhieuCuocGoi(long idCuocGoi, int soLuong)
        {
            return new Data.CuocGoi().EnVangVIP_TaoNhieuCuocGoi(idCuocGoi, soLuong);
        }

        /// <summary>
        /// Tạo message confirm. Đang dùng bên này để tạo message chat
        /// </summary>
        /// <param name="idCuocGoi">Id cuộc gọi.</param>
        /// <param name="maMessage">Mã số message.</param>
        /// <param name="canConfirm">Cần confirm</param>
        /// <param name="daGiaiQuyet">Giải quyết hay chưa</param>
        /// <param name="messageContent">Nội dung message</param>
        /// <param name="soHieuXe">Số hiệu xe.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/20/2015   created
        /// </Modified>
        public static bool EnVangVIP_TaoMessageConfirm(long idCuocGoi, short maMessage, bool canConfirm, bool daGiaiQuyet, string messageContent, string soHieuXe)
        {
            return new Data.CuocGoi().EnVangVIP_TaoMessageConfirm(idCuocGoi, maMessage, canConfirm, daGiaiQuyet, messageContent, soHieuXe);
        }

        /// <summary>
        /// Nhập dữ liệu giám sát xe
        /// </summary>
        /// <param name="bienSo">The bien so.</param>
        /// <param name="maLaiXe">The ma lai xe.</param>
        /// <param name="viTriDiemBao">The vi tri diem bao.</param>
        /// <param name="trangThaiXeBao">The trang thai xe bao.</param>
        /// <param name="diemDo">The diem do.</param>
        /// <param name="isHoatDong">The is hoat dong.</param>
        /// <param name="soPhutNghi">The so phut nghi.</param>
        /// <param name="thoiDiemVe">The thoi diem ve.</param>
        /// <param name="node">Điểm đỗ</param>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/27/2015   created
        /// </Modified>
        public static int EnVangVIP_NhapDuLieuGiamSatXe(string bienSo, string maLaiXe, string viTriDiemBao
            , string trangThaiXeBao, long? diemDo, string isHoatDong, int? soPhutNghi, DateTime? thoiDiemVe, int node = 0)
        {
            var table = new Data.CuocGoi().EnVangVIP_NhapDuLieuGiamSatXe(bienSo, maLaiXe, viTriDiemBao, trangThaiXeBao
                , Convert.ToInt32(diemDo), isHoatDong, soPhutNghi
                , thoiDiemVe, node);
            if (table != null)
            {
                return Convert.ToInt32(table.Rows[0]["Node"].ToString());
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Lấy về các xe đang chat
        /// </summary>
        /// <param name="lineChoPhep">The line cho phep.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/20/2015   created
        /// </Modified>
        public static List<DM.Xe> EnVangVIP_DienThoai_LayCacXeDangChat(string lineChoPhep)
        {
            var listXe = new List<DM.Xe>();
            var dt = new Data.CuocGoi().EnVangVip_DienThoai_LayCacXeDangChat(lineChoPhep);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow objCG in dt.Rows)
                {
                    var xe = new DM.Xe();
                    xe.SoHieuXe = objCG["SoHieuXe"] == DBNull.Value ? string.Empty : objCG["SoHieuXe"].ToString();
                    listXe.Add(xe);
                }
            }
            return listXe;
        }

        /// <summary>
        /// Lấy nội dung chat của xe đang chọn
        /// </summary>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/20/2015   created
        /// </Modified>
        public static List<MessageConfirm> EnVangVip_DienThoai_LayNoiDungChatCuaXe(string soHieuXe, DateTime? thoiDiemLineChatCuoi = null)
        {
            var messages = new List<MessageConfirm>();
            var dt = new Data.CuocGoi().EnVangVip_DienThoai_LayNoiDungChatCuaXe(soHieuXe, thoiDiemLineChatCuoi);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow objCG in dt.Rows)
                {
                    MessageConfirm newMessage = new MessageConfirm();
                    newMessage.IDCuocGoi = objCG["IDCuocGoi"] == DBNull.Value ? 0 : Convert.ToInt64(objCG["IDCuocGoi"].ToString());
                    newMessage.ThoiDiemGoiMessage = objCG["ThoiDiemGoiMessage"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(objCG["ThoiDiemGoiMessage"].ToString());
                    newMessage.SoHieuXe = objCG["SoHieuXe"] == DBNull.Value ? string.Empty : objCG["SoHieuXe"].ToString();
                    newMessage.MessageContent = objCG["MessageContent"] == DBNull.Value ? string.Empty : objCG["MessageContent"].ToString();
                    newMessage.MaMessage = objCG["MaMessage"] == DBNull.Value ? Convert.ToInt16(0) : Convert.ToInt16(objCG["MaMessage"].ToString());
                    newMessage.BienSoXe = objCG["BienSoXe"] == DBNull.Value ? "" : objCG["BienSoXe"].ToString();
                    messages.Add(newMessage);
                }
            }
            return messages;
        }

        /// <summary>
        /// Lấy về các message không có id cuộc gọi
        /// </summary>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/27/2015   created
        /// </Modified>
        public static List<MessageConfirm> EnVangVip_sp_GetMessageWithNoId(string openedMessageKeys)
        {
            var messages = new List<MessageConfirm>();
            var dt = new Data.CuocGoi().EnVangVip_sp_GetMessageWithNoId(openedMessageKeys);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow objCG in dt.Rows)
                {
                    MessageConfirm newMessage = new MessageConfirm();
                    newMessage.IDCuocGoi = objCG["IDCuocGoi"] == DBNull.Value ? 0 : Convert.ToInt64(objCG["IDCuocGoi"].ToString());
                    newMessage.ThoiDiemGoiMessage = objCG["ThoiDiemGoiMessage"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(objCG["ThoiDiemGoiMessage"].ToString());
                    newMessage.SoHieuXe = objCG["SoHieuXe"] == DBNull.Value ? string.Empty : objCG["SoHieuXe"].ToString();
                    newMessage.MessageContent = objCG["MessageContent"] == DBNull.Value ? string.Empty : objCG["MessageContent"].ToString();
                    newMessage.MaMessage = objCG["MaMessage"] == DBNull.Value ? Convert.ToInt16(0) : Convert.ToInt16(objCG["MaMessage"].ToString());
                    newMessage.CanConfirm = objCG["CanConfirm"] == DBNull.Value ? false : Convert.ToBoolean(objCG["CanConfirm"].ToString());
                    newMessage.Timeout = objCG["Timeout"] == DBNull.Value ? Convert.ToInt16(30) : Convert.ToInt16(objCG["Timeout"].ToString());
                    newMessage.ClosingTime = objCG["ClosingTime"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(objCG["ClosingTime"].ToString());
                    newMessage.BienSoXe = objCG["BienSoXe"] == DBNull.Value ? "" : objCG["BienSoXe"].ToString();
                    newMessage.XeDon = newMessage.SoHieuXe;
                    messages.Add(newMessage);
                }
            }
            return messages;
        }


        /// <summary>
        /// Lấy về các xe đang nghỉ
        /// </summary>
        /// <param name="privateCodes">The private codes.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/28/2015   created
        /// </Modified>
        public static string EnVangVip_sp_GetRestingVehicle(string privateCodes)
        {
            var restingVehicle = string.Empty;
            var dt = new Data.CuocGoi().EnVangVip_sp_GetRestingVehicle(privateCodes);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow objCG in dt.Rows)
                {
                    restingVehicle = objCG["CacXeDangNghi"] == DBNull.Value ? string.Empty : objCG["CacXeDangNghi"].ToString();
                }
            }
            return restingVehicle;
        }

        /// <summary>
        /// Tạo cuộc gọi khai thác cho én vàng
        /// </summary>
        /// <param name="soHieuXe">The so hieu xe.</param>
        /// <param name="thoiDiemBao">The thoi diem bao.</param>
        /// <param name="maLaiXe">The ma lai xe.</param>
        /// <param name="tenLaiXe">The ten lai xe.</param>
        /// <param name="viTriDiemBao">The vi tri diem bao.</param>
        /// <param name="diemDo">The diem do.</param>
        /// <param name="ghiChu">The ghi chu.</param>
        /// <param name="gioKhachLen">Length of the gio khach.</param>
        /// <param name="maNVTongDai">The ma nv tong dai.</param>
        /// <param name="maNVDienThoai">The ma nv dien thoai.</param>
        /// <param name="line">The line.</param>
        /// <param name="kinhDo">The kinh do.</param>
        /// <param name="viDo">The vi do.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  9/1/2015   created
        /// </Modified>
        public static bool EnVangVip_sp_TaoCuocGoiKhaiThac(string soHieuXe, DateTime thoiDiemBao, string maLaiXe, string tenLaiXe, string viTriDiemBao,
            int diemDo, string ghiChu, DateTime gioKhachLen, string maNVTongDai, string maNVDienThoai, string line, double kinhDo, double viDo)
        {
            return new Data.CuocGoi().EnVangVip_sp_TaoCuocGoiKhaiThac(soHieuXe, thoiDiemBao, maLaiXe, tenLaiXe, viTriDiemBao, diemDo, ghiChu, gioKhachLen, maNVTongDai, maNVDienThoai, line, kinhDo, viDo);
        }

        /// <summary>
        /// Đổi config có kết nối điện thoại hay không
        /// </summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  9/3/2015   created
        /// </Modified>
        public static bool EnVangVip_sp_ChangeDisconnectMobile(bool value)
        {
            return new Data.CuocGoi().EnVangVip_sp_ChangeDisconnectMobile(value);
        }

        #endregion

        #region ================ G5 ========================
        #region ----------------- Điện thoại --------------
        #region  *********** Lấy dữ liệu ************
        #region == New ==
        public static List<CuocGoi> G5_DIENTHOAI_GetNew(string Line, DateTime LastUpdate)
        {
            using (var dt = new Data.CuocGoi().G5_DIENTHOAI_GetNew(Line, LastUpdate))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt.Rows.Cast<DataRow>().Select(GetCuocGoiByDataRow).ToList();
                }
            }
            return new List<CuocGoi>();
        }
        public static List<CuocGoi> G5_DIENTHOAI_GetUpdate(string Line, DateTime LastUpdate)
        {
            using (var dt = new Data.CuocGoi().G5_DIENTHOAI_GetUpdate(Line, LastUpdate))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt.Rows.Cast<DataRow>().Select(GetCuocGoiByDataRow).ToList();
                }
            }
            return new List<CuocGoi>();
        }
        public static List<long> G5_DIENTHOAI_GetDelete(string Line, string lsId)
        {
            using (var dt = new Data.CuocGoi().G5_DIENTHOAI_GetDelete(Line, lsId))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt.Rows.Cast<DataRow>().Select(p => p[0].To<long>()).ToList();
                }
            }
            return new List<long>();
        }

        #endregion
        public static List<CuocGoi> G5_DIENTHOAI_LayDSCuocGoiMoi_FTNotFT(string lineChoPhep, DateTime thoiDiemLayTruoc)
        {
            var listCuocGoi = new List<CuocGoi>();
            using (var dt = new Data.CuocGoi().G5_DIENTHOAI_LayDSCuocGoiMoi_FTNotFT(lineChoPhep, thoiDiemLayTruoc))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    listCuocGoi.AddRange(from DataRow dr in dt.Rows select GetCuocGoiByDataRow(dr));
                }
            }
            return listCuocGoi;
        }
        public static List<CuocGoi> G5_DIENTHOAI_LayDSCuocGoiMoi_FT(string lineChoPhep, DateTime thoiDiemLayTruoc)
        {
            var listCuocGoi = new List<CuocGoi>();
            using (var dt = new Data.CuocGoi().G5_DIENTHOAI_LayDSCuocGoiMoi_FT(lineChoPhep, thoiDiemLayTruoc))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    listCuocGoi.AddRange(from DataRow dr in dt.Rows select GetCuocGoiByDataRow(dr));
                }
            }
            return listCuocGoi;
        }

        public static List<CuocGoi> G5_DIENTHOAI_LayAllCuocGoi(string linechophep)
        {

            var listCuocGoi = new List<CuocGoi>();
            using (var dt = new Data.CuocGoi().G5_DIENTHOAI_LayAllCuocGoi(linechophep))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    listCuocGoi.AddRange(from DataRow dr in dt.Rows select GetCuocGoiByDataRow(dr));
                }
            }
            return listCuocGoi;
        }

        #region === Cuốc sân bay ===
        public static List<CuocGoi> G5_DIENTHOAI_LayAllCuocGoiSB()
        {

            var listCuocGoi = new List<CuocGoi>();
            using (var dt = new Data.CuocGoi().G5_DIENTHOAI_LayAllCuocGoiSB())
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    listCuocGoi.AddRange(from DataRow dr in dt.Rows select GetCuocGoiByDataRow(dr));
                }
            }
            return listCuocGoi;
        }
        public static List<CuocGoi> G5_DIENTHOAI_LayDSCuocGoiMoi_FTSB(DateTime thoiDiemLayTruoc)
        {
            var listCuocGoi = new List<CuocGoi>();
            using (var dt = new Data.CuocGoi().G5_DIENTHOAI_LayDSCuocGoiMoi_FTSB(thoiDiemLayTruoc))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    listCuocGoi.AddRange(from DataRow dr in dt.Rows select GetCuocGoiByDataRow(dr));
                }
            }
            return listCuocGoi;
        }

        public static List<CuocGoi> G5_DIENTHOAI_LayDSCuocGoiThayDoiByTongDaiSB(DateTime thoiDiemNhanDulieuTruoc)
        {
            List<CuocGoi> listCuocGoi = new List<CuocGoi>();
            try
            {
                DataTable dt = new Data.CuocGoi().G5_DIENTHOAI_LayDSCuocGoiThayDoiByTongDaiSB(thoiDiemNhanDulieuTruoc);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        listCuocGoi.Add(GetCuocGoiByDataRow(dr));
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("G5_DIENTHOAI_LayDSCuocGoiThayDoiByTongDaiSB", ex);
            }
            return listCuocGoi;
        }
        public static List<long> G5_DIENTHOAI_LayCacIDCuocGoiKetThucByTongDaiSB(string listIDCuocGoiHienTai)
        {
            List<long> listID = new List<long>();
            using (DataTable dt = new Data.CuocGoi().G5_DIENTHOAI_LayCacIDCuocGoiKetThucByTongDaiSB(listIDCuocGoiHienTai))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["ID"] != DBNull.Value)
                        {
                            listID.Add(Convert.ToInt64(dr["ID"].ToString()));
                        }
                    }
                }
            }
            return listID;
        }
        #endregion
        public static List<CuocGoi> G5_DIENTHOAI_LayAllCuocGoiNotFT(string linechophep)
        {

            var listCuocGoi = new List<CuocGoi>();
            using (var dt = new Data.CuocGoi().G5_DIENTHOAI_LayAllCuocGoiNotFT(linechophep))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    listCuocGoi.AddRange(from DataRow dr in dt.Rows select GetCuocGoiByDataRow(dr));
                }
            }
            return listCuocGoi;
        }
        public static List<CuocGoi> G5_DIENTHOAI_LayDSCuocGoiThayDoiByTongDai(string linesDuocCapPhep, DateTime thoiDiemNhanDulieuTruoc)
        {
            List<CuocGoi> listCuocGoi = new List<CuocGoi>();
            try
            {
                DataTable dt = new Data.CuocGoi().G5_DIENTHOAI_LayDSCuocGoiThayDoiByTongDai(linesDuocCapPhep,
                    thoiDiemNhanDulieuTruoc);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        listCuocGoi.Add(GetCuocGoiByDataRow(dr));
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("G5_DIENTHOAI_LayDSCuocGoiThayDoiByTongDai", ex);
            }
            return listCuocGoi;
        }

        public static List<long> G5_DIENTHOAI_LayCacIDCuocGoiKetThucByTongDai(string listIDCuocGoiHienTai, string linesDuocCapPhep)
        {
            List<long> listID = new List<long>();
            using (DataTable dt = new Data.CuocGoi().G5_DIENTHOAI_LayCacIDCuocGoiKetThucByTongDai(listIDCuocGoiHienTai, linesDuocCapPhep))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["ID"] != DBNull.Value)
                        {
                            listID.Add(Convert.ToInt64(dr["ID"].ToString()));
                        }
                    }
                }
            }
            return listID;
        }
        /// <summary>
        /// Lấy danh sách biển số đã nhận cuốc và điều App
        /// 
        /// </summary>
        /// <param name="BookId"></param>
        /// <returns></returns>
        public static List<String> G5_DIENTHOAI_TAXIOPERATION_GetVehiclePlateByBookId(Guid BookId)
        {
            List<string> db = new List<string>();
            try
            {
                var dt = new Data.CuocGoi().G5_DIENTHOAI_TAXIOPERATION_GetVehiclePlateByBookId(BookId);
                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Columns.Contains("BienKiemSoat") && dr["BienKiemSoat"] != DBNull.Value)
                    {
                        db.Add(dr["BienKiemSoat"].ToString().Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("G5_DIENTHOAI_TAXIOPERATION_GetVehiclePlateByBookId", ex);
            }

            return db;
        }
        public static List<CuocGoi> G5_DIENTHOAI_LayDSCuocGoiThayDoiByTongDai_Khac(string linesDuocCapPhep, DateTime thoiDiemNhanDulieuTruoc)
        {
            List<CuocGoi> listCuocGoi = new List<CuocGoi>();
            DataTable dt = new Data.CuocGoi().G5_DIENTHOAI_LayDSCuocGoiThayDoiByTongDai_Khac(linesDuocCapPhep, thoiDiemNhanDulieuTruoc);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow objCG in dt.Rows)
                {
                    listCuocGoi.Add(GetCuocGoiByDataRow_Khac(objCG));
                }
            }

            return listCuocGoi;
        }

        public static ThongTinGoiLai GetThongTinGoiLai(string CuocGoiLaiId)
        {
            DataTable dt = new Data.CuocGoi().ThongTinGoiLai(CuocGoiLaiId);
            if (dt.Rows.Count > 0)
            {
                var ttgl = new ThongTinGoiLai();
                if (dt.Columns.Contains("BookId"))
                    ttgl.BookId = dt.Rows[0]["BookId"].ToString();
                if (dt.Columns.Contains("XeNhan"))
                    ttgl.XeNhan = dt.Rows[0]["XeNhan"].ToString();
                if (dt.Columns.Contains("G5_Type"))
                    ttgl.G5_Type = dt.Rows[0]["G5_Type"].ToString();
                if (dt.Columns.Contains("XeDungDiem"))
                    ttgl.XeDungDiem = dt.Rows[0]["XeDungDiem"].ToString();

                return ttgl;
            }
            return null;
        }
        public static ThongTinGoiLai GetThongTinGoiLaiByBookId(Guid bookId)
        {
            DataTable dt = new Data.CuocGoi().GetThongTinGoiLaiByBookId(bookId);
            if (dt.Rows.Count > 0)
            {
                var ttgl = new ThongTinGoiLai();
                if (dt.Columns.Contains("BookId"))
                    ttgl.BookId = dt.Rows[0]["BookId"].ToString();
                if (dt.Columns.Contains("XeNhan"))
                    ttgl.XeNhan = dt.Rows[0]["XeNhan"].ToString();
                if (dt.Columns.Contains("G5_Type"))
                    ttgl.G5_Type = dt.Rows[0]["G5_Type"].ToString();
                if (dt.Columns.Contains("XeDungDiem"))
                    ttgl.XeDungDiem = dt.Rows[0]["XeDungDiem"].ToString();

                return ttgl;
            }
            return null;
        }
        #endregion

        #region *********** Cập nhật dữ liệu *******

        public static bool G5_DIENTHOAI_UpdateThongTinCuocGoi_Mini(CuocGoi cuocGoi)
        {
            try
            {
                return new Data.CuocGoi().G5_DIENTHOAI_UpdateThongTinCuocGoi_Mini(
                    cuocGoi.IDCuocGoi, cuocGoi.DiaChiDonKhach, cuocGoi.DiaChiTraKhach,
                    cuocGoi.PhoneNumber, cuocGoi.Vung, cuocGoi.LoaiXe, cuocGoi.SoLuong,
                    cuocGoi.TrangThaiCuocGoi, cuocGoi.KieuCuocGoi, cuocGoi.LenhDienThoai,
                    cuocGoi.TrangThaiLenh, cuocGoi.GhiChuDienThoai, cuocGoi.MaNhanVienDienThoai,
                    cuocGoi.ThoiDiemChuyenTongDai, cuocGoi.GPS_KinhDo, cuocGoi.GPS_ViDo,
                    cuocGoi.DanhSachXeDeCu, cuocGoi.DanhSachXeDeCu_TD, cuocGoi.xeDon,
                    cuocGoi.KieuKhachHangGoiDen, cuocGoi.xeNhan, cuocGoi.XeDenDiem, cuocGoi.LoaiCuocKhach,
                    cuocGoi.FT_IsFT, cuocGoi.FT_Date, cuocGoi.FT_SendDate, cuocGoi.FT_Status, cuocGoi.BookId, (int)cuocGoi.G5_Type,
                    cuocGoi.SanBay_DuongDai, cuocGoi.G5_CarType,cuocGoi.XeDungDiem);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("G5_DIENTHOAI_UpdateThongTinCuocGoi_Mini", ex);
                return false;
            }

        }
        public static bool G5_DIENTHOAI_UpdateThongTinCuocGoi_Mini_V2(CuocGoi cuocGoi, bool isDieuApp = false)
        {
            try
            {
                return new Data.CuocGoi().G5_DIENTHOAI_UpdateThongTinCuocGoi_Mini_V2(
                    cuocGoi.IDCuocGoi, cuocGoi.DiaChiDonKhach, cuocGoi.DiaChiTraKhach,
                    cuocGoi.PhoneNumber, cuocGoi.Vung, cuocGoi.LoaiXe, cuocGoi.SoLuong,
                    cuocGoi.TrangThaiCuocGoi, cuocGoi.KieuCuocGoi, cuocGoi.LenhDienThoai,
                    cuocGoi.TrangThaiLenh, cuocGoi.GhiChuDienThoai, cuocGoi.MaNhanVienDienThoai,
                    cuocGoi.ThoiDiemChuyenTongDai, cuocGoi.GPS_KinhDo, cuocGoi.GPS_ViDo,
                    cuocGoi.DanhSachXeDeCu, cuocGoi.DanhSachXeDeCu_TD, cuocGoi.xeDon,
                    cuocGoi.KieuKhachHangGoiDen, cuocGoi.xeNhan, cuocGoi.XeDenDiem, cuocGoi.LoaiCuocKhach,
                    cuocGoi.FT_IsFT, cuocGoi.FT_Date, cuocGoi.FT_SendDate, cuocGoi.FT_Status, cuocGoi.BookId, (int)cuocGoi.G5_Type,
                    cuocGoi.SanBay_DuongDai, cuocGoi.G5_CarType, cuocGoi.ThoiGianHen == DateTime.MinValue ? cuocGoi.ThoiDiemGoi : cuocGoi.ThoiGianHen, cuocGoi.MoneyTrip, isDieuApp,
                    cuocGoi.DiaChiGoi);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("G5_DIENTHOAI_UpdateThongTinCuocGoi_Mini_V2", ex);
                return false;
            }

        }
        public static bool G5_DIENTHOAI_UpdateThongTinCuocGoi(CuocGoi cuocGoi, CheckChange change = null)
        {
            try
            {
                return new Data.CuocGoi().G5_DIENTHOAI_UpdateThongTinCuocGoi(
                    cuocGoi.IDCuocGoi,// ((change != null && change.DiaChiDon) ? CharCheckChange : cuocGoi.DiaChiDonKhach), ((change != null && change.DiaChiTra) ? CharCheckChange : cuocGoi.DiaChiTraKhach),
                    cuocGoi.DiaChiDonKhach,
                    cuocGoi.DiaChiTraKhach,
                    cuocGoi.PhoneNumber, cuocGoi.Vung, cuocGoi.LoaiXe, cuocGoi.SoLuong,
                    cuocGoi.TrangThaiCuocGoi, cuocGoi.KieuCuocGoi, cuocGoi.LenhDienThoai,
                    cuocGoi.TrangThaiLenh, cuocGoi.GhiChuDienThoai, cuocGoi.MaNhanVienDienThoai,
                    cuocGoi.ThoiDiemChuyenTongDai, cuocGoi.GPS_KinhDo, cuocGoi.GPS_ViDo,
                    cuocGoi.DanhSachXeDeCu, cuocGoi.DanhSachXeDeCu_TD, ((change != null && change.XeDon) ? CharCheckChange : cuocGoi.XeDon),
                    cuocGoi.KieuKhachHangGoiDen, cuocGoi.LoaiCuocKhach, cuocGoi.FT_IsFT,
                    cuocGoi.FT_Date, cuocGoi.FT_SendDate, cuocGoi.FT_Status, cuocGoi.BookId, (int)cuocGoi.G5_Type,
                    cuocGoi.SanBay_DuongDai, cuocGoi.G5_CarType, ((change != null && change.XeNhan) ? CharCheckChange : cuocGoi.XeNhan));
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("G5_DIENTHOAI_UpdateThongTinCuocGoi", ex);
                return false;
            }
        }

        public static bool G5_DIENTHOAI_UpdateLenhCuocSB(CuocGoi cg)
        {
            try
            {
                return new Data.CuocGoi().G5_DIENTHOAI_UpdateLenhCuocSB(cg.IDCuocGoi, cg.LenhTongDai, cg.TrangThaiLenh, cg.TrangThaiCuocGoi);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("G5_DIENTHOAI_UpdateLenhCuocSB", ex);
                return false;
            }
        }
       
        public static bool G5_DIENTHOAI_UpdateThongTinCuocGoi_V2(CuocGoi cuocGoi, CheckChange change = null, bool isDieuApp = false)
        {
            try
            {
                if (Config_Common.NhapTuyenDuongDai)
                    return new Data.CuocGoi().G5_DienThoai_UpdateThongTinCuocGoi_V3(
                        cuocGoi.IDCuocGoi,
                        // ((change != null && change.DiaChiDon) ? CharCheckChange : cuocGoi.DiaChiDonKhach), ((change != null && change.DiaChiTra) ? CharCheckChange : cuocGoi.DiaChiTraKhach),
                        cuocGoi.DiaChiDonKhach,
                        cuocGoi.DiaChiTraKhach,
                        cuocGoi.PhoneNumber, cuocGoi.Vung, cuocGoi.LoaiXe, cuocGoi.SoLuong,
                        cuocGoi.TrangThaiCuocGoi, cuocGoi.KieuCuocGoi, cuocGoi.LenhDienThoai,
                        cuocGoi.TrangThaiLenh, cuocGoi.GhiChuDienThoai, cuocGoi.MaNhanVienDienThoai,
                        cuocGoi.ThoiDiemChuyenTongDai, cuocGoi.GPS_KinhDo, cuocGoi.GPS_ViDo,
                        cuocGoi.DanhSachXeDeCu, cuocGoi.DanhSachXeDeCu_TD,
                        ((change != null && change.XeDon) ? CharCheckChange : cuocGoi.XeDon),
                        cuocGoi.KieuKhachHangGoiDen, cuocGoi.LoaiCuocKhach, cuocGoi.FT_IsFT,
                        cuocGoi.FT_Date, cuocGoi.FT_SendDate, cuocGoi.FT_Status, cuocGoi.BookId, (int)cuocGoi.G5_Type,
                        cuocGoi.SanBay_DuongDai, cuocGoi.G5_CarType,
                        ((change != null && change.XeNhan) ? CharCheckChange : cuocGoi.XeNhan),
                        cuocGoi.ThoiGianHen == DateTime.MinValue ? cuocGoi.ThoiDiemGoi : cuocGoi.ThoiGianHen,
                        cuocGoi.MoneyTrip,
                        cuocGoi.Long_TuyenID,
                        cuocGoi.Long_ChieuID,
                        cuocGoi.Long_LoaiXeID,
                        cuocGoi.Long_GiaTien,
                        cuocGoi.Long_Km,
                        cuocGoi.Long_ThoiGian,
                        cuocGoi.GPS_KinhDo_Tra,
                        cuocGoi.GPS_ViDo_Tra,
                        isDieuApp,
                        cuocGoi.DiaChiGoi
                        );
                else
                    return new Data.CuocGoi().G5_DIENTHOAI_UpdateThongTinCuocGoi_V2(
                        cuocGoi.IDCuocGoi,
                        // ((change != null && change.DiaChiDon) ? CharCheckChange : cuocGoi.DiaChiDonKhach), ((change != null && change.DiaChiTra) ? CharCheckChange : cuocGoi.DiaChiTraKhach),
                        cuocGoi.DiaChiDonKhach,
                        cuocGoi.DiaChiTraKhach,
                        cuocGoi.PhoneNumber, cuocGoi.Vung, cuocGoi.LoaiXe, cuocGoi.SoLuong,
                        cuocGoi.TrangThaiCuocGoi, cuocGoi.KieuCuocGoi, cuocGoi.LenhDienThoai,
                        cuocGoi.TrangThaiLenh, cuocGoi.GhiChuDienThoai, cuocGoi.MaNhanVienDienThoai,
                        cuocGoi.ThoiDiemChuyenTongDai, cuocGoi.GPS_KinhDo, cuocGoi.GPS_ViDo,
                        cuocGoi.DanhSachXeDeCu, cuocGoi.DanhSachXeDeCu_TD,
                        ((change != null && change.XeDon) ? CharCheckChange : cuocGoi.XeDon),
                        cuocGoi.KieuKhachHangGoiDen, cuocGoi.LoaiCuocKhach, cuocGoi.FT_IsFT,
                        cuocGoi.FT_Date, cuocGoi.FT_SendDate, cuocGoi.FT_Status, cuocGoi.BookId, (int) cuocGoi.G5_Type,
                        cuocGoi.SanBay_DuongDai, cuocGoi.G5_CarType,
                        ((change != null && change.XeNhan) ? CharCheckChange : cuocGoi.XeNhan),
                        cuocGoi.ThoiGianHen == DateTime.MinValue ? cuocGoi.ThoiDiemGoi : cuocGoi.ThoiGianHen,
                        cuocGoi.MoneyTrip,
                        cuocGoi.GPS_KinhDo_Tra,
                        cuocGoi.GPS_ViDo_Tra,
                        isDieuApp);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("G5_DIENTHOAI_UpdateThongTinCuocGoi_V2", ex);
                return false;
            }
        }

        public static bool G5_DIENTHOAI_UpdateGhiChuDTV_ByBookId(long idCuocGoi, Guid bookId, string GhiChuDTV)
        {
            try
            {
                return new Data.CuocGoi().G5_DIENTHOAI_UpdateGhiChuDTV_ByBookId(bookId, idCuocGoi, GhiChuDTV);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("G5_DIENTHOAI_CopyCuocGoi", ex);
                return false;
            }
        }
        public static bool G5_DIENTHOAI_CopyCuocGoi(long idCuocGoi, Enum_G5_Type G5Type)
        {
            try
            {
                return new Data.CuocGoi().G5_DIENTHOAI_CopyCuocGoi(idCuocGoi, (int)G5Type);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("G5_DIENTHOAI_CopyCuocGoi", ex);
                return false;
            }
        }
        public static bool G5_DIENTHOAI_UpdateBookIdByIdCuocGoi(Guid bookId, long idCuocGoi, Enum_G5_Type type, string LenhDTV)
        {
            try
            {
                return new Data.CuocGoi().G5_DIENTHOAI_UpdateBookIdByIdCuocGoi(bookId, idCuocGoi, (int)type, LenhDTV);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("G5_DIENTHOAI_UpdateBookIdByIdCuocGoi", ex);
                return false;
            }
        }
        public static bool G5_DIENTHOAI_UpdateBookTimeout(Guid bookId)
        {
            try
            {
                return new Data.CuocGoi().G5_DIENTHOAI_UpdateBookTimeout(bookId);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("G5_DIENTHOAI_UpdateBookTimeout", ex);
                return false;
            }
        }

        public static bool G5_DIENTHOAI_UpdateLenhMoiKhach(long idCuocGoi, string lenhDTV)
        {
            try
            {
                return new Data.CuocGoi().G5_DIENTHOAI_UpdateLenhMoiKhach(idCuocGoi, lenhDTV);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("G5_DIENTHOAI_UpdateLenhMoiKhach", ex);
                return false;
            }
        }
        /// <summary>
        /// Kiểm tra trùng địa chỉ đón khách trên các cuốc hiện tại chưa kết thúc
        /// </summary>
        /// <param name="idCuocGoi">Id Cuốc gọi</param>
        /// <param name="diaChiDon">Địa chỉ đón</param>
        /// <param name="soDienThoai">Ref Trả về số điện thoại của đường</param>
        /// <returns></returns>
        public static bool G5_DIENTHOAI_CheckTrungDiaChiDon(long idCuocGoi, string diaChiDon, ref string soDienThoai)
        {
            try
            {
                soDienThoai = new Data.CuocGoi().G5_DIENTHOAI_CheckTrungDiaChiDon(idCuocGoi, diaChiDon);
                if (soDienThoai != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("G5_DIENTHOAI_CheckTrungDiaChiDon", ex);
                return false;
            }
        }
        #endregion
        #endregion

        #region --------------- Tổng đài ------------------

        #region *********** Lấy dữ liệu ***********
        public static List<CuocGoi> G5_TONGDAI_LayAllCuocGoi(string vungsDuocCapPhep, ref List<CuocGoi> lstCuocGoi_ChuaNhan)
        {
            var listCuocGoi = new List<CuocGoi>();
            var ds = new Data.CuocGoi().G5_TONGDAI_LayAllCuocGoi(vungsDuocCapPhep);
            if (ds.Tables.Count > 0)
            {
                using (var dtCuocGoiDaNhan = ds.Tables[0])
                {
                    if (dtCuocGoiDaNhan != null && dtCuocGoiDaNhan.Rows.Count > 0)
                    {
                        listCuocGoi.AddRange(from DataRow dr in dtCuocGoiDaNhan.Rows select GetCuocGoiByDataRow(dr));
                    }
                }
                if (Global.GridConfig_CuocGoi == Grid_Config.Has_Grid_Bottom)
                {
                    using (var dtCuocGoiChuaNhan = ds.Tables[1])
                    {
                        if (dtCuocGoiChuaNhan != null && dtCuocGoiChuaNhan.Rows.Count > 0)
                        {
                            lstCuocGoi_ChuaNhan.AddRange(from DataRow dr in dtCuocGoiChuaNhan.Rows select GetCuocGoiByDataRow(dr));
                        }
                    }
                }
            }
            return listCuocGoi;
        }
        public static List<CuocGoi> G5_TONGDAI_LayAllCuocGoiNotFT(string vungsDuocCapPhep, ref List<CuocGoi> lstCuocGoi_ChuaNhan)
        {
            var listCuocGoi = new List<CuocGoi>();
            var ds = new Data.CuocGoi().G5_TONGDAI_LayAllCuocGoiNotFT(vungsDuocCapPhep);
            if (ds.Tables.Count > 0)
            {
                using (var dtCuocGoiDaNhan = ds.Tables[0])
                {
                    if (dtCuocGoiDaNhan != null && dtCuocGoiDaNhan.Rows.Count > 0)
                    {
                        listCuocGoi.AddRange(from DataRow dr in dtCuocGoiDaNhan.Rows select GetCuocGoiByDataRow(dr));
                    }
                }
                if (Global.GridConfig_CuocGoi ==Grid_Config.Has_Grid_Bottom)
                {
                    using (var dtCuocGoiChuaNhan = ds.Tables[1])
                    {
                        if (dtCuocGoiChuaNhan != null && dtCuocGoiChuaNhan.Rows.Count > 0)
                        {
                            lstCuocGoi_ChuaNhan.AddRange(from DataRow dr in dtCuocGoiChuaNhan.Rows select GetCuocGoiByDataRow(dr));
                        }
                    }
                }
            }
            return listCuocGoi;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vungsDuocCapPhep"></param>
        /// <param name="soDong"></param>
        /// <returns></returns>
        public static List<CuocGoi> G5_TONGDAI_LayCuocGoiDaGiaiQuyet(string vungsDuocCapPhep, int soDong)
        {
            var listCuocGoi = new List<CuocGoi>();
            using (DataTable dt = new Data.CuocGoi().G5_TONGDAI_LayCuocGoiDaGiaiQuyet(vungsDuocCapPhep, soDong))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    listCuocGoi.AddRange(from DataRow dr in dt.Rows select GetCuocGoiByDataRow(dr));
                }
            }
            //for (int i = 0; i < listCuocGoi.Count(); i++)
            //{
            //    if (listCuocGoi[i].DiaChiDonKhach==listCuocGoi[0].DiaChiDonKhach)
            //    {
            //        listCuocGoi.Insert(0, listCuocGoi[i]);
            //        listCuocGoi.RemoveAt(i);
            //    }
            //}
            return listCuocGoi;
        }
        public static List<CuocGoi> G5_TONGDAI_LayCuocGoiDaGiaiQuyetNotFT(string vungsDuocCapPhep, int soDong)
        {
            var listCuocGoi = new List<CuocGoi>();
            using (DataTable dt = new Data.CuocGoi().G5_TONGDAI_LayCuocGoiDaGiaiQuyetNotFT(vungsDuocCapPhep, soDong))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    listCuocGoi.AddRange(from DataRow dr in dt.Rows select GetCuocGoiByDataRow(dr));
                }
            }
            return listCuocGoi;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vungsDuocCapPhep"></param>
        /// <param name="thoiDiemLayDuLieuTruoc"></param>
        /// <returns></returns>
        public static List<CuocGoi> G5_TONGDAI_LayCuocGoiDaNhanXuLy(string vungsDuocCapPhep, DateTime thoiDiemLayDuLieuTruoc)
        {
            var listCuocGoi = new List<CuocGoi>();
            using (var dt = new Data.CuocGoi().G5_TONGDAI_LayCuocGoiDaNhanXuLy(vungsDuocCapPhep, thoiDiemLayDuLieuTruoc))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    listCuocGoi.AddRange(from DataRow dr in dt.Rows select GetCuocGoiByDataRow(dr));
                }
            }
            return listCuocGoi;
        }
        /// <summary>
        /// Lấy các cuốc đã nhận xử lý không phải là FT
        /// </summary>
        /// <param name="vungsDuocCapPhep"></param>
        /// <param name="thoiDiemLayDuLieuTruoc"></param>
        /// <returns></returns>
        public static List<CuocGoi> G5_TONGDAI_LayCuocGoiDaNhanXuLyNotFT(string vungsDuocCapPhep, DateTime thoiDiemLayDuLieuTruoc)
        {
            var listCuocGoi = new List<CuocGoi>();
            using (var dt = new Data.CuocGoi().G5_TONGDAI_LayCuocGoiDaNhanXuLyNotFT(vungsDuocCapPhep, thoiDiemLayDuLieuTruoc))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    listCuocGoi.AddRange(from DataRow dr in dt.Rows select GetCuocGoiByDataRow(dr));
                }
            }
            return listCuocGoi;
        }
        public static List<CuocGoi> G5_TONGDAI_LayCuocGoiMoiTuDienThoai(string vungsDuocCapPhep, DateTime thoiDiemLayDuLieuTruoc)
        {
            var listCuocGoi = new List<CuocGoi>();
            using (var dt = new Data.CuocGoi().G5_TONGDAI_LayCuocGoiMoiTuDienThoai(vungsDuocCapPhep, thoiDiemLayDuLieuTruoc))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    listCuocGoi.AddRange(from DataRow dr in dt.Rows select GetCuocGoiByDataRow(dr));
                }
            }
            return listCuocGoi;
        }
        /// <summary>
        /// Lấy dữ cuốc không phải là FT.
        /// </summary>
        /// <param name="vungsDuocCapPhep"></param>
        /// <param name="thoiDiemLayDuLieuTruoc"></param>
        /// <returns></returns>
        public static List<CuocGoi> G5_TONGDAI_LayCuocGoiMoiTuDienThoaiNotFT(string vungsDuocCapPhep, DateTime thoiDiemLayDuLieuTruoc)
        {
            var listCuocGoi = new List<CuocGoi>();
            using (var dt = new Data.CuocGoi().G5_TONGDAI_LayCuocGoiMoiTuDienThoaiNotFT(vungsDuocCapPhep, thoiDiemLayDuLieuTruoc))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    listCuocGoi.AddRange(from DataRow dr in dt.Rows select GetCuocGoiByDataRow(dr));
                }
            }
            return listCuocGoi;
        }
        #endregion

        #region *********** Cập nhật dữ liệu ******
        public static bool G5_TONGDAI_UpdateThongTinCuocGoi(CuocGoi cuocGoi, CheckChange change = null)
        {
            return new Data.CuocGoi().G5_TONGDAI_UpdateThongTinCuocGoi(cuocGoi.IDCuocGoi, cuocGoi.TrangThaiCuocGoi, cuocGoi.LenhTongDai,
                                                                    cuocGoi.GhiChuTongDai, cuocGoi.TrangThaiLenh, cuocGoi.MaNhanVienTongDai, ((change != null && change.XeNhan) ? CharCheckChange : cuocGoi.XeNhan),
                                                                   ((change != null && change.XeDon) ? CharCheckChange : cuocGoi.XeDon), ((change != null && change.DiaChiTra) ? CharCheckChange : cuocGoi.DiaChiTraKhach), cuocGoi.ThoiGianDieuXe, cuocGoi.ThoiGianDonKhach,
                                                                    cuocGoi.ChuyenMK, cuocGoi.XeDenDiem, ((change != null && change.DiaChiDon) ? CharCheckChange : cuocGoi.DiaChiDonKhach), cuocGoi.XeDungDiem, cuocGoi.BTBG_NoiDungXuLy);
        }

        #endregion
        #endregion
        #endregion

        public const string CharCheckChange = "-@-";
        public class CheckChange
        {
            public bool DiaChiDon { get; set; }
            public bool DiaChiTra { get; set; }
            public bool XeDon { get; set; }
            public bool XeNhan { get; set; }
        }

        public class ThongTinGoiLai
        {
            public string BookId { get; set; }
            public string XeNhan { get; set; }
            public string G5_Type { get; set; }
            public string XeDungDiem { get; set; }
        }



        
    }
}
