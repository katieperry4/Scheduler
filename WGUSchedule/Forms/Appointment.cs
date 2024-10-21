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

        public Appointment()
        {
            InitializeComponent();
        }

        private void Appointment_Load(object sender, EventArgs e)
        {

        }

        public void setPresenter(AppointmentPresenter appointmentPresenter)
        {
            _appointmentPresenter = appointmentPresenter;
        }

        private void Appointment_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            _appointmentPresenter.cancel();
        }
    }
}
