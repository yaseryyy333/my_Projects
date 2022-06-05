using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Matjary.Models;
using PagedList.Core;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Matjary.Data;
using Microsoft.AspNetCore.Authorization;

namespace Matjary.Controllers
{
    [Authorize(Roles = "Admin,Employee")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hosting;

        public ProductsController(ApplicationDbContext context, IWebHostEnvironment hosting)
        {
            _context = context;
            _hosting = hosting;
        }

        // GET: Products
        public IActionResult Index(int? page)
        {
            var projectContext = _context.Products.Include(p => p.Store);
            return View(projectContext.ToPagedList(page ?? 1, 10));
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .Include(p => p.Category)
                .Include(p=>p.Store)
                .Include(p=>p.ProductPhoto)
                .Include(p => p.ProductPersons).ThenInclude(p=>p.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "CategoryName");
            List<Persons> mySuppliers = _context.Persons.Where(x => x.Type == Persons.accountType.مورد).ToList();
            List<SelectListItem> suppliers = mySuppliers.ConvertAll(a => {
                return new SelectListItem() {
                    Text = a.Name,
                    Value = a.Id.ToString(),
                    Selected = false
                };
            });
            ViewData["Suppliers"] = suppliers;
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Sku,Name,Cost,SellPrice,Description,DiscountRate,CategoryId,Files,Store,PersonIds")] Products products)
        {
            if (ModelState.IsValid)
            {
                // to add supplier to the product .. 
                for(int i = 0; i<products.PersonIds.Count; i++)
                {
                    int id = products.PersonIds[i];
                    ProductPersons p = new ProductPersons();
                    p.PersonId = id;
                    products.Per_list.Add(p);
                }
                products.ProductPersons = products.Per_list;
                // to add product photo to our project .. 
                if(products.Files.Count > 0)
                {
                    string productFolder = Path.Combine(_hosting.WebRootPath, "Dashboard\\img\\products");
                    for (int x = 0; x<products.Files.Count; x++)
                    {
                        string [] fileList = products.Files[x].FileName.Split('.');
                        string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + '.' + fileList[1];
                        string fullPath = Path.Combine(productFolder, fileName);
                        await using(var streem = new FileStream(fullPath, FileMode.Create))
                        {
                            products.Files[x].CopyTo(streem);
                        }
                        // create ProductPhoto object and insert it to the list 
                        ProductPhoto photo = new ProductPhoto();
                        photo.Photo = fileName;
                        products.Photo_list.Add(photo);
                    }
                }
                products.ProductPhoto = products.Photo_list;
                _context.Add(products);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", products.CategoryId);
            List<Persons> mySuppliers = _context.Persons.Where(x => x.Type == Persons.accountType.مورد).ToList();
            List<SelectListItem> suppliers = mySuppliers.ConvertAll(a => {
                return new SelectListItem()
                {
                    Text = a.Name,
                    Value = a.Id.ToString(),
                    Selected = false
                };
            });
            ViewData["Suppliers"] = suppliers;
            return View(products);
        }

        // GET: Products/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = _context.Products.Where(x => x.Id == id)
                .Include(x => x.Store)
                .Include(x => x.ProductPersons).ThenInclude(p => p.Person)
                .SingleOrDefault();
            List<int> assigned_supplier = products.ProductPersons.Select(x => x.PersonId).ToList();
            if (products == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "CategoryName");
            // here must be edit the type .. 
            List<Persons> allSuppliers = _context.Persons.Where(x => x.Type == Persons.accountType.مورد).ToList();
            for (int i = 0; i < assigned_supplier.Count; i++)
            {
                var myAssignSupplier = allSuppliers.Find(x => x.Id == assigned_supplier[i]);
                allSuppliers.Remove(myAssignSupplier);
            }
            List<SelectListItem> suppliers = allSuppliers.ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.Name,
                    Value = a.Id.ToString(),
                    Selected = false
                };
            });
            ViewData["Suppliers"] = suppliers;
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Sku,Name,Cost,SellPrice,Description,DiscountRate,CategoryId,Store,PersonIds")] Products products)
        {
            if (id != products.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if(products.PersonIds != null)
                    {
                        // to add supplier to the product .. 
                        for (int i = 0; i < products.PersonIds.Count; i++)
                        {
                            int pid = products.PersonIds[i];
                            ProductPersons p = new ProductPersons();
                            p.PersonId = pid;
                            products.Per_list.Add(p);
                        }
                        products.ProductPersons = products.Per_list;
                    }
                    products.Store.Id = _context.Products.Where(x => x.Id == id).Select(x => x.Store.Id).SingleOrDefault();
                    _context.Update(products);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsExists(products.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", products.CategoryId);
            return View(products);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var products = await _context.Products.FindAsync(id);
            // First Delete all files related with this product 
            if(products != null)
            {
                products = _context.Products.Where(x => x.Id == id).Include(x => x.ProductPhoto).FirstOrDefault();
                List<string> photos = new List<string>();
                if (products.ProductPhoto.Count > 0)
                {
                    foreach (var photo in products.ProductPhoto)
                    {
                        photos.Add(photo.Photo);
                    }
                    for(int i=0; i<photos.Count; i++)
                    {
                        if (System.IO.File.Exists(_hosting.WebRootPath + "/Dashboard/img/products/" + photos[i]))
                        {
                            System.IO.File.Delete(_hosting.WebRootPath + "/Dashboard/img/products/" + photos[i]);
                        }
                    }
                }
            }

            _context.Products.Remove(products);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

        [HttpPost]
        public ActionResult Search(string type,string value,int? page)
        {
            switch (type)
            {
                case "name":
                    return View(_context.Products.Where(x => x.Name.Contains(value)).ToPagedList(page ?? 1, 10));
                case "sku":
                    return View(_context.Products.Where(x => x.Sku.Contains(value)).ToPagedList(page ?? 1, 10));
                default:
                    return RedirectToAction("Index");
            }
        }
    }
}
