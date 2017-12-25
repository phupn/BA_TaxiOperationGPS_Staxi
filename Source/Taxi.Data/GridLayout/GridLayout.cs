using System;
using System.Collections.Generic;
using System.Text;
using Taxi.Utils;
using System.Data;
using System.Data.SqlClient;

namespace Taxi.Data.GridLayout
{
    public class GridLayout: DBObject 
    { 
         #region GRID_DIENTHOAI
        /// <summary>
        /// Lưu giai trị mặc định của hệ thống vào lưới
        /// sp_T_GRID_LAYOUT_DEFAULT_UpdateGridDienThoaiDefaultChoGiaiQuyet
	    /// @gridDienThoaiDefault_ChoGiaiQuyet ntext
        /// 
        /// </summary>
        /// <param name="GridLayoutXMLData"></param>
        /// <returns></returns>
        public bool LuuGridLayOutDefalt_DienThoaiChoGiaiQuyet(string GridLayoutXMLData)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@gridDienThoaiDefault_ChoGiaiQuyet",SqlDbType.NText)                    
                };
                parameters[0].Value = GridLayoutXMLData; 

                rowAffected = this.RunProcedure("sp_T_GRID_LAYOUT_DEFAULT_UpdateGridDienThoaiDefaultChoGiaiQuyet", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        #endregion GRID_DIENTHOAI

        public DataTable  GetDuLieuLayOutMacDinh_RunSQLString(string SQL)
        {
            try
            {
                return this.RunSQL(SQL, "tbl");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Insert noi dung Layout
        /// </summary>
        /// <returns></returns>
        public bool InsertLayout(string User_Id, string AppName, string FormId,
                        string ControlId, string LayoutString)
        {
            try
            {
                int rowAffected = 0;
                IDataParameter[] parameters =
                {
                    new SqlParameter("@User_Id",SqlDbType.NVarChar,50),
                    new SqlParameter("@AppName",SqlDbType.NVarChar ,50 ),
                    new SqlParameter("@FormId",SqlDbType.VarChar,50),                    
                    new SqlParameter("@ControlId",SqlDbType.VarChar,50),
                    new SqlParameter("@LayoutString",SqlDbType.NText)
                };
                parameters[0].Value = User_Id;
                parameters[1].Value = AppName;
                parameters[2].Value = FormId;
                parameters[3].Value = ControlId;
                parameters[4].Value = LayoutString;

                rowAffected = this.RunProcedure("SYS_LAYOUT_SETTING_INSERT", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Update noi dung Layout
        /// </summary>
        public bool UpdateLayout(int Id, string LayoutString)
        {
            try
            {
                int rowAffected = 0;
                IDataParameter[] parameters =
                {
                    new SqlParameter("@Id",SqlDbType.Int),
                    new SqlParameter("@LayoutString",SqlDbType.NText)
                };
                parameters[0].Value = Id;
                parameters[1].Value = LayoutString;

                rowAffected = this.RunProcedure("SYS_LAYOUT_SETTING_UPDATE", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Select Layout
        /// </summary>
        public DataTable SelectLayout(string User_Id, string AppName, string FormId, string ControlId)
        {
            try
            {
                IDataParameter[] parameters =
                { 
                    new SqlParameter("@User_Id",SqlDbType.NVarChar,50),
                    new SqlParameter("@AppName",SqlDbType.NVarChar ,50 ),
                    new SqlParameter("@FormId",SqlDbType.VarChar,50),                    
                    new SqlParameter("@ControlId",SqlDbType.VarChar,50)
                };
                parameters[0].Value = User_Id;
                parameters[1].Value = AppName;
                parameters[2].Value = FormId;
                parameters[3].Value = ControlId;

                return this.RunProcedure("SYS_LAYOUT_SETTING_SELECT", parameters, "tblLine").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
