namespace WGUSchedule.Forms
{
    partial class Reports
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
            this.ReportsHeader = new System.Windows.Forms.Label();
            this.DayRadio = new System.Windows.Forms.RadioButton();
            this.UserRadio = new System.Windows.Forms.RadioButton();
            this.TypeRadio = new System.Windows.Forms.RadioButton();
            this.TypeDropdown = new System.Windows.Forms.ComboBox();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.MonthDropdown = new System.Windows.Forms.ComboBox();
            this.MonthLabel = new System.Windows.Forms.Label();
            this.TotalLabel = new System.Windows.Forms.Label();
            this.TotalEditHere = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.UserDropdown = new System.Windows.Forms.ComboBox();
            this.UserLabel = new System.Windows.Forms.Label();
            this.DatePicker = new System.Windows.Forms.MonthCalendar();
            this.ExitButton = new System.Windows.Forms.Button();
            this.DayLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportsHeader
            // 
            this.ReportsHeader.AutoSize = true;
            this.ReportsHeader.Location = new System.Drawing.Point(468, 21);
            this.ReportsHeader.Name = "ReportsHeader";
            this.ReportsHeader.Size = new System.Drawing.Size(161, 20);
            this.ReportsHeader.TabIndex = 15;
            this.ReportsHeader.Text = "Appointment Reports";
            // 
            // DayRadio
            // 
            this.DayRadio.AutoSize = true;
            this.DayRadio.Location = new System.Drawing.Point(798, 59);
            this.DayRadio.Name = "DayRadio";
            this.DayRadio.Size = new System.Drawing.Size(84, 24);
            this.DayRadio.TabIndex = 14;
            this.DayRadio.TabStop = true;
            this.DayRadio.Text = "By Day";
            this.DayRadio.UseVisualStyleBackColor = true;
            // 
            // UserRadio
            // 
            this.UserRadio.AutoSize = true;
            this.UserRadio.Location = new System.Drawing.Point(507, 59);
            this.UserRadio.Name = "UserRadio";
            this.UserRadio.Size = new System.Drawing.Size(90, 24);
            this.UserRadio.TabIndex = 13;
            this.UserRadio.TabStop = true;
            this.UserRadio.Text = "By User";
            this.UserRadio.UseVisualStyleBackColor = true;
            // 
            // TypeRadio
            // 
            this.TypeRadio.AutoSize = true;
            this.TypeRadio.Location = new System.Drawing.Point(213, 59);
            this.TypeRadio.Name = "TypeRadio";
            this.TypeRadio.Size = new System.Drawing.Size(170, 24);
            this.TypeRadio.TabIndex = 12;
            this.TypeRadio.TabStop = true;
            this.TypeRadio.Text = "By Type and Month";
            this.TypeRadio.UseVisualStyleBackColor = true;
            // 
            // TypeDropdown
            // 
            this.TypeDropdown.FormattingEnabled = true;
            this.TypeDropdown.Location = new System.Drawing.Point(295, 107);
            this.TypeDropdown.Name = "TypeDropdown";
            this.TypeDropdown.Size = new System.Drawing.Size(212, 28);
            this.TypeDropdown.TabIndex = 17;
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Location = new System.Drawing.Point(198, 107);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(47, 20);
            this.TypeLabel.TabIndex = 16;
            this.TypeLabel.Text = "Type:";
            // 
            // MonthDropdown
            // 
            this.MonthDropdown.FormattingEnabled = true;
            this.MonthDropdown.Location = new System.Drawing.Point(670, 107);
            this.MonthDropdown.Name = "MonthDropdown";
            this.MonthDropdown.Size = new System.Drawing.Size(212, 28);
            this.MonthDropdown.TabIndex = 19;
            // 
            // MonthLabel
            // 
            this.MonthLabel.AutoSize = true;
            this.MonthLabel.Location = new System.Drawing.Point(573, 107);
            this.MonthLabel.Name = "MonthLabel";
            this.MonthLabel.Size = new System.Drawing.Size(58, 20);
            this.MonthLabel.TabIndex = 18;
            this.MonthLabel.Text = "Month:";
            // 
            // TotalLabel
            // 
            this.TotalLabel.AutoSize = true;
            this.TotalLabel.Location = new System.Drawing.Point(481, 164);
            this.TotalLabel.Name = "TotalLabel";
            this.TotalLabel.Size = new System.Drawing.Size(48, 20);
            this.TotalLabel.TabIndex = 20;
            this.TotalLabel.Text = "Total:";
            // 
            // TotalEditHere
            // 
            this.TotalEditHere.AutoSize = true;
            this.TotalEditHere.Location = new System.Drawing.Point(546, 164);
            this.TotalEditHere.Name = "TotalEditHere";
            this.TotalEditHere.Size = new System.Drawing.Size(104, 20);
            this.TotalEditHere.TabIndex = 21;
            this.TotalEditHere.Text = "Number Here";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(213, 198);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(669, 150);
            this.dataGridView1.TabIndex = 22;
            // 
            // UserDropdown
            // 
            this.UserDropdown.FormattingEnabled = true;
            this.UserDropdown.Location = new System.Drawing.Point(295, 107);
            this.UserDropdown.Name = "UserDropdown";
            this.UserDropdown.Size = new System.Drawing.Size(212, 28);
            this.UserDropdown.TabIndex = 24;
            // 
            // UserLabel
            // 
            this.UserLabel.AutoSize = true;
            this.UserLabel.Location = new System.Drawing.Point(198, 107);
            this.UserLabel.Name = "UserLabel";
            this.UserLabel.Size = new System.Drawing.Size(47, 20);
            this.UserLabel.TabIndex = 23;
            this.UserLabel.Text = "User:";
            // 
            // DatePicker
            // 
            this.DatePicker.Location = new System.Drawing.Point(295, 107);
            this.DatePicker.MaxSelectionCount = 1;
            this.DatePicker.Name = "DatePicker";
            this.DatePicker.TabIndex = 25;
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(495, 379);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(115, 42);
            this.ExitButton.TabIndex = 26;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            // 
            // DayLabel
            // 
            this.DayLabel.AutoSize = true;
            this.DayLabel.Location = new System.Drawing.Point(198, 110);
            this.DayLabel.Name = "DayLabel";
            this.DayLabel.Size = new System.Drawing.Size(41, 20);
            this.DayLabel.TabIndex = 27;
            this.DayLabel.Text = "Day:";
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 450);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.TotalEditHere);
            this.Controls.Add(this.TotalLabel);
            this.Controls.Add(this.MonthDropdown);
            this.Controls.Add(this.MonthLabel);
            this.Controls.Add(this.TypeDropdown);
            this.Controls.Add(this.TypeLabel);
            this.Controls.Add(this.ReportsHeader);
            this.Controls.Add(this.DayRadio);
            this.Controls.Add(this.UserRadio);
            this.Controls.Add(this.TypeRadio);
            this.Controls.Add(this.DayLabel);
            this.Controls.Add(this.UserLabel);
            this.Controls.Add(this.UserDropdown);
            this.Controls.Add(this.DatePicker);
            this.Name = "Reports";
            this.Text = "Reports";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ReportsHeader;
        private System.Windows.Forms.RadioButton DayRadio;
        private System.Windows.Forms.RadioButton UserRadio;
        private System.Windows.Forms.RadioButton TypeRadio;
        private System.Windows.Forms.ComboBox TypeDropdown;
        private System.Windows.Forms.Label TypeLabel;
        private System.Windows.Forms.ComboBox MonthDropdown;
        private System.Windows.Forms.Label MonthLabel;
        private System.Windows.Forms.Label TotalLabel;
        private System.Windows.Forms.Label TotalEditHere;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox UserDropdown;
        private System.Windows.Forms.Label UserLabel;
        private System.Windows.Forms.MonthCalendar DatePicker;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label DayLabel;
    }
}