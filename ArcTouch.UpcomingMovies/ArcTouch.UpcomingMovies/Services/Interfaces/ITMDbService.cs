using System.Threading.Tasks;

namespace ArcTouch.UpcomingMovies.Services.Interfaces
{
    public interface ITMDbService 
    {
          Task GetUpcomingMoviesByPageAsync(int page);
    }
}
