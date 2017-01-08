﻿using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceCalculation.Tests
{
    [TestFixture]
    public class BuyTwoItemsGetDiscountDecoratorTests
    {
        [Test]
        public void CalculateBasketTotal_TwoSourceItemsOneTargetItem_ReturnsBasketPriceMinusDiscount()
        {
            // Arrange
            var basketItems = new List<BasketItem>{
                new BasketItem { Name = "Bread", Cost = 1.00M, Quantity = 1 },
                new BasketItem { Name = "Butter", Cost = 0.80M, Quantity = 2 }
            };
            Mock<IBasketTotalCalculator> mockBasket = new Mock<IBasketTotalCalculator>();
            mockBasket.Setup(x => x.BasketItems).Returns(basketItems);
            mockBasket.Setup(x => x.CalculateBasketTotal()).Returns(basketItems.Sum(i => i.Cost * i.Quantity));

            var basketTotalCalculator = new BuyTwoItemsGetDiscountDecorator("Butter", "Bread", mockBasket.Object);

            decimal expected = 2.10M;
           
            // Act
            var result = basketTotalCalculator.CalculateBasketTotal();

            // Assert   
            Assert.AreEqual(expected, result);
        }


        
    }
}
