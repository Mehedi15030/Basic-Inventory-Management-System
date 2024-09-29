using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Basic_Inventory_Management_System.Data;
using Basic_Inventory_Management_System.Models;
using Microsoft.AspNetCore.Authorization;

namespace Basic_Inventory_Management_System.Controllers
{
    [Authorize]
    public class SellingOrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SellingOrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SellingOrders
        [Authorize(Roles = "Manager,Employee,User")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.SellingOrder.ToListAsync());
        }

        // GET: SellingOrders/Details/5
        [Authorize(Roles = "Manager,Employee,User")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sellingOrder = await _context.SellingOrder
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sellingOrder == null)
            {
                return NotFound();
            }

            return View(sellingOrder);
        }

        // GET: SellingOrders/Create
        [Authorize(Roles = "Manager,Employee")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: SellingOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Manager,Employee")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderDate,TotalAmount")] SellingOrder sellingOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sellingOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sellingOrder);
        }
        [Authorize(Roles = "Manager,Employee")]
        // GET: SellingOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sellingOrder = await _context.SellingOrder.FindAsync(id);
            if (sellingOrder == null)
            {
                return NotFound();
            }
            return View(sellingOrder);
        }

        // POST: SellingOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Manager,Employee")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrderDate,TotalAmount")] SellingOrder sellingOrder)
        {
            if (id != sellingOrder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sellingOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SellingOrderExists(sellingOrder.Id))
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
            return View(sellingOrder);
        }

        // GET: SellingOrders/Delete/5
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sellingOrder = await _context.SellingOrder
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sellingOrder == null)
            {
                return NotFound();
            }

            return View(sellingOrder);
        }
        [Authorize(Roles = "Manager")]
        // POST: SellingOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sellingOrder = await _context.SellingOrder.FindAsync(id);
            if (sellingOrder != null)
            {
                _context.SellingOrder.Remove(sellingOrder);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SellingOrderExists(int id)
        {
            return _context.SellingOrder.Any(e => e.Id == id);
        }
    }
}
