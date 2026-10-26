using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace EShopApp.Controllers
{
    public class AjaxBaseController : Controller
    {
        protected string CurrentUserId => User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        protected IActionResult ValidationErrors()
        {
            var errors = ModelState
                .Where(e => e.Value!.Errors.Count > 0)
                .ToDictionary(e => e.Key, e => e.Value!.Errors.Select(m => m.ErrorMessage).ToArray());
            return BadRequest(new { success = false, errors });
        }

        protected IActionResult Error(string message, string key = "")
        {
            return BadRequest(new
            {
                success = false,
                errors = new Dictionary<string, string[]> { [key] = [message] }
            });
        }

        protected IActionResult Success(string redirectUrl)
        {
            return Json(new { success = true, redirectUrl });
        }
    }
}
