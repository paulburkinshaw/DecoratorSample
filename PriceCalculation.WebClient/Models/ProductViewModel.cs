using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PriceCalculation.WebClient.Models
{
    public class ProductViewModel
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
    }
}