using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;
using Taxi.Common.Extender;

namespace Taxi.Data
{
    [TableInfo(TableName = "T_MESSAGES")]
    public class Msg : DbEntityBase<Msg>
    {
        [Field(IsKey = true, IsIdentity = true)]
        public int ID { get; set; }
        [Field]
        public string UserName { get; set; }
        [Field]
        public string IPAddress { get; set; }
        [Field]
        public string Subject { get; set; }
        [Field]
        public string Contents { get; set; }
        [Field]
        public DateTime Date { get; set; }
     //   [Field]
      //  public DateTime UpdateDate { get; set; }


        public List<Msg> GetData(string userName)
        {
            return ExeStore("sp_dh_GetDataByUserName_T_Message", userName).ToList<Msg>();
        }
    }
}
