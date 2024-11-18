using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;
using WGUSchedule.Forms;
using WGUSchedule.Presenters;

namespace WGUSchedule
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            CultureInfo currentUICulture = CultureInfo.CurrentUICulture;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            string connectionString = "server=127.0.0.1;user=sqlUser;database=client_schedule;port=3306;password=Passw0rd!";

            Login loginForm = new Login();
            LoginPresenter loginPresenter  = new LoginPresenter(loginForm, connectionString, currentCulture);

            
            
            Application.Run(loginForm);
        }
        public static void showMenu(int userId, CultureInfo currentCulture, string connectionString)
        {
            Forms.Menu menuForm = new Forms.Menu();
            MenuPresenter menuPresenter = new MenuPresenter(menuForm, connectionString, currentCulture, userId);
            menuForm.Show();
        }

        public static void showCustomer(int userId, CultureInfo currentCulture, string connectionString)
        {
            Forms.Customer customerForm = new Forms.Customer();
            CustomerPresenter customerPresenter = new CustomerPresenter(customerForm, connectionString, currentCulture, userId);
            customerForm.Show();
        }

        public static void showAppointments(int userId, CultureInfo currentCulture, string connectionString)
        {
            Forms.Appointment appointmentForm = new Forms.Appointment();
            AppointmentPresenter appointmentPresenter = new AppointmentPresenter(appointmentForm, connectionString, currentCulture, userId);
            appointmentForm.Show();
        }

        public static void showCalendar(int userId, CultureInfo currentCulture, string connectionString)
        {
            Forms.Calendar calendarForm = new Forms.Calendar();
            CalendarPresenter calendarPresenter = new CalendarPresenter(calendarForm, connectionString, currentCulture, userId);
            calendarForm.Show();
        }

        public static void showReports(int userId, CultureInfo currentCulture, string connectionString)
        {
            Forms.Reports reportsForm = new Forms.Reports();
            ReportsPresenter reportsPresenter = new ReportsPresenter(reportsForm, connectionString, currentCulture, userId);
            reportsForm.Show();
        }
    }
}
