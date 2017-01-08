using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation
{
    public class Basket
    {
        public Basket()
        {
            BasketItems = new List<BasketItem>();
        }

        public List<BasketItem> BasketItems {get; private set;}

        public void AddBasketItem(BasketItem item)
        {
            BasketItems.Add(item);
        }

    }
}
