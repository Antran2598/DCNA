using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookEccommerce_Admin.Models;


namespace ClassLibrary_RepositoryDLL.Repository
{
    public interface IBookRepository
    {
        List<Book> getAllBook();
        void AddBook(Book newbook);
        bool UpdateBook(Book newbook);
        bool DeleteBook(int bookId);
        Book getDetailBook(int bookId);
    }
}
