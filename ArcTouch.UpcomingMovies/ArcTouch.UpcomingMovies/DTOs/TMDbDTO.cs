namespace ArcTouch.UpcomingMovies.DTOs
{
    public class TMDbDTO
    {
        public results[] results;
        public int page;
        public int total_results;
        public int total_pages;
    }

    public class results
    {
        public int id;
        public string title;
        public string poster_path;
        public int[] genre_ids;
        public string overview;
        public string release_date;
        public string backdrop_path;
    }
}