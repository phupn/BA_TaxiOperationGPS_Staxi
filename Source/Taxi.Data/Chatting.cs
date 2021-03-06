using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Taxi.Utils;
using System.Data.SqlClient;

namespace Taxi.Data
{
    public class Chatting : DBObject
    {
        /// <summary>
        /// Insert noi dung tin nhan
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="IPAddress"></param>
        /// <param name="ToUserName"></param>
        /// <param name="ToIPAddress"></param>
        /// <param name="Subject"></param>
        /// <param name="Contents"></param>
        /// <param name="Date"></param>
        /// <param name="Priority"></param>
        /// <param name="status">trạng thái luôn luôn hiển thị tin nhắn trên màn hình</param>
        /// <param name="ListToUserName">mang tai khoan - fullname</param>
        /// <returns></returns>
        public bool Insert(string UserName, string IPAddress, string ToUserName,
                        string ToIPAddress, string Subject, string Contents, DateTime Date, int Priority, bool status, string ListToUserName)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@UserName",SqlDbType.NVarChar,50),
                    new SqlParameter("@IPAddress",SqlDbType.VarChar ,20 ),
                    new SqlParameter("@ToUserName",SqlDbType.Text),                    
                    new SqlParameter("@ToIPAddress",SqlDbType.Text),
                    new SqlParameter("@Subject",SqlDbType.NVarChar ,100),
                    new SqlParameter("@Contents",SqlDbType.NVarChar ,1000),
                    new SqlParameter("@Date",SqlDbType.DateTime),
                    new SqlParameter("@Priority",SqlDbType.TinyInt),
                    new SqlParameter("@Status",SqlDbType.Bit),
                    new SqlParameter("@ListToUserName",SqlDbType.NVarChar, 4000)
                };
                parameters[0].Value = UserName;
                parameters[1].Value = IPAddress;
                parameters[2].Value = ToUserName;
                parameters[3].Value = ToIPAddress;
                parameters[4].Value = Subject;
                parameters[5].Value = Contents;
                parameters[6].Value = Date;
                parameters[7].Value = Priority;
                parameters[8].Value = status;
                parameters[9].Value = ListToUserName;

                rowAffected = this.RunProcedure("SP_T_MESSAGES_INSERT", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Gửi lại tin nhắn
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool Insert_Resend(int Id)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Id",SqlDbType.Int)
                };
                parameters[0].Value = Id;

                rowAffected = RunProcedure("SP_T_MESSAGES_INSERT_RESEND", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }


