using ArcTouch.UpcomingMovies.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
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
        private IPageDialogService _pageDialogService;
        private INavigationService _navigationService;
        private ObservableCollection<MovieViewModel> _movies = new ObservableCollection<MovieViewModel>();

        public ObservableCollection<MovieViewModel> Movies
        {
            get { return _movies; }
            set { SetProperty(ref _movies, value); }
        }

        public MainPageViewModel(INavigationService navigationService, 
                                 ITMDbService TMDbService, 
                                 IPageDialogService pageDialogService) : base(navigationService)
        {
            _navigationService = navigationService;
            _TMDbService = TMDbService;
            _pageDialogService = pageDialogService;
            Movies = _TMDbService.ListAllUpcomingMovies();
        }

        public DelegateCommand<MovieViewModel> SelectUpcomingMovieCommand
        {
            get
            {
                return new DelegateCommand<MovieViewModel>((movie) =>
                {
                    NavigationParameters parameters = new NavigationParameters
                    {
                        { "upcomingMovie", movie }
                    };
                    _navigationService.NavigateAsync("DetailsPage", parameters);
                });
            }
        }
    }
}
