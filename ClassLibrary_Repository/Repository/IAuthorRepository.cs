using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookEccommerce_Admin.Models;

namespace ClassLibrary_RepositoryDLL.Repository
{
    public interface IAuthorRepository
    {
        List<Author> getAllAuthor();
        void AddAuthor(Author newauthor);
        bool UpdateAuthor(Author newauthor);
        bool DeleteAuthor(int authorId);
        Author getAuthor(int authorId);
    }
}
