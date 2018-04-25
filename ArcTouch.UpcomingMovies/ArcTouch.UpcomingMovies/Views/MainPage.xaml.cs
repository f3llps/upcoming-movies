using ArcTouch.UpcomingMovies.Services.Implementations;
using ArcTouch.UpcomingMovies.ViewModels;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ArcTouch.UpcomingMovies.Views
{
    public partial class MainPage : ContentPage
    {
        bool isLoading;
        int actualPage = 2;
        ObservableCollection<MovieViewModel> Items = new ObservableCollection<MovieViewModel>();

        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            TMDbLogo.Source = ImageSource.FromResource("ArcTouch.UpcomingMovies.Resources.TMDbLogo.png");
            ArcTouchLogo.Source = ImageSource.FromResource("ArcTouch.UpcomingMovies.Resources.ArcTouchLogo.png");

            lstViewMovies.ItemAppearing += (sender, e) =>
            {
                var items = this.lstViewMovies.ItemsSource as ObservableCollection<MovieViewModel>;
                var bIsLastItem = (items.Last() == e.Item);

                if (isLoading)
                    return;

                if (bIsLastItem)
                {
                    LoadMoreMovies();
                }
            };
        }

        private async Task LoadMoreMovies()
        {
            isLoading = true;
            var inMemoryTMDbService = new InMemoryTMDbService();
            await inMemoryTMDbService.GetAsync(actualPage);
            actualPage++;
            isLoading = false;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            Device.BeginInvokeOnMainThread(async () =>
            {
                var inMemoryTMDbService = new InMemoryTMDbService();
                var result = await inMemoryTMDbService.GetAsync();
                if (result != null)
                    lstViewMovies.ItemsSource = result;
            });
        }
    }
}