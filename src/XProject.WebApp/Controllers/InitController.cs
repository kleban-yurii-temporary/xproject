using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XProject.Repositories;

namespace XProject.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHost;
        private readonly DataInitRepository _dataInit;
        
        public InitController(
            IWebHostEnvironment webHost,
            DataInitRepository dataInit)
        {
            _webHost = webHost;
            _dataInit = dataInit;
        }

        [HttpGet]
        [Route("/api/[controller]/start")]
        public IActionResult Test()
        {
            var path = Path.Combine(_webHost.WebRootPath, "data\\russia_losses_equipment.csv");
            return Ok(_dataInit.ParseDataFile(path));
        }
    }
}
