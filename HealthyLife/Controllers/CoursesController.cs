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
using HealthyLife.ViewModels;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Net.Sockets;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HealthyLife.Controllers
{
    [Authorize(Roles = "Admin, Moderator")]
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _host;

        public CoursesController(ApplicationDbContext context, IWebHostEnvironment host)
        {
            _context = context;
            _host = host;
        }        

        // GET: Courses
        [AllowAnonymous]
        public async Task<IActionResult> Index(string sortOrder, List<int>? sid, List<int>? aid, int page = 1)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name" : "name_desc";
            ViewData["NameDescSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "name";
            ViewData["RatingSortParm"] = sortOrder == "Rate" ? "rate_desc" : "Rate";
            ViewData["RatingDescSortParm"] = sortOrder == "rate_desc" ? "Rate" : "rate_desc";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
            ViewData["PriceDescSortParm"] = sortOrder == "price_desc" ? "Price" : "price_desc";            

            int pageSize = 5;
            IQueryable<Course> courses = _context.Courses.Include(c => c.Aurhor).Include(c => c.Subject);
            

            courses = from c in _context.Courses select c;            
            switch (sortOrder)
            {
                case "name":
                    courses = courses.OrderBy(c => c.CourseDescriptionShort);
                    break;
                case "name_desc":
                    courses = courses.OrderByDescending(c => c.CourseDescriptionShort);
                    break;
                case "Rate":
                    courses = courses.OrderBy(c => c.Rating);
                    break;
                case "rate_desc":
                    courses = courses.OrderByDescending(c => c.Rating);
                    break;
                case "Price":
                    courses = courses.OrderBy(c => c.Price);
                    break;
                case "price_desc":
                    courses = courses.OrderByDescending(c => c.Price);
                    break;
            }

            if (aid != null && aid.Any())
            {
                courses = courses.Where(c => aid.Contains(c.AuthorId));
                ViewData["aid"] = courses.Where(c => aid.Contains(c.AuthorId));
            }
            if (sid != null && sid.Any())
            {
                courses = courses.Where(c => sid.Contains(c.SubjectId));
                ViewData["sid"] = courses.Where(c => sid.Contains(c.SubjectId));
            }

            List<Author> authors = _context.Authors.ToList();
            List<Subject> subjects = _context.Subjects.ToList();            

            var count = await courses.CountAsync();
            var items = await courses.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);

            FilterViewModel viewModel = new FilterViewModel()
            {
                Courses = items,
                Authors = authors,
                Subjects = subjects,                
                PageViewModel = pageViewModel
            };

            ViewData["sid"] = sid;
            ViewData["aid"] = aid;
            ViewData["page"] = page;
            ViewData["sortOrder"] = sortOrder;
            //var applicationDbContext = _context.Courses.Include(c => c.Aurhor).Include(c => c.Subject);
            return View(viewModel);
        }

        // GET: Courses/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.Aurhor)
                .Include(c => c.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);            
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Set<Author>(), "Id", "AuthorName");
            ViewData["SubjectId"] = new SelectList(_context.Set<Subject>(), "Id", "SubjectName");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CourseName,CourseDescription,CourseDescriptionShort,PathToPhoto,Price,Rating,LikedNumber,Duration,TimesSelected,SubjectId,AuthorId")] Course course,
            IFormFile pathtophoto)
        {
            if (ModelState.IsValid)
            {
                if(pathtophoto != null)
                {
                    var name = Path.Combine(_host.WebRootPath + "/img/img_courses", Path.GetFileName(pathtophoto.FileName));
                    await pathtophoto.CopyToAsync(new FileStream(name, FileMode.Create));
                    course.PathToPhoto = pathtophoto.FileName;
                }
                else
                {
                    course.PathToPhoto = "default_white.png";
                }

                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Set<Author>(), "Id", "AuthorName", course.AuthorId);
            ViewData["SubjectId"] = new SelectList(_context.Set<Subject>(), "Id", "SubjectName", course.SubjectId);
            return View(course);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Set<Author>(), "Id", "AuthorName", course.AuthorId);
            ViewData["SubjectId"] = new SelectList(_context.Set<Subject>(), "Id", "SubjectName", course.SubjectId);
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CourseName,CourseDescription,CourseDescriptionShort,PathToPhoto,Price,Rating,LikedNumber,Duration,TimesSelected,SubjectId,AuthorId")] Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.Id))
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
            ViewData["AuthorId"] = new SelectList(_context.Set<Author>(), "Id", "AuthorName", course.AuthorId);
            ViewData["SubjectId"] = new SelectList(_context.Set<Subject>(), "Id", "SubjectName", course.SubjectId);
            return View(course);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.Aurhor)
                .Include(c => c.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Courses == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Course'  is null.");
            }
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        private bool CourseExists(int id)
        {
          return (_context.Courses?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [AllowAnonymous]
        public async Task<IActionResult> SearchedCourses(string searchString)
        {
            ViewData["CurrentSearch"] = searchString;
            IQueryable<Course> courses = _context.Courses.Include(c => c.Aurhor).Include(c => c.Subject);
            if (!String.IsNullOrEmpty(searchString))
            {
                courses = courses.Where(c => c.CourseName.Contains(searchString) || c.CourseDescriptionShort.Contains(searchString) || c.CourseDescription.Contains(searchString));
            }
            return View(await courses.ToListAsync());
        }
    }
}
