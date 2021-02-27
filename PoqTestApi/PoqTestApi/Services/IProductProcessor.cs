using PoqTestApi.Models;
using System.Threading.Tasks;

namespace PoqTestApi.Services
{
    /// <summary>
    /// A service which encapsulate all product processing logic for e.g. fetching, filtering, 
    /// highlighting and building response object
    /// </summary>
    public interface IProductProcessor
    {
        Task<FilteredResponse> GetFilteredResponse(int maxPrice = 0, string size = null, string highlight = null);
    }
}
