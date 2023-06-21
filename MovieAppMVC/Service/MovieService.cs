using MovieAppMVC.Data;
using MovieAppMVC.Models;

namespace MovieAppMVC.Service
{
    public class MovieService
    {
        private readonly MovieAppMVCContext _context;

        public MovieService(MovieAppMVCContext context)
        {
            _context = context;
        }

        public List<Movie> GetSuggestedMovies()
        {
            return _context.Movie.Where(m => m.Suggested).ToList();
        }
    }

}
