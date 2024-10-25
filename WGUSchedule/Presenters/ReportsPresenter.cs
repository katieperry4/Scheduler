using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGUSchedule.Forms;
using WGUSchedule.Models;

namespace WGUSchedule.Presenters
{
    public class ReportsPresenter
    {
        private Reports _reportsForm;
        private string _connectionString;
        private CultureInfo _culture;
        private int _userId;

        public ReportsPresenter(Forms.Reports reportsForm, string connectionString, CultureInfo currentCulture, int userId)
        {
            _reportsForm = reportsForm;
            _connectionString = connectionString;
            _culture = currentCulture;
            _userId = userId;

            _reportsForm.setPresenter(this, _userId);
        }

        internal void cancel()
        {
            Program.showMenu(_userId, _culture, _connectionString);
            _reportsForm.Hide();
        }

        public List<User> getUserInfo()
        {
            List<Models.User> userList = new List<Models.User>();
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT userId, userName FROM user";
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    userList.Add(new Models.User
                    {
                        userId = reader.GetInt32("userId"),
                        userName = reader.GetString("userName")
                    });
                }
            }
            return userList;
        }

        internal int getTypeAppointments(int monthSelection, string typeSelection)
        {
            //lambda function to calculate the next month for the end of the date range
            //in the SQL query.
            Func<int, int> getNextMonth = month => month == 12 ? 1 : month + 1;
            int nextMonth = getNextMonth(monthSelection);
            //int nextMonth = monthSelection == 12 ? 1 : nextMonth = monthSelection + 1;
            string startDate = $"2024-{monthSelection:D2}-01 00:00:00";
            string endDate = $"2024-{nextMonth:D2}-01 00:00:00";
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = @"SELECT COUNT(*) FROM appointment WHERE type = @type  
                                AND start >= @startDate AND start < @endDate";
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("type", typeSelection);
                    cmd.Parameters.AddWithValue("startDate", startDate);
                    cmd.Parameters.AddWithValue("endDate", endDate);
                    object result = cmd.ExecuteScalar();
                    int numberOfAppointments = result != null ? Convert.ToInt32(result) : 0;
                    return numberOfAppointments;
                }
            }
        }

        internal List<AppointmentExpanded> getSchedule(int selectedUser)
        {
            List<AppointmentExpanded> appointments = new List<AppointmentExpanded>();
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = @"SELECT appointment.appointmentId,
                                    appointment.start,
                                    appointment.end,
                                    appointment.type,
                                    customer.customerName 
                                FROM appointment 
                                JOIN user ON user.userId = appointment.userId
                                JOIN customer ON appointment.customerId = customer.customerId
                                WHERE appointment.userId = @userId 
                                ORDER BY appointment.start";
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("userId", selectedUser);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        appointments.Add(new AppointmentExpanded
                        {
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

        internal int getAppointmentCount(DateTime selectedDay)
        {
            int year = selectedDay.Year;
            int month = selectedDay.Month;
            int day = selectedDay.Day;
            //lambda function to convert the start and end times to UTC so the datetime value
            //works with the UTC times already in the database
            Func<DateTime, DateTime> convertToUtc = dt => dt.ToUniversalTime();
            string startTime = $"{year:D4}-{month:D2}-{day:D2} 00:00:00";
            string endTime = $"{year:D4}-{month:D2}-{day:D2} 23:59:59";

            DateTime startUTC = convertToUtc(DateTime.Parse(startTime));
            DateTime endUTC = convertToUtc(DateTime.Parse(endTime));

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = @"SELECT COUNT(*) FROM appointment WHERE  start >= @startDate AND start < @endDate";
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("startDate", startUTC);
                    cmd.Parameters.AddWithValue("endDate", endUTC);
                    object result = cmd.ExecuteScalar();
                    int numberOfAppointments = result != null ? Convert.ToInt32(result) : 0;
                    return numberOfAppointments;
                }
            }
        }
    }
}
