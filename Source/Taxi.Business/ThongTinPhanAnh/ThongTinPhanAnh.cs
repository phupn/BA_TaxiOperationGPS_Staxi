using System;
using System.Collections.Generic;
using System.Data;
using Taxi.Utils;

namespace Taxi.Business.ThongTinPhanAnh
{
    public class ThongTinPhanAnh
    {
        #region Properties
        private long _id;
        public long ID
        {
            set { _id = value; }
            get { return _id; }
        }
        private DateTime _thoiGianPhanAnh;
        public DateTime ThoiGianPhanAnh
        {
            set { _thoiGianPhanAnh = value; }
            get { return _thoiGianPhanAnh; }
        }
        private string _dienThoai;
        public string DienThoai
        {
            set { _dienThoai = value; }
            get { return _dienThoai; }
        }
        private string _tenKhachHang;
        public string TenKhachHang
        {
            set { _tenKhachHang = value; }
            get { return _tenKhachHang; }
        }
        private string _noiDung;
        public string NoiDung
        {
            set { _noiDung = value; }
            get { return _noiDung; }
        }
        private string _loaiPhanAnh;
        public string LoaiPhanAnh
        {
            set { _loaiPhanAnh = value; }
            get { return _loaiPhanAnh; }
        }
        private string _mucDo;
        public string MucDoPhanAnh
        {
            set { _mucDo = value; }
            get { return _mucDo; }
        }
        private string _tenCongTy;
        public string TenCongTy
        {
            set { _tenCongTy = value; }
            get { return _tenCongTy; }
        }
        private string _nhanVienTiepNhan;
        public string NhanVienTiepNhan
        {
            set { _nhanVienTiepNhan = value; }
            get { return _nhanVienTiepNhan; }
        }
        private string _ketQua;
        public string KetQua
        {
            set { _ketQua = value; }
            get { return _ketQua; }
        }
        private DateTime _ngayGiaiQuyet;
        public DateTime NgayGiaiQuyet
        {
            set { _ngayGiaiQuyet = value; }
            get { return _ngayGiaiQuyet; }
        }
        private string _mucHaiLong;
        public string MucHaiLong
        {
            set { _mucHaiLong = value; }
            get { return _mucHaiLong; }
        }
        private string _yKien;
        public string YKien
        {
            set { _yKien = value; }
            get { return _yKien; }
        }
        private string _nguoiGiaiQuyet;
        public string NguoiGiaiQuyet
        {
            set { _nguoiGiaiQuyet = value; }
            get { return _nguoiGiaiQuyet; }
        }
        private bool _trangThaiGiaiQuyet;
        public bool TrangThaiGiaiQuyet
        {
            set { _trangThaiGiaiQuyet = value; }
            get { return _trangThaiGiaiQuyet; }
        }
        private long _fkTaxiOperationID;
        public long FKTaxiOperationID
        {
            set { _fkTaxiOperationID = value; }
            get { return _fkTaxiOperationID; }
        }
        private int _congTyID;
        public int CongTyID
        {
            set { _congTyID = value; }
            get { return _congTyID; }
        }
        private int _loaiPhanAnhID;
        public int LoaiPhanhAnhID
        {
            set { _loaiPhanAnhID = value; }
            get { return _loaiPhanAnhID; }
        }
        private bool _chuyenDonVi;
        public bool ChuyenDonVi
        {
            set { _chuyenDonVi = value; }
            get { return _chuyenDonVi; }
        }
        private bool _isGoiLaiGoiKhac;

        public bool IsGoiLaiGoiKhac
        {
            get { return _isGoiLaiGoiKhac; }
            set { _isGoiLaiGoiKhac = value; }
        }
        private string _GhiChu;

        public string GhiChu
        {
            get { return _GhiChu; }
            set { _GhiChu = value; }
        }
        private string maThongTin;

        public string MaThongTin
        {
            get { return maThongTin; }
            set { maThongTin = value; }
        }

