using Microservices.Models;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private static readonly List<Order> Orders = new List<Order>
        {
            new Order { Id = 1, ProductName = "Laptop", Quantity = 1, TotalPrice = 999.99M },
            new Order { Id = 2, ProductName = "Smartphone", Quantity = 2, TotalPrice = 1199.98M }
        };

        private readonly HttpClient _httpClient;

        public OrderController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public IEnumerable<Order> Get() => Orders;

        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            var order = Orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
                return NotFound();
            return order;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Order order)
        {
            // Ürünün varlığını kontrol et
            var response = await _httpClient.GetAsync($"http://localhost:5000/Product/{order.Id}");
            if (!response.IsSuccessStatusCode)
                return BadRequest("Ürün bulunamadı");

            order.Id = Orders.Count + 1;
            Orders.Add(order);
            return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
        }
    }
}
