using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoqTestApi.Models
{
    /// <summary>
    /// External api response object
    /// </summary>
    public class ApiResponse
    {
        public IEnumerable<Product> Products { get; set; }
        public ApiKeys ApiKeys { get; set; }
    }
}
