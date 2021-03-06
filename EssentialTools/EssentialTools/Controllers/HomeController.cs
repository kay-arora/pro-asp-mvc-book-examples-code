using EssentialTools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EssentialTools.Controllers
{
    public class HomeController : Controller
    {
        private IValueCalculator calc;

        public HomeController(IValueCalculator calcParam)
        {
            calc = calcParam;

        }
        private Product[] products =
        {
            new Product{Name = "Kayak", Category = "Watersports", Price = 275M},
            new Product{Name = "Lifejacket", Category = "Watersports", Price = 48.9M},
            new Product{Name = "Soccer ball", Category = "Soccer", Price = 19.5M},
            new Product{Name = "Corner flag", Category = "Soccer", Price = 34.95M}
        };

        // GET: Home
        public ActionResult Index()
        {
            //Adding ninject functionality
            //This below ninject setup can be moved to a seperate location to create DI at the heart of the MVC app
            //and to remove its dependency from the controller
            //IKernel ninjectKernel = new StandardKernel(); //ninjectKernel is the object that is responsible for resolving dependencies and creating new objects
            //ninjectKernel.Bind<IValueCalculator>().To<LinqValueCalculator>();

            //IValueCalculator calc = ninjectKernel.Get<IValueCalculator>();


            //LinqValueCalculator calc = new LinqValueCalculator();
            //apply interface to de-couple
            //IValueCalculator calc = new LinqValueCalculator(); //usually this line can be eliminated when we use dependency injection
            
            ShoppingCart cart = new ShoppingCart(calc) { Products = products };

            decimal totalValue = cart.CalculateProductTotal();

            return View(totalValue);
        }
    }
}