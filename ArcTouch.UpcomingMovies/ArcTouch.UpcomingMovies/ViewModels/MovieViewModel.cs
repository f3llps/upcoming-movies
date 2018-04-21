using Prism.Mvvm;
using System;
using System.Collections.Generic;

namespace ArcTouch.UpcomingMovies.ViewModels
{
    public class MovieViewModel : BindableBase
    {
        public MovieViewModel()
        {
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _overview;
        public string Overview
        {
            get { return _overview; }
            set { SetProperty(ref _overview, value); }
        }

        private string _generes;
        public string Generes
        {
            get { return _generes; }
            set { SetProperty(ref _generes, value); }
        }

        private string _posterImage;
        public string PosterImage
        {
            get { return _posterImage; }
            set { SetProperty(ref _posterImage, value); }
        }

        private DateTime _releaseDate;
        public DateTime ReleaseDate
        {
            get { return _releaseDate; }
            set { SetProperty(ref _releaseDate, value); }
        }
    }
}