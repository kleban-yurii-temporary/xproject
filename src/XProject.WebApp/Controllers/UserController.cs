using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XProject.Repositories;
using XProject.Repositories.Models;

namespace XProject.WebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserRoleRepository _userRoleRepository;
        public UserController(UserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository; 
        }

        public async Task<IActionResult> Index()
        {
            return View(await _userRoleRepository.GetAllWithRolesAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AppUserCreateModel model)
        {
            if(ModelState.IsValid)
            {                
                var user = await _userRoleRepository.CreateAsync(model);
                return RedirectToAction("Edit", "User", new {id = user.Id});
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            ViewBag.Roles = await _userRoleRepository.GetRolesAsync();
            return View(await _userRoleRepository.GetOneWithRolesAsync(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AppUserViewModel model, string[] roles)
        {
            if (ModelState.IsValid)
            {
                await _userRoleRepository.UpdateAsync(model, roles);
                return RedirectToAction("Index");
            }
            ViewBag.Roles = await _userRoleRepository.GetRolesAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<int> CheckUser(string id)
        {
            return await _userRoleRepository.IsConfirmed(id);
        }

        [HttpDelete]
        public async Task Delete(string id)
        {
            await _userRoleRepository.DeleteAsync(id);
        }
    }
}
