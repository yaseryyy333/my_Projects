using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using chatApplication.Models;
using System.Web;
using Microsoft.AspNetCore.Http;
using chatApplication.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using chatApplication.ViewModels;
using chatApplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace chatApplication.Controllers
{
    public class HomeController : Controller 
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<myUser> _userManager;
        private readonly SignInManager<myUser> _signInManager;
        private readonly RoleManager<myRoles> _roleManager;
        private readonly SigInManager _authService;
        ApplicationDbContext _db;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db, UserManager<myUser> userManager, SignInManager<myUser> signInManager, SigInManager authService, RoleManager<myRoles> roleManager)
        {
            this._db = db;
            this._userManager = userManager;
            this._logger = logger;
            this._signInManager = signInManager;
            this._authService = authService;
            this._roleManager = roleManager;
        }

       [HttpGet]
        public async Task<IActionResult> Index(string id)
        {
            ViewBag.isAuthenticated = false;
            ViewBag.id = "";

            if(id != null)
            {
                ViewBag.isAuthenticated = true;
                var user = await _userManager.FindByIdAsync(id);
                ViewBag.user = user;
                ViewBag.branchSelect = new List<SelectListItem>() as List<SelectListItem>;
                foreach (var branch in _db.Branches.ToList())
                {
                    ViewBag.branchSelect.Add(new SelectListItem { Text = branch.Name, Value = branch.Id.ToString() });
                }
            }
           

            return View();
        }


        public IActionResult login_register()
        {
            ViewBag.Branches =  _db.Branches.ToList();
            return View();
        }




        ///////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////
        ///                             Chat section
        ///////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////
        [HttpPost]
        public async Task<IActionResult> Chat(string id)
        {
            List<IndividualRoom> IndividualRoomes = new List<IndividualRoom>();
            List<myUser> myIndividualUsers = new List<myUser>(); 
            var user = await _userManager.FindByIdAsync(id); 
            var role = _userManager.GetRolesAsync(user).Result.FirstOrDefault();
            var userNotifications = getNotificationsAsync(role, user.Id).Result;
            var branch = await _db.Branches.ToListAsync();
            var mybranch = _db.Branches.Find(user.BranchId);
            List<Room> personRooms = GetPersonRoom(id, role).Result;
            if(role == "ADMIN")
            {
                IndividualRoomes = await _db.IndividualRooms.ToListAsync();
                myIndividualUsers = await _userManager.Users.Where(u => u.Id != user.Id).Include(b=> b.Branch).Where(b=>b.BranchId == user.BranchId).ToListAsync();
            }

            ViewBag.user = user;
            ViewBag.role = role;
            ViewBag.userNotifications = userNotifications;
            ViewBag.branch = branch;
            ViewBag.mybranch = mybranch;
            ViewBag.rooms = personRooms;


            return View();
        }










        /// //////////////////////////////////////////////////////////////////////////////
        /// //////////////////////////////////////////////////////////////////////////////
        /// //////////////////////////////////////////////////////////////////////////////
        /// //////////////////////////// Function Helpers ////////////////////////////////
        /// //////////////////////////////////////////////////////////////////////////////
        /// //////////////////////////////////////////////////////////////////////////////
        /// //////////////////////////////////////////////////////////////////////////////
        
        // Function To get Rooms
        

        // Function To Get  User Notifications
        public async Task<List<UserNotification>> getNotificationsAsync(string role,string userId)
        {
            List<UserNotification> userNotifications = new List<UserNotification>();
            switch (role)
            {
                case "Customer":
                   return userNotifications =await _db.UserNotifications.Include(i => i.Notification).Where(x=>x.myUserId == userId).ToListAsync();
                case "ADMIN":
                    return userNotifications = await _db.UserNotifications.Include(i => i.Notification).ToListAsync();

                default:
                    //Groups
                    return userNotifications =await _db.UserNotifications.Where(i => i.myUserId == userId).Include(m => m.Notification).ToListAsync();
            }
        }

        public async Task<List<Room>> GetPersonRoom(string user_id, string role)
        {
            List<Room> personRoom = new List<Room>();
            switch (role)
            {
                case "Customer":
                    //Customer
                    personRoom = await _db.Rooms.Where(r => r.myUserId == user_id).Include(u => u.myRoles).ToListAsync();
                    break;
                case "ADMIN":
                    //Admin
                    personRoom = await _db.Rooms.ToListAsync();
                        break;
                default:
                    //Groups
                    personRoom =  _db.Rooms
                        .Include(u => u.myUser).Where(r=>r.myRoles.Name == role)
                        .Include(c => c.Chats)
                        .ToList();
                    foreach(Room room in personRoom)
                    {
                        room.Chats = room.Chats.OrderBy(c => c.Date).ToList();  
                    }
                    break;
            }

            return personRoom;
        }
    }
}
