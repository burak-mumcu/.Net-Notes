using auction_system.Models;
using Microsoft.EntityFrameworkCore;

namespace auction_system.Infrastructure
{
    public class AppDbContext : DbContext
    {
      
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
