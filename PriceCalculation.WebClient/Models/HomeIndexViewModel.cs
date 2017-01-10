using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PriceCalculation.WebClient.Models
{
    public class HomeIndexViewModel
    {
        public List<ProductViewModel> Products { get; set; }
        public decimal BasketTotal { get; set; }
    }
}