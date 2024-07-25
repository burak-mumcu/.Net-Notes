using System.Security.Cryptography;

namespace auction_system.Models
{
    public class Auction
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public decimal StartingPrice { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsActive { get; set; }
        public List<Bid> Bids { get; set; } = new List<Bid>();
    }
}