        private KieuKhachHangGoiDen _KieuKhachHangGoiDen;
        public KieuKhachHangGoiDen KieuKhachHangGoiDen
        {
            set { _KieuKhachHangGoiDen = value; }
            get { return _KieuKhachHangGoiDen; }
        }
        #endregion
        
        #region GET METHOD
        /// <summary>
        /// lay ra du lieu trong 1 dong roi gan voi thuoc tinh cua
        /// lop ThongTinPhanAnh
        /// </summary>
        /// <modified>
        /// name        date        comments
        /// hangtm      19/5/2011   created
        /// </modified>
        public ThongTinPhanAnh GetThongTinPhanAnh(DataRow drPhanAnh)
        {
            ThongTinPhanAnh objThongTinPA = new ThongTinPhanAnh();
            objThongTinPA.ID = long.Parse(drPhanAnh["ID"].ToString());
            objThongTinPA.ThoiGianPhanAnh = drPhanAnh["ThoiDiemPhanAnh"].ToString()== string.Empty ? DateTime.MinValue : (DateTime)drPhanAnh["ThoiDiemPhanAnh"];
            objThongTinPA.DienThoai = drPhanAnh["DienThoai"].ToString();
            objThongTinPA.TenKhachHang = drPhanAnh["TenKhachHang"].ToString();
            objThongTinPA.NoiDung = drPhanAnh["NoiDungPhanAnh"].ToString();
            objThongTinPA.LoaiPhanAnh = drPhanAnh["TenLoaiPhanAnh"].ToString();
            if (drPhanAnh["MucDoPhanAnh"].ToString() == "0" || drPhanAnh["MucDoPhanAnh"].ToString() == "1")
            {
                objThongTinPA.MucDoPhanAnh = drPhanAnh["MucDoPhanAnh"].ToString() == "0" ? "bình thường" : "nghiêm trọng";
            }
            else
            {
                objThongTinPA.MucDoPhanAnh = string.Empty;
            }
            
            objThongTinPA.NhanVienTiepNhan = drPhanAnh["NhanVienTiepNhan"].ToString();
            objThongTinPA.KetQua = drPhanAnh["GiaiQuyet_KetQua"].ToString();
            objThongTinPA.NgayGiaiQuyet = drPhanAnh["GiaiQuyet_Ngay"].ToString() == string.Empty  ? new DateTime(1900,01,01,0,0,0)  : (DateTime)drPhanAnh["GiaiQuyet_Ngay"];
            if (drPhanAnh["GiaiQuyet_MucHaiLongKH"].ToString() == string.Empty || (drPhanAnh["GiaiQuyet_MucHaiLongKH"].ToString()!= "0"
                && drPhanAnh["GiaiQuyet_MucHaiLongKH"].ToString()!="1"))
            {
                objThongTinPA.MucHaiLong = string.Empty;
            }
            else
            {
                objThongTinPA.MucHaiLong = drPhanAnh["GiaiQuyet_MucHaiLongKH"].ToString() == "0" ? "hài lòng" : "không hài lòng";
            }
           
            objThongTinPA.YKien = drPhanAnh["GiaQuyet_YKienKH"].ToString();
            objThongTinPA.NguoiGiaiQuyet = drPhanAnh["GiaiQuyet_NguoiGiaiQuyet"].ToString();
            objThongTinPA.TrangThaiGiaiQuyet = drPhanAnh["GiaiQuyet_DaXyLyXong"].ToString() == "1";
           // objThongTinPA.FKTaxiOperationID = drPhanAnh["FK_TaxiOperationID "] == null ? 0 : long.Parse(drPhanAnh["FK_TaxiOperationID "].ToString());

            objThongTinPA.CongTyID = Convert.ToInt32(drPhanAnh["FK_CongTyID"]);
            if (Convert.ToInt32(drPhanAnh["FK_CongTyID"]) == 0 && drPhanAnh["TenLoaiPhanAnh"].ToString() == string.Empty)
            {
                objThongTinPA.TenCongTy = string.Empty;
            }
            else if (Convert.ToInt32(drPhanAnh["FK_CongTyID"]) == 0 && drPhanAnh["TenLoaiPhanAnh"].ToString() != string.Empty)
            {
                objThongTinPA.TenCongTy = "TXG";
            }
            else if (Convert.ToInt32(drPhanAnh["FK_CongTyID"]) != 0)
            {
                objThongTinPA.TenCongTy = drPhanAnh["TenCongTy"].ToString();
            }            

            objThongTinPA.LoaiPhanhAnhID = int.Parse(drPhanAnh["FK_LoaiPhanAnh"].ToString());
            objThongTinPA.ChuyenDonVi = Convert.ToInt32(drPhanAnh["Chuyen_DonVi"]== DBNull.Value ? 1 : 0 )== 1  ;

            if (drPhanAnh["IsGoiLaiGoiKhac"] == DBNull.Value)
            {
                objThongTinPA.IsGoiLaiGoiKhac = false;
            }
            else
            {
                objThongTinPA.IsGoiLaiGoiKhac = drPhanAnh["IsGoiLaiGoiKhac"].ToString() != "0";
            }
            objThongTinPA.GhiChu = drPhanAnh["GhiChu"] == DBNull.Value ? string.Empty : drPhanAnh["GhiChu"].ToString();
            objThongTinPA.MaThongTin = drPhanAnh["MaThongTin"] == DBNull.Value ? string.Empty : drPhanAnh["MaThongTin"].ToString();
            objThongTinPA.KieuKhachHangGoiDen = drPhanAnh["KieuKhachHangGoiDen"] == DBNull.Value ? KieuKhachHangGoiDen.KhachHangKhongHieu : (KieuKhachHangGoiDen)Convert.ToInt32(drPhanAnh["KieuKhachHangGoiDen"]);

            return objThongTinPA;
        }

