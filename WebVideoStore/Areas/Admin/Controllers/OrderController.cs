namespace WebVideoStore.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	public class OrderController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
