using Microsoft.AspNetCore.Mvc;

namespace TestCRUD.Controllers
{
	public class MapController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
