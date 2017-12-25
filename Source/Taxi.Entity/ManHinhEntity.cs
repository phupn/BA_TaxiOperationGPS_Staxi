using System;
using System.Collections.Generic;
using Taxi.Utils;

namespace Taxi.Entity
{
    public class ManHinhEntity
    {
        #region Properties

        private string _Id;
        /// <summary>
        /// ID tin nhan Man Hinh
        /// </summary>
        public string ID
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }

        private long _IDCuocGoi;
        /// <summary>
        /// Ma cuoc goi
        /// </summary>
        public long FK_CuocGoiID
        {
            get
            {
                return _IDCuocGoi;
            }
            set
            {
                _IDCuocGoi = value;
            }
        }

        private string _SoHieuXe;
        /// <summary>
        /// Xe gui tin nhan
        /// </summary>
        public string SoHieuXe
        {
            get
            {
                return _SoHieuXe;
            }
            set
            {
                _SoHieuXe = value;
            }
        }

        private string _TinNhan;
        /// <summary>
        /// tin nhan cua Xe gui 
        /// </summary>
        public string TinNhan
        {
            get
            {
                return _TinNhan;
            }
            set
            {
                _TinNhan = value;
            }
        }

        private string _GuiChoAi;
        /// <summary>
        /// tin nhan cua Xe gui 
        /// </summary>
        public string GuiChoAi
        {
            get
            {
                return _GuiChoAi;
            }
            set
            {
                _GuiChoAi = value;
            }
        }

        private LoaiTinNhanMH _LoaiTinNhan;
        /// <summary>
        /// Loai tin nhan
        /// </summary>
        public LoaiTinNhanMH LoaiTinNhan
        {
            get
            {
                return _LoaiTinNhan;
            }
            set
            {
                _LoaiTinNhan = value;
            }
        }

        private DateTime _ThoiDiemCuaXe;
        /// <summary>
        /// Thoi diem xe gui tin nhan
        /// </summary>
        public DateTime ThoiDiemCuaXe
        {
            get
            {
                return _ThoiDiemCuaXe;
            }
            set
            {
                _ThoiDiemCuaXe = value;
            }
        }

        private DateTime _ThoiDiemChen;
        /// <summary>
        /// Thoi diem chen tin nhan
        /// </summary>
        public DateTime ThoiDiemChen
        {
            get
            {
                return _ThoiDiemChen;
            }
            set
            {
                _ThoiDiemChen = value;
            }
        }

        private DateTime _ThoiDiemGoi;
        public DateTime ThoiDiemGoi
        {
            get
            {
                return _ThoiDiemGoi;
            }
            set
            {
                _ThoiDiemGoi = value;
            }
        }

        private int _Line;
        /// <summary>
        /// line dien thoai
        /// </summary>
        public int Line
        {
            get
            {
                return _Line;
            }
            set
            {
                _Line = value;
            }
        }

        private string _PhoneNumber;
        /// <summary>
        /// so dien thoai goi den
        /// </summary>
        public string PhoneNumber
        {
            get
            {
                return _PhoneNumber;
            }
            set
            {
                _PhoneNumber = value;
            }
        }

        private string _DiaChiDonKhach;
        /// <summary>
        /// dia chi thuc hien don khach
        /// </summary>
        public string DiaChiDonKhach
        {
            get
            {
                return _DiaChiDonKhach;
            }
            set
            {
                _DiaChiDonKhach = value;
            }
        }

        private int _Vung;
        /// <summary>
        /// vung (kenh) cua diem dia chi don khach
        /// </summary>
        public int Vung
        {
            get
            {
                return _Vung;
            }
            set
            {
                _Vung = value;
            }
        }

        private LoaiCuocKhach _LoaiCuocKhach;
        /// <summary>
        /// loai cuoc khach
        /// </summary>
        public LoaiCuocKhach LoaiCuocKhach
        {
            get
            {
                return _LoaiCuocKhach;
            }
            set
            {
                _LoaiCuocKhach = value;
            }
        }

        private string _LenhDienThoai;
        /// <summary>
        /// lenh dien thoai, lenh tu nhan vien dien thoai chuyen sang
        /// cho nhan vien tong dai
        /// </summary>
        public string LenhDienThoai
        {
            get
            {
                return _LenhDienThoai;
            }
            set
            {
                _LenhDienThoai = value;
            }
        }

