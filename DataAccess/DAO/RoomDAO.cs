using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class RoomDAO
    {
        private readonly FuminiHotelManagementContext _context;

        public RoomDAO(FuminiHotelManagementContext context)
        {
            _context = context;
        }
        public static List<RoomInformation> GetRooms()
        {
            var list = new List<RoomInformation>();
            try
            {
                using var db = new FuminiHotelManagementContext();
                list = db.RoomInformations.ToList();
            }
            catch (Exception ex) { }
            return list;
        }
        public static void SaveRoom(RoomInformation p)
        {
            try
            {
                using var context = new FuminiHotelManagementContext();
                context.RoomInformations.Add(p);
                context.SaveChanges();
            }
            catch (Exception ex) { }
        }
        public static void DeleteRoom(RoomInformation r)
        {
            try
            {
                using var context = new FuminiHotelManagementContext();
                var r1 =
                    context.RoomInformations.SingleOrDefault(c => c.RoomId.Equals(r.RoomId));
                context.SaveChanges();
            }
            catch (Exception ex) { }
        }
        public static void UpdateRoom(RoomInformation r)
        {
            try
            {
                using var context = new FuminiHotelManagementContext();
                context.Entry<RoomInformation>(r).State
                    = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch(Exception ex) { }
        }
        public static RoomInformation GetRoomById(int id)
        {
            using var db = new FuminiHotelManagementContext();
            return db.RoomInformations.FirstOrDefault(c => c.RoomId.Equals(id));
        }
        
    }
}
