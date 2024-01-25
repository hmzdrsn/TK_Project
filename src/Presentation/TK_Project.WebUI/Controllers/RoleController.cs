using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TK_Project.Application.Interfaces.Repositories.Role;

namespace TK_Project.WebUI.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        readonly IRoleReadRepository _roleReadRepository;
        readonly IRoleWriteRepository _roleWriteRepository;
        public RoleController(IRoleReadRepository roleReadRepository, IRoleWriteRepository roleWriteRepository)
        {
            _roleReadRepository = roleReadRepository;
            _roleWriteRepository = roleWriteRepository;
        }

        public async Task<IActionResult> RoleList()
        {
            var data = await _roleReadRepository.GetAllAsync();
            return View(data);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(Domain.Entities.Role role)
        {
            await _roleWriteRepository.AddAsync(role);
            return RedirectToAction("RoleList", "Role");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRole(int id)
        {
            var data = await _roleReadRepository.GetByIdAsync(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(Domain.Entities.Role role)
        {
            await _roleWriteRepository.UpdateAsync(role);
            return RedirectToAction("RoleList", "Role");
        }

        public async Task<IActionResult> DeleteRole(int id)
        {
            await _roleWriteRepository.DeleteByIDAsync(id);
            return RedirectToAction("RoleList", "Role");
        }
    }
}
