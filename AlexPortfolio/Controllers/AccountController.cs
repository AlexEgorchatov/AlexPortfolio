using System;
using System.Collections.Generic;
using System.Dynamic;
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
using Newtonsoft.Json;

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

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<JsonResult> Login(LoginViewModel loginInfo)
        {
            dynamic respond = new ExpandoObject();

            if (!ModelState.IsValid)
            {
                respond.result = "error";
                var errors = new List<dynamic>();

                foreach (var key in ModelState.Keys.Where(i => ModelState[i].Errors.Any()))
                {
                    errors.Add(new
                    {
                        source = key.Split('.')[1].ToLower(),
                        message = ModelState[key].Errors.First().ErrorMessage
                    });
                }

                respond.errors = errors;
                respond.url = Request.UrlReferrer;

                return Json(JsonConvert.SerializeObject(respond));
            }

            //string email = "vit.ganchuk@gmail.com ";
            var result = await SignInManager.PasswordSignInAsync("Alex", loginInfo.Password, loginInfo.RememberMe, shouldLockout: false);

            switch (result)
            {
                case SignInStatus.Success:
                    respond.result = "success";
                    respond.errors = new List<dynamic>();
                    respond.url = Request.UrlReferrer;
                    break;

                case SignInStatus.LockedOut:
                    respond.result = "error";
                    respond.errors = new List<dynamic>() { new
                    {
                        source = "password",
                        message = "Something goes wrong, try later please",
                    } };
                    respond.url = Request.UrlReferrer;
                    break;

                case SignInStatus.RequiresVerification:
                    respond.result = "error";
                    respond.errors = new List<dynamic>() { new
                    {
                        source = "password",
                        message = "Verification required",
                    } };
                    respond.url = Request.UrlReferrer;
                    break;

                case SignInStatus.Failure:
                    respond.result = "error";
                    respond.errors = new List<dynamic>() { new
                    {
                        source = "password",
                        message = "The password is incorrect",
                    } };
                    respond.url = Request.UrlReferrer;
                    break;

                default:
                    respond.result = "error";
                    respond.errors = new List<dynamic>() { new
                    {
                        source = "password",
                        message = "Something goes wrong, try later please",
                    } };
                    respond.url = Request.UrlReferrer;
                    break;
            }

            return Json(JsonConvert.SerializeObject(respond));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<JsonResult> Register(RegisterViewModel registerInfo)
        {
            dynamic respond = new ExpandoObject();

            if (!ModelState.IsValid)
            {
                respond.result = "error";
                var errors = new List<dynamic>();

                foreach (var key in ModelState.Keys.Where(i => ModelState[i].Errors.Any()))
                {
                    errors.Add(new
                    {
                        source = key.Split('.')[1].ToLower(),
                        message = ModelState[key].Errors.First().ErrorMessage
                    });
                }

                respond.errors = errors;
                respond.url = Request.UrlReferrer;

                return Json(JsonConvert.SerializeObject(respond));
            }

            var user = new ApplicationUser { UserName = "Alex", Email = registerInfo.Email };
            var result = await UserManager.CreateAsync(user, registerInfo.Password);

            if (result.Succeeded)
            {
                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                respond.result = "success";
                respond.errors = new List<dynamic>();
                respond.url = Request.UrlReferrer;

                return Json(JsonConvert.SerializeObject(respond));
            }
            else
            {
                respond.result = "error";
                respond.errors = new List<dynamic>() { new
                {
                    source = "signin",
                    message = result.Errors.FirstOrDefault()
                } };
                respond.url = Request.UrlReferrer;

                return Json(JsonConvert.SerializeObject(respond));
            }
        }

        [HttpPost]
        public JsonResult SignOut()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            dynamic respond = new ExpandoObject();
            respond.result = "success";
            respond.url = Request.UrlReferrer;

            return Json(JsonConvert.SerializeObject(respond));
        }
    }
}