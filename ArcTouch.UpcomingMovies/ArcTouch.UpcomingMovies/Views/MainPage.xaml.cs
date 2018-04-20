using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ArcTouch.UpcomingMovies.Views
{
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            TMDbLogo.Source = ImageSource.FromResource("ArcTouch.UpcomingMovies.Resources.TMDbLogo.png");
            ArcTouchLogo.Source = ImageSource.FromResource("ArcTouch.UpcomingMovies.Resources.ArcTouchLogo.png");
        }
    }
}