using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation
{
    public class BuyThreeItemsGetFourthItemFreeDecorator : BasketTotalDecorator
    {
        string _item;


        public BuyThreeItemsGetFourthItemFreeDecorator(string item, IBasketTotalCalculator basketTotalCalculator)
            : base(basketTotalCalculator)
        {
            this._item = item;           
        }

        public override decimal CalculateBasketTotal()
        {
            decimal total = base.CalculateBasketTotal();

            decimal discountPrice = 0.00M;
            int discounts = 0;

            if (base.BasketItems.Exists(x => x.Name == _item && x.Quantity >= 4))
            {
                var item = base.BasketItems.Find(x => x.Name == _item);
                discounts = item.Quantity / 4;
                discountPrice = item.Cost * discounts;
            }


            return total - discountPrice;
        }
    }
}
