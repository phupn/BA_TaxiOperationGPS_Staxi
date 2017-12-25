using System;
using System.Data;
using System.Data.SqlClient;
using Taxi.Utils;

namespace Taxi.Data.DieuXeDuongDai
{
    public class DUONGDAI_KHACHHEN_XEDK_DA : DBObject
    { 
        #region SQL
        public string TableName = "DUONGDAI_KHACHHEN_XEDK";
        public string Store_Insert = "sp_DUONGDAI_KHACHHEN_XEDK_Insert";
        public string Store_Update = "sp_DUONGDAI_KHACHHEN_XEDK_Update";
        public string Store_Delete = "sp_DUONGDAI_KHACHHEN_XEDK_Delete";
        public string Store_GetAll = "sp_DUONGDAI_KHACHHEN_XEDK_GetAll";
        public string Store_TimKiem = "sp_DUONGDAI_KHACHHEN_XEDK_TimKiem";
        public string Store_GetLichSu = "sp_DUONGDAI_KHACHHEN_XEDK_GetLichSu";
        public string Store_GetByTime = "sp_DUONGDAI_KHACHHEN_XEDK_GetByTime";
        public string Store_UpdateDieuXe = "sp_DUONGDAI_KHACHHEN_XEDK_UpdateDieuXe";
        public string Store_DieuxeTimKiem = "sp_DUONGDAI_KHACHHEN_XEDK_DieuxeTimKiem";
        public string Store_DeleteDieuXe = "sp_DUONGDAI_KHACHHEN_XEDK_DeleteDieuXe";
        
        #endregion

        #region Field
        public long Id { get; set; }
        public DateTime ThoiDiemGoi { get; set; }
        public string DienThoai { get; set; }
        public string SoXe { get; set; }
        public string DiemDo { get; set; }
        public DateTime ThoiDiemDon { get; set; }
        public int TrangThai { get; set; }
        public string GhiChu { get; set; }
        public long FK_DUONGDAI_KHACHHEN { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public long IDCuocGoi { get; set; }
        public int IsXeDangKy { get; set; }
        #endregion

        #region Proc
        public IDataParameter[] GetParameters()
        {
            return new IDataParameter[]
            {
                new SqlParameter("Id", this.Id),
                new SqlParameter("ThoiDiemGoi", this.ThoiDiemGoi),
                new SqlParameter("DienThoai", this.DienThoai),
                new SqlParameter("SoXe", this.SoXe),
                new SqlParameter("ThoiDiemDon", this.ThoiDiemDon),
                new SqlParameter("DiemDo", this.DiemDo),
                new SqlParameter("TrangThai", this.TrangThai),
                new SqlParameter("GhiChu", this.GhiChu),
                new SqlParameter("FK_DUONGDAI_KHACHHEN", this.FK_DUONGDAI_KHACHHEN),
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

        public DataTable TimKiem(DateTime deStart, DateTime deEnd, string sdt,string soxe, int trangThai)
        {
            var pa = new IDataParameter[] { new SqlParameter("deStart", deStart), new SqlParameter("deEnd", deEnd), new SqlParameter("sdt", sdt), new SqlParameter("soxe", soxe), new SqlParameter("trangThai", trangThai) };
            return this.RunProcedure(this.Store_TimKiem, pa, this.TableName).Tables[0];
        }

        public DataTable GetLichSu(long id)
        {
            var pa = new IDataParameter[] { new SqlParameter("id", id) };
            return this.RunProcedure(this.Store_GetLichSu, pa, this.TableName).Tables[0];
        }
        public DataTable GetByTime(DateTime? dt)
        {
            var dat = (dt == null) ? (object)DBNull.Value : (object)dt;
            var pa = new IDataParameter[] { new SqlParameter("dt", dat) };
            return this.RunProcedure(this.Store_GetByTime, pa, this.TableName).Tables[0];
        }

        public bool UpdateDieuXe()
        {
            var par = new IDataParameter[]
            {
                new SqlParameter("Id", this.Id),
                new SqlParameter("FK_DUONGDAI_KHACHHEN", this.FK_DUONGDAI_KHACHHEN),
                new SqlParameter("IsXeDangKy", this.IsXeDangKy),
                new SqlParameter("UpdatedBy", this.UpdatedBy),
                new SqlParameter("TrangThai", this.TrangThai),
            };
            return this.RunProcedure(this.Store_UpdateDieuXe, par, 0) > 0;
        }

        public bool DeleteDieuXe()
        {
            return this.RunProcedure(this.Store_DeleteDieuXe, new IDataParameter[] { new SqlParameter("Id", this.Id), new SqlParameter("TrangThai", this.TrangThai), new SqlParameter("IsXeDangKy", this.IsXeDangKy), new SqlParameter("GhiChu", this.GhiChu), new SqlParameter("UpdatedBy", this.UpdatedBy) }, 0) > 0;
            
        }
        public DataTable DieuxeTimKiem(DateTime? dt,string soXe,string diemDo)
        { 
            var par = new IDataParameter[]
            {
                new SqlParameter("dt", dt != null ? (object)dt : (object)DBNull.Value),
                new SqlParameter("soXe", soXe),
                new SqlParameter("diemDo", diemDo)
            };
            return this.RunProcedure(this.Store_DieuxeTimKiem, par,this.TableName).Tables[0];
        }
        #endregion
    }
}
