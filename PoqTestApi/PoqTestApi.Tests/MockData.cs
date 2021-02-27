using PoqTestApi.Models;
using System.Collections.Generic;

namespace PoqTestApi.Tests
{
    public class MockData
    {
        public static List<Product> GetProducts()
        {
            return new List<Product>
            {
                CreateProduct("A Green Trouser", 10, "This trouser perfectly pairs with a blue shirt.", new List<string> { "small", "medium",}),
                CreateProduct("A red Trouser", 11, "This trouser perfectly pairs with a green shirt.", new List<string> { "small" }),
                CreateProduct("A blue Trouser", 12, "This trouser perfectly pairs with a red shirt.", new List<string> { "medium" })
            };
        }

        private static Product CreateProduct(string title, int price, string description, List<string> sizes)
        {
            return new Product
            {
                Title = title,
                Price = price,
                Description = description,
                Sizes = sizes
            };
        }
    }
}
