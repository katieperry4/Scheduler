using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using WGUSchedule.Forms;
using WGUSchedule.Models;

namespace WGUSchedule.Presenters
{
    public class LoginPresenter
    {
        private Login _loginForm;
        private string _connectionString;
        private CultureInfo _culture;

        public LoginPresenter(Login loginForm, string connectionString, CultureInfo culture)
        {
            _loginForm = loginForm;
            _connectionString = connectionString;
            _culture = culture;

            _loginForm.setPresenter(this);
        }

        public void testFunction()
        {
            MessageBox.Show("This is working");
        }

        public void login(string userName, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                List<User> users = new List<User>();
                string query = $"SELECT * FROM user WHERE userName = @userName AND password = @password";
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@userName", userName);
                    cmd.Parameters.AddWithValue("@password", password);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            userId = reader.GetInt32("userId"),
                            userName = reader.GetString("userName"),
                            password = reader.GetString("password"),
                        });
                    }
                }
                if (users.Count == 1)
                {
                    int userId = users[0].userId;
                    checkAppointments(userId);
                    Program.showMenu(users[0].userId, _culture, _connectionString);
                    _loginForm.Hide();
                }
                else
                {
                    if (_culture.TwoLetterISOLanguageName == "fr")
                    {
                        MessageBox.Show("Nom d'utilisateur ou mot de passe invalide");
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password");
                    }
                }
            }
        }

        private void checkAppointments(int userId)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = @"SELECT COUNT(*) FROM appointment WHERE userId = @userId AND start <= UTC_TIMESTAMP() + INTERVAL 15 MINUTE 
AND start >= UTC_TIMESTAMP()";
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("userId", userId);
                    
                    object result = cmd.ExecuteScalar();

                    int appointmentCount = result != null ? Convert.ToInt32(result) : 0;
                    if (appointmentCount > 0)
                    {
                        MessageBox.Show("You have an appointment within the next 15 minutes");
                        return;
                    }
                    return;
                }

            }
        }

        public string getCulture()
        {
            return _culture.TwoLetterISOLanguageName;
        }
    }
}
