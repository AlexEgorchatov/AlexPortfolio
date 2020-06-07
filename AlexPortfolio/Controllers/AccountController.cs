using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Xml.XPath;
using AlexPortfolio.Models;
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

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { });
            }

            string email = "alex.exorchatov@gmail.com";

            var result = await SignInManager.PasswordSignInAsync(email, model.Password, model.RememberMe, shouldLockout: false);
            //switch (result)
            //{
            //    case SignInStatus.Success:
            //        break;

            //    case SignInStatus.LockedOut:
            //        break;

            //    case SignInStatus.RequiresVerification:
            //        break;

            //    case SignInStatus.Failure:
            //        break;

            //    default:
            //        ModelState.AddModelError("", "Ivalid login attempt");
            //        return View(model);
            //}

            return Json(new { });
        }

        //[HttpPost]
        //public Task<JsonResult> Login(LoginViewModel model)
        //{
        //    return Json(new { message = "Okay!"});
        //}

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
    }
}