        /// <summary>
        /// Update trang thai tin nhan
        /// </summary>
        /// <returns></returns>
        public bool Update(int IDMessage, string UserName, string IPAddress)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IDMessage",SqlDbType.Int),
                    new SqlParameter("@ToUserName",SqlDbType.NVarChar,50),
                    new SqlParameter("@ToIPAddress",SqlDbType.VarChar ,20 )
                };
                parameters[0].Value = IDMessage;
                parameters[1].Value = UserName;
                parameters[2].Value = IPAddress;

                rowAffected = this.RunProcedure("SP_T_MESSAGES_UPDATE", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Update trang thai (luon luon hien thi) cua tin nhan
        /// </summary>
        /// <returns></returns>
        public bool Update_Status(int IDMessage, bool Status)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IDMessage",SqlDbType.Int),
                    new SqlParameter("@Status",SqlDbType.Bit)
                };
                parameters[0].Value = IDMessage;
                parameters[1].Value = Status;

                rowAffected = this.RunProcedure("SP_T_MESSAGES_UPDATE_STATUS", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Select noi dung chat trong ngay hien tai
        /// </summary>
        /// <returns></returns>
        public DataTable SelectByUserName(string UserName, DateTime date, int isAdmin)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@UserName",SqlDbType.NVarChar,50 ),
                    new SqlParameter("@Date",SqlDbType.DateTime),
                    new SqlParameter("@isAdmin",SqlDbType.SmallInt),
                };
                parameters[0].Value = UserName;
                parameters[1].Value = date;
                parameters[2].Value = isAdmin;
                return this.RunProcedure("SP_T_MESSAGES_SELECT_USER", parameters, "tblMessage").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Select chi tiet noi dung chat
        /// </summary>
        /// <returns></returns>
        public DataTable SelectByUserName_Top_Detail(string UserName, int isAdmin)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@UserName",SqlDbType.NVarChar,50 ),
                    new SqlParameter("@isAdmin",SqlDbType.SmallInt)
                };
                parameters[0].Value = UserName;
                parameters[1].Value = isAdmin;
                return this.RunProcedure("SP_T_MESSAGES_SELECT_TOP_DETAIL", parameters, "tblMessageDetail").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Kiem tra co tin nhan moi
        /// </summary>
        public int CheckNewMessage(string UserName)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] 
                {
                    new SqlParameter("@UserName",SqlDbType.NVarChar,50)
                };
                parameters[0].Value = UserName;

                return (this.RunProcedure("SP_T_MESSAGES_SELECT_USER_CHECK", parameters, "tblMessage").Tables[0]).Rows.Count;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Trả về nội dung tin nhắn mới co tin nhan moi
        /// </summary>
        /// <returns></returns>
        public DataTable GetNewMessage(string UserName)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@UserName",SqlDbType.NVarChar,50 )
                };
                parameters[0].Value = UserName;

                return RunProcedure("SP_T_MESSAGES_SELECT_NEW_MSG_USER", parameters, "tblMessage").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Select noi dung chat theo Id
        /// </summary>
        /// <returns></returns>
        public DataTable SelectByID(int Id)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Id",SqlDbType.Int )
                };
                parameters[0].Value = Id;

                return RunProcedure("SP_T_MESSAGES_SELECT_BY_ID", parameters, "tblMessage").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Select cac Tai khoan dang check in
        /// </summary>
        /// <returns></returns>
        public DataTable SelectUserCheckIn()
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] { };

                return this.RunProcedure("SP_T_MESSAGES_SELECT_USER_CHECKIN", parameters, "tblAccount").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Select danh sách cac Tai khoan và hoat động
        /// </summary>
        /// <returns>
        /// Trả về danh sách nhân viên của hệ thống + IP address
        /// + Thời điểm checkout, check in
        /// </returns>
        public DataTable SelectListUser_CheckIn()
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] { };

                return RunProcedure("SP_T_MESSAGES_SELECT_USER_FULL_INFO", parameters, "tblAccount").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Select vung
        /// </summary>
        /// <returns></returns>
        public DataTable SelectVung()
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] { };

                return this.RunProcedure("SP_T_TAXIOPERATION_PARAMETER_GET_VUNGTONGDAI", parameters, "tblVung").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Select Line
        /// </summary>
        /// <returns></returns>
        public DataTable SelectLine()
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] { };

                return this.RunProcedure("SP_T_TAXIOPERATION_PARAMETER_GET_LINECUATAXI", parameters, "tblLine").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// select tat ca noi dung chat theo thang
        /// </summary>
        /// <returns></returns>
        public DataTable SelectMultiByUserName_Month(string UserName, int Month, int Year)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@UserName",SqlDbType.NVarChar,50 ),
                    new SqlParameter("@Month",SqlDbType.Int ),
                    new SqlParameter("@Year",SqlDbType.Int )
                };
                parameters[0].Value = UserName;
                parameters[1].Value = Month;
                parameters[2].Value = Year;

                return this.RunProcedure("SP_T_MESSAGES_SELECT_MULTI_USER_MONTH", parameters, "tblMessage").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// select tat ca noi dung chat
        /// </summary>
        /// <returns></returns>
        public DataTable SelectMultiByUserName(string UserName)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@UserName",SqlDbType.NVarChar,50)
                };
                parameters[0].Value = UserName;

                return this.RunProcedure("SP_T_MESSAGES_SELECT_MULTI_USER", parameters, "tblMessage").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// select Message Template
        /// </summary>
        /// <returns></returns>
        public DataTable SelectMessageTemplate()
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                };

                return this.RunProcedure("SP_T_MESSAGES_TEMPLATE", parameters, "tblMessageTemplate").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Insert Message Template
        /// </summary>
        /// <returns></returns>
        public bool Insert_MessageTemplate(string Subject, string Contents)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Subject",SqlDbType.NVarChar ,100),
                    new SqlParameter("@Contents",SqlDbType.NVarChar ,1000)
                };
                parameters[0].Value = Subject;
                parameters[1].Value = Contents;

                rowAffected = this.RunProcedure("SP_T_MESSAGES_TEMPLATE_INSERT", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Update Message Template
        /// </summary>
        /// <returns></returns>
        public bool Update_MessageTemplate(int Id, string Subject, string Contents)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Id",SqlDbType.Int),
                    new SqlParameter("@Subject",SqlDbType.NVarChar ,100),
                    new SqlParameter("@Contents",SqlDbType.NVarChar ,1000)
                };
                parameters[0].Value = Id;
                parameters[1].Value = Subject;
                parameters[2].Value = Contents;

                rowAffected = this.RunProcedure("SP_T_MESSAGES_TEMPLATE_UPDATE", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Update Message Template
        /// </summary>
        /// <returns></returns>
        public bool Delete_MessageTemplate(int Id)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Id",SqlDbType.Int)
                };
                parameters[0].Value = Id;

                rowAffected = this.RunProcedure("SP_T_MESSAGES_TEMPLATE_DELETE", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }


    }
}
