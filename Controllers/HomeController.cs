using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Meet_Manager.Models;

namespace Meet_Manager.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    [Route("/toplantı_listesi")]
    public IActionResult Toplantı_Listesi()
    {
        return View();
    }
    [Route("/toplantı_ekle")]
    public IActionResult Toplantı_Ekle()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
