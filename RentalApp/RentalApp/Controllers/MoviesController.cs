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

            var viewResult = new ViewResult();
            ViewResult.ViewData.Model  //the movie object passed below will be aassigned to "Model" here, the "View" method below will take care of this so this line is not necessary

            return View(movie);
        }

        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1, 12}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
       

        
    }
}