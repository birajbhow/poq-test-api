using PoqTestApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PoqTestApi.Clients
{
    /// <summary>
    /// An external api client encapsulating logic to retrieve data
    /// </summary>
    public interface IProductApiClient
    {
        Task<IEnumerable<Product>> GetProducts();
    }
}
