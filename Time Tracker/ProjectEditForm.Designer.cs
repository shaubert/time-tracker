namespace Time_Tracker
{
    partial class ProjectEditForm
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectEditForm));
            this.projectsListView = new System.Windows.Forms.ListView();
            this.projectNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.projectRateColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.rateTextBox = new System.Windows.Forms.TextBox();
            this.newButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveButton = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(10, 16);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(38, 13);
            label1.TabIndex = 1;
            label1.Text = "Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(15, 42);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(33, 13);
            label2.TabIndex = 1;
            label2.Text = "Rate:";
            // 
            // projectsListView
            // 
            this.projectsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.projectNameColumnHeader,
            this.projectRateColumnHeader});
            this.projectsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectsListView.FullRowSelect = true;
            this.projectsListView.GridLines = true;
            this.projectsListView.Location = new System.Drawing.Point(0, 100);
            this.projectsListView.MultiSelect = false;
            this.projectsListView.Name = "projectsListView";
            this.projectsListView.Size = new System.Drawing.Size(334, 216);
            this.projectsListView.TabIndex = 0;
            this.projectsListView.UseCompatibleStateImageBehavior = false;
            this.projectsListView.View = System.Windows.Forms.View.Details;
            // 
            // projectNameColumnHeader
            // 
            this.projectNameColumnHeader.Text = "Name";
            this.projectNameColumnHeader.Width = 266;
            // 
            // projectRateColumnHeader
            // 
            this.projectRateColumnHeader.Text = "Rate";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.Location = new System.Drawing.Point(54, 13);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(268, 20);
            this.nameTextBox.TabIndex = 2;
            // 
            // rateTextBox
            // 
            this.rateTextBox.Location = new System.Drawing.Point(54, 39);
            this.rateTextBox.Name = "rateTextBox";
            this.rateTextBox.Size = new System.Drawing.Size(78, 20);
            this.rateTextBox.TabIndex = 2;
            // 
            // newButton
            // 
            this.newButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.newButton.Location = new System.Drawing.Point(13, 71);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(98, 23);
            this.newButton.TabIndex = 3;
            this.newButton.Text = "New";
            this.newButton.UseVisualStyleBackColor = true;
            // 
            // removeButton
            // 
            this.removeButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.removeButton.Location = new System.Drawing.Point(221, 71);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(98, 23);
            this.removeButton.TabIndex = 4;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Controls.Add(this.nameTextBox);
            this.panel1.Controls.Add(this.removeButton);
            this.panel1.Controls.Add(label1);
            this.panel1.Controls.Add(this.newButton);
            this.panel1.Controls.Add(label2);
            this.panel1.Controls.Add(this.rateTextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(334, 100);
            this.panel1.TabIndex = 5;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.saveButton.Location = new System.Drawing.Point(117, 71);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(98, 23);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // ProjectEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 316);
            this.Controls.Add(this.projectsListView);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(350, 350);
            this.Name = "ProjectEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Проекты";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView projectsListView;
        private System.Windows.Forms.ColumnHeader projectNameColumnHeader;
        private System.Windows.Forms.ColumnHeader projectRateColumnHeader;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox rateTextBox;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button saveButton;
    }
}