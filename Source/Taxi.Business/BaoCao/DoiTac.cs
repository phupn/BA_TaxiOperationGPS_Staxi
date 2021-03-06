using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Taxi.Business.BaoCao
{
    public class DoiTac
    {
        #region Member
        private string _maDoiTac;
        public string MaDoiTac
        {
            get { return _maDoiTac; }
            set { _maDoiTac = value;}
        }
        private string _diaChi;
        public string DiaChi
        {
            get{return _diaChi ;}
            set{_diaChi = value;}
        }
        private string _dienThoai;
        public string DienThoai
        {
            get{return _dienThoai ;}
            set{_dienThoai = value;}
        }
        private string _soNha;
        public string SoNha
        {
            get{return _soNha ;}
            set{_soNha = value;}
        }
        private string _tenDuong;
        public string TenDuong
        {
            get{return _tenDuong  ;}
            set{_tenDuong  = value;}
        }
        private float _tiLeNoiTinh;
        public float TiLeNoiTinh
        {
            get{return _tiLeNoiTinh ;}
            set{_tiLeNoiTinh= value;}
        }
        private DateTime _ngayKyKet;
        public DateTime NgayKyKet
        {
            get{return _ngayKyKet ;}
            set{_ngayKyKet = value;}
        }
		private DateTime _ngayKetThuc;
        public DateTime NgayKetThuc
        {
            get{return _ngayKetThuc ;}
            set{_ngayKetThuc = value;}
        }
		private string _tenCongTy;
		public string TenCongTy
        {
            get{return _tenCongTy  ;}
            set { _tenCongTy = value; }
        }
        private string _tenNhanVien;
		public string TenNhanVien
        {
            get { return _tenNhanVien; }
            set { _tenNhanVien = value; }
        }
		private string _idCapNhat;
        public string IDCapNhat
        {
            get{return _idCapNhat ;}
            set{_idCapNhat = value;}
        }
		
        #endregion

        #region GetDoiTac
        public DoiTac GetThongTinDoiTac(DataRow drDoiTac)
        {
            DoiTac objDoiTac = new DoiTac();
            objDoiTac.MaDoiTac = drDoiTac["Ma_DoiTac"].ToString()==string.Empty ? string.Empty :drDoiTac["Ma_DoiTac"].ToString() ;
            objDoiTac.DiaChi = drDoiTac["Address"].ToString() == string.Empty ? string.Empty : drDoiTac["Address"].ToString();
            objDoiTac.SoNha = drDoiTac["SoNha"].ToString() == string.Empty ? string.Empty : drDoiTac["SoNha"].ToString();
            objDoiTac.TenDuong = drDoiTac["TenDuong"].ToString() == string.Empty? string.Empty : drDoiTac["TenDuong"].ToString();
            objDoiTac.DienThoai = drDoiTac["Phones"].ToString()== string.Empty ? string.Empty :drDoiTac["Phones"].ToString();
            objDoiTac.TiLeNoiTinh = drDoiTac["TiLeHoaHongNoiTinh"].ToString()== string.Empty ? 0: float.Parse(drDoiTac["TiLeHoaHongNoiTinh"].ToString());
            objDoiTac.NgayKyKet = drDoiTac["NgayKyKet"].ToString() == string.Empty ? DateTime.MinValue : (DateTime)drDoiTac["NgayKyKet"];
            objDoiTac.NgayKetThuc = drDoiTac["NgayKetThuc"].ToString() == string.Empty ? DateTime.MinValue : (DateTime)drDoiTac["NgayKetThuc"];
            objDoiTac.TenCongTy = drDoiTac["TenCongTy"].ToString() == string.Empty ? string.Empty : drDoiTac["TenCongTy"].ToString();
            objDoiTac.TenNhanVien = drDoiTac["TenNhanVien"].ToString() == string.Empty ? string.Empty : drDoiTac["TenNhanVien"].ToString();
            objDoiTac.IDCapNhat = drDoiTac["IDCapNhat"].ToString() == string.Empty ? string.Empty : drDoiTac["IDCapNhat"].ToString();
            return objDoiTac;
        }
        #endregion
    
        public DataTable GetBaoCaoMoiGioi_KoPhatSinh(DateTime ngayBD, DateTime ngayKT)
        {
            return new Data.BaoCao.DoiTac().GetBaoCaoMoiGioi_KoPhatSinh(ngayBD, ngayKT);
        }

        /// <summary>
        /// báo cáo danh sách địa chỉ môi giới
        /// </summary>
        ///  <modified>
        /// name        date        comments
        /// hangtm      26/5/2011   created
        /// </modified>
        public List<DoiTac> GetBaoCaoDiaChiMoiGioi(string maMoiGioi, string dienThoai, int congTy, DateTime ngayBDTu,
                    DateTime ngayBDDen, DateTime ngayKTTu, DateTime ngayKTDen, string tenDuong, string diaChi)
        {
            List<DoiTac> lstDoiTac = new List<DoiTac>();
            try
            {
                DataTable dt = new DataTable();
                dt = new Taxi.Data.BaoCao.DoiTac().GetBaoCaoDiaChiMoiGioi(maMoiGioi, dienThoai, congTy,
                ngayBDTu, ngayBDDen, ngayKTTu, ngayKTDen,tenDuong,diaChi );
                if (dt != null)
                {
                    if (dt.Rows.Count <= 0) return null;
                    else
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            lstDoiTac.Add(GetThongTinDoiTac(row));
                        }
                    }

                }
                return lstDoiTac ;
            }
            catch (Exception ex)
            {
                return null;
            }
           
        }
        /// <summary>
        /// lay ra thong tin doi tac 
        /// </summary>
        /// <returns></returns>
        /// <modified>
        /// name        date        comments
        /// hangtm      26/5/2011   created
        /// </modified>
        public DataTable GetAllDoiTacID()
        {
            return new Taxi.Data.BaoCao.DoiTac ().GetAllDoiTacID();
        }
        /// <summary>
        ///lay ra thong tin cong ty
        /// </summary>
        /// <returns></returns>
        /// <modified>
        /// name        date        comments
        /// hangtm      26/5/2011   created
        /// </modified>
        public DataTable GetTenCongTy()
        {
            return new Taxi.Data.BaoCao.DoiTac().GetCongTyName();
        }
        /// <summary>
        /// báo cáo địa chỉ môi giới cuộc gọi thấp
        /// </summary>
        /// <returns></returns>
        /// <modified>
        /// name        date        comments
        /// hangtm      28/5/2011   created
        /// </modified>
        public DataTable GetBaoCaoMoiGioi_CuocGoiThap(string maMoiGioi, int congTy, int SoLuongDonDuoc, 
                    DateTime ngayBD, DateTime ngayKT)
        {
            return new Taxi.Data.BaoCao.DoiTac().GetBaoCaoMoiGioi_CuocGoiThap(maMoiGioi, congTy, SoLuongDonDuoc, ngayBD, ngayKT);
        }

        public DataSet GetBaoCaoMoiGioi_PhatSinhTheoXe(string maMoiGioi, string soxe, DateTime ngayBD, DateTime ngayKT, int Type)
        {
            return new Taxi.Data.BaoCao.DoiTac().GetBaoCaoMoiGioi_PhatSinhTheoXe(maMoiGioi, soxe, ngayBD, ngayKT, Type);
        }

    }
}
