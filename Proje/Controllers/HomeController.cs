using Microsoft.AspNetCore.Mvc;
using Proje.Models;
using Proje.Models.siniflar;
using System.Diagnostics;

namespace Proje.Controllers
{
    public class HomeController : Controller
    {
        private Context _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _context.Hakkimizdas.ToList();

        }

        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult About(Hakkimizda model)
        {
          
            return View(model);
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Yardım()
        {
            return View();
        }
        public IActionResult Seferler()
        {
            return View();
        }
        public IActionResult Blog()
        {
            return View();
        }


        public IActionResult Privacy()
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
