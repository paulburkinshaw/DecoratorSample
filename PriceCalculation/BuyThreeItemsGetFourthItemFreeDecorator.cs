using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation
{
    public class BuyThreeItemsGetFourthItemFreeDecorator : BasketTotalDecorator
    {

            : base(basketTotalCalculator)
        {
            }


            return total - discountPrice;
        }
    }
}
