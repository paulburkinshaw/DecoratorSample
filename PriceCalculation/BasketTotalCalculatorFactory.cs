using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation
{
    public static class BasketTotalCalculatorFactory
    {
        public static IBasketTotalCalculator GetBasketTotalCalculator(IBasketTotalCalculator basketTotalCalculator)
        {
            basketTotalCalculator = new BuyTwoItemsGetDiscountDecorator("Butter", "Bread", basketTotalCalculator);
            basketTotalCalculator = new BuyThreeItemsGetFourthItemFreeDecorator("Milk", basketTotalCalculator);

            return basketTotalCalculator;
        }
    }
}
