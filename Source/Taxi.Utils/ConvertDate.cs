using System;
using System.Collections.Generic;
using System.Text;

namespace Taxi.Utils
{
    public class ConvertDate
    {        
        public static string DefaultDate()
        {
            return "01/01/1899";        
        }
        public static string DefaultLongDate()
        {
            return "01/01/1899 12:00:00 AM";
        }
        
        private string DateToChar(string dtDate)//dd/MM/yyyy
        {
            string strDay = dtDate.Substring(0, 2);
            string strMonth = dtDate.Substring(3, 2);
            string strYear = dtDate.Substring(6, 4);
            switch (strMonth)
            {
                case "01":
                    strMonth = "Jan";
                    break;
                case "02":
                    strMonth = "Feb";
                    break;
                case "03":
                    strMonth = "Mar";
                    break;
                case "04":
                    strMonth = "Apr";
                    break;
                case "05":
                    strMonth = "May";
                    break;
                case "06":
                    strMonth = "Jun";
                    break;
                case "07":
                    strMonth = "Jul";
                    break;
                case "08":
                    strMonth = "Aug";
                    break;
                case "09":
                    strMonth = "Sep";
                    break;
                case "10":
                    strMonth = "Oct";
                    break;
                case "11":
                    strMonth = "Nov";
                    break;
                case "12":
                    strMonth = "Dec";
                    break;
            }
            return strDay + " " + strMonth + " " + strYear;
        }
    }
}
