using System;
using System.Data;
using Taxi.Utils;
using System.Data.SqlClient;

namespace Taxi.Data
{
    public class CuocGoiDi : DBObject
    {
        /// <summary>
        /// Line, PhoneNumber,ThoiDiemGoi,DoDaiCuocGoi,VoiceFilePath
        /// </summary>
        /// <returns></returns>
        public bool Insert(string Line,string PhoneNumber,DateTime ThoiDiemGoi,DateTime DoDaiCuocGoi,string VoiceFilePath)
        {
            try
            {
                
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Line",SqlDbType.VarChar,2),
                    new SqlParameter("@PhoneNumber",SqlDbType.VarChar ,11 ),
                    new SqlParameter("@ThoiDiemGoi",SqlDbType.DateTime ) ,
                    new SqlParameter("@DoDaiCuocGoi",SqlDbType.DateTime ) ,
                    new SqlParameter("@VoiceFilePath",SqlDbType.VarChar ,255)                   
                };
                parameters[0].Value = Line ;
                parameters[1].Value = PhoneNumber;
                parameters[2].Value = ThoiDiemGoi ;
                parameters[3].Value = DoDaiCuocGoi ;
                parameters[4].Value = VoiceFilePath ;

                rowAffected = this.RunProcedure("sp_T_TAXIOPERATION_CUOCGOIDI_Insert", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public DataTable Select(DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                //@TuNgayGio datetime,
                //@DenNgayGio datetime      
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgayGio",SqlDbType.DateTime ),
                    new SqlParameter("@DenNgayGio",SqlDbType.DateTime )
                };
                parameters[0].Value = TuNgay;
                parameters[1].Value = DenNgay;

                return this.RunProcedure("sp_T_TAXIOPERATION_CUOCGOIDI_Select", parameters, "tblDienThoaiCuocGoiDi").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }            
        }

        public bool  Delete(DateTime TuNgay, DateTime DenNgay)
        {
            int rowAffected = 0;
            try
            {
                //@TuNgayGio datetime,
                //@DenNgayGio datetime      
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgayGio",SqlDbType.DateTime ),
                    new SqlParameter("@DenNgayGio",SqlDbType.DateTime )
                };
                parameters[0].Value = TuNgay;
                parameters[1].Value = DenNgay;
                rowAffected = this.RunProcedure("sp_T_TAXIOPERATION_CUOCGOIDI_Delete", parameters, rowAffected);
                 return (rowsAffected > 0);
            }
            catch (Exception ex)
            {
                return false ;
            }
        }


        /// <summary>
        /// get thông tin cuocọ gọi đi
        /// 1. Duration <> 0 , Phonumber =""
        ///    --> TÌm thoeo Duration
        /// else Phonum
        /// </summary>
        /// <param name="TuNgayGio"></param>
        /// <param name="DenNgayGio"></param>
        /// <param name="Duration"></param>
        /// <param name="PhoneNumber"></param>
        /// <returns></returns>
        public DataTable GetDSCuocGoiDi(DateTime TuNgayGio, DateTime DenNgayGio, DateTime Duration, string PhoneNumber, string Line)
        {
           // @TuNgayGio datetime,
           //@DenNgayGio datetime,
           //@Line varchar(2),
           //@Duration datetime,
           //@PhoneNumber varchar(11)=''   
              try
            {
                //@TuNgayGio datetime,
                //@DenNgayGio datetime      
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgayGio",SqlDbType.DateTime ),
                    new SqlParameter("@DenNgayGio",SqlDbType.DateTime ), 
                    new SqlParameter("@Line",SqlDbType.VarChar,2 ),
                    new SqlParameter("@Duration",SqlDbType.DateTime ),
                    new SqlParameter("@PhoneNumber",SqlDbType.VarChar,11 )
                };
                parameters[0].Value = TuNgayGio;
                parameters[1].Value = DenNgayGio;
                parameters[2].Value = Line;
                parameters[3].Value = Duration;
                parameters[4].Value = PhoneNumber;

                return this.RunProcedure("sp_T_TAXIOPERATION_CUOCGOIDI_SelectByPhoneNumberDuration", parameters, "tblDienThoaiCuocGoiDi").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }            
        }


        /// <summary>
        /// hafm tra ve ds cuoc goi gan nhat cua thoi diem goi, gan day 30 s
        /// </summary>
        /// <param name="SoDienThoai"></param>
        /// <param name="ThoiDiem"></param>
        /// <returns></returns>
        public DataTable GetFileGhiAmCuocGoiDi(string SoDienThoai, DateTime ThoiDiem)
        {
            //[sp_T_TAXIOPERATION_CUOCGOIDI_SelectByPhoneNumber]		  
            //   @ThoiDiemGoi datetime, 
            //   @PhoneNumber varchar(11) 

            try
            {
                     
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ThoiDiemGoi",SqlDbType.DateTime ), 
                    new SqlParameter("@PhoneNumber",SqlDbType.VarChar,11 )
                };
                parameters[0].Value = ThoiDiem ;
                parameters[1].Value = SoDienThoai;


                return this.RunProcedure("sp_T_TAXIOPERATION_CUOCGOIDI_SelectByPhoneNumber", parameters, "tblDienThoaiCuocGoiDi").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }       
        }

        public DataTable GetDSCuocGoiDi(DateTime TuNgayGio, DateTime DenNgayGio, DateTime Duration, string PhoneNumber, string Line, string NhanVienID, string PhanLoai)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgayGio",SqlDbType.DateTime ),
                    new SqlParameter("@DenNgayGio",SqlDbType.DateTime ), 
                    new SqlParameter("@Line",SqlDbType.VarChar,2 ),
                    new SqlParameter("@PhoneNumber",SqlDbType.VarChar,11 ),
                    new SqlParameter("@DoDaiCuocGoi",SqlDbType.DateTime ),
                    new SqlParameter("@NhanVien",SqlDbType.NVarChar,50 ),
                    new SqlParameter("@ThuocViTri",SqlDbType.VarChar,2 )
                };
                parameters[0].Value = TuNgayGio;
                parameters[1].Value = DenNgayGio;
                if(Line!=string.Empty )
                    parameters[2].Value = Line;
                if(PhoneNumber != string.Empty) 
                    parameters[3].Value = PhoneNumber;
                parameters[4].Value = Duration ;
                if(NhanVienID != string.Empty)
                    parameters[5].Value = NhanVienID;
                if(PhanLoai!=string.Empty)
                    parameters[6].Value = PhanLoai;
                return this.RunProcedure("sp_T_TAXIOPERATION_CUOCGOIDI_Select2", parameters, "tblDienThoaiCuocGoiDi").Tables[0];
            }
            catch
            {
                return null;
            }            
        }
    }
}
