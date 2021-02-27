using NUnit.Framework;
using PoqTestApi.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoqTestApi.Tests
{
    public class ProductProcessorTests
    {
        private ProductProcessor _subject;

        [SetUp]
        public void Setup()
        {   
            _subject = new ProductProcessor(new MockProductApiClient(), new ProductFilter(), new ProductHighlighter());
        }

        [Test]
        public async Task GetFilteredResponse_Returns_Valid_Response_With_AllProducts()
        {
            // arrange
            var products = MockData.GetProducts();
            var expectedCommonWords = new List<string> { "a", "shirt", "blue", "green", "red" };

            // act
            var result = await _subject.GetFilteredResponse();

            // assert
            Assert.AreEqual(products.Count(), result.Products.Count());
            Assert.AreEqual(products.Min(p => p.Price), result.MinPrice);
            Assert.AreEqual(products.Max(p => p.Price), result.MaxPrice);
            Assert.AreEqual(products.SelectMany(p => p.Sizes).Distinct(), result.AllSizes);
            Assert.AreEqual(expectedCommonWords, result.CommonWords);
        }
    }
}