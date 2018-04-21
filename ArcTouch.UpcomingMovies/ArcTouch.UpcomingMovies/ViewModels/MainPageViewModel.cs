using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ArcTouch.UpcomingMovies.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private ObservableCollection<MovieViewModel> _movies = new ObservableCollection<MovieViewModel>();
        public ObservableCollection<MovieViewModel> Movies
        {
            get { return _movies; }
            set { SetProperty(ref _movies, value); }
        }

        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            //Layout test
            for (int i = 0; i < 10; i++)
            Movies.Add(new MovieViewModel
            {
                Name = $"Movie {i}",
                PosterImage = "https://image.tmdb.org/t/p/w500_and_h282_face/oVdLj5JVqNWGY0LEhBfHUuMrvWJ.jpg",
                ReleaseDate = DateTime.Now,
                Generes = "Action, Drama, (...)"
            });    
        }
    }
}
