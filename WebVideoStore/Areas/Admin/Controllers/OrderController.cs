namespace WebVideoStore.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
	using Microsoft.AspNetCore.Mvc;
    using Stripe;
    using Stripe.Checkout;
    using WebVideoStore.DataAccess.Repository.IRepository;
	using WebVideoStore.Models;
    using WebVideoStore.Models.ViewModels;
    using WebVideoStoreUtility;

    [Area("Admin")]
	[Authorize(Roles = SD.Role_Admin)]
	
	public class OrderController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public OrderViewModels OrderViewModels { get; set; }
        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
		{
			return View();
		}

        public IActionResult Details(int orderId) { 
            OrderViewModels orderViewModels=new OrderViewModels()
            {
                OrderHeader = _unitOfWork.OrderHeader.Get(u => u.Id == orderId, includeProperties: "ApplicationUser"),
                OrderDetail = _unitOfWork.OrderDetail.GetAll(o => o.OrderHeaderId == orderId, includeProperties: "VideoTape")
            };
            return View(orderViewModels);
        }
        [HttpPost]
        [Authorize(Roles = SD.Role_Admin+","+SD.Role_Employee)]
        public IActionResult UpdateOrderDetail()
        {
           var orderHeaderFromDb = _unitOfWork.OrderHeader.Get(u => u.Id == OrderViewModels.OrderHeader.Id);
            orderHeaderFromDb.Name = OrderViewModels.OrderHeader.Name;
            orderHeaderFromDb.PhoneNumber= OrderViewModels.OrderHeader.PhoneNumber;
            orderHeaderFromDb.StreetAddress = OrderViewModels.OrderHeader.StreetAddress;
            orderHeaderFromDb.City = OrderViewModels.OrderHeader.City;
            orderHeaderFromDb.State = OrderViewModels.OrderHeader.State;
            orderHeaderFromDb.PostalCode = OrderViewModels.OrderHeader.PostalCode;
            if(!string.IsNullOrEmpty(OrderViewModels.OrderHeader.Carrier))
            {
                orderHeaderFromDb.Carrier = OrderViewModels.OrderHeader.Carrier;
            }
            if (!string.IsNullOrEmpty(OrderViewModels.OrderHeader.TrackingNumber))
            {
                orderHeaderFromDb.TrackingNumber = OrderViewModels.OrderHeader.TrackingNumber;
            }
            _unitOfWork.OrderHeader.Update(orderHeaderFromDb);
            _unitOfWork.Save();

            TempData["Success"] = "Order Details Updated Successfully";
            return RedirectToAction(nameof(Details), new {orderId=orderHeaderFromDb.Id});   
        }
        [HttpPost]
        [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Employee)]
        public IActionResult StartProcessing()
        {
           _unitOfWork.OrderHeader.UpdateStatus(OrderViewModels.OrderHeader.Id, SD.StatusInProcess);
            _unitOfWork.Save();
            TempData["Success"] = "Order Processed Successfully";
            return RedirectToAction(nameof(Details), new {orderId=OrderViewModels.OrderHeader.Id});
        }
        [HttpPost]
        [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Employee)]
        public IActionResult ShipOrder()
        {
            var orderHeader=_unitOfWork.OrderHeader.Get(u => u.Id == OrderViewModels.OrderHeader.Id);
            orderHeader.TrackingNumber = OrderViewModels.OrderHeader.TrackingNumber;
            orderHeader.Carrier = OrderViewModels.OrderHeader.Carrier;
            orderHeader.OrderStatus = SD.StatusShipped;
            orderHeader.ShippingDate = DateTime.Now;
            if (orderHeader.PaymentStatus == SD.PaymentStatusDelayedPayment)
            {
                orderHeader.PaymentDueDate = DateTime.Now.AddDays(30);
            }
            _unitOfWork.OrderHeader.UpdateStatus(OrderViewModels.OrderHeader.Id, SD.StatusShipped);
            _unitOfWork.Save();
            TempData["Success"] = "Order Shiped Successfully";
            return RedirectToAction(nameof(Details), new { orderId = OrderViewModels.OrderHeader.Id });
        }
        [HttpPost]
        [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Employee)]
        public IActionResult CancelOrder()
        {
            var orderHeader = _unitOfWork.OrderHeader.Get(u => u.Id == OrderViewModels.OrderHeader.Id);
            if (orderHeader.PaymentStatus == SD.PaymentStatusApproved)
            {
                var options = new RefundCreateOptions
                {

                    Reason = RefundReasons.RequestedByCustomer,
                    PaymentIntent = orderHeader.PaymentIntentId
                };
                var service = new RefundService();
                Refund refund = service.Create(options);
                _unitOfWork.OrderHeader.UpdateStatus(orderHeader.Id, SD.StatusCancelled, SD.StatusRefunded);
            }
            else
            {
                _unitOfWork.OrderHeader.UpdateStatus(orderHeader.Id, SD.StatusCancelled);
            }
            _unitOfWork.Save();
            TempData["Success"] = "Order Cancelled Successfully";
            return RedirectToAction(nameof(Details), new { orderId = OrderViewModels.OrderHeader.Id });
        }
        [HttpPost]
        [ActionName("Details")]
        public IActionResult Details_PAY_NOW()
        {
            OrderViewModels.OrderHeader = _unitOfWork.OrderHeader.Get(u => u.Id == OrderViewModels.OrderHeader.Id, includeProperties: "ApplicationUser");
            OrderViewModels.OrderDetail = _unitOfWork.OrderDetail.GetAll(o => o.OrderHeaderId == OrderViewModels.OrderHeader.Id, includeProperties: "VideoTape");
            var domain = "https://localhost:44300/";
            var options = new Stripe.Checkout.SessionCreateOptions
            {
                SuccessUrl = domain + "admin/order/PaymentConfirmation?orderHeaderId={OrderViewModels.OrderHeader.Id}",
                CancelUrl = domain + $"admin/order/details?orderId={OrderViewModels.OrderHeader.Id}",
                LineItems = new List<Stripe.Checkout.SessionLineItemOptions>(),
                Mode = "payment",
            };
            
            foreach (var item in OrderViewModels.OrderDetail)
            {
                var sessionLineItem = new Stripe.Checkout.SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
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
            Stripe.Checkout.Session session = service.Create(options);
            _unitOfWork.OrderHeader.UpdateStripePaymentId(OrderViewModels.OrderHeader.Id, session.Id, session.PaymentIntentId);
            _unitOfWork.Save();
            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }
        public IActionResult PaymentConfirmation(int orderHeaderId)
        {
            OrderHeader orderHeader = _unitOfWork.OrderHeader.Get(u => u.Id == orderHeaderId);
            if (orderHeader.PaymentStatus == SD.PaymentStatusDelayedPayment)
            {
                //this is an order by customer
                var service = new Stripe.Checkout.SessionService();
                Stripe.Checkout.Session session = service.Get(orderHeader.SessionId);
                if (session.PaymentStatus.ToLower() == "paid")
                {
                    _unitOfWork.OrderHeader.UpdateStripePaymentId(orderHeaderId, session.Id, session.PaymentIntentId);
                    _unitOfWork.OrderHeader.UpdateStatus(orderHeaderId, orderHeader.OrderStatus, SD.PaymentStatusApproved);
                    _unitOfWork.Save();
                }

            }
            
            return View(orderHeaderId);
        }

        #region API CALLS

        [HttpGet]
		public IActionResult GetAll(string status)
		{
            IEnumerable<OrderHeader> objOrderHeaders;

            if(User.IsInRole(SD.Role_Admin) || User.IsInRole(SD.Role_Employee))
            {
                objOrderHeaders = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser").ToList();
            }
            else
            {
                var claimsIdentity = (System.Security.Claims.ClaimsIdentity)User.Identity;
                var userId = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
                objOrderHeaders = _unitOfWork.OrderHeader.GetAll(u => u.ApplicationUserId==userId, includeProperties: "ApplicationUser");
            }


			switch (status)
            {
                case "pending":
                    objOrderHeaders = objOrderHeaders.Where(o => o.PaymentStatus == SD.PaymentStatusDelayedPayment);
                    break;
                case "inprocess":
                    objOrderHeaders = objOrderHeaders.Where(o => o.OrderStatus == SD.StatusInProcess);
                    break;
                case "completed":
                    objOrderHeaders = objOrderHeaders.Where(o => o.OrderStatus == SD.StatusShipped);
                    break;
                case "approved":
                    objOrderHeaders = objOrderHeaders.Where(o => o.OrderStatus == SD.StatusApproved);
                    break;
                default:
                    break;
            }
			return Json(new { data = objOrderHeaders });
		}
		#endregion
	}
}
