using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WGUSchedule.Presenters;

namespace WGUSchedule.Forms
{
    public partial class Customer : Form
    {
        private CustomerPresenter _customerPresenter;
        private List<Models.Customer> _customerNamesRaw;

        public Customer()
        {
            InitializeComponent();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            refreshDropdown();
        }

        public void refreshDropdown()
        {
            CustomerDropdown.Items.Clear();
            List<Models.Customer> customerNamesRaw = _customerPresenter.getCustomerNames();
            _customerNamesRaw = customerNamesRaw;

            foreach (Models.Customer customer in _customerNamesRaw)
            {
                CustomerDropdown.Items.Add(customer.customerName);
            }
        }

        public void setPresenter(CustomerPresenter customerPresenter)
        {
            _customerPresenter = customerPresenter;
        }

        private void Customer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            _customerPresenter.cancel();
        }

        private void ZipBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                return;
            }
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
                return;
            }
            e.Handled = true;
        }

        private void PhoneBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                return;
            }
            if (char.IsDigit(e.KeyChar) || e.KeyChar.Equals('-'))
            {
                e.Handled = false;
                return;
            }
            e.Handled = true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string customerName = NameBox.Text.Trim();
            string customerPhone = PhoneBox.Text.Trim();
            string customerAddress = AddressBox.Text.Trim();
            string customerCity = CityBox.Text.Trim();
            string customerZip = ZipBox.Text.Trim();
            string customerCountry = CountryBox.Text.Trim();
            string selectedCustomerName = (string)CustomerDropdown.SelectedItem;
            Models.Customer selectedCustomer = _customerNamesRaw.FirstOrDefault(c => c.customerName == selectedCustomerName);
            
            if (AddRadio.Checked)
            {
                if (CountryBox.Text != "" && ZipBox.Text != "" && CityBox.Text != "" && AddressBox.Text != "" && PhoneBox.Text != "" && NameBox.Text != "")
                {
                    bool addStatus = _customerPresenter.addCustomer(customerName, customerPhone, customerAddress, customerCity, customerZip, customerCountry);
                    if (addStatus)
                    {
                        MessageBox.Show($"{customerName} added successfully.");
                        cleanupBoxes();
                        refreshDropdown();
                    } else
                    {
                        MessageBox.Show($"There was an error adding {customerName}");
                    }
                }
                else
                {
                    MessageBox.Show("All fields must be filled.");
                }
            }
            else if (EditRadio.Checked)
            {
                int selectedCustomerId = selectedCustomer.customerId;
                int selectedCustomerAddressId = selectedCustomer.addressId;
                if (CountryBox.Text != "" && ZipBox.Text != "" && CityBox.Text != "" && AddressBox.Text != "" && PhoneBox.Text != "" && NameBox.Text != "")
                {
                    try
                    {


                        _customerPresenter.editCustomer(selectedCustomerId, customerName, customerPhone, customerAddress, customerCity, customerZip, customerCountry, selectedCustomerAddressId);
                        cleanupBoxes();
                        refreshDropdown();
                        MessageBox.Show("Customer successfully edited!");
                        
                    }
                    catch (Exception ex) 
                    {
                        MessageBox.Show($"There was an error editing {customerName}: {ex}");
                    }
                }
                else
                {
                    MessageBox.Show("All fields must be filled.");
                }

            }
            else if (DeleteRadio.Checked)
            {
                int selectedCustomerId = selectedCustomer.customerId;
                if (selectedCustomerId != null)
                {
                    try
                    {
                        bool deletedStatus = _customerPresenter.deleteCustomer(selectedCustomerId);
                        if (deletedStatus)
                        {
                            CustomerDropdown.Items.Remove(CustomerDropdown.SelectedItem);
                            cleanupBoxes();
                            refreshDropdown();
                        }
                        else
                        {
                            MessageBox.Show("The customer could not be deleted. Note: customers with appointments cannot be deleted.");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("There was an error deleting this customer.");
                    }

                }
            }
        }

        public void cleanupBoxes()
        {
            CustomerDropdown.SelectedIndex = -1;
            NameBox.Clear();
            PhoneBox.Clear();
            AddressBox.Clear();
            CountryBox.Clear();
            CityBox.Clear();
            ZipBox.Clear();
        }

        public void checkValidation()
        {
            if (AddRadio.Checked)
            {
                CustomerDropdown.Enabled = false;
                cleanupBoxes();
            }
            else
            {
                CustomerDropdown.Enabled = true;
            }
        }

        private void AddRadio_CheckedChanged(object sender, EventArgs e)
        {
            checkValidation();
        }

        private void EditRadio_CheckedChanged(object sender, EventArgs e)
        {
            checkValidation();
        }

        private void DeleteRadio_CheckedChanged(object sender, EventArgs e)
        {
            checkValidation();
        }

        private void CustomerDropdown_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string selectedCustomerName = (string)CustomerDropdown.SelectedItem;
            Models.Customer selectedCustomer = _customerNamesRaw.FirstOrDefault(c => c.customerName == selectedCustomerName);
            if (selectedCustomer != null)
            {
                int selectedCustomerId = selectedCustomer.customerId;
                int selectedAddressId = selectedCustomer.addressId;
                Models.Address customerAddress = _customerPresenter.getCustomerAddress(selectedAddressId);
                Models.City customerCity = _customerPresenter.getCustomerCity(customerAddress.cityId);
                Models.Country customerCountry = _customerPresenter.getCustomerCountry(customerCity.countryId);

                NameBox.Text = selectedCustomerName;
                PhoneBox.Text = customerAddress.phone;
                AddressBox.Text = customerAddress.address;
                ZipBox.Text = customerAddress.postalCode;
                CityBox.Text = customerCity.city;
                CountryBox.Text = customerCountry.country;

            }
        }
    }
}
