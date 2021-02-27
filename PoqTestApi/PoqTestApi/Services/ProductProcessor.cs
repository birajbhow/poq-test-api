using PoqTestApi.Clients;
using PoqTestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoqTestApi.Services
{
    public class ProductProcessor : IProductProcessor
    {
        private readonly IProductApiClient _apiClient;
        private readonly IProductFilter _productFilter;
        private readonly IProductHighlighter _productHighlighter;

        public ProductProcessor(IProductApiClient apiClient, IProductFilter productFilter, 
            IProductHighlighter productHighlighter)
        {
            _apiClient = apiClient;
            _productFilter = productFilter;
            _productHighlighter = productHighlighter;
        }

        public async Task<FilteredResponse> GetFilteredResponse(int maxPrice = 0, string size = null, string highlight = null)
        {
            // Fetch products from external api
            var products = await _apiClient.GetProducts();

            // Filter products by maxprice and/or size
            var filteredProducts = _productFilter.GetFilteredProducts(products, maxPrice, size);

            // Highlight product description by highlight keywords
            var highlightedProducts = _productHighlighter.HighlightProducts(filteredProducts, highlight);

            // Build filterd response object
            return new FilteredResponse
            {
                Products = highlightedProducts,
                CommonWords = BuildCommonWordsList(filteredProducts)
            };            
        }

        // Build a list of common words in the above product list descriptions, 
        // excluding top 5 and taking maximum 10 words
        private IEnumerable<string> BuildCommonWordsList(IEnumerable<Product> filteredProducts) 
            => filteredProducts
            .SelectMany(p => p.Description.Remove(p.Description.Length - 1).Split(' '))
            .GroupBy(w => w)
            .OrderByDescending(g => g.Count())
            .Select(g => g.Key)
            .Skip(5)
            .Take(10);
    }
}
