using PoqTestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoqTestApi.Services
{
    public interface IProductHighlighter
    {
        IEnumerable<Product> HighlightProducts(IEnumerable<Product> products, string highlightKeywords);
    }
}
