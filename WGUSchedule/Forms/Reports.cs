using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WGUSchedule.Models;
using WGUSchedule.Presenters;

namespace WGUSchedule.Forms
{
    public partial class Reports : Form
    {
        private ReportsPresenter _reportsPresenter;
        private int _userId;
        private List<Models.User> _users;

        public Reports()
        {
            InitializeComponent();

        }

        internal void setPresenter(ReportsPresenter reportsPresenter, int userId)
        {
            _reportsPresenter = reportsPresenter;
            _userId = userId;
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            DatePicker.Hide();
            populateTypeDropdown();
            populateUserDropdown();
            populateMonthDropdown();
            formatGrid();
        }
        List<string> _appointmentTypes = new List<string>()
        {
            "Presentation",
            "Scrum",
            "Standup",
            "Check-In",
            "Training",
            "Design Review"
        };
        List<string> _months = new List<string>()
        {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"
        };
        public void populateUserDropdown()
        {
            List<Models.User> userInfo = _reportsPresenter.getUserInfo();
            _users = userInfo;
            foreach (Models.User user in _users)
            {
                UserDropdown.Items.Add(user.userName);
            }
        }

        public void populateMonthDropdown()
        {
            foreach (string month in _months)
            {
                MonthDropdown.Items.Add(month);
            }
        }
        public void populateTypeDropdown()
        {
            TypeDropdown.Items.Clear();
            foreach (var type in _appointmentTypes)
            {
                TypeDropdown.Items.Add(type);
            }
        }

        public void formatGrid()
        {
            AppointmentGrid.AutoGenerateColumns = false;
            AppointmentGrid.Columns.Clear();
            AppointmentGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "appointmentId",
                HeaderText = "Appointment Id",
                Name = "appointmentId"
            });
            AppointmentGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "customerName",
                HeaderText = "Customer"
            });

            AppointmentGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "type",
                HeaderText = "Appointment Type"
            });
            AppointmentGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "start",
                HeaderText = "Start Time",
                Name = "Start"
            });
            AppointmentGrid.Columns["Start"].DefaultCellStyle.Format = "MM/dd/yyyy hh:mm:ss";
            AppointmentGrid.ClearSelection();
        }
        private void Reports_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            _reportsPresenter.cancel();
        }

        private void TypeRadio_CheckedChanged(object sender, EventArgs e)
        {
            checkChange();
        }

        private void UserRadio_CheckedChanged(object sender, EventArgs e)
        {
            checkChange();
        }

        private void DayRadio_CheckedChanged(object sender, EventArgs e)
        {
            checkChange();
        }

        private void checkChange()
        {
            if (TypeRadio.Checked)
            {
                TotalEditHere.Text = "";
                TypeDropdown.SelectedIndex = -1;
                MonthDropdown.SelectedIndex = -1;
                TypeLabel.Show();
                TypeDropdown.Show();
                MonthLabel.Show();
                MonthDropdown.Show();
                TotalLabel.Show();
                TotalEditHere.Show();
                DayLabel.Hide();
                DatePicker.Hide();
                AppointmentGrid.Hide();
                UserDropdown.Hide();
            }
            else if (UserRadio.Checked)
            {
                UserDropdown.SelectedIndex = -1;
                AppointmentGrid.Show();
                UserDropdown.Show();
                UserLabel.Show();
                DatePicker.Hide();
                TypeDropdown.Hide();
                MonthDropdown.Hide();
                TypeLabel.Hide();
                MonthLabel.Hide();
                DayLabel.Hide();
                TotalLabel.Hide();
                TotalEditHere.Hide();
            }
            else
            {
                TotalEditHere.Text = "";
                DatePicker.Show();
                DayLabel.Show();
                TypeDropdown.Hide();
                MonthDropdown.Hide();
                TypeLabel.Hide();
                MonthLabel.Hide();
                AppointmentGrid.Hide();
                UserDropdown.Hide();
                UserLabel.Hide();
                TotalLabel.Show();
                TotalEditHere.Show();
            }
        }

        public void checkTypes()
        {
            string monthSelectionRaw = (string)MonthDropdown.SelectedItem;
            string typeSelection = (string)TypeDropdown.SelectedItem;
            if ((monthSelectionRaw != null && typeSelection != null) && (monthSelectionRaw != "" && typeSelection != ""))
            {
                int monthSelection = (int)MonthDropdown.SelectedIndex + 1;
                try
                {
                    int numberOfAppointments = _reportsPresenter.getTypeAppointments(monthSelection, typeSelection);
                    TotalEditHere.Text = numberOfAppointments.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error retrieving the requested information");
                }
            }
        }

        private void MonthDropdown_SelectionChangeCommitted(object sender, EventArgs e)
        {
            checkTypes();
        }

        private void TypeDropdown_SelectionChangeCommitted(object sender, EventArgs e)
        {
            checkTypes();
        }

        private void UserDropdown_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string selectedUserName = (string)UserDropdown.SelectedItem;
            if (selectedUserName != null && selectedUserName != "")
            {
                //Lambda function in the Linq statement, short, easy to read function
                //to get search the users list for the selected user
                Models.User selectedUser = _users.FirstOrDefault(u => u.userName == selectedUserName);
                int userId = selectedUser.userId;
                List<Models.AppointmentExpanded> appointments = _reportsPresenter.getSchedule(userId);
                AppointmentGrid.DataSource = appointments;
            }
        }

        private void DatePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDay = DatePicker.Value;
            if (selectedDay != null)
            {
                int numberOfAppointments  = _reportsPresenter.getAppointmentCount(selectedDay);
                TotalEditHere.Text = numberOfAppointments.ToString();
            }
        }
    }
}
