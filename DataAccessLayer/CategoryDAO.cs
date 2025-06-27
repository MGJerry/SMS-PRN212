using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace DataLayer
{
    public class CategoryDAO
    {
        
        static List<Category> categories = new List<Category>();
        private bool isGenerated = false;
        public List<Category> GenerateSampleDataset()
        {
            if (isGenerated)
            {
                return categories;
            }

            categories.Add(new Category()
            {
                CategoryID = 1,
                CategoryName = "Peripherals",
                Description = "Keyboards, mice, webcams, headsets"
            });

            categories.Add(new Category()
            {
                CategoryID = 2,
                CategoryName = "Storage Devices",
                Description = "External hard drives, SSDs, flash drives"
            });

            categories.Add(new Category()
            {
                CategoryID = 3,
                CategoryName = "Displays",
                Description = "Monitors, projectors, display accessories"
            });

            categories.Add(new Category()
            {
                CategoryID = 4,
                CategoryName = "Networking",
                Description = "Routers, switches, Wi-Fi adapters"
            });

            categories.Add(new Category()
            {
                CategoryID = 5,
                CategoryName = "Computers",
                Description = "Laptops, desktops, mini PCs"
            });

            isGenerated = true;
            return categories;
        }

        /*public List<Category> GetDataFromDatabase ()
        {
            return DatabaseContext.GetDbContext().Categories.ToList();
        }*/

        public List<Category> GetCategories()
        {
            return categories;
        }

        public bool AddCategory(Category category)
        {
            Category c = categories.FirstOrDefault(c => c.CategoryID == category.CategoryID);
            if (c != null)
            {
                return false; 
            }

            categories.Add(category);
            return true;
        }

        public bool RemoveCategory(int categoryId)
        {
            Category c = categories.FirstOrDefault(c => c.CategoryID == categoryId);
            if (c == null)
            {
                return false;
            }

            categories.Remove(c);
            return true;
        }

        public Category SearchCategory(int categoryId)
        {
            return categories.FirstOrDefault(c => c.CategoryID == categoryId);
        }

        public bool UpdateCategory(Category category)
        {
            Category c = categories.FirstOrDefault(c => c.CategoryID == category.CategoryID);
            if (c == null)
            {
                return false;
            }

            c.CategoryName = category.CategoryName;
            c.Description = category.Description;

            return true;
        }
    }
}

