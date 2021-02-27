using NUnit.Framework;
using PoqTestApi.Services;
using System.Linq;

namespace PoqTestApi.Tests
{
    public class ProductHighlighterTests
    {
        private ProductHighlighter _subject;

        [SetUp]
        public void Setup()
        {
            _subject = new ProductHighlighter();
        }

        [Test]
        public void HighlightProducts_Dont_Highlight_If_No_Keywords_Supplied()
        {
            // arrange
            var products = MockData.GetProducts();

            // act
            var result = _subject.HighlightProducts(products);

            // assert
            Assert.AreEqual(0, result.ToList().Where(p => p.Description.Contains("<em>")).Count());
        }

        [Test]
        public void HighlightProducts_Dont_Highlight_If_Invalid_Keywords_Supplied()
        {
            // arrange
            var products = MockData.GetProducts();
            var highlightKeyword = "invalid";

            // act
            var result = _subject.HighlightProducts(products, highlightKeyword);

            // assert
            Assert.AreEqual(0, result.ToList().Where(p => p.Description.Contains("<em>")).Count());
        }

        [Test]
        public void HighlightProducts_Highlight_Product_If_Valid_Keywords_Supplied()
        {
            // arrange
            var products = MockData.GetProducts();
            var highlightKeyword = "green";

            // act
            var result = _subject.HighlightProducts(products, highlightKeyword);

            // assert
            Assert.AreEqual(1, result.ToList().Where(p => p.Description.Contains("<em>")).Count());
        }

        [Test]
        public void HighlightProducts_Highlight_Product_If_Multiple_Keywords_Supplied()
        {
            // arrange
            var products = MockData.GetProducts();
            var highlightKeyword = "green,red";

            // act
            var result = _subject.HighlightProducts(products, highlightKeyword);

            // assert
            Assert.AreEqual(2, result.ToList().Where(p => p.Description.Contains("<em>")).Count());
        }
    }
}