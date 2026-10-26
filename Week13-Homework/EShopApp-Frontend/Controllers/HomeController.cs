using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EShopApp.Models;
using EShopApp.Services;

namespace EShopApp.Controllers;

public class HomeController : Controller
{
    private readonly ProductService _productService;

    public HomeController(ProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        var (success, message, products) = await _productService.GetAllProductsAsync();
        return View(products);
    }

}
