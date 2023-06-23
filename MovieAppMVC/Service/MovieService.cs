using MovieAppMVC.Data;
using MovieAppMVC.Models;
using MovieAppMVC.Helpers;

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
            List<Movie> movies = _context.Movie.Where(m => m.Suggested).ToList();
            for (int i = 0; i < movies.Count; i++)
            {
                if (movies[i].Thumbnail != null)
                {
                    movies[i].ThumbnailFile = ConvertHelper.ConvertToIFormFile(movies[i].Thumbnail, movies[i].Title);
                }
            }

            return movies;

        }

      
    }

}
