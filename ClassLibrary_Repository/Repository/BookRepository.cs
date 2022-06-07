using BookEccommerce_Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary_RepositoryDLL.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookEcommerceContext _context;
        public BookRepository()
        {
            _context = new BookEcommerceContext();
        }
        public BookRepository(BookEcommerceContext context)
        {
            _context = context;
        }
        public List<Book> getAllBook()
        {
            List<Book> books = _context.Books.ToList();
            return books;
        }

        public Book getDetailBook(int bookId)
        {
            Book book = _context.Books.Find(bookId);
            return book;
        }
        public void AddBook(Book newbook)
        {
            try
            {
                _context.Books.Add(newbook);
                _context.SaveChanges();
            }
            catch(Exception exception)
            {
                //Exception exception = new Exception("Can not ADD new book to database");
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }
        }
        public bool UpdateBook(Book newbook)
        {
            Book book = _context.Books.SingleOrDefault(book => book.Id == newbook.Id);
            if (book != null)
            {
                try
                {
                    book.Bookname = newbook.Bookname;
                    book.AuthorId = newbook.AuthorId;
                    book.PublisherId = newbook.PublisherId;
                    book.CategoryId = newbook.CategoryId;
                    book.Price = newbook.Price;
                    book.StorageQuantity = newbook.StorageQuantity;
                    book.Description = newbook.Description;
                    book.Image = newbook.Image;

                    _context.Books.Update(newbook);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception exception)
                {
                    System.Diagnostics.Debug.WriteLine(exception.Message);
                }
            }
            return false;
        }

        public bool DeleteBook(int bookId)
        {
            Book book = _context.Books.SingleOrDefault(book => book.Id == bookId);
            if (book != null)
            {
                try
                {
                    _context.Books.Remove(book);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception exception)
                {
                    System.Diagnostics.Debug.WriteLine(exception.Message);
                }
            }
            return false;
        }
    }
}
