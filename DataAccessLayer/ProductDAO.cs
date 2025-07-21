using BusinessObjects;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ProductDAO
    {
        /*static List<Product> products = new List<Product>();
        private bool isGenerated = false;
        public List<Product> GenerateSampleDataset()
        {
            if (isGenerated)
            {
                return products;
            }

            products.Add(new Product()
            {
                ProductId = 1,
                ProductName = "Wireless Mouse",
                SupplierId = 1,
                CategoryId = 1,
                QuantityPerUnit = 10,
                UnitPrice = 25,
                UnitsInStock = 100,
                UnitsOnOrder = 20,
                ReorderLevel = 15,
                Discontinued = false
            });

            products.Add(new Product()
            {
                ProductId = 2,
                ProductName = "Mechanical Keyboard",
                SupplierId = 2,
                CategoryId = 1,
                QuantityPerUnit = 12,
                UnitPrice = 55,
                UnitsInStock = 50,
                UnitsOnOrder = 10,
                ReorderLevel = 10,
                Discontinued = false
            });

            products.Add(new Product()
            {
                ProductId = 3,
                ProductName = "27\" LED Monitor",
                SupplierId = 3,
                CategoryId = 2,
                QuantityPerUnit = 6,
                UnitPrice = 180,
                UnitsInStock = 30,
                UnitsOnOrder = 5,
                ReorderLevel = 5,
                Discontinued = false
            });

            products.Add(new Product()
            {
                ProductId = 4,
                ProductName = "External SSD 1TB",
                SupplierId = 4,
                CategoryId = 3,
                QuantityPerUnit = 20,
                UnitPrice = 99,
                UnitsInStock = 75,
                UnitsOnOrder = 15,
                ReorderLevel = 10,
                Discontinued = false
            });

            products.Add(new Product()
            {
                ProductId = 5,
                ProductName = "Gaming Laptop",
                SupplierId = 5,
                CategoryId = 4,
                QuantityPerUnit = 4,
                UnitPrice = 1200,
                UnitsInStock = 10,
                UnitsOnOrder = 2,
                ReorderLevel = 2,
                Discontinued = true
            });

            isGenerated = true;
            return products;
        }*/

        /*public List<Product> GetDataFromDatabase ()
        {
            return DatabaseContext.GetDbContext().Products.ToList();
        }*/

        public static List<Product> GetProducts ()
        {
            try
            {
                using var context = new LucySalesDataContext();
                return context.Products.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static bool AddProduct (Product product)
        {
            try
            {
                using var context = new LucySalesDataContext();
                context.Products.Add(product);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static bool RemoveProduct(int productId)
        {
            try
            {
                using var context = new LucySalesDataContext();
                var product = context.Products.Find(productId);

                if (product != null)
                {
                    context.Products.Remove(product);
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

        public static Product SearchProduct(int productId)
        {
            try
            {
                using var context = new LucySalesDataContext();
                return context.Products
                    .Include(p => p.Category)
                    .Include(p => p.OrderDetails)
                    .FirstOrDefault(p => p.ProductId == productId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static bool UpdateProduct(Product product)
        {
            try
            {
                using var context = new LucySalesDataContext();
                var existingProduct = context.Products.Find(product.ProductId);

                if (existingProduct != null)
                {
                    existingProduct.ProductName = product.ProductName;
                    existingProduct.SupplierId = product.SupplierId;
                    existingProduct.CategoryId = product.CategoryId;
                    existingProduct.QuantityPerUnit = product.QuantityPerUnit;
                    existingProduct.UnitPrice = product.UnitPrice;
                    existingProduct.UnitsInStock = product.UnitsInStock;
                    existingProduct.UnitsOnOrder = product.UnitsOnOrder;
                    existingProduct.ReorderLevel = product.ReorderLevel;
                    existingProduct.Discontinued = product.Discontinued;

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