        public List<int> GetDonViXuLy(int idPhanAnh)
        {
            List<int> lstCongTyID = new List<int>();
            DataTable dt = new Data.ThongTinPhanAnh.ThongTinPhanAnh().GetCongTyByPhanAnhID(idPhanAnh);
            foreach (DataRow row in dt.Rows)
            {
                lstCongTyID.Add(Convert.ToInt32(row["ID_CongTy"]));
            }
            return lstCongTyID;
            
        }

        /// <summary>
        /// lấy ra anh mục công ty có dòng chọn công ty
        /// </summary>
        ///  <modified>
        /// name        date        comments
        /// hangtm      19/5/2011   created
        /// </modified>
        public DataTable GetDMCongTy()
        {
            return new Data.ThongTinPhanAnh.ThongTinPhanAnh().GetDMCongTy();
        }
        /// <summary>
        /// lấy ra danh mục công ty ko có dòng chọn công ty
        /// </summary>
        /// <returns></returns>
        ///  <modified>
        /// name        date        comments
        /// hangtm      19/7/2011   created
        /// </modified>
        public DataTable GetAllCongTy()
        {
            return new Data.ThongTinPhanAnh.ThongTinPhanAnh().GetAllCongTy();
        }


        /// <summary>
        /// lay ra toan bo bang Loai phan anh
        /// </summary>
        /// <returns></returns>
        ///  <modified>
        /// name        date        comments
        /// hangtm      19/5/2011   created
        /// </modified>
        public DataTable GetLoaiPhanAnh()
        {
            return new Data.ThongTinPhanAnh.ThongTinPhanAnh().GetLoaiPhanAnh();
        }

