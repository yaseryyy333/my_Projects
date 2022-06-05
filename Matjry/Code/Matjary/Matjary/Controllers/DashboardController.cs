using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Matjary.Models;
using Matjary.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Matjary.Controllers
{
    [Authorize(Roles ="Admin,Employee")]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _hosting;

        public DashboardController(ApplicationDbContext context , UserManager<ApplicationUser> userManager,IWebHostEnvironment hosting)
        {
            _context = context;
            _userManager = userManager;
            _hosting = hosting;
        }

        // GET: text
        public async Task<IActionResult> Index(string date = "ThisMoth")
        {
            //============================ the New Order && the Priduct that most sell && the Product that almost Finsh ===================================\\

            TempData["Order"] = await _context.Order.Include(m => m.ApplicationUser).OrderByDescending(id => id.Id).ToListAsync();
            TempData["StoreFinsh"] = await _context.Store.Include(m => m.Product).Where(q => q.Qty <= 10).ToListAsync();

            var listId = await _context.Products.Select(x => x.Id).ToListAsync();
            List<theSum> theBeast = new List<theSum>();
            foreach (var id in listId)
            {
                theSum sumObject = new theSum();
                sumObject.id = id;
                sumObject.sellQty = _context.InvoicesProducts.Where(x => x.ProductId == id).Sum(x => x.Qty);
                sumObject.sellPrice = _context.InvoicesProducts.Where(x => x.ProductId == id).Sum(x => x.SellPrice);
                var nameProduct = await _context.Products.Where(x => x.Id == id).Select(x => x.Name).ToListAsync();
                sumObject.nameProduct = nameProduct[0];
                theBeast.Add(sumObject);
            }
            TempData["theBeasteSell"] = theBeast.OrderByDescending(k => k.sellQty);
            //============================ the New Order && the Priduct that most sell && the Product that almost Finsh ===================================\\
            var thisMonth = DateTime.Now.AddDays(-DateTime.Now.Day + 1);
            var previousMonth = DateTime.Now.AddMonths(-1).AddDays(-DateTime.Now.Day + 1);
            var thisDay = DateTime.Now;
            switch (date)
            {
                case "ThisMoth":
                    //============================ This Month ===================================\\

                    var thisMonthPurchaseInvoice = await _context.Invoices.Where(c => c.Date.Date <= thisDay.Date && c.Date.Date >= thisMonth.Date && c.Invoice_Type.Equals("مشتريات ")).ToListAsync();
                    var thisMonthSalesInvoice = await _context.Invoices.Where(c => c.Date.Date <= thisDay.Date && c.Date.Date >= thisMonth.Date && c.Invoice_Type.Equals("مبيعات ")).ToListAsync();
                    var thisMonthOrder = await _context.Order.Where(c => c.Date.Date <= thisDay.Date && c.Date.Date >= thisMonth.Date).ToListAsync();
                    var thisMonthQuotations = await _context.Quotations.Where(c => c.Date.Date <= thisDay.Date && c.Date.Date >= thisMonth.Date).ToListAsync();

                    // Total of purchase Invoices
                    double totalPurchase1 = 0;
                    foreach (var item in thisMonthPurchaseInvoice)
                    {
                        totalPurchase1 += item.Total;
                    }
                    TempData["totalPurchase"] = totalPurchase1;

                    // Total of Sales Invoices
                    double totalSales1 = 0;
                    foreach (var item in thisMonthSalesInvoice)
                    {
                        totalSales1 += item.Total;
                    }
                    TempData["totalSales"] = totalSales1;

                    // count of order Invoices
                    double countOrder1 = 0;
                    foreach (var item in thisMonthOrder)
                    {
                        countOrder1++;
                    }
                    TempData["countOrder"] = countOrder1;

                    // count of Quotations Invoices
                    double countQuotations1 = 0;
                    foreach (var item in thisMonthQuotations)
                    {
                        countQuotations1++;
                    }
                    TempData["countQuotations"] = countQuotations1;
                    //============================ This Month ===================================\\

                    break;
                //============================ Previous Month ===================================\\

                case "PreviousMonth":
                    var previousMonthPurchaseInvoice = await _context.Invoices.Where(c => c.Date.Date < thisMonth.Date && c.Date >= previousMonth.Date && c.Invoice_Type.Equals("مشتريات ")).ToListAsync();
                    var previousMonthSalesInvoice = await _context.Invoices.Where(c => c.Date.Date < thisMonth.Date && c.Date >= previousMonth.Date && c.Invoice_Type.Equals("مبيعات ")).ToListAsync();
                    var previousMonthOrder = await _context.Order.Where(c => c.Date.Date < thisMonth.Date && c.Date >= previousMonth.Date).ToListAsync();
                    var previousMonthQuotations = await _context.Quotations.Where(c => c.Date.Date < thisMonth.Date && c.Date >= previousMonth.Date).ToListAsync();


                    // Total of purchase Invoices
                    double totalPurchase2 = 0;
                    foreach (var item in previousMonthPurchaseInvoice)
                    {
                        totalPurchase2 += item.Total;
                    }
                    TempData["totalPurchase"] = totalPurchase2;

                    // Total of Sales Invoices
                    double totalSales2 = 0;
                    foreach (var item in previousMonthSalesInvoice)
                    {
                        totalSales2 += item.Total;
                    }
                    TempData["totalSales"] = totalSales2;

                    // count of order Invoices
                    double countOrder2 = 0;
                    foreach (var item in previousMonthOrder)
                    {
                        countOrder2++;
                    }
                    TempData["countOrder"] = countOrder2;

                    // count of Quotations Invoices
                    double countQuotations2 = 0;
                    foreach (var item in previousMonthQuotations)
                    {
                        countQuotations2++;
                    }
                    TempData["countQuotations"] = countQuotations2;
                    break;
                //============================ This Day ===================================\\

                case "ThisDay":

                    var ThisDayPurchaseInvoice = await _context.Invoices.Where(c => c.Date.Date == thisDay.Date && c.Invoice_Type.Equals("مشتريات ")).ToListAsync();
                    var ThisDaySalesInvoice = await _context.Invoices.Where(c => c.Date.Date == thisDay.Date && c.Invoice_Type.Equals("مبيعات ")).ToListAsync();
                    var ThisDayOrder = await _context.Order.Where(c => c.Date.Date == thisDay.Date).ToListAsync();
                    var ThisDayQuotations = await _context.Quotations.Where(c => c.Date.Date == thisDay.Date).ToListAsync();


                    // Total of purchase Invoices
                    double totalPurchase3 = 0;
                    foreach (var item in ThisDayPurchaseInvoice)
                    {
                        totalPurchase3 += item.Total;
                    }
                    TempData["totalPurchase"] = totalPurchase3;

                    // Total of Sales Invoices
                    double totalSales3 = 0;
                    foreach (var item in ThisDaySalesInvoice)
                    {
                        totalSales3 += item.Total;
                    }
                    TempData["totalSales"] = totalSales3;

                    // count of order Invoices
                    double countOrder3 = 0;
                    foreach (var item in ThisDayOrder)
                    {
                        countOrder3++;
                    }
                    TempData["countOrder"] = countOrder3;

                    // count of Quotations Invoices
                    double countQuotations3 = 0;
                    foreach (var item in ThisDayQuotations)
                    {
                        countQuotations3++;
                    }
                    TempData["countQuotations"] = countQuotations3;
                    break;
                    //============================ This Day ===================================\\

            }






            return View();
        }

        public ActionResult EditUser()
        {
            string id = _userManager.GetUserId(User);
            var user = _context.Users.Where(x => x.Id == id).SingleOrDefault();
            return View(user);
        }

        [HttpPost]
        public async Task<ActionResult> EditUserAsync(ApplicationUser user,string password)
        {
            //string id = _userManager.GetUserId(User);
            //var oldUser = _userManager.Users.Where(x => x.Id == id).SingleOrDefault();
            if (ModelState.IsValid)
            {
                if(user.File != null)
                {
                    string UsersFolder = Path.Combine(_hosting.WebRootPath, "Dashboard\\img\\Users");
                    string[] fileList = user.File.FileName.Split('.');
                    string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + '.' + fileList[1];
                    string fullPath = Path.Combine(UsersFolder, fileName);
                    using (var streem = new FileStream(fullPath, FileMode.Create))
                    {
                        user.File.CopyTo(streem);
                    }
                    if(user.Photo != null)
                    {
                        if (System.IO.File.Exists(_hosting.WebRootPath + "/Dashboard/img/Users/" + user.Photo))
                        {
                            System.IO.File.Delete(_hosting.WebRootPath + "/Dashboard/img/Users/" + user.Photo);
                        }
                    }
                    user.Photo = fileName;
                }
                //user.UserName = oldUser.UserName;
                //user.PasswordHash = oldUser.PasswordHash;
                //var result = await _userManager.UpdateAsync(user);
                //if (result.Succeeded)
                //{
                //    return RedirectToAction("Index");
                //}
                _context.Attach(user);
            }
            return View();
        }
        
    }
    public partial class theSum
    {
        public int id { get; set; }
        public double sellPrice { get; set; }
        public int sellQty { get; set; }
        public string nameProduct { get; set; }

    }
}
