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
    public partial class ReportIntervalSelectionForm : Form
    {
        private Project currentProject;
        private IFormatProvider format = CultureInfo.CreateSpecificCulture("en-US");

        public ReportIntervalSelectionForm(Project project)
        {
            InitializeComponent();

            currentProject = project;
            RefreshTasks();
            if (currentProject != null)
            {
                List<Core.Task> tasks = currentProject.GetTasks();
                if (tasks.Any())
                {
                    intervalFromDatePicker.Value = tasks[0].CreationDate;
                    intervalToDatePicker.Value = tasks[tasks.Count - 1].CreationDate;
                }
            }
        }

        private void generateReportButton_Click(object sender, EventArgs e)
        {
            Filter<Core.Task> taskFilter = null;
            if (tasksListView.SelectedItems.Count > 0) 
            {
                if (MessageBox.Show("Do you want to include in report only selected items?", "Use selected items?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    List<Core.Task> tasks = new List<Core.Task>();
                    foreach (ListViewItem item in tasksListView.SelectedItems)
                    {
                        tasks.Add((Core.Task) item.Tag);
                    }
                    taskFilter = new SelectedItemsFilter(tasks);
                }
            }
            if (taskFilter == null) taskFilter = getDateFilter();

            
            if (saveReportFileDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                PdfReporter.GeneratePdfReport(saveReportFileDialog.FileName, currentProject, taskFilter);
                Close();
            } 
        }

        private void RefreshTasks()
        {
            tasksListView.BeginUpdate();
            tasksListView.Items.Clear();

            if (currentProject != null)
            {
                List<Core.Task> tasks = currentProject.GetTasks(getDateFilter());
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
            }            
            tasksListView.EndUpdate();

            generateReportButton.Enabled = tasksListView.Items.Count > 0;
            RefreshDaySummary();
        }

        private Filter<Core.Task> getDateFilter()
        {
            DateTime from = intervalFromDatePicker.Value;
            DateTime to = intervalToDatePicker.Value;
            return new CreationDateFilter(new DateTime(from.Year, from.Month, from.Day),
                new DateTime(to.Year, to.Month, to.Day, 23, 59, 59));
        }

        private Filter<Core.Task> getCurrentFilter()
        {
            if (tasksListView.SelectedItems.Count > 0)
            {
                List<Core.Task> tasks = new List<Core.Task>();
                foreach (ListViewItem item in tasksListView.SelectedItems)
                {
                    tasks.Add((Core.Task)item.Tag);
                }
                return new SelectedItemsFilter(tasks);
            }
            return getDateFilter();
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
            }
            else
            {
                dateStr = date.ToString("MMM d yyyy", format);
            }
            return (dateStr.Length == 0 ? "" : (dateStr + " at ")) + date.ToShortTimeString();
        }

        private void RefreshDaySummary()
        {
            if (currentProject != null)
            {
                long duration = currentProject.GetDuration(getCurrentFilter());
                decimal totalCost = duration * (currentProject.Rate / 3600);
                StringBuilder summary = new StringBuilder();
                if (tasksListView.SelectedItems.Count > 0)
                {
                    summary.Append("Selected time ");
                }
                else
                {
                    summary.Append("Total time ");
                }
                summary.Append(TaskUtil.ConvertDurationInSecondsToDHM(duration));
                if (totalCost > 0)
                {
                    summary.Append(" (earned ").Append(totalCost.ToString("C")).Append(")");
                }
                daySummaryToolStripStatusLabel.Text = summary.ToString();
            }
            else
            {
                daySummaryToolStripStatusLabel.Text = "None";
            }
        }

        private void intervalToDatePicker_ValueChanged(object sender, EventArgs e)
        {
            RefreshTasks();
        }

        private void intervalFromDatePicker_ValueChanged(object sender, EventArgs e)
        {
            RefreshTasks();
        }

        private void tasksListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            RefreshDaySummary();
        }

    }

    public class SelectedItemsFilter : Filter<Core.Task>
    {
        private List<Core.Task> selectedTasks;

        public SelectedItemsFilter(List<Core.Task> selectedTasks)
        {
            this.selectedTasks = selectedTasks;
        }

        public bool match(Core.Task item)
        {
            return selectedTasks.Contains(item);
        }
    }

}
