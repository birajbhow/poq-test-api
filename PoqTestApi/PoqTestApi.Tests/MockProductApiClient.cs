using PoqTestApi.Clients;
using PoqTestApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PoqTestApi.Tests
{
    public class MockProductApiClient : IProductApiClient
    {
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await Task.FromResult(MockData.GetProducts());
        }
    }
}
