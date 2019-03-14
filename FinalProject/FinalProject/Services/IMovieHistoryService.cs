using FinalProject.Models.GenreSelection;
using FinalProject.Models.MoviePopularity;

namespace FinalProject.Service
{
    public interface IMovieHistoryService
    {
        MoviePopularityViewModel GetPopularMovies();
        GenreViewModel GetGenre();
        GenreSelectorViewModel GetByGenre(int id);
    }
}