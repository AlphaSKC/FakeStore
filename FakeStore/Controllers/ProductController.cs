using FakeStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace FakeStore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productServices;
        public ProductController(IProductService productServices)
        {
            _productServices = productServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productServices.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("currency/{currency}")]
        public async Task<IActionResult> GetProductsByCurrency(string currency)
        {
            var products = await _productServices.GetProductsByCurrency(currency);
            return Ok(products);
        }
    }
}
