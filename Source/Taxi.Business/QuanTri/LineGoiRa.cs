using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Taxi.Business.QuanTri
{
   public class LineGoiRa
    {
       public static bool Insert(string IP, string Line_Vung, string IsMayTinh, bool IsActive)
       {
           return new Data.QuanTri.LineGoiRa().Insert(IP, Line_Vung, IsMayTinh, IsActive);
       }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="ip"></param>
       /// <returns></returns>
       public static bool Delete(int id)
       {
           return new Data.QuanTri.LineGoiRa().Delete(id);
       }

       public static DataTable GetDSLineGoiRa()
       {
           return new Data.QuanTri.LineGoiRa().GetDSLineRa();
       }
    }
}