        /// <summary>
        /// Join 3 bang T_DMCongty, T_KHACHHANGPHANANH_LOAIPHANANH, T_KHACHHANGPHANANH
        /// theo dieu kien nhung cuoc goi chua giai quyet
        /// </summary>
        /// <returns></returns>
        /// <modified>
        /// name        date        comments
        /// hangtm      19/5/2011   created
        /// </modified>
        public List<ThongTinPhanAnh> JoinThongTinPhanAnh(bool trangThai)
        {
            List<ThongTinPhanAnh> lstThongTinPhanAnh = new List<ThongTinPhanAnh>();
            try {
                DataTable dt = new DataTable();
                dt = new Data.ThongTinPhanAnh.ThongTinPhanAnh().GetThongTinPhanAnh(trangThai);
                if (dt != null)
                {
                    if (dt.Rows.Count <= 0) return null;
                    else
                    { 
                        foreach(DataRow row in dt.Rows )
                        {
                            lstThongTinPhanAnh.Add(GetThongTinPhanAnh(row));
                        }
                    }

                }
                return lstThongTinPhanAnh;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// lấy thông tin cuộc gọi phản ánh gọi lại gọi khác.
        /// </summary>
        /// <param name="tuNgay"></param>
        /// <param name="denNgay"></param>
        /// <returns></returns>
        public List<ThongTinPhanAnh> GetThongTinPhanAnhGoiLaiGoiKhac(DateTime tuNgay, DateTime denNgay)
        {
            List<ThongTinPhanAnh> lstThongTinPhanAnh = new List<ThongTinPhanAnh>();
            try
            {
                DataTable dt = new DataTable();
                dt = new Data.ThongTinPhanAnh.ThongTinPhanAnh().GetThongTinPhanAnhGoiLaiGoiKhac(tuNgay,denNgay);
                if (dt != null)
                {
                    if (dt.Rows.Count <= 0) return null;
                    else
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            lstThongTinPhanAnh.Add(GetThongTinPhanAnh(row));
                        }
                    }

                }
                return lstThongTinPhanAnh;
            }
            catch 
            {
                return null;
            }
        }

        /// <summary>
        /// lay ra toan bo bang TK_KHACHHANGPHANANH voi dieu kien cuoc goi da giai quyet xong
        /// </summary>
        /// <returns></returns>
        /// <modified>
        /// name        date        comments
        /// hangtm      19/5/2011   created
        /// </modified>
        public DataTable GetPA_DaGiaiQuyet()
        {
            return new Data.ThongTinPhanAnh.ThongTinPhanAnh().GetAllKhachHangPA();
        }

        /// <summary>
        /// lay ra bang T_KHACHHANGPHANANH theo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <modified>
        /// name        date        comments
        /// hangtm      19/5/2011   created
        /// </modified>
        public DataTable GetPhanAnh_ByID( long id)
        {
            return new Data.ThongTinPhanAnh.ThongTinPhanAnh().GetAllByID(id);
        }

        /// <summary>
        /// Lấy ra danh sách cuộc gọi phản ánh chuyển đơn vị
        /// </summary>
        public List<ThongTinPhanAnh> GetPhanAnhChuyenDonVi()
        {
            List<ThongTinPhanAnh> lstPAChuyenDV = new List<ThongTinPhanAnh>();
            DataTable dt = new Data.ThongTinPhanAnh.ThongTinPhanAnh().GetPhanAnhChuyenDonVi();
            if(dt!= null)
            {
                if (dt.Rows.Count <= 0) return null;
                else 
                {
                    foreach(DataRow row in dt.Rows)
                    {
                        lstPAChuyenDV.Add(GetThongTinPhanAnh(row));
                    }
                }
            }
            return lstPAChuyenDV;
        }
        #endregion

        #region Thao tac du lieu
        /// <summary>
        /// chen 1 cuoc goi
        /// </summary>
        /// <modified>
        /// name        date        comments
        /// hangtm      19/5/2011   created
        /// </modified>        
        public int InsertCuocGoi(int loaiPhanAnh,int mucDo, int congTyID, long FK_TaxiOperationID)
        {
            return new Data.ThongTinPhanAnh.ThongTinPhanAnh().InsertCuocGoi(this.DienThoai, this.TenKhachHang,this.NoiDung,loaiPhanAnh,mucDo,
                congTyID,this.NhanVienTiepNhan, FK_TaxiOperationID  );
        }

