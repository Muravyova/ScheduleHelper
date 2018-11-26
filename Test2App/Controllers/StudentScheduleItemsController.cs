using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScheduleHelper.Data;
using ScheduleHelper.Models.DbModels;

namespace ScheduleHelper.Controllers
{
    public class StudentScheduleItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentScheduleItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentScheduleItems
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StudentScheduleItems.Include(s => s.ScheduleItem).Include(s => s.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StudentScheduleItems/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentScheduleItem = await _context.StudentScheduleItems
                .Include(s => s.ScheduleItem)
                .Include(s => s.Student)
                .SingleOrDefaultAsync(m => m.StudentId == id);
            if (studentScheduleItem == null)
            {
                return NotFound();
            }

            return View(studentScheduleItem);
        }

        // GET: StudentScheduleItems/Create
        public IActionResult Create()
        {
            ViewData["ScheduleItemId"] = new SelectList(_context.ScheduleItems, "Id", "StartTime");
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Email");
            return View();
        }

        // POST: StudentScheduleItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,ScheduleItemId")] StudentScheduleItem studentScheduleItem)
        {
            if (ModelState.IsValid)
            {
                studentScheduleItem.StudentId = Guid.NewGuid();
                _context.Add(studentScheduleItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ScheduleItemId"] = new SelectList(_context.ScheduleItems, "Id", "StartTime", studentScheduleItem.ScheduleItemId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Email", studentScheduleItem.StudentId);
            return View(studentScheduleItem);
        }

        // GET: StudentScheduleItems/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentScheduleItem = await _context.StudentScheduleItems.SingleOrDefaultAsync(m => m.StudentId == id);
            if (studentScheduleItem == null)
            {
                return NotFound();
            }
            ViewData["ScheduleItemId"] = new SelectList(_context.ScheduleItems, "Id", "StartTime", studentScheduleItem.ScheduleItemId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Email", studentScheduleItem.StudentId);
            return View(studentScheduleItem);
        }

        // POST: StudentScheduleItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("StudentId,ScheduleItemId")] StudentScheduleItem studentScheduleItem)
        {
            if (id != studentScheduleItem.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentScheduleItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentScheduleItemExists(studentScheduleItem.StudentId))
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
            ViewData["ScheduleItemId"] = new SelectList(_context.ScheduleItems, "Id", "StartTime", studentScheduleItem.ScheduleItemId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Email", studentScheduleItem.StudentId);
            return View(studentScheduleItem);
        }

        // GET: StudentScheduleItems/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentScheduleItem = await _context.StudentScheduleItems
                .Include(s => s.ScheduleItem)
                .Include(s => s.Student)
                .SingleOrDefaultAsync(m => m.StudentId == id);
            if (studentScheduleItem == null)
            {
                return NotFound();
            }

            return View(studentScheduleItem);
        }

        // POST: StudentScheduleItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var studentScheduleItem = await _context.StudentScheduleItems.SingleOrDefaultAsync(m => m.StudentId == id);
            _context.StudentScheduleItems.Remove(studentScheduleItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentScheduleItemExists(Guid id)
        {
            return _context.StudentScheduleItems.Any(e => e.StudentId == id);
        }
    }
}
