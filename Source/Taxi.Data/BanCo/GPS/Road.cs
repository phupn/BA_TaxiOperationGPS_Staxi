using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;

namespace Taxi.Data.BanCo.Entity.GPS
{
    [TableInfo(TableName="[GPS.T_ROAD]")]
    public class T_Road:TaxiOperationDbEntityBase<T_Road>
    {
        [Field(IsKey=true)]
        [ValueField]
        public int ID { get; set; }

        [Field]
        [ColumnField(ColumnName = "Đường")]
        public string Road { get; set; }
        [Field]
        [DisplayField]
        public string NameVN { get; set; }
        [Field]
        public int FK_DistrictID { get; set; }

        [Field]
        public string VietTat { set; get; }

        public string TenDuongMoi { set; get; }

        public List<T_Road> GetListAll()
        {
          //  return this.GetAll().ToList<T_Road>();
            List<T_Road> listRet = this.GetAll().ToList<T_Road>();

            foreach (T_Road obj in listRet)
            {
                if (String.IsNullOrEmpty(obj.VietTat))
                    obj.TenDuongMoi = obj.NameVN;
                else
                    obj.TenDuongMoi = String.Format("{0}_{1}", obj.VietTat, obj.NameVN);
            }

            return listRet;
        }
    }
}
