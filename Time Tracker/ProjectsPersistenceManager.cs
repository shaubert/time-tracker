using Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Time_Tracker
{
    public delegate void ActionWithResult(bool result);

    class SaveTaskInfo
    {        
        private ActionWithResult action;
        private ProjectGroup projectGroup;

        public SaveTaskInfo(ProjectGroup projectGroup, ActionWithResult action)
        {
            this.projectGroup = projectGroup;
            this.action = action;
        }

        public ActionWithResult Action { get { return action; } }
        public ProjectGroup ProjectGroup { get { return projectGroup; } }
    }

    class ProjectsPersistenceManager
    {
        private static ProjectsPersistenceManager instace;
        public static ProjectsPersistenceManager GetInstance() 
        {
            if (instace == null)
            {
                instace = new ProjectsPersistenceManager(new ProjectGroupXmlSerializer());
            }
            return instace;
        }

        private ProjectGroupSerializer serializer;
        private string projectsDir;
        private string projectsFilePath;

        private ProjectsPersistenceManager(ProjectGroupSerializer serializer)
        {
            this.serializer = serializer;
            projectsDir = AppDomain.CurrentDomain.BaseDirectory + "/projects";
            if (!Directory.Exists(projectsDir))
            {
                Directory.CreateDirectory(projectsDir);
            }
            projectsFilePath = projectsDir + "/projects.xml";
        }

        public ProjectGroup Load()
        {
            if (File.Exists(projectsFilePath))
            {
                try
                {
                    return serializer.Deserialize(projectsFilePath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return null;
        }

        public void SaveAsyncOrShowError(ProjectGroup projectGroup)
        {
            System.Threading.Tasks.Task<bool> task = SaveAsync(projectGroup);
            task.ContinueWith((t) =>
            {
                if (!t.Result)
                {
                    MessageBox.Show("Failed to save project changes on disk.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
        }

        public System.Threading.Tasks.Task<bool> SaveAsync(ProjectGroup projectGroup)
        {
            return System.Threading.Tasks.Task.Factory.StartNew(() => Save(projectGroup));
        }

        private void Save(object state)
        {
            SaveTaskInfo info = (SaveTaskInfo) state;
            bool result = Save(info.ProjectGroup);
            if (info.Action != null)
            {
                
            }
        }

        public bool Save(ProjectGroup projectGroup)
        {            
            if (projectGroup != null)
            {
                try
                {
                    serializer.Serialize(projectGroup, projectsFilePath);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return false;
        }
        
    }
}
