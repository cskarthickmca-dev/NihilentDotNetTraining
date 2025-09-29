using Microsoft.AspNetCore.Mvc;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static readonly List<string> Products = new() { "Laptop", "Mobile", "Tablet" };

        [HttpGet]
        public IActionResult GetProducts() => Ok(Products);
    }
}
