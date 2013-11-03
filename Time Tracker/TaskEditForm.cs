using Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Time_Tracker
{
    public partial class TaskEditForm : Form
    {
        private Task result;

        public Task Result { get { return result; } }

        public TaskEditForm(Task task)
        {
            InitializeComponent();

            saveButton.Click += saveButtonClick;
            cancelButton.Click += cancelButtonClick;

            if (task != null)
            {
                nameTextBox.Text = task.Name;
                durationTextBox.Text = TaskUtil.ConvertDurationInSecondsToDHM(task.DurationInSeconds);
                creationDateTimePicker.Value = task.CreationDate;
                saveButton.Text = "Save";
            }
            else
            {
                saveButton.Text = "Create";
            }
        }

        void cancelButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        void saveButtonClick(object sender, EventArgs e)
        {
            result = CollectChanges();
            if (result != null)
            {
                Close();
            }
        }

        private Task CollectChanges()
        {
            try
            {
                Task res = new Task();
                res.Name = nameTextBox.Text;

                String dur = durationTextBox.Text;
                res.DurationInSeconds = (int) TaskUtil.parseDuration(dur);

                res.CreationDate = creationDateTimePicker.Value;
                return res;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please check entered values.\n\n" + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;
        }        

    }
}
