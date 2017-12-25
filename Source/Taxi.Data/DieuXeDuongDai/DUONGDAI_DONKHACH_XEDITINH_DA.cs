using System;
using System.Data;
using System.Data.SqlClient;
using Taxi.Utils;

namespace Taxi.Data.DieuXeDuongDai
{
    public class DUONGDAI_DONKHACH_XEDITINH_DA : DBObject
    {
        #region SQL
        public string TableName = "DUONGDAI_DONKHACH_XEDITINH";
        public string Store_Insert = "sp_DUONGDAI_DONKHACH_XEDITINH_Insert";
        public string Store_Update = "sp_DUONGDAI_DONKHACH_XEDITINH_Update";
        public string Store_Delete = "sp_DUONGDAI_DONKHACH_XEDITINH_Delete";
        public string Store_GetAll = "sp_DUONGDAI_DONKHACH_XEDITINH_GetAll";
        public string Store_TimKiem = "sp_DUONGDAI_DONKHACH_XEDITINH_TimKiem";
        public string Store_GetLichSu = "sp_DUONGDAI_DONKHACH_XEDITINH_GetLichSu";

        #endregion

        #region Field
        public long Id { get; set; }
        public DateTime ThoiDiemGoi { get; set; }
        public string DienThoai { get; set; }
        public string SoXe { get; set; }
        public string DiaChiDon { get; set; }
        public DateTime ThoiDiemDon { get; set; }
        public int TrangThai { get; set; }
        public bool IsDelete { get; set; }
        public string GhiChu { get; set; }
        public float TongTien { get; set; }
        public long FK_DUONGDAI_KHACHHEN { get; set; }
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
                new SqlParameter("DienThoai", this.DienThoai),
                new SqlParameter("SoXe", this.SoXe),
                new SqlParameter("DiaChiDon", this.DiaChiDon),
                new SqlParameter("IsDelete", this.IsDelete),
                new SqlParameter("ThoiDiemDon", this.ThoiDiemDon),
                new SqlParameter("TrangThai", this.TrangThai),
                new SqlParameter("GhiChu", this.GhiChu),
                new SqlParameter("TongTien", this.TongTien),
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

        public DataTable TimKiem(DateTime deStart, DateTime deEnd,string soxe, string sdt, string diaChi,int trangthai)
        {
            var pa = new IDataParameter[] { new SqlParameter("deStart", deStart), new SqlParameter("deEnd", deEnd), new SqlParameter("soxe", soxe), new SqlParameter("sdt", sdt), new SqlParameter("diachi", diaChi), new SqlParameter("trangthai", trangthai) };
            return this.RunProcedure(this.Store_TimKiem, pa, this.TableName).Tables[0];
        }

        public DataTable GetLichSu(long id)
        {
            var pa = new IDataParameter[] { new SqlParameter("id", id) };
            return this.RunProcedure(this.Store_GetLichSu, pa, this.TableName).Tables[0];
        }
        #endregion
    }
}
