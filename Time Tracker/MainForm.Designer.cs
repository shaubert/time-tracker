namespace Time_Tracker
{
    partial class MainForm
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
            this.timerPanel = new System.Windows.Forms.Panel();
            this.timerToggle = new System.Windows.Forms.Button();
            this.currentDateLabel = new System.Windows.Forms.Label();
            this.currentDatePanel = new System.Windows.Forms.Panel();
            this.prevDateButton = new System.Windows.Forms.Button();
            this.nextDateButton = new System.Windows.Forms.Button();
            this.tasksListView = new System.Windows.Forms.ListView();
            this.taskNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.taskDurationColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.taskCreationTimeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.daySummaryToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.currentProjectPanel = new System.Windows.Forms.Panel();
            this.currentProjectComboBox = new System.Windows.Forms.ComboBox();
            this.setupProjectsButton = new System.Windows.Forms.Button();
            this.taskNameTextBox = new System.Windows.Forms.TextBox();
            this.timerPanel.SuspendLayout();
            this.currentDatePanel.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.currentProjectPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerPanel
            // 
            this.timerPanel.Controls.Add(this.taskNameTextBox);
            this.timerPanel.Controls.Add(this.timerToggle);
            this.timerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.timerPanel.Location = new System.Drawing.Point(0, 35);
            this.timerPanel.Name = "timerPanel";
            this.timerPanel.Size = new System.Drawing.Size(324, 50);
            this.timerPanel.TabIndex = 0;
            // 
            // timerToggle
            // 
            this.timerToggle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timerToggle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timerToggle.Location = new System.Drawing.Point(221, 3);
            this.timerToggle.Name = "timerToggle";
            this.timerToggle.Size = new System.Drawing.Size(91, 41);
            this.timerToggle.TabIndex = 1;
            this.timerToggle.Text = "14:30:25";
            this.timerToggle.UseVisualStyleBackColor = true;
            // 
            // currentDateLabel
            // 
            this.currentDateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentDateLabel.Location = new System.Drawing.Point(58, 6);
            this.currentDateLabel.Name = "currentDateLabel";
            this.currentDateLabel.Size = new System.Drawing.Size(208, 20);
            this.currentDateLabel.TabIndex = 2;
            this.currentDateLabel.Text = "26 December, 2013";
            this.currentDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentDatePanel
            // 
            this.currentDatePanel.Controls.Add(this.nextDateButton);
            this.currentDatePanel.Controls.Add(this.prevDateButton);
            this.currentDatePanel.Controls.Add(this.currentDateLabel);
            this.currentDatePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.currentDatePanel.Location = new System.Drawing.Point(0, 85);
            this.currentDatePanel.Name = "currentDatePanel";
            this.currentDatePanel.Size = new System.Drawing.Size(324, 30);
            this.currentDatePanel.TabIndex = 3;
            // 
            // prevDateButton
            // 
            this.prevDateButton.Location = new System.Drawing.Point(12, 3);
            this.prevDateButton.Name = "prevDateButton";
            this.prevDateButton.Size = new System.Drawing.Size(40, 23);
            this.prevDateButton.TabIndex = 3;
            this.prevDateButton.Text = "<";
            this.prevDateButton.UseVisualStyleBackColor = true;
            // 
            // nextDateButton
            // 
            this.nextDateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nextDateButton.Location = new System.Drawing.Point(272, 3);
            this.nextDateButton.Name = "nextDateButton";
            this.nextDateButton.Size = new System.Drawing.Size(40, 23);
            this.nextDateButton.TabIndex = 4;
            this.nextDateButton.Text = ">";
            this.nextDateButton.UseVisualStyleBackColor = true;
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
            this.tasksListView.Location = new System.Drawing.Point(0, 115);
            this.tasksListView.MultiSelect = false;
            this.tasksListView.Name = "tasksListView";
            this.tasksListView.Size = new System.Drawing.Size(324, 201);
            this.tasksListView.TabIndex = 4;
            this.tasksListView.UseCompatibleStateImageBehavior = false;
            this.tasksListView.View = System.Windows.Forms.View.Details;
            // 
            // taskNameColumn
            // 
            this.taskNameColumn.Text = "Task";
            this.taskNameColumn.Width = 197;
            // 
            // taskDurationColumn
            // 
            this.taskDurationColumn.Text = "Duration";
            this.taskDurationColumn.Width = 62;
            // 
            // taskCreationTimeColumn
            // 
            this.taskCreationTimeColumn.Text = "Started";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.daySummaryToolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 294);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(324, 22);
            this.statusStrip.TabIndex = 5;
            this.statusStrip.Text = "statusStrip";
            // 
            // daySummaryToolStripStatusLabel
            // 
            this.daySummaryToolStripStatusLabel.Name = "daySummaryToolStripStatusLabel";
            this.daySummaryToolStripStatusLabel.Size = new System.Drawing.Size(140, 17);
            this.daySummaryToolStripStatusLabel.Text = "Worked today 5:30 ($500)";
            // 
            // currentProjectPanel
            // 
            this.currentProjectPanel.Controls.Add(this.setupProjectsButton);
            this.currentProjectPanel.Controls.Add(this.currentProjectComboBox);
            this.currentProjectPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.currentProjectPanel.Location = new System.Drawing.Point(0, 0);
            this.currentProjectPanel.Name = "currentProjectPanel";
            this.currentProjectPanel.Size = new System.Drawing.Size(324, 35);
            this.currentProjectPanel.TabIndex = 6;
            // 
            // currentProjectComboBox
            // 
            this.currentProjectComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentProjectComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentProjectComboBox.FormattingEnabled = true;
            this.currentProjectComboBox.Location = new System.Drawing.Point(12, 5);
            this.currentProjectComboBox.Name = "currentProjectComboBox";
            this.currentProjectComboBox.Size = new System.Drawing.Size(254, 24);
            this.currentProjectComboBox.TabIndex = 0;
            // 
            // setupProjectsButton
            // 
            this.setupProjectsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.setupProjectsButton.Location = new System.Drawing.Point(272, 5);
            this.setupProjectsButton.Name = "setupProjectsButton";
            this.setupProjectsButton.Size = new System.Drawing.Size(40, 23);
            this.setupProjectsButton.TabIndex = 1;
            this.setupProjectsButton.Text = "...";
            this.setupProjectsButton.UseVisualStyleBackColor = true;
            // 
            // taskNameTextBox
            // 
            this.taskNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.taskNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.taskNameTextBox.Location = new System.Drawing.Point(12, 3);
            this.taskNameTextBox.Multiline = true;
            this.taskNameTextBox.Name = "taskNameTextBox";
            this.taskNameTextBox.Size = new System.Drawing.Size(203, 41);
            this.taskNameTextBox.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 316);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.tasksListView);
            this.Controls.Add(this.currentDatePanel);
            this.Controls.Add(this.timerPanel);
            this.Controls.Add(this.currentProjectPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(340, 0);
            this.Name = "MainForm";
            this.Text = "Tracker";
            this.timerPanel.ResumeLayout(false);
            this.timerPanel.PerformLayout();
            this.currentDatePanel.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.currentProjectPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel timerPanel;
        private System.Windows.Forms.Button timerToggle;
        private System.Windows.Forms.Label currentDateLabel;
        private System.Windows.Forms.Panel currentDatePanel;
        private System.Windows.Forms.Button nextDateButton;
        private System.Windows.Forms.Button prevDateButton;
        private System.Windows.Forms.ListView tasksListView;
        private System.Windows.Forms.ColumnHeader taskCreationTimeColumn;
        private System.Windows.Forms.ColumnHeader taskNameColumn;
        private System.Windows.Forms.ColumnHeader taskDurationColumn;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel daySummaryToolStripStatusLabel;
        private System.Windows.Forms.Panel currentProjectPanel;
        private System.Windows.Forms.Button setupProjectsButton;
        private System.Windows.Forms.ComboBox currentProjectComboBox;
        private System.Windows.Forms.TextBox taskNameTextBox;
    }
}

