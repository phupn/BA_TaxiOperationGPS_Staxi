using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Taxi.Utils;
using Taxi.Utils;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Taxi.Business
{

    public class DieuHanhTaxi
    {
        #region Members & Properties
        //@ID bigint,
        private long mID_DieuHanh;
        public long ID_DieuHanh
        {
            get { return mID_DieuHanh; }
            set { mID_DieuHanh = value; }
        }
        public string LenhLaiXe { get; set; }
        public int G5_Type { get; set; }
        public DateTime G5_SendDate { get; set; }

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
        // lưu là giây
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


        private DateTime mDoDaiCuocGoi;

        public DateTime DoDaiCuocGoi
        {
            get { return mDoDaiCuocGoi; }
            set { mDoDaiCuocGoi = value; }
        }
        public string HienThiDoDaiCuocGoi
        {
            get { return string.Format("{0: mm:ss}", DoDaiCuocGoi); }
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
        private string mSanBay_DuongDai;
        public string SanBay_DuongDai
        {
            get { return mSanBay_DuongDai; }
            set { mSanBay_DuongDai = value; }
        }
        //@Vung int,
        private string mMaVung;
        public string MaVung
        {
            get { return mMaVung; }
            set { mMaVung = value.Replace("_", ""); ; }
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

        private KieuKhachHangGoiDen mKieuKhachHangGoiDen;
        /// <summary>
        /// Kieu khach hang goi den
        /// </summary>
        public KieuKhachHangGoiDen KieuKhachHangGoiDen
        {
            get { return mKieuKhachHangGoiDen; }
            set { mKieuKhachHangGoiDen = value; }
        }

        private KieuCuocGoi _KieuCuocGoi;

        public KieuCuocGoi KieuCuocGoi
        {
            get { return _KieuCuocGoi; }
            set { _KieuCuocGoi = value; }
        }
        /// <summary>
        /// phan loai cuoc goi tra ve dang ky tu de phan biet
        /// </summary>
        private string mPhanLoai;
        public string PhanLoai
        {
            get { return mPhanLoai; }
            set { mPhanLoai = value; }
        }

        /// <summary>
        /// biển trả về thông tin kết quả của cuộc gọi taxi
        /// A : Đón được, B : Trượt, hoãn, C : Không xe
        /// </summary>
        private string mKetQua;
        public string KetQua
        {
            set { mKetQua = value; }
            get { return mKetQua; }
        }

        private TrangThaiCuocGoiTaxi mTrangThaiCuocGoi;

        //TrangThaiKhac = 0,       // giong 999 - CP cu
        //CuocGoiDonDuocKhach = 1,
        //CuocGoiTruot = 2,
        //CuocGoiHoan = 3,
        //CuocGoiKhongXe = 4,
        //CuocGoiChuaXacDinh = 5,  

        public TrangThaiCuocGoiTaxi TrangThaiCuocGoi
        {
            get { return mTrangThaiCuocGoi; }
            set { mTrangThaiCuocGoi = value; }
        }

        private TrangThaiLenhTaxi mTrangThaiLenh;
        /// <summary>
        /// Trang thai lenh 
        /// KhongTruyenDi = 0,
        /// DienThoai =1,
        /// BoDam=2,
        /// KetThuc =3,
        /// KetThucCuaDienThoai=4, 
        ///  DienThoaiGuiSangMoiKhach= 5, // điện thoại gửi thông tin cuốc khách sang mời khách.Cuộc gọi khiếu nại
        ///  TongGuiSangMoiKhach = 6, // Cuoc goi truyen di san gmoi khach, duoc goi di cho cả tổng đài vào
        /// </summary>
        public TrangThaiLenhTaxi TrangThaiLenh
        {
            get { return mTrangThaiLenh; }
            set { mTrangThaiLenh = value; }
        }

        private int mVungID;

        public int VungID
        {
            get { return mVungID; }
            set { mVungID = value; }
        }

        private string Danhsach_Decu;
        /// <summary>
        /// danh sach 5 xe gan dia chi don nhat
        /// </summary>
        public string DanhSachXe
        {
            set { Danhsach_Decu = value; }
            get { return Danhsach_Decu; }
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
        //@ThoiGianDonKhach int,Thoi
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
        private int mTongThoiGianDamThoai;
        /// <summary>
        /// TInh theo so phut
        /// </summary>
        public int TongThoiGianDamThoai
        {
            get { return mTongThoiGianDamThoai; }
            set { mTongThoiGianDamThoai = value; }
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
        private string mFileVoicePath;

        public string FileVoicePath
        {
            get { return mFileVoicePath; }
            set { mFileVoicePath = value; }
        }

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

        private float gps_KinhDo;
        public float GPS_KinhDo
        {
            get { return gps_KinhDo; }
            set { gps_KinhDo = value; }
        }

        private float gps_ViDo;
        public float GPS_ViDo
        {
            get { return gps_ViDo; }
            set { gps_ViDo = value; }
        }
        private string mMaDoiTac;
        public string MaDoiTac
        {
            get { return mMaDoiTac; }
            set { mMaDoiTac = value; }
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
        private DateTime mThoiDiemThayDoiDuLieu;
        public DateTime ThoiDiemThayDoiDuLieu
        {
            get { return mThoiDiemThayDoiDuLieu; }
            set { mThoiDiemThayDoiDuLieu = value; }
        }
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
        public Guid BookId { get; set; }
        public string  XeDungDiem { get; set; }
        //-----------------
        #region THONG TIN MOI KHACH

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

       

        #endregion THONG TIN MOI KHACH

        #region BANTIBANGIA

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

        #region FastTaxi
        public int FT_Status { get; set; }
        public bool FT_IsFT { get; set; }
        public DateTime FT_Date { get; set; }
        public DateTime FT_SendDate { get; set; }
        #endregion
        #endregion Members & Properties

        #region Methods

        #region MethodsGET
        /// <summary>
        /// Tra ve mot danh sach cac doi tuong 
        /// lay tat ca cac trong Cac cuoc goi chua ket thuc
        /// </summary>
        /// <param name="SQLCondition"></param>
        /// <returns></returns>
        /// ID, Line, PhoneNumber, ThoiDiemGoi, SoLuotDoChuong, DiaChiGoi, ThoiDiemKetThucGoi, DiaChiDonKhach, GoiTaxi, GoiLai, GoiKhieuNai, 
        ///       ThongTinKhac, LoaiXe, ChonTaxi4Cho, ChonTaxi7Cho, SanBay_DuongDai, Vung, LenhDienThoai, LenhTongDai, MaNhanVienDienThoai, 
        //       MaNhanVienTongDai, XeNhan, XeDon, DiaChiTraKhach, GhiChu, TrangThaiLenh
        public List<DieuHanhTaxi> GetAllOf_DienThoai(string SQLCondition)
        {
            List<DieuHanhTaxi> lstCuocGoi = new List<DieuHanhTaxi>();
            try
            {
                DataTable dt = new DataTable();

                dt = new Data.DieuHanhTaxi().GetAll_DienThoai(SQLCondition);
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
            catch (Exception ex)
            {
               // //  LogError.WriteLog("GetAllOf_DienThoai :", ex);
                return null;
            }
        }
        public List<DieuHanhTaxi> FT_GetAllOf_DienThoai(string SQLCondition)
        {
            List<DieuHanhTaxi> lstCuocGoi = new List<DieuHanhTaxi>();
            try
            {
                DataTable dt = new DataTable();

                dt = new Data.DieuHanhTaxi().FT_GetAll_DienThoai(SQLCondition);
                if (dt != null)
                {
                    if (dt.Rows.Count <= 0) return null;
                    else
                    {
                        lstCuocGoi.AddRange(from DataRow dr in dt.Rows select GetDieuHanhTaxiV2(dr));
                    }
                }
                return lstCuocGoi;
            }
            catch (Exception ex)
            {
                // //  LogError.WriteLog("GetAllOf_DienThoai :", ex);
                return null;
            }
        }

        /// <summary>
        /// Lấy danh sách các xe đã nhận
        /// </summary>
        /// <param name="SQLCondition"></param>
        /// <returns></returns>
        public DataTable FT_GetAllOf_DienThoaiNew(string SQLCondition)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = new Data.DieuHanhTaxi().FT_GetAll_DienThoai(SQLCondition);
                if (dt!=null && dt.Rows.Count>0)
                {
                    return dt;
                } return null;
            }
            catch (Exception ex)
            {
                // //  LogError.WriteLog("GetAllOf_DienThoai :", ex);
                return null;
            }
        }
        public string G5_GetAddressOfDienThoai(string Phone)
        {
        
            try
            {

                return new Data.DieuHanhTaxi().G5_GetAddressOfDienThoai(Phone);
            }
            catch (Exception ex)
            {
                  LogError.WriteLogError("G5_GetAddressOfDienThoai :", ex);
              return string.Empty;
            }
        }
        /// <summary>
        /// Get tat cac cac cuoc goi ket thuc trong nay
        /// </summary>
        public List<DieuHanhTaxi> Get_CuocGoi_KetThuc(string NRecords, string SQLCondition)
        {
            List<DieuHanhTaxi> lstCuocGoiKT = new List<DieuHanhTaxi>();
            try
            {
                DataTable dt = new DataTable();

                dt = new Data.DieuHanhTaxi().Get_CuocGoi_KetThuc(NRecords, SQLCondition);
                if (dt.Rows.Count <= 0) return null;
                else
                {
                    //foreach (DataRow dr in dt.Rows)
                    //{
                    //    lstCuocGoiKT.Add(GetDieuHanhTaxi(dr));
                    //}
                    return dt.Select().Select(p => GetDieuHanhTaxi(p)).ToList();
                }
            }
            catch (Exception ex)
            {
                return lstCuocGoiKT;
            }
        }
        public List<DieuHanhTaxi> FT_Get_CuocGoi_KetThuc(string NRecords, string SQLCondition)
        {
            var lstCuocGoiKt = new List<DieuHanhTaxi>();
            try
            {
                var dt = new Data.DieuHanhTaxi().FT_Get_CuocGoi_KetThuc(NRecords, SQLCondition);
                if (dt.Rows.Count <= 0) return null;
                else
                {
                    lstCuocGoiKt.AddRange(from DataRow dr in dt.Rows select GetDieuHanhTaxi(dr));
                    return lstCuocGoiKt;
                }
            }
            catch (Exception ex)
            {
                return lstCuocGoiKt;
            }
        }

        public List<DieuHanhTaxi> Get_CuocGoi_KetThucBySoDong(int SoDongLayRa)
        {
            List<DieuHanhTaxi> lstCuocGoiKT = new List<DieuHanhTaxi>();
            try
            {
                DataTable dt = new DataTable();

                dt = new Data.DieuHanhTaxi().Get_CuocGoi_KetThucBySoDong(SoDongLayRa);
                if (dt.Rows.Count <= 0) return null;
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        lstCuocGoiKT.Add(GetDieuHanhTaxi(dr));
                    }
                    return lstCuocGoiKT;
                }
            }
            catch (Exception ex)
            {
                return lstCuocGoiKT;
            }
        }

        /// <summary>
        ///  ID, Line, PhoneNumber, ThoiDiemGoi, SoLuotDoChuong, DiaChiGoi, ThoiDiemKetThucGoi, DiaChiDonKhach, GoiTaxi, GoiLai, GoiKhieuNai, 
        ///       ThongTinKhac, LoaiXe,SoLuong, ChonTaxi4Cho, ChonTaxi7Cho, SanBay_DuongDai, Vung, LenhDienThoai, LenhTongDai, MaNhanVienDienThoai, 
        //       MaNhanVienTongDai, XeNhan, XeDon, DiaChiTraKhach, GhiChu, TrangThaiLenh
        ///, MOIKHACH_NhanVien, MOIKHACH_KhieuNai_ThoiDiem, 
        ///              MOIKHACH_KhieuNai_ThongTinThem, MOIKHACH_KhieuNai_DaXyLy, MOIKHACH_XinLoi_ThoiDiem, MOIKHACH_XinLoi_DaXinLoi, MOIKHACH_ThoiDiemMoi_Giu, 
         ///             MOIKHACH_LenhMoiKhach

        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private DieuHanhTaxi GetDieuHanhTaxi(DataRow drTaxiOpe)
        {
            try
            {
                DieuHanhTaxi objDHTaxi = new DieuHanhTaxi();
                objDHTaxi.ID_DieuHanh = long.Parse(drTaxiOpe["ID"].ToString());
                objDHTaxi.Line = drTaxiOpe["Line"].ToString();
                //moi sua 3 dong nay
                objDHTaxi.LenhLaiXe = !drTaxiOpe.Table.Columns.Contains("LenhLaiXe") || drTaxiOpe["LenhLaiXe"] == DBNull.Value ? "" : drTaxiOpe["LenhLaiXe"].ToString();
                objDHTaxi.G5_SendDate = !drTaxiOpe.Table.Columns.Contains("G5_SendDate") || drTaxiOpe["G5_SendDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)drTaxiOpe["G5_SendDate"];
                objDHTaxi.G5_Type = !drTaxiOpe.Table.Columns.Contains("G5_Type") || drTaxiOpe["G5_Type"] == DBNull.Value ? 0 : int.Parse(drTaxiOpe["G5_Type"].ToString());
                objDHTaxi.XeDungDiem = !drTaxiOpe.Table.Columns.Contains("XeDungDiem") || drTaxiOpe["XeDungDiem"] == DBNull.Value ? string.Empty : (drTaxiOpe["XeDungDiem"].ToString());
                objDHTaxi.BookId = !drTaxiOpe.Table.Columns.Contains("BookId") || drTaxiOpe["BookId"] == DBNull.Value ? Guid.Empty : Guid.Parse(drTaxiOpe["BookId"].ToString());
                ///
                objDHTaxi.PhoneNumber = drTaxiOpe["PhoneNumber"].ToString();
                objDHTaxi.ThoiDiemGoi = (DateTime)drTaxiOpe["ThoiDiemGoi"];
                objDHTaxi.DoDaiCuocGoi = drTaxiOpe["Duration"] == DBNull.Value ? DateTime.MinValue : (DateTime)drTaxiOpe["Duration"];
                objDHTaxi.FileVoicePath = drTaxiOpe["FileVoicePath"].ToString();
                objDHTaxi.ThoiDiemGoiGio = string.Format("{0:yyyy-MM-dd HH:mm:ss}", objDHTaxi.ThoiDiemGoi).Substring(11, 8);
                objDHTaxi.ThoiDiemGoiNgay = string.Format("{0:yyyy-MM-dd HH:mm:ss}", objDHTaxi.ThoiDiemGoi).Substring(0, 10);
               
                    objDHTaxi.TrangThaiCuocGoi = !drTaxiOpe.Table.Columns.Contains("TrangThaiCuocGoi")||drTaxiOpe["TrangThaiCuocGoi"]==DBNull.Value?TrangThaiCuocGoiTaxi.TrangThaiKhac:(TrangThaiCuocGoiTaxi)byte.Parse(drTaxiOpe["TrangThaiCuocGoi"].ToString());
               
                    objDHTaxi.KieuCuocGoi =!drTaxiOpe.Table.Columns.Contains("KieuCuocGoi")||drTaxiOpe["KieuCuocGoi"]==DBNull.Value?Taxi.Utils.KieuCuocGoi.GoiTaxi: (Taxi.Utils.KieuCuocGoi)byte.Parse(drTaxiOpe["KieuCuocGoi"].ToString());
              

                if (drTaxiOpe["ThoiDiemChuyenTongDai"] == DBNull.Value)
                    objDHTaxi.ThoiDiemChuyenTongDai = 0;
                else
                {
                    objDHTaxi.ThoiDiemChuyenTongDai = int.Parse(drTaxiOpe["ThoiDiemChuyenTongDai"].ToString());
                }

                    objDHTaxi.SoLuotDoChuong =!drTaxiOpe.Table.Columns.Contains("SoLuotDoChuong")||drTaxiOpe["SoLuotDoChuong"]==DBNull.Value?0: int.Parse(drTaxiOpe["SoLuotDoChuong"].ToString());
                objDHTaxi.DiaChiDonKhach = drTaxiOpe["DiaChiDonKhach"].ToString();
               
                    objDHTaxi.KieuKhachHangGoiDen = !drTaxiOpe.Table.Columns.Contains("KieuKhachHangGoiDen")||drTaxiOpe["KieuKhachHangGoiDen"]==DBNull.Value?KieuKhachHangGoiDen.KhachHangKhongHieu:(Taxi.Utils.KieuKhachHangGoiDen)int.Parse(drTaxiOpe["KieuKhachHangGoiDen"].ToString());
               
                
                objDHTaxi.GoiTaxi = drTaxiOpe["GoiTaxi"].ToString() == "1" ? true : false;
                objDHTaxi.GoiLai = drTaxiOpe["GoiLai"].ToString() == "1" ? true : false;
                // goi khieu nai
                if (drTaxiOpe["GoiKhieuNai"] == null) objDHTaxi.GoiKhieuNai = false;
                else objDHTaxi.GoiKhieuNai  = drTaxiOpe["GoiKhieuNai"].ToString ()=="1"? true:false ;
                
                objDHTaxi.ThongTinKhac = drTaxiOpe["ThongTinKhac"].ToString() == "1" ? true : false;//GoiKhac
                objDHTaxi.LoaiXe = drTaxiOpe["LoaiXe"].ToString();
                if (drTaxiOpe["SoLuotDoChuong"] != DBNull.Value)
                    objDHTaxi.SoLuong = drTaxiOpe["SoLuong"].ToString();
                else objDHTaxi.SoLuong = "0";

                if (objDHTaxi.LoaiXe.Contains("4")) objDHTaxi.ChonTaxi4Cho = true;
                if (objDHTaxi.LoaiXe.Contains("7")) objDHTaxi.ChonTaxi7Cho = true;
                if (objDHTaxi.LoaiXe.Contains("0")) { objDHTaxi.ChonTaxi7Cho = false; objDHTaxi.ChonTaxi4Cho = false; }



                objDHTaxi.SanBay_DuongDai = drTaxiOpe["SanBay_DuongDai"].ToString();
                if (drTaxiOpe["SoLuotDoChuong"] != DBNull.Value)
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
                if (objDHTaxi.CuocGoiLaiIDs.Contains(";"))
                    objDHTaxi.ThongTinGoiLai = GetThongTinGoiLai(objDHTaxi.CuocGoiLaiIDs); ;
                if (drTaxiOpe["ThoiGianDieuXe"].ToString().Length > 0)
                    objDHTaxi.ThoiGianDieuXe = int.Parse(drTaxiOpe["ThoiGianDieuXe"].ToString());
                if (drTaxiOpe["ThoiGianDonKhach"].ToString().Length > 0)
                    objDHTaxi.ThoiGianDonKhach = int.Parse(drTaxiOpe["ThoiGianDonKhach"].ToString());

                //Ket qua
                //1.Don Duoc : (KieuCuocGoi = 1 AND (TrangThaiCuocGoi =1 OR XeDon='8888')  AND XeDon<>'999')
                if (!string.IsNullOrEmpty(objDHTaxi.XeDon) && 
                        objDHTaxi.KieuCuocGoi == KieuCuocGoi.GoiTaxi &&
                        (objDHTaxi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiDonDuocKhach || 
                        objDHTaxi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.TrangThaiKhac ||
                        objDHTaxi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiChuaXacDinh
                       )
                    )
                {
                    objDHTaxi.KetQua = "A";
                }
                //2.trượt, hoãn (KieuCuocGoi = 1 AND (TrangThaiCuocGoi =2 OR TrangThaiCuocGoi =3) ) 
                else if (objDHTaxi.KieuCuocGoi == KieuCuocGoi.GoiTaxi &&
                    (objDHTaxi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiHoan || objDHTaxi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiTruot||
                    (objDHTaxi.G5_Type==(int)Enum_G5_Type.DieuApp&&!string.IsNullOrEmpty(objDHTaxi.XeDungDiem)) // Dieu app truot/hoan
                    ))
                {
                    objDHTaxi.KetQua = "B";
                }
                //3.khong xe (KieuCuocGoi = 1 AND TrangThaiCuocGoi =4 )
                else if (objDHTaxi.KieuCuocGoi == KieuCuocGoi.GoiTaxi && objDHTaxi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiKhongXe)
                {
                    objDHTaxi.KetQua = "C";
                }
                //4.chọn xe 999  (KieuCuocGoi = 1 AND XeDon ='999' )
                else if (objDHTaxi.KieuCuocGoi == KieuCuocGoi.GoiTaxi && objDHTaxi.XeDon == "999")
                {
                    objDHTaxi.KetQua = "D";
                }
                if (drTaxiOpe["DanhSachXe_DeCu"] == null) objDHTaxi.DanhSachXe_DeCu = "";
                else objDHTaxi.DanhSachXe_DeCu = drTaxiOpe["DanhSachXe_DeCu"].ToString();

                if (drTaxiOpe["XeDenDiem"] == null) objDHTaxi.XeDenDiem = "";
                else objDHTaxi.XeDenDiem = drTaxiOpe["XeDenDiem"].ToString();

                // THONG TIN CAM ON CUOC GOI
                //[CAMON_DaCamOn],[CAMON_ThoiDiemCamOn],[CAMON_DanhGia],[CAMON_YKien],[CAMON_NhanVien],[CAMON_ThoiDiemSuaCuoi],[CAMON_NhanVienSua]
                objDHTaxi.CamOn_DaCamOn = drTaxiOpe["CAMON_DaCamOn"].ToString() == "True" ? true : false;
                
                objDHTaxi.CamOn_ThoiDiemChen = !drTaxiOpe.Table.Columns.Contains("CAMON_ThoiDiemCamOn") || drTaxiOpe["CAMON_ThoiDiemCamOn"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(drTaxiOpe["CAMON_ThoiDiemCamOn"].ToString());
                   
                if (drTaxiOpe["CAMON_DanhGia"] == null || drTaxiOpe["CAMON_DanhGia"].ToString ().Length <=0) objDHTaxi.CamOn_DanhGia = KieuKhachDanhGiaCAMON.ChuaDanhGia;
                else objDHTaxi.CamOn_DanhGia = ((KieuKhachDanhGiaCAMON)int.Parse(drTaxiOpe["CAMON_DanhGia"].ToString()));
               
                if ( drTaxiOpe["CAMON_YKien"]==null) objDHTaxi.CamOn_YKien ="";
                else objDHTaxi.CamOn_YKien =  drTaxiOpe["CAMON_YKien"].ToString() ;

                if ( drTaxiOpe["CAMON_NhanVien"]==null) objDHTaxi.CamOn_NhanVien= "";
                else objDHTaxi.CamOn_NhanVien = drTaxiOpe["CAMON_NhanVien"].ToString();

                objDHTaxi.CamOn_ThoiDiemSuaCuoi = !drTaxiOpe.Table.Columns.Contains("CAMON_ThoiDiemSuaCuoi") || drTaxiOpe["CAMON_ThoiDiemSuaCuoi"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(drTaxiOpe["CAMON_ThoiDiemSuaCuoi"].ToString());
                 
                // ---------------------------
                
                // THONG TIN MOI KHACH
                if (drTaxiOpe["MOIKHACH_LenhMoiKhach"] == null) objDHTaxi.MOIKHACH_LenhMoiKhach = "";
                else objDHTaxi.MOIKHACH_LenhMoiKhach = drTaxiOpe["MOIKHACH_LenhMoiKhach"].ToString();
                
                objDHTaxi.MOIKHACH_ThoiDiemMoi_Giu = !drTaxiOpe.Table.Columns.Contains("MOIKHACH_ThoiDiemMoi_Giu") || drTaxiOpe["MOIKHACH_ThoiDiemMoi_Giu"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(drTaxiOpe["MOIKHACH_ThoiDiemMoi_Giu"].ToString());
                  
                 if (drTaxiOpe["MOIKHACH_XinLoi_DaXinLoi"] != null && drTaxiOpe["MOIKHACH_XinLoi_DaXinLoi"].ToString().Length > 0) objDHTaxi.MOIKHACH_XinLoi_DaXinLoi = Convert.ToBoolean(drTaxiOpe["MOIKHACH_XinLoi_DaXinLoi"].ToString());
                 else objDHTaxi.MOIKHACH_XinLoi_DaXinLoi = false;
               
                 objDHTaxi.MOIKHACH_XinLoi_ThoiDiem = !drTaxiOpe.Table.Columns.Contains("MOIKHACH_XinLoi_ThoiDiem") || drTaxiOpe["MOIKHACH_XinLoi_ThoiDiem"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(drTaxiOpe["MOIKHACH_XinLoi_ThoiDiem"].ToString());
                
                if (drTaxiOpe["MOIKHACH_KhieuNai_DaXyLy"] != null && drTaxiOpe["MOIKHACH_KhieuNai_DaXyLy"].ToString ().Length >0)
                     objDHTaxi.MOIKHACH_KhieuNai_DaXyLy = Convert.ToBoolean (drTaxiOpe["MOIKHACH_KhieuNai_DaXyLy"] .ToString ());
                 else objDHTaxi.MOIKHACH_KhieuNai_DaXyLy = false;
               

                if(drTaxiOpe["MOIKHACH_KhieuNai_ThongTinThem"] == null ) objDHTaxi.MOIKHACH_KhieuNai_ThongTinThem = "";
                else objDHTaxi.MOIKHACH_KhieuNai_ThongTinThem  = drTaxiOpe["MOIKHACH_KhieuNai_ThongTinThem"].ToString ();

                if (drTaxiOpe["MOIKHACH_NhanVien"] == null) objDHTaxi.MOIKHACH_NhanVien = "";
                else objDHTaxi.MOIKHACH_NhanVien = drTaxiOpe["MOIKHACH_NhanVien"].ToString();

                // ---------------------------

                // ----  BAN TIN BAN GIA -----
                if (drTaxiOpe["BANTINBANGIA_NoiDungXuLy"] == null) objDHTaxi.BTBG_NoiDungXuLy = "";
                else objDHTaxi.BTBG_NoiDungXuLy = drTaxiOpe["BANTINBANGIA_NoiDungXuLy"].ToString();

                if (drTaxiOpe["BANTINBANGIA_NhanVien"] == null) objDHTaxi.BTBG_NhanVien = "";
                else objDHTaxi.BTBG_NhanVien = drTaxiOpe["BANTINBANGIA_NhanVien"].ToString();

               
                objDHTaxi.BTBG_IsDaXuLy = !drTaxiOpe.Table.Columns.Contains("BANTINBANGIA_IsXuLy") || drTaxiOpe["BANTINBANGIA_IsXuLy"] == DBNull.Value ? false : Convert.ToBoolean(drTaxiOpe["BANTINBANGIA_IsXuLy"].ToString());
                objDHTaxi.BTBG_ThoiDiemXuLy = !drTaxiOpe.Table.Columns.Contains("BANTINBANGIA_ThoiDiemXuLy") || drTaxiOpe["BANTINBANGIA_ThoiDiemXuLy"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(drTaxiOpe["BANTINBANGIA_ThoiDiemXuLy"].ToString());
                   
                #region FastTaxi
                
                objDHTaxi.FT_Date =! drTaxiOpe.Table.Columns.Contains("FT_Date")||drTaxiOpe["FT_Date"]==DBNull.Value?DateTime.MinValue: Convert.ToDateTime(drTaxiOpe["FT_Date"].ToString());

                objDHTaxi.FT_SendDate = !drTaxiOpe.Table.Columns.Contains("FT_SendDate") || drTaxiOpe["FT_SendDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(drTaxiOpe["FT_SendDate"].ToString());
             
                objDHTaxi.FT_Status =!drTaxiOpe.Table.Columns.Contains("FT_Status")||drTaxiOpe["FT_Status"] ==DBNull.Value?0:  Convert.ToInt32(drTaxiOpe["FT_Status"].ToString());
                
                objDHTaxi.FT_IsFT = !drTaxiOpe.Table.Columns.Contains("FT_IsFT") || drTaxiOpe["FT_IsFT"] == DBNull.Value ? false : Convert.ToBoolean(drTaxiOpe["FT_IsFT"]);
                
                #endregion
                objDHTaxi.ThoiDiemThayDoiDuLieu = drTaxiOpe.Table.Columns.Contains("ThoiDiemThayDoiDuLieu") && drTaxiOpe["ThoiDiemThayDoiDuLieu"] != DBNull.Value ? Convert.ToDateTime(drTaxiOpe["ThoiDiemThayDoiDuLieu"]) : DateTime.MinValue;
                //----------------------------
                return objDHTaxi;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private DieuHanhTaxi GetDieuHanhTaxiV2(DataRow drTaxiOpe)
        {
            DieuHanhTaxi objDHTaxi = new DieuHanhTaxi();
            try
            {

                objDHTaxi.XeNhan = (drTaxiOpe["XeNhan"].ToString());
                objDHTaxi.DiaChiDonKhach = (drTaxiOpe["DiaChiDonKhach"].ToString());
            }
            catch
            {
                
            }
            return objDHTaxi;
        }
        private  static DieuHanhTaxi  GetDieuHanhTaxiStatic(DataRow drTaxiOpe)
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
            try
            {
                objDHTaxi.TrangThaiCuocGoi = (TrangThaiCuocGoiTaxi)byte.Parse(drTaxiOpe["TrangThaiCuocGoi"].ToString());
            }
            catch (Exception ex)
            { objDHTaxi.TrangThaiCuocGoi = Taxi.Utils.TrangThaiCuocGoiTaxi.TrangThaiKhac; }
            try
            {
                objDHTaxi.KieuCuocGoi = (KieuCuocGoi)byte.Parse(drTaxiOpe["KieuCuocGoi"].ToString());
            }
            catch (Exception ex) { objDHTaxi.KieuCuocGoi = KieuCuocGoi.GoiTaxi; }

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
            // goi khieu nai
            if (drTaxiOpe["GoiKhieuNai"] == null) objDHTaxi.GoiKhieuNai = false;
            else objDHTaxi.GoiKhieuNai = drTaxiOpe["GoiKhieuNai"].ToString() == "1" ? true : false;

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
            if (objDHTaxi.CuocGoiLaiIDs.Contains(";"))
                objDHTaxi.ThongTinGoiLai = string.Empty; //GetThongTinGoiLai(objDHTaxi.CuocGoiLaiIDs);
            if (drTaxiOpe["ThoiGianDieuXe"].ToString().Length > 0)
                objDHTaxi.ThoiGianDieuXe = int.Parse(drTaxiOpe["ThoiGianDieuXe"].ToString());
            if (drTaxiOpe["ThoiGianDonKhach"].ToString().Length > 0)
                objDHTaxi.ThoiGianDonKhach = int.Parse(drTaxiOpe["ThoiGianDonKhach"].ToString());

            // THONG TIN CAM ON CUOC GOI
            //[CAMON_DaCamOn],[CAMON_ThoiDiemCamOn],[CAMON_DanhGia],[CAMON_YKien],[CAMON_NhanVien],[CAMON_ThoiDiemSuaCuoi],[CAMON_NhanVienSua]
            objDHTaxi.CamOn_DaCamOn = drTaxiOpe["CAMON_DaCamOn"].ToString() == "True" ? true : false;
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
                catch (Exception ex)
                {
                    objDHTaxi.BTBG_ThoiDiemXuLy = DateTime.MinValue;
                }
            }
            //----------------------------
            return objDHTaxi;
        }
        /// <summary>
        /// Ham nay thuc hien viec lay thong tin cua cac cuoc goi lai
        /// input : CuocGoiLaiIDs : 5;2;1
        /// output: L1: 10:20:5; L2: 10:22:10; L3: 10:25:09
        /// </summary>
        /// <param name="CuocGoiLaiIDs"></param>
        /// <returns></returns>
        public string GetThongTinGoiLai(string CuocGoiLaiIDs)
        {
            try
            {
                if (CuocGoiLaiIDs.Contains(";"))
                {
                    // Tach chuoi
                    char[] charSplits = ";".ToCharArray();
                    string[] ID_DieuHanhs = CuocGoiLaiIDs.Split(charSplits);
                    // Lay thong tin cuoi goi
                    string strThongTinGoiLai = string.Empty;
                    int iLan = 0;
                    for (int i = ID_DieuHanhs.Length - 1; i >= 0; i--)
                    {
                        if (StringTools.TrimSpace(ID_DieuHanhs[i].ToString()).Length > 0)
                        {
                            string SQLCondition = " AND (ID =" + ID_DieuHanhs[i].ToString() + ")";
                            DieuHanhTaxi objDHTX = new DieuHanhTaxi();
                            List<DieuHanhTaxi> lstCalls = objDHTX.GetAllOf_DienThoai(SQLCondition);
                            if (lstCalls.Count > 0)
                            {
                                iLan = iLan + 1;
                                strThongTinGoiLai = strThongTinGoiLai + "; L" + iLan.ToString() + ":" + ((DieuHanhTaxi)lstCalls[0]).ThoiDiemGoiGio;
                            }
                        }
                    }
                    return strThongTinGoiLai;
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }

        }



        #endregion
        /// <summary>
        /// Chen cuoc goi lan dau tien bat duoc
        /// - Line
        /// - PhoneNumber
        /// - DateTime (2008-09-27 15:50:22)
        /// - TrangThaiCuocGoi.CuocGoiDen
        /// - TrangThaiLenh.KhongTruyenDi
        /// </summary>
        /// <returns></returns>
        public bool Insert_DienThoai_LanDau()
        {
            try
            {

                long ID_DieuHanh = new Data.DieuHanhTaxi().Insert_DienThoai_LanDau(this.Line, this.PhoneNumber, this.DiaChiDonKhach, this.KieuKhachHangGoiDen, this.TrangThaiCuocGoi, this.TrangThaiLenh);
                if (ID_DieuHanh > 0) // thanh cong
                {
                    this.ID_DieuHanh = ID_DieuHanh;
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Insert_DienThoai_LanDau_ToaDo()
        {
            try
            {

                long ID_DieuHanh = new Data.DieuHanhTaxi().Insert_DienThoai_LanDau_ToaDo(this.Line, this.PhoneNumber, this.DiaChiDonKhach, this.KieuKhachHangGoiDen, this.TrangThaiCuocGoi, this.TrangThaiLenh, this.GPS_KinhDo,this.GPS_ViDo,MaDoiTac);
                if (ID_DieuHanh > 0) // thanh cong
                {
                    this.ID_DieuHanh = ID_DieuHanh;
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool InsertCuocGoiLanDau_TongDai()
        {
            try
            {
                long ID_DieuHanh = new Data.DieuHanhTaxi().InsertCuocGoiLanDau_TongDai(this.Line, this.PhoneNumber, this.DiaChiDonKhach, this.KieuKhachHangGoiDen, this.TrangThaiCuocGoi, this.TrangThaiLenh, this.GPS_KinhDo, this.GPS_ViDo, MaDoiTac);
                if (ID_DieuHanh > 0) // thanh cong
                {
                    this.ID_DieuHanh = ID_DieuHanh;
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Để test dữ liệu
        /// </summary>
        /// <returns></returns>
        public bool Insert_DienThoai_LanDau_ToaDo_fastTaxi()
        {
            try
            {

                long ID_DieuHanh = new Data.DieuHanhTaxi().Insert_DienThoai_LanDau_ToaDo_FastTaxi(this.Line, this.PhoneNumber, this.DiaChiDonKhach, this.KieuKhachHangGoiDen, this.TrangThaiCuocGoi, this.TrangThaiLenh, this.GPS_KinhDo, this.GPS_ViDo, MaDoiTac);
                if (ID_DieuHanh > 0) // thanh cong
                {
                    this.ID_DieuHanh = ID_DieuHanh;
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Insert_DienThoai_LanDau_ToaDo_TestCuocGoiLai()
        {
            try
            {

                long ID_DieuHanh = new Data.DieuHanhTaxi().Insert_DienThoai_LanDau_ToaDo_TestCuocGoiLai(this.Line, this.PhoneNumber, this.DiaChiDonKhach, this.KieuKhachHangGoiDen, this.TrangThaiCuocGoi, this.TrangThaiLenh, this.GPS_KinhDo, this.GPS_ViDo, MaDoiTac);
                if (ID_DieuHanh > 0) // thanh cong
                {
                    this.ID_DieuHanh = ID_DieuHanh;
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        /// <summary>
        /// Dien thoai vien nhap thong tin cua cuoc goi moi nhan va chuyen
        /// sang cho tong dai
        /// </summary>
        /// <returns></returns>
        public bool Update_DienThoai()
        {
            try
            {
                int SoLuong = 0;
                if (this.SoLuong.Length > 0)
                    SoLuong = int.Parse(this.SoLuong);

                return new Data.DieuHanhTaxi().Update_DienThoai(this.ID_DieuHanh, this.DiaChiDonKhach, this.ThoiDiemChuyenTongDai, this.GoiTaxi, this.GoiLai, this.GoiKhieuNai, this.ThongTinKhac, this.LoaiXe,
                    SoLuong, this.SanBay_DuongDai, this.MaVung == "" ? 1 : int.Parse(this.MaVung), this.LenhDienThoai, this.GhiChuDienThoai, this.MaNhanVienDienThoai, this.TrangThaiLenh, this.CuocGoiLaiIDs,this.KieuCuocGoi);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Cap nhat thong tin cua BoDam chuyen sang cho DienThoai
        /// </summary>
        /// <returns></returns>
        public bool Update_BoDam()
        {
            return new Data.DieuHanhTaxi().Update_BoDam(this.ID_DieuHanh, this.LenhTongDai, this.MaNhanVienTongDai, this.XeNhan, this.XeDon, this.GhiChuTongDai, this.TrangThaiLenh, this.ThoiGianDieuXe, this.ThoiGianDonKhach,this.TrangThaiCuocGoi);
        }
        /// <summary>
        /// hamf thuc hien update thong tin nhan vien tong dai
        /// dieu kien la chua nhap thong tin xu ly
        /// </summary>
        /// <param name="Vung"></param>
        /// <param name="MaNhanVienTongdai"></param>
        /// <returns></returns>
        public static bool Update_BoDam(string Vung, string MaNhanVienTongdai)
        {
            return new Data.DieuHanhTaxi().Update_BoDam(Vung, MaNhanVienTongdai);
        }

        public bool Update_MaNhanVienDienThoai()
        {
            if (this.ID_DieuHanh > 0)
            {
                return new Data.DieuHanhTaxi().Update_MaNhanVienDienThoai(this.ID_DieuHanh, MaNhanVienDienThoai);
            }
            return false;
        }

        public bool Update_MaNhanVienTongDai()
        {
            return new Data.DieuHanhTaxi().Update_MaNhanVienTongDai(this.ID_DieuHanh, MaNhanVienTongDai);
        }

        public bool Update_SoLuongChuongDo(int SoLuotChuongDo)
        {
            return new Data.DieuHanhTaxi().Update_SoLuongChuongDo(this.ID_DieuHanh, SoLuotChuongDo);
        }

        /// <summary>
        /// Update cuoc goi Nho,
        /// khi phat hien ra cuoc goi nho, ghi lai luon, ghi ca so luong chuong do
        /// </summary>
        /// <returns></returns>
        public bool Update_DienThoai_CuocGoiNho()
        {
            if(this.ID_DieuHanh >0)
                return new Data.DieuHanhTaxi().Update_DienThoai_CuocGoiNho(this.ID_DieuHanh, this.SoLuotDoChuong, this.GhiChuDienThoai, this.TrangThaiCuocGoi, this.TrangThaiLenh);
            return false;

        }

        /// <summary>
        /// Update cuoc goi den co nguoi bat may,
        /// Update so do chuong
        /// </summary>
        /// <returns></returns>
        public bool Update_DienThoai_CuocGoiDenCoBatMay()
        {
            return new Data.DieuHanhTaxi().Update_DienThoai_CuocGoiDenCoBatMay(this.ID_DieuHanh, this.SoLuotDoChuong, this.TrangThaiCuocGoi, this.TrangThaiLenh);
        }
        /// <summary>
        /// dung de cap nhat khach hẹn
        /// </summary>
        /// <returns></returns>
        public bool Update_DienThoai_KieuKhachGoi()
        {
            return new Data.DieuHanhTaxi().Update_DienThoai_KieuKhachGoi(this.ID_DieuHanh, this.KieuKhachHangGoiDen);
        }

        /// <summary>
        /// Update trang thai lenh khi ket thuc
        /// </summary>
        /// <param name="IDDieuHanh"></param>
        /// <param name="TrangThaiLenh"></param>
        /// <returns></returns>
        public bool Update_KetThucCuocGoi(long IDDieuHanh, TrangThaiLenhTaxi TrangThaiLenh)
        {
            return new Data.DieuHanhTaxi().Update_KetThucCuocGoi(ID_DieuHanh, TrangThaiLenh);
        }
        /// <summary>
        /// Ket thuc cuoc goi
        ///   - Khach goi taxi thanh cong : TôngDai Nhap xe don khach 
        ///   - Khach goi lai 
        /// </summary>
        /// <returns></returns>
        public bool Update_ChuyenKetThucCuocGoi()
        {
            return new Data.DieuHanhTaxi().Update_ChuyenKetThucCuocGoi();
        }

        /// <summary>
        /// // Cuoc goi khac - chuyen thanh ket thuc dien thoai
        /// (this.ID_DieuHanh, this.DiaChiDonKhach, this.TrangThaiLenh)
        /// </summary>
        /// <returns></returns>
        public bool Update_DienThoai_CuocGoiKhac_KetThuc()
        {
            return new Data.DieuHanhTaxi().Update_DienThoai_CuocGoiKhac_KetThuc(this.ID_DieuHanh, this.DiaChiDonKhach, this.MaNhanVienDienThoai);
        }



        public static bool CheckConnection()
        {
            DateTime timeServer = DieuHanhTaxi.GetTimeServer();
            if (timeServer == DateTime.MinValue)
                return false;
            return true;

        }
        #endregion Methods

        #region OldMethods
        //   /// <summary>
        //   /// Nhan thong tin cua phan cung goi ve, chen ngay vao torng bang dieu hanh
        //   /// CHUA quyet dinh co truyen sang TongDai khong
        //   /// </summary>
        //   /// <returns>true : neu thanh cong; false : neu khong thanh cong</returns>
        //   public bool Insert_TrucDienThoai_LanDau()
        //   {
        //       return new Data.DieuHanhTaxi().Insert_TrucDienThoai_LanDau(this.Line,this.PhoneNumber ,
        //           this.ThoiDiemGoi,this.ThoiDiemKetThucGoi, this.DiaChiGoi,this.DiaChiDi,this.GoiTaxi ,
        //           this.GoiKhieuNai, this.ThongTinKhac, this.GoiLai, this.MaVung, this.ChonTaxi4Cho, this.ChonTaxi7Cho,
        //           this.SanBay_DuongDai,this.LenhTrucDienThoaiID , this.GhiChuChoDienThoai ,this.MaNhanVienDienThoai ,
        //           this.TrangThaiLenh);
        //   }
        //   /// <summary>
        //   /// Update trang thai lenh thuc hien khi ben truc dien thoai muon cho TongDai nhin thay
        //   /// trang thai cac lenh dang lam viec
        //   /// </summary>
        //   /// <param name="ID_DieuHanh"></param>
        //   /// <param name="TrangThaiLenh"></param>
        //   /// <returns></returns>
        ////   public static bool Update_TrangThaiLenh(long ID_DieuHanh, string TrangThaiLenh)
        //   //{
        //   //  return   new Data.DieuHanhTaxi().Update_TrangThaiLenh(ID_DieuHanh, TrangThaiLenh);
        //   //}

        //   //public bool Update_ThongTinTongDai(long ID_DieuHanh)
        //   //{
        //   //   return  new Data.DieuHanhTaxi().Update_ThongTinTongDai(ID_DieuHanh, this.LenhTrucTongDaiID, this.CuocGoiKhongThanhCong,
        //   //        this.MaNhanVienTongDai, this.NhungTaxiCoTheChay, this.TaxiChay, this.DiaChiTraKhach, this.GhiChuChoTongDai); 
        //   //}

        //   /// <summary>
        //   /// Update du lieu chat cua Dien thoai
        //   /// </summary>
        //   /// <returns></returns>
        //   public bool UpdateChatDienThoai()
        //   {
        //       return new Data.DieuHanhTaxi().UpdateChatDienThoai(this.ID_DieuHanh, this.DiaChiGoi, this.DiaChiDi, this.GoiTaxi, this.GoiLai, this.GoiKhieuNai, this.ThongTinKhac,
        //                                                           this.ChonTaxi4Cho, this.ChonTaxi7Cho, this.SanBay_DuongDai, this.MaVung,
        //                                                           this.LenhTrucDienThoaiID, this.LichSuLenhDienThoai, this.GhiChuChoDienThoai, this.TrangThaiLenh);

        //   }
        //   /// <summary>
        //   /// Cap nhat du lieu xuong bang dieu hanh ket thuc
        //   /// </summary>
        //   /// <returns></returns>
        //   public bool UpdateChatDienThoai_DieuHanhKetThuc()
        //   {
        //       return new Data.DieuHanhTaxi().UpdateChatDienThoai_DieuHanhKetThuc(this.ID_DieuHanh, this.DiaChiGoi, this.DiaChiDi, this.GoiTaxi, this.GoiLai, this.GoiKhieuNai, this.ThongTinKhac,
        //                                                           this.ChonTaxi4Cho, this.ChonTaxi7Cho, this.SanBay_DuongDai, this.MaVung,
        //                                                           this.LenhTrucDienThoaiID, this.LichSuLenhDienThoai, this.GhiChuChoDienThoai, this.TrangThaiLenh);

        //   }

        //   public static long GetDieuHanhID(string Line, string PhoneNumber, DateTime ThoiDiemGoi)
        //   {
        //       DataTable dt = new DataTable();
        //       dt = new Data.DieuHanhTaxi().GetDieuHanhID(Line, PhoneNumber, ThoiDiemGoi);
        //       if (dt.Rows.Count > 0)
        //       {
        //           return long.Parse(dt.Rows[0]["ID"].ToString());
        //       }
        //       else return -1;
        //   }

        //   public static long GetDieuHanhID_DieuHanhKetThuc(string Line, string PhoneNumber, DateTime ThoiDiemGoi)
        //   {
        //       DataTable dt = new DataTable();
        //       dt = new Data.DieuHanhTaxi().GetDieuHanhID_DieuHanhKetThuc(Line, PhoneNumber, ThoiDiemGoi);
        //       if (dt.Rows.Count > 0)
        //       {
        //           return long.Parse(dt.Rows[0]["ID"].ToString());
        //       }
        //       else return -1;
        //   }

        //   public DataTable GetBoDam()
        //   {
        //      return new Data.DieuHanhTaxi().GetBoDam();
        //   }
        //   /// <summary>
        //   /// Nhan nhung cuoc goi moi
        //   /// </summary>
        //   /// <param name="Ngay"></param>
        //   /// <returns></returns>
        //   public static DataTable GetNewCallsAndChatForDienThoai(DateTime Ngay)
        //   {
        //       return new Data.DieuHanhTaxi().GetNewCallsAndChatForDienThoai(Ngay);
        //   }
        //   /// <summary>
        //   /// Nhan nhung thong tin chat moi tu bo dam
        //   /// </summary>
        //   /// <param name="Ngay"></param>
        //   /// <returns></returns>
        //   public static  DataTable GetNewChatForDienThoai(DateTime Ngay)
        //   {
        //       return new Data.DieuHanhTaxi().GetNewCallsAndChatForDienThoai(Ngay); 
        //   }

        //   public static DataTable GetAllCallsFinishOnDay_DienThoai(DateTime Ngay)
        //   {
        //       return new Data.DieuHanhTaxi().GetAllCallsFinishOnDay_DienThoai(Ngay);
        //   }
        //   public static DataTable GetAllCallsFinishOnDay(DateTime Ngay)
        //   {
        //       return new Data.DieuHanhTaxi().GetAllCallsFinishOnDay(Ngay);
        //   }

        #region  KHAI THAC THONG TIN CUA CAC CUOC GOI DA KET THUC

        /// <summary>
        /// -- Description:	@Ngay ; Ngcay can truy van thong tin
        /// --				@MaNhanVienTongDai : Chon ma vien la truc tongdai, neu de rong thi lay theo ca ngay
        ///  --			   @CuocGoiKhongThanhCong : Trang thai cua khong thanh cong
        ///   --					1 : Khong xe phuc vu
        ///   --					2 : Truot khach
        ///   --					3 : Khach ao
        ///   --					4 : Khach hoan
        ///               @CuocGoiKhongThanhCong = empty  ; Lay tat ca 4 trang thai
        ///   -- =============================================
        /// </summary>
        /// <param name="Ngay"></param>
        /// <param name="MaNhaVienTongDai"></param>
        /// <param name="CuocGoiKhongThanhCong"></param>
        /// <returns></returns>

        public static DataTable GetAllCallsStatus_CuocGoiKhongThanhCong(DateTime Ngay, string MaNhaVienTongDai, string CuocGoiKhongThanhCong)
        {
            return new Data.DieuHanhTaxi().GetAllCallsStatus_CuocGoiKhongThanhCong(Ngay, MaNhaVienTongDai, CuocGoiKhongThanhCong);
        }

        #endregion  KHAI THAC THONG TIN CUA CAC CUOC GOI DA KET THUC

        #endregion Methods


        /// <summary>
        /// Ham tra ve thoi gian hien tai cua may chu
        /// </summary>
        /// <returns></returns>
        public static DateTime GetTimeServer()
        {
            return new Data.DieuHanhTaxi().GetTimeServer();
        }
        /// <summary>
        /// kiem tra mot line moico nam trong danh sach line duoc cap phep hay khong
        /// </summary>
        /// <param name="LinesDuocCapPhep">1;2;3;4;5;6;12;14;16</param>
        /// <param name="CurrentLine">11</param>
        /// <returns></returns>
        public static bool CheckLineDuocPhepsuDungMayNay(string LinesDuocCapPhep, string CurrentLine)
        {
            if (LinesDuocCapPhep.Length <= 0) return false;
            if (CurrentLine.Length <= 0) return false;
            string[] arrLines = LinesDuocCapPhep.Split(";".ToCharArray());
            for (int i = 0; i < arrLines.Length; i++)
            {
                if (StringTools.TrimSpace(arrLines[i].ToString()) == StringTools.TrimSpace(CurrentLine))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Cap nhat dia chi tra khach, khi cuoc goi da ket thuc
        /// </summary>
        /// <returns></returns>
        public bool Update_BoDam_CapNhatDiaChiTraKhack()
        {
            return new Data.DieuHanhTaxi().Update_BoDam_CapNhatDiaChiTraKhack(this.ID_DieuHanh, this.DiaChiTraKhach);
        }

        public bool Update_BoDam_CapNhatSanBay_DuongDai()
        {
            return new Data.DieuHanhTaxi().Update_BoDam_CapNhatSanBay_DuongDai(this.ID_DieuHanh);
        }

        /// <summary>
        /// dr["Line"].ToString(), dr["PhoneNumber"].ToString(), (DateTime)dr["ThoiDiemGoi"], (DateTime)dr["DoDaiCuocGoi"], dr["VoiceFilePath"].ToString()
        /// </summary>
        /// <param name="p"></param>
        /// <param name="p_2"></param>
        /// <param name="dateTime"></param>
        /// <param name="dateTime_4"></param>
        /// <param name="p_5"></param>
        /// <returns></returns>
        public static bool UpdateCuocGoiDenFileVoice_Duration(string Line, string PhoneNumber, DateTime ThoiDiemGoi, DateTime DoDaiCuocGoi, string VoiceFilePath)
        {
            return new Data.DieuHanhTaxi().UpdateCuocGoiDenFileVoice(Line, PhoneNumber, ThoiDiemGoi, DoDaiCuocGoi, VoiceFilePath);
        }

        /// <summary>
        /// cap lai kieu khach hang cua moi gioi.
        /// khi thay doi lai du lieu 
        /// </summary>
        /// <param name="DoiTac"></param>
        /// <param name="lstCuocGoiKetThuc"></param>
        /// <returns></returns>
        public static bool UpdateLaiCuocGoiMoiGioi(DoiTac DoiTac, List<DieuHanhTaxi> lstCuocGoiKetThuc)
        {
            try
            {
                if (lstCuocGoiKetThuc != null)
                {
                    foreach (DieuHanhTaxi objDHTX in lstCuocGoiKetThuc)
                    {
                        if ((objDHTX.PhoneNumber.Length >= 8) && (DanhBa.IsDienThoaiCoDinh(objDHTX.PhoneNumber))) // thoa man so toi dieu cua
                        {
                            if ((DoiTac.NgayKyKet == new DateTime(1900, 01, 01)) || (DoiTac.NgayKyKet <= objDHTX.ThoiDiemGoi))
                            {
                                if (DoiTac.Phones.Contains(DanhBa.GetSoDienThoaiToiThieu(objDHTX.PhoneNumber)))
                                {
                                    if (!DieuHanhTaxi.UpdateLaiCuocGoiMoiGioi(objDHTX.ID_DieuHanh, KieuKhachHangGoiDen.KhachHangMoiGioi))
                                    {
                                        ////  LogError.WriteLog(" Loi cap nhat lai cuoc goi moi gioi : " + DoiTac.MaDoiTac + " : " + objDHTX.ID_DieuHanh.ToString(), new Exception(" update  kieu khach hang - call ket thuc"));
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// Cap nhat gia tri kieu khach hang
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private static bool UpdateLaiCuocGoiMoiGioi(long ID_DieuHanh, KieuKhachHangGoiDen KieuKHGoiDen)
        {
            return new Data.DieuHanhTaxi().UpdateLaiCuocGoiMoiGioi(ID_DieuHanh, KieuKHGoiDen);
        }

        /// <summary>
        /// hàm thực hiện quét  lại ds các cuộc gọi đã gọi để thực hiện cuộc gọi môi giới
        /// </summary>
        public  static bool UpdateLaiCuocGoiMoiGioi(DateTime TuNgay, DateTime DenNgay, string MaMoiGioi)
        {        
            return new Data.DieuHanhTaxi().UpdateLaiCuocGoiMoiGioi(TuNgay,DenNgay,MaMoiGioi);
            
        }
        /// <summary>
        /// lay tat ca cac cuoc goi cua moi gioi goi taxi trong thang/nam
        /// </summary>
        /// <param name="Thang"></param>
        /// <param name="Nam"></param>
        /// <returns></returns>
        public List<DieuHanhTaxi> GetAllCuocGoiCuaDoiTac_GoiTaxi(int Thang, int Nam)
        {

            List<DieuHanhTaxi> lstCuocGoiCuaDoiTac_GoiTaxi = new List<DieuHanhTaxi>();
            try
            {
                DataTable dt = new DataTable();

                dt = new Data.DieuHanhTaxi().GetAllCuocGoiCuaDoiTac_GoiTaxi(Thang, Nam);
                if (dt != null)
                {
                    if (dt.Rows.Count <= 0) return null;
                    else
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            lstCuocGoiCuaDoiTac_GoiTaxi.Add(GetDieuHanhTaxi(dr));
                        }

                    }
                }
                return lstCuocGoiCuaDoiTac_GoiTaxi;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        /// <summary>
        /// Xóa dữ liệu của một cuộc gọi
        /// </summary>
        /// <returns></returns>
        public bool DeleteCuocGoiChoGiaiQuyet()
        {
            return new Data.DieuHanhTaxi().DeleteCuocGoiChoGiaiQuyet(this.ID_DieuHanh);
        }
        /// <summary>
        /// lay các cuôc goi cach day hon 3 thang
        /// </summary>
        /// <returns></returns>
        public   List<DieuHanhTaxi> GetNhungCuocGoiNhoHon3ThangGanDay()
        {
            List<DieuHanhTaxi> lstCuocGoiHon3Thang = new List<DieuHanhTaxi>();
            try
            {
                DataTable dt = new DataTable();

                dt = new Data.DieuHanhTaxi().GetNhungCuocGoiNhoHon3ThangGanDay();
                if (dt != null)
                {
                    if (dt.Rows.Count <= 0) return null;
                    else
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            lstCuocGoiHon3Thang.Add(GetDieuHanhTaxi(dr));
                        }

                    }
                }
                return lstCuocGoiHon3Thang;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// xoa cac cuoc goi cahc day hon 3 thang
        /// </summary>
        public static bool DeleteNhungCuocGoiNhoHon3ThangGanDay()
        {
            return new Data.DieuHanhTaxi().DeleteNhungCuocGoiNhoHon3ThangGanDay( );
        }
        /// <summary>
        /// trả về dữ liệu riêng của cuộc g
        /// </summary>
        /// <returns></returns>
        public string toStringData()
        {
            string strT = "";
            strT += this.ID_DieuHanh.ToString() + "#%#";
            strT += this.Line  + "#%#";
            strT += this.PhoneNumber + "#%#"; 
             strT += string.Format("{0:HH:mm:ss dd/MM/yyyy}", this.ThoiDiemGoi) + "#%#"; 
             strT += this.ThoiDiemChuyenTongDai.ToString () + "#%#"; 
            strT += string.Format("{0:HH:mm:ss dd/MM/yyyy}", this.DoDaiCuocGoi) + "#%#"; 
             strT += this.SoLuotDoChuong.ToString() + "#%#"; 
              strT += this.DiaChiGoi + "#%#";
              strT += this.DiaChiDonKhach + "#%#"; 
            strT += this.KieuKhachHangGoiDen.ToString() + "#%#";
            strT += this.GoiTaxi.ToString () + "#%#";
            strT += this.ThongTinKhac.ToString() + "#%#";
            strT += this.GoiLai.ToString () + "#%#";
            strT += this.LoaiXe + "#%#";
            strT += this.SoLuong + "#%#";
            strT += this.ChonTaxi4Cho.ToString () + "#%#";
            strT += this.ChonTaxi7Cho.ToString () + "#%#";
            strT += this.MaVung + "#%#";
            strT += this.LenhDienThoai + "#%#";
            strT += this.LenhTongDai + "#%#";
            strT += this.MaNhanVienDienThoai + "#%#";
            strT += this.MaNhanVienTongDai + "#%#";
            strT += this.XeNhan + "#%#";
            strT += this.XeDon + "#%#";
            strT += this.DiaChiTraKhach + "#%#";
            strT += this.GhiChuDienThoai + "#%#";
            strT += this.GhiChuTongDai + "#%#";
            strT += this.TrangThaiLenh.ToString () + "#%#";
            strT += this.ThoiGianDieuXe.ToString () + "#%#";
            strT += this.ThoiGianDonKhach.ToString () + "#%#";
            strT += this.TrangThaiCuocGoi.ToString () + "#%#";
            strT += this.FileVoicePath + "#%#";
            strT += "|||";
            return strT;
        }

        /// <summary>
        /// hamf kiem tra xe da dang nhan diem chua
        ///   true : dang nhan diem
        ///   false la dang khong nhan diem nao
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="SoHieuXe"></param>
        /// <returns></returns>
        public static bool KiemTraXeNhanDaDangNhanCuocKhach(long ID, string SoHieuXe)
        {
            return new Data.DieuHanhTaxi().KiemTraXeNhanDaDangNhanCuocKhach(ID, SoHieuXe);
        }

        /// <summary>
        /// lấy form frmGiamSatXe
        /// </summary>
        /// <returns></returns>
        public static object GetFormGiamSatXe()
        {
            if (Application.OpenForms != null && Application.OpenForms.Count > 0)
            {
                 
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    if (Application.OpenForms[i].Name == "frmGiamSatXe")
                        return (object)Application.OpenForms[i];
                }
            }
            return null;
        }

        public bool UpdateCuocGoiDaGiaiQuyet( string XeNhan, string XeDon)
        {
            return new Data.DieuHanhTaxi().UpdateCuocGoiDaGiaiQuyet(this.ID_DieuHanh, XeNhan, XeDon);
        }




        #region XU LY CUOC GOI CAM ON
       
        /// <summary>
        /// cap nhat thong tin cuoc goi da cam on
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="DaCamOn"></param>
        /// <param name="KieuDanhGia"></param>
        /// <param name="YKienKhach"></param>
        /// <param name="NhanVienNhapDau"></param>
        /// <param name="NhanVienSua"></param>
        /// <returns></returns>
        public bool Update_CuocGoiCamOn(long ID, bool DaCamOn, KieuKhachDanhGiaCAMON KieuDanhGia, string YKienKhach, string NhanVienNhapDau, string NhanVienSua)
        {
            return new Data.DieuHanhTaxi().UpdateCuocGoiCamOn(ID, DaCamOn, KieuDanhGia, YKienKhach, NhanVienNhapDau, NhanVienSua);
        }
        #endregion XU LY CUOC GOI CAM ON

        #region XULY CAC CUOC GOI MoiKhach
         //Lấy các cuộc gọi như tổng đài
        public bool Update_MOIKHACH_MoiKhachGiu( )
        {
            return new Data.DieuHanhTaxi().Update_MOIKHACH(this.ID_DieuHanh, this.DiaChiDonKhach ,MOIKHACH_LenhMoiKhach,false , false , "", this.MOIKHACH_NhanVien );
        }

        public bool Update_MOIKHACH_KhongXeXinLoi( )
        {
            return new Data.DieuHanhTaxi().Update_MOIKHACH(this.ID_DieuHanh, this.DiaChiDonKhach, MOIKHACH_LenhMoiKhach, MOIKHACH_XinLoi_DaXinLoi, false, "", this.MOIKHACH_NhanVien);
        }

        public bool Update_MOIKHACH_KhieuNai( )
        {
            return new Data.DieuHanhTaxi().Update_MOIKHACH(this.ID_DieuHanh,this.DiaChiDonKhach, MOIKHACH_LenhMoiKhach, false, MOIKHACH_KhieuNai_DaXyLy, MOIKHACH_KhieuNai_ThongTinThem, MOIKHACH_NhanVien);
        }

        #endregion XULY CAC CUOC GOI CAM ON


        public static bool TongDai_ChuyenVung(long IDCuocGoi, int iVung)
        {
            return new Data.DieuHanhTaxi().TongDai_ChuyenVung(IDCuocGoi, iVung);
        }
        /// <summary>
        /// Cuộc gọi không xác định xe đón
        /// </summary>
        /// <param name="IDCuocGoi"></param>
        /// <returns></returns>
        public static bool  UpdateCuocKhachKetThucKhongXacDinhXeDon(long IDCuocGoi)
        {
            return new Data.DieuHanhTaxi().UpdateCuocKhachKetThucKhongXacDinhXeDon(IDCuocGoi);
        }
         
        /// <summary>
        /// Cuộc gọi không xác định xe đón, co nhân viên cskh
        /// </summary>
        /// <param name="IDCuocGoi"></param>
        /// <returns></returns>
        public static bool UpdateCuocKhachKetThucKhongXacDinhXeDon(long IDCuocGoi, string NhanVienCSKH, string xeNhan)
        {
            return new Data.DieuHanhTaxi().UpdateCuocKhachKetThucKhongXacDinhXeDon(IDCuocGoi,NhanVienCSKH,xeNhan);
        }
        public static bool UpdateCuocGoiKhieuNaiKetThuc(long IDCuocGoi, string noiDungPA,string maNhanVienDienThoai)
        {
            return new Data.DieuHanhTaxi().UpdateCuocGoiKhieuNaiKetThuc(IDCuocGoi, noiDungPA, maNhanVienDienThoai);
        }
        /// <summary>
        /// Hàm thực hiện cập nhật lại lệnh mời khách và giữ khách khi v
        /// 
        /// IF LenhTongDai = "" AND LenhMoiKhach =""  -> Dat lai dienthoai truyen sang
        /// IF LenhTongDai >0 AND LenhMoiKhach ="" -->  Dat lai TrangThaiLenh = 'TongDai'
        /// 
        /// </summary>
        /// <param name="p"></param>
        public static bool UpdateTuDongMoiGiuKhach(long IDCuocGoi, string LenhTongDai, string LenhMoiKhach)
        {
            return new Data.DieuHanhTaxi().UpdateTuDongMoiGiuKhach(IDCuocGoi,LenhTongDai,LenhMoiKhach);
        }

        /// <summary>
        /// update thông tin cho ban giá
        /// </summary>
        /// <returns></returns>
        public bool Update_BanGiaBanTin()
        {
            return new Data.DieuHanhTaxi().Update_BanGiaBanTin(this.ID_DieuHanh,this.DiaChiDonKhach, this.BTBG_NoiDungXuLy,this.BTBG_NhanVien , this.BTBG_IsDaXuLy, this.MaVung  );
        }

        public static void TuDongChuyenSangTongDai()
        {
              new Data.DieuHanhTaxi().TuDongChuyenSangTongDai();
        }

        /// <summary>
        /// ham xoa di cac cuoc khach taxi khong dieu duoc sau so phut
        /// </summary>
        /// <param name="SoPhut"></param>
        public static void XoaTuDongCacCuocKhachQuaLau(int SoPhut, string Vungs)
        {
            new Data.DieuHanhTaxi().XoaTuDongCacCuocKhachQuaLau(SoPhut,Vungs);
        }

        public static void XoaTuDongCacCuocKhachQuaLau(int SoCuocGiuLai)
        {
            new Data.DieuHanhTaxi().XoaTuDongCacCuocKhachQuaLau(SoCuocGiuLai);
        }
        /// <summary>
        /// Cập nhật thời điểm mời khách
        /// </summary>
        public static bool Update_ThoiDiemMoiKhach(long IDDieuHanh, string NhanVienMoiID)
        {
            return new Data.DieuHanhTaxi().Update_ThoiDiemMoiKhach(IDDieuHanh,NhanVienMoiID);
        }

        public static int UpdateCSPhanBoCuocGoi(string strSQL)
        {
            return new Data.DieuHanhTaxi().UpdateCSPhanBoCuocGoi(strSQL);
        }
        /// <summary>
        /// hàm cập nhật thông tin xe đón phía chăm sóc khách hàng
        /// thiết lập
        ///   - Đón thành công
        ///   - Kết thúc tổng đài 
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="XeDon"></param>
        /// <param name="NhanVienCS"></param>
        public static void UpdateCSThongTinXeDon(long ID,string xeNhan, string  XeDon, string  NhanVienCS)
        {
            new Data.DieuHanhTaxi().UpdateCSPhanBoCuocGoi(ID, xeNhan,XeDon, NhanVienCS);
        }
        /// <summary>
        /// hàm thực hiện trả về thơi điểm gọi lại của cuộc gọi nhỡ
        /// Tìm trong cuoc goi đi từ thời điểm gọi đi 10 phút có số nào bằng điên thoại
        /// Nếu có trả về thời gian nếu không thì rỗng.
        /// </summary>
        public static string GetThoiDiemGoiLaiCuocGioNho(DateTime thoiDiemGoi, string soDienThoai)
        {
            string ret = string.Empty;
            DataTable dt = new Data.DieuHanhTaxi().GetThoiDiemGoiLaiCuocGioNho(thoiDiemGoi, soDienThoai);
            if (dt != null && dt.Rows.Count > 0)
            {   
                if(dt.Rows[0]["ThoiDiemGoi"] != null && dt.Rows[0]["ThoiDiemGoi"].ToString ().Length >0)
                {
                    ret = string.Format("{0:HH:mm}", Convert.ToDateTime (dt.Rows[0]["ThoiDiemGoi"].ToString ()));
                }
            }
            return ret;
        }

        /// <summary>
        /// ham tra ve da sach cuoc goi ket thuc co lay theo so dong
        /// paging - 
        /// </summary>
        /// <param name="linesChoPhep"></param>
        /// <param name="soDong"></param>
        /// <returns></returns>
        public static List<DieuHanhTaxi> DIENTHOAI_LayCuocGoiDaGiaiQuyet(string linesChoPhep, int soDong)
        {
            List<DieuHanhTaxi> lstCuocGoiKT = new List<DieuHanhTaxi>();
            try
            {
                DataTable dt = new DataTable();

                dt = new Data.DieuHanhTaxi().DIENTHOAI_LayCuocGoiDaGiaiQuyet(linesChoPhep, soDong);
                if (dt.Rows.Count <= 0) return null;
                else
                {                     
                    foreach (DataRow dr in dt.Rows)
                    {
                        lstCuocGoiKT.Add( DieuHanhTaxi.GetDieuHanhTaxiStatic(dr));
                    }
                    return lstCuocGoiKT;       
                }
            }
            catch (Exception ex)
            {
                return lstCuocGoiKT;
            }
        }
        /// <summary>
        /// lấy ds cuộc gọi của tổng đài
        /// có phần paging
        /// </summary>
        /// <param name="vungsDuocCapPhep"></param>
        /// <param name="soDong"></param>
        /// <returns></returns>
        public static List<DieuHanhTaxi>  TONGDAI_LayCuocGoiDaGiaiQuyet(string vungsDuocCapPhep, int soDong)
        {
            List<DieuHanhTaxi> lstCuocGoiKT = new List<DieuHanhTaxi>();
            try
            {
                DataTable dt = new DataTable();

                dt = new Data.DieuHanhTaxi().TONGDAI_LayCuocGoiDaGiaiQuyet(vungsDuocCapPhep, soDong);
                if (dt.Rows.Count <= 0) return null;
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        lstCuocGoiKT.Add(DieuHanhTaxi.GetDieuHanhTaxiStatic(dr));
                    }
                    return lstCuocGoiKT;
                }
            }
            catch (Exception ex)
            {
                return lstCuocGoiKT;
            }
        }

        /// <summary>
        /// ghép đầu số số tổng đài
        /// dauSoTongDai = "9";
        /// soDienThoai = "0905228313"
        /// --> return 90905228313
        /// </summary>
        /// <param name="p"></param>
        /// <param name="p_2"></param>
        /// <returns></returns>
        public static string GetSoDienThoai(string dauSoTongDai, string soDienThoai)
        {
            string tempSoDienThoai = soDienThoai;

            if (dauSoTongDai != null && dauSoTongDai.Length > 0)
                tempSoDienThoai = dauSoTongDai + tempSoDienThoai;

            return tempSoDienThoai;
        }

        #region ==============New v3=========================
        /// <summary>
        /// Search chi tiết cuộc gọi đến
        /// </summary>
        /// <param name="tuNgay"></param>
        /// <param name="denNgay"></param>
        /// <param name="kieuGoi"></param>
        /// <param name="loaiXe"></param>
        /// <param name="diaChi"></param>
        /// <param name="Vung"></param>
        /// <param name="soDienThoai"></param>
        /// <param name="line"></param>
        /// <param name="idNhanVienTD"></param>
        /// <param name="idNhanVienDT"></param>
        /// <param name="ketQuaDH"></param>
        /// <returns></returns>
        /// <modified>
        /// name            date        comments
        /// phupn         1/10/2011     created
        ///</modified>
        public List<DieuHanhTaxi> ML_GetCuocGoi_Search_V4(DateTime tuNgay, DateTime denNgay, string kieuGoi, string loaiXe, string diaChi, string Vung,
                        string soDienThoai, string line, int loaiCuocGoi, string xeNhan, string xeDon)
        {
            List<DieuHanhTaxi> lstCuocGoiDen = new List<DieuHanhTaxi>();
            try
            {
                DataTable dt = new DataTable();

                dt = new Taxi.Data.DieuHanhTaxi().ML_GetCuocGoi_Search_V4(tuNgay, denNgay, kieuGoi, loaiXe, diaChi, Vung, soDienThoai, line,
                                        loaiCuocGoi, xeNhan,xeDon);
                if (dt == null || dt.Rows.Count <= 0) return null;
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        lstCuocGoiDen.Add(GetChiTietCuocGoiDen2(dr));
                    }
                    return lstCuocGoiDen;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("ML_GetCuocGoi_Search_V4", ex);
                return lstCuocGoiDen;
            }

        }

        public List<DieuHanhTaxi> ML_GetCuocGoi_Search(DateTime tuNgay, DateTime denNgay, string kieuGoi, string loaiXe, string diaChi, string Vung,
                        string soDienThoai, string line, int loaiCuocGoi)
        {
            List<DieuHanhTaxi> lstCuocGoiDen = new List<DieuHanhTaxi>();
            try
            {
                DataTable dt = new DataTable();

                dt = new Taxi.Data.DieuHanhTaxi().ML_GetCuocGoi_Search(tuNgay, denNgay, kieuGoi, loaiXe, diaChi, Vung, soDienThoai, line,
                                        loaiCuocGoi);
                if (dt.Rows.Count <= 0) return null;
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        lstCuocGoiDen.Add(GetChiTietCuocGoiDen2(dr));
                    }
                    return lstCuocGoiDen;
                }
            }
            catch (Exception ex)
            {
                return lstCuocGoiDen;
            }

        }

        public DieuHanhTaxi GetChiTietCuocGoiDen2(DataRow drGoiDen)
        {
            DieuHanhTaxi objGoiDen = new DieuHanhTaxi();
            objGoiDen.ID_DieuHanh = long.Parse(drGoiDen["ID"].ToString());
            objGoiDen.Line = drGoiDen["Line"].ToString();
            objGoiDen.PhoneNumber = drGoiDen["PhoneNumber"].ToString();
            objGoiDen.ThoiDiemGoi = Convert.ToDateTime(drGoiDen["ThoiDiemGoi"]);
            //objGoiDen.SoLuotDoChuong = drGoiDen["SoLuotDoChuong"] == DBNull.Value ? 0 : Convert.ToInt32(drGoiDen["SoLuotDoChuong"]);
            objGoiDen.PhanLoai = drGoiDen["PhanLoai"].ToString();
            objGoiDen.DiaChiDonKhach = drGoiDen["DiaChiDonKhach"].ToString();
            objGoiDen.LoaiXe = drGoiDen["LoaiXe"].ToString();
            objGoiDen.SoLuong = drGoiDen["SoLuong"].ToString();
            objGoiDen.VungID = drGoiDen["Vung"] == DBNull.Value ? 0 : Convert.ToInt32(drGoiDen["Vung"]);
            objGoiDen.XeNhan = drGoiDen["XeNhan"].ToString();
            objGoiDen.XeDon = drGoiDen["XeDon"].ToString();
            objGoiDen.XeDenDiem = drGoiDen["XeDenDiem"].ToString();
            objGoiDen.KetQua = drGoiDen["KetQua"].ToString();
            //objGoiDen.ThoiDiemChuyenTongDai = drGoiDen["ThoiDiemChuyenTongDai"] == DBNull.Value ? 0 : Convert.ToInt32(drGoiDen["ThoiDiemChuyenTongDai"]);
            objGoiDen.ThoiGianDieuXe = drGoiDen["ThoiGianDieuXe"] == DBNull.Value ? 0 : Convert.ToInt32(drGoiDen["ThoiGianDieuXe"]);
            objGoiDen.ThoiGianDonKhach = drGoiDen["ThoiGianDonKhach"] == DBNull.Value ? 0 : Convert.ToInt32(drGoiDen["ThoiGianDonKhach"]);
            //objGoiDen.DoDaiCuocGoi = drGoiDen["ThoiLuong"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(drGoiDen["ThoiLuong"]);
            objGoiDen.MaNhanVienDienThoai = drGoiDen["MaNhanVienDienThoai"].ToString();
            objGoiDen.MaNhanVienTongDai = drGoiDen["MaNhanVienTongDai"].ToString();
            objGoiDen.LenhDienThoai = drGoiDen["LenhDienThoai"].ToString();
            objGoiDen.LenhTongDai = drGoiDen["LenhTongDai"].ToString();
            objGoiDen.GhiChuDienThoai = drGoiDen["GhiChuDienThoai"].ToString();
            objGoiDen.GhiChuTongDai = drGoiDen["GhiChuTongDai"].ToString();
            objGoiDen.MOIKHACH_LenhMoiKhach = drGoiDen["MOIKHACH_LenhMoiKhach"].ToString();
            objGoiDen.MOIKHACH_KhieuNai_ThongTinThem = drGoiDen["MOIKHACH_KhieuNai_ThongTinThem"].ToString();
            objGoiDen.FileVoicePath = drGoiDen["FileVoicePath"] == DBNull.Value ? string.Empty : drGoiDen["FileVoicePath"].ToString();
            objGoiDen.LenhLaiXe = !drGoiDen.Table.Columns.Contains("LenhLaiXe") || drGoiDen["LenhLaiXe"] == DBNull.Value ? "" : drGoiDen["LenhLaiXe"].ToString();
            return objGoiDen;

        }

        public static List<DieuHanhTaxi> BanTinGia_LayCuocGoiDaGiaiQuyet(string vungsDuocCapPhep, string linesDuocCapPhep, int soDong)
        {
            List<DieuHanhTaxi> lstCuocGoiKT = new List<DieuHanhTaxi>();
            try
            {
                DataTable dt = new DataTable();

                dt = new Data.DieuHanhTaxi().BanTinGia_LayCuocGoiDaGiaiQuyet(vungsDuocCapPhep, linesDuocCapPhep, soDong);
                if (dt.Rows.Count <= 0) return null;
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        lstCuocGoiKT.Add(DieuHanhTaxi.GetDieuHanhTaxiStatic(dr));
                    }
                    return lstCuocGoiKT;
                }
            }
            catch (Exception ex)
            {
                return lstCuocGoiKT;
            }
        }

        #endregion

        /// <summary>
        /// Congnt 
        ///   Neu len(line)>=3 thi la cuoc goi cua tong dai PBXIP
        ///   nguoc lai la cuoc cua he thong binh thuong
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static bool IsPBXIP(string line)
        {
            return (line.Length >= 3);
        }
        public static bool DeleteMuliCuocGoi(string idCuocGoi)
        {
            return new Data.DieuHanhTaxi().DeleteMuliCuocGoi(idCuocGoi) > 0;
        }

        public bool Insert_DienThoai_LanDau_ToaDo_TestCuocGoiLai_ToolTest(string parConnectDB)
        {
            try
            {

                long ID_DieuHanh = new Data.DieuHanhTaxi().Insert_DienThoai_LanDau_ToaDo_TestCuocGoiLai(this.Line, this.PhoneNumber, this.DiaChiDonKhach, this.KieuKhachHangGoiDen, this.TrangThaiCuocGoi, this.TrangThaiLenh, this.GPS_KinhDo, this.GPS_ViDo, MaDoiTac,parConnectDB);
                if (ID_DieuHanh > 0) // thanh cong
                {
                    this.ID_DieuHanh = ID_DieuHanh;
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Insert_DienThoai_LanDau_ToaDo_ToolTest(string parConnectDB)
        {
            try
            {

                long ID_DieuHanh = new Data.DieuHanhTaxi().Insert_DienThoai_LanDau_ToaDo(this.Line, this.PhoneNumber, this.DiaChiDonKhach, this.KieuKhachHangGoiDen, this.TrangThaiCuocGoi, this.TrangThaiLenh, this.GPS_KinhDo, this.GPS_ViDo, MaDoiTac,parConnectDB);
                if (ID_DieuHanh > 0) // thanh cong
                {
                    this.ID_DieuHanh = ID_DieuHanh;
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
