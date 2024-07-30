using Microsoft.AspNetCore.Mvc;
using Rest_Advanced.Models;
using Rest_Advanced.Repositories;

namespace Rest_Advanced.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return Ok(await _bookRepository.GetBooksAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Book>> AddBook(Book book)
        {
            await _bookRepository.AddBookAsync(book);
            return CreatedAtAction(nameof(GetBooks), new { id = book.Id }, book);
        }
    }
}
