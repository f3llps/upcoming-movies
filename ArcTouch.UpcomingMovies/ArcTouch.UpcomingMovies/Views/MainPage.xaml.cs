using ArcTouch.UpcomingMovies.Services.Interfaces;
using Prism.Navigation;
using Xamarin.Forms;

namespace ArcTouch.UpcomingMovies.Views
{
    public partial class MainPage : ContentPage
    {
        private INavigationService _navigationService;
        private ITMDbService _inMemoryTMDbService;

        public MainPage(INavigationService navigationService, ITMDbService inMemoryTMDbService)
        {
            InitializeComponent();
            _navigationService = navigationService;
            _inMemoryTMDbService = inMemoryTMDbService;
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}