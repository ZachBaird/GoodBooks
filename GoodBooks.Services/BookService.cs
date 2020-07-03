using GoodBooks.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GoodBooks.Services
{
    public class BookService : IBookService
    {
        private readonly GoodBooksDbContext _db;
        public BookService(GoodBooksDbContext db) =>
            _db = db;

        public List<Book> GetAllBooks()
        {
            return _db.Books.ToList();
        }

        public Book GetBook(int bookId)
        {
            return _db.Books.Find(bookId);
        }

        public void AddBook(Book book)
        {
            _db.Add(book);
            _db.SaveChanges();
        }

        public void DeleteBook(int bookId)
        {
            var bookToDelete = _db.Books.Find(bookId);

            if (bookToDelete != null)
            {
                _db.Remove(bookToDelete);
                _db.SaveChanges();
            }
            else
                throw new InvalidOperationException("Cannot delete a book that doesn't exist");
        }
    }
}
