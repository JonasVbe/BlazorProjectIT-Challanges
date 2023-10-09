using BlazorIAPP.models;

namespace BlazorIAPP.services
{
    public class MovieSearchResult
    {
        public string? Response { get; set; }
        public string? Error { get; set; }
        public int TotalResults { get; set; }
        public List<Movie>? Search { get; set; }
    }
}