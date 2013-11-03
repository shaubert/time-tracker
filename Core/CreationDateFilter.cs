using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class CreationDateFilter : Filter<Task>
    {
        private DateTime from;
        private DateTime to;

        public CreationDateFilter() : this(DateTime.Now)
        {
        }

        public CreationDateFilter(DateTime forDay)
        {
            from = new DateTime(forDay.Year, forDay.Month, forDay.Day, 0, 0, 0);
            to = new DateTime(forDay.Year, forDay.Month, forDay.Day, 23, 59, 59);
        }

        public CreationDateFilter(DateTime from, DateTime to)
        {
            this.from = from;
            this.to = to;
        }

        public void setupForMonth()
        {
            DateTime now = DateTime.Now;
            from = new DateTime(now.Year, now.Month, 1, 0, 0, 0);
            to = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month), 23, 59, 59);
        }

        public void setupForWeek(DayOfWeek startDay)
        {
            DateTime now = DateTime.Now;
            from = now.FirstDayOfWeek(startDay);
            to = now.LastDayOfWeek(startDay);
        }

        public DateTime ToDate
        {
            get { return to; }
            set { to = value; }
        }

        public DateTime FromDate
        {
            get { return from; }
            set { from = value; }
        }

        public bool match(Task item)
        {
            DateTime start = item.CreationDate;
            DateTime end = item.EndDate;
            return start.CompareTo(to) <= 0 && end.CompareTo(from) >= 0;
        }
    }
}
