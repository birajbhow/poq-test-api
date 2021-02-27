using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PoqTestApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PoqTestApi.Clients
{
    /// <inheritdoc/>
    public class ProductApiClient : IProductApiClient
    {
        private readonly string _baseUrl;
        private readonly ILogger<ProductApiClient> _logger;

        public ProductApiClient(IConfiguration configuration, ILogger<ProductApiClient> logger)
        {
            _baseUrl = configuration["ProductsApiBaseUrl"];
            _logger = logger;
        }

        /// <summary>
        /// This method will fetch product data from external api suing fluent url package (flurl)
        /// <see cref="https://flurl.dev/"/>
        /// </summary>
        /// <returns>List of products</returns>
        public async Task<IEnumerable<Product>> GetProducts()
        {
            try
            {
                var response = await ApiUrl.GetJsonAsync<ApiResponse>();

                _logger.LogDebug("Product Api Full Response", response);

                return response.Products;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }

            return new List<Product>();
        }

        private Url ApiUrl => _baseUrl
                    .AppendPathSegments("v2", "5e307edf3200005d00858b49");
    }
}
