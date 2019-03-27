using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentalApp.Models;

namespace RentalApp.ViewModels
{
    public class NewMovieViewModel
    {
        public IEnumerable<Genre> Genre { get; set; }
        public Movie Movie { get; set; }
    }
}