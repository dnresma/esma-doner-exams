using EShopApp.Models.ViewModels.Products;
using EShopApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace EShopApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        private readonly CategoryService _categoryService;

        public ProductController(ProductService productService, CategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<ActionResult> Index(int? categoryId = null)
        {
            var (successProducts, errorProducts, products) = await _productService.GetAllProductsAsync(categoryId);
            var (successCategories, errorCategories, categories) = await _categoryService.GetAllCategories();
            var model = new ProductsIndexViewModel(products, categories, categoryId);
            return View(model);
        }

        public async Task<ActionResult> Details(int id)
        {
            var (success, error, product) = await _productService.GetProductDetailsAsync(id);
            if (!success)
            {
                TempData["Error"] = error;
                return RedirectToAction(nameof(Index));
            }
            return View(product);

        }

    }
}
