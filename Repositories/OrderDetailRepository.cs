using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataLayer;

namespace Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public bool AddOrderDetail(OrderDetail detail)
        {
            return OrderDetailDAO.AddOrderDetail(detail);
        }

        public List<OrderDetail> GenerateSampleDataset()
        {
            return OrderDetailDAO.GetOrderDetails();
        }

        public List<OrderDetail> GetOrderDetails()
        {
            return OrderDetailDAO.GetOrderDetails();
        }

        public bool RemoveOrderDetail(int orderId, int productId)
        {
            return OrderDetailDAO.RemoveOrderDetail(orderId, productId);
        }

        public OrderDetail SearchOrderDetail(int orderId, int productId)
        {
            return OrderDetailDAO.SearchOrderDetail(orderId, productId);
        }

        public bool UpdateOrderDetail(OrderDetail detail)
        {
            return OrderDetailDAO.UpdateOrderDetail(detail);
        }
    }
}
