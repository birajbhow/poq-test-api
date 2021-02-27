using PoqTestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoqTestApi.Services
{
    /// <summary>
    /// A product filter service encapsulating filtering logic 
    /// </summary>
    public interface IProductFilter
    {
        /// <summary>
        /// This method filter products based on max price or/and size
        /// </summary>
        /// <param name="allProducts">List of all products</param>
        /// <param name="maxPrice">Maximum price of a product</param>
        /// <param name="size">Size of a product</param>        
        /// <returns>Filtered list of products</returns>
        IEnumerable<Product> GetFilteredProducts(IEnumerable<Product> allProducts, int maxPrice = 0, string size = null);
    }
}
