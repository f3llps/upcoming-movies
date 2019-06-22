using System.Threading.Tasks;

namespace ArcTouch.UpcomingMovies.Services.Interfaces
{
    public interface ITMDbService 
    {
          Task GetAllGenres();
          Task GetUpcomingMoviesByPageAsync(int page);
    }
}
