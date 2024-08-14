using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesServices _service;
        public MoviesController(IMoviesServices service)
        {
            _service = service; 
        }
        public async Task<IActionResult> Index()
        {
            var data= await _service.GetAllAsync(c=>c.Cinema);
            return View(data);
        }
        public async Task<IActionResult> Filter(string searchString)
        {
            var data = await _service.GetAllAsync(c => c.Cinema);
            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResultNew = data.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }
            return View(data);
        }
    }
}
