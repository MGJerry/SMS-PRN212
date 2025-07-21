using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataLayer;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        public bool AddProduct(Product product)
        {
            return ProductDAO.AddProduct(product);
        }

        public List<Product> GenerateSampleDataset()
        {
            return ProductDAO.GetProducts();
        }

        public List<Product> GetProducts()
        {
            return ProductDAO.GetProducts();
        }

        public bool RemoveProduct(int productId)
        {
            return ProductDAO.RemoveProduct(productId);
        }

        public Product SearchProduct(int productId)
        {
            return ProductDAO.SearchProduct(productId);
        }

        public bool UpdateProduct(Product product)
        {
            return ProductDAO.UpdateProduct(product);
        }
    }
}
