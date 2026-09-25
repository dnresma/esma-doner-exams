using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Odev04_MVC_GymMembers.Models;

namespace Odev04_MVC_GymMembers.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var context = new GymMembersDbContext();
        var members = context.Members.ToList();
        return View(members);
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
