using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Project
    {
        private String name;
        private decimal rate;
        private ISet<Task> tasks;

        public Project()
        {
            tasks = new HashSet<Task>();
        }

        public decimal Rate
        {
            get { return rate; }
            set { rate = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public void AddTask(Task task)
        {
            tasks.Add(task);
        }

        public void RemoveTask(Task task)
        {
            tasks.Remove(task);
        }

        public List<Task> Tasks
        {
            get { return GetTasks(null); }
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
            return GetTasks(filter).Sum(t => t.DurationInSeconds * costPerSecond);
        }
    }
}
