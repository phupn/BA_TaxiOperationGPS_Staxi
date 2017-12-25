using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
using System;

namespace Taxi.Data.BanCo.Entity.GiamSatXe
{
    [TableInfo(TableName = "BanCo_Config")]
    public class ConfigurationStatusModel : TaxiOperationDbEntityBase<ConfigurationStatusModel>
    {
        #region Properties
// = SqlInt16.Null;
        [Field(IsKey = true, IsIdentity = true)]
        public int Id { get; set; }
// = string.Null;
        [Field]
        public string Name { get; set; }
// = string.Null;
        [Field]
        public string Value { get; set; }
// = bool.True;
        [Field]
        public bool Notify { get; set; }
// = 1;
        [Field]
        public int Type { get; set; }
//= DateTime.Null;
        [Field]
        public DateTime DateCreated { get; set; }
// = string.Null;
        [Field]
        public string Description { get; set; }
        #endregion

        #region Method
        public List<ConfigurationStatusModel> GetAllData()
        {
            return GetAll().ToList<ConfigurationStatusModel>();
        }

        public DataTable GetAllData_Datatable()
        {
            return GetAll();
        }
        public List<ConfigurationStatusModel> GetList()
        {
            return GetAll().ToList<ConfigurationStatusModel>();
        }
        public void ShTest()
        {
            var p1 = 0;
            var p2 = 0;
            var result = this.ExeStoreNoneQueryWithOutput("sh_Test", p1, p2);

            p2 = result.Value["p2"].To<int>();
        }

        public int GetValue(params object[] para) {
            int value =0;
            DataTable dtValue = new DataTable();
            dtValue = ExeStore("SP_BanCo_Get_Config_GetValue", para);
            if (dtValue.Rows.Count > 0) {
                value= Convert.ToInt32(dtValue.Rows[0]["Value"].ToString());
            }
            return value;
        }
        #endregion
    }
}
