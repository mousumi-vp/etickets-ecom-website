using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _context;
        public ActorsController(IActorsService context)
        {
            _context = context; 
        }
        public async Task<IActionResult> Index()
        {
            var data=await _context.GetAll();
            return View(data);
        }
    }
}
