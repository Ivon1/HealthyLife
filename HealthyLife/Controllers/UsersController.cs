using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HealthyLife.Models;
using HealthyLife.Data;

namespace HealthyLife.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        UserManager<ApplicationUser> _userManager;
        ApplicationDbContext _db;

        public UsersController (UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public IActionResult Index() 
        {
            var users = _db.ApplicationUsers.ToList();
            return View(users); 
        }

        public IActionResult Create() { return View(); }

        [HttpPost]
        public async Task<IActionResult> Create(ApplicationUser user)
        {
            user.CreationTime = DateTime.Now;
            if(ModelState.IsValid)
            {
                var result = await _userManager.CreateAsync(user, user.PasswordHash);
                if(result.Succeeded)
                {
                    var isSaveRole = await _userManager.AddToRoleAsync(user, "User");
                    return RedirectToAction(nameof(Index));
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View();
        }


        //Edit
        public IActionResult Edit(string id) 
        { 
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ApplicationUser user) 
        {
            return View();
        }

        public IActionResult Details(string id)
        {
            return View();
        }

        //Lockout
        public IActionResult Lockout (string id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Lockout(ApplicationUser user)
        {
            return View();
        }

        // Active
        public IActionResult Active(string id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Active(ApplicationUser user)
        {
            return View();
        }

        // Delete
        public IActionResult Delete(string id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(ApplicationUser user)
        {
            return View();
        }
    }
}