        private string _LenhTongDai;
        /// <summary>
        /// lenh tong dai chuyen sang ben dien thoai
        /// </summary>
        public string LenhTongDai
        {
            get
            {
                return _LenhTongDai;
            }
            set
            {
                _LenhTongDai = value;
            }
        }

        private TrangThaiLenhTaxi _TrangThaiLenh;
        /// <summary>
        /// trang thai lenh  gan den thay thong tin ben nao thay doi tran trai cuoi cung
        ///
        /// </summary>
        public TrangThaiLenhTaxi TrangThaiLenh
        {
            get
            {
                return _TrangThaiLenh;
            }
            set
            {
                _TrangThaiLenh = value;
            }
        }

        private string _MaNhanVienDienThoai;
        /// <summary>
        /// ma nhan vien dien thoai
        /// </summary>
        public string MaNhanVienDienThoai
        {
            get
            {
                return _MaNhanVienDienThoai;
            }
            set
            {
                _MaNhanVienDienThoai = value;
            }
        }

        private string _MaNhanVienTongDai;
        /// <summary>
        /// ma nhien vien tong dai
        /// </summary>
        public string MaNhanVienTongDai
        {
            get
            {
                return _MaNhanVienTongDai;
            }
            set
            {
                _MaNhanVienTongDai = value;
            }
        }

        private string _XeNhan;
        /// <summary>
        /// Xe nhan
        /// </summary>
        public string XeNhan
        {
            get
            {
                return _XeNhan;
            }
            set
            {
                _XeNhan = value;
            }
        }

        private string _XeDon;
        /// <summary>
        /// xe don 
        /// </summary>
        public string XeDon
        {
            get
            {
                return _XeDon;
            }
            set
            {
                _XeDon = value;
            }
        }

        private int _SoLuong;
        /// <summary>
        /// So luong xe
        /// </summary>
        public int SoLuong
        {
            get
            {
                return _SoLuong;
            }
            set
            {
                _SoLuong = value;
            }
        }

        //public ManHinhEntity(string _Id, long _IDCuocGoi, string _SoHieuXe, string _TinNhan, string _GuiChoAi,
        //    LoaiTinNhanMH _LoaiTinNhan, DateTime _ThoiDiemCuaXe, DateTime _ThoiDiemChen, DateTime _ThoiDiemGoi, int _Line,
        //    string _PhoneNumber, string _DiaChiDonKhach, int _Vung, LoaiCuocKhach _LoaiCuocKhach, string _LenhDienThoai,
        //    string _LenhTongDai, TrangThaiLenhTaxi _TrangThaiLenh, string _MaNhanVienDienThoai, string _MaNhanVienTongDai,
        //    string _XeNhan, string _XeDon, int _SoLuong)
        //{
        //    ID = _Id;
        //    FK_CuocGoiID = _IDCuocGoi;
        //    SoHieuXe = _SoHieuXe;
        //    TinNhan = _TinNhan;
        //    GuiChoAi = _GuiChoAi;
        //    LoaiTinNhan = _LoaiTinNhan;
        //    ThoiDiemCuaXe = _ThoiDiemCuaXe;
        //    ThoiDiemChen = _ThoiDiemChen;
        //    ThoiDiemGoi = _ThoiDiemGoi;
        //    Line = _Line;
        //    PhoneNumber = _PhoneNumber;
        //    DiaChiDonKhach = _DiaChiDonKhach;
        //    Vung = _Vung;
        //    LoaiCuocKhach = _LoaiCuocKhach;
        //    LenhDienThoai = _LenhDienThoai;
        //    LenhTongDai = _LenhTongDai;
        //    TrangThaiLenh = _TrangThaiLenh;
        //    MaNhanVienDienThoai = _MaNhanVienDienThoai;
        //    MaNhanVienTongDai = _MaNhanVienTongDai;
        //    XeNhan = _XeNhan;
        //    XeDon = _XeDon;
        //    SoLuong = _SoLuong;
        //}
         public ManHinhEntity()
         {
             
         }
         
#endregion Properties
    }
}