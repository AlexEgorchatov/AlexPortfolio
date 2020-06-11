using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Xml.XPath;
using AlexPortfolio.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace AlexPortfolio.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().Get<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<JsonResult> Login(LoginViewModel loginInfo)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { result = "error", message = "Please enter the password", url = Request.UrlReferrer });
            }

            string email = "alex.exorchatov@gmail.com";
            var result = await SignInManager.PasswordSignInAsync(email, loginInfo.Password, loginInfo.RememberMe, shouldLockout: false);

            switch (result)
            {
                case SignInStatus.Success:
                    return Json(new { result = "success", message = "Welcome back, Alex", url = Request.UrlReferrer });

                case SignInStatus.LockedOut:
                    return Json(new { result = "failure", message = "Something goes wrong, try later please", url = Request.UrlReferrer });

                case SignInStatus.RequiresVerification:
                    return Json(new { result = "failure", message = "Verification required", url = Request.UrlReferrer });

                case SignInStatus.Failure:
                    return Json(new { result = "failure", message = "The password is incorrect", url = Request.UrlReferrer });

                default:
                    return Json(new { result = "failure", message = "Something goes wrong, try again later", url = Request.UrlReferrer });
            }
        }

        //[HttpPost]
        //[AllowAnonymous]
        //public async Task<JsonResult> Register(RegisterViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Json(new { result = "error", message = "Something is wrong", url = Request.UrlReferrer });
        //    }

        //    var user = new ApplicationUser { UserName = "Alex", Email = model.Email };
        //    var result = await UserManager.CreateAsync(user, model.Password);

        //    if (result.Succeeded)
        //    {
        //        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
        //    }
        //    else
        //    {

        //    }
        //}
    }
}