using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class BookingDAO
    {
        private readonly FuminiHotelManagementContext _context;

        public BookingDAO(FuminiHotelManagementContext context)
        {
            _context = context;
        }
        public static List<BookingDetail> GetBookings()
        {
            var list = new List<BookingDetail>();
            try
            {
                using var db = new FuminiHotelManagementContext();
                list = db.BookingDetails.ToList();
            }
            catch (Exception ex) { }
            return list;
        }
        public static void SaveBooking(BookingDetail p)
        {
            try
            {
                using var context = new FuminiHotelManagementContext();
                context.BookingDetails.Add(p);
                context.SaveChanges();
            }
            catch (Exception ex) { }
        }
        public static void DeleteBooking(BookingDetail r)
        {
            try
            {
                using var context = new FuminiHotelManagementContext();
                var r1 =
                    context.BookingDetails.SingleOrDefault(c => c.BookingReservationId.Equals(r.BookingReservationId));
                context.SaveChanges();
            }
            catch (Exception ex) { }
        }
        public static void UpdateBooking(BookingDetail r)
        {
            try
            {
                using var context = new FuminiHotelManagementContext();
                context.Entry<BookingDetail>(r).State
                    = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex) { }
        }
        public static BookingDetail GetBookingById(int id)
        {
            using var db = new FuminiHotelManagementContext();
            return db.BookingDetails.FirstOrDefault(c => c.BookingReservationId.Equals(id));
        }

    }
}


