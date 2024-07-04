using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class CustomerDAO
    {
        private readonly FuminiHotelManagementContext _context;

        public CustomerDAO(FuminiHotelManagementContext context)
        {
            _context = context;
        }
        public static List<Customer> GetCustomers()
        {
            var list = new List<Customer>();
            try
            {
                using var db = new FuminiHotelManagementContext();
                list = db.Customers.ToList();
            }
            catch (Exception ex) { }
            return list;
        }
        public static void SaveCustomer(Customer cus)
        {
            try
            {
                using var context = new FuminiHotelManagementContext();
                context.Customers.Add(cus);
                context.SaveChanges();
            }
            catch (Exception ex) { }
        }
        public static void DeleteCustomer(Customer r)
        {
            try
            {
                using var context = new FuminiHotelManagementContext();
                var r1 =
                    context.Customers.SingleOrDefault(c => c.CustomerId.Equals(r.CustomerId));
                context.SaveChanges();
            }
            catch (Exception ex) { }
        }
        public static void UpdateCustomer(Customer r)
        {
            try
            {
                using var context = new FuminiHotelManagementContext();
                context.Entry<Customer>(r).State
                    = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex) { }
        }
        public static Customer GetCustomerById(int id)
        {
            using var db = new FuminiHotelManagementContext();
            return db.Customers.FirstOrDefault(c => c.CustomerId.Equals(id));
        }

    }
}
