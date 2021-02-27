using NUnit.Framework;
using PoqTestApi.Services;
using System.Linq;

namespace PoqTestApi.Tests
{
    public class ProductFilterTests
    {
        private ProductFilter _subject;

        [SetUp]
        public void Setup()
        {
            _subject = new ProductFilter();
        }

        [Test]
        public void GetFilteredProducts_Returns_All_Products_If_No_Filters_Supplied()
        {
            // arrange
            var products = MockData.GetProducts();

            // act
            var result = _subject.GetFilteredProducts(products);

            // assert
            Assert.AreEqual(products.Count, result.ToList().Count());
        }

        [Test]
        public void GetFilteredProducts_Returns_FilteredProducts_By_MaxPrice()
        {
            // arrange
            var products = MockData.GetProducts();

            // act
            var result = _subject.GetFilteredProducts(products, 10);

            // assert
            Assert.AreEqual(products.First(p => p.Price == 10), result.First());
        }

        [Test]
        public void GetFilteredProducts_Returns_FilteredProducts_By_Size()
        {
            // arrange
            var products = MockData.GetProducts();
            var mediumSize = "medium";
            var expectedProductCount = products.Count(p => p.Sizes.Contains(mediumSize));

            // act
            var result = _subject.GetFilteredProducts(products, 0, mediumSize);

            // assert
            Assert.AreEqual(expectedProductCount, result.Count());
        }

        [Test]
        public void GetFilteredProducts_Returns_FilteredProducts_By_MaxPrice_And_Size()
        {
            // arrange
            var products = MockData.GetProducts();
            var maxPrice = 12;
            var smallSize = "small";
            var expectedProductCount = products.Count(p => p.Price <= maxPrice && p.Sizes.Contains(smallSize));

            // act
            var result = _subject.GetFilteredProducts(products, maxPrice, smallSize);

            // assert
            Assert.AreEqual(expectedProductCount, result.Count());
        }

        [Test]
        public void GetFilteredProducts_Returns_Empty_ProductList_If_Invalid_Filter_Supplied()
        {
            // arrange
            var products = MockData.GetProducts();
            var mediumSize = "med";

            // act
            var result = _subject.GetFilteredProducts(products, 0, mediumSize);

            // assert
            Assert.AreEqual(0, result.Count());            
        }
    }
}