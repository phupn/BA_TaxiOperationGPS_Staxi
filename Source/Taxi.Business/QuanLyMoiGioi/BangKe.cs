using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Taxi.Utils;

namespace Taxi.Business
{
    public class BangKe
    {
        #region Members

        private int mID;
        public int ID
        {
            get { return mID; }
            set { mID = value; }
        }

        private int mFK_CongTyID;
        public int FK_CongTyID
        {
            get { return mFK_CongTyID; }
            set { mFK_CongTyID = value; }
        }

        private string mFK_MaDoiTac;
        public string FK_MaDoiTac
        {
            get { return mFK_MaDoiTac; }
            set { mFK_MaDoiTac = value; }
        }

        private string mDSXeDon;
        public string DSXeDon
        {
            get { return mDSXeDon; }
            set { mDSXeDon = value; }
        }

        private string mTenCongTy;
        public string TenCongTy
        {
            get { return mTenCongTy; }
            set { mTenCongTy = value; }
        }

        private string mTenDoiTac;
        public string TenDoiTac
        {
            get { return mTenDoiTac; }
            set { mTenDoiTac = value; }
        }
       
        private DateTime mNgayDon;
        public DateTime NgayDon
        {
            get { return mNgayDon; }
            set { mNgayDon = value; }
        }

        private string mCreatedBy;
        public string CreatedBy
        {
            get { return mCreatedBy; }
            set { mCreatedBy = value; }
        }

        private DateTime mCreatedDate;
        public DateTime CreatedDate
        {
            get { return mCreatedDate; }
            set { mCreatedDate = value; }
        }

        private string mUpdatedBy;
        public string UpdatedBy
        {
            get { return mUpdatedBy; }
            set { mUpdatedBy = value; }
        }

        private DateTime mUpdatedDate;
        public DateTime UpdatedDate
        {
            get { return mUpdatedDate; }
            set { mUpdatedDate = value; }
        }

        private double mTiLePhanBo;
        public double TiLePhanBo
        {
            get { return TiLePhanBo; }
            set { TiLePhanBo = value; }
        }

        private double mKinhDo;
        public double KinhDo
        {
            get { return mKinhDo; }
            set { mKinhDo = value; }
        }

        private double mViDo;
        public double ViDo
        {
            get { return mViDo; }
            set { mViDo = value; }
        }

        private string mDiaChi;
        public string DiaChi
        {
            get { return mDiaChi; }
            set { mDiaChi = value; }
        }

        private string mDienThoai;
        public string DienThoai
        {
            get { return mDienThoai; }
            set { mDienThoai = value; }
        }

        private string mTenDuong;
        public string TenDuong
        {
            get { return mTenDuong; }
            set { mTenDuong = value; }
        }
        #endregion Members

        #region Methods

        public BangKe GetBangKeByID(int ID)
        {
            BangKe objBangKe = new BangKe();
            DataTable dt = new DataTable();

            dt = new Data.BangKe().GetBangKe(ID);
            if (dt.Rows.Count == 1)
            {
                objBangKe = getBangKeByRow(dt.Rows[0]);
            }
            return objBangKe;
        }

        public List<BangKe> GetListOfBangKes()
        {
            List<BangKe> lstBangKe = new List<BangKe>();
            DataTable dt = new DataTable();
            string shortDateNow = DateTime.Now.ToShortDateString();
            DateTime fromDate = Convert.ToDateTime(shortDateNow+" 00:00:00");
            DateTime toDate = Convert.ToDateTime(shortDateNow + " 23:59:59");

            dt = new Data.BangKe().GetDSBangKe("0", "", "0", "", fromDate, toDate);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    lstBangKe.Add(getBangKeByRow(dr));
                }
            }

