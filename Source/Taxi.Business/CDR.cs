using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Taxi.Business
{
    public class CDR
    {
        /// <summary>
        /// hafm thuc hien lay ra cac cuoc goi cua he thong PBX IP
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="isIncomming">true : cuoc goi den, false cuoc goi di</param>
        /// <returns></returns>
        public static List<CDRPBXIPEntity> GetCDRs(DateTime from, DateTime to, string line, string phone, bool isIncomming)
        {
            List<CDRPBXIPEntity> list = new List<CDRPBXIPEntity>();

            try
            {
                // laays ds cuoc goi
                DataTable dt = new Taxi.Data.CDR().GetCDRs(from, to, line, phone, isIncomming);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        CDRPBXIPEntity cdr = new CDRPBXIPEntity();
                        cdr.callDate = dr["calldate"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(dr["calldate"].ToString());

                        if (isIncomming)
                        {
                            cdr.src = dr["src"].ToString();
                            cdr.dst = dr["dst"].ToString();
                        }
                        else
                        {
                            cdr.src = dr["dst"].ToString();
                            cdr.dst = dr["src"].ToString();
                        }

                        cdr.bells = dr["bells"] == DBNull.Value ? 0 : int.Parse(dr["bells"].ToString());
                        cdr.duration = dr["duration"] == DBNull.Value ? 0 : int.Parse(dr["duration"].ToString());
                        cdr.fileVoicePath = dr["FileVoicePath"].ToString();
                        cdr.disposition = dr["disposition"].ToString();
                        cdr.isUsed = false;

                        list.Add(cdr);

                    }
                  
                }
            }
            catch (Exception exx)
            {
               
            }
            return list;
        }


    }
}
