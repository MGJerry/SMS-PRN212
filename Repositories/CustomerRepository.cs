using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataLayer;

namespace Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public bool AddCustomer(Customer customer)
        {
            return CustomerDAO.AddCustomer(customer);
        }

        public List<Customer> GenerateSampleDataset()
        {
            return CustomerDAO.GetCustomers();
        }

        public List<Customer> GetCustomers()
        {
            return CustomerDAO.GetCustomers();
        }

        public bool RemoveCustomer(int customerId)
        {
            return CustomerDAO.RemoveCustomer(customerId);
        }

        public Customer SearchCustomer(int customerId)
        {
            return CustomerDAO.SearchCustomer(customerId);
        }

        public bool UpdateCustomer(Customer customer)
        {
            return CustomerDAO.UpdateCustomer(customer);
        }
    }
}
