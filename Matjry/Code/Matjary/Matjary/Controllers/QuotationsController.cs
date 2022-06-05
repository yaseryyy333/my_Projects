using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Matjary.Data;
using Matjary.Models;
using PagedList.Core;
using Microsoft.AspNetCore.Authorization;

namespace Matjary.Controllers
{
    [Authorize(Roles = "Admin,Employee")]
    public class QuotationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuotationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Quotations
        public async Task<IActionResult> Index(int? page)
        {
            var applicationDbContext = _context.Quotations.Include(q => q.Person);
            return View(applicationDbContext.ToPagedList(page ?? 1,10));
        }

        // GET: Quotations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quotations = await _context.Quotations
                .Include(q => q.Person)
                .FirstOrDefaultAsync(m => m.Id == id);

            ViewData["QuotationsProducts"] = _context.QuotationsProducts
                .Where(x => x.QuotationsId == quotations.Id)
                .Include(x => x.Product).ToList();

            ViewData["Total"] = _context.QuotationsProducts
                .Where(x => x.QuotationsId == quotations.Id)
                .Select(x=>x.Total).Sum();

            ViewData["Total_Vat"] = _context.QuotationsProducts
                .Where(x => x.QuotationsId == quotations.Id)
                .Select(x => x.Total_Vat).Sum();

            ViewData["Discount"] = _context.QuotationsProducts
            .Where(x => x.QuotationsId == quotations.Id)
            .Select(x => x.Discount).Sum();
            if (quotations == null)
            {
                return NotFound();
            }

            return View(quotations);
        }

        // GET: Quotations/Create
        public IActionResult Create()
        {
            List<Persons> myCustomer = _context.Persons.Where(x => x.Type == Persons.accountType.زبون).ToList();
            List<SelectListItem> customers = myCustomer.ConvertAll(a => {
                return new SelectListItem()
                {
                    Text = a.Name,
                    Value = a.Id.ToString(),
                    Selected = false
                };
            });
            ViewData["Customers"] = customers;
            ViewData["Products"] = new SelectList(_context.Products, "Id", "Name");
            ViewData["Vat"] = new SelectList(_context.VatTable, "Id", "VatRate");
            return View();
        }

        // POST: Quotations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,VatRate,Status,TotalDiscount,TotalCost,TotalVat,Total,Duration,Note,UserId,PersonId")] Quotations quotations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quotations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", quotations.UserId);
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "Address", quotations.PersonId);
            return View(quotations);
        }

        // GET: Quotations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quotations = await _context.Quotations.FindAsync(id);
            if (quotations == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", quotations.UserId);
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "Address", quotations.PersonId);
            return View(quotations);
        }

        // POST: Quotations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,VatRate,Status,TotalDiscount,TotalCost,TotalVat,Total,Duration,Note,UserId,PersonId")] Quotations quotations)
        {
            if (id != quotations.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quotations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuotationsExists(quotations.Id))
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
            ViewData["UserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", quotations.UserId);
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "Address", quotations.PersonId);
            return View(quotations);
        }

        // GET: Quotations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quotations = await _context.Quotations
                .Include(q => q.ApplicationUser)
                .Include(q => q.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quotations == null)
            {
                return NotFound();
            }

            return View(quotations);
        }

        // POST: Quotations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quotations = await _context.Quotations.FindAsync(id);
            _context.Quotations.Remove(quotations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuotationsExists(int id)
        {
            return _context.Quotations.Any(e => e.Id == id);
        }
    }
}
