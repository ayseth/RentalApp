using System;
using System.Web.Http;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using RentalApp.Dtos;
using RentalApp.Models;

namespace RentalApp.Controllers.Api
{
    public class NewRenatlsController : ApiController
    {
        private ApplicationDbContext _context;

       
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {

            var customer = _context.Customers.Single(
                c => c.Id == newRental.CustomerId);
            

            var movies = _context.Movies.Where(
                m => newRental.MovieIds.Contains(m.Id));

           foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie not available")
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
            
        }
    }
}
