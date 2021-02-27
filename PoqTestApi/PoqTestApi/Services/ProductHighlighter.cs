using PoqTestApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace PoqTestApi.Services
{
    public class ProductHighlighter : IProductHighlighter
    {
        public IEnumerable<Product> HighlightProducts(IEnumerable<Product> products, string highlightKeywords)
        {   
            if (string.IsNullOrWhiteSpace(highlightKeywords))
            {
                return null;
            }

            var result = new List<Product>();
            var highlightColours = highlightKeywords.Split(",").Select(c => c.Trim());

            foreach (var product in products)
            {
                var highlightedProduct = new Product
                {
                    Title = product.Title,
                    Sizes = product.Sizes,
                    Price = product.Price,
                    Description = product.Description
                };

                foreach (var colour in highlightColours)
                {
                    if (product.Description.Contains(colour))
                    {
                        highlightedProduct.Description = product.Description.Replace(colour, $"<em>{colour}</em>");
                    }
                }
                result.Add(highlightedProduct);
            }
            return result;
        }
    }
}
