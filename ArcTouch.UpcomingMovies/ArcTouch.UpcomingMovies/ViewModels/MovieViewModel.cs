using ArcTouch.UpcomingMovies.Enums;
using ArcTouch.UpcomingMovies.Services.Implementations;
using Prism.Navigation;
using System;
using System.Linq;

namespace ArcTouch.UpcomingMovies.ViewModels
{
    public class MovieViewModel : ViewModelBase
    {
        //Attributes
        private string _name;
        private string _overview;
        private string _posterImage;
        private string _genres;
        private string _backdropImage;
        private string _releaseDate;
        private string _daysLeft;

        //Properties
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

        public string PosterImage
        {
            get { return _posterImage; }
            set { SetProperty(ref _posterImage, value); }
        }

        public string BackdropImage
        {
            get { return _backdropImage; }
            set { SetProperty(ref _backdropImage, value); }
        }

        public string ReleaseDate
        {
            get { return _releaseDate; }
            set { SetProperty(ref _releaseDate, value); }
        }

        public string DaysLeft
        {
            get { return _daysLeft; }
            set { SetProperty(ref _daysLeft, value); }
        }

        //Constructor
        public MovieViewModel(INavigationService navigationService) : base(navigationService) { }

        //Methods
        public string GetGenresByIds(int[] genresIds)
        {
            string genres = "";
            foreach (int genreId in genresIds)
                genres += InMemoryTMDbServiceViewModel.Genres.FirstOrDefault(g => g.Id == genreId).Name + ", ";
                    
            if (!String.IsNullOrEmpty(genres))
                genres = genres.Remove(genres.Length - 2, 2);

            return genres;
        }
    }
}