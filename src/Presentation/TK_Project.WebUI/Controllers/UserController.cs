using Microsoft.AspNetCore.Mvc;
using TK_Project.Application.Interfaces.Repositories.Role;
using TK_Project.Application.Interfaces.Repositories.User;
using TK_Project.Domain.Entities;
using TK_Project.WebUI.Models;

namespace TK_Project.WebUI.Controllers
{
    public class UserController : Controller
    {
        readonly IUserReadRepository _userReadRepository;
        readonly IUserWriteRepository _userWriteRepository;
        readonly IRoleReadRepository _roleReadRepository;
        readonly IRoleWriteRepository _roleWriteRepository;
        public UserController(IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository, IRoleReadRepository roleReadRepository, IRoleWriteRepository roleWriteRepository)
        {
            _userReadRepository = userReadRepository;
            _userWriteRepository = userWriteRepository;
            _roleReadRepository = roleReadRepository;
            _roleWriteRepository = roleWriteRepository;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _userReadRepository.GetAllAsync();
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateUser(int id)
        {
            var data = await _userReadRepository.GetByIdAsync(id);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUser(User user)
        {
            await _userWriteRepository.UpdateAsync(user);
            return RedirectToAction("Index","User");
        }
        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var roleList = await _roleReadRepository.GetAllAsync();
            var userData = await _roleReadRepository.GetUserRoles(id);
            List<string> ownedRoles= new List<string>();

            if (userData != null)
            {
                ownedRoles = userData.Roles.Select(x => x.Name).ToList();
                TempData["userId"] = userData.Id;
            }
                             
            List<UserRoleVM> roles = new List<UserRoleVM>();
            foreach (var role in roleList)
            {
                UserRoleVM roleVM = new UserRoleVM()
                {
                    RoleID = role.Id,
                    RoleName = role.Name,
                    RoleExist = ownedRoles.Contains(role.Name),
                };
                roles.Add(roleVM);
            }
            
            return View(roles);
        }
        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole(List<UserRoleVM> model, int id)
        {
            var userID = id;
            List<int> roles = new List<int>();
            foreach (var item in model) 
            {
                if (item.RoleExist == true) 
                { 
                    roles.Add(item.RoleID);
                }
            }
            
            await _roleWriteRepository.AssignRole(userID, roles);
            return RedirectToAction("Index","User");
        }


        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userWriteRepository.DeleteByIDAsync(id);
            return RedirectToAction("Index", "User");
        }
    }
}
