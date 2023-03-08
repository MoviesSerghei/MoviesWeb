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
		private readonly string apiKey = "dad8a59d86a2793dda93aa485f7339c1";
		private readonly string baseUrl = "https://api.themoviedb.org/3/movie/";
		public ThemoviedbAdapter()
		{
			client = new HttpClient();
		}
	
		public async Task<MoviesApiPageModel> GetPopularMovies()
		{
			string responseContent = "";
			try
			{
				var response = await client.GetAsync($"{baseUrl}/popular?api_key={apiKey}");
				if (response.IsSuccessStatusCode)
				{
					responseContent = await response.Content.ReadAsStringAsync();
				}
				else
				{
					throw new HttpRequestException($"GET request failed with status code: {response.StatusCode}");
				}
			}
			catch (Exception ex)
			{
				
			}
			
			var respObj = JsonConvert.DeserializeObject<MoviesApiPageModel>(responseContent);
			return respObj;
		}
			
		public async Task<MoviesApiPageModel> GetTopRatedMoviesApi()
		{
			string responseContent = "";
			try
			{
				var response = await client.GetAsync($"{baseUrl}/top_rated?api_key={apiKey}");
				if (response.IsSuccessStatusCode)
				{
					responseContent = await response.Content.ReadAsStringAsync();
				}
				else
				{
					throw new HttpRequestException($"GET request failed with status code: {response.StatusCode}");
				}
			}
			catch (Exception ex)
			{

			}

			var respObj = JsonConvert.DeserializeObject<MoviesApiPageModel>(responseContent);
			return respObj;
		}
		public async Task<MovieDetailsApiModel> GetMovieDetailsApi(long MovieId) //631842
		{
			string responseContent = "";
			try
			{
				var response = await client.GetAsync($"{baseUrl}/movie/{MovieId}?api_key={apiKey}");
			
				if (response.IsSuccessStatusCode)
				{
					responseContent = await response.Content.ReadAsStringAsync();
				}
				else
				{
					throw new HttpRequestException($"GET request failed with status code: {response.StatusCode}");
				}

			}
			catch (Exception ex)
			{

			}
			var respObj = JsonConvert.DeserializeObject<MovieDetailsApiModel>(responseContent);
			return respObj;
		}
	}
}