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

        public async Task<IEnumerable<DailyEquipmentLosses>> GetMiniChartData2(int id)
        {
            var data = await _lossesRepository.GetMiniChartDataAsync2(id);
            return data;
        }

        public async Task<KeyValuePair<List<string>, List<int>>> GetMiniChartData(int id)
        {
            var data = await _lossesRepository.GetMiniChartDataAsync(id);
            return data;
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