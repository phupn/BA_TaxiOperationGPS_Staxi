using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Taxi.Business.DM
{
   public  class CongTy
    {
       /// <summary>
       /// hamf tra ve ds cong ty (DataTable)
       /// CongTyID TenCongTy
       /// </summary>
       /// <returns></returns>
       public static  DataTable GetAllDSCongTy()
       {
           return new Data.DM.Congty().GetAllDSCongTy();
       }

       /// <summary>
       /// fill to Combobox
       /// </summary>
       /// <returns>Tat ca Cong Ty (CongTyID + [TenCongTy])</returns>
       public static DataTable GetListOfCongTys_NAME()
       {
           return new Taxi.Data.DM.Congty().GetListOfCongTys_NAME();
       }
    }
}
