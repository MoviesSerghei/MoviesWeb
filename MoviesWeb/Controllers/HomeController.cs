using MoviesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviesWeb.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";
			using (var ctx = new MoviesWebContext())
			{
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
				/*
				var genre = new Genre()
				{
					Name = "Научная Фантастика"
				};
				ctx.Genres.Add(genre);
				ctx.SaveChanges();*/
			}
			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}