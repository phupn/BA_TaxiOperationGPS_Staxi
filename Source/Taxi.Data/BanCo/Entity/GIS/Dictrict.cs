using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;

namespace Taxi.Data.BanCo.Entity.GIS
{
    [TableInfo(TableName="[GIS.T_DISTRICT]")]
    public class District : TaxiOperationDbEntityBase<District>
    {
        [Field(IsKey=true)]
        public int PK_DistrictID { get; set; }

        [Field]
        public string NameEN { get; set; }
        
        [Field]
        public string NameVN { get; set; }

        [Field]
        public string VietTat { set; get; }

        public string TenQuanMoi { set; get; }

        public List<District> GetListAll()
        {
            return this.GetAll().ToList<District>();
        }

        public List<District> GetListByProvince(params object[] para)
        {
            List<District> listRet = ExeStore("SP_GIS_T_DISTRICT_GETBYID", para).ToList<District>();

            foreach (District obj in listRet)
            {
                if (String.IsNullOrEmpty(obj.VietTat))
                    obj.TenQuanMoi = obj.NameVN;
                else
                    obj.TenQuanMoi = String.Format("{0}_{1}", obj.VietTat, obj.NameVN);
            }

            return listRet;
        }
    }
}
