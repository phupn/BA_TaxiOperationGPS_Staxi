using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Taxi.Utils;

namespace Taxi.Data.DieuXeDuongDai
{
    public class DUONGDAI_KHACHHEN_DA : DBObject
    {
        #region SQL
        public string TableName = "DUONGDAI_KHACHHEN";
        public string Store_Insert = "sp_DUONGDAI_KHACHHEN_Insert";
        public string Store_Update = "sp_DUONGDAI_KHACHHEN_Update";
        public string Store_Delete = "sp_DUONGDAI_KHACHHEN_Delete";
        public string Store_GetAll = "sp_DUONGDAI_KHACHHEN_GetAll";
        public string Store_TimKiem = "sp_DUONGDAI_KHACHHEN_TimKiem";
        public string Store_GetLichSu = "sp_DUONGDAI_KHACHHEN_GetLichSu";
        public string Store_GetByTime = "sp_DUONGDAI_KHACHHEN_GetByTime";
        public string Store_DieuxeTimKiem = "sp_DUONGDAI_KHACHHEN_DieuxeTimKiem";
        public string Store_UpdateDieuXe = "sp_DUONGDAI_KHACHHEN_UpdateDieuXe";
        #endregion

        #region Field
        public long Id { get; set; }
        public DateTime ThoiDiemGoi { get; set; }
        public string TenKhachHang { get; set; }
        public string DienThoai { get; set; }
        public string DiaChiDon { get; set; }
        public DateTime ThoiDiemDon { get; set; }
        public string LoaiXe { get; set; }
        public int SoPhutBaoTruoc { get; set; }
        public int TrangThai { get; set; }
        public string GhiChu { get; set; }
        public string GhiChuDieu { get; set; }
        public string XeNhan { get; set; }
        public string MaNVDieu { get; set; }
        public DateTime ThoiDiemDieu { get; set; }
        public string XeDon { get; set; }
        public float TongTien { get; set; }
        public string DiaChiTra { get; set; }
        public float KinhDo { get; set; }
        public float ViDo { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public long IDCuocGoi { get; set; }
        #endregion

        #region Proc
        public IDataParameter[] GetParameters()
        {
            return new IDataParameter[]
            {
                new SqlParameter("Id", this.Id),
                new SqlParameter("ThoiDiemGoi", this.ThoiDiemGoi),
                new SqlParameter("TenKhachHang", this.TenKhachHang),
                new SqlParameter("DienThoai", this.DienThoai),
                new SqlParameter("DiaChiDon", this.DiaChiDon),
                new SqlParameter("ThoiDiemDon", this.ThoiDiemDon),
                new SqlParameter("LoaiXe", this.LoaiXe),
                new SqlParameter("SoPhutBaoTruoc", this.SoPhutBaoTruoc),
                new SqlParameter("TrangThai", this.TrangThai),
                new SqlParameter("GhiChu", this.GhiChu),
                new SqlParameter("XeNhan", this.XeNhan),
                new SqlParameter("MaNVDieu", this.MaNVDieu),
                new SqlParameter("ThoiDiemDieu", this.ThoiDiemDieu),
                new SqlParameter("XeDon", this.XeDon),
                new SqlParameter("TongTien", this.TongTien),
                new SqlParameter("DiaChiTra", this.DiaChiTra),
                new SqlParameter("KinhDo", this.KinhDo),
                new SqlParameter("ViDo", this.ViDo),
                new SqlParameter("CreatedDate", this.CreatedDate),
                new SqlParameter("CreatedBy", this.CreatedBy),
                new SqlParameter("UpdatedDate", this.UpdatedDate),
                new SqlParameter("UpdatedBy", this.UpdatedBy),
                new SqlParameter("IDCuocGoi", this.IDCuocGoi),
            };
        }
        public bool Insert()
        {
            return this.RunProcedure(this.Store_Insert, GetParameters(), 0) > 0;
        }

        public bool Update()
        {
            return this.RunProcedure(this.Store_Update, GetParameters(), 0) > 0;
        }

        public bool Delete()
        {
            return this.RunProcedure(this.Store_Delete, new IDataParameter[] { new SqlParameter("Id", this.Id), new SqlParameter("UpdatedBy", this.UpdatedBy) }, 0) > 0;
        }

        public DataTable GetAll()
        {
            return this.RunProcedure(this.Store_GetAll, new IDataParameter[0], this.TableName).Tables[0];
        }

        public DataTable TimKiem(DateTime deStart, DateTime deEnd, string sdt, string diaChi)
        {
            var pa = new IDataParameter[] { new SqlParameter("deStart", deStart), new SqlParameter("deEnd", deEnd), new SqlParameter("sdt", sdt), new SqlParameter("diaChi", diaChi) };
            return this.RunProcedure(this.Store_TimKiem, pa, this.TableName).Tables[0];
        }

        public DataTable GetByTime(DateTime? dt)
        {
            var dat = (dt == null) ? (object)DBNull.Value : (object)dt;
            var pa = new IDataParameter[] { new SqlParameter("dt", dat) };
            return this.RunProcedure(this.Store_GetByTime, pa, this.TableName).Tables[0];
        }

        public DataTable DieuxeTimKiem(DateTime? dt,string dienthoai,string diachi,string tenkhachhang)
        {
            var pa = new IDataParameter[] { new SqlParameter("dt",dt==null?DBNull.Value:(object)dt), new SqlParameter("dienthoai", dienthoai), new SqlParameter("diachi", diachi), new SqlParameter("tenkhachhang", tenkhachhang) };
            return this.RunProcedure(this.Store_DieuxeTimKiem, pa, this.TableName).Tables[0];
        }
        public DataTable GetLichSu(long id)
        {
            var pa = new IDataParameter[] { new SqlParameter("id", id)};
            return this.RunProcedure(this.Store_GetLichSu, pa, this.TableName).Tables[0];
        }
        public bool UpdateDieuXe()
        {
            var par = new IDataParameter[]
            {
                new SqlParameter("Id", this.Id),
                new SqlParameter("TrangThai", this.TrangThai),
                new SqlParameter("XeDon", this.XeDon),
                new SqlParameter("GhiChuDieu", this.GhiChuDieu),
                new SqlParameter("UpdatedBy", this.UpdatedBy),
            };
            return this.RunProcedure(this.Store_UpdateDieuXe, par, 0) > 0;
        }
        #endregion
    }
}
