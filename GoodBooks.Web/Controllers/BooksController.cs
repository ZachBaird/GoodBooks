using GoodBooks.Data;
using GoodBooks.Services;
using GoodBooks.Web.RequestModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace GoodBooks.Web.Controllers
{
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IBookService _bookService;

        public BooksController(ILogger<BooksController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        [HttpGet("/api/books")]
        public ActionResult GetBooks()
        {
            var books = _bookService.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("/api/books/{id}")]
        public ActionResult GetBook(int id)
        {
            var book = _bookService.GetBook(id);

            return Ok(book);
        }

        [HttpPost("/api/books")]
        public ActionResult CreateBook([FromBody] NewBookRequest bookRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest("New Book is not valid.");

            var now = DateTime.UtcNow;
            var book = new Book
            {
                CreatedOn = now,
                Updated = now,
                Title = bookRequest.Title,
                Author = bookRequest.Author,
            };

            _bookService.AddBook(book);

            return Ok($"Book was created: {book.Title}");
        }

        [HttpDelete("/api/books/{id}")]
        public ActionResult DeleteBook(int id)
        {
            _bookService.DeleteBook(id);

            return Ok($"Book at Id {id} was deleted.");
        }
    }
}
