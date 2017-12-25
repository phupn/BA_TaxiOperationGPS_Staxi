using System;
using System.Data;

namespace Taxi.Business.BanGiaGoc
{
    public class NhatkyThuebao
    {
        #region Properties

        private bool _IsQuanToan;

        public bool IsQuanToan
        {
            get { return _IsQuanToan; }
            set { _IsQuanToan = value; }
        }

        private int _ID;
        public int ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
            }
        }
        private DateTime _ThoiDiem;
        public DateTime ThoiDiem
        {
            get { return _ThoiDiem; }
            set
            {
                _ThoiDiem = value;
            }
        }
        private string _SoHieuXe;
        public string SoHieuXe
        {
            get { return _SoHieuXe; }
            set
            {
                _SoHieuXe = value;
            }
        }
        private string _TenLaiXe;
        public string TenLaiXe
        {
            get { return _TenLaiXe; }
            set
            {
                _TenLaiXe = value;
            }
        }
        private int _LoaiXeID;

        public int LoaiXeID
        {
            get { return _LoaiXeID; }
            set { _LoaiXeID = value; }
        }

        private string _TuyenDuongID;
        public string TuyenDuongID
        {
            get { return _TuyenDuongID; }
            set
            {
                _TuyenDuongID = value;
            }
        }

        private string _TenTuyenDuong;
        public string TenTuyenDuong
        {
            get { return _TenTuyenDuong; }
            set
            {
                _TenTuyenDuong = value;
            }
        }

        private int _Chieu;

        public int Chieu
        {
            get { return _Chieu; }
            set { _Chieu = value; }
        }

        private DateTime _ThoiGianDon;
        public DateTime ThoiGianDon
        {
            get { return _ThoiGianDon; }
            set
            {
                _ThoiGianDon = value;
            }
        }

        private int _KmDon;
        public int KmDon
        {
            get { return _KmDon; }
            set
            {
                _KmDon = value;
            }
        }
        private DateTime _ThoiGianTra;
        public DateTime ThoiGianTra
        {
            get { return _ThoiGianTra; }
            set
            {
                _ThoiGianTra = value;
            }
        }
        private int _KmTra;
        public int KmTra
        {
            get { return _KmTra; }
            set
            {
                _KmTra = value;
            }
        }

        private int _KmThucDi;

        public int KmThucDi
        {
            get { return _KmThucDi; }
            set { _KmThucDi = value; }
        }
        private string _GiaThueBao;

        public string GiaThueBao
        {
            get { return _GiaThueBao; }
            set { _GiaThueBao = value; }
        }

        private int _DongHoTien;
        public int DongHoTien
        {
            get { return _DongHoTien; }
            set
            {
                _DongHoTien = value;
            }
        }
        private string _PhuTroi;
        public string PhuTroi
        {
            get { return _PhuTroi; }
            set
            {
                _PhuTroi = value;
            }
        }
        private double _TienThucThu;
        public double TienThucThu
        {
            get { return _TienThucThu; }
            set
            {
                _TienThucThu = value;
            }
        }
        private string _MaNhanVienNhap;
        public string MaNhanVienNhap
        {
            get { return _MaNhanVienNhap; }
            set
            {
                _MaNhanVienNhap = value;
            }
        }
        private string _GhiChu;
        public string GhiChu
        {
            get { return _GhiChu; }
            set
            {
                _GhiChu = value;
            }
        } 
        private int _SoLanSuaDoi;

        public int SoLanSuaDoi
        {
            get { return _SoLanSuaDoi; }
            set { _SoLanSuaDoi = value; }
        }
        private string _soDienThoai;

        public string SoDienThoai
        {
            get { return _soDienThoai; }
            set { _soDienThoai = value; }
        }

        // Thêm thông tin CSKH
        private string _CSKH_NhanVienGoi;

        public string CSKH_NhanVienGoi
        {
            get { return _CSKH_NhanVienGoi; }
            set { _CSKH_NhanVienGoi = value; }
        }

        private DateTime _CSKH_ThoiDiemGoi;

        public DateTime CSKH_ThoiDiemGoi
        {
            get { return _CSKH_ThoiDiemGoi; }
            set { _CSKH_ThoiDiemGoi = value; }
        }

        private bool _CSKH_IsDaGoi;

        public bool CSKH_IsDaGoi
        {
            get { return _CSKH_IsDaGoi; }
            set { _CSKH_IsDaGoi = value; }
        }
        private int _TrangThaiGoi;

        public int CSKH_TrangThaiGoi
        {
            get { return _TrangThaiGoi; }
            set { _TrangThaiGoi = value; }
        }
        private string _CSKH_GhiChu;

        public string CSKH_GhiChu
        {
            get { return _CSKH_GhiChu; }
            set { _CSKH_GhiChu = value; }
        }

        private DateTime _CSKH_ThoiDiemCapNhanCuoi;

        public DateTime CSKH_ThoiDiemCapNhanCuoi
        {
          get { return _CSKH_ThoiDiemCapNhanCuoi; }
          set { _CSKH_ThoiDiemCapNhanCuoi = value; }
        }

        private bool _CSKH_KetThuc;

        public bool CSKH_KetThuc
        {
            get { return _CSKH_KetThuc; }
            set { _CSKH_KetThuc = value; }
        }

        private int _KieuTuyenDuong;

        public int KieuTuyenDuong
        {
            get { return _KieuTuyenDuong; }
            set { _KieuTuyenDuong = value; }
        }

        #endregion

        public int Insert(NhatkyThuebao pNhatkyThuebao)
        {
            Data.BanGiaGoc.NhatkyThuebao NhatkyThuebaoControl = new Data.BanGiaGoc.NhatkyThuebao();
            return NhatkyThuebaoControl.Insert(pNhatkyThuebao.ThoiDiem, pNhatkyThuebao.SoHieuXe, pNhatkyThuebao.TenLaiXe, pNhatkyThuebao.TuyenDuongID, pNhatkyThuebao.TenTuyenDuong, pNhatkyThuebao.Chieu, pNhatkyThuebao.ThoiGianDon, pNhatkyThuebao.KmDon, pNhatkyThuebao.ThoiGianTra, pNhatkyThuebao.KmTra, pNhatkyThuebao.KmThucDi, pNhatkyThuebao.DongHoTien, pNhatkyThuebao.PhuTroi, pNhatkyThuebao.TienThucThu, pNhatkyThuebao.MaNhanVienNhap, pNhatkyThuebao.GhiChu, pNhatkyThuebao.LoaiXeID, pNhatkyThuebao.GiaThueBao, pNhatkyThuebao.IsQuanToan,pNhatkyThuebao.SoDienThoai);
        }
        
        public int Update(NhatkyThuebao NhatkyThuebaoobj)
        {
            Data.BanGiaGoc.NhatkyThuebao NhatkyThuebaoControl = new Data.BanGiaGoc.NhatkyThuebao();
            return NhatkyThuebaoControl.Update( NhatkyThuebaoobj.TuyenDuongID, NhatkyThuebaoobj.TenTuyenDuong,NhatkyThuebaoobj.Chieu, NhatkyThuebaoobj.ThoiGianDon,NhatkyThuebaoobj.KmDon, NhatkyThuebaoobj.ThoiGianTra, NhatkyThuebaoobj.KmTra,NhatkyThuebaoobj.KmThucDi, NhatkyThuebaoobj.DongHoTien, NhatkyThuebaoobj.PhuTroi, NhatkyThuebaoobj.TienThucThu,  NhatkyThuebaoobj.GhiChu, NhatkyThuebaoobj.ID, NhatkyThuebaoobj.LoaiXeID,NhatkyThuebaoobj.GiaThueBao,NhatkyThuebaoobj.MaNhanVienNhap,NhatkyThuebaoobj.SoDienThoai);
        }

        public int Delete( int ID)
        {
            Data.BanGiaGoc.NhatkyThuebao NhatkyThuebaoControl = new Data.BanGiaGoc.NhatkyThuebao();
            return NhatkyThuebaoControl.Delete(ID);
        }

        public DataTable GetAll()
        {           
            Data.BanGiaGoc.NhatkyThuebao NhatkyThuebaoControl = new Data.BanGiaGoc.NhatkyThuebao();
            DataTable dt = NhatkyThuebaoControl.GetAll(); 
            return dt;
        }

        /// <summary>
        /// get ds nhung cuoc chua nhạp thông tin trả
        /// </summary>
        public DataTable GetDSNhungCuocChuaNhapDuThongTin()
        {

            Data.BanGiaGoc.NhatkyThuebao objNKTB = new Data.BanGiaGoc.NhatkyThuebao();
            DataTable dt = objNKTB.GetDSNhungCuocChuaNhapDuThongTin();
            return dt;
        }

        public static NhatkyThuebao Selectone(int ID)
        {
            try
            {
                Data.BanGiaGoc.NhatkyThuebao NhatkyThuebaoControl = new Data.BanGiaGoc.NhatkyThuebao();
                DataTable dt = NhatkyThuebaoControl.GetOne(ID);

                NhatkyThuebao objNhatkyThuebao = new NhatkyThuebao();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        objNhatkyThuebao.SoHieuXe = dt.Rows[0]["SoHieuXe"].ToString();
                        objNhatkyThuebao.ThoiDiem = Convert.ToDateTime(dt.Rows[0]["ThoiDiem"]);
                        objNhatkyThuebao.TenLaiXe = dt.Rows[0]["TenLaiXe"].ToString();
                        objNhatkyThuebao.TenTuyenDuong = dt.Rows[0]["TenTuyenDuong"].ToString();
                        objNhatkyThuebao.TuyenDuongID = dt.Rows[0]["TuyenDuongID"].ToString();
                        objNhatkyThuebao.TienThucThu = Convert.ToDouble(dt.Rows[0]["TienThucThu"]);
                        objNhatkyThuebao.ThoiGianTra = Convert.ToDateTime(dt.Rows[0]["ThoiGianTra"]);
                        objNhatkyThuebao.ThoiGianDon = Convert.ToDateTime(dt.Rows[0]["ThoiGianDon"]);
                        objNhatkyThuebao.KmTra = Convert.ToInt32(dt.Rows[0]["KmTra"]);
                        objNhatkyThuebao.KmDon = Convert.ToInt32(dt.Rows[0]["KmDon"]);
                        objNhatkyThuebao.KmThucDi = Convert.ToInt32(dt.Rows[0]["KmThucDi"]);
                        objNhatkyThuebao.PhuTroi = dt.Rows[0]["PhuTroi"].ToString();
                        objNhatkyThuebao.MaNhanVienNhap = dt.Rows[0]["MaNhanVienNhap"].ToString();

                        objNhatkyThuebao.GhiChu = dt.Rows[0]["GhiChu"].ToString();
                        objNhatkyThuebao.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                        objNhatkyThuebao.DongHoTien = Convert.ToInt32(dt.Rows[0]["DongHoTien"]);
                        objNhatkyThuebao.GiaThueBao = dt.Rows[0]["GiaThueBao"].ToString();
                        objNhatkyThuebao.IsQuanToan = Convert.ToBoolean(dt.Rows[0]["IsQuanToan"].ToString());
                        objNhatkyThuebao.LoaiXeID = Convert.ToInt32(dt.Rows[0]["LoaiXeID"]);
                        objNhatkyThuebao.Chieu = Convert.ToInt32(dt.Rows[0]["Chieu"]);
                        objNhatkyThuebao.SoDienThoai = dt.Rows[0]["SoDienThoai"].ToString();                        
                        objNhatkyThuebao.CSKH_GhiChu = dt.Rows[0]["CSKH_GhiChu"] == DBNull.Value ? "" : dt.Rows[0]["CSKH_GhiChu"].ToString();
                        objNhatkyThuebao.CSKH_IsDaGoi = dt.Rows[0]["CSKH_IsDaGoi"] != DBNull.Value && Convert.ToBoolean(dt.Rows[0]["CSKH_IsDaGoi"].ToString());
                        objNhatkyThuebao.CSKH_TrangThaiGoi = dt.Rows[0]["CSKH_TrangThaiGoi"] == DBNull.Value ? (byte)0 : Convert.ToByte(dt.Rows[0]["CSKH_TrangThaiGoi"].ToString());
                        objNhatkyThuebao.CSKH_KetThuc = dt.Rows[0]["CSKH_KetThuc"] != DBNull.Value && Convert.ToBoolean(dt.Rows[0]["CSKH_KetThuc"].ToString());
                        //Join với bảng tuyến đường!
                        objNhatkyThuebao.KieuTuyenDuong = dt.Columns.Contains("KieuTuyenDuong") ? (dt.Rows[0]["KieuTuyenDuong"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[0]["KieuTuyenDuong"])) : 0;

                        return objNhatkyThuebao;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("Selectone: ", ex);
                return null;
            }
        }

        public static DataTable GetBCNhatKyThueBao(string  strSQL)
        {
            return new Data.BanGiaGoc.NhatkyThuebao().GetBCNhatKyThueBao(strSQL);
        }
        /// <summary>
        /// hàm trả về ds các cuốc trong khonga thoi gian của mot xe
        /// bổ sung nội dung tìm khác, tim like cho nhiều phần
        /// </summary>
        public DataTable GetDSCuocThuebao(DateTime TuNgay, DateTime DenNgay, string SoHieuXe, string noiDungTimKhac)
        {
            return new Data.BanGiaGoc.NhatkyThuebao().GetDSCuocThuebao(TuNgay, DenNgay, SoHieuXe, noiDungTimKhac);
        }

        #region Xử lý cho CSKH
        public static bool GhiNhanThucHienGoi(long idThueBaoTuyen, string nhanVien, string ghiChu, byte  trangThaiCuocGoi,bool ketThuc)
        {
            return new Data.BanGiaGoc.NhatkyThuebao().GhiNhanThucHienGoi(idThueBaoTuyen, nhanVien, ghiChu, trangThaiCuocGoi, ketThuc);
        }

        #endregion Xử lý cho CSKH
    }
}
