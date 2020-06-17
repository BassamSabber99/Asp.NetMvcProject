using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movies.Include(g => g.Genre).ToList().Select(Mapper.Map<Movie,MovieDto>);
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movieInDb = _context.Movies.Single(m => m.id == id);
            if (movieInDb == null)
                return NotFound();
            return Ok(Mapper.Map<Movie, MovieDto>(movieInDb));
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.id = movie.id;
            return Created(new Uri(Request.RequestUri + "/" + movie.id),movieDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateMovie(int id,MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movieInDb = _context.Movies.Single(m => m.id == id);
            if (movieInDb == null)
                return NotFound();

            Mapper.Map(movieDto,movieInDb);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.Single(m => m.id == id);
            if (movieInDb == null)
                return NotFound();
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
