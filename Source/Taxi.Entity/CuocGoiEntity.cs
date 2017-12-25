using System;

using Taxi.Utils;

namespace Taxi.Entity
{
    public class CuocGoiEntity
    {
        #region Properties

        private long id;
        /// <summary>
        /// Ma cuoc goi
        /// </summary>
        public long IDCuocGoi
        {
            get { return id; }
            set { id = value; }
        }
        private DateTime thoiDiemGoi;
        /// <summary>
        /// thoi diem goi
        /// </summary>
        public DateTime ThoiDiemGoi
        {
            get { return thoiDiemGoi; }
            set { thoiDiemGoi = value; }
        }
        private int soLanGoi;
        /// <summary>
        /// số lần khách đã gọi
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
        public int SoChuong
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
        public DateTime ThoiLuongGoi
        {
            get { return thoiLuongGoi; }
            set { thoiLuongGoi = value; }
        }

        private string diaChiLuu;
        /// <summary>
        /// dia chi luu, dia chi luu tu he thong co the lay lai su dung
        /// </summary>
        public string DiaChiLuu
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
        public int SoLuongXe
        {
            get { return soLuongXe; }
            set { soLuongXe = value; }
        }

        //private string _tinNhanDTV;
        ///// <summary>
        ///// Nội dung tin nhắn của Điện thoại viên
        ///// </summary>
        //public string TinNhanDTV
        //{
        //    get { return _tinNhanDTV; }
        //    set { _tinNhanDTV = value; }
        //}

        //private string _tinNhanDHV;
        ///// <summary>
        ///// Nội dung tin nhắn của Điêu hành viên
        ///// </summary>
        //public string TinNhanDHV
        //{
        //    get { return _tinNhanDHV; }
        //    set { _tinNhanDHV = value; }
        //}

        //private bool _tinNhanDTV_DaDoc;
        ///// <summary>
        ///// Trạng thái tin nhắn DTV
        ///// </summary>
        //public bool TinNhanDTV_DaDoc
        //{
        //    get { return _tinNhanDTV_DaDoc; }
        //    set { _tinNhanDTV_DaDoc = value; }
        //}

        //private bool _tinNhanDHV_DaDoc;
        ///// <summary>
        ///// Trạng thái tin nhắn DHV
        ///// </summary>
        //public bool TinNhanDHV_DaDoc
        //{
        //    get { return _tinNhanDHV_DaDoc; }
        //    set { _tinNhanDHV_DaDoc = value; }
        //}

