using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Validation;

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

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult MovieForm()
        {
            var genres = _context.Genres.ToList();
            var movieFormVM = new MovieFormViewModel
            {
                Genres = genres
            };
            return View(movieFormVM);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Include(g => g.Genre).SingleOrDefault(m => m.Id == id);

            if (movie.Id == 0)
             return  HttpNotFound();

            var movieformVM = new MovieFormViewModel(movie)
            {               
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", movieformVM);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Add([Bind(Exclude ="Id")] Movie movie)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    var movieFormVM = new MovieFormViewModel(movie)
                    {                        
                        Genres = _context.Genres.ToList()
                    };

                    return View("MovieForm", movieFormVM);
                }

                if (movie.Id == 0)
                    _context.Movies.Add(movie);
           
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("Index", "Movies");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Update(Movie movie)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    var movieFormVM = new MovieFormViewModel(movie)
                    {                        
                        Genres = _context.Genres.ToList()
                    };

                    return View("MovieForm", movieFormVM);
                }
             
                    var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                    movieInDb.Name = movie.Name;
                    movieInDb.ReleaseDate = movie.ReleaseDate;
                    movieInDb.GenreId = movie.GenreId;
                    movieInDb.NumberInStock = movie.NumberInStock;
                    movieInDb.DateAdded = movie.DateAdded;
                
                _context.SaveChanges();
            }
            catch(DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
           
            return RedirectToAction("Index", "Movies");
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
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");
            return View("ReadOnlyList"); ;
        }
        [Route("movies/GetDetails/{id}")]
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).FirstOrDefault(x => x.Id == id);
            return View(movie);
        }
        [Route("movies/released/{year}/{month:regex(\\d{2})}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);

        }
    }
}