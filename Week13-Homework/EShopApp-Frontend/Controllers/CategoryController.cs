using EShopApp.Models.ViewModels.Categories;
using EShopApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace EShopApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<ActionResult> Index(int? categoryId = null)
        {
            var (successC, messageC, categories) = await _categoryService.GetAllCategories();
            var model = new CategoriesIndexViewModel(categories, categoryId);
            return View(model);
        }

        public async Task<ActionResult> Details(int id)
        {
            var (success, error, category, product) = await _categoryService.GetCategoryDetailsAsync(id);
            if (!success)
            {
                TempData["Error"] = error;
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

    }
}