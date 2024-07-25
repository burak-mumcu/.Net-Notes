using auction_system.Infrastructure;
using auction_system.Models;
using Microsoft.EntityFrameworkCore;

namespace auction_system.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public User Get(int id) => _context.Users.Include(u => u.Bids).SingleOrDefault(u => u.Id == id);

        public IEnumerable<User> GetAll() => _context.Users.Include(u => u.Bids).ToList();

        public IEnumerable<User> Find(System.Linq.Expressions.Expression<System.Func<User, bool>> predicate)
            => _context.Users.Include(u => u.Bids).Where(predicate);

        public void Add(User entity) => _context.Users.Add(entity);

        public void AddRange(IEnumerable<User> entities) => _context.Users.AddRange(entities);

        public void Remove(User entity) => _context.Users.Remove(entity);

        public void RemoveRange(IEnumerable<User> entities) => _context.Users.RemoveRange(entities);
    }
}
