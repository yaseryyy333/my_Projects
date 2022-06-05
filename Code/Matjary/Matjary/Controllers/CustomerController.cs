using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Matjary.Models;
using PagedList.Core;
using Matjary.Data;
using Microsoft.AspNetCore.Authorization;

namespace Matjary.Controllers
{
    [Authorize(Roles = "Admin,Employee")]
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Supplier
        public IActionResult Index(int? page=1)
        {
            var Customer = Persons.accountType.زبون;
            var Customers = _context.Persons.Where(x => x.Type == Customer);

            return View(Customers.ToPagedList(page??1, 15));
        }
        [HttpPost]
        public IActionResult Index(int? page, string searchType, string searchValue)
        {
            var Customer = Persons.accountType.زبون;
            var Customers = _context.Persons.Where(x => x.Type == Customer);
            switch (searchType)
            {
                case "UserName":
                    return View(Customers.Where(n => n.Name.Contains(searchValue)).ToPagedList(page ?? 1, 10));
                case "Telephone":
                    return View(Customers.Where(n => n.Telephone.Contains(searchValue)).ToPagedList(page ?? 1, 10));
                case "PhoneNumber":
                    return View(Customers.Where(n => n.Mobile.Contains(searchValue)).ToPagedList(page ?? 1, 10));
                case "Email":
                    return View(Customers.Where(n => n.Email.Contains(searchValue)).ToPagedList(page ?? 1, 10));
            }
            return View(Customers.ToPagedList(page ?? 1, 10));

        }

        // GET: Supplier/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persons = await _context.Persons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (persons == null)
            {
                return NotFound();
            }

            return View(persons);
        }

        // GET: Supplier/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Supplier/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Name,Address,Telephone,Mobile,Email,Note,Type")] Persons persons)
        {
            if (ModelState.IsValid)
            {
                persons.Type = Persons.accountType.زبون;
                persons.Date = DateTime.Now.Date;

                _context.Add(persons);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(persons);
        }

        // GET: Supplier/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persons = await _context.Persons.FindAsync(id);
            if (persons == null)
            {
                return NotFound();
            }
            return View(persons);
        }

        // POST: Supplier/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Name,Address,Telephone,Mobile,Email,Note,Type")] Persons persons)
        {
            if (id != persons.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(persons);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonsExists(persons.Id))
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
            return View(persons);
        }

        // GET: Supplier/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persons = await _context.Persons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (persons == null)
            {
                return NotFound();
            }

            _context.Persons.Remove(persons);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Supplier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var persons = await _context.Persons.FindAsync(id);
            _context.Persons.Remove(persons);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonsExists(int id)
        {
            return _context.Persons.Any(e => e.Id == id);
        }
    }
}
