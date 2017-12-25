using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Taxi.Utils;
using Taxi.Utils;
using Taxi.Business.DM;
using System.Linq;

namespace Taxi.Business
{
    public class BaoCaoBieuMau3
    {
        #region Members & Properties
        //@ID bigint,
        private long mID_DieuHanh;
        public long ID_DieuHanh
        {
            get { return mID_DieuHanh; }
            set { mID_DieuHanh = value; }
        }
        //@Line char(2),
        private string mLine;
        public string LenhLaiXe { get; set; }
        public int G5_Type { get; set; }
   
        public string GetG5_Type {
            get
            {
                if (BookId==null||BookId==Guid.Empty)
                {
                    return "Điều đàm";
                }
                else if (G5_Type == 1)
                {
                    return "Chuyển đàm";
                }
                else if (G5_Type == 2)
                {
                    return "Cuốc app không xe";
                }
                else if (G5_Type == 3)
                {
                    return "Điều app";
                }
                else return "None";
            ;}
        }
        public DateTime G5_SendDate { get; set; }

        public string GetG5_SendDate
        {
            get { return (G5_SendDate==null|| G5_SendDate.Year < 2000) ? string.Empty : G5_SendDate.ToString("HH:mm:ss dd/MM/yyyy"); }
        }
        public string Line
        {
            get { return mLine; }
            set { mLine = value; }
        }
        //@PhoneNumber char(15),
        private string mPhoneNumber;

        public string PhoneNumber
        {
            get { return mPhoneNumber; }
            set { mPhoneNumber = value; }
        }
        //@ThoiDiemGoi datetime,
        private DateTime mThoiDiemGoi;

        public DateTime ThoiDiemGoi
        {
            get { return mThoiDiemGoi; }
            set { mThoiDiemGoi = value; }
        }

        //@ThoiDiemGoi datetime,
        private string mstrThoiDiemGoi;

