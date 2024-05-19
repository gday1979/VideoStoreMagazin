namespace WebVideoStore.Areas.Customer.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.CodeAnalysis;
    using System.Diagnostics;
    using WebVideoStore.DataAccess.Repository.IRepository;
    using WebVideoStore.Models;

    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<VideoTape> videoTapeList = _unitOfWork.VideoTape.GetAll(includeProperties: "Category");
            return View(videoTapeList);
        }

        public IActionResult Details(int videotapeId)
        {
            ShoppingCart cart = new()
            {
                VideoTape = _unitOfWork.VideoTape.Get(u => u.Id == videotapeId, includeProperties: "Category"),
                Count = 1,
                VideoTapeId = videotapeId
            };
            return View(cart);
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
