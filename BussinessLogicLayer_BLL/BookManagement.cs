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
        BookRepository bookRepository = new BookRepository();
        AuthorRepository authorRepository = new AuthorRepository();
        CategoryRepository categoryRepository = new CategoryRepository();
        PublisherRepository publisherRepository = new PublisherRepository();
        public List<Book> viewAllBook()
        {
            List<Book> list = bookRepository.getAllBook();
            return list;
        }

        public void addBook(Book newbook)
        {
           bookRepository.AddBook(newbook);
        }

        public bool updateBook(Book newbook)
        {
            bool result= bookRepository.UpdateBook(newbook);
            return result;
        }

        public bool delBook(int bookId)
        {
            bool result = bookRepository.DeleteBook(bookId);
            return result;
        }
        public bool UpdateImage(Book newbook)
        {
            bool result = bookRepository.UpdateImage(newbook);
            return result;
        }

        public List<Book> SelectByKeyword(string keyword)
        {
            List<Book> books =  bookRepository.searchBook(keyword);
            return books;
        }

        public List<Book> GetDetailsByAuthorId(int authorId)
        {
            List<Book> books = bookRepository.SelectByAuthorId(authorId);
            return books;
        }

        public List<Book> GetDetailsByCateId(int cateId)
        {
            List<Book> books = bookRepository.SelectByCateId(cateId);
            return books;
        }

        public List<Book> GetDetailsByPubId(int pubId)
        {
            List<Book> books = bookRepository.SelectByPubId(pubId);
            return books;
        }

        public Book viewDetailBook(int bookId)
        {
            Book book = bookRepository.getDetailBook(bookId);
            return book;
        }

        public Author viewAuthor(int authorId)
        {
            Author author = authorRepository.getAuthor(authorId);
            return author;
        }

        public void addAuthor(Author newauthor)
        {
            authorRepository.AddAuthor(newauthor);
        }

        public bool updateAuthor(Author newauthor)
        {
            bool result = authorRepository.UpdateAuthor(newauthor);
            return result;
        }

        public bool delAuthor(int authorId)
        {
            bool result = authorRepository.DeleteAuthor(authorId);
            return result;
        }

        public Category viewCategory(int cateId)
        {
            Category category = categoryRepository.getCategory(cateId);
            return category;
        }

        public Publisher viewPublisher(int pubId)
        {
            Publisher publisher = publisherRepository.getPublisher(pubId);
            return publisher;
        }
        public void addCate(Category newcate)
        {
            categoryRepository.AddCategory(newcate);
        }

        public bool updateCate(Category newcate)
        {
            bool result = categoryRepository.UpdateCategory(newcate);
            return result;
        }

        public bool delCate(int categoryId)
        {
            bool result = categoryRepository.DeleteCategory(categoryId);
            return result;
        }

        public List<Author> viewAllAuthor()
        {
            List<Author> list = authorRepository.getAllAuthor();
            return list;
        }

        public List<Publisher> viewAllPub()
        {
            List<Publisher> list = publisherRepository.getAllPublisher();
            return list;
        }

        public void addPublisher(Publisher newpub)
        {
            publisherRepository.AddPublisher(newpub);
        }

        public bool delPublisher(int pubId)
        {
            bool result = publisherRepository.DeletePublisher(pubId);
            return result;
        }


        public List<Category> viewAllCategory()
        {
            List<Category> list = categoryRepository.getAllCategory();
            return list;
        }


    }
}
