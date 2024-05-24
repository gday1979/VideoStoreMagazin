namespace WebVideoStore.Areas.Customer.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using WebVideoStore.DataAccess.Repository.IRepository;
    using WebVideoStore.Models;
    using WebVideoStore.Models.ViewModels;
	using WebVideoStoreUtility;

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
				ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId, includeProperties: "VideoTape"),
				OrderHeader = new ()
			};
			foreach (var cart in ShoppingCardViewModels.ShoppingCartList)
			{
				cart.PriceBuy = GetPriceBasedOnQuantity(cart);
				
				ShoppingCardViewModels.OrderHeader.OrderTotal += (cart.PriceBuy * cart.Count);
			}

			return View(ShoppingCardViewModels);
		}
        public IActionResult Plus(int cartId)
        {
			var cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.Id == cartId, includeProperties: "VideoTape");
			cartFromDb.Count += 1;
			_unitOfWork.ShoppingCart.Update(cartFromDb);
			_unitOfWork.Save();
			return RedirectToAction(nameof(Index));
		}
        public IActionResult Minus(int cartId)
        {
			var cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.Id == cartId);
			if (cartFromDb.Count <= 1)
			{
				//remove that from cart

				_unitOfWork.ShoppingCart.Remove(cartFromDb);
				HttpContext.Session.SetInt32(SD.SessionCart, _unitOfWork.ShoppingCart
					.GetAll(u => u.ApplicationUserId == cartFromDb.ApplicationUserId).Count() - 1);
			}
			else
			{
				cartFromDb.Count -= 1;
				_unitOfWork.ShoppingCart.Update(cartFromDb);
			}

			_unitOfWork.Save();
			return RedirectToAction(nameof(Index)); 

		}
        public IActionResult Summary()
        {
			
			return View();
		}
        private double GetPriceBasedOnQuantity(ShoppingCart shoppingCart)
        {
            if (shoppingCart.Count <= 1)
            {
                return shoppingCart.VideoTape.PriceBuy;
            }
            else
            {
                if (shoppingCart.Count <= 10)
                {
                    return shoppingCart.VideoTape.PriceBuy;
                }
                else
                {
                    return shoppingCart.VideoTape.PriceBuy;
                }
            }
        }
    }
}
