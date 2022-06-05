using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chatApplication.Data;
using chatApplication.Models;
using chatApplication.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using chatApplication.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using chatApplication.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace chatApplication.Api
{
    [Route("api/[controller]")]
    [ApiController]


    public class userController : ControllerBase
    {
        ApplicationDbContext db;
        private readonly UserManager<myUser> _userManager;
        private readonly SignInManager<myUser> _signInManager;
        private readonly SigInManager _authService;
        private readonly JWT _jwt;


        public userController(ApplicationDbContext context, UserManager<myUser> userManager, SignInManager<myUser> signInManager, SigInManager authservice, IOptions<JWT> jwt)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            db = context;
            _authService = authservice;
            _jwt = jwt.Value;


        }



        [HttpPost("TryMe")]
        [Authorize]
        public  JsonResult TryMeAsync()
        {
            var u = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user =  _userManager.Users.FirstOrDefault(p => p.PhoneNumber == u);
            _userManager.CreateSecurityTokenAsync(user);
            return new JsonResult(user);
        }

        


        public JsonResult Error(string message)
        {
            return new JsonResult(new Exception(message));
        }



        public JsonResult Success(string message)
        {
            return new JsonResult(new Exception(message));
        }


        public void IndexSignIn(string message)
        {
            
        }
        //Function TO Get Current User Information
        [HttpGet("CurrentUser")]
        [Authorize]
        public JsonResult CurrentUser()
        {
            var phoneNumber = User.FindFirstValue(ClaimTypes.NameIdentifier);
            myUser user = _userManager.Users.FirstOrDefault(p => p.PhoneNumber == phoneNumber);

            return new JsonResult(user);
        }

        //Functio To Create Account User
        [HttpPost("CreateUser")]
        public async Task<AuthModel> RegisterAsync([FromBody] VM_CreateUser user)
        {
            if (ModelState.IsValid)
            {

                var result = await _authService.RegisterAsync(user);
                if(result.Message == null)
                {
                    return result;
                }
                else
                {
                    
                }
                return result;

            }
            return new AuthModel {Message = "حدث خطاء في عملية الإدخال"};

        }

        //Function To SignIn The User
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] TokenRequestModel model)
        {
            if (!ModelState.IsValid)
                return Ok(model);
            var result = await _authService.GetTokenAsync(model);
            if (!result.IsAuthenticated)
                return Ok(result);
            return Ok(result);
        }


        //Function To Get User All Information
        [Authorize]
        [HttpGet("GetUserInformation")]
        public async Task<JsonResult> GetUserInformation(string id)
        {
            
            try
            {
                if (id == null)
                {
                    return Error("هاذا المستخدم غير موجود");
                }
                myUser user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return Error("هاذا المستخدم غير موجود");
                }
                return new JsonResult(user);
            }
            catch
            {
                return Error("خطاء  غير متوقع");
            }

        }




        




        ////FUnction To The Name && If He SignIn
        //[HttpGet("CurrentUser")]
        //public JsonResult CurrentUser()
        //{

        //    var Identity = new
        //    {
        //        name = User.Identity.Name,
        //        IsAuthenticated = User.Identity.IsAuthenticated
        //    };
        //    return new JsonResult(Identity);
        //}


        [Authorize]
        [HttpGet("SignOut")]
        public async Task<bool> SignOut()
        {
            HttpContext.Session.Clear();
            await _signInManager.SignOutAsync();
            return true;
        }




        //Function To Update The User Information
        [Authorize]
        [HttpPut("UpdateUser")]
        public async Task<JsonResult> UpdateUser([Bind("Name, PhoneNumber, BranchID, Address, Password")] VM_CreateUser vm_user, string id)
        {
            IdentityResult result = new IdentityResult();
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return Error("المستخدم غير موجود");
                }
                user.Address = vm_user.Address;
                user.UserName = vm_user.Name;
                user.BranchId = vm_user.BranchID;
                user.PhoneNumber = vm_user.PhoneNumber;
                await _userManager.RemovePasswordAsync(user);
                await _userManager.AddPasswordAsync(user, vm_user.Password);


                result = await _userManager.UpdateAsync(user);
                return new JsonResult(result);

            }
            return new JsonResult("كلمة المرور يجب أن تتكون من 5 أحرف على الأقل");
                


        }




        //Function To Delete The User 
        [Authorize]
        [HttpDelete("DeleteUser")]
        public async Task<JsonResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if(user == null)
            {
               return Error("المستخدم غير موجود");

            }
            await _signInManager.SignOutAsync();
            await _userManager.DeleteAsync(user);
            return Success("تم الحذف بنجاح");
        }
    }
    

      
}