using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Odev05_MVC_CafeMenu.Models;

namespace Odev05_MVC_CafeMenu.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var context = new CafeMenuDbContext();
        var menuitems = context.MenuItems.ToList();
        return View(menuitems);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
