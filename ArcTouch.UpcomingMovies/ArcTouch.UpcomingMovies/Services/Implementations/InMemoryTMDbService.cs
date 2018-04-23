using ArcTouch.UpcomingMovies.Services.Interfaces;
using ArcTouch.UpcomingMovies.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using ArcTouch.UpcomingMovies.Enums;

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
                            string genre = "";
                            foreach (var item in movie.results[i].genre_ids)
                            {
                                switch (item)
                                {
                                    case (short)GenreEnum.ACTION:
                                        genre += "Action, ";
                                        break;
                                    case (short)GenreEnum.ADVENTURE:
                                        genre += "Adventure, ";
                                        break;
                                    case (short)GenreEnum.ANIMATION:
                                        genre += "Animation, ";
                                        break;
                                    case (short)GenreEnum.COMEDY:
                                        genre += "Comedy, ";
                                        break;
                                    case (short)GenreEnum.CRIME:
                                        genre += "Crime, ";
                                        break;
                                    case (short)GenreEnum.DOCUMENTARY:
                                        genre += "Documentary, ";
                                        break;
                                    case (short)GenreEnum.DRAMA:
                                        genre += "Drama, ";
                                        break;
                                    case (short)GenreEnum.FAMILY:
                                        genre += "Family, ";
                                        break;
                                    case (short)GenreEnum.FANTASY:
                                        genre += "Fantasy, ";
                                        break;
                                    case (short)GenreEnum.HISTORY:
                                        genre += "History, ";
                                        break;
                                    case (short)GenreEnum.HORROR:
                                        genre += "Horror, ";
                                        break;
                                    case (short)GenreEnum.MUSIC:
                                        genre += "Music, ";
                                        break;
                                    case (short)GenreEnum.MYSTERY:
                                        genre += "Mystery, ";
                                        break;
                                    case (short)GenreEnum.ROMANCE:
                                        genre += "Romance, ";
                                        break;
                                    case (short)GenreEnum.SCIENCE_FICTION:
                                        genre += "Science Fiction, ";
                                        break;
                                    case (short)GenreEnum.TV_MOVIE:
                                        genre += "TV Movie, ";
                                        break;
                                    case (short)GenreEnum.THRILLER:
                                        genre += "Thriller, ";
                                        break;
                                    case (short)GenreEnum.WAR:
                                        genre += "War, ";
                                        break;
                                    case (short)GenreEnum.WESTERN:
                                        genre += "Western, ";
                                        break;
                                }

                            }

                            if (!String.IsNullOrEmpty(genre))
                            genre = genre.Remove(genre.Length - 2, 2) + ".";


                            var includMovie = new MovieViewModel
                            {
                                Name = movie.results[i].title,
                                PosterImage = $"https://image.tmdb.org/t/p/w600_and_h900_bestv2/{movie.results[i].poster_path}",
                                ReleaseDate = Convert.ToDateTime(movie.results[i].release_date),
                                Generes = genre,
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
