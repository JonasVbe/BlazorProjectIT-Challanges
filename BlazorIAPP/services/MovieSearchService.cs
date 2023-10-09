using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorIAPP.models;
using BlazorIAPP.services;

namespace BlazorIAPP.services
{
    public class MovieSearchService
    {
        private readonly HttpClient _httpClient;

        public MovieSearchService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<MovieSearchResult?> SearchMoviesAsync(string searchTerm, string apiKey)
        {
            if (string.IsNullOrEmpty(searchTerm) || searchTerm.Length > 15)
            {
                return null;
            }

            var search = searchTerm.Replace(" ", "%20");

            try
            {
                var response = await _httpClient.GetAsync($"https://www.omdbapi.com/?s={search}&type=movie&apikey={apiKey}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<MovieSearchResult>();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}