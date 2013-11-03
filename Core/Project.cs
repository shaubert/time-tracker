using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public delegate void ProjectChanged(Project sender);

    public class Project
    {
        private String name;
        private decimal rate;
        private ISet<Task> tasks;

        public event ProjectChanged Changed;

        public Project()
        {
            tasks = new HashSet<Task>();
        }

        public decimal Rate
        {
            get { return rate; }
            set 
            { 
                rate = value;
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

        public void AddTask(Task task)
        {
            if (tasks.Add(task))
            {
                task.Changed += OnTaskChanged;
                NotifyChanged();
            }            
        }

        public void RemoveTask(Task task)
        {
            if (tasks.Remove(task))
            {
                task.Changed -= OnTaskChanged;
                NotifyChanged();
            }            
        }

        public List<Task> GetTasks()
        {
            return GetTasks(null);
        }

        public List<Task> GetTasks(Filter<Task> filter)
        {
            List<Task> result;
            if (filter == null)
            {
                result = new List<Task>(tasks);
            }
            else
            { 
                result = tasks.Where(t => filter.match(t)).ToList<Task>();
            }
            result.Sort();
            return result;
        }

        public int TasksCount { get { return tasks.Count; } }

        public decimal GetCost()
        {
            return GetCost(null);
        }        

        public decimal GetCost(Filter<Task> filter)
        {
            decimal costPerSecond = rate / 3600;
            return GetDuration(filter) * costPerSecond;
        }

        public long GetDuration()
        {
            return GetDuration(null);
        }

        public long GetDuration(Filter<Task> filter)
        {
            return GetTasks(filter).Sum(t => t.DurationInSeconds);
        }

        private void OnTaskChanged(Task task)
        {
            NotifyChanged();
        }

        private void NotifyChanged()
        {
            if (Changed != null)
            {
                Changed(this);
            }
        }
    }
}
