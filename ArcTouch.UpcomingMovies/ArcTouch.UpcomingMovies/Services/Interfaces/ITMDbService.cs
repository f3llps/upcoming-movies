using ArcTouch.UpcomingMovies.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ArcTouch.UpcomingMovies.Services.Interfaces
{
    //TODO: create model domain
    public interface ITMDbService
    {
        ObservableCollection<MovieViewModel> ListAllUpcomingMovies();
    }
}
