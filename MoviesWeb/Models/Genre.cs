using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesWeb.Models
{
	public class Genre
	{
		public int Id { set; get; }
		public string Name { set; get; }
		//public virtual ICollection<Movie> Movies { get; set; }
	}
}