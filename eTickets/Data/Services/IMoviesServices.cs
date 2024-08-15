using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IMoviesServices : IEntityBaseRepository<Movie>
    {
        Task AddNewMovieAsync(NewMovieVM movie);
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues();
        Task UpdateMovieAsync(NewMovieVM data);
    }
}
