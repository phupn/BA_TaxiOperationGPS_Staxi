using System;
using System.Data;
using Taxi.Business.QuanTri;

namespace Taxi.Business
{
    public class ThongTinCauHinh
    {
        // Khai báo các tham biến
        static string mTenCongTy = "";

        public static string TenCongTy
        {
            get { return ThongTinCauHinh.mTenCongTy; }
            set { ThongTinCauHinh.mTenCongTy = value; }
        }
        static string mLogoPath = ""; //ApplicationPath +\Reports\Logo.jpg

        public static string LogoPath
        {
            get { return ThongTinCauHinh.mLogoPath; }
            set { ThongTinCauHinh.mLogoPath = value; }
        }

        static int mSoGiayGioiHanThoiGianChuyenTongDai = -1;

        public static int SoGiayGioiHanThoiGianChuyenTongDai
        {
            get { return ThongTinCauHinh.mSoGiayGioiHanThoiGianChuyenTongDai; }
            set { ThongTinCauHinh.mSoGiayGioiHanThoiGianChuyenTongDai = value; }

        }
        static int mSoGiayGioiHanThoiGianDieuXe = -1;

        public static int SoGiayGioiHanThoiGianDieuXe
        {
            get { return ThongTinCauHinh.mSoGiayGioiHanThoiGianDieuXe; }
            set { ThongTinCauHinh.mSoGiayGioiHanThoiGianDieuXe = value; }

        }
        static int mSoGiayGioiHanThoiGianDonKhach = -1;

        public static int SoGiayGioiHanThoiGianDonKhach
        {
            get { return ThongTinCauHinh.mSoGiayGioiHanThoiGianDonKhach; }
            set { ThongTinCauHinh.mSoGiayGioiHanThoiGianDonKhach = value; }
        }

        static int mSoPhutGioiHanMatLienLac = -1;
        /// <summary>
        /// Dùng cho báo nghỉ ăn ca
        /// </summary>
        public static int SoPhutGioiHanMatLienLac
        {
            get { return ThongTinCauHinh.mSoPhutGioiHanMatLienLac; }
            set { ThongTinCauHinh.mSoPhutGioiHanMatLienLac = value; }
        }
        static int mSoPhutGioiHanMatLienLacBaoNghi = -1;
        /// <summary>
        /// Dùng cho báo nghỉ rời xe
        /// </summary>
        public static int SoPhutGioiHanMatLienLacBaoNghi
        {
            get { return ThongTinCauHinh.mSoPhutGioiHanMatLienLacBaoNghi; }
            set { ThongTinCauHinh.mSoPhutGioiHanMatLienLacBaoNghi = value; }

        }
        static int mSoPhutGioiHanMatLienLacBaoDiSanBay = -1;
        /// <summary>
        /// Nghỉ khác
        /// </summary>
        public static int SoPhutGioiHanMatLienLacBaoDiSanBay
        {
            get { return ThongTinCauHinh.mSoPhutGioiHanMatLienLacBaoDiSanBay; }
            set { ThongTinCauHinh.mSoPhutGioiHanMatLienLacBaoDiSanBay = value; }
        }
        static int mSoPhutGioiHanMatLienLacBaoDiDuongDai = -1;

        public static int SoPhutGioiHanMatLienLacBaoDiDuongDai
        {
            get { return ThongTinCauHinh.mSoPhutGioiHanMatLienLacBaoDiDuongDai; }
            set { ThongTinCauHinh.mSoPhutGioiHanMatLienLacBaoDiDuongDai = value; }
        }

        static string mSoDauCuaTongDai = "";

        public static string SoDauCuaTongDai
        {
            get { return ThongTinCauHinh.mSoDauCuaTongDai; }
            set { ThongTinCauHinh.mSoDauCuaTongDai = value; }
        }

        static string mThuMucDuLieuTanasonic = "";

        public static string ThuMucDuLieuTanasonic
        {
            get { return ThongTinCauHinh.mThuMucDuLieuTanasonic; }
            set { ThongTinCauHinh.mThuMucDuLieuTanasonic = value; }
        }


        static string mThuMucFileAmThanh = "";

        public static string ThuMucFileAmThanh
        {
            get { return ThongTinCauHinh.mThuMucFileAmThanh; }
            set { ThongTinCauHinh.mThuMucFileAmThanh = value; }
        }

        static string mTatCaLineCuaHeThong = "";

