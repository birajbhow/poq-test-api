using PoqTestApi.Clients;
using PoqTestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoqTestApi.Services
{
    public class ProductFilter : IProductFilter
    {
        private readonly IProductApiClient _apiClient;

        public ProductFilter(IProductApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IEnumerable<Product>> GetFilteredProducts(int maxPrice = 0, string size = null, string highlight = null)
        {
            var products = await _apiClient.GetProducts();
            IEnumerable<Product> filteredProducts = products;

            if (maxPrice > 0)
            {
                filteredProducts = filteredProducts.Where(p => p.Price <= maxPrice);
            }

            if (!string.IsNullOrWhiteSpace(size))
            {
                filteredProducts = filteredProducts.Where(p => p.Sizes.Contains(size));
            }

            if (!string.IsNullOrWhiteSpace(highlight))
            {
                filteredProducts = HightlightProducts(filteredProducts, highlight);
            }
            return filteredProducts;
        }

        private static IEnumerable<Product> HightlightProducts(IEnumerable<Product> products, string highlight)
        {
            var result = new List<Product>();
            var highlightColours = highlight.Split(",").Select(c => c.Trim());

            foreach(var product in products)
            {
                foreach(var colour in highlightColours)
                {
                    if (product.Description.Contains(colour))
                    {
                        product.Description = product.Description.Replace(colour, $"<em>{colour}</em>");
                    }
                }
                result.Add(product);                
            }
            return result;
        }
    }
}
