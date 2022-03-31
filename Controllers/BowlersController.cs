using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bowlers.Models;

namespace Bowlers.Controllers
{
    public class BowlersController : Controller
    {
        private readonly BowlingDbContext _context;

        public BowlersController(BowlingDbContext context)
        {
            _context = context;
        }

        // GET: Bowlers
        public async Task<IActionResult> Index()
        {
            var bowlingDbContext = _context.Bowlers.Include(b => b.Team);


            return View(await bowlingDbContext.ToListAsync());
        }

        // GET: Bowlers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bowler = await _context.Bowlers
                .Include(b => b.Team)
                .FirstOrDefaultAsync(m => m.BowlerID == id);
            if (bowler == null)
            {
                return NotFound();
            }

            return View(bowler);
        }

        // GET: Bowlers/Create
        public IActionResult Create()
        {
            ViewData["TeamID"] = new SelectList(_context.Teams, "TeamID", "TeamName");
            return View();
        }

        // POST: Bowlers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BowlerID,BowlerLastName,BowlerFirstName,BowlerMiddleInit,BowlerAddress,BowlerCity,BowlerState,BowlerZip,BowlerPhoneNumber,TeamID")] Bowler bowler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bowler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeamID"] = new SelectList(_context.Teams, "TeamID", "TeamName", bowler.TeamID);
            return View(bowler);
        }

        // GET: Bowlers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bowler = await _context.Bowlers.FindAsync(id);
            if (bowler == null)
            {
                return NotFound();
            }
            ViewData["TeamID"] = new SelectList(_context.Teams, "TeamID", "TeamName", bowler.TeamID);
            return View(bowler);
        }

        // POST: Bowlers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BowlerID,BowlerLastName,BowlerFirstName,BowlerMiddleInit,BowlerAddress,BowlerCity,BowlerState,BowlerZip,BowlerPhoneNumber,TeamID")] Bowler bowler)
        {
            if (id != bowler.BowlerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bowler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BowlerExists(bowler.BowlerID))
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
            ViewData["TeamID"] = new SelectList(_context.Teams, "TeamID", "TeamName", bowler.TeamID);
            return View(bowler);
        }

        // GET: Bowlers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bowler = await _context.Bowlers
                .Include(b => b.Team)
                .FirstOrDefaultAsync(m => m.BowlerID == id);
            if (bowler == null)
            {
                return NotFound();
            }

            return View(bowler);
        }

        // POST: Bowlers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bowler = await _context.Bowlers.FindAsync(id);
            _context.Bowlers.Remove(bowler);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BowlerExists(int id)
        {
            return _context.Bowlers.Any(e => e.BowlerID == id);
        }
    }
}
