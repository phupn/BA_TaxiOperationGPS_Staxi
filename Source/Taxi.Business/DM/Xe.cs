using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Data;
using Taxi.Utils;

namespace Taxi.Business.DM
{
    public class Xe
    {
        #region Properties
        private string mSoHieuXe;

        public string SoHieuXe
        {
            get { return mSoHieuXe; }
            set { mSoHieuXe = value; }
        }

        private string mBienKiemSoat;

        public string BienKiemSoat
        {
            get { return mBienKiemSoat; }
            set { mBienKiemSoat = value; }
        }

        private string mSoMay;

        public string SoMay
        {
            get { return mSoMay; }
            set { mSoMay = value; }
        }

        private string mSoKhung;

        public string SoKhung
        {
            get { return mSoKhung; }
            set { mSoKhung = value; }
        }

        private int mLoaiXeID;

        public int LoaiXeID
        {
            get { return mLoaiXeID; }
            set { mLoaiXeID = value; }
        }
        private string mTenLoaiXe;

        public string TenLoaiXe
        {
            get { return mTenLoaiXe; }
            set { mTenLoaiXe = value; }
        }

        private string mLoaiXe;

        public string LoaiXe
        {
            get { return mLoaiXe; }
            set { mLoaiXe = value; }
        }

        private int mGaraID;

        public int GaraID
        {
            get { return mGaraID; }
            set { mGaraID = value; }
        }
        private string mGaraName;

        public string GaraName
        {
            get { return mGaraName; }
            set { mGaraName = value; }
        }
        private string mSanh;

        public string Sanh
        {
            get { return mSanh; }
            set { mSanh = value; }
        }

        private int mSoCho; // số chỗ ngồi

        public int SoCho
        {
            get { return mSoCho; }
            set { mSoCho = value; }
        }

        public string TenNhanVien { get; set; }
        public string DienThoai { get; set; }
        #endregion Properties
        
        public bool Insert()
        {
            return new Data.DM.Xe().Insert(this.SoHieuXe, this.BienKiemSoat, this.SoMay, this.SoKhung, this.LoaiXeID, this.GaraID, SoCho);
        }

        public bool Update()
        {
            return new Data.DM.Xe().Update(this.SoHieuXe, this.BienKiemSoat, this.SoMay, this.SoKhung, this.LoaiXeID, this.GaraID, SoCho);
        }

        public List<Xe> GetListXes()
        {
            try
            {
                DataTable dt = new DataTable();
                List<Xe> lstXe = new List<Xe>();

                dt = new Data.DM.Xe().GetTatCaCacXe();
                if (dt == null) return lstXe;
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {

                        Xe objXe = new Xe();
                        objXe.SoHieuXe = !dr.Table.Columns.Contains("PK_SoHieuXe") ? "" : dr["PK_SoHieuXe"].ToString();
                        objXe.BienKiemSoat = !dr.Table.Columns.Contains("BienKiemSoat") ? "" : dr["BienKiemSoat"].ToString();
                        objXe.SoMay = !dr.Table.Columns.Contains("SoMay") ? "" : dr["SoMay"].ToString();
                        objXe.SoKhung = !dr.Table.Columns.Contains("SoKhung") ? "" : dr["SoKhung"].ToString();
                        int loaiXeId = 0;
                        if (dr.Table.Columns.Contains("FK_LoaiXeID") && dr["FK_LoaiXeID"] != DBNull.Value && int.TryParse(dr["FK_LoaiXeID"].ToString(), out loaiXeId))
                            objXe.LoaiXeID = loaiXeId;
                        objXe.TenLoaiXe = !dr.Table.Columns.Contains("TenLoaiXe") ? "" : dr["TenLoaiXe"].ToString();
                        objXe.LoaiXe = objXe.TenLoaiXe;
                        int garaID = 0;
                        if (dr.Table.Columns.Contains("FK_GaraID") && dr["FK_GaraID"] != DBNull.Value && int.TryParse(dr["FK_GaraID"].ToString(), out garaID))
                            objXe.GaraID = garaID;
                        objXe.GaraName = !dr.Table.Columns.Contains("GaraName") ? "" : dr["GaraName"].ToString();
                        int soCho = 0;
                        if (dr.Table.Columns.Contains("SoCho") && dr["SoCho"] != DBNull.Value && int.TryParse(dr["SoCho"].ToString(), out soCho))
                            objXe.SoCho = soCho;
                        lstXe.Add(objXe);

                    }
                    return lstXe;
                }
                else return null;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetListXes", ex);
                return null;
            }
        }

