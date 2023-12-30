using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Proje.Models;
using Proje.Models.siniflar;
using Proje.ViewModel;
using System.Diagnostics;

namespace Proje.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        private readonly Context _context;



        public HomeController(Context context, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            List<Seferler> seferlist = _context.Seferlers.ToList();


            IEnumerable<ViewSeferEkle> seferwiew = seferlist.Select(sefer => new ViewSeferEkle
            {

                SeferId = sefer.SeferlerId,
                güzergah=sefer.güzergah,
                Gün = sefer.Gün,
                Saat = sefer.Saat,
                Fiyat = sefer.Fiyat,
                Image = sefer.Image,
                Kapasite = sefer.Kapasite,

            });

            return View(seferwiew);

            return View();
        }
        public IActionResult SeferAra(string güzergah,DateTime date) 
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
