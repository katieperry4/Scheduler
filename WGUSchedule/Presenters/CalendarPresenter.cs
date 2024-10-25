using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGUSchedule.Models;

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

        internal List<AppointmentExpanded> getAllAppointments(int userId)
        {
            List<AppointmentExpanded> appointments = new List<AppointmentExpanded>();
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = @"SELECT * FROM appointment JOIN customer ON customer.customerId = appointment.customerId WHERE userId = @userId ORDER BY start";
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("userId", userId);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        appointments.Add(new AppointmentExpanded
                        {
                            customerId = reader.GetInt32("customerId"),
                            userId = reader.GetInt32("userId"),
                            type = reader.GetString("type"),
                            start = (DateTime)reader.GetDateTime("start").ToLocalTime(),
                            end = (DateTime)reader.GetDateTime("end").ToLocalTime(),
                            appointmentId = reader.GetInt32("appointmentId"),
                            customerName = reader.GetString("customerName")
                        });

                    }
                }
                return appointments;
            }
        }

    }
}
