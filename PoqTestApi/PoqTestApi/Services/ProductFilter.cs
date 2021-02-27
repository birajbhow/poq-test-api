using PoqTestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PoqTestApi.Services
{
    public class ProductFilter : IProductFilter
    {
        public IEnumerable<Product> GetFilteredProducts(IEnumerable<Product> allProducts, int maxPrice = 0, string size = null)
        {
            IEnumerable<Product> filteredProducts = allProducts;

            if (maxPrice > 0)
            {
                filteredProducts = filteredProducts.Where(p => p.Price <= maxPrice);
            }

            if (!string.IsNullOrWhiteSpace(size))
            {
                filteredProducts = filteredProducts.Where(p => p.Sizes.Contains(size));
            }

            return filteredProducts;
        }
    }
}
