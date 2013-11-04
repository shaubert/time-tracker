using Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Time_Tracker
{
    public partial class MainForm : Form
    {

        private const int TIMER_INTERVAL = 1000;
        private const int SAVE_INTERVAL = 30000;    

        private ProjectGroup projectGroup;
        private Project currentProject;

        private Timer taskTimer;
        private Core.Task activeTask;
        private Stopwatch saveTimeInterval;
        private Stopwatch increaseDurationInterval;

        private DateTime? currentDate;

        private IFormatProvider format = CultureInfo.CreateSpecificCulture("en-US");

        public MainForm()
        {
            InitializeComponent();

            taskTimer = new System.Windows.Forms.Timer();
            taskTimer.Enabled = false;
            taskTimer.Interval = TIMER_INTERVAL;
            taskTimer.Tick += OnTimerEvent;

            setupProjectsButton.Click += setupProjectsClick;
            currentProjectComboBox.SelectedIndexChanged += currentProjectComboBoxSelectedIndexChanged;
            nextDateButton.Click += nextDateButtonClick;
            prevDateButton.Click += prevDateButtonClick;
            timerToggle.Click += timerToggleClick;
            tasksListView.SelectedIndexChanged += tasksListViewSelectedIndexChanged;
            tasksListView.MouseDoubleClick += tasksListViewDoubleClick;
            taskNameTextBox.TextChanged += taskNameTextBoxTextChanged;
            currentDateLabel.Click += currentDateLabelClick;
            newButton.Click += newButtonClick;
            delButton.Click += delButtonClick;
            taskNameTextBox.KeyUp += taskNameTextBoxKeyUp;
            generateReportButton.Click += generateReportButtonClick;

            FormClosed += MainFormFormClosed;

            LoadProjectGroup();
            RefreshProjects();

            SetCurrentDate(null);
        }

        void MainFormFormClosed(object sender, FormClosedEventArgs e)
        {
            ProjectsPersistenceManager.GetInstance().Save(projectGroup);
        }

        void generateReportButtonClick(object sender, EventArgs e)
        {

            if (saveReportFileDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                PdfReporter.GeneratePdfReport(saveReportFileDialog.FileName, currentProject, null);
            }            
        }

        void taskNameTextBoxKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                timerToggleClick(sender, EventArgs.Empty);
            }
        }

        void delButtonClick(object sender, EventArgs e)
        {
            if (activeTask != null)
            {
                currentProject.RemoveTask(activeTask);
                RefreshTasks();
                RefreshDaySummary();

                ProjectsPersistenceManager.GetInstance().SaveAsyncOrShowError(projectGroup);
            }
        }

        void newButtonClick(object sender, EventArgs e)
        {
            TaskEditForm form = new TaskEditForm(null);
            form.ShowDialog(this);
            if (form.Result != null)
            {
                currentProject.AddTask(form.Result);
                RefreshTasks();
                RefreshDaySummary();

                ProjectsPersistenceManager.GetInstance().SaveAsyncOrShowError(projectGroup);
            }
        }

        void tasksListViewDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo hit = tasksListView.HitTest(e.Location);
            if (hit.Item != null)
            {
                Core.Task oldTask = (Core.Task) hit.Item.Tag;
                TaskEditForm form = new TaskEditForm(oldTask);
                form.ShowDialog(this);
                if (form.Result != null)
                {
                    currentProject.RemoveTask(oldTask);
                    currentProject.AddTask(form.Result);
                    RefreshTasks();
                    RefreshDaySummary();

                    ProjectsPersistenceManager.GetInstance().SaveAsyncOrShowError(projectGroup);
                }
            };
        }

        void currentDateLabelClick(object sender, EventArgs e)
        {
            SetCurrentDate(DateTime.Now);
        }

        void taskNameTextBoxTextChanged(object sender, EventArgs e)
        {
            String taskName = taskNameTextBox.Text;
            Core.Task foundTask = currentProject.GetTasks().FirstOrDefault(
                t => t.Name.Equals(taskName, StringComparison.CurrentCultureIgnoreCase));
            if (foundTask != null)
            {
                SetActiveTask(foundTask);
            }
            else
            {
                SetActiveTask(null);
            }            
        }

        void tasksListViewSelectedIndexChanged(object sender, EventArgs e)
        {
            if (!taskTimer.Enabled && tasksListView.SelectedItems.Count > 0)
            {
                SetActiveTask((Core.Task) tasksListView.SelectedItems[0].Tag);
            }
        }

        void timerToggleClick(object sender, EventArgs e)
        {
            if (taskTimer.Enabled)
            {
                StopTimer();
            }
            else
            {
                if (activeTask != null)
                {
                    StartTimer();
                }
                else
                {
                    Core.Task task = new Core.Task();
                    task.Name = taskNameTextBox.Text;
                    currentProject.AddTask(task);
                    RefreshTasks();
                    SetActiveTask(task);
                    StartTimer();
                }
            }
        }

        void prevDateButtonClick(object sender, EventArgs e)
        {
            if (currentDate.HasValue)
            {
                SetCurrentDate(currentDate.Value.AddDays(-1));
            }
        }

        void nextDateButtonClick(object sender, EventArgs e)
        {
            if (currentDate.HasValue)
            {
                SetCurrentDate(currentDate.Value.AddDays(1));
            }
        }

        void currentProjectComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            int index = currentProjectComboBox.SelectedIndex;
            SetCurrentProject(index == -1 ? null : projectGroup.GetProjects()[index]);
        }

        private void LoadProjectGroup()
        {
            projectGroup = ProjectsPersistenceManager.GetInstance().Load();
            if (projectGroup == null)
            {
                projectGroup = new ProjectGroup();
            }            
        }

        void setupProjectsClick(object sender, EventArgs e)
        {
            ProjectEditForm form = new ProjectEditForm(projectGroup);
            form.ShowDialog(this);

            RefreshProjects();
        }

        private void SetCurrentDate(DateTime? dateTime)
        {
            if (dateTime.HasValue)
            {
                DateTime dateTimeVal = dateTime.Value;
                currentDatePanel.Visible = true;
                currentDate = new DateTime(dateTimeVal.Year, dateTimeVal.Month, dateTimeVal.Day);
                currentDateLabel.Text = dateTimeVal.ToString("dd MMMM yyyy");
            }
            else
            {
                currentDatePanel.Visible = false;
            }
            RefreshTasks();
            RefreshDaySummary();
        }

        private void RefreshProjects()
        {
            List<Project> projects = projectGroup.GetProjects();
            if (projects.Any())
            {
                currentProjectComboBox.Enabled = true;
                currentProjectComboBox.Items.Clear();
                foreach (Project project in projects)
                {
                    currentProjectComboBox.Items.Add(new ProjectsComboboxItem(project));
                }
                if (currentProject != null)
                {
                    currentProjectComboBox.Text = "";
                    int index = projects.IndexOf(currentProject);
                    if (index >= 0)
                    {
                        currentProjectComboBox.SelectedIndex = index;
                    }
                    else
                    {
                        currentProjectComboBox.SelectedIndex = 0;
                    }
                } 
                else 
                {
                    currentProjectComboBox.SelectedIndex = 0;
                }                
            }
            else
            {
                currentProjectComboBox.Enabled = false;
                currentProjectComboBox.Items.Clear();
                currentProjectComboBox.Text = "";
                SetCurrentProject(null);
            }
            
        }

        private void SetCurrentProject(Project project)
        {
            currentProject = project;
            RefreshTasks();
            RefreshDaySummary();
            RefreshTimerToggleText();
            timerToggle.Enabled = project != null;
            taskNameTextBox.Enabled = project != null;
            newButton.Enabled = project != null;
        }

        private void RefreshDaySummary()
        {
            if (currentProject != null)
            {
                long totalDuration = currentProject.GetDuration();
                long dayDuration = currentDate.HasValue
                    ? currentProject.GetDuration(new CreationDateFilter(currentDate.Value)) : -1;
                decimal totalCost = totalDuration * (currentProject.Rate / 3600);
                decimal dayCost = dayDuration * (currentProject.Rate / 3600);
                StringBuilder summary = new StringBuilder();
                if (dayDuration >= 0)
                {
                    summary.Append("Worked for day ")
                        .Append(TaskUtil.ConvertDurationInSecondsToDHM(dayDuration));
                    if (dayCost > 0)
                    {
                        summary.Append(" (earned ").Append(dayCost.ToString("C")).Append(")");
                    }
                    summary.Append(", total ");
                }
                else
                {
                    summary.Append("Worked total ");
                }
                summary.Append(TaskUtil.ConvertDurationInSecondsToDHM(totalDuration));
                if (totalCost > 0)
                {
                    summary.Append(" (earned ").Append(totalCost.ToString("C")).Append(")");
                }
                daySummaryToolStripStatusLabel.Text = summary.ToString();                
            }
            else
            {
                daySummaryToolStripStatusLabel.Text = "Choose project";
            }
        }

        private void RefreshTasks()
        {
            tasksListView.BeginUpdate();
            Core.Task selectedTask = tasksListView.SelectedItems.Count > 0 
                ? (Core.Task) tasksListView.SelectedItems[0].Tag : null;
            tasksListView.Items.Clear();

            taskNameTextBox.AutoCompleteCustomSource.Clear();
            if (currentProject != null)
            {
                List<Core.Task> tasks = currentProject.GetTasks(
                    currentDate.HasValue ? new CreationDateFilter(currentDate.Value) : null);
                tasks.Reverse();
                foreach (Core.Task task in tasks)
                {
                    ListViewItem item = new ListViewItem(new String[] {
                        FormatCreationDate(task.CreationDate),
                        task.Name,
                        TaskUtil.ConvertDurationInSecondsToDHM(task.DurationInSeconds)
                    });
                    item.Tag = task;
                    tasksListView.Items.Add(item);
                }                
                if (activeTask != null && !currentProject.GetTasks().Contains(activeTask))
                {
                    StopTimer();
                    SetActiveTask(null);
                }
                int newSelectedIndex = selectedTask != null ? tasks.IndexOf(selectedTask) : -1;
                if (newSelectedIndex >= 0)
                {
                    tasksListView.SelectedIndices.Add(newSelectedIndex);
                }
                taskNameTextBox.AutoCompleteCustomSource.AddRange(tasks.Select((el) => el.Name).ToArray());
            }
            else
            {
                StopTimer();
                SetActiveTask(null);                
            }
            tasksListView.EndUpdate();
        }

        private String FormatCreationDate(DateTime date)
        {
            DateTime now = DateTime.Now;
            String dateStr;
            if (date.Year == now.Year) 
            {
                if (date.Month == now.Month && date.Day == now.Day)
                {
                    dateStr = "";
                }
                else
                {
                    dateStr = date.ToString("MMM d", format);
                }
            } else {
                dateStr = date.ToString("MMM d yyyy", format);
            }
            return (dateStr.Length == 0 ? "" : (dateStr + " at ")) + date.ToShortTimeString();
        }        

        private void SetActiveTask(Core.Task task)
        {
            if (!taskTimer.Enabled)
            {
                activeTask = task;
                RefreshTimerToggleText();
                delButton.Enabled = task != null;
                if (task != null)
                {                    
                    taskNameTextBox.Text = task.Name;
                }
            }
            
        }

        private void StartTimer()
        {
            StopTimer();
            if (activeTask != null)
            {
                taskTimer.Start();
                taskNameTextBox.Enabled = false;
                saveTimeInterval = Stopwatch.StartNew();
                increaseDurationInterval = Stopwatch.StartNew();
                RefreshTimerToggleText();
                timerToggle.Checked = true;
            }            
        }

        private void StopTimer()
        {
            if (taskTimer.Enabled)
            {
                taskTimer.Stop();
                taskNameTextBox.Enabled = currentProject != null;
                saveTimeInterval.Reset();
                increaseDurationInterval.Reset();
                RefreshTimerToggleText();
                timerToggle.Checked = false;
                if (activeTask != null && currentProject != null)
                {
                    ProjectsPersistenceManager.GetInstance().SaveAsyncOrShowError(projectGroup);
                }
            }
        }

        private void RefreshTimerToggleText()
        {
            Core.Task currentTask = activeTask;
            if (currentTask == null && tasksListView.SelectedItems.Count > 0)
            {
                currentTask = (Core.Task) tasksListView.SelectedItems[0].Tag;
            }
            if (currentTask != null)
            {
                long[] components = TaskUtil.GetDurationComponents(currentTask.DurationInSeconds);

                components[1] += components[0] * 8;
                String duration = "";
                if (components[1] > 0)
                    duration += components[1] + ":";
                duration += components[2].ToString("00") + ":" + components[3].ToString("00");
                timerToggle.Text = duration;
            }
            else
            {
                timerToggle.Text = "Start";
            }
        }

        private void OnTimerEvent(object sender, EventArgs e)
        {
            if (activeTask != null)
            {
                activeTask.DurationInSeconds += (int)increaseDurationInterval.ElapsedMilliseconds / 1000;
                RefreshTimerToggleText();
                RefreshTasks();
                RefreshDaySummary();
                if (saveTimeInterval.ElapsedMilliseconds > SAVE_INTERVAL)
                {
                    ProjectsPersistenceManager.GetInstance().SaveAsyncOrShowError(projectGroup);
                    saveTimeInterval.Restart();
                }
                increaseDurationInterval.Restart();
            }
            else
            {
                StopTimer();
            }
        }
    }
}
