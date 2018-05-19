using ArcTouch.UpcomingMovies.ViewModels;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using ArcTouch.UpcomingMovies.DTOs;
using System.Collections.ObjectModel;
using ArcTouch.UpcomingMovies.Services.Interfaces;
using Prism.Navigation;

namespace ArcTouch.UpcomingMovies.Services.Implementations
{
    public class InMemoryTMDbServiceViewModel : ITMDbService
    {
        //Attributes
        private const string API_KEY = "1f54bd990f1cdfb230adb312546d765d";
        private const string ROOT_PATH = "https://api.themoviedb.org/3/movie/upcoming";
        private const string ROOT_IMAGE_PATH = "https://image.tmdb.org/t/p/w500/";
        private const string LANGUAGE = "en-US";
        //private const string LANGUAGE = "pt-BR";

        public static int ActualPage { get; set; } = 1;
        public static ObservableCollection<MovieViewModel> UpcomingMoviesDownloaded { get; set; } = new ObservableCollection<MovieViewModel>();

        INavigationService _navigationService;

        //Constructor
        public InMemoryTMDbServiceViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        //Methods
        public async Task GetUpcomingMoviesByPageAsync(int page)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync($"{ROOT_PATH}?api_key={API_KEY}&language={LANGUAGE}&page={page}");

            if (response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                TMDbDTO objTMDbDTO = Newtonsoft.Json.JsonConvert.DeserializeObject<TMDbDTO>(jsonString);

                if (page <= objTMDbDTO.total_pages)
                {
                    for (int i = 0; i < objTMDbDTO.results.Count(); i++)
                    {
                        bool isDuplicatedMovie = UpcomingMoviesDownloaded.Any(x => x.Name == objTMDbDTO.results[i].title);
                        if (isDuplicatedMovie)
                            break;

                        DateTime.TryParse(objTMDbDTO.results[i].release_date, out DateTime date);

                        MovieViewModel includMovie = new MovieViewModel(_navigationService)
                        {
                            Name = objTMDbDTO.results[i].title,
                            PosterImage = ROOT_IMAGE_PATH + objTMDbDTO.results[i].poster_path,
                            ReleaseDate = date,
                            Overview = objTMDbDTO.results[i].overview == "" ? "Not registered." : objTMDbDTO.results[i].overview,
                            BackdropImage = ROOT_IMAGE_PATH + objTMDbDTO.results[i].backdrop_path
                        };

                        includMovie.Genres = includMovie.GetAllGenresByIds(objTMDbDTO.results[i].genre_ids);
                        UpcomingMoviesDownloaded.Add(includMovie);
                    }
                    ActualPage++;
                }
            }
        }
    }
}
