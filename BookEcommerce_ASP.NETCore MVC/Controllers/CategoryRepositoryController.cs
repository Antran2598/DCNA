using Microsoft.AspNetCore.Mvc;
using ClassLibrary_RepositoryDLL.Repository;

using System.Collections.Generic;
using BookEccommerce_Admin.Models;

namespace BookEcommerce_ASP.NETCore_MVC.Controllers
{
    public class CategoryRepositoryController : Controller
    {
        ICategoryRepository _repository;
        public CategoryRepositoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<Category> GetAllCategory()
        {
            List<Category> categories = _repository.getAllCategory();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public ActionResult<Category> GetCategory(int id)
        {
            Category category = _repository.getCategory(id);
            return Ok(category);
        }

        [HttpPost]
        public ActionResult AddCategory([FromBody] Category newcategory)
        {
            _repository.AddCategory(newcategory);
            List<Category> authors = _repository.getAllCategory();
            return Ok(authors);
        }

        [HttpPut]
        public ActionResult UpdateCategory([FromBody] Category newcategory)
        {
            _repository.UpdateCategory(newcategory);
            return Ok(newcategory);
        }

        [HttpDelete("{id}")]
        public ActionResult<Category> DeleteCategory(int id)
        {
            _repository.DeleteCategory(id);
            List<Category> categories = _repository.getAllCategory();
            return Ok(categories);
        }
    }
}
