using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Taxi.Business.PhanAnh
{
    public class PhanAnh
    {
        #region Properties

        private long _IdPA;
        public long IdPA
        {
            get { return _IdPA; }
            set { _IdPA = value; }
        }

        private string _TenKH;
        public string TenKH
        {
            get { return _TenKH; }
            set { _TenKH = value; }
        }

        private string _SoDT;
        public string SoDT
        {
            get { return _SoDT; }
            set { _SoDT = value; }
        }

        private string _DiaChi;
        public string DiaChi
        {
            get { return _DiaChi; }
            set { _DiaChi = value; }
        }

        private DateTime _TGPA;
        public DateTime TGPA
        {
            get { return _TGPA; }
            set { _TGPA = value; }
        }

        private int _LoaiPA;
        public int LoaiPA
        {
            get { return _LoaiPA; }
            set { _LoaiPA = value; }
        }
        public string LoaiPA_Name { get; set; }

        private DateTime _TGPS;
        public DateTime TGPS
        {
            get { return _TGPS; }
            set { _TGPS = value; }
        }

        private string _NoiDung;
        public string NoiDung
        {
            get { return _NoiDung; }
            set { _NoiDung = value; }
        }

        private int _DacDiem;
        public int DacDiem
        {
            get { return _DacDiem; }
            set { _DacDiem = value; }
        }
        public string DacDiem_Name { get; set; }

        private int _DoiTuong;
        public int DoiTuong
        {
            get { return _DoiTuong; }
            set { _DoiTuong = value; }
        }
        public string DoiTuong_Name { get; set; }

        private string _LTTu;
        public string LTTu
        {
            get { return _LTTu; }
            set { _LTTu = value; }
        }

        private string _LTDen;
        public string LTDen
        {
            get { return _LTDen; }
            set { _LTDen = value; }
        }

        private string _DHT;
        public string DHT
        {
            get { return _DHT; }
            set { _DHT = value; }
        }

        private DateTime _GQ_TGGQ;
        public DateTime GQ_TGGQ
        {
            get { return _GQ_TGGQ; }
            set { _GQ_TGGQ = value; }
        }

        private bool _GQ_KHDongY;
        public bool GQ_KHDongY
        {
            get { return _GQ_KHDongY; }
            set { _GQ_KHDongY = value; }
        }

        private string _GQ_KQGQ;
        public string GQ_KQGQ
        {
            get { return _GQ_KQGQ; }
            set { _GQ_KQGQ = value; }
        }

        private string _GQ_YKKH;
        public string GQ_YKKH
        {
            get { return _GQ_YKKH; }
            set { _GQ_YKKH = value; }
        }

        private string _GQ_GhiChu;
        public string GQ_GhiChu
        {
            get { return _GQ_GhiChu; }
            set { _GQ_GhiChu = value; }
        }

        private string _GQ_SoTai;
        public string GQ_SoTai
        {
            get { return _GQ_SoTai; }
            set { _GQ_SoTai = value; }
        }

        private bool _GQ_HL;
        public bool GQ_HL
        {
            get { return _GQ_HL; }
            set { _GQ_HL = value; }
        }

        private DateTime _GQ_TGT;
        public DateTime GQ_TGT
        {
            get { return _GQ_TGT; }
            set { _GQ_TGT = value; }
        }

        private DateTime _NgayTao;
        public DateTime NgayTao
        {
            get { return _NgayTao; }
            set { _NgayTao = value; }
        }

        private string _NguoiTao;
        public string NguoiTao
        {
            get { return _NguoiTao; }
            set { _NguoiTao = value; }
        }

        private DateTime _NgaySua;
        public DateTime NgaySua
        {
            get { return _NgaySua; }
            set { _NgaySua = value; }
        }

        private string _NguoiSua;
        public string NguoiSua
        {
            get { return _NguoiSua; }
            set { _NguoiSua = value; }
        }

        private bool _TrangThai;
        public bool TrangThai
        {
            get { return _TrangThai; }
            set { _TrangThai = value; }
        }

        private long _IdCuocGoi;
        public long IdCuocGoi
        {
            get { return _IdCuocGoi; }
            set { _IdCuocGoi = value; }
        } 
        private bool _IsGQCAPCAO;
        /// <summary>
        /// Chuyển cho bộ phẩn xử lý phản ánh cấp cao
        /// </summary>
        public bool IsGQCAPCAO
        {
            get { return _IsGQCAPCAO; }
            set { _IsGQCAPCAO = value; }
        }
        #endregion

        /// <summary>
        /// lay ra du lieu trong 1 dong roi gan voi thuoc tinh cua
        /// lop PhanAnh
        /// </summary>
        /// <param name="drPhanAnh"></param>
        /// <returns></returns>
        public PhanAnh GetThongTinPhanAnh(DataRow drPhanAnh)
        {
            PhanAnh objPhanAnh = new PhanAnh();
            try
            {
                string strEmpty = "";
                objPhanAnh.SoDT = drPhanAnh["SoDT"].ToString();
                strEmpty = drPhanAnh["TGPA"].ToString();
                if (!string.IsNullOrEmpty(strEmpty))
                {
                    objPhanAnh.TGPA = Convert.ToDateTime(strEmpty);
                }
                strEmpty = drPhanAnh["TGPS"].ToString();
                if (!string.IsNullOrEmpty(strEmpty))
                {
                    objPhanAnh.TGPS = Convert.ToDateTime(strEmpty);
                }
                strEmpty = drPhanAnh["GQ_TGT"].ToString();
                if (!string.IsNullOrEmpty(strEmpty))
                {
                    objPhanAnh.GQ_TGT = Convert.ToDateTime(strEmpty);
                }
                strEmpty = drPhanAnh["GQ_TGGQ"].ToString();
                if (!string.IsNullOrEmpty(strEmpty))
                {
                    objPhanAnh.GQ_TGGQ = Convert.ToDateTime(strEmpty);
                }
                strEmpty = drPhanAnh["NgayTao"].ToString();
                if (!string.IsNullOrEmpty(strEmpty))
                {
                    objPhanAnh.NgayTao = Convert.ToDateTime(strEmpty);
                }
                strEmpty = drPhanAnh["NgaySua"].ToString();
                if (!string.IsNullOrEmpty(strEmpty))
                {
                    objPhanAnh.NgaySua = Convert.ToDateTime(strEmpty);
                }
                strEmpty = drPhanAnh["GQ_HL"].ToString();
                if (!string.IsNullOrEmpty(strEmpty))
                {
                    objPhanAnh.GQ_HL = Convert.ToBoolean(strEmpty);
                }
                strEmpty = drPhanAnh["GQ_KHDongY"].ToString();
                if (!string.IsNullOrEmpty(strEmpty))
                {
                    objPhanAnh.GQ_KHDongY = Convert.ToBoolean(strEmpty);
                }
                string LoaiPA = drPhanAnh["LoaiPA"].ToString();
                if (!string.IsNullOrEmpty(LoaiPA))
                {
                    objPhanAnh.LoaiPA = Convert.ToInt32(LoaiPA);
                }
                string DacDiemPA = drPhanAnh["DacDiem"].ToString();
                if (!string.IsNullOrEmpty(DacDiemPA))
                {
                    objPhanAnh.DacDiem = Convert.ToInt32(DacDiemPA);
                }

                string DoiTuongPA = drPhanAnh["DoiTuong"].ToString();
                if (!string.IsNullOrEmpty(DoiTuongPA))
                {
                    objPhanAnh.DoiTuong = Convert.ToInt32(DoiTuongPA);
                }

                objPhanAnh.LoaiPA_Name = drPhanAnh["LoaiPA_Name"].ToString();
                objPhanAnh.DacDiem_Name = drPhanAnh["DacDiem_Name"].ToString();
                objPhanAnh.DoiTuong_Name = drPhanAnh["DoiTuong_Name"].ToString();

                objPhanAnh.TenKH = drPhanAnh["TenKH"].ToString();
                objPhanAnh.NoiDung = drPhanAnh["NoiDung"].ToString();
                objPhanAnh.LTTu = drPhanAnh["LTTu"].ToString();
                objPhanAnh.LTDen = drPhanAnh["LTDen"].ToString();
                objPhanAnh.DHT = drPhanAnh["DHT"].ToString();
                objPhanAnh.GQ_YKKH = drPhanAnh["GQ_YKKH"].ToString();
                objPhanAnh.GQ_SoTai = drPhanAnh["GQ_SoTai"].ToString();
                objPhanAnh.GQ_KQGQ = drPhanAnh["GQ_KQGQ"].ToString();
                objPhanAnh.GQ_GhiChu = drPhanAnh["GQ_GhiChu"].ToString();
                objPhanAnh.DiaChi = drPhanAnh["DiaChi"].ToString();
                objPhanAnh.TrangThai = Convert.ToBoolean(drPhanAnh["TrangThai"].ToString());
                objPhanAnh.NguoiTao = drPhanAnh["NguoiTao"].ToString();
                objPhanAnh.NguoiSua = drPhanAnh["NguoiSua"].ToString();
                objPhanAnh.IdPA = Convert.ToInt64(drPhanAnh["Id"].ToString());
                objPhanAnh.IsGQCAPCAO = drPhanAnh["ISGQCapCao"] == DBNull.Value ? false : Convert.ToBoolean(drPhanAnh["ISGQCapCao"].ToString());
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetThongTinPhanAnh", ex);
            }
            return objPhanAnh;
        }

        /// <summary>
        /// Danh sach cac phan anh
        /// </summary>
        /// <param name="trangThai">true : Da giai quyet ; false : chua giai quyet</param>
        /// <returns></returns>
        public List<PhanAnh> GetPhanAnh_II(bool trangThai, bool isCapCao)
        {
            List<PhanAnh> lstThongTinPhanAnh = new List<PhanAnh>();
            try
            {
                DataTable dt = new DataTable();
                dt = new Taxi.Data.PhanAnh.PhanAnh().GetThongTinPhanAnhII(trangThai, isCapCao);
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
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Danh sach cac phan anh chua giai quyet
        /// </summary>
        /// <param name="trangThai">true : Da giai quyet ; false : chua giai quyet</param>
        /// <returns></returns>
        public List<PhanAnh> GetPhanAnh(bool trangThai)
        {
            List<PhanAnh> lstThongTinPhanAnh = new List<PhanAnh>();
            try
            {
                DataTable dt = new DataTable();
                dt = new Taxi.Data.PhanAnh.PhanAnh().GetThongTinPhanAnh(trangThai);
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
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Insert tat ca cuoc goi vao line phan anh, update cuoc goi thanh cuoc goi khieu nai cua khach hang(neu co cuoc goi moi)
        /// </summary>
        /// <param name="NguoiTao">User dang dang nhap</param>
        /// <param name="lineCapPhep">Line cua may tinh User dang ngoi</param>
        /// <returns>Danh sach cac cuoc goi khieu nai chua giai quyet</returns>
        public List<PhanAnh> GetPhanAnh_By_CuocGoi(string NguoiTao, string lineCapPhep)
        {
            List<PhanAnh> lstThongTinPhanAnh = new List<PhanAnh>();
            try
            {
                using (DataTable dt = new Taxi.Data.PhanAnh.PhanAnh().GetPhanAnh_By_CuocGoi(NguoiTao, lineCapPhep))
                {
                    if (dt != null)
                    {
                        if (dt.Rows.Count <= 0)
                            return null;
                        else
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                lstThongTinPhanAnh.Add(GetThongTinPhanAnh(row));
                            }
                        }
                    }
                    else
                        return null;
                }
                return lstThongTinPhanAnh;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Insert noi dung Phan Anh
        /// </summary>
        /// <returns></returns>
        public bool Insert()
        {
            return new Taxi.Data.PhanAnh.PhanAnh().InsertPhanAnh(TenKH, SoDT, DiaChi, TGPA, LoaiPA,
                                TGPS, NoiDung, DacDiem, DoiTuong, LTTu
                                , LTDen, DHT, GQ_TGGQ, GQ_KHDongY, GQ_KQGQ, GQ_YKKH
                                , GQ_GhiChu, GQ_SoTai, GQ_HL, GQ_TGT, NgayTao
                                , NguoiTao, TrangThai, IdCuocGoi);
        }

        /// <summary>
        /// Update noi dung Phan Anh
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            return new Taxi.Data.PhanAnh.PhanAnh().UpdatePhanAnh(TenKH, SoDT, DiaChi, TGPA, LoaiPA,
                                TGPS, NoiDung, DacDiem, DoiTuong, LTTu
                                , LTDen, DHT, GQ_TGGQ, GQ_KHDongY, GQ_KQGQ, GQ_YKKH
                                , GQ_GhiChu, GQ_SoTai, GQ_HL, GQ_TGT, NgayTao
                                , NguoiTao, TrangThai, IdPA, IsGQCAPCAO);
        }
        /// <summary>
        /// thực hiện xóa phần ánh
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(long id)
        {
            return new Taxi.Data.PhanAnh.PhanAnh().Delete(id);

        }

        /// <summary>
        /// Cập nhật phản ánh thành kết thúc
        /// </summary>
        /// <param name="NguoiSua"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool UpdatePhanAnh_Status(string NguoiSua, long ID)
        {
            return new Taxi.Data.PhanAnh.PhanAnh().UpdatePhanAnh_Status(NguoiSua, ID);
        }

        /// <summary>
        /// báo cáo tổng hợp thông tin khách hàng phản ánh
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <returns></returns>
        public DataTable GetBaoCaoTongHop(DateTime TuNgay, DateTime DenNgay)
        {
            return new Taxi.Data.PhanAnh.PhanAnh().GetBaoCaoTongHop(TuNgay, DenNgay);
        }

        /// <summary>
        /// báo cáo giai quyet thông tin khách hàng phản ánh
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <returns></returns>
        public DataTable GetBaoCaoGiaiQuyet(DateTime TuNgay, DateTime DenNgay, string SoDT, string TenKH, string DiaChi, int TrangThai)
        {
            return new Taxi.Data.PhanAnh.PhanAnh().GetBaoCaoGiaiQuyet(TuNgay, DenNgay, SoDT, TenKH, DiaChi, TrangThai);
        }

    }
}
