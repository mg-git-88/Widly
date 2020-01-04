using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Widly.Models;
using Widly.ViewModels;

namespace Widly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Movies

        public ActionResult Index()
        {
            var movieViewModel = new MovieViewModel
            {
                Movies = _context.Movies.Include(m => m.Genre)
            };
            return View(movieViewModel);
        }

        //[Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        //public ActionResult ByReleaseDate(int year, int month)
        //{
        //    return Content(year + "/" + month);
        //}

        public ActionResult MovieDetails(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(o => o.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }


        public ActionResult MovieForm()
        {
            var genres = _context.Genres.ToList();
            var movieViewModel = new MovieViewModel 
            {
                Genres = genres
            };
            return View(movieViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (movie != null && movie.Id == 0)
            {
                movie.DateAdded = DateTime.Today;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.DateAdded = DateTime.Today;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EditMovie(int id)
        {
            var viewModel = new MovieViewModel
            {
                Movie = _context.Movies.Single(m => m.Id == id),
                Genres = _context.Genres
            };
            return View("MovieForm", viewModel);
        }

    }
}