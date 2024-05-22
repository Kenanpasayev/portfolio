using Microsoft.AspNetCore.Mvc;
using WebApplication15.DAL;

namespace WebApplication15.Controllers
{

    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Portfolio.ToList());
        }

    }
}