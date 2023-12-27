using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Proje.Models;
using Proje.Models.siniflar;
using System.Diagnostics;

namespace Proje.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly ILogger<HomeController> _logger;

        public HomeController(Context context ,ILogger<HomeController> logger)
        {
            _logger = logger;
           
           

        }
        
     
        public IActionResult Index()
        {
            return View();
        }

       
        public IActionResult About()
        {
           
            return View();
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
