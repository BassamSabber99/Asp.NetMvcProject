using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        ApplicationDbContext _context;
        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            if (newRental.MovieIds.Count == 0) return BadRequest("No Movie Ids Have Been Given.");
            var customer = _context.Customers.SingleOrDefault(i => i.id == newRental.CustomerId);
            if (customer == null) return BadRequest("Customer ID Is not Valid.");
            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.id)).ToList();
            if (movies.Count != newRental.MovieIds.Count) BadRequest("One Or More Movie Ids Are Invalid.");
            foreach(var movie in movies)
            {
                if (movie.NumberAvailable == 0) return BadRequest("Movie is not available.");
                movie.NumberAvailable--;
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
