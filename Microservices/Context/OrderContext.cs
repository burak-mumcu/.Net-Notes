using Microservices.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Context
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
    }
}
