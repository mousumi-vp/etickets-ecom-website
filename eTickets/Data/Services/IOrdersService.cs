
using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IOrdersService
    {
        Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string? userId, string? userRole);
    }
}
