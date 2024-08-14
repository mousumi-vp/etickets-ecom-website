using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public class MoviesServices: EntityBaseRepository<Movie>, IMoviesServices
    {
        public MoviesServices(AppDbContext context) : base(context) { }
    }
}
