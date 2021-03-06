using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Taxi.Utils;
using System.Data.SqlClient;

namespace Taxi.Data
{
    public class ManHinhDA : DBObject
    {
        /// <summary>
        /// Trả về nội dung tin nhắn mới co tin nhan moi
        /// </summary>
        /// <param name="Vung">Vung</param>
        /// <param name="GuiChoAi">Bo Phan</param>
        /// <returns></returns>
        public DataTable GetNewManHinh(string Vung, string GuiChoAi)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Vung",SqlDbType.VarChar,20 ),
                    new SqlParameter("@GuiChoAi",SqlDbType.VarChar,2 )
                };
                parameters[0].Value = Vung;
                parameters[1].Value = GuiChoAi;

                return RunProcedure("V3_MANHINH_GETALL", parameters, "tblManHinh").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Trả về nội dung tin nhắn mới co tin nhan moi_Loc chi lay nhung tin nhan moi
        /// </summary>
        /// <param name="Vung">Vung</param>
        /// <param name="GuiChoAi">Bo Phan</param>
        /// <param name="ThoiDiemChen">Thoi Diem Chen cua Lai Xe</param>
        /// <returns></returns>
        public DataTable GetNewManHinh_ThoiDiemChen(string Vung, string GuiChoAi, DateTime ThoiDiemChen)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Vung",SqlDbType.VarChar,20 ),
                    new SqlParameter("@GuiChoAi",SqlDbType.VarChar,2 ),
                    new SqlParameter("@ThoiDiemChen",SqlDbType.DateTime )
                };
                parameters[0].Value = Vung;
                parameters[1].Value = GuiChoAi;
                parameters[2].Value = ThoiDiemChen;

                return RunProcedure("V3_MANHINH_GETALL_THOIDIEMCHEN", parameters, "tblManHinh").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Cap nhat thong tin cuoc goi theo thong tin lai xe gui ve
        /// </summary>
        /// <param name="_Id"></param>
        /// <param name="_IDCuocGoi"></param>
        /// <param name="_SoHieuXe"></param>
        /// <param name="_TinNhan"></param>
        /// <param name="_GuiChoAi"></param>
        /// <param name="_LoaiTinNhan"></param>
        /// <returns></returns>
        public bool UpdateCuocGoi_ByManHinh(string _Id, long _IDCuocGoi, string _SoHieuXe, string _TinNhan, string _GuiChoAi, string _LoaiTinNhan,string _XeNhan, string _XeDon)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IDManHinh",SqlDbType.VarChar,50 ),
                    new SqlParameter("@LoaiTinNhan",SqlDbType.NVarChar,250 ),
                    new SqlParameter("@SoHieuXe",SqlDbType.VarChar,16 ),
                    new SqlParameter("@TinNhan",SqlDbType.NVarChar,250 ),                    
                    new SqlParameter("@FK_CuocGoiID",SqlDbType.BigInt ),
                    new SqlParameter("@GuiChoAi",SqlDbType.VarChar,2 ),
                    new SqlParameter("@XeNhan",SqlDbType.VarChar,50 ),
                    new SqlParameter("@Output",SqlDbType.Bit)
                };
                parameters[0].Value = _Id;
                parameters[1].Value = _LoaiTinNhan;
                parameters[2].Value = _SoHieuXe;
                parameters[3].Value = _TinNhan;
                parameters[4].Value = _IDCuocGoi;
                parameters[5].Value = _GuiChoAi;
                parameters[6].Value = _XeNhan;
                parameters[7].Direction = ParameterDirection.Output;

                RunProcedure("V3_CUOCGOI_UPDATE_BY_MANHINH", parameters, rowsAffected);

                return (int)parameters[7].Value > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// chuyen tin nhan man hinh sang ket thuc
        /// </summary>
        /// <param name="_Id"></param>
        /// <returns></returns>
        public bool DeleteManHinh(string _Id)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.VarChar,50 )
                };
                parameters[0].Value = _Id;
                return RunProcedure("V3_MANHINH_DELETE", parameters, rowsAffected) > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
