using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceCalculation.Tests
{
    [TestFixture]
    public class BasketTests
    {
        #region AddBasketItem tests

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
       
            // Act
            basket.AddBasketItem(item);
         
            var result = basket.BasketItems;

            // Assert
            Assert.AreEqual(0, result.Count, "Number of actual elements do not match the expected number of elements");


        }

        #endregion


        #region CalculateBasketTotal tests

        [Test]
        public void CalculateBasketTotal_SingleItem_ReturnsItemCostMultipliedByItemQuantity()
        {
            // Arrange
            var item = new BasketItem { Name = "Butter", Cost = 0.80M, Quantity = 2 };

            var basket = new Basket();
            basket.AddBasketItem(item);

            decimal expected = 1.60M;

            // Act
            var result = basket.CalculateBasketTotal();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CalculateBasketTotal_MultipleItems_ReturnsSumOfItemCostMultipliedByItemQuantity()
        {
            // Arrange
            var item1 = new BasketItem { Name = "Bread", Cost = 1.00M, Quantity = 1 };
            var item2 = new BasketItem { Name = "Butter", Cost = 0.80M, Quantity = 1 };
            var item3 = new BasketItem { Name = "Milk", Cost = 1.15M, Quantity = 1 };
        
            var basket = new Basket();
            basket.AddBasketItem(item1);
            basket.AddBasketItem(item2);
            basket.AddBasketItem(item3);

            decimal expected = 2.95M;

            // Act
            var result = basket.CalculateBasketTotal();

            // Assert
            Assert.AreEqual(expected, result);
        }


        [Test]
        public void CalculateBasketTotal_TwoButterItemsOneBread_BreadItemCostIsDiscountedByFiftyPercent()
        {
            // Arrange
            var item1 = new BasketItem { Name = "Bread", Cost = 1.00M, Quantity = 1 };
            var item2 = new BasketItem { Name = "Butter", Cost = 0.80M, Quantity = 2 };
           
            var basket = new Basket();
            basket.AddBasketItem(item1);
            basket.AddBasketItem(item2);
          
            decimal expected = 2.10M;

            // Act
            var result = basket.CalculateBasketTotal();

            // Assert
            Assert.AreEqual(expected, result);
        }


        [Test]
        public void CalculateBasketTotal_FourMilkItems_OneMilkIsFree()
        {
            // Arrange
            var item = new BasketItem { Name = "Milk", Cost = 1.15M, Quantity = 4 };

            var basket = new Basket();
            basket.AddBasketItem(item);

            decimal expected = 3.45M;

            // Act
            var result = basket.CalculateBasketTotal();

            // Assert
            Assert.AreEqual(expected, result);
        }
       



        #endregion
    }
}
