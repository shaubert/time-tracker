using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{

    public class ProjectGroup
    {
        private ISet<Project> projects;

        public ProjectGroup()
        {
            projects = new HashSet<Project>();
        }

        public List<Project> GetProjects()
        {
            List<Project> result = new List<Project>(projects);
            result.Sort((p1, p2) => p1.Name.CompareTo(p2.Name));
            return result;            
        }

        public void Add(Project project)
        {
            projects.Add(project);
        }

        public void Remove(Project project)
        {
            projects.Remove(project);
        }

        public void Clear()
        {
            projects.Clear();
        }

    }
}
