using Prism.Mvvm;
using System;
using System.Collections.Generic;

namespace ArcTouch.UpcomingMovies.ViewModels
{
    public class TMDbUpcomingMovieViewModel
    {
        public results[] results;
        public int page;
        public int total_results;
        public int total_pages;
    }

    public class results
    { 
        public string title;
        public string poster_path;
        public int[] genre_ids;
        public string overview;
        public string release_date;
        public string backdrop_path;
    }
}