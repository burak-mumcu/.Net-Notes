using auction_system.Infrastructure;
using Microsoft.EntityFrameworkCore;
using auction_system.Models;

namespace auction_system.Repositories
{
    public class AuctionRepository : IRepository<Auction>
    {
        private readonly AppDbContext _context;

        public AuctionRepository(AppDbContext context)
        {
            _context = context;
        }

        public Auction Get(int id) => _context.Auctions.Include(a => a.Bids).SingleOrDefault(a => a.Id == id);

        public IEnumerable<Auction> GetAll() => _context.Auctions.Include(a => a.Bids).ToList();

        public IEnumerable<Auction> Find(System.Linq.Expressions.Expression<System.Func<Auction, bool>> predicate)
            => _context.Auctions.Include(a => a.Bids).Where(predicate);

        public void Add(Auction entity) => _context.Auctions.Add(entity);

        public void AddRange(IEnumerable<Auction> entities) => _context.Auctions.AddRange(entities);

        public void Remove(Auction entity) => _context.Auctions.Remove(entity);

        public void RemoveRange(IEnumerable<Auction> entities) => _context.Auctions.RemoveRange(entities);
    }
}
