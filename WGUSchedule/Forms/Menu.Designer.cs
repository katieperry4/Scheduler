namespace WGUSchedule.Forms
{
    partial class Menu
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
            this.MenuHeader = new System.Windows.Forms.Label();
            this.CustomersButton = new System.Windows.Forms.Button();
            this.AppointmentsButton = new System.Windows.Forms.Button();
            this.CalendarButton = new System.Windows.Forms.Button();
            this.ReportsButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.CurrentTimeLabel = new System.Windows.Forms.Label();
            this.Clock = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MenuHeader
            // 
            this.MenuHeader.AutoSize = true;
            this.MenuHeader.Location = new System.Drawing.Point(556, 69);
            this.MenuHeader.Name = "MenuHeader";
            this.MenuHeader.Size = new System.Drawing.Size(49, 20);
            this.MenuHeader.TabIndex = 0;
            this.MenuHeader.Text = "Menu";
            // 
            // CustomersButton
            // 
            this.CustomersButton.Location = new System.Drawing.Point(361, 118);
            this.CustomersButton.Name = "CustomersButton";
            this.CustomersButton.Size = new System.Drawing.Size(188, 89);
            this.CustomersButton.TabIndex = 1;
            this.CustomersButton.Text = "Customers";
            this.CustomersButton.UseVisualStyleBackColor = true;
            this.CustomersButton.Click += new System.EventHandler(this.CustomersButton_Click);
            // 
            // AppointmentsButton
            // 
            this.AppointmentsButton.Location = new System.Drawing.Point(361, 249);
            this.AppointmentsButton.Name = "AppointmentsButton";
            this.AppointmentsButton.Size = new System.Drawing.Size(188, 89);
            this.AppointmentsButton.TabIndex = 2;
            this.AppointmentsButton.Text = "Appointments";
            this.AppointmentsButton.UseVisualStyleBackColor = true;
            this.AppointmentsButton.Click += new System.EventHandler(this.AppointmentsButton_Click);
            // 
            // CalendarButton
            // 
            this.CalendarButton.Location = new System.Drawing.Point(607, 118);
            this.CalendarButton.Name = "CalendarButton";
            this.CalendarButton.Size = new System.Drawing.Size(188, 89);
            this.CalendarButton.TabIndex = 3;
            this.CalendarButton.Text = "Calendar";
            this.CalendarButton.UseVisualStyleBackColor = true;
            this.CalendarButton.Click += new System.EventHandler(this.CalendarButton_Click);
            // 
            // ReportsButton
            // 
            this.ReportsButton.Location = new System.Drawing.Point(607, 249);
            this.ReportsButton.Name = "ReportsButton";
            this.ReportsButton.Size = new System.Drawing.Size(188, 89);
            this.ReportsButton.TabIndex = 4;
            this.ReportsButton.Text = "Reports";
            this.ReportsButton.UseVisualStyleBackColor = true;
            this.ReportsButton.Click += new System.EventHandler(this.ReportsButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(533, 374);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(92, 44);
            this.ExitButton.TabIndex = 5;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // CurrentTimeLabel
            // 
            this.CurrentTimeLabel.AutoSize = true;
            this.CurrentTimeLabel.Location = new System.Drawing.Point(22, 18);
            this.CurrentTimeLabel.Name = "CurrentTimeLabel";
            this.CurrentTimeLabel.Size = new System.Drawing.Size(104, 20);
            this.CurrentTimeLabel.TabIndex = 6;
            this.CurrentTimeLabel.Text = "Current Time:";
            // 
            // Clock
            // 
            this.Clock.AutoSize = true;
            this.Clock.Location = new System.Drawing.Point(132, 18);
            this.Clock.Name = "Clock";
            this.Clock.Size = new System.Drawing.Size(40, 20);
            this.Clock.TabIndex = 7;
            this.Clock.Text = "0:00";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 450);
            this.Controls.Add(this.Clock);
            this.Controls.Add(this.CurrentTimeLabel);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.ReportsButton);
            this.Controls.Add(this.CalendarButton);
            this.Controls.Add(this.AppointmentsButton);
            this.Controls.Add(this.CustomersButton);
            this.Controls.Add(this.MenuHeader);
            this.MinimumSize = new System.Drawing.Size(1000, 0);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Menu_FormClosing);
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MenuHeader;
        private System.Windows.Forms.Button CustomersButton;
        private System.Windows.Forms.Button AppointmentsButton;
        private System.Windows.Forms.Button CalendarButton;
        private System.Windows.Forms.Button ReportsButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label CurrentTimeLabel;
        private System.Windows.Forms.Label Clock;
    }
}