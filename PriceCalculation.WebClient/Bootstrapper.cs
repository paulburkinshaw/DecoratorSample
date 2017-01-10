using Microsoft.Practices.Unity;
using PriceCalculation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity.Mvc5;

namespace PriceCalculation.WebClient
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }


        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IProductRepository, ProductRepositoryStub>();
            container.RegisterType<IBasket, Basket>();

           

            return container;
        }
    }
}