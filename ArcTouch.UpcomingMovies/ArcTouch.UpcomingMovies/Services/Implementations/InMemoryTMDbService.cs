using ArcTouch.UpcomingMovies.Services.Interfaces;
using ArcTouch.UpcomingMovies.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ArcTouch.UpcomingMovies.Services.Implementations
{
    public class InMemoryTMDbService : ITMDbService
    {
        private static ObservableCollection<MovieViewModel> _upcomingMovies = new ObservableCollection<MovieViewModel>();

        public InMemoryTMDbService()
        {
            //Layout test
            for (int i = 0; i < 10; i++)
                _upcomingMovies.Add(new MovieViewModel
                {
                    Name = $"Movie {i}",
                    PosterImage = "https://image.tmdb.org/t/p/w500_and_h282_face/oVdLj5JVqNWGY0LEhBfHUuMrvWJ.jpg",
                    ReleaseDate = DateTime.Now,
                    Generes = "Action, Drama, (...)"
                });
        }

        public ObservableCollection<MovieViewModel> ListAllUpcomingMovies()
        {
            return _upcomingMovies;
        }
    }
}
