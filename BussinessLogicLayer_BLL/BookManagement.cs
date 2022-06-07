using System;
using System.Collections.Generic;
using ClassLibrary_RepositoryDLL;
using System.Data;
using System.Data.SqlClient;
using ClassLibrary_RepositoryDLL.Repository;
using BookEccommerce_Admin.Models;

namespace BussinessLogicLayer_BLL
{
    public class BookManagement
    {
        BookRepository iBookRepository = new BookRepository();
        AuthorRepository iAuthorRepository = new AuthorRepository();
        CategoryRepository iCategoryRepository = new CategoryRepository();
        PublisherRepository iPublisherRepository = new PublisherRepository();
        public List<Book> viewAllBook()
        {
            List<Book> list = iBookRepository.getAllBook();
            return list;
        }

        public void addBook(Book newbook)
        {
           iBookRepository.AddBook(newbook);
        }

        public bool updateBook(Book newbook)
        {
            bool result= iBookRepository.UpdateBook(newbook);
            return result;
        }

        public bool delBook(int bookId)
        {
            bool result = iBookRepository.DeleteBook(bookId);
            return result;
        }

        public Book viewDetailBook(int bookId)
        {
            Book book = iBookRepository.getDetailBook(bookId);
            return book;
        }

        public Author viewAuthor(int authorId)
        {
            Author author = iAuthorRepository.getAuthor(authorId);
            return author;
        }

        public void addAuthor(Author newauthor)
        {
            iAuthorRepository.AddAuthor(newauthor);
        }

        public bool updateAuthor(Author newauthor)
        {
            bool result = iAuthorRepository.UpdateAuthor(newauthor);
            return result;
        }

        public bool delAuthor(int authorId)
        {
            bool result = iAuthorRepository.DeleteAuthor(authorId);
            return result;
        }

        public Category viewCategory(int cateId)
        {
            Category category = iCategoryRepository.getCategory(cateId);
            return category;
        }

        public Publisher viewPublisher(int pubId)
        {
            Publisher publisher = iPublisherRepository.getPublisher(pubId);
            return publisher;
        }
        public void addCate(Category newcate)
        {
            iCategoryRepository.AddCategory(newcate);
        }

        public bool updateCate(Category newcate)
        {
            bool result = iCategoryRepository.UpdateCategory(newcate);
            return result;
        }

        public bool delCate(int categoryId)
        {
            bool result = iCategoryRepository.DeleteCategory(categoryId);
            return result;
        }

        public List<Author> viewAllAuthor()
        {
            List<Author> list = iAuthorRepository.getAllAuthor();
            return list;
        }

        public List<Publisher> viewAllPub()
        {
            List<Publisher> list = iPublisherRepository.getAllPublisher();
            return list;
        }

        public void addPublisher(Publisher newpub)
        {
            iPublisherRepository.AddPublisher(newpub);
        }

        public bool delPublisher(int pubId)
        {
            bool result = iPublisherRepository.DeletePublisher(pubId);
            return result;
        }


        public List<Category> viewAllCategory()
        {
            List<Category> list = iCategoryRepository.getAllCategory();
            return list;
        }


    }
}
