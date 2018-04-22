using ArcTouch.UpcomingMovies.Services.Interfaces;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;

namespace ArcTouch.UpcomingMovies.ViewModels
{
    public class DetailsPageViewModel : BindableBase, INavigationAware
    {
        public DetailsPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        private INavigationService _navigationService;
        private MovieViewModel _upcomingMovie;

        public MovieViewModel UpcomingMovie
        {
            get { return _upcomingMovie; }
            set { SetProperty(ref _upcomingMovie, value); }
        }


        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            UpcomingMovie = parameters["upcomingMovie"] as MovieViewModel;
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
        }
    }
}