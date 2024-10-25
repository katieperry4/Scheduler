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
    public partial class Calendar : Form
    {
        private CalendarPresenter _calendarPresenter;
        private int _userId;
        private List<Models.AppointmentExpanded> _allAppointments;

        public Calendar()
        {
            InitializeComponent();
        }

        public void setPresenter(CalendarPresenter calendarPresenter, int userId)
        {
            _calendarPresenter = calendarPresenter;
            _userId = userId;
            formatDataGrid();
        }


        private void formatDataGrid()
        {
            CalendarGrid.AutoGenerateColumns = false;
            CalendarGrid.Columns.Clear();
            CalendarGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "customerName",
                HeaderText = "Customer",
                Name = "customerName"
            });
            CalendarGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "type",
                HeaderText = "Appointment Type"
            });
            CalendarGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "start",
                HeaderText = "Start Time",
                Name = "Start"
            });
            CalendarGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "end",
                HeaderText = "End Time",
                Name = "End"
            });
            
            CalendarGrid.Columns["Start"].DefaultCellStyle.Format = "MM/dd/yyyy hh:mm:ss";
            CalendarGrid.Columns["End"].DefaultCellStyle.Format = "MM/dd/yyyy hh:mm:ss";
        }

        private void Calendar_Load(object sender, EventArgs e)
        {
            List<Models.AppointmentExpanded> allAppointments = _calendarPresenter.getAllAppointments(_userId);
            _allAppointments = allAppointments;
            CalendarGrid.DataSource = _allAppointments;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            _calendarPresenter.cancel();
        }

        private void AllRadio_CheckedChanged(object sender, EventArgs e)
        {
            checkChange();
        }

        private void WeekRadio_CheckedChanged(object sender, EventArgs e)
        {
            checkChange();
        }

        private void MonthRadio_CheckedChanged(object sender, EventArgs e)
        {
            checkChange();
        }

        public void checkChange()
        {
            if (AllRadio.Checked)
            {
                List<Models.AppointmentExpanded> allAppointments = _calendarPresenter.getAllAppointments(_userId);
                _allAppointments = allAppointments;
                CalendarGrid.DataSource = _allAppointments;
            }
            else if (WeekRadio.Checked)
            {
                DateTime timeNow = DateTime.Now;
                DateTime timePlusWeek = timeNow.AddDays(7);
                List<Models.AppointmentExpanded> weekAppointments = new List<Models.AppointmentExpanded>();
                foreach (Models.AppointmentExpanded appointment in _allAppointments)
                {
                    if (appointment.start.Year == timeNow.Year && appointment.start.Month == timeNow.Month && (appointment.start <= timePlusWeek && appointment.start >= timeNow ))
                    {
                        weekAppointments.Add(appointment);
                    }
                }
                CalendarGrid.DataSource = weekAppointments;
            }
            else
            {
                DateTime timeNow = DateTime.Now;
                List<Models.AppointmentExpanded> monthAppointments = new List<Models.AppointmentExpanded>();
                foreach (Models.AppointmentExpanded appointment in _allAppointments) 
                {
                    if (appointment.start.Month == timeNow.Month && appointment.start.Year == timeNow.Year)
                    {
                        monthAppointments.Add(appointment);
                    }
                }
                CalendarGrid.DataSource = monthAppointments;
            }
        }

        private void Calendar_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
