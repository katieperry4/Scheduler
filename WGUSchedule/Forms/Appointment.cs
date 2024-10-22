using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WGUSchedule.Presenters;

namespace WGUSchedule.Forms
{
    public partial class Appointment : Form
    {
        private AppointmentPresenter _appointmentPresenter;
        private int _userId;
        private List<Models.Customer> _customerData;
        private List<Models.Appointment> _appointments;

        public Appointment()
        {
            InitializeComponent();
        }

        private void Appointment_Load(object sender, EventArgs e)
        {
            populateTypeDropdown();
            populateCustomerDropdown();
            setDatePickerFormat();
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

        public void populateTypeDropdown()
        {
            TypeDropdown.Items.Clear();
            foreach (var type in _appointmentTypes) 
            {
                TypeDropdown.Items.Add(type);
            }
        }

        public void populateCustomerDropdown()
        {
            List<Models.Customer> customerList = _appointmentPresenter.getCustomerInfo();
            _customerData = customerList;
            foreach (var customer in customerList) 
            {
                CustomerDropdown.Items.Add(customer.customerName);
            }
        }

        public void populateDataGrid(int customerId)
        {
            AppointmentGrid.AutoGenerateColumns = false;
            AppointmentGrid.Columns.Clear();
            AppointmentGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "customerId",
                HeaderText = "Customer Id"
            });
            AppointmentGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "appointmentId",
                HeaderText = "Appointment Id",
                Name = "appointmentId"
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
            List <Models.Appointment> appointmentList = _appointmentPresenter.getAppointmentByCustomerId(customerId);
            _appointments = appointmentList;
            AppointmentGrid.DataSource = _appointments;
            AppointmentGrid.ClearSelection();
        }

        public void setDatePickerFormat()
        {
            TimePicker.Format = DateTimePickerFormat.Time;
            TimePicker.ShowUpDown = true;
        }

        public void setPresenter(AppointmentPresenter appointmentPresenter, int userId)
        {
            _appointmentPresenter = appointmentPresenter;
            _userId = userId;
        }

        private void Appointment_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            _appointmentPresenter.cancel();
        }

        private void AddRadio_CheckedChanged(object sender, EventArgs e)
        {
            checkValidation();
        }

        private void EditRadio_CheckedChanged(object sender, EventArgs e)
        {
            checkValidation();
        }

        private void DeleteRadio_CheckedChanged(object sender, EventArgs e)
        {
            checkValidation();
        }

        public void checkValidation()
        {
            if (AddRadio.Checked) 
            {
                cleanupBoxes();
                AppointmentGrid.Enabled = false;
            } else
            {
                AppointmentGrid.Enabled = true;
            }
        }

        public void cleanupBoxes()
        {
            TypeDropdown.SelectedIndex = -1;
        }

        private void CustomerDropdown_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string selectedCustomerName = (string)CustomerDropdown.SelectedItem;
            Models.Customer selectedCustomer = _customerData.FirstOrDefault(c => c.customerName == selectedCustomerName);
            int selectedCustomerId = selectedCustomer.customerId;
            populateDataGrid(selectedCustomerId);
            TypeDropdown.SelectedIndex = -1;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            int rowIndex = AppointmentGrid.CurrentCell?.RowIndex ?? -1;
            int appointmentId = rowIndex >= 0 ?(int?)AppointmentGrid.Rows[rowIndex].Cells["appointmentId"]?.Value ?? 0 : 0;
            Models.Appointment selectedAppointment = _appointments.FirstOrDefault(a => a.appointmentId == appointmentId);
            string customerName = (string)CustomerDropdown.SelectedItem;
            Models.Customer selectedCustomer = _customerData.FirstOrDefault(c => c.customerName == customerName);
            int customerId = selectedCustomer.customerId;
            int userId = _userId;
            string appointmentType = TypeDropdown.Text;
            //we need userId, customerId, appointment type, selected appointment, start time
            if(DeleteRadio.Checked)
            {
                try
                {
                    _appointmentPresenter.deleteAppointment(appointmentId);
                    cleanupBoxes();
                    populateDataGrid(customerId);
                    return;
                }
                catch (Exception ex) 
                {
                    MessageBox.Show($"There was an error deleting this appointment. {ex}");
                    return;
                }
            }
            DateTime startTimeUTC = getDateFromForm();
            DateTime endTimeUTC = new DateTime(startTimeUTC.Year, startTimeUTC.Month, startTimeUTC.Day, startTimeUTC.Hour + 1, startTimeUTC.Minute, startTimeUTC.Second);
            bool validTime = withinESTLimits(startTimeUTC);
            if (validTime == false) 
            {
                return;
            }
            if (AddRadio.Checked)
            {
                bool conflictingAppointments = _appointmentPresenter.checkConfliction(startTimeUTC, endTimeUTC, customerId, userId);

                if (appointmentType == "" || appointmentType == null)
                {
                    MessageBox.Show("You must select an appointment type.");
                    return;
                }
                if (conflictingAppointments)
                {
                    return;
                }
               bool appointmentAdded = _appointmentPresenter.addAppointment(startTimeUTC, endTimeUTC, customerId, userId, appointmentType);
                if(appointmentAdded)
                {
                    populateDataGrid(customerId);
                    cleanupBoxes();
                    return;
                } else
                {
                    MessageBox.Show("There was an error adding this appointment");
                    return;
                }
            } else if (EditRadio.Checked)
            {
                if (appointmentType == "" || appointmentType == null)
                {
                    MessageBox.Show("You must select an appointment type.");
                    return;
                }
                try
                {
                    _appointmentPresenter.editAppointment(appointmentId, startTimeUTC, endTimeUTC, appointmentType, customerId, userId);
                    cleanupBoxes();
                    populateDataGrid(customerId);
                } catch
                {
                    MessageBox.Show("There was an error editing this appointment");
                }
            }
        }

        public DateTime getDateFromForm()
        {
            DateTime dateRaw = DatePicker.Value.Date + TimePicker.Value.TimeOfDay;
            DateTime dateUTC = dateRaw.ToUniversalTime();
            return dateUTC;
        }

        public bool withinESTLimits(DateTime startTime)
        {
            TimeZoneInfo estZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime estTime = TimeZoneInfo.ConvertTimeFromUtc(startTime, estZone);
            DateTime nineAM = new DateTime(estTime.Year, estTime.Month, estTime.Day, 9, 0, 0);
            DateTime fivePM = new DateTime(estTime.Year, estTime.Month, estTime.Day, 17, 0, 0);
            if (estTime >= nineAM && estTime <= fivePM) 
            {
                return true;
            } else
            {
                MessageBox.Show($"Appointments must start within 9-5 EST your selected time is {estTime} EST");
                return false;
            }
        }

        

        private void AppointmentGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = AppointmentGrid.CurrentCell.RowIndex;
            int appointmentId = (int)AppointmentGrid.Rows[rowIndex].Cells["appointmentId"].Value;
            Models.Appointment selectedAppointment = _appointments.FirstOrDefault(a => a.appointmentId == appointmentId);
            TypeDropdown.Text = selectedAppointment.type;
            DatePicker.Value = selectedAppointment.start;
            TimePicker.Value = selectedAppointment.start;
        }





    }
}
