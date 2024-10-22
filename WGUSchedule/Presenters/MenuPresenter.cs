using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WGUSchedule.Forms;

namespace WGUSchedule.Presenters
{
    public class MenuPresenter
    {
        private int _userId;
        private CultureInfo _culture;
        private string _connectionString;
        private Forms.Menu _menuForm;

        public MenuPresenter(Forms.Menu menuForm, string connectionString, CultureInfo currentCulture, int userId)
        {
            _userId = userId;
            _culture = currentCulture;
            _connectionString = connectionString;
            _menuForm = menuForm;
            _menuForm.setPresenter(this);
        }
        public string getTime()
        {
            DateTime dateTime = DateTime.Now;
            return dateTime.ToString();
        }
        public void redirect(string menuSelection)
        {
            if (menuSelection == null)
            {
                return;
            }
            else if (menuSelection == "customer")
            {
                Program.showCustomer(_userId, _culture, _connectionString);
                _menuForm.Hide();
            }
            else if (menuSelection == "calendar")
            {
                Program.showCalendar(_userId, _culture, _connectionString);
                _menuForm.Hide();
            }
            else if (menuSelection == "appointments")
            {
                Program.showAppointments(_userId, _culture, _connectionString);
                _menuForm.Hide();
            }
            else
            {
                //reports

            }
        }
    }
}
