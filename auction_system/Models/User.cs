namespace auction_system.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<Bid> Bids { get; set; } = new List<Bid>();
    }

}
