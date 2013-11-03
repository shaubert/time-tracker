using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Tracker
{
    public class ProjectsComboboxItem
    {
        private Core.Project project;

        public Project Project { get; set; }

        public ProjectsComboboxItem(Project project)
        {
            Project = project;
        }

        public override string ToString()
        {
            return Project.Name;
        }
    }
}
