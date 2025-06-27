using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer;

namespace DataLayer
{
    public class CustomerDAO
    {
        static List<Customer> customers = new List<Customer>();
        private bool isGenerated = false;
        public List<Customer> GenerateSampleDataset()
        {
            if (isGenerated)
            {
                return customers;
            }

            customers.Add(new Customer()
            {
                CustomerID = 1,
                CompanyName = "TechGear Solutions",
                ContactName = "Alice Nguyen",
                ContactTitle = "CEO",
                Address = "123 Innovation Street, District 1",
                Phone = "0912345678"
            });

            customers.Add(new Customer()
            {
                CustomerID = 2,
                CompanyName = "NextGen Electronics JSC",
                ContactName = "Bob Tran",
                ContactTitle = "Head of Procurement",
                Address = "45 Silicon Blvd, District 3",
                Phone = "0987654321"
            });

            customers.Add(new Customer()
            {
                CustomerID = 3,
                CompanyName = "SmartTech Co., Ltd",
                ContactName = "Charlie Le",
                ContactTitle = "IT Coordinator",
                Address = "12 Embedded Lane, District 5",
                Phone = "0909090909"
            });

            customers.Add(new Customer()
            {
                CustomerID = 4,
                CompanyName = "FutureWare Inc.",
                ContactName = "Diana Pham",
                ContactTitle = "Deputy Director",
                Address = "78 Hardware Park, District 10",
                Phone = "0966332211"
            });

            customers.Add(new Customer()
            {
                CustomerID = 5,
                CompanyName = "Innovatek Vietnam LLC",
                ContactName = "Ethan Doan",
                ContactTitle = "R&D Manager",
                Address = "89 Cloud Drive, Binh Thanh District",
                Phone = "0944556677"
            });

            isGenerated = true;
            return customers;
        }

        /*public List<Customer> GetDataFromDatabase ()
        {
            return DatabaseContext.GetDbContext().Customers.ToList();
        }*/

        public List<Customer> GetCustomers()
        {
            return customers;
        }

        public bool AddCustomer(Customer customer)
        {
            Customer c = customers.FirstOrDefault(c => c.CustomerID == customer.CustomerID);
            if (c != null)
            {
                return false;
            }

            customers.Add(customer);
            return true;
        }

        public bool RemoveCustomer(int customerId)
        {
            Customer c = customers.FirstOrDefault(c => c.CustomerID == customerId);
            if (c == null)
            {
                return false;
            }

            customers.Remove(c);
            return true;
        }

        public Customer SearchCustomer(int customerId)
        {
            return customers.FirstOrDefault(c => c.CustomerID == customerId);
        }

        public bool UpdateCustomer(Customer customer)
        {
            Customer c = customers.FirstOrDefault(c => c.CustomerID == customer.CustomerID);
            if (c == null)
            {
                return false;
            }

            c.CompanyName = customer.CompanyName;
            c.ContactName = customer.ContactName;
            c.ContactTitle = customer.ContactTitle;
            c.Address = customer.Address;
            c.Phone = customer.Phone;

            return true;
        }
    }
}
