using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcFirst.Data;
using MvcFirst.Models;

namespace MvcFirst.Controllers
{
    public class ScoresController : Controller
    {
        private readonly UniversityContext _context;

        public ScoresController(UniversityContext context)
        {
            _context = context;
        }

        // GET: Scores
        public async Task<IActionResult> Index()
        {
            var universityContext = _context.Scores.Include(s => s.Course).Include(s => s.Student).Include(s => s.Subject);
            return View(await universityContext.ToListAsync());
        }

        // GET: Scores/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var score = await _context.Scores
                .Include(s => s.Course)
                .Include(s => s.Student)
                .Include(s => s.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (score == null)
            {
                return NotFound();
            }

            return View(score);
        }

        // GET: Scores/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id");
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id");
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Id");
            return View();
        }

        // POST: Scores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Value,SubjectId,StudentId,CourseId")] Score score)
        {
            if (ModelState.IsValid)
            {
                score.Id = Guid.NewGuid();
                _context.Add(score);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id", score.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", score.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Id", score.SubjectId);
            return View(score);
        }

        // GET: Scores/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var score = await _context.Scores.FindAsync(id);
            if (score == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id", score.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", score.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Id", score.SubjectId);
            return View(score);
        }

        // POST: Scores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Value,SubjectId,StudentId,CourseId")] Score score)
        {
            if (id != score.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(score);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScoreExists(score.Id))
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
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id", score.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", score.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Id", score.SubjectId);
            return View(score);
        }

        // GET: Scores/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var score = await _context.Scores
                .Include(s => s.Course)
                .Include(s => s.Student)
                .Include(s => s.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (score == null)
            {
                return NotFound();
            }

            return View(score);
        }

        // POST: Scores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var score = await _context.Scores.FindAsync(id);
            _context.Scores.Remove(score);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScoreExists(Guid id)
        {
            return _context.Scores.Any(e => e.Id == id);
        }
    }
}
