using ArcTouch.UpcomingMovies.Services.Interfaces;
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
        private ITMDbService _TMDbService;
        private ObservableCollection<MovieViewModel> _movies = new ObservableCollection<MovieViewModel>();

        public ObservableCollection<MovieViewModel> Movies
        {
            get { return _movies; }
            set { SetProperty(ref _movies, value); }
        }

        public MainPageViewModel(INavigationService navigationService, ITMDbService TMDbService) : base(navigationService)
        {
            _TMDbService = TMDbService;
            _movies = _TMDbService.ListAllUpcomingMovies();
        }
    }
}
