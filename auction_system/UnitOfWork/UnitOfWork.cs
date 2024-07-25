using auction_system.Infrastructure;
using auction_system.Models;
using auction_system.Repositories;

namespace auction_system.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Auctions = new AuctionRepository(_context);
            Bids = new BidRepository(_context);
            Users = new UserRepository(_context);
        }

        public IRepository<Auction> Auctions { get; private set; }
        public IRepository<Bid> Bids { get; private set; }
        public IRepository<User> Users { get; private set; }

        public int Complete() => _context.SaveChanges();

        public void Dispose() => _context.Dispose();
    }
}
