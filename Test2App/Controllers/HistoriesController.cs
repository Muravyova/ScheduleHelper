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
    public class HistoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HistoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Histories
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Histories.Include(h => h.ScheduleItem).Include(h => h.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Histories/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var history = await _context.Histories
                .Include(h => h.ScheduleItem)
                .Include(h => h.Student)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (history == null)
            {
                return NotFound();
            }

            return View(history);
        }

        // GET: Histories/Create
        public IActionResult Create()
        {
            ViewData["ScheduleItem"] = new SelectList(_context.ScheduleItems, "Id", "Title");
            ViewData["Student"] = new SelectList(_context.Students, "Id", "Name");
            return View();
        }

        // POST: Histories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Time,Comment,StudentId,ScheduleItemId")] History history)
        {
            _context.Add(history);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Histories/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var history = await _context.Histories.SingleOrDefaultAsync(m => m.Id == id);
            if (history == null)
            {
                return NotFound();
            }
            ViewData["ScheduleItemId"] = new SelectList(_context.ScheduleItems, "Id", "StartTime", history.ScheduleItemId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Email", history.StudentId);
            return View(history);
        }

        // POST: Histories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Date,Time,Comment,StudentId,ScheduleItemId")] History history)
        {
            if (id != history.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(history);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoryExists(history.Id))
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
            ViewData["ScheduleItemId"] = new SelectList(_context.ScheduleItems, "Id", "StartTime", history.ScheduleItemId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Email", history.StudentId);
            return View(history);
        }

        // GET: Histories/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var history = await _context.Histories
                .Include(h => h.ScheduleItem)
                .Include(h => h.Student)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (history == null)
            {
                return NotFound();
            }

            return View(history);
        }

        // POST: Histories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var history = await _context.Histories.SingleOrDefaultAsync(m => m.Id == id);
            _context.Histories.Remove(history);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistoryExists(Guid id)
        {
            return _context.Histories.Any(e => e.Id == id);
        }
    }
}
