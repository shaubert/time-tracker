using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Task : IComparable<Task>
    {
        private String name;
        private int durationInSeconds;
        private DateTime creationDate;

        public Task()
        {
            creationDate = DateTime.Now;
        }

        public DateTime CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; }
        }

        public DateTime EndDate 
        {
            get { return creationDate.AddSeconds(durationInSeconds); }
        }

        public int DurationInSeconds
        {
            get { return durationInSeconds; }
            set { durationInSeconds = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }


        public int CompareTo(Task other)
        {
            return creationDate.CompareTo(other.creationDate);
        }
    }
}
