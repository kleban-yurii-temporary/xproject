using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using XProject.Repositories;
using XProject.WebApp.Models;

namespace XProject.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LossesRepository _lossesRepository;

        public HomeController(ILogger<HomeController> logger, LossesRepository lossesRepository)
        {
            _logger = logger;
            _lossesRepository = lossesRepository;

        }

        public async Task<IActionResult> Index(string date = "")
        {
            return View(await _lossesRepository.GetAsync(DateTime.Now));
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
}