using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
                    //MessageBox.Show("Valid user");
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

        public string getCulture()
        {
            return _culture.TwoLetterISOLanguageName;
        }
    }
}
