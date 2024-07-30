using qraphql.Models;

namespace qraphql.GraphQL
{
    public class Mutation
    {
        public async Task<Book> AddBook([Service] ApplicationDbContext context, string title, int authorId)
        {
            var book = new Book { Title = title, AuthorId = authorId };
            context.Books.Add(book);
            await context.SaveChangesAsync();
            return book;
        }

        public async Task<Author> AddAuthor([Service] ApplicationDbContext context, string name)
        {
            var author = new Author { Name = name };
            context.Authors.Add(author);
            await context.SaveChangesAsync();
            return author;
        }
    }
}
