using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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

       

        public bool login(string userName, string password)
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
                    return true;
                }
                else
                {
                    if (_culture.TwoLetterISOLanguageName == "fr")
                    {
                        MessageBox.Show("Nom d'utilisateur ou mot de passe invalide");
                        return false;
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password");
                        return false;
                    }
                }
            }
        }

        private void checkAppointments(int userId)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                DateTime rightNow = DateTime.UtcNow;
                DateTime checkTime = DateTime.UtcNow.AddMinutes(15);
                string query = @"SELECT COUNT(*) FROM appointment 
                                WHERE userId = @userId 
                                AND start >= @rightNow
                                AND start <= @checkTime";
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("userId", userId);
                    cmd.Parameters.AddWithValue("rightNow", rightNow);
                    cmd.Parameters.AddWithValue("checkTime", checkTime);
                    
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

        public string getLocation()
        {
            RegionInfo regionInfo = new RegionInfo(CultureInfo.CurrentCulture.Name);
            string country = regionInfo.EnglishName;
            return country;
        }

        internal async void logLogin(string userName, bool validity)
        {
            UTF8Encoding utfEncoding = new UTF8Encoding();
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string logPath = Path.Combine(baseDirectory, "..", "..", "Logs");
            string filePath = Path.Combine(logPath, "Login_History.txt");
            string fullFilePath = Path.GetFullPath(filePath);
            DateTime loginTime = DateTime.Now.ToUniversalTime();
            byte[] content;

            if (validity)
            {
                content = utfEncoding.GetBytes($"Successful login attempt at {loginTime} UTC, with UN: {userName}\n");
            }
            else
            {
                content =  utfEncoding.GetBytes($"Failed login attempt at {loginTime} UTC, with UN: {userName}\n");
            }
            
            using(FileStream SourceStream  = File.Open(fullFilePath, FileMode.OpenOrCreate))
            {
                SourceStream.Seek(0, SeekOrigin.End);
                await SourceStream.WriteAsync(content, 0, content.Length);
            }

        }
    }
}
