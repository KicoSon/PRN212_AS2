using DataAccess.DAO;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class BookingRepository
    {
        private readonly BookingDAO _bookingDAO;

        public BookingRepository(BookingDAO roomDAO)
        {
            _bookingDAO = roomDAO;
        }
        public List<BookingDetail> GetAllBooking() => BookingDAO.GetBookings();

        public BookingDetail GetBookingById(int id) => BookingDAO.GetBookingById(id);

        public void AddBooking(BookingDetail booking) => BookingDAO.SaveBooking(booking);

        public void UpdateBooking(BookingDetail booking) => BookingDAO.UpdateBooking(booking);

        public void DeleteBooking(BookingDetail booking) => BookingDAO.DeleteBooking(booking);
    }
}
