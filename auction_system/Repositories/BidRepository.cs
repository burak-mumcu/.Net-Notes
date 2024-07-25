using auction_system.Infrastructure;
using auction_system.Models;
using Microsoft.EntityFrameworkCore;

namespace auction_system.Repositories
{
    public class BidRepository : IRepository<Bid>
    {
        private readonly AppDbContext _context;

        public BidRepository(AppDbContext context)
        {
            _context = context;
        }

        public Bid Get(int id) => _context.Bids.Include(b => b.Auction).Include(b => b.User).SingleOrDefault(b => b.Id == id);

        public IEnumerable<Bid> GetAll() => _context.Bids.Include(b => b.Auction).Include(b => b.User).ToList();

        public IEnumerable<Bid> Find(System.Linq.Expressions.Expression<System.Func<Bid, bool>> predicate)
            => _context.Bids.Include(b => b.Auction).Include(b => b.User).Where(predicate);

        public void Add(Bid entity) => _context.Bids.Add(entity);

        public void AddRange(IEnumerable<Bid> entities) => _context.Bids.AddRange(entities);

        public void Remove(Bid entity) => _context.Bids.Remove(entity);

        public void RemoveRange(IEnumerable<Bid> entities) => _context.Bids.RemoveRange(entities);
    }
}
