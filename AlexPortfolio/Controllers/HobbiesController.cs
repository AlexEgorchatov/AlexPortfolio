using AlexPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlexPortfolio.Controllers
{
    public class HobbiesController : Controller
    {
        // GET: Hobbies
        public ActionResult Hobbies()
        {
            return View(new MasterViewModel(MenuType.Hobbies, Request.IsAuthenticated, HttpContext.User));
        }
    }
}