namespace WGUSchedule.Forms
{
    partial class Calendar
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
            this.CalendarHeader = new System.Windows.Forms.Label();
            this.MonthRadio = new System.Windows.Forms.RadioButton();
            this.WeekRadio = new System.Windows.Forms.RadioButton();
            this.AllRadio = new System.Windows.Forms.RadioButton();
            this.CalendarGrid = new System.Windows.Forms.DataGridView();
            this.ExitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CalendarGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // CalendarHeader
            // 
            this.CalendarHeader.AutoSize = true;
            this.CalendarHeader.Location = new System.Drawing.Point(514, 23);
            this.CalendarHeader.Name = "CalendarHeader";
            this.CalendarHeader.Size = new System.Drawing.Size(73, 20);
            this.CalendarHeader.TabIndex = 11;
            this.CalendarHeader.Text = "Calendar";
            // 
            // MonthRadio
            // 
            this.MonthRadio.AutoSize = true;
            this.MonthRadio.Location = new System.Drawing.Point(776, 67);
            this.MonthRadio.Name = "MonthRadio";
            this.MonthRadio.Size = new System.Drawing.Size(136, 24);
            this.MonthRadio.TabIndex = 10;
            this.MonthRadio.TabStop = true;
            this.MonthRadio.Text = "Current Month";
            this.MonthRadio.UseVisualStyleBackColor = true;
            this.MonthRadio.CheckedChanged += new System.EventHandler(this.MonthRadio_CheckedChanged);
            // 
            // WeekRadio
            // 
            this.WeekRadio.AutoSize = true;
            this.WeekRadio.Location = new System.Drawing.Point(485, 67);
            this.WeekRadio.Name = "WeekRadio";
            this.WeekRadio.Size = new System.Drawing.Size(132, 24);
            this.WeekRadio.TabIndex = 9;
            this.WeekRadio.TabStop = true;
            this.WeekRadio.Text = "Current Week";
            this.WeekRadio.UseVisualStyleBackColor = true;
            this.WeekRadio.CheckedChanged += new System.EventHandler(this.WeekRadio_CheckedChanged);
            // 
            // AllRadio
            // 
            this.AllRadio.AutoSize = true;
            this.AllRadio.Location = new System.Drawing.Point(191, 67);
            this.AllRadio.Name = "AllRadio";
            this.AllRadio.Size = new System.Drawing.Size(154, 24);
            this.AllRadio.TabIndex = 8;
            this.AllRadio.TabStop = true;
            this.AllRadio.Text = "All Appointments";
            this.AllRadio.UseVisualStyleBackColor = true;
            this.AllRadio.CheckedChanged += new System.EventHandler(this.AllRadio_CheckedChanged);
            // 
            // CalendarGrid
            // 
            this.CalendarGrid.AllowUserToAddRows = false;
            this.CalendarGrid.AllowUserToDeleteRows = false;
            this.CalendarGrid.AllowUserToResizeColumns = false;
            this.CalendarGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.CalendarGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CalendarGrid.Location = new System.Drawing.Point(156, 97);
            this.CalendarGrid.Name = "CalendarGrid";
            this.CalendarGrid.ReadOnly = true;
            this.CalendarGrid.RowHeadersWidth = 62;
            this.CalendarGrid.RowTemplate.Height = 28;
            this.CalendarGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CalendarGrid.Size = new System.Drawing.Size(794, 226);
            this.CalendarGrid.TabIndex = 12;
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(785, 369);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(115, 42);
            this.ExitButton.TabIndex = 13;
            this.ExitButton.Text = "Back";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // Calendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 450);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.CalendarGrid);
            this.Controls.Add(this.CalendarHeader);
            this.Controls.Add(this.MonthRadio);
            this.Controls.Add(this.WeekRadio);
            this.Controls.Add(this.AllRadio);
            this.MinimumSize = new System.Drawing.Size(1000, 0);
            this.Name = "Calendar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calendar";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Calendar_FormClosed);
            this.Load += new System.EventHandler(this.Calendar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CalendarGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CalendarHeader;
        private System.Windows.Forms.RadioButton MonthRadio;
        private System.Windows.Forms.RadioButton WeekRadio;
        private System.Windows.Forms.RadioButton AllRadio;
        private System.Windows.Forms.DataGridView CalendarGrid;
        private System.Windows.Forms.Button ExitButton;
    }
}