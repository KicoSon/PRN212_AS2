using DataAccess.Models;
using System.Linq;
using System.Windows;

namespace SonPTWPF
{
    public partial class ProfileWindow : Window
    {
        private Customer _customer;

        public ProfileWindow(Customer customer)
        {
            InitializeComponent();
            _customer = customer;
            LoadProfile();
        }

        private void LoadProfile()
        {
            txtFullName.Text = _customer.CustomerFullName;
            txtEmail.Text = _customer.EmailAddress;
            txtTelephone.Text = _customer.Telephone;
            dpBirthday.SelectedDate = _customer.CustomerBirthday;
            txtPassword.Password = _customer.Password;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new FuminiHotelManagementContext())
            {
                var customer = context.Customers.FirstOrDefault(c => c.CustomerId == _customer.CustomerId);
                if (customer != null)
                {
                    customer.CustomerFullName = txtFullName.Text;
                    customer.Telephone = txtTelephone.Text;
                    customer.CustomerBirthday = dpBirthday.SelectedDate ?? customer.CustomerBirthday;
                    customer.Password = txtPassword.Password;

                    context.SaveChanges();
                    MessageBox.Show("Profile updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error updating profile.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
