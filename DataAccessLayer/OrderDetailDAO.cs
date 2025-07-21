using BusinessObjects;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public class OrderDetailDAO
    {
        /*static List<OrderDetail> orderDetails = new List<OrderDetail>();
        private bool isGenerated = false;
        public List<OrderDetail> GenerateSampleDataset()
        {
            if (isGenerated)
            {
                return orderDetails;
            }

            // Order 1
            orderDetails.Add(new OrderDetail()
            {
                OrderId = 1,
                ProductId = 1,
                UnitPrice = 18.0,
                Quantity = 5,
                Discount = 0.1
            });

            orderDetails.Add(new OrderDetail()
            {
                OrderId = 1,
                ProductId = 2,
                UnitPrice = 19.0,
                Quantity = 3,
                Discount = 0.0
            });

            // Order 2
            orderDetails.Add(new OrderDetail()
            {
                OrderId = 2,
                ProductId = 3,
                UnitPrice = 10.0,
                Quantity = 10,
                Discount = 0.05
            });

            orderDetails.Add(new OrderDetail()
            {
                OrderId = 2,
                ProductId = 1,
                UnitPrice = 18.0,
                Quantity = 4,
                Discount = 0.0
            });

            // Order 3
            orderDetails.Add(new OrderDetail()
            {
                OrderId = 3,
                ProductId = 4,
                UnitPrice = 22.0,
                Quantity = 2,
                Discount = 0.2
            });

            orderDetails.Add(new OrderDetail()
            {
                OrderId = 3,
                ProductId = 5,
                UnitPrice = 25.0,
                Quantity = 1,
                Discount = 0.1
            });

            // Order 4
            orderDetails.Add(new OrderDetail()
            {
                OrderId = 4,
                ProductId = 5,
                UnitPrice = 25.0,
                Quantity = 1,
                Discount = 0.0
            });

            orderDetails.Add(new OrderDetail()
            {
                OrderId = 4,
                ProductId = 2,
                UnitPrice = 19.0,
                Quantity = 2,
                Discount = 0.05
            });

            // Order 5
            orderDetails.Add(new OrderDetail()
            {
                OrderId = 5,
                ProductId = 3,
                UnitPrice = 10.0,
                Quantity = 8,
                Discount = 0.15
            });

            orderDetails.Add(new OrderDetail()
            {
                OrderId = 5,
                ProductId = 4,
                UnitPrice = 22.0,
                Quantity = 3,
                Discount = 0.0
            });

            isGenerated = true;
            return orderDetails;
        }*/

        /*public List<OrderDetail> GetDataFromDatabase()
        {
            return DatabaseContext.GetDbContext().Order_Details.ToList();
        }*/

        public static List<OrderDetail> GetOrderDetails()
        {
            try
            {
                using var context = new LucySalesDataContext();
                return context.OrderDetails.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Them chi tiet don hang moi
        public static bool AddOrderDetail(OrderDetail detail)
        {
            try
            {
                using var context = new LucySalesDataContext();
                context.OrderDetails.Add(detail);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static bool RemoveOrderDetail(int orderId, int productId)
        {
            try
            {
                using var context = new LucySalesDataContext();
                var orderDetail = context.OrderDetails
                    .FirstOrDefault(od => od.OrderId == orderId && od.ProductId == productId);

                if (orderDetail != null)
                {
                    context.OrderDetails.Remove(orderDetail);
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

        public static OrderDetail SearchOrderDetail(int orderId, int productId)
        {
            try
            {
                using var context = new LucySalesDataContext();
                return context.OrderDetails
                    .Include(od => od.Product)
                    .FirstOrDefault(od => (od.OrderId == orderId && od.ProductId == productId));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static bool UpdateOrderDetail(OrderDetail detail)
        {
            try
            {
                using var context = new LucySalesDataContext();
                var existing = context.OrderDetails
                    .FirstOrDefault(od => od.OrderId == detail.OrderId && od.ProductId == detail.ProductId);

                if (existing != null)
                {
                    existing.UnitPrice = detail.UnitPrice;
                    existing.Quantity = detail.Quantity;
                    existing.Discount = detail.Discount;

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
