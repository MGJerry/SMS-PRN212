using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataLayer;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public bool AddOrder(Order order)
        {
            return OrderDAO.AddOrder(order);
        }

        public List<Order> GenerateSampleDataset()
        {
            return OrderDAO.GetOrders();
        }

        public List<Order> GetOrders()
        {
            return OrderDAO.GetOrders();
        }

        public bool RemoveOrder(int orderId)
        {
            return OrderDAO.RemoveOrder(orderId);
        }

        public Order SearchOrder(int orderId)
        {
            return OrderDAO.SearchOrder(orderId);
        }

        public bool UpdateOrder(Order order)
        {
            return OrderDAO.UpdateOrder(order);
        }
    }
}
