using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Core
{
    public class ProjectGroupXmlSerializer : ProjectGroupSerializer
    {
        private const String PROJECTS_NODE = "projects";

        private const String PROJECT_NODE = "project";
        private const String NAME_ATTR = "name";
        private const String RATE_ATTR = "rate";

        private const String TASK_NODE = "task";
        private const String CREATION_DATE_ATTR = "creationDate";
        private const String DURATION_ATTR = "durationInSec";

        private IFormatProvider format = CultureInfo.InvariantCulture;

        public void Serialize(ProjectGroup projectGroup, String fileName)
        {
            XDocument doc = new XDocument();
            XElement projectsNode = new XElement(PROJECTS_NODE);
            foreach (Project project in projectGroup.GetProjects())
            {
                XElement projectNode = new XElement(PROJECT_NODE, 
                    new XAttribute(NAME_ATTR, project.Name),
                    new XAttribute(RATE_ATTR, project.Rate.ToString(format)));
                foreach (Task task in project.GetTasks())
                {
                    XElement taskNode = new XElement(TASK_NODE,
                        new XAttribute(NAME_ATTR, task.Name),
                        new XAttribute(CREATION_DATE_ATTR, task.CreationDate.ToUniversalTime().ToString("r", format)),
                        new XAttribute(DURATION_ATTR, task.DurationInSeconds));
                    projectNode.Add(taskNode);
                }
                projectsNode.Add(projectNode);
            }
            doc.Add(projectsNode);
            doc.Save(fileName);
        }

        public ProjectGroup Deserialize(String fileName)
        {
            ProjectGroup result = new ProjectGroup();
            XDocument doc = XDocument.Load(fileName);
            XElement projectsNode = doc.Element(PROJECTS_NODE);
            IEnumerable<XElement> projectNodes = projectsNode.Elements(PROJECT_NODE);
            foreach (XElement projectNode in projectNodes) 
            {
                Project project = new Project();
                project.Name = projectNode.Attribute(NAME_ATTR).Value;
                project.Rate = Decimal.Parse(projectNode.Attribute(RATE_ATTR).Value, format);
                IEnumerable<XElement> taskNodes = projectNode.Elements(TASK_NODE);
                foreach (XElement taskNode in taskNodes)
                {
                    Task task = new Task();
                    task.Name = taskNode.Attribute(NAME_ATTR).Value;
                    task.CreationDate = DateTime.ParseExact(taskNode.Attribute(CREATION_DATE_ATTR).Value, "r", format).ToLocalTime();
                    task.DurationInSeconds = Int32.Parse(taskNode.Attribute(DURATION_ATTR).Value);
                    project.AddTask(task);
                }
                result.Add(project);
            }
            return result;
        }
    }
}
