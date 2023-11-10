using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ass_2.Models;
namespace ass_2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            var products = new List<Product>
    {
        new Product { Id = 1, Name = "Product Name 1", Category=Category.Laptop, Price = 999.99M, ImageUrl = "Content/images/copt1.jpg" },
        new Product { Id = 2, Name = "Product Name 2", Category=Category.Laptop, Price = 899.99M, ImageUrl = "Content/images/copt2.jpg" }
        // 更多产品...
    };
            return View(products);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        

    }
}