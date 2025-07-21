using BusinessObjects;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public class OrderDAO
    {
        /*static List<Order> orders = new List<Order>();
        private bool isGenerated = false;
        public List<Order> GenerateSampleDataset()
        {
            if (isGenerated) return orders;

            orders.Add(new Order()
            {
                OrderId = 1,
                CustomerId = 1,
                EmployeeId = 1,
                OrderDate = new DateTime(2024, 12, 10)
            });

            orders.Add(new Order()
            {
                OrderId = 2,
                CustomerId = 2,
                EmployeeId = 2,
                OrderDate = new DateTime(2024, 12, 15)
            });

            orders.Add(new Order()
            {
                OrderId = 3,
                CustomerId = 3,
                EmployeeId = 3,
                OrderDate = new DateTime(2025, 1, 5)
            });

            orders.Add(new Order()
            {
                OrderId = 4,
                CustomerId = 4,
                EmployeeId = 4,
                OrderDate = new DateTime(2025, 1, 20)
            });

            orders.Add(new Order()
            {
                OrderId = 5,
                CustomerId = 5,
                EmployeeId = 5,
                OrderDate = new DateTime(2025, 2, 14)
            });
            isGenerated = true;
            return orders;
        }*/

        /*public List<Order> GetDataFromDatabase ()
        {
            return DatabaseContext.GetDbContext().Orders.ToList();
        }*/

        public static List<Order> GetOrders()
        {
            try
            {
                using var context = new LucySalesDataContext();
                return context.Orders.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static bool AddOrder(Order order)
        {
            try
            {
                using var context = new LucySalesDataContext();
                context.Orders.Add(order);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static bool RemoveOrder(int orderId)
        {
            try
            {
                using var context = new LucySalesDataContext();
                var order = context.Orders.Find(orderId);

                if (order != null)
                {
                    context.Orders.Remove(order);
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

        public static Order SearchOrder(int orderId)
        {
            try
            {
                using var context = new LucySalesDataContext();
                return context.Orders
                    .Include(o => o.Customer)
                    .Include(o => o.Employee)
                    .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                    .FirstOrDefault(o => o.OrderId == orderId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static bool UpdateOrder(Order order)
        {
            try
            {
                using var context = new LucySalesDataContext();
                var existingOrder = context.Orders.Find(order.OrderId);

                if (existingOrder != null)
                {
                    existingOrder.CustomerId = order.CustomerId;
                    existingOrder.EmployeeId = order.EmployeeId;
                    existingOrder.OrderDate = order.OrderDate;

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