        public string strThoiDiemGoi
        {
            get { return ThoiDiemGoi.ToString("HH:mm:ss dd/MM/yyyy"); }
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

        private int mThoiDiemChuyenTongDai;

        public int ThoiDiemChuyenTongDai
        {
            get { return mThoiDiemChuyenTongDai; }
            set { mThoiDiemChuyenTongDai = value; }
        }
        public string HienThiThoiDiemChuyenTongDai
        {
            get { return StringTools.ConvertSoGiay_PhutGiay(ThoiDiemChuyenTongDai); }
        }
        //@ThoiDiemKetThucGoi datetime,
        private DateTime mThoiDiemKetThucGoi;

        public DateTime ThoiDiemKetThucGoi
        {
            get { return mThoiDiemKetThucGoi; }
            set { mThoiDiemKetThucGoi = value; }
        }


        private int mSoLuotDoChuong;
        /// <summary>
        /// SO luot do chuong cua mot cuoc gio lau
        /// </summary>
        public int SoLuotDoChuong
        {
            get { return mSoLuotDoChuong; }
            set { mSoLuotDoChuong = value; }
        }

        //@DiaChiGoi nvarchar(255),
        private string mDiaChiGoi;

        public string DiaChiGoi
        {
            get { return mDiaChiGoi; }
            set { mDiaChiGoi = value; }
        }

        //@DiaChiDonKhach nvarchar(255),
        private string mDiaChiDonKhach;
        public string DiaChiDonKhach
        {
            get { return mDiaChiDonKhach; }
            set { mDiaChiDonKhach = value; }
        }
        private KieuKhachHangGoiDen mKieuKhachHangGoiDen;
        /// <summary>
        /// Kieu khach hang goi den
        /// </summary>
        public KieuKhachHangGoiDen KieuKhachHangGoiDen
        {
            get { return mKieuKhachHangGoiDen; }
            set { mKieuKhachHangGoiDen = value; }
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
        /// <summary>
        /// Loai xe 4 cho, 7 cho , 0
        /// </summary>
        private string mLoaiXe;
        public string LoaiXe
        {
            get { return mLoaiXe; }
            set { mLoaiXe = value; }
        }
        /// <summary>
        /// So luong xe khach cho di
        /// </summary>
        private string mSoLuong;
        public string SoLuong
        {
            get { return mSoLuong; }
            set { mSoLuong = value; }
        }


        //@ChonTaxi4Cho char(1),
        private bool mChonTaxi4Cho;
        public bool ChonTaxi4Cho
        {
            get { return mChonTaxi4Cho; }
            set { mChonTaxi4Cho = value; }
        }
        private bool mChonTaxi7Cho;

        public bool ChonTaxi7Cho
        {
            get { return mChonTaxi7Cho; }
            set { mChonTaxi7Cho = value; }
        }
        private bool mSanBay_DuongDai;
        public bool SanBay_DuongDai
        {
            get { return mSanBay_DuongDai; }
            set { mSanBay_DuongDai = value; }
        }
        //@Vung int,
        private string mMaVung;
        public string MaVung
        {
            get { return mMaVung; }
            set { mMaVung = value; }
        }
        /// <summary>
        /// Lenh tong dai nhap de gi di
        /// </summary>
        private string mLenhDienThoai;
        public string LenhDienThoai
        {
            get { return mLenhDienThoai; }
            set { mLenhDienThoai = value; }
        }

        private string mLenhTongDai;
        /// <summary>
        /// Lenh tong dai nhap de gi sang ben dien thoai
        /// </summary>
        public string LenhTongDai
        {
            get { return mLenhTongDai; }
            set { mLenhTongDai = value; }
        }

        private string mCuocGoiKhongThanhCong;

        public string CuocGoiKhongThanhCong
        {
            get { return mCuocGoiKhongThanhCong; }
            set { mCuocGoiKhongThanhCong = value; }
        }
        private string mMaNhanVienDienThoai;

        public string MaNhanVienDienThoai
        {
            get { return mMaNhanVienDienThoai; }
            set { mMaNhanVienDienThoai = value; }
        }
        private string mMaNhanVienTongDai;

        public string MaNhanVienTongDai
        {
            get { return mMaNhanVienTongDai; }
            set { mMaNhanVienTongDai = value; }
        }
        public string NhanVien
        {
            get { return mMaNhanVienDienThoai + "-" + mMaNhanVienTongDai; }
        }
        private string mXeNhan;
        /// <summary>
        /// Nhung xe nhan don khach
        /// </summary>
        public string XeNhan
        {
            get { return mXeNhan; }
            set { mXeNhan = value; }
        }

        private string mXeDon;
        /// <summary>
        /// Xe don duoc khach
        /// </summary>
        public string XeDon
        {
            get { return mXeDon; }
            set { mXeDon = value; }
        }
        private string mDiaChiTraKhach;

        public string DiaChiTraKhach
        {
            get { return mDiaChiTraKhach; }
            set { mDiaChiTraKhach = value; }
        }
        private string mGhiChuDienThoai;

        public string GhiChuDienThoai
        {
            get { return mGhiChuDienThoai; }
            set { mGhiChuDienThoai = value; }
        }
        private string mGhiChuTongDai;

        public string GhiChuTongDai
        {
            get { return mGhiChuTongDai; }
            set { mGhiChuTongDai = value; }
        }

        public string GhiChu
        {
            get { return mGhiChuTongDai + mGhiChuDienThoai; }
        }

        private TrangThaiLenhTaxi mTrangThaiLenh;
        /// <summary>
        /// Trang thai lenh 
        /// KhongTruyenDi = 0,
        /// DienThoai =1,
        /// BoDam=2,
        /// KetThuc =3,
        /// KetThucCuaDienThoai=4, 
        /// </summary>
        public TrangThaiLenhTaxi TrangThaiLenh
        {
            get { return mTrangThaiLenh; }
            set { mTrangThaiLenh = value; }
        }

        //@ThoiGianDieuXe int,
        private int mThoiGianDieuXe;
        /// <summary>
        /// 
        /// </summary>
        public int ThoiGianDieuXe
        {
            get { return mThoiGianDieuXe; }
            set { mThoiGianDieuXe = value; }
        }
        public string HienThiThoiGianDieuXe
        {
            get { return StringTools.ConvertSoGiay_PhutGiay(ThoiGianDieuXe); }
        }
        //@ThoiGianDonKhach int,
        private int mThoiGianDonKhach;

        public int ThoiGianDonKhach
        {
            get { return mThoiGianDonKhach; }
            set { mThoiGianDonKhach = value; }
        }
        public string HienThiThoiGianDonKhach 
        {
            get { return StringTools.ConvertSoGiay_PhutGiay(ThoiGianDonKhach); }
        }
        //@TongThoiGianDamThoai int,
        private DateTime mDoDaiCuocGoi;
        /// <summary>
        /// TInh theo so phut
        /// </summary>
        public DateTime  DoDaiCuocGoi
        {
            get { return mDoDaiCuocGoi; }
            set { mDoDaiCuocGoi = value; }
        }
        private string mstrDoDaiCuocGoi;

        public string strDoDaiCuocGoi
        {
            get { return DoDaiCuocGoi.ToString("HH:mm:ss"); }
        }
        private TrangThaiCuocGoiTaxi mTrangThaiCuocGoi;
        /// <summary>
        /// Trang thai cuoc gio
        ///  CuocGoiTaxi = 0, // gồm CuocGoiDonDuocKhach,CuocGoiTruot,CuocGoiHoan,CuocGoiKhongXe
        /// CuocGoiLai = 1,
        /// CuocGoiKhac = 2,
        /// CuocGoiDonDuocKhach = 3,
        /// CuocGoiTruot = 4,
        /// CuocGoiHoan = 5,
        /// CuocGoiKhongXe = 6,   
        /// </summary>
        public TrangThaiCuocGoiTaxi TrangThaiCuocGoi
        {
            get { return mTrangThaiCuocGoi; }
            set { mTrangThaiCuocGoi = value; }
        }

        private string mCuocGoiLaiIDs;

        public string CuocGoiLaiIDs
        {
            get { return mCuocGoiLaiIDs; }
            set { mCuocGoiLaiIDs = value; }
        }
        private string mThongTinGoiLai;
        /// <summary>
        /// Thông tin goi lai duoc luu duoi dang
        /// L1: HH:mm:ss; L2: HH:MM:ss
        /// </summary>
        public string ThongTinGoiLai
        {
            get { return mThongTinGoiLai; }
            set { mThongTinGoiLai = value; }
        }

        private bool mDonDuocKhach;

        public bool DonDuocKhach
        {
            get { return mDonDuocKhach; }
            set { mDonDuocKhach = value; }
        }
        private bool mTruotKhach;

        public bool TruotKhach
        {
            get { return mTruotKhach; }
            set { mTruotKhach = value; }
        }
        private bool mKhachHoan;

        public bool KhachHoan
        {
            get { return mKhachHoan; }
            set { mKhachHoan = value; }
        }
        private bool mKhongXe;

        public bool KhongXe
        {
            get { return mKhongXe; }
            set { mKhongXe = value; }
        }
        private string mFileVoicePath;

        public string FileVoicePath
        {
            get { return mFileVoicePath; }
            set { mFileVoicePath = value; }
        }
        public string HienThiDoDaiCuocGoi
        {
            get { return string.Format("{0: mm:ss}", DoDaiCuocGoi); }
        }
        private string _phanLoai;

        public string PhanLoai
        {
            get { return _phanLoai; }
            set { _phanLoai = value; }
        }
        private string _ketQua;

        public string KetQua
        {
            get { return _ketQua; }
            set { _ketQua = value; }
        }
        private string _MOIKHACH_NhanVien;

        public string MOIKHACH_NhanVien
        {
            get { return _MOIKHACH_NhanVien; }
            set { _MOIKHACH_NhanVien = value; }
        }

        private string _MOIKHACH_LenhMoiKhach;

        public string MOIKHACH_LenhMoiKhach
        {
            get { return _MOIKHACH_LenhMoiKhach; }
            set { _MOIKHACH_LenhMoiKhach = value; }
        }

        private string mXeDenDiem;
        public string XeDenDiem
        {
            get { return mXeDenDiem; }
            set { mXeDenDiem = value; }
        }

        private string mDanhSachXe_DeCu;
        public string DanhSachXe_DeCu
        {
            get { return mDanhSachXe_DeCu; }
            set { mDanhSachXe_DeCu = value; }
        }
        /// <summary>
        /// Thời gian mời khách
        /// </summary>
        public int ThoiGianMoiKhach { get; set; }
        public DateTime ThoiDiemThayDoiDuLieu { get; set; }
        public string strThoiDiemThayDoiDuLieu
        {
            get { return ThoiDiemThayDoiDuLieu.ToString("HH:mm:ss dd/MM/yyyy"); }
        }
        public string BTBG_NhanVien { get; set; }
        public DateTime BTBG_ThoiDiemXuLy { get; set; }
        public string BTBG_NoiDungXuLy { get; set; }
        public bool BTBG_IsDaXuLy { get; set; }
        public DateTime MOIKHACH_XinLoi_ThoiDiem { get; set; }
        public bool MOIKHACH_KhieuNai_DaXyLy { get; set; }
        public string MOIKHACH_KhieuNai_ThongTinThem { get; set; }
        public DateTime MOIKHACH_ThoiDiemMoi_Giu { get; set; }
        public bool MOIKHACH_XinLoi_DaXinLoi { get; set; }
        public Guid BookId { get; set; }
        public string XeDungDiem { get; set; }
        #endregion Members & Properties

        public BaoCaoBieuMau3()
        {
        }
    }

    public class BacCao_CuocGoiMoiGioi
    {
        private string mMaKhachHang;

        public string MaKhachHang
        {
            get { return mMaKhachHang; }
            set { mMaKhachHang = value; }
        }
        private string mTenKhachHang;

        public string TenKhachHang
        {
            get { return mTenKhachHang; }
            set { mTenKhachHang = value; }
        }
        private string mDiaChi;

        public string DiaChi
        {
            get { return mDiaChi; }
            set { mDiaChi = value; }
        }
        private string mDienThoais;

        public string DienThoais
        {
            get { return mDienThoais; }
            set { mDienThoais = value; }
        }
        private DateTime mNgay;

        public DateTime Ngay
        {
            get { return mNgay; }
            set { mNgay = value; }
        }

        private int mTongCuocGoi;

        public int TongCuocGoi
        {
            get { return mTongCuocGoi; }
            set { mTongCuocGoi = value; }
        }
        private int mCuocGoiDonDuoc;

        public int CuocGoiDonDuoc
        {
            get { return mCuocGoiDonDuoc; }
            set { mCuocGoiDonDuoc = value; }
        }
        private int mCuocGoiTruot;

        public int CuocGoiTruot
        {
            get { return mCuocGoiTruot; }
            set { mCuocGoiTruot = value; }
        }
        private int mCuocGoiHoan;

        public int CuocGoiHoan
        {
            get { return mCuocGoiHoan; }
            set { mCuocGoiHoan = value; }
        }
        private int mCuocGoiKhongXe;

        public int CuocGoiKhongXe
        {
            get { return mCuocGoiKhongXe; }
            set { mCuocGoiKhongXe = value; }
        }
        private int mSoChuyen;

        public int SoChuyen
        {
            get { return mSoChuyen; }
            set { mSoChuyen = value; }
        }
        /// <summary>
        /// phan tram don duoc = (DonDuoc/(DonDuoc+Truot+Hoan+KhongXe)*100)
        /// </summary>
        private double mPhanTramDonDuoc;

        public double PhanTramDonDuoc
        {
            get {  
                 if((CuocGoiDonDuoc + CuocGoiHoan + CuocGoiTruot + CuocGoiKhongXe)>0)
                     return (CuocGoiDonDuoc / (CuocGoiDonDuoc + CuocGoiHoan + CuocGoiTruot + CuocGoiKhongXe)) / 100;
                 return 0; 
            }
            //set { mPhanTramFonDuoc = value; }
        }
        private string mMaNhanVien;

        public string MaNhanVien
        {
            get { return mMaNhanVien; }
            set { mMaNhanVien = value; }
        }
 

        private string _GhiChu;

        public string GhiChu
        {
            get { return _GhiChu; }
            set { _GhiChu = value; }
        }
        private int _CongTyID;

        public int CongTyID
        {
            get { return _CongTyID; }
            set { _CongTyID = value; }
        }
        public BacCao_CuocGoiMoiGioi()
        {
        }


    }

    public class BaoCao_BieuMau8
    {
        private string mNgay;

        public string Ngay
        {
            get { return mNgay; }
            set { mNgay = value; }
        }
        private string mGio;

        public string Gio
        {
            get { return mGio; }
            set { mGio = value; }
        }
        private string mXeDon;

        public string XeDon
        {
            get { return mXeDon; }
            set { mXeDon = value; }
        }
        private string mSoChuyen;

        public string SoChuyen
        {
            get { return mSoChuyen; }
            set { mSoChuyen = value; }
        }
        private int _iSoChuyen;

        public int iSoChuyen
        {
            get { return _iSoChuyen; }
            set { _iSoChuyen = value; }
        }
        private bool mTruot;

        public bool Truot
        {
            get { return mTruot; }
            set { mTruot = value; }
        }
        private bool mHoan;

        public bool Hoan
        {
            get { return mHoan; }
            set { mHoan = value; }
        }
        private bool mKhongXe;

        public bool KhongXe
        {
            get { return mKhongXe; }
            set { mKhongXe = value; }
        }
        private string mPhoneNumber;

        public string PhoneNumber
        {
            get { return mPhoneNumber; }
            set { mPhoneNumber = value; }
        }

        private string mDiaChiDon;

        public string DiaChiDon
        {
            get { return mDiaChiDon; }
            set { mDiaChiDon = value; }
        }
    }

    public class   BacCao_MoiGioiThang_BC09
    {
        private string mMaKhachHang;

        public string MaKhachHang
        {
            get { return mMaKhachHang; }
            set { mMaKhachHang = value; }
        }
        private string mTenKhachHang;

        public string TenKhachHang
        {
            get { return mTenKhachHang; }
            set { mTenKhachHang = value; }
        }
        private string mDiaChi;

        public string DiaChi
        {
            get { return mDiaChi; }
            set { mDiaChi = value; }
        }
        private string mDienThoais;

        public string DienThoais
        {
            get { return mDienThoais; }
            set { mDienThoais = value; }
        }
        //01
        private int mThang01;

        public int Thang01
        {
            get { return mThang01; }
            set { mThang01 = value; }
        }

        private int mThang02;

        public int Thang02
        {
            get { return mThang02; }
            set { mThang02 = value; }
        }
        //03
        private int mThang03;

        public int Thang03
        {
            get { return mThang03; }
            set { mThang03 = value; }
        }
        //04
        private int mThang04;

        public int Thang04
        {
            get { return mThang04; }
            set { mThang04 = value; }
        }
        //05
        private int mThang05;

        public int Thang05
        {
            get { return mThang05; }
            set { mThang05 = value; }
        }
        //6
        private int mThang06;

        public int Thang06
        {
            get { return mThang06; }
            set { mThang06 = value; }
        }
        //7
        private int mThang07;

        public int Thang07
        {
            get { return mThang07; }
            set { mThang07 = value; }
        }
        //8
        private int mThang08;

        public int Thang08
        {
            get { return mThang08; }
            set { mThang08 = value; }
        }
        //9
        private int mThang09;

        public int Thang09
        {
            get { return mThang09; }
            set { mThang09 = value; }
        }
        //10
        private int mThang10;

        public int Thang10
        {
            get { return mThang10; }
            set { mThang10 = value; }
        }
        //11
        private int mThang11;

        public int Thang11
        {
            get { return mThang11; }
            set { mThang11 = value; }
        }
        //12
        private int mThang12;

        public int Thang12
        {
            get { return mThang12; }
            set { mThang12 = value; }
        }

        private int mTongSoChuyen;

        public int TongSoChuyen
        {
            get { return mThang01+mThang02+mThang03+mThang04+mThang05+mThang06+mThang07+mThang08+mThang09+mThang10+mThang11+mThang12; } 
        }

        private string mMaNhanVien;

        public string MaNhanVien
        {
            get { return mMaNhanVien; }
            set { mMaNhanVien = value; }
        }

        private string mTenNhanVien;

        public string TenNhanVien
        {
            get { return mTenNhanVien; }
            set { mTenNhanVien = value; }
        }
       
    }

    public class BaoCaoBieuMau14
    {
        #region Members & Properties


        private bool mIs_Hoatdong;
        public bool Is_Hoatdong
        {
            get { return mIs_Hoatdong; }
            set { mIs_Hoatdong = value; }
        }
        private bool mIs_KhongHoatdong;
        public bool Khonghoatdong
        {
            get { return mIs_KhongHoatdong; }
            set { mIs_KhongHoatdong = value; }
        }
        private string mSohieutaxi;
        public string Sohieutaxi
        {
            get { return mSohieutaxi; }
            set { mSohieutaxi = value; }
        }
        private DateTime mGioveGara;
        public DateTime GioveGara
        {
            get { return mGioveGara; }
            set { mGioveGara = value; }
        }

        private DateTime mGiorahoatdong;
        public DateTime Giorahoatdong
        {
            get { return mGiorahoatdong; }
            set { mGiorahoatdong = value; }
        }

        private string mTenlaixe;
        public string Tenlaixe
        {
            get { return mTenlaixe; }
            set { mTenlaixe = value; }
        }
        private string mGhichu;
        public string Ghichu
        {
            get { return mGhichu; }
            set { mGhichu = value; }
        }
        private string mCongTy;

        public string CongTy
        {
            get { return mCongTy; }
            set { mCongTy = value; }
        }

        #endregion Members & Properties
        public BaoCaoBieuMau14()
        {
        }
    }

    public class BaoCaoBieuMau15
    {
        #region Members & Properties

         
        private string mSohieutaxi;
        public string Sohieutaxi
        {
            get { return mSohieutaxi; }
            set { mSohieutaxi = value; }
        }
        
        private string mTenlaixe;
        public string Tenlaixe
        {
            get { return mTenlaixe; }
            set { mTenlaixe = value; }
        }
        private string mDoanMatLienLac;

        public string DoanMatLienLac
        {
            get { return mDoanMatLienLac; }
            set { mDoanMatLienLac = value; }
        }

        private string mThoiDiemDaiGoi;

        public string ThoiDiemDaiGoi
        {
            get { return mThoiDiemDaiGoi; }
            set { mThoiDiemDaiGoi = value; }
        }

        private string mGhichu;
        public string Ghichu
        {
            get { return mGhichu; }
            set { mGhichu = value; }
        }


        #endregion Members & Properties
        public BaoCaoBieuMau15()
        {
        }
    }



    public class BaoCaoLogVung
    {
        #region Members & Properties
        //@ID bigint,
        private long mID_DieuHanh;
        public long ID_DieuHanh
        {
            get { return mID_DieuHanh; }
            set { mID_DieuHanh = value; }
        }
        //@Line char(2),
        private string mLine;

        public string Line
        {
            get { return mLine; }
            set { mLine = value; }
        }
        //@PhoneNumber char(15),
        private string mPhoneNumber;

        public string PhoneNumber
        {
            get { return mPhoneNumber; }
            set { mPhoneNumber = value; }
        }
        //@ThoiDiemGoi datetime,
        private DateTime mThoiDiemGoi;

        public DateTime ThoiDiemGoi
        {
            get { return mThoiDiemGoi; }
            set { mThoiDiemGoi = value; }
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

        private int mThoiDiemChuyenTongDai;

        public int ThoiDiemChuyenTongDai
        {
            get { return mThoiDiemChuyenTongDai; }
            set { mThoiDiemChuyenTongDai = value; }
        }
        public string HienThiThoiDiemChuyenTongDai
        {
            get { return StringTools.ConvertSoGiay_PhutGiay(ThoiDiemChuyenTongDai); }
        }
        //@ThoiDiemKetThucGoi datetime,
        private DateTime mThoiDiemKetThucGoi;

        public DateTime ThoiDiemKetThucGoi
        {
            get { return mThoiDiemKetThucGoi; }
            set { mThoiDiemKetThucGoi = value; }
        }


        private int mSoLuotDoChuong;
        /// <summary>
        /// SO luot do chuong cua mot cuoc gio lau
        /// </summary>
        public int SoLuotDoChuong
        {
            get { return mSoLuotDoChuong; }
            set { mSoLuotDoChuong = value; }
        }

        //@DiaChiGoi nvarchar(255),
        private string mDiaChiGoi;

        public string DiaChiGoi
        {
            get { return mDiaChiGoi; }
            set { mDiaChiGoi = value; }
        }

        //@DiaChiDonKhach nvarchar(255),
        private string mDiaChiDonKhach;
        public string DiaChiDonKhach
        {
            get { return mDiaChiDonKhach; }
            set { mDiaChiDonKhach = value; }
        }
        private KieuKhachHangGoiDen mKieuKhachHangGoiDen;
        /// <summary>
        /// Kieu khach hang goi den
        /// </summary>
        public KieuKhachHangGoiDen KieuKhachHangGoiDen
        {
            get { return mKieuKhachHangGoiDen; }
            set { mKieuKhachHangGoiDen = value; }
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
        /// <summary>
        /// Loai xe 4 cho, 7 cho , 0
        /// </summary>
        private string mLoaiXe;
        public string LoaiXe
        {
            get { return mLoaiXe; }
            set { mLoaiXe = value; }
        }
        /// <summary>
        /// So luong xe khach cho di
        /// </summary>
        private string mSoLuong;
        public string SoLuong
        {
            get { return mSoLuong; }
            set { mSoLuong = value; }
        }


        //@ChonTaxi4Cho char(1),
        private bool mChonTaxi4Cho;
        public bool ChonTaxi4Cho
        {
            get { return mChonTaxi4Cho; }
            set { mChonTaxi4Cho = value; }
        }
        private bool mChonTaxi7Cho;

        public bool ChonTaxi7Cho
        {
            get { return mChonTaxi7Cho; }
            set { mChonTaxi7Cho = value; }
        }
        private bool mSanBay_DuongDai;
        public bool SanBay_DuongDai
        {
            get { return mSanBay_DuongDai; }
            set { mSanBay_DuongDai = value; }
        }
        //@Vung int,
        private string mMaVung;
        public string MaVung
        {
            get { return mMaVung; }
            set { mMaVung = value; }
        }
        /// <summary>
        /// Lenh tong dai nhap de gi di
        /// </summary>
        private string mLenhDienThoai;
        public string LenhDienThoai
        {
            get { return mLenhDienThoai; }
            set { mLenhDienThoai = value; }
        }

        private string mLenhTongDai;
        /// <summary>
        /// Lenh tong dai nhap de gi sang ben dien thoai
        /// </summary>
        public string LenhTongDai
        {
            get { return mLenhTongDai; }
            set { mLenhTongDai = value; }
        }

        private string mCuocGoiKhongThanhCong;

        public string CuocGoiKhongThanhCong
        {
            get { return mCuocGoiKhongThanhCong; }
            set { mCuocGoiKhongThanhCong = value; }
        }
        private string mMaNhanVienDienThoai;

        public string MaNhanVienDienThoai
        {
            get { return mMaNhanVienDienThoai; }
            set { mMaNhanVienDienThoai = value; }
        }
        private string mMaNhanVienTongDai;

        public string MaNhanVienTongDai
        {
            get { return mMaNhanVienTongDai; }
            set { mMaNhanVienTongDai = value; }
        }
        public string NhanVien
        {
            get { return mMaNhanVienDienThoai + "-" + mMaNhanVienTongDai; }
        }
        private string mXeNhan;
        /// <summary>
        /// Nhung xe nhan don khach
        /// </summary>
        public string XeNhan
        {
            get { return mXeNhan; }
            set { mXeNhan = value; }
        }

        private string mXeDon;
        /// <summary>
        /// Xe don duoc khach
        /// </summary>
        public string XeDon
        {
            get { return mXeDon; }
            set { mXeDon = value; }
        }
        private string mDiaChiTraKhach;

        public string DiaChiTraKhach
        {
            get { return mDiaChiTraKhach; }
            set { mDiaChiTraKhach = value; }
        }
        private string mGhiChuDienThoai;

        public string GhiChuDienThoai
        {
            get { return mGhiChuDienThoai; }
            set { mGhiChuDienThoai = value; }
        }
        private string mGhiChuTongDai;

        public string GhiChuTongDai
        {
            get { return mGhiChuTongDai; }
            set { mGhiChuTongDai = value; }
        }

        public string GhiChu
        {
            get { return mGhiChuTongDai + mGhiChuDienThoai; }
        }

        private TrangThaiLenhTaxi mTrangThaiLenh;
        /// <summary>
        /// Trang thai lenh 
        /// KhongTruyenDi = 0,
        /// DienThoai =1,
        /// BoDam=2,
        /// KetThuc =3,
        /// KetThucCuaDienThoai=4, 
        /// </summary>
        public TrangThaiLenhTaxi TrangThaiLenh
        {
            get { return mTrangThaiLenh; }
            set { mTrangThaiLenh = value; }
        }

        //@ThoiGianDieuXe int,
        private int mThoiGianDieuXe;
        /// <summary>
        /// 
        /// </summary>
        public int ThoiGianDieuXe
        {
            get { return mThoiGianDieuXe; }
            set { mThoiGianDieuXe = value; }
        }
        public string HienThiThoiGianDieuXe
        {
            get { return StringTools.ConvertSoGiay_PhutGiay(ThoiGianDieuXe); }
        }
        //@ThoiGianDonKhach int,
        private int mThoiGianDonKhach;

        public int ThoiGianDonKhach
        {
            get { return mThoiGianDonKhach; }
            set { mThoiGianDonKhach = value; }
        }
        public string HienThiThoiGianDonKhach
        {
            get { return StringTools.ConvertSoGiay_PhutGiay(ThoiGianDonKhach); }
        }
        //@TongThoiGianDamThoai int,
        private DateTime mDoDaiCuocGoi;
        /// <summary>
        /// TInh theo so phut
        /// </summary>
        public DateTime DoDaiCuocGoi
        {
            get { return mDoDaiCuocGoi; }
            set { mDoDaiCuocGoi = value; }
        }
        private TrangThaiCuocGoiTaxi mTrangThaiCuocGoi;
        /// <summary>
        /// Trang thai cuoc gio
        ///  CuocGoiTaxi = 0, // gồm CuocGoiDonDuocKhach,CuocGoiTruot,CuocGoiHoan,CuocGoiKhongXe
        /// CuocGoiLai = 1,
        /// CuocGoiKhac = 2,
        /// CuocGoiDonDuocKhach = 3,
        /// CuocGoiTruot = 4,
        /// CuocGoiHoan = 5,
        /// CuocGoiKhongXe = 6,   
        /// </summary>
        public TrangThaiCuocGoiTaxi TrangThaiCuocGoi
        {
            get { return mTrangThaiCuocGoi; }
            set { mTrangThaiCuocGoi = value; }
        }

        private string mCuocGoiLaiIDs;

        public string CuocGoiLaiIDs
        {
            get { return mCuocGoiLaiIDs; }
            set { mCuocGoiLaiIDs = value; }
        }
        private string mThongTinGoiLai;
        /// <summary>
        /// Thông tin goi lai duoc luu duoi dang
        /// L1: HH:mm:ss; L2: HH:MM:ss
        /// </summary>
        public string ThongTinGoiLai
        {
            get { return mThongTinGoiLai; }
            set { mThongTinGoiLai = value; }
        }

        private bool mDonDuocKhach;

        public bool DonDuocKhach
        {
            get { return mDonDuocKhach; }
            set { mDonDuocKhach = value; }
        }
        private bool mTruotKhach;

        public bool TruotKhach
        {
            get { return mTruotKhach; }
            set { mTruotKhach = value; }
        }
        private bool mKhachHoan;

        public bool KhachHoan
        {
            get { return mKhachHoan; }
            set { mKhachHoan = value; }
        }
        private bool mKhongXe;

        public bool KhongXe
        {
            get { return mKhongXe; }
            set { mKhongXe = value; }
        }
        private string mFileVoicePath;

        public string FileVoicePath
        {
            get { return mFileVoicePath; }
            set { mFileVoicePath = value; }
        }
        public string HienThiDoDaiCuocGoi
        {
            get { return string.Format("{0: mm:ss}", DoDaiCuocGoi); }
        }
        private string _phanLoai;

        public string PhanLoai
        {
            get { return _phanLoai; }
            set { _phanLoai = value; }
        }
        private string _ketQua;

        public string KetQua
        {
            get { return _ketQua; }
            set { _ketQua = value; }
        }
        private string _MOIKHACH_NhanVien;

        public string MOIKHACH_NhanVien
        {
            get { return _MOIKHACH_NhanVien; }
            set { _MOIKHACH_NhanVien = value; }
        }

        private int _SoLuongChuyenVung;
        /// <summary>
        /// so luong lan chuyen vung co ghi log
        /// </summary>
        public int SoLuongChuyenVung
        {
            get { return _SoLuongChuyenVung; }
            set { _SoLuongChuyenVung = value; }
        }

        #endregion Members & Properties

        public BaoCaoLogVung()
        {
        }

        
    }
    public class TimKiem_BaoCao
    {
        /// <summary>
        /// check dieu kien tu ngay toi ngay
        /// true : TuNgay nho hon hoặc bằng Denngay
        /// false: TuNgay lớn hơn DenNgay
        /// </summary>
        public static bool CheckTuNgayDenNgay(DateTime TuNgay, DateTime DenNgay)
        {
            if (TuNgay.CompareTo(DenNgay) <= 0) return true;
            else return false;
        }
        public DataTable GetBaoCao_TaxiKetThuc(string strSQLCondition)
        {
           return  new Data.TimKiem_BaoCao().GetBaoCao_TaxiKetThuc(strSQLCondition); 
        }
        /// <summary>
        /// Lay tat cac cac cuoc goi thanh cong TrangThaiLenh=3
        /// Tu : TuNGayGio, Den : DenNGayGio
        /// </summary>
        public DataTable GetBaoCaoLuongKhachGoi(DateTime TuNgayGio, DateTime DenNgayGio)
        {
            string strSQLCondition = string.Empty;

            strSQLCondition = " AND (TrangThaiLenh=3) AND ((ThoiDiemGoi >='" + string.Format("{0:yyyy/MM/dd HH:mm:ss}", TuNgayGio) + "') AND(ThoiDiemGoi<='" + string.Format("{0:yyyy/MM/dd HH:mm:ss}", DenNgayGio) + "'))";
            return GetBaoCao_TaxiKetThuc(strSQLCondition);
        }
        /// <summary>
        /// Lay ra cac cuoc goi thanhcong cua doi tac (co nhieu so dien thoai)
        /// Tu : TuNGayGio, Den : DenNGayGio
        /// </summary>
        public DataTable GetBaoCaoCuocGoiTuDoiTac(DoiTac DoiTac, DateTime TuNgayGio, DateTime DenNgayGio)
        {
            // Lay ra cac so dien thoai
            char[] splitChars = ";".ToCharArray();
            string[] DSSoDienThoai;
            DSSoDienThoai=DoiTac.Phones.Split(splitChars);

            string strSQL_SoDienThoai = " AND ((1=0) ";
            if(DSSoDienThoai.Length>0)
            {

                foreach (string SoDT in DSSoDienThoai)
                {
                    if (StringTools.TrimSpace(SoDT).Length >=7)//So dien thoai co dinh toi thieu la 7 so
                    {
                        strSQL_SoDienThoai += " OR (PhoneNumber LIKE '%" + SoDT + "')";
                    }
                }
            }
            strSQL_SoDienThoai  += ")";

                        
            string strSQLCondition = string.Empty;
            
            strSQLCondition = " AND (TrangThaiLenh=3) AND ((ThoiDiemGoi >='" + string.Format("{0:yyyy/MM/dd HH:mm:ss}", TuNgayGio) + "') AND(ThoiDiemGoi<='" + string.Format("{0:yyyy/MM/dd HH:mm:ss}", DenNgayGio) + "'))";

            strSQLCondition = strSQL_SoDienThoai + strSQLCondition;

            return GetBaoCao_TaxiKetThuc(strSQLCondition);

        }

        /// <summary>
        /// Khai thac du lieu , cuoc goi khong thanh cong
        /// </summary>
        public DataTable GetBaoCaoCuocGoiKhongThanhCong(DateTime TuNgayGio, DateTime DenNgayGio)
        {
             string strSQLCondition = string.Empty;

             strSQLCondition = " AND (TrangThaiLenh=3) AND ((ThoiDiemGoi >='" + string.Format("{0:yyyy/MM/dd HH:mm:ss}", TuNgayGio) + "') AND(ThoiDiemGoi<='" + string.Format("{0:yyyy/MM/dd HH:mm:ss}", DenNgayGio) + "')) AND (len(rtrim(ltrim(cuocgoikhongthanhcong)))>0)";
            return GetBaoCao_TaxiKetThuc(strSQLCondition);
            
        }

        public DataTable GetBaoCao_KhachVangLai(DateTime TuNgayGio, DateTime DenNgayGio)
        {
            string strSQLCondition = string.Empty;

            strSQLCondition = "  AND ((NgayGioDonKhach >='" + string.Format("{0:yyyy/MM/dd HH:mm:ss}", TuNgayGio) + "') AND(NgayGioDonKhach<='" + string.Format("{0:yyyy/MM/dd HH:mm:ss}", DenNgayGio) + "'))";
            return GetBaoCao_KhachVangLai(strSQLCondition);
        }

        private DataTable GetBaoCao_KhachVangLai(string strSQLCondition)
        {
            return new Data.TimKiem_BaoCao().GetBaoCao_KhachVangLai(strSQLCondition); 
        }

        public DataTable GetBaoCao_GoiDenTuSoDT(string SoDT, DateTime TuNgayGio, DateTime DenNgayGio)
        {
            string strSQLCondition = string.Empty;

            strSQLCondition = " AND (PhoneNumber LIKE '%" + SoDT + "' ) AND ((ThoiDiemGoi >='" + string.Format("{0:yyyy/MM/dd HH:mm:ss}", TuNgayGio) + "') AND(ThoiDiemGoi<='" + string.Format("{0:yyyy/MM/dd HH:mm:ss}", DenNgayGio) + "'))";
            return GetBaoCao_TaxiKetThuc(strSQLCondition);

        }

        #region BIEU MAU 1
        
        /// <summary>
        /// Lay thong so theo bieu mau 1
        /// - ngay co dang '2008-10-14'
        /// </summary>
        /// <param name="strDate"></param>
        /// <returns></returns>
        public DataTable FillData_BieuMau1(string strDate)
        {
            return new Data.TimKiem_BaoCao().GetBaoCao_BieuMau1(strDate);
        }


        public DataTable FillData_BieuMau1_New(string strDate)
        {
            return new Data.TimKiem_BaoCao().GetBaoCao_BieuMau1_New(strDate);
        }

        /// <summary>
        /// get bao cao theo vung
        /// </summary>
        /// <param name="strDate"></param>
        /// <returns></returns>
        public DataTable FillData_BieuMau1_Vung(string strDate)
        {
            return new Data.TimKiem_BaoCao().GetBaoCao_BieuMau1_Vung(strDate);
        }
        
        #endregion BIEU MAU 1

        public DataTable  FillData_BieuMau2(string strTuNgay, string strDenNgay)
        {
            return new Data.TimKiem_BaoCao().GetBaoCao_BieuMau2(strTuNgay, strDenNgay);
        }
        public DataTable GetBaoCao_BieuMau9(DateTime  TuNgay, DateTime  DenNgay)
        {
            return new Data.TimKiem_BaoCao().GetBaoCao_BieuMau9(string.Format("{0:yyyy-MM-dd}", TuNgay), string.Format("{0:yyyy-MM-dd}", DenNgay));
        }
        #region XULY CUOC GOI MOI GIOI
       
        /// <summary>
        /// Lay so lieu cuoc goi cua moi gioi
        ///     - strTuNgayGio '2008-10-15 12:14:00'
        ///     - strDenNgayGio '2008-10-23 12:14:00'
        ///     - PhoneNumber (80) '37856099'
        /// @TuNgayGio varchar(19), @DenNgayGio varchar(19),@PhoneCall varchar(8)
        /// </summary>
        /// <returns> Danh sach cuoc goi moi gioi
        ///)</returns>
        //public static BacCao_CuocGoiMoiGioi  GetBaoCao_CuocGoiMoiGioi(DateTime TuNgayGio, DateTime DenNgayGio, DoiTac DoiTac)
        //{
        //    BacCao_CuocGoiMoiGioi objBCMoiGioi = new BacCao_CuocGoiMoiGioi();
        //    DataTable dt = new DataTable();
        //    string[] arrPhones = DoiTac.Phones.Split(";".ToCharArray ());

        //    objBCMoiGioi.MaKhachHang = DoiTac.MaDoiTac;
        //    objBCMoiGioi.TenKhachHang = DoiTac.Name;
        //    objBCMoiGioi.DiaChi = DoiTac.Address;
        //    objBCMoiGioi.DienThoais = DoiTac.Phones;
        //    objBCMoiGioi.NhanVien =StringTools.TrimSpace( DoiTac.TenNhanVien).ToLower() ;

        //   if(arrPhones.Length>0)
        //   {
               
        //       for (int i = 0; i < arrPhones.Length; i++)
        //       {
        //           string PhoneCall = arrPhones[i].ToString();
        //           if (PhoneCall.Length >= 8)
        //           {
        //               PhoneCall = PhoneCall.Substring(PhoneCall.Length - 8, 8);

        //               dt = new Data.TimKiem_BaoCao().GetBaoCao_CuocGoiMoiGioi(string.Format("{0:yyyy-MM-dd HH:mm:ss}", TuNgayGio), string.Format("{0:yyyy-MM-dd HH:mm:ss}", DenNgayGio), PhoneCall);
        //               if ((dt != null) && (dt.Rows.Count > 0))
        //               {
        //                   objBCMoiGioi.TongCuocGoi += (int)dt.Rows[0]["TongCuocGoi"];
        //                   objBCMoiGioi.CuocGoiDonDuoc += (int)dt.Rows[0]["CuocGoiDonDuoc"];
        //                   objBCMoiGioi.CuocGoiHoan += (int)dt.Rows[0]["CuocGoiHoan"];
        //                   objBCMoiGioi.CuocGoiTruot += (int)dt.Rows[0]["CuocGoiTruot"];
        //                   objBCMoiGioi.CuocGoiKhongXe += (int)dt.Rows[0]["CuocGoiKhongXe"];
        //                   objBCMoiGioi.SoChuyen += (int)dt.Rows[0]["SoChuyen"];

        //               }
        //           }
        //       }
        //   }
        //   return objBCMoiGioi;
        //}
        public static BacCao_CuocGoiMoiGioi GetBaoCao_CuocGoiMoiGioi(DateTime TuNgayGio, DateTime DenNgayGio, DoiTac DoiTac)
        {
            BacCao_CuocGoiMoiGioi objBCMoiGioi = new BacCao_CuocGoiMoiGioi();
            DataTable dt = new DataTable();
            

            objBCMoiGioi.MaKhachHang = DoiTac.MaDoiTac;
            objBCMoiGioi.TenKhachHang = DoiTac.Name;
            objBCMoiGioi.DiaChi = DoiTac.Address;
            objBCMoiGioi.DienThoais = DoiTac.Phones;
            objBCMoiGioi.MaNhanVien = StringTools.TrimSpace(DoiTac.MaNhanVien).ToLower();
            

            dt = new Data.TimKiem_BaoCao().GetBaoCao_CuocGoiMoiGioi_ByMaMoiGioi (string.Format("{0:yyyy-MM-dd HH:mm:ss}", TuNgayGio), string.Format("{0:yyyy-MM-dd HH:mm:ss}", DenNgayGio),DoiTac.MaDoiTac );
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                try
                {
                    objBCMoiGioi.TongCuocGoi = (int)dt.Rows[0]["TongCuocGoi"];
                    objBCMoiGioi.CuocGoiDonDuoc = (int)dt.Rows[0]["CuocGoiDonDuoc"];
                    objBCMoiGioi.CuocGoiHoan = (int)dt.Rows[0]["CuocGoiHoan"];
                    objBCMoiGioi.CuocGoiTruot = (int)dt.Rows[0]["CuocGoiTruot"];
                    objBCMoiGioi.CuocGoiKhongXe = (int)dt.Rows[0]["CuocGoiKhongXe"];
                    objBCMoiGioi.SoChuyen = (int)dt.Rows[0]["SoChuyen"];
                }
                catch
                {
                    objBCMoiGioi.TongCuocGoi = 0;
                    objBCMoiGioi.CuocGoiDonDuoc =0;
                    objBCMoiGioi.CuocGoiHoan = 0;
                    objBCMoiGioi.CuocGoiTruot = 0;
                    objBCMoiGioi.CuocGoiKhongXe = 0;
                    objBCMoiGioi.SoChuyen = 0;
                }
            }  
            return objBCMoiGioi;
        }

        /// <summary>
        ///  ngay : "2008-11-04"
        ///
        /// </summary>         
        public  static  int  GetSoChuyenCuocGoiMoiGioiInOneDay(string  Ngay , DoiTac DoiTac)
        {
            try{
                int iSoChuyen = 0;
                string[] arrPhones = DoiTac.Phones.Split(";".ToCharArray ());
               if(arrPhones.Length>0)
               {
                   
                   for (int i = 0; i < arrPhones.Length; i++)
                   {
                       string PhoneCall = arrPhones[i].ToString();
                       if (PhoneCall.Length >= 8)
                       {
                           PhoneCall = PhoneCall.Substring(PhoneCall.Length - 8, 8);
                           iSoChuyen += new Data.TimKiem_BaoCao().GetCuocGoiMoiGioiInOneDay(Ngay, PhoneCall);                            
                       }
                   }
                }
                return iSoChuyen;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// Tra ve danh sach cac cuoc goi cua mot moi gioi
        /// </summary>
        /// <param name="TuNgayGio"></param>
        /// <param name="DenNgayGio"></param>
        /// <param name="DoiTac"></param>
        /// <returns></returns>
        public List <DieuHanhTaxi>  GetBaoCao_ChiTietCuocGoiMoiGioi(DateTime TuNgayGio, DateTime DenNgayGio, DoiTac DoiTac)
        {
            List<DieuHanhTaxi> lstCuocGoi = new List<DieuHanhTaxi>();
            DataTable dt = new DataTable();
            string[] arrPhones = DoiTac.Phones.Split(";".ToCharArray());
                       
            if (arrPhones.Length > 0)
            {

                for (int i = 0; i < arrPhones.Length; i++)
                {
                    string PhoneCall = arrPhones[i].ToString();
                    if (PhoneCall.Length >= 7)
                    {
                        PhoneCall = PhoneCall.Substring(PhoneCall.Length - 8, 8);

                        dt = new Data.TimKiem_BaoCao().GetBaoCao_ChiTietCuocGoiMoiGioi(string.Format("{0:yyyy-MM-dd HH:mm:ss}", TuNgayGio), string.Format("{0:yyyy-MM-dd HH:mm:ss}", DenNgayGio), PhoneCall);
                        if ((dt != null) && (dt.Rows.Count > 0))
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
                    }
                }
            }
            return lstCuocGoi;
           
        }




        public List<DieuHanhTaxi> GetBaoCao_ChiTietCuocGoiMoiGioiByMaDoiTac(DateTime TuNgayGio, DateTime DenNgayGio, DoiTac DoiTac)
        {
            List<DieuHanhTaxi> lstCuocGoi = new List<DieuHanhTaxi>();

            DataTable dt = new DataTable();
            dt = new Data.TimKiem_BaoCao().GetBaoCao_ChiTietCuocGoiMoiGioiByMaDoiTac(string.Format("{0:yyyy-MM-dd HH:mm:ss}", TuNgayGio), string.Format("{0:yyyy-MM-dd HH:mm:ss}", DenNgayGio), DoiTac.MaDoiTac);
            if ((dt != null) && (dt.Rows.Count > 0))
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
        
        /// <summary>
        ///  ID, Line, PhoneNumber, ThoiDiemGoi, SoLuotDoChuong, DiaChiGoi, ThoiDiemKetThucGoi, DiaChiDonKhach, GoiTaxi, GoiLai, GoiKhieuNai, 
        ///       ThongTinKhac, LoaiXe,SoLuong, ChonTaxi4Cho, ChonTaxi7Cho, SanBay_DuongDai, Vung, LenhDienThoai, LenhTongDai, MaNhanVienDienThoai, 
        //       MaNhanVienTongDai, XeNhan, XeDon, DiaChiTraKhach, GhiChu, TrangThaiLenh
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private DieuHanhTaxi GetDieuHanhTaxi(DataRow drTaxiOpe)
        {
            DieuHanhTaxi objDHTaxi = new DieuHanhTaxi();
            objDHTaxi.ID_DieuHanh = long.Parse(drTaxiOpe["ID"].ToString());
            objDHTaxi.Line = drTaxiOpe["Line"].ToString();
            objDHTaxi.PhoneNumber = drTaxiOpe["PhoneNumber"].ToString();
            objDHTaxi.ThoiDiemGoi = (DateTime)drTaxiOpe["ThoiDiemGoi"];
            objDHTaxi.DoDaiCuocGoi = (DateTime)drTaxiOpe["Duration"];
            objDHTaxi.FileVoicePath = drTaxiOpe["FileVoicePath"].ToString();
            objDHTaxi.ThoiDiemGoiGio = string.Format("{0:yyyy-MM-dd HH:mm:ss}", objDHTaxi.ThoiDiemGoi).Substring(11, 8);
            objDHTaxi.ThoiDiemGoiNgay = string.Format("{0:yyyy-MM-dd HH:mm:ss}", objDHTaxi.ThoiDiemGoi).Substring(0, 10);
            objDHTaxi.TrangThaiCuocGoi = (TrangThaiCuocGoiTaxi)int.Parse(drTaxiOpe["TrangThaiCuocGoi"].ToString());

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
            objDHTaxi.GoiTaxi = drTaxiOpe["GoiTaxi"].ToString() == "1" ? true : false;
            objDHTaxi.GoiLai = drTaxiOpe["GoiLai"].ToString() == "1" ? true : false;
            // objDHTaxi.GoiKhieuNai  = drTaxiOpe["GoiKhieuNai"].ToString ()=="1"? true:false ;
            objDHTaxi.ThongTinKhac = drTaxiOpe["ThongTinKhac"].ToString() == "1" ? true : false;//GoiKhac
            objDHTaxi.LoaiXe = drTaxiOpe["LoaiXe"].ToString();
            if (StringTools.TrimSpace(drTaxiOpe["SoLuong"].ToString()).Length > 0)
                objDHTaxi.SoLuong = drTaxiOpe["SoLuong"].ToString();
            else objDHTaxi.SoLuong = string.Empty;

            if (objDHTaxi.LoaiXe.Contains("4")) objDHTaxi.ChonTaxi4Cho = true;
            if (objDHTaxi.LoaiXe.Contains("7")) objDHTaxi.ChonTaxi7Cho = true;
            if (objDHTaxi.LoaiXe.Contains("0")) { objDHTaxi.ChonTaxi7Cho = false; objDHTaxi.ChonTaxi4Cho = false; }

            objDHTaxi.SanBay_DuongDai = drTaxiOpe["SanBay_DuongDai"].ToString();
            if (StringTools.TrimSpace(drTaxiOpe["Vung"].ToString()).Length > 0)
                objDHTaxi.MaVung = drTaxiOpe["Vung"].ToString();
            else objDHTaxi.MaVung = string.Empty;
            objDHTaxi.LenhDienThoai = drTaxiOpe["LenhDienThoai"].ToString();
            objDHTaxi.LenhTongDai = drTaxiOpe["LenhTongDai"].ToString();
            objDHTaxi.MaNhanVienDienThoai = drTaxiOpe["MaNhanVienDienThoai"].ToString();
            objDHTaxi.MaNhanVienTongDai = drTaxiOpe["MaNhanVienTongDai"].ToString();
            objDHTaxi.XeNhan = drTaxiOpe["XeNhan"].ToString();
            objDHTaxi.XeDon = drTaxiOpe["XeDon"].ToString();
            objDHTaxi.DiaChiTraKhach = drTaxiOpe["DiaChiTraKhach"].ToString();
            objDHTaxi.GhiChuDienThoai = drTaxiOpe["GhiChuDienThoai"].ToString();
            objDHTaxi.GhiChuTongDai = drTaxiOpe["GhiChuTongDai"].ToString();
            if (StringTools.TrimSpace(drTaxiOpe["TrangThaiLenh"].ToString()).Length > 0)
                objDHTaxi.TrangThaiLenh = (TrangThaiLenhTaxi)int.Parse(drTaxiOpe["TrangThaiLenh"].ToString());
            else objDHTaxi.TrangThaiLenh = TrangThaiLenhTaxi.KhongTruyenDi;

            objDHTaxi.CuocGoiLaiIDs = StringTools.TrimSpace(drTaxiOpe["CuocGoiLaiIDs"].ToString());
           
            if (drTaxiOpe["ThoiGianDieuXe"].ToString().Length > 0)
                objDHTaxi.ThoiGianDieuXe = int.Parse(drTaxiOpe["ThoiGianDieuXe"].ToString());
            if (drTaxiOpe["ThoiGianDonKhach"].ToString().Length > 0)
                objDHTaxi.ThoiGianDonKhach = int.Parse(drTaxiOpe["ThoiGianDonKhach"].ToString());

            return objDHTaxi;
        }

        public static List<BaoCao_BieuMau8> ConvertToBaoCaoBieuMau8(List<DieuHanhTaxi> lstCuocGoiKetThuc)
        {
            List<BaoCao_BieuMau8> lstBaoCaoBieuMau8 = new List<BaoCao_BieuMau8>();
            if (lstCuocGoiKetThuc != null)
            {
                foreach (DieuHanhTaxi objDHTX in lstCuocGoiKetThuc)
                {
                    BaoCao_BieuMau8 objBM8 = new BaoCao_BieuMau8();
                   
                  
               
                    objBM8.Ngay = string.Format ("{0:dd/MM/yyyy}",objDHTX.ThoiDiemGoi);
                    objBM8.Gio = string.Format("{0:HH:mm}", objDHTX.ThoiDiemGoi);
                    objBM8.XeDon = objDHTX.XeDon ;
                    if (objDHTX.XeDon.Length >= 3) objBM8.SoChuyen = Convert.ToString((int)((objDHTX.XeDon.Length + 1) / 4));
                    else objBM8.SoChuyen = "0";
                    
                    
                    if (objDHTX.GhiChuTongDai.Contains("trượt"))
                        objBM8.Truot= true;
                    else objBM8.Truot= false;

                    if (objDHTX.GhiChuTongDai.Contains("hoãn"))
                        objBM8.Hoan = true;
                    else objBM8.Hoan = false;
                    if (objDHTX.GhiChuDienThoai.Contains("không xe"))
                        objBM8.KhongXe = true;
                    else objBM8.KhongXe = false;

               
                    lstBaoCaoBieuMau8.Add(objBM8);
                }

            }
            return lstBaoCaoBieuMau8;
        }

        public static List<BaoCao_BieuMau8> ConvertToBaoCaoBieuMau10(List<DieuHanhTaxi> lstCuocGoiKetThuc)
        {
            List<BaoCao_BieuMau8> lstBaoCaoBieuMau8 = new List<BaoCao_BieuMau8>();
            if (lstCuocGoiKetThuc != null)
            {
                foreach (DieuHanhTaxi objDHTX in lstCuocGoiKetThuc)
                {
                    BaoCao_BieuMau8 objBM8 = new BaoCao_BieuMau8();


                    objBM8.DiaChiDon = objDHTX.DiaChiDonKhach;
                    objBM8.PhoneNumber = objDHTX.PhoneNumber;
                    objBM8.Ngay = string.Format("{0:dd/MM/yyyy}", objDHTX.ThoiDiemGoi);
                    objBM8.Gio = string.Format("{0:HH:mm}", objDHTX.ThoiDiemGoi);
                    objBM8.XeDon = objDHTX.XeDon;
                    if (objDHTX.XeDon.Length >= 3) objBM8.iSoChuyen = Convert.ToInt32(  (objDHTX.XeDon.Length + 1) / 4);
                    else objBM8.iSoChuyen = 0;


                    if (objDHTX.GhiChuTongDai.Contains("trượt"))
                        objBM8.Truot = true;
                    else objBM8.Truot = false;

                    if (objDHTX.GhiChuTongDai.Contains("hoãn"))
                        objBM8.Hoan = true;
                    else objBM8.Hoan = false;
                    if (objDHTX.GhiChuDienThoai.Contains("không xe"))
                        objBM8.KhongXe = true;
                    else objBM8.KhongXe = false;


                    lstBaoCaoBieuMau8.Add(objBM8);
                }

            }
            return lstBaoCaoBieuMau8;
        }
         
        #endregion XULY CUOC GOI MOI GIOI

        // Bieu bao ca
        public static  DataTable GetTrangThaiBaoRa_Ve_GanNhat(string SoHieuXe)
        {
            return new Data.TimKiem_BaoCao().GetTrangThaiBaoRa_Ve_GanNhat(SoHieuXe);
        }
        /// <summary>
        /// lay cacs su kien cua xe trong mot thoi diem 
        /// </summary>
        /// <param name="SoHieuXe"></param>
        /// <returns></returns>
        public static DataTable GetTrangThaiBaoRa_Ve_TrongKhoang( DateTime TuThoiDiem,DateTime DenThoiDiem)
        {
            return new Data.TimKiem_BaoCao().GetTrangThaiBaoRa_Ve_TrongKhoang  (TuThoiDiem,DenThoiDiem );
        }
        /// <summary>
        /// lay danh sach ket qua hoat dong của nhan vien
        /// Username = null : lay tat ca
        /// Username <> null thi lay theo nhan vien nay
        /// </summary>
        /// <param name="IsNhanVienDienThoai"></param>
        /// <param name="Username"></param>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <returns></returns>
        public static DataTable GetKetQuaHoatDongCuaNhanVien_BaoCao16(bool IsNhanVienDienThoai, string Username, DateTime TuNgay, DateTime DenNgay)
        {
            return new Data.TimKiem_BaoCao().GetKetQuaHoatDongCuaNhanVien_BaoCao16(IsNhanVienDienThoai, Username, TuNgay, DenNgay);
        }


        /// <summary>
        /// ham thuc hien chuc nang lay hanh trinh của mot xe trong khoang thoi gian
        /// </summary>
        /// <param name="SoHieuXe"></param>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <returns></returns>
        public static DataTable GetHanhTrinhXe_BaoCao17(string SoHieuXe,DateTime TuNgay, DateTime DenNgay)
        {
           return  new Data.TimKiem_BaoCao().GetHanhTrinhXe_BaoCao17(SoHieuXe,TuNgay, DenNgay);
        }

        //public static List<BaoCaoBieuMau15> GetBaoCao15(DateTime TuNgayGio, DateTime DenNgayGio)
        //{
        //    List<BaoCaoBieuMau15> ListBC15 = new List<BaoCaoBieuMau15>();
        //    // lay danh muc xe 
        //    List<Xe> listXes = new List<Xe>();
        //    Xe objXe = new Xe();
        //    listXes = objXe.GetListXes();
        //    //DateTime timeServer = DieuHanhTaxi.GetTimeServer();
        //    // lay trang thai cua tung xe insert vao bieu 14
        //    if (listXes != null)
        //    {
        //        foreach (Xe xe in listXes )
        //        {
        //             List<KiemSoatXeLienLac> listCacSuKienXeTrongKhoang = new List<KiemSoatXeLienLac>();
        //             listCacSuKienXeTrongKhoang = KiemSoatXeLienLac.GetDanhSachCacSuKienCuaXeTrongKhoangThoiGian(xe.SoHieuXe, TuNgayGio, DenNgayGio);
        //             if (listCacSuKienXeTrongKhoang.Count >= 1)
        //             {
        //                 DateTime start = TuNgayGio;
        //                 DateTime finish = TuNgayGio;
        //                 bool bXeMatLienLac = false;
        //                 foreach (KiemSoatXeLienLac objKSXLL in listCacSuKienXeTrongKhoang)
        //                 {
        //                     if(objKSXLL.
        //                 }
        //             }                    
        //        }
        //    }
        //}

        /// <summary>
        /// báo kết quản nhân viên điều hành - gộp chung
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="dateTime_2"></param>
        /// <returns></returns>
        public static DataTable GetKetQuaHoatDongCuaNhanVien_BaoCao16_GopChung(DateTime TuNgay, DateTime DenNgay)
        {
            return new Data.TimKiem_BaoCao().GetKetQuaHoatDongCuaNhanVien_BaoCao16_GopChung(TuNgay, DenNgay);
        }

        /// <summary>
        /// báo cáo xe đi đường dài san bay theo ngay
        /// </summary>
        /// <param name="Ngay"></param>
        /// <returns></returns>
        public static DataTable GetBaoCaoXeDiSanBayDuongDai(DateTime tuNgay, DateTime denNgay, int tinhThanh, int gara)
        {
            return new Data.TimKiem_BaoCao().GetBaoCaoXeDiSanBayDuongDai(tuNgay, denNgay, tinhThanh, gara);
        }
        /// <summary>
        /// báo cáo xe đi đường dài san bay theo ngay
        /// </summary>
        /// <param name="Ngay"></param>
        /// <returns></returns>
        public static DataTable GetBaoCaoXeDiSanBayDuongDai_RutGon(DateTime Ngay)
        {
            return new Data.TimKiem_BaoCao().GetBaoCaoXeDiSanBayDuongDai_RutGon(Ngay);
        }
        /// <summary>
        /// lấy hành trình xe - cuốc khách theo ngày
        /// </summary>
        /// <param name="NgayServer"></param>
        /// <returns></returns>
        public static DataTable GetXeHanhTrinh_CuocKhach_TrongNgay(DateTime NgayServer)
        {
            return new Data.TimKiem_BaoCao().GetXeHanhTrinh_CuocKhach_TrongNgay(NgayServer);
        }
        /// <summary>
        /// lấy hành trình xe theo địa chỉ
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DataTable GetXeHanhTrinh_DiaChi_TrongNgay(DateTime Ngay)
        {
            return new Data.TimKiem_BaoCao().GetXeHanhTrinh_DiaChi_TrongNgay(Ngay);
        }
        /// <summary>
        /// bao cao tra ve thong tin chi tiet cua cuoc khach cua moi gioi
        /// sau khi  them MaMoiGioi va bang KetThuc
        /// </summary>
        /// <param name="MaNhanVien"></param>
        /// <returns></returns>
        public static List<BacCao_CuocGoiMoiGioi> GetBCChiTietCuocKhachMoiGioi_BC07(string MaNhanVien, DateTime TuNgay, DateTime DenNgay,int SoChuyen)
        {
            List<BacCao_CuocGoiMoiGioi> lstTemp = new List<BacCao_CuocGoiMoiGioi> ();
            DataTable dt = new DataTable();
            dt = new Data.TimKiem_BaoCao().GetBCChiTietCuocKhachMoiGioi_BC07(MaNhanVien,TuNgay, DenNgay,SoChuyen);
            if( dt!=null  && dt.Rows.Count>0)
            {
              //  DT.Ma_DoiTac,DT.Name,DT.Address,Phones,DT.FK_MaNhanVien, DT.TenNhanVien, DTT.TongCuocGoi,DTT.CuocGoiDonDuoc,DTT.CuocGoiTruot,DTT.CuocGoiHoan,DTT.CuocGoiKhongXe,DTT.SoChuyen
		        foreach(DataRow dr in dt.Rows)
                {
                    BacCao_CuocGoiMoiGioi objBC7 = new BacCao_CuocGoiMoiGioi();
                    objBC7.MaKhachHang = dr["Ma_DoiTac"].ToString ();
                    objBC7.TenKhachHang = dr["Name"].ToString();
                    objBC7.DiaChi = dr["Address"].ToString();
                    objBC7.DienThoais = dr["Phones"].ToString();
                   // objBC7.Ngay= dr[" "].ToString ();
                    objBC7.TongCuocGoi= dr["TongCuocGoi"].ToString ().Length==0 ? 0 : Convert.ToInt32(dr["TongCuocGoi"].ToString ());
                    objBC7.CuocGoiDonDuoc = dr["CuocGoiDonDuoc"].ToString().Length == 0 ? 0 : Convert.ToInt32(dr["CuocGoiDonDuoc"].ToString());
                    objBC7.CuocGoiTruot = dr["CuocGoiTruot"].ToString().Length == 0 ? 0 : Convert.ToInt32(dr["CuocGoiTruot"].ToString());
                    objBC7.CuocGoiHoan = dr["CuocGoiHoan"].ToString().Length == 0 ? 0 : Convert.ToInt32(dr["CuocGoiHoan"].ToString());
                    objBC7.CuocGoiKhongXe = dr["CuocGoiKhongXe"].ToString().Length == 0 ? 0 : Convert.ToInt32(dr["CuocGoiKhongXe"].ToString());
                    objBC7.SoChuyen = dr["SoChuyen"].ToString().Length == 0 ? 0 : Convert.ToInt32(dr["SoChuyen"].ToString());
                   // objBC7.PhanTramDonDuoc= dr[" "].ToString ();
                    objBC7.MaNhanVien = dr["TenNhanVien"] == null ? "" : dr["TenNhanVien"].ToString();
                    objBC7.GhiChu = dr["Notes"] == null ? "" : dr["Notes"].ToString();
                    objBC7.CongTyID = int.Parse(dr["CongTyID"].ToString());
                    lstTemp.Add(objBC7);
                }
            }
            return lstTemp;
        }
        /// <summary>
        /// báo cáo trả về số chuyến của một môi giới trong một ngày trong tháng.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="MaNhanVien"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static DataTable GetBCChiTietCuocKhachMoiGioiTheoNgay_BC08(DateTime Thang, string MaNhanVien, int SoChuyen)
        {
            return new Data.TimKiem_BaoCao().GetBCChiTietCuocKhachMoiGioiTheoNgay_BC08(Thang, MaNhanVien, SoChuyen);
        }
        public static DataTable GetBCChiTietCuocKhachMoiGioiTheoNgay(DateTime Thang, string MaNhanVien, int SoChuyen, string MaMoiGioi)
        {
            return new Data.TimKiem_BaoCao().GetBCChiTietCuocKhachMoiGioiTheoNgay(Thang, MaNhanVien, SoChuyen, MaMoiGioi);
        }
        /// <summary>
        /// hàm trả về số cuốc khách theo tháng
        /// </summary>
        /// <param name="MaNhanVien"></param>
        /// <param name="TuThang"></param>
        /// <param name="DenThang"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static DataTable GetBCChiTietCuocKhachMoiGioiTheoThang_BC09(string MaNhanVien, DateTime TuThang, DateTime DenThang, int SoChuyen)
        {
            return new Data.TimKiem_BaoCao().GetBCChiTietCuocKhachMoiGioiTheoThang_BC09(MaNhanVien, TuThang, DenThang, SoChuyen);
        }

        public static DataTable MoiGioi_GetBaoCaoGroupMoiGioi(DateTime TuNgay, DateTime DenNgay, int CongtyID)
        {
            return new Data.TimKiem_BaoCao().GetBaoCaoGroupMoiGioi(TuNgay, DenNgay, CongtyID);
        }

        /// <summary>
        /// trả về ds các cuốc 999 của điểm môi giới
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="dateTime_2"></param>
        /// <param name="CongtyID"></param>
        /// <returns></returns>
        public static DataTable MoiGioi_GetChiTietCuoc999(DateTime TuNgay, DateTime DenNgay, int CongtyID)
        {
            return new Data.TimKiem_BaoCao().MoiGioi_GetChiTietCuoc999(TuNgay, DenNgay, CongtyID);
        }
        /// <summary>
        /// trả về ds các cuốc tự xóa
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <param name="CongtyID"></param>
        /// <returns></returns>
        public static DataTable MoiGioi_GetChiTietCuocTuXoa(DateTime TuNgay, DateTime DenNgay, int CongtyID)
        {
            return new Data.TimKiem_BaoCao().MoiGioi_GetChiTietCuocTuXoa(TuNgay, DenNgay, CongtyID);
        }
        /// <summary>
        /// BC 5.6
        /// báo cáo kết quả điều hành của môi giới.
        ///  - 
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <param name="CongtyID"></param>
        /// <returns></returns>
        public static DataTable MoiGioi_GetBaoCaoKetQuaDieuHanh(DateTime TuNgay, DateTime DenNgay, int CongtyID)
        {
            return new Data.TimKiem_BaoCao().MoiGioi_GetBaoCaoKetQuaDieuHanh(TuNgay, DenNgay, CongtyID);
        }
    /// <summary>
    /// Ham lay thong itn cuoc goi tong hop cskh
    /// loaiSoDienThoai :
    ///   1 : Moi gioi
    ///   2 : Vang lai di dong
    ///   3 : Vang lai co dinh
    ///   9 : Tat ca 
    /// </summary>

        public static DataTable CSKH_BaoCaoTongHop(DateTime TuNgay, DateTime DenNgay, string sVung, int SoLanKhachGoiLai, string idCSKH,int loaiSoDienThoai)
        {
            return new Data.TimKiem_BaoCao().CSKH_BaoCaoTongHop(  TuNgay,   DenNgay,     sVung,   SoLanKhachGoiLai,idCSKH,loaiSoDienThoai );
        }
        /// <summary>
        /// hàm trả về dữ liệu báo cáo 1 - dư liệu báo cáo theo ca
        /// </summary>
        /// <param name="Ngay"></param>
        /// <returns></returns>
        public DataTable GROUP_BC_1_1_TongKetCuocGoiDenByCa(DateTime  Ngay)
        {
            return new Data.TimKiem_BaoCao().GROUP_BC_1_1_TongKetCuocGoiDenByCa(Ngay);
        }

        public DataTable GROUP_BC_1_1_TongKetCuocGoiDenByGio(DateTime Ngay)
        {
            return new Data.TimKiem_BaoCao().GROUP_BC_1_1_TongKetCuocGoiDenByGio(Ngay);
           
        }
        /// <summary>
        /// hàm trả về dữ liệu báo cáo điều hành theo ngày 
        /// sVung : 1,2,3,7 (or null)
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <param name="sVung"></param>
        /// <returns></returns>
        public DataTable GROUP_BC_3_1_BaoCaoDieuHanhTheoNgay(DateTime TuNgay, DateTime DenNgay, string sVung)
        {
            return new Data.TimKiem_BaoCao().GROUP_BC_3_1_BaoCaoDieuHanhTheoNgay(TuNgay, DenNgay, sVung);
        }

        public DataTable GROUP_BC_3_1_BaoCaoDieuHanhTheoCa(DateTime Ngay, string sVung)
        {
            return new Data.TimKiem_BaoCao().GROUP_BC_3_1_BaoCaoDieuHanhTheoCa(Ngay, sVung);
        }

        public DataTable GROUP_BC_3_1_BaoCaoDieuHanhTheoGio(DateTime  TuNgay,DateTime DenNgay,string sVung)
        {
            return new Data.TimKiem_BaoCao().GROUP_BC_3_1_BaoCaoDieuHanhTheoGio(TuNgay,DenNgay, sVung);
        }

        public static DataTable GROUP_BC_3_1_BaoCaoDieuHanhTheoDonVi(DateTime TuNgay, DateTime DenNgay, string sVung)
        {
            return new Data.TimKiem_BaoCao().GROUP_BC_3_1_BaoCaoDieuHanhTheoDonVi(TuNgay, DenNgay, sVung);
        }

        /// <summary>
        /// ham thuc hien tra ve ket qua lam viecj cua nhan vien
        /// lua chon theo Vung, Theo NhanVien
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <param name="denNgay"></param>
        /// <param name="Vung"></param>
        /// <param name="NhanVienID"></param>
        /// <returns></returns>
        public static DataTable GROUP_BC_2_3_BaoCaoNhanVien(DateTime TuNgay, DateTime denNgay, string Vung, string NhanVienID)
        {
            return new Data.TimKiem_BaoCao().GROUP_BC_2_3_BaoCaoNhanVien(TuNgay, denNgay, Vung, NhanVienID);
        }

        #region BAO CAO NEW  (chuyen sang MyDinh 
        public DataTable GROUP_BC_1_1_BaoCaoTongHopCuocGoiDenTheoGio(DateTime TuNgay, DateTime DenNgay,ref string id)
        {
            return new Data.TimKiem_BaoCao().GROUP_BC_1_1_BaoCaoTongHopCuocGoiDenTheoGio(TuNgay, DenNgay,ref id);
        }
        /// <summary>
        /// lay du lieu binh quan cua cuoc khach theo gio
        /// Theo id of ham GROUP_BC_1_1_BaoCaoTongHopCuocGoiDenTheoGio tra ve
        /// </summary>
        public DataTable GROUP_BC_1_1_BaoCaoTongHopCuocGoiDenTheoGioBinhQuan(string id)
        {
            return new Data.TimKiem_BaoCao().GROUP_BC_1_1_BaoCaoTongHopCuocGoiDenTheoGioBinhQuan( id);
        }
        public DataTable GROUP_BC_1_1_BaoCaoTongHopCuocGoiDenTheoNgay(DateTime TuNgay, DateTime DenNgay, ref string id)
        {
            return new Data.TimKiem_BaoCao().GROUP_BC_1_1_BaoCaoTongHopCuocGoiDenTheoNgay(TuNgay, DenNgay, ref id);
        }
        public DataTable GROUP_BC_1_1_BaoCaoTongHopCuocGoiDenTheoNgayV2(DateTime TuNgay, DateTime DenNgay, ref string id,int khuVuc)
        {
            return new Data.TimKiem_BaoCao().GROUP_BC_1_1_BaoCaoTongHopCuocGoiDenTheoNgayV2(TuNgay, DenNgay, ref id, khuVuc);
        }
        public DataTable GROUP_BC_1_1_BaoCaoTongHopCuocGoiDenTheoCa(DateTime TuNgay, DateTime DenNgay, ref string id)
        {
            return new Data.TimKiem_BaoCao().GROUP_BC_1_1_BaoCaoTongHopCuocGoiDenTheoCa(TuNgay, DenNgay, ref id);
        }
        public DataTable GROUP_BaoCaoKetQuaDieuHanh_TheoNgay(DateTime tuNgay, DateTime denNgay)
        {
           DataSet ds = new Taxi.Data.TimKiem_BaoCao().GROUP_BaoCaoKetQuaDieuHanh_TheoNgay(tuNgay, denNgay );
           return ds.Tables[0];
        }
        public DataTable GROUP_BaoCaoKetQuaDieuHanh_TheoCa(DateTime tuNgay, DateTime denNgay)
        {
            DataSet ds = new Taxi.Data.TimKiem_BaoCao().GROUP_BaoCaoKetQuaDieuHanh_TheoCa(tuNgay, denNgay);
            return ds.Tables[0];

        }
        public DataTable GROUP_BaoCaoKetQuaDieuHanh_TheoGio(DateTime tuNgay, DateTime denNgay)
        {
            DataSet ds = new Taxi.Data.TimKiem_BaoCao().GROUP_BaoCaoKetQuaDieuHanh_TheoGio(tuNgay, denNgay);
            return ds.Tables[0];

        }

        /// <summary>
        /// Ham tra ve thong tin xe hoat dong bao ra ve
        /// </summary>
        /// <param name="tuNgayGio"></param>
        /// <param name="denNgayGio"></param>
        /// <param name="soHieuXe"></param>
        /// <param name="laiXeID"></param>
        /// <param name="congTyID"></param>
        /// <returns></returns>
        public static DataTable GROUP_BC_5_1_LaiXeBaoRaVe(DateTime tuNgayGio, DateTime denNgayGio, string soHieuXe, string laiXeID, int congTyID)
        {
             return  new Taxi.Data.TimKiem_BaoCao().GROUP_BC_5_1_LaiXeBaoRaVe(tuNgayGio, denNgayGio, soHieuXe,  laiXeID,  congTyID);

        }

        public static DataTable GROUP_BC_5_1_LaiXeBaoRaVeTheoThoiDiem(DateTime thoiDiem, string soHieuXe, string laiXeID, int congtyID)
        {
            return new Taxi.Data.TimKiem_BaoCao().GROUP_BC_5_1_LaiXeBaoRaVeTheoThoiDiem(thoiDiem, soHieuXe, laiXeID, congtyID);
        }
        #region BCKetQuaDieuHanhTheoNgay
        /// <summary>
        /// ham tra ve thong tin la viec cua nhan vien tai cac vi tri
        ///   Dienthoai -- TongDai -- NVCSKH -- NVBanTinGia
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <param name="NhanVienID"></param>
        /// <returns></returns>
        public   DataTable GROUP_BC4_6_KetQuaDieuHanhNVTheoNgay(DateTime TuNgay, DateTime DenNgay, string NhanVienID)
        {
            // Tao table luu tru chung
            DataTable dtKQNV = TimKiem_BaoCao.CreateTableKQNV();            
            // Lay dulieu dien thoai
            DataTable dtDT = new DataTable();
            dtDT = new Data.TimKiem_BaoCao().GetKQNV_DienThoai(TuNgay, DenNgay, NhanVienID);
            // Lay du lieu tong dai
            DataTable dtTD = new Data.TimKiem_BaoCao().GetKQNV_TongDai(TuNgay, DenNgay, NhanVienID);
            // lay du lieu CS
            DataTable dtCS = new Data.TimKiem_BaoCao().GetKQNV_NVCS(TuNgay, DenNgay, NhanVienID);
            // lay du lieu ban tin ban gia
            DataTable dtBTin = new Data.TimKiem_BaoCao().GetKQNV_BanTinGia(TuNgay, DenNgay, NhanVienID);
            //Lấy dữ liệu điều G5
            DataTable dtDieuG5 = new Data.TimKiem_BaoCao().GetKQNV_DieuG5(TuNgay, DenNgay, NhanVienID);
            
            // Khoi tao du lieu cot ngay
            TimeSpan timeSpan = DenNgay - TuNgay;
            for (int i = 0; i <= timeSpan.Days; i++)
            {  
                DateTime ngay = TuNgay.AddDays(i);
                DataRow dr = dtKQNV.NewRow();
                dr["NgayHienThi"] = string.Format("{0:dd/MM/yyyy}", ngay);
                dtKQNV.Rows.Add(dr);
            }
            TimKiem_BaoCao.ChenDuLieuDienThoai(dtKQNV, dtDT);
            TimKiem_BaoCao.ChenDuLieuTongDai(dtKQNV, dtTD);
            TimKiem_BaoCao.ChenDuLieuCS(dtKQNV, dtCS);
            TimKiem_BaoCao.ChenDuLieuBanTin(dtKQNV, dtBTin);
            TimKiem_BaoCao.ChenDuLieuDieuG5(dtKQNV, dtDieuG5);


            return dtKQNV;
        }
          
        /// <summary>
        /// hamf tra ve thong tin luu tru ket qua lam viec cua nhan vien
        /// 
        /// </summary>
        /// <returns></returns>
        private static DataTable CreateTableKQNV()
        {
            
            DataTable dt = new DataTable();
            DataColumn[] keyPrimary = new DataColumn[1]; 
            //NgayHienThi
            DataColumn dcNgay = new DataColumn("NgayHienThi", Type.GetType("System.String"));
            dt.Columns.Add(dcNgay);
            keyPrimary[0] = dcNgay;
            // DIENTHOAI
            // CuoiGoiNhan
            DataColumn dcCuocGoiNhan = new DataColumn("CuocGoiNhan", Type.GetType("System.Int32"));
            dt.Columns.Add(dcCuocGoiNhan);
            // CuocGoiTaxi
            DataColumn dcCuocGoiTaxi = new DataColumn("CuocGoiTaxi", Type.GetType("System.Int32"));
            dt.Columns.Add(dcCuocGoiTaxi);
            // CuocChuyenCham
            DataColumn dcCuocChuyenCham = new DataColumn("CuocChuyenCham", Type.GetType("System.Int32"));
            dt.Columns.Add(dcCuocChuyenCham);
            // PhanTramChuyenCham
            DataColumn dcPhanTramChuyenCham = new DataColumn("PhanTramChuyenCham", Type.GetType("System.Double"));
            dt.Columns.Add(dcPhanTramChuyenCham);
            //Vi tri TONGDAI
            //CuocGoiDieu
            DataColumn dcCuocGoiDieu = new DataColumn("CuocGoiDieu", Type.GetType("System.Int32"));
            dt.Columns.Add(dcCuocGoiDieu);
            // CuocDonDuoc
            DataColumn dcCuocDonDuoc = new DataColumn("CuocDonDuoc", Type.GetType("System.Int32"));            
            dt.Columns.Add(dcCuocDonDuoc);
            // PhanTramDonDuoc
            DataColumn dcPhanTramDonDuoc = new DataColumn("PhanTramDonDuoc", Type.GetType("System.Double"));
            dt.Columns.Add(dcPhanTramDonDuoc);
            // Cuoc 999 -- CuocKhach999
            DataColumn dcCuocKhach999 = new DataColumn("CuocKhach999", Type.GetType("System.Int32"));
            dt.Columns.Add(dcCuocKhach999);
            // Vi Tri CSKH
            // CSCuocGoiTaxi
            DataColumn dcCSCuocGoiTaxi = new DataColumn("CSCuocGoiTaxi", Type.GetType("System.Int32"));
            dt.Columns.Add(dcCSCuocGoiTaxi);
            // CuocGoiCoCS
            DataColumn dcCuocGoiCoCS = new DataColumn("CuocGoiCoCS", Type.GetType("System.Int32"));
            dt.Columns.Add(dcCuocGoiCoCS);
            // PhanTramCS
            DataColumn dcPhanTramCS = new DataColumn("PhanTramCS", Type.GetType("System.Double"));
            dt.Columns.Add(dcPhanTramCS);
            // CSCuocGoiDonDuoc
            DataColumn dcCSCuocGoiDonDuoc = new DataColumn("CSCuocGoiDonDuoc", Type.GetType("System.Int32"));
            dt.Columns.Add(dcCSCuocGoiDonDuoc);
            // CSPhanTramDonDuoc
            DataColumn dcCSPhanTramDonDuoc = new DataColumn("CSPhanTramDonDuoc", Type.GetType("System.Double"));
            dt.Columns.Add(dcCSPhanTramDonDuoc);
            // Tong cuốc 888
            DataColumn dcCSCuoc888 = new DataColumn("TongCuoc888", Type.GetType("System.Int32"));
            dt.Columns.Add(dcCSCuoc888);

            // Vi tri BANTIN_GIA
            // CuoiGoiGiaiQuyet
            DataColumn dcCuoiGoiGiaiQuyet = new DataColumn("CuoiGoiGiaiQuyet", Type.GetType("System.Int32"));
            dt.Columns.Add(dcCuoiGoiGiaiQuyet);
            // CuocGoiGiaiQuyetDuoc
            DataColumn dcCuocGoiGiaiQuyetDuoc = new DataColumn("CuocGoiGiaiQuyetDuoc", Type.GetType("System.Int32"));
            dt.Columns.Add(dcCuocGoiGiaiQuyetDuoc);
            // PhanTramGiaiQuyetDuoc
            DataColumn dcPhanTramGiaiQuyetDuoc = new DataColumn("PhanTramGiaiQuyetDuoc", Type.GetType("System.Double"));
            dt.Columns.Add(dcPhanTramGiaiQuyetDuoc);

            // Điều G5
            DataColumn dcCuocDieuG5 = new DataColumn("CuocDieuG5", Type.GetType("System.Int32"));
            dt.Columns.Add(dcCuocDieuG5);
            // Đón được G5
            DataColumn dcDonDuocG5 = new DataColumn("DonDuocG5", Type.GetType("System.Int32"));
            dt.Columns.Add(dcDonDuocG5);
            // % đón được G5
            DataColumn dcPhanTramDonDuocG5 = new DataColumn("PhanTramDonDuocG5", Type.GetType("System.Double"));
            dt.Columns.Add(dcPhanTramDonDuocG5);

            dt.PrimaryKey = keyPrimary;
            return dt;
        }
        /// <summary>
        /// ghep du lieu DT --> KQNV
        /// </summary>
        /// <param name="dtKQNV"></param>
        /// <param name="dtDT"></param>
        private static void ChenDuLieuDienThoai(DataTable dtKQNV, DataTable dtDT)
        {
            if(dtDT!=null && dtDT.Rows.Count >0)
            {
                foreach (DataRow dr in dtDT.Rows)
                { 
                    DataRow drKQ = TimKiem_BaoCao.TimDong(dtKQNV, dr["NgayHienThi"].ToString());
                    drKQ["CuocGoiNhan"] = dr["SoCuocGoi"];
                    drKQ["CuocGoiTaxi"] = dr["SoCuocTaxi"];
                    drKQ["CuocChuyenCham"] = dr["SoChuyenCham"];
                    double soCuocGoi = Convert.ToDouble(dr["SoCuocGoi"].ToString());
                    double cuocChuyenCham = Convert.ToDouble(dr["SoChuyenCham"].ToString());
                    if (soCuocGoi != 0)
                        drKQ["PhanTramChuyenCham"] = Convert.ToDouble(cuocChuyenCham / soCuocGoi*100);
                    else
                        drKQ["PhanTramChuyenCham"] = 0; 
                }
            }
        }

        /// <summary>
        /// ghep du lieu tong dai --> KQNV
        /// </summary>
        /// <param name="dtKQNV"></param>
        /// <param name="dtTD"></param>
        private static void ChenDuLieuTongDai(DataTable dtKQNV, DataTable dtTD)
        {
            if (dtTD != null && dtTD.Rows.Count > 0)
            {
                foreach (DataRow dr in dtTD.Rows)
                {
                    DataRow drKQ = TimKiem_BaoCao.TimDong(dtKQNV, dr["NgayHienThi"].ToString());
                    if (drKQ != null)
                    {
                        drKQ["CuocGoiDieu"] = dr["SoCuocDieu"];
                        drKQ["CuocDonDuoc"] = dr["TongDonDuoc"];
                        drKQ["CuocKhach999"] = dr["CuocKhach999"];
                        double soCuocDieu = Convert.ToDouble(dr["SoCuocDieu"].ToString());
                        double cuocDonDuoc = Convert.ToDouble(dr["TongDonDuoc"].ToString());
                        if (soCuocDieu != 0)
                            drKQ["PhanTramDonDuoc"] = Convert.ToDouble(cuocDonDuoc / soCuocDieu *100);
                        else
                            drKQ["PhanTramDonDuoc"] = 0;
                    }
                }
            }
        }
        /// <summary>
        /// gheo du lieu CS  --> KQNV 
        /// </summary>
        /// <param name="dtKQNV"></param>
        /// <param name="dtTD"></param>
        private static void ChenDuLieuCS(DataTable dtKQNV, DataTable dtCS)
        {
            if (dtCS != null && dtCS.Rows.Count > 0)
            {
                foreach (DataRow dr in dtCS.Rows)
                {
                    DataRow drKQ = TimKiem_BaoCao.TimDong(dtKQNV, dr["NgayHienThi"].ToString());
                    if (drKQ != null)
                    {
                        drKQ["CSCuocGoiTaxi"] = dr["SoCuocGoiTaxi"];
                        drKQ["CuocGoiCoCS"] = dr["TongCuocCS"];
                        double csCuocGoiTaxi = Convert.ToDouble(dr["SoCuocGoiTaxi"].ToString());
                        double cuocGoiCoCS = Convert.ToDouble(dr["TongCuocCS"].ToString());

                        drKQ["CSCuocGoiDonDuoc"] = dr["TongDonDuoc"];
                        double csCuocDonDuoc = Convert.ToDouble(dr["TongDonDuoc"].ToString());
                        if (cuocGoiCoCS != 0)
                        {
                            drKQ["PhanTramCS"] = Convert.ToDouble(cuocGoiCoCS / csCuocGoiTaxi*100);
                            drKQ["CSPhanTramDonDuoc"] = Convert.ToDouble(csCuocDonDuoc / csCuocGoiTaxi*100);
                        }
                        else
                        {
                            drKQ["PhanTramCS"] = 0;
                            drKQ["CSPhanTramDonDuoc"] = 0;
                        }
                        drKQ["TongCuoc888"] = dr["TongCuoc888"];
                       
                    }
                }
            }
        }
        /// <summary>
        /// chen du lieu ban tin vao --> KQNV
        /// </summary>
        /// <param name="dtKQNV"></param>
        /// <param name="dtCS"></param>
        private static void ChenDuLieuBanTin(DataTable dtKQNV, DataTable dtBanTin)
        {
            if (dtBanTin != null && dtBanTin.Rows.Count > 0)
            {
                foreach (DataRow dr in dtBanTin.Rows)
                {
                    DataRow drKQ = TimKiem_BaoCao.TimDong(dtKQNV, dr["NgayHienThi"].ToString());
                    if (drKQ != null)
                    {
                        drKQ["CuoiGoiGiaiQuyet"] = dr["SoCuocGoiGiaiQuyet"];
                        drKQ["CuocGoiGiaiQuyetDuoc"] = dr["SoCuocGoiDaGiaiQuyetDuoc"];


                        double cuocGoiGiaiQuyet = Convert.ToDouble(dr["SoCuocGoiGiaiQuyet"].ToString());
                        double cuocGoiGiaiQuyetDuoc = Convert.ToDouble(dr["SoCuocGoiDaGiaiQuyetDuoc"].ToString());

                        if (cuocGoiGiaiQuyet != 0)
                        {
                            drKQ["PhanTramGiaiQuyetDuoc"] = Convert.ToDouble(cuocGoiGiaiQuyetDuoc / cuocGoiGiaiQuyet * 100);

                        }
                        else
                        {
                            drKQ["PhanTramGiaiQuyetDuoc"] = 0;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Chèn dữ liệu điều G5
        /// </summary>
        /// <param name="dtKQNV"></param>
        /// <param name="dtDieuG5"></param>
        private static void ChenDuLieuDieuG5(DataTable dtKQNV, DataTable dtDieuG5)
        {
            if (dtDieuG5 != null && dtDieuG5.Rows.Count > 0)
            {
                foreach (DataRow dr in dtDieuG5.Rows)
                {
                    DataRow drKQ = TimKiem_BaoCao.TimDong(dtKQNV, dr["NgayHienThi"].ToString());
                    drKQ["CuocDieuG5"] = dr["CuocDieuG5"];
                    drKQ["DonDuocG5"] = dr["DonDuocG5"];
                    drKQ["PhanTramDonDuocG5"] = double.Parse(dr["PhanTramDonDuocG5"].ToString());
                }
            }
        }
        /// <summary>
        /// tim dong co ngay hien thi = ngayHienThi
        /// </summary>
        /// <param name="dtKQNV"></param>
        /// <param name="ngayHienThi"></param>
        /// <returns></returns>
        private static DataRow TimDong(DataTable dtKQNV, string ngayHienThi)
        {
            return dtKQNV.Rows.Find(ngayHienThi);
        }
        #endregion BCKetQuaDieuHanhTheoNgay

        #region BCTongHopKetQua

        #endregion BCTongHopKetQua
        /// <summary>
        /// BC tổng hợp nhân viên điều hành
        /// </summary>
        /// <param name="p"></param>
        /// <param name="p_2"></param>
        /// <param name="NhanVienID"></param>
        /// <returns></returns>
        public DataTable GROUP_BC4_5_TongHopKetQuaDieuHanhNV(DateTime tuNgay, DateTime denNgay, string NhanVienID)
        {
            int SoGiayGioiHanChuyenTongDai = ThongTinCauHinh.SoGiayGioiHanThoiGianChuyenTongDai;
            // Tao table luu tru chung
            DataTable dtKQNV = TimKiem_BaoCao.CreateTableTongHopKQNV();
            // Lay dulieu dien thoai
            DataTable dtDT = new DataTable();
            dtDT = new Data.TimKiem_BaoCao().GetTongHopKQNV_DienThoai_V3(tuNgay, denNgay, NhanVienID, SoGiayGioiHanChuyenTongDai);
            // Lay du lieu tong dai
            DataTable dtTD = new Data.TimKiem_BaoCao().GetTongHopKQNV_TongDai(tuNgay,denNgay, NhanVienID);
            // Lấy trung bình thời gian đón của tổng đài.
            DataTable dtTDTime = new Data.TimKiem_BaoCao().GetTongHopKQNV_TongDai_TBThoiGianDonKhach_V2(tuNgay, denNgay, NhanVienID);

            // lay du lieu CS
            DataTable dtCS ;
            if (license.idxCompany == 28)
                dtCS= new Data.TimKiem_BaoCao().GetTongHopKQNV_NVCSMK(tuNgay, denNgay, NhanVienID);
            else
                dtCS = new Data.TimKiem_BaoCao().GetTongHopKQNV_NVCS(tuNgay, denNgay, NhanVienID);

            // lấy thông tin thời gian của CS
            DataTable dtCSTime = new Data.TimKiem_BaoCao().GetTongHopKQNV_NVCS_TBThoiGianDonKhach(tuNgay, denNgay, NhanVienID);
            
            // lay du lieu ban tin ban gia 
            //DataTable dtBTin = new Data.TimKiem_BaoCao().GetGetTongHopKQNV_BanTinGia(tuNgay, denNgay, NhanVienID);
            // Thông tin nhóm
            //DataTable dtTheoNhom = new Data.TimKiem_BaoCao().GetTongHopKQNV_TheoNhom(tuNgay, denNgay, NhanVienID);

            DataTable dtNhanVien = new Users().GetAllUserInfo_ForReport(); 
            if (NhanVienID.Length > 0)
            {
                DataRow dr = dtKQNV.NewRow();
                dr["NhanVienID"] = NhanVienID;
                dr["NhanVienTen"] = Users.GetTenIDNhanVien(dtNhanVien, NhanVienID);
                dtKQNV.Rows.Add(dr);
            }
            else
            {
                if (dtNhanVien != null && dtNhanVien.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtNhanVien.Rows )
                    {
                        DataRow drNew = dtKQNV.NewRow();
                        drNew["NhanVienID"] = dr["USER_ID"].ToString();
                        drNew["NhanVienTen"] = dr["USER_ID"].ToString() + " - " + dr["FULLNAME"].ToString();
                        dtKQNV.Rows.Add(drNew);
                    }
                }
            }
            
            TimKiem_BaoCao.KQTongHopChenDuLieuDienThoai(dtKQNV, dtDT);
            TimKiem_BaoCao.KQTongHopChenDuLieuTongDai(dtKQNV, dtTD);
            TimKiem_BaoCao.KQTongHopChenDuLieuTongDaiThoiGianDon(dtKQNV, dtTDTime); 

            TimKiem_BaoCao.KQTongHopChenDuLieuCS(dtKQNV, dtCS);
            TimKiem_BaoCao.KQTongHopChenDuLieuCSThoiGianDon(dtKQNV, dtCSTime);

            //TimKiem_BaoCao.KQTongHopChenDuLieuBanTin(dtKQNV, dtBTin);
            //TimKiem_BaoCao.KQTongHopChenDuLieuTheoNhom(dtKQNV, dtTheoNhom);


            return dtKQNV;
        }

        

        private static void KQTongHopChenDuLieuDienThoai(DataTable dtKQNV, DataTable dtDT)
        {
            if (dtDT != null && dtDT.Rows.Count > 0)
            {
                foreach (DataRow dr in dtDT.Rows)
                {
                    DataRow drKQ = TimKiem_BaoCao.TimDong(dtKQNV, dr["NVDT"].ToString());
                    if (drKQ != null)
                    {
                        drKQ["CuocGoiNhan"] = dr["SoCuocGoi"];
                        drKQ["CuocGoiTaxi"] = dr["SoCuocTaxi"];
                        drKQ["CuocChuyenCham"] = dr["SoChuyenCham"];
                        drKQ["CuocGPS"] = dr["CuocGPS"];
                        drKQ["CuocDonDuocDT"] = dr["CuocDonDuoc"];
                        drKQ["CuocGoiNho"] = dr["CuocGoiNho"];
                        drKQ["DieuApp"] = dr["DieuApp"];
                        drKQ["DieuDam"] = dr["DieuDam"];
                        drKQ["ChuyenDam"] = dr["ChuyenDam"];
                        double soCuocGoi = Convert.ToDouble(dr["SoCuocGoi"].ToString());
                        double cuocChuyenCham = Convert.ToDouble(dr["SoChuyenCham"].ToString());
                        if (soCuocGoi != 0)
                            drKQ["PhanTramChuyenCham"] = Convert.ToDouble(cuocChuyenCham / soCuocGoi*100);
                        else
                            drKQ["PhanTramChuyenCham"] = 0;
                        //tính phần trăm đón được điện thoại
                        double cuocGoiTaxi = Convert.ToDouble(dr["SoCuocTaxi"].ToString());
                        double cuocDonDuocDT = Convert.ToDouble(dr["CuocDonDuoc"].ToString());
                        if (cuocGoiTaxi != 0)
                            drKQ["PhanTramDonDuocDT"] = Convert.ToDouble(cuocDonDuocDT / cuocGoiTaxi * 100);
                        else
                            drKQ["PhanTramDonDuocDT"] = 0;
                    }
                }
            }
        }
        private static void KQTongHopChenDuLieuTongDai(DataTable dtKQNV, DataTable dtTD)
        {
            if (dtTD != null && dtTD.Rows.Count > 0)
            {
                foreach (DataRow dr in dtTD.Rows)
                {
                    DataRow drKQ = TimKiem_BaoCao.TimDong(dtKQNV, dr["NVTD"].ToString());
                    if (drKQ != null)
                    {
                        drKQ["CuocGoiDieu"] =  dr["SoCuocDieu"];
                        drKQ["CuocDonDuoc"] = dr["TongDonDuoc"];
                        drKQ["CuocKhach999"] =dr["CuocKhach999"];
                        drKQ["TruotHoan"] = dr["TruotHoan"];
                        drKQ["CuocKhongXe"] = dr["CuocKhongXe"]; 
                        double soCuocDieu = Convert.ToDouble(dr["SoCuocDieu"].ToString());
                        double cuocDonDuoc = Convert.ToDouble(dr["TongDonDuoc"].ToString());
                        if (soCuocDieu != 0)
                            drKQ["PhanTramDonDuoc"] = Convert.ToDouble(cuocDonDuoc / soCuocDieu * 100);
                        else
                            drKQ["PhanTramDonDuoc"] = 0;
                    }
                }
            }
        }
        /// <summary>
        /// lấy thông tin số giây bình quân/số cuốc 
        /// 
        /// </summary>
        /// <param name="dtKQNV"></param>
        /// <param name="dtDTTime"></param>
        private static void KQTongHopChenDuLieuTongDaiThoiGianDon(DataTable dtKQNV, DataTable dtDTTime)
        {
            if (dtDTTime != null && dtDTTime.Rows.Count > 0)
            {
                foreach (DataRow dr in dtDTTime.Rows)
                {
                    DataRow drKQ = TimKiem_BaoCao.TimDong(dtKQNV, dr["NVTD"].ToString());
                    if (drKQ != null)
                    {
                        drKQ["TDSoCuocTinhBinhQuanTGDon"] = dr["SoCuoc"];
                        drKQ["TDSoGiayBinhQuanDon"]        = dr["TBTGDonTD"];                        
                    }
                }
            }
        }

        private static void KQTongHopChenDuLieuCS(DataTable dtKQNV, DataTable dtCS)
        {
            if (dtCS != null && dtCS.Rows.Count > 0)
            {
                foreach (DataRow dr in dtCS.Rows)
                {
                    DataRow drKQ = TimKiem_BaoCao.TimDong(dtKQNV, dr["NVCS"].ToString());
                    if (drKQ != null)
                    {
                        drKQ["CSCuocGoiTaxi"] = dr["SoCuocGoiTaxi"];
                        drKQ["CuocGoiCoCS"] = dr["CuocGoiCoCS"];
                        drKQ["CuocGoiCS_DonDuoc"] = dr["CuocGoiCS_DonDuoc"];

                        double csCuocDonDuoc = Convert.ToDouble(dr["CuocGoiCS_DonDuoc"].ToString());
                        double csCuocGoiTaxi = Convert.ToDouble(dr["SoCuocGoiTaxi"].ToString());
                        double cuocGoiCoCS = Convert.ToDouble(dr["CuocGoiCoCS"].ToString());

                        if (cuocGoiCoCS != 0)
                        {
                            drKQ["PhanTramCS"] = Convert.ToDouble(cuocGoiCoCS / csCuocGoiTaxi * 100);
                            drKQ["PhanTramCSDonDuoc"] = Convert.ToDouble(csCuocDonDuoc / csCuocGoiTaxi * 100);
                        }
                        else
                        {
                            drKQ["PhanTramCS"] = 0;
                            drKQ["PhanTramCSDonDuoc"] = 0;
                        }
                        //drKQ["TongCuoc888"] = dr["TongCuoc888"];
                    }
                }
            }
        }

        /// <summary>
        /// ghep thoi gian don trung bình của CS
        /// </summary>
        /// <param name="dtKQNV"></param>
        /// <param name="dtCSTime"></param>
        private static void KQTongHopChenDuLieuCSThoiGianDon(DataTable dtKQNV, DataTable dtCSTime)
        {
            if (dtCSTime != null && dtCSTime.Rows.Count > 0)
            {
                foreach (DataRow dr in dtCSTime.Rows)
                {
                    DataRow drKQ = TimKiem_BaoCao.TimDong(dtKQNV, dr["NVCS"].ToString());
                    if (drKQ != null)
                    {
                        drKQ["CSSoCuocTinhBinhQuanTGDon"] = dr["SoCuoc"];
                        drKQ["CSSoGiayBinhQuanDon"]       = dr["TBTGDonMK"];                        
                    }
                }
            }
        }

        private static void KQTongHopChenDuLieuBanTin(DataTable dtKQNV, DataTable dtBanTin)
        {
            if (dtBanTin != null && dtBanTin.Rows.Count > 0)
            {
                foreach (DataRow dr in dtBanTin.Rows)
                {
                    DataRow drKQ = TimKiem_BaoCao.TimDong(dtKQNV, dr["NVBanTin"].ToString());
                    if (drKQ != null)
                    {
                        drKQ["CuoiGoiGiaiQuyet"] = dr["SoCuocGoiGiaiQuyet"];
                        drKQ["CuocGoiGiaiQuyetDuoc"] = dr["SoCuocGoiDaGiaiQuyetDuoc"];


                        double cuocGoiGiaiQuyet = Convert.ToDouble(dr["SoCuocGoiGiaiQuyet"].ToString());
                        double cuocGoiGiaiQuyetDuoc = Convert.ToDouble(dr["SoCuocGoiDaGiaiQuyetDuoc"].ToString());

                        if (cuocGoiGiaiQuyet != 0)
                        {
                            drKQ["PhanTramGiaiQuyetDuoc"] = Convert.ToDouble(cuocGoiGiaiQuyetDuoc / cuocGoiGiaiQuyet * 100);

                        }
                        else
                        {
                            drKQ["PhanTramGiaiQuyetDuoc"] = 0;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// thêm thông tin nhóm vào 
        /// </summary>
        /// <param name="dtKQNV"></param>
        /// <param name="dtTheoNhom"></param>
        private static void KQTongHopChenDuLieuTheoNhom(DataTable dtKQNV, DataTable dtTheoNhom)
        {
            if (dtTheoNhom != null && dtTheoNhom.Rows.Count > 0)
            {
                foreach (DataRow dr in dtTheoNhom.Rows)
                {
                    DataRow drKQ = TimKiem_BaoCao.TimDong(dtKQNV, dr["NV"].ToString());
                    if (drKQ != null)
                    {
                        drKQ["CuocGoiDieuNHOM"] = dr["CuocGoiDieuNHOM"];
                        drKQ["DonDuocNHOM"] = dr["DonDuocNHOM"];


                        double CuocGoiDieuNHOM = Convert.ToDouble(dr["CuocGoiDieuNHOM"].ToString());
                        double DonDuocNHOM = Convert.ToDouble(dr["DonDuocNHOM"].ToString());

                        if (CuocGoiDieuNHOM != 0)
                        {
                            drKQ["PhanTramDonDuocNHOM"] = Convert.ToDouble(DonDuocNHOM / CuocGoiDieuNHOM * 100);

                        }
                        else
                        {
                            drKQ["PhanTramDonDuocNHOM"] = 0;
                        }
                    }
                }
            }
        }


        private static DataTable CreateTableTongHopKQNV()
        {
            DataTable dt = new DataTable();
            DataColumn[] keyPrimary = new DataColumn[1];
            //NgayHienThi
            DataColumn dcNhanVienID = new DataColumn("NhanVienID", Type.GetType("System.String"));
            dt.Columns.Add(dcNhanVienID);
            keyPrimary[0] = dcNhanVienID;
            DataColumn dcNhanVienTen = new DataColumn("NhanVienTen", Type.GetType("System.String"));
            dt.Columns.Add(dcNhanVienTen);
            // DIENTHOAI
            // CuoiGoiNhan
            DataColumn dcCuocGoiNhan = new DataColumn("CuocGoiNhan", Type.GetType("System.Int32"));
            dt.Columns.Add(dcCuocGoiNhan);
            // CuocGoiNho
            DataColumn dcCuocGoiNho = new DataColumn("CuocGoiNho", Type.GetType("System.Int32"));
            dt.Columns.Add(dcCuocGoiNho);
            //CuocDonDuocDT
            DataColumn dcCuocDonDuocDT = new DataColumn("CuocDonDuocDT", Type.GetType("System.Int32"));
            dt.Columns.Add(dcCuocDonDuocDT);
            // CuocGoiTaxi
            DataColumn dcCuocGoiTaxi = new DataColumn("CuocGoiTaxi", Type.GetType("System.Int32"));
            dt.Columns.Add(dcCuocGoiTaxi);
            //cuoc goi co GPS
            DataColumn dcCuocGoiGPS = new DataColumn("CuocGPS", Type.GetType("System.Int32"));
            dt.Columns.Add(dcCuocGoiGPS);
            //Cuốc điều app
            DataColumn dcCuocGoiDieuApp = new DataColumn("DieuApp", Type.GetType("System.Int32"));
            dt.Columns.Add(dcCuocGoiDieuApp);
            //Cuốc điều đàm
            DataColumn dcCuocGoiDieuDam = new DataColumn("DieuDam", Type.GetType("System.Int32"));
            dt.Columns.Add(dcCuocGoiDieuDam);
            //Cuốc chuyển đàm
            DataColumn dcCuocGoiChuyenDam = new DataColumn("ChuyenDam", Type.GetType("System.Int32"));
            dt.Columns.Add(dcCuocGoiChuyenDam);
            // CuocChuyenCham
            DataColumn dcCuocChuyenCham = new DataColumn("CuocChuyenCham", Type.GetType("System.Int32"));
            dt.Columns.Add(dcCuocChuyenCham);
            // PhanTramChuyenCham
            DataColumn dcPhanTramChuyenCham = new DataColumn("PhanTramChuyenCham", Type.GetType("System.Double"));
            dt.Columns.Add(dcPhanTramChuyenCham);
            //Vi tri TONGDAI
            //CuocGoiDieu
            DataColumn dcCuocGoiDieu = new DataColumn("CuocGoiDieu", Type.GetType("System.Int32"));
            dt.Columns.Add(dcCuocGoiDieu);
            // CuocDonDuoc
            DataColumn dcCuocDonDuoc = new DataColumn("CuocDonDuoc", Type.GetType("System.Int32"));
            dt.Columns.Add(dcCuocDonDuoc);
            // TruotHoan
            DataColumn dcTruotHoan = new DataColumn("TruotHoan", Type.GetType("System.Int32"));
            dt.Columns.Add(dcTruotHoan);
            // CuocKhongXe
            DataColumn dcCuocKhongXe = new DataColumn("CuocKhongXe", Type.GetType("System.Int32"));
            dt.Columns.Add(dcCuocKhongXe);
            // PhanTramDonDuoc
            DataColumn dcPhanTramDonDuoc = new DataColumn("PhanTramDonDuoc", Type.GetType("System.Double"));
            dt.Columns.Add(dcPhanTramDonDuoc);
             // PhanTramDonDuocDT
            DataColumn dcPhanTramDonDuocDT = new DataColumn("PhanTramDonDuocDT", Type.GetType("System.Double"));
            dt.Columns.Add(dcPhanTramDonDuocDT);
            // số cuốc tính bình quân thời gian đón
            DataColumn dcTDSoCuocTinhBinhQuanTGDon = new DataColumn("TDSoCuocTinhBinhQuanTGDon", Type.GetType("System.Double"));
            dt.Columns.Add(dcTDSoCuocTinhBinhQuanTGDon);
            // số giây bình quân đón
            DataColumn dcTDSoGiayBinhQuanDon = new DataColumn("TDSoGiayBinhQuanDon", Type.GetType("System.Double"));
            dt.Columns.Add(dcTDSoGiayBinhQuanDon);
            // cuoc 999            
            DataColumn dcCuoc999 = new DataColumn("CuocKhach999", Type.GetType("System.Int32"));
            dt.Columns.Add(dcCuoc999);
            // Vi Tri CSKH
            // CSCuocGoiTaxi
            DataColumn dcCSCuocGoiTaxi = new DataColumn("CSCuocGoiTaxi", Type.GetType("System.Int32"));
            dt.Columns.Add(dcCSCuocGoiTaxi);
            // CuocGoiCoCS
            DataColumn dcCuocGoiCoCS = new DataColumn("CuocGoiCoCS", Type.GetType("System.Int32"));
            dt.Columns.Add(dcCuocGoiCoCS);
            // PhanTramCS
            DataColumn dcPhanTramCS = new DataColumn("PhanTramCS", Type.GetType("System.Double"));
            dt.Columns.Add(dcPhanTramCS);
            // CSCuocGoiDonDuoc
            DataColumn dcCSCuocGoiDonDuoc = new DataColumn("CuocGoiCS_DonDuoc", Type.GetType("System.Int32"));
            dt.Columns.Add(dcCSCuocGoiDonDuoc);
            // CSPhanTramDonDuoc
            DataColumn dcCSPhanTramDonDuoc = new DataColumn("PhanTramCSDonDuoc", Type.GetType("System.Double"));
            dt.Columns.Add(dcCSPhanTramDonDuoc);

            // số cuốc tính bình quân thời gian đón
            DataColumn dcCSSoCuocTinhBinhQuanTGDon = new DataColumn("CSSoCuocTinhBinhQuanTGDon", Type.GetType("System.Double"));
            dt.Columns.Add(dcCSSoCuocTinhBinhQuanTGDon);
            // số giây bình quân đón
            DataColumn dcCSSoGiayBinhQuanDon = new DataColumn("CSSoGiayBinhQuanDon", Type.GetType("System.Double"));
            dt.Columns.Add(dcCSSoGiayBinhQuanDon);

            //// TongCuoc888
            //DataColumn dcTongCuoc888 = new DataColumn("TongCuoc888", Type.GetType("System.Int32"));
            //dt.Columns.Add(dcTongCuoc888);
            //// Theo NHOM
            //// -- Cuộc gọi tham gia
            //DataColumn dcCuocGoiDieuNHOM = new DataColumn("CuocGoiDieuNHOM", Type.GetType("System.Int32"));
            //dt.Columns.Add(dcCuocGoiDieuNHOM);
            //// -- cuoc gọi đón được 
            //DataColumn dcDonDuocNHOM = new DataColumn("DonDuocNHOM", Type.GetType("System.Int32"));
            //dt.Columns.Add(dcDonDuocNHOM);
            //// -- % thêm nhóm 
            //DataColumn dcPhanTramDonDuocNHOM = new DataColumn("PhanTramDonDuocNHOM", Type.GetType("System.Double"));
            //dt.Columns.Add(dcPhanTramDonDuocNHOM);
            //// Vi tri BANTIN_GIA
            //// CuoiGoiGiaiQuyet
            //DataColumn dcCuoiGoiGiaiQuyet = new DataColumn("CuoiGoiGiaiQuyet", Type.GetType("System.Int32"));
            //dt.Columns.Add(dcCuoiGoiGiaiQuyet);
            //// CuocGoiGiaiQuyetDuoc
            //DataColumn dcCuocGoiGiaiQuyetDuoc = new DataColumn("CuocGoiGiaiQuyetDuoc", Type.GetType("System.Int32"));
            //dt.Columns.Add(dcCuocGoiGiaiQuyetDuoc);
            //// PhanTramGiaiQuyetDuoc
            //DataColumn dcPhanTramGiaiQuyetDuoc = new DataColumn("PhanTramGiaiQuyetDuoc", Type.GetType("System.Double"));
            //dt.Columns.Add(dcPhanTramGiaiQuyetDuoc);

            dt.PrimaryKey = keyPrimary;
            return dt;
        }
        /// <summary>
        /// bao cao tinh trang vung dam 7.4
        /// </summary>
        /// <returns></returns>
        public DataTable GROUP_BC_TinhTrangVungDam()
        {
            // Lay thong tin du lieu cuoc goi
            // Vung, Dam,  CSKH1, CSKH2, TinGia,  CoXeNhan,  ChuaCoXeNhan,   KhachHen
            DataTable dtCuocGoi = new Data.TimKiem_BaoCao().GROUP_BC_7_4_TinhTrangVungDam(); 
            // Lay thong tin nguoi dang nhap
            // Vung, Ten, IsMayTinh
            DataTable dtNguoiDung = new Data.TimKiem_BaoCao().GROUP_BC_7_4_TinhTrangVungDamNguoiDangDangNhap();
            if (dtCuocGoi != null && dtNguoiDung != null)
            {
                if (dtCuocGoi.Rows.Count > 0)
                {
                    for (int i = 0; i < dtCuocGoi.Rows.Count; i++)
                    {
                        DataRow dr = dtCuocGoi.Rows[i];
                        int vung = 0;
                        int.TryParse(dr["Vung"].ToString(), out vung);
                        byte moiKhach1 = 0;
                        if (vung > 0 && vung <= 8)
                        {

                            foreach (DataRow drNguoi in dtNguoiDung.Rows)
                            {
                                int vungNguoi = 0;
                                int.TryParse(drNguoi["Vung"].ToString(), out vungNguoi);
                                if (vung == vungNguoi)  // hai truong vung = nhau, lay thong tin tung vi tri
                                {
                                    if (vung <= 8) // lay tong dai, moi khach
                                    {
                                        if (drNguoi["IsMayTinh"].ToString() == "TD")
                                        {
                                            dr["Dam"] = drNguoi["Ten"];
                                        }
                                        else if (drNguoi["IsMayTinh"].ToString() == "MK")
                                        {
                                            if (moiKhach1 == 0)
                                            {
                                                dr["CSKH1"] = drNguoi["Ten"];
                                                moiKhach1 = 1;
                                            }
                                            else
                                            {
                                                dr["CSKH2"] = drNguoi["Ten"];
                                                moiKhach1 = 0;
                                            }

                                        }
                                    }
                                    else if (vung > 8) // lay ban tin gia
                                    {
                                        if (drNguoi["IsMayTinh"].ToString() == "TD")
                                        {
                                            if (dr["Dam"] == DBNull.Value || dr["Dam"].ToString().Length <= 0)
                                            {
                                                dr["Dam"] = drNguoi["Ten"];
                                            }
                                            else
                                            {
                                                dr["TinGia"] = drNguoi["Ten"];
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else  // du lieu vung 9,10 =  "9,10"
                        {
                            // chạy lấy vùng 9/10  
                            foreach (DataRow drNguoi in dtNguoiDung.Rows)
                            {
                                int k = 0;
                                if (drNguoi["Vung"].ToString().Contains("9;10"))
                                {
                                    k++;
                                    if (k == 1)
                                    {
                                        dr["Dam"] = drNguoi["Ten"];
                                    }
                                    else if (k == 2)
                                    {
                                        dr["CSKH1"] = drNguoi["Ten"];
                                    }
                                    else if (k == 3)
                                    {
                                        dr["CSKH2"] = drNguoi["Ten"];
                                    }
                                    else if (k == 4)
                                    {
                                        dr["TinGia"] = drNguoi["Ten"];
                                    }

                                }                        
                            }
                    }
                }
                
                    
                }
            }
            return dtCuocGoi;
        }
        #endregion BAO CAO NEW  (chuyen sang MyDinh)

        public DataTable GROUP_BC_8_3_BaoCaoTHCuocGoiTheoSoDienThoai(DateTime TuNgay, DateTime DenNgay, string Sodienthoai)
        {
            DataTable table = new DataTable();
            table.Columns.Add("PhoneNumber");
            table.Columns.Add("DiaChiGoi");
            table.Columns.Add("SoCuoc");
            table.Columns.Add("DonDuoc");
            table.Columns.Add("TruotHoan");
            table.Columns.Add("KhongXe");

            DataTable dt = new Taxi.Data.TimKiem_BaoCao().GROUP_BC_8_3_BaoCaoTHCuocGoiTheoSoDienThoai(TuNgay, DenNgay, Sodienthoai);

            dt.AsEnumerable().GroupBy(dr => dr["PhoneNumber"].ToString()).Select(g =>
            {
                DataRow r = table.NewRow();
                r["PhoneNumber"] = g.Key;
                r["DiaChiGoi"] = g.FirstOrDefault()["DiaChiDonKhach"];
                r["SoCuoc"] = g.Sum(dr => Convert.ToInt32(dr["SoCuoc"]));
                r["DonDuoc"] = g.Sum(dr => Convert.ToInt32(dr["DonDuoc"]));
                r["TruotHoan"] = g.Sum(dr => Convert.ToInt32(dr["TruotHoan"]));
                r["KhongXe"] = g.Sum(dr => Convert.ToInt32(dr["KhongXe"]));

                table.Rows.Add(r);
                return -1;
            }).Count();

            return table;
        }

        public DataTable GROUP_BC_GPS_BCCuocKhachGPSTheoQuan(DateTime TuNgay, DateTime DenNgay, bool DonDuoc, bool TruotHoan, bool KhongXe)
        {
            return new Taxi.Data.TimKiem_BaoCao().GROUP_BC_GPS_BCCuocKhachGPSTheoQuan(TuNgay, DenNgay, DonDuoc, TruotHoan, KhongXe);
        }

        #region Quynh
        public DataTable GROUP_BC_8_2_BaoCaoChiTietCuocGoiDenTheoNgay(DateTime TuNgay, DateTime DenNgay, string Sodienthoai)
        {
            return new Taxi.Data.TimKiem_BaoCao().GROUP_BC_8_2_BaoCaoChiTietCuocGoiDenTheoNgay(TuNgay, DenNgay, Sodienthoai);
        }
        public DataTable GROUP_BC_8_2_BaoCaoTongHopKhachGoiThuongXuyen(DateTime TuNgay, DateTime DenNgay, string Sodienthoai, string LoaiKhachGoi, string CoDinh,int soCuoc)
        {
            return new Taxi.Data.TimKiem_BaoCao().GROUP_BC_8_2_BaoCaoTongHopKhachGoiThuongXuyen(TuNgay, DenNgay, Sodienthoai, LoaiKhachGoi, CoDinh,soCuoc);
        }

        public DataTable GROUP_BC_1_6_BaoCaoTongCuocKhachThoat999(DateTime TuNgay, DateTime DenNgay, int Vung)
        {
            return new Taxi.Data.TimKiem_BaoCao().GROUP_BC_1_6_BaoCaoTongCuocKhachThoat999(TuNgay, DenNgay, Vung);
        }
        public DataTable GROUP_BC_1_6_BaoCaoTongCuocKhachThoat999_V2(DateTime TuNgay, DateTime DenNgay, byte Vung)
        {
            return new Taxi.Data.TimKiem_BaoCao().GROUP_BC_1_6_BaoCaoTongCuocKhachThoat999_V2(TuNgay, DenNgay, Vung);
        }
        public DataTable GROUP_BC_1_7_BaoCaoChiTietKhachThoat999(string TuNgay, string DenNgay, string TruongCa, string NhanVien)
        {
            return new Taxi.Data.TimKiem_BaoCao().GROUP_BC_1_7_BaoCaoChiTietKhachThoat999(TuNgay, DenNgay, TruongCa, NhanVien);
        }
        public DataTable GROUP_BC_1_7_BaoCaoChiTietKhachThoat999_V2(DateTime TuNgay, DateTime DenNgay, string TruongCa, string NhanVien)
        {
            return new Taxi.Data.TimKiem_BaoCao().GROUP_BC_1_7_BaoCaoChiTietKhachThoat999_V2(TuNgay, DenNgay, TruongCa, NhanVien);
        }
        public DataTable GetDanhSach_NguoiDung(string RoleID)
        {
            return new Taxi.Data.TimKiem_BaoCao().GetDanhSach_NguoiDung(RoleID);
        }
        public DataTable GROUP_BC_1_8_BaoCaoChiTietKhachDat(DateTime TuNgay, DateTime DenNgay)
        {
            return new Taxi.Data.TimKiem_BaoCao().GROUP_BC_1_8_BaoCaoChiTietKhachDat(TuNgay, DenNgay);
        }

        public DataTable GROUP_BC_GPS_1_BCCuocKhachGPSTheoNgay(DateTime TuNgay, DateTime DenNgay,string MaNhanVien)
        {
            return new Taxi.Data.TimKiem_BaoCao().GROUP_BC_GPS_1_BCCuocKhachGPSTheoNgay(TuNgay, DenNgay, MaNhanVien);
        }

        public DataTable GROUP_BC_GPS_2_BCCuocKhachGPS_CoCanhBao(DateTime TuNgay, DateTime DenNgay, string Vung, string MaNhanVien, KieuCanhBaoKhiNhapThongTin? kieuCanhBao)
        {
            return new Taxi.Data.TimKiem_BaoCao().GROUP_BC_GPS_2_BCCuocKhachGPS_CoCanhBao(TuNgay, DenNgay, Vung, MaNhanVien, kieuCanhBao);
        }

        public DataTable GetData_BCDSKHThanThiet(DateTime TuNgay, DateTime DenNgay, int LoaiKH)
        {
            return new Data.TimKiem_BaoCao().GROUP_BC_DanhSachKHThanThiet(TuNgay, DenNgay, LoaiKH);
        }
        #endregion 

        // Lay thong tin du lieu log vung
        /// <summary>
        /// hàm trả về số liệu log vung
        /// </summary>
        public static List<BaoCaoLogVung> GetBaoCaoLogChuyenVung(DateTime TuNgay, DateTime DenNgay)
        {
            List<BaoCaoLogVung> lstLogVung = new List<BaoCaoLogVung>();
            DataTable dt = new Data.TimKiem_BaoCao().GetBaoCaoLogChuyenVung(TuNgay, DenNgay);
            if (dt.Rows.Count <= 0) return null;

            foreach (DataRow dr in dt.Rows)
            {
                lstLogVung.Add(TimKiem_BaoCao.GetLogVung(dr));
            }
            return lstLogVung;
        }

        private static BaoCaoLogVung GetLogVung(DataRow dr)
        {
            BaoCaoLogVung objLogVung = new BaoCaoLogVung();
            objLogVung.ID_DieuHanh = long.Parse(dr["ID"].ToString());
            objLogVung.Line = dr["Line"].ToString();
            objLogVung.PhoneNumber = dr["PhoneNumber"].ToString();
            objLogVung.ThoiDiemGoi = (DateTime)dr["ThoiDiemGoi"];
            objLogVung.DoDaiCuocGoi = (DateTime)dr["Duration"];
            objLogVung.FileVoicePath = dr["FileVoicePath"].ToString();
            objLogVung.ThoiDiemGoiGio = string.Format("{0:yyyy-MM-dd HH:mm:ss}", objLogVung.ThoiDiemGoi).Substring(11, 8);
            objLogVung.ThoiDiemGoiNgay = string.Format("{0:yyyy-MM-dd HH:mm:ss}", objLogVung.ThoiDiemGoi).Substring(0, 10);
            try
            {
                objLogVung.TrangThaiCuocGoi = (TrangThaiCuocGoiTaxi) byte.Parse(dr["TrangThaiCuocGoi"].ToString());
            }
            catch (Exception ex)
            {
                objLogVung.TrangThaiCuocGoi = Taxi.Utils.TrangThaiCuocGoiTaxi.TrangThaiKhac;
            }

            if (StringTools.TrimSpace(dr["ThoiDiemChuyenTongDai"].ToString()).Length > 0)
            {
                objLogVung.ThoiDiemChuyenTongDai = int.Parse(dr["ThoiDiemChuyenTongDai"].ToString());
            }
            else
                objLogVung.ThoiDiemChuyenTongDai = 0;

            if (StringTools.TrimSpace(dr["SoLuotDoChuong"].ToString()).Length > 0)
                objLogVung.SoLuotDoChuong = int.Parse(dr["SoLuotDoChuong"].ToString());
            objLogVung.DiaChiDonKhach = dr["DiaChiDonKhach"].ToString();
            objLogVung.KieuKhachHangGoiDen = (KieuKhachHangGoiDen)int.Parse(dr["KieuKhachHangGoiDen"].ToString());
            objLogVung.GoiTaxi = dr["GoiTaxi"].ToString() == "1" ? true : false;
            objLogVung.GoiLai = dr["GoiLai"].ToString() == "1" ? true : false;
            // goi khieu nai
            if (dr["GoiKhieuNai"] == null) objLogVung.GoiKhieuNai = false;
            else objLogVung.GoiKhieuNai = dr["GoiKhieuNai"].ToString() == "1" ? true : false;

            objLogVung.ThongTinKhac = dr["ThongTinKhac"].ToString() == "1" ? true : false;//GoiKhac
            objLogVung.LoaiXe = dr["LoaiXe"].ToString();
            if (StringTools.TrimSpace(dr["SoLuong"].ToString()).Length > 0)
                objLogVung.SoLuong = dr["SoLuong"].ToString();
            else objLogVung.SoLuong = string.Empty;

            if (objLogVung.LoaiXe.Contains("4")) objLogVung.ChonTaxi4Cho = true;
            if (objLogVung.LoaiXe.Contains("7")) objLogVung.ChonTaxi7Cho = true;
            if (objLogVung.LoaiXe.Contains("0")) { objLogVung.ChonTaxi7Cho = false; objLogVung.ChonTaxi4Cho = false; }

            if (StringTools.TrimSpace(dr["Vung"].ToString()).Length > 0)
                objLogVung.MaVung = dr["Vung"].ToString();
            else objLogVung.MaVung = string.Empty;
            objLogVung.LenhDienThoai = dr["LenhDienThoai"].ToString();
            objLogVung.LenhTongDai = dr["LenhTongDai"].ToString();
            objLogVung.MaNhanVienDienThoai = dr["MaNhanVienDienThoai"].ToString();
            objLogVung.MaNhanVienTongDai = dr["MaNhanVienTongDai"].ToString();
            objLogVung.XeNhan = dr["XeNhan"].ToString();
            objLogVung.XeDon = dr["XeDon"].ToString();
            objLogVung.DiaChiTraKhach = dr["DiaChiTraKhach"].ToString();
            objLogVung.GhiChuDienThoai = dr["GhiChuDienThoai"].ToString();
            objLogVung.GhiChuTongDai = dr["GhiChuTongDai"].ToString();
            if (StringTools.TrimSpace(dr["TrangThaiLenh"].ToString()).Length > 0)
                objLogVung.TrangThaiLenh = (TrangThaiLenhTaxi)int.Parse(dr["TrangThaiLenh"].ToString());
            else objLogVung.TrangThaiLenh = TrangThaiLenhTaxi.KhongTruyenDi;

            objLogVung.CuocGoiLaiIDs = StringTools.TrimSpace(dr["CuocGoiLaiIDs"].ToString());
            if (objLogVung.CuocGoiLaiIDs.Contains(";"))
                objLogVung.ThongTinGoiLai = string.Empty; //GetThongTinGoiLai(objLogVung.CuocGoiLaiIDs);
            if (dr["ThoiGianDieuXe"].ToString().Length > 0)
                objLogVung.ThoiGianDieuXe = int.Parse(dr["ThoiGianDieuXe"].ToString());
            if (dr["ThoiGianDonKhach"].ToString().Length > 0)
                objLogVung.ThoiGianDonKhach = int.Parse(dr["ThoiGianDonKhach"].ToString());
            objLogVung.SoLuongChuyenVung = int.Parse(dr["SoLanChuyenVung"].ToString());
            return objLogVung;
        }


        public static DataTable GetBaoCaoLogChuyenVungChiTietVung(long idDieuHanh)
        {
            return new Data.TimKiem_BaoCao().GetBaoCaoLogChuyenVungChiTietVung(idDieuHanh);
        }

        /// <summary>
        /// báo cáo xe nhận không thuộc xe đề cử
        /// Congnt - 21/09/2012
        /// </summary>
        public DataTable GROUP_BC_GPS_2_BCXeNhanKhongThuocXeDeCu(DateTime TuNgay, DateTime DenNgay)
        {
            return new Data.TimKiem_BaoCao().GROUP_BC_GPS_2_BCXeNhanKhongThuocXeDeCu(TuNgay, DenNgay);
        }

        public static DataTable GROUP_BC_SuCoVeThe(string SoHieuXe, DateTime TuNgay, DateTime DenNgay)
        {
            return new Data.TimKiem_BaoCao().GROUP_BC_SuCoVeThe(SoHieuXe, TuNgay, DenNgay);
        }

        public static DataTable GROUP_BC_XeGapSuCo(string SoHieuXe, DateTime TuNgay, DateTime DenNgay)
        {
            return new Data.TimKiem_BaoCao().GROUP_BC_XeGapSuCo(SoHieuXe, TuNgay, DenNgay);
        }


        #region BC Khach Quen - CSKH - TrungKien

        /// <summary>
        /// Báo cáo hanh trình xe
        /// </summary>
        public static DataTable GetBCNhatKyDieuHanh(string SoHieuXe, DateTime TuNgayGio, DateTime DenNgayGio)
        {
            return new Data.TimKiem_BaoCao().GetBCNhatKyDieuHanh(SoHieuXe, TuNgayGio, DenNgayGio);
        }

        public static DataTable TimKhachHangThanThiet(DateTime TuNgay, DateTime DenNgay, int SoCuoc, bool IsCoDinh)
        {
            return new Data.TimKiem_BaoCao().TimKhachHangThanThiet(TuNgay, DenNgay, SoCuoc, IsCoDinh);
        }
        public static DataTable TimKhachHangThanThietBySoDienThoai(DateTime TuNgay, DateTime DenNgay, string SoDienThoai)
        {
            return new Data.TimKiem_BaoCao().TimKhachHangThanThietBySoDienThoai(TuNgay, DenNgay, SoDienThoai);
        }

        public static DataTable BaoCaoKhachHangThanThiet(DateTime tuNgay, DateTime denNgay, int soCuoc)
        {
            return new Data.TimKiem_BaoCao().BaoCaoKhachHangThanThiet(tuNgay, denNgay, soCuoc);
        }

        public static DataTable BaoCaoKhachHangThanThietDaCoMa(DateTime tuNgay, DateTime denNgay, int soCuoc)
        {
            return new Data.TimKiem_BaoCao().BaoCaoKhachHangThanThietDaCoMa(tuNgay, denNgay, soCuoc);
        }

        public static DataTable BaoCaoKhachHangThanThietTheoThang(DateTime tuNgay, DateTime denNgay)
        {
            return new Data.TimKiem_BaoCao().BaoCaoKhachHangThanThietTheoThang(tuNgay, denNgay);
        }
        public static DataTable BaoCaoKhachHangThanThietTheoThang_V2(DateTime tuNgay, DateTime denNgay, string SoDienThoai, string TenKH, string DiaChi,int TypeKH=0)
        {
            try
            {
                return new Data.TimKiem_BaoCao().BaoCaoKhachHangThanThietTheoThang_V3(tuNgay, denNgay, SoDienThoai, TenKH, DiaChi, TypeKH);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("BaoCaoKhachHangThanThietTheoThang_V2: ", ex);                
                return new DataTable();
            }
        }
        #endregion

        #region FastTaxi

        public static DataTable FastTaxi_BC_BaoCaoTongHopCuocGoiDenTheoGio(DateTime start, DateTime end)
        {
           return new Data.TimKiem_BaoCao().FastTaxi_BC_BaoCaoTongHopCuocGoiDenTheoGio(start, end);
        }
        
        #endregion

      
    }

}
