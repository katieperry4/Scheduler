namespace WGUSchedule.Forms
{
    partial class Customer
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
            this.AddRadio = new System.Windows.Forms.RadioButton();
            this.EditRadio = new System.Windows.Forms.RadioButton();
            this.DeleteRadio = new System.Windows.Forms.RadioButton();
            this.CustomerHeader = new System.Windows.Forms.Label();
            this.CustomerDropdown = new System.Windows.Forms.ComboBox();
            this.CustomerLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.PhoneBox = new System.Windows.Forms.TextBox();
            this.AddressLabel = new System.Windows.Forms.Label();
            this.AddressBox = new System.Windows.Forms.TextBox();
            this.CountryLabel = new System.Windows.Forms.Label();
            this.CountryBox = new System.Windows.Forms.TextBox();
            this.CityLabel = new System.Windows.Forms.Label();
            this.CityBox = new System.Windows.Forms.TextBox();
            this.ZipLabel = new System.Windows.Forms.Label();
            this.ZipBox = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddRadio
            // 
            this.AddRadio.AutoSize = true;
            this.AddRadio.Location = new System.Drawing.Point(207, 73);
            this.AddRadio.Name = "AddRadio";
            this.AddRadio.Size = new System.Drawing.Size(136, 24);
            this.AddRadio.TabIndex = 0;
            this.AddRadio.TabStop = true;
            this.AddRadio.Text = "Add Customer";
            this.AddRadio.UseVisualStyleBackColor = true;
            this.AddRadio.CheckedChanged += new System.EventHandler(this.AddRadio_CheckedChanged);
            // 
            // EditRadio
            // 
            this.EditRadio.AutoSize = true;
            this.EditRadio.Location = new System.Drawing.Point(501, 73);
            this.EditRadio.Name = "EditRadio";
            this.EditRadio.Size = new System.Drawing.Size(135, 24);
            this.EditRadio.TabIndex = 1;
            this.EditRadio.TabStop = true;
            this.EditRadio.Text = "Edit Customer";
            this.EditRadio.UseVisualStyleBackColor = true;
            this.EditRadio.CheckedChanged += new System.EventHandler(this.EditRadio_CheckedChanged);
            // 
            // DeleteRadio
            // 
            this.DeleteRadio.AutoSize = true;
            this.DeleteRadio.Location = new System.Drawing.Point(792, 73);
            this.DeleteRadio.Name = "DeleteRadio";
            this.DeleteRadio.Size = new System.Drawing.Size(154, 24);
            this.DeleteRadio.TabIndex = 2;
            this.DeleteRadio.TabStop = true;
            this.DeleteRadio.Text = "Delete Customer";
            this.DeleteRadio.UseVisualStyleBackColor = true;
            this.DeleteRadio.CheckedChanged += new System.EventHandler(this.DeleteRadio_CheckedChanged);
            // 
            // CustomerHeader
            // 
            this.CustomerHeader.AutoSize = true;
            this.CustomerHeader.Location = new System.Drawing.Point(530, 29);
            this.CustomerHeader.Name = "CustomerHeader";
            this.CustomerHeader.Size = new System.Drawing.Size(86, 20);
            this.CustomerHeader.TabIndex = 3;
            this.CustomerHeader.Text = "Customers";
            // 
            // CustomerDropdown
            // 
            this.CustomerDropdown.FormattingEnabled = true;
            this.CustomerDropdown.Location = new System.Drawing.Point(548, 122);
            this.CustomerDropdown.Name = "CustomerDropdown";
            this.CustomerDropdown.Size = new System.Drawing.Size(212, 28);
            this.CustomerDropdown.TabIndex = 4;
            this.CustomerDropdown.SelectionChangeCommitted += new System.EventHandler(this.CustomerDropdown_SelectionChangeCommitted);
            // 
            // CustomerLabel
            // 
            this.CustomerLabel.AutoSize = true;
            this.CustomerLabel.Location = new System.Drawing.Point(414, 125);
            this.CustomerLabel.Name = "CustomerLabel";
            this.CustomerLabel.Size = new System.Drawing.Size(131, 20);
            this.CustomerLabel.TabIndex = 5;
            this.CustomerLabel.Text = "Select Customer:";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(215, 182);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(55, 20);
            this.NameLabel.TabIndex = 6;
            this.NameLabel.Text = "Name:";
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(349, 182);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(212, 26);
            this.NameBox.TabIndex = 7;
            // 
            // PhoneLabel
            // 
            this.PhoneLabel.AutoSize = true;
            this.PhoneLabel.Location = new System.Drawing.Point(215, 230);
            this.PhoneLabel.Name = "PhoneLabel";
            this.PhoneLabel.Size = new System.Drawing.Size(59, 20);
            this.PhoneLabel.TabIndex = 8;
            this.PhoneLabel.Text = "Phone:";
            // 
            // PhoneBox
            // 
            this.PhoneBox.Location = new System.Drawing.Point(349, 230);
            this.PhoneBox.Name = "PhoneBox";
            this.PhoneBox.Size = new System.Drawing.Size(212, 26);
            this.PhoneBox.TabIndex = 9;
            this.PhoneBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PhoneBox_KeyPress);
            // 
            // AddressLabel
            // 
            this.AddressLabel.AutoSize = true;
            this.AddressLabel.Location = new System.Drawing.Point(215, 277);
            this.AddressLabel.Name = "AddressLabel";
            this.AddressLabel.Size = new System.Drawing.Size(72, 20);
            this.AddressLabel.TabIndex = 10;
            this.AddressLabel.Text = "Address:";
            // 
            // AddressBox
            // 
            this.AddressBox.Location = new System.Drawing.Point(349, 277);
            this.AddressBox.Name = "AddressBox";
            this.AddressBox.Size = new System.Drawing.Size(212, 26);
            this.AddressBox.TabIndex = 11;
            // 
            // CountryLabel
            // 
            this.CountryLabel.AutoSize = true;
            this.CountryLabel.Location = new System.Drawing.Point(622, 182);
            this.CountryLabel.Name = "CountryLabel";
            this.CountryLabel.Size = new System.Drawing.Size(68, 20);
            this.CountryLabel.TabIndex = 12;
            this.CountryLabel.Text = "Country:";
            // 
            // CountryBox
            // 
            this.CountryBox.Location = new System.Drawing.Point(756, 182);
            this.CountryBox.Name = "CountryBox";
            this.CountryBox.Size = new System.Drawing.Size(212, 26);
            this.CountryBox.TabIndex = 13;
            // 
            // CityLabel
            // 
            this.CityLabel.AutoSize = true;
            this.CityLabel.Location = new System.Drawing.Point(622, 236);
            this.CityLabel.Name = "CityLabel";
            this.CityLabel.Size = new System.Drawing.Size(39, 20);
            this.CityLabel.TabIndex = 14;
            this.CityLabel.Text = "City:";
            // 
            // CityBox
            // 
            this.CityBox.Location = new System.Drawing.Point(756, 230);
            this.CityBox.Name = "CityBox";
            this.CityBox.Size = new System.Drawing.Size(212, 26);
            this.CityBox.TabIndex = 15;
            // 
            // ZipLabel
            // 
            this.ZipLabel.AutoSize = true;
            this.ZipLabel.Location = new System.Drawing.Point(622, 280);
            this.ZipLabel.Name = "ZipLabel";
            this.ZipLabel.Size = new System.Drawing.Size(77, 20);
            this.ZipLabel.TabIndex = 16;
            this.ZipLabel.Text = "Zip Code:";
            // 
            // ZipBox
            // 
            this.ZipBox.Location = new System.Drawing.Point(756, 277);
            this.ZipBox.Name = "ZipBox";
            this.ZipBox.Size = new System.Drawing.Size(212, 26);
            this.ZipBox.TabIndex = 17;
            this.ZipBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ZipBox_KeyPress);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(467, 361);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(96, 36);
            this.SaveButton.TabIndex = 18;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(626, 361);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(96, 36);
            this.CancelButton.TabIndex = 19;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // Customer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 450);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ZipBox);
            this.Controls.Add(this.ZipLabel);
            this.Controls.Add(this.CityBox);
            this.Controls.Add(this.CityLabel);
            this.Controls.Add(this.CountryBox);
            this.Controls.Add(this.CountryLabel);
            this.Controls.Add(this.AddressBox);
            this.Controls.Add(this.AddressLabel);
            this.Controls.Add(this.PhoneBox);
            this.Controls.Add(this.PhoneLabel);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.CustomerLabel);
            this.Controls.Add(this.CustomerDropdown);
            this.Controls.Add(this.CustomerHeader);
            this.Controls.Add(this.DeleteRadio);
            this.Controls.Add(this.EditRadio);
            this.Controls.Add(this.AddRadio);
            this.MinimumSize = new System.Drawing.Size(1000, 0);
            this.Name = "Customer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Customer_FormClosing);
            this.Load += new System.EventHandler(this.Customer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton AddRadio;
        private System.Windows.Forms.RadioButton EditRadio;
        private System.Windows.Forms.RadioButton DeleteRadio;
        private System.Windows.Forms.Label CustomerHeader;
        private System.Windows.Forms.ComboBox CustomerDropdown;
        private System.Windows.Forms.Label CustomerLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Label PhoneLabel;
        private System.Windows.Forms.TextBox PhoneBox;
        private System.Windows.Forms.Label AddressLabel;
        private System.Windows.Forms.TextBox AddressBox;
        private System.Windows.Forms.Label CountryLabel;
        private System.Windows.Forms.TextBox CountryBox;
        private System.Windows.Forms.Label CityLabel;
        private System.Windows.Forms.TextBox CityBox;
        private System.Windows.Forms.Label ZipLabel;
        private System.Windows.Forms.TextBox ZipBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;
    }
}