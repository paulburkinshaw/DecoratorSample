using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation
{
    public class Basket : IBasketTotalCalculator
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

            decimal totalDiscount = 0.00M;

            decimal breadDiscount = 0.00M;
            if (BasketItems.Exists(x => x.Name == "Butter" && x.Quantity == 2))
                breadDiscount = BasketItems.Exists(x => x.Name == "Bread") ? (BasketItems.Find(x => x.Name == "Bread").Cost * 50 / 100) : 0.00M;

            decimal milkDiscount = 0.00M;
            if (BasketItems.Exists(x => x.Name == "Milk" && x.Quantity == 4))
                milkDiscount = BasketItems.Find(x => x.Name == "Milk").Cost;

            totalDiscount += (breadDiscount + milkDiscount);

            return BasketItems.Sum(i => i.Cost * i.Quantity) - totalDiscount;
        }

    }


}
