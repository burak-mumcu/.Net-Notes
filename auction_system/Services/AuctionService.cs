using auction_system.Models;
using auction_system.Specifications;
using auction_system.UnitOfWork;

namespace auction_system.Services
{
    public class AuctionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuctionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Auction> GetActiveAuctions()
        {
            var spec = new ActiveAuctionsSpecification();
            return _unitOfWork.Auctions.Find(spec.ToExpression());
        }

        public void CreateAuction(Auction auction)
        {
            _unitOfWork.Auctions.Add(auction);
            _unitOfWork.Complete();
        }
    }
}
