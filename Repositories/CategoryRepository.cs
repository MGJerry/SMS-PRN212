using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataLayer;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        public bool AddCategory(Category category)
        {
            return CategoryDAO.AddCategory(category);
        }

        public List<Category> GenerateSampleDataset()
        {
            return CategoryDAO.GetCategories();
        }

        public List<Category> GetCategories()
        {
            return CategoryDAO.GetCategories();
        }

        public bool RemoveCategory(int categoryId)
        {
            return CategoryDAO.RemoveCategory(categoryId);
        }

        public Category SearchCategory(int categoryId)
        {
            return CategoryDAO.SearchCategory(categoryId);
        }

        public bool UpdateCategory(Category category)
        {
            return CategoryDAO.UpdateCategory(category);
        }
    }
}
