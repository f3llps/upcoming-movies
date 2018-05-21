using Prism;
using Prism.Ioc;
using ArcTouch.UpcomingMovies.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;
using ArcTouch.UpcomingMovies.Services.Interfaces;
using ArcTouch.UpcomingMovies.Services.Implementations;
using Prism.Navigation;
using Plugin.Multilingual;
using System.Linq;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ArcTouch.UpcomingMovies
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            CrossMultilingual.Current.CurrentCultureInfo = CrossMultilingual.Current.NeutralCultureInfoList.ToList().First(element => element.EnglishName.Contains("English"));
            AppResources.Culture = CrossMultilingual.Current.CurrentCultureInfo;
            InitializeComponent();
            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register(typeof(INavigationService),typeof(PageNavigationService));
            containerRegistry.Register(typeof(ITMDbService), typeof(InMemoryTMDbServiceViewModel));
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<DetailsPage>();
        }
    }
}
