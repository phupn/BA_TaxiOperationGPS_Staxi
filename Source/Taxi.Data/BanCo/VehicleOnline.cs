using System;

namespace Taxi.Data.BanCo
{
   public class VehicleOnline
    {
        private string _MaXN;

        public string MaXN
        {
            get { return _MaXN; }
            set { _MaXN = value; }
        }

        private string _BienSoXe;

        public string BienSoXe
        {
            get { return _BienSoXe; }
            set { _BienSoXe = value; }
        }

        private DateTime _ThoidiemGui;

        public DateTime ThoidiemGui
        {
            get { return _ThoidiemGui; }
            set { _ThoidiemGui = value; }
        }

        private DateTime _ThoidiemchenDLServer;

        public DateTime ThoidiemchenDLServer
        {
            get { return _ThoidiemchenDLServer; }
            set { _ThoidiemchenDLServer = value; }
        }

        private DateTime _ThoidiemChenDL;

        public DateTime ThoidiemChenDL
        {
            get { return _ThoidiemChenDL; }
            set { _ThoidiemChenDL = value; }
        }

        private DateTime _ThoiDiemDiChuyenGanNhat;

        public DateTime ThoiDiemDiChuyenGanNhat
        {
            get { return _ThoiDiemDiChuyenGanNhat; }
            set { _ThoiDiemDiChuyenGanNhat = value; }
        }

        private float _KinhDo;

        public float KinhDo
        {
            get { return _KinhDo; }
            set { _KinhDo = value; }
        }

        private float _ViDo;

        public float ViDo
        {
            get { return _ViDo; }
            set { _ViDo = value; }
        }

        private int _Vantocco;

        public int Vantocco
        {
            get { return _Vantocco; }
            set { _Vantocco = value; }
        }

        private int _VantocPGS;

        public int VantocPGS
        {
            get { return _VantocPGS; }
            set { _VantocPGS = value; }
        }

        private int _Trangthai;

        public int Trangthai
        {
            get { return _Trangthai; }
            set { _Trangthai = value; }
        }

        private string _SoHieuXe;

        public string SoHieuXe
        {
            get { return _SoHieuXe; }
            set { _SoHieuXe = value; }
        }

        private int _Huong;

        public int Huong
        {
            get { return _Huong; }
            set { _Huong = value; }
        }

        private int _SoChoNgoi;

        public int SoChoNgoi
        {
            get { return _SoChoNgoi; }
            set { _SoChoNgoi = value; }
        }

        private int _disTance;

        public int disTance
        {
            get { return _disTance; }
            set { _disTance = value; }
        }

        private double _goc;

        public double Goc
        {
            get { return _goc; }
            set { _goc = value; }
        }

        private float _ViDoCu;

        public float ViDoCu
        {
            get { return _ViDoCu; }
            set { _ViDoCu = value; }
        }

        private float _KinhDoCu;

        public float KinhDoCu
        {
            get { return _KinhDoCu; }
            set { _KinhDoCu = value; }
        }

        private int _LoaiXeGPS;

        public int LoaiXeGPS
        {
            get { return _LoaiXeGPS; }
            set { _LoaiXeGPS = value; }
        }

        private string _LoaiXe;

        public string LoaiXe
        {
            get { return _LoaiXe; }
            set { _LoaiXe = value; }
        }

        private string _Gara;

        public string Gara
        {
            get { return _Gara; }
            set { _Gara = value; }
        }

        private int _TGDungXeNoMay;

        public int TGDungXeNoMay
        {
            get { return _TGDungXeNoMay; }
            set { _TGDungXeNoMay = value; }
        }

        private int _VCo;

        public int VCo
        {
            get { return _VCo; }
            set { _VCo = value; }
        }

        private int _VGPS;

        public int VGPS
        {
            get { return _VGPS; }
            set { _VGPS = value; }
        }
        private DateTime _TGGPS;

        public DateTime TGGPS
        {
            get { return _TGGPS; }
            set { _TGGPS = value; }
        }

        private int _TrangThaiKhac;

        public int TrangThaiKhac
        {
            get { return _TrangThaiKhac; }
            set { _TrangThaiKhac = value; }
        }

        private string _TrangThaiKhacText;

        public string TrangThaiKhacText
        {
            get { return _TrangThaiKhacText; }
            set { _TrangThaiKhacText = value; }
        }

        private DateTime _TGCapNhat;

        public DateTime TGCapNhat
        {
            get { return _TGCapNhat; }
            set { _TGCapNhat = value; }
        }

        private int _VungID;

        public int VungID
        {
            get { return _VungID; }
            set { _VungID = value; }
        }

        #region Trip Online
        public int TongDoanhThu { set; get; }
        public int TongCuoc { set; get; }
        public double KmCoKhach { set; get; }
        public double KmRong { set; get; }
       /// <summary>
       /// Km rỗng (Trip)
       /// </summary>
        public double EmptyKm { set; get; }
       /// <summary>
        /// Km có khách (Trip)
       /// </summary>
        public double KmWithPassenger { set; get; }
       /// <summary>
       /// Thời gian chờ
       /// </summary>
        public int WaitingTime { set; get; }
        public int FreeWatingTime { set; get; }
       /// <summary>
       /// Tiền cuốc hiện tại
       /// </summary>
        public int Money { set; get; }

        #endregion
    }
}