        private KieuKhachHangGoiDen loaiKhachHang;
        /// <summary>
        /// kieu khach hang goi den 
        /// KhachHangKhongHieu = 0, // khach vui ve, khach ao
        /// KhachHangBinhThuong=1,
        /// KhachHangMoiGioi=2,
        /// KhachHangVIP=3,
        /// KhachHangHen=9,
        /// </summary>
        public KieuKhachHangGoiDen LoaiKhachHang
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
        /// trang thai lenh  gan den thay thong tin ben nao thay doi tran trai cuoi cung
        /// 
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
        /// Xe nhan
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
        public int ThoiGianChuyenTongDai
        {
            get { return thoiGianChuyenTongDai; }
            set { thoiGianChuyenTongDai = value; }
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

        private int thoiGianDonKhach;
        /// <summary>
        /// thoigian don duoc khach tu luc co xe don
        /// </summary>
        public int ThoiGianDonKhach
        {
            get { return thoiGianDonKhach; }
            set { thoiGianDonKhach = value; }
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
        private bool coGPS;
        /// <summary>
        /// dia chi cua khach co lay duoc thong tin toa do
        /// </summary>
        public bool CoGPS
        {
            get { return coGPS; }
            set { coGPS = value; }
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
        /// danh sach xe de cu
        /// </summary>
        public string DanhSachXeDeCu
        {
            get { return danhSachXeDeCu; }
            set { danhSachXeDeCu = value; }
        }
        private string danhSachXeDeCu_TD;
        /// <summary>
        /// danh sach xe de cu
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
        public DateTime ThoiDiemCapNhat
        {
            get { return thoiDiemCapNhat; }
            set { thoiDiemCapNhat = value; }
        }

        private string moiKhach_Lenh;
        public string MOIKHACH_LenhMoiKhach
        {
            get { return moiKhach_Lenh; }
            set { moiKhach_Lenh = value; }
        }

        private string moiKhach_NhanVien;
        public string MOIKHACH_NhanVien
        {
            get { return moiKhach_NhanVien; }
            set { moiKhach_NhanVien = value; }
        }

        private string _xeDenDiem;
        /// <summary>
        /// Xe nhan
        /// </summary>
        public string XeDenDiem
        {
            get { return _xeDenDiem; }
            set { _xeDenDiem = value; }
        }

        private string _xeDenDiemDonKhach;
        /// <summary>
        /// Xe nhan
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
        #endregion Properties

        #region Contructor
        //  [ID] ,line,phoneNumber,soLan,[DiaChiDonKhach] ,[Vung] ,[LoaiXe] ,[SoLuongXe] ,[LoaiKhachHang]  ,[IsCuocGiaLap] 
           // ,[KieuCuocGoi] ,[LenhDienThoai]  ,[TrangThaiLenh] ,[GhiChuDienThoai] ,[MaNhanVienDienThoai] 
           //    ,[ThoiGianChuyenTongDai]    ,[DanhSachXe_DeCu] ,[ThoiDiemCapNhatXeDeCu] 
        /// <summary>
        /// khoi tao cuoc goi tu dien thoai --> tongdai
        /// </summary>
        /// <param name="idCuocGoi"></param>
        /// <param name="diaChiDonKhach"></param>
        /// <param name="vung"></param>
        /// <param name="loaiXe"></param>
        /// <param name="soLuongXe"></param>
        /// <param name="loaiKhachHang"></param>
        /// <param name="isCuocGiaLap"></param>
        /// <param name="kieuCuocGoi"></param>
        /// <param name="lenhDienThoai"></param>
        /// <param name="ghiChuDT"></param>
        /// <param name="trangThaiLenh"></param>
        /// <param name="maNVDT"></param>
        /// <param name="thoiGianChuyenTD"></param>
        /// <param name="dsXeDeCu"></param>
        /// <param name="thoiDiemXeDeCu"></param>
        public CuocGoiEntity(long idCuocGoi,DateTime thoiDiemGoi, int  line, string phoneNumber,int soLanGoi, string diaChiDonKhach, int vung, string loaiXe, int soLuongXe, KieuKhachHangGoiDen loaiKhachHang,
                               bool isCuocGiaLap, KieuCuocGoi kieuCuocGoi, string lenhDienThoai, string ghiChuDT, TrangThaiLenhTaxi trangThaiLenh,
                               string maNVDT, int thoiGianChuyenTD, string dsXeDeCu, DateTime thoiDiemXeDeCu, string dsXeDeCu_TD,double KD,double VD)
        {
            this.IDCuocGoi = idCuocGoi;
            this.ThoiDiemGoi = thoiDiemGoi;
            this.Line = line;
            this.PhoneNumber = phoneNumber;
            this.SoLanGoi = soLanGoi ;
            this.DiaChiDonKhach = diaChiDonKhach;
            this.Vung = vung ;         
            this.LoaiXe = loaiXe;
            this.SoLuongXe = soLuongXe;
             this.LoaiKhachHang = loaiKhachHang;
             this.IsCuocGiaLap = isCuocGiaLap;
             this.KieuCuocGoi = kieuCuocGoi;
             this.LenhDienThoai = lenhDienThoai;
             this.GhiChuDienThoai = ghiChuDT;
             this.TrangThaiLenh = trangThaiLenh;
            this.MaNhanVienDienThoai = maNVDT ;
            this.ThoiGianChuyenTongDai = thoiGianChuyenTD;

            this.DanhSachXeDeCu = dsXeDeCu;
            this.DanhSachXeDeCu_TD = dsXeDeCu_TD;
            this.ThoiDiemCapNhatXeDeCu = thoiDiemXeDeCu;
            this.GPS_ViDo = VD;
            this.GPS_KinhDo = KD;

        }

        public CuocGoiEntity(long idCuocGoi, DateTime thoiDiemGoi, int line, string phoneNumber, int soLanGoi, string diaChiDonKhach, int vung, string loaiXe, int soLuongXe, KieuKhachHangGoiDen loaiKhachHang,
                               bool isCuocGiaLap, KieuCuocGoi kieuCuocGoi, string lenhDienThoai, string ghiChuDT, TrangThaiLenhTaxi trangThaiLenh,
                               string maNVDT, int thoiGianChuyenTD, string dsXeDeCu, DateTime thoiDiemXeDeCu, string dsXeDeCu_TD, double KD, double VD,string strXeNhan)
        {
            this.IDCuocGoi = idCuocGoi;
            this.ThoiDiemGoi = thoiDiemGoi;
            this.Line = line;
            this.PhoneNumber = phoneNumber;
            this.SoLanGoi = soLanGoi;
            this.DiaChiDonKhach = diaChiDonKhach;
            this.Vung = vung;
            this.LoaiXe = loaiXe;
            this.SoLuongXe = soLuongXe;
            this.LoaiKhachHang = loaiKhachHang;
            this.IsCuocGiaLap = isCuocGiaLap;
            this.KieuCuocGoi = kieuCuocGoi;
            this.LenhDienThoai = lenhDienThoai;
            this.GhiChuDienThoai = ghiChuDT;
            this.TrangThaiLenh = trangThaiLenh;
            this.MaNhanVienDienThoai = maNVDT;
            this.ThoiGianChuyenTongDai = thoiGianChuyenTD;

            this.DanhSachXeDeCu = dsXeDeCu;
            this.DanhSachXeDeCu_TD = dsXeDeCu_TD;
            this.ThoiDiemCapNhatXeDeCu = thoiDiemXeDeCu;
            this.GPS_ViDo = VD;
            this.GPS_KinhDo = KD;
            this.XeNhan = strXeNhan;
        }

        public CuocGoiEntity(long idCuocGoi, DateTime thoiDiemGoi, int line, string phoneNumber, int soLanGoi, string diaChiDonKhach, int vung, string loaiXe, int soLuongXe, KieuKhachHangGoiDen loaiKhachHang,
                               bool isCuocGiaLap, KieuCuocGoi kieuCuocGoi, string lenhDienThoai, string ghiChuDT, string lenhTongDai, string ghiChuTD, TrangThaiLenhTaxi trangThaiLenh,
                               string maNVDT, string maNVTD, int thoiGianChuyenTD, string dsXeDeCu, DateTime thoiDiemXeDeCu, string dsXeDeCu_TD, double KD, double VD, string strXeNhan, string strXeNhan_TD, string LenhMoiKhach, string NhanVienMoiKhach, string xeDenDiem, string xeDenDiemDonKhach, string xeDenDiemDonKhach_TD)
        {
            this.IDCuocGoi = idCuocGoi;
            this.ThoiDiemGoi = thoiDiemGoi;
            this.Line = line;
            this.PhoneNumber = phoneNumber;
            this.SoLanGoi = soLanGoi;
            this.DiaChiDonKhach = diaChiDonKhach;
            this.Vung = vung;
            this.LoaiXe = loaiXe;
            this.SoLuongXe = soLuongXe;
            this.LoaiKhachHang = loaiKhachHang;
            this.IsCuocGiaLap = isCuocGiaLap;
            this.KieuCuocGoi = kieuCuocGoi;
            this.LenhDienThoai = lenhDienThoai;
            this.GhiChuDienThoai = ghiChuDT;
            this.LenhTongDai = lenhTongDai;
            this.GhiChuTongDai = ghiChuTD;
            this.TrangThaiLenh = trangThaiLenh;
            this.MaNhanVienDienThoai = maNVDT;
            this.MaNhanVienTongDai = maNVTD;
            this.ThoiGianChuyenTongDai = thoiGianChuyenTD;

            this.DanhSachXeDeCu = dsXeDeCu;
            this.DanhSachXeDeCu_TD = dsXeDeCu_TD;
            this.ThoiDiemCapNhatXeDeCu = thoiDiemXeDeCu;
            this.GPS_ViDo = VD;
            this.GPS_KinhDo = KD;
            this.XeNhan = strXeNhan;
            this.XeNhan_TD = strXeNhan_TD;
            this.MOIKHACH_LenhMoiKhach = LenhMoiKhach;
            this.MOIKHACH_NhanVien = NhanVienMoiKhach;
            XeDenDiem = xeDenDiem;
            XeDenDiemDonKhach = xeDenDiemDonKhach;
            XeDenDiemDonKhach_TD = xeDenDiemDonKhach_TD;
        }


        public CuocGoiEntity(long idCuocGoi, DateTime thoiDiemGoi, int line, string phoneNumber, int soLanGoi, string diaChiDonKhach, int vung, string loaiXe, int soLuongXe, KieuKhachHangGoiDen loaiKhachHang,
                              bool isCuocGiaLap, KieuCuocGoi kieuCuocGoi, string lenhDienThoai, string ghiChuDT, string lenhTongDai, string ghiChuTD, TrangThaiLenhTaxi trangThaiLenh,
                              string maNVDT, string maNVTD, int thoiGianChuyenTD, string dsXeDeCu, DateTime thoiDiemXeDeCu, string dsXeDeCu_TD, double KD, double VD, string strXeNhan, string strXeNhan_TD, 
                            string LenhMoiKhach, string NhanVienMoiKhach, string xeDenDiem, string xeDenDiemDonKhach, string xeDenDiemDonKhach_TD, TrangThaiCuocGoiTaxi trangthaicuocgoitaxi)
        {
            this.IDCuocGoi = idCuocGoi;
            this.ThoiDiemGoi = thoiDiemGoi;
            this.Line = line;
            this.PhoneNumber = phoneNumber;
            this.SoLanGoi = soLanGoi;
            this.DiaChiDonKhach = diaChiDonKhach;
            this.Vung = vung;
            this.LoaiXe = loaiXe;
            this.SoLuongXe = soLuongXe;
            this.LoaiKhachHang = loaiKhachHang;
            this.IsCuocGiaLap = isCuocGiaLap;
            this.KieuCuocGoi = kieuCuocGoi;
            this.LenhDienThoai = lenhDienThoai;
            this.GhiChuDienThoai = ghiChuDT;
            this.LenhTongDai = lenhTongDai;
            this.GhiChuTongDai = ghiChuTD;
            this.TrangThaiLenh = trangThaiLenh;
            this.MaNhanVienDienThoai = maNVDT;
            this.MaNhanVienTongDai = maNVTD;
            this.ThoiGianChuyenTongDai = thoiGianChuyenTD;

            this.DanhSachXeDeCu = dsXeDeCu;
            this.DanhSachXeDeCu_TD = dsXeDeCu_TD;
            this.ThoiDiemCapNhatXeDeCu = thoiDiemXeDeCu;
            this.GPS_ViDo = VD;
            this.GPS_KinhDo = KD;
            this.XeNhan = strXeNhan;
            this.XeNhan_TD = strXeNhan_TD;
            this.MOIKHACH_LenhMoiKhach = LenhMoiKhach;
            this.MOIKHACH_NhanVien = NhanVienMoiKhach;
            XeDenDiem = xeDenDiem;
            XeDenDiemDonKhach = xeDenDiemDonKhach;
            XeDenDiemDonKhach_TD = xeDenDiemDonKhach_TD;
            TrangThaiCuocGoi = trangthaicuocgoitaxi;
        }

        #endregion Contructor
    }

}
