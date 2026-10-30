using EShopApp.Controllers;
using EShopApp.Models.Enums;
using EShopApp.Models.ViewModels.Orders;
using EShopApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EShopApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrderController : AjaxBaseController
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> Index(OrderStatus? status = null)
        {
            var model = await _orderService.GetOrdersForAdminAsync(status);
            return View(model);
        }

        public async Task<IActionResult> Details(int id, string status)
        {
            var (succes, message, order) = await _orderService.GetOrderDetailsForAdminAsync(id);
            if (order == null) return NotFound();

            var CurrentStatus = await _orderService.GetOrdersByStatus(status);

            order.CurrentStatus = status;
            return View(order);
        }



        public async Task<IActionResult> UpdateStatus(int id, OrderStatus status)
        {
            var (success, message) = await _orderService.UpdateStatusAsync(id, status);
            if (!success) return Error(message);
            TempData["Success"] = message;
            return Success(Url.Action(nameof(Details), new { area = "Admin", id })!);
        }
    }
}
