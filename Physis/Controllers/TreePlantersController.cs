using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Physis.Data;
using Physis.Models;

namespace Physis.Controllers
{
    public class TreePlantersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TreePlantersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TreePlanters
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TreePlanter.Include(t => t.Address);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TreePlanters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treePlanter = await _context.TreePlanter
                .Include(t => t.Address)
                .FirstOrDefaultAsync(m => m.TreePlanterId == id);
            if (treePlanter == null)
            {
                return NotFound();
            }

            return View(treePlanter);
        }

        // GET: TreePlanters/Create
        public IActionResult Create()
        {
            ViewData["AddressId"] = new SelectList(_context.Address, "AddressId", "AddressId");
            return View();
        }

        // POST: TreePlanters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TreePlanterId,FirstName,LastName,AddressId")] TreePlanter treePlanter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(treePlanter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.Address, "AddressId", "AddressId", treePlanter.AddressId);
            return View(treePlanter);
        }

        // GET: TreePlanters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treePlanter = await _context.TreePlanter.FindAsync(id);
            if (treePlanter == null)
            {
                return NotFound();
            }
            ViewData["AddressId"] = new SelectList(_context.Address, "AddressId", "AddressId", treePlanter.AddressId);
            return View(treePlanter);
        }

        // POST: TreePlanters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TreePlanterId,FirstName,LastName,AddressId")] TreePlanter treePlanter)
        {
            if (id != treePlanter.TreePlanterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(treePlanter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TreePlanterExists(treePlanter.TreePlanterId))
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
            ViewData["AddressId"] = new SelectList(_context.Address, "AddressId", "AddressId", treePlanter.AddressId);
            return View(treePlanter);
        }

        // GET: TreePlanters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treePlanter = await _context.TreePlanter
                .Include(t => t.Address)
                .FirstOrDefaultAsync(m => m.TreePlanterId == id);
            if (treePlanter == null)
            {
                return NotFound();
            }

            return View(treePlanter);
        }

        // POST: TreePlanters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var treePlanter = await _context.TreePlanter.FindAsync(id);
            _context.TreePlanter.Remove(treePlanter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TreePlanterExists(int id)
        {
            return _context.TreePlanter.Any(e => e.TreePlanterId == id);
        }
    }
}
