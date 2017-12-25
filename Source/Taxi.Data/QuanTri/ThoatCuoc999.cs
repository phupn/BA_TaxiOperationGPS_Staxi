using System;
using System.Collections.Generic;
using System.Text;
using Taxi.Utils;
using System.Data.SqlClient;
using System.Data;

namespace Taxi.Data 
{
    public class ThoatCuoc999:DBObject
    {
        public bool InsertCauHinh(int vung, int soCuocGioiHan, int soPhutGioiHan, string nguoiTao)
        {
            int rowAffected=0;
			SqlParameter[] parameters = new SqlParameter[] { 
					new SqlParameter("@Vung", SqlDbType.Int),
					new SqlParameter("@SoCuocGioiHan", SqlDbType.Int),
                    new SqlParameter("@SoPhutGioiHan", SqlDbType.Int),
                    new SqlParameter("@NguoiTao", SqlDbType.NVarChar,50)
            };
			parameters[0].Value = vung ;
			parameters[1].Value =  soCuocGioiHan;
            parameters[2].Value = soPhutGioiHan;
            parameters[3].Value = nguoiTao;
            rowAffected = this.RunProcedure("[THOAT999.spInsert_T_CAUHINH_THOAT999]", parameters, rowAffected);
            return (rowAffected > 0);
        }

        public bool UpdateCauHinh(int vung, int soCuocGioiHan, int soPhutGioiHan, string nguoiSua)
        {
            int rowAffected = 0;
            SqlParameter[] parameters = new SqlParameter[] { 
					new SqlParameter("@Vung", SqlDbType.Int),
					new SqlParameter("@SoCuocGioiHan", SqlDbType.Int),
                    new SqlParameter("@SoPhutGioiHan", SqlDbType.Int),
                    new SqlParameter("@NguoiSua", SqlDbType.NVarChar,50)
            };
            parameters[0].Value = vung;
            parameters[1].Value = soCuocGioiHan;
            parameters[2].Value = soPhutGioiHan;
            parameters[3].Value = nguoiSua;
            rowAffected = this.RunProcedure("[THOAT999.spUpdate_T_CAUHINH_THOAT999]", parameters, rowAffected);
            return (rowAffected > 0);
        }

        public bool DeleteCauHinh(int vung)
        {
            int rowAffected = 0;
            SqlParameter[] parameters = new SqlParameter[] { 
					new SqlParameter("@Vung", SqlDbType.Int) 
            };
            parameters[0].Value = vung;
            rowAffected = this.RunProcedure("[THOAT999.spDelete_T_CAUHINH_THOAT999]", parameters, rowAffected);
            return (rowAffected > 0);
        }

        public DataTable GetAllCauHinh()
        {
            
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@Vung", SqlDbType.Int) 
            };
            parameters[0].Value = 0;  // lay tat ca
            return this.RunProcedure("[THOAT999.spSelect_T_CAUHINH_THOAT999]", parameters, "tblLog").Tables[0];
        }
        public DataTable GetCauHinhByVung(int vung)
        {

            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@Vung", SqlDbType.Int) 
            };
            parameters[0].Value = vung;  // lay tat ca
            return this.RunProcedure("[THOAT999.spSelect_T_CAUHINH_THOAT999]", parameters, "tblLog").Tables[0];
        }

        public DataTable GetCauHinhBATTATByVung(int vung)
        {
            //[THOAT999.spSelect_CauHinhBATTATByVung]  
            //    -- Add the parameters for the stored procedure here
            //     @Vung INT  
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@Vung", SqlDbType.Int) 
            };
            parameters[0].Value = vung;  // lay tat ca
            return this.RunProcedure("[THOAT999.spSelect_CauHinhBATTATByVung]", parameters, "tblLog").Tables[0];
        }

        /// <summary>
        /// trả về  T3.Vung,T3.GioiHanSoCuocDuocBat,T3.SoCuocHienTai,T4.ThoiDiemBatDau999,T4.ThoiDiemKetThuc999,T4.NguoiBat
        /// </summary>
        /// <returns></returns>
        public DataTable GetThongTinCauHinhBatCuoc()
        {
            SqlParameter[] parameters = new SqlParameter[] {                 
            };
            return this.RunProcedure("[THOAT999.spLayThongTinDatCauHinhThoat999HienTai]", parameters, "tblLog").Tables[0];
        }

        public bool BatThoatCuoc999(int vung, string nguoiBat)
        {
            int rowAffected = 0;
            SqlParameter[] parameters = new SqlParameter[] { 
					new SqlParameter("@Vung", SqlDbType.Int), 
                    new SqlParameter("@NguoiBat", SqlDbType.NVarChar,50)
            };
            parameters[0].Value = vung;
            parameters[1].Value = nguoiBat;
         
            rowAffected = this.RunProcedure("[THOAT999.spBatThoat999]", parameters, rowAffected);
            return (rowAffected > 0);
        }

        public bool  TatThoatCuoc999(int vung, string nguoiTat)
        {
            int rowAffected = 0;
            SqlParameter[] parameters = new SqlParameter[] { 
					new SqlParameter("@Vung", SqlDbType.Int), 
                    new SqlParameter("@NguoiTat", SqlDbType.NVarChar,50)
            };
            parameters[0].Value = vung;
            parameters[1].Value = nguoiTat;

            rowAffected = this.RunProcedure("[THOAT999.spTatThoat999]", parameters, rowAffected);
            return (rowAffected > 0);
        }

        
    }
}
