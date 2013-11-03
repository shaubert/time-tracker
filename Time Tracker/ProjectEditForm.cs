using Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Time_Tracker
{
    public partial class ProjectEditForm : Form
    {
        private ProjectGroup projectGroup;
        private Project currentProject;

        public ProjectEditForm(ProjectGroup projectGroup)
        {
            InitializeComponent();
            this.projectGroup = projectGroup;

            projectsListView.ItemSelectionChanged += projectsListItemSelectionChanged;
            saveButton.Click += saveButtonClick;
            newButton.Click += newButtonClick;
            removeButton.Click += removeButtonClick;

            RefreshListView();

            List<Project> projects = projectGroup.GetProjects();
            SetCurrentProject(projects.Any() ? projects[0] : null);
        }

        void removeButtonClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will remove project and all of it tasks. Are you sure?", "Removing project",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                projectGroup.Remove(currentProject);
                SetCurrentProject(null);
                RefreshListView();

                ProjectsPersistenceManager.GetInstance().SaveAsyncOrShowError(projectGroup);
            }
        }

        void newButtonClick(object sender, EventArgs e)
        {
            Project newProject = new Project();
            newProject.Name = ProjectNames.GenerateName();
            newProject.Rate = 0;
            projectGroup.Add(newProject);
            SetCurrentProject(newProject);
            RefreshListView();

            ProjectsPersistenceManager.GetInstance().SaveAsyncOrShowError(projectGroup);
        }

        void saveButtonClick(object sender, EventArgs e)
        {
            if (currentProject != null)
            {
                try
                {
                    decimal rate = Decimal.Parse(rateTextBox.Text, CultureInfo.CreateSpecificCulture("en-US"));

                    currentProject.Name = nameTextBox.Text;
                    currentProject.Rate = rate;

                    RefreshListView();

                    ProjectsPersistenceManager.GetInstance().SaveAsyncOrShowError(projectGroup);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please check entered values.\n\n" + ex.Message, "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        void projectsListItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                SetCurrentProject((Project) e.Item.Tag);
            }
        }

        private void SetCurrentProject(Project project)
        {
            currentProject = project;
            if (currentProject != null)
            {
                nameTextBox.Enabled = true;
                rateTextBox.Enabled = true;
                saveButton.Enabled = true;
                removeButton.Enabled = true;
                nameTextBox.Text = currentProject.Name;
                rateTextBox.Text = currentProject.Rate.ToString(CultureInfo.CreateSpecificCulture("en-US"));
            }
            else
            {
                nameTextBox.Enabled = false;
                rateTextBox.Enabled = false;
                saveButton.Enabled = false;
                removeButton.Enabled = false;
                nameTextBox.Text = "";
                rateTextBox.Text = "";
            }
        }

        private void RefreshListView()
        {
            projectsListView.Items.Clear();
            foreach (var project in projectGroup.GetProjects())
            {
                ListViewItem item = new ListViewItem(new string[] { 
                    project.Name, 
                    project.Rate.ToString(CultureInfo.CreateSpecificCulture("en-US"))
                });
                item.Tag = project;
                projectsListView.Items.Add(item);
            }
        }


    }
}
