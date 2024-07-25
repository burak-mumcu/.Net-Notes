using auction_system.Models;
using auction_system.Repositories;

namespace auction_system.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Auction> Auctions { get; }
        IRepository<Bid> Bids { get; }
        IRepository<User> Users { get; }
        int Complete();
    }
}
