using PoqTestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoqTestApi.Services
{
    /// <summary>
    /// A product filter service encapsulating all filtering and highlighting logic 
    /// </summary>
    public interface IProductFilter
    {
        /// <summary>
        /// Filter and highlight products based on max price, size and highlight keywords
        /// </summary>
        /// <param name="maxprice">Maximum price of a product</param>
        /// <param name="size">Size of a product</param>
        /// <param name="highlight">Description highlighting keywords</param>
        /// <returns>Filtered list of products</returns>
        IEnumerable<Product> GetFilteredProducts(IEnumerable<Product> allProducts, int maxPrice = 0, string size = null);
    }
}
