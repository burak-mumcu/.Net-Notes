using Xunit;
using Moq;
using Rest_Advanced.Models;
using Rest_Advanced.Repositories;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Rest_Advanced.Tests
{
    public class BookRepositoryTests
    {
        private readonly ApplicationDbContext _context;
        private readonly BookRepository _repository;

        public BookRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "BooksTestDb")
                .Options;

            _context = new ApplicationDbContext(options);
            _repository = new BookRepository(_context);
        }

        [Fact]
        public async Task AddBookAsync_ShouldAddBook()
        {
            var author = new Author { Name = "Author1" };
            var book = new Book { Title = "Book1", Author = author };

            await _repository.AddBookAsync(book);

            var books = await _repository.GetBooksAsync();
            Assert.Single(books);
            Assert.Equal("Book1", books[0].Title);
        }
    }
}
