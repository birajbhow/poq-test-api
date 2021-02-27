using PoqTestApi.Models;
using System.Collections.Generic;

namespace PoqTestApi.Services
{
    /// <summary>
    /// A product highlighter service
    /// </summary>
    public interface IProductHighlighter
    {
        /// <summary>
        /// This method highlights product description based on supplied keywords
        /// </summary>
        /// <param name="products">List of products</param>
        /// <param name="highlightKeywords">Highlight keywords</param>
        /// <returns>Highlighted products</returns>
        IEnumerable<Product> HighlightProducts(IEnumerable<Product> products, string highlightKeywords = null);
    }
}
