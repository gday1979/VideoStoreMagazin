﻿namespace WebVideoStore.Areas.Customer.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using Stripe.BillingPortal;
	using Stripe.Checkout;
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
		[BindProperty]
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

    ShoppingCardViewModels.OrderHeader.ApplicationUser = _unitOfWork.ApplicationUser.Get(u => u.Id == userId);
    ShoppingCardViewModels.OrderHeader.Name = ShoppingCardViewModels.OrderHeader.ApplicationUser.PhoneNumber;
    foreach (var cart in ShoppingCardViewModels.ShoppingCartList)
    {
        cart.Price = GetPriceBasedOnQuantity(cart);
        ShoppingCardViewModels.OrderHeader.OrderTotal += (cart.Price * cart.Count);
    }

    return View(ShoppingCardViewModels); // Corrected here
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
			var cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.Id == cartId, tracked :true);
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
        public IActionResult Remove(int cartId)
        {
            var cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.Id == cartId,tracked:true);

            HttpContext.Session.SetInt32(SD.SessionCart, _unitOfWork.ShoppingCart
                .GetAll(u => u.ApplicationUserId == cartFromDb.ApplicationUserId).Count() - 1);
            _unitOfWork.ShoppingCart.Remove(cartFromDb);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Summary()
        {

			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

			ShoppingCardViewModels = new()
			{
				ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId, includeProperties: "VideoTape"),
				OrderHeader = new()
			};
			ShoppingCardViewModels.OrderHeader.ApplicationUser = _unitOfWork.ApplicationUser.Get(u => u.Id == userId);
            ShoppingCardViewModels.OrderHeader.PhoneNumber = ShoppingCardViewModels.
                OrderHeader.ApplicationUser.PhoneNumber;
            ShoppingCardViewModels.OrderHeader.StreetAddress = ShoppingCardViewModels.OrderHeader.ApplicationUser.StreetAddress;
            ShoppingCardViewModels.OrderHeader.City = ShoppingCardViewModels.OrderHeader.ApplicationUser.StreetAddress;
            ShoppingCardViewModels.OrderHeader.State = ShoppingCardViewModels.OrderHeader.ApplicationUser.State;
            ShoppingCardViewModels.OrderHeader.PostalCode = ShoppingCardViewModels.OrderHeader.ApplicationUser.PostalCode;
			foreach(var cart in ShoppingCardViewModels.ShoppingCartList)
			{
				cart.Price = GetPriceBasedOnQuantity(cart);
				ShoppingCardViewModels.OrderHeader.OrderTotal += (cart.Price * cart.Count);
			}
			return View(ShoppingCardViewModels);
		}
        [HttpPost]
        [ActionName("Summary")]
        public IActionResult SummaryPOST()
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;


            ShoppingCardViewModels.ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId, includeProperties: "VideoTape");

            ShoppingCardViewModels.OrderHeader.OrderDate = DateTime.Now;

           ApplicationUser applicationUser = _unitOfWork.ApplicationUser.Get(u => u.Id == userId);

            foreach (var cart in ShoppingCardViewModels.ShoppingCartList)
            {
                cart.Price = GetPriceBasedOnQuantity(cart);
                ShoppingCardViewModels.OrderHeader.OrderTotal += (cart.Price * cart.Count);
            }
            if (applicationUser.CompanyId.GetValueOrDefault() == 0)
            {
                ShoppingCardViewModels.OrderHeader.PaymentStatus = SD.PaymentStatusPending;
                ShoppingCardViewModels.OrderHeader.OrderStatus = SD.StatusPending;
            }
            else
            {
                ShoppingCardViewModels.OrderHeader.PaymentStatus = SD.PaymentStatusDelayedPayment;
                ShoppingCardViewModels.OrderHeader.OrderStatus = SD.StatusApproved;
            }
            _unitOfWork.OrderHeader.Add(ShoppingCardViewModels.OrderHeader);
            _unitOfWork.Save();
            foreach (var cart in ShoppingCardViewModels.ShoppingCartList)
            {
                OrderDetail orderDetail = new()
                {
                    VideoTapeId = cart.VideoTapeId,
                    OrderHeaderId = ShoppingCardViewModels.OrderHeader.Id,
                    Price = cart.Price,
                    Count = cart.Count,

                };
                _unitOfWork.OrderDetail.Add(orderDetail);
                _unitOfWork.Save();
            }
            if (applicationUser.CompanyId.GetValueOrDefault() == 0)
            {
                var domain= "https://localhost:44300/";
				var options = new Stripe.Checkout.SessionCreateOptions
				{
					SuccessUrl = domain+"customer/cart/OrderConfirmation?id={VideoTapeViewModels.OrderHeader.Id}",
                    CancelUrl = domain+"customer/cart/index",
					LineItems = new      List<Stripe.Checkout.SessionLineItemOptions>(),
					Mode = "payment",
			};
                foreach (var item in ShoppingCardViewModels.ShoppingCartList)
				{
					var sessionLineItem = new Stripe.Checkout.SessionLineItemOptions 
					{
						PriceData= new SessionLineItemPriceDataOptions { 
                            UnitAmount = (long)item.Price * 100,
                            Currency = "usd",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
							{
								Name = item.VideoTape.Title,
								
							}
                        },
                        Quantity = item.Count,
					};
                    options.LineItems.Add(sessionLineItem);
				}
				var service = new Stripe.Checkout.SessionService();
				Stripe.Checkout.Session session =service.Create(options);
                _unitOfWork.OrderHeader.UpdateStripePaymentId(ShoppingCardViewModels.OrderHeader.Id, session.Id,session.PaymentIntentId );
                _unitOfWork.Save();
                Response.Headers.Add("Location", session.Url);
			}
            return RedirectToAction(nameof(OrderConfirmation), new {id=ShoppingCardViewModels.OrderHeader.Id});

        }
        public IActionResult OrderConfirmation(int id)
		{
            OrderHeader orderHeader = _unitOfWork.OrderHeader.Get(u => u.Id == id,includeProperties:"ApplicationUser");
            if(orderHeader.PaymentStatus != SD.PaymentStatusDelayedPayment)
            {
                //this is an order by customer
                var service = new Stripe.Checkout.SessionService();
               Stripe.Checkout.Session session= service.Get(orderHeader.SessionId);
                if(session.PaymentStatus.ToLower()== "paid")
				{
				   _unitOfWork.OrderHeader.UpdateStripePaymentId(id, session.Id, session.PaymentIntentId);
                    _unitOfWork.OrderHeader.UpdateStatus(id, SD.StatusApproved, SD.PaymentStatusApproved);
                    _unitOfWork.Save();
				}
				
            }
			List<ShoppingCart> shoppingCarts = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == orderHeader.ApplicationUserId).ToList();
            _unitOfWork.ShoppingCart.RemoveRange(shoppingCarts);
            _unitOfWork.Save();
            return View(id);
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
