using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Physis.Data;
using Physis.Models;

namespace Physis.Controllers
{
    public class TreesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TreesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Trees
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Tree.Include(t => t.Address).Include(t => t.TreePlanter);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Trees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tree = await _context.Tree
                .Include(t => t.Address)
                .Include(t => t.TreePlanter)
                .FirstOrDefaultAsync(m => m.TreeId == id);
            if (tree == null)
            {
                return NotFound();
            }

            return View(tree);
        }

        // GET: Trees/Create
        public IActionResult Create()
        {
            ViewData["AddressId"] = new SelectList(_context.Address, "AddressId", "AddressId");
            ViewData["TreePlanterId"] = new SelectList(_context.TreePlanter, "TreePlanterId", "TreePlanterId");
            return View();
        }

        // POST: Trees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TreeId,TreeType,AddressId,TreePlanterId")] Tree tree)
        {
            if (ModelState.IsValid)
            {
                //string loggedInIdentityUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                //TreePlanter tp = _context.TreePlanter.Where(tp => tp.IdentityUserId == loggedInIdentityUserId).FirstOrDefault();
                //tree.TreePlanterId = tp.Id;
                _context.Add(tree);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.Address, "AddressId", "AddressId", tree.AddressId);
            ViewData["TreePlanterId"] = new SelectList(_context.TreePlanter, "TreePlanterId", "TreePlanterId", tree.TreePlanterId);
            return View(tree);
        }

        // GET: Trees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tree = await _context.Tree.FindAsync(id);
            if (tree == null)
            {
                return NotFound();
            }
            ViewData["AddressId"] = new SelectList(_context.Address, "AddressId", "AddressId", tree.AddressId);
            ViewData["TreePlanterId"] = new SelectList(_context.TreePlanter, "TreePlanterId", "TreePlanterId", tree.TreePlanterId);
            return View(tree);
        }

        // POST: Trees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TreeId,TreeType,AddressId,TreePlanterId")] Tree tree)
        {
            if (id != tree.TreeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tree);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TreeExists(tree.TreeId))
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
            ViewData["AddressId"] = new SelectList(_context.Address, "AddressId", "AddressId", tree.AddressId);
            ViewData["TreePlanterId"] = new SelectList(_context.TreePlanter, "TreePlanterId", "TreePlanterId", tree.TreePlanterId);
            return View(tree);
        }

        // GET: Trees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tree = await _context.Tree
                .Include(t => t.Address)
                .Include(t => t.TreePlanter)
                .FirstOrDefaultAsync(m => m.TreeId == id);
            if (tree == null)
            {
                return NotFound();
            }

            return View(tree);
        }

        // POST: Trees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tree = await _context.Tree.FindAsync(id);
            _context.Tree.Remove(tree);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TreeExists(int id)
        {
            return _context.Tree.Any(e => e.TreeId == id);
        }
    }
}
