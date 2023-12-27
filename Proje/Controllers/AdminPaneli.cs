using Microsoft.AspNetCore.Mvc;

namespace Proje.Controllers
{
	public class AdminPaneli : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
