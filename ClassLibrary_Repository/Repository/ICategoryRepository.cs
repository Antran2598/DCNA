using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookEccommerce_Admin.Models;

namespace ClassLibrary_RepositoryDLL.Repository
{
    public interface ICategoryRepository
    {
        List<Category> getAllCategory();
        void AddCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(int categoryId);
        Category getCategory(int categoryId);
    }
}
