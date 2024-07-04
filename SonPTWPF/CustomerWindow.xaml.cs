using System.Windows;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DataAccess.Models;

namespace SonPTWPF
{
    public partial class CustomerWindow : Window
    {
        private Customer _customer;

        public CustomerWindow(Customer customer)
        {
            InitializeComponent();
            _customer = customer;
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            ProfileWindow profileWindow = new ProfileWindow(_customer);
            profileWindow.ShowDialog();
        }

        private void btnReservationHistory_Click(object sender, RoutedEventArgs e)
        {
            ReservationHistoryWindow reservationHistoryWindow = new ReservationHistoryWindow(_customer);
            reservationHistoryWindow.ShowDialog();
        }
    }
}
