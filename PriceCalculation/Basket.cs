using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation
{
    public class Basket : IBasket
    {
        List<BasketItem> _basketItems = new List<BasketItem>();
     
        public List<BasketItem> BasketItems { get { return _basketItems; } }

        public void AddBasketItem(BasketItem item)
        {
            if(item.Quantity > 0)
                if (BasketItems.Exists(x => x.Name == item.Name))
                    BasketItems.Find(x => x.Name == item.Name).Quantity += item.Quantity;
                else
                {
                    BasketItems.Add(item);
                }     
        }

        public decimal CalculateBasketTotal()
        {
            return BasketItems.Sum(i => i.Cost * i.Quantity);
        }

    }


}
