using BookEccommerce_Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_RepositoryDLL.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BookEcommerceContext _context;

        public CategoryRepository()
        {
            _context = new BookEcommerceContext();
        }
        public CategoryRepository(BookEcommerceContext context)
        {
            _context = context;
        }
        public void AddCategory(Category newcategory)
        {
            try
            {
                _context.Categories.Add(newcategory);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public bool DeleteCategory(int categoryId)
        {
            Category category = _context.Categories.Find(categoryId);
            if (category != null)
            {
                try
                {
                    _context.Categories.Remove(category);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return false;
        }

        public List<Category> getAllCategory()
        {
            List<Category> categories = _context.Categories.ToList();
            return categories;
        }

        public Category getCategory(int categoryId)
        {
            Category category = _context.Categories.Find(categoryId);
            return category;
        }

        public bool UpdateCategory(Category newcategory)
        {
            Category category = _context.Categories.SingleOrDefault(category => category.Id.Equals(newcategory.Id));
            if (category != null)
            {
                try
                {
                    category.Categoryname = newcategory.Categoryname;
                    _context.Categories.Update(newcategory);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return false;
        }
    }
}
