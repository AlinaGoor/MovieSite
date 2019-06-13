using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieSite.Models;

namespace MovieSite.Controllers
{
    public class IndexController : Controller
    {
        private readonly MovieDBContext _context;

        public IndexController(MovieDBContext context)
        {
            _context = context;
            //if (_context.Movies.Count() == 0)
            //{
            //    _context.Movies.Add(new Movie()
            //    {
            //        Id = 1,
            //        Title = "The Godfather",
            //        ReleaseDate = new DateTime(1972, 3, 24)
            //    });
            //    _context.SaveChanges();
            //}
        }

        [Route("")]
        [HttpGet]
        public ActionResult<List<Movie>> Index()
        {
            return _context.Movies.ToList();

        }

        [Route("")]
        [HttpPost]
        public async Task<ActionResult<Movie>> PostIndex([FromBody] Movie movie)
        {
            
            int count = (from row in _context.Movies
                where row.Id != null
                select row).Count();
            movie.Id = ++count;
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Index), new {id = movie.Id}, movie);
        }
    }
}

