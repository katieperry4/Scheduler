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
    public class CustomerPresenter
    {
        private Forms.Customer _customerForm;
        private string _connectionString;
        private CultureInfo _culture;
        private int _userId;

        public CustomerPresenter(Forms.Customer customerForm, string connectionString, CultureInfo currentCulture, int userId)
        {
            _customerForm = customerForm;
            _connectionString = connectionString;
            _culture = currentCulture;
            _userId = userId;

            _customerForm.setPresenter(this);
        }

        public void cancel()
        {
            Program.showMenu(_userId, _culture, _connectionString);
            _customerForm.Hide();
        }

        public List<Models.Customer> getCustomerNames()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                List<Models.Customer> customerList = new List<Models.Customer>();
                string query = "SELECT customerId, customerName, addressId FROM customer";
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) 
                {
                    customerList.Add(new Models.Customer
                    {
                        customerId = reader.GetInt32("customerId"),
                        customerName = reader.GetString("customerName"),
                        addressId = reader.GetInt32("addressId")
                    });
                }
                return customerList;

            }
                
         }


        public Models.Address getCustomerAddress(int addressId)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                Models.Address address = new Models.Address();
                string query = "SELECT * FROM address WHERE addressId = @id";
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("id", addressId);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        address.addressId = reader.GetInt32("addressId");
                        address.address = reader.GetString("address");
                        address.address2 = reader.GetString("address2");
                        address.cityId = reader.GetInt32("cityId");
                        address.postalCode = reader.GetString("postalCode");
                        address.phone = reader.GetString("phone");
                    }
                };
                
                return address;

            }
        }


        public Models.City getCustomerCity(int cityId)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                Models.City city = new Models.City();
                string query = "SELECT * FROM city WHERE cityId = @id";
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("id", cityId);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        city.cityId = reader.GetInt32("cityId");
                        city.city = reader.GetString("city");
                        city.countryId = reader.GetInt32("countryId");
                    }
                };

                return city;

            }
        }


        public Models.Country getCustomerCountry(int countryId)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                Models.Country country = new Models.Country();
                string query = "SELECT * FROM country WHERE countryId = @id";
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("id", countryId);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        country.countryId = reader.GetInt32("countryId");
                        country.country = reader.GetString("country");
                    }
                };

                return country;

            }
        }




        public void addCustomer(string customerName, string customerPhone, string customerAddress, string customerCity, string customerZip, string customerCountry)
        {
            MessageBox.Show($"adding customer {customerName}");
        }
        public void editCustomer(int customerId, string customerName, string customerPhone, string customerAddress, string customerCity, string customerZip, string customerCountry)
        {
            MessageBox.Show($"editing customer {customerName}");
        }

        public bool deleteCustomer(int customerId)
        {
            string message = "Are you sure you want to delete this customer?";
            string caption = "Are you sure?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
            bool appointmentStatus = hasAppointments(customerId);
            if (result == DialogResult.Yes && appointmentStatus == false) {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                 
                    string query = "DELETE FROM customer WHERE customerId = @id";
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("id", customerId);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        
                    };

                    return true;

                }
            } else
            {
                return false;
            }
            

        }
        public bool hasAppointments(int customerId)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                List<Models.Appointment> appointments = new List<Models.Appointment>();
                string query = "SELECT * FROM appointment WHERE customerId = @id";
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("id", customerId);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        appointments.Add(new Models.Appointment 
                        {
                            appointmentId = reader.GetInt32("appointmentId")
                        });
                    }
                };

                if (appointments.Count > 0)
                {
                    return true;
                } else
                {
                    return false;
                }

            }
        }

        public bool hasEntry(string tableName, string columnName, string searchTerm)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                int count = 0;
                string query = "SELECT * FROM @table WHERE @column = @searchTerm";
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("searchTerm", searchTerm);
                    cmd.Parameters.AddWithValue("table", tableName);
                    cmd.Parameters.AddWithValue("column", columnName);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        count++;
                    }
                };

                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
    }
}
