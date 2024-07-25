using auction_system.Models;
using System.Linq.Expressions;

namespace auction_system.Specifications
{
    public class ActiveAuctionsSpecification : ISpecification<Auction>
    {
        public Expression<Func<Auction, bool>> ToExpression()
        {
            return auction => auction.IsActive && auction.EndTime > DateTime.UtcNow;
        }
    }
}
