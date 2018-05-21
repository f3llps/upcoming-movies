using Prism.Navigation;

namespace ArcTouch.UpcomingMovies.ViewModels
{
    public class DetailsPageViewModel : ViewModelBase
    {
        //Attribues
        INavigationService _navigationService;
        private MovieViewModel _upcomingMovie;
        private string _name;
        private string _overview;
        private string _genres;
        private string _releaseDate;

        //Properties
        public MovieViewModel UpcomingMovie
        {
            get { return _upcomingMovie; }
            set { SetProperty(ref _upcomingMovie, value); }
        }

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public string Overview
        {
            get { return _overview; }
            set { SetProperty(ref _overview, value); }
        }

        public string Genres
        {
            get { return _genres; }
            set { SetProperty(ref _genres, value); }
        }

        public string ReleaseDate
        {
            get { return _releaseDate; }
            set { SetProperty(ref _releaseDate, value); }
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
            ReleaseDate = AppResources.Release_Date + UpcomingMovie.ReleaseDate.ToShortDateString().ToString();
            Genres = AppResources.Genres + UpcomingMovie.Genres;
            Overview =  AppResources.Overview + UpcomingMovie.Overview;
            Name = AppResources.Name + UpcomingMovie.Name;
        }
    }
}