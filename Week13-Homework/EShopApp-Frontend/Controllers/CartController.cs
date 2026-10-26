using System.Security.Claims;
using EShopApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EShopApp.Controllers
{
    [Authorize]
    public class CartController : AjaxBaseController
    {
        private readonly CartService _cartService;

        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<IActionResult> Index()
        {
            var cart = await _cartService.GetCartAsync(CurrentUserId);
            return View(cart);
        }

        public async Task<IActionResult> Count()
        {
            var count = await _cartService.GetItemCountAsync(CurrentUserId);
            return Json(new { count }); // count= count
        }

        public async Task<IActionResult> Add(int productId, int quantity = 1)
        {
            var (success, message, count) = await _cartService.AddToCartAsync(CurrentUserId, productId, quantity);
            if (!success) return Error(message);
            return Json(new { success = true, message, count });
        }

        [HttpPost]
        public async Task<IActionResult> Update(int productId, int quantity)
        {
            var (success, message) = await _cartService.UpdateQuantityAsnyc(CurrentUserId, productId, quantity);
            if (!success) return Error(message);
            return Success(Url.Action(nameof(Index))!);
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int productId)
        {
            var (success, message) = await _cartService.RemoveAsync(CurrentUserId, productId);
            if (!success) return Error(message);
            return Success(Url.Action(nameof(Index))!);
        }

    }
}
