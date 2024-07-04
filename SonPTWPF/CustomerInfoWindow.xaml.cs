using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using DataAccess.DAO;
using DataAccess.Models;
using DataAccess.Repository;

namespace SonPTWPF
{
    public partial class CustomerInfoWindow : Window
    {
        private readonly CustomerRepository _customerRepository;
        private readonly FuminiHotelManagementContext _context;
        public List<Customer> Customers { get; set; }
        public Customer SelectedCustomer { get; set; }

        public CustomerInfoWindow()
        {
            InitializeComponent();
            _context = new FuminiHotelManagementContext();
            _customerRepository = new CustomerRepository(new CustomerDAO(_context));
            RefreshCustomerData();
        }

        private void RefreshCustomerData()
        {
            Customers = _customerRepository.GetAllCustomers().ToList();
            dgCustomers.ItemsSource = Customers;
        }

        private void btnCreateCustomer_Click(object sender, RoutedEventArgs e)
        {
            Customer newCustomer = new Customer
            {
                CustomerFullName = txtCustomerName.Text,
                EmailAddress = txtEmailAddress.Text,
                Telephone = txtTelephone.Text,
                CustomerBirthday = dpBirthday.SelectedDate,
                CustomerStatus = Convert.ToByte(cbStatus.SelectedIndex),
                Password = txtPassword.Password
            };

            _customerRepository.AddCustomer(newCustomer);
            RefreshCustomerData();
            ClearInputs();
        }

        private void btnUpdateCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedCustomer != null)
            {
                SelectedCustomer.CustomerFullName = txtCustomerName.Text;
                SelectedCustomer.EmailAddress = txtEmailAddress.Text;
                SelectedCustomer.Telephone = txtTelephone.Text;
                SelectedCustomer.CustomerBirthday = dpBirthday.SelectedDate;
                SelectedCustomer.CustomerStatus = Convert.ToByte(cbStatus.SelectedIndex);
                SelectedCustomer.Password = txtPassword.Password;

                _customerRepository.UpdateCustomer(SelectedCustomer);
                RefreshCustomerData();
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Please select a customer to update.");
            }
        }

        private void btnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedCustomer != null)
            {
                _customerRepository.DeleteCustomer(SelectedCustomer);
                RefreshCustomerData();
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ClearInputs()
        {
            txtCustomerName.Text = "";
            txtEmailAddress.Text = "";
            txtTelephone.Text = "";
            dpBirthday.SelectedDate = null;
            cbStatus.SelectedIndex = -1;
            txtPassword.Password = "";
        }


        private void dgCustomerData_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            SelectedCustomer = dgCustomers.SelectedItem as Customer;
            if (SelectedCustomer != null)
            {
                txtCustomerName.Text = SelectedCustomer.CustomerFullName;
                txtEmailAddress.Text = SelectedCustomer.EmailAddress;
                txtTelephone.Text = SelectedCustomer.Telephone;
                dpBirthday.SelectedDate = SelectedCustomer.CustomerBirthday;
                cbStatus.SelectedIndex = SelectedCustomer.CustomerStatus ?? -1;
                txtPassword.Password = SelectedCustomer.Password;
            }
        }
    }
}
