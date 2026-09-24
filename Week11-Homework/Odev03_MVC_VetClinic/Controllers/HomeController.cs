using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Odev03_MVC_VetClinic.Models;

namespace Odev03_MVC_VetClinic.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var context =  new VetClinicDbContext();
        var vets = context.Vets.ToList();
        return View(vets);
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
