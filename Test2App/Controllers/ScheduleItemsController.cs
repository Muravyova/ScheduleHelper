using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScheduleHelper.Data;
using ScheduleHelper.Models.DbModels;
using System.Collections.Generic;
using ScheduleHelper.Models.Other;
using ScheduleHelper.Models.ViewModels;

namespace ScheduleHelper.Controllers
{
    public class ScheduleItemsController : Controller
    {

        private static List<Int32> DURATION = new List<Int32> { 60, 90 };
       
        private static List<String> START_TIMES = new List<String>
        {
                "06:00","06:15","06:30","06:45",
                "07:00","07:15","07:30","07:45",
                "08:00","08:15","08:30","08:45",
                "09:00","09:15","09:30","09:45",
                "10:00","10:15","10:30","10:45",
                "11:00","11:15","11:30","11:45",
                "12:00","12:15","12:30","12:45",
                "13:00","13:15","13:30","13:45",
                "14:00","14:15","14:30","14:45",
                "15:00","15:15","15:30","15:45",
                "16:00","16:15","16:30","16:45",
                "17:00","17:15","17:30","17:45",
                "18:00","18:15","18:30","18:45",
                "19:00","19:15","19:30","19:45",
                "20:00","20:15","20:30","20:45",
                "21:00","21:15","21:30","21:45",
                "22:00","22:15","22:30","22:45",
                "23:00"
        };

    private readonly ApplicationDbContext _context;

        public ScheduleItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ScheduleItems
        public async Task<IActionResult> Index(String start)
        {
            DateTime sD;
            if (start != null)
            {
                sD = DateTimeExtensions.StartOfWeek(Convert.ToDateTime(start), DayOfWeek.Monday);
            } else
            {
                sD = DateTimeExtensions.StartOfWeek(DateTime.Now, DayOfWeek.Monday);
            }

            var items = await _context.ScheduleItems.Include(it => it.Language).Include(it => it.Place).Include(it => it.Teacher)
                .ToListAsync();

            var scheduleItems = items.Where(it => sD >= it.StartDate && it.EndDate >= sD).ToList();

            var result = new ScheduleViewModel(){
                CurrentWeek = sD,
                Days = new List<ScheduleDay>()
            };

            result.Days.Add(new ScheduleDay()
            {
                DayKey = 1,
                DayName = "Понедельник",
                Times = FormScheduleTime(scheduleItems.Where(it => it.DayOfWeek == 1).ToList())
            });

            result.Days.Add(new ScheduleDay()
            {
                DayKey = 2,
                DayName = "Вторник",
                Times = FormScheduleTime(scheduleItems.Where(it => it.DayOfWeek == 2).ToList())
            });

            result.Days.Add(new ScheduleDay()
            {
                DayKey = 3,
                DayName = "Среда",
                Times = FormScheduleTime(scheduleItems.Where(it => it.DayOfWeek == 3).ToList())
            });

            result.Days.Add(new ScheduleDay()
            {
                DayKey = 4,
                DayName = "Четверг",
                Times = FormScheduleTime(scheduleItems.Where(it => it.DayOfWeek == 4).ToList())
            });

            result.Days.Add(new ScheduleDay()
            {
                DayKey = 5,
                DayName = "Пятница",
                Times = FormScheduleTime(scheduleItems.Where(it => it.DayOfWeek == 5).ToList())
            });

            result.Days.Add(new ScheduleDay()
            {
                DayKey = 6,
                DayName = "Суббота",
                Times = FormScheduleTime(scheduleItems.Where(it => it.DayOfWeek == 6).ToList())
            });

            result.Days.Add(new ScheduleDay()
            {
                DayKey = 7,
                DayName = "Воскресенье",
                Times = FormScheduleTime(scheduleItems.Where(it => it.DayOfWeek == 7).ToList())
            });

            return View(result);
        }

        private List<ScheduleTime> FormScheduleTime(List<ScheduleItem> weekItems)
        {
            var weekItemsTime = new List<ScheduleTime>();

            foreach (var item in weekItems)
            {
                var finded = weekItemsTime.FirstOrDefault(it => it.StartTime == item.StartTime);
                if (finded == null)
                {
                    weekItemsTime.Add(new ScheduleTime()
                    {
                        StartTime = item.StartTime,
                        Items = new List<ScheduleItem>()
                        {
                            item
                        }
                    });
                }
                else
                {
                    finded.Items.Add(item);
                }
            }

            return weekItemsTime;
        }

        // GET: ScheduleItems/Details/5
        public async Task<IActionResult> Details(Guid? id, String cw)
        {
            if (id == null || cw == null)
            {
                return NotFound();
            }

            var date = Convert.ToDateTime(cw);

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
            ViewData["DayOfWeek"] = new SelectList(Models.Other.DayOfWeekApp.DAYS_OF_WEEK, "Key", "Name");
            ViewData["Type"] = new SelectList(ScheduleItemType.TYPES, "Key", "Key");
            ViewData["Duration"] = new SelectList(DURATION);
            ViewData["StartTimes"] = new SelectList(START_TIMES);
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Name");
            ViewData["Place"] = new SelectList(_context.Places, "Id", "Type");
            ViewData["Teacher"] = new SelectList(_context.Teachers, "Id", "Name");
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
            ViewData["DayOfWeek"] = new SelectList(Models.Other.DayOfWeekApp.DAYS_OF_WEEK, "Key", "Name");
            ViewData["Type"] = new SelectList(ScheduleItemType.TYPES, "Key", "Key");
            ViewData["Duration"] = new SelectList(DURATION);
            ViewData["StartTimes"] = new SelectList(START_TIMES);
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Name");
            ViewData["Place"] = new SelectList(_context.Places, "Id", "Type");
            ViewData["Teacher"] = new SelectList(_context.Teachers, "Id", "Name");
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
            ViewData["DayOfWeek"] = new SelectList(Models.Other.DayOfWeekApp.DAYS_OF_WEEK, "Key", "Name");
            ViewData["Type"] = new SelectList(ScheduleItemType.TYPES, "Key", "Key");
            ViewData["Duration"] = new SelectList(DURATION);
            ViewData["StartTimes"] = new SelectList(START_TIMES);
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Name");
            ViewData["Place"] = new SelectList(_context.Places, "Id", "Type");
            ViewData["Teacher"] = new SelectList(_context.Teachers, "Id", "Name");
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
