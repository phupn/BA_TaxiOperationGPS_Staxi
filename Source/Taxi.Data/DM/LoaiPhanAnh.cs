using System;
using System.Collections.Generic;
using System.Text;
using Taxi.Utils;
using System.Data;
using System.Data.SqlClient;

namespace Taxi.Data.DM
{
  
   public class LoaiPhanAnh : DBObject
    {
       private string SP_KHACHHANG_PHANANH_INSERT = "sp_KHACHHANG_PHANANH_INSERT";
       private string SP_KHACHHANG_PHANANH_UPDATE = "sp_KHACHHANG_PHANANH_UPDATE";
       private string SP_KHACHHANG_PHANANH_DELETE = "sp_KHACHHANG_PHANANH_DELETE";
       private string SP_KHACHHANG_PHANANH_SELECTALL = "SP_KHACHHANG_PHANANH_SELECTALL";
       private string SP_KHACHHANG_PHANANH_GETBYID = "SP_KHACHHANG_PHANANH_GETBYID";
       private string SP_KHACHHANG_PHANANH_CheckTonTai = "SP_KHACHHANG_PHANANH_CheckTenTonTai";
       private string SP_KHACHHANG_PHANANH_SORT = "SP_KHACHHANG_PHANANH_SORT";
       /// <summary>
       /// Chèn một loại phản ánh vào bảng 
       /// </summary>
       /// <param name="tenLoaiPhanAnh"></param>
       /// <param name="createdBy"></param>
       /// <returns></returns>
       /// <modified>
       /// Name         date        comments
       /// hangtm       17/5/2011   created
       /// </modified>
        public bool Insert(string tenLoaiPhanAnh ,string createdBy)
        {
            try
            {
                int rowAffect =0;
                SqlParameter[] parameters = new SqlParameter[] { 
                 new SqlParameter ("@TenLoaiPhanAnh",SqlDbType.NVarChar,150),
                new SqlParameter ("@CreatedBy",SqlDbType.NVarChar ,50)
                };

                parameters[0].Value = tenLoaiPhanAnh;
                parameters[1].Value = createdBy;

                rowAffect = this.RunProcedure(SP_KHACHHANG_PHANANH_INSERT, parameters,rowAffect );
                return (rowAffect > 0);
            }
            catch(Exception ex)
            {
                return false;
            }
        }
       /// <summary>
       /// Sửa tên loại phản ánh
       /// </summary>
       /// <param name="iD"></param>
       /// <param name="tenLoaiPhanAnh"></param>
       /// <param name="UpdatedBy"></param>
       /// <returns></returns>
       /// <modified>
       /// name         date        comments
       /// hangtm       17/5/2011   created
       /// </modified>
       public bool Update(int id, string tenLoaiPhanAnh, string UpdatedBy) 
       {
           try
           { 
                int rowAffect =0;
               SqlParameter [] parameters = new SqlParameter[]
               {
                    new SqlParameter ("@ID",SqlDbType.Int ),
                    new SqlParameter("@TenLoaiPhanAnh", SqlDbType.NVarChar ,150),
                    new SqlParameter("@UpdateBy",SqlDbType.NVarChar ,50),
               };
               parameters[0].Value = id;
               parameters[1].Value = tenLoaiPhanAnh;
               parameters[2].Value = UpdatedBy ;

               rowAffect = this.RunProcedure(SP_KHACHHANG_PHANANH_UPDATE,parameters,rowAffect );
               return (rowAffect >0);
           }
           catch(Exception ex)
           {
               return false;
           }
       }
       /// <summary>
       /// xóa 1 loại phản ánh trong bảng
       /// và cập nhật lại thứ tự các loại phản ánh trong bảng
       /// </summary>
       /// <param name="iD"></param>
       /// <returns></returns>
       /// <modified>
       /// name         date        comments
       /// hangtm      17/5/2011    created
       /// </modified>
       public bool Delete(int id)
       {
           try
           {
               int rowAffect =0;
               SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter("@ID", SqlDbType.Int )
               
               };
               parameters[0].Value = id;

               rowAffect = this.RunProcedure(SP_KHACHHANG_PHANANH_DELETE,parameters,rowAffect  );
               return (rowAffect > 0);
           }
           catch(Exception ex)
           {
               return false;
           }
       }
       /// <summary>
       /// lấy ra bản ghi theo ID
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       /// <modified>
       /// name         date        comments
       /// hangtm       17/5/2011   created
       /// </modified>
       public DataTable GetByID(int id)
       {        
           DataSet ds = new DataSet();
           SqlParameter [] parameters = new SqlParameter[]
           {
                new SqlParameter ("@ID",SqlDbType.Int )
           };
           parameters[0].Value = id ;

           ds= this.RunProcedure(SP_KHACHHANG_PHANANH_GETBYID, parameters, "tblPhanAnh");
           return ds.Tables[0];
       }
       /// <summary>
       /// Lấy ra cả bảng Khách hàng Phản ánh
       /// </summary>
       /// <returns></returns>
      /// <modified>
       /// name         date        comments
       /// hangtm       17/5/2011   created
       /// </modified>
       public DataTable SelectAll()
       {
           DataSet ds = new DataSet();
            SqlParameter [] param = new SqlParameter[]
           {};

            ds= this.RunProcedure(SP_KHACHHANG_PHANANH_SELECTALL, param, "tblPhanAnh");
            return ds.Tables[0];
       }
       /// <summary>
       /// kiểm tra xem đã có tên nào trùng vơi tên vừa nhập chưa
       /// </summary>
       /// <param name="tenLoaiPhanAnh"></param>
       /// <returns></returns>
       /// <modified>
       /// name         date        comments
       /// hangtm       17/5/2011   created
       /// </modified>
       public bool CheckTen(string tenLoaiPhanAnh)
       {
           SqlParameter[] parameter = new SqlParameter[] { 
                new SqlParameter("@TenLoaiPhanAnh",SqlDbType.NVarChar ,150),
               new SqlParameter("@Count",SqlDbType.Int )            
           };
           parameter[0].Value = tenLoaiPhanAnh;
           parameter[1].Direction = ParameterDirection.Output;

           this.RunProcedure(SP_KHACHHANG_PHANANH_CheckTonTai,parameter,"tblPhanAnh");

           int iCount = int.Parse(parameter[1].Value.ToString());
           if (iCount > 0)
           {
               return true;
           }
           else
           {
               return false;
           }
       }
       /// <summary>
       /// sắp xếp lại thứ tự các mục phản ánh theo ý người dùng
       /// </summary>
       /// <param name="currentID"></param>
       ///  <param name="thuTu"></param>
       ///  <param name="Sort"></param>
       /// <returns></returns>
       /// <modified>
       /// name         date        comments
       /// hangtm       18/5/2011   created
       /// </modified>
       public bool SortDMPhanAnh(int currentID,int thuTu,int Sort)
       {
           try
           {
               int rowAffect =0;
               SqlParameter[] parameter = new SqlParameter[] { 
                new SqlParameter("@CurrentId",SqlDbType.Int),
               new SqlParameter("@ThuTu",SqlDbType.Int ),
               new SqlParameter ("@Sort",SqlDbType.Int )
                };
               parameter[0].Value = currentID;
               parameter[1].Value = thuTu;
               parameter[2].Value = Sort;
               rowAffect = this.RunProcedure(SP_KHACHHANG_PHANANH_SORT, parameter, rowAffect );
              return (rowAffect>0);
           }
           catch(Exception ex)
           {
               return false;
           }
          
       }

    }
}
