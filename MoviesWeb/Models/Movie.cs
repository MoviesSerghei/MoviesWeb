using System;
using System.Collections.Generic;

namespace MoviesWeb.Models
{
	public class Movie
	{
		public int Id { set; get; }
		public string Name { set; get;}
		public DateTime Date { set; get;}
		public string Image {set; get;}
		public string Description{set; get;}
		public int GenreID { set; get; }
		public int Rate { set; get; }
		public bool Favorite { set; get; }
		public virtual Genre Genre { get; set; }
	}
}
