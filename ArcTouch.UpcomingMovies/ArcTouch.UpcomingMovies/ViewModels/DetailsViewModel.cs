using Prism.Navigation;

namespace ArcTouch.UpcomingMovies.ViewModels
{
    public class DetailsPageViewModel : ViewModelBase
    {
        //Attribues
        INavigationService _navigationService;
        private MovieViewModel _upcomingMovie;

        //Properties
        public MovieViewModel UpcomingMovie
        {
            get { return _upcomingMovie; }
            set { SetProperty(ref _upcomingMovie, value); }
        }

        //Constructor
        public DetailsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = NavigationService;
        }

        //Methods
        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            UpcomingMovie = parameters["selectedUpcomingMovie"] as MovieViewModel;
        }

    }
}