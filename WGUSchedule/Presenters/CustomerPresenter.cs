using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public Models.CustomerDetails getAllCustomerInfo(int customerId)
        {
            Models.CustomerDetails customerDetailsList = new Models.CustomerDetails();
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = @"
                    SELECT 
                        customer.customerId,
                        customer.customerName,
                        address.addressId,
                        address.address,
                        address.phone,
                        address.postalCode,
                        city.cityId,    
                        city.city,
                        country.countryId,
                        country.country
                    FROM customer
                    JOIN address ON customer.addressId = address.addressId
                    JOIN city ON address.cityId = city.cityId
                    JOIN country ON city.countryId = country.countryId
                    WHERE customer.customerId = @customerId";
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("customerId", customerId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Models.CustomerDetails customerDetails = new Models.CustomerDetails
                            {
                                customerId = reader.GetInt32("customerId"),
                                customerName = reader.GetString("customerName"),
                                addressId = reader.GetInt32("addressId"),
                                address = reader.GetString("address"),
                                cityId = reader.GetInt32("cityId"),
                                city = reader.GetString("city"),
                                countryId = reader.GetInt32("countryId"),
                                country = reader.GetString("country"),
                                postalCode = reader.GetString("postalCode"),
                                phone = reader.GetString("phone")
                            };
                            customerDetailsList = customerDetails;


                        }
                    }
                }
            }
            return customerDetailsList;
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


        public int checkOrAddCountry(string countryName, string connectionString)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                Models.Country country = new Models.Country();
                string query = "SELECT * FROM country WHERE country = @countryName";
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("countryName", countryName);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        country.countryId = reader.GetInt32("countryId");
                        return country.countryId;
                    }
                    else
                    {
                        reader.Close();
                        string insertQuery = "INSERT INTO country (country, createdBy, lastUpdateBy, createDate, lastUpdate) VALUES (@newCountryName, 'test', 'test', NOW(), NOW())";
                        using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection))
                        {
                            insertCmd.Parameters.AddWithValue("newCountryName", countryName);
                            insertCmd.ExecuteNonQuery();
                            return checkOrAddCountry(countryName, connectionString);
                        }
                    }
                }
            }
        }

        public int checkOrAddCity(string cityName, int countryId, string connectionString)
        {

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                Models.City city = new Models.City();
                string query = "SELECT * FROM city WHERE city = @cityName";
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("cityName", cityName);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        city.cityId = reader.GetInt32("cityId");
                        return city.cityId;
                    }
                    else
                    {
                        reader.Close();
                        string insertQuery = "INSERT INTO city (city, countryId, createdBy, lastUpdateBy, createDate, lastUpdate) VALUES (@newCityName, @countryId, 'test', 'test', NOW(), NOW())";
                        using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection))
                        {
                            insertCmd.Parameters.AddWithValue("newCityName", cityName);
                            insertCmd.Parameters.AddWithValue("countryId", countryId);
                            insertCmd.ExecuteNonQuery();
                            return checkOrAddCity(cityName, countryId, connectionString);
                        }
                    }
                }
            }
        }

        public int checkOrAddAddress(string customerAddress, int cityId, string customerPhone, string customerZip, string connectionString)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                Models.Address address = new Models.Address();
                string query = "SELECT * FROM address WHERE address = @address";
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("address", customerAddress);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        address.addressId = reader.GetInt32("addressId");
                        return address.addressId;
                    }
                    else
                    {
                        reader.Close();
                        string insertQuery = "INSERT INTO address (address, cityId, postalCode, phone, address2, createdBy, lastUpdateBy, createDate, lastUpdate) VALUES (@address, @cityId, @postalCode, @phone, 'not needed', 'test', 'test', NOW(), NOW())";
                        using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection))
                        {
                            insertCmd.Parameters.AddWithValue("address", customerAddress);
                            insertCmd.Parameters.AddWithValue("cityId", cityId);
                            insertCmd.Parameters.AddWithValue("postalCode", customerZip);
                            insertCmd.Parameters.AddWithValue("phone", customerPhone);
                            insertCmd.ExecuteNonQuery();
                            return checkOrAddAddress(customerAddress, cityId, customerPhone, customerZip, connectionString);
                        }
                    }
                }
            }
        }

        public bool addCustomer(string customerName, string customerPhone, string customerAddress, string customerCity, string customerZip, string customerCountry)
        {
            //search, then add/get id country
            int countryId = checkOrAddCountry(customerCountry, _connectionString);
            //search, then add/get id city
            int cityId = checkOrAddCity(customerCity, countryId, _connectionString);
            //search, then add/get id address
            int addressId = checkOrAddAddress(customerAddress, cityId, customerPhone, customerZip, _connectionString);
            //compile info, add customer
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    string query = "INSERT INTO customer (customerName, addressId, active, createdBy, lastUpdateBy, createDate, lastUpdate) VALUES (@customerName, @addressId, 1, 'test', 'test', NOW(), NOW())";
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("customerName", customerName);
                        cmd.Parameters.AddWithValue("addressId", addressId);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return true;
                        }
                        else { return false; }
                    }
                }
            }
            catch
            {
                MessageBox.Show("There was an error");
                return false;
            }
        }
        public void editCustomer(int selectedCustomerId, string newCustomerName, string newCustomerPhone, string newCustomerAddress, string newCustomerCity, string newCustomerZip, string newCustomerCountry, int oldAddressId)
        {
            Models.CustomerDetails oldCustomerDetails = getAllCustomerInfo(selectedCustomerId);
            Models.CustomerDetails newCustomerDetails = new Models.CustomerDetails
            {
                customerName = newCustomerName,
                address = newCustomerAddress,
                phone = newCustomerPhone,
                postalCode = newCustomerZip,
                city = newCustomerCity,
                country = newCustomerCountry
            };
            int newCustomerCountryId = checkOrAddCountry(newCustomerDetails.country, _connectionString);
            int newCustomerCityId = checkOrAddCity(newCustomerDetails.city, newCustomerCountryId, _connectionString);
            //update customer name
            updateIfChanged("customer", "customerName", oldCustomerDetails.customerName, newCustomerDetails.customerName, "customerId", selectedCustomerId);
            //update customer country   
            updateIfChanged("city", "countryId", oldCustomerDetails.countryId, newCustomerCountryId, "cityId", newCustomerCityId);
            if (newCustomerDetails.address != oldCustomerDetails.address)
            {
                int newCustomerAddressId = checkOrAddAddress(newCustomerDetails.address, newCustomerCityId, newCustomerDetails.phone, newCustomerDetails.postalCode, _connectionString);
                updateIfChanged("customer", "addressId", oldAddressId, newCustomerAddressId, "customerId", selectedCustomerId);
                updateIfChanged("address", "phone", oldCustomerDetails.phone, newCustomerDetails.phone, "addressId", newCustomerAddressId);
                updateIfChanged("address", "postalCode", oldCustomerDetails.postalCode, newCustomerDetails.postalCode, "addressId", newCustomerAddressId);
                updateIfChanged("address", "cityId", oldCustomerDetails.cityId, newCustomerCityId, "addressId", newCustomerAddressId);

            }
            else
            {
                updateIfChanged("address", "phone", oldCustomerDetails.phone, newCustomerDetails.phone, "addressId", oldAddressId);
                updateIfChanged("address", "postalCode", oldCustomerDetails.postalCode, newCustomerDetails.postalCode, "addressId", oldAddressId);
                updateIfChanged("address", "cityId", oldCustomerDetails.cityId, newCustomerCityId, "addressId", oldAddressId);

            }
        }

        public void updateIfChanged(string tableName, string columnName, object oldValue, object newValue, string conditionColumn, object conditionValue)
        {
            if (!Equals(oldValue, newValue))
            {
                string query = $"UPDATE {tableName} SET {columnName} = @newValue WHERE {conditionColumn} = @conditionValue";
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    try
                    {
                        connection.Open();
                        using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("newValue", newValue);
                            cmd.Parameters.AddWithValue("conditionValue", conditionValue);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (MySqlException ex) 
                    {
                        MessageBox.Show($"Database Error: {ex}");
                    }
                }
            }
        }

        public bool deleteCustomer(int customerId)
        {
            string message = "Are you sure you want to delete this customer?";
            string caption = "Are you sure?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
            bool appointmentStatus = hasAppointments(customerId);
            if (result == DialogResult.Yes && appointmentStatus == false)
            {
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
            }
            else
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
                }
                else
                {
                    return false;
                }

            }
        }

    }
}
