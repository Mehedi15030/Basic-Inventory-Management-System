using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Basic_Inventory_Management_System.Data;
using Basic_Inventory_Management_System.Models;

namespace Basic_Inventory_Management_System.Controllers
{
    public class PurchaseordersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PurchaseordersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Purchaseorders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Purchaseorder.ToListAsync());
        }

        // GET: Purchaseorders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseorder = await _context.Purchaseorder
                .FirstOrDefaultAsync(m => m.Id == id);
            if (purchaseorder == null)
            {
                return NotFound();
            }

            return View(purchaseorder);
        }

        // GET: Purchaseorders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Purchaseorders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderDate,TotalAmount")] Purchaseorder purchaseorder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchaseorder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(purchaseorder);
        }

        // GET: Purchaseorders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseorder = await _context.Purchaseorder.FindAsync(id);
            if (purchaseorder == null)
            {
                return NotFound();
            }
            return View(purchaseorder);
        }

        // POST: Purchaseorders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrderDate,TotalAmount")] Purchaseorder purchaseorder)
        {
            if (id != purchaseorder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaseorder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseorderExists(purchaseorder.Id))
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
            return View(purchaseorder);
        }

        // GET: Purchaseorders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseorder = await _context.Purchaseorder
                .FirstOrDefaultAsync(m => m.Id == id);
            if (purchaseorder == null)
            {
                return NotFound();
            }

            return View(purchaseorder);
        }

        // POST: Purchaseorders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchaseorder = await _context.Purchaseorder.FindAsync(id);
            if (purchaseorder != null)
            {
                _context.Purchaseorder.Remove(purchaseorder);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseorderExists(int id)
        {
            return _context.Purchaseorder.Any(e => e.Id == id);
        }
    }
}
