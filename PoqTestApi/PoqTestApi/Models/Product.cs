using System.Collections.Generic;

namespace PoqTestApi.Models
{
    public class Product
    {
        public string Title { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Sizes { get; set; }
    }
}
