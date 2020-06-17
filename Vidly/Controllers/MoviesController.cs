using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Authorize(Roles = RoleName.CanManageMovie)]

        public ActionResult New()
        {
            var genre = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genres = genre
            };
            return View("MovieForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewmodel = new MovieFormViewModel(movie)
                {
                    
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewmodel);
            }
            if (movie.id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
                
            else
            {
                var movieInDb = _context.Movies.Single(m => m.id == movie.id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.genreId = movie.genreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                

            }

            _context.SaveChanges();

            return RedirectToAction("index","Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.id == id);
            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }










        // GET: Movies/Random
        public ActionResult index()
        {
            if (User.IsInRole(RoleName.CanManageMovie))
            {
                return View("List");
            }
            return View("ReadOnlyList");
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(i => i.id == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
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


        
    }
}