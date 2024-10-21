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
            this.StartTimeDropdown = new System.Windows.Forms.ComboBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
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
            // 
            // AppointmentGrid
            // 
            this.AppointmentGrid.AllowUserToAddRows = false;
            this.AppointmentGrid.AllowUserToDeleteRows = false;
            this.AppointmentGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AppointmentGrid.Location = new System.Drawing.Point(196, 172);
            this.AppointmentGrid.MultiSelect = false;
            this.AppointmentGrid.Name = "AppointmentGrid";
            this.AppointmentGrid.ReadOnly = true;
            this.AppointmentGrid.RowHeadersWidth = 62;
            this.AppointmentGrid.RowTemplate.Height = 28;
            this.AppointmentGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AppointmentGrid.Size = new System.Drawing.Size(807, 150);
            this.AppointmentGrid.TabIndex = 12;
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
            this.StartTimeLabel.Location = new System.Drawing.Point(443, 425);
            this.StartTimeLabel.Name = "StartTimeLabel";
            this.StartTimeLabel.Size = new System.Drawing.Size(86, 20);
            this.StartTimeLabel.TabIndex = 15;
            this.StartTimeLabel.Text = "Start Time:";
            // 
            // StartTimeDropdown
            // 
            this.StartTimeDropdown.FormattingEnabled = true;
            this.StartTimeDropdown.Location = new System.Drawing.Point(540, 417);
            this.StartTimeDropdown.Name = "StartTimeDropdown";
            this.StartTimeDropdown.Size = new System.Drawing.Size(212, 28);
            this.StartTimeDropdown.TabIndex = 16;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(622, 491);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(96, 36);
            this.CancelButton.TabIndex = 21;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(463, 491);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(96, 36);
            this.SaveButton.TabIndex = 20;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // Appointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 580);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.StartTimeDropdown);
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
            this.Name = "Appointment";
            this.Text = "Appointment";
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
        private System.Windows.Forms.ComboBox StartTimeDropdown;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveButton;
    }
}