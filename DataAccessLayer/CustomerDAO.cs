using BusinessObjects;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public class CustomerDAO
    {
        /*static List<Customer> customers = new List<Customer>();
        private bool isGenerated = false;
        public List<Customer> GenerateSampleDataset()
        {
            if (isGenerated)
            {
                return customers;
            }

            customers.Add(new Customer()
            {
                CustomerId = 1,
                CompanyName = "TechGear Solutions",
                ContactName = "Alice Nguyen",
                ContactTitle = "CEO",
                Address = "123 Innovation Street, District 1",
                Phone = "0912345678"
            });

            customers.Add(new Customer()
            {
                CustomerId = 2,
                CompanyName = "NextGen Electronics JSC",
                ContactName = "Bob Tran",
                ContactTitle = "Head of Procurement",
                Address = "45 Silicon Blvd, District 3",
                Phone = "0987654321"
            });

            customers.Add(new Customer()
            {
                CustomerId = 3,
                CompanyName = "SmartTech Co., Ltd",
                ContactName = "Charlie Le",
                ContactTitle = "IT Coordinator",
                Address = "12 Embedded Lane, District 5",
                Phone = "0909090909"
            });

            customers.Add(new Customer()
            {
                CustomerId = 4,
                CompanyName = "FutureWare Inc.",
                ContactName = "Diana Pham",
                ContactTitle = "Deputy Director",
                Address = "78 Hardware Park, District 10",
                Phone = "0966332211"
            });

            customers.Add(new Customer()
            {
                CustomerId = 5,
                CompanyName = "Innovatek Vietnam LLC",
                ContactName = "Ethan Doan",
                ContactTitle = "R&D Manager",
                Address = "89 Cloud Drive, Binh Thanh District",
                Phone = "0944556677"
            });

            isGenerated = true;
            return customers;
        }*/

        /*public List<Customer> GetDataFromDatabase ()
        {
            return DatabaseContext.GetDbContext().Customers.ToList();
        }*/

        public static List<Customer> GetCustomers()
        {
            try
            {
                using var context = new LucySalesDataContext();
                return context.Customers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static bool AddCustomer(Customer customer)
        {
            try
            {
                using var context = new LucySalesDataContext();
                context.Customers.Add(customer);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static bool RemoveCustomer(int customerId)
        {
            try
            {
                using var context = new LucySalesDataContext();
                var customer = context.Customers.Find(customerId);

                if (customer != null)
                {
                    context.Customers.Remove(customer);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Customer SearchCustomer(int customerId)
        {
            try
            {
                using var context = new LucySalesDataContext();
                return context.Customers
                    .Include(c => c.Orders)
                    .FirstOrDefault(c => c.CustomerId == customerId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static bool UpdateCustomer(Customer customer)
        {
            try
            {
                using var context = new LucySalesDataContext();
                var existingCustomer = context.Customers.Find(customer.CustomerId);

                if (existingCustomer != null)
                {
                    existingCustomer.CompanyName = customer.CompanyName;
                    existingCustomer.ContactName = customer.ContactName;
                    existingCustomer.ContactTitle = customer.ContactTitle;
                    existingCustomer.Address = customer.Address;
                    existingCustomer.Phone = customer.Phone;

                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
