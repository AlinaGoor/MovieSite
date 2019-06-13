using System;
using System.Collections.Generic;
using System.Linq;
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
            if (_context.Movies.Count() == 0)
            {
                _context.Movies.Add(new Movie()
                {
                    Id = 1,
                    Title = "The Godfather",
                    ReleaseDate = new DateTime(1972, 3, 24)
                });
                _context.SaveChanges();
            }
        }

        [Route("")]
        [HttpGet]
        public ActionResult<List<Movie>> GetAll()
        {
            return _context.Movies.ToList();
        }


    }
}

