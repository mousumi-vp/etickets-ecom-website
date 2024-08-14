using eTickets.Data.Base;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class ProducersServices : EntityBaseRepository<Producer>, IProducersServices
    {
        public ProducersServices(AppDbContext context) : base(context) { }
        
    }
}
