using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Widly.Models;
using Widly.ViewModels;

namespace Widly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            var movieViewModel = new RandomMovieViewModel
            {
                Movies = GetMovies()
            };
            return View(movieViewModel);
        }

        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
        public ActionResult MovieDetails(int id)
        {
            var movie = new Movie
            {
                Name = GetMovies().Single(o => o.Id == id).Name
            };
            if(movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        private IEnumerable<Movie> GetMovies()
        {
            var movies = new List<Movie>
            {
                new Movie {Id=1, Name="Shrek"},
                new Movie {Id=2, Name="Wall-E"},
                new Movie {Id=3, Name="Spiderman"},
                new Movie {Id=4, Name="Inception"}
            };
            return movies;
        }
    }
}