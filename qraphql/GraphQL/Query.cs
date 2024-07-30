using qraphql.Models;
using HotChocolate;
using HotChocolate.Types;
using System.Collections.Generic;
using System.Linq;

namespace qraphql.GraphQL
{
    public class Query
    {
        public List<Book> GetBooks([Service] ApplicationDbContext context) => context.Books.ToList();
        public List<Author> GetAuthors([Service] ApplicationDbContext context) => context.Authors.ToList();

    }
}