        /// <summary>
        /// tất cả các line của hệ thông tổng đài
        /// 1;2;3;4;5;6;7;8
        /// </summary>
        public static string TatCaLineCuaHeThong
        {
            get { return ThongTinCauHinh.mTatCaLineCuaHeThong; }
            set { ThongTinCauHinh.mTatCaLineCuaHeThong = value; }
        }


        static string mCacLineCuaTaxiOperation = "";
        /// <summary>
        /// các line cho hệ thống TaxiOperation
        /// 1;2;3;4;5;6;7;8
        /// </summary>
        public static string CacLineCuaTaxiOperation
        {
            get { return ThongTinCauHinh.mCacLineCuaTaxiOperation; }
            set { ThongTinCauHinh.mCacLineCuaTaxiOperation = value; }
        }

        static string mSoDienThoaiCongTy = "";

        public static string SoDienThoaiCongTy
        {
            get { return ThongTinCauHinh.mSoDienThoaiCongTy; }
            set { ThongTinCauHinh.mSoDienThoaiCongTy = value; }
        }
        static bool mHasTongDai;
        /// <summary>
        /// công ty có dùng hệ thống tổng đài (Hipath 3800)
        /// </summary>
        public static bool HasTongDai
        {
            get { return ThongTinCauHinh.mHasTongDai; }
            set { ThongTinCauHinh.mHasTongDai = value; }
        }

        static int mSoDongCuocGoiDaGiaiQuyet;

        public static int SoDongCuocGoiDaGiaiQuyet
        {
            get
            {
                if (ThongTinCauHinh.mSoDongCuocGoiDaGiaiQuyet <= 0) return 50;
                else return ThongTinCauHinh.mSoDongCuocGoiDaGiaiQuyet;
            }
            set { ThongTinCauHinh.mSoDongCuocGoiDaGiaiQuyet = value; }
        }

        static bool mKiemTraXeDaRaHoatDong;
        /// <summary>
        /// Kiểm tra xe ra hoạt động có thông tin lái xe
        /// </summary>
        public static bool KiemTraXeDaRaHoatDong
        {
            get { return ThongTinCauHinh.mKiemTraXeDaRaHoatDong; }
            set { ThongTinCauHinh.mKiemTraXeDaRaHoatDong = value; }
        }

        static string mCacVungTongDai;

        public static string CacVungTongDai
        {
            get { return ThongTinCauHinh.mCacVungTongDai; }
            set { ThongTinCauHinh.mCacVungTongDai = value; }
        }
        static bool mTinhTienCuocHaiChieuKhongNgatCuoc;

        public static bool TinhTienCuocHaiChieuKhongNgatCuoc
        {
            get { return ThongTinCauHinh.mTinhTienCuocHaiChieuKhongNgatCuoc; }
            set { ThongTinCauHinh.mTinhTienCuocHaiChieuKhongNgatCuoc = value; }
        }
        static bool _KichHoachTaxiGroupDon;

        public static bool KichHoachTaxiGroupDon
        {
            get { return _KichHoachTaxiGroupDon; }
            set { _KichHoachTaxiGroupDon = value; }
        }
        static byte _SoPhutGiuKhachChuaCoXeNhan;

        public static byte SoPhutGiuKhachChuaCoXeNhan
        {
            get { return _SoPhutGiuKhachChuaCoXeNhan; }
            set { _SoPhutGiuKhachChuaCoXeNhan = value; }
        }
        static byte _SoPhutGiuKhachCoXeNhan;

        public static byte SoPhutGiuKhachCoXeNhan
        {
            get { return _SoPhutGiuKhachCoXeNhan; }
            set { _SoPhutGiuKhachCoXeNhan = value; }
        }
        static byte _SoPhutGiuKhachLai;

        public static byte SoPhutGiuKhachLai
        {
            get { return _SoPhutGiuKhachLai; }
            set { _SoPhutGiuKhachLai = value; }
        }

        public static string FolderAmThanh { get; set; }

        /// <summary>
        /// Có duyệt thì hiển thị control duyệt.
        /// Không thì disable đi
        /// </summary>
        public static bool FT_ChieuVe_CoDuyet { get; set; }
        /// <summary>
        /// Có chốt cơ thì hiển thị Group panel Nhập thông tin cơ đi cơ về
        /// </summary>
        public static bool FT_ChieuVe_CoChotCo { get; set; }
        /// <summary>
        /// Biến cấu hình sử dụng service của google hay BinhAnh lấy lộ trình và quãng đường đi.
        /// </summary>
        public static Utils.Enums.Enum_FT_ServiceMap FT_ServiceMap { get; set; }

