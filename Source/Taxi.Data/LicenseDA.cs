using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Taxi.Utils;

namespace Taxi.Data
{
    public class LicenseDA : DBObject
    {
        public bool UpdateLicense(string LicenseKey, DateTime FromDate, DateTime ToDate)
        {
            int rowAffected = 0;
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@LicenseKey",SqlDbType.NVarChar ,500),
                    new SqlParameter("@FromDate",SqlDbType.DateTime),
                    new SqlParameter("@ToDate",SqlDbType.DateTime)                  
                };
            parameters[0].Value = LicenseKey;
            parameters[1].Value = FromDate;
            parameters[2].Value = ToDate;

            rowAffected = this.RunProcedure("SP_SYS_LICENSE_UPDATE", parameters, rowAffected);
            return rowAffected > 0;
        }

        public DataTable GetLicense()
        {
            SqlParameter[] parameters = new SqlParameter[] {};

            return this.RunProcedure("SP_SYS_LICENSE_GET", parameters, "tblUser").Tables[0];
        }
    }
}
