using EShopApp.Models.ViewModels.Account;
using EShopApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace EShopApp.Controllers
{
    public class AccountController : AjaxBaseController
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            if (User.Identity?.IsAuthenticated == true) return RedirectToAction("Index", "Home");
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) ValidationErrors();
            var (success, message, isAdmin) = await _accountService.LoginAsync(model);
            if (!success) return Error(message);
            if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
            {
                return Success(model.ReturnUrl);
            }

            return Success(
                isAdmin
                ? Url.Action("Index", "Home", new { area = "Admin" })!
                : Url.Action("Index", "Home", new { area = "" })!);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _accountService.LogoutAsync();
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public IActionResult AccessDenied()
        {
            return View();
        }




    }
}