        /// <summary>
        /// update 1 cuoc goi voi chi tiet noi dung phan anh
        /// </summary>
        /// <modified>
        /// name        date        comments
        /// hangtm      19/5/2011   created
        /// </modified>
        public int UpdateCuocGoi(int pLoaiPhanAnh,int mucDoPhanAnh ,int congTyID, bool isChuyen,bool isGoiLaiGoiKhac, string pMaThongTin)
        {
            return new Data.ThongTinPhanAnh.ThongTinPhanAnh().UpdateCuocGoi(this.ID, this.TenKhachHang, this.NoiDung, pLoaiPhanAnh, mucDoPhanAnh,
                congTyID, this.NhanVienTiepNhan, isChuyen, isGoiLaiGoiKhac, pMaThongTin);
        }

        /// <summary>
        /// update thong tin giai quyet phan anh cua khach hang
        /// </summary>   
        /// <modified>
        /// name        date        comments
        /// hangtm      19/5/2011   created
        /// </modified>
        public int UpdateGiaiQuyet(int mucHaiLong, bool isChuyen)
        {
            return new Data.ThongTinPhanAnh.ThongTinPhanAnh().UpdateGiaiQuyet(this.ID, this.KetQua, this.NgayGiaiQuyet, mucHaiLong,
                this.YKien, this.NguoiGiaiQuyet, this.TrangThaiGiaiQuyet,isChuyen );
        }

        /// <summary>
        /// update tất cả thông tin trong bảng KHACHHANGPHANANH
        /// </summary>
        ///  <modified>
        /// name        date        comments
        /// hangtm      19/5/2011   created
        /// </modified>
        public int UpdateAll(int mucDoPA, int mucHaiLong, int loaiPhanAnh, int congTyID)
        {
            return new Data.ThongTinPhanAnh.ThongTinPhanAnh().UpdateAll(this.ID, this.TenKhachHang, this.NoiDung, loaiPhanAnh, mucDoPA,
               congTyID, this.NhanVienTiepNhan, this.KetQua, DateTime.Parse(this.NgayGiaiQuyet.ToString()), mucHaiLong, this.YKien, this.NguoiGiaiQuyet, this.TrangThaiGiaiQuyet);
        }

        /// <summary>
        /// insert vào bảng phản ánh công ty
        /// </summary>
        /// <modified>
        /// name        date        comments
        /// hangtm      20/7/2011   created
        /// </modified>
        public bool InsertPhanAnh_CongTy(int phanAnhID, List<int> congTyID)
        {
            return new Data.ThongTinPhanAnh.ThongTinPhanAnh().InsertPhanAnh_CongTy(phanAnhID, congTyID);
        }
        
        #endregion

