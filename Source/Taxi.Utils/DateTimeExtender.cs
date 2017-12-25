using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Taxi.Utils
{
    public static class DateTimeExtender
    {
        public static int GetWeekNumberOfYear(this DateTime time)
        {
            var weekRule = CalendarWeekRule.FirstFourDayWeek;
            var firstWeekDay = DayOfWeek.Monday;
            var calendar = System.Threading.Thread.CurrentThread.CurrentCulture.Calendar;
            return calendar.GetWeekOfYear(time, weekRule, firstWeekDay);
        }
    }
}
