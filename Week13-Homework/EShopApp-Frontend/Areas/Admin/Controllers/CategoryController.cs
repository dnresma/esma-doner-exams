using EShopApp.Models.ViewModels.Categories;
using EShopApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace EShopApp.Areas.Admin.Controllers
{
    [Area("Admin")]
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

        public IActionResult Create()
        {
            return View(new AdminCreateCategoryViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdminCreateCategoryViewModel model)
        {
            if (!ModelState.IsValid) return ValidationErrors();

            var (success, message) = await _categoryService.CreateCategoryAsync(model);
            if (!success) return Error(message ?? "Kategori oluşturulamadı.");

            TempData["Success"] = message;
            return Json(new { success = true, redirectUrl = Url.Action(nameof(Index), new { area = "Admin" }) });
        }

        

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