using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        List<Movie> lstMovies = new List<Movie>
            {
                new Movie{Name = "Shrek!",Id = 1},
                new Movie{Name = "Wall-e", Id = 2}
            };

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies
        public ActionResult Random()
        {
            
            var movie = new Movie() { Name = "Shrek!"};

            var customers = new List<Customer>
            {
                new Customer{ Name = "Customer 1" },
                new Customer{Name = "Customer 2" }
            };

            var viewmodel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };


            //return Content("Hello World!");
            // return HttpNotFound();
            //return new EmptyResult();
            // return RedirectToAction("Index", "Home", new { page = "1", sortBy = "name" });

            return View(viewmodel);
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        [Route("movies/Index")]
        public ActionResult Index()
        {
            //if (!pageIndex.HasValue)
            //    pageIndex = 1000;

            //if (string.IsNullOrWhiteSpace(sortBy))
            //    sortBy = "MovieName";

            //return Content(string.Format("Index={0}&sortBy={1}", pageIndex, sortBy));
            //  MoviesViewModel moviesVM = new MoviesViewModel { Movies = lstMovies };
            var movies = _context.Movies.Include(c => c.GenreType);
            return View(movies);
        }
        [Route("movies/GetDetails/{id}")]
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(c => c.GenreType).FirstOrDefault(x => x.Id == id);
            return View(movie);
        }
        [Route("movies/released/{year}/{month:regex(\\d{2})}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);

        }
    }
}