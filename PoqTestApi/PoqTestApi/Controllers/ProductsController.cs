using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PoqTestApi.Models;
using PoqTestApi.Services;
using System;
using System.Threading.Tasks;

namespace PoqTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductProcessor _productProcessor;

        public ProductsController(ILogger<ProductsController> logger, IProductProcessor productProcessor)
        {
            _logger = logger;
            _productProcessor = productProcessor;
        }

        /// <summary>
        /// Get filtered product response
        /// </summary>
        /// <param name="maxprice">Maximum price of a product</param>
        /// <param name="size">Size of a product</param>
        /// <param name="highlight">Description highlighting keywords(comma separated)</param>
        /// <returns>Filtered response object</returns>
        [HttpGet("filter")]
        public async Task<IActionResult> GetFilterdResonse(int maxPrice = 0, string size = null, string highlight = null)
        {
            try
            {
                // Retrieve filtered response
                var filteredResponse = await _productProcessor.GetFilteredResponse(maxPrice, size, highlight);

                _logger.LogDebug("Filtered Response Object", filteredResponse);

                return Ok(filteredResponse);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            return Problem("Some error occurred! Try with valid input fields.", null, 500);
        }
    }
}
