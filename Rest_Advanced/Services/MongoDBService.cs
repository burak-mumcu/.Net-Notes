using MongoDB.Driver;
using Rest_Advanced.Models;

namespace Rest_Advanced.Services
{
    public class MongoDBService
    {
        private readonly IMongoCollection<Book> _collection;

        public MongoDBService(IMongoClient client)
        {
            var database = client.GetDatabase("BooksDb");
            _collection = database.GetCollection<Book>("Books");
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _collection.Find(book => book.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddBookAsync(Book book)
        {
            await _collection.InsertOneAsync(book);
        }
    }
}
