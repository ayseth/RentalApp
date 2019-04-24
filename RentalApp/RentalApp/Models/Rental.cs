using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RentalApp.Models
{
    public class Rental
    {
        public int ID { get; set; }

        [Required]
        public Movie Movie { get; set; }

        public DateTime DateRented { get; set; }

        [Required]
        public Customer Customer { get; set; }
    }
}