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
    public class CategoryDAO
    {
        
        /*static List<Category> categories = new List<Category>();
        private bool isGenerated = false;
        public List<Category> GenerateSampleDataset()
        {
            if (isGenerated)
            {
                return categories;
            }

            categories.Add(new Category()
            {
                CategoryId = 1,
                CategoryName = "Peripherals",
                Description = "Keyboards, mice, webcams, headsets"
            });

            categories.Add(new Category()
            {
                CategoryId = 2,
                CategoryName = "Storage Devices",
                Description = "External hard drives, SSDs, flash drives"
            });

            categories.Add(new Category()
            {
                CategoryId = 3,
                CategoryName = "Displays",
                Description = "Monitors, projectors, display accessories"
            });

            categories.Add(new Category()
            {
                CategoryId = 4,
                CategoryName = "Networking",
                Description = "Routers, switches, Wi-Fi adapters"
            });

            categories.Add(new Category()
            {
                CategoryId = 5,
                CategoryName = "Computers",
                Description = "Laptops, desktops, mini PCs"
            });

            isGenerated = true;
            return categories;
        }*/

        public static List<Category> GetCategories()
        {
            try
            {
                using var context = new LucySalesDataContext();
                return context.Categories.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static bool AddCategory(Category category)
        {
            try
            {
                using var context = new LucySalesDataContext();
                context.Categories.Add(category);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static bool RemoveCategory(int categoryId)
        {
            try
            {
                using var context = new LucySalesDataContext();
                var category = context.Categories.Find(categoryId);

                if (category != null)
                {
                    context.Categories.Remove(category);
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

        public static Category SearchCategory(int categoryId)
        {
            try
            {
                using var context = new LucySalesDataContext();
                return context.Categories
                    .Include(c => c.Products)
                    .FirstOrDefault(c => c.CategoryId == categoryId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static bool UpdateCategory(Category category)
        {
            try
            {
                using var context = new LucySalesDataContext();
                var existingCategory = context.Categories.Find(category.CategoryId);

                if (existingCategory != null)
                {
                    existingCategory.CategoryName = category.CategoryName;
                    existingCategory.Description = category.Description;
                    existingCategory.Picture = category.Picture;

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

