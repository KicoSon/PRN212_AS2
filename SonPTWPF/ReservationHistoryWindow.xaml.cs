using DataAccess.Models;
using System.Linq;
using System.Windows;

namespace SonPTWPF
{
    public partial class ReservationHistoryWindow : Window
    {
        private Customer _customer;

        public ReservationHistoryWindow(Customer customer)
        {
            InitializeComponent();
            _customer = customer;
            LoadReservationHistory();
        }

        private void LoadReservationHistory()
        {
            using (var context = new FuminiHotelManagementContext())
            {
                var reservations = context.BookingReservations
                                          .Where(br => br.CustomerId == _customer.CustomerId)
                                          .Select(br => new
                                          {
                                              br.BookingReservationId,
                                              br.BookingDate,
                                              br.TotalPrice,
                                              br.BookingStatus
                                          })
                                          .ToList();

                dataGridReservations.ItemsSource = reservations;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
