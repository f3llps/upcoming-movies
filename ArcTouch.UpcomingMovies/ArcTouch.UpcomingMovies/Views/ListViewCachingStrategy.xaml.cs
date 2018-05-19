using ArcTouch.UpcomingMovies.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArcTouch.UpcomingMovies.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewCachingStrategy : ContentView
    {
        public ListViewCachingStrategy()
        {
            InitializeComponent();
        }

        //https://github.com/luberda-molinet/FFImageLoading/wiki/Xamarin.Forms-Advanced
        protected override void OnBindingContextChanged()
        {
            BackdropImage.Source = null;
            var item = BindingContext as MovieViewModel;

            if (item == null)
                return;

            BackdropImage.Source = item.BackdropImage;
            base.OnBindingContextChanged();
        }
    }
}