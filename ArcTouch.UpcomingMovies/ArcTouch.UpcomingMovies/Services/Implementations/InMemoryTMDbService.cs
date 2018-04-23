using ArcTouch.UpcomingMovies.Services.Interfaces;
using ArcTouch.UpcomingMovies.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;
using System.Collections.Generic;

namespace ArcTouch.UpcomingMovies.Services.Implementations
{
    public class InMemoryTMDbService : ITMDbService
    {
        private static ObservableCollection<MovieViewModel> _upcomingMovies = new ObservableCollection<MovieViewModel>();

        public async Task<ObservableCollection<MovieViewModel>> GetAsync()
        {
            try
            {
                HttpClient client = new HttpClient();
                int actualPage = 1;
                int totalPages = 99;

                do
                {
                    var response = await client.GetAsync($"https://api.themoviedb.org/3/movie/upcoming?api_key=1f54bd990f1cdfb230adb312546d765d&language=en-US&page={actualPage}");

                    if (response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
                    {
                        var jsonstring = await response.Content.ReadAsStringAsync();
                        var movie = Newtonsoft.Json.JsonConvert.DeserializeObject<TMDbUpcomingMovieViewModel>(jsonstring);

                        //The total_pages is depending on the actualPage???
                        if (actualPage == 1)
                            totalPages = movie.total_pages;

                        for (int i = 0; i < movie.results.Count(); i++)
                        {
                            var includMovie = new MovieViewModel
                            {
                                Name = movie.results[i].title,
                                PosterImage = $"https://image.tmdb.org/t/p/w600_and_h900_bestv2/{movie.results[i].poster_path}",
                                ReleaseDate = Convert.ToDateTime(movie.results[i].release_date),
                                //Generes = movie.results[i].genre_ids.ToString(),
                                Overview = movie.results[i].overview,
                                BackdropImage = $"https://image.tmdb.org/t/p/w600_and_h900_bestv2/{movie.results[i].backdrop_path}"
                            };

                            var isDuplicated = _upcomingMovies.FirstOrDefault(x => x.Name.Equals(includMovie.Name));
                            if (isDuplicated == null)
                                _upcomingMovies.Add(includMovie);
                        }
                        actualPage++;
                    }

                } while (actualPage <= totalPages);

                return _upcomingMovies;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ObservableCollection<MovieViewModel> ListAllUpcomingMovies()
        {
            return _upcomingMovies;
        }
    }
}
