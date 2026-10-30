using EShopApp.Models.Enums;
using EShopApp.Models.ViewModels.Orders;
using EShopApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace EShopApp.Controllers
{
    public class OrderController : AjaxBaseController
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> Index(OrderStatus? orderStatus = null)
        {
            var orders = await _orderService.GetUserOrdersAsync(CurrentUserId, orderStatus);
            var orderStatuses = Enum.GetValues<OrderStatus>().ToList();
            var model = new OrdersIndexViewModel(orders, orderStatuses, orderStatus);
            return View(model);
        }

        public async Task<IActionResult> Checkout()
        {
            var (success, message, checkout) = await _orderService.GetCheckoutAsync(CurrentUserId);
            if (!success)
            {
                TempData["Error"] = message;
                return RedirectToAction("Index", "Cart");
            }
            return View(checkout);
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(CreateOrderViewModel model)
        {
            if (!ModelState.IsValid) return ValidationErrors();
            var (success, message, orderId) = await _orderService.PlaceOrderAsync(CurrentUserId, model);
            if (!success) return Error(message);
            TempData["Success"] = message;
            return Success(Url.Action(nameof(Details), new { id = orderId })!);
        }

        public async Task<IActionResult> Details(int id)
        {
            var (success, message, order) = await _orderService.GetUserOrderDetailsAsync(CurrentUserId, id);
            if (!success)
            {
                TempData["Error"] = message;
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> Cancel(int id)
        {
            var (success, message) = await _orderService.CancelUserOrderAsync(CurrentUserId, id);
            if (!success) Error(message);
            TempData["Success"] = message;
            return Success(Url.Action(nameof(Details), new { id })!);
        }
    }
}
