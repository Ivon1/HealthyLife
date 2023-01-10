using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HealthyLife.Data;
using HealthyLife.Models;
using Microsoft.AspNetCore.Authorization;

namespace HealthyLife.Controllers
{
    public class StatInfo2
    {
        public int Count { get; set; }        
    }

    [AllowAnonymous]
    public class UserWishesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserWishesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [AllowAnonymous]
        public StatInfo2 GetStatInfo()
        {
            var currentUser = _context.ApplicationUsers.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            if (currentUser == null)
            {
                return new StatInfo2() { Count = 0 };
            }
            else
            {
                int count = 0;                

                var currentUserWishes = _context.UserWishes.Include(u => u.ApplicationUser).Include(u => u.Course).Where(u => u.ApplicationUser.UserName == User.Identity.Name).ToList();
                foreach (var userWish in currentUserWishes)
                {
                    count++;                    
                }
                return new StatInfo2() { Count = count };
            }
        }

        [HttpPost]
        public StatInfo2 AddCourseToWishlist(int courseId)
        {
            var currentUser = _context.ApplicationUsers.Where(u => u.UserName == User.Identity.Name).First();
            _context.UserWishes.Add(new UserWish()
            {
                UserId = currentUser.Id,
                CourseId = courseId
            });
            _context.SaveChanges();
            return GetStatInfo();
        }

        // GET: UserWishes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UserWishes.Include(u => u.ApplicationUser).Include(u => u.Course).Include(u => u.Course.Aurhor).Include(u => u.Course.Subject).Where(u => u.ApplicationUser.UserName == User.Identity.Name);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UserWishes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserWishes == null)
            {
                return NotFound();
            }

            var userWish = await _context.UserWishes
                .Include(u => u.ApplicationUser)
                .Include(u => u.Course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userWish == null)
            {
                return NotFound();
            }

            return View(userWish);
        }

        // GET: UserWishes/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "CourseDescription");
            return View();
        }

        // POST: UserWishes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CourseId,UserId")] UserWish userWish)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userWish);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", userWish.UserId);
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "CourseDescription", userWish.CourseId);
            return View(userWish);
        }

        // GET: UserWishes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserWishes == null)
            {
                return NotFound();
            }

            var userWish = await _context.UserWishes.FindAsync(id);
            if (userWish == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", userWish.UserId);
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "CourseDescription", userWish.CourseId);
            return View(userWish);
        }

        // POST: UserWishes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CourseId,UserId")] UserWish userWish)
        {
            if (id != userWish.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userWish);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserWishExists(userWish.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", userWish.UserId);
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "CourseDescription", userWish.CourseId);
            return View(userWish);
        }

        // GET: UserWishes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserWishes == null)
            {
                return NotFound();
            }

            var userWish = await _context.UserWishes
                .Include(u => u.ApplicationUser)
                .Include(u => u.Course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userWish == null)
            {
                return NotFound();
            }

            return View(userWish);
        }

        // POST: UserWishes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserWishes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UserWishes'  is null.");
            }
            var userWish = await _context.UserWishes.FindAsync(id);
            if (userWish != null)
            {
                _context.UserWishes.Remove(userWish);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserWishExists(int id)
        {
          return (_context.UserWishes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
