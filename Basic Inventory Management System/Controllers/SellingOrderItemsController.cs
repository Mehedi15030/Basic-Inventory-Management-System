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
    public class SellingOrderItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SellingOrderItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SellingOrderItems
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SellingOrderItem.Include(s => s.Product).Include(s => s.SellingOrder);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SellingOrderItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sellingOrderItem = await _context.SellingOrderItem
                .Include(s => s.Product)
                .Include(s => s.SellingOrder)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sellingOrderItem == null)
            {
                return NotFound();
            }

            return View(sellingOrderItem);
        }

        // GET: SellingOrderItems/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Product, "id", "name");
            ViewData["SellingOrderId"] = new SelectList(_context.SellingOrder, "Id", "Id");
            return View();
        }

        // POST: SellingOrderItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SellingOrderId,ProductId,Quantity,Price")] SellingOrderItem sellingOrderItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sellingOrderItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "id", "name", sellingOrderItem.ProductId);
            ViewData["SellingOrderId"] = new SelectList(_context.SellingOrder, "Id", "Id", sellingOrderItem.SellingOrderId);
            return View(sellingOrderItem);
        }

        // GET: SellingOrderItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sellingOrderItem = await _context.SellingOrderItem.FindAsync(id);
            if (sellingOrderItem == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "id", "name", sellingOrderItem.ProductId);
            ViewData["SellingOrderId"] = new SelectList(_context.SellingOrder, "Id", "Id", sellingOrderItem.SellingOrderId);
            return View(sellingOrderItem);
        }

        // POST: SellingOrderItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SellingOrderId,ProductId,Quantity,Price")] SellingOrderItem sellingOrderItem)
        {
            if (id != sellingOrderItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sellingOrderItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SellingOrderItemExists(sellingOrderItem.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Product, "id", "name", sellingOrderItem.ProductId);
            ViewData["SellingOrderId"] = new SelectList(_context.SellingOrder, "Id", "Id", sellingOrderItem.SellingOrderId);
            return View(sellingOrderItem);
        }

        // GET: SellingOrderItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sellingOrderItem = await _context.SellingOrderItem
                .Include(s => s.Product)
                .Include(s => s.SellingOrder)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sellingOrderItem == null)
            {
                return NotFound();
            }

            return View(sellingOrderItem);
        }

        // POST: SellingOrderItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sellingOrderItem = await _context.SellingOrderItem.FindAsync(id);
            if (sellingOrderItem != null)
            {
                _context.SellingOrderItem.Remove(sellingOrderItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SellingOrderItemExists(int id)
        {
            return _context.SellingOrderItem.Any(e => e.Id == id);
        }
    }
}
