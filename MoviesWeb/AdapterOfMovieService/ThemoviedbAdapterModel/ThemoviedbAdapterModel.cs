using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesWeb.AdapterOfMovieService.ThemoviedbAdapterModel
{
	public class MoviesApiPageModel
	{
		[JsonProperty("page")]
		public long Page { set; get; }
		[JsonProperty("results")]
		public List<MovieApi> Results = new List<MovieApi>();
		[JsonProperty("total_pages")]
		public long TotalPages { set; get; }
		[JsonProperty("total_results")]
		public long TotalResults { set; get; }
	}
	public class MovieBase
	{
		[JsonProperty("adult")]
		public bool Adult { set; get; }
		[JsonProperty("backdrop_path")]
		public string BackdropPath { set; get; }
		[JsonProperty("id")]
		public long Id { set; get; }
		[JsonProperty("original_language")]
		public string OriginalLanguage { set; get; }
		[JsonProperty("original_title")]
		public string OriginalTitle { set; get; }
		[JsonProperty("overview")]
		public string Overview { set; get; }
		[JsonProperty("popularity")]
		public float Popularity { set; get; }
		[JsonProperty("poster_path")]
		public string PosterPath { set; get; }
		[JsonProperty("release_date")]
		public string ReleaseDate { set; get; }
		[JsonProperty("title")]
		public string Title { set; get; }
		[JsonProperty("video")]
		public bool Video { set; get; }
		[JsonProperty("vote_average")]
		public float VoteAverage { set; get; }
		[JsonProperty("vote_count")]
		public int VoteCount { set; get; }
	}
	public class MovieApi: MovieBase
	{
		[JsonProperty("genre_ids")]
		public List<int> GenreIds = new List<int>();

	}
	public class ProductionCountry
	{
		[JsonProperty("iso_3166_1")]
		public string CountryCode { set; get; }
		[JsonProperty("name")]
		public string Name { set; get; }
	}
	public class SpokenLanguage
	{
		[JsonProperty("english_name")]
		public string EnglishName { set; get; }
		[JsonProperty("iso_639_1")]
		public string CountryCode { set; get; }
		[JsonProperty("name")]
		public string Name { set; get; }
	}
	public class Genre
	{
		[JsonProperty("id")]
		public int Id { set; get; }
		[JsonProperty("name")]
		public string Name { set; get; }
	}
	public class ProductionCompany
	{
		[JsonProperty("id")]
		public long Id { set; get; }
		[JsonProperty("logo_path")]
		public string LogoPath { set; get; }
		[JsonProperty("name")]
		public string Name { set; get; }
		[JsonProperty("origin_country")]
		public string CountryCode { set; get; }
	}
	public class BelongsToCollection
	{
		[JsonProperty("id")]
		public long Id { set; get; }
		[JsonProperty("name")]
		public string Name { set; get; }
		[JsonProperty("poster_path")]
		public string PosterPath { set; get; }
		[JsonProperty("backdrop_path")]
		public string BackdropPath { set; get; }
	}
	public class MovieDetailsApiModel : MovieBase
	{
		[JsonProperty("belongs_to_collection")]
		public BelongsToCollection Belongs = new BelongsToCollection();
		[JsonProperty("budget")]
		public long Budget { set; get; }
		[JsonProperty("imdb_id")]
		public string ImdbId { set; get; }
		[JsonProperty("revenue")]
		public long Revenue { set; get; }
		[JsonProperty("runtime")]
		public int Runtime { set; get; }
		[JsonProperty("status")]
		public string Status { set; get; }
		[JsonProperty("tagline")]
		public string Tagline { set; get; }
		[JsonProperty("genres")]
		public List<Genre> Genres = new List<Genre>();
		[JsonProperty("production_companies")]
		public List<ProductionCompany> ProductionCompanies = new List<ProductionCompany>();
		[JsonProperty("production_countries")]
		public List<ProductionCountry> ProductionCountries = new List<ProductionCountry>();
		[JsonProperty("spoken_languages")]
		public List<SpokenLanguage> SpokenLanguages = new List<SpokenLanguage>();
	}
}