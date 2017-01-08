using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation
{
    public class BuyTwoItemsGetDiscountDecorator : BasketTotalDecorator
    {
        string _sourceItem;
        string _targetItem;

        public BuyTwoItemsGetDiscountDecorator(string sourceItem, string targetItem, IBasketTotalCalculator basketTotalCalculator)
            : base(basketTotalCalculator)
	    {
            this._sourceItem = sourceItem;
            this._targetItem = targetItem;
	    }

        public override decimal CalculateBasketTotal()
	    {
            decimal total = base.CalculateBasketTotal();
           
            decimal discountPrice = 0.00M;
           
            if (base.BasketItems.Exists(x => x.Name == _sourceItem && x.Quantity >= 2))              
                discountPrice = base.BasketItems.Exists(x => x.Name == _targetItem) ? (BasketItems.Find(x => x.Name == _targetItem).Cost * 50 / 100) : 0.00M;
            

            return total - discountPrice;
	    }
    }
}
