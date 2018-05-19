using ArcTouch.UpcomingMovies.Enums;
using Prism.Navigation;
using System;

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
        private DateTime _releaseDate;
        
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

        public DateTime ReleaseDate
        {
            get { return _releaseDate; }
            set { SetProperty(ref _releaseDate, value); }
        }

        //Constructor
        public MovieViewModel(INavigationService navigationService) : base(navigationService) { }

        //Methods
        public string GetAllGenresByIds(int[] genresIds)
        {
            string genres = "";
            foreach (int genreId in genresIds)
            {
                switch (genreId)
                {
                    case (short)GenreEnum.ACTION:
                        genres += "Action, ";
                        break;
                    case (short)GenreEnum.ADVENTURE:
                        genres += "Adventure, ";
                        break;
                    case (short)GenreEnum.ANIMATION:
                        genres += "Animation, ";
                        break;
                    case (short)GenreEnum.COMEDY:
                        genres += "Comedy, ";
                        break;
                    case (short)GenreEnum.CRIME:
                        genres += "Crime, ";
                        break;
                    case (short)GenreEnum.DOCUMENTARY:
                        genres += "Documentary, ";
                        break;
                    case (short)GenreEnum.DRAMA:
                        genres += "Drama, ";
                        break;
                    case (short)GenreEnum.FAMILY:
                        genres += "Family, ";
                        break;
                    case (short)GenreEnum.FANTASY:
                        genres += "Fantasy, ";
                        break;
                    case (short)GenreEnum.HISTORY:
                        genres += "History, ";
                        break;
                    case (short)GenreEnum.HORROR:
                        genres += "Horror, ";
                        break;
                    case (short)GenreEnum.MUSIC:
                        genres += "Music, ";
                        break;
                    case (short)GenreEnum.MYSTERY:
                        genres += "Mystery, ";
                        break;
                    case (short)GenreEnum.ROMANCE:
                        genres += "Romance, ";
                        break;
                    case (short)GenreEnum.SCIENCE_FICTION:
                        genres += "Science Fiction, ";
                        break;
                    case (short)GenreEnum.TV_MOVIE:
                        genres += "TV Movie, ";
                        break;
                    case (short)GenreEnum.THRILLER:
                        genres += "Thriller, ";
                        break;
                    case (short)GenreEnum.WAR:
                        genres += "War, ";
                        break;
                    case (short)GenreEnum.WESTERN:
                        genres += "Western, ";
                        break;
                }
            }

            if (!String.IsNullOrEmpty(genres))
                genres = genres.Remove(genres.Length - 2, 2) + ".";

            return genres;
        }
    }
}