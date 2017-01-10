using PriceCalculation.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Repository
{
    public class ProductRepositoryStub : IProductRepository
    {
        public List<Product> GetProducts()
        {
            return new List<Product>()
            {
                new Product { Name = "Bread", Cost = 1.00M},
                new Product { Name = "Butter", Cost = 0.80M},
                new Product { Name = "Milk", Cost = 1.15M}
            };
        }
    }
}
