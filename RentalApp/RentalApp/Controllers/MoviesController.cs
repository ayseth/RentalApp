using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentalApp.Models;

namespace RentalApp.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() {Name = "Shrek!"};

            ViewData["randomMovie"] = movie;
            ViewBag.Movie = movie; //movie property is added to run bag at runtime, so no compile time safety

            return View();
        }

        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1, 12}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
       

        
    }
}