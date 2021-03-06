using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Taxi.Data.KhachDat;

namespace Taxi.Business.KhachDat
{
    public class KhachDatBL
    { 
        #region ====================Encapsulation field==================

        public int PK_KhachDatID{ get; set; }

        public DateTime ThoiDiemTiepNhan{ get; set; }

        public string TenKhachHang { get; set; }

        public string DiaChi { get; set; }

        public string SoDienThoai { get; set; }

        public int VungKenh { get; set; }

        public int Line { get; set; }

        public bool IsLapLai { get; set; }

        public DateTime GioDon { get; set; }

        public DateTime ThoiDiemBatDau { get; set; }

        public DateTime ThoiDiemKetThuc { get; set; }

        public string NgayTrongTuanLapLai { get; set; }

        public int SoPhutBaoTruoc { get; set; }

        public long FK_CuocGoiID { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public string FULLNAME { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public string GhiChu { get; set; }

        public string LoaiXe { get; set; }      //Dùng lưu mã loại xe trong SCarTaxi
        public string TenLoaiXe { get; set; }   //Dùng để hiển thị text loại xe!
        public int SoLuongXe { get; set; }

        public double KinhDo { get; set; }

        public double ViDo { get; set; }

        public double SoTien { get; set; }

        public string  DiaChiTra { get; set; }
        public int FK_SystemBookID { get; set; }
        public float SoKm { get; set; }
        public DateTime UpdatedDateKD { get; set; }
        /// <summary>
        /// Trạng thái khách đặt.
        /// = -2 là Đã Xóa
        /// = -1 : Đã hoãn
        /// = 0 hoặc null : Chưa chèn
        /// = 1 đã chèn 1 lần
        /// = 2 đã chèn 2 lần
        /// </summary>
        public int StatusRow { get; set; }
        #endregion

        private KhachDatBL GetKhachDat_Row(DataRow row)
        {
            KhachDatBL KhachDat = new KhachDatBL();
            try
            {
                KhachDat.PK_KhachDatID = Convert.ToInt32(row["PK_KhachDatID"]);
                if (row["ThoiDiemTiepNhan"]!=DBNull.Value)
                    KhachDat.ThoiDiemTiepNhan = Convert.ToDateTime(row["ThoiDiemTiepNhan"].ToString());
                KhachDat.TenKhachHang = row["TenKhachHang"].ToString();
                KhachDat.SoDienThoai = row["SoDienThoai"].ToString();
                KhachDat.DiaChi = row["DiaChiDon"].ToString();
                KhachDat.VungKenh = Convert.ToInt32(row["VungKenh"]);
                KhachDat.IsLapLai = Convert.ToBoolean(row["IsLapLai"]);
                KhachDat.Line = 111;
                if (row["GioDon"]!=DBNull.Value)
                    KhachDat.GioDon = Convert.ToDateTime(row["GioDon"].ToString());
                if (row["ThoiDiemBatDau"]!=DBNull.Value)
                    KhachDat.ThoiDiemBatDau = Convert.ToDateTime(row["ThoiDiemBatDau"].ToString());
                if (row["ThoiDiemKetThuc"]!=DBNull.Value)
                    KhachDat.ThoiDiemKetThuc = Convert.ToDateTime(row["ThoiDiemKetThuc"].ToString());
                KhachDat.NgayTrongTuanLapLai = row["NgayTrongTuanLapLai"].ToString();
                KhachDat.SoPhutBaoTruoc = Convert.ToInt32(row["SoPhutBaoTruoc"]);
                KhachDat.FK_CuocGoiID = Convert.ToInt64(row["FK_CuocGoiID"]);
                KhachDat.GhiChu = row["GhiChu"].ToString();
                KhachDat.LoaiXe = row["LoaiXe"].ToString();
                KhachDat.SoLuongXe = Convert.ToInt32(row["SoLuongXe"]);
                KhachDat.CreatedBy = row["CreatedBy"].ToString();
                KhachDat.FULLNAME = row["FULLNAME"].ToString();
                KhachDat.KinhDo = row["KinhDo"] == DBNull.Value ? 0 : Convert.ToDouble(row["KinhDo"]);
                KhachDat.ViDo = row["ViDo"] == DBNull.Value ? 0 : Convert.ToDouble(row["ViDo"]);
                KhachDat.SoTien = row["SoTien"] == DBNull.Value ? 0 : Convert.ToDouble(row["SoTien"]);
                if (row.Table.Columns.Contains("TenLoaiXe"))
                    KhachDat.TenLoaiXe = row["TenLoaiXe"].ToString();
                else
                {
                    KhachDat.TenLoaiXe = CommonBL.ListStaxiLoaiXe.FirstOrDefault(a => a.StaxiType.ToString() == KhachDat.LoaiXe).Name;
                } 

                if (row.Table.Columns.Contains("DiaChiTra") && row["DiaChiTra"] != DBNull.Value)
                    KhachDat.DiaChiTra = row["DiaChiTra"].ToString();
                else KhachDat.DiaChiTra = string.Empty;

                if (row.Table.Columns.Contains("SoKm") && row["SoKm"] != DBNull.Value)
                    KhachDat.SoKm = float.Parse(row["SoKm"].ToString());
                else KhachDat.SoKm = 0;

                if (row.Table.Columns.Contains("FK_SystemBookID") && row["FK_SystemBookID"] != DBNull.Value)
                    KhachDat.FK_SystemBookID = int.Parse(row["FK_SystemBookID"].ToString());
                else KhachDat.FK_SystemBookID = 0;

                if (row["UpdatedDateKD"] != DBNull.Value)
                    KhachDat.UpdatedDateKD = Convert.ToDateTime(row["UpdatedDateKD"].ToString());
                KhachDat.StatusRow = row["StatusRow"] == DBNull.Value ? 0 : int.Parse(row["StatusRow"].ToString());
            }
            catch (Exception exx)
            {
                LogError.WriteLogError("GetKhachDat_Row", exx);
            }
            return KhachDat;
               
        }

        /// <summary>
        /// get KhachDat để chèn cuộc gọi (gán thêm line)
        /// </summary>
        private KhachDatBL GetKhachDat_Row_Line(DataRow row, string line)
        {
            KhachDatBL KhachDat = new KhachDatBL();
            KhachDat.PK_KhachDatID = Convert.ToInt32(row["PK_KhachDatID"]);
            string ThoiDiemTiepNhan = row["ThoiDiemTiepNhan"].ToString();
            if (!string.IsNullOrEmpty(ThoiDiemTiepNhan))
                KhachDat.ThoiDiemTiepNhan = Convert.ToDateTime(ThoiDiemTiepNhan);
            KhachDat.TenKhachHang = row["TenKhachHang"].ToString();
            KhachDat.SoDienThoai = row["SoDienThoai"].ToString();
            KhachDat.DiaChi = row["DiaChiDon"].ToString();
            KhachDat.Line = Convert.ToInt32(line);
            KhachDat.VungKenh = Convert.ToInt32(row["VungKenh"]);
            KhachDat.IsLapLai = Convert.ToBoolean(row["IsLapLai"]);
            string GioDon = row["GioDon"].ToString();
            if (!string.IsNullOrEmpty(GioDon))
                KhachDat.GioDon = Convert.ToDateTime(GioDon);
            string ThoiDiemBatDau = row["ThoiDiemBatDau"].ToString();
            if (!string.IsNullOrEmpty(ThoiDiemBatDau))
                KhachDat.ThoiDiemBatDau = Convert.ToDateTime(ThoiDiemBatDau);
            string ThoiDiemKetThuc = row["ThoiDiemKetThuc"].ToString();
            if (!string.IsNullOrEmpty(ThoiDiemKetThuc))
                KhachDat.ThoiDiemKetThuc = Convert.ToDateTime(ThoiDiemKetThuc);
            KhachDat.NgayTrongTuanLapLai = row["NgayTrongTuanLapLai"].ToString();
            KhachDat.SoPhutBaoTruoc = Convert.ToInt32(row["SoPhutBaoTruoc"]);
            KhachDat.FK_CuocGoiID = row["FK_CuocGoiID"] == DBNull.Value ? 1 : Convert.ToInt64(row["FK_CuocGoiID"]);
            KhachDat.GhiChu = row["GhiChu"].ToString();
            KhachDat.LoaiXe = row["LoaiXe"].ToString();
            KhachDat.SoLuongXe = row["SoLuongXe"] == DBNull.Value ? 1 : Convert.ToInt32(row["SoLuongXe"]);
            KhachDat.DiaChiTra = row["DiaChiTra"] == DBNull.Value ? "" : row["DiaChiTra"].ToString();
            KhachDat.SoKm = row["SoKm"] == DBNull.Value ? 1 : float.Parse(row["SoKm"].ToString());
            KhachDat.FK_SystemBookID = row["FK_SystemBookID"] == DBNull.Value ? 1 : int.Parse(row["FK_SystemBookID"].ToString());
            if (row["UpdatedDateKD"] != DBNull.Value)
                KhachDat.UpdatedDateKD = Convert.ToDateTime(row["UpdatedDateKD"].ToString());
            KhachDat.StatusRow = row["StatusRow"] == DBNull.Value ? 0 : int.Parse(row["StatusRow"].ToString());
            //KhachDat.KinhDo = 
            return KhachDat;
        }

        /// <summary>
        /// Lấy thông tin khách đặt
        /// </summary>
        /// <returns>Khách đặt Entity</returns>
        public KhachDatBL GetKhachDat(int PK_KhachDatID)
        {
            using (DataTable dt = new KhachDatDA().GetKhachDat(PK_KhachDatID))
            {
                if (dt == null)
                    return null;
                if (dt.Rows.Count <= 0)
                    return null;

                return GetKhachDat_Row(dt.Rows[0]);
            }

        }

        /// <summary>
        /// lay ra tat ca thong tin khach dat theo ngay tiếp nhận
        /// </summary>
        public List<KhachDatBL> GetKhachDat_TGTiepNhan(DateTime ThoiDiemTiepNhan)
        {
            try
            {
                List<KhachDatBL> lstKhachDat = new List<KhachDatBL>();
                using (DataTable dt = new KhachDatDA().GetKhachDat_TGTiepNhan(ThoiDiemTiepNhan))
                {
                    if (dt != null)
                    {
                        if (dt.Rows.Count <= 0)
                            return null;
                        else
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                lstKhachDat.Add(GetKhachDat_Row(row));
                            }
                        }
                    }
                }
                return lstKhachDat;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// lay ra tat ca thong tin khach dat theo ngay tiếp nhận
        /// </summary>
        public List<KhachDatBL> GetKhachDat_ChenCuocGoi(DateTime ThoiDiemTiepNhan)
        {
            try
            {
                List<KhachDatBL> lstKhachDat = new List<KhachDatBL>();
                using (DataTable dt = new KhachDatDA().GetKhachDat_ChenCuocGoi(ThoiDiemTiepNhan))
                {
                    if (dt != null)
                    {
                        if (dt.Rows.Count <= 0)
                            return null;
                        else
                        {                             
                            foreach (DataRow row in dt.Rows)
                            {
                                lstKhachDat.Add(GetKhachDat_Row_Line(row,"90"));
                            }                             
                        }
                    }
                }
                return lstKhachDat;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetKhachDat_ChenCuocGoi:", ex);
                return null;
            }
        }

        /// <summary>
        /// Lay dữ liệu Khách đặt. theo search
        /// </summary>
        /// <param name="ThoiDiemTiepNhan"></param>
        /// <param name="TenKhachHang"></param>
        /// <param name="DiaChiDon"></param>
        /// <param name="SoDienThoai"></param>
        /// <param name="VungKenh"></param>
        /// <param name="IsLapLai"></param>
        /// <param name="GioDon"></param>
        /// <param name="ThoiDiemBatDau"></param>
        /// <param name="ThoiDiemKetThuc"></param>
        /// <param name="SoPhutBaoTruoc"></param>
        /// <returns></returns>
        public List<KhachDatBL> GetKhachDat_Search(DateTime TGTiepNhanTu, DateTime TGTiepNhanDen, string TenKhachHang, string DiaChiDon, string SoDienThoai, int VungKenh
                                , int IsLapLai, DateTime GioDonTu, DateTime GioDonDen, DateTime ThoiDiemBatDau, DateTime ThoiDiemKetThuc, int SoPhutBaoTruoc, string LoaiXe, int SoLuongXe)
        {
            try
            {
                List<KhachDatBL> lstKhachDat = new List<KhachDatBL>();
                using (DataTable dt = new KhachDatDA().GetKhachDat_Search(TGTiepNhanTu, TGTiepNhanDen, TenKhachHang, DiaChiDon, SoDienThoai, VungKenh, IsLapLai, GioDonTu, GioDonDen, ThoiDiemBatDau, ThoiDiemKetThuc, SoPhutBaoTruoc, LoaiXe, SoLuongXe))
                {
                    if (dt != null)
                    {
                        if (dt.Rows.Count <= 0)
                            return null;
                        else
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                lstKhachDat.Add(GetKhachDat_Row(row));
                            }
                        }
                    }
                }
                return lstKhachDat;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<KhachDatBL> GetKhachDat_Search_V2(DateTime TGTiepNhanTu, DateTime TGTiepNhanDen, string TenKhachHang, string DiaChiDon, string SoDienThoai)
        {
            try
            {
                List<KhachDatBL> lstKhachDat = new List<KhachDatBL>();
                using (DataTable dt = new KhachDatDA().GetKhachDat_Search_V2(TGTiepNhanTu, TGTiepNhanDen, TenKhachHang, DiaChiDon, SoDienThoai))
                {
                    if (dt != null)
                    {
                        if (dt.Rows.Count <= 0)
                            return null;
                        else
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                lstKhachDat.Add(GetKhachDat_Row(row));
                            }
                        }
                    }
                }
                return lstKhachDat;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// Insert Khách Đặt Lịch Xe
        /// </summary>
        /// <returns>Thành công = 1, Không thành công = 0 </returns>
        public bool InsertKhachDat()
        {
            return new KhachDatDA().InsertKhachDat(ThoiDiemTiepNhan,
                                                   TenKhachHang,
                                                   DiaChi,
                                                   SoDienThoai,
                                                   VungKenh,
                                                   IsLapLai,
                                                   GioDon,
                                                   ThoiDiemBatDau,
                                                   ThoiDiemKetThuc,
                                                   NgayTrongTuanLapLai,
                                                   SoPhutBaoTruoc,
                                                   FK_CuocGoiID,
                                                   CreatedBy,
                                                   GhiChu,
                                                   LoaiXe,
                                                   SoLuongXe);
        }
        public bool InsertKhachDat_V2()
        {
            return new KhachDatDA().InsertKhachDat_V2(ThoiDiemTiepNhan,
                                                   TenKhachHang,
                                                   DiaChi,
                                                   SoDienThoai,
                                                   VungKenh,
                                                   IsLapLai,
                                                   GioDon,
                                                   ThoiDiemBatDau,
                                                   ThoiDiemKetThuc,
                                                   NgayTrongTuanLapLai,
                                                   SoPhutBaoTruoc,
                                                   FK_CuocGoiID,
                                                   CreatedBy,
                                                   GhiChu,
                                                   LoaiXe,
                                                   SoLuongXe,
                                                   DiaChiTra,
                                                   SoKm,
                                                   FK_SystemBookID);
        }

        /// <summary>
        /// Update Khách Đặt Lịch Xe
        /// </summary>
        /// <param name="PK_KhachDatID">Id Khach Dat</param>
        /// <returns>Thành công = 1, Không thành công = 0 </returns>
        public bool UpdateKhachDat()
        {
            return new KhachDatDA().UpdateKhachDat(TenKhachHang,
                                                   DiaChi,
                                                   SoDienThoai,
                                                   VungKenh,
                                                   IsLapLai,
                                                   GioDon,
                                                   ThoiDiemBatDau,
                                                   ThoiDiemKetThuc,
                                                   NgayTrongTuanLapLai,
                                                   SoPhutBaoTruoc,
                                                   UpdatedBy,
                                                   PK_KhachDatID,
                                                   GhiChu,
                                                   LoaiXe,
                                                   SoLuongXe,
                                                   SoTien);
        }

        public bool UpdateKhachDat_V2()
        {
            return new KhachDatDA().UpdateKhachDat_V2(TenKhachHang,
                                                   DiaChi,
                                                   SoDienThoai,
                                                   VungKenh,
                                                   IsLapLai,
                                                   GioDon,
                                                   ThoiDiemBatDau,
                                                   ThoiDiemKetThuc,
                                                   NgayTrongTuanLapLai,
                                                   SoPhutBaoTruoc,
                                                   UpdatedBy,
                                                   PK_KhachDatID,
                                                   GhiChu,
                                                   LoaiXe,
                                                   SoLuongXe,
                                                   SoTien,
                                                   DiaChiTra,
                                                   SoKm,
                                                   FK_SystemBookID);
        }
        /// <summary>
        /// Delete Khách Đặt Lịch Xe
        /// </summary>
        /// <returns>Thành công = 1, Không thành công = 0 </returns>
        public bool DeleteKhachDat(int PK_KhachDatID)
        {
            return new KhachDatDA().DeleteKhachDat(PK_KhachDatID);
        }

        public KhachDatEntity ParseToEntity()
        {
            KhachDatEntity result = new KhachDatEntity();
            result.FK_CuocGoiID = this.FK_CuocGoiID;
            result.ThoiDiemTiepNhan = this.ThoiDiemTiepNhan;
            result.TenKhachHang = this.TenKhachHang;
            result.DiaChiDon = this.DiaChi;
            result.SoDienThoai = this.SoDienThoai;
            result.VungKenh = this.VungKenh;
            result.Line = this.Line;
            result.IsLapLai = this.IsLapLai;
            result.GioDon = this.GioDon;
            result.ThoiDiemBatDau = this.ThoiDiemBatDau;
            result.ThoiDiemKetThuc = this.ThoiDiemKetThuc;
            result.NgayTrongTuanLapLai = this.NgayTrongTuanLapLai;
            result.SoPhutBaoTruoc = this.SoPhutBaoTruoc;            
            result.CreatedDate = DateTime.Now;            
            result.UpdatedDate = DateTime.Now;
            result.CreatedBy = this.CreatedBy;
            result.UpdatedBy = this.UpdatedBy;
            result.GhiChu = this.GhiChu;
            result.LoaiXe = this.LoaiXe;
            result.TenLoaiXe = this.TenLoaiXe;
            result.SoLuongXe = this.SoLuongXe;
            result.SoTien = this.SoTien;
            return result;
        }
    }
}
