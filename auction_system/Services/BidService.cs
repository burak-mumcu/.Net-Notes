using auction_system.Models;
using auction_system.UnitOfWork;

namespace auction_system.Services
{
    public class BidService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BidService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void PlaceBid(Bid bid)
        {
            var auction = _unitOfWork.Auctions.Get(bid.AuctionId);
            if (auction != null && auction.IsActive && auction.EndTime > DateTime.UtcNow)
            {
                _unitOfWork.Bids.Add(bid);
                _unitOfWork.Complete();
            }
        }
    }
}
