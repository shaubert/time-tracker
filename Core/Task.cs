using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public delegate void TaskChanged(Task sender);

    public class Task : IComparable<Task>
    {
        private String name;
        private long durationInMillis;
        private DateTime creationDate;

        public event TaskChanged Changed;

        public Task()
        {
            creationDate = DateTime.Now;
        }

        public DateTime CreationDate
        {
            get { return creationDate; }
            set 
            { 
                creationDate = value;
                NotifyChanged();
            }
        }

        public DateTime EndDate 
        {
            get { return creationDate.AddMilliseconds(durationInMillis); }
        }

        public int DurationInSeconds
        {
            get { return (int) durationInMillis / 1000; }
            set 
            { 
                durationInMillis += value * 1000;
                NotifyChanged();
            }
        }

        public long DurationInMillis
        {
            get { return durationInMillis; }
            set
            {
                durationInMillis = value;
                NotifyChanged();
            }
        }

        public String Name
        {
            get { return name; }
            set 
            { 
                name = value;
                NotifyChanged();
            }
        }

        private void NotifyChanged()
        {
            if (Changed != null)
            {
                Changed(this);
            }
        }

        public int CompareTo(Task other)
        {
            return creationDate.CompareTo(other.creationDate);
        }
    }
}
