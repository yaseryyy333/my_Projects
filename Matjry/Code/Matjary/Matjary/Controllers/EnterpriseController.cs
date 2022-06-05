using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Matjary.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Matjary.Data;
using Microsoft.AspNetCore.Authorization;

namespace Matjary.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EnterpriseController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;


        public EnterpriseController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }


        // GET: Enterprise/Edit/5
        ////////////////////////////////// Enterprise /////////////////////////////

        public async Task<IActionResult> EditEnterprise(int? id = 1)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owner = await _context.Owner.FindAsync(id);
            if (owner == null)
            {
                return NotFound();
            }
            return View(owner);
        }

        // POST: Enterprise/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEnterprise([Bind("Id,Name,Title,Telephone,Mobile,Email,Commercial,NumberVat,Logo,File")] Owner owner, string oldLogo, int id)
        {
            if (id != owner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (owner.File != null)
                {
                    try
                    {
                        string fileExtension = Path.GetExtension(owner.File.FileName);
                        if (System.IO.File.Exists(_env.WebRootPath + "/Dashboard/img/" + oldLogo))
                        {
                            System.IO.File.Delete(_env.WebRootPath + "/Dashboard/img/" + oldLogo);
                        }
                        owner.Logo = await UploadedFileAsync(owner.File, fileExtension);
                        owner.Id = 1;
                        _context.Update(owner);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!OwnerExists(owner.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Dashboard");
            }
            return View(owner);
        }

        ////////////////////////////////// Tax /////////////////////////////
        public async Task<IActionResult> Tax()
        {
            return View(await _context.VatTable.ToListAsync());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Tax([Bind("VatRate")] VatTable vatTable)
        {
            if (vatTable.VatRate == 0)
            {
                ModelState.AddModelError("TaxVatError", "الرجاء ادخال الضريبة");
                return View(await _context.VatTable.ToListAsync());
            }
            if (ModelState.IsValid)
            {
                _context.VatTable.Add(vatTable);
                await _context.SaveChangesAsync();
                return View(await _context.VatTable.ToListAsync());
            }
            return View(vatTable);
        }
        public async Task<IActionResult> DeleteTax(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vatTable = await _context.VatTable
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vatTable == null)
            {
                return NotFound();
            }
            _context.VatTable.Remove(vatTable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Tax));

        }
        public async Task<IActionResult> EditTax(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Vat = await _context.VatTable.FindAsync(id);
            if (Vat == null)
            {
                return NotFound();
            }
            return View(Vat);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTax([Bind("Id, VatRate")]VatTable vatTable, int? id)
        {
            if (id != vatTable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vatTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OwnerExists(vatTable.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Tax");
            }
            return View(vatTable);
        }

        ////////////////////////////////// Tax /////////////////////////////



        ////////////////////////////////// Category /////////////////////////////
        // GET: Enterprise
        public async Task<IActionResult> Category()
        {
            return View(await _context.Categories.ToListAsync());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Category([Bind("CategoryName")] Categories categories)
        {
            if (categories.CategoryName == null)
            {
                ModelState.AddModelError("CategoryNameError", "الرجاء ادخال نوع الفئة");
                return View(await _context.Categories.ToListAsync());
            }
            if (ModelState.IsValid)
            {
                _context.Categories.Add(categories);
                await _context.SaveChangesAsync();
                return View(await _context.Categories.ToListAsync());
            }
            return View(categories);
        }
        public async Task<IActionResult> DeleteCategory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Category == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(Category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Category));

        }

        public async Task<IActionResult> EditCategory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Category = await _context.Categories.FindAsync(id);
            if (Category == null)
            {
                return NotFound();
            }
            return View(Category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategory([Bind("Id, CategoryName")]Categories Category, int? id)
        {
            if (id != Category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OwnerExists(Category.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Category");
            }
            return View(Category);
        }
        ////////////////////////////////// Category /////////////////////////////

        
        

        ////////////////// To Loade Image  /////////////////////////////
        private async Task<string> UploadedFileAsync(IFormFile File, string fileExtension)
        {
            if (File != null)
            {
                string fullFileName = "Logo" + fileExtension;
                string pathWithName = Path.Combine(_env.WebRootPath + "/Dashboard/img/" + fullFileName);
                using (var fileStream = new FileStream(pathWithName, FileMode.Create))
                {
                    await File.CopyToAsync(fileStream);
                }
                return fullFileName;
            }
            return null;

        }
        ////////////////////////////////// Enterprise /////////////////////////////
        // GET: Enterprise/Delete/5
        //    public async Task<IActionResult> Delete(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var owner = await _context.Owner
        //            .FirstOrDefaultAsync(m => m.Id == id);
        //        if (owner == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(owner);
        //    }

        //    // POST: Enterprise/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> DeleteConfirmed(int id)
        //    {
        //        var owner = await _context.Owner.FindAsync(id);
        //        _context.Owner.Remove(owner);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        private bool OwnerExists(int id)
        {
            return _context.Owner.Any(e => e.Id == id);
        }
    }
}