        private static bool _layThongTinCauHinh { get; set; }
        public static void LayThongTinCauHinh()
        {
            if (_layThongTinCauHinh == false)
                _layThongTinCauHinh = true;
            else return;

            try
            {
                DataTable dt = QuanTriCauHinh.GetThongTinCauHinh();

                if ((dt == null) || (dt.Rows.Count <= 0))
                {
                    ThietLapMacDinh();
                }
                else
                {
                    DataRow dr = dt.Rows[0];
                    mTenCongTy = dr["TenCongTy"].ToString();
                    mLogoPath = dr["LogoCongTy"].ToString();

                    mSoGiayGioiHanThoiGianChuyenTongDai = int.Parse(dr["SoGiayGioiHanThoiGianChuyenTongDai"].ToString().Length > 0 ? dr["SoGiayGioiHanThoiGianChuyenTongDai"].ToString() : "60");
                    mSoGiayGioiHanThoiGianDieuXe = int.Parse(dr["SoGiayGioiHanThoiGianDieuXe"].ToString().Length > 0 ? dr["SoGiayGioiHanThoiGianDieuXe"].ToString() : "120");
                    mSoGiayGioiHanThoiGianDonKhach = int.Parse(dr["SoGiayGioiHanThoiGianDonKhach"].ToString().Length > 0 ? dr["SoGiayGioiHanThoiGianDonKhach"].ToString() : "300");

                    mSoPhutGioiHanMatLienLac = int.Parse(dr["SoPhutGioiHanMatLienLac"].ToString().Length > 0 ? dr["SoPhutGioiHanMatLienLac"].ToString() : "120");
                    mSoPhutGioiHanMatLienLacBaoNghi = int.Parse(dr["SoPhutGioiHanMatLienLacBaoNghi"].ToString().Length > 0 ? dr["SoPhutGioiHanMatLienLacBaoNghi"].ToString() : "180");
                    mSoPhutGioiHanMatLienLacBaoDiSanBay = int.Parse(dr["SoPhutGioiHanMatLienLacBaoDiSanBay"].ToString().Length > 0 ? dr["SoPhutGioiHanMatLienLacBaoDiSanBay"].ToString() : "180");
                    mSoPhutGioiHanMatLienLacBaoDiDuongDai = int.Parse(dr["SoPhutGioiHanMatLienLacBaoDiDuongDai"].ToString().Length > 0 ? dr["SoPhutGioiHanMatLienLacBaoDiDuongDai"].ToString() : "180");

                    mSoDauCuaTongDai = dr["SoDauCuaTongDai"].ToString();

                    mThuMucDuLieuTanasonic = dr["ThuMucDuLieuTanasonic"].ToString();
                    mThuMucFileAmThanh = dr["ThuMucFileAmThanh"].ToString();

                    mTatCaLineCuaHeThong = dr["TatCaLineCuaHeThong"].ToString();
                    mCacLineCuaTaxiOperation = dr["CacLineCuaTaxiOperation"].ToString();
                    mSoDienThoaiCongTy = dr["SoDienThoaiCongTy"].ToString();

                    mHasTongDai = Convert.ToBoolean(dr["HasTongDai"].ToString());
                    mSoDongCuocGoiDaGiaiQuyet = Convert.ToInt16(dr["SoDongCuocGoiDaGiaiQuyet"].ToString());

                    mKiemTraXeDaRaHoatDong = dr["KiemTraXeDaRaHoatDong"] != DBNull.Value && bool.Parse(dr["KiemTraXeDaRaHoatDong"].ToString());
                    mCacVungTongDai = dr["CacVungTongDai"].ToString();
                    mTinhTienCuocHaiChieuKhongNgatCuoc = dr["TinhTienCuocHaiChieuKhongNgatCuoc"] != DBNull.Value && bool.Parse(dr["TinhTienCuocHaiChieuKhongNgatCuoc"].ToString());

                    KichHoachTaxiGroupDon = dr["KichHoachTaxiGroupDon"] != DBNull.Value && bool.Parse(dr["KichHoachTaxiGroupDon"].ToString());
                    SoPhutGiuKhachChuaCoXeNhan = Convert.ToByte(dr["SoPhutGiuKhachChuaCoXeNhan"].ToString());
                    SoPhutGiuKhachCoXeNhan = Convert.ToByte(dr["SoPhutGiuKhachCoXeNhan"].ToString());
                    SoPhutGiuKhachLai = Convert.ToByte(dr["SoPhutGiuKhachLai"].ToString());

                    GPS_MaCungXN = dr["GPS_MaXN"].ToString();
                    GPS_LoaiBanDo = dr["GPS_MAP_LoaiBanDo"].ToString();
                    GPS_MucZoom = Convert.ToInt32(dr["GPS_MAP_Zoom"].ToString());
                    GPS_KinhDo = float.Parse(dr["GPS_MAP_KinhDo"].ToString());
                    GPS_ViDo = float.Parse(dr["GPS_MAP_ViDo"].ToString());
                    GPS_TenTinh = dr["GPS_TenTinh"].ToString();
                    GPS_TrangThai = dr["GPS_Trangthai"] != DBNull.Value && bool.Parse(dr["GPS_Trangthai"].ToString());
                    GPS_BKGioiHan = Convert.ToInt32(dr["GPS_BKGioiHan"].ToString());
                    GPS_BKXeNhan = Convert.ToInt32(dr["GPS_BKXeNhan"].ToString());
                    GPS_KetNoiManHinh = dr["GPS_KetNoiManHinh"] != DBNull.Value && bool.Parse(dr["GPS_KetNoiManHinh"].ToString());

                    GopKenh_TrangThai = dr["GopKenh_TrangThai"] != DBNull.Value && bool.Parse(dr["GopKenh_TrangThai"].ToString());
                    GopKenh_GioBD = TimeSpan.Parse(dr["GopKenh_GioBD"].ToString());
                    GopKenh_GioKT = TimeSpan.Parse(dr["GopKenh_GioKT"].ToString());
                    var ft = false;
                    if (dr.Table.Columns["FT_ChieuVe_CoDuyet"] != null)
                    {
                        bool.TryParse(dr["FT_ChieuVe_CoDuyet"].ToString(), out ft);
                        FT_ChieuVe_CoDuyet = ft;
                        var ft_ChieuVe_CoDuyet = false;
                        bool.TryParse(dr["FT_ChieuVe_CoChotCo"].ToString(), out ft_ChieuVe_CoDuyet);
                        FT_ChieuVe_CoChotCo = ft_ChieuVe_CoDuyet;
                    }
                    else
                    {
                        FT_ChieuVe_CoChotCo = false;
                    }
                    if (dr.Table.Columns["FT_KM"] != null)
                    {
                        int FT_KM = 1;
                        if (dr["FT_KM"] != DBNull.Value)
                            int.TryParse(dr["FT_KM"].ToString(), out FT_KM);
                        FT_SoKM = FT_KM;
                    }
                    else
                    {
                        FT_SoKM = 5;
                    }
                    if (dr.Table.Columns["FT_KM"] != null)
                    {
                        try
                        {
                            FT_ServiceMap = (Utils.Enums.Enum_FT_ServiceMap)Enum.Parse(typeof(Utils.Enums.Enum_FT_ServiceMap), dr["FT_ServiceMap"].ToString());
                        }
                        catch
                        {
                            FT_ServiceMap = Utils.Enums.Enum_FT_ServiceMap.Google;
                        }
                    }
                    else
                    {
                        FT_ServiceMap = Utils.Enums.Enum_FT_ServiceMap.None;
                    }
                    if (dr.Table.Columns["FT_ChieuVe_Active"] != null)
                    {
                        FT_ChieuVe_Active = dr["FT_ChieuVe_Active"] != DBNull.Value && bool.Parse(dr["FT_ChieuVe_Active"].ToString());
                    }
                    if (dr.Table.Columns["FT_Active"] != null)
                    {
                        FT_Active = dr["FT_Active"] != DBNull.Value && bool.Parse(dr["FT_Active"].ToString());
                    }

                    if (dr.Table.Columns.Contains("FolderAmThanh") && dr["FolderAmThanh"] != null && !string.IsNullOrEmpty(dr["FolderAmThanh"].ToString()))
                    {
                        FolderAmThanh = dr["FolderAmThanh"].ToString();
                    }
                    else
                    {
                        FolderAmThanh = @"D:\Public\AmThanhEnVangVip";
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("Lấy T.tin cấu hình", ex);
            }
        }
        private static void ThietLapMacDinh()
        {
            mTenCongTy = "Tên công ty";
            mLogoPath = "\\Reports\\Logo.jpg";

            mSoGiayGioiHanThoiGianChuyenTongDai = 60;
            mSoGiayGioiHanThoiGianDieuXe = 120;
            mSoGiayGioiHanThoiGianDonKhach = 300;

            mSoPhutGioiHanMatLienLac = 120;
            mSoPhutGioiHanMatLienLacBaoNghi = 180;
            mSoPhutGioiHanMatLienLacBaoDiSanBay = 180;
            mSoPhutGioiHanMatLienLacBaoDiDuongDai = 240;
            mSoDongCuocGoiDaGiaiQuyet = 50;
            mHasTongDai = false;
            mSoDienThoaiCongTy = "911";
            mKiemTraXeDaRaHoatDong = true;
        }

        #region ----new v3-----
        private static string mMaXn;
        public static string GPS_MaCungXN
        {
            set { mMaXn = value; }
            get { return mMaXn; }
        }
        /// <summary>
        /// so tuong ung voi loai ban do
        /// </summary>
        private static string mLoaiBanDo;
        public static string GPS_LoaiBanDo
        {
            set { ThongTinCauHinh.mLoaiBanDo = value; }
            get { return ThongTinCauHinh.mLoaiBanDo; }
        }
        /// <summary>
        /// muc zoo cua ban do
        /// </summary>
        static int mZoom;
        public static int GPS_MucZoom
        {
            set { ThongTinCauHinh.mZoom = value; }
            get { return ThongTinCauHinh.mZoom; }
        }
        static float mKinhDo;
        public static float GPS_KinhDo
        {
            set { ThongTinCauHinh.mKinhDo = value; }
            get { return ThongTinCauHinh.mKinhDo; }
        }

        static float mViDo;
        public static float GPS_ViDo
        {
            set { ThongTinCauHinh.mViDo = value; }
            get { return ThongTinCauHinh.mViDo; }
        }

        static string mTenTinh;
        public static string GPS_TenTinh
        {
            set { ThongTinCauHinh.mTenTinh = value; }
            get { return ThongTinCauHinh.mTenTinh; }
        }
        /// <summary>
        /// trang thai co ket noi gps ko
        /// </summary>
        static bool mTrangThai;
        public static bool GPS_TrangThai
        {
            set { ThongTinCauHinh.mTrangThai = value; }
            get { return ThongTinCauHinh.mTrangThai; }
        }
        static int mGPS_BKGioiHan;
        public static int GPS_BKGioiHan
        {
            set { ThongTinCauHinh.mGPS_BKGioiHan = value; }
            get { return ThongTinCauHinh.mGPS_BKGioiHan; }
        }
        static int mGPS_BKXeNhan;
        public static int GPS_BKXeNhan
        {
            set { ThongTinCauHinh.mGPS_BKXeNhan = value; }
            get { return ThongTinCauHinh.mGPS_BKXeNhan; }
        }
        static bool mGPS_KetNoiManHinh;

        public static bool GPS_KetNoiManHinh
        {
            get { return ThongTinCauHinh.mGPS_KetNoiManHinh; }
            set { ThongTinCauHinh.mGPS_KetNoiManHinh = value; }
        }

        private static bool _GopKenh_TrangThai;
        public static bool GopKenh_TrangThai
        {
            get { return _GopKenh_TrangThai; }
            set { _GopKenh_TrangThai = value; }
        }

        private static TimeSpan _GopKenh_GioBD;
        public static TimeSpan GopKenh_GioBD
        {
            get { return _GopKenh_GioBD; }
            set { _GopKenh_GioBD = value; }
        }

        private static TimeSpan _GopKenh_GioKT;
        public static TimeSpan GopKenh_GioKT
        {
            get { return _GopKenh_GioKT; }
            set { _GopKenh_GioKT = value; }
        }

        private static int? companyID;
        /// <summary>
        /// GPS_MaCungXN
        /// </summary>
        public static int CompanyID
        {
            get
            {
                return (int)(companyID ?? (companyID = (string.IsNullOrEmpty(GPS_MaCungXN) ? 0 : int.Parse(GPS_MaCungXN))));
            }
            set { companyID = value; }
        }
        public static bool FT_ChieuVe_Active { get; set; }
        public static bool FT_Active { get; set; }
        /// <summary>
        /// Cấu hình khoảng cách
        /// </summary>
        public static int FT_SoKM { get; set; }

        #endregion
        public static bool UpdateInsetThongTinCauHinh(string TenCongTy, string LogoPath, string SoDauCuaTongDai,
                        int SoGiayGioiHanThoiGianChuyenTongDai, int SoGiayGioiHanThoiGianDieuXe, int SoGiayGioiHanThoiGianDonKhach,
                        int SoPhutGioiHanMatLienLac, int SoPhutGioiHanMatLienLacBaoNghi, int SoPhutGioiHanMatLienLacBaoDiSanBay,
                        int SoPhutGioiHanMatLienLacBaoDiDuongDai, string ThuMucDuLieuTanasonic, string ThuMucFileAmThanh, string TatCaLineCuaHeThong,
                        string CacLineCuaTaxiOperation, string SoDienThoaiCongTy, bool hasTongDai, int SoDongCuocGoiDaGiaiQuyet, bool KiemTraXeDaRaHoatDong,
                        string CacVungTongDai, bool TinhTienCuocHaiChieuKhongNgatCuoc,
                        bool KichHoachTaxiGroupDon, byte SoPhutGiuKhachChuaCoXeNhan, byte SoPhutGiuKhachCoXeNhan, byte SoPhutGiuKhachLai,
            string MaCungXn, string BanDo, int Zoom, float KinhDo, float ViDo, string TenTinh, bool TrangThai, int BKGioiHan, int BKXeNhan,
            bool status, TimeSpan GioKT, TimeSpan GioBD, bool ft_ChieuVe_CoDuyet, bool ft_ChieuVe_CoChotCo, bool fT_Active, bool fT_ChieuVe_Active, int fT_ServiceMap, int fT_SoKM)
        {
            return new Data.QuanTri.QuanTriCauHinh().UpdateInsetThongTinCauHinh(TenCongTy, LogoPath, SoDauCuaTongDai,
                 SoGiayGioiHanThoiGianChuyenTongDai, SoGiayGioiHanThoiGianDieuXe, SoGiayGioiHanThoiGianDonKhach,
                 SoPhutGioiHanMatLienLac, SoPhutGioiHanMatLienLacBaoNghi, SoPhutGioiHanMatLienLacBaoDiSanBay, SoPhutGioiHanMatLienLacBaoDiDuongDai, ThuMucDuLieuTanasonic,
                 ThuMucFileAmThanh, TatCaLineCuaHeThong, CacLineCuaTaxiOperation, SoDienThoaiCongTy, hasTongDai, SoDongCuocGoiDaGiaiQuyet, KiemTraXeDaRaHoatDong,
                 CacVungTongDai, TinhTienCuocHaiChieuKhongNgatCuoc,
                 KichHoachTaxiGroupDon, SoPhutGiuKhachChuaCoXeNhan, SoPhutGiuKhachCoXeNhan, SoPhutGiuKhachLai,
                 MaCungXn, BanDo, Zoom, KinhDo, ViDo, TenTinh, TrangThai, BKGioiHan, BKXeNhan, status, GioKT, GioBD, ft_ChieuVe_CoDuyet, ft_ChieuVe_CoChotCo, fT_Active, fT_ChieuVe_Active, fT_ServiceMap, fT_SoKM);
        }
        /// <summary>
        /// hàm cập nhật thông tin ca
        /// Thông tin ca được tạo trước ID = 1
        /// </summary>
        public static bool CapNhatThongTinCa(int ID, DateTime DauCa1, DateTime KetThucCa1, DateTime KetThucCa2)
        {
            return new Data.QuanTri.QuanTriCauHinh().CapNhatThongTinCa(ID, DauCa1, KetThucCa1, KetThucCa2);
        }
        /// <summary>
        /// lấy thông tin ca
        /// </summary>
        public static DataTable GetThongTinCa(int ID)
        {
            return new Data.QuanTri.QuanTriCauHinh().GetThongTinCa(ID);
        }

        public static bool Update_GopKenh(bool status, TimeSpan GioKT, TimeSpan GioBD)
        {
            return new Data.QuanTri.QuanTriCauHinh().Update_GopKenh(status, GioKT, GioBD);
        }
        public static bool Update_CauHinhStaxi(bool ckbStaxi, bool ckbStaxiChieuVe)
        {
            return new Data.QuanTri.QuanTriCauHinh().Update_CauHinhStaxi(ckbStaxi, ckbStaxiChieuVe);
        }
        public static bool Update_CauHinhStaxiChieuVe(bool CoDuyet, bool CoChotCo, int ServerMapType, float KM)
        {
            return new Data.QuanTri.QuanTriCauHinh().Update_CauHinhStaxiChieuVe(CoDuyet, CoDuyet, ServerMapType, KM);
        }
    }
}
