using System.Collections.Generic;
using System.Linq;

namespace PoqTestApi.Models
{
    /// <summary>
    /// Api response object combining all calcuated properties
    /// </summary>
    public class FilteredResponse
    {
        // All or filtered and highlighted product list
        public IEnumerable<Product> Products { get; set; }

        // Minimum product price in the above product list
        public int MinPrice => Products?.Count() > 0 ? Products.Min(p => p.Price) : 0;

        // Maximum product price in the above product list
        public int MaxPrice => Products?.Count() > 0 ? Products.Max(p => p.Price) : 0;

        // All product sizes in the above product list
        public IEnumerable<string> AllSizes => Products.SelectMany(p => p.Sizes).Distinct();

        // A list of common words in the above product list descriptions, 
        // excluding top 5 and taking maximum 10 words
        public IEnumerable<string> CommonWords { get; set; }
            
    }
}
