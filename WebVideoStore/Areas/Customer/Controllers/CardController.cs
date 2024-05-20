namespace WebVideoStore.Areas.Customer.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using WebVideoStore.DataAccess.Repository.IRepository;
    using WebVideoStore.Models.ViewModels;

    [Area("Customer")]
    [Authorize]
    public class CardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShoppingCardViewModels ShoppingCardViewModels{ get; set; }
        public CardController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ShoppingCardViewModels = new()
            {
                ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId, includeProperties: "VideoTape")
            };
            return View(ShoppingCardViewModels);
        }
    }
}
