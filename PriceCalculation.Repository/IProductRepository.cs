using PriceCalculation.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Repository
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
    }
}
