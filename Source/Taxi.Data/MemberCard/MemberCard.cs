using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Taxi.Utils;

namespace Taxi.Data.DM
{
    public class MemberCard : DBObject
    {
        public int Insert(string _Name, string _Address, string _Type, string _Code, string _Note, 
            DateTime _DateOfIssue, DateTime _ExpDate, bool _Active)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Name",SqlDbType.NVarChar,100),
                    new SqlParameter("@Address",SqlDbType.NVarChar,200),
                    new SqlParameter("@Type",SqlDbType.NVarChar, 20),
                    new SqlParameter("@Code",SqlDbType.VarChar,50),
                    new SqlParameter("@Note",SqlDbType.NVarChar,50),
                    new SqlParameter("@DateOfIssue",SqlDbType.DateTime),
                    new SqlParameter("@ExpireDate",SqlDbType.DateTime),
                    new SqlParameter("@Active",SqlDbType.Bit),
                    new SqlParameter("@ID",SqlDbType.BigInt)
                    
                };
                parameters[0].Value = _Name;
                parameters[1].Value = _Address;
                parameters[2].Value = _Type;
                parameters[3].Value = _Code;
                parameters[4].Value = _Note;
                parameters[5].Value = _DateOfIssue;
                parameters[6].Value = _ExpDate;
                parameters[7].Value = _Active;
                parameters[8].Direction = ParameterDirection.Output;

                rowAffected = this.RunProcedure("SP_MEMBERCARD_INSERT", parameters, rowAffected);
                if (rowAffected > 0)
                {
                    return int.Parse(parameters[8].Value.ToString());
                }
                return -1;
            }
            catch
            {
                return -1;
            }

        }

        public bool Update(int ID, string _Name, string _Address, string _Type, string _Code, string _Note, 
            DateTime _DateOfIssue, DateTime _ExpDate, bool _Active)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                   new SqlParameter("@Name",SqlDbType.NVarChar,100),
                    new SqlParameter("@Address",SqlDbType.NVarChar,200),
                    new SqlParameter("@Type",SqlDbType.NVarChar, 20),
                    new SqlParameter("@Code",SqlDbType.VarChar,50),
                    new SqlParameter("@Note",SqlDbType.NVarChar,50),
                    new SqlParameter("@DateOfIssue",SqlDbType.DateTime),
                    new SqlParameter("@ExpireDate",SqlDbType.DateTime),
                    new SqlParameter("@Active",SqlDbType.Bit),
                    new SqlParameter("@ID",SqlDbType.BigInt)
                };
                parameters[0].Value = _Name;
                parameters[1].Value = _Address;
                parameters[2].Value = _Type;
                parameters[3].Value = _Code;
                parameters[4].Value = _Note;
                parameters[5].Value = _DateOfIssue;
                parameters[6].Value = _ExpDate;
                parameters[7].Value = _Active;
                parameters[8].Value = ID;

                rowAffected = this.RunProcedure("SP_MEMBERCARD_UPDATE", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public System.Data.DataTable GetMemberCardByID(int ID)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.BigInt  )                    
                };
            parameters[0].Value = ID;

            return this.RunProcedure("SP_MEMBERCARD_GETBYID", parameters, "tblGara").Tables[0];
        }

        public System.Data.DataTable GetAllMemberCard()
        {
            SqlParameter[] parameters = new SqlParameter[] {                                     
                };

            return this.RunProcedure("SP_MEMBERCARD_GETALL", parameters, "tblGara").Tables[0];
        }

        public bool Delete(int ID)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                   new SqlParameter("@ID",SqlDbType.BigInt  )   
                };
                parameters[0].Value = ID;


                rowAffected = this.RunProcedure("SP_MEMBERCARD_DELETE", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool CheckTonTaiMaThe(string _Code)
        {
            int rowAffected = 0;
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Code",SqlDbType.VarChar,50)     
                };
            parameters[0].Value = _Code;

            return this.RunProcedure("T_MEMBER_CARD_CHECK_EXIST_CODE", parameters, rowAffected) > 0;
        }

        public DataTable GetMemberCard_ByCode(string _Code)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Code",SqlDbType.VarChar, 50  )                    
                };
            parameters[0].Value = _Code;

            return this.RunProcedure("SP_MEMBERCARD_GETBYCODE", parameters, "tblGara").Tables[0];
        }

        public DataTable GetMemberCard_BySearch(string _Code, string _Name, string _Address)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Code",SqlDbType.VarChar, 50  ),
                    new SqlParameter("@Name",SqlDbType.NVarChar,100),
                    new SqlParameter("@Address",SqlDbType.NVarChar,200),
                };
            parameters[0].Value = _Code;
            parameters[1].Value = _Name;
            parameters[2].Value = _Address;

            return this.RunProcedure("SP_MEMBERCARD_GETBYSEARCH", parameters, "tblGara").Tables[0];
        }
    }
}
