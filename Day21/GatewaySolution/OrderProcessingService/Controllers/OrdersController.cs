using Microsoft.AspNetCore.Mvc;

namespace OrderProcessingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private static readonly List<string> Orders = new();

        [HttpPost]
        public IActionResult PlaceOrder([FromBody] string product)
        {
            Orders.Add(product);
            return Ok($"Order placed for {product}");
        }

        [HttpGet]
        public IActionResult GetOrders() => Ok(Orders);
    }
}
