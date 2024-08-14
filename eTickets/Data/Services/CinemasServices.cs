using eTickets.Data.Base;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class CinemasServices : EntityBaseRepository<Cinema>, ICinemasService
    {
        public CinemasServices(AppDbContext context) : base(context) { }
        
    }
}
