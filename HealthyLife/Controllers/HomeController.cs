using HealthyLife.Data;
using HealthyLife.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HealthyLife.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {            
            var applicationDbContext = _context.Courses.Include(c => c.Aurhor).Include(c => c.Subject);            
            return View(await applicationDbContext.ToListAsync());
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> TopTwenty()
        {
            var applicationDbContext = _context.Courses.Include(c => c.Aurhor).Include(c => c.Subject).OrderByDescending(c => c.Rating);
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}