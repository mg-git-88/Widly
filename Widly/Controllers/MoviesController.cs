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
            var movieViewModel = new RandomMovieViewModel();
            return View(movieViewModel);
        }

        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
        public ActionResult MovieDetails(int id)
        {
            var movieViewModel = new RandomMovieViewModel();
            Movie movie = new Movie();
            movie.Name = movieViewModel.Movies.Find(o => o.Id == id).Name;
            return View(movie);
        }
    }
}