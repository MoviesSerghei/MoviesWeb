using MoviesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MoviesWeb.AdapterOfMovieService.ThemoviedbService;
using System.Threading.Tasks;

namespace MoviesWeb.Controllers
{
	public class HomeController : Controller
	{
		private MoviesWebContext ctx = new MoviesWebContext();
		
		public ActionResult Index()
		{
			var movies = ctx.Movies.OrderBy(q => q.Name).ToList();
			ViewBag.SelectedDepartment = new SelectList(movies, "Name");

			return View(movies.ToList());
		}

		public ActionResult Favorite()
		{
			ViewBag.Message = "Your application description page.";
			var movie = new Movie()
			{
				Name = "movie1",
				Date = System.DateTime.Now,
				Image = "",
				Description = "Description sdfsdf",
				GenreID = 2,
				Rate = 1,
				Favorite = false
			};

			ctx.Movies.Add(movie);
			ctx.SaveChanges();
			return View();
		}

		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Movie movie = ctx.Movies.Find(id);
			if (movie == null)
			{
				return HttpNotFound();
			}
			return View(movie);
		}

		public async Task<ActionResult> Contact()
		{
			ThemoviedbAdapter themoviedbAdapter = new ThemoviedbAdapter();
			
			var resultPopularMovies = await themoviedbAdapter.GetPopularMovies();
			var resultTopRatedMoviesApi = await themoviedbAdapter.GetTopRatedMoviesApi();
			var resultMovieDetailsApi = await themoviedbAdapter.GetMovieDetailsApi(631842);
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}