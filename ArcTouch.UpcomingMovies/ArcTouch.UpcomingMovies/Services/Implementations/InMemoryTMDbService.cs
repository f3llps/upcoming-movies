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
                    Generes = "Action, Drama, (...)",
                    Overview = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean quam justo, fermentum id porta non, congue ac purus. Praesent varius fringilla odio, nec elementum odio efficitur a. Etiam egestas sodales est, quis ornare turpis laoreet nec. Praesent elementum egestas ipsum sed auctor. Praesent lacinia, massa non consequat viverra, odio orci aliquet nisi, et mattis tortor felis nec dui. Suspendisse suscipit, leo eu imperdiet efficitur, ex elit ullamcorper ante, at ornare odio sapien sit amet felis. Mauris nibh libero, ultricies feugiat sodales nec, sagittis eu magna. Quisque id feugiat felis. Donec volutpat non neque a blandit. Aliquam eu tincidunt urna. Sed in congue elit, non tincidunt leo. Vestibulum sed laoreet libero. Donec tincidunt pretium euismod. "
                });
        }

        public ObservableCollection<MovieViewModel> ListAllUpcomingMovies()
        {
            return _upcomingMovies;
        }
    }
}
