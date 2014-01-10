namespace Time_Tracker
{
    partial class ReportIntervalSelectionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportIntervalSelectionForm));
            this.label1 = new System.Windows.Forms.Label();
            this.intervalFromDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.intervalToDatePicker = new System.Windows.Forms.DateTimePicker();
            this.tasksListView = new System.Windows.Forms.ListView();
            this.taskCreationTimeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.taskNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.taskDurationColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.generateReportButton = new System.Windows.Forms.Button();
            this.saveReportFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.daySummaryToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "From:";
            // 
            // intervalFromDatePicker
            // 
            this.intervalFromDatePicker.CustomFormat = "dd MMMM yyyy";
            this.intervalFromDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.intervalFromDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.intervalFromDatePicker.Location = new System.Drawing.Point(41, 3);
            this.intervalFromDatePicker.Name = "intervalFromDatePicker";
            this.intervalFromDatePicker.Size = new System.Drawing.Size(146, 22);
            this.intervalFromDatePicker.TabIndex = 3;
            this.intervalFromDatePicker.ValueChanged += new System.EventHandler(this.intervalFromDatePicker_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "To:";
            // 
            // intervalToDatePicker
            // 
            this.intervalToDatePicker.CustomFormat = "dd MMMM yyyy";
            this.intervalToDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.intervalToDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.intervalToDatePicker.Location = new System.Drawing.Point(234, 3);
            this.intervalToDatePicker.Name = "intervalToDatePicker";
            this.intervalToDatePicker.Size = new System.Drawing.Size(146, 22);
            this.intervalToDatePicker.TabIndex = 3;
            this.intervalToDatePicker.ValueChanged += new System.EventHandler(this.intervalToDatePicker_ValueChanged);
            // 
            // tasksListView
            // 
            this.tasksListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.taskCreationTimeColumn,
            this.taskNameColumn,
            this.taskDurationColumn});
            this.tasksListView.Cursor = System.Windows.Forms.Cursors.Default;
            this.tasksListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tasksListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tasksListView.FullRowSelect = true;
            this.tasksListView.GridLines = true;
            this.tasksListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.tasksListView.Location = new System.Drawing.Point(0, 30);
            this.tasksListView.Name = "tasksListView";
            this.tasksListView.Size = new System.Drawing.Size(614, 262);
            this.tasksListView.TabIndex = 5;
            this.tasksListView.UseCompatibleStateImageBehavior = false;
            this.tasksListView.View = System.Windows.Forms.View.Details;
            this.tasksListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.tasksListView_ItemSelectionChanged);
            // 
            // taskCreationTimeColumn
            // 
            this.taskCreationTimeColumn.Text = "Created";
            this.taskCreationTimeColumn.Width = 151;
            // 
            // taskNameColumn
            // 
            this.taskNameColumn.Text = "Task";
            this.taskNameColumn.Width = 383;
            // 
            // taskDurationColumn
            // 
            this.taskDurationColumn.Text = "Duration";
            this.taskDurationColumn.Width = 75;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.generateReportButton);
            this.panel1.Controls.Add(this.intervalFromDatePicker);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.intervalToDatePicker);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(614, 30);
            this.panel1.TabIndex = 6;
            // 
            // generateReportButton
            // 
            this.generateReportButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.generateReportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.generateReportButton.Location = new System.Drawing.Point(401, 3);
            this.generateReportButton.Name = "generateReportButton";
            this.generateReportButton.Size = new System.Drawing.Size(203, 22);
            this.generateReportButton.TabIndex = 4;
            this.generateReportButton.Text = "Generate Report";
            this.generateReportButton.UseVisualStyleBackColor = true;
            this.generateReportButton.Click += new System.EventHandler(this.generateReportButton_Click);
            // 
            // saveReportFileDialog
            // 
            this.saveReportFileDialog.DefaultExt = "pdf";
            this.saveReportFileDialog.Filter = "PDF Report File|*.pdf";
            this.saveReportFileDialog.RestoreDirectory = true;
            this.saveReportFileDialog.Title = "Choose output file";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.daySummaryToolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 270);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(614, 22);
            this.statusStrip.TabIndex = 7;
            this.statusStrip.Text = "statusStrip";
            // 
            // daySummaryToolStripStatusLabel
            // 
            this.daySummaryToolStripStatusLabel.Name = "daySummaryToolStripStatusLabel";
            this.daySummaryToolStripStatusLabel.Size = new System.Drawing.Size(140, 17);
            this.daySummaryToolStripStatusLabel.Text = "Worked today 5:30 ($500)";
            // 
            // ReportIntervalSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 292);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.tasksListView);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(630, 330);
            this.Name = "ReportIntervalSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Report Interval";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker intervalFromDatePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker intervalToDatePicker;
        private System.Windows.Forms.ListView tasksListView;
        private System.Windows.Forms.ColumnHeader taskCreationTimeColumn;
        private System.Windows.Forms.ColumnHeader taskNameColumn;
        private System.Windows.Forms.ColumnHeader taskDurationColumn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button generateReportButton;
        private System.Windows.Forms.SaveFileDialog saveReportFileDialog;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel daySummaryToolStripStatusLabel;
    }
}