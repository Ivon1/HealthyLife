using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authorization;
using HealthyLife.Models;
using HealthyLife.Data;
using HealthyLife.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace HealthyLife.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        RoleManager<IdentityRole> _roleManager;
        UserManager<ApplicationUser> _userManager;
        ApplicationDbContext _db;

        public RolesController(RoleManager<IdentityRole> roleManager, 
            UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
        }

        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            ViewBag.Roles = roles;
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            IdentityRole role = new IdentityRole();
            role.Name = name;
            var isExists = await _roleManager.RoleExistsAsync(role.Name);

            if(isExists) 
            {
                ViewBag.mess = "Така роль вже існує!";
                ViewBag.name = name;
                return View();
            }

            var result = await _roleManager.CreateAsync(role);
            if(result.Succeeded)
            {
                TempData["save"] = "Роль успішно була добавлена!";
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public IActionResult Assign()
        {
            ViewData["UserId"] = new SelectList(_db.ApplicationUsers
                .Where(u => u.LockoutEnd < DateTime.Now || u.LockoutEnd == null)
                .ToList(), "Id" , "UserName");

            ViewData["RoleId"] = new SelectList(_roleManager.Roles.ToList(), "Name", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Assign(RoleUserVm roleUser)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(u => u.Id == roleUser.UserId); 
            var isCheckRoleAssign = await _userManager.IsInRoleAsync(user, roleUser.RoleId);

            if(isCheckRoleAssign)
            {
                ViewBag.mess = "Користувач уже має цю роль";
                ViewData["UserId"] = new SelectList(_db.ApplicationUsers
                    .Where(u => u.LockoutEnd < DateTime.Now || u.LockoutEnd == null)
                    .ToList(), "Id", "UserName");
                ViewData["RoleId"] = new SelectList(_roleManager.Roles.ToList(), "Name", "Name");
                return View();
            }

            var role = await _userManager.AddToRoleAsync(user, roleUser.RoleId); // БАГ !!!
            // (ПРИ ДОБАВЛЕНИИ РОЛИ К ЮЗЕРУ , У ЮЗЕРА ОСТАЕТЬСЯ СТАРАЯ РОЛЬ)


            if (role.Succeeded)
            {
                //foreach(var r in _db.UserRoles.ToList())
                //{
                //    if(r.UserId == roleUser.UserId)
                //    {
                //        if(roleUser.RoleId != r.RoleId)
                //        {
                //            _db.UserRoles.Remove(r);
                //        }
                        
                //    }
                //}
                //_db.SaveChangesAsync();
                return RedirectToAction(nameof(AssignUserRole));
            }
            return View();
        }

        public IActionResult AssignUserRole()
        {
            var result = from ur in _db.UserRoles
                         join r in _db.Roles on ur.RoleId equals r.Id
                         join u in _db.ApplicationUsers on ur.UserId equals u.Id
                         select new UserRoleMapping()
                         {
                             UserId = ur.UserId,
                             RoleId = ur.RoleId,
                             UserName = u.UserName,
                             RoleName = r.Name
                         };
            ViewBag.UserRoles = result;
            return View();
        }
    }
}