            return lstBangKe;
        }

        public List<BangKe> GetListOfDoiTac()
        {
            List<BangKe> lstBangKe = new List<BangKe>();
            DataTable dt = new DataTable();

            dt = new Data.BangKe().GetDoiTac();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    lstBangKe.Add(getBangKeByRow2(dr));
                }
            }

            return lstBangKe;
        }

        public List<BangKe> GetListOfBangKes_BySearch(  string MaDoiTac, 
                                                        string TenDoiTac, 
                                                        string MaCongTy, 
                                                        string XeDon, 
                                                        DateTime NgayDonTu, 
                                                        DateTime NgayDonDen)
        {
            List<BangKe> lstBangKe = new List<BangKe>();
            DataTable dt = new DataTable();
            DateTime fromDate = Convert.ToDateTime(NgayDonTu.ToShortDateString() + " 00:00:00");
            DateTime toDate = Convert.ToDateTime(NgayDonDen.ToShortDateString() + " 23:59:59");

            dt = new Data.BangKe().GetDSBangKe(MaDoiTac, TenDoiTac, MaCongTy, XeDon, fromDate, toDate);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    lstBangKe.Add(getBangKeByRow(dr));
                }
            }

            return lstBangKe;
        }

        private BangKe getBangKeByRow(DataRow dr)
        {
            BangKe objBangKe = new BangKe();
            objBangKe.ID = int.Parse(dr["ID"].ToString());
            objBangKe.FK_CongTyID = int.Parse(dr["FK_CongTyID"].ToString());
            objBangKe.TenCongTy = dr["TenCongTy"].ToString();
            objBangKe.TenDoiTac = dr["TenDoiTac"].ToString();
            objBangKe.FK_MaDoiTac = StringTools.TrimSpace(dr["FK_MaDoiTac"].ToString());
            objBangKe.DSXeDon = StringTools.TrimSpace(dr["DSXeDon"].ToString());
            objBangKe.NgayDon = DateTime.Parse(dr["NgayDon"].ToString());
            objBangKe.CreatedBy = StringTools.TrimSpace(dr["CreatedBy"].ToString());
            string createdDate = dr["CreatedDate"].ToString();
            if (!createdDate.Equals(""))
            {
                objBangKe.CreatedDate = DateTime.Parse(createdDate);
            }
            
            objBangKe.UpdatedBy = StringTools.TrimSpace(dr["UpdatedBy"].ToString());
            string updateDate = dr["UpdatedDate"].ToString();
            if (!updateDate.Equals(""))
            {
                objBangKe.UpdatedDate = DateTime.Parse(updateDate);
            }
            return objBangKe;
        }

        private BangKe getBangKeByRow2(DataRow dr)
        {
            BangKe objBangKe = new BangKe();
            objBangKe.TenDoiTac = dr["Name"].ToString();
            objBangKe.DiaChi = dr["Address"].ToString();
            objBangKe.DienThoai = dr["Phones"].ToString();
            objBangKe.TenDuong = dr["TenDuong"].ToString();
            objBangKe.FK_MaDoiTac = StringTools.TrimSpace(dr["Ma_DoiTac"].ToString());
            objBangKe.KinhDo = float.Parse(dr["KinhDo"].ToString());
            objBangKe.ViDo = float.Parse(dr["ViDo"].ToString());
            return objBangKe;
        }

        public bool Insert()
        {
            return new Data.BangKe().Insert(this.FK_CongTyID, this.FK_MaDoiTac, this.DSXeDon, this.CreatedBy, this.NgayDon);
        }

        public bool Update()
        {
            return new Data.BangKe().Update(this.ID, this.FK_CongTyID, this.FK_MaDoiTac, this.DSXeDon, this.UpdatedBy, this.NgayDon);

        }

        public bool Delete(int ID)
        {
            return new Data.BangKe().Delete(ID);
        }
         /// <summary>
        /// Lấy danh sách cuốc khách mô giới theo bảng kê
        /// </summary>
        /// <param name="MaDoiTac"></param>
        /// <param name="MaCongTy"></param>
        /// <param name="NgayDonTu"></param>
        /// <param name="NgayDonDen"></param>
        /// <returns></returns>
        public DataTable BaoCaoCuocKhachMoGioi_BangKe(string MaDoiTac, string MaCongTy, DateTime NgayDonTu, DateTime NgayDonDen)
        {
            return new Data.BangKe().BaoCaoCuocKhachMoGioi_BangKe(MaDoiTac, MaCongTy, NgayDonTu, NgayDonDen);
        }

        /// <summary>
        /// Bao cao tong hop moi gioi goi qua trung tam
        /// </summary>
        /// <param name="NgayDonTu"></param>
        /// <param name="NgayDonDen"></param>
        /// <returns></returns>
        public DataTable BCTHMoiGioi_TT(DateTime NgayDonTu, DateTime NgayDonDen)
        {
            return new Data.BangKe().BCTHMoiGioi_TT(NgayDonTu, NgayDonDen);
        }

        /// <summary>
        /// Bao cao chi tiet cuoc khach moi gioi theo dia chi
        /// </summary>
        /// <param name="MaDoiTac"></param>
        /// <param name="MaCongTy"></param>
        /// <param name="NgayDonTu"></param>
        /// <param name="NgayDonDen"></param>
        /// <returns></returns>
        public DataTable BaoCaoChiTietCuocKhachMoGioi_DiaChi(string MaDoiTac, string MaCongTy, DateTime NgayDonTu, DateTime NgayDonDen)
        {
            return new Data.BangKe().BaoCaoChiTietCuocKhachMoGioi_DiaChi(MaDoiTac, MaCongTy, NgayDonTu, NgayDonDen);
        }

        /// <summary>
        /// Báo cáo kết quả điều hành theo đơn vị
        /// </summary>
        /// <param name="TuNgayGio"></param>
        /// <param name="DenNgayGio"></param>
        /// <returns></returns>
        public DataTable GetBaoCao_KQDieuHanh_DV(DateTime TuNgayGio, DateTime DenNgayGio, bool filter)
        {
            return new Data.BangKe().GetBaoCao_KQDieuHanh_DV(TuNgayGio, DenNgayGio, filter);
        }

        //=========================================Tỷ lệ phân bổ =======================================
        public bool Insert_TyLePhanBo(DataTable dtTiLePhanBo)
        {
            return new Data.BangKe().Insert_TyLePhanBo(dtTiLePhanBo);
        }

        public bool Update_TyLePhanBo(DataTable dtTiLePhanBo)
        {
            return new Data.BangKe().Update_TyLePhanBo(dtTiLePhanBo);

        }

        public DataTable GetTiLePhanBo()
        {
            return new Data.BangKe().GetTiLePhanBo();
        }

        #endregion Methods
    }
}
