using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation
{
    public abstract class BasketTotalDecorator : IBasketTotalCalculator
    {
        IBasketTotalCalculator _basketTotalCalculator;

        protected IBasketTotalCalculator BasketTotalCalculator
        {
            get { return _basketTotalCalculator; }
        }

        public BasketTotalDecorator(IBasketTotalCalculator basketTotalCalculator)
        {
            _basketTotalCalculator = basketTotalCalculator;
        }

        public virtual decimal CalculateBasketTotal()
        {
            return _basketTotalCalculator.CalculateBasketTotal();
        }

        public virtual List<BasketItem> BasketItems { get { return _basketTotalCalculator.BasketItems; } }
    }
}