        public Xe GetChiTietXe(string SoHieuXe)
        {
            try
            {
                DataTable dt = new DataTable();


                dt = new Data.DM.Xe().GetChiTietMotXe(SoHieuXe);
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];

                    Xe objXe = new Xe();
                    objXe.SoHieuXe = dr["PK_SoHieuXe"] == DBNull.Value ? string.Empty : dr["PK_SoHieuXe"].ToString(); 
                    objXe.BienKiemSoat = dr["BienKiemSoat"] == DBNull.Value ? string.Empty : dr["BienKiemSoat"].ToString();
                    objXe.SoMay = dr["SoMay"] == DBNull.Value ? string.Empty : dr["SoMay"].ToString(); 
                    objXe.SoKhung = dr["SoKhung"] == DBNull.Value ? string.Empty : dr["SoKhung"].ToString();
                    objXe.LoaiXeID = dr["FK_LoaiXeID"] == DBNull.Value ? 0 : int.Parse(dr["FK_LoaiXeID"].ToString());
                    objXe.TenLoaiXe = dr["TenLoaiXe"].ToString();
                    objXe.GaraID = dr["FK_GaraID"] == DBNull.Value ? 0 : int.Parse(dr["FK_GaraID"].ToString());
                    objXe.GaraName = dr["GaraName"].ToString();
                    objXe.SoCho =  dr["SoCho"] == DBNull.Value ?  4 :   int.Parse(dr["SoCho"].ToString());
                    objXe.TenNhanVien = dr["TenNhanVien"] == DBNull.Value ? string.Empty : dr["TenNhanVien"].ToString();
                    objXe.DienThoai = dr["DienThoai"] == DBNull.Value ? string.Empty : dr["DienThoai"].ToString();
                    return objXe;

                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetChiTietXe", ex);
                return null;
            }

        }         

        public bool Delete(string SoHieuXe)
        {
            return new Data.DM.Xe().Delete(SoHieuXe);
        }
        /// <summary>
        /// kiem tra xem mot so hieu xe da co chua
        /// </summary>
        /// <param name="SoHieuXe"></param>
        /// <returns></returns>
        public static bool KiemTraTonTaiCuaSoHieuXe(string SoHieuXe)
        {
            DataTable dt = new DataTable();
            dt = new Data.DM.Xe().GetChiTietMotXe(SoHieuXe);
            if (dt.Rows.Count > 0)
                return true;
            return false;
        }

        public static bool KiemTraTonTaiCuaDanhSachSoHieuXe(string dsSoXe, out string msg)
        {
           
            var re = true;
            var ms = string.Empty;
            if (string.IsNullOrEmpty(dsSoXe))
                re = false;
            else
            {
                dsSoXe.Split(',').ToList().ForEach(p =>
                {
                    var r = KiemTraTonTaiCuaSoHieuXe(p);
                    if (r) return;
                    re = false;

                    ms = string.Format("{1}{0},", p, ms);
                });
            }
            msg = ms.Trim(',');
            return re;
        }

        #region -----New v3-----
        public static List<string> GetListSoHieuXe()
        {
            List<string> listSoHieuXe = new List<string>();
            try
            {
                DataTable dt = new DataTable();
                List<Xe> lstXe = new List<Xe>();
                dt = new Data.DM.Xe().GetTatCaCacXe();
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        listSoHieuXe.Add(StringTools.TrimSpace(dr["PK_SoHieuXe"].ToString()));
                    }
                }
                else listSoHieuXe = null;
            }
            catch (Exception ex)
            {
                listSoHieuXe = null;
            }
            return listSoHieuXe;
        }

        /// <summary>
        /// Danh sách Mã loại xe ứng với Loại xe bên GPS
        /// </summary>
        /// <param name="NhomXe">4,7,0</param>
        /// <returns>12,23,34,45</returns>
        public string LayDanhSachLoaiXe_GPS(string NhomXe)
        {
            string strID = "";
            DataTable dt = new Data.DM.Xe().LayDanhSachLoaiXe_GPS(NhomXe);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        strID = string.Format("{0}{1},", strID, row["LoaiXeID_GPS"]);
                    }
                    strID = strID.Substring(0, strID.Length - 1);
                }
            }
            return strID;
        }

        /// <summary>
        /// Danh sách Mã loại xe GPS mặc định ứng với kênh
        /// </summary>
        /// <param name="kenh">Số chỗ (group ko dung loai xe theo kenh)</param>
        /// <returns>12,23,34,45</returns>
        public string LayDanhSachLoaiXe_GPS_Kenh(string kenh)
        {
            return new Data.DM.Xe().LayDanhSachLoaiXe_GPS_Kenh(kenh);
        }

        /// <summary>
        /// Lấy danh sách loại xe (IDLoaiXe, Tên Loại Xe)
        /// </summary>
        /// <returns></returns>
        public DataTable LayDanhSach()
        {
            return new Taxi.Data.DM.TuDienLoaiXe().LayDanhSach();
        }

        public DataTable LayDanhSach_SHXe()
        {
            return new Taxi.Data.DM.Xe().GetDS_SHXe();
        }
        #endregion
    }
}