        #region Báo Cáo
        /// <summary>
        /// Báo cáo giải quyết thông tin khách hàng phản ánh
        /// </summary>
        ///  <modified>
        /// name        date        comments
        /// hangtm      21/5/2011   created
        /// </modified>
        public List<ThongTinPhanAnh> JoinByDate(DateTime startDate, DateTime endDate)
        {
            List<ThongTinPhanAnh> lstThongTinPhanAnh = new List<ThongTinPhanAnh>();
            try
            {
                DataTable dt = new DataTable();
                dt = new Data.ThongTinPhanAnh.ThongTinPhanAnh().JoinByDate(startDate, endDate);
                if (dt != null)
                {
                    if (dt.Rows.Count <= 0) return null;
                    else
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            lstThongTinPhanAnh.Add(GetThongTinPhanAnh(row));
                        }
                    }

                }
                return lstThongTinPhanAnh;
            }
            catch 
            {
                return null;
            }
        }
        /// <summary>
        /// báo cáo tổng hợp thông tin khách hàng phản ánh
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        ///  <modified>
        /// name        date        comments
        /// hangtm      23/5/2011   created
        /// </modified>
        public DataTable GetReport(DateTime startDate, DateTime endDate)
        {
            return new Data.ThongTinPhanAnh.ThongTinPhanAnh().GetReport(startDate, endDate);
        }
        #endregion

        #region Search thông tin phản ánh
        /// <summary>
        /// tìm kiếm thông tin phản ánh
        /// </summary>
        /// <param name="soDienThoai"></param> tìm theo số điện thoại (bắt buộc)
        /// <param name="noiDung"></param> tìm theo nội dung phản ánh (tùy chọn)
        /// <param name="tuNgay"></param> tìm theo ngày (bắt buộc)
        /// <param name="denNgay"></param>-----------------------
        /// <param name="trangThai"></param> tìm theo trạng thái đã giải quyết xong chưa (phụ thuộc vào người dùng đang đứng ở tab nào)
        /// <param name="chuyenDV"></param> tìm theo trạng thái có chuyển đơn vị ko (phụ thuộc vào người dùng đang đứng ở tab nào)
        /// <returns></returns>
        /// <modified>
        /// name            date        comments
        /// hangtm         19/7/2011    created
        ///</modified>
        public List<ThongTinPhanAnh> SearchPhanAnh(string soDienThoai, string noiDung, DateTime tuNgay, DateTime denNgay, bool trangThai, bool chuyenDV)
        {
            List<ThongTinPhanAnh> lstPhanAnh = new List<ThongTinPhanAnh>();
            DataTable dt =  new Data.ThongTinPhanAnh.ThongTinPhanAnh().SearchPhanAnh(soDienThoai, noiDung, tuNgay, denNgay, trangThai, chuyenDV);
            if(dt != null)
            {
                if (dt.Rows.Count <= 0) return null;
                else 
                {
                    foreach(DataRow row in dt.Rows)
                    {
                        lstPhanAnh.Add(GetThongTinPhanAnh(row));
                    }
                }
            }
            return lstPhanAnh;
        }
        #endregion

        #region Chuyển đàm
        public int InsertPhanAnhChuyenDam(string soDienThoai, string diaChi, int vung)
        {
            return new Data.ThongTinPhanAnh.ThongTinPhanAnh().InsertPhanAnhChuyenDam(soDienThoai, diaChi, vung);
        }
        #endregion

        /// <summary>
        /// Hàm trả về thông tin ghi chú của một  phản ảnh
        /// </summary>
        public static string GetGhiChu(long  ID)
        {
            string ghichu = string.Empty;
            DataTable dt =  new Data.ThongTinPhanAnh.ThongTinPhanAnh().GetAllByID (ID);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                ghichu = dr["GhiChu"] == DBNull.Value ? string.Empty : dr["GhiChu"].ToString();
            }
            return ghichu;
        }
        /// <summary>
        /// Cập nhật thông tin ghi chú phản ảnh.
        /// </summary>
        public static bool UpdateGhiChu(long   id, string ghiChu)
        {
            return new Data.ThongTinPhanAnh. ThongTinPhanAnh().UpdateGhiChu(id, ghiChu);
        }


        /// <summary>
        /// Hàm trả về thông tin phản ánh theo giá trị lọc
        /// </summary>
        public   List<ThongTinPhanAnh> GetThongTinKhachHangPhanAnh(DateTime tuNgay, DateTime denNgay, string dienThoai, string tenKhachHang, string pMaThongTin, int loaiPhanAnhID, int congTyID)
        {
            List<ThongTinPhanAnh> lstPhanAnh = new List<ThongTinPhanAnh>();

            DataTable dt = new Data.ThongTinPhanAnh.ThongTinPhanAnh().GetThongTinKhachHangPhanAnh ( tuNgay,  denNgay,  dienThoai,  tenKhachHang,  pMaThongTin,  loaiPhanAnhID,  congTyID); 
            if (dt != null)
            {
                if (dt.Rows.Count <= 0) return null;
                else
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        lstPhanAnh.Add(GetThongTinPhanAnh(row));
                    }
                }
            }
            return lstPhanAnh;

        }

        /// <summary>
        /// Cập nhật thông tin giải quyết
        /// </summary>
        public static bool  UpdateKetQuaGiaiQuyet(string maThongTin, string ketQuaGiaiQuyet)
        {
            return new Data.ThongTinPhanAnh.ThongTinPhanAnh().UpdateKetQuaGiaiQuyet(maThongTin, ketQuaGiaiQuyet);
        }
    }
}
