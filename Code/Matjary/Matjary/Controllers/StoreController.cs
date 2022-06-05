using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Matjary.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Matjary.Controllers.handle_session_objects;//To use  [GetComplexData] & [SetComplexData]
using Microsoft.AspNetCore.Mvc.Rendering;
using PagedList;
using PagedList.Core;
using Matjary.Data;
using static Matjary.Models.Address;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Matjary.Controllers
{
    public class StoreController : Controller
    {


        static int ids;
        static string se;
        List<Address> addresses;

        // GET: Store
        private readonly ApplicationDbContext _storeContext;

        private readonly IHostingEnvironment hosting;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public StoreController(ApplicationDbContext context, IHostingEnvironment hosting,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _storeContext = context;
            this.hosting = hosting;

        }
        public async Task<IActionResult> HomePage()
        {
            ViewData["Category"] = _storeContext.Categories.ToList();

            var projectContext = _storeContext.Products.Include(p => p.ProductPhoto);


            return View(projectContext.ToList());

        }

        public async Task<IActionResult> Category(int? id)
        {
            ViewData["Category"] = _storeContext.Categories.ToList();

            if (id == null)
            {
                return NotFound();
            }

            Categories Category = await _storeContext.Categories
                .Include(c => c.Products).ThenInclude(p => p.ProductPhoto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Category == null)
            {
                return NotFound();
            }
            return View(Category);
        }

        // GET: Store/Create


        public async Task<IActionResult> DisplayProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var DisplayProduct = await _storeContext.Products
                .Include(p => p.ProductPhoto).Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            var RelatedProduct = _storeContext.Products.Where(p => p.CategoryId == DisplayProduct.CategoryId)
                .Include(p => p.ProductPhoto).ToList();

            ViewBag.RelatedProduct = RelatedProduct;
            ViewBag.getProduct = DisplayProduct;

            if (DisplayProduct == null)
            {
                return NotFound();
            }
            return View();
        }
        //SessionManagment Delete and Add
        public async Task<IActionResult> SessionManagment(int id, bool delete)
        {
            if (delete == true)
            {
                List<Products> GetSession = HttpContext.Session.GetComplexData<List<Products>>("Products");
                for (int i = 0; i < GetSession.Count(); i++)
                {
                    if (GetSession[i].Id == id)
                    {
                        GetSession.RemoveAt(i);
                        break;
                    }
                }
                HttpContext.Session.SetComplexData("Products", GetSession);
                return View();
            }
            else
            {

                List<Products> GetSession = HttpContext.Session.GetComplexData<List<Products>>("Products");
                var findProduct = await _storeContext.Products.FindAsync(id);
                if (GetSession == null)
                {
                    GetSession = new List<Products>();
                    GetSession.Add(findProduct);
                    HttpContext.Session.SetComplexData("Products", GetSession);
                    return View();
                }
                else
                {
                    for (int i = 0; i < GetSession.Count(); i++)
                    {
                        if (GetSession[i].Id == id)
                        {

                            break;
                        }
                        else
                        {
                            GetSession.Add(findProduct);
                            HttpContext.Session.SetComplexData("Products", GetSession);
                            return View();
                        }

                    }
                    return View();

                }
            }
        }

        public IActionResult ShoppingCart()
        {

            ViewBag.photo = _storeContext.Products.Include(p => p.ProductPhoto).ToList();

            return View();
        }

        public IActionResult ShoppingCartAddPaymentPhoto(List<OrderProduct> op)
        {
            var vatlist = _storeContext.VatTable.ToList();
            double vat = 0;

            if (op.Count() == 0 )
            {


                return NotFound();

            }
            else
            {
                if(vatlist.Count() != 0) {
                    vat = _storeContext.VatTable.FirstOrDefault().VatRate;
                }
               

                foreach (var item in op)
                {

                    item.Total = (item.SellPrice * item.Qty);
                    item.Total_Vat = ((item.Total * vat) / 100) + item.Total;

                }
                HttpContext.Session.SetComplexData("ordersp", op);
                return View();
            }
            return View();
        }
        [HttpPost]
        public IActionResult ShoppingCartAddPaymentPhoto(IFormFile photo)
        {
            var filename = string.Empty;
            if (photo != null)
            {

                string upload = Path.Combine(hosting.WebRootPath, "Dashboard", "img", "sanad");
                filename = photo.FileName;
                string fullpath = Path.Combine(upload, filename);
                photo.CopyTo(new FileStream(fullpath, FileMode.Create));
                HttpContext.Session.SetString("photoName", filename);
            }
            else
            {

                return NotFound();

            }
            return View();

        }
        [Authorize(Roles = "Admin,Employee,Customer")]
        public ActionResult Address()
        {
            string uid = _userManager.GetUserId(User);
            List<OrderProduct> OrderProducts = HttpContext.Session.GetComplexData<List<OrderProduct>>("ordersp");
            if (OrderProducts == null) { RedirectToAction("HomePage"); }
            else
            {
                ViewData["City"] = new SelectList(_storeContext.Address.Where(a => a.UserId == uid), "Id", "City");
                // var add = _storeContext.Address.Where(a => a.UserId == 1).ToList();
                return View();
            }
            return RedirectToAction("HomePage");
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Employee,Customer")]
        public async Task<ActionResult> ComplateOrder(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            string uid = _userManager.GetUserId(User);
            Address Address = await _storeContext.Address.FindAsync(id);
            string City = Address.City;
            string Street = Address.Street;
            double Total = 0;
            double TotalWithVat = 0;
            double TotalDis = 0;
            double TotalCost = 0;
            string photo = HttpContext.Session.GetString("photoName");
            List<OrderProduct> OrderProducts = HttpContext.Session.GetComplexData<List<OrderProduct>>("ordersp");
            foreach (var item in OrderProducts)
            {
                Total += item.Total;
                TotalWithVat += item.Total_Vat;
                TotalDis += item.Discount;
                TotalCost += (item.Cost * item.Qty);
            }


            Order Order = new Order
            {

                Address = City + "/" + Street,
                Date = DateTime.Now,
                PaymentPhoto = photo,
                Status = "لم يتم التسليم",
                Total = Total,
                TotalVat = TotalWithVat,
                UserId = uid,
                TotalCost = TotalCost,
                TotalDiscount = TotalDis,
                OrderProducts = OrderProducts


            };
            if (ModelState.IsValid)
            {
                try
                {
                    _storeContext.Add(Order);
                    await _storeContext.SaveChangesAsync();
                    HttpContext.Session.Clear();
                    return View();
                }
                catch (DbUpdateConcurrencyException)
                {

                    return NotFound();
                }

            }
            return View();

        }

        // var add = _storeContext.Address.Where(a => a.UserId == 1).ToList();


        [Authorize(Roles = "Admin,Employee,Customer")]
        public ActionResult UserInfo()
        {
            
            string id = _userManager.GetUserId(User);
            var U = _storeContext.Users.Where(u=>u.Id==id).FirstOrDefault();
            ViewBag.us = U;
            return View();
        }
        [Authorize(Roles = "Admin,Employee,Customer")]
        public ActionResult EditUser()
        {
            string id = _userManager.GetUserId(User);
            var U = _storeContext.Users.Where(u => u.Id == id).FirstOrDefault();
            return View(U);
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Employee,Customer")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditUser(ApplicationUser users)
        {

            if (ModelState.IsValid)
            {

                _storeContext.Update(users);
                await _storeContext.SaveChangesAsync();
                return RedirectToAction(nameof(UserInfo));


            }
            return View(users);
        }

        // GET: Store/Delete/5
        [Authorize(Roles = "Admin,Employee,Customer")]
        public ActionResult ListMyOrders(int? page)
        {
            string id = _userManager.GetUserId(User);
            var Orders = _storeContext.Order.Where(o=>o.UserId==id)
                .Include(order => order.OrderProducts);

            return View(Orders.ToPagedList(page ?? 1, 2));
        }
        public ActionResult Orders(int iD, int? page = 1)
        {


            if (page == 1)
            {
                if (iD == 0)
                {
                    iD = ids;
                }
                ids = iD;//1

            }
            else
            {
                iD = ids;



            }


            var OrderProduct = _storeContext.OrderProduct.Where(i => i.OrderId == iD)
               .Include(op => op.Product)
                .ThenInclude(p => p.ProductPhoto).ToPagedList(page ?? 1, 10);
            return View(OrderProduct);
        }


        [Authorize(Roles = "Admin,Employee,Customer")]
        public ActionResult MyAddress()
        {
            string uid = _userManager.GetUserId(User);
            
            ViewData["address"] = _storeContext.Address.Where(a=>a.UserId== uid).ToList();

            addresses = new List<Address>()
            {
                new Address
                {
                    City="المكلا"
                },
                new Address
                {
                    City="عدن"
                },
                new Address
                {
                    City="شبوة"
                },
                new Address
                {
                    City="الغيضة"
                },
                new Address
                {
                    City="صنعاء"
                },
                new Address
                {
                    City="الشحر"
                },
                new Address
                {
                    City="سيئون"
                },
            };
            ViewData["add"] = addresses;

            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Employee,Customer")]
        [ValidateAntiForgeryToken]
        public ActionResult MyAddress(Address Newaddress)
        {
            string uid = _userManager.GetUserId(User);
            Newaddress.UserId = uid;

            if (ModelState.IsValid)
            {
                foreach (Address ad in _storeContext.Address)
                {
                    if (ad.City == Newaddress.City)
                    {
                        _storeContext.Address.Remove(ad);
                    }
                }

                _storeContext.Address.Add(Newaddress);
                _storeContext.SaveChanges();

                return RedirectToAction(nameof(MyAddress));

            }

            return View(Newaddress);
        }
        //display products of any order






        public ActionResult ResultSearch(int id, string search)
        {



          
            var myProduct = _storeContext.Products.Where(p => p.Name.Contains(search) && p.CategoryId == id)
              .Include(p => p.ProductPhoto).ToList();

            ViewBag.search = search;
            return View(myProduct);
        }

        public ActionResult About()
        {
            return View();
        }


    }




}