using PoqTestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoqTestApi.Services
{
    public interface IProductFilter
    {
        Task<IEnumerable<Product>> GetFilteredProducts(int maxprice = 0, string size = null, string highlight = null);
    }
}
