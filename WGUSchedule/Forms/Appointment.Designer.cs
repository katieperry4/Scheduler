namespace WGUSchedule.Forms
{
    partial class Appointment
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
            this.AppointmentHeader = new System.Windows.Forms.Label();
            this.DeleteRadio = new System.Windows.Forms.RadioButton();
            this.EditRadio = new System.Windows.Forms.RadioButton();
            this.AddRadio = new System.Windows.Forms.RadioButton();
            this.CustomerLabel = new System.Windows.Forms.Label();
            this.CustomerDropdown = new System.Windows.Forms.ComboBox();
            this.AppointmentGrid = new System.Windows.Forms.DataGridView();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.TypeDropdown = new System.Windows.Forms.ComboBox();
            this.StartTimeLabel = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.DatePicker = new System.Windows.Forms.DateTimePicker();
            this.TimePicker = new System.Windows.Forms.DateTimePicker();
            this.DurationLabel = new System.Windows.Forms.Label();
            this.DurationDropdown = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // AppointmentHeader
            // 
            this.AppointmentHeader.AutoSize = true;
            this.AppointmentHeader.Location = new System.Drawing.Point(519, 30);
            this.AppointmentHeader.Name = "AppointmentHeader";
            this.AppointmentHeader.Size = new System.Drawing.Size(108, 20);
            this.AppointmentHeader.TabIndex = 7;
            this.AppointmentHeader.Text = "Appointments";
            // 
            // DeleteRadio
            // 
            this.DeleteRadio.AutoSize = true;
            this.DeleteRadio.Location = new System.Drawing.Point(781, 74);
            this.DeleteRadio.Name = "DeleteRadio";
            this.DeleteRadio.Size = new System.Drawing.Size(176, 24);
            this.DeleteRadio.TabIndex = 6;
            this.DeleteRadio.TabStop = true;
            this.DeleteRadio.Text = "Delete Appointment";
            this.DeleteRadio.UseVisualStyleBackColor = true;
            this.DeleteRadio.CheckedChanged += new System.EventHandler(this.DeleteRadio_CheckedChanged);
            // 
            // EditRadio
            // 
            this.EditRadio.AutoSize = true;
            this.EditRadio.Location = new System.Drawing.Point(490, 74);
            this.EditRadio.Name = "EditRadio";
            this.EditRadio.Size = new System.Drawing.Size(157, 24);
            this.EditRadio.TabIndex = 5;
            this.EditRadio.TabStop = true;
            this.EditRadio.Text = "Edit Appointment";
            this.EditRadio.UseVisualStyleBackColor = true;
            this.EditRadio.CheckedChanged += new System.EventHandler(this.EditRadio_CheckedChanged);
            // 
            // AddRadio
            // 
            this.AddRadio.AutoSize = true;
            this.AddRadio.Location = new System.Drawing.Point(196, 74);
            this.AddRadio.Name = "AddRadio";
            this.AddRadio.Size = new System.Drawing.Size(158, 24);
            this.AddRadio.TabIndex = 4;
            this.AddRadio.TabStop = true;
            this.AddRadio.Text = "Add Appointment";
            this.AddRadio.UseVisualStyleBackColor = true;
            this.AddRadio.CheckedChanged += new System.EventHandler(this.AddRadio_CheckedChanged);
            // 
            // CustomerLabel
            // 
            this.CustomerLabel.AutoSize = true;
            this.CustomerLabel.Location = new System.Drawing.Point(406, 124);
            this.CustomerLabel.Name = "CustomerLabel";
            this.CustomerLabel.Size = new System.Drawing.Size(131, 20);
            this.CustomerLabel.TabIndex = 9;
            this.CustomerLabel.Text = "Select Customer:";
            // 
            // CustomerDropdown
            // 
            this.CustomerDropdown.FormattingEnabled = true;
            this.CustomerDropdown.Location = new System.Drawing.Point(540, 121);
            this.CustomerDropdown.Name = "CustomerDropdown";
            this.CustomerDropdown.Size = new System.Drawing.Size(212, 28);
            this.CustomerDropdown.TabIndex = 8;
            this.CustomerDropdown.SelectionChangeCommitted += new System.EventHandler(this.CustomerDropdown_SelectionChangeCommitted);
            // 
            // AppointmentGrid
            // 
            this.AppointmentGrid.AllowUserToAddRows = false;
            this.AppointmentGrid.AllowUserToDeleteRows = false;
            this.AppointmentGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.AppointmentGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AppointmentGrid.Location = new System.Drawing.Point(196, 160);
            this.AppointmentGrid.MultiSelect = false;
            this.AppointmentGrid.Name = "AppointmentGrid";
            this.AppointmentGrid.ReadOnly = true;
            this.AppointmentGrid.RowHeadersWidth = 62;
            this.AppointmentGrid.RowTemplate.Height = 28;
            this.AppointmentGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AppointmentGrid.Size = new System.Drawing.Size(807, 183);
            this.AppointmentGrid.TabIndex = 12;
            this.AppointmentGrid.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.AppointmentGrid_CellMouseClick);
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Location = new System.Drawing.Point(443, 361);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(47, 20);
            this.TypeLabel.TabIndex = 13;
            this.TypeLabel.Text = "Type:";
            // 
            // TypeDropdown
            // 
            this.TypeDropdown.FormattingEnabled = true;
            this.TypeDropdown.Location = new System.Drawing.Point(540, 361);
            this.TypeDropdown.Name = "TypeDropdown";
            this.TypeDropdown.Size = new System.Drawing.Size(212, 28);
            this.TypeDropdown.TabIndex = 14;
            // 
            // StartTimeLabel
            // 
            this.StartTimeLabel.AutoSize = true;
            this.StartTimeLabel.Location = new System.Drawing.Point(336, 423);
            this.StartTimeLabel.Name = "StartTimeLabel";
            this.StartTimeLabel.Size = new System.Drawing.Size(86, 20);
            this.StartTimeLabel.TabIndex = 15;
            this.StartTimeLabel.Text = "Start Time:";
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(622, 521);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(96, 36);
            this.CancelButton.TabIndex = 21;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(463, 521);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(96, 36);
            this.SaveButton.TabIndex = 20;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // DatePicker
            // 
            this.DatePicker.Location = new System.Drawing.Point(428, 423);
            this.DatePicker.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.DatePicker.Name = "DatePicker";
            this.DatePicker.Size = new System.Drawing.Size(341, 26);
            this.DatePicker.TabIndex = 22;
            // 
            // TimePicker
            // 
            this.TimePicker.Location = new System.Drawing.Point(794, 422);
            this.TimePicker.Name = "TimePicker";
            this.TimePicker.Size = new System.Drawing.Size(200, 26);
            this.TimePicker.TabIndex = 23;
            // 
            // DurationLabel
            // 
            this.DurationLabel.AutoSize = true;
            this.DurationLabel.Location = new System.Drawing.Point(393, 478);
            this.DurationLabel.Name = "DurationLabel";
            this.DurationLabel.Size = new System.Drawing.Size(144, 20);
            this.DurationLabel.TabIndex = 24;
            this.DurationLabel.Text = "Duration: (minutes)";
            // 
            // DurationDropdown
            // 
            this.DurationDropdown.FormattingEnabled = true;
            this.DurationDropdown.Location = new System.Drawing.Point(549, 475);
            this.DurationDropdown.Name = "DurationDropdown";
            this.DurationDropdown.Size = new System.Drawing.Size(169, 28);
            this.DurationDropdown.TabIndex = 25;
            // 
            // Appointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 589);
            this.Controls.Add(this.DurationDropdown);
            this.Controls.Add(this.DurationLabel);
            this.Controls.Add(this.TimePicker);
            this.Controls.Add(this.DatePicker);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.StartTimeLabel);
            this.Controls.Add(this.TypeDropdown);
            this.Controls.Add(this.TypeLabel);
            this.Controls.Add(this.AppointmentGrid);
            this.Controls.Add(this.CustomerLabel);
            this.Controls.Add(this.CustomerDropdown);
            this.Controls.Add(this.AppointmentHeader);
            this.Controls.Add(this.DeleteRadio);
            this.Controls.Add(this.EditRadio);
            this.Controls.Add(this.AddRadio);
            this.MinimumSize = new System.Drawing.Size(1000, 56);
            this.Name = "Appointment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Appointment";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Appointment_FormClosing);
            this.Load += new System.EventHandler(this.Appointment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label AppointmentHeader;
        private System.Windows.Forms.RadioButton DeleteRadio;
        private System.Windows.Forms.RadioButton EditRadio;
        private System.Windows.Forms.RadioButton AddRadio;
        private System.Windows.Forms.Label CustomerLabel;
        private System.Windows.Forms.ComboBox CustomerDropdown;
        private System.Windows.Forms.DataGridView AppointmentGrid;
        private System.Windows.Forms.Label TypeLabel;
        private System.Windows.Forms.ComboBox TypeDropdown;
        private System.Windows.Forms.Label StartTimeLabel;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.DateTimePicker DatePicker;
        private System.Windows.Forms.DateTimePicker TimePicker;
        private System.Windows.Forms.Label DurationLabel;
        private System.Windows.Forms.ComboBox DurationDropdown;
    }
}