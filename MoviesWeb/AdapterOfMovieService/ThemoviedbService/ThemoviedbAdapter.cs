using MoviesWeb.AdapterOfMovieService.ThemoviedbAdapterModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MoviesWeb.AdapterOfMovieService.ThemoviedbService
{
	public class ThemoviedbAdapter
	{
		private readonly HttpClient client;

		public ThemoviedbAdapter()
		{
			client = new HttpClient();
		}
		Dictionary<string, string> values = new Dictionary<string, string>
		{
		   { "api_key", "dad8a59d86a2793dda93aa485f7339c1" },
		};
		string BaseUrl = "https://api.themoviedb.org/";
		/*
			"API_Key": "dad8a59d86a2793dda93aa485f7339c1",

			"UrlForPopularMovies": "https://api.themoviedb.org/3/movie/popular?api_key=",

			"UrlForTopRatedMovies": "https://api.themoviedb.org/3/movie/top_rated?api_key=",

			"UrlForMovieDetails": "https://api.themoviedb.org/3/movie/"
		 
		*/
		public async Task<string> PostAsync(string url, string data)
		{
			var content1 = new StringContent(data, Encoding.UTF8, "application/json");
			var content = new FormUrlEncodedContent(values);
			//client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "dad8a59d86a2793dda93aa485f7339c1");
			var response = await client.GetAsync(url);
			var responseString = await response.Content.ReadAsStringAsync();
			return responseString;
		}
		public async Task<PopularMoviesApiModel> GetPopularMovies()
		{
			string result="";
			var content = new FormUrlEncodedContent(values);
			try
			{
				//client.DefaultRequestHeaders.Authorization =  new AuthenticationHeaderValue("Bearer", "dad8a59d86a2793dda93aa485f7339c1");
				var response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Post, "https://api.themoviedb.org/3/movie/popular?api_key=dad8a59d86a2793dda93aa485f7339c1"));
				result = await response.Content.ReadAsStringAsync();
			}
			catch (Exception ex)
			{
				;
			}
			finally
			{
				;
			}
			
			
			var respObj = JsonConvert.DeserializeObject<PopularMoviesApiModel>(result);
			return respObj;
		}
			
		public async Task<TopRatedMoviesApiModel> GetTopRatedMoviesApi()
		{
			var content = new FormUrlEncodedContent(values);
			var response = await client.GetAsync("https://api.themoviedb.org/3/movie/top_rated?api_key=dad8a59d86a2793dda93aa485f7339c1");
			var result = await response.Content.ReadAsStringAsync();
			var respObj = JsonConvert.DeserializeObject<TopRatedMoviesApiModel>(result);
			return respObj;
		}
		public async Task<MovieDetailsApiModel> MovieDetailsApi()
		{
			var content = new FormUrlEncodedContent(values);
			var response = await client.GetAsync("https://api.themoviedb.org/3/movie/");
			var result = await response.Content.ReadAsStringAsync();
			var respObj = JsonConvert.DeserializeObject<MovieDetailsApiModel>(result);
			return respObj;
		}
	}
}