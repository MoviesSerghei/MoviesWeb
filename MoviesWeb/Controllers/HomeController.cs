using MoviesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MoviesWeb.AdapterOfMovieService.ThemoviedbService;
using System.Threading.Tasks;
using MoviesWeb.AdapterOfMovieService.ThemoviedbAdapterModel;
using PagedList;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace MoviesWeb.Controllers
{
	public class HomeController : Controller
	{
		private MoviesWebContext ctx = new MoviesWebContext();
		private ThemoviedbAdapter themoviedbAdapter = new ThemoviedbAdapter();
		public async Task<ViewResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
		{
			ViewBag.CurrentSort = sortOrder;
			ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
			ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

			if (searchString != null)
			{
				page = 1;
			}
			else
			{
				searchString = currentFilter;
			}

			ViewBag.CurrentFilter = searchString;
			IEnumerable<Movie> movies;
			//IEnumerable<Movie> movies = ctx.Movies.OrderBy(q => q.Id);

			//получить фильмы
			var popularMovies = await themoviedbAdapter.GetPopularMovies();
				List<MovieApi> moviesApi;
				if (!String.IsNullOrEmpty(searchString))
				{
					moviesApi = popularMovies.Results.Where(s => s.Title.Contains(searchString)
							       || s.OriginalTitle.Contains(searchString)).ToList();
				}
				else
				{
					moviesApi = popularMovies.Results;
				}

				movies = moviesApi.Select(x => new Movie
				{
					Name = x.Title,
					Date = Convert.ToDateTime(x.ReleaseDate),
					Image = $"https://image.tmdb.org/t/p/w500{x.PosterPath}",
					Description = x.Overview,
					GenreID = 2,
					Rate = x.VoteAverage,
					Favorite = false,
					ExternalMovieId = x.Id
				});
				ctx.Movies.AddRange(movies);
				ctx.SaveChanges();
			/*
			switch (sortOrder)
			{
				case "name_desc":
					students = students.OrderByDescending(s => s.LastName);
					break;
				case "Date":
					students = students.OrderBy(s => s.EnrollmentDate);
					break;
				case "date_desc":
					students = students.OrderByDescending(s => s.EnrollmentDate);
					break;
				default:  // Name ascending 
					students = students.OrderBy(s => s.LastName);
					break;
			}
			*/
			int pageSize = 10;
			int pageNumber = (page ?? 1);
			
			return View(movies.ToPagedList(pageNumber, pageSize));
		}

		/*
		public async Task<ActionResult> Index()
		{

			var resultPopularMovies = await themoviedbAdapter.GetPopularMovies();
			var movies = ctx.Movies.OrderBy(q => q.Name).ToList();
			ViewBag.SelectedDepartment = new SelectList(movies, "Name");

			return View(movies.ToList());
		}
		*/
		public async Task<ActionResult> Favorite()
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

		public async Task<ActionResult> Details(int? id)
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
			var resultTopRatedMoviesApi = await themoviedbAdapter.GetTopRatedMoviesApi();
			var resultMovieDetailsApi = await themoviedbAdapter.GetMovieDetailsApi(631842);
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}