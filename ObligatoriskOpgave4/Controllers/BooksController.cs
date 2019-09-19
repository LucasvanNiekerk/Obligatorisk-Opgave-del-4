using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ModelLib;

namespace ObligatoriskOpgave4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static List<Book> _books = new List<Book>()
        {
            new Book("The hunt for cake", "Hungry Chef", 124, "1337420666123"),
            new Book("The hunt for cake2", "Hungry Chef", 412, "1392496583913"),
            new Book("The Bible", "Jesus", 800, "8270836271932"),
            new Book("Harry Potter", "JK. Rowling", 901, "5463746590215")
        };

        // GET: api/Books
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _books;
        }

        // GET: api/Books/5
        [HttpGet("{isbn13}", Name = "Get")]
        public Book Get(string isbn13)
        {
            return _books.Find(i => i.Isbn13 == isbn13);
        }

        // POST: api/Books
        [HttpPost]
        public void Post([FromBody] Book value)
        {
            _books.Add(value);
        }

        // PUT: api/Books/5
        [HttpPut("{isbn13}")]
        public void Put(string isbn13, [FromBody] Book value)
        {
            Book book = Get(isbn13);
            if (book != null)
            {
                book.Author = value.Author;
                book.Pagenumber = value.Pagenumber;
                book.Title = value.Title;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{isbn13}")]
        public void Delete(string isbn13)
        {
            Book book = Get(isbn13);
            if (book != null)
            {
                _books.Remove(book);
            }
        }
    }
}
