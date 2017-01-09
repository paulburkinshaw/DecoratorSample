using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceCalculation.Tests
{
    [TestFixture]
    public class BuyThreeItemsGetFourthItemFreeDecoratorTests
    {
        [Test]
        public void CalculateBasketTotal_FourItems_ReturnsBasketPriceMinusFourthItemPrice()
        {
            // Arrange
            var basketItems = new List<BasketItem>{
                new BasketItem { Name = "Milk", Cost = 1.15M, Quantity = 4 }
            };
            Mock<IBasketTotalCalculator> mockBasket = new Mock<IBasketTotalCalculator>();
            mockBasket.Setup(x => x.BasketItems).Returns(basketItems);
            mockBasket.Setup(x => x.CalculateBasketTotal()).Returns(basketItems.Sum(i => i.Cost * i.Quantity));

            var basketTotalCalculator = new BuyThreeItemsGetFourthItemFreeDecorator("Milk", mockBasket.Object);

            decimal expected = 3.45M;

            // Act
            var result = basketTotalCalculator.CalculateBasketTotal();

            // Assert   
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CalculateBasketTotal_EightItems_ReturnsBasketPriceMinusPriceOfTwoItems()
        {
            // Arrange
            var basketItems = new List<BasketItem>{
                new BasketItem { Name = "Milk", Cost = 1.15M, Quantity = 8 }
            };
            Mock<IBasketTotalCalculator> mockBasket = new Mock<IBasketTotalCalculator>();
            mockBasket.Setup(x => x.BasketItems).Returns(basketItems);
            mockBasket.Setup(x => x.CalculateBasketTotal()).Returns(basketItems.Sum(i => i.Cost * i.Quantity));

            var basketTotalCalculator = new BuyThreeItemsGetFourthItemFreeDecorator("Milk", mockBasket.Object);

            decimal expected = 6.90M;

            // Act
            var result = basketTotalCalculator.CalculateBasketTotal();

            // Assert   
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CalculateBasketTotal_SixItems_ReturnsBasketPriceMinusPriceOfOneItem()
        {
            // Arrange
            var basketItems = new List<BasketItem>{
                new BasketItem { Name = "Milk", Cost = 1.15M, Quantity = 6 }
            };
            Mock<IBasketTotalCalculator> mockBasket = new Mock<IBasketTotalCalculator>();
            mockBasket.Setup(x => x.BasketItems).Returns(basketItems);
            mockBasket.Setup(x => x.CalculateBasketTotal()).Returns(basketItems.Sum(i => i.Cost * i.Quantity));

            var basketTotalCalculator = new BuyThreeItemsGetFourthItemFreeDecorator("Milk", mockBasket.Object);

            decimal expected = 5.75M;

            // Act
            var result = basketTotalCalculator.CalculateBasketTotal();

            // Assert   
            Assert.AreEqual(expected, result);
        }
    }
}
