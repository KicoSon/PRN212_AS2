using System.Collections.Generic;
using System.Linq;
using System.Windows;
using DataAccess.DAO;
using DataAccess.Models;
using DataAccess.Repository;

namespace SonPTWPF
{
    public partial class BookingInfoWindow : Window
    {
        private readonly BookingRepository _bookingRepository;
        private readonly FuminiHotelManagementContext _context;
        public List<BookingDetail> Bookings { get; set; }
        public BookingDetail SelectedBooking { get; set; }

        public BookingInfoWindow()
        {
            InitializeComponent();
            _context = new FuminiHotelManagementContext();
            _bookingRepository = new BookingRepository(new BookingDAO(_context));
            RefreshBookingData();
        }

        private void RefreshBookingData()
        {
            Bookings = _bookingRepository.GetAllBooking().ToList();
            dgBookings.ItemsSource = Bookings;
        }

        private void btnCreateBooking_Click(object sender, RoutedEventArgs e)
        {
            BookingDetail newBooking = new BookingDetail
            {
                BookingReservationId = int.Parse(txtBookingReservationID.Text),
                RoomId = int.Parse(txtRoomID.Text),
                StartDate = dpStartDate.SelectedDate.Value,
                EndDate = dpEndDate.SelectedDate.Value,
                ActualPrice = decimal.Parse(txtActualPrice.Text)
            };

            _bookingRepository.AddBooking(newBooking);
            RefreshBookingData();
            ClearInputs();
        }

        private void btnUpdateBooking_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedBooking != null)
            {
                SelectedBooking.BookingReservationId = int.Parse(txtBookingReservationID.Text);
                SelectedBooking.RoomId = int.Parse(txtRoomID.Text);
                SelectedBooking.StartDate = dpStartDate.SelectedDate.Value;
                SelectedBooking.EndDate = dpEndDate.SelectedDate.Value;
                SelectedBooking.ActualPrice = decimal.Parse(txtActualPrice.Text);

                _bookingRepository.UpdateBooking(SelectedBooking);
                RefreshBookingData();
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Please select a booking to update.");
            }
        }

        private void btnDeleteBooking_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedBooking != null)
            {
                _bookingRepository.DeleteBooking(SelectedBooking);
                RefreshBookingData();
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Please select a booking to delete.");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ClearInputs()
        {
            txtBookingReservationID.Text = "";
            txtRoomID.Text = "";
            dpStartDate.SelectedDate = null;
            dpEndDate.SelectedDate = null;
            txtActualPrice.Text = "";
        }

        private void dgBookingData_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            SelectedBooking = dgBookings.SelectedItem as BookingDetail;
            if (SelectedBooking != null)
            {
                txtBookingReservationID.Text = SelectedBooking.BookingReservationId.ToString();
                txtRoomID.Text = SelectedBooking.RoomId.ToString();
                dpStartDate.SelectedDate = SelectedBooking.StartDate;
                dpEndDate.SelectedDate = SelectedBooking.EndDate;
                txtActualPrice.Text = SelectedBooking.ActualPrice.ToString();
            }
        }
    }
}
