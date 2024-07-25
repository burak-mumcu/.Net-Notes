using auction_system.Models;
using auction_system.Services;
using Microsoft.AspNetCore.Mvc;

namespace auction_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidController : ControllerBase
    {
        private readonly BidService _bidService;

        public BidController(BidService bidService)
        {
            _bidService = bidService;
        }

        [HttpPost]
        public IActionResult PlaceBid(Bid bid)
        {
            _bidService.PlaceBid(bid);
            return Ok();
        }
    }
}
