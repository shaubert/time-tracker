using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public static class DateTimeExtensions
    {
        public static DateTime FirstDayOfWeek(this DateTime source)            
        {
            return FirstDayOfWeek(source, DayOfWeek.Monday);
        }

        public static DateTime FirstDayOfWeek(this DateTime source, DayOfWeek startDay)
        {
            var dayDelta = ((int)source.DayOfWeek - (int)startDay);
            if (dayDelta == 0)
            {
                return new DateTime(source.Year, source.Month, source.Day);
            }
            else if (dayDelta < 0)
            {
                DateTime start = source.AddDays(-(dayDelta + 7));
                return new DateTime(start.Year, start.Month, start.Day);
            }
            else
            {
                DateTime start = source.AddDays(-dayDelta);
                return new DateTime(start.Year, start.Month, start.Day);
            }            
        }

        public static DateTime LastDayOfWeek(this DateTime source)
        {
            return LastDayOfWeek(source, DayOfWeek.Monday);
        }

        public static DateTime LastDayOfWeek(this DateTime source, DayOfWeek startDay)
        {
            return FirstDayOfWeek(source, startDay).AddDays(7).AddSeconds(-1);            
        }
    }
}
