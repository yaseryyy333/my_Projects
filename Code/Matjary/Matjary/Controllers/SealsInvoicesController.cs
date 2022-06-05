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
    public class SealsInvoicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SealsInvoicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SealsInvoices
        public async Task<IActionResult> Index(int? page)
        {
            var applicationDbContext = _context.Invoices
                .Where(x => x.Invoice_Type == "مبيعات")
                .Include(i => i.Person);

            return View( applicationDbContext.ToPagedList(page??1,10));
        }

        // GET: SealsInvoices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoices = await _context.Invoices
                .Include(q => q.Person)
                .FirstOrDefaultAsync(m => m.Id == id);

            ViewData["InvoicesProducts"] = _context.InvoicesProducts
                .Where(x => x.InvoiceId == invoices.Id)
                .Include(x => x.Product).ToList();

            ViewData["Total"] = _context.InvoicesProducts
                .Where(x => x.InvoiceId == invoices.Id)
                .Select(x => x.Total).Sum();

            ViewData["Total_Vat"] = _context.InvoicesProducts
                .Where(x => x.InvoiceId == invoices.Id)
                .Select(x => x.Total_Vat).Sum();

            ViewData["Discount"] = _context.InvoicesProducts
            .Where(x => x.InvoiceId == invoices.Id)
            .Select(x => x.Discount).Sum();

            ViewData["Payments"] = _context.Payment
            .Where(x => x.InvoiceId == id).ToList();
            if (invoices == null)
            {
                return NotFound();
            }

            return View(invoices);
        }

        // GET: SealsInvoices/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id");
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "Address");
            return View();
        }

        // POST: SealsInvoices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Type,Invoice_Type,Vat_Rate,TotalDiscount,TotalCost,TotalVat,Total,Payments,Note,PersonId,UserId")] Invoices invoices)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoices);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", invoices.UserId);
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "Address", invoices.PersonId);
            return View(invoices);
        }

        // GET: SealsInvoices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoices = await _context.Invoices.FindAsync(id);
            if (invoices == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", invoices.UserId);
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "Address", invoices.PersonId);
            return View(invoices);
        }

        // POST: SealsInvoices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Type,Invoice_Type,Vat_Rate,TotalDiscount,TotalCost,TotalVat,Total,Payments,Note,PersonId,UserId")] Invoices invoices)
        {
            if (id != invoices.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoices);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoicesExists(invoices.Id))
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
            ViewData["UserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", invoices.UserId);
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "Address", invoices.PersonId);
            return View(invoices);
        }

        // GET: SealsInvoices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoices = await _context.Invoices
                .Include(i => i.ApplicationUser)
                .Include(i => i.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoices == null)
            {
                return NotFound();
            }

            return View(invoices);
        }

        // POST: SealsInvoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoices = await _context.Invoices.FindAsync(id);
            _context.Invoices.Remove(invoices);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoicesExists(int id)
        {
            return _context.Invoices.Any(e => e.Id == id);
        }
    }
}
