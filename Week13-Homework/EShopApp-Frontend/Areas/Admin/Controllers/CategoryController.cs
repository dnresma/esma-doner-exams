using EShopApp.Models.ViewModels.Categories;
using EShopApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EShopApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var (success, message, categories) = await _categoryService.GetAllCategories();
            if (!success) TempData["Error"] = message;

            var model = new CategoriesIndexViewModel(categories ?? [], null);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new AdminCreateCategoryViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdminCreateCategoryViewModel model)
        {
            if (!ModelState.IsValid)
                return ValidationErrors();

            var (success, message) = await _categoryService.CreateCategoryAsync(model);

            if (!success)
                return Error(message);

            return Json(new {
                success = true,
                message,
                redirectUrl = Url.Action(nameof(Index), "Category", new { area = "Admin" })
            });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _categoryService.GetCategoryForUpdateAsync(id);
            if (model is null) return NotFound();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AdminUpdateCategoryViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { success = false, errors = ToErrors(ModelState) });

            var result = await _categoryService.UpdateCategoryAsync(model);
            if (!result.Success)
                return BadRequest(new { success = false, message = result.Message });

            return Json(new { success = true, redirectUrl = Url.Action("Index", "Category", new { area = "Admin" }) });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _categoryService.GetCategoryForDeleteAsync(id);
            if (model is null) return NotFound();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, AdminDeleteCategoryViewModel _)
        {
            var result = await _categoryService.DeleteCategoryAsync(id);
            if (!result.Success)
                return BadRequest(new { success = false, message = result.Message });

            return Json(new { success = true, redirectUrl = Url.Action("Index", "Category", new { area = "Admin" }) });
        }

private static Dictionary<string, string[]> ToErrors(ModelStateDictionary modelState) =>
    modelState
        .Where(e => e.Value!.Errors.Count > 0)
        .ToDictionary(e => e.Key, e => e.Value!.Errors.Select(x => x.ErrorMessage).ToArray());


        private IActionResult ValidationErrors()
        {
            var errors = ModelState
                .Where(e => e.Value!.Errors.Count > 0)
                .ToDictionary(e => e.Key, e => e.Value!.Errors.Select(m => m.ErrorMessage).ToArray());
            return BadRequest(new { success = false, errors });
        }

        private IActionResult Error(string message, string key = "")
        {
            return BadRequest(new
            {
                success = false,
                errors = new Dictionary<string, string[]> { [key] = [message] }
            });
        }
    }
}