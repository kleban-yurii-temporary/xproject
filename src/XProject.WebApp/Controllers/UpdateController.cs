using Microsoft.AspNetCore.Mvc;
using XProject.Repositories;

namespace XProject.WebApp.Controllers
{
    public class UpdateController : Controller
    {
        private readonly UpdateRepository _updateRepository;

        public UpdateController(UpdateRepository updateRepository)
        {
            _updateRepository = updateRepository;   
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IEnumerable<string>> Run()
        {
            return await _updateRepository.UpdateAsync();
        }
    }
}
