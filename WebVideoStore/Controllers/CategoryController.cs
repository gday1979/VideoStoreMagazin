namespace WebVideoStore.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using WebVideoStore.Data;

    public class CategoryController : Controller
    {
        public CategoryController()
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
