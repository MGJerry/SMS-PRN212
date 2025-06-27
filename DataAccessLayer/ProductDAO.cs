using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace DataLayer
{
    public class ProductDAO
    {
        static List<Product> products = new List<Product>();
        private bool isGenerated = false;
        public List<Product> GenerateSampleDataset()
        {
            if (isGenerated)
            {
                return products;
            }

            products.Add(new Product()
            {
                ProductID = 1,
                ProductName = "Wireless Mouse",
                SupplierID = 1,
                CategoryID = 1,
                QuantityPerUnit = 10,
                UnitPrice = 25,
                UnitsInStock = 100,
                UnitsOnOrder = 20,
                ReorderLevel = 15,
                Discontinued = false
            });

            products.Add(new Product()
            {
                ProductID = 2,
                ProductName = "Mechanical Keyboard",
                SupplierID = 2,
                CategoryID = 1,
                QuantityPerUnit = 12,
                UnitPrice = 55,
                UnitsInStock = 50,
                UnitsOnOrder = 10,
                ReorderLevel = 10,
                Discontinued = false
            });

            products.Add(new Product()
            {
                ProductID = 3,
                ProductName = "27\" LED Monitor",
                SupplierID = 3,
                CategoryID = 2,
                QuantityPerUnit = 6,
                UnitPrice = 180,
                UnitsInStock = 30,
                UnitsOnOrder = 5,
                ReorderLevel = 5,
                Discontinued = false
            });

            products.Add(new Product()
            {
                ProductID = 4,
                ProductName = "External SSD 1TB",
                SupplierID = 4,
                CategoryID = 3,
                QuantityPerUnit = 20,
                UnitPrice = 99,
                UnitsInStock = 75,
                UnitsOnOrder = 15,
                ReorderLevel = 10,
                Discontinued = false
            });

            products.Add(new Product()
            {
                ProductID = 5,
                ProductName = "Gaming Laptop",
                SupplierID = 5,
                CategoryID = 4,
                QuantityPerUnit = 4,
                UnitPrice = 1200,
                UnitsInStock = 10,
                UnitsOnOrder = 2,
                ReorderLevel = 2,
                Discontinued = true
            });

            isGenerated = true;
            return products;
        }
        /*public List<Product> GetDataFromDatabase ()
        {
            return DatabaseContext.GetDbContext().Products.ToList();
        }*/
        public List<Product> GetProducts ()
        {
            return products;
        }
        public bool AddProduct (Product product)
        {
            Product p = products.FirstOrDefault(p=> p.ProductID == product.ProductID);

            if (p == null) { 
                return false;
            }

            products.Add(p);
            return true;
        }

        public bool RemoveProduct(int pId) {
            Product p = products.FirstOrDefault(p => p.ProductID == pId);
            if (p == null) {
                return false;
            }
            products.Remove(p);
            return true;
        }

        public Product SearchProduct(int pId) { 
            return products.FirstOrDefault(p => p.ProductID==pId);
        }

        public bool UpdateProduct(Product product) {
            Product p = products.FirstOrDefault(p => p.ProductID == product.ProductID);

            if (p == null) {
                return false;
            }

            p.ProductID = product.ProductID;
            p.ProductName = product.ProductName;
            p.UnitPrice = product.UnitPrice;
            p.QuantityPerUnit = product.QuantityPerUnit;
            p.UnitsInStock = product.UnitsInStock;
            p.CategoryID = product.CategoryID;
            p.Discontinued = product.Discontinued;
            p.ReorderLevel = product.ReorderLevel;
            p.SupplierID = product.SupplierID;
            p.UnitsOnOrder = product.UnitsOnOrder;

            return true;
        }
    }
}
