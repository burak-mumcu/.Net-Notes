using auction_system.Models;
using auction_system.Services;
using Microsoft.AspNetCore.Mvc;

namespace auction_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        private readonly AuctionService _auctionService;

        public AuctionController(AuctionService auctionService)
        {
            _auctionService = auctionService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Auction>> GetActiveAuctions()
        {
            return Ok(_auctionService.GetActiveAuctions());
        }

        [HttpPost]
        public IActionResult CreateAuction(Auction auction)
        {
            _auctionService.CreateAuction(auction);
            return Ok();
        }
    }
}
