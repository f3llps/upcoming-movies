using ArcTouch.UpcomingMovies.Services.Implementations;
using ArcTouch.UpcomingMovies.Services.Interfaces;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ArcTouch.UpcomingMovies.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        //Atributtes
        private ITMDbService _inMemoryTMDbService;
        private INavigationService _navigationService;
        private bool _isBusy;
        private ObservableCollection<MovieViewModel> _moviesDownloaded;

        //Properties
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        public ObservableCollection<MovieViewModel> MoviesDownloaded
        {
            get { return _moviesDownloaded; }
            set { SetProperty(ref _moviesDownloaded, value); }
        }

        //Constructor
        public MainPageViewModel(INavigationService navigationService, ITMDbService inMemoryTMDbService) : base(navigationService)
        {
            _navigationService = NavigationService;
            _inMemoryTMDbService = inMemoryTMDbService;
            InitializeAsync();
        }

        //Methods
        public async Task InitializeAsync()
        {
            if (!InMemoryTMDbServiceViewModel.UpcomingMoviesDownloaded.Any())
            {
                IsBusy = true;
                await _inMemoryTMDbService.GetUpcomingMoviesByPageAsync(1);
                MoviesDownloaded = new ObservableCollection<MovieViewModel>(InMemoryTMDbServiceViewModel.UpcomingMoviesDownloaded);
                IsBusy = false;
            }
        }

        //Commands
        public DelegateCommand<MovieViewModel> SelectUpcomingMovieCommand
        {
            get
            {
                return new DelegateCommand<MovieViewModel>((selectedUpcomingMovie) =>
                {
                    NavigationParameters parameters = new NavigationParameters
                    {
                        { "selectedUpcomingMovie", selectedUpcomingMovie }
                    };
                    if (selectedUpcomingMovie != null)
                        _navigationService.NavigateAsync("DetailsPage", parameters);
                });
            }
        }


        public DelegateCommand<MovieViewModel> ItemAppearingUpcomingMovieCommand
        {
            get
            {
                return new DelegateCommand<MovieViewModel>(async (appearingUpcomingMovie) =>
                {

                    var isLastMovieDownloaded = (InMemoryTMDbServiceViewModel.UpcomingMoviesDownloaded.LastOrDefault() == appearingUpcomingMovie) ? true : false;
                    if (!IsBusy && InMemoryTMDbServiceViewModel.UpcomingMoviesDownloaded.Any() && isLastMovieDownloaded)
                    {
                        IsBusy = true;
                        await _inMemoryTMDbService.GetUpcomingMoviesByPageAsync(InMemoryTMDbServiceViewModel.ActualPage);
                        MoviesDownloaded = new ObservableCollection<MovieViewModel>(InMemoryTMDbServiceViewModel.UpcomingMoviesDownloaded);
                        IsBusy = false;
                    }
                });
            }
        }

        public DelegateCommand<string> SearchUpcomingMovieCommand
        {
            get
            {
                return new DelegateCommand<string>( (keyword) =>
              {
                  IsBusy = true;

                  if (!string.IsNullOrEmpty(keyword))
                  {
                      var searchedMovies = new ObservableCollection<MovieViewModel>((InMemoryTMDbServiceViewModel.UpcomingMoviesDownloaded).Where(i => i.Name.ToLower().Contains(keyword.ToLower())).ToList());

                      if (searchedMovies.Any())
                          MoviesDownloaded = new ObservableCollection<MovieViewModel>(searchedMovies);
                      else
                          MoviesDownloaded = new ObservableCollection<MovieViewModel>();
                  }
                  else
                      MoviesDownloaded = new ObservableCollection<MovieViewModel>(InMemoryTMDbServiceViewModel.UpcomingMoviesDownloaded);

                  IsBusy = false;
              });
            }
        }

    }
}
