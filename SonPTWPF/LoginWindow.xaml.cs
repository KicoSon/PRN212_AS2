using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using DataAccess.Models;

namespace SonPTWPF
{
    public partial class LoginWindow : Window
    {
        private string _adminEmail;
        private string _adminPassword;

        public LoginWindow()
        {
            InitializeComponent();
            LoadConfiguration();
        }

        private void LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            _adminEmail = configuration["Login:Email"];
            _adminPassword = configuration["Login:Password"];
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = txtUser.Text;
            string password = txtPass.Password;

            if (email == "admin@FUMiniHotelSystem.com" && password == "@@abc123@@")
            {
                MessageBox.Show("Admin login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                var customer = ValidateCustomerLogin(email, password);
                if (customer != null)
                {
                    MessageBox.Show("Customer login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    CustomerWindow customerWindow = new CustomerWindow(customer);
                    customerWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid email or password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private Customer ValidateCustomerLogin(string email, string password)
        {
            using (var context = new FuminiHotelManagementContext())
            {
                return context.Customers.FirstOrDefault(c => c.EmailAddress == email && c.Password == password);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
