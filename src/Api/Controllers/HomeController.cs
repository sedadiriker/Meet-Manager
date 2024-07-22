using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Meet_Manager.Models;
using Microsoft.AspNetCore.Authorization;

namespace Meet_Manager.src.Api.Controllers
{
    [Authorize] 
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("/anasayfa")]
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

        [AllowAnonymous] 
        [Route("/")]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous] 
        [Route("/register")]
        public IActionResult Register()
        {
            return View();
        }

        [Route("/toplantı_raporları")]
        public IActionResult Toplantı_Raporları()
        {
            return View();
        }

        [Route("/tablolar")]
        public IActionResult Tablolar()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
