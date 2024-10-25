using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using WGUSchedule.Forms;
using MySql.Data.MySqlClient;
using WGUSchedule.Models;
using System.Windows.Forms;


namespace WGUSchedule.Presenters
{
    public class AppointmentPresenter
    {
        private Forms.Appointment _appointmentForm;
        private string _connectionString;
        private CultureInfo _culture;
        private int _userId;

        public AppointmentPresenter(Forms.Appointment appointmentForm, string connectionString, CultureInfo currentCulture, int userId)
        {
            _appointmentForm = appointmentForm;
            _connectionString = connectionString;
            _culture = currentCulture;
            _userId = userId;

            _appointmentForm.setPresenter(this, _userId);
        }

        public void cancel()
        {
            Program.showMenu(_userId, _culture, _connectionString);
            _appointmentForm.Hide();
        }

        public List<Models.Customer> getCustomerInfo()
        {
            List<Models.Customer> customerList = new List<Models.Customer>();
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT customerId, customerName FROM customer";
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    customerList.Add(new Models.Customer
                    {
                        customerId = reader.GetInt32("customerId"),
                        customerName = reader.GetString("customerName")
                    });
                }
            }
            return customerList;
        }

        public List<Models.Appointment> getAppointmentByCustomerId(int customerId)
        {
            List<Models.Appointment> appointmentList = new List<Models.Appointment>();
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = @"SELECT appointmentId, customerId, userId, type, start, end FROM appointment WHERE customerId = @customerId";
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("customerId", customerId);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        appointmentList.Add(new Models.Appointment
                        {
                            customerId = reader.GetInt32("customerId"),
                            userId = reader.GetInt32("userId"),
                            type = reader.GetString("type"),
                            start = (DateTime)reader.GetDateTime("start").ToLocalTime(),
                            end = (DateTime)reader.GetDateTime("end").ToLocalTime(),
                            appointmentId = reader.GetInt32("appointmentId")
                        });
                    }
                }

            }
            return appointmentList;
        }

        public Models.Appointment getAppointmentByAppointmentId(int appointmentId)
        {
            Models.Appointment appointment = new Models.Appointment();
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = @"SELECT appointmentId, customerId, userId, type, start FROM appointment WHERE appointmentId = @appointmentId";
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("appointmentId", appointmentId);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        appointment.type = reader.GetString("type");
                        appointment.start = reader.GetDateTime("start"); //in UTC

                    }
                }

            }

            return appointment;
        }
        public bool checkConfliction(DateTime startTimeUTC, DateTime endTimeUTC, int customerId, int userId, int appointmentId)
        {
            List<Models.Appointment> customerAppointments = getAppointmentsByCustomerAndUser(customerId, userId);
            //checking customer appointments
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = @"SELECT COUNT(*) FROM appointment 
                                WHERE customerId = @customerId 
                                AND appointmentId != @appointmentId
                                AND(
                                    (@startTime < end AND @endTime > start) OR
                                    (@endTime > start AND @startTime < end))";
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("customerId", customerId);
                    cmd.Parameters.AddWithValue("appointmentId", appointmentId);
                    cmd.Parameters.AddWithValue("startTime", startTimeUTC);
                    cmd.Parameters.AddWithValue("endTime", endTimeUTC);
                    object result = cmd.ExecuteScalar();

                    int conflictCount = result != null ? Convert.ToInt32(result) : 0;
                    if (conflictCount > 0)
                    {
                        MessageBox.Show("The customer has a conflicting appointment.");
                        return true;
                    }
                }
               
            }


            //checking user appointments
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
               
                string query = @"SELECT COUNT(*) FROM appointment WHERE userId = @userId 
                                AND appointmentId != @appointmentId
                                AND(
                                     (@startTime < end AND @endTime > start) OR
                                     (@endTime > start AND @startTime < end))";
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("userId", userId);
                    cmd.Parameters.AddWithValue("appointmentId", appointmentId);
                    cmd.Parameters.AddWithValue("startTime", startTimeUTC);
                    cmd.Parameters.AddWithValue("endTime", endTimeUTC);
                    object result = cmd.ExecuteScalar();

                    int conflictCount = result != null ? Convert.ToInt32(result) : 0;
                    if (conflictCount > 0)
                    {
                        MessageBox.Show("You have a conflicting appointment.");
                        return true;
                    }
                }
                return false;
            }
           
        }

        private List<Models.Appointment> getAppointmentsByUserId(int userId)
        {
            List<Models.Appointment> appointmentList = new List<Models.Appointment>();
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = @"SELECT start, end FROM appointment WHERE userId = @userId";
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("userId", userId);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        appointmentList.Add(new Models.Appointment
                        {
                            start = (DateTime)reader.GetDateTime("start"),
                            end = (DateTime)reader.GetDateTime("end"),
                        });
                    }
                }

            }
            return appointmentList;
        }

        private List<Models.Appointment> getAppointmentsByCustomerAndUser(int customerId, int userId)
        {
            List<Models.Appointment> appointmentList = new List<Models.Appointment>();
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = @"SELECT start, end FROM appointment WHERE customerId = @customerId AND userId = @userId";
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("customerId", customerId);
                    cmd.Parameters.AddWithValue("userId", userId);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        appointmentList.Add(new Models.Appointment
                        {
                            start = (DateTime)reader.GetDateTime("start"),
                            end = (DateTime)reader.GetDateTime("end"),
                        });
                    }
                }

            }
            return appointmentList;
        }

        public void deleteAppointment(int appointmentId)
        {
            string message = "Are you sure you want to delete this appointment?";
            string caption = "Are you sure?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
            if (result == DialogResult.Yes)
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    string query = @"DELETE FROM appointment WHERE appointmentId = @appointmentId";
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("appointmentId", appointmentId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public bool addAppointment(DateTime startTimeUTC, DateTime endTimeUTC, int customerId, int userId, string appointmentType)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = @"INSERT INTO appointment (customerId, userId, start, end, type, title, description, location, contact, createdBy, lastUpdateBy, url, createDate, lastUpdate) VALUES (@customerId, @userId, @start, @end, @type, 'not needed', 'not needed', 'not needed', 'not needed', 'not needed', 'not needed', 'not needed', NOW(), NOW())";
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("customerId", customerId);
                    cmd.Parameters.AddWithValue("userId", userId);
                    cmd.Parameters.AddWithValue("start", startTimeUTC);
                    cmd.Parameters.AddWithValue("end", endTimeUTC);
                    cmd.Parameters.AddWithValue("type", appointmentType);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
        }

        public void editAppointment(int appointmentId, DateTime startTimeUTC, DateTime endTimeUTC, string appointmentType, int customerId, int userId)
        {
            Models.Appointment oldAppointment = getAppointmentByAppointmentId(appointmentId);
            if (oldAppointment.start != startTimeUTC)
            {
                bool confliction = checkConfliction(startTimeUTC, endTimeUTC, customerId, userId, appointmentId);
                if (confliction)
                {
                    return;
                }
                editAppointmentTime(appointmentId, startTimeUTC, endTimeUTC);
            }
            if (oldAppointment.type != appointmentType) 
            {
                editAppointmentType(appointmentId,appointmentType);
            }
            
        }

        private void editAppointmentTime(int appointmentId, DateTime startTimeUTC, DateTime endTimeUTC)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = @"UPDATE appointment SET start = @startTime, end = @endTime WHERE appointmentId = @appointmentId";
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("appointmentId", appointmentId);
                    cmd.Parameters.AddWithValue("startTime", startTimeUTC);
                    cmd.Parameters.AddWithValue("endTime", endTimeUTC);
                    cmd.ExecuteNonQuery();
                }

            }
        }

        private void editAppointmentType(int appointmentId, string changeValue)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = @"UPDATE appointment SET type = @appointmentType WHERE appointmentId = @appointmentId";
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("appointmentId", appointmentId);
                    cmd.Parameters.AddWithValue("appointmentType", changeValue);
                    cmd.ExecuteNonQuery();
                }

            }
        }
    }




}

