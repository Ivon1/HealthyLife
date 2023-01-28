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
    public class CourseRatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public class RateInfo
        {
            public int Count { get; set; }
            public int TotalRate { get; set; }
        }

        public CourseRatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [AllowAnonymous]
        public RateInfo GetRateInfo(int courseId)
        {
            var rateCourse = _context.Courses.Where(c => c.Id == courseId).FirstOrDefault();
            if (rateCourse == null)
            {
                return new RateInfo() { Count = 0, TotalRate = 0 };
            }
            else
            {
                int count = 0;
                int totalRate = 0;

                var currentRateCourses = _context.CourseRates.Include(c => c.ApplicationUser).Include(c => c.Course).Where(c => c.Course.Id == courseId).ToList();
                foreach (var ratedCourse in currentRateCourses)
                {
                    count++;
                    totalRate += ratedCourse.Rate;
                }                
                return new RateInfo() { Count = count, TotalRate = totalRate };
            }
        }

        [HttpPost]
        public RateInfo AddRate(int courseId, int rate)
        {
            var currentUser = _context.ApplicationUsers.Where(u => u.UserName == User.Identity.Name).First();
            _context.CourseRates.Add(new CourseRate()
            {
                UserId = currentUser.Id,
                CourseId = courseId,
                Rate = rate
            });
            _context.SaveChanges();
            return GetRateInfo(courseId);
        }

        [HttpPost]
        public RateInfo DeleteRate(int courseId)
        {
            var currentUser = _context.ApplicationUsers.Where(u => u.UserName == User.Identity.Name).First();
            var courseRate = _context.CourseRates
                .Include(u => u.ApplicationUser)
                .Include(u => u.Course)
                .Include(u => u.Course.Aurhor)
                .Include(u => u.Course.Subject).Where(c => c.CourseId == courseId && c.ApplicationUser == currentUser).FirstOrDefault();
            _context.CourseRates.Remove(courseRate);
            _context.SaveChanges();
            return GetRateInfo(courseId);
        }

        // GET: CourseRates
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CourseRates.Include(c => c.ApplicationUser).Include(c => c.Course);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CourseRates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CourseRates == null)
            {
                return NotFound();
            }

            var courseRate = await _context.CourseRates
                .Include(c => c.ApplicationUser)
                .Include(c => c.Course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (courseRate == null)
            {
                return NotFound();
            }

            return View(courseRate);
        }

        // GET: CourseRates/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "CourseDescription");
            return View();
        }

        // POST: CourseRates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Rate,CourseId,UserId")] CourseRate courseRate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseRate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", courseRate.UserId);
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "CourseDescription", courseRate.CourseId);
            return View(courseRate);
        }

        // GET: CourseRates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CourseRates == null)
            {
                return NotFound();
            }

            var courseRate = await _context.CourseRates.FindAsync(id);
            if (courseRate == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", courseRate.UserId);
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "CourseDescription", courseRate.CourseId);
            return View(courseRate);
        }

        // POST: CourseRates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Rate,CourseId,UserId")] CourseRate courseRate)
        {
            if (id != courseRate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseRate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseRateExists(courseRate.Id))
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
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", courseRate.UserId);
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "CourseDescription", courseRate.CourseId);
            return View(courseRate);
        }

        // GET: CourseRates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CourseRates == null)
            {
                return NotFound();
            }

            var courseRate = await _context.CourseRates
                .Include(c => c.ApplicationUser)
                .Include(c => c.Course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (courseRate == null)
            {
                return NotFound();
            }

            return View(courseRate);
        }

        // POST: CourseRates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CourseRates == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CourseRates'  is null.");
            }
            var courseRate = await _context.CourseRates.FindAsync(id);
            if (courseRate != null)
            {
                _context.CourseRates.Remove(courseRate);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseRateExists(int id)
        {
          return (_context.CourseRates?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
