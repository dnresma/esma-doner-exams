using EShopApp.Models.ViewModels.Products;
using EShopApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace EShopApp.Areas.Admin.Controllers
{
    [Area("Admin")]
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
            var (successP, messageP, products) = await _productService.GetAllProductsForAdminAsync(categoryId);
            var (successC, messageC, categories) = await _categoryService.GetAllCategories();
            var model = new AdminProductsIndexViewModel(products, categories, categoryId);
            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            var (success, error, categories) = await _categoryService.GetAllCategories();
            return View(new AdminCreateProductViewModel { Categories = categories });
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdminCreateProductViewModel model, IFormFile imageFile)
        {
            if (!ModelState.IsValid) ValidationErrors();

            if(imageFile is null) return Error("Lütfen bir resim seçin.","imageFile");

            var (success, message, productId) = await _productService.CreateProductAsync(model, imageFile);
            if (!success) Error(message ?? "Ürün oluşturulamadı.", imageFile is not null ? "imageFile" : string.Empty);

            TempData["Success"] = message;
            return Json(new { success = true, redirectUrl = Url.Action(nameof(Index), new { area = "Admin" }) });

        }

        public async Task<ActionResult> Edit(int id)
        {
            var (success, message, product) = await _productService.GetProductForEditAsync(id);
            if (!success)
            {
                TempData["Error"] = message;
                return RedirectToAction(nameof(Index));
            }
            var (successC, messageC, categories) = await _categoryService.GetAllCategories();
            product!.Categories = categories;
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AdminUpdateProductViewModel model, IFormFile? imageFile)
        {
            if(!ModelState.IsValid) return ValidationErrors();

            var (success, message) = await _productService.UpdateProductAsync(model, imageFile);
            if(!success) return Error(message, imageFile is not null ? "imageFile": string.Empty);

            TempData["Success"] = message;
            return Json(new {success=true, redirectUrl = Url.Action(nameof(Index), new { area="Admin"})});
        }
    
        public async Task<IActionResult> Delete(int id)
        {
            var (success, message, product) = await _productService.GetProductForDeleteAsync(id);
            if (!success)
            {
                TempData["Error"] = message;
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var (success, message) = await _productService.DeleteProductAsync(id);
            if(!success) return Error(message);
            TempData["Success"]=message;
            return Json(new {success=true, redirectUrl = Url.Action(nameof(Index),new {area="Admin"})});
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
