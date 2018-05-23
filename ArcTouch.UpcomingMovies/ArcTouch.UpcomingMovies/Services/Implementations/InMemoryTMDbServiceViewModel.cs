using ArcTouch.UpcomingMovies.ViewModels;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using ArcTouch.UpcomingMovies.DTOs;
using System.Collections.ObjectModel;
using ArcTouch.UpcomingMovies.Services.Interfaces;
using Prism.Navigation;
using System.Collections.Generic;

namespace ArcTouch.UpcomingMovies.Services.Implementations
{
    public class InMemoryTMDbServiceViewModel : ITMDbService
    {
        //Attributes
        private const string API_KEY = "1f54bd990f1cdfb230adb312546d765d";
        private const string ROOT_PATH = "https://api.themoviedb.org/3/";
        private const string ROOT_IMAGE_PATH = "https://image.tmdb.org/t/p/w500/";

        INavigationService _navigationService;

        //Properties
        public static List<Genres> Genres { get; set; }
        public static string Language { get; set; } = "en-US";
        public static int ActualPage { get; set; } = 1;
        public static ObservableCollection<MovieViewModel> UpcomingMoviesDownloaded { get; set; } = new ObservableCollection<MovieViewModel>();

        //Constructor
        public InMemoryTMDbServiceViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

        }

        //Methods
        public async Task GetUpcomingMoviesByPageAsync(int page)
        {

            HttpClient client = new HttpClient();
            var additionalPath = "movie/upcoming";
            var response = await client.GetAsync($"{ROOT_PATH}{additionalPath}?api_key={API_KEY}&language={Language}&page={page}");

            if (response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                TMDbDTO objTMDbDTO = Newtonsoft.Json.JsonConvert.DeserializeObject<TMDbDTO>(jsonString);

                if (page <= objTMDbDTO.total_pages)
                {
                    for (int i = 0; i < objTMDbDTO.results.Count(); i++)
                    {
                        DateTime.TryParse(objTMDbDTO.results[i].release_date, out DateTime date);
                        TimeSpan difference = date - DateTime.Now;
                        int daysLeft = Convert.ToInt32(Math.Ceiling(difference.TotalDays));
                        daysLeft = (daysLeft < 0) ? 0 : daysLeft; 

                        MovieViewModel includMovie = new MovieViewModel(_navigationService)
                        {
                            Name = objTMDbDTO.results[i].title,
                            PosterImage = ROOT_IMAGE_PATH + objTMDbDTO.results[i].poster_path,
                            ReleaseDate = date.ToShortDateString(),
                            Overview = objTMDbDTO.results[i].overview == "" ? AppResources.Not_registered : objTMDbDTO.results[i].overview,
                            BackdropImage = ROOT_IMAGE_PATH + objTMDbDTO.results[i].backdrop_path,
                            DaysLeft = daysLeft.ToString() + " day(s) left."
                        };

                        includMovie.Genres = includMovie.GetGenresByIds(objTMDbDTO.results[i].genre_ids);
                        UpcomingMoviesDownloaded.Add(includMovie);
                    }
                    ActualPage++;
                }
            }
        }

        public async Task GetAllGenres()
        {
            Genres = new List<Genres>();
            HttpClient client = new HttpClient();
            var additionalPath = "genre/movie/list";
            var response = await client.GetAsync($"{ROOT_PATH}{additionalPath}?api_key={API_KEY}&language={Language}");

            if (response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                GenresDTO objGenresDTO = Newtonsoft.Json.JsonConvert.DeserializeObject<GenresDTO>(jsonString);

                for (int i = 0; i < objGenresDTO.Genres.Count(); i++)
                {
                    Genres.Add(objGenresDTO.Genres[i]);
                }
            }
        }
    }
}
