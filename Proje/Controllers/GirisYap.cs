using Microsoft.AspNetCore.Mvc;

namespace Proje.Controllers
{
	public class GirisYap : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Login()
		{
			return View();
		}
		public IActionResult Register()
		{
			return View();
		}
	}
}
