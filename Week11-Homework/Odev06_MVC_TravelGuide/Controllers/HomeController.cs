using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Odev06_MVC_TravelGuide.Models;

namespace Odev06_MVC_TravelGuide.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var context = new TravelGuideDbContext();
        var places = context.Places.ToList();
        return View(places);
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
