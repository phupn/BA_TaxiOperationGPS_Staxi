using System;
using System.Collections.Generic;
using Taxi.Common.Extender;

namespace StaxiMan_DAL
{
    public class DALCommon : DBServices<DALCommon>
    {
        /// <summary>
        /// Ham tra ve thoi gian hien tai cua may chu
        /// </summary>
        public DateTime GetTimeServer()
        {
            try
            {
                var result = this.ExeStoreWithOutput("sp_GetDateTimeServer", DateTime.MinValue);
                return (DateTime)result.Value.Items[0].Value;
            }
            catch (Exception ex)
            {
                Taxi.Logger.LogError.WriteLogError("GetTimeServer", ex);
                return DateTime.MinValue;
            }
        }
        private static List<Company> _ListCompany;
        public static List<Company> ListCompany
        {
            get
            {
                if (_ListCompany == null)
                {
                    _ListCompany = Company.Inst.GetAll().ToList<Company>();  
                }  
                return _ListCompany;
            }
            set { _ListCompany = value; }
        }
    }
}
