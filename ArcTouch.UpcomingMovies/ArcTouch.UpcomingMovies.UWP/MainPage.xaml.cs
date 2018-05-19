using Prism;
using Prism.Ioc;

namespace ArcTouch.UpcomingMovies.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new ArcTouch.UpcomingMovies.App(new UwpInitializer()));
        }
    }

    public class UwpInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry container)
        {

        }
    }
}
