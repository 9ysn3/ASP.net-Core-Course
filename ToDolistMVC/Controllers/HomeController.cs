using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDolistMVC.Models;

namespace ToDolistMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public IActionResult SetTheme(string theme)
    {
        HttpContext.Session.SetString("Theme", theme);
        return Ok();
    }

    public IActionResult Index()
    {
        var theme = HttpContext.Session.GetString("Theme") ?? "Light";
        ViewBag.Theme = theme;
        return View();
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
