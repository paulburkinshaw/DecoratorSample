using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceCalculation.Tests
{
    [TestFixture]
    public class BasketTests
    {
        [Test]
        public void AddBasketItem_SingleItem_ItemIsAdded()
        {
            // Arrange
            var item = new BasketItem { Name = "Butter", Cost = 0.80M, Quantity = 1 };
            var basket = new Basket();

            var expected = new List<BasketItem>
            {
                item
            };

            // Act
            basket.AddBasketItem(item);
            var result = basket.BasketItems;

            // Assert
            Assert.AreEqual(expected.Count, result.Count, "Number of actual elements do not match the expected number of elements");

            Assert.IsTrue(expected.All(e => result.Count(a => a.Name == e.Name) == 1)
                          && expected.All(e => result.Count(a => a.Cost == e.Cost) == 1)
                          && expected.All(e => result.Count(a => a.Quantity == e.Quantity) == 1), "Actual items do not match expected items");

        }


        [Test]
        public void AddBasketItem_DuplicateItem_ExistingItemQuantityIsIncremented()
        {
            // Arrange
            var item = new BasketItem { Name = "Butter", Cost = 0.80M, Quantity = 1 };
            var item2 = new BasketItem { Name = "Butter", Cost = 0.80M, Quantity = 1 };
            var basket = new Basket();

            var expected = new List<BasketItem>
            {
                new BasketItem { Name = "Butter", Cost = 0.80M, Quantity = 2 }
            };

            // Act
            basket.AddBasketItem(item);
            basket.AddBasketItem(item2);
            var result = basket.BasketItems;

            // Assert
            Assert.AreEqual(expected.Count, result.Count, "Number of actual elements do not match the expected number of elements");

            Assert.IsTrue(expected.All(e => result.Count(a => a.Name == e.Name) == 1)
                          && expected.All(e => result.Count(a => a.Cost == e.Cost) == 1)
                          && expected.All(e => result.Count(a => a.Quantity == e.Quantity) == 1), "Actual items do not match expected items");

        }

        [Test]
        public void AddBasketItem_ItemWithZeroQuantity_ItemIsNotAdded()
        {
            // Arrange
            var item = new BasketItem { Name = "Butter", Cost = 0.80M, Quantity = 0 };
            
            var basket = new Basket();

            var expected = new List<BasketItem>();
         
            // Act
            basket.AddBasketItem(item);
         
            var result = basket.BasketItems;

            // Assert
            Assert.AreEqual(expected.Count, result.Count, "Number of actual elements do not match the expected number of elements");

         
        }
    }
}
