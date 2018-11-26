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
    public class ScheduleItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ScheduleItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ScheduleItems
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ScheduleItems.Include(s => s.Language).Include(s => s.Place).Include(s => s.Teacher);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ScheduleItems/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduleItem = await _context.ScheduleItems
                .Include(s => s.Language)
                .Include(s => s.Place)
                .Include(s => s.Teacher)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (scheduleItem == null)
            {
                return NotFound();
            }

            return View(scheduleItem);
        }

        // GET: ScheduleItems/Create
        public IActionResult Create()
        {
            ViewData["LanguageId"] = new SelectList(_context.Languages, "Id", "Name");
            ViewData["PlaceId"] = new SelectList(_context.Places, "Id", "Id");
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Email");
            return View();
        }

        // POST: ScheduleItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,StartDate,DayOfWeek,StartTime,EndDate,Duration,Type,PlaceId,TeacherId,LanguageId")] ScheduleItem scheduleItem)
        {
            if (ModelState.IsValid)
            {
                scheduleItem.Id = Guid.NewGuid();
                _context.Add(scheduleItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LanguageId"] = new SelectList(_context.Languages, "Id", "Name", scheduleItem.LanguageId);
            ViewData["PlaceId"] = new SelectList(_context.Places, "Id", "Id", scheduleItem.PlaceId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Email", scheduleItem.TeacherId);
            return View(scheduleItem);
        }

        // GET: ScheduleItems/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduleItem = await _context.ScheduleItems.SingleOrDefaultAsync(m => m.Id == id);
            if (scheduleItem == null)
            {
                return NotFound();
            }
            ViewData["LanguageId"] = new SelectList(_context.Languages, "Id", "Name", scheduleItem.LanguageId);
            ViewData["PlaceId"] = new SelectList(_context.Places, "Id", "Id", scheduleItem.PlaceId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Email", scheduleItem.TeacherId);
            return View(scheduleItem);
        }

        // POST: ScheduleItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,StartDate,DayOfWeek,StartTime,EndDate,Duration,Type,PlaceId,TeacherId,LanguageId")] ScheduleItem scheduleItem)
        {
            if (id != scheduleItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scheduleItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduleItemExists(scheduleItem.Id))
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
            ViewData["LanguageId"] = new SelectList(_context.Languages, "Id", "Name", scheduleItem.LanguageId);
            ViewData["PlaceId"] = new SelectList(_context.Places, "Id", "Id", scheduleItem.PlaceId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Email", scheduleItem.TeacherId);
            return View(scheduleItem);
        }

        // GET: ScheduleItems/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduleItem = await _context.ScheduleItems
                .Include(s => s.Language)
                .Include(s => s.Place)
                .Include(s => s.Teacher)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (scheduleItem == null)
            {
                return NotFound();
            }

            return View(scheduleItem);
        }

        // POST: ScheduleItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var scheduleItem = await _context.ScheduleItems.SingleOrDefaultAsync(m => m.Id == id);
            _context.ScheduleItems.Remove(scheduleItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScheduleItemExists(Guid id)
        {
            return _context.ScheduleItems.Any(e => e.Id == id);
        }
    }
}
