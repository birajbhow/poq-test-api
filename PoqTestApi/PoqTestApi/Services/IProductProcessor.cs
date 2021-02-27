using PoqTestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoqTestApi.Services
{
    public interface IProductProcessor
    {
        Task<FilteredResponse> GetFilteredResponse(int maxPrice = 0, string size = null, string highlight = null);
    }
}
