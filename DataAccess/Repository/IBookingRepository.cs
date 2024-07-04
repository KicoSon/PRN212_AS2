using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IBookingRepository
    {
        List<BookingDetail> GetAllBooking();
        BookingDetail GetBookingById(int id);
        void AddBooking(BookingDetail booking);
        void Updatebooking(BookingDetail booking);
        void DeleteBooking(BookingDetail booking);
    }
}
