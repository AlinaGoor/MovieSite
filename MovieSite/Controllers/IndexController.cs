using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieSite.Models;

namespace MovieSite.Controllers
{
    [Route("")]
    [ApiController]
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

        
        [HttpGet]
        public ActionResult<List<Movie>> Index()
        {
            return _context.Movies.ToList();

        }

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

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}

