using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoqTestApi.Models
{
    public class FilteredResponse
    {
        public IEnumerable<Product> Products { get; set; }

        public int MinPrice => Products.Min(p => p.Price);

        public int MaxPrice => Products.Max(p => p.Price);

        public IEnumerable<string> AllSizes => Products.SelectMany(p => p.Sizes).Distinct();

        public IEnumerable<string> CommonWords
            => Products
            .SelectMany(p => p.Description.Split(' '))
            .Take(10);

    }
}
