using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using XProject.Repositories;

namespace XProject.WebApp.Controllers
{
    public class EqController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly EqRepository _eqRepository;

        public EqController(IWebHostEnvironment webHostEnvironment, 
            EqRepository eqRepository)
        {
            _webHostEnvironment = webHostEnvironment;
            _eqRepository = eqRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<FileResult> Image(int id)
        {
            var mimeType = "image/png";

            var eq = await _eqRepository.GetByIdAsync(id);

            var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, eq.IconPath);

            if(!System.IO.File.Exists(filePath))
            {
                filePath = Path.Combine(_webHostEnvironment.ContentRootPath, @"Images\eq\no-photo.png");
            }

            new FileExtensionContentTypeProvider().TryGetContentType(filePath, out mimeType);
            return PhysicalFile(filePath, mimeType);
        }
    }
}
