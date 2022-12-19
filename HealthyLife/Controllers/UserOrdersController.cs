using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using HealthyLife.Data;
using HealthyLife.Models;


namespace HealthyLife.Controllers
{
    [Authorize]
    public class UserOrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserOrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserOrders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UserOrders.Include(u => u.ApplicationUser).Include(u => u.Course);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UserOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserOrders == null)
            {
                return NotFound();
            }

            var userOrder = await _context.UserOrders
                .Include(u => u.ApplicationUser)
                .Include(u => u.Course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userOrder == null)
            {
                return NotFound();
            }

            return View(userOrder);
        }

        // GET: UserOrders/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "CourseDescription");
            return View();
        }

        // POST: UserOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CourseId,UserId")] UserOrder userOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", userOrder.UserId);
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "CourseDescription", userOrder.CourseId);
            return View(userOrder);
        }

        // GET: UserOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserOrders == null)
            {
                return NotFound();
            }

            var userOrder = await _context.UserOrders.FindAsync(id);
            if (userOrder == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", userOrder.UserId);
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "CourseDescription", userOrder.CourseId);
            return View(userOrder);
        }

        // POST: UserOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CourseId,UserId")] UserOrder userOrder)
        {
            if (id != userOrder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserOrderExists(userOrder.Id))
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
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", userOrder.UserId);
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "CourseDescription", userOrder.CourseId);
            return View(userOrder);
        }

        // GET: UserOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserOrders == null)
            {
                return NotFound();
            }

            var userOrder = await _context.UserOrders
                .Include(u => u.ApplicationUser)
                .Include(u => u.Course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userOrder == null)
            {
                return NotFound();
            }

            return View(userOrder);
        }

        // POST: UserOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserOrders == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UserOrders'  is null.");
            }
            var userOrder = await _context.UserOrders.FindAsync(id);
            if (userOrder != null)
            {
                _context.UserOrders.Remove(userOrder);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserOrderExists(int id)
        {
          return (_context.UserOrders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
