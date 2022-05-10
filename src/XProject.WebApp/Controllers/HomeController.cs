using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using XProject.Core;
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

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IEnumerable<DailyEquipmentLosses>> GetData()
        {
            return await _lossesRepository.GetDataAsync();
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