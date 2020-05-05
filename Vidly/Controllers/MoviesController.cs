using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        

        public List<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie{Name = "Shrek"},
                new Movie{Name = "Wall-e"}
            };
        }

        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customer = new List<Customer>
            {
                new Customer{Name = "Customer 1"},
                new Customer{Name = "Customer 2"},
            };


            var viewmodel = new RandomMovieViewModel
            {
                Movie = movie,
                Customer = customer
            };

            return View(viewmodel);
        }

        public ActionResult index()
        {
            var movie = GetMovies();
            return View(movie);
        }


    }
}