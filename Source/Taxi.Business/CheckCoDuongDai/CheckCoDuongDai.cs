using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Taxi.Business.CheckCoDuongDai
{
    public class CheckCoDuongDai
    {
        #region Properties
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _soHieuXe;
        public string SoHieuXe
        {
            get { return _soHieuXe; }
            set { _soHieuXe = value; }
        }
        private string _noiDi;
        public string NoiDi
        {
            get { return _noiDi; }
            set { _noiDi = value; }
        }
        private string _noiDen;
        public string NoiDen
        {
            get { return _noiDen; }
            set { _noiDen = value; }
        }
        private int _tinhThanhDenID;
        public int TinhThanhDenID
        {
            get { return _tinhThanhDenID; }
            set { _tinhThanhDenID = value; }
        }
        private int _coDau;
        public int CoDau
        {
            get { return _coDau; }
            set { _coDau = value; }
        }
        private int _coCuoi;
        public int CoCuoi
        {
            get { return _coCuoi; }
            set { _coCuoi = value; }
        }
        private DateTime _thoiDiemDi;
        public DateTime ThoiDiemDi
        {
            get { return _thoiDiemDi; }
            set { _thoiDiemDi = value; }
        }
        private DateTime _thoiDiemVe;
        public DateTime ThoiDiemVe
        {
            get { return _thoiDiemVe; }
            set { _thoiDiemVe = value; }
        }
        private string _chieuDi;
        public string  ChieuDi
        {
            get { return _chieuDi; }
            set { _chieuDi = value; }
        }
        private float _tongTien;
        public float TongTien
        {
            get { return _tongTien; }
            set { _tongTien = value; }
        }
        private string _ghiChu;
        public string GhiChu
        {
            get { return _ghiChu; }
            set { _ghiChu = value; }
        }
        private DateTime _ngayTao;
        public DateTime NgayTao
        {
            get { return _ngayTao; }
            set { _ngayTao = value; }
        }
        private string _nguoiTao;
        public string NguoiTao
        {
            get { return _nguoiTao; }
            set { _nguoiTao = value; }
        }
        private DateTime _ngaySua;
        public DateTime NgaySua
        {
            get { return _ngaySua; }
            set { _ngaySua = value; }
        }
        private string _nguoiSua;
        public string NguoiSua
        {
            get { return _nguoiSua; }
            set { _nguoiSua = value; }
        }
        private string _gara;
        public string Gara
        {
            get { return _gara; }
            set { _gara = value; }
        }

        private int _tinhThanhDiID;
        public int FK_TinhThanhDiID
        {
            get { return _tinhThanhDiID; }
            set { _tinhThanhDiID = value; }
        }

        private string _tinhThanhDi;
        public string TinhThanhDi
        {
            get { return _tinhThanhDi; }
            set { _tinhThanhDi = value; }
        }

        private string _tinhThanhDen;
        public string TinhThanhDen
        {
            get { return _tinhThanhDen; }
            set { _tinhThanhDen = value; }
        }

        private int _quanHuyenDiID;
        public int FK_QuanHuyenDiID
        {
            get { return _quanHuyenDiID; }
            set { _quanHuyenDiID = value; }
        }

        private int _quanHuyenDenID;
        public int FK_QuanHuyenDenID
        {
            get { return _quanHuyenDenID; }
            set { _quanHuyenDenID = value; }
        }

        private int _phuongXaDenID;
        public int FK_PhuongXaDenID
        {
            get { return _phuongXaDenID; }
            set { _phuongXaDenID = value; }
        }

        private int _phuongXaDiID;
        public int FK_PhuongXaDiID
        {
            get { return _phuongXaDiID; }
            set { _phuongXaDiID = value; }
        }

        private bool _isChiaSeChuyenDi;
        public bool isChiaSeChuyenDi
        {
            get { return _isChiaSeChuyenDi; }
            set { _isChiaSeChuyenDi = value; }
        }

        private string _SoDienThoai;
        public string SoDienThoai
        {
            get { return _SoDienThoai; }
            set { _SoDienThoai = value; }
        }

        private string _TenLaiXe;
        public string TenLaiXe
        {
            get { return _TenLaiXe; }
            set { _TenLaiXe = value; }
        }

        private bool _isTrangThaiDuyet;
        public bool TrangThaiDuyet
        {
            get { return _isTrangThaiDuyet; }
            set { _isTrangThaiDuyet = value; }
        }

        private DateTime _thoiDiemDuyet;
        public DateTime ThoiDiemDuyet
        {
            get { return _thoiDiemDuyet; }
            set { _thoiDiemDuyet = value; }
        }

        private string _nguoiDuyet;
        public string NguoiDuyet
        {
            get { return _nguoiDuyet; }
            set { _nguoiDuyet = value; }
        }
        #endregion

        public CheckCoDuongDai GetDSCheckCoDuongDai(DataRow drCheckCo)
        {
            CheckCoDuongDai objCheckCo = new CheckCoDuongDai();
            objCheckCo.ID = Convert.ToInt32(drCheckCo["ID"]);
            objCheckCo.SoHieuXe = drCheckCo["FK_SoHieuXe"].ToString();
            objCheckCo.NoiDi = drCheckCo["DiaDiemDi"].ToString();
            objCheckCo.NoiDen = drCheckCo["DiaDiemDen"].ToString();
            if (!drCheckCo["FK_TinhThanhDenID"].ToString().Equals(""))
                objCheckCo.TinhThanhDenID = (int)(drCheckCo["FK_TinhThanhDenID"]);
            objCheckCo.CoDau = Convert.ToInt32(drCheckCo["CoDau"]);
            objCheckCo.CoCuoi = Convert.ToInt32(drCheckCo["CoCuoi"]);
            objCheckCo.ThoiDiemDi = drCheckCo["ThoiDiemDi"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(drCheckCo["ThoiDiemDi"]);
            objCheckCo.ThoiDiemVe = drCheckCo["ThoiDiemVe"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(drCheckCo["ThoiDiemVe"]);
            objCheckCo.ChieuDi = drCheckCo["Is1Chieu"] == DBNull.Value  || Convert.ToBoolean(drCheckCo["Is1Chieu"]) == false  ? "Hai chiều" : "Một chiều";
            objCheckCo.TongTien = float.Parse(drCheckCo["TongTien"].ToString());
            objCheckCo.GhiChu = drCheckCo["GhiChu"].ToString();
            objCheckCo.NgayTao = Convert.ToDateTime(drCheckCo["CreatedDate"]);
            objCheckCo.NguoiTao = drCheckCo["CreatedByUser"].ToString();
            objCheckCo.NgaySua = drCheckCo["UpdatedDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(drCheckCo["UpdatedDate"]);
            objCheckCo.NguoiSua = drCheckCo["UpdatedByUser"].ToString();
            objCheckCo.Gara = drCheckCo["Gara"].ToString();
            objCheckCo.TenLaiXe = drCheckCo["TenLaiXe"].ToString();
            objCheckCo.SoDienThoai = drCheckCo["SoDienThoai"].ToString();
            objCheckCo.isChiaSeChuyenDi = drCheckCo["isChiaSeChuyenDi"] != DBNull.Value && Convert.ToBoolean(drCheckCo["isChiaSeChuyenDi"]);
            if (drCheckCo["TrangThaiDuyet"] != DBNull.Value)
            {
                objCheckCo.TrangThaiDuyet = Convert.ToBoolean(drCheckCo["TrangThaiDuyet"]);
                if (drCheckCo["ThoiDiemDuyet"] != DBNull.Value)
                    objCheckCo.ThoiDiemDuyet = Convert.ToDateTime(drCheckCo["ThoiDiemDuyet"]);
                objCheckCo.NguoiDuyet = drCheckCo["NguoiDuyet"].ToString();
            }

            //objCheckCo.TinhThanhDen = drCheckCo["TinhThanhDen"].ToString();
            //objCheckCo.TinhThanhDi = drCheckCo["TinhThanhDi"].ToString();

            if (!drCheckCo["FK_TinhThanhDiID"].ToString().Equals(""))
                objCheckCo.FK_TinhThanhDiID = (int)(drCheckCo["FK_TinhThanhDiID"]);
            if (!drCheckCo["FK_QuanHuyenDenID"].ToString().Equals(""))
                objCheckCo.FK_QuanHuyenDenID = (int)(drCheckCo["FK_QuanHuyenDenID"]);
            if (!drCheckCo["FK_QuanHuyenDiID"].ToString().Equals(""))
                objCheckCo.FK_QuanHuyenDiID = (int)(drCheckCo["FK_QuanHuyenDiID"]);
            if (!drCheckCo["FK_PhuongXaDenID"].ToString().Equals(""))
                objCheckCo.FK_PhuongXaDenID = (int)(drCheckCo["FK_PhuongXaDenID"]);
            if (!drCheckCo["FK_PhuongXaDiID"].ToString().Equals(""))
                objCheckCo.FK_PhuongXaDiID = (int)(drCheckCo["FK_PhuongXaDiID"]);

            return objCheckCo;
        }
    
        public DataTable GetDistrict()
        {
            return new Taxi.Data.CheckCoDuongDai.CheckCoDuongDai().GetDistrict().Tables[0];
        }

        public DataTable GetCommune()
        {
            return new Data.CheckCoDuongDai.CheckCoDuongDai().GetCommune().Tables[0];
        }

        /// <summary>
        /// Kiem tra so hieu xe co ton tai khong
        /// </summary>
        /// <modified>
        /// name        date        comment
        /// hangtm      4/7/2011   created
        /// </modified>
        public bool CheckSoHieuXe(string soHieuXe)
        {
            return new Data.CheckCoDuongDai.CheckCoDuongDai().CheckSoHieuXe(soHieuXe);
        }

        /// <summary>
        /// insert du lieu vao bang T_SANBAY_DUONGDAI
        /// </summary>
        /// <modified>
        /// name            date        comment
        /// hangtm          4/7/2011    created
        ///</modified>
        public int InsertCheckCo(string soHieuXe, string diaDiemDi, string diaDiemDen, int tinhThanhID, 
                                int coDau, int coCuoi,DateTime thoiDiemDi, DateTime thoiDiemVe, bool chieuDi, 
                                float tongTien, string ghiChu, string userName, int tinhThanhDiID, int quanHuyenDiID, 
                                int quanHuyenDenID, int phuongXaDiID, int phuongXaDenID, string tenLaiXe,string soDienThoai,bool isChiaSe)
        {
            return new Data.CheckCoDuongDai.CheckCoDuongDai().InsertCheckCo(soHieuXe, diaDiemDi, diaDiemDen, tinhThanhID, coDau,
                                    coCuoi, thoiDiemDi, thoiDiemVe, chieuDi, tongTien, ghiChu, userName
                                    , tinhThanhDiID, quanHuyenDiID, quanHuyenDenID, phuongXaDiID, phuongXaDenID, tenLaiXe, soDienThoai, isChiaSe);
        }

        public List<CheckCoDuongDai> GetDSCuocDuongDaiSanBay_TG()
        {
            List<CheckCoDuongDai> lstCheckCoDuongDai = new List<CheckCoDuongDai>();
            DataSet ds = new Taxi.Data.CheckCoDuongDai.CheckCoDuongDai().GetDSCuocDuongDaiSanBay_TG();
            DataTable dt = ds.Tables[0];
            try
            {
                if (dt != null)
                {
                    if (dt.Rows.Count <= 0) return null;
                    else
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            lstCheckCoDuongDai.Add(GetDSCheckCoDuongDai(row));
                        }
                    }
                }
                return lstCheckCoDuongDai;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Lấy ra danh sách cuốc khách đường dài sắp xếp theo thời gian và lọc cuốc chưa trả khách lên trước
        /// </summary>
        /// <modified>
        /// name        date        comment
        /// hangtm      6/7/2011    created
        ///</modified>
        public List<CheckCoDuongDai> GetDSCuocDuongDaiSanBay(string soHieuXe, int thoiGian)
        {
            List<CheckCoDuongDai> lstCheckCoDuongDai = new List<CheckCoDuongDai>();
            DataSet ds = new Taxi.Data.CheckCoDuongDai.CheckCoDuongDai().GetDSCuocDuongDaiSanBay(soHieuXe, thoiGian);
            DataTable dt = ds.Tables[0];
            try
            {
                if (dt != null)
                {
                    if (dt.Rows.Count <= 0) return null;
                    else
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            lstCheckCoDuongDai.Add(GetDSCheckCoDuongDai(row));
                        }
                    }

                }
                return lstCheckCoDuongDai;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<CheckCoDuongDai> GetDSCuocDuongDaiSanBay_Gara(string soHieuXe, int thoiGian, int gara)
        {
            List<CheckCoDuongDai> lstCheckCoDuongDai = new List<CheckCoDuongDai>();
            using (DataSet ds = new Taxi.Data.CheckCoDuongDai.CheckCoDuongDai().GetDSCuocDuongDaiSanBay_Gara(soHieuXe, thoiGian, gara))
            {
                DataTable dt = ds.Tables[0];
                try
                {
                    if (dt != null)
                    {
                        if (dt.Rows.Count <= 0)
                            return null;
                        else
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                lstCheckCoDuongDai.Add(GetDSCheckCoDuongDai(row));
                            }
                        }
                    }
                    return lstCheckCoDuongDai;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public List<CheckCoDuongDai> GetDSCuocDuongDaiSanBayMoi(DateTime TGLayDuLieuTruoc)
        {
            List<CheckCoDuongDai> lstCheckCoDuongDai = new List<CheckCoDuongDai>();
            using (DataSet ds = new Taxi.Data.CheckCoDuongDai.CheckCoDuongDai().GetDSCuocDuongDaiSanBayMoi(TGLayDuLieuTruoc))
            {
                DataTable dt = ds.Tables[0];
                try
                {
                    if (dt != null)
                    {
                        if (dt.Rows.Count <= 0)
                            return null;
                        else
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                lstCheckCoDuongDai.Add(GetDSCheckCoDuongDai(row));
                            }
                        }
                    }
                    return lstCheckCoDuongDai;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public List<CheckCoDuongDai> GetDSCuocDuongDaiSanBayMoiThayDoi(DateTime TGLayDuLieuTruoc)
        {
            List<CheckCoDuongDai> lstCheckCoDuongDai = new List<CheckCoDuongDai>();
            using (DataSet ds = new Taxi.Data.CheckCoDuongDai.CheckCoDuongDai().GetDSCuocDuongDaiSanBayMoiThayDoi(TGLayDuLieuTruoc))
            {
                DataTable dt = ds.Tables[0];
                try
                {
                    if (dt != null)
                    {
                        if (dt.Rows.Count <= 0)
                            return null;
                        else
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                lstCheckCoDuongDai.Add(GetDSCheckCoDuongDai(row));
                            }
                        }
                    }
                    return lstCheckCoDuongDai;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public List<long> LayCacIDCheckCoKetThuc(string listIDCheckCoHienTai)
        {
            List<long> listID = new List<long>();
            using (DataTable dt = new Data.CheckCoDuongDai.CheckCoDuongDai().GetDSIDCuocDuongDaiSanBayDelete(listIDCheckCoHienTai))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["ID"] != DBNull.Value)
                        {
                            listID.Add(Convert.ToInt64(dr["ID"].ToString()));
                        }
                    }
                }
            }
            return listID;
        }

        public int UpdateCheckCo(int ID ,string SoHieuXe,string NoiDi, string NoiDen ,int TinhThanhID,
                       int CoDau,int CoCuoi,DateTime ThoiDiemDi,DateTime  ThoiDiemVe ,bool ChieuDi,float TongTien, string GhiChu,string NguoiSua
            , int tinhThanhDiID, int quanHuyenDiID, int quanHuyenDenID, int phuongXaDiID, int phuongXaDenID, string tenLaiXe, string soDienThoai, bool isChiaSe,bool trangThaiDuyet, bool isDaDuyet)
        { 
            int result = new Data.CheckCoDuongDai.CheckCoDuongDai().UpdateCheckCo(ID ,SoHieuXe,NoiDi, NoiDen ,TinhThanhID,
                                                CoDau,CoCuoi ,ThoiDiemDi,ThoiDiemVe ,ChieuDi,TongTien,GhiChu, NguoiSua
                                                , tinhThanhDiID, quanHuyenDiID, quanHuyenDenID, phuongXaDiID, phuongXaDenID, tenLaiXe, soDienThoai, isChiaSe, trangThaiDuyet);
            return result;
        }
        public int DeleteCheckCo(int id, string deleteByUser)
        {
            return new Data.CheckCoDuongDai.CheckCoDuongDai().DeleteChecCo(id, deleteByUser);
        }

        public int DuyetChecCo(CheckCoDuongDai objCheckCo, string nguoiSua, bool trangThaiDuyet)
        {
            try
            {
                int result = new Data.CheckCoDuongDai.CheckCoDuongDai().DuyetChecCo(objCheckCo.ID, nguoiSua, trangThaiDuyet);
                return result;
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show(ex.ToString());
                return 0;
            }
        }

        public static List<T> CloneList<T>(List<T> oldList)
        {
            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, oldList);
                    stream.Position = 0;
                    return (List<T>)formatter.Deserialize(stream);
                }
            }
            catch 
            {
                return null;
            }            
        }
    }

    #region Province
    [Serializable]
    public class Province
    {
        #region Properties
        private int _PK_ProvinceID;
        public int PK_ProvinceID
        {
            get { return _PK_ProvinceID; }
            set { _PK_ProvinceID = value; }
        }

        private string _NameVN;
        public string NameVN
        {
            get { return _NameVN; }
            set { _NameVN = value; }
        }

        private string _NameEN;
        public string NameEN
        {
            get { return _NameEN; }
            set { _NameEN = value; }
        }
        #endregion

        public Province()
        {
            PK_ProvinceID = 0;
            NameEN = "Chon Tinh/TP";
            NameVN = "Chọn Tỉnh/TP";
        }

        public Province(int pK_ProvinceID, string nameEN, string nameVN)
        {
            PK_ProvinceID = pK_ProvinceID;
            NameEN = nameEN;
            NameVN = nameVN;
        }

        private static Province GetProvinceByDataRow(DataRow row)
        {
            return new Province(
            (int)row["PK_ProvinceID"],
            row["NameEN"].ToString(),
            row["NameVN"].ToString());
        }

        public static List<Province> GetAllProvince()
        {
            List<Province> lstProvince = new List<Province>();
            DataTable dt = new Taxi.Data.CheckCoDuongDai.CheckCoDuongDai().GetProvince().Tables[0];

            if (dt.Rows.Count > 0)
            {
                lstProvince.Add(new Province());
                foreach (DataRow dr in dt.Rows)
                {
                    lstProvince.Add(GetProvinceByDataRow(dr));
                }
            }
            dt.Dispose();
            dt = null;

            return lstProvince;
        }

        //public static ProvinceItem[] GetAllProvince_asmx()
        //{
        //    try
        //    {
        //        using (TripServices.Service Trip = new Taxi.Business.TripServices.Service())
        //        {
        //            return Trip.GetProvince();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
            
        //}

    }
    #endregion

    #region District
    [Serializable]
    public class District
    {
        #region Properties
        private int _PK_DistrictID;
        public int PK_DistrictID
        {
            get { return _PK_DistrictID; }
            set { _PK_DistrictID = value; }
        }

        private string _NameVN;
        public string NameVN
        {
            get { return _NameVN; }
            set { _NameVN = value; }
        }

        private string _NameEN;
        public string NameEN
        {
            get { return _NameEN; }
            set { _NameEN = value; }
        }

        private int _FK_ProvinceID;
        public int FK_ProvinceID
        {
            get { return _FK_ProvinceID; }
            set { _FK_ProvinceID = value; }
        }

        private Province _Province;
        //private List<Commune> communes = new List<Commune>();


        //public List<Commune> Communes 
        //{
        //    get { return this.communes; }
        //    set { this.communes = value; }
        //}

        public Province Province
        {
            get { return _Province; }
            set { _Province = value; }
        }
        #endregion

        public District()
        {
            PK_DistrictID = 0;
            FK_ProvinceID = 0;
            NameEN = "Chon Quan Huyen";
            NameVN = "Chọn Quận Huyện";
        }

        public District(int pK_DistrictID, int fK_ProvinceID, string nameEN, string nameVN)
        {
            PK_DistrictID = pK_DistrictID;
            FK_ProvinceID = fK_ProvinceID;
            NameEN = nameEN;
            NameVN = nameVN;
        }

        private static District GetDistrictByDataRow(DataRow row)
        {
            return new District(
            (int)row["PK_DistrictID"],
            (int)row["FK_ProvinceID"],
            row["NameEN"].ToString(),
            row["NameVN"].ToString() );
        }

        public static List<District> GetAllDistrict()
        {
            List<District> lstDistrict = new List<District>();
            DataTable dt = new Taxi.Data.CheckCoDuongDai.CheckCoDuongDai().GetDistrict().Tables[0];

            if (dt.Rows.Count > 0)
            {
                lstDistrict.Add(new District());
                foreach (DataRow dr in dt.Rows)
                {
                    lstDistrict.Add(GetDistrictByDataRow(dr));
                }
            }
            dt.Dispose();
            dt = null;

            return lstDistrict;
        }


        //public static DistrictItem getDistrictEmpty()
        //{
        //    DistrictItem objDistrict = new DistrictItem();
        //    objDistrict.PK_DistrictID = 0;
        //    objDistrict.FK_ProvinceID = 0;
        //    objDistrict.NameEN = "Chon Quan Huyen";
        //    objDistrict.NameVN = "Chọn Quận Huyện";
        //    return objDistrict;
        //}

        //public static DistrictItem[] GetAllDistrict_asmx()
        //{
        //    try
        //    {
        //        using (TripServices.Service Trip = new Taxi.Business.TripServices.Service())
        //        {
        //            return Trip.GetDistrict();

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }

        //}
    }
    #endregion

    #region Commune

    [Serializable]
    public class Commune
    {
        #region Properties
        private int _PK_CommuneID;
        public int PK_CommuneID
        {
            get { return _PK_CommuneID; }
            set { _PK_CommuneID = value; }
        }

        private string _NameVN;
        public string NameVN
        {
            get { return _NameVN; }
            set { _NameVN = value; }
        }

        private string _NameEN;
        public string NameEN
        {
            get { return _NameEN; }
            set { _NameEN = value; }
        }

        private int _FK_DistrictID;
        public int FK_DistrictID
        {
            get { return _FK_DistrictID; }
            set { _FK_DistrictID = value; }
        }

        private District _District;

        public District District
        {
            get { return _District; }
            set { _District = value; }
        }
        #endregion

        public Commune()
        {
            PK_CommuneID = 0;
            FK_DistrictID = 0;
            NameEN = "Chon Phuong Xa";
            NameVN = "Chọn Phường Xã";
        }

        public Commune(int pK_CommuneID, int fK_DistrictID,string nameEN, string nameVN)
        {
            PK_CommuneID = pK_CommuneID;
            FK_DistrictID = fK_DistrictID;
            NameEN = nameEN;
            NameVN = nameVN;
        }

        private static Commune GetCommuneByDataRow(DataRow row)
        {
            return new Commune(
                    (int)row["PK_CommuneID"], 
                    (int)row["FK_DistrictID"],
                    row["NameEN"].ToString(), 
                    row["NameVN"].ToString());
        }

        public static List<Commune> GetAllCommune()
        {
            List<Commune> lstCommune = new List<Commune>();
            DataTable dt = new Taxi.Data.CheckCoDuongDai.CheckCoDuongDai().GetCommune().Tables[0];
            lstCommune.Add(new Commune());
            if (dt.Rows.Count > 0)
                foreach (DataRow dr in dt.Rows)
                {
                    lstCommune.Add(GetCommuneByDataRow(dr));
                }

            dt.Dispose();
            dt = null;

            return lstCommune;
        }
    }
    #endregion
}
