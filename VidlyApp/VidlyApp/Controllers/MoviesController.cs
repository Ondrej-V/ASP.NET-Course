using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyApp.Models;
using VidlyApp.ViewModels;

namespace VidlyApp.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() {Name = "Shrek!"};
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult ShowMovies()
        {
            var movies = GetMovies();
            var viewmodelMovies = new ShowMovieViewModel()
            {
                Movies = movies
            };

            return View(viewmodelMovies);
        }

        public ActionResult MovieDetail(int? id)
        {
            var movieDetail = GetMovies().SingleOrDefault(m => m.Id == id);
            if (movieDetail == null)
            {
                return HttpNotFound();
            }

            return View(movieDetail);
        }

        private List<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie {Id = 1, Name = "Shrek"},
                new Movie {Id = 2, Name = "Jedine zrno"}
            };
        }
    }
}