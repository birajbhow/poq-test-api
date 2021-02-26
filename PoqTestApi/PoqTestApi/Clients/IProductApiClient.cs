using PoqTestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoqTestApi.Clients
{
    public interface IProductApiClient
    {
        Task<IEnumerable<Product>> GetProducts();
    }
}
