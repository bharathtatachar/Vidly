using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }

        public string Title
        {
            get
            {
                return Movie.Id != 0 ? "Edit Movie" : "New Movie";
            }

        }



        public MovieFormViewModel()
        {
            this.Movie = new Movie();
            Movie.Id = 0;
        }



        public MovieFormViewModel(Movie mov)
        {
            Movie.Id = mov.Id;
            Movie.Name = mov.Name;
            Movie.ReleaseDate = mov.ReleaseDate;
            Movie.NumberInStock = mov.NumberInStock;
            Movie.GenreId = mov.GenreId;
            Movie.DateAdded = mov.DateAdded;
        }
    }
}