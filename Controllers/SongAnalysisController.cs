#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChordsWebApp;

namespace ChordsWebApp.Controllers
{
    public class SongAnalysisController : Controller
    {
        private readonly DBChordsContext _context;

        public SongAnalysisController(DBChordsContext context)
        {
            _context = context;
        }

        // GET: SongAnalysis
        public async Task<IActionResult> Index()
        {
            var dBChordsContext = _context.SongAnalyses.Include(s => s.Instrument).Include(s => s.Song).Include(s => s.User);
            return View(await dBChordsContext.ToListAsync());
        }

        // GET: SongAnalysis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songAnalysis = await _context.SongAnalyses
                .Include(s => s.Instrument)
                .Include(s => s.Song)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (songAnalysis == null)
            {
                return NotFound();
            }

            return View(songAnalysis);
        }

        // GET: SongAnalysis/Create
        public IActionResult Create()
        {
            ViewData["InstrumentId"] = new SelectList(_context.Instruments, "Id", "Id");
            ViewData["SongId"] = new SelectList(_context.Songs, "Id", "Name");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: SongAnalysis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SongId,UserId,InstrumentId,Chords,AddingDate")] SongAnalysis songAnalysis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(songAnalysis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InstrumentId"] = new SelectList(_context.Instruments, "Id", "Id", songAnalysis.InstrumentId);
            ViewData["SongId"] = new SelectList(_context.Songs, "Id", "Name", songAnalysis.SongId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", songAnalysis.UserId);
            return View(songAnalysis);
        }

        // GET: SongAnalysis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songAnalysis = await _context.SongAnalyses.FindAsync(id);
            if (songAnalysis == null)
            {
                return NotFound();
            }
            ViewData["InstrumentId"] = new SelectList(_context.Instruments, "Id", "Id", songAnalysis.InstrumentId);
            ViewData["SongId"] = new SelectList(_context.Songs, "Id", "Name", songAnalysis.SongId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", songAnalysis.UserId);
            return View(songAnalysis);
        }

        // POST: SongAnalysis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SongId,UserId,InstrumentId,Chords,AddingDate")] SongAnalysis songAnalysis)
        {
            if (id != songAnalysis.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(songAnalysis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongAnalysisExists(songAnalysis.Id))
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
            ViewData["InstrumentId"] = new SelectList(_context.Instruments, "Id", "Id", songAnalysis.InstrumentId);
            ViewData["SongId"] = new SelectList(_context.Songs, "Id", "Name", songAnalysis.SongId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", songAnalysis.UserId);
            return View(songAnalysis);
        }

        // GET: SongAnalysis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songAnalysis = await _context.SongAnalyses
                .Include(s => s.Instrument)
                .Include(s => s.Song)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (songAnalysis == null)
            {
                return NotFound();
            }

            return View(songAnalysis);
        }

        // POST: SongAnalysis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var songAnalysis = await _context.SongAnalyses.FindAsync(id);
            _context.SongAnalyses.Remove(songAnalysis);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SongAnalysisExists(int id)
        {
            return _context.SongAnalyses.Any(e => e.Id == id);
        }
    }
}
