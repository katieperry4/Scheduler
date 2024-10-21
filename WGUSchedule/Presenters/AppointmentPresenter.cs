using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using WGUSchedule.Forms;


namespace WGUSchedule.Presenters
{
    public class AppointmentPresenter
    {
        private Appointment _appointmentForm;
        private string _connectionString;
        private CultureInfo _culture;
        private int _userId;

        public AppointmentPresenter(Forms.Appointment appointmentForm, string connectionString, CultureInfo currentCulture, int userId) 
        {
            _appointmentForm = appointmentForm;
            _connectionString = connectionString;
            _culture = currentCulture;
            _userId = userId;

            _appointmentForm.setPresenter(this);
        }

        public void cancel()
        {
            Program.showMenu(_userId, _culture, _connectionString);
            _appointmentForm.Hide();
        }
    }
}
