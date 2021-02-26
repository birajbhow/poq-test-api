using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PoqTestApi.Models;
using PoqTestApi.Services;
using System.Threading.Tasks;

namespace PoqTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductFilter _productFilter;

        public ProductsController(ILogger<ProductsController> logger, IProductFilter productFilter)
        {
            _logger = logger;
            _productFilter = productFilter;
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetProducts(int maxPrice = 0, string size = null, string highlight = null)
        {
            var products = await _productFilter.GetFilteredProducts(maxPrice, size, highlight);

            var filteredResponse = new FilteredResponse
            {
                Products = products
            };

            return Ok(filteredResponse);
        }
    }
}
