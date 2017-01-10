using PriceCalculation.Repository;
using PriceCalculation.WebClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PriceCalculation.WebClient.Controllers
{
    public class HomeController : Controller
    {

        IProductRepository _productRepository;
        IBasket _basket;

        public HomeController(IProductRepository productRepository, IBasket basket)
        {
            _productRepository = productRepository;
            _basket = basket;
        }

        public ActionResult Index()
        {
            
            var products = _productRepository.GetProducts();

            var ProductViewModelList = (from p in products
                                       select new ProductViewModel
                                       {
                                           ProductName = p.Name,
                                           ProductPrice = p.Cost                                       
                                       }).ToList();

            return View(new HomeIndexViewModel { Products = ProductViewModelList });
        }

        [HttpPost]
        public ActionResult Index(HomeIndexViewModel viewModel)
        {
          
            var basketItems = from p in viewModel.Products
                              select new BasketItem
                              {
                                  Name = p.ProductName,
                                  Cost = p.ProductPrice,
                                  Quantity = p.Quantity
                              };

            foreach (var item in basketItems)
            {
                _basket.AddBasketItem(item);
            }

            IBasketTotalCalculator basketTotalCalculator = _basket;
            basketTotalCalculator = BasketTotalCalculatorFactory.GetBasketTotalCalculator(basketTotalCalculator);

            viewModel.BasketTotal = basketTotalCalculator.CalculateBasketTotal();

            return View(viewModel);
        }

       
    }
}