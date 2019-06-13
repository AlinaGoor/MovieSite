using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MovieSite.Models;

namespace MovieSite.Controllers
{
    public class IndexController : Controller
    {
        private Movie _actualMovie = new Movie()
        {
            Id = 1,
            Title = "The Godfather",
            ReleaseDate = new DateTime(1972, 3, 24)
        };
        private Movie _actualMovie2 = new Movie()
        {
            Id = 2,
            Title = "The Godfathere",
            ReleaseDate = new DateTime(1972, 4, 24)
        };

        private IEnumerable<Movie> _allOfMovies = new Movie[]{new Movie()
            {
                Id = 2,
                Title = "One",
                ReleaseDate = new DateTime(1972, 4, 24)
            }, new Movie()
            {
                Id = 1,
                Title = "TWo",
                ReleaseDate = new DateTime(1972, 3, 24)
            }
    };


        [Route("")]
        public IActionResult Index()
        {
            
            return View(_allOfMovies);
        }
    }
}