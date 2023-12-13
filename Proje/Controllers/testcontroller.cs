using Microsoft.AspNetCore.Mvc;

namespace Proje.Controllers
{
    public class testcontroller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
