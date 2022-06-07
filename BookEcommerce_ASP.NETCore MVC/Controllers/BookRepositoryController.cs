using Microsoft.AspNetCore.Mvc;
using ClassLibrary_RepositoryDLL.Repository;
using System.Collections.Generic;
using BookEccommerce_Admin.Models;

namespace BookEcommerce_ASP.NETCore_MVC.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookRepositoryController : Controller
    {
        IBookRepository _repository;
        public BookRepositoryController(IBookRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<Book> GetAllBooks()
        {
            List<Book> books = _repository.getAllBook();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetDetailBook(int id)
        {
            Book book = _repository.getDetailBook(id);
            return Ok(book);
        }

        [HttpPost]
        public ActionResult AddBook([FromBody]Book newbook)
        {
            _repository.AddBook(newbook);
            List<Book> books = _repository.getAllBook();
            return Ok(books);
        }

        [HttpPut]
        public ActionResult UpdateBook([FromBody]Book newbook)
        {
            _repository.UpdateBook(newbook);
            return Ok(newbook);
        }

        [HttpDelete("{id}")]
        public ActionResult <Book> DeleteBook(int id)
        {
            _repository.DeleteBook(id);
            List<Book> books = _repository.getAllBook();
            return Ok(books);
        }
    }
}
