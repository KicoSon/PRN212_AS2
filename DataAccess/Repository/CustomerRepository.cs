using DataAccess.DAO;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDAO _customerDAO;
        public CustomerRepository(CustomerDAO customerDAO)
        {
            _customerDAO = customerDAO;
        }

        public List<Customer> GetAllCustomers() => CustomerDAO.GetCustomers();

        public Customer GetCustomerById(int id) => CustomerDAO.GetCustomerById(id);

        public void AddCustomer(Customer customer) => CustomerDAO.SaveCustomer(customer);

        public void UpdateCustomer(Customer customer) => CustomerDAO.UpdateCustomer(customer);

        public void DeleteCustomer(Customer customer) => CustomerDAO.DeleteCustomer(customer);
    }
}
