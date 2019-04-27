using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace RentalApp.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        //Enable caching
        /*[OutputCache(Duration = 50, Location = OutputCacheLocation.Server, VaryByParam = "*")]*/
        
        //Disable caching
        /*[OutputCache(Duration = 0, VaryByParam = "*", Nostore = true)]*/
        public ActionResult Index()
        {
            return View();
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