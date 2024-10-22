using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WGUSchedule.Presenters
{
    public class CalendarPresenter
    {
        private Forms.Calendar _calendarForm;
        private string _connectionString;
        private CultureInfo _culture;
        private int _userId;

        public CalendarPresenter(Forms.Calendar calendar, string connectionString, CultureInfo currentCulture, int userId)
        {
            _calendarForm = calendar;
            _connectionString = connectionString;
            _culture = currentCulture;
            _userId = userId;

            _calendarForm.setPresenter(this, _userId);
        }

        internal void cancel()
        {
            Program.showMenu(_userId, _culture, _connectionString);
            _calendarForm.Hide();
        }

        //method to return all appointments
        //method to return appointments between two dates -> able to handle week or month
            //month is easy bc we can just search for ex october 2024
            //week might take some math
    }
}
