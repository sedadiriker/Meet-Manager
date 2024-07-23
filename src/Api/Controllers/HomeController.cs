using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Meet_Manager.Models;

namespace Meet_Manager.src.Api.Controllers
{
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
            // Token kontrolü kaldırıldı
            return View();
        }

        [Route("/toplantı_listesi")]
        public IActionResult Toplantı_Listesi()
        {
            // Token kontrolü kaldırıldı
            return View();
        }

        [Route("/toplantı_ekle")]
        public IActionResult Toplantı_Ekle()
        {
            // Token kontrolü kaldırıldı
            return View();
        }

        [Route("/")]
        public IActionResult Login()
        {
            // Token kontrolü kaldırıldı
            return View();
        }

        [Route("/register")]
        public IActionResult Register()
        {
            // Token kontrolü kaldırıldı
            return View();
        }

        [Route("/toplantı_raporları")]
        public IActionResult Toplantı_Raporları()
        {
            // Token kontrolü kaldırıldı
            return View();
        }

        [Route("/tablolar")]
        public IActionResult Tablolar()
        {
            // Token kontrolü kaldırıldı
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
