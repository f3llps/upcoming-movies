using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using FFImageLoading.Forms.Droid;
using Prism;
using Prism.Ioc;

namespace ArcTouch.UpcomingMovies.Droid
{
    [Activity(Label = "ArcTouch.UpcomingMovies", 
              Icon = "@mipmap/ic_launcher", 
              Theme = "@style/MainTheme", 
              MainLauncher = false, 
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        internal static MainActivity Instance { get; private set; }

        protected override void OnCreate(Bundle bundle)
        {
            Instance = this;
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            CachedImageRenderer.Init(true);
            UserDialogs.Init(() => (Activity)Instance);
            LoadApplication(new App(new AndroidInitializer()));
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry container)
        {
            // Register any platform specific implementations
        }
    }
}

